Imports Microsoft.Office.Interop.Excel
Imports System.Runtime.InteropServices

Public Class HojaResumen
    Dim _xlWorkBook As Workbook
    Dim help As New HelperReporteVE

    Sub New(xlWorkBook As Workbook)
        Me._xlWorkBook = xlWorkBook
    End Sub

    Sub Generar(cantCols As Integer)
        Dim xlWorkSheet As New Worksheet
        xlWorkSheet = _xlWorkBook.Worksheets.Item(1) '1: HOJA RESUMEN
        xlWorkSheet.Select()
        _xlWorkBook.Windows(1).Zoom = 100

        'Formato General Texto para la hoja
        xlWorkSheet.Range(xlWorkSheet.Cells(1, 1), xlWorkSheet.Cells(200, 200)).Font.Name = "Calibri"
        xlWorkSheet.Range(xlWorkSheet.Cells(1, 1), xlWorkSheet.Cells(200, 200)).Font.Size = 11

        xlWorkSheet.Cells(1, 7) = "DÍAS ÚTILES:"
        xlWorkSheet.Range(xlWorkSheet.Cells(1, 7), xlWorkSheet.Cells(1, 10)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
        xlWorkSheet.Range(xlWorkSheet.Cells(1, 7), xlWorkSheet.Cells(1, 10)).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignBottom
        xlWorkSheet.Range(xlWorkSheet.Cells(1, 8), xlWorkSheet.Cells(1, 8)).FormulaLocal = "='AVANCE SODIMAC'!W2"
        xlWorkSheet.Cells(1, 9) = "DÍAS AVANCE:"
        xlWorkSheet.Range(xlWorkSheet.Cells(1, 10), xlWorkSheet.Cells(1, 10)).FormulaLocal = "='AVANCE SODIMAC'!Y2"

        xlWorkSheet.Cells(7, 4) = "PLAN VENTA NETA"
        xlWorkSheet.Cells(8, 4) = "VENTA NETA CONTADO"
        xlWorkSheet.Cells(9, 4) = "VENTA NETA CRÉDITO"
        xlWorkSheet.Cells(10, 4) = "VENTA NETA TOTAL"
        xlWorkSheet.Cells(11, 4) = "CUMPLIMIENTO PLAN"
        xlWorkSheet.Cells(12, 4) = "PROYECTADO"
        xlWorkSheet.Cells(13, 4) = "CUMPLIMIENTO PROYECTADO"
        xlWorkSheet.Range(xlWorkSheet.Cells(7, 4), xlWorkSheet.Cells(13, 4)).Font.Size = 12
        xlWorkSheet.Range(xlWorkSheet.Cells(7, 4), xlWorkSheet.Cells(13, 4)).Font.Bold = True

        xlWorkSheet.Range(xlWorkSheet.Cells(5, 5), xlWorkSheet.Cells(6, 6)).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
        xlWorkSheet.Cells(5, 5) = "TOTAL MAESTRO"
        xlWorkSheet.Range(xlWorkSheet.Cells(5, 5), xlWorkSheet.Cells(6, 5)).Merge()
        xlWorkSheet.Range(xlWorkSheet.Cells(5, 5), xlWorkSheet.Cells(13, 5)).Font.Size = 20
        xlWorkSheet.Range(xlWorkSheet.Cells(5, 6), xlWorkSheet.Cells(5, 6)).Interior.Color = RGB(48, 84, 150)
        'Formato numeros
        xlWorkSheet.Range(xlWorkSheet.Cells(7, 5), xlWorkSheet.Cells(10, 6)).NumberFormat = "#,##0"
        xlWorkSheet.Range(xlWorkSheet.Cells(10, 5), xlWorkSheet.Cells(10, 5)).FormulaLocal = "=SI(SUMA(E8:E9)=0," & Chr(34) & Chr(34) & ",SUMA(E8:E9))"
        xlWorkSheet.Range(xlWorkSheet.Cells(11, 5), xlWorkSheet.Cells(11, 5)).FormulaLocal = "=SIERROR(E10/E7," & Chr(34) & Chr(34) & ")"
        xlWorkSheet.Range(xlWorkSheet.Cells(12, 5), xlWorkSheet.Cells(12, 5)).FormulaLocal = "=SIERROR((+E10/$J$1*$H$1)/0.96," & Chr(34) & Chr(34) & ")"
        xlWorkSheet.Range(xlWorkSheet.Cells(13, 5), xlWorkSheet.Cells(13, 5)).FormulaLocal = "=SIERROR(E12/E7," & Chr(34) & Chr(34) & ")"

        xlWorkSheet.Cells(5, 6) = "TOTAL SODIMAC"
        xlWorkSheet.Range(xlWorkSheet.Cells(5, 6), xlWorkSheet.Cells(6, 6)).Merge()
        xlWorkSheet.Range(xlWorkSheet.Cells(5, 6), xlWorkSheet.Cells(6, 6)).Font.Bold = True
        xlWorkSheet.Range(xlWorkSheet.Cells(5, 6), xlWorkSheet.Cells(13, 6)).Font.Size = 20
        xlWorkSheet.Range(xlWorkSheet.Cells(5, 6), xlWorkSheet.Cells(6, 6)).Font.Color = RGB(48, 84, 150) 'azul

        xlWorkSheet.Range(xlWorkSheet.Cells(7, 6), xlWorkSheet.Cells(7, 6)).FormulaLocal = "='AVANCE SODIMAC'!" & help.ColName(cantCols) & "8"
        xlWorkSheet.Range(xlWorkSheet.Cells(8, 6), xlWorkSheet.Cells(8, 6)).FormulaLocal = "='AVANCE SODIMAC'!" & help.ColName(cantCols) & "9"
        xlWorkSheet.Range(xlWorkSheet.Cells(9, 6), xlWorkSheet.Cells(9, 6)).FormulaLocal = "='AVANCE SODIMAC'!" & help.ColName(cantCols) & "10"
        xlWorkSheet.Range(xlWorkSheet.Cells(10, 6), xlWorkSheet.Cells(10, 6)).FormulaLocal = "=SI(SUMA(F8:F9) = 0," & Chr(34) & Chr(34) & ",SUMA(F8:F9))"
        xlWorkSheet.Range(xlWorkSheet.Cells(11, 5), xlWorkSheet.Cells(11, 6)).NumberFormat = "0.00%"
        xlWorkSheet.Range(xlWorkSheet.Cells(11, 6), xlWorkSheet.Cells(11, 6)).FormulaLocal = "=SIERROR(F10/F7," & Chr(34) & Chr(34) & ")"
        xlWorkSheet.Range(xlWorkSheet.Cells(12, 5), xlWorkSheet.Cells(12, 6)).NumberFormat = "#,##0"
        xlWorkSheet.Range(xlWorkSheet.Cells(12, 6), xlWorkSheet.Cells(12, 6)).FormulaLocal = "=SIERROR(F10/$J$1*$H$1," & Chr(34) & Chr(34) & ")"
        xlWorkSheet.Range(xlWorkSheet.Cells(13, 5), xlWorkSheet.Cells(13, 6)).NumberFormat = "0.00%"
        xlWorkSheet.Range(xlWorkSheet.Cells(13, 6), xlWorkSheet.Cells(13, 6)).FormulaLocal = "=SIERROR(F12/F7," & Chr(34) & Chr(34) & ")"

        xlWorkSheet.Range(xlWorkSheet.Cells(7, 5), xlWorkSheet.Cells(7, 6)).Font.Bold = True
        xlWorkSheet.Range(xlWorkSheet.Cells(5, 5), xlWorkSheet.Cells(7, 6)).Interior.Color = RGB(217, 217, 217) 'fondo gris
        xlWorkSheet.Range(xlWorkSheet.Cells(5, 5), xlWorkSheet.Cells(13, 6)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

        xlWorkSheet.Range(xlWorkSheet.Cells(11, 5), xlWorkSheet.Cells(11, 6)).Interior.Color = RGB(217, 217, 217) 'fondo gris

        'Setea bordes cabecera
        help.SetAllBorders_Thin(xlWorkSheet.Range(xlWorkSheet.Cells(1, 7), xlWorkSheet.Cells(1, 10)))
        help.SetBordesCeldas_Medium(xlWorkSheet.Range(xlWorkSheet.Cells(1, 7), xlWorkSheet.Cells(1, 10)))

        'Setea bordes tabla
        help.SetAllBorders_Thin(xlWorkSheet.Range(xlWorkSheet.Cells(7, 4), xlWorkSheet.Cells(13, 6)))

        help.SetBordesCeldas_Thin(xlWorkSheet.Range(xlWorkSheet.Cells(7, 4), xlWorkSheet.Cells(13, 4)))
        help.SetAllBorders_Thin(xlWorkSheet.Range(xlWorkSheet.Cells(5, 5), xlWorkSheet.Cells(13, 6)))
        help.SetBordesCeldas_Medium(xlWorkSheet.Range(xlWorkSheet.Cells(7, 4), xlWorkSheet.Cells(13, 6)))
        help.SetBordesCeldas_Medium(xlWorkSheet.Range(xlWorkSheet.Cells(5, 5), xlWorkSheet.Cells(13, 5)))
        help.SetBordesCeldas_Medium(xlWorkSheet.Range(xlWorkSheet.Cells(5, 6), xlWorkSheet.Cells(13, 6)))
        help.SetBordesCeldas_Medium(xlWorkSheet.Range(xlWorkSheet.Cells(13, 5), xlWorkSheet.Cells(13, 6)))

        xlWorkSheet.Columns("D").AutoFit()
        xlWorkSheet.Columns("E").AutoFit()
        xlWorkSheet.Columns("F").AutoFit()
        xlWorkSheet.Columns("G").AutoFit()
        xlWorkSheet.Columns("I").AutoFit()

        Marshal.ReleaseComObject(xlWorkSheet)
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        Marshal.ReleaseComObject(Me._xlWorkBook)
    End Sub
End Class
