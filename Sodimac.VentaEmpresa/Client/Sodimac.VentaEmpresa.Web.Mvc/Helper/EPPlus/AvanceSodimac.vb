Imports OfficeOpenXml
Imports OfficeOpenXml.Style
Imports Sodimac.VentaEmpresa.DataContracts
Imports System.Drawing
Imports Sodimac.VentaEmpresa.BusinessLogic

Public Class AvanceSodimac
    Dim _xlWorkBook As ExcelWorkbook
    Dim _FechaIniRep As Date
    Dim _FechaFinRep As Date
    Dim _lstZona As List(Of Zona)
    Dim _lstSucursal As List(Of Sucursal)
    Dim _IdMarca As Integer
    Dim F1, F2 As String
    Dim help As New HelperReporteVAP

    Sub New(xlWorkBook As ExcelWorkbook, fechaInicio As Date, fechaFin As Date, lstZona As List(Of Zona), lstSucursal As List(Of Sucursal), IdMarca As Integer)
        Me._xlWorkBook = xlWorkBook
        Me._FechaIniRep = fechaInicio
        Me._FechaFinRep = fechaFin
        Me._lstZona = lstZona
        Me._lstSucursal = lstSucursal
        Me._IdMarca = IdMarca
    End Sub

    Sub Generar()
        formatoPrevio()
        GenerarCabecera()
        GenerarCuadroVenta()
        GenerarCuadroVentaInteranual()
        GenerarCuadroPlanAlDia()
        GenerarCuadroContribucion()
        GenerarCuadroMargen()
        GenerarCuadroTransacciones()
        GenerarTicketPromedio()
        setearTitulo()
    End Sub

    Sub setearTitulo()
        Dim xlWorkSheet As ExcelWorksheet
        xlWorkSheet = _xlWorkBook.Worksheets.Item(2) '2: HOJA AVANCE SODIMAC
        xlWorkSheet.Select()

        xlWorkSheet.Column(1).AutoFit() '"A"

        xlWorkSheet.Cells(1, 1).Value = "VENTA EMPRESAS " + (New HelperReporteVE).getNombreMes(_FechaFinRep.Month).ToUpper() + " " + _FechaFinRep.Year.ToString()
        xlWorkSheet.Cells(1, 1, 1, 1000).Style.Fill.PatternType = ExcelFillStyle.Solid
        xlWorkSheet.Cells(1, 1, 1, 1000).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(244, 176, 132))
        xlWorkSheet.Cells(1, 1, 1, 1).Style.Font.Color.SetColor(Color.FromArgb(255, 255, 255))
        xlWorkSheet.Cells(1, 1, 1, 1).Style.Font.Name = "Arial Black"
        xlWorkSheet.Cells(1, 1, 1, 1).Style.Font.Size = 36
        xlWorkSheet.Cells(1, 1, 1, 1).Style.Font.Bold = True
        xlWorkSheet.Cells(1, 1, 1, 1).Style.Font.UnderLine = True

    End Sub

    Sub formatoPrevio()
        Dim xlWorkSheet As ExcelWorksheet
        xlWorkSheet = _xlWorkBook.Worksheets.Item(2) '2: HOJA AVANCE SODIMAC
        xlWorkSheet.Select()
        xlWorkSheet.View.ZoomScale = 50

        'Formato General Texto para la hoja
        xlWorkSheet.Cells(1, 1, 200, 200).Style.Font.Name = "Calibri"
        xlWorkSheet.Cells(1, 1, 200, 200).Style.Font.Size = 20
        'Formato numeros
        xlWorkSheet.Cells(8, 2, 200, 200).Style.Numberformat.Format = "#,##0"
        'Alineamiento para la hoja
        xlWorkSheet.Cells(5, 2, 200, 200).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
        'Ancho columnas
        For col = 2 To 200
            xlWorkSheet.Column(col).Width = 35
        Next
        'Freeze panels
        xlWorkSheet.View.FreezePanes(8, 2)
    End Sub

    Sub GenerarCabecera()
        Dim xlWorkSheet As ExcelWorksheet
        xlWorkSheet = _xlWorkBook.Worksheets.Item(2) '2: HOJA AVANCE SODIMAC
        xlWorkSheet.Select()

        xlWorkSheet.Cells(2, 1).Value = "PROYECTADO:"
        xlWorkSheet.Cells(2, 1, 2, 1).Style.Font.Name = "Arial"
        xlWorkSheet.Cells(2, 1, 2, 1).Style.Font.Size = 20
        xlWorkSheet.Cells(2, 1, 2, 1).Style.Font.Bold = True
        xlWorkSheet.Cells(2, 1, 2, 1).Style.VerticalAlignment = ExcelVerticalAlignment.Center

        'xlWorkSheet.Cells(2, 1).Value = "V. DESARROLLO"
        xlWorkSheet.Cells(2, 1).Value = ""
        'xlWorkSheet.Cells(2, 1, 2, 1).Style.Fill.PatternType = ExcelFillStyle.Solid
        'xlWorkSheet.Cells(2, 1, 2, 1).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 0, 0))
        xlWorkSheet.Cells(2, 1, 2, 1).Style.Font.Bold = True

        'xlWorkSheet.Cells(2, 2).Value = Date.FromOADate(_FechaFinRep.ToString)
        Dim fecha As String = _FechaFinRep
        xlWorkSheet.Cells(2, 2).Value = fecha
        xlWorkSheet.Cells(2, 2, 2, 2).Style.Font.Name = "Arial"
        xlWorkSheet.Cells(2, 2, 2, 2).Style.Font.Size = 20


        Dim str As String = (New ReporteBusinessLogic()).SelDiasUtilesyDiasAvancePorMes(_FechaFinRep)
        Dim DiasUtiles As Integer
        Dim DiasAvance As Integer
        DiasUtiles = Convert.ToInt32(str.Split(";")(0))
        DiasAvance = Convert.ToInt32(str.Split(";")(1))

        xlWorkSheet.Cells(2, 22).Value = "DÍAS ÚTILES:"
        xlWorkSheet.Cells(2, 23).Value = DiasUtiles
        xlWorkSheet.Cells(2, 24).Value = "AVANCE:"
        xlWorkSheet.Cells(2, 25).Value = DiasAvance
        xlWorkSheet.Cells(2, 22, 2, 25).Style.Font.Name = "Arial"
        xlWorkSheet.Cells(2, 22, 2, 25).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
    End Sub

    Sub GenerarCuadroVenta()
        Dim xlWorkSheet As ExcelWorksheet
        xlWorkSheet = _xlWorkBook.Worksheets.Item(2) '2: HOJA AVANCE SODIMAC
        xlWorkSheet.Select()

        'Formato previo celdas
        'help.SetAllBorders_Thin(xlWorkSheet.Cells(5, 1,15, 1 + _lstSucursal.Count + _lstZona.Count + 3)))

        xlWorkSheet.Cells(4, 1).Value = "VENTA"
        xlWorkSheet.Cells(4, 1, 4, 1).Style.Font.Name = "Arial"
        xlWorkSheet.Cells(4, 1, 4, 1).Style.Font.Size = 20
        xlWorkSheet.Cells(4, 1, 4, 1).Style.Font.Bold = True

        xlWorkSheet.Cells(5, 1).Value = "MERCADO"
        'xlWorkSheet.Cells(5, 1, 5, 2).Merge = True
        xlWorkSheet.Cells(6, 1, 7, 1).Merge = True
        xlWorkSheet.Cells(5, 1, 5, 1).Style.Font.Bold = True

        xlWorkSheet.Cells(6, 1).Value = "VENTA NETA"
        xlWorkSheet.Cells(8, 1).Value = "PLAN VENTA NETA VENTA EMPRESA"
        xlWorkSheet.Cells(9, 1).Value = "VENTA NETA CONTADO"
        xlWorkSheet.Cells(10, 1).Value = "VENTA NETA CRÉDITO"
        xlWorkSheet.Cells(11, 1).Value = "VENTA NETA TOTAL"
        xlWorkSheet.Cells(12, 1).Value = "CUMPLIMIENTO VENTA EMPRESA"
        xlWorkSheet.Cells(13, 1).Value = "PROYECTADO VENTA EMPRESA"
        xlWorkSheet.Cells(14, 1).Value = "VENTA NECESARIA DIARIA"
        xlWorkSheet.Cells(15, 1).Value = "CUMPLIMIENTO PROYECTADO"
        xlWorkSheet.Cells(15, 1, 15, 1).Style.Font.Bold = True
        xlWorkSheet.Cells(14, 1).Style.Hidden = True
        xlWorkSheet.Column(14).Hidden = True
       

        xlWorkSheet.Row(14).Hidden = True
        Dim iniColTiendas As Integer = 2
        Dim col As Integer = iniColTiendas
        Dim FormulaSubTotales_PlanVentaNetaVE As String = "=SUM("
        Dim FormulaSubTotales_VentaNetaContado As String = "=SUM("
        Dim FormulaSubTotales_VentaNetaCredito As String = "=SUM("
        Dim FormulaSubTotales_VentaNetaTotal As String = "=SUM("

        For i = 0 To _lstZona.Count - 1
            Dim local_i As Integer = i
            Dim lstSucursal As List(Of Sucursal) = _lstSucursal.FindAll(Function(x) x.IdZona = _lstZona.Item(local_i).IdZona)

            For j = 0 To lstSucursal.Count - 1
                xlWorkSheet.Cells(6, col).Value = (lstSucursal(j)).CodigoSucursal
                xlWorkSheet.Cells(7, col).Value = (lstSucursal(j)).Descripcion.ToUpper

                'row "PLAN VENTA NETA VENTA EMPRESA" por tienda:
                xlWorkSheet.Cells(8, col).Value = (New ReporteBusinessLogic()).SelPlanVentaPorTienda(_FechaFinRep, (lstSucursal(j)).CodigoSucursal)
                'row "VENTA NETA CONTADO" por tienda:
                xlWorkSheet.Cells(9, col).Value = (New ReporteBusinessLogic()).SelVentaNetaContadoPorTienda(_FechaIniRep, _FechaFinRep, (lstSucursal(j)).IdSucursal)
                'row "VENTA NETA CREDITO" por tienda:
                xlWorkSheet.Cells(10, col).Value = (New ReporteBusinessLogic()).SelVentaNetaCreditoPorTienda(_FechaIniRep, _FechaFinRep, (lstSucursal(j)).IdSucursal)

                'formula VENTA NETA TOTAL
                xlWorkSheet.Cells(11, col, 11, col).Formula = "=SUM(" & help.ColName(col) & "9:" & help.ColName(col) & "10)"

                'formula CUMPLIMIENTO
                'xlWorkSheet.Cells(27, col, 27, col).Formula = "=IF(" & help.ColName(col) & "25<0," & help.ColName(col) & "26" & ",IF(" & help.ColName(col) & "25>0," & help.ColName(col) & "25+" & help.ColName(col) & "26  ))"
                xlWorkSheet.Cells(12, col, 12, col).Formula = "=IF(" & help.ColName(col) & "8=0," & "0," & help.ColName(col) & "11/" & help.ColName(col) & "8)"
                'xlWorkSheet.Cells(12, col, 12, col).Formula = "=(" & help.ColName(col) & "11/" & help.ColName(col) & "8)"
                'formula PROYECTADO
                xlWorkSheet.Cells(13, col, 13, col).Formula = "=(" & help.ColName(col) & "11/$Y$2)*$W$2"
                'formula VENTA NECESARIA DIARIA
                xlWorkSheet.Cells(14, col, 14, col).Formula = "=IF((($W$2-$Y$2)*0.999)=0,0,(" & help.ColName(col) & "8-" & help.ColName(col) & "11)/($W$2-$Y$2)*0.999)"
                'formula CUMPLIMIENTO PROYECTADO
                xlWorkSheet.Cells(15, col, 15, col).Formula = "=" & help.ColName(col) & "13/" & help.ColName(col) & "8"

                'formato bordes celdas
                help.SetAllBorders_Medium(xlWorkSheet.Cells(8, col, 10, col))

                col = col + 1
            Next

            'Merge para el nombre de la zona
            'xlWorkSheet.Cells(53, col - lstSucursal.Count).Value = (_lstZona(i)).NombreZona
            'xlWorkSheet.Cells(53, col - lstSucursal.Count, 53, col).Merge = True
            xlWorkSheet.Cells(5, col - lstSucursal.Count).Value = (_lstZona(i)).NombreZona
            xlWorkSheet.Cells(5, col - lstSucursal.Count, 5, col).Merge = True

            xlWorkSheet.Cells(5, col - lstSucursal.Count, 5, col).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
            xlWorkSheet.Cells(5, col - lstSucursal.Count, 5, col).Style.Font.Bold = True
            ' xlWorkSheet.Cells(5, col - lstSucursal.Count, 5, col).Style.WrapText = True
            'col TOTAL ZONA
            xlWorkSheet.Cells(6, col).Value = (_lstZona(i)).NombreZona.Replace("ZONA", "TOTAL")
            'nueva linea
            xlWorkSheet.Cells(6, col, 7, col).Merge = True

            xlWorkSheet.Cells(6, col, 6, col).Style.Font.Bold = True
            xlWorkSheet.Cells(6, col, 7, col).Style.WrapText = True
            xlWorkSheet.Cells(6, col, 7, col).Style.VerticalAlignment = ExcelVerticalAlignment.Center
            'nueva linea
            help.SetAllBorders_Medium(xlWorkSheet.Cells(6, col, 15, col))
            xlWorkSheet.Cells(6, col, 15, col).Style.Fill.PatternType = ExcelFillStyle.Solid
            xlWorkSheet.Cells(6, col, 15, col).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(217, 217, 217))
            ''nueva linea
            ' xlWorkSheet.Cells(6, col - lstSucursal.Count, 6, col - 1).Columns.Group()
            For colGroup = col - lstSucursal.Count To col - 1
                xlWorkSheet.Column(colGroup).OutlineLevel = 1
                xlWorkSheet.Column(colGroup).Collapsed = True
            Next

            'col TOTAL ZONA - PLAN VENTA NETA VENTA EMPRESA
            xlWorkSheet.Cells(8, col, 8, col).Formula = "=SUM(" & help.ColName(col - lstSucursal.Count) & "8:" & help.ColName(col - 1) & "8)"
            'col TOTAL ZONA - VENTA NETA CONTADO
            xlWorkSheet.Cells(9, col, 9, col).Formula = "=SUM(" & help.ColName(col - lstSucursal.Count) & "9:" & help.ColName(col - 1) & "9)"
            'col TOTAL ZONA - VENTA NETA CREDITO
            xlWorkSheet.Cells(10, col, 10, col).Formula = "=SUM(" & help.ColName(col - lstSucursal.Count) & "10:" & help.ColName(col - 1) & "10)"
            'col TOTAL ZONA - VENTA NETA TOTAL
            xlWorkSheet.Cells(11, col, 11, col).Formula = "=SUM(" & help.ColName(col - lstSucursal.Count) & "11:" & help.ColName(col - 1) & "11)"
            'col TOTAL ZONA - CUMPLIMIENTO
            xlWorkSheet.Cells(12, col, 12, col).Formula = "=(" & help.ColName(col) & "11/" & help.ColName(col) & "8)"
            'col TOTAL ZONA - PROYECTADO
            xlWorkSheet.Cells(13, col, 13, col).Formula = "=(" & help.ColName(col) & "11/$Y$2)*$W$2"
            'col TOTAL ZONA - VENTA NECESARIA DIARIA
            xlWorkSheet.Cells(14, col, 14, col).Formula = "=IF((($W$2-$Y$2)*0.999)=0,0,(" & help.ColName(col) & "8-" & help.ColName(col) & "11)/($W$2-$Y$2)*0.999)"
            'col TOTAL ZONA - CUMPLIMIENTO PROYECTADO
            xlWorkSheet.Cells(15, col, 15, col).Formula = "=" & help.ColName(col) & "13/" & help.ColName(col) & "8"

            If (i = 0) Then
                FormulaSubTotales_PlanVentaNetaVE = FormulaSubTotales_PlanVentaNetaVE & help.ColName(iniColTiendas + lstSucursal.Count) & 8
                FormulaSubTotales_VentaNetaContado = FormulaSubTotales_VentaNetaContado & help.ColName(iniColTiendas + lstSucursal.Count) & 9
                FormulaSubTotales_VentaNetaCredito = FormulaSubTotales_VentaNetaCredito & help.ColName(iniColTiendas + lstSucursal.Count) & 10
                FormulaSubTotales_VentaNetaTotal = FormulaSubTotales_VentaNetaTotal & help.ColName(iniColTiendas + lstSucursal.Count) & 11
            Else
                FormulaSubTotales_PlanVentaNetaVE = FormulaSubTotales_PlanVentaNetaVE & "+" & help.ColName(col) & 8
                FormulaSubTotales_VentaNetaContado = FormulaSubTotales_VentaNetaContado & "+" & help.ColName(col) & 9
                FormulaSubTotales_VentaNetaCredito = FormulaSubTotales_VentaNetaCredito & "+" & help.ColName(col) & 10
                FormulaSubTotales_VentaNetaTotal = FormulaSubTotales_VentaNetaTotal & "+" & help.ColName(col) & 11
            End If
            col = col + 1
        Next
        FormulaSubTotales_PlanVentaNetaVE = FormulaSubTotales_PlanVentaNetaVE & ")"
        FormulaSubTotales_VentaNetaContado = FormulaSubTotales_VentaNetaContado & ")"
        FormulaSubTotales_VentaNetaCredito = FormulaSubTotales_VentaNetaCredito & ")"
        FormulaSubTotales_VentaNetaTotal = FormulaSubTotales_VentaNetaTotal & ")"

        'col SUBTOTALES-----------------------------------------------------------------------------------------------------------
        xlWorkSheet.Cells(6, col).Value = "SUBTOTALES"
        'nueva linea
        xlWorkSheet.Cells(6, col, 7, col).Merge = True
        xlWorkSheet.Cells(6, col, 12, col).Style.Fill.PatternType = ExcelFillStyle.Solid
        xlWorkSheet.Cells(6, col, 12, col).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(217, 217, 217))
        xlWorkSheet.Cells(14, col, 15, col).Style.Fill.PatternType = ExcelFillStyle.Solid
        xlWorkSheet.Cells(14, col, 15, col).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(217, 217, 217))

        'col SUBTOTALES - row PLAN VENTA NETA VENTA EMPRESA
        xlWorkSheet.Cells(8, col, 8, col).Formula = FormulaSubTotales_PlanVentaNetaVE
        'col SUBTOTALES - row VENTA NETA CONTADO
        xlWorkSheet.Cells(9, col, 9, col).Formula = FormulaSubTotales_VentaNetaContado
        'col SUBTOTALES - row VENTA NETA CREDITO
        xlWorkSheet.Cells(10, col, 10, col).Formula = FormulaSubTotales_VentaNetaCredito
        'col SUBTOTALES - row VENTA NETA TOTAL
        xlWorkSheet.Cells(11, col, 11, col).Formula = FormulaSubTotales_VentaNetaTotal
        'col SUBTOTALES - row CUMPLIMIENTO
        xlWorkSheet.Cells(12, col, 12, col).Formula = "=" & help.ColName(col) & "11" & "/" & help.ColName(col) & "8"
        'col SUBTOTALES - row PROYECTADO
        xlWorkSheet.Cells(13, col, 13, col).Formula = "=(" & help.ColName(col) & "11/$Y$2)*$W$2"
        'col SUBTOTALES - row VENTA NECESARIA DIARIA (NO utiliza formula)
        'col SUBTOTALES - row CUMPLIMIENTO PROYECTADO
        xlWorkSheet.Cells(15, col, 15, col).Formula = "=" & help.ColName(col) & "13/" & help.ColName(col) & "8"

        col = col + 1

        'col T007-----------------------------------------------------------------------------------------------------------
        'nueva linea
        ' xlWorkSheet.Cells(5, col - 2, 5, col).Merge = True
        xlWorkSheet.Cells(6, col, 12, col).Style.Fill.PatternType = ExcelFillStyle.Solid
        xlWorkSheet.Cells(6, col, 12, col).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(217, 217, 217))
        xlWorkSheet.Cells(14, col, 14, col).Style.Fill.PatternType = ExcelFillStyle.Solid
        xlWorkSheet.Cells(14, col, 14, col).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(217, 217, 217))

        xlWorkSheet.Cells(6, col).Value = "T007"
        xlWorkSheet.Cells(7, col).Value = "VENTA EMPRESA"
        xlWorkSheet.Cells(8, col).Value = (New ReporteBusinessLogic()).SelPlanVentaPorTienda(_FechaFinRep, "T007")
        xlWorkSheet.Cells(9, col).Value = (New ReporteBusinessLogic()).SelVentaNetaContadoPorTienda(_FechaIniRep, _FechaFinRep, 31)
        xlWorkSheet.Cells(10, col).Value = (New ReporteBusinessLogic()).SelVentaNetaCreditoPorTienda(_FechaIniRep, _FechaFinRep, 31)
        xlWorkSheet.Cells(11, col, 11, col).Formula = "=SUM(" & help.ColName(col) & 9 & ":" & help.ColName(col) & 10 & ")"
        xlWorkSheet.Cells(12, col).Value = "0.0%"
        xlWorkSheet.Cells(13, col).Value = "0"
        xlWorkSheet.Cells(14, col).Value = "" 'sin valores
        xlWorkSheet.Cells(15, col).Value = "0.0%"

        col = col + 1

        'col TOTAL VAP-----------------------------------------------------------------------------------------------------------
        xlWorkSheet.Cells(6, col).Value = "TOTAL VE"
        'nueva linea
        xlWorkSheet.Cells(6, col, 7, col).Merge = True
        xlWorkSheet.Cells(9, col, 11, col).Style.Fill.PatternType = ExcelFillStyle.Solid
        xlWorkSheet.Cells(9, col, 11, col).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(217, 217, 217))

        'col TOTAL VAP - PLAN VENTA NETA VENTA EMPRESA
        xlWorkSheet.Cells(8, col, 8, col).Formula = "=SUM(" & help.ColName(col - 2) & 8 & ":" & help.ColName(col - 1) & "8)"
        'col TOTAL VAP - VENTA NETA CONTADO
        xlWorkSheet.Cells(9, col, 9, col).Formula = "=SUM(" & help.ColName(col - 2) & 9 & ":" & help.ColName(col - 1) & "9)"
        'col TOTAL VAP - VENTA NETA CREDITO 
        xlWorkSheet.Cells(10, col, 10, col).Formula = "=SUM(" & help.ColName(col - 2) & 10 & ":" & help.ColName(col - 1) & "10)"
        'col TOTAL VAP - VENTA NETA TOTAL
        xlWorkSheet.Cells(11, col, 11, col).Formula = "=SUM(" & help.ColName(col - 2) & 11 & ":" & help.ColName(col - 1) & "11)"
        'col TOTAL VAP - CUMPLIMIENTO VENTA EMPRESA
        xlWorkSheet.Cells(12, col, 12, col).Formula = "=" & help.ColName(col) & "11/" & help.ColName(col) & "8"
        'col TOTAL VAP - PROYECTADO VENTA EMPRESA
        xlWorkSheet.Cells(13, col, 13, col).Formula = "=(" & help.ColName(col) & "11/$Y$2)*$W$2"
        'col TOTAL VAP - VENTA NECESARIA DIARIA
        xlWorkSheet.Cells(14, col, 14, col).Formula = "=IF((($W$2-$Y$2)*0.999)=0,0,(" & help.ColName(col - 2) & "8-" & help.ColName(col) & "11)/($W$2-$Y$2)*0.999)"
        'col TOTAL VAP - CUMPLIMIENTO PROYECTADO
        xlWorkSheet.Cells(15, col, 15, col).Formula = "=" & help.ColName(col) & "13/" & help.ColName(col) & "8"

        '---------------------------------------------------------------------------------------------------------------------------
        'FORMATO CUADRO VENTAS
        '---------------------------------------------------------------------------------------------------------------------------

        Dim xl_range As ExcelRange = xlWorkSheet.Cells(5, 1, 5, 1)

        help.SetAllBorders_Thin(xl_range)
        help.SetAllBorders_Medium(xl_range)

        Dim xl_range1 As ExcelRange = xlWorkSheet.Cells(6, 1, 8, col)
        help.SetAllBorders_Thin(xl_range1)
        help.SetAllBorders_Medium(xl_range1)

        Dim xl_range2 As ExcelRange = xlWorkSheet.Cells(9, 1, 10, col)
        help.SetAllBorders_Thin(xl_range2)
        help.SetAllBorders_Medium(xl_range2)

        Dim xl_range3 As ExcelRange = xlWorkSheet.Cells(12, 1, 12, col)
        help.SetAllBorders_Thin(xl_range3)
        help.SetAllBorders_Medium(xl_range3)

        Dim xl_range4 As ExcelRange = xlWorkSheet.Cells(15, 1, 15, col)
        help.SetAllBorders_Thin(xl_range4)
        help.SetAllBorders_Medium(xl_range4)

        Dim xl_range5 As ExcelRange = xlWorkSheet.Cells(6, 1, 15, col - 2)
        help.SetAllBorders_Thin(xl_range5)
        help.SetAllBorders_Medium(xl_range5)

        Dim xl_range6 As ExcelRange = xlWorkSheet.Cells(5, 1, 15, col)
        help.SetAllBorders_Thin(xl_range6)
        help.SetAllBorders_Medium(xl_range6)

        xlWorkSheet.Cells(8, 1, 8, col).Style.Font.Bold = True
        xlWorkSheet.Cells(11, 1, 11, col).Style.Font.Bold = True
        xlWorkSheet.Cells(12, 1, 12, col).Style.Font.Bold = True
        xlWorkSheet.Cells(14, 2, 14, col).Style.Font.Bold = True

        xlWorkSheet.Cells(5, 1, 8, col).Style.Fill.PatternType = ExcelFillStyle.Solid
        xlWorkSheet.Cells(5, 1, 8, col).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(217, 217, 217))
        xlWorkSheet.Cells(12, 1, 12, col).Style.Fill.PatternType = ExcelFillStyle.Solid
        xlWorkSheet.Cells(12, 1, 12, col).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(217, 217, 217))

        xlWorkSheet.Cells(15, 2, 15, col).Style.Numberformat.Format = "0.00%"
        xlWorkSheet.Cells(12, 2, 12, col).Style.Numberformat.Format = "0.0%"


    End Sub



    Sub GenerarCuadroVentaInteranual()
        Dim xlWorkSheet As ExcelWorksheet
        xlWorkSheet = _xlWorkBook.Worksheets.Item(2) '2: HOJA AVANCE SODIMAC
        xlWorkSheet.Select()

        Dim fecIniVI As Date
        Dim fecFinVI As Date

        Dim bll As New ReporteBusinessLogic
        bll.SelPeriodosVentaInteranual(_FechaIniRep, _FechaFinRep, fecIniVI, fecFinVI)
        'Dim FechaIni, FechaFin As String
        'Dim M1, M2 As Integer
        'M1 = 0
        'M2 = 1
        'FechaIni = fecIniVI.Month.ToString
        'FechaFin = fecIniVI.Month.ToString
        'Fecha(FechaIni, M1)
        'Fecha(FechaFin, M2)
    
        xlWorkSheet.Cells(18, 1).Value = Left(fecIniVI.Day.ToString, 2) & " DE " & (New HelperReporteVE).getNombreMes(fecIniVI.Month).ToUpper & " AL " & Left(fecFinVI.Day.ToString(), 2) & " DE " & (New HelperReporteVE).getNombreMes(fecFinVI.Month).ToUpper & " DEL " & fecFinVI.Year.ToString
        xlWorkSheet.Cells(19, 1).Value = "VENTA INTERANUAL " & fecFinVI.Year.ToString
        xlWorkSheet.Cells(20, 1).Value = "VARIACION INTERANUAL S/."
        xlWorkSheet.Cells(21, 1).Value = "VARIACION INTERANUAL %"

        Dim iniColTiendas As Integer = 2
        Dim col As Integer = iniColTiendas
        Dim FormulaSubTotales_VentaInteranualYYYY As String = "=SUM("

        For i = 0 To _lstZona.Count - 1
            Dim local_i As Integer
            local_i = i
            Dim lstSucursal As List(Of Sucursal) = _lstSucursal.FindAll(Function(x) x.IdZona = _lstZona.Item(local_i).IdZona)

            For j = 0 To lstSucursal.Count - 1
                xlWorkSheet.Cells(19, col).Value = (New ReporteBusinessLogic()).SelVentaInteranual(fecIniVI, fecFinVI, (lstSucursal(j)).CodigoSucursal)

                xlWorkSheet.Cells(20, col, 20, col).Formula = "=" & help.ColName(col) & "11-" & help.ColName(col) & "19"
                xlWorkSheet.Cells(21, col, 21, col).Formula = "=" & help.ColName(col) & "11/" & help.ColName(col) & "19-1"
                col = col + 1
            Next
            'COL - TOTAL ZONA
            'ROW - VENTA INTERANUAL YYYY
            xlWorkSheet.Cells(19, col, 19, col).Formula = "=SUM(" & help.ColName(col - lstSucursal.Count) & "19:" & help.ColName(col - 1) & "19)"
            'ROW - VARIACION INTERANUAL S/.
            xlWorkSheet.Cells(20, col, 20, col).Formula = "=" & help.ColName(col) & "11-" & help.ColName(col) & "19"
            'ROW - VARIACION INTERANUAL %
            xlWorkSheet.Cells(21, col, 21, col).Formula = "=" & help.ColName(col) & "11/" & help.ColName(col) & "19-1"

            If (i = 0) Then
                FormulaSubTotales_VentaInteranualYYYY = FormulaSubTotales_VentaInteranualYYYY & help.ColName(iniColTiendas + lstSucursal.Count) & 19
            Else
                FormulaSubTotales_VentaInteranualYYYY = FormulaSubTotales_VentaInteranualYYYY & "+" & help.ColName(col) & 19
            End If

            col = col + 1
        Next
        FormulaSubTotales_VentaInteranualYYYY = FormulaSubTotales_VentaInteranualYYYY & ")"

        'col SUBTOTALES-----------------------------------------------------------------------------------------------------------
        'col SUBTOTALES - row VENTA INTERANUAL YYYY
        xlWorkSheet.Cells(19, col, 19, col).Formula = FormulaSubTotales_VentaInteranualYYYY
        'col SUBTOTALES - row VARIACION INTERANUAL S/. 
        xlWorkSheet.Cells(20, col, 20, col).Formula = "=" & help.ColName(col) & "11-" & help.ColName(col) & "19"
        'col SUBTOTALES - row VARIACION INTERANUAL %
        xlWorkSheet.Cells(21, col, 21, col).Formula = "=" & help.ColName(col) & "11/" & help.ColName(col) & "19-1"

        col = col + 1
        'col T007-----------------------------------------------------------------------------------------------------------
     
        xlWorkSheet.Cells(19, col).Value = 0.0
        xlWorkSheet.Cells(20, col, 20, col).Formula = "=" & help.ColName(col) & "11-" & help.ColName(col) & "19"
        xlWorkSheet.Cells(21, col).Value = "0.0%"

        col = col + 1

        'col TOTAL VAP-----------------------------------------------------------------------------------------------------------
        'col TOTAL VAP - VENTA INTERANUAL YYYY
        xlWorkSheet.Cells(19, col, 19, col).Formula = "=SUM(" & help.ColName(col - 2) & 19 & ":" & help.ColName(col - 1) & "19)"
        'col TOTAL VAP - VARIACION INTERANUAL S/. 
        xlWorkSheet.Cells(20, col, 20, col).Formula = "=" & help.ColName(col) & "11-" & help.ColName(col) & "19"
        'col TOTAL VAP - VARIACION INTERANUAL %
        xlWorkSheet.Cells(21, col, 21, col).Formula = "=" & help.ColName(col) & "11/" & help.ColName(col) & "19-1"

        '---------------------------------------------------------------------------------------------------------------------------
        'FORMATO CUADRO VENTA INTERANUAL
        '---------------------------------------------------------------------------------------------------------------------------
        xlWorkSheet.Cells(18, 1, 18, 1).Style.Font.Bold = True
        xlWorkSheet.Cells(19, 1, 21, col).Style.Font.Bold = True
        Dim xl_range As ExcelRange = xlWorkSheet.Cells(19, 1, 21, col)
        help.SetAllBorders_Thin(xl_range)
        help.SetAllBorders_Medium(xl_range)

        xlWorkSheet.Cells(19, 1, 20, col).Style.Fill.PatternType = ExcelFillStyle.Solid
        xlWorkSheet.Cells(19, 1, 20, col).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(217, 217, 217))
        xlWorkSheet.Cells(21, 2, 21, col).Style.Numberformat.Format = "0.00%"

        

    End Sub

    Sub GenerarCuadroPlanAlDia()
        Dim xlWorkSheet As ExcelWorksheet
        xlWorkSheet = _xlWorkBook.Worksheets.Item(2) '2: HOJA AVANCE SODIMAC
        xlWorkSheet.Select()

        xlWorkSheet.Cells(24, 1).Value = "PLAN AL DIA"
        xlWorkSheet.Cells(25, 1).Value = "DEBE AL PLAN AL DIA DE AYER"
        xlWorkSheet.Cells(26, 1).Value = "PLAN DIARIO"
        xlWorkSheet.Cells(27, 1).Value = "PLAN DEL DIA"

        Dim iniColTiendas As Integer = 2
        Dim col As Integer = iniColTiendas

        For i = 0 To _lstZona.Count - 1
            Dim local_i As Integer
            local_i = i
            Dim lstSucursal As List(Of Sucursal) = _lstSucursal.FindAll(Function(x) x.IdZona = _lstZona.Item(local_i).IdZona)

            For j = 0 To lstSucursal.Count - 1
                'col TIENDA - row PLAN AL DIA
                xlWorkSheet.Cells(24, col).Formula = "=(" & help.ColName(col) & "8/$W$2)*$Y$2"

                'col TIENDA - row DEBE AL PLAN AL DIA DE AYER

                xlWorkSheet.Cells(25, col).Formula = "=(" & help.ColName(col) & "24-" & help.ColName(col) & "11)"
                'col TIENDA - PLAN DIARIO
                xlWorkSheet.Cells(26, col).Formula = "=(" & help.ColName(col) & "8/$W$2)"
                'col TIENDA - PLAN DEL DIA
                xlWorkSheet.Cells(27, col, 27, col).Formula = "=IF(" & help.ColName(col) & "25<0," & help.ColName(col) & "26" & ",IF(" & help.ColName(col) & "25>0," & help.ColName(col) & "25+" & help.ColName(col) & "26  ))"

                col = col + 1
            Next
            'col TOTAL ZONA - row PLAN AL DIA
            xlWorkSheet.Cells(24, col).Formula = "=(" & help.ColName(col) & "8/$W$2)*$Y$2"
            'col TOTAL ZONA - row DEBE AL PLAN AL DIA DE AYER
            xlWorkSheet.Cells(25, col).Formula = "=(" & help.ColName(col) & "24-" & help.ColName(col) & "11)"
            'col TOTAL ZONA - row PLAN DIARIO
            xlWorkSheet.Cells(26, col).Formula = "=(" & help.ColName(col) & "8/$W$2)"
            'col TOTAL ZONA - row PLAN DEL DIA
            xlWorkSheet.Cells(27, col, 27, col).Formula = "=IF(" & help.ColName(col) & "25<0," & help.ColName(col) & "26" & ",IF(" & help.ColName(col) & "25>0," & help.ColName(col) & "25+" & help.ColName(col) & "26  ))"
            xlWorkSheet.Cells(27, col, 27, col).Style.Font.Bold = True
            col = col + 1
        Next
        'col SUBTOTALES-----------------------------------------------------------------------------------------------------------
        'col SUBTOTALES - row PLAN AL DIA
        xlWorkSheet.Cells(24, col).Formula = "=(" & help.ColName(col) & "8/$W$2)*$Y$2"
        'col SUBTOTALES - row DEBE AL PLAN AL DIA DE AYER
        xlWorkSheet.Cells(25, col).Formula = "=(" & help.ColName(col) & "24-" & help.ColName(col) & "11)"
        'col SUBTOTALES - row PLAN DIARIO
        xlWorkSheet.Cells(26, col).Formula = "=(" & help.ColName(col) & "8/$W$2)"
        'col SUBTOTALES - row PLAN DEL DIA
        xlWorkSheet.Cells(27, col, 27, col).Formula = "=IF(" & help.ColName(col) & "25<0," & help.ColName(col) & "26" & ",IF(" & help.ColName(col) & "25>0," & help.ColName(col) & "25+" & help.ColName(col) & "26  ))"
        xlWorkSheet.Cells(27, col, 27, col).Style.Font.Bold = True

        col = col + 1

        'col T007-----------------------------------------------------------------------------------------------------------
        'col T007 - row PLAN AL DIA
        xlWorkSheet.Cells(24, col).Value = "0"
        'col T007 - row DEBE AL PLAN AL DIA DE AYER
        xlWorkSheet.Cells(25, col).Value = "0"
        'col T007 - row PLAN DIARIO
        xlWorkSheet.Cells(26, col).Formula = "=(" & help.ColName(col) & "8/$W$2)"
        'col T007 - row PLAN DEL DIA
        xlWorkSheet.Cells(27, col, 27, col).Formula = "=IF(" & help.ColName(col) & "25<0," & help.ColName(col) & "26" & ",IF(" & help.ColName(col) & "25>0," & help.ColName(col) & "25+" & help.ColName(col) & "26  ))"
        xlWorkSheet.Cells(27, col, 27, col).Style.Font.Bold = True

        col = col + 1

        'col TOTAL VAP-----------------------------------------------------------------------------------------------------------
        'col TOTAL VAP - row PLAN AL DIA
        xlWorkSheet.Cells(24, col).Formula = "=(" & help.ColName(col) & "8/$W$2)*$Y$2"
        'col TOTAL VAP - row DEBE AL PLAN AL DIA DE AYER
        xlWorkSheet.Cells(25, col).Formula = "=(" & help.ColName(col) & "24-" & help.ColName(col) & "11)"
        'col TOTAL VAP - row PLAN DIARIO
        xlWorkSheet.Cells(26, col).Formula = "=(" & help.ColName(col) & "8/$W$2)"
        'col TOTAL VAP - row PLAN DEL DIA
        xlWorkSheet.Cells(27, col, 27, col).Formula = "=IF(" & help.ColName(col) & "25<0," & help.ColName(col) & "26" & ",IF(" & help.ColName(col) & "25>0," & help.ColName(col) & "25+" & help.ColName(col) & "26  ))"
        xlWorkSheet.Cells(27, col, 27, col).Style.Font.Bold = True

        '---------------------------------------------------------------------------------------------------------------------------
        'FORMATO CUADRO PLAN AL DIA
        '---------------------------------------------------------------------------------------------------------------------------
        
        Dim xl_range As ExcelRange = xlWorkSheet.Cells(24, 1, 27, col)
        help.SetAllBorders_Thin(xl_range)
        help.SetAllBorders_Medium(xl_range)
        Dim xl_range1 As ExcelRange = xlWorkSheet.Cells(24, 1, 27, 1)
        help.SetAllBorders_Thin(xl_range1)
        help.SetAllBorders_Medium(xl_range1)
        Dim xl_range2 As ExcelRange = xlWorkSheet.Cells(24, 1, 27, col)
        help.SetAllBorders_Thin(xl_range2)
        help.SetAllBorders_Medium(xl_range2)
        Dim xl_range3 As ExcelRange = xlWorkSheet.Cells(24, 1, 24, col)
        help.SetAllBorders_Thin(xl_range3)
        help.SetAllBorders_Medium(xl_range3)

        xlWorkSheet.Cells(24, 1, 27, 1).Style.Font.Bold = True
        xlWorkSheet.Cells(24, 1, 27, 1).Style.Fill.PatternType = ExcelFillStyle.Solid
        xlWorkSheet.Cells(24, 1, 27, 1).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(217, 217, 217))
        xlWorkSheet.Cells(27, 2, 27, col).Style.Fill.PatternType = ExcelFillStyle.Solid
        xlWorkSheet.Cells(27, 2, 27, col).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 153))

        
    End Sub

    Sub GenerarCuadroContribucion()
        Dim xlWorkSheet As ExcelWorksheet
        xlWorkSheet = _xlWorkBook.Worksheets.Item(2) '2: HOJA AVANCE SODIMAC
        xlWorkSheet.Select()

        xlWorkSheet.Cells(29, 1).Value = "CONTRIBUCION"
        xlWorkSheet.Cells(30, 1).Value = "PLAN DE CONTRIBUCION"
        xlWorkSheet.Cells(31, 1).Value = "CONTRIBUCION REAL"
        xlWorkSheet.Cells(32, 1).Value = "DIFERENCIA"

        Dim iniColTiendas As Integer = 2
        Dim col As Integer = iniColTiendas

        For i = 0 To _lstZona.Count - 1
            Dim local_i As Integer
            local_i = i
            Dim lstSucursal As List(Of Sucursal) = _lstSucursal.FindAll(Function(x) x.IdZona = _lstZona.Item(local_i).IdZona)

            For j = 0 To lstSucursal.Count - 1
                'col TIENDA - row PLAN DE CONTRIBUCION
                xlWorkSheet.Cells(30, col).Formula = "=(" & help.ColName(col) & "8*" & help.ColName(col) & "38)"
                'col TIENDA - row CONTRIBUCION REAL
                xlWorkSheet.Cells(31, col).Formula = "=(" & help.ColName(col) & "11*" & help.ColName(col) & "41)"
                'col TIENDA - row DIFERENCIA
                xlWorkSheet.Cells(32, col).Formula = "=(" & help.ColName(col) & "31-" & help.ColName(col) & "30)"
                col = col + 1
            Next
            'col TOTAL ZONA - row PLAN DE CONTRIBUCION
            xlWorkSheet.Cells(30, col).Formula = "=(" & help.ColName(col) & "8*" & help.ColName(col) & "38)"
            'col TOTAL ZONA - row CONTRIBUCION REAL
            xlWorkSheet.Cells(31, col).Formula = "=(" & help.ColName(col) & "11*" & help.ColName(col) & "41)"
            'col TOTAL ZONA - row DIFERENCIA
            xlWorkSheet.Cells(32, col).Formula = "=(" & help.ColName(col) & "31-" & help.ColName(col) & "30)"
            col = col + 1
        Next
        'col SUBTOTALES-----------------------------------------------------------------------------------------------------------
        'col SUBTOTALES - row PLAN DE CONTRIBUCION
        xlWorkSheet.Cells(30, col).Formula = "=(" & help.ColName(col) & "8*" & help.ColName(col) & "38)"
        'col SUBTOTALES - row CONTRIBUCION REAL
        xlWorkSheet.Cells(31, col).Formula = "=(" & help.ColName(col) & "11*" & help.ColName(col) & "41)"
        'col SUBTOTALES - row DIFERENCIA
        xlWorkSheet.Cells(32, col).Formula = "=(" & help.ColName(col) & "31-" & help.ColName(col) & "30)"

        col = col + 1

        'col T007 - row PLAN DE CONTRIBUCION
        xlWorkSheet.Cells(30, col).Formula = "=(" & help.ColName(col) & "8*" & help.ColName(col) & "38)"
        'col T007 - row CONTRIBUCION REAL
        xlWorkSheet.Cells(31, col).Formula = "=(" & help.ColName(col) & "11*" & help.ColName(col) & "41)"
        'col T007 - row DIFERENCIA
        xlWorkSheet.Cells(32, col).Value = "0"

        col = col + 1

        'col TOTAL VAP-----------------------------------------------------------------------------------------------------------
        'col TOTAL VAP - row PLAN DE CONTRIBUCION
        xlWorkSheet.Cells(30, col).Formula = "=(" & help.ColName(col) & "8*" & help.ColName(col) & "38)"
        'col TOTAL VAP - row CONTRIBUCION REAL
        xlWorkSheet.Cells(31, col, 31, col).Formula = "=SUM(" & help.ColName(col - 2) & "31:" & help.ColName(col - 1) & "31)"
        'col TOTAL VAP - row DIFERENCIA
        xlWorkSheet.Cells(32, col, 32, col).Formula = "=SUM(" & help.ColName(col - 2) & "32:" & help.ColName(col - 1) & "32)"

        '---------------------------------------------------------------------------------------------------------------------------
        'FORMATO CUADRO CONTRIBUCION
        '---------------------------------------------------------------------------------------------------------------------------
        
        Dim xl_range As ExcelRange = xlWorkSheet.Cells(30, 1, 32, col)
        help.SetAllBorders_Thin(xl_range)
        Dim xl_range1 As ExcelRange = xlWorkSheet.Cells(30, 1, 32, col)

        help.SetAllBorders_Medium(xl_range1)

        xlWorkSheet.Cells(30, 1, 30, col).Style.Fill.PatternType = ExcelFillStyle.Solid
        xlWorkSheet.Cells(30, 1, 30, col).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(217, 217, 217))
        xlWorkSheet.Cells(32, 2, 32, col).Style.Fill.PatternType = ExcelFillStyle.Solid
        xlWorkSheet.Cells(32, 2, 32, col).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(217, 217, 217))
        xlWorkSheet.Cells(31, col, 31, col).Style.Fill.PatternType = ExcelFillStyle.Solid
        xlWorkSheet.Cells(31, col, 31, col).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(172, 185, 202))
        xlWorkSheet.Cells(29, 1, 29, 1).Style.Font.Bold = True
        xlWorkSheet.Cells(4, 1, 4, 1).Style.Font.Name = "Calibri"
        xlWorkSheet.Cells(4, 1, 4, 1).Style.Font.Size = 24
        xlWorkSheet.Cells(30, 1, 30, col).Style.Font.Bold = True
        xlWorkSheet.Cells(32, 1, 32, col).Style.Font.Bold = True

    End Sub

    Sub GenerarCuadroMargen()
        Dim xlWorkSheet As ExcelWorksheet
        xlWorkSheet = _xlWorkBook.Worksheets.Item(2) '2: HOJA AVANCE SODIMAC
        xlWorkSheet.Select()

        'formato previo celdas
        xlWorkSheet.Cells(38, 1, 38, 1 + _lstSucursal.Count + _lstZona.Count + 3).Style.Numberformat.Format = "0.00%"
        xlWorkSheet.Cells(39, 1, 39, 1 + _lstSucursal.Count + _lstZona.Count + 3).Style.Numberformat.Format = "0.00%"
        xlWorkSheet.Cells(40, 1, 40, 1 + _lstSucursal.Count + _lstZona.Count + 3).Style.Numberformat.Format = "0.00%"
        xlWorkSheet.Cells(41, 1, 41, 1 + _lstSucursal.Count + _lstZona.Count + 3).Style.Numberformat.Format = "0.00%"
        xlWorkSheet.Cells(42, 1, 42, 1 + _lstSucursal.Count + _lstZona.Count + 3).Style.Numberformat.Format = "0.00%"

        xlWorkSheet.Cells(34, 1).Value = "MARGEN"
        xlWorkSheet.Cells(34, 1, 34, 1).Style.Font.Name = "Calibri"
        xlWorkSheet.Cells(34, 1, 34, 1).Style.Font.Size = 24

        xlWorkSheet.Cells(35, 1).Value = "MARGEN NETO"
        xlWorkSheet.Cells(35, 1, 37, 1).Merge = True
        xlWorkSheet.Cells(35, 1, 35, 1).Style.VerticalAlignment = ExcelVerticalAlignment.Center
        xlWorkSheet.Cells(35, 1, 35, 1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center

        xlWorkSheet.Cells(38, 1).Value = "PLAN MARGEN NETO VENTA EMPRESA"
        xlWorkSheet.Cells(39, 1).Value = "MARGEN NETO CONTADO"
        xlWorkSheet.Cells(40, 1).Value = "MARGEN NETO CRÉDITO"
        xlWorkSheet.Cells(41, 1).Value = "MARGEN NETO TOTAL"
        xlWorkSheet.Cells(42, 1).Value = "DIFERENCIA MARGEN NETO"

        Dim iniColTiendas As Integer = 2
        Dim col As Integer = iniColTiendas

        For i = 0 To _lstZona.Count - 1
            Dim local_i As Integer
            local_i = i
            Dim lstSucursal As List(Of Sucursal) = _lstSucursal.FindAll(Function(x) x.IdZona = _lstZona.Item(local_i).IdZona)
            For j = 0 To lstSucursal.Count - 1
                xlWorkSheet.Cells(36, col).Value = (lstSucursal(j)).CodigoSucursal
                xlWorkSheet.Cells(37, col).Value = (lstSucursal(j)).Descripcion.ToUpper
                xlWorkSheet.Cells(37, col, 37, col).Style.Font.Bold = True
                'row PLAN MARGEN NETO VENTA EMPRESA
                xlWorkSheet.Cells(38, col).Value = (New ReporteBusinessLogic()).SelPlanMargenPorTienda(_FechaFinRep, _IdMarca)
                'row MARGEN NETO CONTADO
                xlWorkSheet.Cells(39, col).Value = (New ReporteBusinessLogic()).SelMargenNetoContadoPorTienda(_FechaIniRep, _FechaFinRep, (lstSucursal(j)).IdSucursal)
                'row MARGEN NETO CRÉDITO
                xlWorkSheet.Cells(40, col).Value = (New ReporteBusinessLogic()).SelMargenNetoCreditoPorTienda(_FechaIniRep, _FechaFinRep, (lstSucursal(j)).IdSucursal)
                'row MARGEN NETO TOTAL
                xlWorkSheet.Cells(41, col).Value = (New ReporteBusinessLogic()).SelMargenNetoTotalPorTienda(_FechaIniRep, _FechaFinRep, (lstSucursal(j)).IdSucursal)
                'row DIFERENCIA MARGEN NETO
                '"=(" & help.ColName(col) & "11/" & help.ColName(col) & "8)"
                xlWorkSheet.Cells(42, col).Formula = "=" & help.ColName(col) & "41-" & help.ColName(col) & "38"
                col = col + 1
            Next

           

            'Merge para el nombre de la zona
            
            xlWorkSheet.Cells(35, col - lstSucursal.Count).Value = (_lstZona(i)).NombreZona
            xlWorkSheet.Cells(35, col - lstSucursal.Count, 35, col).Merge = True
            xlWorkSheet.Cells(35, col - lstSucursal.Count, 35, col).Style.Font.Bold = True
            xlWorkSheet.Cells(35, col - lstSucursal.Count, 35, col).Style.WrapText = True

            'col TOTAL ZONA----------------------------------------------------------------------------------------
            xlWorkSheet.Cells(36, col).Value = (_lstZona(i)).NombreZona.Replace("ZONA", "TOTAL")
            'nueva linea
            xlWorkSheet.Cells(36, col, 37, col).Merge = True
            xlWorkSheet.Cells(36, col, 37, col).Style.Font.Bold = True
            xlWorkSheet.Cells(36, col, 37, col).Style.WrapText = True
            xlWorkSheet.Cells(36, col, 37, col).Style.VerticalAlignment = ExcelVerticalAlignment.Center

            'col TOTAL ZONA - row PLAN MARGEN NETO VENTA EMPRESA
            xlWorkSheet.Cells(38, col).Value = 0.0
            

            xlWorkSheet.Cells(39, col, 39, col).Value = (New ReporteBusinessLogic()).SelMargenNetoContadoPorZona(_FechaIniRep, _FechaFinRep, (lstSucursal(i)).IdZona)
            'End If


            'col TOTAL ZONA - row MARGEN NETO CRÉDITO

            xlWorkSheet.Cells(40, col).Value = (New ReporteBusinessLogic()).SelMargenNetoCreditoPorZona(_FechaIniRep, _FechaFinRep, (lstSucursal(i)).IdZona)
            'col TOTAL ZONA - row MARGEN NETO TOTAL
            xlWorkSheet.Cells(41, col).Value = (New ReporteBusinessLogic()).SelMargenNetoTotalPorZona(_FechaIniRep, _FechaFinRep, (lstSucursal(i)).IdZona)
            'col TOTAL ZONA - row DIFERENCIA MARGEN NETO
            xlWorkSheet.Cells(42, col).Formula = "=" & help.ColName(col) & "41-" & help.ColName(col) & "38"


            col = col + 1

        Next
        'col SUBTOTALES-------------------------------------------------------------------------------------------------------------
        xlWorkSheet.Cells(36, col).Value = "SUBTOTALES"
        'nueva linea
        xlWorkSheet.Cells(36, col, 37, col).Merge = True
        xlWorkSheet.Cells(36, col, 42, col).Style.Fill.PatternType = ExcelFillStyle.Solid
        xlWorkSheet.Cells(36, col, 42, col).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(217, 217, 217))
        'col SUBTOTALES - row PLAN MARGEN NETO VENTA EMPRESA
        xlWorkSheet.Cells(38, col).Value = 0.0
        'col SUBTOTALES - row MARGEN NETO CONTADO
        xlWorkSheet.Cells(39, col, 39, col).Value = (New ReporteBusinessLogic()).SelMargenTotalContado(_FechaIniRep, _FechaFinRep)

        'col SUBTOTALES - row MARGEN NETO CRÉDITO
        xlWorkSheet.Cells(40, col).Value = (New ReporteBusinessLogic()).SelMargenTotalCredito(_FechaIniRep, _FechaFinRep)

        'col SUBTOTALES - row MARGEN NETO TOTAL
        xlWorkSheet.Cells(41, col).Value = (New ReporteBusinessLogic()).SelMargenNetoTotal(_FechaIniRep, _FechaFinRep)
        'col SUBTOTALES - row DIFERENCIA MARGEN NETO
        xlWorkSheet.Cells(42, col, 42, col).Formula = "=" & help.ColName(col) & "41-" & help.ColName(col) & "38"


        col = col + 1

        'col T007-----------------------------------------------------------------------------------------------------------
        'nueva linea

        xlWorkSheet.Cells(36, col).Value = "T007"
        xlWorkSheet.Cells(36, col, 37, col).Merge = True
        'col T007 - row PLAN MARGEN NETO VENTA EMPRESA
        xlWorkSheet.Cells(38, col).Value = (New ReporteBusinessLogic()).SelPlanMargenPorTienda(_FechaFinRep, _IdMarca)
        'col T007 - row MARGEN NETO CONTADO

        xlWorkSheet.Cells(39, col).Value = 0.0
        'col T007 - row MARGEN NETO CRÉDITO
        xlWorkSheet.Cells(40, col).Value = 0.0
        'col T007 - row MARGEN NETO TOTAL
        xlWorkSheet.Cells(41, col).Value = 0.0
        'col T007 - row DIFERENCIA MARGEN NETO
        xlWorkSheet.Cells(42, col).Value = 0.0

        col = col + 1

        'col TOTAL VAP-----------------------------------------------------------------------------------------------------------
        xlWorkSheet.Cells(36, col).Value = "TOTAL VAP"
        'nueva linea
        xlWorkSheet.Cells(36, col, 37, col).Merge = True
        'col TOTAL VAP - row PLAN MARGEN NETO VENTA EMPRESA
        xlWorkSheet.Cells(38, col).Value = 0.0
        'col TOTAL VAP - row MARGEN NETO CONTADO
        xlWorkSheet.Cells(39, col, 39, col).Value = (New ReporteBusinessLogic()).SelMargenTotalContado(_FechaIniRep, _FechaFinRep)
        'xlWorkSheet.Cells(39, col).Value = 0.0

        'col TOTAL VAP - row MARGEN NETO CRÉDITO
        xlWorkSheet.Cells(40, col, 40, col).Value = (New ReporteBusinessLogic()).SelMargenTotalCredito(_FechaIniRep, _FechaFinRep)
        'xlWorkSheet.Cells(40, col).Value = 0.0
        'col TOTAL VAP - row MARGEN NETO TOTAL
        xlWorkSheet.Cells(41, col, 41, col).Value = (New ReporteBusinessLogic()).SelMargenNetoTotal(_FechaIniRep, _FechaFinRep)
        'col TOTAL VAP - row DIFERENCIA MARGEN NETO
        xlWorkSheet.Cells(42, col, 42, col).Formula = "=" & help.ColName(col) & "41-" & help.ColName(col) & "38"
        ' xlWorkSheet.Cells(42, col).Value = 0.0

        '---------------------------------------------------------------------------------------------------------------------------
        'FORMATO CUADRO MARGEN
        '---------------------------------------------------------------------------------------------------------------------------
        xlWorkSheet.Cells(34, 1, 34, 1).Style.Font.Bold = True
        xlWorkSheet.Cells(35, 1, 38, col).Style.Fill.PatternType = ExcelFillStyle.Solid
        xlWorkSheet.Cells(35, 1, 38, col).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(217, 217, 217))
        xlWorkSheet.Cells(41, 1, 42, col).Style.Fill.PatternType = ExcelFillStyle.Solid
        xlWorkSheet.Cells(41, 1, 42, col).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(217, 217, 217))
        xlWorkSheet.Cells(38, 1, 38, col).Style.Font.Bold = True
        xlWorkSheet.Cells(41, 1, 41, col).Style.Font.Bold = True
        xlWorkSheet.Cells(42, 1, 42, col).Style.Font.Bold = True

        Dim xl_range As ExcelRange = xlWorkSheet.Cells(35, 1, 42, col)
        help.SetAllBorders_Thin(xl_range)
        help.SetAllBorders_Medium(xl_range)

        Dim xl_range1 As ExcelRange = xlWorkSheet.Cells(35, 2, 35, col)
        help.SetAllBorders_Thin(xl_range1)
        help.SetAllBorders_Medium(xl_range1)

        Dim xl_range2 As ExcelRange = xlWorkSheet.Cells(35, 1, 42, 1)
        help.SetAllBorders_Thin(xl_range2)
        help.SetAllBorders_Medium(xl_range2)

        Dim xl_range3 As ExcelRange = xlWorkSheet.Cells(41, 1, 41, col)
        help.SetAllBorders_Thin(xl_range3)
        help.SetAllBorders_Medium(xl_range3)

        Dim xl_range4 As ExcelRange = xlWorkSheet.Cells(42, 1, 42, col)
        help.SetAllBorders_Thin(xl_range4)
        help.SetAllBorders_Medium(xl_range4)

    End Sub

    Sub GenerarCuadroTransacciones()
        Dim xlWorkSheet As ExcelWorksheet
        xlWorkSheet = _xlWorkBook.Worksheets.Item(2) '2: HOJA AVANCE SODIMAC
        xlWorkSheet.Select()

        xlWorkSheet.Cells(44, 1).Value = "TRANSACCIONES"
        xlWorkSheet.Cells(44, 1, 44, 1).Style.Font.Name = "Calibri"
        xlWorkSheet.Cells(44, 1, 44, 1).Style.Font.Size = 24
        xlWorkSheet.Cells(44, 1, 44, 1).Style.Font.Bold = True

        xlWorkSheet.Cells(45, 1).Value = "NÚMERO DE TRANSACCIONES"
        'nueva linea
        xlWorkSheet.Cells(45, 1, 47, 1).Merge = True
        xlWorkSheet.Cells(45, 1, 45, 1).Style.VerticalAlignment = ExcelVerticalAlignment.Center
        xlWorkSheet.Cells(45, 1, 45, 1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center

        'formato previo celdas
    

        xlWorkSheet.Cells(48, 1).Value = "TRANSACCIONES VENTA CONTADO"
        xlWorkSheet.Cells(49, 1).Value = "TRANSACCIONES VENTA CREDITO"
        xlWorkSheet.Cells(50, 1).Value = "TRANSACCIONES VENTA TOTAL"

        Dim iniColTiendas As Integer = 2
        Dim col As Integer = iniColTiendas
        Dim FormulaSubTotales_TranVentaContado As String = "=SUM("
        Dim FormulaSubTotales_TranVentaCredito As String = "=SUM("
        Dim FormulaSubTotales_TranVentaTotal As String = "=SUM("

        For i = 0 To _lstZona.Count - 1
            Dim local_i As Integer
            local_i = i
            Dim lstSucursal As List(Of Sucursal) = _lstSucursal.FindAll(Function(x) x.IdZona = _lstZona.Item(local_i).IdZona)

            For j = 0 To lstSucursal.Count - 1
                xlWorkSheet.Cells(46, col).Value = (lstSucursal(j)).CodigoSucursal
                xlWorkSheet.Cells(47, col).Value = (lstSucursal(j)).Descripcion.ToUpper
                'row TRANSACCIONES VENTA CONTADO
                xlWorkSheet.Cells(48, col).Value = (New ReporteBusinessLogic()).SelTransacVentaContadoPorTienda(_FechaIniRep, _FechaFinRep, (lstSucursal(j)).IdSucursal)
                'row TRANSACCIONES VENTA CREDITO
                xlWorkSheet.Cells(49, col).Value = (New ReporteBusinessLogic()).SelTransacVentaCreditoPorTienda(_FechaIniRep, _FechaFinRep, (lstSucursal(j)).IdSucursal)
                'row TRANSACCIONES VENTA TOTAL
                xlWorkSheet.Cells(50, col, 50, col).Formula = "=SUM(" & help.ColName(col) & "48:" & help.ColName(col) & "49)"
                col = col + 1
            Next

            'Merge para el nombre de la zona
            xlWorkSheet.Cells(45, col - lstSucursal.Count).Value = (_lstZona(i)).NombreZona
            'nueva linea
            xlWorkSheet.Cells(45, col - lstSucursal.Count, 45, col).Merge = True
            xlWorkSheet.Cells(45, col - lstSucursal.Count, 45, col).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
            xlWorkSheet.Cells(45, col - lstSucursal.Count, 45, col).Style.Font.Bold = True
            'col TOTAL ZONA
            xlWorkSheet.Cells(46, col).Value = (_lstZona(i)).NombreZona.Replace("ZONA", "TOTAL")
            'nueva linea
            xlWorkSheet.Cells(46, col, 47, col).Merge = True
            xlWorkSheet.Cells(46, col, 47, col).Style.Font.Bold = True
            xlWorkSheet.Cells(46, col, 47, col).Style.WrapText = True
            xlWorkSheet.Cells(46, col, 47, col).Style.VerticalAlignment = ExcelVerticalAlignment.Center

            'col TOTAL ZONA - TRANSACCIONES VENTA CONTADO
            xlWorkSheet.Cells(48, col, 48, col).Formula = "=SUM(" & help.ColName(col - lstSucursal.Count) & "48:" & help.ColName(col - 1) & "48)"
            xlWorkSheet.Cells(48, col, 48, col).Style.Font.Bold = True
            'col TOTAL ZONA - TRANSACCIONES VENTA CREDITO
            xlWorkSheet.Cells(49, col, 49, col).Formula = "=SUM(" & help.ColName(col - lstSucursal.Count) & "49:" & help.ColName(col - 1) & "49)"
            xlWorkSheet.Cells(49, col, 49, col).Style.Font.Bold = True
            'col TOTAL ZONA - TRANSACCIONES VENTA TOTAL
            xlWorkSheet.Cells(50, col, 50, col).Formula = "=SUM(" & help.ColName(col - lstSucursal.Count) & "50:" & help.ColName(col - 1) & "50)"
            If (i = 0) Then
                FormulaSubTotales_TranVentaContado = FormulaSubTotales_TranVentaContado & help.ColName(iniColTiendas + lstSucursal.Count) & 48
                FormulaSubTotales_TranVentaCredito = FormulaSubTotales_TranVentaCredito & help.ColName(iniColTiendas + lstSucursal.Count) & 49
                FormulaSubTotales_TranVentaTotal = FormulaSubTotales_TranVentaTotal & help.ColName(iniColTiendas + lstSucursal.Count) & 50
            Else
                FormulaSubTotales_TranVentaContado = FormulaSubTotales_TranVentaContado & "+" & help.ColName(col) & 48
                FormulaSubTotales_TranVentaCredito = FormulaSubTotales_TranVentaCredito & "+" & help.ColName(col) & 49
                FormulaSubTotales_TranVentaTotal = FormulaSubTotales_TranVentaTotal & "+" & help.ColName(col) & 50
            End If
            col = col + 1
        Next
        FormulaSubTotales_TranVentaContado = FormulaSubTotales_TranVentaContado & ")"
        FormulaSubTotales_TranVentaCredito = FormulaSubTotales_TranVentaCredito & ")"
        FormulaSubTotales_TranVentaTotal = FormulaSubTotales_TranVentaTotal & ")"

        'col SUBTOTALES-----------------------------------------------------------------------------------------------------------
        xlWorkSheet.Cells(46, col).Value = "SUBTOTALES"
        'nueva linea
        xlWorkSheet.Cells(46, col, 47, col).Merge = True
        'col SUBTOTALES - row TRANSACCIONES VENTA CONTADO
        xlWorkSheet.Cells(48, col, 48, col).Formula = FormulaSubTotales_TranVentaContado
        xlWorkSheet.Cells(48, col, 48, col).Style.Font.Bold = True
        'col SUBTOTALES - row TRANSACCIONES VENTA CREDITO
        xlWorkSheet.Cells(49, col, 49, col).Formula = FormulaSubTotales_TranVentaCredito
        xlWorkSheet.Cells(49, col, 49, col).Style.Font.Bold = True
        'col SUBTOTALES - row TRANSACCIONES VENTA TOTAL
        xlWorkSheet.Cells(50, col, 50, col).Formula = FormulaSubTotales_TranVentaTotal

        col = col + 1

        'col T007-----------------------------------------------------------------------------------------------------------
        xlWorkSheet.Cells(46, col).Value = "T007"
        'nueva linea
        xlWorkSheet.Cells(45, col, 45, col).Merge = True

        
        xlWorkSheet.Cells(47, col).Value = "VENTA EMPRESA"
        'row TRANSACCIONES VENTA CONTADO
        xlWorkSheet.Cells(48, col).Value = (New ReporteBusinessLogic()).SelTransacVentaContadoPorTienda(_FechaIniRep, _FechaFinRep, 31)
        xlWorkSheet.Cells(48, col, 48, col).Style.Font.Bold = True
        'row TRANSACCIONES VENTA CREDITO
        xlWorkSheet.Cells(49, col).Value = (New ReporteBusinessLogic()).SelTransacVentaCreditoPorTienda(_FechaIniRep, _FechaFinRep, 31)
        xlWorkSheet.Cells(49, col, 49, col).Style.Font.Bold = True
        'row TRANSACCIONES VENTA TOTAL
        xlWorkSheet.Cells(50, col, 50, col).Formula = "=SUM(" & help.ColName(col) & "48:" & help.ColName(col) & "49)"

        col = col + 1

        'col TOTAL VAP-----------------------------------------------------------------------------------------------------------
        xlWorkSheet.Cells(46, col).Value = "TOTAL VAP"
        'nueva linea
        xlWorkSheet.Cells(46, col, 47, col).Merge = True
        'col TOTAL VAP - TRANSACCIONES VENTA CONTADO
        xlWorkSheet.Cells(48, col, 48, col).Formula = "=" & help.ColName(col - 2) & "48+" & help.ColName(col - 1) & "48"
        xlWorkSheet.Cells(48, col, 48, col).Style.Font.Bold = True
        'col TOTAL VAP - TRANSACCIONES VENTA CREDITO
        xlWorkSheet.Cells(49, col, 49, col).Formula = "=" & help.ColName(col - 2) & "49+" & help.ColName(col - 1) & "49"
        xlWorkSheet.Cells(49, col, 49, col).Style.Font.Bold = True
        'col TOTAL VAP - TRANSACCIONES VENTA TOTAL
        xlWorkSheet.Cells(50, col, 50, col).Formula = "=" & help.ColName(col - 2) & "50+" & help.ColName(col - 1) & "50"

        '---------------------------------------------------------------------------------------------------------------------------
        'FORMATO CUADRO TRANSACCIONES
        '---------------------------------------------------------------------------------------------------------------------------
      

        Dim xl_range As ExcelRange = xlWorkSheet.Cells(45, 2, 45, col)
        help.SetAllBorders_Thin(xl_range)
        help.SetAllBorders_Medium(xl_range)

        Dim xl_range1 As ExcelRange = xlWorkSheet.Cells(48, 1, 48, col)
        help.SetAllBorders_Thin(xl_range1)
        help.SetAllBorders_Medium(xl_range1)

        Dim xl_range2 As ExcelRange = xlWorkSheet.Cells(49, 1, 49, col)
        help.SetAllBorders_Thin(xl_range2)
        help.SetAllBorders_Medium(xl_range2)

        Dim xl_range3 As ExcelRange = xlWorkSheet.Cells(45, 1, 50, col)
        help.SetAllBorders_Thin(xl_range3)
        help.SetAllBorders_Medium(xl_range3)

        Dim xl_range4 As ExcelRange = xlWorkSheet.Cells(45, 1, 47, 1)
        help.SetAllBorders_Thin(xl_range4)
        help.SetAllBorders_Medium(xl_range4)

        xlWorkSheet.Cells(45, 1, 47, col).Style.Fill.PatternType = ExcelFillStyle.Solid
        xlWorkSheet.Cells(45, 1, 47, col).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(217, 217, 217))
        xlWorkSheet.Cells(50, 1, 50, col).Style.Fill.PatternType = ExcelFillStyle.Solid
        xlWorkSheet.Cells(50, 1, 50, col).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(217, 217, 217))
        xlWorkSheet.Cells(50, 1, 50, col).Style.Font.Bold = True
    End Sub

    Sub GenerarTicketPromedio()
        Dim xlWorkSheet As ExcelWorksheet
        xlWorkSheet = _xlWorkBook.Worksheets.Item(2) '2: HOJA AVANCE SODIMAC
        xlWorkSheet.Select()

        xlWorkSheet.Cells(52, 1).Value = "TICKET PROMEDIO"
        xlWorkSheet.Cells(52, 1, 52, 1).Style.Font.Name = "Calibri"
        xlWorkSheet.Cells(52, 1, 52, 1).Style.Font.Size = 24
        xlWorkSheet.Cells(52, 1, 52, 1).Style.Font.Bold = True

        xlWorkSheet.Cells(53, 1).Value = "TICKET PROMEDIO"
        'nueva linea
        xlWorkSheet.Cells(53, 1, 55, 1).Merge = True
        xlWorkSheet.Cells(53, 1, 53, 1).Style.VerticalAlignment = ExcelVerticalAlignment.Center
        xlWorkSheet.Cells(53, 1, 53, 1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center

        'formato previo celdas


        xlWorkSheet.Cells(56, 1).Value = "TICKET PROMEDIO VENTA CONTADO"
        xlWorkSheet.Cells(57, 1).Value = "TICKET PROMEDIO VENTA CREDITO"
        xlWorkSheet.Cells(58, 1).Value = "TICKET PROMEDIO TOTAL"

        Dim iniColTiendas As Integer = 2
        Dim col As Integer = iniColTiendas

        For i = 0 To _lstZona.Count - 1
            Dim local_i As Integer = i
            Dim lstSucursal As List(Of Sucursal) = _lstSucursal.FindAll(Function(x) x.IdZona = _lstZona.Item(local_i).IdZona)
            For j = 0 To lstSucursal.Count - 1
                xlWorkSheet.Cells(54, col).Value = (lstSucursal(j)).CodigoSucursal
                xlWorkSheet.Cells(55, col).Value = (lstSucursal(j)).Descripcion.ToUpper
                'row TICKET PROMEDIO VENTA CONTADO
                xlWorkSheet.Cells(56, col, 56, col).Formula = "=IF(" & help.ColName(col) & "48=0,0," & help.ColName(col) & "9/" & help.ColName(col) & "48)"
                'row TICKET PROMEDIO VENTA CREDITO
                xlWorkSheet.Cells(57, col, 57, col).Formula = "=IF(" & help.ColName(col) & "49=0,0," & help.ColName(col) & "10/" & help.ColName(col) & "49)"
                'row TICKET PROMEDIO VENTA TOTAL
                xlWorkSheet.Cells(58, col, 58, col).Formula = "=IF(" & help.ColName(col) & "50=0,0," & help.ColName(col) & "11/" & help.ColName(col) & "50)"
                col = col + 1
            Next

            'Merge para el nombre de la zona
            xlWorkSheet.Cells(53, col - lstSucursal.Count).Value = (_lstZona(i)).NombreZona
            xlWorkSheet.Cells(53, col - lstSucursal.Count, 53, col).Merge = True
            'xlWorkSheet.Cells(53, col - lstSucursal.Count, 53, col).Merge = True
            xlWorkSheet.Cells(53, col - lstSucursal.Count, 53, col).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
            xlWorkSheet.Cells(53, col - lstSucursal.Count, 53, col).Style.Font.Bold = True

            'col TOTAL ZONA
            xlWorkSheet.Cells(54, col).Value = (_lstZona(i)).NombreZona.Replace("ZONA", "TOTAL")
            'xlWorkSheet.Cells(54, col, 55, col).Merge = True
            xlWorkSheet.Cells(54, col, 55, col).Style.Font.Bold = True
            xlWorkSheet.Cells(54, col, 55, col).Style.WrapText = True
            xlWorkSheet.Cells(54, col, 55, col).Style.VerticalAlignment = ExcelVerticalAlignment.Center
            'help.SetBordesCeldas_Medium(xlWorkSheet.Cells(54, col, 58, col)))
            'col TOTAL ZONA - row TICKET PROMEDIO VENTA CONTADO
            xlWorkSheet.Cells(56, col, 56, col).Formula = "=IF(" & help.ColName(col) & "48=0,0," & help.ColName(col) & "9/" & help.ColName(col) & "48)"
            'col TOTAL ZONA - row TICKET PROMEDIO VENTA CREDITO
            xlWorkSheet.Cells(57, col, 57, col).Formula = "=IF(" & help.ColName(col) & "49=0,0," & help.ColName(col) & "10/" & help.ColName(col) & "49)"
            'col TOTAL ZONA - row TICKET PROMEDIO VENTA TOTAL
            xlWorkSheet.Cells(58, col, 58, col).Formula = "=IF(" & help.ColName(col) & "50=0,0," & help.ColName(col) & "11/" & help.ColName(col) & "50)"
            col = col + 1
        Next
        'col SUBTOTALES
        xlWorkSheet.Cells(54, col).Value = "SUBTOTALES"
        'xlWorkSheet.Cells(54, col, 55, col).Merge = True
        'col SUBTOTALES - row TICKET PROMEDIO VENTA CONTADO 
        xlWorkSheet.Cells(56, col, 56, col).Formula = "=IF(" & help.ColName(col) & "48=0,0," & help.ColName(col) & "9/" & help.ColName(col) & "48)"
        'col SUBTOTALES - row TICKET PROMEDIO VENTA CREDITO
        xlWorkSheet.Cells(57, col, 57, col).Formula = "=IF(" & help.ColName(col) & "49=0,0," & help.ColName(col) & "10/" & help.ColName(col) & "49)"
        'col SUBTOTALES - row TICKET PROMEDIO VENTA TOTAL
        xlWorkSheet.Cells(58, col, 58, col).Formula = "=IF(" & help.ColName(col) & "50=0,0," & help.ColName(col) & "11/" & help.ColName(col) & "50)"

        col = col + 1

        'col T007-----------------------------------------------------------------------------------------------------------
        xlWorkSheet.Cells(54, col).Value = "T007"
        'xlWorkSheet.Cells(53, col - 2, 53, col).Merge = True
        'help.SetAllBorders_Medium(xlWorkSheet.Cells(54, col, 58, col)))

        xlWorkSheet.Cells(55, col).Value = "VENTA EMPRESA"
        'col T007 - row TICKET PROMEDIO VENTA CONTADO
        xlWorkSheet.Cells(56, col, 56, col).Formula = "=IF(" & help.ColName(col) & "48=0,0," & help.ColName(col) & "9/" & help.ColName(col) & "48)"
        'col T007 - row TICKET PROMEDIO VENTA CREDITO
        xlWorkSheet.Cells(57, col, 57, col).Formula = "=IF(" & help.ColName(col) & "49=0,0," & help.ColName(col) & "10/" & help.ColName(col) & "49)"
        'col T007 - row TICKET PROMEDIO VENTA TOTAL
        xlWorkSheet.Cells(58, col, 58, col).Formula = "=IF(" & help.ColName(col) & "50=0,0," & help.ColName(col) & "11/" & help.ColName(col) & "50)"

        col = col + 1

        'col TOTAL VAP-----------------------------------------------------------------------------------------------------------
        xlWorkSheet.Cells(54, col).Value = "TOTAL VAP"
        'xlWorkSheet.Cells(54, col, 55, col).Merge = True
        'col TOTAL - row TICKET PROMEDIO VENTA CONTADO
        xlWorkSheet.Cells(56, col, 56, col).Formula = "=IF(" & help.ColName(col) & "48=0,0," & help.ColName(col) & "9/" & help.ColName(col) & "48)"
        'col TOTAL - row TICKET PROMEDIO VENTA CREDITO
        xlWorkSheet.Cells(57, col, 57, col).Formula = "=IF(" & help.ColName(col) & "49=0,0," & help.ColName(col) & "10/" & help.ColName(col) & "49)"
        'col TOTAL - row TICKET PROMEDIO VENTA TOTAL
        xlWorkSheet.Cells(58, col, 58, col).Formula = "=IF(" & help.ColName(col) & "50=0,0," & help.ColName(col) & "11/" & help.ColName(col) & "50)"

        '---------------------------------------------------------------------------------------------------------------------------
        'FORMATO CUADRO TICKET PROMEDIO
        '---------------------------------------------------------------------------------------------------------------------------


        Dim xl_range As ExcelRange = xlWorkSheet.Cells(53, 2, 53, col)
        help.SetAllBorders_Thin(xl_range)
        help.SetAllBorders_Medium(xl_range)

        Dim xl_range1 As ExcelRange = xlWorkSheet.Cells(56, 1, 56, col)
        help.SetAllBorders_Thin(xl_range1)
        help.SetAllBorders_Medium(xl_range1)

        Dim xl_range2 As ExcelRange = xlWorkSheet.Cells(57, 1, 57, col)
        help.SetAllBorders_Thin(xl_range2)
        help.SetAllBorders_Medium(xl_range2)

        Dim xl_range3 As ExcelRange = xlWorkSheet.Cells(53, 1, 58, col)
        help.SetAllBorders_Thin(xl_range3)
        help.SetAllBorders_Medium(xl_range3)

        Dim xl_range4 As ExcelRange = xlWorkSheet.Cells(53, 1, 53, 1)
        help.SetAllBorders_Thin(xl_range4)
        help.SetAllBorders_Medium(xl_range4)

        xlWorkSheet.Cells(53, 1, 55, col).Style.Fill.PatternType = ExcelFillStyle.Solid
        xlWorkSheet.Cells(53, 1, 55, col).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(217, 217, 217))
        xlWorkSheet.Cells(58, 1, 58, col).Style.Fill.PatternType = ExcelFillStyle.Solid
        xlWorkSheet.Cells(58, 1, 58, col).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(217, 217, 217))
        xlWorkSheet.Cells(58, 1, 58, col).Style.Font.Bold = True
    End Sub

End Class
