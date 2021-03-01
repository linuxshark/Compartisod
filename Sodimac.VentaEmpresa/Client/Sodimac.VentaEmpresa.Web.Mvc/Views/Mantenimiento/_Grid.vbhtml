@ModelType Sodimac.VentaEmpresa.Web.Mvc.Models.ViewModel.ProveedorViewModel
<div id="contenedor-grid-GridProovedor">
    @Code
        Dim grid As New WebGrid(rowsPerPage:=Model.Paginacion.RowsPerPage, ajaxUpdateContainerId:="contenedor-grid-GridProovedor", ajaxUpdateCallback:="PaintFooterGrid")
        grid.Bind(Model.ListaProveedor, autoSortAndPage:=False, rowCount:=Model.Paginacion.TotalRows)
        @grid.GetHtml(
                                           headerStyle:="fix_head", rowStyle:="fix_td", alternatingRowStyle:="fix_td", footerStyle:="pagination",
                                           htmlAttributes:=New With {.id = "GridProveedor", .class = "tDefault"},
                                           mode:=WebGridPagerModes.All,
                                           firstText:="<< Primera",
                                           previousText:="< Anterior",
                                           nextText:="Siguiente >",
                                           lastText:="Última >>",
                                           columns:=grid.Columns(
                                               grid.Column("EmpresaDescripcion", "Empresa", canSort:=True, style:="person"),
                                               grid.Column("Ruc", "Ruc", canSort:=True, style:="person"),
                                               grid.Column("RazonSocial", "Razon Social", canSort:=True, style:="person"),
                                               grid.Column("Numero", "Número", canSort:=True, style:="person"),
                                               grid.Column("Direccion", "Dirección", canSort:=True, style:="person"),
                                               grid.Column(header:="Editar", style:="center", format:=
                                               Function(item)
                                                       Return Html.Raw(String.Format("<a class='edit_table' title='Editar' data='{0}'></a>", item.IdProveedor))
                                               End Function),
                                               grid.Column(header:="Eliminar", style:="center", format:=
                                               Function(item)
                                                       If (item.Estado = True) Then
                                                           Return Html.Raw(String.Format("<a class='desactivar_table delete-register' title='Eliminar' data='{0}'></a>", item.IdProveedor, item.Estado))
                                                       Else
                                                           Return Html.Raw(String.Format("<a class='Asistio delete-register' title='Activar' data='{0}'></a>", item.IdProveedor, item.Estado))
                                                       End If
                                               End Function),
                                               grid.Column(header:="Asignar SKU", style:="center", format:=
                                               Function(item)
                                                       If (item.Estado = True) Then
                                                           Return Html.Raw(String.Format("<button class='btn btn-mini btn-info buttonS bBlue bGridProvAct' title='Asignar' data='{0}' estado='{1}'>Ver Detalle</button>", item.IdProveedor, item.Estado))
                                                       Else
                                                           Return Html.Raw(String.Format("<button class='btn btn-mini btn-info buttonS bBlue bGridProvInac' title='Asignar' data='{0}' estado='{1}' disabled>Inhabilitado</button>", item.IdProveedor, item.Estado))
                                                       End If
                                               End Function)
                                               )
                                           )
        @Html.HiddenFor(Function(m) m.Paginacion.DescRegistrosPorPaginas, New With {.id = "FooterDesc"})
        @Html.HiddenFor(Function(m) m.Paginacion.TotalRows, New With {.id = "TotalRows"})
    End Code
</div>
<script>
    //PaintFooterGrid();
</script>


<style>
    .bGridProv{
        padding:2px 10px !important;
    }
</style>
