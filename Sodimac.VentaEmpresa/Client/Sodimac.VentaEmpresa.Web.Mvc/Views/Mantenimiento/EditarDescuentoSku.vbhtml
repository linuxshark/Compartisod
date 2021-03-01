@ModelType Sodimac.VentaEmpresa.Web.Mvc.MantenimientoViewModel
@Imports Sodimac.VentaEmpresa.Web.Mvc.ParametrosView
@Code
    ViewData("Title") = "Nuevo Descuento por Familia"
End Code

@Using (Html.BeginForm("EditarDescuentoSku", "Mantenimiento", FormMethod.Post, New With {.id = "frmEditarDescuentoSku"}))
    @Html.AntiForgeryToken
    @<div Class="wrapper">
        <div Class="form">
            <fieldset>
                <div Class="widget fluid" id="divDefinicion">
                    <div class="whead">
                        <h6>Definición del Descuento del Sku</h6>
                        <div class="clear"> </div>
                    </div>
                    <div class="formRow fluid">
                        <div class="grid12">
                            <div class="grid5" style="padding-top:-30px"><label>Sku:<span class="req">*</span></label></div>
                            <div class="grid7">
                                @Html.TextBoxFor(Function(m) m.DescuentoSku.CodigoSku,
New With
{
.id = "Cod_Sku_Edit",
.name = "Cod_Sku_Edit",
.maxLength = "15",
.class = "textinput",
.style = "text-transform:uppercase;width: 170px;"
})
                                @Html.ValidationMessageFor(Function(m) m.DescuentoSku.CodigoSku, "", New With {.class = "reqizq"})
                            </div>
                        </div>
                    </div>
                    <div class="formRow fluid">
                        <div class="grid12">
                            <div class="grid5" style="padding-top:-30px"><label>Cantidad Desde :<span class="req">*</span></label></div>
                            <div class="grid7" id="divIdnombrecargo">
                                @Html.TextBoxFor(Function(m) m.DescuentoSku.CantidadDesde,
New With
{
.id = "CantidadDesde",
.name = "CantidadDesde",
.onkeypress = "return val_09_2D(event)",
.maxLength = "20",
.class = "textinput",
.style = "text-transform:uppercase;width: 170px;"
})
                                @Html.ValidationMessageFor(Function(m) m.DescuentoSku.CantidadDesde, "", New With {.class = "reqizq"})
                            </div>
                        </div>
                    </div>
                    <div class="formRow fluid">
                        <div class="grid12">
                            <div class="grid5" style="padding-top:-30px"><label>Cantidad Hasta :<span class="req">*</span></label></div>
                            <div class="grid7" id="divIdnombrecargo">
                                @Html.TextBoxFor(Function(m) m.DescuentoSku.CantidadHasta,
New With
{
.id = "CantidadHasta",
.name = "CantidadHasta",
.onkeypress = "return val_09_2D(event)",
.maxLength = "20",
.class = "textinput",
.style = "text-transform:uppercase;width: 170px;"
})
                                @Html.ValidationMessageFor(Function(m) m.DescuentoSku.CantidadHasta, "", New With {.class = "reqizq"})


                            </div>
                        </div>
                    </div>
                    <div class="formRow fluid">
                        <div class="grid12">
                            <div class="grid5" style="padding-top:-30px"><label>Margen :<span class="req">*</span></label></div>
                            <div class="grid7" id="divIdnombrecargo">
                                @Html.TextBoxFor(Function(m) m.DescuentoSku.MargenDscto,
New With
{
.id = "MargenDscto",
.name = "MargenDscto",
.onkeypress = "return val_09_2D(event)",
.maxLength = "20",
.class = "textinput",
.style = "text-transform:uppercase;width: 170px;"
})
                                @Html.ValidationMessageFor(Function(m) m.DescuentoSku.MargenDscto, "", New With {.class = "reqizq"})
                            </div>
                        </div>
                    </div>
                    <div class="formRow fluid">
                        <div class="grid12">
                            <div class="grid5" style="padding-top:-30px"><label>% Dscto. :<span class="req">*</span></label></div>
                            <div class="grid7" id="divIdnombrecargo">
                                @Html.TextBoxFor(Function(m) m.DescuentoSku.Descuento,
New With {.id = "Descuento",
.name = "Descuento",
.onkeypress = "return val_09_2D(event)",
.maxLength = "20",
.class = "texinput",
.style = "text-transform:uppercase;width: 170px;"
})
                                @Html.ValidationMessageFor(Function(m) m.DescuentoSku.Descuento, "", New With {.class = "reqizq"})
                            </div>
                        </div>
                    </div>

                    <div class="formRow" style="margin-right:10px">
                        <button type="button" name="ActionCancelar" id="btnCancelar" style="cursor:pointer" class="buttonS bBlue formSubmit group_button" onclick="DialogCancelarRegistroDescuentoSku();">Cancelar</button>
                        <button type="button" name="ActionAgregar" id="btnAgregarA" style="cursor:pointer" class="buttonS bBlue formSubmit group_button " onclick="RegistrarDescuentoSku();">Guardar</button>
                        <br class="clear" />
                        <div class="clear"></div>
                    </div>
                </div>
            </fieldset>
        </div>
    </div>
End Using