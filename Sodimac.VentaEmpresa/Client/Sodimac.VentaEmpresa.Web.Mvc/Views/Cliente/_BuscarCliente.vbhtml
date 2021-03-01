@ModelType  Sodimac.VentaEmpresa.Web.Mvc.ClientesViewModel 
<div id="contendorgrilla-ListaClientes">

@Code
    Dim gridVentas = New WebGrid(rowsPerPage:=Model.Paginacion.PageSize, ajaxUpdateContainerId:="contendorgrilla-ListaClientes", ajaxUpdateCallback:="SetTotalRegistrosCliente")
    gridVentas.Bind(Model.Paginacion.ListaClienteVenta, autoSortAndPage:=False, rowCount:=Model.Paginacion.TotalRows)
        @gridVentas.GetHtml(
        headerStyle:="fix_head", rowStyle:="fix_td", alternatingRowStyle:="fix_td", footerStyle:="pagination",
        htmlAttributes:=New With {.id = "dgvDatos", .class = "tDefault"},
        mode:=WebGridPagerModes.All,
        firstText:="<< Primera",
        previousText:="< Anterior",
        nextText:="Siguiente >",
        lastText:="Última >>",
        columns:=gridVentas.Columns(
            gridVentas.Column("RUC", "RUC", canSort:=True, style:="person"),
            gridVentas.Column("RazonSocial", "Razón Social", canSort:=True, style:="person"),
            gridVentas.Column("NombresApellidos", "Vendedor Principal", canSort:=True, style:="person"),
            gridVentas.Column("DescripcionModoPago", "Modo Pago", canSort:=True, style:="person", format:=
                              Function(item)
                                      Dim control As String
                                      If (item.FechaRango <= 30 And item.FechaRango >= 0 And item.ClienteModoPagoCombo.IdModoPago = 1) Then
                                          control = String.Format("<font color='red'>" & item.DescripcionModoPago.ToString() & "*" & "</font>")
                                      Else
                                          control = String.Format("<font color='black'>" & item.DescripcionModoPago.ToString() & "</font>")
                                      End If
                                      Return Html.Raw(control)
                              End Function
                              ),
            gridVentas.Column("EmpleadoDepartamento.DescripcionDepa", "Departamento ", canSort:=True, style:="person"),
            gridVentas.Column("ClienteSector.Descripcion", "Sector", canSort:=True, style:="person"),
            gridVentas.Column("ClienteCategoria.Descripcion", "Categoría", canSort:=True, style:="person"),
            gridVentas.Column("ClienteTipo.Descripcion", "Tipo", canSort:=True, style:="person"),
            gridVentas.Column("ProcesoEstado.IdEstado", "Estado", canSort:=True, style:="person", format:=
                              Function(item)
                                      If (item.ProcesoEstado.IdEstado = 8) Then
                                          Return "ACTIVO"
                                      Else
                                          Return "INACTIVO"
                                      End If
                              End Function
                              ),
            gridVentas.Column(header:="Detalle", format:=
            Function(item)
                    Return Html.ActionLink(" ", "GestionarCliente", "Cliente", New With {.IdCliente = item.IdCliente}, New With {.class = "select_table", .title = "Ver Detalle"})
            End Function)
            )
        )
        @Html.HiddenFor(Function(m) m.Paginacion.DescRegistrosPorPaginas, New With {.id = "hdfTotalRegistros"})
        @Html.HiddenFor(Function(m) m.Paginacion.ListaClienteVenta.Count, New With {.id = "countListaClienteVenta"})
End Code
@If (Not Model.Paginacion.ListaClienteVenta Is Nothing) Then
    If (Not Model.Paginacion.ListaClienteVenta.Count = 0) Then
        @<script type="text/javascript" language="javascript">
            $("#dgvDatos tfoot tr:last td").prepend("<a id='tfootPage' class='total_registros'></a>");
            $("#tfootPage").html($('#hdfTotalRegistros').val());

            $(function () {
                $('th a, tfoot a').live('click', function () {
                    $(this).attr('href', '#dgvDatos');
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
