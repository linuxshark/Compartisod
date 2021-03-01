Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Public Class General
    Public Shared Function TimeToSeconds(ByVal Time As String) As Integer
        Dim T As String() = Time.Split(":")

        If (T.Length = 3) Then
            Return (T(0) * 3600) + (T(1) * 60) + T(2)
        ElseIf (T.Length = 2) Then
            Return (T(0) * 3600) + (T(1) * 60)
        Else
            Return (T(0) * 3600)
        End If
    End Function

    Public Shared Function SecondsToTime(ByVal Seconds As Integer) As String
        Dim H As String
        Dim M As String
        Dim S As String

        H = (Int(Seconds / 3600)).ToString().PadLeft(2, "0")
        M = (Int((Seconds - (H * 3600)) / 60)).ToString().PadLeft(2, "0")
        S = (Int(Seconds - (H * 3600 + M * 60))).ToString().PadLeft(2, "0")

        Return H + ":" + M + ":" + S
    End Function

    Public Shared Function DiffTime(ByVal TF As String, ByVal TI As String) As String
        Dim Diff As String
        Diff = TimeToSeconds(TF) - TimeToSeconds(TI)

        Return SecondsToTime(Diff)
    End Function
End Class
