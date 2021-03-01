@ModelType Sodimac.VentaEmpresa.Web.Mvc.MantenimientoViewModel
<div id="contenedor-grid-DetalleCotizacion">
    @Code
        Dim gridCargo As New WebGrid(rowsPerPage:=Model.Paginacion.PageSize, ajaxUpdateContainerId:="contenedor-grid-DetalleCotizacion", ajaxUpdateCallback:="SetTotalRegistrosDetalleCotizacion")
        gridCargo.Bind(Model.Paginacion.ListaDetalleCotizacion, autoSortAndPage:=False, rowCount:=Model.Paginacion.TotalRows)
        @gridCargo.GetHtml(
                                                  headerStyle:="fix_head", rowStyle:="fix_td", alternatingRowStyle:="fix_td", footerStyle:="pagination",
                                                  htmlAttributes:=New With {.id = "GrillaDetalleCotizacion", .class = "tDefault"},
                                                  mode:=WebGridPagerModes.All,
                                                  firstText:="<< Primera",
                                                  previousText:="< Anterior",
                                                  nextText:="Siguiente >",
                                                  lastText:="Última >>",
                                                  columns:=gridCargo.Columns(
                                                  gridCargo.Column("NroCotizacionDesc", "Nro. Cotización", canSort:=False, style:="person"),
                                                  gridCargo.Column("Sku", "Sku", canSort:=True, style:="person"),
                                                  gridCargo.Column("Producto", "Producto", canSort:=True, style:="person"),
                                                  gridCargo.Column("PrecioTiendaDesc", "Precio Tienda", canSort:=False, style:="person"),
                                                  gridCargo.Column("PrecioVolumenDesc", "Precio VVEE", canSort:=False, style:="person"),
                                                  gridCargo.Column("PrecioSinIgvDesc", "Precio VVEE Sin Igv", canSort:=False, style:="person"),
                                                  gridCargo.Column("Cantidad", "Cantidad", canSort:=False, style:="person"),
                                                  gridCargo.Column("TotalDesc", "Total", canSort:=False, style:="person")
                                                  )
                                                  )
        @Html.HiddenFor(Function(m) m.Paginacion.DescRegistrosPorPaginas, New With {.id = "hdfTotalRegistros"})
        @Html.HiddenFor(Function(m) m.Paginacion.ListaDetalleCotizacion.Count, New With {.id = "countListaDetalleCotizacion"})
        @Html.HiddenFor(Function(m) m.Paginacion.DetalleCotizacion.NroCotizacion, New With {.id = "hdfNroCotizacion"})
    End Code
    @If (Not Model.Paginacion.ListaDetalleCotizacion Is Nothing) Then
        If (Not Model.Paginacion.ListaDetalleCotizacion.Count = 0) Then
            @<script type="text/javascript" language="javascript">
                 $("#GrillaDetalleCotizacion tfoot tr:last td").prepend("<a id='tfootPage' class='total_registros'></a>");
                 $("#tfootPage").html($('#hdfTotalRegistros').val());

                 $(function () {
                     $('th a, tfoot a').live('click', function () {
                         $(this).attr('href', '#GrillaDetalleCotizacion');
                         return false;
                     });
                 });
            </script>
        Else
            @<span>&nbsp;&nbsp;&nbsp;No se encontraron resultados</span>
        End If
    Else
        @<span>&nbsp;&nbsp;&nbsp;No se encontraron resultados</span>
    End If
</div>