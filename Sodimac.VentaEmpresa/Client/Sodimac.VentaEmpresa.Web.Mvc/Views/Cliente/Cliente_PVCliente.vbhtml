@ModelType Sodimac.VentaEmpresa.Web.Mvc.ClientesViewModel
@Imports Sodimac.VentaEmpresa.Web.Mvc.ParametrosView
@Imports Sodimac.VentaEmpresa.Common
@Html.Hidden("UrlProvincia", Url.Action("ListarProvincia", "Cliente"))
@Html.Hidden("UrlDistrito", Url.Action("ListarDistrito", "Cliente"))
@Html.Hidden("HdnFechaActual", String.Concat(Date.Now.Year, Date.Now.Month, Date.Now.Day))
@Html.HiddenFor(Function(m) m.ClienteVenta.RazonSocial, New With {.id = "HdnRazonSocial"})
@Using (Html.BeginForm("CrearCliente", "Cliente", FormMethod.Post, New With {.id = "frmRegistrarCliente", .onsubmit = "return false;"}))
    @Html.AntiForgeryToken
    @<div class="wrapper">
        <div class="formRow">
            <div class="clear">
            </div>
        </div>
        <div class="formRow fluid">
            <div class="grid6">
                <div class="grid3">
                    <label class="form-label">
                        Modo Pago:<span class="req">*</span>
                    </label>
                </div>
                <div class="grid3">
                    <div id="divListaModoPago">
                        @Html.HiddenFor(Function(m) m.ClienteVenta.IdModoPago)
                        @Html.DropDownListFor(Function(m) m.ClienteVenta.IdModoPago,
                     New SelectList(Model.ListaClienteModoPagoCliente, "IdModoPago", "DescripcionModoPago"),
                     "- SELECCIONE -",
                     New With {
                         .class = "selector",
                         .id = "IdModoPago"
                     })
                    </div>
                </div>
            </div>
            <div class="grid6">
                <div class="grid3">
                    <label class="form-label">
                        Tipo Documento:<span class="req">*</span>
                    </label>
                </div>
                <div class="grid3">
                    <div id="divListaTipoDocumento">
                        @Html.DropDownListFor(Function(m) m.ClienteVenta.IdTipoDocumentoCliente,
                          New SelectList(Model.ListaTipoDocumentoCliente, "IdTipoDocumento", "Descripcion"),
                          New With {
                              .class = "selector",
                              .id = "IdTipoDocumentoCliente"
                          })
                    </div>
                </div>
            </div>
        </div>
        <div class="formRow fluid">
            <div class="grid6">
                <div class="grid3">
                    <label class="form-label">
                        Razón Social:<span class="req">*</span>
                    </label>
                </div>
                <div class="grid7">
                    @Html.HiddenFor(Function(m) m.ClienteVenta.Estado.Codigo, New With {.id = "IdCodigoEstado"})
                    @Html.HiddenFor(Function(m) m.ClienteVenta.IdCliente, New With {.id = "IdCliente"})
                    @Html.TextAreaFor(Function(m) m.ClienteVenta.RazonSocial,
                     New With {
                         .id = "IdRazonSocial",
                         .class = "textinput",
                         .maxlength = "100"
                     })
                    <div class="clear">
                    </div>
                    @Html.ValidationMessageFor(Function(m) m.ClienteVenta.RazonSocial, "", New With {.class = "reqizq"})
                </div>
            </div>
            <div class="grid6">
                <div class="grid3">
                    <label class="form-label">
                        Nùmero Documento:<span class="req">*</span>
                    </label>
                </div>
                <div class="grid6">
                    @Html.TextBoxFor(Function(m) m.ClienteVenta.RUC,
                       New With {
                           .id = "IdClienteRuc",
                           .onkeypress = "return val_09(event)",
                           .class = "textinput",
                           .maxlength = "11"
                      })
                    <div class="clear">
                    </div>
                    @Html.ValidationMessageFor(Function(m) m.ClienteVenta.RUC, "", New With {.class = "reqizq"})
                </div>
            </div>
            <div class="clear">
            </div>
        </div>
        <div class="formRow fluid">
            <div class="grid6">
                <div class="grid3">
                    <label class="form-label">
                        Nombre Comerc:<span class="req">*</span>
                    </label>
                </div>
                <div class="grid7">
                    @Html.TextBoxFor(Function(m) m.ClienteVenta.NombreFantasia,
                     New With {
                         .id = "IdNombreFantasia",
                         .class = "textinput",
                         .maxlength = "100"
                     })
                    <div class="clear">
                    </div>
                    @Html.ValidationMessageFor(Function(m) m.ClienteVenta.NombreFantasia, "", New With {.class = "reqizq"})
                </div>
            </div>
            <div class="grid6">
                <div class="grid3">
                    <label class="form-label">
                        Departamento:<span class="req">*</span>
                    </label>
                </div>
                <div class="grid6">
                    @Html.DropDownListFor(Function(m) m.ClienteVenta.IdDepartamento,
                     New SelectList(Model.ListaEmpleadoDepartamento, "IdDepartamento", "DescripcionDepa"),
                     "-SELECCIONE-",
                     New With {
                         .id = "ID_Departamento",
                         .onchange = "CargarProvincia();",
                         .class = "selector"
                     })
                    <div class="clear">
                    </div>
                    @Html.ValidationMessageFor(Function(m) m.ClienteVenta.IdDepartamento, "", New With {.class = "reqizq"})
                </div>
            </div>
            <div class="clear">
            </div>
        </div>
        <div class="formRow fluid">
            <div class="grid6">
                <div class="grid3">
                    <label class="form-label">
                        Provincia:<span class="req">*</span>
                    </label>
                </div>
                <div class="grid6">
                    <div id="divListaComboProvincia">
                        @Html.Partial(ParametrosPartialView.UCCLiente_Provincia_Combo, Model)
                    </div>
                </div>
            </div>
            <div class="grid6">
                <div class="grid3">
                    <label class="form-label">
                        Distrito:<span class="req">*</span>
                    </label>
                </div>
                <div class="grid6">
                    <div class="grid6">
                        <div id="divListaComboDistrito">
                            @Html.Partial(ParametrosPartialView.UCCLiente_Distrito_Combo, Model)
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="formRow fluid">
            <div class="grid6">
                <div class="grid3">
                    <label class="form-label">
                        Dirección:
                    </label>
                </div>
                <div class="grid7">
                    @Html.TextAreaFor(Function(m) m.ClienteVenta.Calle,
                     New With {
                         .id = "IdCalle",
                         .class = "textinput",
                         .maxlength = "100"
                     })
                    <div class="clear">
                    </div>
                    @Html.ValidationMessageFor(Function(m) m.ClienteVenta.Calle, "", New With {.class = "reqizq"})
                </div>
            </div>
            <div class="clear">
            </div>
        </div>
        <div class="formRow fluid">
            <div class="grid6">
                <div class="grid3">
                    <label class="form-label">
                        Fecha de Ingreso:<span class="req">*</span>
                    </label>
                </div>
                <div class="grid6">
                    @Html.TextBoxFor(Function(x) x.ClienteVenta.FechaActivacion,
                     New With {
                         .id = "IdFechaActivacion",
                         .class = "datepicker maskDate",
                         .Value = Format("{0:d}", If(Model.ClienteVenta Is Nothing, "", Model.ClienteVenta.FechaActivacion))
                     })
                    <div class="clear">
                    </div>
                    @Html.ValidationMessageFor(Function(x) x.ClienteVenta.FechaActivacion, "", New With {.id = "IdMsgFechaActivacion", .class = "reqizq"})
                </div>
            </div>
            <div class="grid6">
                <div class="grid3">
                    <label class="form-label">
                        Fecha de Vigencia:<span class="req">*</span>
                    </label>
                </div>
                <div class="grid6">
                    @Html.TextBoxFor(Function(x) x.ClienteVenta.FechaVigenciaCliente,
                     New With {
                         .id = "IdFechaVigenciaCliente",
                         .class = "datepicker maskDate",
                         .Value = Format("{0:d}", If(Model.ClienteVenta Is Nothing, "", Model.ClienteVenta.FechaVigenciaCliente))
                     })
                    <div class="clear">
                    </div>
                    @Html.ValidationMessageFor(Function(x) x.ClienteVenta.FechaVigenciaCliente, "", New With {.id = "IdMsgFechaVigenciaCliente", .class = "reqizq"})
                </div>
            </div>
            <div class="clear">
            </div>
        </div>
        <div class="formRow fluid">
            <div class="grid6">
                <div class="grid3">
                    <label class="form-label">
                        Grupo: @*<span class="req">*</span>*@
                    </label>
                </div>
                <div class="grid6">
                    @Html.DropDownListFor(Function(x) x.ClienteVenta.Grupo.IdGrupo,
                            New SelectList(Model.ListaGrupo, "IdGrupo", "NombreGrupo"),
                            "-SELECCIONE-",
                             New With {
                                 .id = "Id_Grupo",
                                 .class = "Selector"
                             })
                    <div class="clear">
                    </div>
                </div>
            </div>
            <div class="grid6">
                <div class="grid3">
                    <label class="form-label">
                        Procedencia Capital:
                    </label>
                </div>
                <div class="grid6">
                    @Html.TextBoxFor(Function(m) m.ClienteVenta.ProcedenciaCapital,
                     New With {
                         .id = "Id_ProcCapital",
                         .class = "textinput",
                         .maxlength = "50"
                     })
                </div>
                <div class="clear">
                </div>
            </div>
        </div>
        @If Model.ClienteVenta.IdModoPago = Constantes.ID_MODOPAGO_CREDITO Then
            @<div class="formRow fluid">
                <div class="grid6">
                    <div class="grid3">
                        <label class="form-label">
                            Activación SIGIC:
                        </label>
                    </div>
                    <div class="grid6">
                        @Html.TextBoxFor(Function(m) m.ClienteVenta.SigicFechaRegistro,
                         New With {
                             .id = "SigicFechaRegistro",
                             .class = "textinput datepicker"
                         })
                        <div class="clear">
                        </div>
                        @Html.ValidationMessageFor(Function(x) x.ClienteVenta.FechaRegistro, "", New With {.class = "reqizq"})
                    </div>
                </div>
            </div>
        End If
        <div class="widget fluid">
            <ul class="tabs">
                <li id="ID_tabDatosContacto" class="activeTab">
                    <a href="#tabb1_1">Datos Contacto</a>
                </li>
                <li id="ID_tabClasificacion" class=""><a href="#tabb2_2">Clasificación</a> </li>
            </ul>
            <div class="tab_container">
                <div id="tabb1_1" class="tab_content" style="display: block;">
                    <div class="formRow fluid">
                        <div class="grid6">
                            <div class="grid3">
                                <label class="form-label">
                                    Fecha Aniversario:
                                </label>
                            </div>
                            <div class="grid6">
                                @Html.TextBoxFor(Function(x) x.ClienteVenta.FechaAniversario,
                     New With {
                         .id = "ID_FechaAniversario",
                         .class = "textinput datepicker",
                         .Value = IIf(CBool(Model.ClienteVenta.FechaAniversario Is Nothing) = False, "", Model.ClienteVenta.FechaAniversario)
                     })
                                @*<div class="clear">
                                    </div>.Value = Format("{0:d}", Model.ClienteVenta.FechaAniversario)
                                    @Html.ValidationMessageFor(Function(x) x.ClienteVenta.FechaAniversario, "", New With {.class = "reqizq"})*@
                            </div>
                        </div>
                        <div class="grid6">
                            <div class="grid3">
                                <label class="form-label">
                                    Email:
                                </label>
                            </div>
                            <div class="grid7">
                                @Html.TextBoxFor(Function(m) m.ClienteVenta.Email,
                     New With {
                         .id = "IdEmail",
                         .class = "textinput",
                         .maxlength = "50"
                     })
                                @Html.ValidationMessageFor(Function(m) m.ClienteVenta.Email, "", New With {.class = "reqizq"})
                            </div>
                        </div>
                        <div class="clear">
                        </div>
                    </div>
                    <div class="formRow fluid">
                        <div class="grid6">
                            <div class="grid3">
                                <label class="form-label">
                                    Teléfono:
                                </label>
                            </div>
                            <div class="grid6">
                                <div class="grid6">
                                    @Html.TextBoxFor(Function(m) m.ClienteVenta.Telefono,
                     New With {
                         .id = "IdTelefono",
                         .class = "textinput",
                         .maxlength = "15",
                         .onkeypress = "return val_TelefonoFax(event)"
                     })
                                </div>
                                <div class="clear">
                                </div>
                                @Html.ValidationMessageFor(Function(m) m.ClienteVenta.Telefono, "", New With {.class = "reqizq"})
                            </div>
                        </div>
                        <div class="grid6">
                            <div class="grid3">
                                <label class="form-label">
                                    Fax:
                                </label>
                            </div>
                            <div class="grid6">
                                <div class="grid6">
                                    @Html.TextBoxFor(Function(m) m.ClienteVenta.Fax,
                     New With {
                         .id = "IdFax",
                         .class = "textinput",
                         .maxlength = "15",
                         .onkeypress = "return val_TelefonoFax(event)"
                     })
                                </div>
                                <div class="clear">
                                </div>
                                @Html.ValidationMessageFor(Function(m) m.ClienteVenta.Fax, "", New With {.class = "reqizq"})
                            </div>
                        </div>
                    </div>
                </div>
                <div id="tabb2_2" class="tab_content" style="display: none;">
                    <div class="formRow fluid">
                        <div class="grid6">
                            <div class="grid3">
                                <label class="form-label">
                                    Sector Económico:<span class="req">*</span>
                                </label>
                            </div>
                            <div class="grid6">
                                @Html.DropDownListFor(Function(m) m.ClienteVenta.IdClienteSector,
                     New SelectList(Model.ListaClienteSector, "IdClienteSector", "Descripcion"),
                     "-SELECCIONE-",
                     New With {
                         .id = "IdClienteSector",
                         .class = "textinput selector"
                     })
                                <div class="clear">
                                </div>
                                @Html.ValidationMessageFor(Function(m) m.ClienteVenta.IdClienteSector, "", New With {.class = "reqizq"})
                            </div>
                        </div>
                        <div class="grid6">
                            <div class="grid3">
                                <label class="form-label">
                                    Tipo:<span class="req">*</span>
                                </label>
                            </div>
                            <div class="grid6">
                                @Html.DropDownListFor(Function(m) m.ClienteVenta.IdClienteTipo,
                     New SelectList(Model.ListaClienteTipo, "IdClienteTipo", "Descripcion"),
                     "-SELECCIONE-",
                     New With {
                         .id = "IdClienteTipo",
                         .class = "textinput selector"
                     })
                                <div class="clear">
                                </div>
                                @Html.ValidationMessageFor(Function(m) m.ClienteVenta.IdClienteTipo, "", New With {.class = "reqizq"})
                            </div>
                        </div>
                        <div class="clear">
                        </div>
                    </div>
                    <div class="formRow fluid">
                        <div class="grid6">
                            <div class="grid3">
                                <label class="form-label">
                                    Categoría:<span class="req">*</span>
                                </label>
                            </div>
                            <div class="grid6">
                                @Html.DropDownListFor(Function(m) m.ClienteVenta.IdClienteCategoria,
                     New SelectList(Model.ListaClienteCategoria, "IdClienteCategoria", "Descripcion"),
                     "-SELECCIONE-",
                     New With {
                         .id = "IdClienteCategoria",
                         .class = "textinput selector"
                     })
                                <div class="clear">
                                </div>
                                @Html.ValidationMessageFor(Function(m) m.ClienteVenta.IdClienteCategoria, "", New With {.class = "reqizq"})
                            </div>
                        </div>
                        @*<div class="grid6">
                                <div class="grid3">
                                    <label class="form-label">
                                        Clasificación Externa:</label>
                                </div>
                                <div class="grid6">
                                    <select class="textinput selector" id="Cliente.Cexterna" name="Cliente.Cexterna"
                                        disabled>
                                        <option value="">- SELECCIONE -</option>
                                    </select>
                                </div>
                            </div>*@
                        <div class="clear">
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="formRow">
            <div class="clear">
            </div>
        </div>
        <div class="formRow">
            <button type="button" class="buttonS bDefault formSubmit group_button" style="cursor: pointer;"
                    onclick="InicioJPopUpOpen('#dialogCancelarCliente');">
                Cancelar
            </button>
            @If Model.ClienteVenta.Estado.Codigo = Parametros.CLIENTE_ESTADO_CODIGO_ACTIVO Or Model.ClienteVenta.IdCliente = 0 Then
                @<button type="button" onclick="ValidarPagoContactoCliente();" class="buttonS bBlue formSubmit group_button" style="cursor: pointer;">
                    Guardar
                </button>
            Else
                @<button type="button" disabled="disabled" class="buttonS bBlue formSubmit group_button" style="cursor: pointer;">
                    Guardar
                </button>
            End If
            @If Model.ClienteVenta.IdCliente <> 0 Then
                @* @If Model.ClienteVenta.Estado.Codigo <> Parametros.CLIENTE_ESTADO_CODIGO_ACTIVO Then*@
                @If Not Model.ClienteVenta.Activo Then
                    @<button type="button" onclick="ValidaClienteCartera();" class="buttonS bBlue
                    formSubmit group_button" style="cursor: pointer;">
                        Habilitar
                    </button>
                ElseIf Model.ClienteVenta.IdModoPago <> 1 Or Model.ClienteVenta.Activo Then
                    @<button type="button" onclick="ValidaClienteCartera();" class="buttonS bBlue
                formSubmit group_button" style="cursor: pointer;">
                        Desactivar
                    </button>

                End If

            Else

            End If
            @*  'End If*@
            <div class="clear">
            </div>
        </div>
        <div class="formRow">
            <div class="clear">
            </div>
        </div>
    </div>

    @If Model.ClienteVenta.Activo = 0 Then
        @<div id="dialogGrabarCliente" title="Mensaje de Confirmación">
            <p>
                ¿Desea grabar el registro?
            </p>
        </div>
    Else
        @<div id="dialogGrabarCliente" title="Mensaje de Confirmación">
            <p>
                ¿Desea actualizar el registro?
            </p>
        </div>
    End If

    @<div id="dialogCancelarCliente" title="Mensaje de confirmación">
        <p>
            ¿Desea cancelar el registro?
        </p>
    </div>
    @<div id="dialogEstadoClienteconCartera" title="Mensaje de confirmación">
        <p>
            ¿Desea actualizar el estado?
        </p>
        <p>
            Este cliente esta asociado a cartera
        </p>
    </div>
    @<div id="dialogEstadoClientesinCartera" title="Mensaje de confirmación">
        <p>
            ¿Desea actualizar el estado?
        </p>
    </div>


