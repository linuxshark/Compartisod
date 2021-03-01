@ModelType Sodimac.VentaEmpresa.Web.Mvc.ProcesoViewModel

@If (Not Model.ListaClienteCartera Is Nothing) Then
    If (Not Model.ListaClienteCartera.Count = 0) Then
        Dim gridCMClienteCartera As New WebGrid(rowsPerPage:=Model.PaginacionCartera.RowsPerPage, ajaxUpdateContainerId:="contenedor-grid-Servicio", ajaxUpdateCallback:="Load")
        gridCMClienteCartera.Bind(Model.ListaClienteCartera, autoSortAndPage:=False, rowCount:=Model.PaginacionCartera.TotalRows)
        @gridCMClienteCartera.GetHtml(
                 headerStyle:="fix_head", rowStyle:="fix_td", alternatingRowStyle:="fix_td", footerStyle:="pagination",
                 htmlAttributes:=New With {.id = "dgvDatosCliente", .class = "tDefault"},
                 mode:=WebGridPagerModes.All,
                 firstText:="<< Primera",
                 previousText:="< Anterior",
                 nextText:="Siguiente >",
                 lastText:="Última >>",
                 columns:=gridCMClienteCartera.Columns(
                 gridCMClienteCartera.Column("RUC", "Razón Social", canSort:=True, style:="person"),
                 gridCMClienteCartera.Column("CodigoSucursal", "Código Sucursal", canSort:=True, style:="person"),
                 gridCMClienteCartera.Column("CodigoOfisis", "Código Ofisis", canSort:=True, style:="person"),
                 gridCMClienteCartera.Column("FechaInicio", "Inicio", canSort:=True, style:="person"),
                 gridCMClienteCartera.Column("FechaFin", "Fin", canSort:=True, style:="person"),
                 gridCMClienteCartera.Column("Mes", "Mes", canSort:=True, style:="person"),
                 gridCMClienteCartera.Column("Anio", "Año", canSort:=True, style:="person")
                 )
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              )
        @Html.HiddenFor(Function(m) m.PaginacionCartera.DescRegistrosPorPaginas, New With {.id = "hdfTotalRegistrosCliente"})

    End If
End If

<script type="text/javascript" language="javascript">
    $(function () {
        $("#dgvDatosCliente tfoot tr:last td").prepend("<a id='tfootPageC' class='total_registros'></a>")
        $("#tfootPageC").html($('#hdfTotalRegistrosCliente').val())

    })

    $(function () {
        $('#dgvDatosCliente tfoot a').click(function () {
            if ($(this).attr('class') == undefined) {
                $("#GrillaCMCliente").load("/Proceso/CargarCMClienteCartera?page=" + $(this).attr('href').slice(-1))
                $(this).removeAttr('href');
            }
        });
    });
</script>