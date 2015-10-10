Imports System.IO
Imports MpqLib.Mpq
Imports Heroes.ReplayParser
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Globalization
Imports System.Text.RegularExpressions
Imports System.ComponentModel
Imports System.Text

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
        If My.Settings.ChatTexts IsNot Nothing AndAlso My.Settings.ChatTexts.Count > 0 Then
            CB_ChatTexts.Items.Clear()

            For Each t In My.Settings.ChatTexts
                CB_ChatTexts.Items.Add(t)
            Next
        End If
        Lb_Time.Visible = False
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


    Sub updateReplay(total As Integer, skipCounter As Integer, startcount As Integer)
        Lb_ReplayCount.Text = ReplayList.Stats.Count.ToString + " / " + total.ToString + " Replays"
        If skipCounter > 0 Then Lb_ReplayCount.Text += ", " + skipCounter.ToString + " skipped"
        Dim TimePassed As TimeSpan = Now - ReplayList.TimeOfLastUpdate
        Dim TimeLeft As TimeSpan = TimeSpan.FromTicks(CLng((TimePassed).Ticks * (total - ReplayList.Stats.Count) / (ReplayList.Stats.Count - startcount)))
        Lb_Time.Text = "Time passed: " + TimePassed.ToString("hh\:mm\:ss") + "  Time left: " + TimeLeft.ToString("hh\:mm\:ss")
        Application.DoEvents()
    End Sub



    Private Sub Butt_ReadReplays_Click(sender As Object, e As EventArgs) Handles Butt_ReadReplays.Click
        Dim heroesAccountsFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Heroes of the Storm\Accounts")
        Dim allReplays = Directory.GetFiles(heroesAccountsFolder, "*.StormReplay", SearchOption.AllDirectories)
        Dim startCount = ReplayList.Stats.Count
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
                    updateReplay(allReplays.Count, skipCounter, startCount)
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
                    'Debug.Print(replay.GameMode.ToString)
                    skipCounter += 1
                    Exit Sub
                End If
                addCounter += 1
                If replay.ReplayBuild >= 32455 Then
                    ReplayGameEvents.Parse(replay, GetMpqArchiveFileBytes(archive, "replay.game.events"))
                End If
                ReplayServerBattlelobby.Parse(replay, GetMpqArchiveFileBytes(archive, "replay.server.battlelobby"))
                ReplayMessageEvents.Parse(replay, GetMpqArchiveFileBytes(archive, "replay.message.events"))
            End Using

            Dim Rep As New ReplayStats
            If InStr(rp, "Multiplayer") > 0 Then
                Rep.Filename = Mid(rp, 12 + InStr(rp, "Multiplayer"))
            Else
                Rep.Filename = rp
            End If
            ReplayList.Stats.Add(Rep)
            If File.GetLastWriteTime(rp) > ReplayList.DateOfLastAddedReplay Then ReplayList.DateOfLastAddedReplay = File.GetLastWriteTime(rp)
            Rep.Gamemode = replay.GameMode
            If replay.Timestamp.Ticks = 0 Then
                Rep.Time = File.GetLastWriteTimeUtc(rp)
            Else
                Rep.Time = replay.Timestamp
            End If
            Rep.Length = replay.ReplayLength
            Rep.Messages = CType(replay.ChatMessages, List(Of ChatMessage))
            If replay.Players(0).PlayerType = PlayerType.Computer AndAlso replay.Players(4).PlayerType = PlayerType.Computer Then
                For Each msg In Rep.Messages
                    msg.PlayerId += 5
                Next
            End If
            Rep.Map = replay.Map
            Rep.MapWidth = replay.MapSize.X
            Rep.MapHeight = replay.MapSize.Y
            'Debug.Print(Rep.Map)
            If replay.Players(0).IsWinner Then
                Rep.Teams(replay.Players(0).Team).isWinner = True
                Rep.Teams(1 - replay.Players(0).Team).isWinner = False
            Else
                Rep.Teams(replay.Players(0).Team).isWinner = False
                Rep.Teams(1 - replay.Players(0).Team).isWinner = True
            End If

            'For Each player In replay.Players.OrderBy(Function(i) i.Team)
            For i = 0 To replay.Players.Count - 1
                Dim player = replay.Players(i)
                Dim t As ReplayStatsTeam = Rep.Teams(player.Team)
                Dim p As New ReplayStatsPlayer
                t.Players.Add(p)
                p.Name = player.Name
                p.Hero = player.Character
                p.Level = player.CharacterLevel
                p.Type = player.PlayerType
                p.Autoselect = player.IsAutoSelect
                p.Number = i
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
            'FilterReplays()
        Else
            Grp_Chart.Visible = False
            Grp_Filter.Visible = False
            Pic_Filter.Visible = False
            lb_ReplaysLoaded.Text = "no replays loaded"
        End If

    End Sub

    Private Sub CB_GameType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DD_GameType.SelectionChangeCommitted
        FilterReplays()
        ChartIt()
    End Sub

    Sub FilterReplays(Optional finished As Boolean = True)
        If Not LoadingComplete Then Exit Sub
        ReplayList.selected = 0
        ReplayList.Wins = 0
        Dim computer As New Regex(".* \d{1,2}$")
        Dim Names As New Dictionary(Of String, Integer)
        DD_Replays.Items.Clear()
        Dim regex As New Regex("\b" + CB_ChatTexts.Text + "\b")
        Dim minute = New TimeSpan(0, 0, 30)

        For Each rp In ReplayList.Stats.OrderBy(Function(i) i.Time)
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
                If Not rp.playerFound Then
                    rp.isSelected = False
                    Continue For
                End If
            End If

            If DD_AgainstHero.SelectedIndex > 0 Then
                If Not rp.EnemyTeam.ContainsHero(DD_AgainstHero.SelectedItem.ToString) Then
                    rp.isSelected = False
                    Continue For
                End If
            End If
            If DD_WithHero.SelectedIndex > 0 Then
                If Not rp.OwnTeam.ContainsHero(DD_WithHero.SelectedItem.ToString) Then
                    rp.isSelected = False
                    Continue For
                End If
            End If
            If CB_ChatTexts.Text <> "" Then
                If CB_ChatTexts.SelectedIndex = 1 Then
                    If rp.Messages.Count = 0 Then rp.isSelected = False : Continue For
                ElseIf CB_ChatTexts.SelectedIndex = 2 Then
                    If rp.Messages.Count > 0 Then rp.isSelected = False : Continue For
                ElseIf CB_ChatTexts.SelectedIndex = 3 Then
                    rp.isSelected = False
                    For Each msg In rp.Messages
                        If msg.Message.Length > 3 AndAlso msg.Timestamp > minute AndAlso msg.Timestamp < rp.Length.Subtract(minute) Then rp.isSelected = True : Exit For
                        Next

                        If Not rp.isSelected Then Continue For
                    Else
                        rp.isSelected = False
                    If Not CB_WholeWords.Checked Then
                        For Each msg In rp.Messages
                            If msg.Message.ToLower.Contains(CB_ChatTexts.Text.ToLower) Then rp.isSelected = True : Exit For
                        Next
                    Else
                        For Each msg In rp.Messages
                            If Regex.IsMatch(msg.Message) Then rp.isSelected = True : Exit For
                        Next
                    End If
                    If Not rp.isSelected Then Continue For
                End If
            End If
            If DD_OtherPlayer.SelectedIndex > 0 Then
                Dim otherPlayerFound = False
                For Each t In rp.Teams
                    For Each p In t.Players
                        If p.Name = OtherPlayerName Then otherPlayerFound = True : Exit For
                    Next
                    If otherPlayerFound Then Exit For
                Next
                If Not otherPlayerFound Then
                    rp.isSelected = False
                    Continue For
                End If
            End If

            If PlayerName <> "" Then
                If rp.isWinner Then ReplayList.Wins += 1
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

            If rp.isSelected Then
                ReplayList.selected += 1
                DD_Replays.Items.Add(rp.Time.ToLocalTime.ToString + " " + rp.Filename)
            End If

        Next

        'IndexChanged = True
        DD_OtherPlayer.Items.Clear()
        DD_OtherPlayer.Items.Add("Games played with/against ...")
        DD_OtherPlayer.SelectedIndex = 0
        If Not OtherPlayerByName Then
            For Each n In Names.OrderBy(Function(x) x.Key)
                If (n.Value > 1 OrElse Names.Count < 100) AndAlso n.Key <> PlayerName Then
                    DD_OtherPlayer.Items.Add(n.Key + " (" + n.Value.ToString + ")")
                    If n.Key = OtherPlayerName Then DD_OtherPlayer.SelectedIndex = DD_OtherPlayer.Items.Count - 1
                End If
            Next
        Else
            For Each n In Names.OrderBy(Function(x) (10000000 - x.Value).ToString("0000000") + x.Key)
                If (n.Value > 1 OrElse Names.Count < 100) AndAlso n.Key <> PlayerName Then
                    DD_OtherPlayer.Items.Add(n.Key + " (" + n.Value.ToString + ")")
                    If n.Key = OtherPlayerName Then DD_OtherPlayer.SelectedIndex = DD_OtherPlayer.Items.Count - 1
                End If
            Next
        End If
        'IndexChanged = False


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

    Private Sub DD_PlayerNames_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DD_PlayerNames.SelectionChangeCommitted
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
        readLengths()
        readDates()
        ReadMaps()
        ReadHeroes()
        ReadPlayerNames()
        UpdatePlayerInfo()
    End Sub

    Sub readLengths()
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

    Sub readDates()
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
        DD_WithHero.Items.Clear()
        DD_WithHero.Items.Add("With ...")
        DD_WithHero.SelectedIndex = 0
        DD_AgainstHero.Items.Clear()
        DD_AgainstHero.Items.Add("Against ...")
        DD_AgainstHero.SelectedIndex = 0
        For Each h In Heroes.OrderBy(Function(x As String) x)
            If h IsNot Nothing Then
                DD_Heroes.Items.Add(h)
                DD_WithHero.Items.Add(h)
                DD_AgainstHero.Items.Add(h)
            End If
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
        DD_PlayerNames.Items.Add("Stats for Player ...")
        DD_OtherPlayer.Items.Clear()
        DD_OtherPlayer.Items.Add("Games played with/against ...")
        DD_OtherPlayer.SelectedIndex = 0
        If PlayerName Is Nothing Then PlayerName = maxName  ' after loading
        For Each n In Names.OrderBy(Function(x) x.Key)
            If (n.Value >= 1 OrElse Names.Count < 100) Then
                DD_PlayerNames.Items.Add(n.Key + " (" + n.Value.ToString + ")")

                If OtherPlayerByName AndAlso n.Key <> PlayerName Then
                    DD_OtherPlayer.Items.Add(n.Key + " (" + n.Value.ToString + ")")
                    If n.Key = OtherPlayerName Then DD_OtherPlayer.SelectedIndex = DD_OtherPlayer.Items.Count - 1
                End If
            End If
        Next
        If Not OtherPlayerByName Then
            For Each n In Names.OrderBy(Function(x) (10000000 - x.Value).ToString("0000000") + x.Key)
                If (n.Value > 1 OrElse Names.Count < 100) AndAlso n.Key <> PlayerName Then
                    DD_OtherPlayer.Items.Add(n.Key + " (" + n.Value.ToString + ")")
                    If n.Key = OtherPlayerName Then DD_OtherPlayer.SelectedIndex = DD_OtherPlayer.Items.Count - 1
                End If
            Next
        End If
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
        Lb_Date.Text = "Date: " + minTime.ToShortDateString + " - " + maxTime.ToShortDateString
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

    Private Sub DD_ChartData_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DD_ChartData.SelectionChangeCommitted
        If LoadingComplete AndAlso Chart.Table IsNot Nothing Then
            If DD_OtherPlayer.SelectedIndex = 0 And DD_ChartData.SelectedIndex = 2 Then DD_ChartData.SelectedIndex = 1
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
        Dim texts As New Specialized.StringCollection
        For Each t As String In CB_ChatTexts.Items
            texts.Add(t)
        Next
        My.Settings.ChatTexts = texts
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

    'Private IndexChanged As Boolean = False
    Private Sub DD_OtherPlayer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DD_OtherPlayer.SelectionChangeCommitted
        'If IndexChanged Then IndexChanged = False : Return
        Dim name As New Regex("^(.*) \(\d+\)$")
        If DD_OtherPlayer.SelectedIndex > 0 Then
            OtherPlayerName = name.Match(CStr(DD_OtherPlayer.SelectedItem)).Groups(1).Value
        Else
            OtherPlayerName = ""
            If DD_ChartData.SelectedIndex = 2 Then DD_ChartData.SelectedIndex = 1
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
        If LoadingComplete Then
            OtherPlayerByName = CB_OtherOrder.Checked
            ReadPlayerNames()
        End If
    End Sub

    Private Sub DD_AgainstHero_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DD_AgainstHero.SelectionChangeCommitted
        FilterReplays()
        ChartIt()
    End Sub

    Private Sub DD_WithHero_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DD_WithHero.SelectionChangeCommitted
        FilterReplays()
        ChartIt()
    End Sub

    Dim LastFolder As String = ""
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Butt_LoadReplays.Click
        Dim dlg As New OpenFileDialog
        dlg.Multiselect = True
        If LastFolder <> "" Then
            dlg.InitialDirectory = LastFolder
        Else
            Dim heroesAccountsFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Heroes of the Storm\Accounts")
            dlg.InitialDirectory = heroesAccountsFolder
        End If
        dlg.Filter = "Heroes of the Storm Replays|*.StormReplay"
        If dlg.ShowDialog <> DialogResult.Cancel Then
            LastFolder = Path.GetDirectoryName(dlg.FileNames(0))
            For Each rp In dlg.FileNames
                ReadReplay(rp)
            Next
            FilterReplays()
            ChartIt()
            UpdateAfterLoading()
        End If

    End Sub


    Private Sub CB_Words_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles CB_ChatTexts.SelectionChangeCommitted
        CB_ChatTexts.Text = CStr(CB_ChatTexts.SelectedItem)
        FilterReplays()
        ChartIt()
    End Sub

    Private Sub CB_Words_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CB_ChatTexts.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            If CB_ChatTexts.Text.Trim <> "" Then
                Dim found = False
                For Each w As String In CB_ChatTexts.Items
                    If w.ToLower = CB_ChatTexts.Text.ToLower.Trim Then found = True : Exit For
                Next
                If Not found Then CB_ChatTexts.Items.Add(CB_ChatTexts.Text.Trim)

            End If
            FilterReplays()
            ChartIt()
        End If
    End Sub


    Private Sub DD_Replays_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles DD_Replays.SelectionChangeCommitted
        For Each rp In ReplayList.Stats
            If DD_Replays.SelectedItem.ToString = rp.Time.ToString + " " + rp.Filename Then
                Dim sb As New StringBuilder
                TB_Chat.Text = rp.Chat
                sb.AppendLine("Own Team " + IIf(rp.OwnTeam.isWinner, "(Winner)", "(Loser)").ToString)
                For Each p In rp.OwnTeam.Players
                    If p.Type = PlayerType.Human Then
                        sb.AppendLine("  " + p.Name + ": " + p.Hero + " (" + p.Level.ToString + ")")
                    Else
                        sb.AppendLine("  " + p.Name + ": " + p.Hero)
                    End If
                Next
                sb.AppendLine()
                sb.AppendLine("Enemy Team " + IIf(rp.EnemyTeam.isWinner, "(Winner)", "(Loser)").ToString)
                For Each p In rp.EnemyTeam.Players
                    If p.Type = PlayerType.Human Then
                        sb.AppendLine("  " + p.Name + ": " + p.Hero + " (" + p.Level.ToString + ")")
                    Else
                        sb.AppendLine("  " + p.Name + ": " + p.Hero)
                    End If
                Next
                Lb_Players.Text = sb.ToString
                Lb_GameInfo.Text = IIf(rp.isWinner, "Win", "Loss").ToString + vbCrLf + "Length: " + rp.Length.ToString + vbCrLf + rp.Map
            End If
        Next
    End Sub

    Private Sub Butt_DeleteTexts_Click(sender As Object, e As EventArgs) Handles Butt_DeleteTexts.Click
        CB_ChatTexts.Items.Clear()
        CB_ChatTexts.Items.Add("")
        CB_ChatTexts.Items.Add("Any Chat")
        CB_ChatTexts.Items.Add("No Chat")
        CB_ChatTexts.Items.Add("Relevant Chats")

    End Sub

    Private Sub CB_WholeWords_CheckedChanged(sender As Object, e As EventArgs) Handles CB_WholeWords.CheckedChanged
        FilterReplays()
        ChartIt()
    End Sub
End Class
