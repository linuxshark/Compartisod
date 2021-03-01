Imports Microsoft.Office.Interop.Excel
Imports System.Runtime.InteropServices
Imports Sodimac.VentaEmpresa.DataContracts
Imports Sodimac.VentaEmpresa.BusinessLogic

Public Class HojaDetalladoXDia

    Dim _xlWorkBook As Workbook
    Dim _xlWorkSheet As Worksheet
    Dim _FechaIniRep As Date
    Dim _FechaFinRep As Date
    Dim _lstZona As List(Of Zona)
    Dim _lstSucursal As List(Of Sucursal)
    Dim help As New HelperReporteVE
    Dim _Agrupacion() As String = {"VENTA", "MARGEN", "TRANSACCIONES", "TICKET PROMEDIO"}
    Dim _SubAgrupacion() As String = {"CONTADO", "CREDITO"}
    'Dim lastCol As Integer
    'Dim numRowsDias As Integer = 0
    'Dim rowTotalGeneral As Integer = 5
    'Dim bDiasGenerados As Boolean = False

    Sub New(xlWorkBook As Workbook, fechaInicio As Date, fechaFin As Date, lstZona As List(Of Zona), lstSucursal As List(Of Sucursal))
        Me._xlWorkBook = xlWorkBook
        ' Me._xlWorkSheet = _xlWorkBook.Worksheets.Item(3) '3: HOJA DETALLADO X DIA
        Me._FechaIniRep = fechaInicio
        Me._FechaFinRep = fechaFin
        Me._lstZona = lstZona
        Me._lstSucursal = lstSucursal

        '_xlWorkSheet.Select()
        '_xlWorkBook.Windows(1).Zoom = 50
    End Sub

    Sub Generar()
        GenerarFormatoPrevio()
        GenerarCuadroDetallePorDia()
        'formatoPrevio()
        'GenerarVentaNeta()
        'GenerarMargen()
        'GenerarTransacciones()
        'GenerarTicketPromedio()
    End Sub

    Sub GenerarFormatoPrevio()
        Dim ArrayInicioColumna(_lstZona.Count - 1) As Integer
        Dim xlWorkSheet As New Worksheet
        xlWorkSheet = _xlWorkBook.Worksheets.Item(3) '3: HOJA DETALLADO X DIA
        xlWorkSheet.Select()
        _xlWorkBook.Windows(1).Zoom = 100
        GenerarCabecera(xlWorkSheet)
    End Sub

    Sub GenerarCabecera(ByRef xlWorkSheet As Worksheet)
        Dim columna As Integer = 2, inicio As Integer = 2, zona As Integer = 2

        xlWorkSheet.Range(xlWorkSheet.Cells(1, inicio - 1), xlWorkSheet.Cells(4, inicio - 1)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
        xlWorkSheet.Range(xlWorkSheet.Cells(1, inicio - 1), xlWorkSheet.Cells(4, inicio - 1)).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
        xlWorkSheet.Range(xlWorkSheet.Cells(1, inicio - 1), xlWorkSheet.Cells(4, inicio - 1)).Font.Name = "Calibri"
        xlWorkSheet.Range(xlWorkSheet.Cells(1, inicio - 1), xlWorkSheet.Cells(4, inicio - 1)).Font.Size = 9
        xlWorkSheet.Range(xlWorkSheet.Cells(1, inicio - 1), xlWorkSheet.Cells(4, inicio - 1)).Font.Bold = True
        xlWorkSheet.Range(xlWorkSheet.Cells(1, inicio - 1), xlWorkSheet.Cells(4, inicio - 1)).Interior.Color = RGB(51, 204, 204)
        xlWorkSheet.Cells(2, inicio - 1) = "Forma de Pago"
        xlWorkSheet.Cells(3, inicio - 1) = "ZONAS"
        xlWorkSheet.Cells(4, inicio - 1) = "Día Natural"

        Dim i, j, k As Integer

        For i = 0 To _Agrupacion.Length - 1

            If i > 0 Then

                xlWorkSheet.Range(xlWorkSheet.Cells(1, inicio), xlWorkSheet.Cells(4, columna)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                xlWorkSheet.Range(xlWorkSheet.Cells(1, inicio), xlWorkSheet.Cells(4, columna)).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                xlWorkSheet.Range(xlWorkSheet.Cells(1, inicio), xlWorkSheet.Cells(4, columna)).Font.Name = "Calibri"
                xlWorkSheet.Range(xlWorkSheet.Cells(1, inicio), xlWorkSheet.Cells(4, columna)).Font.Size = 9
                xlWorkSheet.Range(xlWorkSheet.Cells(1, inicio), xlWorkSheet.Cells(4, columna)).Font.Bold = True

                xlWorkSheet.Range(xlWorkSheet.Cells(1, inicio), xlWorkSheet.Cells(4, inicio)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                xlWorkSheet.Range(xlWorkSheet.Cells(1, inicio), xlWorkSheet.Cells(4, inicio)).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                xlWorkSheet.Range(xlWorkSheet.Cells(1, inicio), xlWorkSheet.Cells(4, inicio)).Interior.Color = RGB(51, 204, 204)
                xlWorkSheet.Cells(2, inicio) = "Forma de Pago"
                xlWorkSheet.Cells(3, inicio) = "ZONAS"
                xlWorkSheet.Cells(4, inicio) = "Día Natural"

                columna = columna + 1
                inicio = columna

            End If

            For j = 0 To _SubAgrupacion.Length - 1

                zona = inicio

                For k = 0 To _lstZona.Count - 1

                    Dim lstSucursal As List(Of Sucursal) = _lstSucursal.FindAll(Function(x) x.IdZona = _lstZona.Item(k).IdZona)

                    For l = 0 To lstSucursal.Count - 1
                        xlWorkSheet.Cells(4, columna) = (lstSucursal(l)).Descripcion
                        columna = columna + 1
                    Next

                    columna = columna - 1

                    xlWorkSheet.Range(xlWorkSheet.Cells(3, zona), xlWorkSheet.Cells(3, columna)).Merge()
                    xlWorkSheet.Range(xlWorkSheet.Cells(3, zona), xlWorkSheet.Cells(3, columna)).Interior.Color = RGB(248, 203, 173)
                    xlWorkSheet.Cells(3, zona) = (_lstZona(k)).NombreZona

                    xlWorkSheet.Range(xlWorkSheet.Cells(4, zona), xlWorkSheet.Cells(4, columna)).Interior.Color = RGB(221, 235, 247)

                    columna = columna + 1

                    xlWorkSheet.Range(xlWorkSheet.Cells(1, inicio), xlWorkSheet.Cells(2, columna)).Interior.Color = RGB(51, 204, 204)
                    xlWorkSheet.Range(xlWorkSheet.Cells(3, columna), xlWorkSheet.Cells(3, columna)).Interior.Color = RGB(51, 204, 204)

                    xlWorkSheet.Cells(1, inicio) = _Agrupacion(i)
                    xlWorkSheet.Cells(2, inicio) = _SubAgrupacion(j)
                    xlWorkSheet.Cells(3, columna) = _Agrupacion(i)

                    xlWorkSheet.Range(xlWorkSheet.Cells(4, columna), xlWorkSheet.Cells(4, columna)).Interior.Color = RGB(255, 255, 153)
                    xlWorkSheet.Cells(4, columna) = "Resultado"

                    columna = columna + 1
                    zona = columna
                Next

                If j = 1 Then

                    xlWorkSheet.Range(xlWorkSheet.Cells(1, columna), xlWorkSheet.Cells(2, columna)).Interior.Color = RGB(51, 204, 204)
                    xlWorkSheet.Range(xlWorkSheet.Cells(3, columna), xlWorkSheet.Cells(3, columna)).Interior.Color = RGB(217, 217, 217)
                    xlWorkSheet.Cells(3, columna) = "ORACLE"

                    xlWorkSheet.Range(xlWorkSheet.Cells(4, columna), xlWorkSheet.Cells(4, columna)).Interior.Color = RGB(255, 255, 153)
                    xlWorkSheet.Cells(4, columna) = "Resultado"

                    columna = columna + 1

                End If


                xlWorkSheet.Range(xlWorkSheet.Cells(1, columna), xlWorkSheet.Cells(3, columna)).Interior.Color = RGB(51, 204, 204)
                xlWorkSheet.Cells(3, columna) = _Agrupacion(i)

                xlWorkSheet.Range(xlWorkSheet.Cells(4, columna), xlWorkSheet.Cells(4, columna)).Interior.Color = RGB(255, 255, 153)
                xlWorkSheet.Cells(4, columna) = "TOTAL " & _SubAgrupacion(j)

                xlWorkSheet.Range(xlWorkSheet.Cells(4, IIf(i > 0 And j = 0, inicio - 1, inicio)), xlWorkSheet.Cells(4, columna - 1)).Columns.Group()

                If j = 1 Then

                    columna = columna + 1

                    xlWorkSheet.Range(xlWorkSheet.Cells(1, columna), xlWorkSheet.Cells(3, columna)).Interior.Color = RGB(51, 204, 204)
                    xlWorkSheet.Cells(3, columna) = _Agrupacion(i)

                    xlWorkSheet.Range(xlWorkSheet.Cells(4, columna), xlWorkSheet.Cells(4, columna)).Interior.Color = RGB(255, 255, 153)
                    xlWorkSheet.Cells(4, columna) = "TOTALES"

                End If


                xlWorkSheet.Range(xlWorkSheet.Cells(1, inicio), xlWorkSheet.Cells(4, columna)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                xlWorkSheet.Range(xlWorkSheet.Cells(1, inicio), xlWorkSheet.Cells(4, columna)).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                xlWorkSheet.Range(xlWorkSheet.Cells(1, inicio), xlWorkSheet.Cells(4, columna)).Font.Name = "Calibri"
                xlWorkSheet.Range(xlWorkSheet.Cells(1, inicio), xlWorkSheet.Cells(4, columna)).Font.Size = 9
                xlWorkSheet.Range(xlWorkSheet.Cells(1, inicio), xlWorkSheet.Cells(4, columna)).Font.Bold = True


                columna = columna + 1
                inicio = columna
            Next

        Next

        help.SetAllBorders_Thin(xlWorkSheet.Range(xlWorkSheet.Cells(1, 1), xlWorkSheet.Cells(1, columna - 1)))
        help.SetAllBorders_Thin(xlWorkSheet.Range(xlWorkSheet.Cells(2, 1), xlWorkSheet.Cells(2, columna - 1)))
        help.SetAllBorders_Thin(xlWorkSheet.Range(xlWorkSheet.Cells(3, 1), xlWorkSheet.Cells(3, columna - 1)))
        help.SetAllBorders_Thin(xlWorkSheet.Range(xlWorkSheet.Cells(4, 1), xlWorkSheet.Cells(4, columna - 1)))

        xlWorkSheet.Range(xlWorkSheet.Cells(5, 2), xlWorkSheet.Cells(5, 2)).Select()
        _xlWorkBook.Windows(1).FreezePanes = True

        Marshal.ReleaseComObject(xlWorkSheet)

    End Sub

    Sub GenerarCuadroDetallePorDia()

        Dim xlWorkSheet As New Worksheet
        xlWorkSheet = _xlWorkBook.Worksheets.Item(3) '4: HOJA DETALLADO X DIA
        xlWorkSheet.Select()

        Dim ReporteBusinessLogic As New ReporteBusinessLogic()

        Dim ListaReporteEmpresa As New List(Of ReporteVentaEmpresa)

        ListaReporteEmpresa = ReporteBusinessLogic.SelReporteDetalladoPorDia(_FechaIniRep, _FechaFinRep)


        Dim fila, columna, totalColumnas, inicio, indexAgrupacion, indexSubagrupacion, indexZona, indexSucursal, za As Integer
        Dim formulaLocal, diaNatural As String

        formulaLocal = String.Empty
        diaNatural = String.Empty

        Dim ListaColumnTotalPorSucursal, ListaColumnaTotalPorSubAgrupacion, ListaColumnaTotales, ListaColumnaDiaNatural As New ArrayList

        fila = 5

        For Each dia As Date In ListaReporteEmpresa.[Select](Function(s) s.DiaNatural).Distinct()

            columna = 2
            inicio = 2
            totalColumnas = 0

            diaNatural = String.Concat("'", dia.Day.ToString().PadLeft(2, "0"c), "/", dia.Month.ToString().PadLeft(2, "0"c), "/", dia.Year.ToString())

            xlWorkSheet.Cells(fila, 1) = diaNatural

            '------------------AGRUPACION--------------------
            For indexAgrupacion = 0 To _Agrupacion.Length - 1

                '-------------RECORRE SUBAGRUPACION--------------------
                For indexSubagrupacion = 0 To _SubAgrupacion.Length - 1

                    '------------RECORRE ZONA-------------------
                    For indexZona = 0 To _lstZona.Count - 1

                        Dim local_i As Integer = indexZona
                        Dim lstSucursal As List(Of Sucursal) = _lstSucursal.FindAll(Function(x) x.IdZona = _lstZona.Item(local_i).IdZona)

                        '--------RECORRE SUCURSAL----------------------
                        For indexSucursal = 0 To lstSucursal.Count - 1

                            Dim codigoSucursal As String = lstSucursal(indexSucursal).CodigoSucursal.Trim()
                            Dim codigoTienda As Integer = Integer.Parse(codigoSucursal.Substring(1, codigoSucursal.Length - 1))
                            Dim valor As String = String.Empty

                            Select Case indexAgrupacion
                                Case 0
                                    If indexSubagrupacion = 0 Then
                                        valor = ListaReporteEmpresa.Where(Function(m) m.IdZona = _lstZona.Item(local_i).IdZona And m.CodigoTienda = codigoTienda And m.DiaNatural = dia).Select(Function(n) n.VentaContado).FirstOrDefault
                                    Else
                                        valor = ListaReporteEmpresa.Where(Function(m) m.IdZona = _lstZona.Item(local_i).IdZona And m.CodigoTienda = codigoTienda And m.DiaNatural = dia).Select(Function(n) n.VentaCredito).FirstOrDefault
                                    End If
                                Case 1
                                    If indexSubagrupacion = 0 Then
                                        valor = ListaReporteEmpresa.Where(Function(m) m.IdZona = _lstZona.Item(local_i).IdZona And m.CodigoTienda = codigoTienda And m.DiaNatural = dia).Select(Function(n) n.MargenContado).FirstOrDefault
                                    Else
                                        valor = ListaReporteEmpresa.Where(Function(m) m.IdZona = _lstZona.Item(local_i).IdZona And m.CodigoTienda = codigoTienda And m.DiaNatural = dia).Select(Function(n) n.MargenCredito).FirstOrDefault
                                    End If
                                Case 2
                                    If indexSubagrupacion = 0 Then
                                        valor = ListaReporteEmpresa.Where(Function(m) m.IdZona = _lstZona.Item(local_i).IdZona And m.CodigoTienda = codigoTienda And m.DiaNatural = dia).Select(Function(n) n.TransaccionesContado).FirstOrDefault
                                    Else
                                        valor = ListaReporteEmpresa.Where(Function(m) m.IdZona = _lstZona.Item(local_i).IdZona And m.CodigoTienda = codigoTienda And m.DiaNatural = dia).Select(Function(n) n.TransaccionesCredito).FirstOrDefault
                                    End If
                                Case Else
                                    If indexSubagrupacion = 0 Then
                                        valor = ListaReporteEmpresa.Where(Function(m) m.IdZona = _lstZona.Item(local_i).IdZona And m.CodigoTienda = codigoTienda And m.DiaNatural = dia).Select(Function(n) n.TicketPromedioContado).FirstOrDefault
                                    Else
                                        valor = ListaReporteEmpresa.Where(Function(m) m.IdZona = _lstZona.Item(local_i).IdZona And m.CodigoTienda = codigoTienda And m.DiaNatural = dia).Select(Function(n) n.TicketPromedioCredito).FirstOrDefault
                                    End If
                            End Select

                            xlWorkSheet.Cells(fila, columna) = valor

                            columna += 1
                            totalColumnas += 1

                            If indexSucursal = lstSucursal.Count - 1 Then

                                ListaColumnTotalPorSucursal.Add(columna.ToString())

                                xlWorkSheet.Range(xlWorkSheet.Cells(fila, columna), xlWorkSheet.Cells(fila, columna)).Interior.Color = RGB(217, 217, 217)
                                xlWorkSheet.Range(xlWorkSheet.Cells(fila, columna), xlWorkSheet.Cells(fila, columna)).FormulaLocal = "=SUMA(" & help.ColName(inicio) & fila.ToString() & ":" & help.ColName(columna - 1) & fila.ToString() & ")"
                                xlWorkSheet.Range(xlWorkSheet.Cells(fila, inicio), xlWorkSheet.Cells(fila, columna)).NumberFormat = "#,##0"

                                columna += 1
                                totalColumnas += 1
                                inicio = columna

                            End If

                        Next

                        If indexSubagrupacion = _SubAgrupacion.Length - 1 And indexZona = _lstZona.Count - 1 Then

                            columna += 1
                            totalColumnas += 1
                            inicio = columna

                        End If

                        If indexZona = _lstZona.Count - 1 Then

                            For za = 0 To ListaColumnTotalPorSucursal.Count - 1
                                If za = ListaColumnTotalPorSucursal.Count - 1 Then
                                    formulaLocal &= help.ColName(TryCast(ListaColumnTotalPorSucursal.Item(za), String)) & fila.ToString()
                                Else
                                    formulaLocal &= help.ColName(TryCast(ListaColumnTotalPorSucursal.Item(za), String)) & fila.ToString() & ","
                                End If
                            Next

                            xlWorkSheet.Range(xlWorkSheet.Cells(fila, columna), xlWorkSheet.Cells(fila, columna)).Interior.Color = RGB(255, 255, 153)
                            xlWorkSheet.Range(xlWorkSheet.Cells(fila, columna), xlWorkSheet.Cells(fila, columna)).FormulaLocal = "=SUMA(" & formulaLocal & ")"
                            help.SetAllBorders_Thin(xlWorkSheet.Range(xlWorkSheet.Cells(fila, columna), xlWorkSheet.Cells(fila, columna)))
                            xlWorkSheet.Range(xlWorkSheet.Cells(fila, columna), xlWorkSheet.Cells(fila, columna)).NumberFormat = "#,##0"

                            ListaColumnaTotalPorSubAgrupacion.Add(columna.ToString())

                            If fila = 5 Then
                                ListaColumnaTotales.Add(columna.ToString())
                            End If

                            columna += 1
                            totalColumnas += 1
                            inicio = columna

                        End If

                        formulaLocal = String.Empty

                        If indexSubagrupacion = _SubAgrupacion.Length - 1 And indexZona = _lstZona.Count - 1 Then

                            For za = 0 To ListaColumnaTotalPorSubAgrupacion.Count - 1
                                If za = ListaColumnaTotalPorSubAgrupacion.Count - 1 Then
                                    formulaLocal &= help.ColName(TryCast(ListaColumnaTotalPorSubAgrupacion.Item(za), String)) & fila.ToString()
                                Else
                                    formulaLocal &= help.ColName(TryCast(ListaColumnaTotalPorSubAgrupacion.Item(za), String)) & fila.ToString() & ","
                                End If
                            Next

                            xlWorkSheet.Range(xlWorkSheet.Cells(fila, columna), xlWorkSheet.Cells(fila, columna)).Interior.Color = RGB(255, 255, 153)
                            xlWorkSheet.Range(xlWorkSheet.Cells(fila, columna), xlWorkSheet.Cells(fila, columna)).FormulaLocal = "=SUMA(" & formulaLocal & ")"
                            help.SetAllBorders_Thin(xlWorkSheet.Range(xlWorkSheet.Cells(fila, columna), xlWorkSheet.Cells(fila, columna)))
                            xlWorkSheet.Range(xlWorkSheet.Cells(fila, columna), xlWorkSheet.Cells(fila, columna)).NumberFormat = "#,##0"

                            If fila = 5 Then
                                ListaColumnaTotales.Add(columna.ToString())
                            End If

                            columna += 1
                            totalColumnas += 1
                            inicio = columna

                            If Not (indexAgrupacion = _Agrupacion.Length - 1 And indexSubagrupacion = _SubAgrupacion.Length - 1) Then
                                xlWorkSheet.Cells(fila, columna) = diaNatural
                                If fila = 5 Then
                                    ListaColumnaDiaNatural.Add(columna.ToString())
                                End If

                            End If

                            columna += 1
                            totalColumnas += 1
                            inicio = columna

                        End If

                    Next

                    ListaColumnTotalPorSucursal.Clear()

                Next

                ListaColumnaTotalPorSubAgrupacion.Clear()

            Next

            fila += 1

        Next

        xlWorkSheet.Range(xlWorkSheet.Cells(5, 1), xlWorkSheet.Cells(fila, totalColumnas - 1)).Font.Name = "Calibri"
        xlWorkSheet.Range(xlWorkSheet.Cells(5, 1), xlWorkSheet.Cells(fila, totalColumnas - 1)).Font.Size = 9

        xlWorkSheet.Range(xlWorkSheet.Cells(fila, 1), xlWorkSheet.Cells(fila, 1)).Font.Bold = True
        xlWorkSheet.Range(xlWorkSheet.Cells(fila, 1), xlWorkSheet.Cells(fila, 1)).Interior.Color = RGB(221, 235, 247)
        xlWorkSheet.Range(xlWorkSheet.Cells(fila, 1), xlWorkSheet.Cells(fila, 1)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft
        xlWorkSheet.Range(xlWorkSheet.Cells(fila, 1), xlWorkSheet.Cells(fila, 1)).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignBottom
        xlWorkSheet.Cells(fila, 1) = "Total general"

        Dim icol As Integer
        icol = 0

        For icol = 1 To totalColumnas - 1

            xlWorkSheet.Range(xlWorkSheet.Cells(fila, icol + 1), xlWorkSheet.Cells(fila, icol + 1)).Font.Bold = True
            xlWorkSheet.Range(xlWorkSheet.Cells(fila, icol + 1), xlWorkSheet.Cells(fila, icol + 1)).Interior.Color = RGB(221, 235, 247)
            xlWorkSheet.Range(xlWorkSheet.Cells(fila, icol + 1), xlWorkSheet.Cells(fila, icol + 1)).FormulaLocal = "=SUMA(" & help.ColName(icol + 1) & "5:" & help.ColName(icol + 1) & (fila - 1).ToString() & ")"

            If ListaColumnaDiaNatural.IndexOf((icol + 1).ToString()) <> -1 Then
                xlWorkSheet.Range(xlWorkSheet.Cells(fila, icol + 1), xlWorkSheet.Cells(fila, icol + 1)).Font.Bold = True
                xlWorkSheet.Range(xlWorkSheet.Cells(fila, icol + 1), xlWorkSheet.Cells(fila, icol + 1)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft
                xlWorkSheet.Range(xlWorkSheet.Cells(fila, icol + 1), xlWorkSheet.Cells(fila, icol + 1)).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignBottom
                xlWorkSheet.Cells(fila, icol + 1) = "Total general"
            Else
                If ListaColumnaTotales.IndexOf((icol + 1).ToString()) <> -1 Then
                    xlWorkSheet.Range(xlWorkSheet.Cells(fila, icol + 1), xlWorkSheet.Cells(fila, icol + 1)).Interior.Color = RGB(255, 255, 153)
                    help.SetAllBorders_Thin(xlWorkSheet.Range(xlWorkSheet.Cells(fila, icol + 1), xlWorkSheet.Cells(fila, icol + 1)))
                End If
            End If

            xlWorkSheet.Columns(help.ColName(icol + 1)).AutoFit()

        Next

    End Sub

    'Sub formatoPrevio()
    '    'Freeze panels
    '    _xlWorkSheet.Range(_xlWorkSheet.Cells(5, 2), _xlWorkSheet.Cells(5, 2)).Select()
    '    _xlWorkBook.Windows(1).FreezePanes = True
    'End Sub

    'Sub GenerarColDiasNaturales(col As Integer, nomGrupo As String)
    '    Dim varFecha As Date = _FechaIniRep
    '    Dim rowIniDiasNaturales As Integer = 5
    '    rowTotalGeneral = rowIniDiasNaturales

    '    _xlWorkSheet.Cells(1, col) = nomGrupo '"V. Neta, MARGEN, etc"
    '    _xlWorkSheet.Range(_xlWorkSheet.Cells(1, col), _xlWorkSheet.Cells(1, col)).Interior.Color = RGB(255, 255, 0) 'amarillo
    '    _xlWorkSheet.Cells(2, col) = "Forma de Pago"
    '    _xlWorkSheet.Cells(3, col) = "ZONAS"
    '    _xlWorkSheet.Cells(4, col) = "Día natural"

    '    If bDiasGenerados Then
    '        CopyDiasNaturalesTo(_xlWorkSheet.Range(_xlWorkSheet.Cells(rowIniDiasNaturales, col), _xlWorkSheet.Cells(rowIniDiasNaturales, col)))
    '    Else
    '        Do While varFecha <= _FechaFinRep
    '            _xlWorkSheet.Cells(rowIniDiasNaturales, col) = varFecha
    '            varFecha = varFecha.AddDays(1)
    '            rowIniDiasNaturales = rowIniDiasNaturales + 1
    '            numRowsDias = numRowsDias + 1
    '        Loop
    '        bDiasGenerados = True
    '    End If

    '    rowTotalGeneral = rowTotalGeneral + numRowsDias
    '    _xlWorkSheet.Range(_xlWorkSheet.Cells(1, col), _xlWorkSheet.Cells(4, col)).Interior.Color = RGB(51, 204, 204) 'turquesa
    '    _xlWorkSheet.Cells(rowTotalGeneral, col) = "Total general"
    '    _xlWorkSheet.Range(_xlWorkSheet.Cells(rowTotalGeneral, col), _xlWorkSheet.Cells(rowTotalGeneral, col)).Interior.Color = RGB(221, 235, 247) 'celeste
    '    'formato celdas
    '    help.SetAllBorders_Thin(_xlWorkSheet.Range(_xlWorkSheet.Cells(1, col), _xlWorkSheet.Cells(4, col)))
    'End Sub

    'Sub CopyDiasNaturalesTo(rng As Range)
    '    _xlWorkSheet.Range(_xlWorkSheet.Cells(5, 1), _xlWorkSheet.Cells(4 + numRowsDias, 1)).Copy()
    '    rng.PasteSpecial(XlPasteType.xlPasteAll)
    'End Sub

    'Sub GenerarVentaNeta()
    '    Dim col As Integer = 1
    '    GenerarColDiasNaturales(col, "V.Neta")
    '    _xlWorkSheet.Cells(2, col + 1) = "CONTADO"

    '    Dim iniColTiendas As Integer = 2
    '    col = iniColTiendas

    '    For i = 0 To _lstZona.Count - 1
    '        Dim local_i As Integer = i
    '        Dim lstSucursal As List(Of Sucursal) = _lstSucursal.FindAll(Function(x) x.IdZona = _lstZona.Item(local_i).IdZona)

    '        For j = 0 To lstSucursal.Count - 1
    '            _xlWorkSheet.Cells(4, col) = (lstSucursal(j)).Descripcion
    '            col = col + 1
    '        Next

    '        _xlWorkSheet.Cells(3, col - lstSucursal.Count) = (_lstZona(i)).NombreZona
    '        'Merge para el nombre de la zona
    '        _xlWorkSheet.Range(_xlWorkSheet.Cells(3, col - lstSucursal.Count), _xlWorkSheet.Cells(3, col - 1)).Merge()
    '        _xlWorkSheet.Range(_xlWorkSheet.Cells(3, col - lstSucursal.Count), _xlWorkSheet.Cells(3, col - 1)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
    '        _xlWorkSheet.Range(_xlWorkSheet.Cells(3, col - lstSucursal.Count), _xlWorkSheet.Cells(3, col - 1)).Interior.Color = RGB(248, 203, 173) 'rosa
    '        _xlWorkSheet.Range(_xlWorkSheet.Cells(4, col - lstSucursal.Count), _xlWorkSheet.Cells(4, col - 1)).Interior.Color = RGB(221, 235, 247) 'celeste

    '        _xlWorkSheet.Cells(3, col) = "VENTA"
    '        _xlWorkSheet.Range(_xlWorkSheet.Cells(3, col), _xlWorkSheet.Cells(3, col)).Interior.Color = RGB(51, 204, 204) 'turquesa
    '        _xlWorkSheet.Cells(4, col) = "Resultado"
    '        _xlWorkSheet.Range(_xlWorkSheet.Cells(4, col), _xlWorkSheet.Cells(4, col)).Interior.Color = RGB(255, 255, 153) 'crema
    '        _xlWorkSheet.Range(_xlWorkSheet.Cells(5, col), _xlWorkSheet.Cells(4 + numRowsDias, col)).Interior.Color = RGB(217, 217, 217) 'lila
    '        col = col + 1
    '    Next

    '    'setea color fraja superior
    '    _xlWorkSheet.Range(_xlWorkSheet.Cells(1, iniColTiendas), _xlWorkSheet.Cells(2, col)).Interior.Color = RGB(51, 204, 204) 'turquesa
    '    'setea color celeste a la fila "total general"
    '    _xlWorkSheet.Range(_xlWorkSheet.Cells(rowTotalGeneral, iniColTiendas), _xlWorkSheet.Cells(rowTotalGeneral, col - 1)).Interior.Color = RGB(221, 235, 247) 'celeste
    '    'agrupacion de columnas
    '    _xlWorkSheet.Range(_xlWorkSheet.Cells(4, iniColTiendas), _xlWorkSheet.Cells(4, col - 1)).Columns.Group()

    '    _xlWorkSheet.Cells(3, col) = "VENTA"
    '    _xlWorkSheet.Range(_xlWorkSheet.Cells(3, col), _xlWorkSheet.Cells(3, col)).Interior.Color = RGB(51, 204, 204) 'turquesa
    '    _xlWorkSheet.Cells(4, col) = "TOTAL CONTADO"
    '    _xlWorkSheet.Range(_xlWorkSheet.Cells(4, col), _xlWorkSheet.Cells(rowTotalGeneral, col)).Interior.Color = RGB(255, 255, 153) 'crema
    '    help.SetAllBorders_Thin(_xlWorkSheet.Range(_xlWorkSheet.Cells(4, col), _xlWorkSheet.Cells(rowTotalGeneral, col)))

    '    col = col + 1

    '    '----------------------------------------------------------------------------------------------------------------------------------------------------
    '    iniColTiendas = col

    '    _xlWorkSheet.Cells(1, col) = "V.Neta"
    '    _xlWorkSheet.Cells(2, col) = "CREDITO"

    '    For i = 0 To _lstZona.Count - 1
    '        Dim local_i As Integer = i
    '        Dim lstSucursal As List(Of Sucursal) = _lstSucursal.FindAll(Function(x) x.IdZona = _lstZona.Item(local_i).IdZona)

    '        For j = 0 To lstSucursal.Count - 1
    '            _xlWorkSheet.Cells(4, col) = (lstSucursal(j)).Descripcion
    '            col = col + 1
    '        Next

    '        _xlWorkSheet.Cells(3, col - lstSucursal.Count) = (_lstZona(i)).NombreZona
    '        'Merge para el nombre de la zona
    '        _xlWorkSheet.Range(_xlWorkSheet.Cells(3, col - lstSucursal.Count), _xlWorkSheet.Cells(3, col - 1)).Merge()
    '        _xlWorkSheet.Range(_xlWorkSheet.Cells(3, col - lstSucursal.Count), _xlWorkSheet.Cells(3, col - 1)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
    '        _xlWorkSheet.Range(_xlWorkSheet.Cells(3, col - lstSucursal.Count), _xlWorkSheet.Cells(3, col - 1)).Interior.Color = RGB(248, 203, 173) 'rosa
    '        _xlWorkSheet.Range(_xlWorkSheet.Cells(4, col - lstSucursal.Count), _xlWorkSheet.Cells(4, col - 1)).Interior.Color = RGB(221, 235, 247) 'celeste

    '        _xlWorkSheet.Cells(3, col) = "VENTA"
    '        _xlWorkSheet.Range(_xlWorkSheet.Cells(3, col), _xlWorkSheet.Cells(3, col)).Interior.Color = RGB(51, 204, 204) 'turquesa
    '        _xlWorkSheet.Cells(4, col) = "Resultado"
    '        _xlWorkSheet.Range(_xlWorkSheet.Cells(4, col), _xlWorkSheet.Cells(4, col)).Interior.Color = RGB(255, 255, 153) 'crema
    '        _xlWorkSheet.Range(_xlWorkSheet.Cells(5, col), _xlWorkSheet.Cells(4 + numRowsDias, col)).Interior.Color = RGB(217, 217, 217) 'lila
    '        col = col + 1
    '    Next

    '    _xlWorkSheet.Cells(4, col) = "ORACLE"
    '    _xlWorkSheet.Range(_xlWorkSheet.Cells(3, col), _xlWorkSheet.Cells(3, col)).Interior.Color = RGB(51, 204, 204) 'turquesa
    '    _xlWorkSheet.Range(_xlWorkSheet.Cells(4, col), _xlWorkSheet.Cells(4, col)).Interior.Color = RGB(217, 217, 217) 'lila

    '    'setea color celeste a la fila "total general"
    '    _xlWorkSheet.Range(_xlWorkSheet.Cells(rowTotalGeneral, iniColTiendas), _xlWorkSheet.Cells(rowTotalGeneral, col)).Interior.Color = RGB(221, 235, 247) 'celeste
    '    'agrupacion de columnas
    '    _xlWorkSheet.Range(_xlWorkSheet.Cells(4, iniColTiendas), _xlWorkSheet.Cells(4, col)).Columns.Group()

    '    col = col + 1

    '    _xlWorkSheet.Cells(3, col) = "VENTA"
    '    _xlWorkSheet.Range(_xlWorkSheet.Cells(3, col), _xlWorkSheet.Cells(3, col)).Interior.Color = RGB(51, 204, 204) 'turquesa

    '    _xlWorkSheet.Cells(4, col) = "TOTAL CREDITO"
    '    _xlWorkSheet.Range(_xlWorkSheet.Cells(4, col), _xlWorkSheet.Cells(rowTotalGeneral, col)).Interior.Color = RGB(255, 255, 153) 'crema
    '    help.SetAllBorders_Thin(_xlWorkSheet.Range(_xlWorkSheet.Cells(4, col), _xlWorkSheet.Cells(rowTotalGeneral, col)))

    '    col = col + 1

    '    _xlWorkSheet.Cells(3, col) = "VENTA"
    '    _xlWorkSheet.Range(_xlWorkSheet.Cells(3, col), _xlWorkSheet.Cells(3, col)).Interior.Color = RGB(51, 204, 204) 'turquesa
    '    _xlWorkSheet.Cells(4, col) = "TOTALES"
    '    _xlWorkSheet.Range(_xlWorkSheet.Cells(4, col), _xlWorkSheet.Cells(rowTotalGeneral, col)).Interior.Color = RGB(255, 255, 153) 'crema
    '    help.SetAllBorders_Thin(_xlWorkSheet.Range(_xlWorkSheet.Cells(4, col), _xlWorkSheet.Cells(rowTotalGeneral, col)))
    '    'setea color fraja superior
    '    _xlWorkSheet.Range(_xlWorkSheet.Cells(1, iniColTiendas), _xlWorkSheet.Cells(2, col)).Interior.Color = RGB(51, 204, 204) 'turquesa

    '    col = col + 1

    '    lastCol = col
    'End Sub

    'Sub GenerarMargen()
    '    Dim col As Integer = lastCol
    '    GenerarColDiasNaturales(col, "MARGEN")
    '    _xlWorkSheet.Range(_xlWorkSheet.Cells(1, col), _xlWorkSheet.Cells(1, col)).Interior.Color = RGB(255, 255, 0) 'amarillo
    '    _xlWorkSheet.Cells(2, col) = "Forma de Pago"
    '    _xlWorkSheet.Cells(3, col) = "ZONAS"
    '    _xlWorkSheet.Cells(4, col) = "Día natural"
    '    _xlWorkSheet.Cells(2, col + 1) = "CONTADO"

    '    CopyDiasNaturalesTo(_xlWorkSheet.Range(_xlWorkSheet.Cells(5, col), _xlWorkSheet.Cells(5, col)))

    'End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        Marshal.ReleaseComObject(Me._xlWorkSheet)
        Marshal.ReleaseComObject(Me._xlWorkBook)
    End Sub
End Class
