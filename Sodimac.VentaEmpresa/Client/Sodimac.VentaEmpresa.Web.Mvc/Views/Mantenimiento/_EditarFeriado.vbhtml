@ModelType Sodimac.VentaEmpresa.Web.Mvc.Models.ViewModel.FeriadosViewModel
@Imports Sodimac.VentaEmpresa.Web.Mvc.ParametrosView
<div class="wrapper">
    <div class="form">
        @Using (Html.BeginForm("ActualizarFeriado", "Mantenimiento", FormMethod.Post, New With {.id = "FrmEditarFeriado"}))
            @Html.HiddenFor(Function(m) m.Feriados.IdFeriado, New With {.id = "IdFerieadoEditar"})
            @<fieldset>
                <div class="formRow fluid">
                    <div class="grid12">
                        @Html.LabelFor(Function(m) m.Feriados.Mes, New With {.class = "grid4"})
                        <div class="grid8">
                            @Html.ValidationMessageFor(Function(m) m.Feriados.Mes, String.Empty, New With {.class = "reqizq"})
                            @Html.DropDownListFor(Function(m) m.Feriados.Mes,
                                         New SelectList(Model.ListaMes, "IdMes", "Mes"),
                                         " SELECCIONE ", New With {
                                         .id = "IdMesEditar"})

                        </div>
                    </div>
                </div>
                <div class="formRow fluid">
                    <div class="grid12">
                        @Html.LabelFor(Function(m) m.Feriados.Dia, New With {.class = "grid4"})
                        <div class="grid8">
                            @Html.ValidationMessageFor(Function(m) m.Feriados.Dia, String.Empty, New With {.class = "reqizq"})
                            @Html.TextBoxFor(Function(m) m.Feriados.Dia,
                                 New With {
                                 .style = "text-transform:uppercase",
                                 .class = "textinput"
                                 })

                        </div>
                    </div>
                </div>
                <div class="formRow fluid">
                    <div class="grid12">
                        @Html.LabelFor(Function(m) m.Feriados.Descripcion, New With {.class = "grid4"})
                        <div class="grid8">
                            @Html.ValidationMessageFor(Function(m) m.Feriados.Descripcion, String.Empty, New With {.class = "reqizq"})
                            @Html.TextBoxFor(Function(m) m.Feriados.Descripcion,
                                 New With {
                                 .style = "text-transform:uppercase",
                                 .class = "textinput"
                                 })

                        </div>
                    </div>
                </div>
                <div class="formRow fluid">
                    <div class="grid12">
                        @Html.LabelFor(Function(m) m.Feriados.Anio, New With {.class = "grid4"})
                        <div class="grid8">
                            @If (Model.OpcionModalidad = False) Then
                            Model.OpcionModalidad = True
                            End If
                            @Html.RadioButtonFor(Function(m) m.OpcionModalidad, True,
                                                 New With {.id = "rdoTodoAnio", .name = "rdoOpcionModalidad"}
                                                 )
                            <label for="rdoTodoAnio" style="margin-top:0px;margin-right:5px; padding:0px;line-height:14px">
                                Todos los años
                            </label>
                            <br />
                            @Html.RadioButtonFor(Function(m) m.OpcionModalidad, False,
                                                 New With {.id = "rdoAnio", .name = "rdoOpcionModalidad"}
                                                 )
                            <label for="rdoAnio" style="margin-top:0px;margin-right:5px; padding:0px;line-height:14px">
                                Año específico
                            </label>
                            <br />
                            @Html.ValidationMessageFor(Function(m) m.Feriados.Anio, String.Empty, New With {.class = "reqizq"})
                            @Html.TextBoxFor(Function(m) m.Feriados.Anio,
                                 New With {
                                 .style = "text-transform:uppercase solonumero",
                                 .class = "textinput"
                                 })
                        </div>
                    </div>
                </div>
                <div class="formRow">
                    <button type="button" name="ActionCancelar" id="btnCancelarFeriado" style="cursor:pointer" class="buttonS bDefault formSubmit group_button " onclick="return CancelarRegistro();">Cancelar</button>
                    <button type="button" name="ActionAgregar" id="btnGuardarFeriado" style="cursor:pointer" class="buttonS bBlue formSubmit group_button ">Guardar</button>
                    <br class="clear" />
                    <div class="clear"></div>
                </div>
            </fieldset>
        End Using
    </div>
</div>

