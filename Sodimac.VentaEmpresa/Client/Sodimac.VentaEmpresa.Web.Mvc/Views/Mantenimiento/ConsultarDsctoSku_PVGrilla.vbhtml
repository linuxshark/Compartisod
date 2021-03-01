@ModelType Sodimac.VentaEmpresa.Web.Mvc.MantenimientoViewModel
<div id="contenedor-grid-DescuentoSku">
    @Code
        Dim gridCargo As New WebGrid(rowsPerPage:=Model.Paginacion.PageSize, ajaxUpdateContainerId:="contenedor-grid-DescuentoSku", ajaxUpdateCallback:="SetTotalRegistrosDescuentoSku")
        gridCargo.Bind(Model.Paginacion.ListaDescuentoSku, autoSortAndPage:=False, rowCount:=Model.Paginacion.TotalRows)
        @gridCargo.GetHtml(
                  headerStyle:="fix_head", rowStyle:="fix_td", alternatingRowStyle:="fix_td", footerStyle:="pagination",
                  htmlAttributes:=New With {.id = "GrillaDescuentoSku", .class = "tDefault"},
                  mode:=WebGridPagerModes.All,
                  firstText:="<< Primera",
                  previousText:="< Anterior",
                  nextText:="Siguiente >",
                  lastText:="Última >>",
                  columns:=gridCargo.Columns(
                  gridCargo.Column("CodigoSku", "Codigo Sku", canSort:=True, style:="person"),
                  gridCargo.Column("NombreSku", "Nombre Sku", canSort:=True, style:="person"),
                  gridCargo.Column("CantidadDesde", "Desde", canSort:=False, style:="person"),
                  gridCargo.Column("CantidadHasta", "Hasta", canSort:=False, style:="person"),
                  gridCargo.Column("MargenDsctoDsc", "Margen Dscto", canSort:=False, style:="person"),
                  gridCargo.Column("DescuentoDsc", "Descuento", canSort:=False, style:="person"),
                gridCargo.Column("", "Eliminar", style:="center", format:=
                 Function(item)
                     Dim control As String
                     control = String.Format("<a class={0}desactivar_table{0} title= {0}Eliminar Cargo{0} onClick={0}DialogEliminarDescuentoSku('" & item.IdDescuentoSku.ToString() & "'){0}/>", Chr(34))
                     Return Html.Raw(control)
                 End Function
                 )
                                 )
                                 )
        @Html.HiddenFor(Function(m) m.Paginacion.DescRegistrosPorPaginas, New With {.id = "hdfTotalRegistros"})
        @Html.HiddenFor(Function(m) m.Paginacion.ListaDescuentoSku.Count, New With {.id = "countListaDescuentoSku"})
    End Code
    @If (Not Model.Paginacion.ListaDescuentoSku Is Nothing) Then
        If (Not Model.Paginacion.ListaDescuentoSku.Count = 0) Then
            @<script type="text/javascript" language="javascript">
                $("#GrillaDescuentoSku tfoot tr:last td").prepend("<a id='tfootPage' class='total_registros'></a>");
                 $("#tfootPage").html($('#hdfTotalRegistros').val());

                 $(function () {
                     $('th a, tfoot a').live('click', function () {
                         $(this).attr('href', '#GrillaDescuentoSku');
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