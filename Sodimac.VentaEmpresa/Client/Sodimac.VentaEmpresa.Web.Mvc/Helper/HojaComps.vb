Imports Microsoft.Office.Interop.Excel
Imports System.Runtime.InteropServices
Imports Sodimac.VentaEmpresa.BusinessLogic
Imports Sodimac.VentaEmpresa.DataContracts

Public Class HojaCOMPS

    Dim _xlWorkBook As Workbook
    Dim _FechaIniRep As Date
    Dim _FechaFinRep As Date
    Dim help As New HelperReporteVE
    Dim _idMarca As Integer

    Sub New(xlWorkBook As Workbook, fechaInicio As Date, fechaFin As Date, idMarca As Integer)
        Me._xlWorkBook = xlWorkBook
        Me._FechaIniRep = fechaInicio
        Me._FechaFinRep = fechaFin
        Me._idMarca = idMarca
    End Sub

    Sub Generar()
        Dim xlWorkSheet As New Worksheet
        xlWorkSheet = _xlWorkBook.Worksheets.Item(5) '5: HOJA COMPS
        xlWorkSheet.Select()

        xlWorkSheet.Cells(1, 1) = "COMPS X RUBRO X FAM"

        xlWorkSheet.Range(xlWorkSheet.Cells(1, 1), xlWorkSheet.Cells(1, 3)).Font.Name = "Calibri"
        xlWorkSheet.Range(xlWorkSheet.Cells(1, 1), xlWorkSheet.Cells(1, 3)).Font.Size = 10
        xlWorkSheet.Range(xlWorkSheet.Cells(1, 1), xlWorkSheet.Cells(1, 3)).Font.Bold = True
        xlWorkSheet.Range(xlWorkSheet.Cells(1, 1), xlWorkSheet.Cells(1, 1)).Interior.Color = RGB(155, 194, 230)
        xlWorkSheet.Range(xlWorkSheet.Cells(1, 1), xlWorkSheet.Cells(1, 1)).ColumnWidth = 45.86
        xlWorkSheet.Range(xlWorkSheet.Cells(1, 2), xlWorkSheet.Cells(1, 3)).ColumnWidth = 20.14
        xlWorkSheet.Range(xlWorkSheet.Cells(1, 4), xlWorkSheet.Cells(1, 4)).ColumnWidth = 15.71
        xlWorkSheet.Range(xlWorkSheet.Cells(1, 4), xlWorkSheet.Cells(1, 4)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
        xlWorkSheet.Range(xlWorkSheet.Cells(1, 4), xlWorkSheet.Cells(1, 4)).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter

        xlWorkSheet.Range(xlWorkSheet.Cells(2, 1), xlWorkSheet.Cells(2, 4)).Font.Name = "Calibri"
        xlWorkSheet.Range(xlWorkSheet.Cells(2, 1), xlWorkSheet.Cells(2, 4)).Font.Size = 10
        xlWorkSheet.Range(xlWorkSheet.Cells(2, 1), xlWorkSheet.Cells(2, 4)).Font.Bold = True
        xlWorkSheet.Range(xlWorkSheet.Cells(2, 1), xlWorkSheet.Cells(2, 4)).Interior.Color = RGB(221, 235, 247)
        xlWorkSheet.Range(xlWorkSheet.Cells(2, 1), xlWorkSheet.Cells(2, 4)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
        xlWorkSheet.Range(xlWorkSheet.Cells(2, 1), xlWorkSheet.Cells(2, 4)).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter

        help.SetAllBorders_Thin(xlWorkSheet.Range(xlWorkSheet.Cells(2, 1), xlWorkSheet.Cells(2, 4)))

        xlWorkSheet.Cells(1, 2) = "AÑO " & (_FechaFinRep.Year - 1).ToString
        xlWorkSheet.Cells(1, 3) = "AÑO " & _FechaFinRep.Year.ToString
        xlWorkSheet.Cells(2, 1) = "Familia"
        xlWorkSheet.Cells(2, 2) = "Venta Neta Sin IGV"
        xlWorkSheet.Cells(2, 3) = "Venta Neta Sin IGV"
        xlWorkSheet.Cells(2, 4) = "COMPS"
        
        Dim reporteBusinessLogic As New ReporteBusinessLogic()
        Dim oListaReporteComps As New List(Of ReporteComparativoAAAC)
        oListaReporteComps = reporteBusinessLogic.SelReporteComps(_FechaIniRep, _FechaFinRep, _idMarca)
        Dim filas As Integer = oListaReporteComps.Count() - 1
        For x As Integer = 0 To filas
            Dim n = x + 3
            xlWorkSheet.Cells(n, 1) = oListaReporteComps(x).NombreFam
            xlWorkSheet.Cells(n, 2) = oListaReporteComps(x).TotalAA
            xlWorkSheet.Cells(n, 3) = oListaReporteComps(x).TotalAC
            xlWorkSheet.Cells(n, 4) = oListaReporteComps(x).Comps
            help.SetAllBorders_Thin(xlWorkSheet.Range(xlWorkSheet.Cells(n, 1), xlWorkSheet.Cells(n, 4)))

            xlWorkSheet.Range(xlWorkSheet.Cells(n, 1), xlWorkSheet.Cells(n, 4)).Font.Name = "Calibri"
            xlWorkSheet.Range(xlWorkSheet.Cells(n, 1), xlWorkSheet.Cells(n, 4)).Font.Size = 10
            xlWorkSheet.Range(xlWorkSheet.Cells(n, 2), xlWorkSheet.Cells(n, 4)).VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
            xlWorkSheet.Range(xlWorkSheet.Cells(n, 2), xlWorkSheet.Cells(n, 4)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
        Next


        xlWorkSheet.Cells(filas + 4, 1) = "Total General"
        xlWorkSheet.Range(xlWorkSheet.Cells(filas + 4, 2), xlWorkSheet.Cells(filas + 4, 2)).FormulaLocal = "=SUMA(B3:B" & filas + 3 & ")"
        xlWorkSheet.Range(xlWorkSheet.Cells(filas + 4, 3), xlWorkSheet.Cells(filas + 4, 3)).FormulaLocal = "=SUMA(C3:C" & filas + 3 & ")"
        xlWorkSheet.Range(xlWorkSheet.Cells(filas + 4, 4), xlWorkSheet.Cells(filas + 4, 4)).FormulaLocal = "=REDONDEAR(SUMA(C3:C" & filas + 3 & ")/SUMA(B3:B" & filas + 3 & ")  - 1,3)"
        help.SetAllBorders_Thin(xlWorkSheet.Range(xlWorkSheet.Cells(filas + 4, 1), xlWorkSheet.Cells(filas + 4, 4)))
        xlWorkSheet.Range(xlWorkSheet.Cells(filas + 4, 1), xlWorkSheet.Cells(filas + 4, 4)).Font.Name = "Calibri"
        xlWorkSheet.Range(xlWorkSheet.Cells(filas + 4, 1), xlWorkSheet.Cells(filas + 4, 4)).Font.Size = 11
        xlWorkSheet.Range(xlWorkSheet.Cells(filas + 4, 1), xlWorkSheet.Cells(filas + 4, 4)).Font.Bold = True
        xlWorkSheet.Range(xlWorkSheet.Cells(filas + 4, 1), xlWorkSheet.Cells(filas + 4, 4)).VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
        xlWorkSheet.Range(xlWorkSheet.Cells(filas + 4, 1), xlWorkSheet.Cells(filas + 4, 4)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter

        Marshal.ReleaseComObject(xlWorkSheet)
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        Marshal.ReleaseComObject(Me._xlWorkBook)
    End Sub
End Class
