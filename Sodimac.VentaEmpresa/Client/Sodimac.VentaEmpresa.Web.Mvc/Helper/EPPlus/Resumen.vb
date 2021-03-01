Imports OfficeOpenXml
Imports OfficeOpenXml.Style
Imports System.Drawing

Public Class Resumen
    Dim _xlWorkBook As ExcelWorkbook
    Dim help As New HelperReporteVAP

    Sub New(xlWorkBook As ExcelWorkbook)
        Me._xlWorkBook = xlWorkBook
    End Sub

    Sub Generar(cantCols As Integer, NomMarca As String)
        Dim xlWorkSheet As ExcelWorksheet
        xlWorkSheet = _xlWorkBook.Worksheets.Item(1) '1: HOJA RESUMEN
        Dim ws2 As ExcelWorksheet
        ws2 = _xlWorkBook.Worksheets.Item(2)
        xlWorkSheet.Select()
        xlWorkSheet.View.ZoomScale = 100

        'Formato General Texto para la hoja
        xlWorkSheet.Cells(1, 1, 200, 200).Style.Font.Name = "Calibri"
        xlWorkSheet.Cells(1, 1, 200, 200).Style.Font.Size = 11

        xlWorkSheet.Cells(1, 7).Value = "DÍAS ÚTILES:"
        xlWorkSheet.Cells(1, 7, 1, 10).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
        xlWorkSheet.Cells(1, 7, 1, 10).Style.VerticalAlignment = ExcelVerticalAlignment.Bottom

        xlWorkSheet.Cells(1, 8, 1, 8).Formula = "='AVANCE " & NomMarca & "'!W2"
        xlWorkSheet.Cells(1, 9).Value = "DÍAS AVANCE:"
        xlWorkSheet.Cells(1, 10, 1, 10).Formula = "='AVANCE " & NomMarca & "'!Y2"

        xlWorkSheet.Cells(7, 4).Value = "PLAN VENTA NETA"
        xlWorkSheet.Cells(8, 4).Value = "VENTA NETA CONTADO"
        xlWorkSheet.Cells(9, 4).Value = "VENTA NETA CRÉDITO"
        xlWorkSheet.Cells(10, 4).Value = "VENTA NETA TOTAL"
        xlWorkSheet.Cells(11, 4).Value = "CUMPLIMIENTO PLAN"
        xlWorkSheet.Cells(12, 4).Value = "PROYECTADO"
        xlWorkSheet.Cells(13, 4).Value = "CUMPLIMIENTO PROYECTADO"
        xlWorkSheet.Cells(7, 4, 13, 4).Style.Font.Size = 12
        xlWorkSheet.Cells(7, 4, 13, 4).Style.Font.Bold = True

        xlWorkSheet.Cells(5, 5, 6, 6).Style.VerticalAlignment = ExcelHorizontalAlignment.Center
        xlWorkSheet.Cells(5, 5).Value = "TOTAL MAESTRO"
        xlWorkSheet.Cells(5, 5, 6, 5).Merge = True
        xlWorkSheet.Cells(5, 5, 13, 5).Style.Font.Size = 20
        xlWorkSheet.Cells(5, 6, 5, 6).Style.Fill.PatternType = ExcelFillStyle.Solid
        xlWorkSheet.Cells(5, 6, 5, 6).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(48, 84, 150))
        'Formato numeros
        xlWorkSheet.Cells(7, 5, 10, 6).Style.Numberformat.Format = "#,##0"
        xlWorkSheet.Cells(10, 5, 10, 5).Formula = "=IF(SUM(E8:E9)=0," & Chr(34) & Chr(34) & ",SUM(E8:E9))"
        xlWorkSheet.Cells(11, 5, 11, 5).Formula = "=IFERROR(E10/E7," & Chr(34) & Chr(34) & ")"
        xlWorkSheet.Cells(12, 5, 12, 5).Formula = "=IFERROR((+E10/$J$1*$H$1)/0.96," & Chr(34) & Chr(34) & ")"
        xlWorkSheet.Cells(13, 5, 13, 5).Formula = "=IFERROR(E12/E7," & Chr(34) & Chr(34) & ")"

        xlWorkSheet.Cells(5, 6).Value = "TOTAL SODIMAC"
        'xlWorkSheet.Cells(5, 6).AutoFitColumns()
        xlWorkSheet.Cells(5, 6, 6, 6).Merge = True

        xlWorkSheet.Cells(5, 6, 6, 6).Style.Font.Bold = True
        xlWorkSheet.Cells(5, 6, 13, 6).Style.Font.Size = 20

        xlWorkSheet.Cells(5, 6, 6, 6).Style.Font.Color.SetColor(Color.FromArgb(48, 84, 150))
        xlWorkSheet.Cells(7, 6, 7, 6).Formula = "='AVANCE " & NomMarca & "'!" & help.ColName(cantCols) & "8"

        xlWorkSheet.Cells(8, 6, 8, 6).Formula = "='AVANCE " & NomMarca & "'!" & help.ColName(cantCols) & "9"

        xlWorkSheet.Cells(9, 6, 9, 6).Formula = "='AVANCE " & NomMarca & "'!" & help.ColName(cantCols) & "10"

        xlWorkSheet.Cells(10, 6, 10, 6).Formula = "=IF(SUM(F8:F9) = 0," & Chr(34) & Chr(34) & ",SUM(F8:F9))"

        xlWorkSheet.Cells(11, 5, 11, 6).Style.Numberformat.Format = "0.00%"

        xlWorkSheet.Cells(11, 6, 11, 6).Formula = "=IFERROR(F10/F7," & Chr(34) & Chr(34) & ")"

        xlWorkSheet.Cells(12, 5, 12, 6).Style.Numberformat.Format = "#,##0"
        xlWorkSheet.Cells(12, 6, 12, 6).Formula = "=IFERROR(F10/$J$1*$H$1," & Chr(34) & Chr(34) & ")"

        xlWorkSheet.Cells(13, 5, 13, 6).Style.Numberformat.Format = "0.00%"
        xlWorkSheet.Cells(13, 6, 13, 6).Formula = "=IFERROR(F12/F7," & Chr(34) & Chr(34) & ")"

        xlWorkSheet.Cells(7, 5, 7, 6).Style.Font.Bold = True
        xlWorkSheet.Cells(5, 5, 7, 6).Style.Fill.PatternType = ExcelFillStyle.Solid
        xlWorkSheet.Cells(5, 5, 7, 6).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(217, 217, 217))
        xlWorkSheet.Cells(5, 5, 13, 6).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
        xlWorkSheet.Cells(11, 5, 11, 6).Style.Fill.PatternType = ExcelFillStyle.Solid
        xlWorkSheet.Cells(11, 5, 11, 6).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(217, 217, 217))
        'xlWorkSheet.Cells(7, 6, 13, 6).AutoFitColumns()

        'Setea bordes cabecera
        Dim xl_range As ExcelRange = xlWorkSheet.Cells(1, 7, 1, 10)
        help.SetAllBorders_Thin(xl_range)
        help.SetAllBorders_Medium(xl_range)
        'help.SetAllBorders_Thin(xlWorkSheet.Range(xlWorkSheet.Cells(1, 7), xlWorkSheet.Cells(1, 10)))
        'help.SetBordesCeldas_Medium(xlWorkSheet.Range(xlWorkSheet.Cells(1, 7), xlWorkSheet.Cells(1, 10)))

        'Setea bordes tabla
        Dim range As ExcelRange = xlWorkSheet.Cells(7, 4, 7, 4)
        help.SetAllBorders_Medium(range)
        Dim rangeColum As ExcelRange = xlWorkSheet.Cells(7, 4, 13, 4)
        help.SetAllBorders_Medium(rangeColum)
        Dim range2 As ExcelRange = xlWorkSheet.Cells(5, 5, 13, 6)
        help.SetAllBorders_Medium(range2)
        Dim rangeColum2 As ExcelRange = xlWorkSheet.Cells(7, 4, 13, 6)
        help.SetAllBorders_Medium(rangeColum2)
        Dim rangeColum3 As ExcelRange = xlWorkSheet.Cells(5, 5, 13, 6)
        help.SetAllBorders_Medium(rangeColum3)
        Dim rangeColum4 As ExcelRange = xlWorkSheet.Cells(5, 6, 13, 6)
        help.SetAllBorders_Medium(rangeColum4)
        Dim rangeColum5 As ExcelRange = xlWorkSheet.Cells(13, 5, 13, 6)
        help.SetAllBorders_Medium(rangeColum5)
        'help.SetAllBorders_Thin(xlWorkSheet.Range(xlWorkSheet.Cells(7, 4), xlWorkSheet.Cells(13, 6)))
        'help.SetBordesCeldas_Thin(xlWorkSheet.Range(xlWorkSheet.Cells(7, 4), xlWorkSheet.Cells(13, 4)))
        'help.SetAllBorders_Thin(xlWorkSheet.Range(xlWorkSheet.Cells(5, 5), xlWorkSheet.Cells(13, 6)))
        'help.SetBordesCeldas_Medium(xlWorkSheet.Range(xlWorkSheet.Cells(7, 4), xlWorkSheet.Cells(13, 6)))
        'help.SetBordesCeldas_Medium(xlWorkSheet.Range(xlWorkSheet.Cells(5, 5), xlWorkSheet.Cells(13, 5)))
        'help.SetBordesCeldas_Medium(xlWorkSheet.Range(xlWorkSheet.Cells(5, 6), xlWorkSheet.Cells(13, 6)))
        'help.SetBordesCeldas_Medium(xlWorkSheet.Range(xlWorkSheet.Cells(13, 5), xlWorkSheet.Cells(13, 6)))

        xlWorkSheet.Column(4).AutoFit()  '"D"
        xlWorkSheet.Column(5).AutoFit()  '"E"
        xlWorkSheet.Column(6).Width = 35  '"F"
        xlWorkSheet.Column(7).AutoFit()  '"G"
        xlWorkSheet.Column(8).AutoFit()  '"I"
    End Sub
End Class
