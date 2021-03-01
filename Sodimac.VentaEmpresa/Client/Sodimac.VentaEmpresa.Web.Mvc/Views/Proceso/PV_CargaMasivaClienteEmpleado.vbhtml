@ModelType Sodimac.VentaEmpresa.Web.Mvc.CargaMasivaClienteViewModel

@If (Not Model.ListaClienteEmpleado Is Nothing) Then
    If (Not Model.ListaClienteEmpleado.Count = 0) Then
        Dim gridCMClienteEmpleado As New WebGrid(rowsPerPage:=Model.PaginacionClienteEmpleado.RowsPerPage, ajaxUpdateContainerId:="contenedor-grid-ClienteEmpleado", ajaxUpdateCallback:="PaintFooterGrid")
        gridCMClienteEmpleado.Bind(Model.ListaClienteEmpleado, autoSortAndPage:=False, rowCount:=Model.PaginacionClienteEmpleado.TotalRows)
    @gridCMClienteEmpleado.GetHtml(
                headerStyle:="fix_head", rowStyle:="fix_td", alternatingRowStyle:="fix_td", footerStyle:="pagination",
                htmlAttributes:=New With {.id = "dgvDatos", .class = "tDefault"},
                mode:=WebGridPagerModes.All,
                firstText:="<< Primera",
                previousText:="< Anterior",
                nextText:="Siguiente >",
                lastText:="Última >>",
                columns:=gridCMClienteEmpleado.Columns(gridCMClienteEmpleado.Column("ClienteVenta.RUC", "RUC", canSort:=True, style:="person"),
                gridCMClienteEmpleado.Column("Empleado.TablaGeneral.DescripcionTabGen", "Tipo Vendedor", canSort:=True, style:="person"),
                gridCMClienteEmpleado.Column("Empleado.Sucursal.CodigoSucursal", "Código Sucursal", canSort:=True, style:="person"),
                gridCMClienteEmpleado.Column("Empleado.CodigoOfisis", "Representante Ventas Código Ofisis", canSort:=True, style:="person"),
                gridCMClienteEmpleado.Column("Empleado.FechaAsignacion", "Fecha Asignación", canSort:=True, style:="person"),
                gridCMClienteEmpleado.Column("Empleado.Porcentaje", "Porcentaje", canSort:=True, style:="person")
                )
            )
    @Html.HiddenFor(Function(m) m.PaginacionClienteEmpleado.DescRegistrosPorPaginas, New With {.id = "hdfTotalRegistrosClienteEmpleado"})
End If
    @*Else
        @<span>&nbsp;&nbsp;&nbsp;Archivo vacío o se produjo un error</span>*@
End If

<script type="text/javascript" language="javascript">
    $(function () {
        $("#dgvDatos tfoot tr:last td").prepend("<a id='tfootPageCE' class='total_registros'></a>")
        $("#tfootPageCE").html($('#hdfTotalRegistrosClienteEmpleado').val())

    })

    $(function () {
        $('#dgvDatos tfoot a').click(function () {
            if ($(this).attr('class') == undefined) {
                $("#GrillaCMClienteEmpleado").load("/Proceso/CargarClienteEmpleado?page=" + $(this).attr('href').slice(-1))
                $(this).removeAttr('href');
            }
        });
    });

</script>