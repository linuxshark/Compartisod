@ModelType Sodimac.VentaEmpresa.Web.Mvc.MantenimientoViewModel
<div id="contenedor-grid-Grupo">
    @Code
        Dim gridGrupo As New WebGrid(rowsPerPage:=Model.Paginacion.PageSize, ajaxUpdateContainerId:="contenedor-grid-Grupo", ajaxUpdateCallback:="SetTotalRegistrosGrupo")
        gridGrupo.Bind(Model.Paginacion.ListaGrupo, autoSortAndPage:=False, rowCount:=Model.Paginacion.TotalRows)
        @gridGrupo.GetHtml(
                headerStyle:="fix_head", rowStyle:="fix_td", alternatingRowStyle:="fix_td", footerStyle:="pagination",
                htmlAttributes:=New With {.id = "GrillaGrupo", .class = "tDefault"},
                mode:=WebGridPagerModes.All,
                firstText:="<< Primera",
                previousText:="< Anterior",
                nextText:="Siguiente >",
                lastText:="Última >>",
                columns:=gridGrupo.Columns(
                gridGrupo.Column("NombreGrupo", "Nombre Grupo", canSort:=True, style:="person"),
                gridGrupo.Column(header:="Editar", style:="person", format:=
                    Function(item)
                            Dim control As String
                            control = String.Format("<a class={0}edit_table{0} title={0}Editar Zona{0} onClick={0}EditaGrupo('" & item.IdGrupo.ToString() & "','" & item.NombreGrupo.ToString() & "') {0}/>", Chr(34))
                            Return Html.Raw(control)
                    End Function
                ),
                gridGrupo.Column("", "Eliminar", style:="person", format:=
                Function(item)
                        Dim control As String
                        control = String.Format("<a class={0}desactivar_table{0} title= {0}Eliminar Zona{0} onClick={0}DialogEliminarGrupo('" & item.IdGrupo.ToString() & "') {0}/>", Chr(34))
                        Return Html.Raw(control)
                End Function
                ),
            gridGrupo.Column(header:="Detalle", format:=
                             Function(item)
                                     Return Html.ActionLink(" ", "ListadoGrupos", "Mantenimiento", New With {.IdGrupo = item.IdGrupo}, New With {.class = "select_table", .title = "Ver Detalle"})
                             End Function
                             )
        )) 
            @Html.HiddenFor(Function(m) m.Paginacion.DescRegistrosPorPaginas, New With {.id = "hdfTotalRegistros"})
            @Html.HiddenFor(Function(m) m.Paginacion.ListaZonaMantenimiento.Count, New With {.id = "countListaGrupo"})
   End Code
 @If (Not Model.Paginacion.ListaGrupo  Is Nothing) Then
     If (Not Model.Paginacion.ListaGrupo.Count = 0) Then
        @<script type="text/javascript" language="javascript">
             $("#GrillaGrupo tfoot tr:last td").prepend("<a id='tfootPage' class='total_registros'></a>");
             $("#tfootPage").html($('#hdfTotalRegistros').val());
        </script>
    Else
        @<span>&nbsp;&nbsp;&nbsp;No se encontraron resultados</span>
    End If
Else
    @<span>&nbsp;&nbsp;&nbsp;No se encontraron resultados</span>
End If 

</div>




