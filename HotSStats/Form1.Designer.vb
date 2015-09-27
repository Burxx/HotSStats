<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.Butt_ReadReplays = New System.Windows.Forms.Button()
        Me.DD_GameType = New System.Windows.Forms.ComboBox()
        Me.Lb_ReplayCount = New System.Windows.Forms.Label()
        Me.Butt_ReadStats = New System.Windows.Forms.Button()
        Me.Butt_SaveStats = New System.Windows.Forms.Button()
        Me.LB_Wins = New System.Windows.Forms.Label()
        Me.LB_Winrate = New System.Windows.Forms.Label()
        Me.Bar_MinLength = New System.Windows.Forms.TrackBar()
        Me.Bar_MaxLength = New System.Windows.Forms.TrackBar()
        Me.Lb_Length = New System.Windows.Forms.Label()
        Me.Lb_Date = New System.Windows.Forms.Label()
        Me.Bar_MaxDate = New System.Windows.Forms.TrackBar()
        Me.Bar_MinDate = New System.Windows.Forms.TrackBar()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.DD_ChartInfo = New System.Windows.Forms.ComboBox()
        Me.DD_ChartType = New System.Windows.Forms.ComboBox()
        Me.Grp_Chart = New System.Windows.Forms.GroupBox()
        Me.DD_ChartData = New System.Windows.Forms.ComboBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Grp_Filter = New System.Windows.Forms.GroupBox()
        Me.CB_WholeWords = New System.Windows.Forms.CheckBox()
        Me.Butt_DeleteTexts = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CB_OtherOrder = New System.Windows.Forms.CheckBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.DD_OtherPlayer = New System.Windows.Forms.ComboBox()
        Me.CB_ChatTexts = New System.Windows.Forms.ComboBox()
        Me.CB_Losses = New System.Windows.Forms.CheckBox()
        Me.CB_Wins = New System.Windows.Forms.CheckBox()
        Me.PB_Date = New System.Windows.Forms.PictureBox()
        Me.PB_Length = New System.Windows.Forms.PictureBox()
        Me.DD_PlayerNames = New System.Windows.Forms.ComboBox()
        Me.Lb_Time = New System.Windows.Forms.Label()
        Me.DD_WithHero = New System.Windows.Forms.ComboBox()
        Me.DD_AgainstHero = New System.Windows.Forms.ComboBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Butt_LoadReplays = New System.Windows.Forms.Button()
        Me.Pic_Filter = New System.Windows.Forms.PictureBox()
        Me.Butt_Settings = New System.Windows.Forms.Button()
        Me.lb_ReplaysLoaded = New System.Windows.Forms.Label()
        Me.Lb_Added = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Lb_GameInfo = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TB_Chat = New System.Windows.Forms.TextBox()
        Me.Lb_Players = New System.Windows.Forms.Label()
        Me.DD_Replays = New System.Windows.Forms.ComboBox()
        Me.DD_Map = New HotSStats.DropdownListbox()
        Me.DD_Heroes = New HotSStats.DropdownListbox()
        CType(Me.Bar_MinLength, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar_MaxLength, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar_MaxDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar_MinDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grp_Chart.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grp_Filter.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PB_Date, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PB_Length, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Pic_Filter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Butt_ReadReplays
        '
        Me.Butt_ReadReplays.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Butt_ReadReplays.Image = CType(resources.GetObject("Butt_ReadReplays.Image"), System.Drawing.Image)
        Me.Butt_ReadReplays.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Butt_ReadReplays.Location = New System.Drawing.Point(10, 109)
        Me.Butt_ReadReplays.Margin = New System.Windows.Forms.Padding(5)
        Me.Butt_ReadReplays.Name = "Butt_ReadReplays"
        Me.Butt_ReadReplays.Size = New System.Drawing.Size(143, 48)
        Me.Butt_ReadReplays.TabIndex = 2
        Me.Butt_ReadReplays.Text = "Add All New" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Replays"
        Me.Butt_ReadReplays.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.Butt_ReadReplays, "Add new replays (if not already loaded)")
        Me.Butt_ReadReplays.UseVisualStyleBackColor = True
        '
        'DD_GameType
        '
        Me.DD_GameType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.DD_GameType.FormattingEnabled = True
        Me.DD_GameType.Items.AddRange(New Object() {"Game Mode", "Against A.I.", "QuickMatch", "Hero League", "Team League"})
        Me.DD_GameType.Location = New System.Drawing.Point(7, 85)
        Me.DD_GameType.Margin = New System.Windows.Forms.Padding(5)
        Me.DD_GameType.Name = "DD_GameType"
        Me.DD_GameType.Size = New System.Drawing.Size(221, 28)
        Me.DD_GameType.TabIndex = 2
        '
        'Lb_ReplayCount
        '
        Me.Lb_ReplayCount.AutoSize = True
        Me.Lb_ReplayCount.Location = New System.Drawing.Point(3, 116)
        Me.Lb_ReplayCount.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Lb_ReplayCount.Name = "Lb_ReplayCount"
        Me.Lb_ReplayCount.Size = New System.Drawing.Size(79, 20)
        Me.Lb_ReplayCount.TabIndex = 3
        Me.Lb_ReplayCount.Text = "0 Replays"
        '
        'Butt_ReadStats
        '
        Me.Butt_ReadStats.Image = CType(resources.GetObject("Butt_ReadStats.Image"), System.Drawing.Image)
        Me.Butt_ReadStats.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Butt_ReadStats.Location = New System.Drawing.Point(10, 7)
        Me.Butt_ReadStats.Margin = New System.Windows.Forms.Padding(5)
        Me.Butt_ReadStats.Name = "Butt_ReadStats"
        Me.Butt_ReadStats.Size = New System.Drawing.Size(143, 48)
        Me.Butt_ReadStats.TabIndex = 0
        Me.Butt_ReadStats.Text = "Load Stats"
        Me.Butt_ReadStats.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.Butt_ReadStats, "Load stats from previously saved file")
        Me.Butt_ReadStats.UseVisualStyleBackColor = True
        '
        'Butt_SaveStats
        '
        Me.Butt_SaveStats.Image = CType(resources.GetObject("Butt_SaveStats.Image"), System.Drawing.Image)
        Me.Butt_SaveStats.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Butt_SaveStats.Location = New System.Drawing.Point(10, 58)
        Me.Butt_SaveStats.Margin = New System.Windows.Forms.Padding(5)
        Me.Butt_SaveStats.Name = "Butt_SaveStats"
        Me.Butt_SaveStats.Size = New System.Drawing.Size(143, 48)
        Me.Butt_SaveStats.TabIndex = 1
        Me.Butt_SaveStats.Text = "Save Stats"
        Me.Butt_SaveStats.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.Butt_SaveStats, "Save stats to file")
        Me.Butt_SaveStats.UseVisualStyleBackColor = True
        '
        'LB_Wins
        '
        Me.LB_Wins.AutoSize = True
        Me.LB_Wins.Location = New System.Drawing.Point(3, 135)
        Me.LB_Wins.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.LB_Wins.Name = "LB_Wins"
        Me.LB_Wins.Size = New System.Drawing.Size(57, 20)
        Me.LB_Wins.TabIndex = 7
        Me.LB_Wins.Text = "0 Wins"
        '
        'LB_Winrate
        '
        Me.LB_Winrate.AutoSize = True
        Me.LB_Winrate.Location = New System.Drawing.Point(92, 135)
        Me.LB_Winrate.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.LB_Winrate.Name = "LB_Winrate"
        Me.LB_Winrate.Size = New System.Drawing.Size(36, 20)
        Me.LB_Winrate.TabIndex = 9
        Me.LB_Winrate.Text = "0 %"
        '
        'Bar_MinLength
        '
        Me.Bar_MinLength.LargeChange = 300
        Me.Bar_MinLength.Location = New System.Drawing.Point(572, 24)
        Me.Bar_MinLength.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.Bar_MinLength.Name = "Bar_MinLength"
        Me.Bar_MinLength.Size = New System.Drawing.Size(408, 45)
        Me.Bar_MinLength.SmallChange = 60
        Me.Bar_MinLength.TabIndex = 10
        Me.Bar_MinLength.TickFrequency = 60
        Me.Bar_MinLength.TickStyle = System.Windows.Forms.TickStyle.TopLeft
        Me.ToolTip1.SetToolTip(Me.Bar_MinLength, "Minimum game length")
        '
        'Bar_MaxLength
        '
        Me.Bar_MaxLength.AutoSize = False
        Me.Bar_MaxLength.LargeChange = 300
        Me.Bar_MaxLength.Location = New System.Drawing.Point(572, 53)
        Me.Bar_MaxLength.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.Bar_MaxLength.Name = "Bar_MaxLength"
        Me.Bar_MaxLength.Size = New System.Drawing.Size(408, 27)
        Me.Bar_MaxLength.SmallChange = 60
        Me.Bar_MaxLength.TabIndex = 11
        Me.Bar_MaxLength.TickFrequency = 60
        Me.ToolTip1.SetToolTip(Me.Bar_MaxLength, "Maximum game length")
        Me.Bar_MaxLength.Value = 10
        '
        'Lb_Length
        '
        Me.Lb_Length.BackColor = System.Drawing.Color.Transparent
        Me.Lb_Length.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Lb_Length.Location = New System.Drawing.Point(572, 14)
        Me.Lb_Length.Name = "Lb_Length"
        Me.Lb_Length.Size = New System.Drawing.Size(408, 20)
        Me.Lb_Length.TabIndex = 12
        Me.Lb_Length.Text = "Length"
        Me.Lb_Length.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Lb_Date
        '
        Me.Lb_Date.BackColor = System.Drawing.Color.Transparent
        Me.Lb_Date.Location = New System.Drawing.Point(572, 84)
        Me.Lb_Date.Name = "Lb_Date"
        Me.Lb_Date.Size = New System.Drawing.Size(408, 20)
        Me.Lb_Date.TabIndex = 15
        Me.Lb_Date.Text = "Date"
        Me.Lb_Date.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Bar_MaxDate
        '
        Me.Bar_MaxDate.AutoSize = False
        Me.Bar_MaxDate.LargeChange = 7
        Me.Bar_MaxDate.Location = New System.Drawing.Point(572, 124)
        Me.Bar_MaxDate.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.Bar_MaxDate.Name = "Bar_MaxDate"
        Me.Bar_MaxDate.Size = New System.Drawing.Size(408, 29)
        Me.Bar_MaxDate.TabIndex = 14
        Me.Bar_MaxDate.TickFrequency = 7
        Me.ToolTip1.SetToolTip(Me.Bar_MaxDate, "Last date")
        Me.Bar_MaxDate.Value = 10
        '
        'Bar_MinDate
        '
        Me.Bar_MinDate.LargeChange = 7
        Me.Bar_MinDate.Location = New System.Drawing.Point(572, 95)
        Me.Bar_MinDate.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.Bar_MinDate.Name = "Bar_MinDate"
        Me.Bar_MinDate.Size = New System.Drawing.Size(408, 45)
        Me.Bar_MinDate.TabIndex = 13
        Me.Bar_MinDate.TickFrequency = 7
        Me.Bar_MinDate.TickStyle = System.Windows.Forms.TickStyle.TopLeft
        Me.ToolTip1.SetToolTip(Me.Bar_MinDate, "Earliest date")
        '
        'Chart1
        '
        Me.Chart1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Chart1.BackColor = System.Drawing.SystemColors.Control
        ChartArea1.BackColor = System.Drawing.SystemColors.Control
        ChartArea1.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea1)
        Legend1.BackColor = System.Drawing.SystemColors.Control
        Legend1.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend1)
        Me.Chart1.Location = New System.Drawing.Point(0, 0)
        Me.Chart1.Margin = New System.Windows.Forms.Padding(0)
        Me.Chart1.Name = "Chart1"
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.Chart1.Series.Add(Series1)
        Me.Chart1.Size = New System.Drawing.Size(1344, 307)
        Me.Chart1.TabIndex = 16
        Me.Chart1.Text = "Chart1"
        '
        'DD_ChartInfo
        '
        Me.DD_ChartInfo.DropDownHeight = 200
        Me.DD_ChartInfo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.DD_ChartInfo.DropDownWidth = 400
        Me.DD_ChartInfo.FormattingEnabled = True
        Me.DD_ChartInfo.IntegralHeight = False
        Me.DD_ChartInfo.Items.AddRange(New Object() {"for each ...", "Hero", "Hero Role", "Attack Type", "Map", "Day", "Week", "Month", "Weekday", "Time of Day", "Length", "Highest Tier", "Hero Level", "Team Hero Level Average", "Team Hero Level Median", "Team Hero Level Average Difference", "Team Hero Level Median Difference", "Hero in Own Team", "Hero in Enemy Team", "Own Team Composition", "Enemy Team Composition", "Number of Own Warriors", "Number of Own Assassins", "Number of Own Support", "Number of Own Specialists", "Number of Enemy Warriors", "Number of Enemy Assassins", "Number of Enemy Support", "Number of Enemy Specialists", "Number of Chat Messages", "Number of Players Talking"})
        Me.DD_ChartInfo.Location = New System.Drawing.Point(237, 32)
        Me.DD_ChartInfo.Margin = New System.Windows.Forms.Padding(5)
        Me.DD_ChartInfo.Name = "DD_ChartInfo"
        Me.DD_ChartInfo.Size = New System.Drawing.Size(221, 28)
        Me.DD_ChartInfo.TabIndex = 21
        Me.ToolTip1.SetToolTip(Me.DD_ChartInfo, "Categories in the x-axis (each category becomes a column)")
        '
        'DD_ChartType
        '
        Me.DD_ChartType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.DD_ChartType.FormattingEnabled = True
        Me.DD_ChartType.Items.AddRange(New Object() {"as Chart Type ...", "Columns stacked", "Columns stacked (100%)", "Area stacked", "Area stacked (100%)"})
        Me.DD_ChartType.Location = New System.Drawing.Point(466, 32)
        Me.DD_ChartType.Margin = New System.Windows.Forms.Padding(5)
        Me.DD_ChartType.Name = "DD_ChartType"
        Me.DD_ChartType.Size = New System.Drawing.Size(221, 28)
        Me.DD_ChartType.TabIndex = 22
        '
        'Grp_Chart
        '
        Me.Grp_Chart.Controls.Add(Me.DD_ChartData)
        Me.Grp_Chart.Controls.Add(Me.PictureBox1)
        Me.Grp_Chart.Controls.Add(Me.DD_ChartType)
        Me.Grp_Chart.Controls.Add(Me.DD_ChartInfo)
        Me.Grp_Chart.Location = New System.Drawing.Point(168, 181)
        Me.Grp_Chart.Name = "Grp_Chart"
        Me.Grp_Chart.Size = New System.Drawing.Size(695, 68)
        Me.Grp_Chart.TabIndex = 23
        Me.Grp_Chart.TabStop = False
        Me.Grp_Chart.Text = "        Charting Options"
        Me.Grp_Chart.Visible = False
        '
        'DD_ChartData
        '
        Me.DD_ChartData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.DD_ChartData.FormattingEnabled = True
        Me.DD_ChartData.Items.AddRange(New Object() {"Show ...", "Wins/Losses", "Wins/Losses with/against ...", "Game Types", "Heroes", "Hero Roles", "Attack Types", "Highest Tiers"})
        Me.DD_ChartData.Location = New System.Drawing.Point(8, 32)
        Me.DD_ChartData.Margin = New System.Windows.Forms.Padding(5)
        Me.DD_ChartData.Name = "DD_ChartData"
        Me.DD_ChartData.Size = New System.Drawing.Size(221, 28)
        Me.DD_ChartData.TabIndex = 23
        Me.ToolTip1.SetToolTip(Me.DD_ChartData, "Categories in the y-axis (different colors within each column)")
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(12, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(24, 24)
        Me.PictureBox1.TabIndex = 23
        Me.PictureBox1.TabStop = False
        '
        'Grp_Filter
        '
        Me.Grp_Filter.AutoSize = True
        Me.Grp_Filter.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Grp_Filter.Controls.Add(Me.CB_WholeWords)
        Me.Grp_Filter.Controls.Add(Me.Butt_DeleteTexts)
        Me.Grp_Filter.Controls.Add(Me.DD_Map)
        Me.Grp_Filter.Controls.Add(Me.DD_Heroes)
        Me.Grp_Filter.Controls.Add(Me.Label1)
        Me.Grp_Filter.Controls.Add(Me.CB_OtherOrder)
        Me.Grp_Filter.Controls.Add(Me.PictureBox2)
        Me.Grp_Filter.Controls.Add(Me.DD_OtherPlayer)
        Me.Grp_Filter.Controls.Add(Me.CB_ChatTexts)
        Me.Grp_Filter.Controls.Add(Me.CB_Losses)
        Me.Grp_Filter.Controls.Add(Me.CB_Wins)
        Me.Grp_Filter.Controls.Add(Me.PB_Date)
        Me.Grp_Filter.Controls.Add(Me.PB_Length)
        Me.Grp_Filter.Controls.Add(Me.DD_PlayerNames)
        Me.Grp_Filter.Controls.Add(Me.Lb_Length)
        Me.Grp_Filter.Controls.Add(Me.LB_Winrate)
        Me.Grp_Filter.Controls.Add(Me.Bar_MaxLength)
        Me.Grp_Filter.Controls.Add(Me.LB_Wins)
        Me.Grp_Filter.Controls.Add(Me.Lb_Date)
        Me.Grp_Filter.Controls.Add(Me.Lb_ReplayCount)
        Me.Grp_Filter.Controls.Add(Me.Bar_MaxDate)
        Me.Grp_Filter.Controls.Add(Me.Bar_MinDate)
        Me.Grp_Filter.Controls.Add(Me.DD_GameType)
        Me.Grp_Filter.Controls.Add(Me.Bar_MinLength)
        Me.Grp_Filter.Controls.Add(Me.Lb_Time)
        Me.Grp_Filter.Controls.Add(Me.DD_WithHero)
        Me.Grp_Filter.Controls.Add(Me.DD_AgainstHero)
        Me.Grp_Filter.Location = New System.Drawing.Point(169, 4)
        Me.Grp_Filter.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Grp_Filter.Name = "Grp_Filter"
        Me.Grp_Filter.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.Grp_Filter.Size = New System.Drawing.Size(1166, 174)
        Me.Grp_Filter.TabIndex = 24
        Me.Grp_Filter.TabStop = False
        Me.Grp_Filter.Text = "        Replay Filter"
        Me.Grp_Filter.Visible = False
        '
        'CB_WholeWords
        '
        Me.CB_WholeWords.AutoSize = True
        Me.CB_WholeWords.Location = New System.Drawing.Point(1004, 68)
        Me.CB_WholeWords.Name = "CB_WholeWords"
        Me.CB_WholeWords.Size = New System.Drawing.Size(123, 24)
        Me.CB_WholeWords.TabIndex = 36
        Me.CB_WholeWords.Text = "Whole Words"
        Me.ToolTip1.SetToolTip(Me.CB_WholeWords, "Only search for whole words (searching for ""hi"" won't find ""high"")")
        Me.CB_WholeWords.UseVisualStyleBackColor = True
        '
        'Butt_DeleteTexts
        '
        Me.Butt_DeleteTexts.Image = CType(resources.GetObject("Butt_DeleteTexts.Image"), System.Drawing.Image)
        Me.Butt_DeleteTexts.Location = New System.Drawing.Point(1128, 36)
        Me.Butt_DeleteTexts.Name = "Butt_DeleteTexts"
        Me.Butt_DeleteTexts.Size = New System.Drawing.Size(32, 32)
        Me.Butt_DeleteTexts.TabIndex = 35
        Me.ToolTip1.SetToolTip(Me.Butt_DeleteTexts, "Remove texts from dropdown list")
        Me.Butt_DeleteTexts.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(1032, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 20)
        Me.Label1.TabIndex = 34
        Me.Label1.Text = "Chat Texts"
        '
        'CB_OtherOrder
        '
        Me.CB_OtherOrder.Appearance = System.Windows.Forms.Appearance.Button
        Me.CB_OtherOrder.FlatAppearance.BorderSize = 0
        Me.CB_OtherOrder.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black
        Me.CB_OtherOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CB_OtherOrder.Image = CType(resources.GetObject("CB_OtherOrder.Image"), System.Drawing.Image)
        Me.CB_OtherOrder.Location = New System.Drawing.Point(230, 59)
        Me.CB_OtherOrder.Name = "CB_OtherOrder"
        Me.CB_OtherOrder.Size = New System.Drawing.Size(19, 19)
        Me.CB_OtherOrder.TabIndex = 30
        Me.ToolTip1.SetToolTip(Me.CB_OtherOrder, "if checked sort alphabetically, otherwise by number of games")
        Me.CB_OtherOrder.UseVisualStyleBackColor = True
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(1004, 11)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(24, 24)
        Me.PictureBox2.TabIndex = 33
        Me.PictureBox2.TabStop = False
        '
        'DD_OtherPlayer
        '
        Me.DD_OtherPlayer.FormattingEnabled = True
        Me.DD_OtherPlayer.Location = New System.Drawing.Point(7, 55)
        Me.DD_OtherPlayer.Name = "DD_OtherPlayer"
        Me.DD_OtherPlayer.Size = New System.Drawing.Size(221, 28)
        Me.DD_OtherPlayer.TabIndex = 29
        Me.ToolTip1.SetToolTip(Me.DD_OtherPlayer, "Games with or against the selected player")
        '
        'CB_ChatTexts
        '
        Me.CB_ChatTexts.DropDownWidth = 200
        Me.CB_ChatTexts.FormattingEnabled = True
        Me.CB_ChatTexts.Items.AddRange(New Object() {"", "Any Chat", "No Chat", "Relevant Chats"})
        Me.CB_ChatTexts.Location = New System.Drawing.Point(1004, 38)
        Me.CB_ChatTexts.Name = "CB_ChatTexts"
        Me.CB_ChatTexts.Size = New System.Drawing.Size(121, 28)
        Me.CB_ChatTexts.TabIndex = 33
        Me.ToolTip1.SetToolTip(Me.CB_ChatTexts, "Find replays with a certain text in chat messages (e.g. Noob). Relevant Chats: Me" &
        "ssages with more than 3 letters, not before 00:30 and not after 30 Seconds befor" &
        "e the end")
        '
        'CB_Losses
        '
        Me.CB_Losses.AutoSize = True
        Me.CB_Losses.Location = New System.Drawing.Point(489, 57)
        Me.CB_Losses.Name = "CB_Losses"
        Me.CB_Losses.Size = New System.Drawing.Size(79, 24)
        Me.CB_Losses.TabIndex = 27
        Me.CB_Losses.Text = "Losses"
        Me.ToolTip1.SetToolTip(Me.CB_Losses, "Show only games lost")
        Me.CB_Losses.UseVisualStyleBackColor = True
        '
        'CB_Wins
        '
        Me.CB_Wins.AutoSize = True
        Me.CB_Wins.Location = New System.Drawing.Point(489, 27)
        Me.CB_Wins.Name = "CB_Wins"
        Me.CB_Wins.Size = New System.Drawing.Size(63, 24)
        Me.CB_Wins.TabIndex = 26
        Me.CB_Wins.Text = "Wins"
        Me.ToolTip1.SetToolTip(Me.CB_Wins, "Show only games won")
        Me.CB_Wins.UseVisualStyleBackColor = True
        '
        'PB_Date
        '
        Me.PB_Date.Image = CType(resources.GetObject("PB_Date.Image"), System.Drawing.Image)
        Me.PB_Date.Location = New System.Drawing.Point(721, 80)
        Me.PB_Date.Name = "PB_Date"
        Me.PB_Date.Size = New System.Drawing.Size(24, 24)
        Me.PB_Date.TabIndex = 25
        Me.PB_Date.TabStop = False
        '
        'PB_Length
        '
        Me.PB_Length.Image = CType(resources.GetObject("PB_Length.Image"), System.Drawing.Image)
        Me.PB_Length.Location = New System.Drawing.Point(721, 11)
        Me.PB_Length.Name = "PB_Length"
        Me.PB_Length.Size = New System.Drawing.Size(24, 24)
        Me.PB_Length.TabIndex = 24
        Me.PB_Length.TabStop = False
        '
        'DD_PlayerNames
        '
        Me.DD_PlayerNames.FormattingEnabled = True
        Me.DD_PlayerNames.Location = New System.Drawing.Point(7, 25)
        Me.DD_PlayerNames.Name = "DD_PlayerNames"
        Me.DD_PlayerNames.Size = New System.Drawing.Size(221, 28)
        Me.DD_PlayerNames.TabIndex = 21
        Me.ToolTip1.SetToolTip(Me.DD_PlayerNames, "View stats for the selected player")
        '
        'Lb_Time
        '
        Me.Lb_Time.AutoSize = True
        Me.Lb_Time.Location = New System.Drawing.Point(225, 116)
        Me.Lb_Time.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Lb_Time.Name = "Lb_Time"
        Me.Lb_Time.Size = New System.Drawing.Size(47, 20)
        Me.Lb_Time.TabIndex = 28
        Me.Lb_Time.Text = "Time:"
        '
        'DD_WithHero
        '
        Me.DD_WithHero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.DD_WithHero.DropDownWidth = 221
        Me.DD_WithHero.FormattingEnabled = True
        Me.DD_WithHero.Location = New System.Drawing.Point(262, 86)
        Me.DD_WithHero.Margin = New System.Windows.Forms.Padding(5)
        Me.DD_WithHero.Name = "DD_WithHero"
        Me.DD_WithHero.Size = New System.Drawing.Size(109, 28)
        Me.DD_WithHero.TabIndex = 31
        Me.ToolTip1.SetToolTip(Me.DD_WithHero, "Games with the selected hero in your team")
        '
        'DD_AgainstHero
        '
        Me.DD_AgainstHero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.DD_AgainstHero.DropDownWidth = 221
        Me.DD_AgainstHero.FormattingEnabled = True
        Me.DD_AgainstHero.Location = New System.Drawing.Point(374, 86)
        Me.DD_AgainstHero.Margin = New System.Windows.Forms.Padding(5)
        Me.DD_AgainstHero.Name = "DD_AgainstHero"
        Me.DD_AgainstHero.Size = New System.Drawing.Size(109, 28)
        Me.DD_AgainstHero.TabIndex = 32
        Me.ToolTip1.SetToolTip(Me.DD_AgainstHero, "Games with the selected hero in the enemy team")
        '
        'Butt_LoadReplays
        '
        Me.Butt_LoadReplays.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Butt_LoadReplays.Image = CType(resources.GetObject("Butt_LoadReplays.Image"), System.Drawing.Image)
        Me.Butt_LoadReplays.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Butt_LoadReplays.Location = New System.Drawing.Point(10, 160)
        Me.Butt_LoadReplays.Name = "Butt_LoadReplays"
        Me.Butt_LoadReplays.Size = New System.Drawing.Size(143, 48)
        Me.Butt_LoadReplays.TabIndex = 3
        Me.Butt_LoadReplays.Text = "Add Replays"
        Me.Butt_LoadReplays.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.Butt_LoadReplays, "Pick replays to add")
        Me.Butt_LoadReplays.UseVisualStyleBackColor = True
        '
        'Pic_Filter
        '
        Me.Pic_Filter.Image = CType(resources.GetObject("Pic_Filter.Image"), System.Drawing.Image)
        Me.Pic_Filter.Location = New System.Drawing.Point(176, 2)
        Me.Pic_Filter.Name = "Pic_Filter"
        Me.Pic_Filter.Size = New System.Drawing.Size(24, 24)
        Me.Pic_Filter.TabIndex = 25
        Me.Pic_Filter.TabStop = False
        Me.Pic_Filter.Visible = False
        '
        'Butt_Settings
        '
        Me.Butt_Settings.Image = CType(resources.GetObject("Butt_Settings.Image"), System.Drawing.Image)
        Me.Butt_Settings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Butt_Settings.Location = New System.Drawing.Point(10, 211)
        Me.Butt_Settings.Margin = New System.Windows.Forms.Padding(5)
        Me.Butt_Settings.Name = "Butt_Settings"
        Me.Butt_Settings.Size = New System.Drawing.Size(143, 48)
        Me.Butt_Settings.TabIndex = 4
        Me.Butt_Settings.Text = "Settings"
        Me.Butt_Settings.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Butt_Settings.UseVisualStyleBackColor = True
        '
        'lb_ReplaysLoaded
        '
        Me.lb_ReplaysLoaded.AutoSize = True
        Me.lb_ReplaysLoaded.Location = New System.Drawing.Point(6, 263)
        Me.lb_ReplaysLoaded.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lb_ReplaysLoaded.Name = "lb_ReplaysLoaded"
        Me.lb_ReplaysLoaded.Size = New System.Drawing.Size(133, 20)
        Me.lb_ReplaysLoaded.TabIndex = 29
        Me.lb_ReplaysLoaded.Text = "no replays loaded"
        '
        'Lb_Added
        '
        Me.Lb_Added.AutoSize = True
        Me.Lb_Added.Location = New System.Drawing.Point(166, 263)
        Me.Lb_Added.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Lb_Added.Name = "Lb_Added"
        Me.Lb_Added.Size = New System.Drawing.Size(0, 20)
        Me.Lb_Added.TabIndex = 30
        '
        'Timer1
        '
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Location = New System.Drawing.Point(0, 292)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.Padding = New System.Drawing.Point(0, 0)
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1348, 422)
        Me.TabControl1.TabIndex = 32
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage2.Controls.Add(Me.Chart1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 29)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(0)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(1340, 389)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Chart"
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage1.Controls.Add(Me.Lb_GameInfo)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.TB_Chat)
        Me.TabPage1.Controls.Add(Me.Lb_Players)
        Me.TabPage1.Controls.Add(Me.DD_Replays)
        Me.TabPage1.Location = New System.Drawing.Point(4, 29)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(0)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(1340, 389)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Details"
        '
        'Lb_GameInfo
        '
        Me.Lb_GameInfo.AutoSize = True
        Me.Lb_GameInfo.Location = New System.Drawing.Point(308, 90)
        Me.Lb_GameInfo.Name = "Lb_GameInfo"
        Me.Lb_GameInfo.Size = New System.Drawing.Size(0, 20)
        Me.Lb_GameInfo.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(308, 70)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 20)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Game Info"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(123, 20)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Filtered Replays"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(626, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 20)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Chat Messages"
        '
        'TB_Chat
        '
        Me.TB_Chat.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TB_Chat.Location = New System.Drawing.Point(630, 26)
        Me.TB_Chat.Multiline = True
        Me.TB_Chat.Name = "TB_Chat"
        Me.TB_Chat.ReadOnly = True
        Me.TB_Chat.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TB_Chat.Size = New System.Drawing.Size(663, 324)
        Me.TB_Chat.TabIndex = 2
        '
        'Lb_Players
        '
        Me.Lb_Players.AutoSize = True
        Me.Lb_Players.Location = New System.Drawing.Point(10, 70)
        Me.Lb_Players.Name = "Lb_Players"
        Me.Lb_Players.Size = New System.Drawing.Size(60, 20)
        Me.Lb_Players.TabIndex = 1
        Me.Lb_Players.Text = "Players"
        '
        'DD_Replays
        '
        Me.DD_Replays.DropDownHeight = 200
        Me.DD_Replays.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.DD_Replays.DropDownWidth = 600
        Me.DD_Replays.FormattingEnabled = True
        Me.DD_Replays.IntegralHeight = False
        Me.DD_Replays.Location = New System.Drawing.Point(14, 26)
        Me.DD_Replays.MaxDropDownItems = 5
        Me.DD_Replays.Name = "DD_Replays"
        Me.DD_Replays.Size = New System.Drawing.Size(507, 28)
        Me.DD_Replays.TabIndex = 0
        '
        'DD_Map
        '
        Me.DD_Map.FormattingEnabled = True
        Me.DD_Map.ItemHeight = 20
        Me.DD_Map.Location = New System.Drawing.Point(262, 27)
        Me.DD_Map.Name = "DD_Map"
        Me.DD_Map.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.DD_Map.Size = New System.Drawing.Size(221, 24)
        Me.DD_Map.TabIndex = 20
        '
        'DD_Heroes
        '
        Me.DD_Heroes.FormattingEnabled = True
        Me.DD_Heroes.ItemHeight = 20
        Me.DD_Heroes.Location = New System.Drawing.Point(262, 57)
        Me.DD_Heroes.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.DD_Heroes.Name = "DD_Heroes"
        Me.DD_Heroes.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.DD_Heroes.Size = New System.Drawing.Size(221, 24)
        Me.DD_Heroes.TabIndex = 19
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1348, 715)
        Me.Controls.Add(Me.Butt_LoadReplays)
        Me.Controls.Add(Me.Lb_Added)
        Me.Controls.Add(Me.Pic_Filter)
        Me.Controls.Add(Me.Grp_Filter)
        Me.Controls.Add(Me.lb_ReplaysLoaded)
        Me.Controls.Add(Me.Butt_Settings)
        Me.Controls.Add(Me.Grp_Chart)
        Me.Controls.Add(Me.Butt_SaveStats)
        Me.Controls.Add(Me.Butt_ReadStats)
        Me.Controls.Add(Me.Butt_ReadReplays)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Heroes of the Storm Replay Stats"
        CType(Me.Bar_MinLength, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar_MaxLength, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar_MaxDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar_MinDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grp_Chart.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grp_Filter.ResumeLayout(False)
        Me.Grp_Filter.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PB_Date, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PB_Length, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Pic_Filter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Butt_ReadReplays As Button
    Friend WithEvents DD_GameType As ComboBox
    Friend WithEvents Lb_ReplayCount As Label
    Friend WithEvents Butt_ReadStats As Button
    Friend WithEvents Butt_SaveStats As Button
    Friend WithEvents LB_Wins As Label
    Friend WithEvents LB_Winrate As Label
    Friend WithEvents Bar_MinLength As TrackBar
    Friend WithEvents Bar_MaxLength As TrackBar
    Friend WithEvents Lb_Length As Label
    Friend WithEvents Lb_Date As Label
    Friend WithEvents Bar_MaxDate As TrackBar
    Friend WithEvents Bar_MinDate As TrackBar
    Friend WithEvents Chart1 As DataVisualization.Charting.Chart
    Friend WithEvents DD_Heroes As DropdownListbox
    Friend WithEvents DD_Map As DropdownListbox
    Friend WithEvents DD_ChartInfo As ComboBox
    Friend WithEvents DD_ChartType As ComboBox
    Friend WithEvents Grp_Chart As GroupBox
    Friend WithEvents Grp_Filter As GroupBox
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents DD_PlayerNames As ComboBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PB_Length As PictureBox
    Friend WithEvents PB_Date As PictureBox
    Friend WithEvents DD_ChartData As ComboBox
    Friend WithEvents Pic_Filter As PictureBox
    Friend WithEvents Butt_Settings As Button
    Friend WithEvents CB_Losses As CheckBox
    Friend WithEvents CB_Wins As CheckBox
    Friend WithEvents Lb_Time As Label
    Friend WithEvents lb_ReplaysLoaded As Label
    Friend WithEvents Lb_Added As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents DD_OtherPlayer As ComboBox
    Friend WithEvents CB_OtherOrder As CheckBox
    Friend WithEvents DD_AgainstHero As ComboBox
    Friend WithEvents DD_WithHero As ComboBox
    Friend WithEvents Butt_LoadReplays As Button
    Friend WithEvents CB_ChatTexts As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents DD_Replays As ComboBox
    Friend WithEvents TB_Chat As TextBox
    Friend WithEvents Lb_Players As Label
    Friend WithEvents Lb_GameInfo As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents CB_WholeWords As CheckBox
    Friend WithEvents Butt_DeleteTexts As Button
End Class
