@ModelType Sodimac.VentaEmpresa.Web.Mvc.Models.ViewModel.ProveedorViewModel
<div id="contenedor-grid-GridSkuProv">
    @Code
        Dim grid As New WebGrid(rowsPerPage:=Model.Paginacion.RowsPerPage, canPage:=True, ajaxUpdateContainerId:="contenedor-grid-GridSkuProv", ajaxUpdateCallback:="PaintFooterGridSkuProv")
        grid.Bind(Model.ListaProducto, autoSortAndPage:=False, rowCount:=Model.Paginacion.TotalRows)
        @grid.GetHtml(
                           headerStyle:="fix_head", rowStyle:="fix_td", alternatingRowStyle:="fix_td", footerStyle:="pagination",
                           htmlAttributes:=New With {.id = "GridSkuProv", .class = "tDefault"},
                           mode:=WebGridPagerModes.All,
                           firstText:="<< Primera",
                           previousText:="< Anterior",
                           nextText:="Siguiente >",
                           lastText:="Última >>",
                           columns:=grid.Columns(
                                    grid.Column(header:="Item", style:="person", format:=Function(x)
                                                                                                 If (x.Estado) Then
                                                                                                     If (x.Seleccion) Then
                                                                                                         Return Html.Raw(String.Format("<input type='checkbox' class='selectCheck' data='{0}' checked>", x.Sku))
                                                                                                     Else
                                                                                                         Return Html.Raw(String.Format("<input type='checkbox' class='selectCheck' data='{0}' >", x.Sku))
                                                                                                     End If
                                                                                                 Else
                                                                                                     Return Html.Raw(String.Format("<input type='checkbox' class='' data='{0}' disabled>", x.Sku))
                                                                                                 End If
                                                                                         End Function),
                                    grid.Column("Sku", "Sku", canSort:=True, style:="person"),
                                    grid.Column("Descripcion", "Descripción", canSort:=True, style:="person"),
                                    grid.Column(header:="Activo", style:="person", canSort:=False, format:=Function(x)
                                                                                                                   If (x.Estado) Then
                                                                                                                       Return Html.Raw("<a class='desactivar_table' title='Eliminar' data='{0}'></a>")
                                                                                                                   Else
                                                                                                                       Return Html.Raw("<a class='Asistio' title='Eliminar' data='{0}'></a>")
                                                                                                                   End If
                                                                                                           End Function))
                                )
        @Html.HiddenFor(Function(m) m.Paginacion.DescRegistrosPorPaginas, New With {.id = "FooterDescSkuProv"})
        @Html.HiddenFor(Function(m) m.Paginacion.TotalRows, New With {.id = "TotalRowsSkuProv"})
    End Code
</div>
<script>
    //PaintFooterGridSku();
</script>
