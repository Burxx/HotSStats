Imports Heroes.ReplayParser

<Serializable()> Public Class Replays
    Public TimeOfLastUpdate As DateTime
    Public DateOfLastAddedReplay As DateTime = DateTime.MinValue
    'Public Stats As New List(Of ReplayStats)
    Public Stats As New Concurrent.ConcurrentBag(Of ReplayStats)
    Public selected As Integer
    Public Wins As Integer
    Public Sub New()
    End Sub
End Class

<Serializable()> Public Class ReplayStats
    Public isWinner As Boolean
    Public Hero As String
    Public playerFound As Boolean
    Public isSelected As Boolean
    Public Gamemode As GameMode
    Public Time As DateTime
    Public Length As TimeSpan
    Public Map As String
    Public MapWidth As Integer
    Public MapHeight As Integer
    Public Teams(1) As ReplayStatsTeam
    Sub New()
        Teams(0) = New ReplayStatsTeam
        Teams(1) = New ReplayStatsTeam
    End Sub
    Public Function OwnTeam() As ReplayStatsTeam
        If isWinner = Teams(0).isWinner Then Return Teams(0)
        Return Teams(1)
    End Function
    Public Function EnemyTeam() As ReplayStatsTeam
        If isWinner = Teams(0).isWinner Then Return Teams(1)
        Return Teams(0)
    End Function

End Class

<Serializable()> Public Class ReplayStatsTeam
    Public isWinner As Boolean
    Public Players As New List(Of ReplayStatsPlayer)
    Public Milestones As New List(Of TimeSpan)
    Public Humans As Integer
    Public Function Contains(name As String) As Boolean
        For Each p In Players
            If p.Name = name Then Return True
        Next
        Return False
    End Function
End Class

<Serializable()> Public Class ReplayStatsPlayer
    Public Name As String
    Public Hero As String
    Public Level As Integer
    Public Type As PlayerType
    Public Autoselect As Boolean
End Class
