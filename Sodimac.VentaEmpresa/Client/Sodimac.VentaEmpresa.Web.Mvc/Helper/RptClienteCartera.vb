Imports OfficeOpenXml
Imports Sodimac.VentaEmpresa.DataContracts
Imports OfficeOpenXml.Style
Imports System.Drawing

Public Class RptClienteCartera

    Dim _wb As ExcelWorkbook

    Sub New(wb As ExcelWorkbook)
        Me._wb = wb
    End Sub

    Public Sub CrearExcel_ClienteCartera(lista As List(Of ReporteClienteCartera), cabecera As List(Of String))
        Dim ws As ExcelWorksheet
        ws = _wb.Worksheets.Add("CarteraCliente")
        ws.Select()

        Dim fila = lista.Count() - 1
        Dim n = 0

        For i = 0 To fila
            If i.Equals(0) Then
                n = n + 1
                ws.Cells(n, 1).Value = cabecera(0)
                ws.Cells(n, 2).Value = cabecera(1)
                ws.Cells(n, 3).Value = cabecera(2)
                ws.Cells(n, 4).Value = cabecera(3)
                ws.Cells(n, 5).Value = cabecera(4)
                ws.Cells(n, 6).Value = cabecera(5)
                ws.Cells(n, 7).Value = cabecera(6)
                ws.Cells(n, 8).Value = cabecera(7)
                ws.Cells(n, 9).Value = cabecera(8)
                ws.Cells(n, 10).Value = cabecera(9)
                ws.Cells(n, 11).Value = cabecera(10)
                ws.Cells(n, 12).Value = cabecera(11)
                ws.Cells(n, 13).Value = cabecera(12)
                ws.Cells(n, 14).Value = cabecera(13)
                ws.Cells(n, 15).Value = cabecera(14)
                ws.Cells(n, 16).Value = cabecera(15)
                ws.Cells(n, 17).Value = cabecera(16)
                ws.Cells(n, 18).Value = cabecera(17)
                ws.Cells(n, 19).Value = cabecera(18)
                ws.Cells(n, 20).Value = cabecera(19)
                ws.Cells(n, 21).Value = cabecera(20)
                ws.Cells(n, 22).Value = cabecera(21)
                ws.Cells(n, 23).Value = cabecera(22)
                ws.Cells(n, 24).Value = cabecera(23)
                ws.Cells(n, 25).Value = cabecera(24)
                ws.Cells(n, 26).Value = cabecera(25)

                ws.Cells(n, 27).Value = cabecera(26)
                ws.Cells(n, 28).Value = cabecera(27)
                ws.Cells(n, 29).Value = cabecera(28)
                ws.Cells(n, 30).Value = cabecera(29)
                ws.Cells(n, 31).Value = cabecera(30)
                ws.Cells(n, 32).Value = cabecera(31)
                ws.Cells(n, 33).Value = cabecera(32)

                ws.Cells(n, 1, n, 33).Style.Border.Top.Style = ExcelBorderStyle.Thin
                ws.Cells(n, 1, n, 33).Style.Border.Left.Style = ExcelBorderStyle.Thin
                ws.Cells(n, 1, n, 33).Style.Border.Right.Style = ExcelBorderStyle.Thin
                ws.Cells(n, 1, n, 33).Style.Border.Bottom.Style = ExcelBorderStyle.Thin
                ws.Cells(n, 1, n, 33).Style.Font.Bold = True
                ws.Cells(n, 1, n, 33).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center

                ws.Cells(n, 1, n, 13).Style.Fill.PatternType = ExcelFillStyle.Solid
                ws.Cells(n, 1, n, 13).Style.Fill.BackgroundColor.SetColor(Color.LightGray)

                ws.Cells(n, 14, n, 23).Style.Fill.PatternType = ExcelFillStyle.Solid
                ws.Cells(n, 14, n, 23).Style.Fill.BackgroundColor.SetColor(Color.Red)
                ws.Cells(n, 14, n, 23).Style.Font.Color.SetColor(Color.White)

                ws.Cells(n, 24, n, 27).Style.Fill.PatternType = ExcelFillStyle.Solid
                ws.Cells(n, 24, n, 27).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(146, 208, 80))

                ws.Cells(n, 28, n, 33).Style.Fill.PatternType = ExcelFillStyle.Solid
                ws.Cells(n, 28, n, 33).Style.Fill.BackgroundColor.SetColor(Color.Navy)
                ws.Cells(n, 28, n, 33).Style.Font.Color.SetColor(Color.White)

            Else
                n = n + 1
                ws.Cells(n, 1).Value = lista(n - 1).Empresa
                ws.Cells(n, 2).Value = lista(n - 1).Zona
                ws.Cells(n, 3).Value = lista(n - 1).SubGerente
                ws.Cells(n, 4).Value = lista(n - 1).JefeVenta
                ws.Cells(n, 5).Value = lista(n - 1).AsignRrvv
                ws.Cells(n, 6).Value = lista(n - 1).CodigoEmpleado
                ws.Cells(n, 7).Value = lista(n - 1).NombreRrvv
                ws.Cells(n, 8).Value = lista(n - 1).Sucursal
                ws.Cells(n, 9).Value = lista(n - 1).Ruc
                ws.Cells(n, 10).Value = lista(n - 1).RazonSocial
                ws.Cells(n, 11).Value = lista(n - 1).Sector
                ws.Cells(n, 12).Value = lista(n - 1).FechaCreacion
                ws.Cells(n, 13).Value = lista(n - 1).FechaAsignacion
                ws.Cells(n, 14).Value = lista(n - 1).ModoPago
                ws.Cells(n, 15).Value = lista(n - 1).FechaApertura
                ws.Cells(n, 16).Value = lista(n - 1).FechaExpiracion
                ws.Cells(n, 17).Value = lista(n - 1).DiasPlazo
                ws.Cells(n, 18).Value = lista(n - 1).LcSigic
                ws.Cells(n, 19).Value = lista(n - 1).FactSigic
                ws.Cells(n, 20).Value = lista(n - 1).LcDisponible
                ws.Cells(n, 21).Value = lista(n - 1).PorcentajeUtilizacion
                ws.Cells(n, 22).Value = lista(n - 1).EstadoLC
                ws.Cells(n, 23).Value = lista(n - 1).EstadoCliente
                ws.Cells(n, 24).Value = lista(n - 1).VentaTotalCredito
                ws.Cells(n, 25).Value = lista(n - 1).VentaTotalOracleCredito
                ws.Cells(n, 26).Value = lista(n - 1).VentaTotalContado

                ws.Cells(n, 27).Value = lista(n - 1).VentaTotalOracleContado
                ws.Cells(n, 28).Value = lista(n - 1).TotalVentasAvance
                ws.Cells(n, 29).Value = lista(n - 1).TotalCosto
                ws.Cells(n, 30).Value = lista(n - 1).TotalContribucion
                ws.Cells(n, 31).Value = lista(n - 1).MargenContribucion
                ws.Cells(n, 32).Value = lista(n - 1).VentaSodimac
                ws.Cells(n, 33).Value = lista(n - 1).VentaMaestro

                ws.Cells(n, 18, n, 20).Style.Numberformat.Format = "#,##0"
                ws.Cells(n, 23, n, 30).Style.Numberformat.Format = "#,##0"
                ws.Cells(n, 32, n, 33).Style.Numberformat.Format = "#,##0"
                ws.Cells(n, 21).Style.Numberformat.Format = "#,##0.00%"
                ws.Cells(n, 31).Style.Numberformat.Format = "#,##0.00%"

                'Alineaciones
                ws.Cells(n, 1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                ws.Cells(n, 2).Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                ws.Cells(n, 3).Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                ws.Cells(n, 4).Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                ws.Cells(n, 5).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                ws.Cells(n, 6).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                ws.Cells(n, 7).Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                ws.Cells(n, 8).Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                ws.Cells(n, 9).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                ws.Cells(n, 10).Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                ws.Cells(n, 11).Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                ws.Cells(n, 12).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                ws.Cells(n, 13).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                ws.Cells(n, 14).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                ws.Cells(n, 15).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                ws.Cells(n, 16).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                ws.Cells(n, 17).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                ws.Cells(n, 18).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                ws.Cells(n, 19).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                ws.Cells(n, 20).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                ws.Cells(n, 21).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                ws.Cells(n, 22).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                ws.Cells(n, 23).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                ws.Cells(n, 24).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                ws.Cells(n, 25).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                ws.Cells(n, 26).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                ws.Cells(n, 27).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                ws.Cells(n, 28).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                ws.Cells(n, 29).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                ws.Cells(n, 30).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                ws.Cells(n, 31).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                ws.Cells(n, 32).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                ws.Cells(n, 33).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right

            End If
        Next

        For a = 1 To 36
            ws.Column(a).AutoFit()
        Next

    End Sub

End Class
