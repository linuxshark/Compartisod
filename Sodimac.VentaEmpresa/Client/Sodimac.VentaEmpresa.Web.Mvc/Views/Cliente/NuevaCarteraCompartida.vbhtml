@ModelType Sodimac.VentaEmpresa.Web.Mvc.ClientesViewModel
@Imports Sodimac.VentaEmpresa.DataAccess

@Using (Html.BeginForm("Agregar", "Cliente", FormMethod.Post, New With {.id = "frmAgregarCarteraCompartida"}))
    @Html.HiddenFor(Function(m) m.ClienteVenta.IdCliente, New With {.id = "ID_IdCliente"})
    @<div id="ID_CopiarCurso">
        <input type="hidden" value="@Url.Action("Agregar", "Cliente")" id="Agregar_URL" />
        <div class="wrapper">
            <div class="form">
                <fieldset>
                    <div class="widget fluid" id="divDefinicion">
                        <div class="whead">
                            <h6>
                                Agregar Cartera Compartida
                            </h6>
                            <div class="clear">
                            </div>
                        </div>
                        <div class="formRow fluid">
                            <div class="grid6">
                                <div class="grid4" style="padding-top: -30px">
                                    <label class="form-label">
                                        Fecha Inicio:
                                    </label>
                                </div>
                                <div class="grid8">
                                    @Html.TextBoxFor(Function(m) (m.ClienteCarteraFechas.FechaInicio),
                                     New With {
                                     .id = "FechaInicio",
                                     .autocomplete = "off",
                                     .class = "datepickerp maskDate",
                                     .style = "width: 35%;",
                                     .maxlength = "10",
                                     .Value = String.Format("{0:d}", "")
                                     })
                                    <div id="msgFechaInicio">
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="formRow fluid">
                            <div class="grid6">
                                <div class="grid4" style="padding-top: -30px">
                                    <label class="form-label">
                                        Fecha Fin:
                                    </label>
                                </div>
                                <div class="grid8">
                                    @Html.TextBoxFor(Function(m) (m.ClienteCarteraFechas.FechaFin),
                                     New With {
                                     .id = "FechaFin",
                                     .autocomplete = "off",
                                     .class = "datepickerp maskDate",
                                     .style = "width: 35%;",
                                     .maxlength = "10",
                                     .Value = String.Format("{0:d}", "")
                                     })
                                    <div id="msgFechaFin">
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="formRow">
                            <button type="button" name="ActionCancelar" id="btnCancelar" style="cursor: pointer"
                                    class="buttonS bDefault formSubmit group_button" onclick="return CancelarRegistro();">
                                Cancelar
                            </button>
                            <button type="button" name="ActionAgregar" id="btnAgregarA" style="cursor: pointer"
                                    class="buttonS bBlue formSubmit group_button " onclick="RegistrarCarteraCompartida('frmAgregarCarteraCompartida');">
                                Guardar
                            </button>
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
        $(".datepickerp").datepicker({
            showOtherMonths: true,
            autoSize: true,
            changeMonth: true,
            changeYear: true,
            appendText: '(DD/MM/AAAA)',
            dateFormat: 'dd/mm/yy',
            minDate: 0
        });
    });
</script>
