<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Settings
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Settings))
        Me.DGV_Heroes = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Butt_Ok = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Butt_Reset = New System.Windows.Forms.Button()
        Me.Butt_Cancel = New System.Windows.Forms.Button()
        CType(Me.DGV_Heroes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DGV_Heroes
        '
        Me.DGV_Heroes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGV_Heroes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_Heroes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column4, Me.Column2, Me.Column3})
        Me.DGV_Heroes.Location = New System.Drawing.Point(12, 26)
        Me.DGV_Heroes.Name = "DGV_Heroes"
        Me.DGV_Heroes.Size = New System.Drawing.Size(644, 455)
        Me.DGV_Heroes.TabIndex = 1
        '
        'Column1
        '
        Me.Column1.HeaderText = "Hero"
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 150
        '
        'Column4
        '
        Me.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column4.HeaderText = "Aliases (localized names)"
        Me.Column4.Name = "Column4"
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column2.HeaderText = "Role"
        Me.Column2.Items.AddRange(New Object() {"Warrior", "Assassin", "Support", "Specialist"})
        Me.Column2.Name = "Column2"
        Me.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Column2.Width = 54
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column3.HeaderText = "Attack Type"
        Me.Column3.Items.AddRange(New Object() {"Melee", "Ranged"})
        Me.Column3.Name = "Column3"
        Me.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Column3.Width = 90
        '
        'Butt_Ok
        '
        Me.Butt_Ok.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Butt_Ok.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Butt_Ok.Image = CType(resources.GetObject("Butt_Ok.Image"), System.Drawing.Image)
        Me.Butt_Ok.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Butt_Ok.Location = New System.Drawing.Point(664, 26)
        Me.Butt_Ok.Name = "Butt_Ok"
        Me.Butt_Ok.Size = New System.Drawing.Size(106, 40)
        Me.Butt_Ok.TabIndex = 2
        Me.Butt_Ok.Text = "OK"
        Me.Butt_Ok.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Butt_Ok.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(592, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Add missing heroes (one per line) and their localized names (comma separated list" &
    ")"
        '
        'Butt_Reset
        '
        Me.Butt_Reset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Butt_Reset.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Butt_Reset.Image = CType(resources.GetObject("Butt_Reset.Image"), System.Drawing.Image)
        Me.Butt_Reset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Butt_Reset.Location = New System.Drawing.Point(664, 441)
        Me.Butt_Reset.Name = "Butt_Reset"
        Me.Butt_Reset.Size = New System.Drawing.Size(106, 40)
        Me.Butt_Reset.TabIndex = 4
        Me.Butt_Reset.Text = "Default"
        Me.Butt_Reset.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Butt_Reset.UseVisualStyleBackColor = True
        '
        'Butt_Cancel
        '
        Me.Butt_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Butt_Cancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Butt_Cancel.Image = CType(resources.GetObject("Butt_Cancel.Image"), System.Drawing.Image)
        Me.Butt_Cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Butt_Cancel.Location = New System.Drawing.Point(664, 76)
        Me.Butt_Cancel.Name = "Butt_Cancel"
        Me.Butt_Cancel.Size = New System.Drawing.Size(106, 40)
        Me.Butt_Cancel.TabIndex = 5
        Me.Butt_Cancel.Text = "Cancel"
        Me.Butt_Cancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Butt_Cancel.UseVisualStyleBackColor = True
        '
        'Settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(780, 493)
        Me.Controls.Add(Me.Butt_Cancel)
        Me.Controls.Add(Me.Butt_Reset)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Butt_Ok)
        Me.Controls.Add(Me.DGV_Heroes)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Settings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Settings"
        CType(Me.DGV_Heroes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DGV_Heroes As DataGridView
    Friend WithEvents Butt_Ok As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewComboBoxColumn
    Friend WithEvents Column3 As DataGridViewComboBoxColumn
    Friend WithEvents Butt_Reset As Button
    Friend WithEvents Butt_Cancel As Button
End Class
