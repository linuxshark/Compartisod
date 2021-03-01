@ModelType Sodimac.VentaEmpresa.Web.Mvc.ComisionViewModel
@Code
    ViewData("Title") = "Gestionar Escala Comisión"
End Code
<script type='text/javascript' src='@Url.Content("~/Scripts/View/Comision.js")'></script>
<div class="breadLine">
    <div class="bc">
        <ul id="breadcrumbs" class="breadcrumbs">
            <li><a href="#">Inicio</a> </li>
            <li class=""><a href="#">Planificación</a></li>
            <li class="current"><a title="" href="#">Gestionar Escala Comisión</a></li>
        </ul>
    </div>
</div>
<div class="contentTop">
    <span class="pageTitle"><span id="IdAgregarTitle" class="icon-screen"></span>Gestionar
        Escala Comisión</span>
    <div class="clear">
    </div>
</div>
<div class="wrapper">
    <div class="main">
        <fieldset>
            @Using (Html.BeginForm(Nothing, Nothing, FormMethod.Post, New With {.id = "ID_ComisionEscalaDetalle", .onsubmit = "return false;"}))
                @Html.AntiForgeryToken
                @Html.HiddenFor(Function(m) m.ComisionEscala.FechaActualizacion, New With {.id = "ID_FechaActualizacion"})
                @<div class="widget fluid">
                    <div class="whead">
                        <h6>
                            Datos Generales
                        </h6>
                        <div class="clear">
                        </div>
                    </div>
                    <div class="formRow fluid">
                        <div class="grid6">
                            <div class="grid3">
                                <label class="form-label">
                                    Periodo:</label>
                            </div>
                            <div class="grid3">
                                @Html.TextBoxFor(Function(m) m.ComisionEscala.ComisionPeriodo.NombrePeriodo,
                                New With {
                                    .id = "ID_NombrePeriodo",
                                    .class = "textinput ",
                                    .style = "text-transform:uppercase;",
                                    .disabled = "disabled",
                                    .maxlength = "50"
                                })
                            </div>
                        </div>
                        <div class="grid6">
                            <div class="grid3">
                                <label class="form-label" for="tipoPersona">
                                    Perfil: <small class="alert_validation"></small>
                                </label>
                            </div>
                            <div class="grid9">
                                @Html.DropDownListFor(Function(m) m.ComisionEscala.EmpleadoPerfil.IdPerfil,
                                New SelectList(Model.ListaEmpleadoPerfil, "IdPerfil", "DescripcionPerfil"),
                                "-SELECCIONE-",
                                New With {
                                    .id = "ID_IdPerfil",
                                    .disabled = "disabled",
                                    .style = "cursor:default;"
                                })
                            </div>
                        </div>
                        <div class="clear">
                        </div>
                    </div>
                    <div class="formRow fluid">
                        <div class="grid6">
                            <div class="grid3">
                                <label class="form-label" for="tipoPersona">
                                    Cargo:</label>
                            </div>
                            <div class="grid9">
                                @Html.DropDownListFor(Function(m) m.ComisionEscala.EmpleadoCargo.IdEmpleadoCargo,
                                New SelectList(Model.ListaEmpleadoCargo, "IdEmpleadoCargo", "DescripcionCargo"),
                                "-SELECCIONE-",
                                New With {
                                    .id = "ID_IdEmpleadoCargo",
                                    .disabled = "disabled",
                                    .style = "cursor:default;"
                                })
                            </div>
                        </div>
                        <div class="grid6">
                            <div class="grid3">
                                <label class="form-label" for="tipoPersona">
                                    Tiempo de Servicio: <small class="alert_validation"></small>
                                </label>
                            </div>
                            <div class="grid9">
                                @Html.DropDownListFor(Function(m) m.ComisionEscala.TiempoServicio,
                                New SelectList(Model.ListaTiempoServicio, "TiempoServicio", "TiempoServicio"),
                                "-SELECCIONE-",
                                New With {
                                    .id = "ID_TiempoServicio",
                                    .disabled = "disabled",
                                    .style = "cursor:default;"
                                })
                            </div>
                        </div>
                        <div class="clear">
                        </div>
                    </div>
                    <div class="formRow fluid">
                        <div class="grid6">
                            <div class="grid3">
                                <label class="form-label" for="tipoPersona">
                                    Plan Venta (S/.)<span class="req">*</span></label>
                            </div>
                            <div class="grid3">
                                @Html.TextBoxFor(Function(m) m.ComisionEscala.PlanVenta,
                                New With {
                                    .id = "ID_PlanVenta",
                                    .class = "textinput",
                                    .onkeypress = "return val_09D(event)",
                                    .onclick = "selectTextInput(event)",
                                    .maxlength = "12",
                                    .Value = IIf(Model.ComisionEscala.PlanVenta <> 0, Model.ComisionEscala.PlanVenta, "")
                                })
                                <div id="ID_MsgPlanVenta">
                                </div>
                                <script type="text/javascript">
                                    $('#ID_PlanVenta').focus();
                                </script>
                            </div>
                        </div>
                        <div class="grid6">
                            <div class="grid4">
                                <label class="form-label" for="tipoPersona">
                                    Ingreso Básico Mensual (S/.)<span class="req">*</span>
                                </label>
                            </div>
                            <div class="grid8">
                                <div class="grid3">
                                    @Html.TextBoxFor(Function(m) m.ComisionEscala.IngresoBasicoMensual,
                                    New With {
                                        .id = "ID_IngresoBasicoMensual",
                                        .class = "textinput ",
                                        .onkeypress = "return val_09D(event)",
                                        .onclick = "selectTextInput(event)",
                                        .onpaste = "return false;",
                                        .maxlength = "12",
                                        .Value = IIf(Model.ComisionEscala.IngresoBasicoMensual <> 0, Model.ComisionEscala.IngresoBasicoMensual, "")
                                    })
                                </div>
                                <div class="clear">
                                </div>
                                <div id="ID_MsgIngresoBasicoMensual">
                                </div>
                            </div>
                        </div>
                        <div class="clear">
                        </div>
                        <input id="ID_CancelarEscalaComision" style="cursor: pointer;" type="button" class="buttonS bDefault formSubmit group_button"
                            onclick="CancelarRegistroEscala()" value="Cancelar" />
                        @If Model.ComisionEscala.FechaActualizacion = "01/01/0001"
                            @<input id="ID_GuardarPeriodoComision" style="cursor: pointer;" type="button" class="buttonS bBlue formSubmit group_button" 
                            onclick="GuardarRegistroEscala('ID_ComisionEscalaDetalle','@Url.Action("GuardarEscalaComision", "Comision")')" value="Guardar"/>
                        Else
                            @<input id="ID_AceptarEscalaComision" style="cursor: pointer;" type="button" class="buttonS bBlue formSubmit group_button"
                            onclick="AceptarEscalaComision()" value="Aceptar" />
                        End If 
                    </div>
                    <div class="formRow">
                        <div class="grid12">
                        </div>
                    </div>
                </div>
                @<div class="formRow fluid" style="padding: 0px;">
                    <div id="contenedorgrilla-ListadoEscalaComisionDetalle">
                        @Html.Partial("_ListaComisionEscalaDetalle", Model)
                    </div>
                </div>
                @Html.HiddenFor(Function(x) x.ComisionEscala.IdComisionEscala, New With {.id = "ID_IdComisionEscala"})
                @Html.HiddenFor(Function(x) x.ComisionEscala.ComisionPeriodo.IdPeriodo, New With {.id = "ID_IdPeriodo"})
            End Using
        </fieldset>
    </div>
