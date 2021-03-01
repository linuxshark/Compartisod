Imports OfficeOpenXml
Imports Sodimac.VentaEmpresa.DataContracts
Imports System.Drawing
Imports Sodimac.VentaEmpresa.BusinessLogic

Public Class detalleXDia
    Dim _xlWorkBook As ExcelWorkbook
    Dim _FechaIniRep As Date
    Dim _FechaFinRep As Date
    Dim _lstZona As List(Of Zona)
    Dim _lstSucursal As List(Of Sucursal)
    Dim help As New HelperReporteVAP
    Dim _Agrupacion() As String = {"VENTA", "MARGEN", "TRANSACCIONES", "TICKET PROMEDIO"}
    Dim _SubAgrupacion() As String = {"CONTADO", "CREDITO"}

    Sub New(xlWorkBook As ExcelWorkbook, fechaInicio As Date, fechaFin As Date, lstZona As List(Of Zona), lstSucursal As List(Of Sucursal))
        Me._xlWorkBook = xlWorkBook
        Me._FechaIniRep = fechaInicio
        Me._FechaFinRep = fechaFin
        Me._lstZona = lstZona
        Me._lstSucursal = lstSucursal
    End Sub

    Sub Generar()
        GenerarFormatoPrevio()
        GenerarCuadroDetallePorDia()
    End Sub

    Sub GenerarFormatoPrevio()
        Dim ArrayInicioColumna(_lstZona.Count - 1) As Integer
        Dim xlWorkSheet As ExcelWorksheet
        xlWorkSheet = _xlWorkBook.Worksheets.Item(3) '3: HOJA DETALLADO X DIA
        xlWorkSheet.Select()
        xlWorkSheet.View.ZoomScale = 100
        GenerarCabecera(xlWorkSheet)
    End Sub

    Sub GenerarCabecera(ByRef xlWorkSheet As ExcelWorksheet)
        Dim columna As Integer = 2, inicio As Integer = 2, zona As Integer = 2

        xlWorkSheet.Cells(1, inicio - 1, 4, inicio - 1).Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Center
        xlWorkSheet.Cells(1, inicio - 1, 4, inicio - 1).Style.VerticalAlignment = Style.ExcelVerticalAlignment.Center
        xlWorkSheet.Cells(1, inicio - 1, 4, inicio - 1).Style.Font.Name = "Calibri"
        xlWorkSheet.Cells(1, inicio - 1, 4, inicio - 1).Style.Font.Size = 9
        xlWorkSheet.Cells(1, inicio - 1, 4, inicio - 1).Style.Font.Bold = True
        xlWorkSheet.Cells(1, inicio - 1, 4, inicio - 1).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
        xlWorkSheet.Cells(1, inicio - 1, 4, inicio - 1).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(51, 204, 204))
        xlWorkSheet.Cells(2, inicio - 1).Value = "Forma de Pago"
        xlWorkSheet.Cells(3, inicio - 1).Value = "ZONAS"
        xlWorkSheet.Cells(4, inicio - 1).Value = "Día Natural"

        Dim i, j, k As Integer

        For i = 0 To _Agrupacion.Length - 1
            If i > 0 Then
                xlWorkSheet.Cells(1, inicio, 4, columna).Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Center
                xlWorkSheet.Cells(1, inicio, 4, columna).Style.VerticalAlignment = Style.ExcelVerticalAlignment.Center
                xlWorkSheet.Cells(1, inicio, 4, columna).Style.Font.Name = "Calibri"
                xlWorkSheet.Cells(1, inicio, 4, columna).Style.Font.Size = 9
                xlWorkSheet.Cells(1, inicio, 4, columna).Style.Font.Bold = True

                xlWorkSheet.Cells(1, inicio, 4, inicio).Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Center
                xlWorkSheet.Cells(1, inicio, 4, inicio).Style.VerticalAlignment = Style.ExcelVerticalAlignment.Center
                xlWorkSheet.Cells(1, inicio, 4, inicio).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                xlWorkSheet.Cells(1, inicio, 4, inicio).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(51, 204, 204))
                xlWorkSheet.Cells(2, inicio).Value = "Forma de Pago"
                xlWorkSheet.Cells(3, inicio).Value = "ZONAS"
                xlWorkSheet.Cells(4, inicio).Value = "Día Natural"

                columna = columna + 1
                inicio = columna
            End If

            For j = 0 To _SubAgrupacion.Length - 1
                zona = inicio
                For k = 0 To _lstZona.Count - 1
                    Dim lstSucursal As List(Of Sucursal) = _lstSucursal.FindAll(Function(x) x.IdZona = _lstZona.Item(k).IdZona)
                    For l = 0 To lstSucursal.Count - 1
                        xlWorkSheet.Cells(4, columna).Value = (lstSucursal(l)).Descripcion
                        columna = columna + 1
                    Next

                    columna = columna - 1

                    xlWorkSheet.Cells(3, zona, 3, columna).Merge = True
                    xlWorkSheet.Cells(3, zona, 3, columna).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                    xlWorkSheet.Cells(3, zona, 3, columna).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(248, 203, 173))
                    xlWorkSheet.Cells(3, zona).Value = (_lstZona(k)).NombreZona

                    xlWorkSheet.Cells(4, zona, 4, columna).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                    xlWorkSheet.Cells(4, zona, 4, columna).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(221, 235, 247))

                    columna = columna + 1

                    xlWorkSheet.Cells(1, inicio, 2, columna).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                    xlWorkSheet.Cells(1, inicio, 2, columna).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(51, 204, 204))
                    xlWorkSheet.Cells(3, columna, 3, columna).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                    xlWorkSheet.Cells(3, columna, 3, columna).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(51, 204, 204))

                    xlWorkSheet.Cells(1, inicio).Value = _Agrupacion(i)
                    xlWorkSheet.Cells(2, inicio).Value = _SubAgrupacion(j)
                    xlWorkSheet.Cells(3, columna).Value = _Agrupacion(i)

                    xlWorkSheet.Cells(4, columna, 4, columna).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                    xlWorkSheet.Cells(4, columna, 4, columna).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 153))
                    xlWorkSheet.Cells(4, columna).Value = "Resultado"

                    columna = columna + 1
                    zona = columna
                Next

                If j = 1 Then
                    xlWorkSheet.Cells(1, columna, 2, columna).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                    xlWorkSheet.Cells(1, columna, 2, columna).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(51, 204, 204))
                    xlWorkSheet.Cells(3, columna, 3, columna).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                    xlWorkSheet.Cells(3, columna, 3, columna).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(217, 217, 217))
                    xlWorkSheet.Cells(3, columna).Value = "ORACLE"

                    xlWorkSheet.Cells(4, columna, 4, columna).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                    xlWorkSheet.Cells(4, columna, 4, columna).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 153))
                    xlWorkSheet.Cells(4, columna).Value = "Resultado"

                    columna = columna + 1
                End If

                xlWorkSheet.Cells(1, columna, 3, columna).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                xlWorkSheet.Cells(1, columna, 3, columna).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(51, 204, 204))
                xlWorkSheet.Cells(3, columna).Value = _Agrupacion(i)

                xlWorkSheet.Cells(4, columna, 4, columna).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                xlWorkSheet.Cells(4, columna, 4, columna).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 153))
                xlWorkSheet.Cells(4, columna).Value = "TOTAL " & _SubAgrupacion(j)

                'xlWorkSheet.Cells(4, IIf(i > 0 And j = 0, inicio - 1, inicio), 4, columna - 1).Columns.Group()
                For col = IIf(i > 0 And j = 0, inicio - 1, inicio) To columna - 1
                    xlWorkSheet.Column(col).OutlineLevel = 1
                    xlWorkSheet.Column(col).Collapsed = True
                Next
                If j = 1 Then
                    columna = columna + 1

                    xlWorkSheet.Cells(1, columna, 3, columna).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                    xlWorkSheet.Cells(1, columna, 3, columna).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(51, 204, 204))
                    xlWorkSheet.Cells(3, columna).Value = _Agrupacion(i)

                    xlWorkSheet.Cells(4, columna, 4, columna).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                    xlWorkSheet.Cells(4, columna, 4, columna).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 153))
                    xlWorkSheet.Cells(4, columna).Value = "TOTALES"
                End If

                xlWorkSheet.Cells(1, inicio, 4, columna).Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Center
                xlWorkSheet.Cells(1, inicio, 4, columna).Style.VerticalAlignment = Style.ExcelVerticalAlignment.Center
                xlWorkSheet.Cells(1, inicio, 4, columna).Style.Font.Name = "Calibri"
                xlWorkSheet.Cells(1, inicio, 4, columna).Style.Font.Size = 9
                xlWorkSheet.Cells(1, inicio, 4, columna).Style.Font.Bold = True

                columna = columna + 1
                inicio = columna
            Next
        Next

        'help.SetAllBorders_Thin(xlWorkSheet.Range(xlWorkSheet.Cells(1, 1), xlWorkSheet.Cells(1, columna - 1)))
        'help.SetAllBorders_Thin(xlWorkSheet.Range(xlWorkSheet.Cells(2, 1), xlWorkSheet.Cells(2, columna - 1)))
        'help.SetAllBorders_Thin(xlWorkSheet.Range(xlWorkSheet.Cells(3, 1), xlWorkSheet.Cells(3, columna - 1)))
        'help.SetAllBorders_Thin(xlWorkSheet.Range(xlWorkSheet.Cells(4, 1), xlWorkSheet.Cells(4, columna - 1)))
        Dim xl_range As ExcelRange = xlWorkSheet.Cells(1, 1, 1, columna - 1)
        help.SetAllBorders_Thin(xl_range)
        Dim xl_range1 As ExcelRange = xlWorkSheet.Cells(2, 1, 2, columna - 1)
        help.SetAllBorders_Thin(xl_range1)
        Dim xl_range2 As ExcelRange = xlWorkSheet.Cells(3, 1, 3, columna - 1)
        help.SetAllBorders_Thin(xl_range2)
        Dim xl_range3 As ExcelRange = xlWorkSheet.Cells(4, 1, 4, columna - 1)
        help.SetAllBorders_Thin(xl_range3)
        'help.SetAllBorders_Medium(xl_range)
        'xlWorkSheet.Cells(5, 2, 5, 2).Select()
        xlWorkSheet.View.FreezePanes(5, 2)
        'Marshal.ReleaseComObject(xlWorkSheet)

    End Sub

    Sub GenerarCuadroDetallePorDia()

        Dim xlWorkSheet As ExcelWorksheet
        xlWorkSheet = _xlWorkBook.Worksheets.Item(3) '4: HOJA DETALLADO X DIA
        xlWorkSheet.Select()

        Dim ReporteBusinessLogic As New ReporteBusinessLogic()
        Dim ListaReporteEmpresa As New List(Of ReporteVentaEmpresa)
        ListaReporteEmpresa = ReporteBusinessLogic.SelReporteDetalladoPorDia(_FechaIniRep, _FechaFinRep)

        Dim fila, columna, totalColumnas, inicio, indexAgrupacion, indexSubagrupacion, indexZona, indexSucursal, za, TotalVenta, TotalMargen, TotalTransac, TotalTicket As Integer
        Dim formulaLocal, diaNatural As String
        formulaLocal = String.Empty
        diaNatural = String.Empty
        Dim pcol As String
        Dim Trans As String
        Dim formulaPrueba, colValor, colTotal, TMTotal As String
        colValor = String.Empty
        colTotal = String.Empty
        TMTotal = String.Empty
        Dim TotalCredito, TotalContado, TotalTransacontado, TotalTransacCredito As String
        Dim ListaSucursalTicket As New ArrayList
        Dim ListaColumnTotalPorSucursal, ListaColumnaTotalPorSubAgrupacion, ListaColumnaTotales, ListaColumnaDiaNatural, ListaTotal As New ArrayList
        fila = 5
        TotalCredito = String.Empty
        formulaPrueba = String.Empty
        For Each dia As Date In ListaReporteEmpresa.[Select](Function(s) s.DiaNatural).Distinct()
            columna = 2
            colValor = columna.ToString
            TotalCredito = columna.ToString
            'colTotal = columna.ToString
            inicio = 2
            totalColumnas = 0
            diaNatural = String.Concat("'", dia.Day.ToString().PadLeft(2, "0"c), "/", dia.Month.ToString().PadLeft(2, "0"c), "/", dia.Year.ToString())
            xlWorkSheet.Cells(fila, 1).Value = diaNatural

            '------------------AGRUPACION--------------------
            For indexAgrupacion = 0 To _Agrupacion.Length - 1
               
                 Select indexAgrupacion
                    Case 0

                        '-------------RECORRE SUBAGRUPACION--------------------
                        For indexSubagrupacion = 0 To _SubAgrupacion.Length - 1
                            '------------RECORRE ZONA-------------------
                            For indexZona = 0 To _lstZona.Count - 1
                                Dim local_i As Integer = indexZona
                                Dim lstSucursal As List(Of Sucursal) = _lstSucursal.FindAll(Function(x) x.IdZona = _lstZona.Item(local_i).IdZona)
                                '--------RECORRE SUCURSAL----------------------
                                For indexSucursal = 0 To lstSucursal.Count - 1
                                    Dim codigoSucursal As String = lstSucursal(indexSucursal).IdSucursal
                                    Dim codigoTienda As Integer = codigoSucursal
                                    Dim valor As Decimal = 0

                                    If indexSubagrupacion = 0 Then
                                        valor = ListaReporteEmpresa.Where(Function(m) m.IdZona = _lstZona.Item(local_i).IdZona And m.CodigoTienda = codigoTienda And m.DiaNatural = dia).Select(Function(n) n.VentaContado).FirstOrDefault
                                    Else
                                        valor = ListaReporteEmpresa.Where(Function(m) m.IdZona = _lstZona.Item(local_i).IdZona And m.CodigoTienda = codigoTienda And m.DiaNatural = dia).Select(Function(n) n.VentaCredito).FirstOrDefault
                                    End If
                                  

                                    xlWorkSheet.Cells(fila, columna).Value = valor
                                    columna += 1
                                    totalColumnas += 1

                                    'Nuevo Codigo
                                    If indexAgrupacion = 0 Then

                                        If indexSucursal = lstSucursal.Count - 1 Then
                                            ListaColumnTotalPorSucursal.Add(columna.ToString())
                                            xlWorkSheet.Cells(fila, columna, fila, columna).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                                            xlWorkSheet.Cells(fila, columna, fila, columna).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(217, 217, 217))
                                            xlWorkSheet.Cells(fila, columna, fila, columna).Formula = "=SUM(" & help.ColName(inicio) & fila.ToString() & ":" & help.ColName(columna - 1) & fila.ToString() & ")"
                                            xlWorkSheet.Cells(fila, inicio, fila, columna).Style.Numberformat.Format = "#,##0"

                                            columna += 1
                                            totalColumnas += 1
                                            inicio = columna
                                        End If

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
                                            formulaLocal &= help.ColName(TryCast(ListaColumnTotalPorSucursal.Item(za), String)) & fila.ToString() & "+"
                                        End If
                                    Next
                                    xlWorkSheet.Cells(fila, columna, fila, columna).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                                    xlWorkSheet.Cells(fila, columna, fila, columna).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 153))
                                    xlWorkSheet.Cells(fila, columna, fila, columna).Formula = "=SUM(" & formulaLocal & ")"
                                    'help.SetAllBorders_Thin(xlWorkSheet.Range(xlWorkSheet.Cells(fila, columna), xlWorkSheet.Cells(fila, columna)))
                                    xlWorkSheet.Cells(fila, columna, fila, columna).Style.Numberformat.Format = "#,##0"

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
                                            formulaLocal &= help.ColName(TryCast(ListaColumnaTotalPorSubAgrupacion.Item(za), String)) & fila.ToString() & "+"
                                        End If
                                    Next

                                    xlWorkSheet.Cells(fila, columna, fila, columna).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                                    xlWorkSheet.Cells(fila, columna, fila, columna).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 153))
                                    xlWorkSheet.Cells(fila, columna, fila, columna).Formula = "=SUM(" & formulaLocal & ")"
                                    'help.SetAllBorders_Thin(xlWorkSheet.Range(xlWorkSheet.Cells(fila, columna), xlWorkSheet.Cells(fila, columna)))
                                    xlWorkSheet.Cells(fila, columna, fila, columna).Style.Numberformat.Format = "#,##0"

                                    If fila = 5 Then
                                        ListaColumnaTotales.Add(columna.ToString())
                                    End If

                                    columna += 1
                                    totalColumnas += 1
                                    inicio = columna
                                    TotalVenta = columna
                                    If Not (indexAgrupacion = _Agrupacion.Length - 1 And indexSubagrupacion = _SubAgrupacion.Length - 1) Then
                                        xlWorkSheet.Cells(fila, columna).Value = diaNatural
                                        If fila = 5 Then
                                            ListaColumnaDiaNatural.Add(columna.ToString())
                                        End If
                                    End If

                                    columna += 1
                                    totalColumnas += 1
                                    inicio = columna
                                    formulaLocal = String.Empty
                                End If
                            Next
                            ListaColumnTotalPorSucursal.Clear()
                        Next
                        ListaColumnaTotalPorSubAgrupacion.Clear()
                    Case 1

                        '-------------RECORRE SUBAGRUPACION--------------------


                        For indexSubagrupacion = 0 To _SubAgrupacion.Length - 1

                            If indexSubagrupacion = 0 Then
                                '------------RECORRE ZONA-------------------
                                For indexZona = 0 To _lstZona.Count - 1
                                    Dim local_i As Integer = indexZona
                                    Dim lstSucursal As List(Of Sucursal) = _lstSucursal.FindAll(Function(x) x.IdZona = _lstZona.Item(local_i).IdZona)
                                    '--------RECORRE SUCURSAL----------------------
                                    For indexSucursal = 0 To lstSucursal.Count - 1
                                        Dim codigoSucursal As String = lstSucursal(indexSucursal).IdSucursal
                                        Dim codigoTienda As Integer = codigoSucursal
                                        Dim valorSucursal As Decimal = 0

                                        valorSucursal = ListaReporteEmpresa.Where(Function(m) m.CodigoTienda = codigoTienda And m.DiaNatural = dia).Select(Function(n) n.MargenContado).FirstOrDefault
                                        xlWorkSheet.Cells(fila, columna).Style.Numberformat.Format = "0.00%"
                                        xlWorkSheet.Cells(fila, columna).Value = valorSucursal
                                        columna += 1
                                        totalColumnas += 1


                                    Next

                                    If indexSubagrupacion = _SubAgrupacion.Length - 1 And indexZona = _lstZona.Count - 1 Then
                                        columna += 1
                                        totalColumnas += 1
                                        inicio = columna
                                    End If

                                    Dim valorZona As String = 0
                                    valorZona = (New ReporteBusinessLogic()).SelReporteDetalladoPorFamiliaZonaContado(dia, (lstSucursal(indexZona)).IdZona.ToString())

                                    xlWorkSheet.Cells(fila, columna, fila, columna).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                                    xlWorkSheet.Cells(fila, columna, fila, columna).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 153))
                                    xlWorkSheet.Cells(fila, columna, fila, columna).Formula = valorZona
                                    xlWorkSheet.Cells(fila, inicio, fila, columna).Style.Numberformat.Format = "0.00%"

                                    ListaColumnaTotalPorSubAgrupacion.Add(columna.ToString())

                                    If fila = 5 Then
                                        ListaColumnaTotales.Add(columna.ToString())
                                    End If
                                    columna += 1
                                    totalColumnas += 1
                                    inicio = columna


                                    formulaLocal = String.Empty
                                    '********* Nuevo codigo  **************+
                                   


                                Next
                                Dim valorZonaTotal As Decimal = 0
                                
                                valorZonaTotal = (New ReporteBusinessLogic()).SelReporteDetalladoPorFamiliaTotalContado(dia)
                                xlWorkSheet.Cells(fila, columna, fila, columna).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                                xlWorkSheet.Cells(fila, columna, fila, columna).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 153))
                                xlWorkSheet.Cells(fila, columna, fila, columna).Value = valorZonaTotal
                                'help.SetAllBorders_Thin(xlWorkSheet.Range(xlWorkSheet.Cells(fila, columna), xlWorkSheet.Cells(fila, columna)))
                                xlWorkSheet.Cells(fila, columna, fila, columna).Style.Numberformat.Format = "0.00%"

                                If fila = 5 Then
                                    ListaColumnaTotales.Add(columna.ToString())
                                End If

                                columna += 1
                                totalColumnas += 1
                                inicio = columna


                                ListaColumnaTotalPorSubAgrupacion.Clear()
                            Else


                                '------------RECORRE ZONA-------------------
                                For indexZona = 0 To _lstZona.Count - 1

                                    Dim local_i As Integer = indexZona
                                    Dim lstSucursal As List(Of Sucursal) = _lstSucursal.FindAll(Function(x) x.IdZona = _lstZona.Item(local_i).IdZona)
                                    '--------RECORRE SUCURSAL----------------------
                                    For indexSucursal = 0 To lstSucursal.Count - 1

                                        Dim codigoSucursal As String = lstSucursal(indexSucursal).IdSucursal
                                        Dim codigoTienda As Integer = codigoSucursal
                                        Dim valorZonaCredito As Decimal = 0

                                        valorZonaCredito = ListaReporteEmpresa.Where(Function(m) m.CodigoTienda = codigoTienda And m.DiaNatural = dia).Select(Function(n) n.MargenCredito).FirstOrDefault
                                        xlWorkSheet.Cells(fila, columna).Style.Numberformat.Format = "0.00%"
                                        xlWorkSheet.Cells(fila, columna).Value = valorZonaCredito
                                        columna += 1
                                        totalColumnas += 1

                                    Next


                                    Dim valorZona As Decimal = 0

                                    valorZona = (New ReporteBusinessLogic()).SelReporteDetalladoPorFamiliaZonaCredito(dia, (lstSucursal(indexZona)).IdZona.ToString())
                                    'Next
                                    xlWorkSheet.Cells(fila, columna, fila, columna).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                                    xlWorkSheet.Cells(fila, columna, fila, columna).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 153))
                                    xlWorkSheet.Cells(fila, columna, fila, columna).Formula = valorZona
                                    xlWorkSheet.Cells(fila, inicio, fila, columna).Style.Numberformat.Format = "0.00%"

                                    ListaColumnaTotalPorSubAgrupacion.Add(columna.ToString())

                                    If fila = 5 Then
                                        ListaColumnaTotales.Add(columna.ToString())
                                    End If

                                    columna += 1
                                    totalColumnas += 1
                                    inicio = columna


                            formulaLocal = String.Empty
                            '********* Nuevo codigo  **************+


                        Next

                                columna += 1
                                totalColumnas += 1
                                inicio = columna
                                Dim valorZonaTotal As Decimal = 0
                                
                                valorZonaTotal = (New ReporteBusinessLogic()).SelReporteDetalladoPorFamiliaTotalCredito(dia)

                                xlWorkSheet.Cells(fila, columna, fila, columna).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                                xlWorkSheet.Cells(fila, columna, fila, columna).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 153))
                                xlWorkSheet.Cells(fila, columna, fila, columna).Value = valorZonaTotal

                                xlWorkSheet.Cells(fila, columna, fila, columna).Style.Numberformat.Format = "0.00%"

                                If fila = 5 Then
                                    ListaColumnaTotales.Add(columna.ToString())
                                End If

                                columna += 1
                                totalColumnas += 1
                                inicio = columna


                                ListaColumnTotalPorSucursal.Clear()
                            End If
                        Next

                        Dim valorZonaTotales As Decimal = 0

                        valorZonaTotales = (New ReporteBusinessLogic()).SelReporteDetalladoPorDia(dia)

                        xlWorkSheet.Cells(fila, columna, fila, columna).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                        xlWorkSheet.Cells(fila, columna, fila, columna).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 153))
                        xlWorkSheet.Cells(fila, columna, fila, columna).Value = valorZonaTotales

                        xlWorkSheet.Cells(fila, columna, fila, columna).Style.Numberformat.Format = "0.00%"

                        If fila = 5 Then
                            ListaColumnaTotales.Add(columna.ToString())
                        End If

                        columna += 1
                        totalColumnas += 1
                        inicio = columna
                        TotalMargen = columna
                        If Not (indexAgrupacion = _Agrupacion.Length - 1 And indexSubagrupacion = _SubAgrupacion.Length - 1) Then
                            xlWorkSheet.Cells(fila, columna).Value = diaNatural
                            If fila = 5 Then
                                ListaColumnaDiaNatural.Add(columna.ToString())
                            End If
                        End If

                        columna += 1
                        totalColumnas += 1
                        inicio = columna
                        TMTotal = columna.ToString
                        ListaColumnaTotalPorSubAgrupacion.Clear()




                    Case 2

                        '-------------RECORRE SUBAGRUPACION--------------------
                        For indexSubagrupacion = 0 To _SubAgrupacion.Length - 1

                            Select Case indexSubagrupacion
                                Case 0

                                    '------------RECORRE ZONA-------------------
                                    For indexZona = 0 To _lstZona.Count - 1
                                        Dim local_i As Integer = indexZona
                                        Dim lstSucursal As List(Of Sucursal) = _lstSucursal.FindAll(Function(x) x.IdZona = _lstZona.Item(local_i).IdZona)
                                        '--------RECORRE SUCURSAL----------------------
                                        For indexSucursal = 0 To lstSucursal.Count - 1
                                            Dim codigoSucursal As String = lstSucursal(indexSucursal).IdSucursal
                                            Dim codigoTienda As Integer = codigoSucursal
                                            Dim valor As Decimal = 0

                                            valor = (New ReporteBusinessLogic()).SelReporteTranssaccionPorsucursal(dia, codigoTienda)
                                           
                                           
                                            ListaColumnTotalPorSucursal.Add(columna.ToString())
                                            xlWorkSheet.Cells(fila, columna).Value = valor
                                            columna += 1
                                            totalColumnas += 1

                                           


                                        Next

                                        If indexSubagrupacion = _SubAgrupacion.Length - 1 And indexZona = _lstZona.Count - 1 Then
                                            columna += 1
                                            totalColumnas += 1
                                            inicio = columna
                                        End If

                                        For za = 0 To ListaColumnTotalPorSucursal.Count - 1
                                            If za = ListaColumnTotalPorSucursal.Count - 1 Then
                                                formulaLocal &= help.ColName(TryCast(ListaColumnTotalPorSucursal.Item(za), String)) & fila.ToString()
                                            Else
                                                formulaLocal &= help.ColName(TryCast(ListaColumnTotalPorSucursal.Item(za), String)) & fila.ToString() & "+"
                                            End If
                                        Next
                                        xlWorkSheet.Cells(fila, columna, fila, columna).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                                        xlWorkSheet.Cells(fila, columna, fila, columna).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 153))
                                        xlWorkSheet.Cells(fila, columna, fila, columna).Formula = "=SUM(" & formulaLocal & ")"
                                        'help.SetAllBorders_Thin(xlWorkSheet.Range(xlWorkSheet.Cells(fila, columna), xlWorkSheet.Cells(fila, columna)))
                                        xlWorkSheet.Cells(fila, columna, fila, columna).Style.Numberformat.Format = "#,##0"

                                        ListaColumnaTotalPorSubAgrupacion.Add(columna.ToString())

                                        If fila = 5 Then
                                            ListaColumnaTotales.Add(columna.ToString())
                                        End If
                                        columna += 1
                                        totalColumnas += 1
                                        inicio = columna
                                        'End If

                                        formulaLocal = String.Empty

                                        ListaColumnTotalPorSucursal.Clear()
                                    Next

                                    'If indexSubagrupacion = _SubAgrupacion.Length - 1 And indexZona = _lstZona.Count - 1 Then
                                    For za = 0 To ListaColumnaTotalPorSubAgrupacion.Count - 1
                                        If za = ListaColumnaTotalPorSubAgrupacion.Count - 1 Then
                                            formulaLocal &= help.ColName(TryCast(ListaColumnaTotalPorSubAgrupacion.Item(za), String)) & fila.ToString()
                                        Else
                                            formulaLocal &= help.ColName(TryCast(ListaColumnaTotalPorSubAgrupacion.Item(za), String)) & fila.ToString() & "+"
                                        End If
                                    Next

                                    xlWorkSheet.Cells(fila, columna, fila, columna).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                                    xlWorkSheet.Cells(fila, columna, fila, columna).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 153))
                                    xlWorkSheet.Cells(fila, columna, fila, columna).Formula = "=SUM(" & formulaLocal & ")"
                                    'help.SetAllBorders_Thin(xlWorkSheet.Range(xlWorkSheet.Cells(fila, columna), xlWorkSheet.Cells(fila, columna)))
                                    xlWorkSheet.Cells(fila, columna, fila, columna).Style.Numberformat.Format = "#,##0"

                                    If fila = 5 Then
                                        ListaColumnaTotales.Add(columna.ToString())
                                    End If
                                    ListaTotal.Add(columna.ToString())
                                    columna += 1
                                    totalColumnas += 1
                                    inicio = columna

                                    
                                    formulaLocal = String.Empty
                                    'End If
                                Case 1

                                    ListaColumnTotalPorSucursal.Clear()
                                    ListaColumnaTotalPorSubAgrupacion.Clear()
                                    '********************* Transacciones Credito **************


                                    '------------RECORRE ZONA-------------------
                                    For indexZona = 0 To _lstZona.Count - 1
                                        Dim local_i As Integer = indexZona
                                        Dim lstSucursal As List(Of Sucursal) = _lstSucursal.FindAll(Function(x) x.IdZona = _lstZona.Item(local_i).IdZona)
                                        '--------RECORRE SUCURSAL----------------------
                                        For indexSucursal = 0 To lstSucursal.Count - 1
                                            Dim codigoSucursal As String = lstSucursal(indexSucursal).IdSucursal
                                            Dim codigoTienda As Integer = codigoSucursal
                                            Dim valor As Decimal = 0

                                            valor = (New ReporteBusinessLogic()).SelReporteTranssaccionPorsucursalCredito(dia, codigoTienda)
                                            
                                            ListaColumnTotalPorSucursal.Add(columna.ToString())
                                            xlWorkSheet.Cells(fila, columna).Value = valor
                                            columna += 1
                                            totalColumnas += 1


                                        Next

                                        

                                        For za = 0 To ListaColumnTotalPorSucursal.Count - 1
                                            If za = ListaColumnTotalPorSucursal.Count - 1 Then
                                                formulaLocal &= help.ColName(TryCast(ListaColumnTotalPorSucursal.Item(za), String)) & fila.ToString()
                                            Else
                                                formulaLocal &= help.ColName(TryCast(ListaColumnTotalPorSucursal.Item(za), String)) & fila.ToString() & "+"
                                            End If
                                        Next
                                        xlWorkSheet.Cells(fila, columna, fila, columna).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                                        xlWorkSheet.Cells(fila, columna, fila, columna).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 153))
                                        xlWorkSheet.Cells(fila, columna, fila, columna).Formula = "=SUM(" & formulaLocal & ")"
                                        'help.SetAllBorders_Thin(xlWorkSheet.Range(xlWorkSheet.Cells(fila, columna), xlWorkSheet.Cells(fila, columna)))
                                        xlWorkSheet.Cells(fila, columna, fila, columna).Style.Numberformat.Format = "#,##0"

                                        ListaColumnaTotalPorSubAgrupacion.Add(columna.ToString())

                                        If fila = 5 Then
                                            ListaColumnaTotales.Add(columna.ToString())
                                        End If
                                        columna += 1
                                        totalColumnas += 1
                                        inicio = columna
                                        'End If

                                        formulaLocal = String.Empty

                                        ListaColumnTotalPorSucursal.Clear()
                                    Next

                                    columna += 1


                                    For za = 0 To ListaColumnaTotalPorSubAgrupacion.Count - 1
                                        If za = ListaColumnaTotalPorSubAgrupacion.Count - 1 Then
                                            formulaLocal &= help.ColName(TryCast(ListaColumnaTotalPorSubAgrupacion.Item(za), String)) & fila.ToString()
                                        Else
                                            formulaLocal &= help.ColName(TryCast(ListaColumnaTotalPorSubAgrupacion.Item(za), String)) & fila.ToString() & "+"
                                        End If
                                    Next

                                    xlWorkSheet.Cells(fila, columna, fila, columna).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                                    xlWorkSheet.Cells(fila, columna, fila, columna).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 153))
                                    xlWorkSheet.Cells(fila, columna, fila, columna).Formula = "=SUM(" & formulaLocal & ")"
                                    'help.SetAllBorders_Thin(xlWorkSheet.Range(xlWorkSheet.Cells(fila, columna), xlWorkSheet.Cells(fila, columna)))
                                    xlWorkSheet.Cells(fila, columna, fila, columna).Style.Numberformat.Format = "#,##0"

                                    If fila = 5 Then
                                        ListaColumnaTotales.Add(columna.ToString())
                                    End If
                                    ListaTotal.Add(columna.ToString())
                                    columna += 1
                                    totalColumnas += 1
                                    inicio = columna

                                    
                                    formulaLocal = String.Empty


                            End Select



                            ListaColumnTotalPorSucursal.Clear()
                        Next
                        For za = 0 To ListaTotal.Count - 1
                            If za = ListaTotal.Count - 1 Then
                                formulaLocal &= help.ColName(TryCast(ListaTotal.Item(za), String)) & fila.ToString()
                            Else
                                formulaLocal &= help.ColName(TryCast(ListaTotal.Item(za), String)) & fila.ToString() & "+"
                            End If
                        Next

                        xlWorkSheet.Cells(fila, columna, fila, columna).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                        xlWorkSheet.Cells(fila, columna, fila, columna).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 153))
                        xlWorkSheet.Cells(fila, columna, fila, columna).Formula = "=SUM(" & formulaLocal & ")"
                        'help.SetAllBorders_Thin(xlWorkSheet.Range(xlWorkSheet.Cells(fila, columna), xlWorkSheet.Cells(fila, columna)))
                        xlWorkSheet.Cells(fila, columna, fila, columna).Style.Numberformat.Format = "#,##"

                        If fila = 5 Then
                            ListaColumnaTotales.Add(columna.ToString())
                        End If
                        ListaTotal.Add(columna.ToString())
                        columna += 1
                        totalColumnas += 1
                        inicio = columna
                        TotalTransac = columna

                        If Not (indexAgrupacion = _Agrupacion.Length - 1 And indexSubagrupacion = _SubAgrupacion.Length - 1) Then
                            xlWorkSheet.Cells(fila, columna).Value = diaNatural
                            If fila = 5 Then
                                ListaColumnaDiaNatural.Add(columna.ToString())
                            End If
                        End If

                        columna += 1
                        totalColumnas += 1
                        inicio = columna
                        formulaLocal = String.Empty
                        ListaColumnaTotalPorSubAgrupacion.Clear()
                        ListaTotal.Clear()
                    Case 3


                        '-------------RECORRE SUBAGRUPACION--------------------
                        For indexSubagrupacion = 0 To _SubAgrupacion.Length - 1

                            Select Case indexSubagrupacion
                                Case 0

                                    '------------RECORRE ZONA-------------------
                                    For indexZona = 0 To _lstZona.Count - 1
                                        Dim local_i As Integer = indexZona
                                        Dim lstSucursal As List(Of Sucursal) = _lstSucursal.FindAll(Function(x) x.IdZona = _lstZona.Item(local_i).IdZona)
                                        '--------RECORRE SUCURSAL----------------------
                                        For indexSucursal = 0 To lstSucursal.Count - 1
                                            Dim codigoSucursal As String = lstSucursal(indexSucursal).IdSucursal
                                            Dim codigoTienda As Integer = codigoSucursal
                                            Dim valor As Decimal = 0
                                            ListaSucursalTicket.Add(colValor.ToString)
                                            ListaSucursalTicket.Add(TMTotal.ToString)
                                            For index = 0 To ListaSucursalTicket.Count - 1
                                                If index = ListaSucursalTicket.Count - 1 Then
                                                    colTotal &= help.ColName(TryCast(ListaSucursalTicket.Item(index), String)) & fila.ToString()
                                                Else
                                                    colTotal &= help.ColName(TryCast(ListaSucursalTicket.Item(index), String)) & fila.ToString() & "<=0,0," & help.ColName(TryCast(ListaSucursalTicket.Item(index), String)) & fila.ToString() & "/"
                                                End If

                                            Next
                                            xlWorkSheet.Cells(fila, columna).Formula = "=IF(" & colTotal & ")"
                                            'valor = (New ReporteBusinessLogic()).SelReporteTicketPorSucursal(dia, codigoSucursal)


                                            ListaColumnTotalPorSucursal.Add(columna.ToString())
                                            xlWorkSheet.Cells(fila, columna, fila, columna).Style.Numberformat.Format = "#,##0"
                                            'xlWorkSheet.Cells(fila, columna).Value = valor

                                            colValor += 1
                                            TMTotal += 1
                                            columna += 1
                                            totalColumnas += 1

                                            ListaSucursalTicket.Clear()
                                            colTotal = String.Empty

                                        Next

                                        If indexSubagrupacion = _SubAgrupacion.Length - 1 And indexZona = _lstZona.Count - 1 Then
                                            columna += 1
                                            totalColumnas += 1
                                            inicio = columna
                                        End If

                                        Dim valorZonas As Decimal = 0

                                        ListaSucursalTicket.Add(colValor.ToString)
                                        ListaSucursalTicket.Add(TMTotal.ToString)
                                        For index = 0 To ListaSucursalTicket.Count - 1
                                            If index = ListaSucursalTicket.Count - 1 Then
                                                colTotal &= help.ColName(TryCast(ListaSucursalTicket.Item(index), String)) & fila.ToString()
                                            Else
                                                colTotal &= help.ColName(TryCast(ListaSucursalTicket.Item(index), String)) & fila.ToString() & "<=0,0," & help.ColName(TryCast(ListaSucursalTicket.Item(index), String)) & fila.ToString() & "/"
                                            End If

                                        Next
                                        'valorZonas = (New ReporteBusinessLogic()).SelReporteTicketPorZonaContado(dia, (lstSucursal(indexZona)).IdZona.ToString())

                                        xlWorkSheet.Cells(fila, columna, fila, columna).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                                        xlWorkSheet.Cells(fila, columna, fila, columna).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 153))
                                        'xlWorkSheet.Cells(fila, columna, fila, columna).Formula = valorZonas
                                        xlWorkSheet.Cells(fila, columna, fila, columna).Formula = "=IF(" & colTotal & ")"
                                        xlWorkSheet.Cells(fila, columna, fila, columna).Style.Numberformat.Format = "#,##0"

                                        ListaColumnaTotalPorSubAgrupacion.Add(columna.ToString())

                                        If fila = 5 Then
                                            ListaColumnaTotales.Add(columna.ToString())
                                        End If
                                        columna += 1
                                        totalColumnas += 1
                                        inicio = columna
                                        colValor += 1
                                        TMTotal += 1
                                        ListaSucursalTicket.Clear()
                                        colTotal = String.Empty
                                        formulaLocal = String.Empty

                                    Next

                                    Dim totaZona As Decimal = 0
                                    ListaSucursalTicket.Add(colValor.ToString)
                                    ListaSucursalTicket.Add(TMTotal.ToString)
                                    For index = 0 To ListaSucursalTicket.Count - 1
                                        If index = ListaSucursalTicket.Count - 1 Then
                                            colTotal &= help.ColName(TryCast(ListaSucursalTicket.Item(index), String)) & fila.ToString()
                                        Else
                                            colTotal &= help.ColName(TryCast(ListaSucursalTicket.Item(index), String)) & fila.ToString() & "<=0,0," & help.ColName(TryCast(ListaSucursalTicket.Item(index), String)) & fila.ToString() & "/"
                                        End If

                                    Next
                                    'totaZona = (New ReporteBusinessLogic()).SelReporteTicketPorTotalContado(dia)
                                    'Next
                                    xlWorkSheet.Cells(fila, columna, fila, columna).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                                    xlWorkSheet.Cells(fila, columna, fila, columna).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 153))
                                    'xlWorkSheet.Cells(fila, columna, fila, columna).Formula = totaZona
                                    xlWorkSheet.Cells(fila, columna, fila, columna).Formula = "=IF(" & colTotal & ")"
                                    xlWorkSheet.Cells(fila, columna, fila, columna).Style.Numberformat.Format = "#,##0"

                                    ListaColumnaTotalPorSubAgrupacion.Add(columna.ToString())

                                    If fila = 5 Then
                                        ListaColumnaTotales.Add(columna.ToString())
                                    End If
                                    colValor += 1
                                    TMTotal += 1
                                    columna += 1
                                    totalColumnas += 1
                                    inicio = columna


                                    ListaSucursalTicket.Clear()
                                    colTotal = String.Empty
                                    formulaLocal = String.Empty

                                Case 1

                                    ListaColumnTotalPorSucursal.Clear()
                                    ListaColumnaTotalPorSubAgrupacion.Clear()
                                    '********************* Transacciones Credito **************


                                    '------------RECORRE ZONA-------------------
                                    For indexZona = 0 To _lstZona.Count - 1
                                        Dim local_i As Integer = indexZona
                                        Dim lstSucursal As List(Of Sucursal) = _lstSucursal.FindAll(Function(x) x.IdZona = _lstZona.Item(local_i).IdZona)
                                        '--------RECORRE SUCURSAL----------------------
                                        For indexSucursal = 0 To lstSucursal.Count - 1
                                            Dim codigoSucursal As String = lstSucursal(indexSucursal).IdSucursal
                                            Dim codigoTienda As Integer = codigoSucursal
                                            Dim valor As Decimal = 0
                                            ListaSucursalTicket.Add(colValor.ToString)
                                            ListaSucursalTicket.Add(TMTotal.ToString)
                                            For index = 0 To ListaSucursalTicket.Count - 1
                                                If index = ListaSucursalTicket.Count - 1 Then
                                                    colTotal &= help.ColName(TryCast(ListaSucursalTicket.Item(index), String)) & fila.ToString()
                                                Else
                                                    colTotal &= help.ColName(TryCast(ListaSucursalTicket.Item(index), String)) & fila.ToString() & "<=0,0," & help.ColName(TryCast(ListaSucursalTicket.Item(index), String)) & fila.ToString() & "/"
                                                End If

                                            Next
                                            'valor = (New ReporteBusinessLogic()).SelReporteTicketPorSucursalCredito(dia, codigoTienda)

                                            ListaColumnTotalPorSucursal.Add(columna.ToString())
                                            xlWorkSheet.Cells(fila, columna, fila, columna).Style.Numberformat.Format = "#,##0"
                                            'xlWorkSheet.Cells(fila, columna).Value = valor
                                            xlWorkSheet.Cells(fila, columna).Formula = "=IF(" & colTotal & ")"
                                            columna += 1
                                            totalColumnas += 1
                                            colValor += 1
                                            TMTotal += 1
                                            ListaSucursalTicket.Clear()
                                            colTotal = String.Empty
                                            formulaLocal = String.Empty
                                        Next
                                        'If indexSubagrupacion = _SubAgrupacion.Length - 1 And indexZona = _lstZona.Count - 1 Then
                                        '    columna += 1
                                        '    totalColumnas += 1
                                        '    inicio = columna
                                        'End If

                                        Dim valoresZonas As Decimal = 0
                                        ListaSucursalTicket.Add(colValor.ToString)
                                        ListaSucursalTicket.Add(TMTotal.ToString)
                                        For index = 0 To ListaSucursalTicket.Count - 1
                                            If index = ListaSucursalTicket.Count - 1 Then
                                                colTotal &= help.ColName(TryCast(ListaSucursalTicket.Item(index), String)) & fila.ToString()
                                            Else
                                                colTotal &= help.ColName(TryCast(ListaSucursalTicket.Item(index), String)) & fila.ToString() & "<=0,0," & help.ColName(TryCast(ListaSucursalTicket.Item(index), String)) & fila.ToString() & "/"
                                            End If

                                        Next
                                        'valoresZonas = (New ReporteBusinessLogic()).SelReporteTicketPorZonaCredito(dia, (lstSucursal(indexZona)).IdZona.ToString())

                                        xlWorkSheet.Cells(fila, columna, fila, columna).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                                        xlWorkSheet.Cells(fila, columna, fila, columna).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 153))
                                        'xlWorkSheet.Cells(fila, columna, fila, columna).Formula = valoresZonas
                                        xlWorkSheet.Cells(fila, columna, fila, columna).Formula = "=IF(" & colTotal & ")"
                                        xlWorkSheet.Cells(fila, columna, fila, columna).Style.Numberformat.Format = "#,##0"

                                        ListaColumnaTotalPorSubAgrupacion.Add(columna.ToString())

                                        If fila = 5 Then
                                            ListaColumnaTotales.Add(columna.ToString())
                                        End If
                                        columna += 1
                                        totalColumnas += 1
                                        inicio = columna
                                        colValor += 1
                                        TMTotal += 1
                                        ListaSucursalTicket.Clear()
                                        colTotal = String.Empty
                                        formulaLocal = String.Empty


                                    Next

                                    xlWorkSheet.Cells(fila, columna, fila, columna).Value = 0
                                    columna += 1
                                    colValor += 1
                                    TMTotal += 1
                                    Dim valorZonas As Decimal = 0
                                    ListaSucursalTicket.Add(colValor.ToString)
                                    ListaSucursalTicket.Add(TMTotal.ToString)
                                    For index = 0 To ListaSucursalTicket.Count - 1
                                        If index = ListaSucursalTicket.Count - 1 Then
                                            colTotal &= help.ColName(TryCast(ListaSucursalTicket.Item(index), String)) & fila.ToString()
                                        Else
                                            colTotal &= help.ColName(TryCast(ListaSucursalTicket.Item(index), String)) & fila.ToString() & "<=0,0," & help.ColName(TryCast(ListaSucursalTicket.Item(index), String)) & fila.ToString() & "/"
                                        End If

                                    Next
                                    'valorZonas = (New ReporteBusinessLogic()).SelReporteTicketPorTotalCredito(dia)
                                    'Next
                                    xlWorkSheet.Cells(fila, columna, fila, columna).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                                    xlWorkSheet.Cells(fila, columna, fila, columna).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 153))
                                    'xlWorkSheet.Cells(fila, columna, fila, columna).Formula = valorZonas
                                    xlWorkSheet.Cells(fila, columna, fila, columna).Formula = "=IF(" & colTotal & ")"
                                    xlWorkSheet.Cells(fila, columna, fila, columna).Style.Numberformat.Format = "#,##0"
                                    xlWorkSheet.Cells(fila, columna, fila, columna).Style.Font.Size = 9
                                    ListaColumnaTotalPorSubAgrupacion.Add(columna.ToString())

                                    If fila = 5 Then
                                        ListaColumnaTotales.Add(columna.ToString())
                                    End If

                                    columna += 1
                                    totalColumnas += 1
                                    inicio = columna
                                    colValor += 1
                                    TMTotal += 1
                                    ListaSucursalTicket.Clear()
                                    colTotal = String.Empty
                                    formulaLocal = String.Empty
                            End Select



                            ListaColumnTotalPorSucursal.Clear()
                        Next


                        Dim valorZona As Decimal = 0
                        'columna += 1
                        'colValor += 1
                        'TMTotal += 1
                        'valorZona = (New ReporteBusinessLogic()).SelReporteTicketPorTotal(dia)
                        ListaSucursalTicket.Add(colValor.ToString)
                        ListaSucursalTicket.Add(TMTotal.ToString)
                        For index = 0 To ListaSucursalTicket.Count - 1
                            If index = ListaSucursalTicket.Count - 1 Then
                                colTotal &= help.ColName(TryCast(ListaSucursalTicket.Item(index), String)) & fila.ToString()
                            Else
                                colTotal &= help.ColName(TryCast(ListaSucursalTicket.Item(index), String)) & fila.ToString() & "<=0,0," & help.ColName(TryCast(ListaSucursalTicket.Item(index), String)) & fila.ToString() & "/"
                            End If

                        Next
                        xlWorkSheet.Cells(fila, columna, fila, columna).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                        xlWorkSheet.Cells(fila, columna, fila, columna).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 153))
                        'xlWorkSheet.Cells(fila, columna, fila, columna).Formula = valorZona
                        xlWorkSheet.Cells(fila, columna, fila, columna).Formula = "=IF(" & colTotal & ")"
                        xlWorkSheet.Cells(fila, columna, fila, columna).Style.Numberformat.Format = "#,##0"
                        xlWorkSheet.Cells(fila, columna, fila, columna).Style.Font.Size = 9
                        ListaColumnaTotalPorSubAgrupacion.Add(columna.ToString())

                        If fila = 5 Then
                            ListaColumnaTotales.Add(columna.ToString())
                        End If
                        TotalTicket = columna
                        columna += 1
                        totalColumnas += 1
                        inicio = columna
                        colValor += 1
                        TMTotal += 1
                        ListaColumnaTotalPorSubAgrupacion.Clear()
                        ListaSucursalTicket.Clear()
                        colTotal = String.Empty
                        formulaLocal = String.Empty
                End Select

                formulaLocal = String.Empty
            Next
            fila += 1
        Next



        If (totalColumnas > 0) Then
            xlWorkSheet.Cells(5, 1, fila, totalColumnas).Style.Font.Name = "Calibri"
            xlWorkSheet.Cells(5, 1, fila, totalColumnas).Style.Font.Size = 9
        Else
            xlWorkSheet.Cells(5, 1, fila, 1).Style.Font.Name = "Calibri"
            xlWorkSheet.Cells(5, 1, fila, 1).Style.Font.Size = 9
        End If
        xlWorkSheet.Cells(fila, 1, fila, 1).Style.Font.Bold = True
        xlWorkSheet.Cells(fila, 1, fila, 1).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
        xlWorkSheet.Cells(fila, 1, fila, 1).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(221, 235, 247))
        xlWorkSheet.Cells(fila, 1, fila, 1).Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Center
        xlWorkSheet.Cells(fila, 1, fila, 1).Style.VerticalAlignment = Style.ExcelVerticalAlignment.Bottom
        xlWorkSheet.Cells(fila, 1).Value = "Total general"

        Dim icol As Integer
        icol = 0


   

        For icol = 1 To totalColumnas - 1

            If icol < TotalVenta Then
                xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Font.Bold = True
                xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(221, 235, 247))

                xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Formula = "=SUM(" & help.ColName(icol + 1) & "5:" & help.ColName(icol + 1) & (fila - 1).ToString() & ")"
                xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Numberformat.Format = "#,##0"


                If ListaColumnaDiaNatural.IndexOf((icol + 1).ToString()) <> -1 Then
                    xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Font.Bold = True
                    xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Left
                    xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.VerticalAlignment = Style.ExcelVerticalAlignment.Bottom
                    xlWorkSheet.Cells(fila, icol + 1).Value = "Total general"

                Else
                    If ListaColumnaTotales.IndexOf((icol + 1).ToString()) <> -1 Then
                        xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                        xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 153))
                        'help.SetAllBorders_Thin(xlWorkSheet.Range(xlWorkSheet.Cells(fila, icol + 1), xlWorkSheet.Cells(fila, icol + 1)))
                    End If
                End If
                xlWorkSheet.Column(icol + 1).AutoFit()

                pcol = icol.ToString()
            Else
                If icol < TotalMargen Then

                    For indexSubagrupacion = 0 To _SubAgrupacion.Length - 1
                        If indexSubagrupacion = 0 Then

                            '******************** Totales Contados ************************

                            For indexZona = 0 To _lstZona.Count - 1
                                Dim local_i As Integer = indexZona
                                Dim lstSucursal As List(Of Sucursal) = _lstSucursal.FindAll(Function(x) x.IdZona = _lstZona.Item(local_i).IdZona)

                                For indexSucursal = 0 To lstSucursal.Count - 1
                                    Dim codigoSucursal As String = lstSucursal(indexSucursal).IdSucursal
                                    Dim codigoTienda As Integer = codigoSucursal
                                    'icol += 1
                                    xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Font.Bold = True
                                    xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                                    xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(221, 235, 247))

                                    'xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Value = (New ReporteBusinessLogic()).SelMargenTotalContado(_FechaIniRep, _FechaFinRep)
                                    xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Value = (New ReporteBusinessLogic()).SelMargenNetoContadoPorTienda(_FechaIniRep, _FechaFinRep, (lstSucursal(indexSucursal)).IdSucursal)
                                    xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Numberformat.Format = "0.00%"


                                    If ListaColumnaDiaNatural.IndexOf((icol + 1).ToString()) <> -1 Then
                                        xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Font.Bold = True
                                        xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Left
                                        xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.VerticalAlignment = Style.ExcelVerticalAlignment.Bottom
                                        xlWorkSheet.Cells(fila, icol + 1).Value = "Total general"
                                    Else
                                        If ListaColumnaTotales.IndexOf((icol + 1).ToString()) <> -1 Then
                                            xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                                            xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 153))
                                            'help.SetAllBorders_Thin(xlWorkSheet.Range(xlWorkSheet.Cells(fila, icol + 1), xlWorkSheet.Cells(fila, icol + 1)))
                                        End If
                                    End If
                                    xlWorkSheet.Column(icol + 1).AutoFit()
                                    icol += 1
                                Next

                                xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Font.Bold = True
                                xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                                xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(221, 235, 247))
                                xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Value = (New ReporteBusinessLogic()).SelMargenNetoContadoPorZona(_FechaIniRep, _FechaFinRep, (lstSucursal(indexZona)).IdZona)
                                xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Numberformat.Format = "0.00%"


                                If ListaColumnaDiaNatural.IndexOf((icol + 1).ToString()) <> -1 Then
                                    xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Font.Bold = True
                                    xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Left
                                    xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.VerticalAlignment = Style.ExcelVerticalAlignment.Bottom
                                    xlWorkSheet.Cells(fila, icol + 1).Value = "Total general"
                                Else
                                    If ListaColumnaTotales.IndexOf((icol + 1).ToString()) <> -1 Then
                                        xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                                        xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 153))
                                        'help.SetAllBorders_Thin(xlWorkSheet.Range(xlWorkSheet.Cells(fila, icol + 1), xlWorkSheet.Cells(fila, icol + 1)))
                                    End If
                                End If
                                xlWorkSheet.Column(icol + 1).AutoFit()
                                icol += 1
                            Next

                            xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Font.Bold = True
                            xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                            xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(221, 235, 247))
                            xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Value = (New ReporteBusinessLogic()).SelMargenTotalContado(_FechaIniRep, _FechaFinRep)
                            xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Numberformat.Format = "0.00%"
                            If ListaColumnaDiaNatural.IndexOf((icol + 1).ToString()) <> -1 Then
                                xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Font.Bold = True
                                xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Left
                                xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.VerticalAlignment = Style.ExcelVerticalAlignment.Bottom
                                xlWorkSheet.Cells(fila, icol + 1).Value = "Total general"
                            Else
                                If ListaColumnaTotales.IndexOf((icol + 1).ToString()) <> -1 Then
                                    xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                                    xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 153))
                                    'help.SetAllBorders_Thin(xlWorkSheet.Range(xlWorkSheet.Cells(fila, icol + 1), xlWorkSheet.Cells(fila, icol + 1)))
                                End If
                            End If
                            xlWorkSheet.Column(icol + 1).AutoFit()
                            icol += 1


                        Else

                            '******************** Totales Creditos *******************




                            For indexZona = 0 To _lstZona.Count - 1
                                Dim local_i As Integer = indexZona
                                Dim lstSucursal As List(Of Sucursal) = _lstSucursal.FindAll(Function(x) x.IdZona = _lstZona.Item(local_i).IdZona)

                                For indexSucursal = 0 To lstSucursal.Count - 1
                                    Dim codigoSucursal As String = lstSucursal(indexSucursal).IdSucursal
                                    Dim codigoTienda As Integer = codigoSucursal
                                    ' icol += 1
                                    xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Font.Bold = True
                                    xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                                    xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(221, 235, 247))

                                    'xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Value = (New ReporteBusinessLogic()).SelMargenTotalContado(_FechaIniRep, _FechaFinRep)
                                    xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Value = (New ReporteBusinessLogic()).SelMargenNetoCreditoPorTienda(_FechaIniRep, _FechaFinRep, (lstSucursal(indexSucursal)).IdSucursal)
                                    xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Numberformat.Format = "0.00%"


                                    If ListaColumnaDiaNatural.IndexOf((icol + 1).ToString()) <> -1 Then
                                        xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Font.Bold = True
                                        xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Left
                                        xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.VerticalAlignment = Style.ExcelVerticalAlignment.Bottom
                                        xlWorkSheet.Cells(fila, icol + 1).Value = "Total general"
                                    Else
                                        If ListaColumnaTotales.IndexOf((icol + 1).ToString()) <> -1 Then
                                            xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                                            xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 153))
                                            'help.SetAllBorders_Thin(xlWorkSheet.Range(xlWorkSheet.Cells(fila, icol + 1), xlWorkSheet.Cells(fila, icol + 1)))
                                        End If
                                    End If
                                    xlWorkSheet.Column(icol + 1).AutoFit()
                                    icol += 1
                                Next

                                xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Font.Bold = True
                                xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                                xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(221, 235, 247))
                                xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Value = (New ReporteBusinessLogic()).SelMargenNetoCreditoPorZona(_FechaIniRep, _FechaFinRep, (lstSucursal(indexZona)).IdZona)
                                xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Numberformat.Format = "0.00%"


                                If ListaColumnaDiaNatural.IndexOf((icol + 1).ToString()) <> -1 Then
                                    xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Font.Bold = True
                                    xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Left
                                    xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.VerticalAlignment = Style.ExcelVerticalAlignment.Bottom
                                    xlWorkSheet.Cells(fila, icol + 1).Value = "Total general"
                                Else
                                    If ListaColumnaTotales.IndexOf((icol + 1).ToString()) <> -1 Then
                                        xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                                        xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 153))
                                        'help.SetAllBorders_Thin(xlWorkSheet.Range(xlWorkSheet.Cells(fila, icol + 1), xlWorkSheet.Cells(fila, icol + 1)))
                                    End If
                                End If
                                xlWorkSheet.Column(icol + 1).AutoFit()
                                icol += 1
                            Next
                            xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Font.Bold = True
                            xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                            xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(221, 235, 247))
                            xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Value = 0
                            xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Numberformat.Format = "0.00%"
                            icol += 1
                            xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Font.Bold = True
                            xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                            xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(221, 235, 247))
                            xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Value = (New ReporteBusinessLogic()).SelMargenTotalCredito(_FechaIniRep, _FechaFinRep)
                            xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Numberformat.Format = "0.00%"
                            If ListaColumnaDiaNatural.IndexOf((icol + 1).ToString()) <> -1 Then
                                xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Font.Bold = True
                                xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Left
                                xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.VerticalAlignment = Style.ExcelVerticalAlignment.Bottom
                                xlWorkSheet.Cells(fila, icol + 1).Value = "Total general"
                            Else
                                If ListaColumnaTotales.IndexOf((icol + 1).ToString()) <> -1 Then
                                    xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                                    xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 153))
                                    'help.SetAllBorders_Thin(xlWorkSheet.Range(xlWorkSheet.Cells(fila, icol + 1), xlWorkSheet.Cells(fila, icol + 1)))
                                End If
                            End If
                            xlWorkSheet.Column(icol + 1).AutoFit()
                            icol += 1

                        End If
                    Next



                    xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Font.Bold = True
                    xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                    xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(221, 235, 247))
                    xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Value = (New ReporteBusinessLogic()).SelMargenNetoTotal(_FechaIniRep, _FechaFinRep)
                    xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Numberformat.Format = "0.00%"
                    If ListaColumnaDiaNatural.IndexOf((icol + 1).ToString()) <> -1 Then
                        xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Font.Bold = True
                        xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Left
                        xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.VerticalAlignment = Style.ExcelVerticalAlignment.Bottom
                        xlWorkSheet.Cells(fila, icol + 1).Value = "Total general"
                    Else
                        If ListaColumnaTotales.IndexOf((icol + 1).ToString()) <> -1 Then
                            xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                            xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 153))
                            'help.SetAllBorders_Thin(xlWorkSheet.Range(xlWorkSheet.Cells(fila, icol + 1), xlWorkSheet.Cells(fila, icol + 1)))
                        End If
                    End If
                    xlWorkSheet.Column(icol + 1).AutoFit()
                    icol += 1
                    formulaPrueba = icol
                    formulaPrueba += 2
                Else

                    If icol < TotalTransac Then

                        xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Font.Bold = True
                        xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                        xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(221, 235, 247))

                        xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Formula = "=SUM(" & help.ColName(icol + 1) & "5:" & help.ColName(icol + 1) & (fila - 1).ToString() & ")"
                        xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Numberformat.Format = "#,##0"


                        If ListaColumnaDiaNatural.IndexOf((icol + 1).ToString()) <> -1 Then
                            xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Font.Bold = True
                            xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Left
                            xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.VerticalAlignment = Style.ExcelVerticalAlignment.Bottom
                            xlWorkSheet.Cells(fila, icol + 1).Value = "Total general"
                        Else
                            If ListaColumnaTotales.IndexOf((icol + 1).ToString()) <> -1 Then
                                xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                                xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 153))
                                'help.SetAllBorders_Thin(xlWorkSheet.Range(xlWorkSheet.Cells(fila, icol + 1), xlWorkSheet.Cells(fila, icol + 1)))
                            End If
                        End If
                        Trans = icol.ToString()
                        xlWorkSheet.Column(icol + 1).AutoFit()

                    Else

                        If icol < TotalTicket Then

                            For indexSubagrupacion = 0 To _SubAgrupacion.Length - 1
                                If indexSubagrupacion = 0 Then
                                    For indexZona = 0 To _lstZona.Count - 1
                                        Dim local_i As Integer = indexZona
                                        Dim lstSucursal As List(Of Sucursal) = _lstSucursal.FindAll(Function(x) x.IdZona = _lstZona.Item(local_i).IdZona)

                                        For indexSucursal = 0 To lstSucursal.Count - 1
                                            Dim codigoSucursal As String = lstSucursal(indexSucursal).IdSucursal
                                            Dim codigoTienda As Integer = codigoSucursal

                                            ListaSucursalTicket.Add(TotalCredito.ToString)
                                            ListaSucursalTicket.Add(formulaPrueba.ToString)
                                            For index = 0 To ListaSucursalTicket.Count - 1
                                                If index = ListaSucursalTicket.Count - 1 Then
                                                    colTotal &= help.ColName(TryCast(ListaSucursalTicket.Item(index), String)) & fila.ToString()
                                                Else
                                                    colTotal &= help.ColName(TryCast(ListaSucursalTicket.Item(index), String)) & fila.ToString() & "<=0,0," & help.ColName(TryCast(ListaSucursalTicket.Item(index), String)) & fila.ToString() & "/"
                                                End If

                                            Next

                                            ' icol += 1
                                            xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Font.Bold = True
                                            xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                                            xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(221, 235, 247))

                                            'xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Value = (New ReporteBusinessLogic()).SelReporteTotalTicketSucursalContado(_FechaIniRep, _FechaFinRep, codigoTienda)
                                            xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Formula = "=IF(" & colTotal & ")"
                                            xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Numberformat.Format = "#,##0"


                                            If ListaColumnaDiaNatural.IndexOf((icol + 1).ToString()) <> -1 Then
                                                xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Font.Bold = True
                                                xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Left
                                                xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.VerticalAlignment = Style.ExcelVerticalAlignment.Bottom
                                                xlWorkSheet.Cells(fila, icol + 1).Value = "Total general"
                                            Else
                                                If ListaColumnaTotales.IndexOf((icol + 1).ToString()) <> -1 Then
                                                    xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                                                    xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 153))
                                                    'help.SetAllBorders_Thin(xlWorkSheet.Range(xlWorkSheet.Cells(fila, icol + 1), xlWorkSheet.Cells(fila, icol + 1)))
                                                End If
                                            End If
                                            xlWorkSheet.Column(icol + 1).AutoFit()
                                            icol += 1
                                            TotalCredito += 1
                                            formulaPrueba += 1
                                            ListaSucursalTicket.Clear()
                                            colTotal = String.Empty
                                        Next

                                        ListaSucursalTicket.Add(TotalCredito.ToString)
                                        ListaSucursalTicket.Add(formulaPrueba.ToString)
                                        For index = 0 To ListaSucursalTicket.Count - 1
                                            If index = ListaSucursalTicket.Count - 1 Then
                                                colTotal &= help.ColName(TryCast(ListaSucursalTicket.Item(index), String)) & fila.ToString()
                                            Else
                                                colTotal &= help.ColName(TryCast(ListaSucursalTicket.Item(index), String)) & fila.ToString() & "<=0,0," & help.ColName(TryCast(ListaSucursalTicket.Item(index), String)) & fila.ToString() & "/"
                                            End If

                                        Next
                                        xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Font.Bold = True
                                        xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                                        xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(221, 235, 247))
                                        'xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Value = (New ReporteBusinessLogic()).SelReporteTotalTicketZonaContado(_FechaIniRep, _FechaFinRep, (lstSucursal(indexZona)).IdZona)
                                        xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Formula = "=IF(" & colTotal & ")"
                                        xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Numberformat.Format = "#,##0"


                                        If ListaColumnaDiaNatural.IndexOf((icol + 1).ToString()) <> -1 Then
                                            xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Font.Bold = True
                                            xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Left
                                            xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.VerticalAlignment = Style.ExcelVerticalAlignment.Bottom
                                            xlWorkSheet.Cells(fila, icol + 1).Value = "Total general"
                                        Else
                                            If ListaColumnaTotales.IndexOf((icol + 1).ToString()) <> -1 Then
                                                xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                                                xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 153))
                                                'help.SetAllBorders_Thin(xlWorkSheet.Range(xlWorkSheet.Cells(fila, icol + 1), xlWorkSheet.Cells(fila, icol + 1)))
                                            End If
                                        End If
                                        xlWorkSheet.Column(icol + 1).AutoFit()
                                        icol += 1
                                        TotalCredito += 1
                                        formulaPrueba += 1
                                        ListaSucursalTicket.Clear()
                                        colTotal = String.Empty

                                    Next
                                    ListaSucursalTicket.Add(TotalCredito.ToString)
                                    ListaSucursalTicket.Add(formulaPrueba.ToString)
                                    For index = 0 To ListaSucursalTicket.Count - 1
                                        If index = ListaSucursalTicket.Count - 1 Then
                                            colTotal &= help.ColName(TryCast(ListaSucursalTicket.Item(index), String)) & fila.ToString()
                                        Else
                                            colTotal &= help.ColName(TryCast(ListaSucursalTicket.Item(index), String)) & fila.ToString() & "<=0,0," & help.ColName(TryCast(ListaSucursalTicket.Item(index), String)) & fila.ToString() & "/"
                                        End If

                                    Next
                                    xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Font.Bold = True
                                    xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                                    xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 153))
                                    'xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Value = (New ReporteBusinessLogic()).SelReporteTotalContado(_FechaIniRep, _FechaFinRep)
                                    xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Formula = "=IF(" & colTotal & ")"
                                    xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Numberformat.Format = "#,##0"
                                    xlWorkSheet.Column(icol + 1).AutoFit()
                                    icol += 1
                                    TotalCredito += 1
                                    formulaPrueba += 1
                                    ListaSucursalTicket.Clear()
                                    colTotal = String.Empty
                                Else


                                    For indexZona = 0 To _lstZona.Count - 1
                                        Dim local_i As Integer = indexZona
                                        Dim lstSucursal As List(Of Sucursal) = _lstSucursal.FindAll(Function(x) x.IdZona = _lstZona.Item(local_i).IdZona)

                                        For indexSucursal = 0 To lstSucursal.Count - 1
                                            Dim codigoSucursal As String = lstSucursal(indexSucursal).IdSucursal
                                            Dim codigoTienda As Integer = codigoSucursal

                                            ListaSucursalTicket.Add(TotalCredito.ToString)
                                            ListaSucursalTicket.Add(formulaPrueba.ToString)
                                            For index = 0 To ListaSucursalTicket.Count - 1
                                                If index = ListaSucursalTicket.Count - 1 Then
                                                    colTotal &= help.ColName(TryCast(ListaSucursalTicket.Item(index), String)) & fila.ToString()
                                                Else
                                                    colTotal &= help.ColName(TryCast(ListaSucursalTicket.Item(index), String)) & fila.ToString() & "<=0,0," & help.ColName(TryCast(ListaSucursalTicket.Item(index), String)) & fila.ToString() & "/"
                                                End If

                                            Next
                                            ' icol += 1
                                            xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Font.Bold = True
                                            xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                                            xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(221, 235, 247))

                                            'xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Value = (New ReporteBusinessLogic()).SelReporteTotalTicketSucursalCredito(_FechaIniRep, _FechaFinRep, codigoTienda)
                                            xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Formula = "=IF(" & colTotal & ")"

                                            xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Numberformat.Format = "#,##0"


                                            If ListaColumnaDiaNatural.IndexOf((icol + 1).ToString()) <> -1 Then
                                                xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Font.Bold = True
                                                xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Left
                                                xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.VerticalAlignment = Style.ExcelVerticalAlignment.Bottom
                                                xlWorkSheet.Cells(fila, icol + 1).Value = "Total general"
                                            Else
                                                If ListaColumnaTotales.IndexOf((icol + 1).ToString()) <> -1 Then
                                                    xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                                                    xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 153))
                                                    'help.SetAllBorders_Thin(xlWorkSheet.Range(xlWorkSheet.Cells(fila, icol + 1), xlWorkSheet.Cells(fila, icol + 1)))
                                                End If
                                            End If
                                            xlWorkSheet.Column(icol + 1).AutoFit()
                                            icol += 1
                                            TotalCredito += 1
                                            formulaPrueba += 1
                                            ListaSucursalTicket.Clear()
                                            colTotal = String.Empty
                                        Next

                                        ListaSucursalTicket.Add(TotalCredito.ToString)
                                        ListaSucursalTicket.Add(formulaPrueba.ToString)
                                        For index = 0 To ListaSucursalTicket.Count - 1
                                            If index = ListaSucursalTicket.Count - 1 Then
                                                colTotal &= help.ColName(TryCast(ListaSucursalTicket.Item(index), String)) & fila.ToString()
                                            Else
                                                colTotal &= help.ColName(TryCast(ListaSucursalTicket.Item(index), String)) & fila.ToString() & "<=0,0," & help.ColName(TryCast(ListaSucursalTicket.Item(index), String)) & fila.ToString() & "/"
                                            End If

                                        Next
                                        xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Font.Bold = True
                                        xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                                        xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(221, 235, 247))
                                        'xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Value = (New ReporteBusinessLogic()).SelReporteTotalTicketZonaCredito(_FechaIniRep, _FechaFinRep, (lstSucursal(indexZona)).IdZona)
                                        xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Formula = "=IF(" & colTotal & ")"
                                        xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Numberformat.Format = "#,##0"


                                        If ListaColumnaDiaNatural.IndexOf((icol + 1).ToString()) <> -1 Then
                                            xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Font.Bold = True
                                            xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Left
                                            xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.VerticalAlignment = Style.ExcelVerticalAlignment.Bottom
                                            xlWorkSheet.Cells(fila, icol + 1).Value = "Total general"
                                        Else
                                            If ListaColumnaTotales.IndexOf((icol + 1).ToString()) <> -1 Then
                                                xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                                                xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 153))
                                                'help.SetAllBorders_Thin(xlWorkSheet.Range(xlWorkSheet.Cells(fila, icol + 1), xlWorkSheet.Cells(fila, icol + 1)))
                                            End If
                                        End If
                                        xlWorkSheet.Column(icol + 1).AutoFit()
                                        icol += 1
                                        TotalCredito += 1
                                        formulaPrueba += 1
                                        ListaSucursalTicket.Clear()
                                        colTotal = String.Empty

                                    Next
                                    icol += 1
                                    TotalCredito += 1
                                    formulaPrueba += 1
                                    ListaSucursalTicket.Add(TotalCredito.ToString)
                                    ListaSucursalTicket.Add(formulaPrueba.ToString)
                                    For index = 0 To ListaSucursalTicket.Count - 1
                                        If index = ListaSucursalTicket.Count - 1 Then
                                            colTotal &= help.ColName(TryCast(ListaSucursalTicket.Item(index), String)) & fila.ToString()
                                        Else
                                            colTotal &= help.ColName(TryCast(ListaSucursalTicket.Item(index), String)) & fila.ToString() & "<=0,0," & help.ColName(TryCast(ListaSucursalTicket.Item(index), String)) & fila.ToString() & "/"
                                        End If

                                    Next
                                    xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Font.Bold = True
                                    xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                                    xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 153))
                                    'xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Value = (New ReporteBusinessLogic()).SelReporteTotalCredito(_FechaIniRep, _FechaFinRep)
                                    xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Formula = "=IF(" & colTotal & ")"
                                    xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Numberformat.Format = "#,##0"
                                    xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Font.Size = 9
                                    xlWorkSheet.Column(icol + 1).AutoFit()
                                    icol += 1
                                    TotalCredito += 1
                                    formulaPrueba += 1
                                    ListaSucursalTicket.Clear()
                                    colTotal = String.Empty
                                End If
                                '******************** Totales Contados ************************

                            Next

                            Dim FormulaTicket As New ArrayList
                            FormulaTicket.Add(pcol)
                            FormulaTicket.Add(Trans)
                            For index = 0 To FormulaTicket.Count - 1
                                If index = FormulaTicket.Count - 1 Then
                                    formulaLocal &= help.ColName(TryCast(FormulaTicket.Item(index), String)) & fila.ToString()
                                Else
                                    formulaLocal &= help.ColName(TryCast(FormulaTicket.Item(index), String)) & fila.ToString() & "/"

                                End If

                                xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Formula = "=(" & formulaLocal & ")"
                                xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Font.Bold = True
                                xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                                xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 153))
                                xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Font.Size = 9
                                xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Numberformat.Format = "#,##0"
                                xlWorkSheet.Column(icol + 1).AutoFit()
                            Next


                            FormulaTicket.Clear()

                            formulaLocal = String.Empty

                        End If

                    End If
                End If





            End If
           
          
          


        Next








    End Sub
End Class
