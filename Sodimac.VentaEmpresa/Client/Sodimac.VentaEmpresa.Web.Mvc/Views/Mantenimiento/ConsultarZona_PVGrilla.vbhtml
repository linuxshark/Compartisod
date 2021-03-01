@ModelType Sodimac.VentaEmpresa.Web.Mvc.MantenimientoViewModel
     <script type="text/javascript" src="@Url.Content("~/Scripts/View/Mantenimiento.js")"></script>
    <div id="contenedor-grid-Zona">
    @Code
        Dim gridZona As New WebGrid(rowsPerPage:=Model.Paginacion.PageSize, ajaxUpdateContainerId:="contenedor-grid-Zona", ajaxUpdateCallback:="SetTotalRegistrosZonas")
            gridZona.Bind(Model.Paginacion.ListaZonaMantenimiento, autoSortAndPage:=False, rowCount:=Model.Paginacion.TotalRows)
            @gridZona.GetHtml(
                headerStyle:="fix_head", rowStyle:="fix_td", alternatingRowStyle:="fix_td", footerStyle:="pagination",
                htmlAttributes:=New With {.id = "GrillaZonas", .class = "tDefault"},
                mode:=WebGridPagerModes.All,
                firstText:="<< Primera",
                previousText:="< Anterior",
                nextText:="Siguiente >",
                lastText:="Última >>",
                columns:=gridZona.Columns(
                gridZona.Column("NombreZona", "Nombre Zona", canSort:=True, style:="person"),
                gridZona.Column(header:="Editar", style:="person", format:=
                    Function(item)
                            Dim control As String
                            control = String.Format("<a class={0}edit_table{0} title={0}Editar Zona{0} onClick={0}EditarZona('" & item.IdZona.ToString() & "','" & item.NombreZona.ToString() & "','" & item.IsNacional.ToString() & "'){0}    />", Chr(34))
                            Return Html.Raw(control)
                    End Function
                ),
                gridZona.Column("", "Eliminar", style:="person", format:=
                Function(item)
                        Dim control As String
                        control = String.Format("<a class={0}desactivar_table{0} title= {0}Eliminar Zona{0} onClick={0}DialogEliminarZona('" & item.IdZona.ToString() & "'){0}/>", Chr(34))
                        Return Html.Raw(control)
                End Function
                )
            )
            )            
            @Html.HiddenFor(Function(m) m.Paginacion.DescRegistrosPorPaginas, New With {.id = "hdfTotalRegistros"})
            @Html.HiddenFor(Function(m) m.Paginacion.ListaZonaMantenimiento.Count, New With {.id = "countListaZona"})
   End Code
@If (Not Model.Paginacion.ListaZonaMantenimiento Is Nothing) Then
    If (Not Model.Paginacion.ListaZonaMantenimiento.Count = 0) Then
        @<script type="text/javascript" language="javascript">
             $("#GrillaZonas tfoot tr:last td").prepend("<a id='tfootPage' class='total_registros'></a>");
             $("#tfootPage").html($('#hdfTotalRegistros').val());

//             $(function () {
//                 $('th a, tfoot a').live('click', function () {
//                     $(this).attr('href', '#GrillaZonaes');
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
