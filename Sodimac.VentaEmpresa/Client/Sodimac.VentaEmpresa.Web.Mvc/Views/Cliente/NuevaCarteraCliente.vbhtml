@ModelType Sodimac.VentaEmpresa.Web.Mvc.ClientesViewModel
@Imports Sodimac.VentaEmpresa.Web.Mvc.ParametrosView
@Code
    ViewBag.Title = "Agregar Cartera de Cliente"
End Code
@Using (Html.BeginForm("NuevaCarteraCliente_", "Cliente", FormMethod.Post, New With {.id = "frmAgregarCarteraClientes"}))
    @Html.AntiForgeryToken
    @Html.Hidden("UrlEmpleado", Url.Action("ListarEmpleado_ComboBox", "Cliente"))
    @Html.Hidden("UrlSucursales", Url.Action("Sucursales_PV_Grilla", "Cliente"))
    @Html.Hidden("UrlVistaCartera",Url.Action("CargarVistaCartera","Cliente"))
    @Html.HiddenFor(Function(m) m.ClienteVenta.IdCliente, New With {.id = "ID_IdCliente"})
    @Html.HiddenFor(Function(m) m.VentaCartera.IdCarteraEmpleadoTipo, New With {.id = "ID_idCarteraEmpleadoTipo"})
    @Html.HiddenFor(Function(m) m.VentaCartera.TCompartida, New With {.id = "ID_TCompartida"})
    @Html.HiddenFor(Function(m) m.VentaCartera.IdSucursal, New With {.id = "ID_idSucursales"})
    @Html.HiddenFor(Function(m) m.VentaCartera.IdCartera, New With {.id = "ID_IdCartera"})
    @Html.HiddenFor(Function(m) m.VentaCartera.Activo, New With {.id = "ID_IdCarteraEstado"})
    @Html.HiddenFor(Function(m) m.VentaCartera.IdEmpleado, New With {.id = "ID_IdEmpleado"})
 

    @<div id="ID_AgregarCarteraCliente">
        @*<input type="hidden" value="@Url.Action("AgregarCarteraCliente", "Cliente")" id="AgregarCarteraCliente_URL" />*@
        <div class="wrapper">
            <div class="form">
                <fieldset>
                    @Html.Hidden("PagePreview", 1)
                    <div class="widget fluid" id="divDefinicion">
                        <div class="whead">
                            <h6>
                                Agregar Cartera de Cliente</h6>
                            <div class="clear">
                            </div>
                        </div>
                        <div class="formRow fluid">
                            <div class="grid12">
                                <div class="grid3" style="padding-top: -30px">
                                    <label>
                                        Cliente :</label></div>
                                <div class="grid9">
                                    @Html.TextBoxFor(Function(m) m.ClienteVenta.RazonSocial, New With {.id = "IdRazonSocial", .class = "textinput", .disabled = "disabled"})
                                </div>
                            </div>
                        </div>
                        <div class="formRow fluid">
                            <div class="grid12">
                                <div class="grid3" style="margin-top: -10px;">
                                    <label>
                                        Tipo :</label>
                                </div>
                                <div class="grid9">
                                    <input type="radio" id="rbtPrincipal" name="VentaCartera.IdCarteraEmpleadoTipo" checked="checked" value="Principal" onclick="CargarVistaporVendedor(1)" />
                                    <label for="rbtPrincipal" class="mr20" style="margin-top: -5px;">
                                        Principal
                                    </label>
                                    <input type="radio" id="rbtSecundario" disabled="disabled"  name="VentaCartera.IdCarteraEmpleadoTipo" value="Secundario" onclick="CargarVistaporVendedor(2)"/>
                                    <label for="rbtSecundario" class="mr20" style="margin-top: -5px;">
                                        Secundario
                                    </label>
                                    <br class="clear" />
                                </div>
                            </div>
                        </div>
                        <div id="IdVistaCartera">
                            @Html.Partial(ParametrosPartialView.PVCliente_NuevaCarteraporTipo, Model)
                        </div>                      
                        <div class="formRow">
                            <button type="button" name="ActionCancelar" id="btnCancelar" style="cursor: pointer"
                                class="buttonS bDefault formSubmit group_button" onclick="DialogCancelarRegistroCargo();">
                                Cancelar</button>
                            <button type="button" name="ActionAgregar" id="btnAgregarA" style="cursor: pointer"
                                class="buttonS bBlue formSubmit group_button" onclick="RegistrarNuevaCartera();">
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
@*   @Html.Hidden("rbtPrincipal", 0, New With {.id = "HD_IDTipocarteraEmpleado"})
  @Html.Hidden("rbtSecundario", 1, New With {.id = "HD_IDTipocarteraEmpleadoSe"})*@
<script type="text/javascript" language="javascript">
    $(function () {
        document.getElementById("rbtPrincipal").click();
        //        CargarEmpleados();
    });
    $("#IdFechaActivacion").datepicker();
    $(".datepicker").mask("99/99/9999");
</script>
