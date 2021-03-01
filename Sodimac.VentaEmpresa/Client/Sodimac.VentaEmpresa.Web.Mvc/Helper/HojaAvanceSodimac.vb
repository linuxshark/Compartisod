Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports Microsoft.Office.Interop.Excel
Imports System.Runtime.InteropServices
Imports Sodimac.VentaEmpresa.BusinessLogic
Imports Sodimac.VentaEmpresa.DataContracts

Public Class HojaAvanceSodimac

    Dim _xlWorkBook As Workbook
    Dim _FechaIniRep As Date
    Dim _FechaFinRep As Date
    Dim _lstZona As List(Of Zona)
    Dim _lstSucursal As List(Of Sucursal)
    Dim _IdMarca As Integer

    Dim help As New HelperReporteVE

    Sub New(xlWorkBook As Workbook, fechaInicio As Date, fechaFin As Date, lstZona As List(Of Zona), lstSucursal As List(Of Sucursal), IdMarca As Integer)
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
        Dim xlWorkSheet As New Worksheet
        xlWorkSheet = _xlWorkBook.Worksheets.Item(2) '2: HOJA AVANCE SODIMAC
        xlWorkSheet.Select()

        xlWorkSheet.Columns("A").AutoFit()

        xlWorkSheet.Cells(1, 1) = "VENTA EMPRESAS " + (New HelperReporteVE).getNombreMes(_FechaFinRep.Month).ToUpper() + " " + _FechaFinRep.Year.ToString()
        xlWorkSheet.Range(xlWorkSheet.Cells(1, 1), xlWorkSheet.Cells(1, 1000)).Interior.Color = RGB(244, 176, 132)
        xlWorkSheet.Range(xlWorkSheet.Cells(1, 1), xlWorkSheet.Cells(1, 1)).Font.Color = RGB(255, 255, 255)
        xlWorkSheet.Range(xlWorkSheet.Cells(1, 1), xlWorkSheet.Cells(1, 1)).Font.Name = "Arial Black"
        xlWorkSheet.Range(xlWorkSheet.Cells(1, 1), xlWorkSheet.Cells(1, 1)).Font.Size = 36
        xlWorkSheet.Range(xlWorkSheet.Cells(1, 1), xlWorkSheet.Cells(1, 1)).Font.Bold = True
        xlWorkSheet.Range(xlWorkSheet.Cells(1, 1), xlWorkSheet.Cells(1, 1)).Font.Underline = True

        Marshal.ReleaseComObject(xlWorkSheet)
    End Sub

    Sub formatoPrevio()
        Dim xlWorkSheet As New Worksheet
        xlWorkSheet = _xlWorkBook.Worksheets.Item(2) '2: HOJA AVANCE SODIMAC
        xlWorkSheet.Select()
        _xlWorkBook.Windows(1).Zoom = 50

        'Formato General Texto para la hoja
        xlWorkSheet.Range(xlWorkSheet.Cells(1, 1), xlWorkSheet.Cells(200, 200)).Font.Name = "Calibri"
        xlWorkSheet.Range(xlWorkSheet.Cells(1, 1), xlWorkSheet.Cells(200, 200)).Font.Size = 20

        'Formato numeros
        xlWorkSheet.Range(xlWorkSheet.Cells(8, 2), xlWorkSheet.Cells(200, 200)).NumberFormat = "#,##0"

        'Alineamiento para la hoja
        xlWorkSheet.Range(xlWorkSheet.Cells(5, 2), xlWorkSheet.Cells(200, 200)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

        'Ancho columnas
        xlWorkSheet.Range(xlWorkSheet.Cells(5, 2), xlWorkSheet.Cells(200, 200)).ColumnWidth = 35

        'Freeze panels
        xlWorkSheet.Range(xlWorkSheet.Cells(8, 2), xlWorkSheet.Cells(8, 2)).Select()
        _xlWorkBook.Windows(1).FreezePanes = True



        Marshal.ReleaseComObject(xlWorkSheet)
    End Sub

    Sub GenerarCabecera()
        Dim xlWorkSheet As New Worksheet
        xlWorkSheet = _xlWorkBook.Worksheets.Item(2) '2: HOJA AVANCE SODIMAC
        xlWorkSheet.Select()

        xlWorkSheet.Cells(2, 1) = "PROYECTADO:"
        xlWorkSheet.Range(xlWorkSheet.Cells(2, 1), xlWorkSheet.Cells(2, 1)).Font.Name = "Arial"
        xlWorkSheet.Range(xlWorkSheet.Cells(2, 1), xlWorkSheet.Cells(2, 1)).Font.Size = 20
        xlWorkSheet.Range(xlWorkSheet.Cells(2, 1), xlWorkSheet.Cells(2, 1)).Font.Bold = True
        xlWorkSheet.Range(xlWorkSheet.Cells(2, 1), xlWorkSheet.Cells(2, 1)).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter

        xlWorkSheet.Cells(2, 1) = "V. DESARROLLO"
        xlWorkSheet.Range(xlWorkSheet.Cells(2, 1), xlWorkSheet.Cells(2, 1)).Interior.Color = RGB(255, 0, 0)
        xlWorkSheet.Range(xlWorkSheet.Cells(2, 1), xlWorkSheet.Cells(2, 1)).Font.Bold = True

        xlWorkSheet.Cells(2, 2) = _FechaFinRep
        xlWorkSheet.Range(xlWorkSheet.Cells(2, 2), xlWorkSheet.Cells(2, 2)).Font.Name = "Arial"
        xlWorkSheet.Range(xlWorkSheet.Cells(2, 2), xlWorkSheet.Cells(2, 2)).Font.Size = 20

        Dim str As String = (New ReporteBusinessLogic()).SelDiasUtilesyDiasAvancePorMes(_FechaFinRep)
        Dim DiasUtiles As Integer
        Dim DiasAvance As Integer
        DiasUtiles = Convert.ToInt32(str.Split(";")(0))
        DiasAvance = Convert.ToInt32(str.Split(";")(1))

        xlWorkSheet.Cells(2, 22) = "DÍAS ÚTILES:"
        xlWorkSheet.Cells(2, 23) = DiasUtiles
        xlWorkSheet.Cells(2, 24) = "AVANCE:"
        xlWorkSheet.Cells(2, 25) = DiasAvance
        xlWorkSheet.Range(xlWorkSheet.Cells(2, 22), xlWorkSheet.Cells(2, 25)).Font.Name = "Arial"
        xlWorkSheet.Range(xlWorkSheet.Cells(2, 22), xlWorkSheet.Cells(2, 25)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter


        Marshal.ReleaseComObject(xlWorkSheet)
    End Sub

    Sub GenerarCuadroVenta()
        Dim xlWorkSheet As New Worksheet
        xlWorkSheet = _xlWorkBook.Worksheets.Item(2) '2: HOJA AVANCE SODIMAC
        xlWorkSheet.Select()

        'Formato previo celdas
        help.SetAllBorders_Thin(xlWorkSheet.Range(xlWorkSheet.Cells(5, 1), xlWorkSheet.Cells(15, 1 + _lstSucursal.Count + _lstZona.Count + 3)))

        xlWorkSheet.Cells(4, 1) = "VENTA"
        xlWorkSheet.Range(xlWorkSheet.Cells(4, 1), xlWorkSheet.Cells(4, 1)).Font.Name = "Arial"
        xlWorkSheet.Range(xlWorkSheet.Cells(4, 1), xlWorkSheet.Cells(4, 1)).Font.Size = 20
        xlWorkSheet.Range(xlWorkSheet.Cells(4, 1), xlWorkSheet.Cells(4, 1)).Font.Bold = True

        xlWorkSheet.Cells(5, 1) = "MERCADO"
        xlWorkSheet.Range(xlWorkSheet.Cells(6, 1), xlWorkSheet.Cells(7, 1)).Merge()
        xlWorkSheet.Range(xlWorkSheet.Cells(5, 1), xlWorkSheet.Cells(5, 1)).Font.Bold = True

        xlWorkSheet.Cells(6, 1) = "VENTA NETA"
        xlWorkSheet.Cells(8, 1) = "PLAN VENTA NETA VENTA EMPRESA"
        xlWorkSheet.Cells(9, 1) = "VENTA NETA CONTADO"
        xlWorkSheet.Cells(10, 1) = "VENTA NETA CRÉDITO"
        xlWorkSheet.Cells(11, 1) = "VENTA NETA TOTAL"
        xlWorkSheet.Cells(12, 1) = "CUMPLIMIENTO VENTA EMPRESA"
        xlWorkSheet.Cells(13, 1) = "PROYECTADO VENTA EMPRESA"
        xlWorkSheet.Cells(14, 1) = "VENTA NECESARIA DIARIA"
        xlWorkSheet.Cells(15, 1) = "CUMPLIMIENTO PROYECTADO"
        xlWorkSheet.Range(xlWorkSheet.Cells(15, 1), xlWorkSheet.Cells(15, 1)).Font.Bold = True

        Dim iniColTiendas As Integer = 2
        Dim col As Integer = iniColTiendas
        Dim FormulaSubTotales_PlanVentaNetaVE As String = "=SUMA("
        Dim FormulaSubTotales_VentaNetaContado As String = "=SUMA("
        Dim FormulaSubTotales_VentaNetaCredito As String = "=SUMA("
        Dim FormulaSubTotales_VentaNetaTotal As String = "=SUMA("

        For i = 0 To _lstZona.Count - 1
            Dim local_i As Integer = i
            Dim lstSucursal As List(Of Sucursal) = _lstSucursal.FindAll(Function(x) x.IdZona = _lstZona.Item(local_i).IdZona)

            For j = 0 To lstSucursal.Count - 1
                xlWorkSheet.Cells(6, col) = (lstSucursal(j)).CodigoSucursal
                xlWorkSheet.Cells(7, col) = (lstSucursal(j)).Descripcion.ToUpper

                'row "PLAN VENTA NETA VENTA EMPRESA" por tienda:
                xlWorkSheet.Cells(8, col) = (New ReporteBusinessLogic()).SelPlanVentaPorTienda(_FechaFinRep, (lstSucursal(j)).CodigoSucursal)
                'row "VENTA NETA CONTADO" por tienda:
                xlWorkSheet.Cells(9, col) = (New ReporteBusinessLogic()).SelVentaNetaContadoPorTienda(_FechaIniRep, _FechaFinRep, (lstSucursal(j)).CodigoSucursal)
                'row "VENTA NETA CREDITO" por tienda:
                xlWorkSheet.Cells(10, col) = (New ReporteBusinessLogic()).SelVentaNetaCreditoPorTienda(_FechaIniRep, _FechaFinRep, (lstSucursal(j)).CodigoSucursal)

                'formula VENTA NETA TOTAL
                xlWorkSheet.Range(xlWorkSheet.Cells(11, col), xlWorkSheet.Cells(11, col)).FormulaLocal = "=SUMA(" & help.ColName(col) & "9:" & help.ColName(col) & "10)"
                'formula CUMPLIMIENTO
                xlWorkSheet.Range(xlWorkSheet.Cells(12, col), xlWorkSheet.Cells(12, col)).FormulaLocal = "=(" & help.ColName(col) & "11/" & help.ColName(col) & "8)"
                'formula PROYECTADO
                xlWorkSheet.Range(xlWorkSheet.Cells(13, col), xlWorkSheet.Cells(13, col)).FormulaLocal = "=(" & help.ColName(col) & "11/$Y$2)*$W$2"
                'formula VENTA NECESARIA DIARIA
                xlWorkSheet.Range(xlWorkSheet.Cells(14, col), xlWorkSheet.Cells(14, col)).FormulaLocal = "=(" & help.ColName(col) & "8-" & help.ColName(col) & "11)/($W$2-$Y$2)*0.999"
                'formula CUMPLIMIENTO PROYECTADO
                xlWorkSheet.Range(xlWorkSheet.Cells(15, col), xlWorkSheet.Cells(15, col)).FormulaLocal = "=" & help.ColName(col) & "13/" & help.ColName(col) & "8"

                'formato bordes celdas
                help.SetAllBorders_Medium(xlWorkSheet.Range(xlWorkSheet.Cells(8, col), xlWorkSheet.Cells(10, col)))

                col = col + 1
            Next

            'Merge para el nombre de la zona
            xlWorkSheet.Cells(5, col - lstSucursal.Count) = (_lstZona(i)).NombreZona
            xlWorkSheet.Range(xlWorkSheet.Cells(5, col - lstSucursal.Count), xlWorkSheet.Cells(5, col)).Merge()
            xlWorkSheet.Range(xlWorkSheet.Cells(5, col - lstSucursal.Count), xlWorkSheet.Cells(5, col)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
            xlWorkSheet.Range(xlWorkSheet.Cells(5, col - lstSucursal.Count), xlWorkSheet.Cells(5, col)).Font.Bold = True

            'col TOTAL ZONA
            xlWorkSheet.Cells(6, col) = (_lstZona(i)).NombreZona.Replace("ZONA", "TOTAL")
            xlWorkSheet.Range(xlWorkSheet.Cells(6, col), xlWorkSheet.Cells(7, col)).Merge()
            xlWorkSheet.Range(xlWorkSheet.Cells(6, col), xlWorkSheet.Cells(6, col)).Font.Bold = True
            xlWorkSheet.Range(xlWorkSheet.Cells(6, col), xlWorkSheet.Cells(7, col)).WrapText = True
            xlWorkSheet.Range(xlWorkSheet.Cells(6, col), xlWorkSheet.Cells(7, col)).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            help.SetAllBorders_Medium(xlWorkSheet.Range(xlWorkSheet.Cells(6, col), xlWorkSheet.Cells(15, col)))
            xlWorkSheet.Range(xlWorkSheet.Cells(6, col), xlWorkSheet.Cells(15, col)).Interior.Color = RGB(217, 217, 217) 'gris

            xlWorkSheet.Range(xlWorkSheet.Cells(6, col - lstSucursal.Count), xlWorkSheet.Cells(6, col - 1)).Columns.Group()

            'col TOTAL ZONA - PLAN VENTA NETA VENTA EMPRESA
            xlWorkSheet.Range(xlWorkSheet.Cells(8, col), xlWorkSheet.Cells(8, col)).FormulaLocal = "=SUMA(" & help.ColName(col - lstSucursal.Count) & "8:" & help.ColName(col - 1) & "8)"
            'col TOTAL ZONA - VENTA NETA CONTADO
            xlWorkSheet.Range(xlWorkSheet.Cells(9, col), xlWorkSheet.Cells(9, col)).FormulaLocal = "=SUMA(" & help.ColName(col - lstSucursal.Count) & "9:" & help.ColName(col - 1) & "9)"
            'col TOTAL ZONA - VENTA NETA CREDITO
            xlWorkSheet.Range(xlWorkSheet.Cells(10, col), xlWorkSheet.Cells(10, col)).FormulaLocal = "=SUMA(" & help.ColName(col - lstSucursal.Count) & "10:" & help.ColName(col - 1) & "10)"
            'col TOTAL ZONA - VENTA NETA TOTAL
            xlWorkSheet.Range(xlWorkSheet.Cells(11, col), xlWorkSheet.Cells(11, col)).FormulaLocal = "=SUMA(" & help.ColName(col - lstSucursal.Count) & "11:" & help.ColName(col - 1) & "11)"
            'col TOTAL ZONA - CUMPLIMIENTO
            xlWorkSheet.Range(xlWorkSheet.Cells(12, col), xlWorkSheet.Cells(12, col)).FormulaLocal = "=(" & help.ColName(col) & "11/" & help.ColName(col) & "8)"
            'col TOTAL ZONA - PROYECTADO
            xlWorkSheet.Range(xlWorkSheet.Cells(13, col), xlWorkSheet.Cells(13, col)).FormulaLocal = "=(" & help.ColName(col) & "11/$Y$2)*$W$2"
            'col TOTAL ZONA - VENTA NECESARIA DIARIA
            xlWorkSheet.Range(xlWorkSheet.Cells(14, col), xlWorkSheet.Cells(14, col)).FormulaLocal = "=(" & help.ColName(col) & "8-" & help.ColName(col) & "11)/($W$2-$Y$2)*0.999"
            'col TOTAL ZONA - CUMPLIMIENTO PROYECTADO
            xlWorkSheet.Range(xlWorkSheet.Cells(15, col), xlWorkSheet.Cells(15, col)).FormulaLocal = "=" & help.ColName(col) & "13/" & help.ColName(col) & "8"

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
        xlWorkSheet.Cells(6, col) = "SUBTOTALES"
        xlWorkSheet.Range(xlWorkSheet.Cells(6, col), xlWorkSheet.Cells(7, col)).Merge()
        xlWorkSheet.Range(xlWorkSheet.Cells(6, col), xlWorkSheet.Cells(12, col)).Interior.Color = RGB(217, 217, 217) 'gris
        xlWorkSheet.Range(xlWorkSheet.Cells(14, col), xlWorkSheet.Cells(15, col)).Interior.Color = RGB(217, 217, 217) 'gris

        'col SUBTOTALES - row PLAN VENTA NETA VENTA EMPRESA
        xlWorkSheet.Range(xlWorkSheet.Cells(8, col), xlWorkSheet.Cells(8, col)).FormulaLocal = FormulaSubTotales_PlanVentaNetaVE
        'col SUBTOTALES - row VENTA NETA CONTADO
        xlWorkSheet.Range(xlWorkSheet.Cells(9, col), xlWorkSheet.Cells(9, col)).FormulaLocal = FormulaSubTotales_VentaNetaContado
        'col SUBTOTALES - row VENTA NETA CREDITO
        xlWorkSheet.Range(xlWorkSheet.Cells(10, col), xlWorkSheet.Cells(10, col)).FormulaLocal = FormulaSubTotales_VentaNetaCredito
        'col SUBTOTALES - row VENTA NETA TOTAL
        xlWorkSheet.Range(xlWorkSheet.Cells(11, col), xlWorkSheet.Cells(11, col)).FormulaLocal = FormulaSubTotales_VentaNetaTotal
        'col SUBTOTALES - row CUMPLIMIENTO
        xlWorkSheet.Range(xlWorkSheet.Cells(12, col), xlWorkSheet.Cells(12, col)).FormulaLocal = "=" & help.ColName(col) & "11" & "/" & help.ColName(col) & "8"
        'col SUBTOTALES - row PROYECTADO
        xlWorkSheet.Range(xlWorkSheet.Cells(13, col), xlWorkSheet.Cells(13, col)).FormulaLocal = "=(" & help.ColName(col) & "11/$Y$2)*$W$2"
        'col SUBTOTALES - row VENTA NECESARIA DIARIA (NO utiliza formula)
        'col SUBTOTALES - row CUMPLIMIENTO PROYECTADO
        xlWorkSheet.Range(xlWorkSheet.Cells(15, col), xlWorkSheet.Cells(15, col)).FormulaLocal = "=" & help.ColName(col) & "13/" & help.ColName(col) & "8"

        col = col + 1

        'col T007-----------------------------------------------------------------------------------------------------------
        xlWorkSheet.Range(xlWorkSheet.Cells(5, col - 2), xlWorkSheet.Cells(5, col)).Merge()
        xlWorkSheet.Range(xlWorkSheet.Cells(6, col), xlWorkSheet.Cells(12, col)).Interior.Color = RGB(217, 217, 217) 'gris
        xlWorkSheet.Range(xlWorkSheet.Cells(14, col), xlWorkSheet.Cells(14, col)).Interior.Color = RGB(217, 217, 217) 'gris

        xlWorkSheet.Cells(6, col) = "T007"
        xlWorkSheet.Cells(7, col) = "VENTA EMPRESA"
        xlWorkSheet.Cells(8, col) = (New ReporteBusinessLogic()).SelPlanVentaPorTienda(_FechaFinRep, "T007")
        xlWorkSheet.Cells(9, col) = (New ReporteBusinessLogic()).SelVentaNetaContadoPorTienda(_FechaIniRep, _FechaFinRep, "T007")
        xlWorkSheet.Cells(10, col) = (New ReporteBusinessLogic()).SelVentaNetaCreditoPorTienda(_FechaIniRep, _FechaFinRep, "T007")
        xlWorkSheet.Range(xlWorkSheet.Cells(11, col), xlWorkSheet.Cells(11, col)).FormulaLocal = "=SUMA(" & help.ColName(col) & 9 & ":" & help.ColName(col) & 10 & ")"
        xlWorkSheet.Cells(12, col) = "0.0%"
        xlWorkSheet.Cells(13, col) = "0"
        xlWorkSheet.Cells(14, col) = "" 'sin valores
        xlWorkSheet.Cells(15, col) = "0.0%"

        col = col + 1

        'col TOTAL VAP-----------------------------------------------------------------------------------------------------------
        xlWorkSheet.Cells(6, col) = "TOTAL VAP"
        xlWorkSheet.Range(xlWorkSheet.Cells(6, col), xlWorkSheet.Cells(7, col)).Merge()
        xlWorkSheet.Range(xlWorkSheet.Cells(9, col), xlWorkSheet.Cells(11, col)).Interior.Color = RGB(217, 217, 217) 'gris

        'col TOTAL VAP - PLAN VENTA NETA VENTA EMPRESA
        xlWorkSheet.Range(xlWorkSheet.Cells(8, col), xlWorkSheet.Cells(8, col)).FormulaLocal = "=SUMA(" & help.ColName(col - 2) & 8 & ":" & help.ColName(col - 1) & "8)"
        'col TOTAL VAP - VENTA NETA CONTADO
        xlWorkSheet.Range(xlWorkSheet.Cells(9, col), xlWorkSheet.Cells(9, col)).FormulaLocal = "=SUMA(" & help.ColName(col - 2) & 9 & ":" & help.ColName(col - 1) & "9)"
        'col TOTAL VAP - VENTA NETA CREDITO 
        xlWorkSheet.Range(xlWorkSheet.Cells(10, col), xlWorkSheet.Cells(10, col)).FormulaLocal = "=SUMA(" & help.ColName(col - 2) & 10 & ":" & help.ColName(col - 1) & "10)"
        'col TOTAL VAP - VENTA NETA TOTAL
        xlWorkSheet.Range(xlWorkSheet.Cells(11, col), xlWorkSheet.Cells(11, col)).FormulaLocal = "=SUMA(" & help.ColName(col - 2) & 11 & ":" & help.ColName(col - 1) & "11)"
        'col TOTAL VAP - CUMPLIMIENTO VENTA EMPRESA
        xlWorkSheet.Range(xlWorkSheet.Cells(12, col), xlWorkSheet.Cells(12, col)).FormulaLocal = "=" & help.ColName(col) & "11/" & help.ColName(col) & "8"
        'col TOTAL VAP - PROYECTADO VENTA EMPRESA
        xlWorkSheet.Range(xlWorkSheet.Cells(13, col), xlWorkSheet.Cells(13, col)).FormulaLocal = "=(" & help.ColName(col) & "11/$Y$2)*$W$2"
        'col TOTAL VAP - VENTA NECESARIA DIARIA
        xlWorkSheet.Range(xlWorkSheet.Cells(14, col), xlWorkSheet.Cells(14, col)).FormulaLocal = "=(" & help.ColName(col - 2) & "8-" & help.ColName(col) & "11)/($W$2-$Y$2)*0.999"
        'col TOTAL VAP - CUMPLIMIENTO PROYECTADO
        xlWorkSheet.Range(xlWorkSheet.Cells(15, col), xlWorkSheet.Cells(15, col)).FormulaLocal = "=" & help.ColName(col) & "13/" & help.ColName(col) & "8"

        '---------------------------------------------------------------------------------------------------------------------------
        'FORMATO CUADRO VENTAS
        '---------------------------------------------------------------------------------------------------------------------------
        'Formato de cells zonas - LUEGO DEL MERGE DE LA ULTIMA ZONA
        help.SetBordesCeldas_Medium(xlWorkSheet.Range(xlWorkSheet.Cells(5, 2), xlWorkSheet.Cells(5, col)))
        help.SetBordesCeldas_Medium(xlWorkSheet.Range(xlWorkSheet.Cells(5, 1), xlWorkSheet.Cells(8, 1)))
        help.SetBordesCeldas_Medium(xlWorkSheet.Range(xlWorkSheet.Cells(9, 1), xlWorkSheet.Cells(10, 1)))
        help.SetBordesCeldas_Medium(xlWorkSheet.Range(xlWorkSheet.Cells(12, 1), xlWorkSheet.Cells(12, col)))
        help.SetBordesCeldas_Medium(xlWorkSheet.Range(xlWorkSheet.Cells(15, 1), xlWorkSheet.Cells(15, col)))
        help.SetAllBorders_Medium(xlWorkSheet.Range(xlWorkSheet.Cells(6, col - 2), xlWorkSheet.Cells(15, col - 2)))
        help.SetBordesCeldas_Medium(xlWorkSheet.Range(xlWorkSheet.Cells(5, col), xlWorkSheet.Cells(15, col)))

        xlWorkSheet.Range(xlWorkSheet.Cells(8, 1), xlWorkSheet.Cells(8, col)).Font.Bold = True
        xlWorkSheet.Range(xlWorkSheet.Cells(11, 1), xlWorkSheet.Cells(11, col)).Font.Bold = True
        xlWorkSheet.Range(xlWorkSheet.Cells(12, 1), xlWorkSheet.Cells(12, col)).Font.Bold = True
        xlWorkSheet.Range(xlWorkSheet.Cells(14, 2), xlWorkSheet.Cells(14, col)).Font.Bold = True

        xlWorkSheet.Range(xlWorkSheet.Cells(5, 1), xlWorkSheet.Cells(8, col)).Interior.Color = RGB(217, 217, 217) 'gris
        xlWorkSheet.Range(xlWorkSheet.Cells(12, 1), xlWorkSheet.Cells(12, col)).Interior.Color = RGB(217, 217, 217) 'gris

        xlWorkSheet.Range(xlWorkSheet.Cells(15, 2), xlWorkSheet.Cells(15, col)).NumberFormat = "0.00%"
        xlWorkSheet.Range(xlWorkSheet.Cells(12, 2), xlWorkSheet.Cells(12, col)).NumberFormat = "0.0%"

        Dim mis As Object = Type.Missing
        Dim cond As FormatCondition
        cond = xlWorkSheet.Range(xlWorkSheet.Cells(15, 2), xlWorkSheet.Cells(15, col)).FormatConditions.Add((XlFormatConditionType.xlCellValue), XlFormatConditionOperator.xlLess, "1", mis, mis, mis, mis, mis)
        cond.Font.Color = RGB(255, 0, 0)
        cond.StopIfTrue = False

        xlWorkSheet.Range(xlWorkSheet.Cells(9, 1), xlWorkSheet.Cells(10, 1)).EntireRow.Group()

        Marshal.ReleaseComObject(xlWorkSheet)
    End Sub

    Sub GenerarCuadroVentaInteranual()
        Dim xlWorkSheet As New Worksheet
        xlWorkSheet = _xlWorkBook.Worksheets.Item(2) '2: HOJA AVANCE SODIMAC
        xlWorkSheet.Select()

        Dim fecIniVI As Date
        Dim fecFinVI As Date

        Dim bll As New ReporteBusinessLogic
        bll.SelPeriodosVentaInteranual(_FechaIniRep, _FechaFinRep, fecIniVI, fecFinVI)

        xlWorkSheet.Cells(18, 1) = Left("0" & fecIniVI.Day.ToString, 2) & " AL " & Left("0" & fecFinVI.Day, 2) & " DE " & fecFinVI.Year.ToString
        xlWorkSheet.Cells(19, 1) = "VENTA INTERANUAL " & fecFinVI.Year.ToString
        xlWorkSheet.Cells(20, 1) = "VARIACION INTERANUAL S/."
        xlWorkSheet.Cells(21, 1) = "VARIACION INTERANUAL %"

        Dim iniColTiendas As Integer = 2
        Dim col As Integer = iniColTiendas
        Dim FormulaSubTotales_VentaInteranualYYYY As String = "=SUMA("

        For i = 0 To _lstZona.Count - 1
            Dim local_i As Integer
            local_i = i
            Dim lstSucursal As List(Of Sucursal) = _lstSucursal.FindAll(Function(x) x.IdZona = _lstZona.Item(local_i).IdZona)

            For j = 0 To lstSucursal.Count - 1
                xlWorkSheet.Cells(19, col) = (New ReporteBusinessLogic()).SelVentaInteranual(fecIniVI, fecFinVI, (lstSucursal(j)).CodigoSucursal)
                xlWorkSheet.Range(xlWorkSheet.Cells(20, col), xlWorkSheet.Cells(20, col)).FormulaLocal = "=" & help.ColName(col) & "11-" & help.ColName(col) & "19"
                xlWorkSheet.Range(xlWorkSheet.Cells(21, col), xlWorkSheet.Cells(21, col)).FormulaLocal = "=" & help.ColName(col) & "11/" & help.ColName(col) & "19-1"
                col = col + 1
            Next
            'COL - TOTAL ZONA
            'ROW - VENTA INTERANUAL YYYY
            xlWorkSheet.Range(xlWorkSheet.Cells(19, col), xlWorkSheet.Cells(19, col)).FormulaLocal = "=SUMA(" & help.ColName(col - lstSucursal.Count) & "19:" & help.ColName(col - 1) & "19)"
            'ROW - VARIACION INTERANUAL S/.
            xlWorkSheet.Range(xlWorkSheet.Cells(20, col), xlWorkSheet.Cells(20, col)).FormulaLocal = "=" & help.ColName(col) & "11-" & help.ColName(col) & "19"
            'ROW - VARIACION INTERANUAL %
            xlWorkSheet.Range(xlWorkSheet.Cells(21, col), xlWorkSheet.Cells(21, col)).FormulaLocal = "=" & help.ColName(col) & "11/" & help.ColName(col) & "19-1"

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
        xlWorkSheet.Range(xlWorkSheet.Cells(19, col), xlWorkSheet.Cells(19, col)).FormulaLocal = FormulaSubTotales_VentaInteranualYYYY
        'col SUBTOTALES - row VARIACION INTERANUAL S/. 
        xlWorkSheet.Range(xlWorkSheet.Cells(20, col), xlWorkSheet.Cells(20, col)).FormulaLocal = "=" & help.ColName(col) & "11-" & help.ColName(col) & "19"
        'col SUBTOTALES - row VARIACION INTERANUAL %
        xlWorkSheet.Range(xlWorkSheet.Cells(21, col), xlWorkSheet.Cells(21, col)).FormulaLocal = "=" & help.ColName(col) & "11/" & help.ColName(col) & "19-1"

        col = col + 1
        'col T007-----------------------------------------------------------------------------------------------------------
        xlWorkSheet.Cells(19, col) = (New ReporteBusinessLogic()).SelVentaInteranual(fecIniVI, fecFinVI, "T007")
        xlWorkSheet.Range(xlWorkSheet.Cells(20, col), xlWorkSheet.Cells(20, col)).FormulaLocal = "=" & help.ColName(col) & "11-" & help.ColName(col) & "19"
        xlWorkSheet.Cells(21, col) = "0.0%"

        col = col + 1

        'col TOTAL VAP-----------------------------------------------------------------------------------------------------------
        'col TOTAL VAP - VENTA INTERANUAL YYYY
        xlWorkSheet.Range(xlWorkSheet.Cells(19, col), xlWorkSheet.Cells(19, col)).FormulaLocal = "=SUMA(" & help.ColName(col - 2) & 19 & ":" & help.ColName(col - 1) & "19)"
        'col TOTAL VAP - VARIACION INTERANUAL S/. 
        xlWorkSheet.Range(xlWorkSheet.Cells(20, col), xlWorkSheet.Cells(20, col)).FormulaLocal = "=" & help.ColName(col) & "11-" & help.ColName(col) & "19"
        'col TOTAL VAP - VARIACION INTERANUAL %
        xlWorkSheet.Range(xlWorkSheet.Cells(21, col), xlWorkSheet.Cells(21, col)).FormulaLocal = "=" & help.ColName(col) & "11/" & help.ColName(col) & "19-1"

        '---------------------------------------------------------------------------------------------------------------------------
        'FORMATO CUADRO VENTA INTERANUAL
        '---------------------------------------------------------------------------------------------------------------------------
        xlWorkSheet.Range(xlWorkSheet.Cells(18, 1), xlWorkSheet.Cells(18, 1)).Font.Bold = True
        xlWorkSheet.Range(xlWorkSheet.Cells(19, 1), xlWorkSheet.Cells(21, col)).Font.Bold = True
        help.SetAllBorders_Medium(xlWorkSheet.Range(xlWorkSheet.Cells(19, 1), xlWorkSheet.Cells(21, col)))
        xlWorkSheet.Range(xlWorkSheet.Cells(19, 1), xlWorkSheet.Cells(20, col)).Interior.Color = RGB(217, 217, 217) 'gris
        xlWorkSheet.Range(xlWorkSheet.Cells(21, 2), xlWorkSheet.Cells(21, col)).NumberFormat = "0.00%"

        Dim mis As Object = Type.Missing
        Dim cond As FormatCondition
        cond = xlWorkSheet.Range(xlWorkSheet.Cells(21, 2), xlWorkSheet.Cells(21, col)).FormatConditions.Add((XlFormatConditionType.xlCellValue), XlFormatConditionOperator.xlLess, "0", mis, mis, mis, mis, mis)
        cond.Font.Color = RGB(255, 0, 0)
        cond.StopIfTrue = False

        Marshal.ReleaseComObject(xlWorkSheet)
    End Sub

    Sub GenerarCuadroPlanAlDia()
        Dim xlWorkSheet As New Worksheet
        xlWorkSheet = _xlWorkBook.Worksheets.Item(2) '2: HOJA AVANCE SODIMAC
        xlWorkSheet.Select()

        xlWorkSheet.Cells(24, 1) = "PLAN AL DIA"
        xlWorkSheet.Cells(25, 1) = "DEBE AL PLAN AL DIA DE AYER"
        xlWorkSheet.Cells(26, 1) = "PLAN DIARIO"
        xlWorkSheet.Cells(27, 1) = "PLAN DEL DIA"

        Dim iniColTiendas As Integer = 2
        Dim col As Integer = iniColTiendas

        For i = 0 To _lstZona.Count - 1
            Dim local_i As Integer
            local_i = i
            Dim lstSucursal As List(Of Sucursal) = _lstSucursal.FindAll(Function(x) x.IdZona = _lstZona.Item(local_i).IdZona)

            For j = 0 To lstSucursal.Count - 1
                'col TIENDA - row PLAN AL DIA
                xlWorkSheet.Cells(24, col) = "=(" & help.ColName(col) & "8/$W$2)*$Y$2"
                'col TIENDA - row DEBE AL PLAN AL DIA DE AYER
                xlWorkSheet.Cells(25, col) = "=(" & help.ColName(col) & "24-" & help.ColName(col) & "11)"
                'col TIENDA - PLAN DIARIO
                xlWorkSheet.Cells(26, col) = "=" & help.ColName(col) & "8/$W$2"
                'col TIENDA - PLAN DEL DIA
                xlWorkSheet.Range(xlWorkSheet.Cells(27, col), xlWorkSheet.Cells(27, col)).FormulaLocal = "=SI(" & help.ColName(col) & "25>0,(" & help.ColName(col) & "25+" & help.ColName(col) & "26)," & help.ColName(col) & "26)"
                col = col + 1
            Next
            'col TOTAL ZONA - row PLAN AL DIA
            xlWorkSheet.Cells(24, col) = "=(" & help.ColName(col) & "8/$W$2)*$Y$2"
            'col TOTAL ZONA - row DEBE AL PLAN AL DIA DE AYER
            xlWorkSheet.Cells(25, col) = "=(" & help.ColName(col) & "24-" & help.ColName(col) & "11)"
            'col TOTAL ZONA - row PLAN DIARIO
            xlWorkSheet.Cells(26, col) = "=" & help.ColName(col) & "8/$W$2"
            'col TOTAL ZONA - row PLAN DEL DIA
            xlWorkSheet.Range(xlWorkSheet.Cells(27, col), xlWorkSheet.Cells(27, col)).FormulaLocal = "=SI(" & help.ColName(col) & "25>0,(" & help.ColName(col) & "25+" & help.ColName(col) & "26)," & help.ColName(col) & "26)"
            xlWorkSheet.Range(xlWorkSheet.Cells(27, col), xlWorkSheet.Cells(27, col)).Font.Bold = True
            col = col + 1
        Next
        'col SUBTOTALES-----------------------------------------------------------------------------------------------------------
        'col SUBTOTALES - row PLAN AL DIA
        xlWorkSheet.Cells(24, col) = "=(" & help.ColName(col) & "8/$W$2)*$Y$2"
        'col SUBTOTALES - row DEBE AL PLAN AL DIA DE AYER
        xlWorkSheet.Cells(25, col) = "=(" & help.ColName(col) & "24-" & help.ColName(col) & "11)"
        'col SUBTOTALES - row PLAN DIARIO
        xlWorkSheet.Cells(26, col) = "=" & help.ColName(col) & "8/$W$2"
        'col SUBTOTALES - row PLAN DEL DIA
        xlWorkSheet.Range(xlWorkSheet.Cells(27, col), xlWorkSheet.Cells(27, col)).FormulaLocal = "=SI(" & help.ColName(col) & "25>0,(" & help.ColName(col) & "25+" & help.ColName(col) & "26)," & help.ColName(col) & "26)"
        xlWorkSheet.Range(xlWorkSheet.Cells(27, col), xlWorkSheet.Cells(27, col)).Font.Bold = True

        col = col + 1

        'col T007-----------------------------------------------------------------------------------------------------------
        'col T007 - row PLAN AL DIA
        xlWorkSheet.Cells(24, col) = "0"
        'col T007 - row DEBE AL PLAN AL DIA DE AYER
        xlWorkSheet.Cells(25, col) = "0"
        'col T007 - row PLAN DIARIO
        xlWorkSheet.Cells(26, col) = "=" & help.ColName(col) & "8/$W$2"
        'col T007 - row PLAN DEL DIA
        xlWorkSheet.Range(xlWorkSheet.Cells(27, col), xlWorkSheet.Cells(27, col)).FormulaLocal = "=SI(" & help.ColName(col) & "25>0,(" & help.ColName(col) & "25+" & help.ColName(col) & "26)," & help.ColName(col) & "26)"
        xlWorkSheet.Range(xlWorkSheet.Cells(27, col), xlWorkSheet.Cells(27, col)).Font.Bold = True

        col = col + 1

        'col TOTAL VAP-----------------------------------------------------------------------------------------------------------
        'col TOTAL VAP - row PLAN AL DIA
        xlWorkSheet.Cells(24, col) = "=(" & help.ColName(col) & "8/$W$2)*$Y$2"
        'col TOTAL VAP - row DEBE AL PLAN AL DIA DE AYER
        xlWorkSheet.Cells(25, col) = "=(" & help.ColName(col) & "24-" & help.ColName(col) & "11)"
        'col TOTAL VAP - row PLAN DIARIO
        xlWorkSheet.Cells(26, col) = "=" & help.ColName(col) & "8/$W$2"
        'col TOTAL VAP - row PLAN DEL DIA
        xlWorkSheet.Range(xlWorkSheet.Cells(27, col), xlWorkSheet.Cells(27, col)).FormulaLocal = "=SI(" & help.ColName(col) & "25>0,(" & help.ColName(col) & "25+" & help.ColName(col) & "26)," & help.ColName(col) & "26)"
        xlWorkSheet.Range(xlWorkSheet.Cells(27, col), xlWorkSheet.Cells(27, col)).Font.Bold = True

        '---------------------------------------------------------------------------------------------------------------------------
        'FORMATO CUADRO PLAN AL DIA
        '---------------------------------------------------------------------------------------------------------------------------
        help.SetAllBorders_Thin(xlWorkSheet.Range(xlWorkSheet.Cells(24, 1), xlWorkSheet.Cells(27, col)))
        help.SetAllBorders_Medium(xlWorkSheet.Range(xlWorkSheet.Cells(24, 1), xlWorkSheet.Cells(27, 1)))
        help.SetBordesCeldas_Medium(xlWorkSheet.Range(xlWorkSheet.Cells(24, 1), xlWorkSheet.Cells(27, col)))
        help.SetBordesCeldas_Medium(xlWorkSheet.Range(xlWorkSheet.Cells(24, 1), xlWorkSheet.Cells(24, col)))
        xlWorkSheet.Range(xlWorkSheet.Cells(24, 1), xlWorkSheet.Cells(27, 1)).Font.Bold = True
        xlWorkSheet.Range(xlWorkSheet.Cells(24, 1), xlWorkSheet.Cells(27, 1)).Interior.Color = RGB(217, 217, 217) 'gris
        xlWorkSheet.Range(xlWorkSheet.Cells(27, 2), xlWorkSheet.Cells(27, col)).Interior.Color = RGB(255, 255, 153) 'crema

        Dim mis As Object = Type.Missing
        Dim cond As FormatCondition
        cond = xlWorkSheet.Range(xlWorkSheet.Cells(25, 2), xlWorkSheet.Cells(25, col)).FormatConditions.Add((XlFormatConditionType.xlCellValue), XlFormatConditionOperator.xlLess, "0", mis, mis, mis, mis, mis)
        cond.Font.Color = RGB(156, 0, 6)
        cond.Interior.Color = RGB(255, 199, 206)
        cond.StopIfTrue = False

        Marshal.ReleaseComObject(xlWorkSheet)
    End Sub

    Sub GenerarCuadroContribucion()
        Dim xlWorkSheet As New Worksheet
        xlWorkSheet = _xlWorkBook.Worksheets.Item(2) '2: HOJA AVANCE SODIMAC
        xlWorkSheet.Select()

        xlWorkSheet.Cells(29, 1) = "CONTRIBUCION"
        xlWorkSheet.Cells(30, 1) = "PLAN DE CONTRIBUCION"
        xlWorkSheet.Cells(31, 1) = "CONTRIBUCION REAL"
        xlWorkSheet.Cells(32, 1) = "DIFERENCIA"

        Dim iniColTiendas As Integer = 2
        Dim col As Integer = iniColTiendas

        For i = 0 To _lstZona.Count - 1
            Dim local_i As Integer
            local_i = i
            Dim lstSucursal As List(Of Sucursal) = _lstSucursal.FindAll(Function(x) x.IdZona = _lstZona.Item(local_i).IdZona)

            For j = 0 To lstSucursal.Count - 1
                'col TIENDA - row PLAN DE CONTRIBUCION
                xlWorkSheet.Cells(30, col) = "=" & help.ColName(col) & "8*" & help.ColName(col) & "38"
                'col TIENDA - row CONTRIBUCION REAL
                xlWorkSheet.Cells(31, col) = "=" & help.ColName(col) & "11*" & help.ColName(col) & "41"
                'col TIENDA - row DIFERENCIA
                xlWorkSheet.Cells(32, col) = "=" & help.ColName(col) & "31-" & help.ColName(col) & "30"
                col = col + 1
            Next
            'col TOTAL ZONA - row PLAN DE CONTRIBUCION
            xlWorkSheet.Cells(30, col) = "=" & help.ColName(col) & "8*" & help.ColName(col) & "38"
            'col TOTAL ZONA - row CONTRIBUCION REAL
            xlWorkSheet.Cells(31, col) = "=" & help.ColName(col) & "11*" & help.ColName(col) & "41"
            'col TOTAL ZONA - row DIFERENCIA
            xlWorkSheet.Cells(32, col) = "=" & help.ColName(col) & "31-" & help.ColName(col) & "30"
            col = col + 1
        Next
        'col SUBTOTALES-----------------------------------------------------------------------------------------------------------
        'col SUBTOTALES - row PLAN DE CONTRIBUCION
        xlWorkSheet.Cells(30, col) = "=" & help.ColName(col) & "8*" & help.ColName(col) & "38"
        'col SUBTOTALES - row CONTRIBUCION REAL
        xlWorkSheet.Cells(31, col) = "=" & help.ColName(col) & "11*" & help.ColName(col) & "41"
        'col SUBTOTALES - row DIFERENCIA
        xlWorkSheet.Cells(32, col) = "=" & help.ColName(col) & "31-" & help.ColName(col) & "30"

        col = col + 1

        'col T007 - row PLAN DE CONTRIBUCION
        xlWorkSheet.Cells(30, col) = "=" & help.ColName(col) & "8*" & help.ColName(col) & "38"
        'col T007 - row CONTRIBUCION REAL
        xlWorkSheet.Cells(31, col) = "=" & help.ColName(col) & "11*" & help.ColName(col) & "41"
        'col T007 - row DIFERENCIA
        xlWorkSheet.Cells(32, col) = "0"

        col = col + 1

        'col TOTAL VAP-----------------------------------------------------------------------------------------------------------
        'col TOTAL VAP - row PLAN DE CONTRIBUCION
        xlWorkSheet.Cells(30, col) = "=" & help.ColName(col) & "8*" & help.ColName(col) & "38"
        'col TOTAL VAP - row CONTRIBUCION REAL
        xlWorkSheet.Range(xlWorkSheet.Cells(31, col), xlWorkSheet.Cells(31, col)).FormulaLocal = "=SUMA(" & help.ColName(col - 2) & "31:" & help.ColName(col - 1) & "31)"
        'col TOTAL VAP - row DIFERENCIA
        xlWorkSheet.Range(xlWorkSheet.Cells(32, col), xlWorkSheet.Cells(32, col)).FormulaLocal = "=SUMA(" & help.ColName(col - 2) & "32:" & help.ColName(col - 1) & "32)"

        Marshal.ReleaseComObject(xlWorkSheet)

        '---------------------------------------------------------------------------------------------------------------------------
        'FORMATO CUADRO CONTRIBUCION
        '---------------------------------------------------------------------------------------------------------------------------
        help.SetAllBorders_Thin(xlWorkSheet.Range(xlWorkSheet.Cells(30, 1), xlWorkSheet.Cells(32, col)))
        help.SetBordesCeldas_Medium(xlWorkSheet.Range(xlWorkSheet.Cells(30, 1), xlWorkSheet.Cells(32, col)))
        xlWorkSheet.Range(xlWorkSheet.Cells(30, 1), xlWorkSheet.Cells(30, col)).Interior.Color = RGB(217, 217, 217) 'gris
        xlWorkSheet.Range(xlWorkSheet.Cells(32, 2), xlWorkSheet.Cells(32, col)).Interior.Color = RGB(217, 217, 217) 'gris
        xlWorkSheet.Range(xlWorkSheet.Cells(31, col), xlWorkSheet.Cells(31, col)).Interior.Color = RGB(172, 185, 202) 'gris oscuro
        xlWorkSheet.Range(xlWorkSheet.Cells(29, 1), xlWorkSheet.Cells(29, 1)).Font.Bold = True
        xlWorkSheet.Range(xlWorkSheet.Cells(4, 1), xlWorkSheet.Cells(4, 1)).Font.Name = "Calibri"
        xlWorkSheet.Range(xlWorkSheet.Cells(4, 1), xlWorkSheet.Cells(4, 1)).Font.Size = 24
        xlWorkSheet.Range(xlWorkSheet.Cells(30, 1), xlWorkSheet.Cells(30, col)).Font.Bold = True
        xlWorkSheet.Range(xlWorkSheet.Cells(32, 1), xlWorkSheet.Cells(32, col)).Font.Bold = True

    End Sub

    Sub GenerarCuadroMargen()
        Dim xlWorkSheet As New Worksheet
        xlWorkSheet = _xlWorkBook.Worksheets.Item(2) '2: HOJA AVANCE SODIMAC
        xlWorkSheet.Select()

        'formato previo celdas
        xlWorkSheet.Range(xlWorkSheet.Cells(38, 1), xlWorkSheet.Cells(38, 1 + _lstSucursal.Count + _lstZona.Count + 3)).NumberFormat = "0.00%"
        xlWorkSheet.Range(xlWorkSheet.Cells(39, 1), xlWorkSheet.Cells(39, 1 + _lstSucursal.Count + _lstZona.Count + 3)).NumberFormat = "0.00%"
        xlWorkSheet.Range(xlWorkSheet.Cells(40, 1), xlWorkSheet.Cells(40, 1 + _lstSucursal.Count + _lstZona.Count + 3)).NumberFormat = "0.00%"
        xlWorkSheet.Range(xlWorkSheet.Cells(41, 1), xlWorkSheet.Cells(41, 1 + _lstSucursal.Count + _lstZona.Count + 3)).NumberFormat = "0.00%"
        xlWorkSheet.Range(xlWorkSheet.Cells(42, 1), xlWorkSheet.Cells(42, 1 + _lstSucursal.Count + _lstZona.Count + 3)).NumberFormat = "0.00%"

        xlWorkSheet.Cells(34, 1) = "MARGEN"
        xlWorkSheet.Range(xlWorkSheet.Cells(34, 1), xlWorkSheet.Cells(34, 1)).Font.Name = "Calibri"
        xlWorkSheet.Range(xlWorkSheet.Cells(34, 1), xlWorkSheet.Cells(34, 1)).Font.Size = 24

        xlWorkSheet.Cells(35, 1) = "MARGEN NETO"
        xlWorkSheet.Range(xlWorkSheet.Cells(35, 1), xlWorkSheet.Cells(37, 1)).Merge()
        xlWorkSheet.Range(xlWorkSheet.Cells(35, 1), xlWorkSheet.Cells(35, 1)).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
        xlWorkSheet.Range(xlWorkSheet.Cells(35, 1), xlWorkSheet.Cells(35, 1)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

        xlWorkSheet.Cells(38, 1) = "PLAN MARGEN NETO VENTA EMPRESA"
        xlWorkSheet.Cells(39, 1) = "MARGEN NETO CONTADO"
        xlWorkSheet.Cells(40, 1) = "MARGEN NETO CRÉDITO"
        xlWorkSheet.Cells(41, 1) = "MARGEN NETO TOTAL"
        xlWorkSheet.Cells(42, 1) = "DIFERENCIA MARGEN NETO"

        Dim iniColTiendas As Integer = 2
        Dim col As Integer = iniColTiendas

        For i = 0 To _lstZona.Count - 1
            Dim local_i As Integer
            local_i = i
            Dim lstSucursal As List(Of Sucursal) = _lstSucursal.FindAll(Function(x) x.IdZona = _lstZona.Item(local_i).IdZona)

            For j = 0 To lstSucursal.Count - 1
                xlWorkSheet.Cells(36, col) = (lstSucursal(j)).CodigoSucursal
                xlWorkSheet.Cells(37, col) = (lstSucursal(j)).Descripcion.ToUpper
                xlWorkSheet.Range(xlWorkSheet.Cells(37, col), xlWorkSheet.Cells(37, col)).Font.Bold = True

                'row PLAN MARGEN NETO VENTA EMPRESA
                xlWorkSheet.Cells(38, col) = (New ReporteBusinessLogic()).SelPlanMargenPorTienda(_FechaFinRep, _IdMarca)
                'row MARGEN NETO CONTADO
                xlWorkSheet.Cells(39, col) = (New ReporteBusinessLogic()).SelMargenNetoContadoPorTienda(_FechaIniRep, _FechaFinRep, (lstSucursal(j)).CodigoSucursal)
                'row MARGEN NETO CRÉDITO
                xlWorkSheet.Cells(40, col) = (New ReporteBusinessLogic()).SelMargenNetoCreditoPorTienda(_FechaIniRep, _FechaFinRep, (lstSucursal(j)).CodigoSucursal)
                'row MARGEN NETO TOTAL
                xlWorkSheet.Cells(41, col) = (New ReporteBusinessLogic()).SelMargenNetoTotalPorTienda(_FechaIniRep, _FechaFinRep, (lstSucursal(j)).CodigoSucursal)
                'row DIFERENCIA MARGEN NETO
                xlWorkSheet.Cells(42, col) = "=" & help.ColName(col) & "41-" & help.ColName(col) & "38"

                col = col + 1
            Next
            'Merge para el nombre de la zona
            xlWorkSheet.Cells(35, col - lstSucursal.Count) = (_lstZona(i)).NombreZona
            xlWorkSheet.Range(xlWorkSheet.Cells(35, col - lstSucursal.Count), xlWorkSheet.Cells(35, col)).Merge()
            xlWorkSheet.Range(xlWorkSheet.Cells(35, col - lstSucursal.Count), xlWorkSheet.Cells(35, col)).Font.Bold = True
            xlWorkSheet.Range(xlWorkSheet.Cells(35, col - lstSucursal.Count), xlWorkSheet.Cells(35, col)).WrapText = True

            'col TOTAL ZONA----------------------------------------------------------------------------------------
            xlWorkSheet.Cells(36, col) = (_lstZona(i)).NombreZona.Replace("ZONA", "TOTAL")
            xlWorkSheet.Range(xlWorkSheet.Cells(36, col), xlWorkSheet.Cells(37, col)).Merge()
            xlWorkSheet.Range(xlWorkSheet.Cells(36, col), xlWorkSheet.Cells(37, col)).Font.Bold = True
            xlWorkSheet.Range(xlWorkSheet.Cells(36, col), xlWorkSheet.Cells(37, col)).WrapText = True
            xlWorkSheet.Range(xlWorkSheet.Cells(36, col), xlWorkSheet.Cells(37, col)).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter

            'col TOTAL ZONA - row PLAN MARGEN NETO VENTA EMPRESA
            xlWorkSheet.Cells(38, col) = 0.0
            'col TOTAL ZONA - row MARGEN NETO CONTADO
            xlWorkSheet.Cells(39, col) = 0.0
            'col TOTAL ZONA - row MARGEN NETO CRÉDITO
            xlWorkSheet.Cells(40, col) = 0.0
            'col TOTAL ZONA - row MARGEN NETO TOTAL
            xlWorkSheet.Cells(41, col) = 0.0
            'col TOTAL ZONA - row DIFERENCIA MARGEN NETO
            xlWorkSheet.Cells(42, col) = 0.0

            col = col + 1

        Next
        'col SUBTOTALES-------------------------------------------------------------------------------------------------------------
        xlWorkSheet.Cells(36, col) = "SUBTOTALES"
        xlWorkSheet.Range(xlWorkSheet.Cells(36, col), xlWorkSheet.Cells(37, col)).Merge()
        xlWorkSheet.Range(xlWorkSheet.Cells(36, col), xlWorkSheet.Cells(42, col)).Interior.Color = RGB(217, 217, 217) 'gris
        'col SUBTOTALES - row PLAN MARGEN NETO VENTA EMPRESA
        xlWorkSheet.Cells(38, col) = 0.0
        'col SUBTOTALES - row MARGEN NETO CONTADO
        xlWorkSheet.Cells(39, col) = 0.0
        'col SUBTOTALES - row MARGEN NETO CRÉDITO
        xlWorkSheet.Cells(40, col) = 0.0
        'col SUBTOTALES - row MARGEN NETO TOTAL
        xlWorkSheet.Cells(41, col) = 0.0
        'col SUBTOTALES - row DIFERENCIA MARGEN NETO
        xlWorkSheet.Range(xlWorkSheet.Cells(42, col), xlWorkSheet.Cells(42, col)).FormulaLocal = "=" & help.ColName(col) & "41-" & help.ColName(col) & 38

        col = col + 1

        'col T007-----------------------------------------------------------------------------------------------------------
        xlWorkSheet.Range(xlWorkSheet.Cells(35, col - 2), xlWorkSheet.Cells(35, col)).Merge()
        xlWorkSheet.Cells(36, col) = "T007"
        xlWorkSheet.Range(xlWorkSheet.Cells(36, col), xlWorkSheet.Cells(37, col)).Merge()
        'col T007 - row PLAN MARGEN NETO VENTA EMPRESA
        xlWorkSheet.Cells(38, col) = (New ReporteBusinessLogic()).SelPlanMargenPorTienda(_FechaFinRep, _IdMarca)
        'col T007 - row MARGEN NETO CONTADO
        xlWorkSheet.Cells(39, col) = 0.0
        'col T007 - row MARGEN NETO CRÉDITO
        xlWorkSheet.Cells(40, col) = 0.0
        'col T007 - row MARGEN NETO TOTAL
        xlWorkSheet.Cells(41, col) = 0.0
        'col T007 - row DIFERENCIA MARGEN NETO
        xlWorkSheet.Cells(42, col) = 0.0

        col = col + 1

        'col TOTAL VAP-----------------------------------------------------------------------------------------------------------
        xlWorkSheet.Cells(36, col) = "TOTAL VAP"
        xlWorkSheet.Range(xlWorkSheet.Cells(36, col), xlWorkSheet.Cells(37, col)).Merge()
        'col TOTAL VAP - row PLAN MARGEN NETO VENTA EMPRESA
        xlWorkSheet.Cells(38, col) = 0.0
        'col TOTAL VAP - row MARGEN NETO CONTADO
        xlWorkSheet.Cells(39, col) = 0.0
        'col TOTAL VAP - row MARGEN NETO CRÉDITO
        xlWorkSheet.Cells(40, col) = 0.0
        'col TOTAL VAP - row MARGEN NETO TOTAL
        xlWorkSheet.Cells(41, col) = 0.0
        'col TOTAL VAP - row DIFERENCIA MARGEN NETO
        xlWorkSheet.Cells(42, col) = 0.0

        '---------------------------------------------------------------------------------------------------------------------------
        'FORMATO CUADRO MARGEN
        '---------------------------------------------------------------------------------------------------------------------------
        xlWorkSheet.Range(xlWorkSheet.Cells(34, 1), xlWorkSheet.Cells(34, 1)).Font.Bold = True
        xlWorkSheet.Range(xlWorkSheet.Cells(35, 1), xlWorkSheet.Cells(38, col)).Interior.Color = RGB(217, 217, 217) 'gris
        xlWorkSheet.Range(xlWorkSheet.Cells(41, 1), xlWorkSheet.Cells(42, col)).Interior.Color = RGB(217, 217, 217) 'gris
        xlWorkSheet.Range(xlWorkSheet.Cells(38, 1), xlWorkSheet.Cells(38, col)).Font.Bold = True
        xlWorkSheet.Range(xlWorkSheet.Cells(41, 1), xlWorkSheet.Cells(41, col)).Font.Bold = True
        xlWorkSheet.Range(xlWorkSheet.Cells(42, 1), xlWorkSheet.Cells(42, col)).Font.Bold = True

        help.SetAllBorders_Thin(xlWorkSheet.Range(xlWorkSheet.Cells(35, 1), xlWorkSheet.Cells(42, col)))
        help.SetBordesCeldas_Medium(xlWorkSheet.Range(xlWorkSheet.Cells(35, 2), xlWorkSheet.Cells(35, col)))
        help.SetBordesCeldas_Medium(xlWorkSheet.Range(xlWorkSheet.Cells(35, 1), xlWorkSheet.Cells(42, 1)))
        help.SetBordesCeldas_Medium(xlWorkSheet.Range(xlWorkSheet.Cells(41, 1), xlWorkSheet.Cells(41, col)))
        help.SetBordesCeldas_Medium(xlWorkSheet.Range(xlWorkSheet.Cells(42, 1), xlWorkSheet.Cells(42, col)))

        Dim mis As Object = Type.Missing
        Dim cond As FormatCondition
        cond = xlWorkSheet.Range(xlWorkSheet.Cells(39, 2), xlWorkSheet.Cells(39, col)).FormatConditions.Add((XlFormatConditionType.xlCellValue), XlFormatConditionOperator.xlLess, "0", mis, mis, mis, mis, mis)
        cond.Font.Color = RGB(255, 0, 0)
        cond.StopIfTrue = False

        xlWorkSheet.Range(xlWorkSheet.Cells(39, 1), xlWorkSheet.Cells(40, 1)).EntireRow.Group()

        Marshal.ReleaseComObject(xlWorkSheet)
    End Sub

    Sub GenerarCuadroTransacciones()
        Dim xlWorkSheet As New Worksheet
        xlWorkSheet = _xlWorkBook.Worksheets.Item(2) '2: HOJA AVANCE SODIMAC
        xlWorkSheet.Select()

        xlWorkSheet.Cells(44, 1) = "TRANSACCIONES"
        xlWorkSheet.Range(xlWorkSheet.Cells(44, 1), xlWorkSheet.Cells(44, 1)).Font.Name = "Calibri"
        xlWorkSheet.Range(xlWorkSheet.Cells(44, 1), xlWorkSheet.Cells(44, 1)).Font.Size = 24
        xlWorkSheet.Range(xlWorkSheet.Cells(44, 1), xlWorkSheet.Cells(44, 1)).Font.Bold = True

        xlWorkSheet.Cells(45, 1) = "NÚMERO DE TRANSACCIONES"
        xlWorkSheet.Range(xlWorkSheet.Cells(45, 1), xlWorkSheet.Cells(47, 1)).Merge()
        xlWorkSheet.Range(xlWorkSheet.Cells(45, 1), xlWorkSheet.Cells(45, 1)).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
        xlWorkSheet.Range(xlWorkSheet.Cells(45, 1), xlWorkSheet.Cells(45, 1)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

        'formato previo celdas
        help.SetAllBorders_Thin(xlWorkSheet.Range(xlWorkSheet.Cells(45, 1), xlWorkSheet.Cells(47, 1 + _lstSucursal.Count + _lstZona.Count + 3)))
        help.SetAllBorders_Thin(xlWorkSheet.Range(xlWorkSheet.Cells(50, 1), xlWorkSheet.Cells(50, 1 + _lstSucursal.Count + _lstZona.Count + 3)))

        xlWorkSheet.Cells(48, 1) = "TRANSACCIONES VENTA CONTADO"
        xlWorkSheet.Cells(49, 1) = "TRANSACCIONES VENTA CREDITO"
        xlWorkSheet.Cells(50, 1) = "TRANSACCIONES VENTA TOTAL"

        Dim iniColTiendas As Integer = 2
        Dim col As Integer = iniColTiendas
        Dim FormulaSubTotales_TranVentaContado As String = "=SUMA("
        Dim FormulaSubTotales_TranVentaCredito As String = "=SUMA("
        Dim FormulaSubTotales_TranVentaTotal As String = "=SUMA("

        For i = 0 To _lstZona.Count - 1
            Dim local_i As Integer
            local_i = i
            Dim lstSucursal As List(Of Sucursal) = _lstSucursal.FindAll(Function(x) x.IdZona = _lstZona.Item(local_i).IdZona)

            For j = 0 To lstSucursal.Count - 1
                xlWorkSheet.Cells(46, col) = (lstSucursal(j)).CodigoSucursal
                xlWorkSheet.Cells(47, col) = (lstSucursal(j)).Descripcion.ToUpper
                'row TRANSACCIONES VENTA CONTADO
                xlWorkSheet.Cells(48, col) = (New ReporteBusinessLogic()).SelTransacVentaContadoPorTienda(_FechaIniRep, _FechaFinRep, (lstSucursal(j)).CodigoSucursal)
                'row TRANSACCIONES VENTA CREDITO
                xlWorkSheet.Cells(49, col) = (New ReporteBusinessLogic()).SelTransacVentaCreditoPorTienda(_FechaIniRep, _FechaFinRep, (lstSucursal(j)).CodigoSucursal)
                'row TRANSACCIONES VENTA TOTAL
                xlWorkSheet.Range(xlWorkSheet.Cells(50, col), xlWorkSheet.Cells(50, col)).FormulaLocal = "=SUMA(" & help.ColName(col) & "48:" & help.ColName(col) & "49)"
                col = col + 1
            Next

            'Merge para el nombre de la zona
            xlWorkSheet.Cells(45, col - lstSucursal.Count) = (_lstZona(i)).NombreZona
            xlWorkSheet.Range(xlWorkSheet.Cells(45, col - lstSucursal.Count), xlWorkSheet.Cells(45, col)).Merge()
            xlWorkSheet.Range(xlWorkSheet.Cells(45, col - lstSucursal.Count), xlWorkSheet.Cells(45, col)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
            xlWorkSheet.Range(xlWorkSheet.Cells(45, col - lstSucursal.Count), xlWorkSheet.Cells(45, col)).Font.Bold = True
            'col TOTAL ZONA
            xlWorkSheet.Cells(46, col) = (_lstZona(i)).NombreZona.Replace("ZONA", "TOTAL")
            xlWorkSheet.Range(xlWorkSheet.Cells(46, col), xlWorkSheet.Cells(47, col)).Merge()
            xlWorkSheet.Range(xlWorkSheet.Cells(46, col), xlWorkSheet.Cells(47, col)).Font.Bold = True
            xlWorkSheet.Range(xlWorkSheet.Cells(46, col), xlWorkSheet.Cells(47, col)).WrapText = True
            xlWorkSheet.Range(xlWorkSheet.Cells(46, col), xlWorkSheet.Cells(47, col)).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            help.SetBordesCeldas_Medium(xlWorkSheet.Range(xlWorkSheet.Cells(46, col), xlWorkSheet.Cells(50, col)))
            'col TOTAL ZONA - TRANSACCIONES VENTA CONTADO
            xlWorkSheet.Range(xlWorkSheet.Cells(48, col), xlWorkSheet.Cells(48, col)).FormulaLocal = "=SUMA(" & help.ColName(col - lstSucursal.Count) & "48:" & help.ColName(col - 1) & "48)"
            xlWorkSheet.Range(xlWorkSheet.Cells(48, col), xlWorkSheet.Cells(48, col)).Font.Bold = True
            'col TOTAL ZONA - TRANSACCIONES VENTA CREDITO
            xlWorkSheet.Range(xlWorkSheet.Cells(49, col), xlWorkSheet.Cells(49, col)).FormulaLocal = "=SUMA(" & help.ColName(col - lstSucursal.Count) & "49:" & help.ColName(col - 1) & "49)"
            xlWorkSheet.Range(xlWorkSheet.Cells(49, col), xlWorkSheet.Cells(49, col)).Font.Bold = True
            'col TOTAL ZONA - TRANSACCIONES VENTA TOTAL
            xlWorkSheet.Range(xlWorkSheet.Cells(50, col), xlWorkSheet.Cells(50, col)).FormulaLocal = "=SUMA(" & help.ColName(col - lstSucursal.Count) & "50:" & help.ColName(col - 1) & "50)"


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
        xlWorkSheet.Cells(46, col) = "SUBTOTALES"
        xlWorkSheet.Range(xlWorkSheet.Cells(46, col), xlWorkSheet.Cells(47, col)).Merge()
        'col SUBTOTALES - row TRANSACCIONES VENTA CONTADO
        xlWorkSheet.Range(xlWorkSheet.Cells(48, col), xlWorkSheet.Cells(48, col)).FormulaLocal = FormulaSubTotales_TranVentaContado
        xlWorkSheet.Range(xlWorkSheet.Cells(48, col), xlWorkSheet.Cells(48, col)).Font.Bold = True
        'col SUBTOTALES - row TRANSACCIONES VENTA CREDITO
        xlWorkSheet.Range(xlWorkSheet.Cells(49, col), xlWorkSheet.Cells(49, col)).FormulaLocal = FormulaSubTotales_TranVentaCredito
        xlWorkSheet.Range(xlWorkSheet.Cells(49, col), xlWorkSheet.Cells(49, col)).Font.Bold = True
        'col SUBTOTALES - row TRANSACCIONES VENTA TOTAL
        xlWorkSheet.Range(xlWorkSheet.Cells(50, col), xlWorkSheet.Cells(50, col)).FormulaLocal = FormulaSubTotales_TranVentaTotal

        col = col + 1

        'col T007-----------------------------------------------------------------------------------------------------------
        xlWorkSheet.Cells(46, col) = "T007"
        xlWorkSheet.Range(xlWorkSheet.Cells(45, col - 2), xlWorkSheet.Cells(45, col)).Merge()
        help.SetBordesCeldas_Medium(xlWorkSheet.Range(xlWorkSheet.Cells(46, col), xlWorkSheet.Cells(50, col)))
        xlWorkSheet.Cells(47, col) = "VENTA EMPRESA"
        'row TRANSACCIONES VENTA CONTADO
        xlWorkSheet.Cells(48, col) = (New ReporteBusinessLogic()).SelTransacVentaContadoPorTienda(_FechaIniRep, _FechaFinRep, "T007")
        xlWorkSheet.Range(xlWorkSheet.Cells(48, col), xlWorkSheet.Cells(48, col)).Font.Bold = True
        'row TRANSACCIONES VENTA CREDITO
        xlWorkSheet.Cells(49, col) = (New ReporteBusinessLogic()).SelTransacVentaCreditoPorTienda(_FechaIniRep, _FechaFinRep, "T007")
        xlWorkSheet.Range(xlWorkSheet.Cells(49, col), xlWorkSheet.Cells(49, col)).Font.Bold = True
        'row TRANSACCIONES VENTA TOTAL
        xlWorkSheet.Range(xlWorkSheet.Cells(50, col), xlWorkSheet.Cells(50, col)).FormulaLocal = "=SUMA(" & help.ColName(col) & "48:" & help.ColName(col) & "49)"

        col = col + 1

        'col TOTAL VAP-----------------------------------------------------------------------------------------------------------
        xlWorkSheet.Cells(46, col) = "TOTAL VAP"
        xlWorkSheet.Range(xlWorkSheet.Cells(46, col), xlWorkSheet.Cells(47, col)).Merge()
        'col TOTAL VAP - TRANSACCIONES VENTA CONTADO
        xlWorkSheet.Range(xlWorkSheet.Cells(48, col), xlWorkSheet.Cells(48, col)).FormulaLocal = "=" & help.ColName(col - 2) & "48+" & help.ColName(col - 1) & "48"
        xlWorkSheet.Range(xlWorkSheet.Cells(48, col), xlWorkSheet.Cells(48, col)).Font.Bold = True
        'col TOTAL VAP - TRANSACCIONES VENTA CREDITO
        xlWorkSheet.Range(xlWorkSheet.Cells(49, col), xlWorkSheet.Cells(49, col)).FormulaLocal = "=" & help.ColName(col - 2) & "49+" & help.ColName(col - 1) & "49"
        xlWorkSheet.Range(xlWorkSheet.Cells(49, col), xlWorkSheet.Cells(49, col)).Font.Bold = True
        'col TOTAL VAP - TRANSACCIONES VENTA TOTAL
        xlWorkSheet.Range(xlWorkSheet.Cells(50, col), xlWorkSheet.Cells(50, col)).FormulaLocal = "=" & help.ColName(col - 2) & "50+" & help.ColName(col - 1) & "50"

        '---------------------------------------------------------------------------------------------------------------------------
        'FORMATO CUADRO TRANSACCIONES
        '---------------------------------------------------------------------------------------------------------------------------
        help.SetBordesCeldas_Medium(xlWorkSheet.Range(xlWorkSheet.Cells(45, 2), xlWorkSheet.Cells(45, col)))
        help.SetBordesCeldas_Medium(xlWorkSheet.Range(xlWorkSheet.Cells(48, 1), xlWorkSheet.Cells(48, col)))
        help.SetBordesCeldas_Medium(xlWorkSheet.Range(xlWorkSheet.Cells(49, 1), xlWorkSheet.Cells(49, col)))
        help.SetBordesCeldas_Medium(xlWorkSheet.Range(xlWorkSheet.Cells(45, 1), xlWorkSheet.Cells(50, col)))
        help.SetBordesCeldas_Medium(xlWorkSheet.Range(xlWorkSheet.Cells(45, 1), xlWorkSheet.Cells(47, 1)))
        xlWorkSheet.Range(xlWorkSheet.Cells(45, 1), xlWorkSheet.Cells(47, col)).Interior.Color = RGB(217, 217, 217) 'gris
        xlWorkSheet.Range(xlWorkSheet.Cells(50, 1), xlWorkSheet.Cells(50, col)).Interior.Color = RGB(217, 217, 217) 'gris
        xlWorkSheet.Range(xlWorkSheet.Cells(50, 1), xlWorkSheet.Cells(50, col)).Font.Bold = True

        Marshal.ReleaseComObject(xlWorkSheet)
    End Sub

    Sub GenerarTicketPromedio()
        Dim xlWorkSheet As New Worksheet
        xlWorkSheet = _xlWorkBook.Worksheets.Item(2) '2: HOJA AVANCE SODIMAC
        xlWorkSheet.Select()

        xlWorkSheet.Cells(52, 1) = "TICKET PROMEDIO"
        xlWorkSheet.Range(xlWorkSheet.Cells(52, 1), xlWorkSheet.Cells(52, 1)).Font.Name = "Calibri"
        xlWorkSheet.Range(xlWorkSheet.Cells(52, 1), xlWorkSheet.Cells(52, 1)).Font.Size = 24
        xlWorkSheet.Range(xlWorkSheet.Cells(52, 1), xlWorkSheet.Cells(52, 1)).Font.Bold = True

        xlWorkSheet.Cells(53, 1) = "TICKET PROMEDIO"
        xlWorkSheet.Range(xlWorkSheet.Cells(53, 1), xlWorkSheet.Cells(55, 1)).Merge()
        xlWorkSheet.Range(xlWorkSheet.Cells(53, 1), xlWorkSheet.Cells(53, 1)).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
        xlWorkSheet.Range(xlWorkSheet.Cells(53, 1), xlWorkSheet.Cells(53, 1)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

        'formato previo celdas
        help.SetAllBorders_Thin(xlWorkSheet.Range(xlWorkSheet.Cells(53, 1), xlWorkSheet.Cells(55, 1 + _lstSucursal.Count + _lstZona.Count + 3)))
        help.SetAllBorders_Thin(xlWorkSheet.Range(xlWorkSheet.Cells(58, 1), xlWorkSheet.Cells(58, 1 + _lstSucursal.Count + _lstZona.Count + 3)))

        xlWorkSheet.Cells(56, 1) = "TICKET PROMEDIO VENTA CONTADO"
        xlWorkSheet.Cells(57, 1) = "TICKET PROMEDIO VENTA CREDITO"
        xlWorkSheet.Cells(58, 1) = "TICKET PROMEDIO TOTAL"

        Dim iniColTiendas As Integer = 2
        Dim col As Integer = iniColTiendas

        For i = 0 To _lstZona.Count - 1
            Dim local_i As Integer = i
            Dim lstSucursal As List(Of Sucursal) = _lstSucursal.FindAll(Function(x) x.IdZona = _lstZona.Item(local_i).IdZona)

            For j = 0 To lstSucursal.Count - 1
                xlWorkSheet.Cells(54, col) = (lstSucursal(j)).CodigoSucursal
                xlWorkSheet.Cells(55, col) = (lstSucursal(j)).Descripcion.ToUpper
                'row TICKET PROMEDIO VENTA CONTADO
                xlWorkSheet.Range(xlWorkSheet.Cells(56, col), xlWorkSheet.Cells(56, col)).FormulaLocal = "=" & help.ColName(col) & "9/" & help.ColName(col) & "48"
                'row TICKET PROMEDIO VENTA CREDITO
                xlWorkSheet.Range(xlWorkSheet.Cells(57, col), xlWorkSheet.Cells(57, col)).FormulaLocal = "=" & help.ColName(col) & "10/" & help.ColName(col) & "49"
                'row TICKET PROMEDIO VENTA TOTAL
                xlWorkSheet.Range(xlWorkSheet.Cells(58, col), xlWorkSheet.Cells(58, col)).FormulaLocal = "=" & help.ColName(col) & "11/" & help.ColName(col) & "50"
                col = col + 1
            Next

            'Merge para el nombre de la zona
            xlWorkSheet.Cells(53, col - lstSucursal.Count) = (_lstZona(i)).NombreZona
            xlWorkSheet.Range(xlWorkSheet.Cells(53, col - lstSucursal.Count), xlWorkSheet.Cells(53, col)).Merge()
            xlWorkSheet.Range(xlWorkSheet.Cells(53, col - lstSucursal.Count), xlWorkSheet.Cells(53, col)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
            xlWorkSheet.Range(xlWorkSheet.Cells(53, col - lstSucursal.Count), xlWorkSheet.Cells(53, col)).Font.Bold = True

            'col TOTAL ZONA
            xlWorkSheet.Cells(54, col) = (_lstZona(i)).NombreZona.Replace("ZONA", "TOTAL")
            xlWorkSheet.Range(xlWorkSheet.Cells(54, col), xlWorkSheet.Cells(55, col)).Merge()
            xlWorkSheet.Range(xlWorkSheet.Cells(54, col), xlWorkSheet.Cells(55, col)).Font.Bold = True
            xlWorkSheet.Range(xlWorkSheet.Cells(54, col), xlWorkSheet.Cells(55, col)).WrapText = True
            xlWorkSheet.Range(xlWorkSheet.Cells(54, col), xlWorkSheet.Cells(55, col)).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            help.SetBordesCeldas_Medium(xlWorkSheet.Range(xlWorkSheet.Cells(54, col), xlWorkSheet.Cells(58, col)))
            'col TOTAL ZONA - row TICKET PROMEDIO VENTA CONTADO
            xlWorkSheet.Range(xlWorkSheet.Cells(56, col), xlWorkSheet.Cells(56, col)).FormulaLocal = "=" & help.ColName(col) & "9/" & help.ColName(col) & "48"
            'col TOTAL ZONA - row TICKET PROMEDIO VENTA CREDITO
            xlWorkSheet.Range(xlWorkSheet.Cells(57, col), xlWorkSheet.Cells(57, col)).FormulaLocal = "=" & help.ColName(col) & "10/" & help.ColName(col) & "49"
            'col TOTAL ZONA - row TICKET PROMEDIO VENTA TOTAL
            xlWorkSheet.Range(xlWorkSheet.Cells(58, col), xlWorkSheet.Cells(58, col)).FormulaLocal = "=" & help.ColName(col) & "11/" & help.ColName(col) & "50"
            col = col + 1
        Next
        'col SUBTOTALES
        xlWorkSheet.Cells(54, col) = "SUBTOTALES"
        xlWorkSheet.Range(xlWorkSheet.Cells(54, col), xlWorkSheet.Cells(55, col)).Merge()
        'col SUBTOTALES - row TICKET PROMEDIO VENTA CONTADO 
        xlWorkSheet.Range(xlWorkSheet.Cells(56, col), xlWorkSheet.Cells(56, col)).FormulaLocal = "=" & help.ColName(col) & "9/" & help.ColName(col) & "48"
        'col SUBTOTALES - row TICKET PROMEDIO VENTA CREDITO
        xlWorkSheet.Range(xlWorkSheet.Cells(57, col), xlWorkSheet.Cells(57, col)).FormulaLocal = "=" & help.ColName(col) & "10/" & help.ColName(col) & "49"
        'col SUBTOTALES - row TICKET PROMEDIO VENTA TOTAL
        xlWorkSheet.Range(xlWorkSheet.Cells(58, col), xlWorkSheet.Cells(58, col)).FormulaLocal = "=" & help.ColName(col) & "11/" & help.ColName(col) & "50"

        col = col + 1

        'col T007-----------------------------------------------------------------------------------------------------------
        xlWorkSheet.Cells(54, col) = "T007"
        xlWorkSheet.Range(xlWorkSheet.Cells(53, col - 2), xlWorkSheet.Cells(53, col)).Merge()
        help.SetAllBorders_Medium(xlWorkSheet.Range(xlWorkSheet.Cells(54, col), xlWorkSheet.Cells(58, col)))

        xlWorkSheet.Cells(55, col) = "VENTA EMPRESA"
        'col T007 - row TICKET PROMEDIO VENTA CONTADO
        xlWorkSheet.Range(xlWorkSheet.Cells(56, col), xlWorkSheet.Cells(56, col)).FormulaLocal = "=" & help.ColName(col) & "9/" & help.ColName(col) & "48"
        'col T007 - row TICKET PROMEDIO VENTA CREDITO
        xlWorkSheet.Range(xlWorkSheet.Cells(57, col), xlWorkSheet.Cells(57, col)).FormulaLocal = "=" & help.ColName(col) & "10/" & help.ColName(col) & "49"
        'col T007 - row TICKET PROMEDIO VENTA TOTAL
        xlWorkSheet.Range(xlWorkSheet.Cells(58, col), xlWorkSheet.Cells(58, col)).FormulaLocal = "=" & help.ColName(col) & "11/" & help.ColName(col) & "50"

        col = col + 1

        'col TOTAL VAP-----------------------------------------------------------------------------------------------------------
        xlWorkSheet.Cells(54, col) = "TOTAL VAP"
        xlWorkSheet.Range(xlWorkSheet.Cells(54, col), xlWorkSheet.Cells(55, col)).Merge()
        'col TOTAL - row TICKET PROMEDIO VENTA CONTADO
        xlWorkSheet.Range(xlWorkSheet.Cells(56, col), xlWorkSheet.Cells(56, col)).FormulaLocal = "=" & help.ColName(col) & "9/" & help.ColName(col) & "48"
        'col TOTAL - row TICKET PROMEDIO VENTA CREDITO
        xlWorkSheet.Range(xlWorkSheet.Cells(57, col), xlWorkSheet.Cells(57, col)).FormulaLocal = "=" & help.ColName(col) & "10/" & help.ColName(col) & "49"
        'col TOTAL - row TICKET PROMEDIO VENTA TOTAL
        xlWorkSheet.Range(xlWorkSheet.Cells(58, col), xlWorkSheet.Cells(58, col)).FormulaLocal = "=" & help.ColName(col) & "11/" & help.ColName(col) & "50"

        '---------------------------------------------------------------------------------------------------------------------------
        'FORMATO CUADRO TICKET PROMEDIO
        '---------------------------------------------------------------------------------------------------------------------------
        help.SetBordesCeldas_Medium(xlWorkSheet.Range(xlWorkSheet.Cells(53, 2), xlWorkSheet.Cells(53, col)))
        help.SetBordesCeldas_Medium(xlWorkSheet.Range(xlWorkSheet.Cells(56, 1), xlWorkSheet.Cells(56, col)))
        help.SetBordesCeldas_Medium(xlWorkSheet.Range(xlWorkSheet.Cells(57, 1), xlWorkSheet.Cells(57, col)))
        help.SetBordesCeldas_Medium(xlWorkSheet.Range(xlWorkSheet.Cells(53, 1), xlWorkSheet.Cells(58, col)))
        help.SetBordesCeldas_Medium(xlWorkSheet.Range(xlWorkSheet.Cells(53, 1), xlWorkSheet.Cells(53, 1)))
        xlWorkSheet.Range(xlWorkSheet.Cells(53, 1), xlWorkSheet.Cells(55, col)).Interior.Color = RGB(217, 217, 217) 'gris
        xlWorkSheet.Range(xlWorkSheet.Cells(58, 1), xlWorkSheet.Cells(58, col)).Interior.Color = RGB(217, 217, 217) 'gris
        xlWorkSheet.Range(xlWorkSheet.Cells(58, 1), xlWorkSheet.Cells(58, col)).Font.Bold = True

        Marshal.ReleaseComObject(xlWorkSheet)
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        Marshal.ReleaseComObject(Me._xlWorkBook)
    End Sub
End Class
