@modeltype Sodimac.VentaEmpresa.Web.Mvc.MantenimientoViewModel
<div class="widget" style="margin-top: -5px;">
    <div id="divListaClientes">
        @code
            @If (Not Model.Paginacion.ListaClienteVenta Is Nothing) Then
                If (Not Model.Paginacion.ListaClienteVenta.Count = 0) Then
                    Dim wgCliente = New WebGrid(rowsPerPage:=Model.Paginacion.PageSize, ajaxUpdateContainerId:="divListaClientes", ajaxUpdateCallback:="SetTotalRegistrosClientes")
                    wgCliente.Bind(Model.Paginacion.ListaClienteVenta, autoSortAndPage:=False, rowCount:=Model.Paginacion.TotalRows)
                    @wgCliente.GetHtml(
                    headerStyle:="fix_head", rowStyle:="fix_td", alternatingRowStyle:="fix_td", footerStyle:="pagination",
                    htmlAttributes:=New With {.id = "dgvDatosClienteGrupo", .class = "tDefault"},
                    mode:=WebGridPagerModes.All,
                    firstText:="<< Primera",
                    previousText:="< Anterior",
                    nextText:="Siguiente >",
                    lastText:="Última >>",
                    columns:=wgCliente.Columns(
                    wgCliente.Column("IdCliente", "IdCliente", canSort:=False, style:="ui-helper-hidden"),
                    wgCliente.Column("Sel.", canSort:=False, Format:=
                    Function(item)
                        Return Html.CheckBox("checkCliente", False,
                        New With {
                                .id = "chk" & item.IdCliente,
                                .value = item.IdCliente,
                                .style = "float:=left",
                                .class = "chk_clientes"
                            })
                    End Function),
                    wgCliente.Column("RUC - Razón Social", canSort:=False, Format:=
                    Function(item)
                        Dim control As String
                        control = "<label style='float:left' for='" & item.IdCliente & "'>" & item.Ruc & " - " & item.RazonSocial & "</label> "
                        Return Html.Raw(control)
                    End Function))
                    )
                    @Html.HiddenFor(Function(m) m.Paginacion.TotalRows, New With {.id = "Cli_RowCount"})
                    @Html.HiddenFor(Function(m) m.Paginacion.DescRegistrosPorPaginas, New With {.id = "HdnTotalRegistros"})
                    @Html.HiddenFor(Function(m) m.Paginacion.PageSize, New With {.id = "Cli_RowsPerPage"})
                    @If (Model.Paginacion.ListaClienteVenta.Count < 1) Then
                    @<p>No se encontraron resultados para ésta búsqueda</p>
                    End If         
                End If
            End If
        End Code
    </div>
</div>
@If (Not Model.Paginacion.ListaClienteVenta Is Nothing) Then
    If (Not Model.Paginacion.ListaClienteVenta.Count = 0) Then
        @<script type="text/javascript" language="javascript">
             $("#dgvDatosClienteGrupo tfoot tr:last td").prepend("<a id='tfootPage' class='total_registros'></a>");
             $("#tfootPage").html($('#hdfTotalRegistros').val());
             $("#dgvDatosClienteGrupo tbody tr td input").uniform();
             $("#dgvDatosClienteGrupo thead tr th:nth-child(1)").hide();
             $(function () {
                 $('th a, tfoot a').live('click', function () {
                     $(this).attr('href', '#dgvDatosClienteGrupo');
                     $(".chosen-select").chosen();
                     return false;
                 });
             });
        </script>
    Else
        @<span>&nbsp;&nbsp;&nbsp;No se encontraron resultados</span>
    End If
@*Else
    @<span>&nbsp;&nbsp;&nbsp;No se encontraron resultados</span>*@
End If