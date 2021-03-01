@ModelType Sodimac.VentaEmpresa.Web.Mvc.MantenimientoViewModel
<div id="contenedor-grid-SkuBloqueado">
    @Code
        Dim gridCargo As New WebGrid(rowsPerPage:=Model.Paginacion.PageSize, ajaxUpdateContainerId:="contenedor-grid-SkuBloqueado", ajaxUpdateCallback:="SetTotalRegistrosSkuBloqueado")
        gridCargo.Bind(Model.Paginacion.ListaProducto, autoSortAndPage:=False, rowCount:=Model.Paginacion.TotalRows)
        @gridCargo.GetHtml(
            headerStyle:="fix_head", rowStyle:="fix_td", alternatingRowStyle:="fix_td", footerStyle:="pagination",
            htmlAttributes:=New With {.id = "GrillaSkuBloqueado", .class = "tDefault"},
            mode:=WebGridPagerModes.All,
            firstText:="<< Primera",
            previousText:="< Anterior",
            nextText:="Siguiente >",
            lastText:="Última >>",
            columns:=gridCargo.Columns(
            gridCargo.Column("Sku", "Codigo Sku", canSort:=True, style:="person"),
            gridCargo.Column("Descripcion", "Nombre Sku", canSort:=True, style:="person"),
            gridCargo.Column("", "Eliminar", style:="center", format:=
            Function(item)
                Dim control As String
                control = String.Format("<a class={0}desactivar_table{0} title={0}Eliminar Cargo{0} onClick={0}DialogEliminarSkuBloqueado('" & item.Sku.ToString() & "'){0}/>", Chr(34))
                Return Html.Raw(control)
            End Function
                                        )
                                        )
                                        )
        @Html.HiddenFor(Function(m) m.Paginacion.DescRegistrosPorPaginas, New With {.id = "hdfTotalRegistros"})
        @Html.HiddenFor(Function(m) m.Paginacion.ListaProducto.Count, New With {.id = "countListaSkuBloqueado"})
    End Code
    @If (Not Model.Paginacion.ListaProducto Is Nothing) Then
        If (Not Model.Paginacion.ListaProducto.Count = 0) Then
            @<script type="text/javascript" language="javascript">
                $("#GrillaSkuBloqueado tfoot tr:last td").prepend("<a id='tfootPage' class='total_registros'></a>");
                 $("#tfootPage").html($('#hdfTotalRegistros').val());

                 $(function () {
                     $('th a, tfoot a').live('click', function () {
                         $(this).attr('href', '#GrillaSkuBloqueado');
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