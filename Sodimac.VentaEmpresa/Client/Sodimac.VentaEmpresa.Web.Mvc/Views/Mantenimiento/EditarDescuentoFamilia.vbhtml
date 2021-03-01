@ModelType Sodimac.VentaEmpresa.Web.Mvc.MantenimientoViewModel
@Imports Sodimac.VentaEmpresa.Web.Mvc.ParametrosView
@Code
    ViewData("Title") = If(Model.DescuentoFamilia.CodigoFamilia.Equals(""), "Nuevo Descuento por Familia", "Editar Descuento por Familia")
End Code

@Using (Html.BeginForm("EditarDescuentoFamilia", "Mantenimiento", FormMethod.Post, New With {.id = "frmEditarDescuentoFamilia"}))
    @Html.AntiForgeryToken
    @<div Class="wrapper">
            <div Class="form">
                <fieldset>
            <div Class="widget fluid" id="divDefinicion">
                        <div class="whead">
                            <h6>Definición del Descuento de la Familia</h6>
                            <div class="clear"> </div>
                        </div>
                        <div class="formRow fluid">
                            <div class="grid12">
                                <div class="grid3" style="padding-top:-30px"><label>Familia:<span class="req">*</span></label></div>
                                <div class="grid6">
                                    @Html.DropDownListFor(Function(m) m.DescuentoFamilia.CodigoFamilia,
New SelectList(Model.ListaFamilia, "CodigoFamilia", "NombreFamilia"),
"- SELECCIONE -",
New With {
.id = "ID_Familia_Edit",
.style = "cursor:default;"
})
                                    @Html.ValidationMessageFor(Function(m) m.DescuentoFamilia.CodigoFamilia, "", New With {.class = "reqizq"})
                                </div>
                            </div>
                        </div>
                        <div class="formRow fluid">
                            <div class="grid12">
                                <div class="grid3" style="padding-top:-30px"><label>Margen :<span class="req">*</span></label></div>
                                <div class="grid9" id="divIdnombrecargo">
                                    @Html.TextBoxFor(Function(m) m.DescuentoFamilia.MargenDscto,
New With
{
.id = "MargenDscto",
.name = "MargenDscto",
.onkeypress = "return val_09_2D(event)",
.maxLength = "20",
.class = "textinput",
.style = "text-transform:uppercase;width: 208px;"
})
                                    @Html.ValidationMessageFor(Function(m) m.DescuentoFamilia.MargenDscto, "", New With {.class = "reqizq"})
                                </div>
                            </div>
                        </div>
                        <div class="formRow fluid">
                            <div class="grid12">
                                <div class="grid3" style="padding-top:-30px"><label>% Dscto. :<span class="req">*</span></label></div>
                                <div class="grid9" id="divIdnombrecargo">
                                    @Html.TextBoxFor(Function(m) m.DescuentoFamilia.Descuento,
New With {.id = "Descuento",
.name = "Descuento",
.onkeypress = "return val_09_2D(event)",
.maxLength = "20",
.class = "texinput",
.style = "text-transform:uppercase;width: 208px;"
})
                                    @Html.ValidationMessageFor(Function(m) m.DescuentoFamilia.Descuento, "", New With {.class = "reqizq"})
                                </div>
                            </div>
                        </div>

                        <div class="formRow" style="margin-right:10px">
                            <button type="button" name="ActionCancelar" id="btnCancelar" style="cursor:pointer" class="buttonS bBlue formSubmit group_button" onclick="DialogCancelarRegistroDescuentoFamilia();">Cancelar</button>
                            <button type="button" name="ActionAgregar" id="btnAgregarA" style="cursor:pointer" class="buttonS bBlue formSubmit group_button " onclick="RegistrarDescuentoFamilia();">Guardar</button>
                            <br class="clear" />
                            <div class="clear"></div>
                        </div>
                    </div>
                </fieldset>
            </div>
        </div>
End Using