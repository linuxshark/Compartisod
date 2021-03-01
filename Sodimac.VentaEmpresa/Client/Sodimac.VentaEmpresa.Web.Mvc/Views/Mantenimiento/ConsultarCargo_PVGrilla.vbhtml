@ModelType Sodimac.VentaEmpresa.Web.Mvc.MantenimientoViewModel
    <div id="contenedor-grid-Cargo">
    @Code
        Dim gridCargo As New WebGrid(rowsPerPage:=Model.Paginacion.PageSize, ajaxUpdateContainerId:="contenedor-grid-Cargo", ajaxUpdateCallback:="SetTotalRegistrosCargos")
        gridCargo.Bind(Model.Paginacion.ListaCargo, autoSortAndPage:=False, rowCount:=Model.Paginacion.TotalRows)
            @gridCargo.GetHtml(
                headerStyle:="fix_head", rowStyle:="fix_td", alternatingRowStyle:="fix_td", footerStyle:="pagination",
                htmlAttributes:=New With {.id = "GrillaCargos", .class = "tDefault"},
                mode:=WebGridPagerModes.All,
                firstText:="<< Primera",
                previousText:="< Anterior",
                nextText:="Siguiente >",
                lastText:="Última >>",
                columns:=gridCargo.Columns(
                gridCargo.Column("Perfil.NombrePerfil", "Perfil", canSort:=True, style:="person"),
                gridCargo.Column("Zona.NombreZona", "Zona", canSort:=True, style:="person"),
                gridCargo.Column("NombreCargoSuperior", "Reporta A", canSort:=True, style:="person"),
                gridCargo.Column(header:="Editar", style:="center", format:=
                    Function(item)
                            Dim control As String
                            If (item.Perfil.TipoPerfil <> 1) Then
                                control = String.Format("<a class={0}edit_table{0} title={0}Editar Cargo{0} onClick={0}EditarCargo('" & item.IdCargo.ToString() & "','" & item.IdCargoSuperior.ToString() & "','" & item.NombreCargo.ToString() & "','" + item.Zona.idzona.ToString() & "','" & item.comisiona.ToString() & "','" & item.Perfil.IdPerfil.ToString() & "','" & item.Perfil.TipoPerfil.ToString() & "'){0}/>", Chr(34))
                            Else
                                control = ""
                            End If
                            Return Html.Raw(control)
                    End Function
                ),
                gridCargo.Column("", "Eliminar", style:="center", format:=
                Function(item)
                        Dim control As String
                        If (item.Perfil.TipoPerfil <> 1) Then
                            control = String.Format("<a class={0}desactivar_table{0} title= {0}Eliminar Cargo{0} onClick={0}DialogEliminarCargo('" & item.IdCargo.ToString() & "','" & item.Perfil.TipoPerfil.ToString() & "'){0}/>", Chr(34))
                        Else
                            control = ""
                        End If
                        Return Html.Raw(control)
                End Function
                )
            )
            )            
            @Html.HiddenFor(Function(m) m.Paginacion.DescRegistrosPorPaginas, New With {.id = "hdfTotalRegistros"})
            @Html.HiddenFor(Function(m) m.Paginacion.ListaCargo.Count, New With {.id = "countListaCargo"})
   End Code
@If (Not Model.Paginacion.ListaCargo Is Nothing) Then
    If (Not Model.Paginacion.ListaCargo.Count = 0) Then
        @<script type="text/javascript" language="javascript">
             $("#GrillaCargos tfoot tr:last td").prepend("<a id='tfootPage' class='total_registros'></a>");
             $("#tfootPage").html($('#hdfTotalRegistros').val());

             $(function () {
                 $('th a, tfoot a').live('click', function () {
                     $(this).attr('href', '#GrillaCargos');
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
