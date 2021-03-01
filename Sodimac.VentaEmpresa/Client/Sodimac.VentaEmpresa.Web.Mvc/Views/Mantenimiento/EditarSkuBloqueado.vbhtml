@ModelType Sodimac.VentaEmpresa.Web.Mvc.MantenimientoViewModel
@Imports Sodimac.VentaEmpresa.Web.Mvc.ParametrosView
@Code
    ViewData("Title") = "Nuevo Sku Bloqueado"
End Code

@Using (Html.BeginForm("EditarSkuBloqueado", "Mantenimiento", FormMethod.Post, New With {.id = "frmEditarSkuBloqueado"}))
    @Html.AntiForgeryToken
    @<div Class="wrapper">
        <div Class="form">
            <fieldset>
                <div Class="widget fluid" id="divDefinicion">
                    <div class="whead">
                        <h6>Definición del Sku Bloqueado</h6>
                        <div class="clear"> </div>
                    </div>
                    <div class="formRow fluid">
                        <div class="grid12">
                            <div class="grid5" style="padding-top:-30px"><label>Sku:<span class="req">*</span></label></div>
                            <div class="grid7">
                                @Html.TextBoxFor(Function(m) m.Producto.Sku,
New With
{
.id = "Cod_Sku_Edit",
.name = "Cod_Sku_Edit",
.maxLength = "15",
.class = "textinput",
.style = "text-transform:uppercase;width: 170px;"
})
                                @Html.ValidationMessageFor(Function(m) m.Producto.Sku, "", New With {.class = "reqizq"})
                            </div>
                        </div>
                    </div>

                    <div class="formRow" style="margin-right:10px">
                        <button type="button" name="ActionCancelar" id="btnCancelar" style="cursor:pointer" class="buttonS bBlue formSubmit group_button" onclick="DialogCancelarRegistroSkuBloqueado();">Cancelar</button>
                        <button type="button" name="ActionAgregar" id="btnAgregarA" style="cursor:pointer" class="buttonS bBlue formSubmit group_button " onclick="RegistrarSkuBloqueado();">Guardar</button>
                        <br class="clear" />
                        <div class="clear"></div>
                    </div>
                </div>
            </fieldset>
        </div>
    </div>
End Using