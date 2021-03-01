Imports Microsoft.Office.Interop.Excel
Imports System.Runtime.InteropServices

Public Class HelperReporteVE
    'Dim sheExcel As New Worksheet
    'Retorna el nombre de la columna
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

    ''' <summary>
    ''' Setea Bordes alrededor de un rango de celdas
    ''' </summary>
    ''' <param name="borders"></param>
    ''' <remarks></remarks>
    Public Sub SetBordesCeldas_Thin(rng As Range)
        With rng
            .Borders(XlBordersIndex.xlEdgeTop).LineStyle = XlLineStyle.xlContinuous
            .Borders(XlBordersIndex.xlEdgeTop).Weight = XlBorderWeight.xlThin
            .Borders(XlBordersIndex.xlEdgeLeft).LineStyle = XlLineStyle.xlContinuous
            .Borders(XlBordersIndex.xlEdgeLeft).Weight = XlBorderWeight.xlThin
            .Borders(XlBordersIndex.xlEdgeRight).LineStyle = XlLineStyle.xlContinuous
            .Borders(XlBordersIndex.xlEdgeRight).Weight = XlBorderWeight.xlThin
            .Borders(XlBordersIndex.xlEdgeBottom).LineStyle = XlLineStyle.xlContinuous
            .Borders(XlBordersIndex.xlEdgeBottom).Weight = XlBorderWeight.xlThin
        End With
    End Sub

    ''' <summary>
    ''' Setea Bordes alrededor de un rango de celdas
    ''' </summary>
    ''' <param name="borders"></param>
    ''' <remarks></remarks>
    Public Sub SetBordesCeldas_Medium(rng As Range)
        With rng
            .Borders(XlBordersIndex.xlEdgeTop).Weight = XlBorderWeight.xlMedium
            .Borders(XlBordersIndex.xlEdgeTop).LineStyle = XlLineStyle.xlContinuous
            .Borders(XlBordersIndex.xlEdgeLeft).Weight = XlBorderWeight.xlMedium
            .Borders(XlBordersIndex.xlEdgeLeft).LineStyle = XlLineStyle.xlContinuous
            .Borders(XlBordersIndex.xlEdgeRight).Weight = XlBorderWeight.xlMedium
            .Borders(XlBordersIndex.xlEdgeRight).LineStyle = XlLineStyle.xlContinuous
            .Borders(XlBordersIndex.xlEdgeBottom).Weight = XlBorderWeight.xlMedium
            .Borders(XlBordersIndex.xlEdgeBottom).LineStyle = XlLineStyle.xlContinuous
        End With
    End Sub

    Public Sub SetAllBorders_Thin(rng As Range)
        rng.Borders.Weight = XlBorderWeight.xlThin
    End Sub

    Public Sub SetAllBorders_Medium(rng As Range)
        rng.Borders.Weight = XlBorderWeight.xlMedium
    End Sub

    Function getNombreMes(NumMes As Integer) As String
        Dim NombreMes As String = String.Empty
        Select Case NumMes
            Case 1
                NombreMes = "Enero"
            Case 2
                NombreMes = "Febrero"
            Case 3
                NombreMes = "Marzo"
            Case 4
                NombreMes = "Abril"
            Case 5
                NombreMes = "Mayo"
            Case 6
                NombreMes = "Junio"
            Case 7
                NombreMes = "Julio"
            Case 8
                NombreMes = "Agosto"
            Case 9
                NombreMes = "Septiembre"
            Case 10
                NombreMes = "Octubre"
            Case 11
                NombreMes = "Noviembre"
            Case 12
                NombreMes = "Diciembre"
        End Select
        Return NombreMes
    End Function

    'Protected Overrides Sub Finalize()
    '    MyBase.Finalize()
    '    Marshal.ReleaseComObject(sheExcel)
    'End Sub

End Class
