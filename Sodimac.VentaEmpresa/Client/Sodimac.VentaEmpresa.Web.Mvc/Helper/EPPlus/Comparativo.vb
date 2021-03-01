Imports OfficeOpenXml
Imports OfficeOpenXml.Style
Imports Sodimac.VentaEmpresa.BusinessLogic
Imports Sodimac.VentaEmpresa.DataContracts
Imports System.Drawing

Public Class Comparativo
    Dim _xlWorkBook As ExcelWorkbook
    Dim _FechaIniRep As Date
    Dim _FechaFinRep As Date
    Dim _idMarca As Integer

    Sub New(xlWorkBook As ExcelWorkbook, fechaInicio As Date, fechaFin As Date, idMarca As Integer)
        Me._xlWorkBook = xlWorkBook
        Me._FechaIniRep = fechaInicio
        Me._FechaFinRep = fechaFin
        Me._idMarca = idMarca
    End Sub

    Sub Generar()
        Dim xlWorkSheet As ExcelWorksheet
        xlWorkSheet = _xlWorkBook.Worksheets.Item(5) '5: HOJA COMPARATIVO
        xlWorkSheet.Select()

        xlWorkSheet.Cells(1, 1).Value = "COMPS X RUBRO X FAM"

        xlWorkSheet.Cells(1, 1, 1, 3).Style.Font.Name = "Calibri"
        xlWorkSheet.Cells(1, 1, 1, 3).Style.Font.Size = 10
        xlWorkSheet.Cells(1, 1, 1, 3).Style.Font.Bold = True
        xlWorkSheet.Cells(1, 1, 1, 1).Style.Fill.PatternType = ExcelFillStyle.Solid
        xlWorkSheet.Cells(1, 1, 1, 1).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(155, 194, 230))
        xlWorkSheet.Column(1).Width = 45.86
        xlWorkSheet.Column(2).Width = 20.14
        xlWorkSheet.Column(3).Width = 20.14
        xlWorkSheet.Column(4).Width = 15.71
        xlWorkSheet.Cells(1, 4, 1, 4).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
        xlWorkSheet.Cells(1, 4, 1, 4).Style.VerticalAlignment = ExcelHorizontalAlignment.Center

        xlWorkSheet.Cells(2, 1, 2, 4).Style.Font.Name = "Calibri"
        xlWorkSheet.Cells(2, 1, 2, 4).Style.Font.Size = 10
        xlWorkSheet.Cells(2, 1, 2, 4).Style.Font.Bold = True
        xlWorkSheet.Cells(2, 1, 2, 4).Style.Fill.PatternType = ExcelFillStyle.Solid
        xlWorkSheet.Cells(2, 1, 2, 4).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(221, 235, 247))
        xlWorkSheet.Cells(2, 1, 2, 4).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
        xlWorkSheet.Cells(2, 1, 2, 4).Style.VerticalAlignment = ExcelHorizontalAlignment.Center
        'AGREGAR BORDE
        xlWorkSheet.Cells(2, 1, 2, 4).Style.Border.Top.Style = ExcelBorderStyle.Thin
        xlWorkSheet.Cells(2, 1, 2, 4).Style.Border.Left.Style = ExcelBorderStyle.Thin
        xlWorkSheet.Cells(2, 1, 2, 4).Style.Border.Right.Style = ExcelBorderStyle.Thin
        xlWorkSheet.Cells(2, 1, 2, 4).Style.Border.Bottom.Style = ExcelBorderStyle.Thin

        xlWorkSheet.Cells(1, 2).Value = "AÑO " & (_FechaFinRep.Year - 1).ToString
        xlWorkSheet.Cells(1, 3).Value = "AÑO " & _FechaFinRep.Year.ToString
        xlWorkSheet.Cells(2, 1).Value = "Familia"
        xlWorkSheet.Cells(2, 2).Value = "Venta Neta Sin IGV"
        xlWorkSheet.Cells(2, 3).Value = "Venta Neta Sin IGV"
        xlWorkSheet.Cells(2, 4).Value = "COMPS"

        Dim reporteBusinessLogic As New ReporteBusinessLogic()
        Dim oListaReporteComps As New List(Of ReporteComparativoAAAC)
        oListaReporteComps = reporteBusinessLogic.SelReporteComps(_FechaIniRep, _FechaFinRep, _idMarca)
        Dim filas As Integer = oListaReporteComps.Count() - 1
        For x As Integer = 0 To filas
            Dim n = x + 3
            xlWorkSheet.Cells(n, 1).Value = oListaReporteComps(x).NombreFam
            xlWorkSheet.Cells(n, 2).Value = oListaReporteComps(x).TotalAA
            xlWorkSheet.Cells(n, 3).Value = oListaReporteComps(x).TotalAC
            xlWorkSheet.Cells(n, 4).Value = oListaReporteComps(x).Comps
            'AGREGAR BORDE
            xlWorkSheet.Cells(n, 1, n, 4).Style.Border.Top.Style = ExcelBorderStyle.Thin
            xlWorkSheet.Cells(n, 1, n, 4).Style.Border.Left.Style = ExcelBorderStyle.Thin
            xlWorkSheet.Cells(n, 1, n, 4).Style.Border.Right.Style = ExcelBorderStyle.Thin
            xlWorkSheet.Cells(n, 1, n, 4).Style.Border.Bottom.Style = ExcelBorderStyle.Thin

            xlWorkSheet.Cells(n, 1, n, 4).Style.Font.Name = "Calibri"
            xlWorkSheet.Cells(n, 1, n, 4).Style.Font.Size = 10
            xlWorkSheet.Cells(n, 2, n, 4).Style.VerticalAlignment = ExcelHorizontalAlignment.Center
            xlWorkSheet.Cells(n, 2, n, 4).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
        Next


        xlWorkSheet.Cells(filas + 4, 1).Value = "Total General"
        xlWorkSheet.Cells(filas + 4, 2).Formula = "=SUM(B3:B" & filas + 3 & ")"
        xlWorkSheet.Cells(filas + 4, 3).Formula = "=SUM(C3:C" & filas + 3 & ")"
        xlWorkSheet.Cells(filas + 4, 4).Formula = "SUM(C3:C" & filas + 3 & ")/SUM(B3:B" & filas + 3 & ")  - 1"
        xlWorkSheet.Cells(filas + 4, 4).Style.Numberformat.Format = "0.000"
        'AGREGAR BORDE
        xlWorkSheet.Cells(filas + 4, 1, filas + 4, 4).Style.Border.Top.Style = ExcelBorderStyle.Thin
        xlWorkSheet.Cells(filas + 4, 1, filas + 4, 4).Style.Border.Left.Style = ExcelBorderStyle.Thin
        xlWorkSheet.Cells(filas + 4, 1, filas + 4, 4).Style.Border.Right.Style = ExcelBorderStyle.Thin
        xlWorkSheet.Cells(filas + 4, 1, filas + 4, 4).Style.Border.Bottom.Style = ExcelBorderStyle.Thin

        xlWorkSheet.Cells(filas + 4, 1, filas + 4, 4).Style.Font.Name = "Calibri"
        xlWorkSheet.Cells(filas + 4, 1, filas + 4, 4).Style.Font.Size = 11
        xlWorkSheet.Cells(filas + 4, 1, filas + 4, 4).Style.Font.Bold = True
        xlWorkSheet.Cells(filas + 4, 1, filas + 4, 4).Style.VerticalAlignment = ExcelHorizontalAlignment.Center
        xlWorkSheet.Cells(filas + 4, 1, filas + 4, 4).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center

    End Sub

End Class
