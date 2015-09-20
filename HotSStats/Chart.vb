Imports System.Globalization
Imports System.Text.RegularExpressions

Module Chart

    Public Table As DataTable
    Class ReplayValueCounter
        Public Win As Integer
        Public Loss As Integer
        Public WinWithPlayer As Integer
        Public WinAgainstPlayer As Integer
        Public LossWithPlayer As Integer
        Public LossAgainstPlayer As Integer
        Public Players10 As Integer
        Public Players5 As Integer
        Public Players1 As Integer
        Public Warrior As Integer
        Public Assassin As Integer
        Public Support As Integer
        Public Specialist As Integer
        Public Melee As Integer
        Public Ranged As Integer
        Public Tier0 As Integer
        Public Tier1 As Integer
        Public Tier2 As Integer
        Public Tier3 As Integer
        Public Tier4 As Integer
        Public Tier5 As Integer
        Public Tier6 As Integer
        Public Tier7 As Integer
        Public Heroes As New SortedDictionary(Of String, Integer)


        Public Sub addToTable(t As DataTable, Key As String)
            Dim tr = t.NewRow()
            tr("Item") = Key
            tr("Win") = Win
            tr("Loss")=Loss
            tr("WinWith") = WinWithPlayer
            tr("LossWith") = LossWithPlayer
            tr("WinAgainst") = WinAgainstPlayer
            tr("LossAgainst") = LossAgainstPlayer
            tr("PvP") = Players10
            tr("PvC") = Players5
            tr("Solo") = Players1
            tr("Warrior") = Warrior
            tr("Assassin") = Assassin
            tr("Support") = Support
            tr("Specialist") = Specialist
            tr("Melee") = Melee
            tr("Ranged") = Ranged
            tr("Tier0") = Tier0
            tr("Tier1") = Tier1
            tr("Tier2") = Tier2
            tr("Tier3") = Tier3
            tr("Tier4") = Tier4
            tr("Tier5") = Tier5
            tr("Tier6") = Tier6
            tr("Tier7") = Tier7

            For Each h In allHeroesPlayed
                If Heroes.ContainsKey(h) Then
                    tr(h) = Heroes(h)
                Else
                    tr(h) = 0
                End If
            Next

            't.Rows.Add(Key, Win, Loss, Players10, Players5, Players1, Warrior, Assassin, Support, Specialist, Melee, Ranged, Tier0, Tier1, Tier2, Tier3, Tier4, Tier5, Tier6, Tier7)
            t.Rows.Add(tr)

        End Sub


    End Class

    Dim allHeroesPlayed As New SortedSet(Of String)

    Enum ChartCategoryTypes
        noChart
        Days
        Weeks
        Months
        Heroes
        Hero_Roles
        Own_Heroes
        Enemy_Heroes
        Attack_Type
        Maps
        Length_in_Minutes
        Tier_achieved
        Time_of_Day
        Weekday
        Hero_Level
        Team_Hero_Level_Average
        Team_Hero_Level_Median
        Team_Hero_Level_Average_Difference
        Team_Hero_Level_Median_Difference
        Own_Team_Composition
        Enemy_Team_Composition
        Own_Warriors
        Own_Assassins
        Own_Support
        Own_Specialists
        Enemy_Warriors
        Enemy_Assassins
        Enemy_Support
        Enemy_Specialists
    End Enum

    Enum TeamComposition
        _5_Warriors = 5000
        _4_Warriors__1_Assassin = 4100
        _4_Warriors__1_Support = 4010
        _4_Warriors__1_Specialist = 4001
        _3_Warriors__2_Assassins = 3200
        _3_Warriors__1_Assassin__1_Support = 3110
        _3_Warriors__1_Assassin__1_Specialist = 3101
        _3_Warriors__2_Support = 3020
        _3_Warriors__1_Support__1_Specialist = 3011
        _3_Warriors__2_Specialists = 3002
        _2_Warriors__3_Assassins = 2300
        _2_Warriors__2_Assassins__1_Support = 2210
        _2_Warriors__2_Assassins__1_Specialist = 2201
        _2_Warriors__1_Assassin__2_Support = 2120
        _2_Warriors__1_Assassin__1_Support__1_Specialist = 2111
        _2_Warriors__1_Assassin__2_Specialists = 2102
        _2_Warriors__3_Support = 2030
        _2_Warriors__2_Support__1_Specialist = 2021
        _2_Warriors__1_Support__2_Specialists = 2012
        _2_Warriors__3_Specialists = 2003
        _1_Warrior__4_Assassins = 1400
        _1_Warrior__3_Assassins__1_Support = 1310
        _1_Warrior__3_Assassins__1_Specialist = 1301
        _1_Warrior__2_Assassins__2_Support = 1220
        _1_Warrior__2_Assassins__1_Support__1_Specialist = 1211
        _1_Warrior__2_Assassins__2_Specialists = 1202
        _1_Warrior__1_Assassin__3_Support = 1130
        _1_Warrior__1_Assassin__2_Support__1_Specialist = 1121
        _1_Warrior__1_Assassin__1_Support__2_Specialists = 1112
        _1_Warrior__1_Assassin__3_Specialists = 1103
        _1_Warrior__4_Support = 1040
        _1_Warrior__3_Support__1_Specialist = 1031
        _1_Warrior__2_Support__2_Specialists = 1022
        _1_Warrior__1_Support__3_Specialists = 1013
        _1_Warrior__4_Specialists = 1004
        _5_Assassins = 0500
        _4_Assassins__1_Support = 0410
        _4_Assassins__1_Specialist = 0401
        _3_Assassins__2_Support = 0320
        _3_Assassins__1_Support__1_Specialist = 0311
        _3_Assassins__2_Specialists = 0302
        _2_Assassins__3_Support = 0230
        _2_Assassins__2_Support__1_Specialist = 0221
        _2_Assassins__1_Support__2_Specialists = 0212
        _2_Assassins__3_Specialists = 0203
        _1_Assassin__4_Support = 0140
        _1_Assassin__3_Support__1_Specialist = 0131
        _1_Assassin__2_Support__2_Specialists = 0122
        _1_Assassin__1_Support__3_Specialists = 0113
        _1_Assassin__4_Specialists = 0104
        _5_Support = 0050
        _4_Support__1_Specialist = 0041
        _3_Support__2_Specialists = 0032
        _2_Support__3_Specialists = 0023
        _1_Support__4_Specialists = 0014
        _5_Specialists = 0005

    End Enum

    Sub DrawChart(CategoryType As ChartCategoryTypes)
        Dim ReplayValues As New SortedList(Of Object, ReplayValueCounter)
        Dim Category As Object = Nothing
        allHeroesPlayed.Clear()
        For Each rp In ReplayList.Stats
            If rp.isSelected Then
                Category = getCategoryFromReplay(CategoryType, rp)
                If Category IsNot Nothing Then
                    If Category.GetType.Name = "String[]" Then
                        For Each c As String In CType(Category, Array)
                            countAllReplayValues(ReplayValues, rp, c)
                        Next
                    Else
                        countAllReplayValues(ReplayValues, rp, Category)
                    End If
                End If
            End If
        Next
        Table = New DataTable()
        addTableColumns(Table)
        writeDataTable(Table, CategoryType, ReplayValues)
        addChartSeries(Form1.Chart1, Table, CType(Form1.DD_ChartData.SelectedItem, String))
        formatChart(Form1.Chart1, Table, CategoryType)
    End Sub

    Private Sub addTableColumns(Table As DataTable)
        Table.Columns.Add("Item", GetType(String))
        Table.Columns.Add("Win", GetType(Integer))
        Table.Columns.Add("Loss", GetType(Integer))
        Table.Columns.Add("WinWith", GetType(Integer))
        Table.Columns.Add("LossWith", GetType(Integer))
        Table.Columns.Add("WinAgainst", GetType(Integer))
        Table.Columns.Add("LossAgainst", GetType(Integer))
        Table.Columns.Add("PvP", GetType(Integer))
        Table.Columns.Add("PvC", GetType(Integer))
        Table.Columns.Add("Solo", GetType(Integer))
        Table.Columns.Add("Warrior", GetType(Integer))
        Table.Columns.Add("Assassin", GetType(Integer))
        Table.Columns.Add("Support", GetType(Integer))
        Table.Columns.Add("Specialist", GetType(Integer))
        Table.Columns.Add("Melee", GetType(Integer))
        Table.Columns.Add("Ranged", GetType(Integer))
        Table.Columns.Add("Tier0", GetType(Integer))
        Table.Columns.Add("Tier1", GetType(Integer))
        Table.Columns.Add("Tier2", GetType(Integer))
        Table.Columns.Add("Tier3", GetType(Integer))
        Table.Columns.Add("Tier4", GetType(Integer))
        Table.Columns.Add("Tier5", GetType(Integer))
        Table.Columns.Add("Tier6", GetType(Integer))
        Table.Columns.Add("Tier7", GetType(Integer))
        For Each h In allHeroesPlayed
            Table.Columns.Add(h, GetType(Integer))
        Next
    End Sub

    Private Function getCategoryFromReplay(CategoryType As ChartCategoryTypes, rp As ReplayStats) As Object
        Dim ownWarrior = 0, ownAssassin = 0, ownSupport = 0, ownSpecialist = 0
        For Each p In rp.OwnTeam.Players
            Select Case AllHeroProperties.Role(p.Hero)
                Case HeroProperties.HeroRoles.Warrior
                    ownWarrior += 1
                Case HeroProperties.HeroRoles.Assassin
                    ownAssassin += 1
                Case HeroProperties.HeroRoles.Support
                    ownSupport += 1
                Case HeroProperties.HeroRoles.Specialist
                    ownSpecialist += 1
            End Select
        Next
        Dim enemyWarrior = 0, enemyAssassin = 0, enemySupport = 0, enemySpecialist = 0
        For Each p In rp.EnemyTeam.Players
            Select Case AllHeroProperties.Role(p.Hero)
                Case HeroProperties.HeroRoles.Warrior
                    enemyWarrior += 1
                Case HeroProperties.HeroRoles.Assassin
                    enemyAssassin += 1
                Case HeroProperties.HeroRoles.Support
                    enemySupport += 1
                Case HeroProperties.HeroRoles.Specialist
                    enemySpecialist += 1
            End Select
        Next

        Select Case CategoryType
            Case ChartCategoryTypes.Own_Team_Composition
                Return CType(1000 * ownWarrior + 100 * ownAssassin + 10 * ownSupport + ownSpecialist, TeamComposition).ToString.Replace("__", ", ").Replace("_", " ").Trim
            Case ChartCategoryTypes.Enemy_Team_Composition
                Return CType(1000 * enemyWarrior + 100 * enemyAssassin + 10 * enemySupport + enemySpecialist, TeamComposition).ToString.Replace("__", ", ").Replace("_", " ").Trim
            Case ChartCategoryTypes.Own_Warriors
                Return ownWarrior
            Case ChartCategoryTypes.Own_Assassins
                Return ownAssassin
            Case ChartCategoryTypes.Own_Support
                Return ownSupport
            Case ChartCategoryTypes.Own_Specialists
                Return ownSpecialist
            Case ChartCategoryTypes.Enemy_Warriors
                Return enemyWarrior
            Case ChartCategoryTypes.Enemy_Assassins
                Return enemyAssassin
            Case ChartCategoryTypes.Enemy_Support
                Return enemySupport
            Case ChartCategoryTypes.Enemy_Specialists
                Return enemySpecialist
            Case ChartCategoryTypes.Days
                Return rp.Time.ToLocalTime.Date
            Case ChartCategoryTypes.Weeks
                Dim cal As New GregorianCalendar()
                Return rp.Time.ToLocalTime.Year.ToString + " Wk " + cal.GetWeekOfYear(rp.Time.ToLocalTime, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday).ToString
            Case ChartCategoryTypes.Months
                Return rp.Time.ToLocalTime.Year.ToString + "-" + rp.Time.ToLocalTime.Month.ToString("00")
            Case ChartCategoryTypes.Heroes
                Return rp.Hero
            Case ChartCategoryTypes.Enemy_Heroes
                Return {rp.EnemyTeam.Players(0).Hero, rp.EnemyTeam.Players(1).Hero, rp.EnemyTeam.Players(2).Hero, rp.EnemyTeam.Players(3).Hero, rp.EnemyTeam.Players(4).Hero}
            Case ChartCategoryTypes.Own_Heroes
                Return {rp.OwnTeam.Players(0).Hero, rp.OwnTeam.Players(1).Hero, rp.OwnTeam.Players(2).Hero, rp.OwnTeam.Players(3).Hero, rp.OwnTeam.Players(4).Hero}
            Case ChartCategoryTypes.Hero_Roles
                Return AllHeroProperties.Role(rp.Hero).ToString
            Case ChartCategoryTypes.Attack_Type
                Return AllHeroProperties.AttackType(rp.Hero).ToString
            Case ChartCategoryTypes.Maps
                Return rp.Map
            Case ChartCategoryTypes.Time_of_Day
                Return rp.Time.ToLocalTime.Hour
            Case ChartCategoryTypes.Weekday
                Return ((rp.Time.ToLocalTime.DayOfWeek + 7 - CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek) Mod 7).ToString + rp.Time.ToLocalTime.ToString("ddd")
            Case ChartCategoryTypes.Length_in_Minutes
                Return Int(rp.Length.TotalMinutes)
            Case ChartCategoryTypes.Tier_achieved
                Return TierLevel(rp.OwnTeam.Milestones.Count)
            Case ChartCategoryTypes.Hero_Level
                For Each team In rp.Teams
                    For Each player In team.Players
                        If player.Name = PlayerName Then
                            Return player.Level
                            Exit For
                        End If
                    Next
                Next
            Case ChartCategoryTypes.Team_Hero_Level_Average
                If rp.playerFound Then
                    Dim myTeamLevel As Integer = 0
                    Dim theirTeamLevel As Integer = 0
                    For Each team In rp.Teams
                        For Each player In team.Players
                            If team.isWinner = rp.isWinner Then
                                myTeamLevel += player.Level
                            Else
                                theirTeamLevel += player.Level
                            End If
                        Next
                    Next
                    Return Int(myTeamLevel / 5)
                End If
            Case ChartCategoryTypes.Team_Hero_Level_Median
                If rp.playerFound Then
                    Return rp.OwnTeam.Players.OrderBy(Function(x As ReplayStatsPlayer) x.Level).ElementAt(2).Level
                End If
            Case ChartCategoryTypes.Team_Hero_Level_Median_Difference
                If rp.playerFound Then
                    Return rp.OwnTeam.Players.OrderBy(Function(x As ReplayStatsPlayer) x.Level).ElementAt(2).Level - rp.EnemyTeam.Players.OrderBy(Function(x As ReplayStatsPlayer) x.Level).ElementAt(2).Level
                End If
            Case ChartCategoryTypes.Team_Hero_Level_Average_Difference
                If rp.playerFound Then
                    Dim myTeamLevel As Integer = 0
                    Dim theirTeamLevel As Integer = 0
                    For Each team In rp.Teams
                        For Each player In team.Players
                            If team.isWinner = rp.isWinner Then
                                myTeamLevel += player.Level
                            Else
                                theirTeamLevel += player.Level
                            End If
                        Next
                    Next
                    Return Int((myTeamLevel - theirTeamLevel) / 5)
                End If
        End Select
        Return "Error"
    End Function


    Private Sub countAllReplayValues(ReplayValues As SortedList(Of Object, ReplayValueCounter), Replay As ReplayStats, Category As Object)
        If Not ReplayValues.ContainsKey(Category) Then ReplayValues.Add(Category, New ReplayValueCounter)
        Dim PlayWithOtherPlayer = False
        If Form1.DD_OtherPlayer.SelectedIndex > 0 Then
            If Replay.OwnTeam.ContainsPlayer(OtherPlayerName) Then PlayWithOtherPlayer = True
        End If

            ' Win / Loss
            If Replay.isWinner Then
            ReplayValues(Category).Win += 1
            If Form1.DD_OtherPlayer.SelectedIndex > 0 Then
                If PlayWithOtherPlayer Then
                    ReplayValues(Category).WinWithPlayer += 1
                Else
                    ReplayValues(Category).WinAgainstPlayer += 1
                End If
            End If
        Else
            ReplayValues(Category).Loss += 1
            If Form1.DD_OtherPlayer.SelectedIndex > 0 Then
                If PlayWithOtherPlayer Then
                    ReplayValues(Category).LossWithPlayer += 1
                Else
                    ReplayValues(Category).LossAgainstPlayer += 1
                End If
            End If
        End If

        ' Game Type
        Select Case Replay.Teams(0).Humans + Replay.Teams(1).Humans
            Case 10
                ReplayValues(Category).Players10 += 1
            Case 1
                ReplayValues(Category).Players1 += 1
            Case Else
                ReplayValues(Category).Players5 += 1
        End Select

        If Replay.Hero IsNot Nothing Then
            If Not ReplayValues(Category).Heroes.ContainsKey(Replay.Hero) Then
                ReplayValues(Category).Heroes.Add(Replay.Hero, 1)
                If Not allHeroesPlayed.Contains(Replay.Hero) Then
                    allHeroesPlayed.Add(Replay.Hero)
                End If
            Else
                ReplayValues(Category).Heroes(Replay.Hero) += 1
            End If
        End If

        ' Hero Role
        Select Case AllHeroProperties.Role(Replay.Hero)
            Case HeroProperties.HeroRoles.Warrior
                ReplayValues(Category).Warrior += 1
            Case HeroProperties.HeroRoles.Assassin
                ReplayValues(Category).Assassin += 1
            Case HeroProperties.HeroRoles.Support
                ReplayValues(Category).Support += 1
            Case HeroProperties.HeroRoles.Specialist
                ReplayValues(Category).Specialist += 1
        End Select

        ' Attack Type
        Select Case AllHeroProperties.AttackType(Replay.Hero)
            Case HeroProperties.HeroAttackTypes.Melee
                ReplayValues(Category).Melee += 1
            Case HeroProperties.HeroAttackTypes.Ranged
                ReplayValues(Category).Ranged += 1
        End Select

        'Highest Tier
        Select Case Replay.OwnTeam.Milestones.Count
            Case 0
                ReplayValues(Category).Tier0 += 1
            Case 1
                ReplayValues(Category).Tier1 += 1
            Case 2
                ReplayValues(Category).Tier2 += 1
            Case 3
                ReplayValues(Category).Tier3 += 1
            Case 4
                ReplayValues(Category).Tier4 += 1
            Case 5
                ReplayValues(Category).Tier5 += 1
            Case 6
                ReplayValues(Category).Tier6 += 1
            Case 7
                ReplayValues(Category).Tier7 += 1
        End Select
    End Sub

    Private Sub writeDataTable(Table As DataTable, ValueType As ChartCategoryTypes, ReplayValues As SortedList(Of Object, ReplayValueCounter))
        Dim lastD As Object = Nothing
        If ValueType = ChartCategoryTypes.Time_of_Day Then  ' Make sure time of day shows always 24 hours
            lastD = -1
        End If
        For Each d In ReplayValues
            Select Case ValueType
                Case ChartCategoryTypes.Days
                    If lastD IsNot Nothing Then
                        Dim diff = DateDiff(DateInterval.Day, CDate(lastD), CDate(d.Key))
                        For i = 1 To diff - 1  ' Fill gaps of days without any replays
                            Dim gap = CDate(lastD).AddDays(i)
                            Table.Rows.Add(gap.ToShortDateString)
                        Next
                    End If
                    d.Value.addToTable(Table, CDate(d.Key).ToShortDateString)
                Case ChartCategoryTypes.Time_of_Day
                    If lastD IsNot Nothing Then
                        For i = CInt(lastD) + 1 To CInt(d.Key) - 1  ' Make sure time of day shows always 24 hours
                            Table.Rows.Add(i)
                        Next
                    End If
                    d.Value.addToTable(Table, CType(d.Key, String))
                Case ChartCategoryTypes.Weekday
                    d.Value.addToTable(Table, Mid(CType(d.Key, String), 2))
                Case Else
                    d.Value.addToTable(Table, CType(d.Key, String))
            End Select
            lastD = d.Key
        Next
        If ValueType = ChartCategoryTypes.Time_of_Day Then  ' Make sure time of day shows always 24 hours
            For i = CInt(lastD) + 1 To 23
                Table.Rows.Add(i)
            Next
        End If

    End Sub

    Public Sub formatChart(Chart As DataVisualization.Charting.Chart, Table As DataTable, ValueType As ChartCategoryTypes)
        Dim ChartAreaWidth As Integer = CInt(Chart.ChartAreas(0).Position.Width * Chart.Width / 100)
        With Chart.ChartAreas(0)
            .AxisX.Interval = Math.Ceiling(20 * Table.Rows.Count / ChartAreaWidth)
            Select Case ValueType
                Case ChartCategoryTypes.Hero_Level, ChartCategoryTypes.Team_Hero_Level_Average_Difference, ChartCategoryTypes.Team_Hero_Level_Average, ChartCategoryTypes.Tier_achieved,
                     ChartCategoryTypes.Time_of_Day, ChartCategoryTypes.Length_in_Minutes, ChartCategoryTypes.Weekday, ChartCategoryTypes.Hero_Roles,
                     ChartCategoryTypes.Attack_Type, ChartCategoryTypes.Own_Warriors, ChartCategoryTypes.Own_Assassins, ChartCategoryTypes.Own_Support,
                     ChartCategoryTypes.Own_Specialists, ChartCategoryTypes.Enemy_Warriors, ChartCategoryTypes.Enemy_Assassins, ChartCategoryTypes.Enemy_Support,
                     ChartCategoryTypes.Enemy_Specialists
                    .AxisX.LabelStyle.Angle = 0
                Case Else
                    .AxisX.LabelStyle.Angle = -60
            End Select
            .AxisX.Title = ValueType.ToString.Replace("_", " ")
            .AxisY.Title = "Replays"
        End With


        Dim ChartType As DataVisualization.Charting.SeriesChartType = DataVisualization.Charting.SeriesChartType.StackedColumn
        Select Case CStr(Form1.DD_ChartType.SelectedItem)
            Case "Columns stacked"
                ChartType = DataVisualization.Charting.SeriesChartType.StackedColumn
            Case "Columns stacked (100%)"
                ChartType = DataVisualization.Charting.SeriesChartType.StackedColumn100
            Case "Area stacked"
                ChartType = DataVisualization.Charting.SeriesChartType.StackedArea
            Case "Area stacked (100%)"
                ChartType = DataVisualization.Charting.SeriesChartType.StackedArea100
        End Select
        For i = 0 To Chart.Series.Count - 1
            Chart.Series(i).ToolTip = "#AXISLABEL - #SERIESNAME: #VAL"
            Chart.Series(i).ChartType = ChartType
        Next
    End Sub


    Public Sub addChartSeries(chart As DataVisualization.Charting.Chart, table As DataTable, DDText As String)
        chart.Series.Clear()
        Select Case DDText
            Case "Game Types"
                chart.Legends(0).Title = "Game Type"
                chart.Series.Add("Players vs Players")
                chart.Series.Add("Players vs A.I.")
                chart.Series.Add("Solo vs A.I.")
                chart.Series(0).Points.DataBind(table.DefaultView, "Item", "PvP", Nothing)
                chart.Series(1).Points.DataBind(table.DefaultView, "Item", "PvC", Nothing)
                chart.Series(2).Points.DataBind(table.DefaultView, "Item", "Solo", Nothing)
            Case "Heroes"
                chart.Legends(0).Title = "Hero"
                Dim z = 0
                For Each h In allHeroesPlayed
                    chart.Series.Add(h)
                    chart.Series(z).Points.DataBind(table.DefaultView, "Item", h, Nothing)
                    z = z + 1
                Next
            Case "Hero Roles"
                chart.Legends(0).Title = "Hero Role"
                chart.Series.Add("Warrior")
                chart.Series.Add("Assassin")
                chart.Series.Add("Support")
                chart.Series.Add("Specialist")
                chart.Series(0).Points.DataBind(table.DefaultView, "Item", "Warrior", Nothing)
                chart.Series(1).Points.DataBind(table.DefaultView, "Item", "Assassin", Nothing)
                chart.Series(2).Points.DataBind(table.DefaultView, "Item", "Support", Nothing)
                chart.Series(3).Points.DataBind(table.DefaultView, "Item", "Specialist", Nothing)
            Case "Highest Tiers"
                chart.Legends(0).Title = "Highest Tier achieved"
                chart.Series.Add(TierLevel(0))
                chart.Series.Add(TierLevel(1))
                chart.Series.Add(TierLevel(2))
                chart.Series.Add(TierLevel(3))
                chart.Series.Add(TierLevel(4))
                chart.Series.Add(TierLevel(5))
                chart.Series.Add(TierLevel(6))
                chart.Series.Add(TierLevel(7))
                chart.Series(0).Points.DataBind(table.DefaultView, "Item", "Tier0", Nothing)
                chart.Series(1).Points.DataBind(table.DefaultView, "Item", "Tier1", Nothing)
                chart.Series(2).Points.DataBind(table.DefaultView, "Item", "Tier2", Nothing)
                chart.Series(3).Points.DataBind(table.DefaultView, "Item", "Tier3", Nothing)
                chart.Series(4).Points.DataBind(table.DefaultView, "Item", "Tier4", Nothing)
                chart.Series(5).Points.DataBind(table.DefaultView, "Item", "Tier5", Nothing)
                chart.Series(6).Points.DataBind(table.DefaultView, "Item", "Tier6", Nothing)
                chart.Series(7).Points.DataBind(table.DefaultView, "Item", "Tier7", Nothing)
            Case "Attack Types"
                chart.Legends(0).Title = "Attack Type"
                chart.Series.Add("Melee")
                chart.Series.Add("Ranged")
                chart.Series(0).Points.DataBind(table.DefaultView, "Item", "Melee", Nothing)
                chart.Series(1).Points.DataBind(table.DefaultView, "Item", "Ranged", Nothing)
            Case "Wins/Losses with/against ..."
                chart.Legends(0).Title = "Wins / Losses with/against " + OtherPlayerName
                chart.Series.Add("Wins with " + OtherPlayerName)
                chart.Series.Add("Losses with " + OtherPlayerName)
                chart.Series.Add("Wins against " + OtherPlayerName)
                chart.Series.Add("Losses against " + OtherPlayerName)
                chart.Series(0).Points.DataBind(table.DefaultView, "Item", "WinWith", Nothing)
                chart.Series(1).Points.DataBind(table.DefaultView, "Item", "LossWith", Nothing)
                chart.Series(2).Points.DataBind(table.DefaultView, "Item", "WinAgainst", Nothing)
                chart.Series(3).Points.DataBind(table.DefaultView, "Item", "LossAgainst", Nothing)

            Case Else
                chart.Legends(0).Title = "Wins / Losses"
                chart.Series.Add("Wins")
                chart.Series.Add("Losses")
                chart.Series(0).Points.DataBind(table.DefaultView, "Item", "Win", Nothing)
                chart.Series(1).Points.DataBind(table.DefaultView, "Item", "Loss", Nothing)
        End Select
    End Sub

    Public Sub ChartIt()
        Dim ct = ChartType()
        If ct <> Nothing Then DrawChart(ct)
    End Sub

    Public Function ChartType() As ChartCategoryTypes
        Select Case CStr(Form1.DD_ChartInfo.SelectedItem)
            Case "Hero"
                Return (ChartCategoryTypes.Heroes)
            Case "Hero Role"
                Return (ChartCategoryTypes.Hero_Roles)
            Case "Hero in Own Team"
                Return ChartCategoryTypes.Own_Heroes
            Case "Hero in Enemy Team"
                Return ChartCategoryTypes.Enemy_Heroes
            Case "Attack Type"
                Return (ChartCategoryTypes.Attack_Type)
            Case "Map"
                Return (ChartCategoryTypes.Maps)
            Case "Day"
                Return (ChartCategoryTypes.Days)
            Case "Week"
                Return (ChartCategoryTypes.Weeks)
            Case "Month"
                Return (ChartCategoryTypes.Months)
            Case "Time of Day"
                Return (ChartCategoryTypes.Time_of_Day)
            Case "Weekday"
                Return (ChartCategoryTypes.Weekday)
            Case "Length"
                Return (ChartCategoryTypes.Length_in_Minutes)
            Case "Highest Tier"
                Return (ChartCategoryTypes.Tier_achieved)
            Case "Hero Level"
                Return (ChartCategoryTypes.Hero_Level)
            Case "Team Hero Level Average"
                Return (ChartCategoryTypes.Team_Hero_Level_Average)
            Case "Team Hero Level Median"
                Return (ChartCategoryTypes.Team_Hero_Level_Median)
            Case "Team Hero Level Average Difference"
                Return (ChartCategoryTypes.Team_Hero_Level_Average_Difference)
            Case "Team Hero Level Median Difference"
                Return (ChartCategoryTypes.Team_Hero_Level_Median_Difference)
            Case "Own Team Composition"
                Return (ChartCategoryTypes.Own_Team_Composition)
            Case "Enemy Team Composition"
                Return (ChartCategoryTypes.Enemy_Team_Composition)
            Case "Number of Own Warriors"
                Return (ChartCategoryTypes.Own_Warriors)
            Case "Number of Own Assassins"
                Return (ChartCategoryTypes.Own_Assassins)
            Case "Number of Own Support"
                Return (ChartCategoryTypes.Own_Support)
            Case "Number of Own Specialists"
                Return (ChartCategoryTypes.Own_Specialists)
            Case "Number of Enemy Warriors"
                Return (ChartCategoryTypes.Enemy_Warriors)
            Case "Number of Enemy Assassins"
                Return (ChartCategoryTypes.Enemy_Assassins)
            Case "Number of Enemy Support"
                Return (ChartCategoryTypes.Enemy_Support)
            Case "Number of Enemy Specialists"
                Return (ChartCategoryTypes.Enemy_Specialists)
            Case Else
                Return ChartCategoryTypes.noChart
        End Select
    End Function
End Module
