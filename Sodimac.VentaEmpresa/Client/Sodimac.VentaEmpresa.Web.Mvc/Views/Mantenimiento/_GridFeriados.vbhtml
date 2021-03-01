@ModelType Sodimac.VentaEmpresa.Web.Mvc.Models.ViewModel.FeriadosViewModel
<div id="contenedor-grid-GridFeriados">
    @code
        Dim grid As New WebGrid(rowsPerPage:=Model.Paginacion.RowsPerPage, ajaxUpdateContainerId:="contenedor-grid-GridFeriados", ajaxUpdateCallback:="PaintFooterGrid")
        grid.Bind(Model.ListaFeriados, autoSortAndPage:=False, rowCount:=Model.Paginacion.TotalRows)
        @grid.GetHtml(headerStyle:="fix_head", rowStyle:="fix_td", alternatingRowStyle:="fix_td", footerStyle:="pagination",
                                           htmlAttributes:=New With {.id = "GridFeriados", .class = "tDefault"},
                                           mode:=WebGridPagerModes.All,
                                           firstText:="<< Primera",
                                           previousText:="< Anterior",
                                           nextText:="Siguiente >",
                                           lastText:="Última >>",
                                           columns:=grid.Columns(
                                               grid.Column("NombreMes", "Mes", canSort:=True, style:="person"),
                                               grid.Column("Dia", "Dia", canSort:=True, style:="person"),
                                               grid.Column("Descripcion", "Descripcion", canSort:=True, style:="person"),
                                               grid.Column("DescripcionAnio", "Modalidad", canSort:=True, style:="person"),
                                               grid.Column(header:="Editar", style:="center", format:=
                                               Function(item)
                                                       If (item.Activo = True) Then
                                                           Return Html.Raw(String.Format("<a class='edit_table' title='Editar' data='{0}'></a>", item.IdFeriado))
                                                       Else
                                                           Return Html.Raw(String.Format("<a class='edit_table_disable' title='Editar' data='{0}'></a>", item.IdFeriado))
                                                       End If
                                               End Function),
                                               grid.Column(header:="Activar / Inactivar", style:="center", format:=
                                               Function(item)
                                                       If (item.Activo = True) Then
                                                           Return Html.Raw(String.Format("<a class='Asistio delete-register' title='Inactivar' data='{0}'></a>", item.IdFeriado))
                                                       Else
                                                           Return Html.Raw(String.Format("<a class='desactivar_table delete-register' title='Activar' data='{0}'></a>", item.IdFeriado))
                                                       End If
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