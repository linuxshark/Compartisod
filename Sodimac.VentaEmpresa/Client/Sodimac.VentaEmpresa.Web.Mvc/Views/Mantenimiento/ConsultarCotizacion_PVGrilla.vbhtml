@ModelType Sodimac.VentaEmpresa.Web.Mvc.MantenimientoViewModel
<div id="contenedor-grid-Cotizacion">
    @Code
        Dim gridCargo As New WebGrid(rowsPerPage:=Model.Paginacion.PageSize, ajaxUpdateContainerId:="contenedor-grid-Cotizacion", ajaxUpdateCallback:="SetTotalRegistrosCotizacion")
        gridCargo.Bind(Model.Paginacion.ListaCotizacion, autoSortAndPage:=False, rowCount:=Model.Paginacion.TotalRows)
        @gridCargo.GetHtml(
                                                                headerStyle:="fix_head", rowStyle:="fix_td", alternatingRowStyle:="fix_td", footerStyle:="pagination",
                                                                htmlAttributes:=New With {.id = "GrillaCotizacion", .class = "tDefault"},
                                                                mode:=WebGridPagerModes.All,
                                                                firstText:="<< Primera",
                                                                previousText:="< Anterior",
                                                                nextText:="Siguiente >",
                                                                lastText:="Última >>",
                                                                columns:=gridCargo.Columns(
                                                                gridCargo.Column("NroCotizacionDesc", "Nro. Proforma", canSort:=True, style:="person"),
                                                                gridCargo.Column("NroCotizacionUXPOSDesc", "Nro. Cot. UXPOS", canSort:=True, style:="person"),
                                                                gridCargo.Column("Fecha", "Fecha", canSort:=True, style:="person"),
                                                                gridCargo.Column("Vendedor", "Vendedor", canSort:=True, style:="person"),
                                                                gridCargo.Column("Ruc", "Ruc", canSort:=True, style:="person"),
                                                                gridCargo.Column("Cliente", "Cliente", canSort:=True, style:="person"),
                                                                gridCargo.Column("Tienda", "Tienda", canSort:=True, style:="person"),
                                                                gridCargo.Column("SubTotalDesc", "SubTotal", canSort:=False, style:="person"),
                                                                gridCargo.Column("DescuentoTotalDesc", "Dscto. tot.", canSort:=False, style:="person"),
                                                                gridCargo.Column("TotalGeneralDesc", "Tot. General", canSort:=False, style:="person"),
                                                                gridCargo.Column("", "Ver Detalle", style:="center", format:=
                                                Function(item)
                                                    Dim control As String
                                                    control = String.Format("<a class={0}select_table{0} title= {0}Ver Detalle Cotización{0} onClick={0}VerDetalleCotizacion('" & item.NroCotizacion.ToString() & "'){0}/>", Chr(34))
                                                    Return Html.Raw(control)
                                                End Function
                                                ),
                                                                gridCargo.Column("", "Cot. Uxpos", style:="center", format:=
                                        Function(item)
                                            Dim control As String
                                            If (Not item.EsPreProforma) Then
                                                control = String.Format("<a class={0}edit_table{0} title= {0}Editar Cotización{0} onClick={0}EditarCotizacion('" & item.NroCotizacion.ToString() & "'){0}/>", Chr(34))
                                            End If
                                            Return Html.Raw(control)
                                        End Function
                               )
                                                       )
                                                       )
        @Html.HiddenFor(Function(m) m.Paginacion.DescRegistrosPorPaginas, New With {.id = "hdfTotalRegistros"})
        @Html.HiddenFor(Function(m) m.Paginacion.ListaCotizacion.Count, New With {.id = "countListaCotizacion"})
    End Code
    @If (Not Model.Paginacion.ListaCotizacion Is Nothing) Then
        If (Not Model.Paginacion.ListaCotizacion.Count = 0) Then
            @<script type="text/javascript" language="javascript">
                 $("#GrillaCotizacion tfoot tr:last td").prepend("<a id='tfootPage' class='total_registros'></a>");
                 $("#tfootPage").html($('#hdfTotalRegistros').val());

                 $(function () {
                     $('th a, tfoot a').live('click', function () {
                         $(this).attr('href', '#GrillaCotizacion');
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