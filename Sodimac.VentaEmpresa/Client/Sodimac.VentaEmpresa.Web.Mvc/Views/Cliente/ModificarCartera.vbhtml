@ModelType Sodimac.VentaEmpresa.Web.Mvc.ClientesViewModel
@Imports Sodimac.VentaEmpresa.Web.Mvc.ParametrosView
@Code
    ViewBag.Title = "Agregar Cartera de Cliente"
End Code
@Using (Html.BeginForm("Agregar", "Account", FormMethod.Post, New With {.id = "frmAgregarCarteraCliente"}))
    @Html.AntiForgeryToken
    @Html.Hidden("UrlEmpleado", Url.Action("ListarEmpleado_ComboBox", "Cliente"))
    @Html.HiddenFor(Function(m) m.ClienteVenta.IdCliente, New With {.id = "ID_IdCliente"})
    @Html.HiddenFor(Function(m) m.VentaCartera.IdCarteraEmpleadoTipo, New With {.id = "ID_idCarteraEmpleadoTipo"})
    @Html.HiddenFor(Function(m) m.VentaCartera.IdSucursal, New With {.id = "ID_idSucursales"})
    @<div id="ID_AgregarCarteraCliente">
        @*<input type="hidden" value="@Url.Action("AgregarCarteraCliente", "Cliente")" id="AgregarCarteraCliente_URL" />*@
        <div class="wrapper">
            <div class="form">
                <fieldset>
                    <div class="widget fluid" id="divDefinicion">
                        <div class="whead">
                            <h6>
                                Modificar Cartera de Cliente</h6>
                            <div class="clear">
                            </div>
                        </div>
                        <div class="formRow fluid">
                            <div class="grid12">
                                <div class="grid2" style="padding-top: -30px">
                                    <label>
                                        Cliente :</label></div>
                                <div class="grid9">
                                    @Html.TextBoxFor(Function(m) m.ClienteVenta.RazonSocial, New With {.id = "IdRazonSocial", .class = "textinput", .disabled = "disabled"})
                                </div>
                            </div>
                        </div>
                        <div class="formRow fluid">
                            <div class="grid12">
                                <div class="grid2" style="margin-top: -10px;">
                                    <label>
                                        Tipo :</label>
                                </div>
                                <div class="grid9">
                                    <input type="radio" id="rbtPrincipal" name="VentaCartera.IdCarteraEmpleadoTipo" checked="checked" value="Principal" onclick="CargarSucursales('@Url.Action("ListarSucursalesComboBox", "Cliente")','1');" />
                                    <label for="rbtPrincipal" class="mr20" style="margin-top: -5px;">
                                        Principal
                                    </label>
                                    <input type="radio" id="rbtSecundario" name="VentaCartera.IdCarteraEmpleadoTipo" value="Secundario" onclick="CargarSucursales('@Url.Action("ListarSucursalesGrilla", "Cliente")','2');"/>
                                    <label for="rbtSecundario" class="mr20" style="margin-top: -5px;">
                                        Secundario
                                    </label>
                                    <br class="clear" />
                                </div>
                            </div>
                        </div>
                        <div class="formRow fluid">
                            <div id="ID_DivSucursal" title="ComboSucursal">
                            </div>
                        </div>

                        <div class="formRow fluid">
                            <div class="grid12">
                                <div class="grid2" style="padding-top: -30px">
                                    <label>
                                        RRVV :<span class="req">*</span></label>
                                </div>
                                <div class="grid9">
                                    <div id="divListaComboEmpleados">
                                        @Html.Partial(ParametrosPartialView.ComboEmpleados_PV, Model)
                                    </div>
                                    <div class="clear"></div>
                                    <div id="msgListaEmpleado">
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="formRow">
                            <button type="button" name="ActionCancelar" id="btnCancelar" style="cursor: pointer"
                                class="buttonS bBlue formSubmit group_button" onclick="return CancelarRegistroCartera();">
                                Cancelar</button>
                            <button type="button" name="ActionAgregar" id="btnAgregarA" style="cursor: pointer"
                                class="buttonS bBlue formSubmit group_button " onclick="RegistrarCartera('frmAgregarCarteraCliente');">
                                Guardar</button>
                            <br class="clear" />
                            <div class="clear">
                            </div>
                        </div>
                    </div>
                </fieldset>
            </div>
        </div>
    </div> 
 
End Using
<script type="text/javascript" language="javascript">
    $(function () {
        document.getElementById("rbtPrincipal").click();
        CargarEmpleados();
    });
</script>
