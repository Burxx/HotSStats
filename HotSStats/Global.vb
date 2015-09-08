Module Globals

    Enum HeroRoles
        Warrior
        Assassin
        Support
        Specialist
    End Enum

    Enum AttackTypes
        Melee
        Ranged
    End Enum

    Public ReplayList As New Replays
    Public PlayerName As String
    Public OtherPlayerName As String
    'Public HeroRole As New Dictionary(Of String, HeroRoles)
    'Public AttackType As New Dictionary(Of String, AttackTypes)
    Public AllHeroProperties As New HeroProperties
    Public TierLevel() As String = {"N/A", "Tier 1 (Lvl 1)", "Tier 2 (Lvl 4)", "Tier 3 (Lvl 7)", "Tier 4 (Lvl 10)", "Tier 5 (Lvl 13)", "Tier 6 (Lvl 16)", "Tier 7 (Lvl 20)"}

    Public LoadingComplete As Boolean = False
    Public Closing As Boolean = False
    Public skipCounter As Integer = 0
    Public addCounter As Integer = 0


End Module
