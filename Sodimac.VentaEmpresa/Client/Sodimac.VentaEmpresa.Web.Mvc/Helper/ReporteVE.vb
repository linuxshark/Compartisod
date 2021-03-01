Imports Microsoft.Office.Interop.Excel
Imports System.Runtime.InteropServices
Imports System.Collections.Generic
Imports System.IO
Imports System.Configuration
Imports System.Web
Imports Sodimac.VentaEmpresa.DataContracts
Imports Sodimac.VentaEmpresa.BusinessLogic
Imports OfficeOpenXml
Imports OfficeOpenXml.Style

Public Class ReporteVE

    Public Sub GenerarReporteCarteraClientes(ByVal datos As List(Of ClienteCartera), ruta As String, nombreArchivo As String)
        Dim ep As New ExcelPackage
        Dim xlWorkSheet As ExcelWorksheet

        ep.Workbook.Worksheets.Add("Hoja1")
        xlWorkSheet = ep.Workbook.Worksheets.Item(1)
        xlWorkSheet.Select()

        Dim fila As Integer = 1
        Dim colu As Integer = 1

        xlWorkSheet.Cells(fila, 1, datos.Count + 2, 4).Style.Font.Name = "Arial"

        'SECCIÓN DE TÍTULO
        'xlWorkSheet.Cells(fila, 1).Value = "REPORTE CARTERA DE CLIENTES - SGVE"
        'xlWorkSheet.Cells(fila, 1, fila, 4).Style.Font.Name = "Arial"
        'xlWorkSheet.Cells(fila, 1, fila, 4).Style.Font.Size = 14
        'xlWorkSheet.Cells(fila, 1, fila, 4).Style.Font.Bold = True
        'xlWorkSheet.Cells(fila, 1, fila, 4).Merge = True
        'xlWorkSheet.Cells(fila, 1, fila, 4).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
        'xlWorkSheet.Cells(fila, 1, fila, 4).Style.VerticalAlignment = ExcelVerticalAlignment.Center

        'SECCIÓN DE CABECERAS
        fila = fila + 1
        xlWorkSheet.Cells(fila, 1).Value = "RUC"
        xlWorkSheet.Cells(fila, 2).Value = "Razón Social"
        xlWorkSheet.Cells(fila, 3).Value = "Código Sucursal"
        xlWorkSheet.Cells(fila, 4).Value = "Sucursal"
        xlWorkSheet.Cells(fila, 5).Value = "Código Ofisis"
        xlWorkSheet.Cells(fila, 6).Value = "Inicio"
        xlWorkSheet.Cells(fila, 7).Value = "Fin"
        xlWorkSheet.Cells(fila, 8).Value = "Mes"
        xlWorkSheet.Cells(fila, 9).Value = "Año"
        xlWorkSheet.Cells(fila, 10).Value = "Fecha de Carga"

        xlWorkSheet.Cells(fila, 1, fila, 10).Style.Font.Bold = True
        xlWorkSheet.Cells(fila, 1, fila, 10).Style.Font.Size = 10
        xlWorkSheet.Cells(fila, 1, fila, 10).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
        xlWorkSheet.Cells(fila, 1, fila, 10).Style.VerticalAlignment = ExcelVerticalAlignment.Center

        xlWorkSheet.Cells(fila, 1, fila, 10).Style.Border.Top.Style = ExcelBorderStyle.Medium
        xlWorkSheet.Cells(fila, 1, fila, 10).Style.Border.Bottom.Style = ExcelBorderStyle.Medium
        xlWorkSheet.Cells(fila, 1, fila, 10).Style.Border.Left.Style = ExcelBorderStyle.Medium
        xlWorkSheet.Cells(fila, 1, fila, 10).Style.Border.Right.Style = ExcelBorderStyle.Medium

        'SECCIÓN DE DETALLE
        If datos.Count > 0 Then
            For i = 0 To datos.Count - 1
                fila = fila + 1
                xlWorkSheet.Cells(fila, 1).Value = (datos(i)).RUC
                xlWorkSheet.Cells(fila, 2).Value = (datos(i)).RazonSocial
                xlWorkSheet.Cells(fila, 3).Value = (datos(i)).CodigoSucursal
                xlWorkSheet.Cells(fila, 4).Value = (datos(i)).Sucursal
                xlWorkSheet.Cells(fila, 5).Value = (datos(i)).CodigoOfisis
                xlWorkSheet.Cells(fila, 6).Value = (datos(i)).Fechainicio
                xlWorkSheet.Cells(fila, 7).Value = (datos(i)).FechaFin
                xlWorkSheet.Cells(fila, 8).Value = (datos(i)).Mes
                xlWorkSheet.Cells(fila, 9).Value = (datos(i)).Anio
                xlWorkSheet.Cells(fila, 10).Value = (datos(i)).FechaRegistro

            Next
            xlWorkSheet.Cells(3, 1, datos.Count + 2, 10).Style.Font.Size = 10
            xlWorkSheet.Cells(3, 1, datos.Count + 2, 10).Style.VerticalAlignment = ExcelVerticalAlignment.Center
            xlWorkSheet.Cells(3, 10, datos.Count + 2, 10).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center

            xlWorkSheet.Cells(3, 1, datos.Count + 2, 10).Style.Border.Top.Style = ExcelBorderStyle.Thin
            xlWorkSheet.Cells(3, 1, datos.Count + 2, 10).Style.Border.Bottom.Style = ExcelBorderStyle.Thin
            xlWorkSheet.Cells(3, 1, datos.Count + 2, 10).Style.Border.Left.Style = ExcelBorderStyle.Thin
            xlWorkSheet.Cells(3, 1, datos.Count + 2, 10).Style.Border.Right.Style = ExcelBorderStyle.Thin
        End If

    'AUTOAJUSTAR ANCHO COLUMNAS
    For j = 1 To 4
            xlWorkSheet.Column(j).AutoFit()
        Next

    Dim bt As Byte()
        bt = ep.GetAsByteArray()
        System.IO.File.WriteAllBytes(ruta + nombreArchivo, bt)

    End Sub

    Public Sub GenerarExcel(idMarca As Integer, NomMarca As String, fechaInicio As Date, fechaFin As Date)
        Dim xlApp As Microsoft.Office.Interop.Excel.Application = New Microsoft.Office.Interop.Excel.Application()
        Dim xlWorkBook As Workbook
        Dim xlWorkSheet As New Worksheet

        Dim misValue As Object = System.Reflection.Missing.Value

        Dim lstZona As List(Of Zona)
        Dim lstSucursal As List(Of Sucursal)
        Dim lstNombreHojas As New List(Of String)

        If (xlApp Is Nothing) Then
            Console.WriteLine("Excel is not properly installed.")
            Return
        End If

        'xlApp.Visible = True
        'xlApp.DisplayAlerts = False

        'xlWorkBook = xlApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet)
        'xlWorkSheet = xlWorkBook.Worksheets(1)

        xlWorkBook = CType(xlApp.Workbooks.Add(misValue), Workbook)
        xlWorkSheet = CType(xlWorkBook.Sheets(1), Worksheet)
        'lstNombreHojas.Add("RESUMEN")
        'lstNombreHojas.Add("AVANCE " + NomMarca)
        'lstNombreHojas.Add("DETALLADO X DIA")
        'lstNombreHojas.Add("DETALLADO X FAMILIA")
        'lstNombreHojas.Add("COMP FAMILIA 15 VS 16")

        ' CrearHojas(xlWorkBook, xlWorkSheet, lstNombreHojas)

        'lstZona = (New ReporteBusinessLogic()).ListaZonas()
        'lstSucursal = (New ReporteBusinessLogic()).ListaSucursalesPorZona(0)

        'Dim hojaRESUMEN As New HojaResumen(xlWorkBook)
        'HojaResumen.Generar(1 + (lstSucursal.Count + lstZona.Count) + 3)

        'Dim hojaAVANCE As New HojaAvanceSodimac(xlWorkBook, fechaInicio, fechaFin, lstZona, lstSucursal, idMarca)
        'hojaAVANCE.Generar()

        'Dim hojaDetalleXDia As New HojaDetalladoXDia(xlWorkBook, fechaInicio, fechaFin, lstZona, lstSucursal)
        'hojaDetalleXDia.Generar()

        'Dim hojaDetalleXFamilia As New HojaDetalladoXFamilia(xlWorkBook, fechaInicio, fechaFin, lstZona, lstSucursal)
        'hojaDetalleXFamilia.Generar()

        'Dim hojaComp As New HojaCOMPS(xlWorkBook, fechaInicio, fechaFin, idMarca)
        'hojaComp.Generar()

        Dim FileNameOnServer As String = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings("PathArchivo") + ConfigurationManager.AppSettings("fileNameReporteVE"))
        'Dim FileNameOnServer As String = "D:\SODIMAC\ReporteVE_Test\ReporteVE\ReporteVE\ArchivoExcel\ReporteVE.xlsx"

        xlWorkBook.SaveAs(FileNameOnServer)
        xlWorkBook.Close()
        xlApp.Quit()

        'Marshal.ReleaseComObject(xlWorkSheet)
        'Marshal.ReleaseComObject(xlWorkBook)
        'Marshal.ReleaseComObject(xlApp)
    End Sub

    Private Sub CrearHojas(xlWorkBook As Workbook, xlWorkSheet As Worksheet, lista As List(Of String))
        For i = 1 To lista.Count
            xlWorkBook.Worksheets.Add()
        Next

        For i = 0 To lista.Count - 1
            xlWorkSheet = xlWorkBook.Worksheets(i + 1)
            xlWorkSheet.Name = lista(i)
        Next
    End Sub


    'CREAR EXCEL EPPLUS
    Public Sub CrearExcel_EPPlus(marca As String, NomMarca As String, fechaInicio As Date, fechaFin As Date, Path As String, fileName As String)
        Dim lstZona As List(Of Zona)
        Dim lstSucursal As List(Of Sucursal)
        Dim lstNombreHojas As New List(Of String)

        lstNombreHojas.Add("RESUMEN")
        lstNombreHojas.Add("AVANCE " + NomMarca)
        lstNombreHojas.Add("DETALLADO X DIA")
        lstNombreHojas.Add("DETALLADO X FAMILIA")
        lstNombreHojas.Add("COMP FAMILIA 15 VS 16")

        Dim p As New ExcelPackage
        CrearHojas_EEPlus(p, lstNombreHojas)

        lstZona = (New ReporteBusinessLogic()).ListaZonas()
        lstSucursal = (New ReporteBusinessLogic()).ListaSucursalesPorZona(0)

        Dim resumen As New Resumen(p.Workbook)
        resumen.Generar(1 + (lstSucursal.Count + lstZona.Count) + 3, NomMarca)

        Dim avance As New AvanceSodimac(p.Workbook, fechaInicio, fechaFin, lstZona, lstSucursal, marca)
        avance.Generar()

        Dim detalleXDia As New detalleXDia(p.Workbook, fechaInicio, fechaFin, lstZona, lstSucursal)
        detalleXDia.Generar()

        Dim detallexfamilia As New detalleXFamilia(p.Workbook, fechaInicio, fechaFin, lstZona, lstSucursal)
        detallexfamilia.Generar()

        Dim comparativo As New Comparativo(p.Workbook, fechaInicio, fechaFin, marca)
        comparativo.Generar()

        Dim bin As Byte()
        bin = p.GetAsByteArray()
        System.IO.File.WriteAllBytes(Path + fileName, bin)
    End Sub

    Private Sub CrearHojas_EEPlus(p As ExcelPackage, lista As List(Of String))
        Dim ws As ExcelWorksheet
        For i = 1 To lista.Count
            p.Workbook.Worksheets.Add(lista.Item(i - 1))
        Next

        For i = 0 To lista.Count - 1
            ws = p.Workbook.Worksheets(i + 1)
            ws.Name = lista(i)
        Next
    End Sub

    Public Sub GenerarReporteUsuario(ByVal datos As List(Of Usuario), ruta As String, nombreArchivo As String)
        Dim ep As New ExcelPackage
        Dim xlWorkSheet As ExcelWorksheet

        ep.Workbook.Worksheets.Add("Hoja1")
        xlWorkSheet = ep.Workbook.Worksheets.Item(1)
        xlWorkSheet.Select()

        Dim fila As Integer = 1
        Dim colu As Integer = 1

        xlWorkSheet.Cells(fila, 1, datos.Count + 2, 7).Style.Font.Name = "Arial"

        'SECCIÓN DE TÍTULO
        xlWorkSheet.Cells(fila, 1).Value = "REPORTE DE USUARIOS - SGVE"
        xlWorkSheet.Cells(fila, 1, fila, 7).Style.Font.Name = "Arial"
        xlWorkSheet.Cells(fila, 1, fila, 7).Style.Font.Size = 14
        xlWorkSheet.Cells(fila, 1, fila, 7).Style.Font.Bold = True
        xlWorkSheet.Cells(fila, 1, fila, 7).Merge = True
        xlWorkSheet.Cells(fila, 1, fila, 7).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
        xlWorkSheet.Cells(fila, 1, fila, 7).Style.VerticalAlignment = ExcelVerticalAlignment.Center

        'SECCIÓN DE CABECERAS
        fila = fila + 1
        xlWorkSheet.Cells(fila, 1).Value = "Nombre Rol"
        xlWorkSheet.Cells(fila, 2).Value = "Usuario"
        xlWorkSheet.Cells(fila, 3).Value = "Usuario Nombre"
        xlWorkSheet.Cells(fila, 4).Value = "Email"
        xlWorkSheet.Cells(fila, 5).Value = "DNI"
        xlWorkSheet.Cells(fila, 6).Value = "Estado"
        xlWorkSheet.Cells(fila, 7).Value = "Fecha Última Sesión"

        xlWorkSheet.Cells(fila, 1, fila, 7).Style.Font.Bold = True
        xlWorkSheet.Cells(fila, 1, fila, 7).Style.Font.Size = 10
        xlWorkSheet.Cells(fila, 1, fila, 7).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
        xlWorkSheet.Cells(fila, 1, fila, 7).Style.VerticalAlignment = ExcelVerticalAlignment.Center

        xlWorkSheet.Cells(fila, 1, fila, 7).Style.Border.Top.Style = ExcelBorderStyle.Medium
        xlWorkSheet.Cells(fila, 1, fila, 7).Style.Border.Bottom.Style = ExcelBorderStyle.Medium
        xlWorkSheet.Cells(fila, 1, fila, 7).Style.Border.Left.Style = ExcelBorderStyle.Medium
        xlWorkSheet.Cells(fila, 1, fila, 7).Style.Border.Right.Style = ExcelBorderStyle.Medium

        'SECCIÓN DE DETALLE
        If datos.Count > 0 Then
            For i = 0 To datos.Count - 1
                fila = fila + 1
                xlWorkSheet.Cells(fila, 1).Value = (datos(i)).Rol.NombreRol
                xlWorkSheet.Cells(fila, 2).Value = (datos(i)).UsuarioUsu
                xlWorkSheet.Cells(fila, 3).Value = (datos(i)).UsuarioNom
                xlWorkSheet.Cells(fila, 4).Value = (datos(i)).Empleado.Email
                xlWorkSheet.Cells(fila, 5).Value = (datos(i)).Empleado.DNI
                xlWorkSheet.Cells(fila, 6).Value = (datos(i)).Estado
                xlWorkSheet.Cells(fila, 7).Value = (datos(i)).FechaSesion.ToString("dd/MM/yyyy HH:mm:ss")
            Next
            xlWorkSheet.Cells(3, 1, datos.Count + 2, 7).Style.Font.Size = 10
            xlWorkSheet.Cells(3, 1, datos.Count + 2, 7).Style.VerticalAlignment = ExcelVerticalAlignment.Center
            xlWorkSheet.Cells(3, 5, datos.Count + 2, 7).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center

            xlWorkSheet.Cells(3, 1, datos.Count + 2, 7).Style.Border.Top.Style = ExcelBorderStyle.Thin
            xlWorkSheet.Cells(3, 1, datos.Count + 2, 7).Style.Border.Bottom.Style = ExcelBorderStyle.Thin
            xlWorkSheet.Cells(3, 1, datos.Count + 2, 7).Style.Border.Left.Style = ExcelBorderStyle.Thin
            xlWorkSheet.Cells(3, 1, datos.Count + 2, 7).Style.Border.Right.Style = ExcelBorderStyle.Thin
        End If

        'AUTOAJUSTAR ANCHO COLUMNAS
        For j = 1 To 7
            xlWorkSheet.Column(j).AutoFit()
        Next

        Dim bt As Byte()
        bt = ep.GetAsByteArray()
        System.IO.File.WriteAllBytes(ruta + nombreArchivo, bt)

    End Sub

    Public Sub GenerarReporteRolPagina(ByVal datos As List(Of PaginaRol), ruta As String, nombreArchivo As String)
        Dim ep As New ExcelPackage
        Dim xlWorkSheet As ExcelWorksheet

        ep.Workbook.Worksheets.Add("Hoja1")
        xlWorkSheet = ep.Workbook.Worksheets.Item(1)
        xlWorkSheet.Select()

        Dim fila As Integer = 1
        Dim colu As Integer = 1
        Dim cantFil As Integer = datos.Count + 2 'cantidad filas detalle + titulo + cabeceras
        Dim cantCol As Integer = 3

        xlWorkSheet.Cells(fila, 1, cantFil, cantCol).Style.Font.Name = "Arial"

        'SECCIÓN DE TÍTULO
        xlWorkSheet.Cells(fila, 1).Value = "REPORTE DE ROLES Y PÁGINAS - SGVE"
        xlWorkSheet.Cells(fila, 1, fila, cantCol).Style.Font.Name = "Arial"
        xlWorkSheet.Cells(fila, 1, fila, cantCol).Style.Font.Size = 14
        xlWorkSheet.Cells(fila, 1, fila, cantCol).Style.Font.Bold = True
        xlWorkSheet.Cells(fila, 1, fila, cantCol).Merge = True
        xlWorkSheet.Cells(fila, 1, fila, cantCol).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
        xlWorkSheet.Cells(fila, 1, fila, cantCol).Style.VerticalAlignment = ExcelVerticalAlignment.Center

        'SECCIÓN DE CABECERAS
        fila = fila + 1
        xlWorkSheet.Cells(fila, 1).Value = "Nombre Rol"
        xlWorkSheet.Cells(fila, 2).Value = "Nombre Página"
        xlWorkSheet.Cells(fila, 3).Value = "Activo Página"

        xlWorkSheet.Cells(fila, 1, fila, cantCol).Style.Font.Bold = True
        xlWorkSheet.Cells(fila, 1, fila, cantCol).Style.Font.Size = 10
        xlWorkSheet.Cells(fila, 1, fila, cantCol).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
        xlWorkSheet.Cells(fila, 1, fila, cantCol).Style.VerticalAlignment = ExcelVerticalAlignment.Center

        xlWorkSheet.Cells(fila, 1, fila, cantCol).Style.Border.Top.Style = ExcelBorderStyle.Medium
        xlWorkSheet.Cells(fila, 1, fila, cantCol).Style.Border.Bottom.Style = ExcelBorderStyle.Medium
        xlWorkSheet.Cells(fila, 1, fila, cantCol).Style.Border.Left.Style = ExcelBorderStyle.Medium
        xlWorkSheet.Cells(fila, 1, fila, cantCol).Style.Border.Right.Style = ExcelBorderStyle.Medium

        'SECCIÓN DE DETALLE
        If datos.Count > 0 Then
            For i = 0 To datos.Count - 1
                fila = fila + 1
                xlWorkSheet.Cells(fila, 1).Value = datos(i).Rol.NombreRol
                xlWorkSheet.Cells(fila, 2).Value = datos(i).Pagina.NombrePagina
                xlWorkSheet.Cells(fila, 3).Value = datos(i).Pagina.EstadoPagina
            Next
            xlWorkSheet.Cells(3, 1, cantFil, cantCol).Style.Font.Size = 10
            xlWorkSheet.Cells(3, 1, cantFil, cantCol).Style.VerticalAlignment = ExcelVerticalAlignment.Center
            xlWorkSheet.Cells(3, 3, cantFil, cantCol).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center

            xlWorkSheet.Cells(3, 1, cantFil, cantCol).Style.Border.Top.Style = ExcelBorderStyle.Thin
            xlWorkSheet.Cells(3, 1, cantFil, cantCol).Style.Border.Bottom.Style = ExcelBorderStyle.Thin
            xlWorkSheet.Cells(3, 1, cantFil, cantCol).Style.Border.Left.Style = ExcelBorderStyle.Thin
            xlWorkSheet.Cells(3, 1, cantFil, cantCol).Style.Border.Right.Style = ExcelBorderStyle.Thin
        End If

        'AUTOAJUSTAR ANCHO COLUMNAS
        For j = 1 To cantCol
            xlWorkSheet.Column(j).AutoFit()
        Next

        Dim bt As Byte()
        bt = ep.GetAsByteArray()
        System.IO.File.WriteAllBytes(ruta + nombreArchivo, bt)

    End Sub
End Class
