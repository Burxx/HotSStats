Imports System.IO
Imports MpqLib.Mpq
Imports Heroes.ReplayParser
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Globalization
Imports System.Text.RegularExpressions
Imports System.ComponentModel

Public Class Form1

    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If My.Settings.Heroes Is Nothing Then
            My.Settings.Reset()
            My.Settings.Save()
            Settings.ShowDialog()

            'Exit Sub
        End If
        DD_GameType.SelectedIndex = 0
        DD_ChartInfo.SelectedIndex = 0
        DD_ChartType.SelectedIndex = 0
        DD_ChartData.SelectedIndex = 0
        My.Settings.Reload()
        If My.Settings.Heroes Is Nothing Then
            Settings.ShowDialog()
        End If
        LoadingComplete = True
    End Sub

    Sub updateReplay_(total As Integer, skipCounter As Integer)
        Me.Invoke(Sub()
                      Lb_ReplayCount.Text = ReplayList.Stats.Count.ToString + " / " + total.ToString + " Replays"
                      If skipCounter > 0 Then Lb_ReplayCount.Text += ", " + skipCounter.ToString + " skipped"
                      Dim TimeLeft As TimeSpan = TimeSpan.FromTicks(CLng((Now - ReplayList.TimeOfLastUpdate).Ticks * (total - ReplayList.Stats.Count) / ReplayList.Stats.Count))
                      Lb_ReplayCount.Text += "  Time left: " + TimeLeft.ToString("hh\:mm\:ss")
                      Lb_ReplayCount.Invalidate()
                      'Application.DoEvents()
        End Sub)
    End Sub


    Sub updateReplay(total As Integer, skipCounter As Integer)
        Lb_ReplayCount.Text = ReplayList.Stats.Count.ToString + " / " + total.ToString + " Replays"
        If skipCounter > 0 Then Lb_ReplayCount.Text += ", " + skipCounter.ToString + " skipped"
        Dim TimePassed As TimeSpan = Now - ReplayList.TimeOfLastUpdate
        Dim TimeLeft As TimeSpan = TimeSpan.FromTicks(CLng((TimePassed).Ticks * (total - ReplayList.Stats.Count) / ReplayList.Stats.Count))
        Lb_Time.Text = "Time passed: " + TimePassed.ToString("hh\:mm\:ss") + "  Time left: " + TimeLeft.ToString("hh\:mm\:ss")
        Application.DoEvents()
    End Sub



    Private Sub Butt_ReadReplays_Click(sender As Object, e As EventArgs) Handles Butt_ReadReplays.Click
        Dim heroesAccountsFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Heroes of the Storm\Accounts")
        Dim allReplays = Directory.GetFiles(heroesAccountsFolder, "*.StormReplay", SearchOption.AllDirectories)
        Grp_Filter.Visible = True
        Lb_Time.Visible = True
        Dim LastAddedReplay = ReplayList.DateOfLastAddedReplay

        ReplayList.TimeOfLastUpdate = Now
        addCounter = 0
        Dim BunchOfReplays As New List(Of String)
        For Each rp In allReplays
            If Globals.Closing Then Exit Sub
            If File.GetLastWriteTime(rp) > LastAddedReplay Then
                BunchOfReplays.Add(rp)
                If BunchOfReplays.Count = 8 Then
                    Parallel.ForEach(BunchOfReplays, Sub(currentFile)
                                                         ReadReplay(currentFile)
                                                     End Sub)
                    BunchOfReplays.Clear()
                    updateReplay(allReplays.Count, skipCounter)
                End If
            End If
        Next
        Parallel.ForEach(BunchOfReplays, Sub(currentFile)
                                             ReadReplay(currentFile)
                                         End Sub)
        BunchOfReplays.Clear()
        Lb_Time.Visible = False



        'For Each rp In allReplays
        '    If Globals.Closing Then Exit Sub
        '    If File.GetLastWriteTime(rp) > LastAddedReplay Then
        '        If True Then
        '            ReadReplay(rp, skipCounter)
        '            Lb_ReplayCount.Text = ReplayList.Stats.Count.ToString + " / " + allReplays.Count.ToString + " Replays"
        '            If skipCounter > 0 Then Lb_ReplayCount.Text += ", " + skipCounter.ToString + " skipped"
        '            Dim TimePassed As TimeSpan = Now - ReplayList.TimeOfLastUpdate
        '            Dim TimeLeft As TimeSpan = TimeSpan.FromTicks(CLng((TimePassed).Ticks * (allReplays.Count - ReplayList.Stats.Count) / ReplayList.Stats.Count))
        '            Lb_Time.Text = "Time passed: " + TimePassed.ToString("hh\:mm\:ss") + "  Time left: " + TimeLeft.ToString("hh\:mm\:ss")
        '            Application.DoEvents()
        '        End If
        '        ReplayFileCounter += 1
        '        Debug.Print(ReplayFileCounter.ToString)
        '    End If
        'Next
        UpdateAfterLoading()
        Lb_Added.Visible = True
        Lb_Added.Text = addCounter.ToString + " Replays added"
        Lb_Added.ForeColor = Color.DarkBlue
        Timer1.Interval = 5000
        Timer1.Start()
    End Sub

    Sub ReadReplay(rp As String)
        Dim tmpPath As String = Nothing
        Try
            ' Create our Replay object: this object will be filled as you parse the different files in the .StormReplay archive
            ' Use temp directory for MpqLib directory permissions requirements
            tmpPath = Path.GetTempFileName()
            File.Copy(rp, tmpPath, True)


            Dim replay = New Replay()
            MpqHeader.ParseHeader(replay, tmpPath)
            Using archive = New CArchive(tmpPath)
                ReplayInitData.Parse(replay, GetMpqArchiveFileBytes(archive, "replay.initData"))
                ReplayDetails.Parse(replay, GetMpqArchiveFileBytes(archive, "replay.details"))
                ReplayTrackerEvents.Parse(replay, GetMpqArchiveFileBytes(archive, "replay.tracker.events"))
                ReplayAttributeEvents.Parse(replay, GetMpqArchiveFileBytes(archive, "replay.attributes.events"))
                If replay.GameMode = GameMode.TryMe OrElse replay.GameMode = GameMode.Unknown Then
                    Debug.Print(replay.GameMode.ToString)
                    skipCounter += 1
                    Exit Sub
                End If
                addCounter += 1
                If replay.ReplayBuild >= 32455 Then
                    ReplayGameEvents.Parse(replay, GetMpqArchiveFileBytes(archive, "replay.game.events"))
                End If
                ReplayServerBattlelobby.Parse(replay, GetMpqArchiveFileBytes(archive, "replay.server.battlelobby"))
            End Using

            Dim Rep As New ReplayStats
            ReplayList.Stats.Add(Rep)
            If File.GetLastWriteTime(rp) > ReplayList.DateOfLastAddedReplay Then ReplayList.DateOfLastAddedReplay = File.GetLastWriteTime(rp)
            Rep.Gamemode = replay.GameMode
            If replay.Timestamp.Ticks = 0 Then
                Rep.Time = File.GetLastWriteTimeUtc(rp)
            Else
                Rep.Time = replay.Timestamp
            End If
            Rep.Length = replay.ReplayLength
            Rep.Map = replay.Map
            Rep.MapWidth = replay.MapSize.X
            Rep.MapHeight = replay.MapSize.Y
            Debug.Print(Rep.Map)
            If replay.Players(0).IsWinner Then
                Rep.Teams(replay.Players(0).Team).isWinner = True
                Rep.Teams(1 - replay.Players(0).Team).isWinner = False
            Else
                Rep.Teams(replay.Players(0).Team).isWinner = False
                Rep.Teams(1 - replay.Players(0).Team).isWinner = True
            End If

            For Each player In replay.Players.OrderBy(Function(i) i.Team)
                Dim t As ReplayStatsTeam = Rep.Teams(player.Team)
                Dim p As New ReplayStatsPlayer
                t.Players.Add(p)
                p.Name = player.Name
                p.Hero = player.Character
                p.Level = player.CharacterLevel
                p.Type = player.PlayerType
                p.Autoselect = player.IsAutoSelect
                If p.Type = PlayerType.Human Then
                    t.Humans += 1
                End If
            Next

            For m = 0 To replay.TeamLevelMilestones.Length - 1
                For i = 0 To replay.TeamLevelMilestones(m).Length - 1
                    Rep.Teams(m).Milestones.Add(replay.TeamLevelMilestones(m)(i))
                Next
            Next

        Finally
            If File.Exists(tmpPath) Then
                File.Delete(tmpPath)
            End If
        End Try

    End Sub

    Private Shared Function GetMpqArchiveFileBytes(archive As CArchive, archivedFileName As String) As Byte()
        Dim buffer = New Byte(archive.FindFiles(archivedFileName).[Single]().Size - 1) {}
        archive.ExportFile(archivedFileName, buffer)
        Return buffer
    End Function

    Private Sub Butt_SaveStats_Click(sender As Object, e As EventArgs) Handles Butt_SaveStats.Click
        Dim dlg As New SaveFileDialog
        dlg.InitialDirectory = My.Settings.ReplayPath
        dlg.Filter = "HotS Replay Stats|*.hots"
        Dim filename As String
        If dlg.ShowDialog() <> DialogResult.Cancel Then
            filename = dlg.FileName
            My.Settings.ReplayPath = Path.GetDirectoryName(dlg.FileName)
            My.Settings.Save()
            Dim fs As Stream = New FileStream(filename, FileMode.Create)
            Dim bf As BinaryFormatter = New BinaryFormatter()
            bf.Serialize(fs, ReplayList)
            fs.Close()
        End If
    End Sub

    Private Sub Butt_ReadStats_Click(sender As Object, e As EventArgs) Handles Butt_ReadStats.Click
        Lb_Added.Visible = False
        Dim dlg As New OpenFileDialog()
        dlg.Filter = "HotS Replay Stats|*.hots"
        dlg.InitialDirectory = My.Settings.ReplayPath
        Dim filename As String
        If dlg.ShowDialog() <> DialogResult.Cancel Then
            filename = dlg.FileName
            My.Settings.ReplayPath = Path.GetDirectoryName(dlg.FileName)
            'Dim fs As Stream = New FileStream("C:\Users\sven\Documents\HotsReplayStats.txt", FileMode.Open)
            Dim fs As Stream = New FileStream(filename, FileMode.Open)
            Dim bf As BinaryFormatter = New BinaryFormatter()
            ReplayList = CType(bf.Deserialize(fs), Replays)
            fs.Close()
            UpdateAfterLoading()
        End If
    End Sub

    Sub UpdateAfterLoading()
        If ReplayList.Stats.Count > 0 Then
            Grp_Chart.Visible = True
            Grp_Filter.Visible = True
            Pic_Filter.Visible = True
            Pic_Filter.BringToFront()
            lb_ReplaysLoaded.Text = ReplayList.Stats.Count.ToString + " replays loaded"
            ReadAll()
            FilterReplays()
        Else
            Grp_Chart.Visible = False
            Grp_Filter.Visible = False
            Pic_Filter.Visible = False
            lb_ReplaysLoaded.Text = "no replays loaded"
        End If

    End Sub

    Private Sub CB_GameType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DD_GameType.SelectedIndexChanged
        FilterReplays()
        ChartIt()
    End Sub

    Sub FilterReplays(Optional finished As Boolean = True)
        If Not LoadingComplete Then Exit Sub
        ReplayList.selected = 0
        ReplayList.Wins = 0
        Dim computer As New Regex(".* \d{1,2}$")
        Dim Names As New Dictionary(Of String, Integer)

        For Each rp In ReplayList.Stats
            rp.isSelected = True
            Select Case DD_GameType.SelectedIndex
                Case 1
                    If Not (rp.Gamemode = GameMode.QuickMatch AndAlso (rp.Teams(0).Humans < 5 OrElse rp.Teams(1).Humans < 5)) Then
                        rp.isSelected = False
                        Continue For
                    End If

                Case 2
                    If Not (rp.Gamemode = GameMode.QuickMatch AndAlso rp.Teams(0).Humans = 5 And rp.Teams(1).Humans = 5) Then
                        rp.isSelected = False
                        Continue For
                    End If

                Case 3
                    If Not (rp.Gamemode = GameMode.HeroLeague) Then
                        rp.isSelected = False
                        Continue For
                    End If
                Case 4
                    If Not (rp.Gamemode = GameMode.TeamLeague) Then
                        rp.isSelected = False
                        Continue For
                    End If
            End Select
            If DD_Map.SelectedIndices.Count > 0 AndAlso Not DD_Map.isItemSelected(rp.Map) Then
                rp.isSelected = False
                Continue For
            End If

            If DD_Heroes.SelectedIndices.Count > 0 AndAlso Not DD_Heroes.isItemSelected(rp.Hero) Then
                rp.isSelected = False
                Continue For
            End If

            If rp.Length.TotalSeconds < Bar_MinLength.Value OrElse rp.Length.TotalSeconds > Bar_MaxLength.Value Then
                rp.isSelected = False
                Continue For
            End If

            If rp.Time.Ticks < Bar_MinDate.Value * 864000000000 OrElse rp.Time.Ticks > (Bar_MaxDate.Value + 1) * 864000000000 Then
                rp.isSelected = False
                Continue For
            End If
            If CB_Wins.Checked AndAlso Not CB_Losses.Checked AndAlso Not rp.isWinner Then rp.isSelected = False : Continue For
            If CB_Losses.Checked AndAlso Not CB_Wins.Checked AndAlso rp.isWinner Then rp.isSelected = False : Continue For

            If PlayerName <> "" Then
                If rp.playerFound Then
                    If rp.isWinner Then ReplayList.Wins += 1
                Else
                    rp.isSelected = False
                    Continue For
                End If
            End If


            If DD_OtherPlayer.SelectedIndex > 0 Then
                Dim otherPlayerFound = False
                For Each t In rp.Teams
                    For Each p In t.Players
                        If p.Name = OtherPlayerName Then otherPlayerFound = True : Exit For
                    Next
                Next
                If Not otherPlayerFound Then
                    rp.isSelected = False
                    Continue For
                End If
            Else

            End If
            For Each team In rp.Teams
                For Each player In team.Players
                    If computer.IsMatch(player.Name) Then
                    Else
                        If Not Names.ContainsKey(player.Name) Then
                            Names.Add(player.Name, 1)
                        Else
                            Names(player.Name) += 1
                        End If
                    End If
                Next
            Next

            If rp.isSelected Then ReplayList.selected += 1

        Next
        If finished AndAlso Names.Count > 0 Then
            IndexChanged = True
            DD_OtherPlayer.Items.Clear()
            DD_OtherPlayer.Items.Add("Games played with/against ...")
            DD_OtherPlayer.SelectedIndex = 0
            If OtherPlayerByName Then

                For Each n In Names.OrderBy(Function(x) x.Key)
                    If n.Key <> PlayerName Then
                        DD_OtherPlayer.Items.Add(n.Key + " (" + n.Value.ToString + ")")
                        If n.Key = OtherPlayerName Then DD_OtherPlayer.SelectedIndex = DD_OtherPlayer.Items.Count - 1
                    End If
                Next
            Else
                For Each n In Names.OrderBy(Function(x) (10000000 - x.Value).ToString("0000000") + x.Key)
                    If n.Key <> PlayerName Then
                        DD_OtherPlayer.Items.Add(n.Key + " (" + n.Value.ToString + ")")
                        If n.Key = OtherPlayerName Then DD_OtherPlayer.SelectedIndex = DD_OtherPlayer.Items.Count - 1
                    End If
                Next
            End If
            IndexChanged = False
        End If

        Lb_ReplayCount.Text = ReplayList.selected.ToString + " replays filtered"
        LB_Wins.Text = ReplayList.Wins.ToString + " Wins"
        If ReplayList.selected > 0 Then
            LB_Winrate.Text = (ReplayList.Wins / ReplayList.selected).ToString("##0.0%")
        Else
            LB_Winrate.Text = ""
        End If

    End Sub

    Private Sub Map_SelectedIndexChanged(sender As Object, e As EventArgs)
        FilterReplays()
    End Sub

    Private Sub DD_PlayerNames_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DD_PlayerNames.SelectedIndexChanged
        Dim name As New Regex("^(.*) \(\d+\)$")
        PlayerName = name.Match(CStr(DD_PlayerNames.SelectedItem)).Groups(1).Value
        UpdatePlayerInfo()
        FilterReplays()
        ChartIt()
    End Sub


    Sub UpdatePlayerInfo()
        If PlayerName <> "" Then
            For Each rp In ReplayList.Stats
                rp.playerFound = False
                For Each team In rp.Teams
                    For Each player In team.Players
                        If player.Name = PlayerName Then
                            rp.isWinner = team.isWinner
                            rp.Hero = player.Hero
                            rp.playerFound = True
                            Exit For
                        End If
                    Next
                    If rp.playerFound Then Exit For
                Next
            Next
        End If

        FilterReplays()
    End Sub

    Sub ReadAll()
        ReadMaps()
        ReadHeroes()
        ReadPlayerNames()
        UpdatePlayerInfo()
        readLength()
        readTime()
    End Sub

    Sub readLength()
        Dim minLength As TimeSpan = TimeSpan.MaxValue
        Dim maxLength As TimeSpan = TimeSpan.MinValue
        For Each rp In ReplayList.Stats
            If rp.Length > maxLength Then maxLength = rp.Length
            If rp.Length < minLength AndAlso rp.Length.TotalSeconds > 60 Then minLength = rp.Length
        Next
        Bar_MaxLength.Maximum = CInt(maxLength.TotalSeconds)
        Bar_MaxLength.Minimum = CInt(minLength.TotalSeconds)
        Bar_MinLength.Maximum = CInt(maxLength.TotalSeconds)
        Bar_MinLength.Minimum = CInt(minLength.TotalSeconds)
        Bar_MaxLength.Value = CInt(maxLength.TotalSeconds)
        DisplayLength()
    End Sub

    Sub readTime()
        Dim minTime As DateTime = DateTime.MaxValue
        Dim maxTime As DateTime = DateTime.MinValue
        For Each rp In ReplayList.Stats
            If rp.Time > maxTime Then maxTime = rp.Time
            If rp.Time < minTime AndAlso rp.Time > DateTime.MinValue Then minTime = rp.Time
        Next
        Bar_MaxDate.Maximum = CInt(Math.Floor(maxTime.Ticks / 864000000000.0))
        Bar_MaxDate.Minimum = CInt(Math.Floor(minTime.Ticks / 864000000000.0))
        Bar_MinDate.Maximum = CInt(Math.Floor(maxTime.Ticks / 864000000000.0))
        Bar_MinDate.Minimum = CInt(Math.Floor(minTime.Ticks / 864000000000.0))
        Bar_MinDate.Value = Bar_MinDate.Minimum
        Bar_MaxDate.Value = Bar_MaxDate.Maximum
        DisplayDate()

    End Sub


    Sub ReadMaps()
        Dim maps As New List(Of String)
        For Each rp In ReplayList.Stats
            If Not maps.Contains(rp.Map) Then maps.Add(rp.Map)
        Next
        DD_Map.Items.Clear()
        DD_Map.Items.Add("Maps")
        For Each m In maps.OrderBy(Function(x As String) x)
            If m IsNot Nothing Then DD_Map.Items.Add(m)
        Next
    End Sub

    Sub ReadHeroes()
        Dim Heroes As New List(Of String)
        For Each rp In ReplayList.Stats
            For Each team In rp.Teams
                For Each player In team.Players
                    If Not Heroes.Contains(player.Hero) Then Heroes.Add(player.Hero)
                Next
            Next
        Next
        DD_Heroes.Items.Clear()
        DD_Heroes.Items.Add("Heroes")
        For Each h In Heroes.OrderBy(Function(x As String) x)
            If h IsNot Nothing Then DD_Heroes.Items.Add(h)
        Next
    End Sub

    Sub ReadPlayerNames()
        Dim computer As New Regex(".* \d{1,2}$")
        Dim Names As New Dictionary(Of String, Integer)
        Dim max As Integer = 0
        Dim maxName As String = ""
        For Each rp In ReplayList.Stats
            For Each team In rp.Teams
                For Each player In team.Players
                    If computer.IsMatch(player.Name) Then
                        'Debug.Print(player.Name)
                    Else
                        If Not Names.ContainsKey(player.Name) Then
                            Names.Add(player.Name, 1)
                        Else
                            Names(player.Name) += 1
                            If Names(player.Name) > max Then
                                max = Names(player.Name)
                                maxName = player.Name
                            End If
                        End If
                    End If
                Next
            Next
        Next
        DD_PlayerNames.Items.Clear()
        DD_OtherPlayer.Items.Add("Stats for Player ...")
        DD_OtherPlayer.Items.Clear()
        DD_OtherPlayer.Items.Add("Games played with/against ...")
        DD_OtherPlayer.SelectedIndex = 0

        '        For Each n In Names.OrderBy(Function(x) (10000000 - x.Value).ToString("0000000") + x.Key)
        For Each n In Names.OrderBy(Function(x) x.Key)
            DD_PlayerNames.Items.Add(n.Key + " (" + n.Value.ToString + ")")
            If OtherPlayerByName Then
                DD_OtherPlayer.Items.Add(n.Key + " (" + n.Value.ToString + ")")
                If n.Key = OtherPlayerName Then DD_OtherPlayer.SelectedIndex = DD_OtherPlayer.Items.Count - 1
            End If
        Next
        If Not OtherPlayerByName Then
            For Each n In Names.OrderBy(Function(x) (10000000 - x.Value).ToString("0000000") + x.Key)
                DD_OtherPlayer.Items.Add(n.Key + " (" + n.Value.ToString + ")")
                If n.Key = OtherPlayerName Then DD_OtherPlayer.SelectedIndex = DD_OtherPlayer.Items.Count - 1
            Next
        End If
        'DD_PlayerNames.SelectedIndex = 0
        DD_PlayerNames.SelectedItem = maxName + " (" + max.ToString + ")"
    End Sub



    Private Sub DD_Heroes_SelectedIndexChanged(sender As Object, e As EventArgs)
        FilterReplays()
    End Sub

    Private Sub Bar_MinLength_Scroll(sender As Object, e As EventArgs) Handles Bar_MinLength.Scroll
        If Bar_MaxLength.Value < Bar_MinLength.Value Then Bar_MaxLength.Value = Bar_MinLength.Value
        DisplayLength()
        FilterReplays(False)
        ChartIt()
    End Sub

    Private Sub Bar_MaxLength_Scroll(sender As Object, e As EventArgs) Handles Bar_MaxLength.Scroll
        If Bar_MinLength.Value > Bar_MaxLength.Value Then Bar_MinLength.Value = Bar_MaxLength.Value
        DisplayLength()
        FilterReplays(False)
        ChartIt()
    End Sub

    Sub DisplayLength()
        Dim minLength = New TimeSpan(0, 0, Bar_MinLength.Value)
        Dim maxLength = New TimeSpan(0, 0, Bar_MaxLength.Value)
        Lb_Length.Text = "Length: " + (Int(minLength.TotalMinutes)).ToString("00") + ":" + (minLength.Seconds).ToString("00") + " - " + (Int(maxLength.TotalMinutes)).ToString("00") + ":" + (maxLength.Seconds).ToString("00")
        PB_Length.Left = CInt(Lb_Length.Left + (Lb_Length.Width - Lb_Length.CreateGraphics.MeasureString(Lb_Length.Text, Lb_Length.Font).Width) / 2 - 24)
    End Sub

    Sub DisplayDate()
        Dim minTime = New DateTime(Bar_MinDate.Value * 864000000000)
        Dim maxTime = New DateTime(Bar_MaxDate.Value * 864000000000)
        Lb_Date.Text = "Time: " + minTime.ToShortDateString + " - " + maxTime.ToShortDateString
        PB_Date.Left = CInt(Lb_Date.Left + (Lb_Date.Width - Lb_Date.CreateGraphics.MeasureString(Lb_Date.Text, Lb_Date.Font).Width) / 2 - 24)

    End Sub

    Private Sub Bar_MinTime_Scroll(sender As Object, e As EventArgs) Handles Bar_MinDate.Scroll
        If Bar_MaxDate.Value < Bar_MinDate.Value Then Bar_MaxDate.Value = Bar_MinDate.Value
        DisplayDate()
        FilterReplays(False)
        ChartIt()
    End Sub

    Private Sub Bar_MaxTime_Scroll(sender As Object, e As EventArgs) Handles Bar_MaxDate.Scroll
        If Bar_MinDate.Value > Bar_MaxDate.Value Then Bar_MinDate.Value = Bar_MaxDate.Value
        DisplayDate()
        FilterReplays(False)
        ChartIt()
    End Sub


    Private Sub DD_Heroes_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles DD_Heroes.SelectedIndexChanged
        If DD_Heroes.GetSelected(0) Then DD_Heroes.SetSelected(0, False)
        FilterReplays()
        ChartIt()
    End Sub

    Private Sub DD_Map_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DD_Map.SelectedIndexChanged
        If DD_Map.GetSelected(0) Then DD_Map.SetSelected(0, False)
        FilterReplays()
        ChartIt()
    End Sub

    Private Sub Form1_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        Try
            If LoadingComplete Then
                'ChartIt()
                formatChart(Chart1, Chart.Table, Chart.ChartType)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DD_ChartInfo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DD_ChartInfo.SelectedIndexChanged
        If DD_ChartInfo.SelectedIndex = 0 Then
            Chart1.Series.Clear()
        Else
            ChartIt()
        End If
    End Sub

    Private Sub DD_ChartType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DD_ChartType.SelectedIndexChanged
        ChartIt()
    End Sub

    Private Sub Form1_Click(sender As Object, e As EventArgs) Handles Me.Click
        Me.Focus()
    End Sub

    Private Sub GroupBox2_MouseHover(sender As Object, e As EventArgs) Handles Grp_Filter.MouseHover
        DD_Heroes.Shrink()
        DD_Map.Shrink()
    End Sub

    Private Sub DD_ChartData_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DD_ChartData.SelectedIndexChanged
        If LoadingComplete AndAlso Chart.Table IsNot Nothing Then
            'ChartIt()
            addChartSeries(Chart1, Chart.Table, CType(DD_ChartData.SelectedItem, String))
            formatChart(Chart1, Chart.Table, ChartType)
        End If
    End Sub

    Private Sub Butt_Settings_Click(sender As Object, e As EventArgs) Handles Butt_Settings.Click
        Settings.ShowDialog()
        My.Settings.Reload()
        AllHeroProperties = New HeroProperties
        ChartIt()
    End Sub

    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Globals.Closing = True
    End Sub

    Private Sub CB_Wins_CheckedChanged(sender As Object, e As EventArgs) Handles CB_Wins.CheckedChanged
        FilterReplays()
        ChartIt()
    End Sub

    Private Sub CB_Losses_CheckedChanged(sender As Object, e As EventArgs) Handles CB_Losses.CheckedChanged
        FilterReplays()
        ChartIt()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Interval = 10
        Dim r As Integer = Lb_Added.ForeColor.R
        Dim g As Integer = Lb_Added.ForeColor.G
        Dim b As Integer = Lb_Added.ForeColor.B
        Dim flag = False

        If r < Lb_Added.BackColor.R Then r += 1 : flag = True
        If g < Lb_Added.BackColor.R Then g += 1 : flag = True
        If b < Lb_Added.BackColor.R Then b += 1 : flag = True

        If flag Then
            Lb_Added.ForeColor = Color.FromArgb(r, g, b)
        Else
            Timer1.Stop()
        End If

    End Sub

    Private IndexChanged As Boolean = False
    Private Sub DD_OtherPlayer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DD_OtherPlayer.SelectedIndexChanged
        If IndexChanged Then Return
        Dim name As New Regex("^(.*) \(\d+\)$")
        If DD_OtherPlayer.SelectedIndex > 0 Then
            OtherPlayerName = name.Match(CStr(DD_OtherPlayer.SelectedItem)).Groups(1).Value
        Else
            OtherPlayerName = ""
        End If
        FilterReplays()
        ChartIt()
    End Sub

    Private Sub Bar_MinDate_MouseUp(sender As Object, e As MouseEventArgs) Handles Bar_MinDate.MouseUp
        FilterReplays()
    End Sub

    Private Sub Bar_MaxDate_MouseUp(sender As Object, e As MouseEventArgs) Handles Bar_MaxDate.MouseUp
        FilterReplays()
    End Sub

    Private Sub Bar_MaxLength_MouseUp(sender As Object, e As MouseEventArgs) Handles Bar_MaxLength.MouseUp
        FilterReplays()
    End Sub

    Private Sub Bar_MinLength_MouseUp(sender As Object, e As MouseEventArgs) Handles Bar_MinLength.MouseUp
        FilterReplays()
    End Sub

    Dim OtherPlayerByName As Boolean = True


    Private Sub CB_OtherOrder_CheckedChanged(sender As Object, e As EventArgs) Handles CB_OtherOrder.CheckedChanged
        OtherPlayerByName = CB_OtherOrder.Checked
        FilterReplays()

    End Sub
End Class
