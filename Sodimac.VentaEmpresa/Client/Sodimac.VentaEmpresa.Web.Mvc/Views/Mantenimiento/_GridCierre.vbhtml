@ModelType Sodimac.VentaEmpresa.Web.Mvc.CierreViewModel
<div id="contenedor-grid-GridCierre">
    @code
        Dim grid As New WebGrid(rowsPerPage:=Model.Paginacion.RowsPerPage, ajaxUpdateContainerId:="contenedor-grid-GridCierre", ajaxUpdateCallback:="PaintFooterGrid")
        grid.Bind(Model.ListaCierre, autoSortAndPage:=False, rowCount:=Model.Paginacion.TotalRows)
        @grid.GetHtml(headerStyle:="fix_head", rowStyle:="fix_td", alternatingRowStyle:="fix_td", footerStyle:="pagination",
                                           htmlAttributes:=New With {.id = "dgvDatos", .class = "tDefault"},
                                           mode:=WebGridPagerModes.All,
                                           firstText:="<< Primera",
                                           previousText:="< Anterior",
                                           nextText:="Siguiente >",
                                           lastText:="Última >>",
                                           columns:=grid.Columns(
                                               grid.Column("Año", "Año", canSort:=True, style:="center"),
                                               grid.Column("NombreMes", "Mes", canSort:=True, style:="center"),
                                               grid.Column("FechaCierre", "Fecha de Cierre", canSort:=True, style:="center"),
                                               grid.Column("Estado", "Estado", canSort:=True, style:="center"),
                                               grid.Column(header:="Eliminar", style:="center", format:=
                                               Function(item)
                                                       Return Html.Raw(String.Format("<a class='desactivar_table eliminar_cierre' title='Eliminar' data='{0}'></a>", item.IdCierre))
                                               End Function)
                                           ))

        @Html.HiddenFor(Function(m) m.Paginacion.DescRegistrosPorPaginas, New With {.id = "FooterDesc"})
        @Html.HiddenFor(Function(m) m.Paginacion.TotalRows, New With {.id = "TotalRows"})
    End Code
</div>
<style>
    .bGridProv {
        padding: 2px 10px !important;
    }
</style>