</div>
@Html.Hidden("ID_UrlGestionarPeriodoComision", Url.Action("GestionarPeriodoComision"), "Comision")
@Html.Hidden("ID_UrlValidarGuardarEscalaComision", Url.Action("ValidarGuardarEscalaComision"), "Comision")
<div id="dialogGuardarRegistroEscala" title="Mensaje de confirmación">
    <p>
        ¿Desea actualizar el registro?</p>
</div>
<div id="dialogCancelarRegistroEscala" title="Mensaje de confirmación">
    <p>
        ¿Desea cancelar el registro?</p>
</div>
<div id="dialogInformacionResultado" title="Mensaje de información">
    <p>
        Se registró correctamente...</p>
</div>
<div id="dialogGenerarRegistroEscalas" title="Mensaje de confirmación">
    <p>
        ¿Desea Generar nuevamente las escalas de comisión?</p>
</div>


<script type="text/javascript" language="javascript">
    $(window).load(function () {
        InicioJPopUpConfirm("#dialogGenerarRegistroEscalas", 490, false, "Mensaje de Confirmación", GenerarPlanVenta);
    });
</script>

@*<script type="text/javascript" language="javascript">
    $(function () {
        var vID_FechaActualizacion = $('#ID_FechaActualizacion').val();
        if (vID_FechaActualizacion.substr(0, 10) != "01/01/0001") {
            $("#ID_PlanVenta").prop('disabled', true);
            $("#ID_IngresoBasicoMensual").prop('disabled', true);
            $("#ID_TableEscalaDetalles tbody tr td div input").prop('disabled', "disabled");
        }
    });
</script>*@