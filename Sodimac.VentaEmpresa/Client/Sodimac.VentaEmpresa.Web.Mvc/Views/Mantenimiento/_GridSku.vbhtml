@ModelType Sodimac.VentaEmpresa.Web.Mvc.Models.ViewModel.ProveedorViewModel
<div id="contenedor-grid-GridSku">

    @Code
        Dim grid As New WebGrid(rowsPerPage:=Model.Paginacion.RowsPerPage, ajaxUpdateContainerId:="contenedor-grid-GridSku", ajaxUpdateCallback:="PaintFooterGridSku")
        grid.Bind(Model.ListaProducto, autoSortAndPage:=False, rowCount:=Model.Paginacion.TotalRows)
    @grid.GetHtml(
                           headerStyle:="fix_head", rowStyle:="fix_td", alternatingRowStyle:="fix_td", footerStyle:="pagination",
                           htmlAttributes:=New With {.id = "GridSku", .class = "tDefault"},
                           mode:=WebGridPagerModes.All,
                           firstText:="<< Primera",
                           previousText:="< Anterior",
                           nextText:="Siguiente >",
                           lastText:="Última >>",
                           columns:=grid.Columns(
                                    grid.Column("Item", "Item", canSort:=True, style:="person"),
                                    grid.Column("Sku", "Sku", canSort:=True, style:="person"),
                                    grid.Column("Descripcion", "Descripción", canSort:=True, style:="person"),
                                    grid.Column(header:="Activar / Inactivar", style:="center", format:=
                                    Function(item)
                                            If (item.Estado = True) Then
                                                Return Html.Raw(String.Format("<a class='desactivar_table delete-registerSku' title='Eliminar' data='{0}' estado='{1}'></a>", item.Sku, item.Estado))
                                            Else
                                                Return Html.Raw(String.Format("<a class='Asistio delete-registerSku' title='Eliminar' data='{0}' estado='{1}'></a>", item.Sku, item.Estado))
                                            End If
                                    End Function))
                 )
    @Html.HiddenFor(Function(m) m.Paginacion.DescRegistrosPorPaginas, New With {.id = "FooterDescSku"})
    @Html.HiddenFor(Function(m) m.Paginacion.TotalRows, New With {.id = "TotalRowsSku"})
    End Code

</div>
<script>
    //PaintFooterGridSku();
</script>
