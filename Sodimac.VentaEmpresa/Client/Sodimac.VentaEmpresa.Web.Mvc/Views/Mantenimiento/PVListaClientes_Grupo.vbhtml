@ModelType Sodimac.VentaEmpresa.Web.Mvc.MantenimientoViewModel
@Imports Sodimac.VentaEmpresa.Web.Mvc.ParametrosView
@Imports Sodimac.VentaEmpresa.Common

@Code
    ViewData("title") = "Lista Clientes por Grupos"
End Code

<div id="divListaClientesGrupo">
    <div class="widget fluid">
        <div class="whead">
            <h6>
                Lista de Clientes Asignados a  </h6>      
            <div class="clear">
            </div>
        </div>
        @Code
            @If (Not Model.Paginacion.ListaGrupoClienteMantenimiento Is Nothing) Then
                If (Not Model.Paginacion.ListaGrupoClienteMantenimiento.Count = 0) Then
                    Dim gridListaClienteGrupo = New WebGrid(rowsPerPage:=Model.Paginacion.PageSize, ajaxUpdateContainerId:="divListaClientesGrupo", ajaxUpdateCallback:="SetTotalRegistrosClientesGrupo")
                    gridListaClienteGrupo.Bind(Model.Paginacion.ListaGrupoClienteMantenimiento, autoSortAndPage:=False, rowCount:=Model.Paginacion.TotalRows)
                @gridListaClienteGrupo.GetHtml(
                headerStyle:="fix_head", rowStyle:="fix_td", alternatingRowStyle:="fix_td", footerStyle:="pagination",
                htmlAttributes:=New With {.id = "dgvDatos", .class = "tDefault"},
                mode:=WebGridPagerModes.All,
                firstText:="<< Primera",
                previousText:="< Anterior",
                nextText:="Siguiente >",
                lastText:="Última >>",
                    columns:=gridListaClienteGrupo.Columns(
                        gridListaClienteGrupo.Column("Grupo.NombreGrupo", "Nombre de Grupo", canSort:=False, style:="person"),
                        gridListaClienteGrupo.Column("ClienteVenta.RUC", "RUC", canSort:=False, style:="person"),
                        gridListaClienteGrupo.Column("ClienteVenta.RazonSocial", "Razón Social", canSort:=False, style:="person"),
                        gridListaClienteGrupo.Column("ClienteVenta.DescripcionSector", "Sector", canSort:=False, Style:="person", Format:=
                                                     Function(item)
                                                         Dim control As String
                                                         If (item.ClienteVenta.DescripcionSector = Constantes.Clear) Then
                                                             control = String.Format("-")
                                                             Return control
                                                         Else
                                                             control = Format(item.ClienteVenta.DescripcionSector)
                                                             Return control
                                                         End If
                                                     End Function
                                                     ),
                        gridListaClienteGrupo.Column("ClienteVenta.DescripcionTipo", "Tipo Cliente", canSort:=False, Style:="person", Format:=
                                                     Function(item)
                                                         Dim control As String
                                                         If (item.ClienteVenta.DescripcionTipo = Constantes.Clear) Then
                                                             control = String.Format("-")
                                                             Return control
                                                         Else
                                                             control = Format(item.ClienteVenta.DescripcionTipo)
                                                             Return control
                                                         End If
                                                     End Function
                                                     ),
                        gridListaClienteGrupo.Column("Empleado.NombresApellidos", "Nombres del RRVV", canSort:=False, style:="person"),
                        gridListaClienteGrupo.Column("ClienteVenta.NombreZona", "Zona", canSort:=False, Style:="person", Format:=
                                                     Function(item)
                                                         Dim control As String
                                                         If (item.ClienteVenta.NombreZona = "") Then
                                                             control = String.Format("-")
                                                             Return control
                                                         Else
                                                             control = Format(item.ClienteVenta.NombreZona)
                                                             Return control
                                                         End If
                                                     End Function
                       ),
                       gridListaClienteGrupo.Column("ClienteVenta.DescripcionSucursal", "Sucursal", canSort:=False, Style:="person", Format:=
                                                     Function(item)
                                                         Dim control As String
                                                         If (item.ClienteVenta.DescripcionSucursal = "") Then
                                                             control = String.Format("-")
                                                             Return control
                                                         Else
                                                             control = Format(item.ClienteVenta.DescripcionSucursal)
                                                             Return control
                                                         End If
                                                     End Function
                        )
                )
                )
                @Html.HiddenFor(Function(m) m.Paginacion.DescRegistrosPorPaginas, New With {.id = "hdfTotalRegistros"})
                @Html.HiddenFor(Function(m) m.Paginacion.ListaGrupoClienteMantenimiento.Count, New With {.id = "countListaGrupo"})
                Else
                @<span>No se encontraron clientes para este grupo</span>
                End If
            Else
                @<span>No se encontraron clientes para este grupo</span>
            End If

        End Code
    </div>
    <div class="formRow">
      <button type="button" name="ActionCancelar" id="btnRegresar" style="cursor: pointer" class="buttonS bBlue formSubmit group_button" onclick="dialogRegresarMantenimientoGrupo();"> Regresar</button>
    <div class="clear"></div>
    </div></div>

    <div id="dialogRegresarMantenimientoGrupo" title="Mensaje de Confirmación">
       <p>¿Deseas regresar al Mantenedor de Grupo?</p>
     </div>
      <script type="text/javascript" src="@Url.Content("~/Scripts/View/Mantenimiento.js")"></script>
     <script type="text/javascript" language="javascript">
         InicioJPopUpConfirm("#dialogRegresarMantenimientoGrupo", 490, false, "Mensaje de Confirmación", CancelarMantenimientoGrupo);;
    </script>



