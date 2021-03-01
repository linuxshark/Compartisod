@ModelType Sodimac.VentaEmpresa.Web.Mvc.MantenimientoViewModel
<div id="contenedor-grid-DescuentoFamilia">
    @Code
        Dim gridCargo As New WebGrid(rowsPerPage:=Model.Paginacion.PageSize, ajaxUpdateContainerId:="contenedor-grid-DescuentoFamilia", ajaxUpdateCallback:="SetTotalRegistrosDescuentoFamilia")
        gridCargo.Bind(Model.Paginacion.ListaDescuentoFamilia, autoSortAndPage:=False, rowCount:=Model.Paginacion.TotalRows)
        @gridCargo.GetHtml(
                                                                                                           headerStyle:="fix_head", rowStyle:="fix_td", alternatingRowStyle:="fix_td", footerStyle:="pagination",
                                                                                                           htmlAttributes:=New With {.id = "GrillaDescuentoFamilia", .class = "tDefault"},
                                                                                                           mode:=WebGridPagerModes.All,
                                                                                                           firstText:="<< Primera",
                                                                                                           previousText:="< Anterior",
                                                                                                           nextText:="Siguiente >",
                                                                                                           lastText:="Última >>",
                                                                                                           columns:=gridCargo.Columns(
                                                                                                           gridCargo.Column("CodigoFamilia", "Codigo Familia", canSort:=True, style:="person"),
                                                                                                           gridCargo.Column("NombreFamilia", "Nombre Familia", canSort:=True, style:="person"),
                                                                                                           gridCargo.Column("MargenDsctoDsc", "Margen Dscto", canSort:=False, style:="person"),
                                                                                                           gridCargo.Column("DescuentoDsc", "Descuento", canSort:=False, style:="person"),
                                                                                                           gridCargo.Column(header:="Editar", style:="center", format:=
                                                                          Function(item)
                                                                              Dim control As String
                                                                              control = String.Format("<a class={0}edit_table{0} title={0}Editar Cargo{0} onClick={0}EditarDescuentoFamilia('" & item.CodigoFamilia.ToString() & "','" & item.MargenDscto.ToString() & "','" + item.Descuento.ToString() & "'){0}/>", Chr(34))
                                                                              Return Html.Raw(control)
                                                                          End Function
                                                                      ),
                                                                                                           gridCargo.Column("", "Eliminar", style:="center", format:=
                                                                                        Function(item)
                                                                                            Dim control As String
                                                                                            control = String.Format("<a class={0}desactivar_table{0} title= {0}Eliminar Cargo{0} onClick={0}DialogEliminarDescuentoFamilia('" & item.CodigoFamilia.ToString() & "'){0}/>", Chr(34))
                                                                                            Return Html.Raw(control)
                                                                                        End Function
                                                                                        )
                                                                                                       )
                                                                                                       )
        @Html.HiddenFor(Function(m) m.Paginacion.DescRegistrosPorPaginas, New With {.id = "hdfTotalRegistros"})
        @Html.HiddenFor(Function(m) m.Paginacion.ListaDescuentoFamilia.Count, New With {.id = "countListaDescuentoFamilia"})
    End Code
    @If (Not Model.Paginacion.ListaDescuentoFamilia Is Nothing) Then
        If (Not Model.Paginacion.ListaDescuentoFamilia.Count = 0) Then
            @<script type="text/javascript" language="javascript">
                $("#GrillaDescuentoFamilia tfoot tr:last td").prepend("<a id='tfootPage' class='total_registros'></a>");
                 $("#tfootPage").html($('#hdfTotalRegistros').val());

                 $(function () {
                     $('th a, tfoot a').live('click', function () {
                         $(this).attr('href', '#GrillaDescuentoFamilia');
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