End Using
@Html.HiddenFor(Function(m) m.ClienteVenta.IdCliente, New With {.id = "ID_IdCliente"})
<script type="text/javascript">
    $(function () {
        $("#IdModoPago").prop('disabled', true);
        InicioJPopUpConfirm("#dialogGrabarCliente", 400, false, "Mensaje de Confirmación", GuardarPagoContactoCliente);
        InicioJPopUpConfirm("#dialogCancelarCliente", 400, false, "Mensaje de Confirmación", CancelarPagoContactoCliente);
        InicioJPopUpConfirm("#dialogEstadoClienteconCartera", 400, false, "Mensaje de Confirmación", CambiarSituacionCliente);
        InicioJPopUpConfirm("#dialogEstadoClientesinCartera", 400, false, "Mensaje de Confirmación", CambiarSituacionCliente);
        ValidarFechaMaskEdit(".datepicker");
        $("#IdRazonSocial").css('resize', 'none');
        $("#IdCalle").css('resize', 'none');
    });
</script>
@If Model.ClienteVenta.IdModoPago = Constantes.ID_MODOPAGO_CREDITO Then
    @<script type="text/javascript">
        //         $("#IdRazonSocial").prop('disabled', true);
        //         $("#IdClienteRuc").prop('disabled', true);
        //         $("#IdModoPago").prop('disabled', true);
        //         $("#IdNombreFantasia").prop('disabled', true);
        //         $("#SigicFechaRegistro").prop('disabled', true);
        //         $("#ID_Departamento").prop('disabled', true);
        //         $("#ID_Provincia").prop('disabled', true);
        //         $("#ID_Distrito").prop('disabled', true);
        //         $("#IdCalle").prop('disabled', true);
        $("#TabDatosCliente select").prop('disabled', true);
        $("#TabDatosCliente input").prop('disabled', true);
    </script>
End If
@*If (Model.ClienteVenta.Estado.Codigo = Parametros.CLIENTE_ESTADO_CODIGO_INACTIVO) Then*@
@If (Model.ClienteVenta.IdCliente <> 0 AndAlso Not Model.ClienteVenta.Activo) Then
    @<script type="text/javascript" language="javascript">
        $('#tabPage4').attr("disabled", true);
        $('#tabPage3').attr("disabled", true);
        $('#tabPage2').attr("disabled", true);
        $("#IdRazonSocial").attr("disabled", "disabled");
        $("#IdCalle").attr("disabled", "disabled");

    </script>
Else
    @<script type="text/javascript" language="javascript">
        $('#tabPage3').attr("disabled", false);
        $('#tabPage4').attr("disabled", false);
    </script>
End If