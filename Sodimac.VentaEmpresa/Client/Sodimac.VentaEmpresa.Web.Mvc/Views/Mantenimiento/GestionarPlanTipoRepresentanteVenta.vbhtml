@ModelType Sodimac.VentaEmpresa.Web.Mvc.MantenimientoViewModel
@Imports Sodimac.VentaEmpresa.Web.Mvc.ParametrosView
@Code
    ViewData("Title") = "Gestionar Plan de Ventas"
End Code

@Using (Html.BeginForm("GestionarPlanTipoRepresentanteVenta_", "Mantenimiento", FormMethod.Post, New With {.id = "frmGestionarPlanTipoRepVen"}))
    @Html.AntiForgeryToken
    @<div id="ID_CopiarCurso">
        <div class="wrapper">
            <div class="form">
                <fieldset>
                    <div class="widget fluid" id="divDefinicion">
                        <div class="whead">
                            <h6>Definir Plan de Ventas</h6>
                            <div class="clear"> </div>
                        </div>

                        <div class="formRow fluid">
                            <div class="grid12">
                                <div class="grid4" style="padding-top:-30px"><label>Tipo Representante: <span class="req">*</span></label></div>
                                <div class="grid4" style="display:inline-grid">
                                    @Html.DropDownListFor(Function(m) m.PlanTipoRepresentanteVenta.TipoRepresentanteVenta.IdTipoRepVen,
                                             New SelectList(Model.PlanTipoRepresentanteVenta.ListaTipoRepresentanteVenta, "IdTipoRepVen", "NombreTipoRepVen"),
                                             "- NINGUNO -",
                                             New With {
                                             .id = "ID_CmbTipoRepVen",
                                             .class = "selector"
                                             })
                                    @Html.ValidationMessageFor(Function(m) m.PlanTipoRepresentanteVenta.TipoRepresentanteVenta.IdTipoRepVen, "", New With {.class = "reqizq"})
                                </div>
                            </div>
                        </div>

                        <div class="formRow fluid">
                            <div class="grid12">
                                <div class="grid4" style="padding-top:-30px"><label> Mes: <span class="req">*</span></label> </div>
                                <div class="grid4">
                                    @Html.DropDownListFor(Function(m) m.PlanTipoRepresentanteVenta.MesPlan.IdMes,
                                             New SelectList(Model.PlanTipoRepresentanteVenta.ListaMesPlan, "IdMes", "OrdenMes"),
                                             "-NINGUNO-",
                                             New With {
                                             .id = "ID_CmbMesPlan",
                                             .class = "selector"
                                             })
                                    @Html.ValidationMessageFor(Function(m) m.PlanTipoRepresentanteVenta.MesPlan.IdMes, "", New With {.class = "reqizq"})
                                </div>
                            </div>
                        </div>

                        <div class="formRow fluid">
                            <div class="grid12">
                                <div class="grid4" style="padding-top:-30px"><label>Plan: <span class="req">*</span></label></div>
                                <div class="grid4">
                                    @Html.TextBoxFor(Function(m) m.PlanTipoRepresentanteVenta.Plan,
                               New With
                               {
                               .id = "Plan",
                               .name = "Plan",
                               .maxLength = "10",
                               .class = "textinput",
                               .Style = "max-width:100px",
                               .onkeypress = "return validarNumeros(event)"
                                              })
                                    @Html.ValidationMessageFor(Function(m) m.PlanTipoRepresentanteVenta.Plan, "", New With {.class = "reqizq"})
                                </div>
                            </div>
                        </div>

                        <div class="formRow" style="margin-right:10px">
                            <button type="button" name="ActionCancelar" id="btnCancelar" style="cursor:pointer" class="buttonS bBlue formSubmit group_button" onclick="ConfirmarCancelarRegistroPlanTipoRepVen();">Cancelar</button>
                            <button type="button" name="ActionAgregar" id="btnAgregarA" style="cursor:pointer" class="buttonS bBlue formSubmit group_button " onclick="RegistrarPlanTipoRepVen();">Guardar</button>
                            <br class="clear" />
                            <div class="clear"></div>
                        </div>
                    </div>
                </fieldset>
            </div>
        </div>
    </div>
    @Html.HiddenFor(Function(m) m.PlanTipoRepresentanteVenta.IdPlanTipoRepVen, New With {.id = "hdn_IdPlanTipoRepVen"})
    @Html.HiddenFor(Function(m) m.PlanTipoRepresentanteVenta.TipoRepresentanteVenta.IdTipoRepVen, New With {.id = "hdn_IdTipoRepVen"})
    @Html.HiddenFor(Function(m) m.PlanTipoRepresentanteVenta.MesPlan.IdMes, New With {.id = "hdn_IdMes"})
End Using
