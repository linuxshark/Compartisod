@modeltype Sodimac.VentaEmpresa.Web.Mvc.ClientesViewModel
@If Not Model.Paginacion.ListaSucursal Is Nothing AndAlso Not (Model.Paginacion.ListaSucursal.Count = 0) Then
@<div class="widget" style="margin-top:0px">
    <table class="tDefault row-fluid" id="dgvDatosPagSucursal">
        <thead>
            <tr class="fix_head">
                <td>
                    IdSucursal
                </td>
                <td>
                    Sucursal
                </td>
                <td>
                    Fecha<br />Asignación
                </td>
                <td>
                    Fecha<br />Desasignación
                </td>
                <td>
                    Porcentaje
                </td>
            </tr>
        </thead>
        <tbody id="divSucursales">
                @For ii = 0 To Model.Paginacion.ListaSucursal.Count - 1
                    Dim j As Integer = ii
                    @<tr>
                        <td>
                        @Html.HiddenFor(Function(m) m.Paginacion.ListaSucursal(j).CodigoSucursal, New With{ .id = "HdnCodigoSucursal_" & Model.Paginacion.ListaSucursal(j).CodigoSucursal })
                        </td> 
                        <td style="width: 55%">
                            @Html.DisplayTextFor(Function (m) m.Paginacion.ListaSucursal(j).DescripcionSucursal)
                        </td>
                        <td style="width: 16%; text-align: center">
                            @Html.TextBoxFor(Function(m) m.Paginacion.ListaSucursal(j).FechaAsignacion,
                                                  New With {
                                                      .class = "cFechaAsignacion",
                                                      .maxlength = "10",
                                                      .value = String.Format("{0:d}", "")
                                                  })
                            @*<div class="clear"></div>*@
                                @Html.ValidationMessageFor(Function(m) m.Paginacion.Sucursal.FechaAsignacion, "", New With {.id = "msgFechaAsignacion_" & Model.Paginacion.ListaSucursal(j).CodigoSucursal, .Style = "color:red", .class = "reqizq"})
                        </td>
                        <td style="width: 16%; text-align: center">
                            @Html.TextBoxFor(Function(m) m.Paginacion.ListaSucursal(j).FechaDesasignacion,
                                                      New With {
                                                          .class = "cFechaDesasignacion",
                                                          .maxlength = "10",
                                                          .value = String.Format("{0:d}", "")
                                                      })
                            @Html.ValidationMessageFor(Function(m) m.Paginacion.Sucursal.FechaDesasignacion, "", New With {.id = "msgFechaDeasignacion_" & Model.Paginacion.ListaSucursal(j).CodigoSucursal, .Style = "color:red", .class = "reqizq"})
                        </td>
                        <td style="width: 13%; text-align: center">
                            @Html.TextBoxFor(Function(m) m.Paginacion.ListaSucursal(j).Porcentaje,
                                         New With {
                                             .class = "cPorcentaje",
                                             .onkeypress = "return val_09(event)",
                                             .Style = "text-align:center",
                                             .maxlength = "5",
                                             .onkeyup = "this.value = minmax(this.value, 0, 100)",
                                             .value = ""
                                         })
                            @Html.ValidationMessageFor(Function(m) m.Paginacion.Sucursal.Porcentaje, "", New With {.id = "msgPorcentaje_" & Model.Paginacion.ListaSucursal(j).CodigoSucursal, .Style = "color:red", .class = "reqizq"})
                        </td>                        
                        @Html.HiddenFor(Function(m) m.Paginacion.ListaSucursal(j).IdSucursal, New With{ .id = "IdSucursal_" & Model.Paginacion.ListaSucursal(j).IdSucursal})
                    </tr>
                Next
                                                   
        </tbody>
        <tfoot>
        </tfoot>
    </table>
</div>
End If