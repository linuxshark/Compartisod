Imports OfficeOpenXml
Imports OfficeOpenXml.Style
Imports System.Drawing

Public Class HelperReporteVAP
    Function ColName(columnNumber As Integer) As String
        Dim dividend As Integer = columnNumber
        Dim columnName As String = String.Empty
        Dim modulo As Integer

        While (dividend > 0)
            modulo = (dividend - 1) Mod 26
            columnName = Convert.ToChar(65 + modulo).ToString() + columnName
            dividend = Convert.ToInt32((dividend - modulo) / 26)
        End While
        Return columnName
    End Function

    Public Sub SetAllBorders_Thin(rng As ExcelRange)
        rng.Style.Border.Bottom.Style = Style.ExcelBorderStyle.Thin
        rng.Style.Border.Top.Style = Style.ExcelBorderStyle.Thin
        rng.Style.Border.Left.Style = Style.ExcelBorderStyle.Thin
        rng.Style.Border.Right.Style = Style.ExcelBorderStyle.Thin
    End Sub

    Public Sub SetAllBorders_Medium(rng As ExcelRange)
        rng.Style.Border.Top.Style = Style.ExcelBorderStyle.Medium
        rng.Style.Border.Bottom.Style = Style.ExcelBorderStyle.Medium
        rng.Style.Border.Left.Style = Style.ExcelBorderStyle.Medium
        rng.Style.Border.Right.Style = Style.ExcelBorderStyle.Medium
    End Sub


End Class
