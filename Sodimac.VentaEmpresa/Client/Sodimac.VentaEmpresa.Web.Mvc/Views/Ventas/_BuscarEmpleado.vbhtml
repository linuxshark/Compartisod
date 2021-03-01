@ModelType  Sodimac.VentaEmpresa.Web.Mvc.VentasViewModel
<div id="contendorgrilla-ListadoEmpleados">
@Code
    Dim gridVentas = New WebGrid(rowsPerPage:=Model.Paginacion.PageSize, ajaxUpdateContainerId:="contendorgrilla-ListadoEmpleados", ajaxUpdateCallback:="SetTotalRegistros_BuscarEmpleado")
    gridVentas.Bind(Model.Paginacion.ListaEmpleado, autoSortAndPage:=False, rowCount:=Model.Paginacion.TotalRows)
        @gridVentas.GetHtml(
                     headerStyle:="fix_head", rowStyle:="fix_td", alternatingRowStyle:="fix_td", footerStyle:="pagination",
                     htmlAttributes:=New With {.id = "dgvDatos_", .class = "tDefault"},
                     mode:=WebGridPagerModes.All,
                     firstText:="<< Primera",
                     previousText:="< Anterior",
                     nextText:="Siguiente >",
                     lastText:="Última >>",
                     columns:=gridVentas.Columns(
                     gridVentas.Column("CodigoOfisis", "Código Ofisis", canSort:=True, style:="person"),
                     gridVentas.Column("NombresApellidos", "Apellidos y Nombres", canSort:=True, style:="person"),
                     gridVentas.Column("Perfil.NombrePerfil", "Perfil", canSort:=True, style:="person"),
                     gridVentas.Column("TipoRepresentanteVenta.NombreTipoRepVen", "Tipo Representante", canSort:=True, style:="person"),
                     gridVentas.Column("ZonaMantenimiento.NombreZona", "Zona", canSort:=True, style:="person"),
                     gridVentas.Column("Sucursal.Descripcion", "Sucursal ", canSort:=True, style:="person"),
                     gridVentas.Column("Estado.IdEstado", "Estado", canSort:=True, style:="person", format:=
                                       Function(item)
                                               If (item.Estado.IdEstado = 26) Then
                                                   Return "ACTIVO"
                                               ElseIf (item.Estado.IdEstado = 27) Then
                                                   Return "INACTIVO"
                                               Else
                                                   Return "INACTIVO"
                                               End If
                                       End Function
                                       ),
                     gridVentas.Column(header:="Detalle", format:=
                     Function(item)
                             Return Html.ActionLink(" ", "GestionarEmpleado", "Ventas",
                    New With {.IdEmpleado = item.IdEmpleado,
                              .TipoPerfil = item.Perfil.TipoPerfil,
                              .IdEstado = item.Estado.IdEstado},
                    New With {.class = "select_table", .title = "Ver Detalle"})
                     End Function)))
            @Html.HiddenFor(Function(m) m.Paginacion.DescRegistrosPorPaginas, New With {.id = "hdfTotalRegistros"})
            @Html.HiddenFor(Function(m) m.Paginacion.ListaEmpleado.Count, New With {.id = "countListaEmpleado"})
            @Html.HiddenFor(Function(m) m.Empleado.Perfil.TipoPerfil, New With {.id = "ID_IdTipoPerfil"})  
End Code
@If (Not Model.Paginacion.ListaEmpleado Is Nothing) Then
    If (Not Model.Paginacion.ListaEmpleado.Count = 0) Then
        @<script type="text/javascript" language="javascript">
//             $("#dgvDatos_ tfoot tr:last td").prepend("<a id='tfootPage' class='total_registros'></a>");
//             $("#tfootPage").html($('#hdfTotalRegistros').val());
             $(function () {
                 SetTotalRegistros_BuscarEmpleado();
             });
        </script>
    Else
        @<span>&nbsp;&nbsp;&nbsp;No se encontraron resultados</span>
    End If
Else
    @<span>&nbsp;&nbsp;&nbsp;No se encontraron resultados</span>
End If
</div>