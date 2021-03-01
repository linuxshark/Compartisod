@ModelType Sodimac.VentaEmpresa.Web.Mvc.MantenimientoViewModel
    <div id="contenedor-grid-Perfil">
    @Code
            Dim gridPerfil As New WebGrid(rowsPerPage:=Model.Paginacion.PageSize, ajaxUpdateContainerId:="contenedor-grid-Perfil", ajaxUpdateCallback:="SetTotalRegistrosPerfiles")
            gridPerfil.Bind(Model.Paginacion.ListaPerfil, autoSortAndPage:=False, rowCount:=Model.Paginacion.TotalRows)
            @gridPerfil.GetHtml(
                headerStyle:="fix_head", rowStyle:="fix_td", alternatingRowStyle:="fix_td", footerStyle:="pagination",
                htmlAttributes:=New With {.id = "GrillaPerfiles", .class = "tDefault"},
                mode:=WebGridPagerModes.All,
                firstText:="<< Primera",
                previousText:="< Anterior",
                nextText:="Siguiente >",
                lastText:="Última >>",
                columns:=gridPerfil.Columns(
                gridPerfil.Column("NombrePerfil", "Nombre Perfil", canSort:=True, style:="person"),
                gridPerfil.Column("NombrePerfilSuperior", "Reporta A", canSort:=True, style:="person"),
                gridPerfil.Column(header:="Editar", style:="person", format:=
                    Function(item)
                            Dim control As String
                            If (item.TipoPerfil = 2 Or item.TipoPerfil = 3 Or item.TipoPerfil = 4) Then
                                control = String.Format("<a class={0}edit_table{0} title={0}Editar Perfil{0} onClick={0}EditarPerfil('" + item.IdPerfil.ToString() + "','" + item.IdPerfilSuperior.ToString() + "','" + item.NombrePerfil.ToString() + "','" + item.TipoPerfil.ToString() + "'){0}/>", Chr(34))
                            Else
                                control = ""
                            End If
                            Return Html.Raw(control)
                    End Function
                ),
                gridPerfil.Column("", "Eliminar", style:="person", format:=
                Function(item)
                        Dim control As String
                        If (item.TipoPerfil = 2 Or item.TipoPerfil = 3  Or item.TipoPerfil = 4) Then
                            control = String.Format("<a class={0}desactivar_table{0} title= {0}Eliminar Perfil{0} onClick={0}DialogEliminarPerfil('" + item.IdPerfil.ToString() + "','" + item.TipoPerfil.ToString() + "'){0}/>", Chr(34))
                        Else
                            control = ""
                        End If
                        Return Html.Raw(control)
                End Function
                )
            )
            )            
            @Html.HiddenFor(Function(m) m.Paginacion.DescRegistrosPorPaginas, New With {.id = "hdfTotalRegistros"})
            @Html.HiddenFor(Function(m) m.Paginacion.ListaPerfil.Count, New With {.id = "countListaPerfil"})
   End Code
@If (Not Model.Paginacion.ListaPerfil Is Nothing) Then
    If (Not Model.Paginacion.ListaPerfil.Count = 0) Then
        @<script type="text/javascript" language="javascript">
             $("#GrillaPerfiles tfoot tr:last td").prepend("<a id='tfootPage' class='total_registros'></a>");
             $("#tfootPage").html($('#hdfTotalRegistros').val());

//             $(function () {
//                 $('th a, tfoot a').live('click', function () {
//                     $(this).attr('href', '#GrillaPerfiles');
//                     return false;
//                 });
//             });
        </script>
    Else
        @<span>&nbsp;&nbsp;&nbsp;No se encontraron resultados</span>
    End If
Else
    @<span>&nbsp;&nbsp;&nbsp;No se encontraron resultados</span>
End If  
 </div>