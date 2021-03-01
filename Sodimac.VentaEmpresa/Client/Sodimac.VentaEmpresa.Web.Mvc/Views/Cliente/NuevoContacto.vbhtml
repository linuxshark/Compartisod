@ModelType Sodimac.VentaEmpresa.Web.Mvc.ClientesViewModel
@Imports Sodimac.VentaEmpresa.DataAccess

@Using (Html.BeginForm("Agregar", "Cliente", FormMethod.Post, New With {.id = "frmAgregarContacto"}))
@Html.HiddenFor(Function(m) m.ClienteVenta.IdCliente, New With {.id = "ID_IdCliente"})
@<div id="ID_CopiarCurso">
    <input type="hidden" value="@Url.Action("Agregar", "Cliente")" id="Agregar_URL" />
    <div class="wrapper">
        <div class="form">
            <fieldset>
                <div class="widget fluid" id="divDefinicion">
                    <div class="whead">
                        <h6>
                            Agregar Personal Contacto</h6>
                        <div class="clear">
                        </div>
                    </div>
                    <div class="formRow fluid">
                        <div class="grid6">
                            <div class="grid3" style="padding-top: -30px">
                                <label>
                                    Tipo:<span class="req">*</span></label>
                            </div>
                            <div class="grid9">
                                @If (Not Model.ListaContactoTipo Is Nothing) Then
                                    @Html.DropDownListFor(Function(m) m.ClienteContacto.IdCargoTipo,
                                    New SelectList(Model.ListaContactoTipo, "IdContactoTipo", "Descripcion"),
                                    "- SELECCIONE -",
                                    New With {
                                        .id = "ID_IdCargoTipo",
                                        .class = "selector"
                                    })
                                End If
                                <div id="msgListaContactoTipo">
                                </div>
                            </div>
                        </div>
                        <div class="grid6">
                            <div class="grid3" style="padding-top: -30px">
                                <label>
                                    Clase:<span class="req">*</span></label>
                            </div>
                            <div class="grid9">
                                @If (Not Model.ListaContactoClase Is Nothing) Then
                                    @Html.DropDownListFor(Function(m) m.ClienteContacto.IdContactoClase,
                                    New SelectList(Model.ListaContactoClase, "IdContactoClase", "Descripcion"),
                                    "- SELECCIONE -",
                                    New With {
                                        .id = "ID_IdContactoClase",
                                        .class = "selector"
                                    })
                                End If
                                <div id="msgListaContactoClase">
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="formRow fluid">
                        <div class="grid6">
                            <div class="grid3" style="padding-top: -30px">
                                <label>
                                    Nombres:<span class="req">*</span></label>
                            </div>
                            <div class="grid8">
                                @Html.TextBoxFor(Function(m) m.ClienteContacto.Nombres,
                                New With {
                                    .id = "Nombres",
                                    .name = "Nombres",
                                    .onkeypress = "return val_AZ(event)",
                                    .maxLength = "50",
                                    .class = "textinput",
                                    .style = "text-transform:uppercase;"
                                })
                                <div id="msgNombres">
                                </div>
                            </div>
                        </div>
                        <div class="grid6">
                            <div class="grid3" style="padding-top: -30px">
                                <label>
                                    Apellidos:<span class="req">*</span></label>
                            </div>
                            <div class="grid8">
                                @Html.TextBoxFor(Function(m) m.ClienteContacto.Apellidos,
                                New With {
                                    .id = "Apellidos",
                                    .name = "Apellidos",
                                    .onkeypress = "return val_AZ(event)",
                                    .maxLength = "50",
                                    .class = "textinput",
                                    .style = "text-transform:uppercase;"
                                })
                                <div id="msgApellidos">
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="formRow fluid">
                        <div class="grid6">
                            <div class="grid3" style="padding-top: -30px">
                                <label>
                                    Teléfono:</label>
                            </div>
                            <div class="grid6">
                                @Html.TextBoxFor(Function(m) m.ClienteContacto.Telefono,
                                New With {
                                    .id = "ID_Telefono",
                                    .onkeypress = "return val_TelefonoFax(event)",
                                    .maxLength = "50",
                                    .class = "textinput"
                                })
                                <div id="msgTelefono">
                                </div>
                            </div>
                        </div>
                        <div class="grid6">
                            <div class="grid3" style="padding-top: -30px">
                                <label>
                                    Fax:</label>
                            </div>
                            <div class="grid6">
                                @Html.TextBoxFor(Function(m) m.ClienteContacto.Fax,
                                New With {
                                    .id = "Telefono",
                                    .name = "Telefono",
                                    .onkeypress = "return val_TelefonoFax(event)",
                                    .maxLength = "50",
                                    .class = "textinput"
                                })
                                <div id="msgFax">
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="formRow fluid">
                        <div class="grid6">
                            <div class="grid3" style="padding-top: -30px">
                                <label>
                                    Celular 1:</label>
                            </div>
                            <div class="grid6">
                                @Html.TextBoxFor(Function(m) m.ClienteContacto.Celular1,
                                New With {
                                    .id = "Telefono",
                                    .name = "Telefono",
                                    .onkeypress = "return val_TelefonoFax(event)",
                                    .maxLength = "50",
                                    .class = "textinput"
                                })
                                <div id="msgCelular1">
                                </div>
                            </div>
                        </div>
                        <div class="grid6">
                            <div class="grid3" style="padding-top: -30px">
                                <label class="form-label">
                                    Celular 2:</label>
                            </div>
                            <div class="grid6">
                                @Html.TextBoxFor(Function(m) m.ClienteContacto.Celular2,
                                New With {
                                    .id = "Telefono",
                                    .name = "Telefono",
                                    .onkeypress = "return val_TelefonoFax(event)",
                                    .maxLength = "50",
                                    .class = "textinput"
                                })
                                <div id="msgCelular2">
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="formRow fluid">
                        <div class="grid6">
                            <div class="grid3" style="padding-top: -30px">
                                <label class="form-label">
                                    Email:</label>
                            </div>
                            <div class="grid8">
                                @Html.TextBoxFor(Function(m) m.ClienteContacto.Email,
                                New With {
                                    .id = "Email",
                                    .name = "Email",
                                    .maxLength = "50",
                                    .class = "textinput"
                                })
                                <div id="msgEmail">
                                </div>
                            </div>
                        </div>
                        <div class="grid6">
                            <div class="grid4" style="padding-top: -30px">
                                <label class="form-label">
                                    Fecha Nacimiento:</label>
                            </div>
                            <div class="grid8">
                                @Html.TextBoxFor(Function(m) (m.ClienteContacto.FechaNacimiento),
                                New With {
                                    .id = "ID_FechaNacimiento",
                                    .autocomplete = "off",
                                    .class = "datepicker maskDate",
                                    .maxlength = "10",
                                    .Value = String.Format("{0:d}", "")
                                })
                                <div id="msgFecha">
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="formRow">
                        <button type="button" name="ActionCancelar" id="btnCancelar" style="cursor: pointer"
                            class="buttonS bDefault formSubmit group_button" onclick="return CancelarRegistro();">
                            Cancelar</button>
                        <button type="button" name="ActionAgregar" id="btnAgregarA" style="cursor: pointer"
                            class="buttonS bBlue formSubmit group_button " onclick="RegistrarContacto('frmAgregarContacto');">
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
        $(".datepicker").datepicker({
            showOtherMonths: true,
            autoSize: true,
            changeMonth: true,
            changeYear: true,
            appendText: '(DD/MM/AAAA)',
            dateFormat: 'dd/mm/yy'
        });
    });
    $("#ID_IdCargoTipo").uniform();
    $("#ID_IdContactoClase").uniform();
</script>
