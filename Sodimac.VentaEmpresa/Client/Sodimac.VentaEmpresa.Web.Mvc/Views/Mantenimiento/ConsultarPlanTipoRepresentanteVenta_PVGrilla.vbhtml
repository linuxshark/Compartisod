@ModelType Sodimac.VentaEmpresa.Web.Mvc.MantenimientoViewModel
<script type="text/javascript" src="@Url.Content("~/Scripts/View/Mantenimiento.js")"></script>

<div id="contenedor-grid-PlanTipoRepVen">
    @Code
        Dim gridPlanTipoRepVen As New WebGrid(rowsPerPage:=Model.Paginacion.PageSize, ajaxUpdateContainerId:="contenedor-grid-PlanTipoRepVen", ajaxUpdateCallback:="SetTotalRegistrosPlanTipoRepVen")
        gridPlanTipoRepVen.Bind(Model.Paginacion.ListaPlanTipoRepresentanteVenta, autoSortAndPage:=False, rowCount:=Model.Paginacion.TotalRows)
        @gridPlanTipoRepVen.GetHtml(
                               headerStyle:="fix_head", rowStyle:="fix_td", alternatingRowStyle:="fix_td", footerStyle:="pagination",
                               htmlAttributes:=New With {.id = "GrillaPlanTipoRepVen", .class = "tDefault"},
                               mode:=WebGridPagerModes.All,
                               firstText:="<< Primera",
                               previousText:="< Anterior",
                               nextText:="Siguiente >",
                               lastText:="Última >>",
                               columns:=gridPlanTipoRepVen.Columns(
                               gridPlanTipoRepVen.Column("TipoRepresentanteVenta.NombreTipoRepVen", "Tipo Representante", canSort:=True, style:="person"),
                               gridPlanTipoRepVen.Column("MesPlan.OrdenMes", "Mes", canSort:=True, style:="person"),
                               gridPlanTipoRepVen.Column("Plan", "Plan", canSort:=True, style:="person"),
                               gridPlanTipoRepVen.Column("FechaRegistro", "Fecha Registro", canSort:=True, style:="person"),
                               gridPlanTipoRepVen.Column(header:="Editar", style:="person", format:=
                                                           Function(item)
                                                               Dim control As String
                                                               control = String.Format("<a class={0}edit_table{0} title={0}Editar Plan Venta{0} onClick={0}EditarPlanTipoRepVen('" & item.IdPlanTipoRepVen.ToString() & "'){0}    />", Chr(34))
                                                               Return Html.Raw(control)
                                                           End Function
                                                           ),
                               gridPlanTipoRepVen.Column("", "Eliminar", style:="person", format:=
                                                           Function(item)
                                                               Dim control As String
                                                               control = String.Format("<a class={0}desactivar_table{0} title= {0}Eliminar Plan Venta{0} onClick={0}ConfirmarEliminarPlanTipoRepVen('" & item.IdPlanTipoRepVen.ToString() & "'){0}/>", Chr(34))
                                                               Return Html.Raw(control)
                                                           End Function)))

        @Html.HiddenFor(Function(m) m.Paginacion.DescRegistrosPorPaginas, New With {.id = "hdfTotalRegistros"})
        @Html.HiddenFor(Function(m) m.Paginacion.ListaPlanTipoRepresentanteVenta.Count, New With {.id = "countListaPlanTipoRepVen"})
    End Code
    @If (Not Model.Paginacion.ListaPlanTipoRepresentanteVenta Is Nothing) Then
        If (Not Model.Paginacion.ListaPlanTipoRepresentanteVenta.Count = 0) Then
            @<script type="text/javascript" language="javascript">
                 $("#GrillaPlanTipoRepVen tfoot tr:last td").prepend("<a id='tfootPage' class='total_registros'></a>");
                 $("#tfootPage").html($('#hdfTotalRegistros').val());
            </script>
        Else
            @<span>&nbsp;&nbsp;&nbsp;No se encontraron resultados</span>
        End If
    Else
        @<span>&nbsp;&nbsp;&nbsp;No se encontraron resultados</span>
    End If
</div>
