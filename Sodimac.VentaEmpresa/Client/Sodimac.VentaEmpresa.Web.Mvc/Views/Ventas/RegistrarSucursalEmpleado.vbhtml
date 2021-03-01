@ModelType  Sodimac.VentaEmpresa.Web.Mvc.VentasViewModel
<div id="grid-sucursales">
    @Code 
        Dim gridVentas = New WebGrid(rowsPerPage:=Model.Paginacion.PageSize, ajaxUpdateContainerId:="grid-sucursales", ajaxUpdateCallback:="SetTotalRegistrosSucursales")
                gridVentas.Bind(Model.Paginacion.ListaSucursalEmpleado, autoSortAndPage:=False, rowCount:=Model.Paginacion.TotalRows)
                @gridVentas.GetHtml(
                headerStyle:="fix_head", rowStyle:="fix_td", alternatingRowStyle:="fix_td", footerStyle:="pagination",
                htmlAttributes:=New With {.id = "dgvSucursalEmpleado", .class = "tDefault"},
                mode:=WebGridPagerModes.All,
                firstText:="<< Primera",
                previousText:="< Anterior",
                nextText:="Siguiente >",
                lastText:="Última >>",
                columns:=gridVentas.Columns(
                    gridVentas.Column("Empleado.NombresApellidos", "Nombre Completo", canSort:=False, style:="person"),
                    gridVentas.Column("Perfil.NombrePerfil", "Nombre Perfil", canSort:=False, style:="person"),
                    gridVentas.Column("Zona", "Zona", canSort:=False, style:="person"),
                    gridVentas.Column("Sucursal.DescripcionSucursal", "Sucursal", canSort:=False, style:="person"),
                    gridVentas.Column("Reporta", "Reporta a", canSort:=False, style:="person"),
                    gridVentas.Column("EscalaTiempoAsignado", "Escala Inicial", canSort:=False, style:="person"),
                    gridVentas.Column("FechaRegistro", "Fecha Ingreso", canSort:=False, style:="person", format:=
                    Function(item)
                            Return Format(item.FechaRegistro, "dd/MM/yyyy")
                    End Function),
                    gridVentas.Column("FechaSalida", "Fecha Salida", canSort:=False, style:="person", format:=
                    Function(item)
                            If (item.FechaSalida = "01/01/1900" Or item.FechaSalida = "01/01/0001") Then
                                Return Format("-")
                            Else
                                Return Format(item.FechaSalida, "dd/MM/yyyy")
                            End If
                    End Function),
                    gridVentas.Column("Activo", "Vigente", canSort:=False, style:="person", format:=
                    Function(item)
                            Return IIf(item.Activo = 1, "SI", "NO")
                    End Function),
                    gridVentas.Column("Empleado.Activo", "Estado", canSort:=False, style:="person", format:=
                    Function(item)
                            Return IIf(item.Empleado.Activo = True, "Registrado", "Inactivo")
                    End Function)
                ))
                @Html.HiddenFor(Function(m) m.Paginacion.DescRegistrosPorPaginas, New With {.id = "hdfTotalRegistros"})
                @Html.HiddenFor(Function(m) m.Paginacion.ListaCargo.Count, New With {.id = "countListaSucursal"})
     
    End Code
      @If (Not Model.Paginacion.ListaSucursalEmpleado Is Nothing) Then
          If (Not Model.Paginacion.ListaSucursalEmpleado.Count = 0) Then
              @<script type="text/javascript" language="javascript">
                   $("#dgvSucursalEmpleado tfoot tr:last td").prepend("<a id='tfootPage' class='total_registros'></a>");
                   $("#tfootPage").html($('#hdfTotalRegistros').val());

                   //    function SetTotalRegistros() {
                   //        $("#dgvSucursalEmpleado tfoot tr:last td").prepend("<a id='tfootPage' class='total_registros'></a>");
                   //        $("#tfootPage").html($('#hdfTotalRegistros').val());
                   //    } 
                   // GRILLA DE ESCALA DE TIEMPO
       //            gridVentas.Column("ComisionEscalaTiempoServicio.TiempoServicio", "EscalaInicial", canSort:=False, style:="person"),

//                   $(function () {
//                       $('th a, tfoot a').live('click', function () {
//                           $(this).attr('href', '#dgvSucursalEmpleado');
//                           return false;
//                       });
//                   });
            </script>
          Else
            @<span>&nbsp;&nbsp;&nbsp;No se encontraron resultados</span>
          End If
      Else
            @<span>&nbsp;&nbsp;&nbsp;No se encontraron resultados</span>
      End If




</div>