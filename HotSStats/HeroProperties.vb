Public Class HeroProperties
    Public Enum HeroRoles
        Warrior
        Assassin
        Support
        Specialist
        Unknown
    End Enum

    Public Enum HeroAttackTypes
        Melee
        Ranged
        Unknown
    End Enum

    Dim Roles As New Dictionary(Of String, HeroRoles)
    Dim AttackTypes As New Dictionary(Of String, HeroAttackTypes)

    Public Sub New()
        Roles.Clear()
        AttackTypes.Clear()
        If My.Settings.Heroes IsNot Nothing Then
            For i = 0 To My.Settings.Heroes.Count - 1
                Dim HeroRole As HeroRoles
                Dim HeroAttack As HeroAttackTypes
                Dim Hero = LCase(Trim(My.Settings.Heroes(i)))
                If Not Roles.ContainsKey(Hero) Then
                    [Enum].TryParse(Of HeroRoles)(My.Settings.HeroRole(i), HeroRole)
                    Roles.Add(Hero, HeroRole)
                    [Enum].TryParse(Of HeroAttackTypes)(My.Settings.HeroRange(i), HeroAttack)
                    AttackTypes.Add(Hero, HeroAttack)
                End If
                If My.Settings.Aliases(i) <> "" Then
                    Dim spl = Split(My.Settings.Aliases(i), ",")
                    For Each ali In spl
                        Hero = LCase(Trim(ali))
                        If Not Roles.ContainsKey(Hero) Then
                            Roles.Add(Hero, HeroRole)
                            AttackTypes.Add(Hero, HeroAttack)
                        End If
                    Next
                End If
            Next
        End If
    End Sub

    Public Function Role(Hero As String) As HeroRoles
        Hero = LCase(Trim(Hero))
        If Roles.ContainsKey(Hero) Then
            Return Roles(Hero)
        Else
            Return HeroRoles.Unknown
        End If
    End Function

    ''' <summary>
    ''' Returns Ranged or Melee 
    ''' </summary>
    ''' <param name="Hero"></param>
    ''' <returns></returns>
    Public Function AttackType(Hero As String) As HeroAttackTypes
        Hero = LCase(Trim(Hero))
        If Roles.ContainsKey(Hero) Then
            Return AttackTypes(LCase(Trim(Hero)))
        Else
            Return HeroAttackTypes.Unknown
        End If
    End Function

End Class
