Imports OfficeOpenXml
Imports System.Drawing
Imports OfficeOpenXml.Style
Imports Sodimac.VentaEmpresa.DataContracts
Imports Sodimac.VentaEmpresa.BusinessLogic

Public Class detalleXFamilia

    Dim _xlWorkBook As ExcelWorkbook
    Dim _FechaIniRep As Date
    Dim _FechaFinRep As Date
    Dim _lstZona As List(Of Zona)
    Dim _lstSucursal As List(Of Sucursal)
    Dim help As New HelperReporteVAP
    Dim _Agrupacion() As String = {"VENTA", "MARGEN", "TRANSACCIONES", "TICKET PROMEDIO"}

    Sub New(xlWorkBook As ExcelWorkbook, fechaInicio As Date, fechaFin As Date, lstZona As List(Of Zona), lstSucursal As List(Of Sucursal))
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

        Dim xlWorkSheet As ExcelWorksheet
        xlWorkSheet = _xlWorkBook.Worksheets.Item(4) '4: HOJA DETALLADO X FAMILIA
        xlWorkSheet.Select()

        xlWorkSheet.Cells(2, 1).Value = "ZONAS"
        xlWorkSheet.Cells(3, 1).Value = "FAMILIAS"

        Dim columna As Integer = 2, inicio As Integer = 2, zona As Integer = 2

        xlWorkSheet.Cells(1, 1, 2, 1).Style.Fill.PatternType = ExcelFillStyle.Solid
        xlWorkSheet.Cells(1, 1, 2, 1).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(51, 204, 204))
        xlWorkSheet.Cells(2, 1, 2, 1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
        xlWorkSheet.Cells(2, 1, 2, 1).Style.VerticalAlignment = ExcelVerticalAlignment.Center
        xlWorkSheet.Cells(2, 1, 2, 1).Style.Font.Name = "Calibri"
        xlWorkSheet.Cells(2, 1, 2, 1).Style.Font.Size = 9
        xlWorkSheet.Cells(2, 1, 2, 1).Style.Font.Bold = True
        xlWorkSheet.Cells(2, 1, 2, 1).Style.Fill.PatternType = ExcelFillStyle.Solid
        xlWorkSheet.Cells(2, 1, 2, 1).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(51, 204, 204))
        xlWorkSheet.Cells(3, 1, 3, 1).Style.HorizontalAlignment = HorizontalAlign.Center
        xlWorkSheet.Cells(3, 1, 3, 1).Style.VerticalAlignment = ExcelVerticalAlignment.Bottom
        xlWorkSheet.Cells(3, 1, 3, 1).Style.Fill.PatternType = ExcelFillStyle.Solid
        xlWorkSheet.Cells(3, 1, 3, 1).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(221, 235, 247))
        xlWorkSheet.Cells(3, 1, 3, 1).Style.Font.Name = "Calibri"
        xlWorkSheet.Cells(3, 1, 3, 1).Style.Font.Size = 10
        xlWorkSheet.Cells(3, 1, 3, 1).Style.Font.Bold = True

        For index = 0 To _Agrupacion.Length - 1
            zona = inicio
            For i = 0 To _lstZona.Count - 1
                Dim local_i As Integer = i
                Dim lstSucursal As List(Of Sucursal) = _lstSucursal.FindAll(Function(x) x.IdZona = _lstZona.Item(local_i).IdZona)
                For j = 0 To lstSucursal.Count - 1
                    xlWorkSheet.Cells(3, columna).Value = (lstSucursal(j)).Descripcion
                    columna = columna + 1
                Next
                columna = columna - 1
                xlWorkSheet.Cells(2, zona, 2, columna).Merge = True
                xlWorkSheet.Cells(2, zona).Value = (_lstZona(i)).NombreZona
                zona = columna + 1
                columna = columna + 1
            Next

            xlWorkSheet.Cells(1, inicio, 1, columna).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
            xlWorkSheet.Cells(1, inicio, 1, columna).Style.VerticalAlignment = ExcelVerticalAlignment.Center
            xlWorkSheet.Cells(1, inicio, 1, columna).Style.Fill.PatternType = ExcelFillStyle.Solid
            xlWorkSheet.Cells(1, inicio, 1, columna).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(51, 204, 204))
            xlWorkSheet.Cells(1, inicio, 1, columna).Style.Font.Name = "Calibri"
            xlWorkSheet.Cells(1, inicio, 1, columna).Style.Font.Size = 9
            xlWorkSheet.Cells(1, inicio, 1, columna).Style.Font.Bold = True
            xlWorkSheet.Cells(1, inicio).Value = _Agrupacion(index)
            xlWorkSheet.Cells(1, columna).Value = _Agrupacion(index)

            xlWorkSheet.Cells(2, inicio, 2, columna).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
            xlWorkSheet.Cells(2, inicio, 2, columna).Style.VerticalAlignment = ExcelVerticalAlignment.Center
            xlWorkSheet.Cells(2, inicio, 2, columna).Style.Fill.PatternType = ExcelFillStyle.Solid
            xlWorkSheet.Cells(2, inicio, 2, columna).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(248, 203, 173))
            xlWorkSheet.Cells(2, inicio, 2, columna).Style.Font.Name = "Calibri"
            xlWorkSheet.Cells(2, inicio, 2, columna).Style.Font.Size = 9
            xlWorkSheet.Cells(2, inicio, 2, columna).Style.Font.Bold = True
            xlWorkSheet.Cells(2, columna, 2, columna).Style.Fill.PatternType = ExcelFillStyle.Solid
            xlWorkSheet.Cells(2, columna, 2, columna).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(51, 204, 204))

            xlWorkSheet.Cells(3, inicio, 3, columna).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
            xlWorkSheet.Cells(3, inicio, 3, columna).Style.VerticalAlignment = ExcelVerticalAlignment.Bottom
            xlWorkSheet.Cells(3, inicio, 3, columna).Style.Fill.PatternType = ExcelFillStyle.Solid
            xlWorkSheet.Cells(3, inicio, 3, columna).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(221, 235, 247))
            xlWorkSheet.Cells(3, inicio, 3, columna).Style.Font.Name = "Calibri"
            xlWorkSheet.Cells(3, inicio, 3, columna).Style.Font.Size = 10
            xlWorkSheet.Cells(3, inicio, 3, columna).Style.Font.Bold = True
            xlWorkSheet.Cells(3, inicio, 3, columna).AutoFitColumns()
            xlWorkSheet.Cells(3, columna).Value = "Total general"

            'xlWorkSheet.Column(3, inicio, 3, columna - 1).ou()
            For col = inicio To columna - 1
                xlWorkSheet.Column(col).OutlineLevel = 1
                xlWorkSheet.Column(col).Collapsed = True
            Next

            columna = columna + 1
            inicio = columna

        Next
        
        'BORDER
        xlWorkSheet.Cells(1, 1, 1, columna - 1).Style.Border.Top.Style = ExcelBorderStyle.Thin
        xlWorkSheet.Cells(1, 1, 1, columna - 1).Style.Border.Left.Style = ExcelBorderStyle.Thin
        xlWorkSheet.Cells(1, 1, 1, columna - 1).Style.Border.Right.Style = ExcelBorderStyle.Thin
        xlWorkSheet.Cells(1, 1, 1, columna - 1).Style.Border.Bottom.Style = ExcelBorderStyle.Thin

        xlWorkSheet.Cells(2, 1, 2, columna - 1).Style.Border.Top.Style = ExcelBorderStyle.Thin
        xlWorkSheet.Cells(2, 1, 2, columna - 1).Style.Border.Left.Style = ExcelBorderStyle.Thin
        xlWorkSheet.Cells(2, 1, 2, columna - 1).Style.Border.Right.Style = ExcelBorderStyle.Thin
        xlWorkSheet.Cells(2, 1, 2, columna - 1).Style.Border.Bottom.Style = ExcelBorderStyle.Thin

        xlWorkSheet.Cells(3, 1, 3, columna - 1).Style.Border.Top.Style = ExcelBorderStyle.Thin
        xlWorkSheet.Cells(3, 1, 3, columna - 1).Style.Border.Left.Style = ExcelBorderStyle.Thin
        xlWorkSheet.Cells(3, 1, 3, columna - 1).Style.Border.Right.Style = ExcelBorderStyle.Thin
        xlWorkSheet.Cells(3, 1, 3, columna - 1).Style.Border.Bottom.Style = ExcelBorderStyle.Thin
    End Sub

    Sub GenerarCuadroDetallePorFamilia()
        Dim xlWorkSheet As ExcelWorksheet
        xlWorkSheet = _xlWorkBook.Worksheets.Item(4) '4: HOJA DETALLADO X FAMILIA
        xlWorkSheet.Select()

        Dim ReporteBusinessLogic As New ReporteBusinessLogic()
        Dim ListaReporteEmpresa As New List(Of ReporteVentaEmpresa)
        Dim columna As Integer, totalColumnas As Integer = 0, inicio As Integer
        ListaReporteEmpresa = ReporteBusinessLogic.SelReporteDetalladoPorFamilia(_FechaIniRep, _FechaFinRep)
        Dim fila As Integer = 4
        Dim formulaLocal As String
        formulaLocal = String.Empty
        Dim Venta, Trans As String
        Dim TotalVenta, TotalMargen, TotalTransac, TotalTicket As Integer
        Dim TotalTransPrueba, colValor, TGSucursal As String
        Dim valoresSucursal As String
        Dim valorZona, TGeneral As String
        Dim TGMargen As String
        TGMargen = String.Empty
        TGeneral = String.Empty
        valorZona = String.Empty
        TGSucursal = String.Empty
        valoresSucursal = String.Empty
        Dim TicketSucursal As New ArrayList
        For Each familia As String In ListaReporteEmpresa.[Select](Function(s) s.Familia.Trim()).Distinct()
            columna = 2
            colValor = columna.ToString()
            TGSucursal = columna.ToString()
            inicio = 2
            totalColumnas = 0

            Dim fam As String
            fam = familia.Substring(5)
            xlWorkSheet.Cells(fila, 1).Value = fam.Trim()
            Dim codigoFamilia As String = ListaReporteEmpresa.Where(Function(s) s.Familia.Trim() = familia.Trim()).Select(Function(m) m.CodigoFamilia.Trim()).FirstOrDefault
            For index = 0 To _Agrupacion.Length - 1

                Select Case index
                    Case 0

                        For i = 0 To _lstZona.Count - 1
                            Dim local_i As Integer = i
                            Dim lstSucursal As List(Of Sucursal) = _lstSucursal.FindAll(Function(x) x.IdZona = _lstZona.Item(local_i).IdZona)
                            For j = 0 To lstSucursal.Count - 1
                                
                                Dim codigoSucursal As String = lstSucursal(j).IdSucursal
                                Dim codigoTienda As Integer = codigoSucursal
                                Dim valor As Decimal
                             
                                valor = ListaReporteEmpresa.Where(Function(m) m.IdZona = _lstZona.Item(local_i).IdZona And m.CodigoTienda = codigoTienda And m.CodigoFamilia.Trim() = codigoFamilia).Select(Function(n) n.Venta).FirstOrDefault
                              
                                xlWorkSheet.Cells(fila, columna).Value = valor
                                columna += 1
                                totalColumnas += 1
                            Next
                        Next

                        xlWorkSheet.Cells(fila, columna, fila, columna).Formula = "=SUM(" & help.ColName(inicio) & fila.ToString() & ":" & help.ColName(columna - 1) & fila.ToString() & ")"
                        xlWorkSheet.Cells(fila, columna, fila, columna).Style.Fill.PatternType = ExcelFillStyle.Solid
                        xlWorkSheet.Cells(fila, columna, fila, columna).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(217, 217, 217))
                        xlWorkSheet.Cells(fila, inicio, fila, columna).Style.Font.Name = "Calibri"
                        xlWorkSheet.Cells(fila, inicio, fila, columna).Style.Font.Size = 9
                        xlWorkSheet.Cells(fila, inicio, fila, columna).Style.Numberformat.Format = "#,##0"
                        TotalVenta = columna
                        columna += 1
                        inicio = columna
                        totalColumnas += 1

                    Case 1

                        For i = 0 To _lstZona.Count - 1
                            Dim local_i As Integer = i
                            Dim lstSucursal As List(Of Sucursal) = _lstSucursal.FindAll(Function(x) x.IdZona = _lstZona.Item(local_i).IdZona)
                            For j = 0 To lstSucursal.Count - 1
                                
                                Dim codigoSucursal As String = lstSucursal(j).IdSucursal
                                Dim codigoTienda As Integer = codigoSucursal
                                Dim valor As Decimal
                              
                                valor = ListaReporteEmpresa.Where(Function(m) m.IdZona = _lstZona.Item(local_i).IdZona And m.CodigoTienda = codigoTienda And m.CodigoFamilia.Trim() = codigoFamilia).Select(Function(n) n.Margen).FirstOrDefault
                                xlWorkSheet.Cells(fila, inicio, fila, columna).Style.Numberformat.Format = "0.00%"
                             
                                xlWorkSheet.Cells(fila, columna).Value = valor
                                columna += 1
                                totalColumnas += 1
                            Next
                        Next

                        xlWorkSheet.Cells(fila, columna, fila, columna).Value = ListaReporteEmpresa.Where(Function(m) m.CodigoFamilia.Trim() = codigoFamilia).Select(Function(n) n.Margen).FirstOrDefault
                        xlWorkSheet.Cells(fila, columna, fila, columna).Style.Fill.PatternType = ExcelFillStyle.Solid
                        xlWorkSheet.Cells(fila, columna, fila, columna).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(217, 217, 217))
                        xlWorkSheet.Cells(fila, inicio, fila, columna).Style.Font.Name = "Calibri"
                        xlWorkSheet.Cells(fila, inicio, fila, columna).Style.Font.Size = 9
                        xlWorkSheet.Cells(fila, inicio, fila, columna).Style.Numberformat.Format = "0.00%"
                        TotalMargen = columna
                        'TotalTransPrueba = columna.ToString
                        columna += 1
                        inicio = columna
                        totalColumnas += 1
                        TotalTransPrueba = columna.ToString
                    Case 2

                        For i = 0 To _lstZona.Count - 1
                            Dim local_i As Integer = i
                            Dim lstSucursal As List(Of Sucursal) = _lstSucursal.FindAll(Function(x) x.IdZona = _lstZona.Item(local_i).IdZona)
                            For j = 0 To lstSucursal.Count - 1
                                Dim codigoSucursal As String = lstSucursal(j).IdSucursal
                                Dim codigoTienda As Integer = codigoSucursal
                                Dim valor As Integer = 0
                                

                                valor = ReporteBusinessLogic.SelReporteTranssaccionPorFamilia(_FechaIniRep, _FechaFinRep, codigoSucursal, codigoFamilia)
                             
                                xlWorkSheet.Cells(fila, columna).Value = valor
                                xlWorkSheet.Cells(fila, columna).Style.Numberformat.Format = "#,##0"
                                columna += 1
                                totalColumnas += 1
                            Next
                        Next

                        xlWorkSheet.Cells(fila, columna, fila, columna).Formula = "=SUM(" & help.ColName(inicio) & fila.ToString() & ":" & help.ColName(columna - 1) & fila.ToString() & ")"
                        xlWorkSheet.Cells(fila, columna, fila, columna).Style.Fill.PatternType = ExcelFillStyle.Solid
                        xlWorkSheet.Cells(fila, columna, fila, columna).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(217, 217, 217))
                        xlWorkSheet.Cells(fila, inicio, fila, columna).Style.Font.Name = "Calibri"
                        xlWorkSheet.Cells(fila, inicio, fila, columna).Style.Font.Size = 9
                        xlWorkSheet.Cells(fila, columna, fila, columna).Style.Numberformat.Format = "#,##0"
                        TotalTransac = columna

                        columna += 1
                        inicio = columna
                        totalColumnas += 1



                    Case 3
                        Dim p1, p2 As Integer

                        For i = 0 To _lstZona.Count - 1
                            Dim local_i As Integer = i
                            Dim lstSucursal As List(Of Sucursal) = _lstSucursal.FindAll(Function(x) x.IdZona = _lstZona.Item(local_i).IdZona)
                            For j = 0 To lstSucursal.Count - 1
                                Dim codigoSucursal As String = lstSucursal(j).IdSucursal
                                Dim codigoTienda As Integer = codigoSucursal



                                TicketSucursal.Add(colValor)
                                'p2 = TotalTransPrueba.ToString
                                TicketSucursal.Add(TotalTransPrueba)
                                'valores = p1 / p2

                                For s = 0 To TicketSucursal.Count - 1
                                    If s = TicketSucursal.Count - 1 Then
                                        valoresSucursal &= help.ColName(TryCast(TicketSucursal.Item(s), String)) & fila.ToString()
                                    Else
                                        valoresSucursal &= help.ColName(TryCast(TicketSucursal.Item(s), String)) & fila.ToString() & "<=0,0," & help.ColName(TryCast(TicketSucursal.Item(s), String)) & fila.ToString() & "/"
                                    End If

                                Next
                                'valores = ReporteBusinessLogic.SelReporteTranssaccionPorFamiliaTicket(_FechaIniRep, _FechaFinRep, codigoSucursal, codigoFamilia)
                                '"=(" & formulaLocal & ")"
                                xlWorkSheet.Cells(fila, columna).Formula = "=IF(" & valoresSucursal & ")"
                                xlWorkSheet.Cells(fila, columna).Style.Numberformat.Format = "#,##" & "0.00"
                                colValor += 1
                                TotalTransPrueba += 1
                                columna += 1
                                totalColumnas += 1
                                valoresSucursal = String.Empty
                                TicketSucursal.Clear()
                            Next
                        Next

                        TicketSucursal.Add(colValor.ToString)
                        TicketSucursal.Add(TotalTransPrueba.ToString)
                        For j = 0 To TicketSucursal.Count - 1
                            If j = TicketSucursal.Count - 1 Then
                                valorZona &= help.ColName(TryCast(TicketSucursal.Item(j), String)) & fila.ToString()
                            Else
                                valorZona &= help.ColName(TryCast(TicketSucursal.Item(j), String)) & fila.ToString() & "<=0,0," & help.ColName(TryCast(TicketSucursal.Item(j), String)) & fila.ToString() & "/"
                            End If

                        Next
                        'valor = ReporteBusinessLogic.SelReporteTranssaccionPorFamiliaTotalTicket(_FechaIniRep, _FechaFinRep, codigoFamilia)
                        TotalTicket = columna
                        xlWorkSheet.Cells(fila, columna, fila, columna).Formula = "=IF(" & valorZona & ")"
                        xlWorkSheet.Cells(fila, columna, fila, columna).Style.Fill.PatternType = ExcelFillStyle.Solid
                        xlWorkSheet.Cells(fila, columna, fila, columna).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(217, 217, 217))
                        xlWorkSheet.Cells(fila, inicio, fila, columna).Style.Font.Name = "Calibri"
                        xlWorkSheet.Cells(fila, inicio, fila, columna).Style.Font.Size = 9
                        xlWorkSheet.Cells(fila, inicio, fila, columna).Style.Numberformat.Format = "#,##0"
                        colValor += 1
                        TotalTransPrueba += 1
                        columna += 1
                        inicio = columna
                        totalColumnas += 1
                        TicketSucursal.Clear()
                        valorZona = String.Empty
                End Select
              
            Next
            fila += 1
        Next

        xlWorkSheet.Cells(fila, 1, fila, 1).Style.Font.Name = "Calibri"
        xlWorkSheet.Cells(fila, 1, fila, 1).Style.Font.Size = 10
        xlWorkSheet.Cells(fila, 1, fila, 1).Style.Font.Bold = True
        xlWorkSheet.Cells(fila, 1, fila, 1).Style.Fill.PatternType = ExcelFillStyle.Solid
        xlWorkSheet.Cells(fila, 1, fila, 1).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(221, 235, 247))
        xlWorkSheet.Cells(fila, 1, fila, 1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
        xlWorkSheet.Cells(fila, 1, fila, 1).Style.VerticalAlignment = ExcelVerticalAlignment.Bottom
        xlWorkSheet.Cells(fila, 1).Value = "Total general"



        For icol = 1 To totalColumnas
            If icol < TotalVenta Then

                xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Font.Name = "Calibri"
                xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Font.Size = 9
                xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Font.Bold = True
                xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Fill.PatternType = ExcelFillStyle.Solid
                xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(221, 235, 247))
                xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Formula = "=SUM(" & help.ColName(icol + 1) & "4:" & help.ColName(icol + 1) & (fila - 1).ToString() & ")"
                xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Numberformat.Format = "#,##0"
                Venta = icol
                xlWorkSheet.Column(icol + 1).AutoFit()


            Else
                If icol < TotalMargen Then

                    For indexZona = 0 To _lstZona.Count - 1
                        Dim local_i As Integer = indexZona
                        Dim lstSucursal As List(Of Sucursal) = _lstSucursal.FindAll(Function(x) x.IdZona = _lstZona.Item(local_i).IdZona)
                        For indexSucursal = 0 To lstSucursal.Count - 1
                            Dim codigoSucursal As String = lstSucursal(indexSucursal).IdSucursal
                            Dim codigoTienda As Integer = codigoSucursal

                            xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Font.Name = "Calibri"
                            xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Font.Size = 9
                            xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Font.Bold = True
                            xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Fill.PatternType = ExcelFillStyle.Solid
                            xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(221, 235, 247))
                            xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Value = (New ReporteBusinessLogic()).SelMargenNetoTotalPorTienda(_FechaIniRep, _FechaFinRep, (lstSucursal(indexSucursal)).IdSucursal)
                            xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Numberformat.Format = "0.00%"
                            xlWorkSheet.Column(icol + 1).AutoFit()
                            icol += 1
                        Next

             

                    Next

                    xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Font.Name = "Calibri"
                    xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Font.Size = 9
                    xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Font.Bold = True
                    xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Fill.PatternType = ExcelFillStyle.Solid
                    xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(221, 235, 247))
                    xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Value = (New ReporteBusinessLogic()).SelMargenNetoTotal(_FechaIniRep, _FechaFinRep)
                    xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Numberformat.Format = "0.00%"
                    xlWorkSheet.Column(icol + 1).AutoFit()
                    TGMargen = icol.ToString
                    TGMargen += 2

                Else
                    If icol < TotalTransac Then
                        xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Font.Name = "Calibri"
                        xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Font.Size = 9
                        xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Font.Bold = True
                        xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Fill.PatternType = ExcelFillStyle.Solid
                        xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(221, 235, 247))
                        xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Formula = "=SUM(" & help.ColName(icol + 1) & "4:" & help.ColName(icol + 1) & (fila - 1).ToString() & ")"
                        xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Numberformat.Format = "#,##0"
                        Trans = icol
                        xlWorkSheet.Column(icol + 1).AutoFit()

                    Else
                        If icol < TotalTicket Then
                            For indexZona = 0 To _lstZona.Count - 1
                                Dim local_i As Integer = indexZona
                                Dim lstSucursal As List(Of Sucursal) = _lstSucursal.FindAll(Function(x) x.IdZona = _lstZona.Item(local_i).IdZona)
                                For indexSucursal = 0 To lstSucursal.Count - 1
                                    Dim codigoSucursal As String = lstSucursal(indexSucursal).IdSucursal
                                    Dim codigoTienda As Integer = codigoSucursal

                                    TicketSucursal.Add(TGSucursal)
                                    TicketSucursal.Add(TGMargen)

                                    For t = 0 To TicketSucursal.Count - 1
                                        If t = TicketSucursal.Count - 1 Then
                                            TGeneral &= help.ColName(TryCast(TicketSucursal.Item(t), String)) & fila.ToString()
                                        Else
                                            TGeneral &= help.ColName(TryCast(TicketSucursal.Item(t), String)) & fila.ToString() & "<=0,0," & help.ColName(TryCast(TicketSucursal.Item(t), String)) & fila.ToString() & "/"
                                        End If

                                    Next

                                    xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Font.Name = "Calibri"
                                    xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Font.Size = 9
                                    xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Font.Bold = True
                                    xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Fill.PatternType = ExcelFillStyle.Solid
                                    xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(221, 235, 247))
                                    'xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Value = (New ReporteBusinessLogic()).SelReporteTotalTicket(_FechaIniRep, _FechaFinRep, codigoTienda)
                                    xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Formula = "=IF(" & TGeneral & ")"
                                    xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Numberformat.Format = "#,##0"
                                    xlWorkSheet.Column(icol + 1).AutoFit()
                                    TGMargen += 1
                                    TGSucursal += 1
                                    icol += 1
                                    TicketSucursal.Clear()
                                    TGeneral = String.Empty
                                Next

                       
                            Next


                            Dim TotalVentaTrans As New ArrayList
                            Venta += 1
                            Trans += 1
                            TotalVentaTrans.Add(Venta)
                            TotalVentaTrans.Add(Trans)
                            For index = 0 To TotalVentaTrans.Count - 1
                                If index = TotalVentaTrans.Count - 1 Then
                                    formulaLocal &= help.ColName(TryCast(TotalVentaTrans.Item(index), String)) & fila.ToString()
                                Else
                                    formulaLocal &= help.ColName(TryCast(TotalVentaTrans.Item(index), String)) & fila.ToString() & "<=0,0," & help.ColName(TryCast(TotalVentaTrans.Item(index), String)) & fila.ToString() & "/"
                                End If

                            Next

                            xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Formula = "=IF(" & formulaLocal & ")"

                            xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Font.Name = "Calibri"
                            xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Font.Size = 9
                            xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Font.Bold = True
                            xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Fill.PatternType = ExcelFillStyle.Solid
                            xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(221, 235, 247))
                            xlWorkSheet.Cells(fila, icol + 1, fila, icol + 1).Style.Numberformat.Format = "#,##0"

                        End If
                    End If

                End If


            End If


        Next
        xlWorkSheet.View.FreezePanes(4, 2)
        xlWorkSheet.Column(1).AutoFit()

        If fila > 4 Then
            xlWorkSheet.Cells(4, 1, fila - 1, 1).Style.Font.Name = "Calibri"
            xlWorkSheet.Cells(4, 1, fila - 1, 1).Style.Font.Size = 11
        Else
            xlWorkSheet.Cells(4, 1, fila, 1).Style.Font.Name = "Calibri"
            xlWorkSheet.Cells(4, 1, fila, 1).Style.Font.Size = 11
        End If

      
    End Sub
End Class
