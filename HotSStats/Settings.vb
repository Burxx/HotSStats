Public Class Settings
    Dim Dirty As Boolean = False

    Private Sub Settings_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Dirty = False
        If My.Settings.Heroes Is Nothing Then
            ResetSettings()
        Else
            DGV_Heroes.Rows.Clear()

            For i = 0 To My.Settings.Heroes.Count - 1
                Dim row As New DataGridViewRow
                row.CreateCells(DGV_Heroes, My.Settings.Heroes(i), My.Settings.Aliases(i), My.Settings.HeroRole(i), My.Settings.HeroRange(i))
                DGV_Heroes.Rows.Add(row)
            Next
        End If
    End Sub

    Private Sub ResetSettings()
        DGV_Heroes.Rows.Clear()
        Dim row As DataGridViewRow
        row = New DataGridViewRow : row.CreateCells(DGV_Heroes, "Abathur", "Abatur,Абатур", "Specialist", "Melee") : DGV_Heroes.Rows.Add(row)
        row = New DataGridViewRow : row.CreateCells(DGV_Heroes, "Anub'arak", "Ануб’арак", "Warrior", "Melee") : DGV_Heroes.Rows.Add(row)
        row = New DataGridViewRow : row.CreateCells(DGV_Heroes, "Arthas", "Артас", "Warrior", "Melee") : DGV_Heroes.Rows.Add(row)
        row = New DataGridViewRow : row.CreateCells(DGV_Heroes, "Azmodan", "Asmodan,Азмодан,Azmodán", "Specialist", "Ranged") : DGV_Heroes.Rows.Add(row)
        row = New DataGridViewRow : row.CreateCells(DGV_Heroes, "Brightwing", "Funkelchen,Luisaile,Alachiara,Alafeliz,Jasnoskrzydła,Светик,Asaluz,Alasol", "Support", "Ranged") : DGV_Heroes.Rows.Add(row)
        row = New DataGridViewRow : row.CreateCells(DGV_Heroes, "Chen", "Czen,Чэнь", "Warrior", "Melee") : DGV_Heroes.Rows.Add(row)
        row = New DataGridViewRow : row.CreateCells(DGV_Heroes, "Diablo", "Диабло", "Warrior", "Melee") : DGV_Heroes.Rows.Add(row)
        row = New DataGridViewRow : row.CreateCells(DGV_Heroes, "E.T.C.", "ETC,C.T.E.", "Warrior", "Melee") : DGV_Heroes.Rows.Add(row)
        row = New DataGridViewRow : row.CreateCells(DGV_Heroes, "Falstad", "Фалстад", "Assassin", "Ranged") : DGV_Heroes.Rows.Add(row)
        row = New DataGridViewRow : row.CreateCells(DGV_Heroes, "Gazlowe", "Gazleu,Sparachiodi,Gazol,Газлоу,Gasganete", "Specialist", "Melee") : DGV_Heroes.Rows.Add(row)
        row = New DataGridViewRow : row.CreateCells(DGV_Heroes, "Illidan", "Иллидан", "Assassin", "Melee") : DGV_Heroes.Rows.Add(row)
        row = New DataGridViewRow : row.CreateCells(DGV_Heroes, "Jaina", "Джайна", "Assassin", "Ranged") : DGV_Heroes.Rows.Add(row)
        row = New DataGridViewRow : row.CreateCells(DGV_Heroes, "Johanna", "Джоанна", "Warrior", "Melee") : DGV_Heroes.Rows.Add(row)
        row = New DataGridViewRow : row.CreateCells(DGV_Heroes, "Kael'thas", "Кель'тас", "Assassin", "Ranged") : DGV_Heroes.Rows.Add(row)
        row = New DataGridViewRow : row.CreateCells(DGV_Heroes, "Kerrigan", "Керриган", "Assassin", "Melee") : DGV_Heroes.Rows.Add(row)
        row = New DataGridViewRow : row.CreateCells(DGV_Heroes, "Kharazim", "Каразим", "Support", "Melee") : DGV_Heroes.Rows.Add(row)
        row = New DataGridViewRow : row.CreateCells(DGV_Heroes, "Leoric", "Léoric,Leoryk,Леорик", "Warrior", "Melee") : DGV_Heroes.Rows.Add(row)
        row = New DataGridViewRow : row.CreateCells(DGV_Heroes, "Li Li", "Ли Ли", "Support", "Ranged") : DGV_Heroes.Rows.Add(row)
        row = New DataGridViewRow : row.CreateCells(DGV_Heroes, "Lost Vikings", "Les Vikings perdus,Vikingos Perdidos,Vichinghi Sperduti,Zaginieni Wikingowie,Потерявшиеся викинги,Os Vikings Perdidos", "Specialist", "Melee") : DGV_Heroes.Rows.Add(row)
        row = New DataGridViewRow : row.CreateCells(DGV_Heroes, "Lt. Morales", "Tte. Morales,Lt Morales,Ten. Morales,Por. Morales,Лейтенант Моралес,Teniente Morales", "Support", "Ranged") : DGV_Heroes.Rows.Add(row)
        row = New DataGridViewRow : row.CreateCells(DGV_Heroes, "Malfurion", "Малфурион", "Support", "Ranged") : DGV_Heroes.Rows.Add(row)
        row = New DataGridViewRow : row.CreateCells(DGV_Heroes, "Muradin", "Мурадин", "Warrior", "Melee") : DGV_Heroes.Rows.Add(row)
        row = New DataGridViewRow : row.CreateCells(DGV_Heroes, "Murky", "Bourbie,Fosky,Męcik,Мурчаль,Murquinho", "Specialist", "Melee") : DGV_Heroes.Rows.Add(row)
        row = New DataGridViewRow : row.CreateCells(DGV_Heroes, "Nazeebo", "Nasibo,Nazebo,Назибо,Nazibo", "Specialist", "Ranged") : DGV_Heroes.Rows.Add(row)
        row = New DataGridViewRow : row.CreateCells(DGV_Heroes, "Nova", "Нова", "Assassin", "Ranged") : DGV_Heroes.Rows.Add(row)
        row = New DataGridViewRow : row.CreateCells(DGV_Heroes, "Raynor", "Рейнор", "Assassin", "Ranged") : DGV_Heroes.Rows.Add(row)
        row = New DataGridViewRow : row.CreateCells(DGV_Heroes, "Rehgar", "Регар", "Support", "Melee") : DGV_Heroes.Rows.Add(row)
        row = New DataGridViewRow : row.CreateCells(DGV_Heroes, "Rexxar", "Рексар", "Warrior", "Ranged") : DGV_Heroes.Rows.Add(row)
        row = New DataGridViewRow : row.CreateCells(DGV_Heroes, "Sergeant Hammer", "Sgt Marteau,Sgt. Hammer,Sgto. Martillo,Sierżant Petarda,Сержант Кувалда,Sgt. Marreta,Sargento Maza", "Specialist", "Ranged") : DGV_Heroes.Rows.Add(row)
        row = New DataGridViewRow : row.CreateCells(DGV_Heroes, "Sonya", "Sonia,Соня", "Warrior", "Melee") : DGV_Heroes.Rows.Add(row)
        row = New DataGridViewRow : row.CreateCells(DGV_Heroes, "Stitches", "Kleiner,Balafré,Puntos,Tritacarne,Zszywaniec,Стежок,Suturino", "Warrior", "Melee") : DGV_Heroes.Rows.Add(row)
        row = New DataGridViewRow : row.CreateCells(DGV_Heroes, "Sylvanas", "Sylwana,Сильвана,Sylvana", "Specialist", "Ranged") : DGV_Heroes.Rows.Add(row)
        row = New DataGridViewRow : row.CreateCells(DGV_Heroes, "Tassadar", "Тассадар", "Support", "Ranged") : DGV_Heroes.Rows.Add(row)
        row = New DataGridViewRow : row.CreateCells(DGV_Heroes, "The Butcher", "Der Schlächter,Le Boucher,Macellaio,El carnicero,Rzeźnik,Мясник,O Açougueiro", "Assassin", "Melee") : DGV_Heroes.Rows.Add(row)
        row = New DataGridViewRow : row.CreateCells(DGV_Heroes, "Thrall", "Тралл", "Assassin", "Melee") : DGV_Heroes.Rows.Add(row)
        row = New DataGridViewRow : row.CreateCells(DGV_Heroes, "Tychus", "Тайкус", "Assassin", "Ranged") : DGV_Heroes.Rows.Add(row)
        row = New DataGridViewRow : row.CreateCells(DGV_Heroes, "Tyrael", "Tyraël,Тираэль", "Warrior", "Melee") : DGV_Heroes.Rows.Add(row)
        row = New DataGridViewRow : row.CreateCells(DGV_Heroes, "Tyrande", "Тиранда", "Support", "Ranged") : DGV_Heroes.Rows.Add(row)
        row = New DataGridViewRow : row.CreateCells(DGV_Heroes, "Uther", "Утер", "Support", "Melee") : DGV_Heroes.Rows.Add(row)
        row = New DataGridViewRow : row.CreateCells(DGV_Heroes, "Valla", "Cacciatrice di demoni,Валла", "Assassin", "Ranged") : DGV_Heroes.Rows.Add(row)
        row = New DataGridViewRow : row.CreateCells(DGV_Heroes, "Zagara", "Загара", "Specialist", "Ranged") : DGV_Heroes.Rows.Add(row)
        row = New DataGridViewRow : row.CreateCells(DGV_Heroes, "Zeratul", "Зератул", "Assassin", "Melee") : DGV_Heroes.Rows.Add(row)
        row = New DataGridViewRow : row.CreateCells(DGV_Heroes, "Artanis", "Артанис", "Warrior", "Melee") : DGV_Heroes.Rows.Add(row)
        row = New DataGridViewRow : row.CreateCells(DGV_Heroes, "Cho", "Czo,Чо", "Warrior", "Melee") : DGV_Heroes.Rows.Add(row)
        row = New DataGridViewRow : row.CreateCells(DGV_Heroes, "Gall", "Gal,Галл", "Assassin", "Ranged") : DGV_Heroes.Rows.Add(row)
        row = New DataGridViewRow : row.CreateCells(DGV_Heroes, "Lunara", "Лунара", "Assassin", "Ranged") : DGV_Heroes.Rows.Add(row)
        row = New DataGridViewRow : row.CreateCells(DGV_Heroes, "Greymane", "Graummähne,Cringris,Grisetête,Mantogrigio,Szarogrzywy,Седогрив", "Assassin", "Ranged") : DGV_Heroes.Rows.Add(row)
        row = New DataGridViewRow : row.CreateCells(DGV_Heroes, "Li-Ming", "Ли-Мин", "Assassin", "Ranged") : DGV_Heroes.Rows.Add(row)
        row = New DataGridViewRow : row.CreateCells(DGV_Heroes, "Xul", "Зул", "Specialist", "Melee") : DGV_Heroes.Rows.Add(row)
        row = New DataGridViewRow : row.CreateCells(DGV_Heroes, "Dehaka", "Дехака", "Warrior", "Melee") : DGV_Heroes.Rows.Add(row)
        row = New DataGridViewRow : row.CreateCells(DGV_Heroes, "Tracer", "Smuga,Трейсер", "Assassin", "Ranged") : DGV_Heroes.Rows.Add(row)
        row = New DataGridViewRow : row.CreateCells(DGV_Heroes, "Chromie", "Cromi,Cromie,Chronia,Хроми,Crona", "Assassin", "Ranged") : DGV_Heroes.Rows.Add(row)
        row = New DataGridViewRow : row.CreateCells(DGV_Heroes, "Medivh", "Медив", "Specialist", "Ranged") : DGV_Heroes.Rows.Add(row)
    End Sub
    Private Sub Butt_Ok_Click(sender As Object, e As EventArgs) Handles Butt_Ok.Click
        SaveSettings()
        Me.Close()
    End Sub

    Private Sub Butt_Cancel_Click(sender As Object, e As EventArgs) Handles Butt_Cancel.Click
        If Not Dirty OrElse MsgBox("Lose all changes?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub

    Sub SaveSettings()
        Dim Hero As New Specialized.StringCollection
        Dim Aliases As New Specialized.StringCollection
        Dim HeroRole As New Specialized.StringCollection
        Dim HeroRange As New Specialized.StringCollection
        For i = 0 To DGV_Heroes.RowCount - 1
            If Trim(CType(DGV_Heroes.Rows(i).Cells(0).FormattedValue, String)) <> "" Then
                Hero.Add(CType(DGV_Heroes.Rows(i).Cells(0).FormattedValue, String))
                Aliases.Add(CType(DGV_Heroes.Rows(i).Cells(1).FormattedValue, String))
                HeroRole.Add(CType(DGV_Heroes.Rows(i).Cells(2).FormattedValue, String))
                HeroRange.Add(CType(DGV_Heroes.Rows(i).Cells(3).FormattedValue, String))
            End If
        Next
        My.Settings.Heroes = Hero
        My.Settings.HeroRange = HeroRange
        My.Settings.HeroRole = HeroRole
        My.Settings.Aliases = Aliases
        My.Settings.Save()
    End Sub


    Private Sub Butt_Reset_Click(sender As Object, e As EventArgs) Handles Butt_Reset.Click
        If MsgBox("Really reset to default values and lose all changes made previously?", MsgBoxStyle.YesNo, "Reset to default") = MsgBoxResult.Yes Then
            ResetSettings()
        End If
    End Sub

    Private Sub DGV_Heroes_UserAddedRow(sender As Object, e As DataGridViewRowEventArgs) Handles DGV_Heroes.UserAddedRow
        Dirty = True
    End Sub

    Private Sub DGV_Heroes_UserDeletedRow(sender As Object, e As DataGridViewRowEventArgs) Handles DGV_Heroes.UserDeletedRow
        Dirty = True
    End Sub

    Private Sub DGV_Heroes_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_Heroes.CellValueChanged
        Dirty = True
    End Sub
End Class