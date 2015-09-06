Imports System.Windows.Forms

Public Class DropdownListbox : Inherits ListBox
    Dim closeTimer As New Timer

    Sub New()
        AddHandler closeTimer.Tick, AddressOf TimerTick
    End Sub

    Private Sub DropdownListbox_LostFocus(sender As Object, e As EventArgs) Handles Me.LostFocus
        Shrink()
    End Sub

    Private Sub DropdownListbox_MouseHover(sender As Object, e As EventArgs) Handles Me.MouseHover
        closeTimer.Stop()
        If Height < 30 Then
            Height = 250
            Focus()
        End If
    End Sub

    Private Sub DropdownListbox_MouseLeave(sender As Object, e As EventArgs) Handles Me.MouseLeave
        closeTimer.Interval = 800
        closeTimer.Start()
    End Sub

    Public Sub Shrink()
        Height = 30
        closeTimer.Stop()
    End Sub
    Sub TimerTick(myObject As Object, ByVal myEventArgs As EventArgs)
        Shrink()
    End Sub

    Public Event Scroll As ScrollEventHandler
    Protected Overridable Sub OnScroll(e As ScrollEventArgs)
        closeTimer.Stop()
        closeTimer.Start()
    End Sub
    Protected Overrides Sub WndProc(ByRef m As Message)
        MyBase.WndProc(m)
        If m.Msg = &H115 Then
            ' Trap WM_VSCROLL
            OnScroll(New ScrollEventArgs(CType(m.WParam.ToInt32() And &HFFFF, ScrollEventType), 0))
        End If
    End Sub

    Public Function isItemSelected(Text As String) As Boolean
        For Each i As String In SelectedItems
            If i = Text Then Return True
        Next
        Return False
    End Function

End Class
