Imports Heroes.ReplayParser
Imports System.Collections
Imports System.Text

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
    Public Filename As String
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
    Public Messages As New List(Of ChatMessage)
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
    Public Function PlayerName(index As Integer) As String
        For Each t In Teams
            For Each p In t.Players
                If p.Number = index Then Return p.Name
            Next
        Next
        Return ""
    End Function
    Public Function Chat() As String
        Dim SB As New StringBuilder
        For Each msg In Messages
            SB.AppendLine("(→" + msg.MessageTarget.ToString + ") " + msg.Timestamp.ToString + " " + PlayerName(msg.PlayerId) + ": " + msg.Message)
        Next
        Return SB.ToString
    End Function

End Class

<Serializable()> Public Class ReplayStatsTeam
    Public isWinner As Boolean
    Public Players As New List(Of ReplayStatsPlayer)
    Public Milestones As New List(Of TimeSpan)
    Public Humans As Integer
    Public Function ContainsPlayer(name As String) As Boolean
        For Each p In Players
            If p.Name = name Then Return True
        Next
        Return False
    End Function
    Public Function ContainsHero(name As String) As Boolean
        For Each p In Players
            If p.Hero = name Then Return True
        Next
        Return False
    End Function
End Class

<Serializable()> Public Class ReplayStatsPlayer
    Public Name As String
    Public Hero As String
    Public Level As Integer
    Public Type As PlayerType
    Public Number As Integer
    Public Autoselect As Boolean
End Class
