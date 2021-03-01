Imports Microsoft.Office.Interop.Excel
Imports System.Runtime.InteropServices
Imports Sodimac.VentaEmpresa.DataContracts
Imports Sodimac.VentaEmpresa.BusinessLogic

Public Class HojaDetalladoXFamilia

    Dim _xlWorkBook As Workbook
    Dim _FechaIniRep As Date
    Dim _FechaFinRep As Date
    Dim _lstZona As List(Of Zona)
    Dim _lstSucursal As List(Of Sucursal)
    Dim help As New HelperReporteVE
    Dim _Agrupacion() As String = {"VENTA", "MARGEN", "TRANSACCIONES", "TICKET PROMEDIO"}

    Sub New(xlWorkBook As Workbook, fechaInicio As Date, fechaFin As Date, lstZona As List(Of Zona), lstSucursal As List(Of Sucursal))
        Me._xlWorkBook = xlWorkBook
        Me._FechaIniRep = fechaInicio
        Me._FechaFinRep = fechaFin
        Me._lstZona = lstZona
        Me._lstSucursal = lstSucursal
    End Sub

    Sub Generar()
        GenerarFormatoPrevio()
        GenerarCuadroDetallePorFamilia()
    End Sub

    Sub GenerarFormatoPrevio()

        Dim xlWorkSheet As New Worksheet
        xlWorkSheet = _xlWorkBook.Worksheets.Item(4) '4: HOJA DETALLADO X FAMILIA
        xlWorkSheet.Select()
        _xlWorkBook.Windows(1).Zoom = 100

        xlWorkSheet.Cells(2, 1) = "ZONAS"
        xlWorkSheet.Cells(3, 1) = "FAMILIAS"

        GenerarCabecera(xlWorkSheet)

    End Sub

    Sub GenerarCabecera(ByRef xlWorkSheet As Worksheet)
        Dim columna As Integer = 2, inicio As Integer = 2, zona As Integer = 2

        xlWorkSheet.Range(xlWorkSheet.Cells(1, 1), xlWorkSheet.Cells(2, 1)).Interior.Color = RGB(51, 204, 204)
        xlWorkSheet.Range(xlWorkSheet.Cells(2, 1), xlWorkSheet.Cells(2, 1)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
        xlWorkSheet.Range(xlWorkSheet.Cells(2, 1), xlWorkSheet.Cells(2, 1)).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
        xlWorkSheet.Range(xlWorkSheet.Cells(2, 1), xlWorkSheet.Cells(2, 1)).Font.Name = "Calibri"
        xlWorkSheet.Range(xlWorkSheet.Cells(2, 1), xlWorkSheet.Cells(2, 1)).Font.Size = 9
        xlWorkSheet.Range(xlWorkSheet.Cells(2, 1), xlWorkSheet.Cells(2, 1)).Font.Bold = True
        xlWorkSheet.Range(xlWorkSheet.Cells(2, 1), xlWorkSheet.Cells(2, 1)).Interior.Color = RGB(51, 204, 204)
        xlWorkSheet.Range(xlWorkSheet.Cells(3, 1), xlWorkSheet.Cells(3, 1)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
        xlWorkSheet.Range(xlWorkSheet.Cells(3, 1), xlWorkSheet.Cells(3, 1)).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignBottom
        xlWorkSheet.Range(xlWorkSheet.Cells(3, 1), xlWorkSheet.Cells(3, 1)).Interior.Color = RGB(221, 235, 247)
        xlWorkSheet.Range(xlWorkSheet.Cells(3, 1), xlWorkSheet.Cells(3, 1)).Font.Name = "Calibri"
        xlWorkSheet.Range(xlWorkSheet.Cells(3, 1), xlWorkSheet.Cells(3, 1)).Font.Size = 10
        xlWorkSheet.Range(xlWorkSheet.Cells(3, 1), xlWorkSheet.Cells(3, 1)).Font.Bold = True

        For index = 0 To _Agrupacion.Length - 1

            zona = inicio


            For i = 0 To _lstZona.Count - 1

                Dim local_i As Integer = i
                Dim lstSucursal As List(Of Sucursal) = _lstSucursal.FindAll(Function(x) x.IdZona = _lstZona.Item(local_i).IdZona)

                For j = 0 To lstSucursal.Count - 1
                    xlWorkSheet.Cells(3, columna) = (lstSucursal(j)).Descripcion
                    columna = columna + 1
                Next

                columna = columna - 1

                xlWorkSheet.Range(xlWorkSheet.Cells(2, zona), xlWorkSheet.Cells(2, columna)).Merge()
                xlWorkSheet.Cells(2, zona) = (_lstZona(i)).NombreZona

                zona = columna + 1
                columna = columna + 1
            Next

            xlWorkSheet.Range(xlWorkSheet.Cells(1, inicio), xlWorkSheet.Cells(1, columna)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
            xlWorkSheet.Range(xlWorkSheet.Cells(1, inicio), xlWorkSheet.Cells(1, columna)).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            xlWorkSheet.Range(xlWorkSheet.Cells(1, inicio), xlWorkSheet.Cells(1, columna)).Interior.Color = RGB(51, 204, 204)
            xlWorkSheet.Range(xlWorkSheet.Cells(1, inicio), xlWorkSheet.Cells(1, columna)).Font.Name = "Calibri"
            xlWorkSheet.Range(xlWorkSheet.Cells(1, inicio), xlWorkSheet.Cells(1, columna)).Font.Size = 9
            xlWorkSheet.Range(xlWorkSheet.Cells(1, inicio), xlWorkSheet.Cells(1, columna)).Font.Bold = True
            xlWorkSheet.Cells(1, inicio) = _Agrupacion(index)
            xlWorkSheet.Cells(1, columna) = _Agrupacion(index)

            xlWorkSheet.Range(xlWorkSheet.Cells(2, inicio), xlWorkSheet.Cells(2, columna)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
            xlWorkSheet.Range(xlWorkSheet.Cells(2, inicio), xlWorkSheet.Cells(2, columna)).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            xlWorkSheet.Range(xlWorkSheet.Cells(2, inicio), xlWorkSheet.Cells(2, columna - 1)).Interior.Color = RGB(248, 203, 173)
            xlWorkSheet.Range(xlWorkSheet.Cells(2, inicio), xlWorkSheet.Cells(2, columna)).Font.Name = "Calibri"
            xlWorkSheet.Range(xlWorkSheet.Cells(2, inicio), xlWorkSheet.Cells(2, columna)).Font.Size = 9
            xlWorkSheet.Range(xlWorkSheet.Cells(2, inicio), xlWorkSheet.Cells(2, columna)).Font.Bold = True
            xlWorkSheet.Range(xlWorkSheet.Cells(2, columna), xlWorkSheet.Cells(2, columna)).Interior.Color = RGB(51, 204, 204)

            xlWorkSheet.Range(xlWorkSheet.Cells(3, inicio), xlWorkSheet.Cells(3, columna)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
            xlWorkSheet.Range(xlWorkSheet.Cells(3, inicio), xlWorkSheet.Cells(3, columna)).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignBottom
            xlWorkSheet.Range(xlWorkSheet.Cells(3, inicio), xlWorkSheet.Cells(3, columna)).Interior.Color = RGB(221, 235, 247)
            xlWorkSheet.Range(xlWorkSheet.Cells(3, inicio), xlWorkSheet.Cells(3, columna)).Font.Name = "Calibri"
            xlWorkSheet.Range(xlWorkSheet.Cells(3, inicio), xlWorkSheet.Cells(3, columna)).Font.Size = 10
            xlWorkSheet.Range(xlWorkSheet.Cells(3, inicio), xlWorkSheet.Cells(3, columna)).Font.Bold = True
            xlWorkSheet.Range(xlWorkSheet.Cells(3, inicio), xlWorkSheet.Cells(3, columna)).Columns.AutoFit()
            xlWorkSheet.Cells(3, columna) = "Total general"

            xlWorkSheet.Range(xlWorkSheet.Cells(3, inicio), xlWorkSheet.Cells(3, columna - 1)).Columns.Group()

            columna = columna + 1
            inicio = columna

        Next

        help.SetAllBorders_Thin(xlWorkSheet.Range(xlWorkSheet.Cells(1, 1), xlWorkSheet.Cells(1, columna - 1)))
        help.SetAllBorders_Thin(xlWorkSheet.Range(xlWorkSheet.Cells(2, 1), xlWorkSheet.Cells(2, columna - 1)))
        help.SetAllBorders_Thin(xlWorkSheet.Range(xlWorkSheet.Cells(3, 1), xlWorkSheet.Cells(3, columna - 1)))

        Marshal.ReleaseComObject(xlWorkSheet)

    End Sub

    Sub GenerarCuadroDetallePorFamilia()
        Dim xlWorkSheet As New Worksheet
        xlWorkSheet = _xlWorkBook.Worksheets.Item(4) '4: HOJA DETALLADO X FAMILIA
        xlWorkSheet.Select()

        Dim ReporteBusinessLogic As New ReporteBusinessLogic()

        Dim ListaReporteEmpresa As New List(Of ReporteVentaEmpresa)

        Dim columna As Integer, totalColumnas As Integer = 0, inicio As Integer

        ListaReporteEmpresa = ReporteBusinessLogic.SelReporteDetalladoPorFamilia(_FechaIniRep, _FechaFinRep)

        Dim fila As Integer = 4

        For Each familia As String In ListaReporteEmpresa.[Select](Function(s) s.Familia.Trim()).Distinct()

            columna = 2
            inicio = 2
            totalColumnas = 0

            xlWorkSheet.Cells(fila, 1) = familia.Trim()

            Dim codigoFamilia As String = ListaReporteEmpresa.Where(Function(s) s.Familia.Trim() = familia.Trim()).Select(Function(m) m.CodigoFamilia.Trim()).FirstOrDefault

            For index = 0 To _Agrupacion.Length - 1

                For i = 0 To _lstZona.Count - 1
                    Dim local_i As Integer = i
                    Dim lstSucursal As List(Of Sucursal) = _lstSucursal.FindAll(Function(x) x.IdZona = _lstZona.Item(local_i).IdZona)

                    For j = 0 To lstSucursal.Count - 1
                        Dim codigoSucursal As String = lstSucursal(j).CodigoSucursal.Trim()
                        Dim codigoTienda As Integer = Integer.Parse(codigoSucursal.Substring(1, codigoSucursal.Length - 1))
                        Dim valor As String
                        Select Case index
                            Case 0
                                valor = ListaReporteEmpresa.Where(Function(m) m.IdZona = _lstZona.Item(local_i).IdZona And m.CodigoTienda = codigoTienda And m.CodigoFamilia.Trim() = codigoFamilia).Select(Function(n) n.Venta).FirstOrDefault
                            Case 1
                                valor = ListaReporteEmpresa.Where(Function(m) m.IdZona = _lstZona.Item(local_i).IdZona And m.CodigoTienda = codigoTienda And m.CodigoFamilia.Trim() = codigoFamilia).Select(Function(n) n.Margen).FirstOrDefault
                            Case 2
                                valor = ListaReporteEmpresa.Where(Function(m) m.IdZona = _lstZona.Item(local_i).IdZona And m.CodigoTienda = codigoTienda And m.CodigoFamilia.Trim() = codigoFamilia).Select(Function(n) n.Transacciones).FirstOrDefault
                            Case Else
                                valor = ListaReporteEmpresa.Where(Function(m) m.IdZona = _lstZona.Item(local_i).IdZona And m.CodigoTienda = codigoTienda And m.CodigoFamilia.Trim() = codigoFamilia).Select(Function(n) n.TicketPromedio).FirstOrDefault
                        End Select
                        xlWorkSheet.Cells(fila, columna) = valor
                        columna += 1
                        totalColumnas += 1
                    Next

                Next

                xlWorkSheet.Range(xlWorkSheet.Cells(fila, columna), xlWorkSheet.Cells(fila, columna)).FormulaLocal = "=SUMA(" & help.ColName(inicio) & fila.ToString() & ":" & help.ColName(columna - 1) & fila.ToString() & ")"
                xlWorkSheet.Range(xlWorkSheet.Cells(fila, columna), xlWorkSheet.Cells(fila, columna)).Interior.Color = RGB(217, 217, 217)
                xlWorkSheet.Range(xlWorkSheet.Cells(fila, inicio), xlWorkSheet.Cells(fila, columna)).Font.Name = "Calibri"
                xlWorkSheet.Range(xlWorkSheet.Cells(fila, inicio), xlWorkSheet.Cells(fila, columna)).Font.Size = 9
                xlWorkSheet.Range(xlWorkSheet.Cells(fila, inicio), xlWorkSheet.Cells(fila, columna)).NumberFormat = "#,##0"
                columna += 1
                inicio = columna
                totalColumnas += 1
            Next

            fila += 1

        Next

        xlWorkSheet.Range(xlWorkSheet.Cells(fila, 1), xlWorkSheet.Cells(fila, 1)).Font.Name = "Calibri"
        xlWorkSheet.Range(xlWorkSheet.Cells(fila, 1), xlWorkSheet.Cells(fila, 1)).Font.Size = 10
        xlWorkSheet.Range(xlWorkSheet.Cells(fila, 1), xlWorkSheet.Cells(fila, 1)).Font.Bold = True
        xlWorkSheet.Range(xlWorkSheet.Cells(fila, 1), xlWorkSheet.Cells(fila, 1)).Interior.Color = RGB(221, 235, 247)
        xlWorkSheet.Range(xlWorkSheet.Cells(fila, 1), xlWorkSheet.Cells(fila, 1)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft
        xlWorkSheet.Range(xlWorkSheet.Cells(fila, 1), xlWorkSheet.Cells(fila, 1)).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignBottom
        xlWorkSheet.Cells(fila, 1) = "Total general"


        For icol = 1 To totalColumnas
            xlWorkSheet.Range(xlWorkSheet.Cells(fila, icol + 1), xlWorkSheet.Cells(fila, icol + 1)).Font.Name = "Calibri"
            xlWorkSheet.Range(xlWorkSheet.Cells(fila, icol + 1), xlWorkSheet.Cells(fila, icol + 1)).Font.Size = 9
            xlWorkSheet.Range(xlWorkSheet.Cells(fila, icol + 1), xlWorkSheet.Cells(fila, icol + 1)).Font.Bold = True
            xlWorkSheet.Range(xlWorkSheet.Cells(fila, icol + 1), xlWorkSheet.Cells(fila, icol + 1)).Interior.Color = RGB(221, 235, 247)
            xlWorkSheet.Range(xlWorkSheet.Cells(fila, icol + 1), xlWorkSheet.Cells(fila, icol + 1)).FormulaLocal = "=SUMA(" & help.ColName(icol + 1) & "4:" & help.ColName(icol + 1) & (fila - 1).ToString() & ")"
            xlWorkSheet.Columns(help.ColName(icol + 1)).AutoFit()
        Next


        xlWorkSheet.Range(xlWorkSheet.Cells(4, 2), xlWorkSheet.Cells(4, 2)).Select()
        _xlWorkBook.Windows(1).FreezePanes = True
        xlWorkSheet.Columns("A").AutoFit()

        xlWorkSheet.Range(xlWorkSheet.Cells(4, 1), xlWorkSheet.Cells(fila - 1, 1)).Font.Name = "Calibri"
        xlWorkSheet.Range(xlWorkSheet.Cells(4, 1), xlWorkSheet.Cells(fila - 1, 1)).Font.Size = 11

        Marshal.ReleaseComObject(xlWorkSheet)
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        Marshal.ReleaseComObject(Me._xlWorkBook)
    End Sub
End Class
