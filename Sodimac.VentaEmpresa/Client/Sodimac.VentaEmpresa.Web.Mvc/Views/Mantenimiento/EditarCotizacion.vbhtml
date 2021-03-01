@ModelType Sodimac.VentaEmpresa.Web.Mvc.MantenimientoViewModel
@Imports Sodimac.VentaEmpresa.Web.Mvc.ParametrosView
@Code
    ViewData("Title") = "Agregar Nro. Cotización Uxpos"
End Code

@Using (Html.BeginForm("EditarCotizacion", "Mantenimiento", FormMethod.Post, New With {.id = "frmEditarCotizacion"}))
    @Html.AntiForgeryToken
    @<div Class="wrapper">
        <div Class="form">
            <fieldset>
                <div Class="widget fluid" id="divDefinicion">
                    <div class="whead">
                        <h6>Definición del Cotización</h6>
                        <div class="clear"> </div>
                    </div>
                    <div class="formRow fluid">
                        <div class="grid12">
                            <div class="grid6" style="padding-top:-30px"><label>Nro. Cotización :<span class="req">*</span></label></div>
                            <div class="grid6" id="divIdnombrecargo">
                                @Html.TextBoxFor(Function(m) m.Cotizacion.NroCotizacion,
New With
{
.id = "NroCotizacion",
.name = "NroCotizacion",
.maxLength = "30",
.class = "textinput",
.style = "text-transform:uppercase;width: 150px;",
.readonly = "readonly"
})
                                @Html.ValidationMessageFor(Function(m) m.Cotizacion.NroCotizacion, "", New With {.class = "reqizq"})
                            </div>
                        </div>
                    </div>
                    <div class="formRow fluid">
                        <div class="grid12">
                            <div class="grid6" style="padding-top:-30px"><label>Nro. Cotización UXPOS :<span class="req">*</span></label></div>
                            <div class="grid6" id="divIdnombrecargo">
                                @Html.TextBoxFor(Function(m) m.Cotizacion.NroCotizacionUxpos,
New With {
.id = "NroCotizacionUxpos",
.name = "NroCotizacionUxpos",
.onkeypress = "return val_09_2D(event)",
.maxLength = "30",
.class = "texinput",
.style = "text-transform:uppercase;width: 150px;"
})
                                @Html.ValidationMessageFor(Function(m) m.Cotizacion.NroCotizacionUxpos, "", New With {.class = "reqizq"})
                            </div>
                        </div>
                    </div>

                    <div class="formRow" style="margin-right:10px">
                        <button type="button" name="ActionCancelar" id="btnCancelar" style="cursor:pointer" class="buttonS bBlue formSubmit group_button" onclick="DialogCancelarRegistroCotizacion();">Cancelar</button>
                        <button type="button" name="ActionAgregar" id="btnAgregarA" style="cursor:pointer" class="buttonS bBlue formSubmit group_button " onclick="RegistrarCotizacion();">Guardar</button>
                        <br class="clear" />
                        <div class="clear"></div>
                    </div>
                </div>
            </fieldset>
        </div>
    </div>
End Using