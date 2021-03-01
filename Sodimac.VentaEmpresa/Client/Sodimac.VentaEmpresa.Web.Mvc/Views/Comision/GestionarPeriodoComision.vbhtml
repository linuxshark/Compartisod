@ModelType Sodimac.VentaEmpresa.Web.Mvc.ComisionViewModel
@Imports Sodimac.VentaEmpresa.Common
@Code
    If Model.ComisionPeriodo.IdPeriodo = 0 Then
        ViewData("Title") = "Nuevo Periodo Comisión"
    Else
        ViewData("Title") = "Detalle Periodo Comisión"
    End If
End Code
<script src="../../Scripts/View/Comision.js" type="text/javascript"></script>
<div class="breadLine">
    <div class="bc">
        <ul id="breadcrumbs" class="breadcrumbs">
            <li><a href="#">Inicio</a> </li>
            <li class=""><a href="#">Planificación</a></li>
            @If Model.ComisionPeriodo.IdPeriodo = 0 Then
                @<li class="current"><a title="" href="#">Nuevo Periodo Comisión</a> </li>
            Else
                @<li class="current"><a title="" href="#">Detalle Periodo Comisión</a> </li>
            End If
        </ul>
    </div>
</div>
<div class="contentTop">
    @If Model.ComisionPeriodo.IdPeriodo = 0 Then
        @<span class="pageTitle"><span id="IdAgregarTitle" class="icon-screen"></span>Nuevo
        Periodo Comisión</span>
    Else
        @<span class="pageTitle"><span id="IdAgregarTitle" class="icon-screen"></span>Detalle
        Periodo Comisión</span>
    End If
    <div class="clear">
    </div>
</div>
<div class="wrapper">
    <div class="main">
        <fieldset>
            @Using (Html.BeginForm(Nothing, Nothing, FormMethod.Post, New With {.id = "ID_PeriodoComision", .onsubmit = "return false;"}))
                @Html.AntiForgeryToken
                @Html.HiddenFor(Function(m) m.PlanVenta.ComisionEscala.IdPeriodo, New With {.id = "IdPeriodoGlobal"})
                @Html.HiddenFor(Function(m) m.ModificaEscala, New With {.id = "HDModificaEscala"})               
                @<div class="form">
                    <div class="widget fluid">
                        <div class="whead">
                            <h6>
                                Datos Generales
                            </h6>
                            <div class="clear">
                            </div>
                        </div>
                        <div class="formRow">
                            <div class="grid6">
                                <div class="grid3">
                                    <label class="form-label">
                                        Nombre del Periodo:<span class="req">*</span></label>
                                </div>
                                <div class="grid8">
                                    @Html.TextBoxFor(Function(m) m.ComisionPeriodo.NombrePeriodo,
                                    New With {
                                        .autocomplete = "off",
                                        .id = "ID_NombrePeriodo",
                                        .style = "text-transform:uppercase;",
                                        .onkeypress = "SubmitButton(event)",
                                        .maxlength = "50"
                                    })
                                    <div id="ID_MsgNombrePeriodo">
                                    </div>
                                    <script type="text/javascript">
                                        $('#ID_NombrePeriodo').focus();
                                    </script>
                                </div>
                            </div>
                            <div class="grid6">
                                <div class="grid3">
                                    <label class="form-label">
                                        Plantilla de Periodo:</label>
                                </div>                    
                                <div class="grid6">
                                    @Html.Partial("_ComboListaPlantilla", Model)
                                </div>
                            </div>
                            <div class="clear">
                            </div>
                        </div>
                        <div class="formRow">
                            <div class="grid6">
                                <div class="grid3">
                                    <label class="form-label">
                                        Fecha Inicio:<span class="req">*</span></label>
                                </div>
                                <div class="grid9">
                                @If Model.ComisionPeriodo.FechaInicio = Nothing Then
                                 @Html.TextBoxFor(Function(m) (m.ComisionPeriodo.FechaInicio),
                                    New With {
                                        .id = "ID_FechaInicio",
                                        .autocomplete = "off",
                                        .onkeypress = "SubmitButton(event)",
                                        .class = "datepicker maskDate",
                                        .maxlength = "10",
                                        .Value = String.Format("{0:d}", "")
                                    })
                                Else
                                @Html.TextBoxFor(Function(m) (m.ComisionPeriodo.FechaInicio),
                                    New With {
                                        .id = "ID_FechaInicio",
                                        .autocomplete = "off",
                                        .onkeypress = "SubmitButton(event)",
                                        .class = "datepicker maskDate",
                                        .maxlength = "10",
                                        .Value = String.Format("{0:d}",Model.ComisionPeriodo.FechaInicio)
                                    })                                
                                End If
                                   
                                    <div id="ID_MsgFechaInicio">
                                    </div>
                                </div>
                            </div>
                            <div class="grid6">
                                <div class="grid3">
                                    <label class="form-label">
                                        Fecha Fin:<span class="req">*</span></label>
                                </div>
                                <div class="grid9">
                                @If Model.ComisionPeriodo.FechaFin = Nothing Then
                                @Html.TextBoxFor(Function(m) (m.ComisionPeriodo.FechaFin),
                                    New With {
                                        .id = "ID_FechaFin",
                                        .autocomplete = "off",
                                        .onkeypress = "SubmitButton(event)",
                                        .class = "datepicker maskDate",
                                        .maxlength = "10",
                                        .Value = String.Format("{0:d}", "")
                                    })
                                Else
                                @Html.TextBoxFor(Function(m) (m.ComisionPeriodo.FechaFin),
                                    New With {
                                        .id = "ID_FechaFin",
                                        .autocomplete = "off",
                                        .onkeypress = "SubmitButton(event)",
                                        .class = "datepicker maskDate",
                                        .maxlength = "10",
                                        .Value = String.Format("{0:d}", Model.ComisionPeriodo.FechaFin)
                                    })
                                End If
                                    
                                    <div id="ID_MsgFechaFin">
                                    </div>
                                </div>
                            </div>
                            <div class="clear">
                            </div>
                        </div>            

                        <div class="formRow">
                            <div class="grid12">
                                <input id="ID_TerminarGestionarPeriodo" style="cursor: pointer;display:none" type="button" class="buttonS bBlue formSubmit group_button"
                                    onclick="TerminarGestionarPeriodo()" value="Terminar" />
                                <input id="ID_CancelarPeriodoComision" style="cursor: pointer;display:none" type="button" class="buttonS bDefault formSubmit group_button"
                                    onclick="CancelarRegistro()" value="Cancelar" />
                                @If (Not Model.ComisionPeriodo.IdPeriodo <> 0) Then
                                    @<input id="ID_GuardarPeriodoComision" style="cursor: pointer;" type="button" class="buttonS bBlue formSubmit group_button" onclick="GuardarRegistro('ID_PeriodoComision','@Url.Action("GuardarPeriodoComision", "Comision")')" value="Guardar"/>
                                Else
                                If Model.ComisionPeriodo.Estado.IdEstado = Constantes.ID_ESTADO_PERIODOCOMISION_REGISTRADO Then
                                        @<input id="ID_TerminarGestionarPeriodo" style="cursor: pointer;display:block" type="button" class="buttonS bBlue formSubmit group_button" onclick="TerminarGestionarPeriodo()" value="Terminar" />
                                        @<input id="ID_ApruebaPeriodoComision" style="cursor: pointer;" type="button" class="buttonS bBlue formSubmit group_button" onclick="ApruebaRegistro('@Url.Action("AprobarPeriodoComision", "Comision")')" value="Aprobar"/>
                                    Else
                                        @<input id="ID_AceptaPeriodoComision" style="cursor: pointer;" type="button" class="buttonS bBlue formSubmit group_button" onclick="window.location='@Url.Action("BuscarPeriodoComision", "Comision")'" value="Aceptar"/>
                                    End If
                                End If
                            </div>
                            <div class="clear"></div>
                        </div>
                    </div>
                    @Html.HiddenFor(Function(m) m.ComisionPeriodo.Estado.IdEstado, New With {.id = "IdEstadoComision"})
                    @Html.HiddenFor(Function(m) m.ComisionPeriodo.IdPeriodo, New With {.id = "IdPeriodo"})
                    @Html.HiddenFor(Function(m) m.ModificaEscala, New With {.id = "ID_ModificaEscala"})
                    @Html.Hidden("ID_UrlGestionarEscalaComision", Url.Action("GestionarEscalaComision"), "Comision")
                    @Html.Hidden("ID_UrlBuscarPeriodoComision", Url.Action("BuscarPeriodoComision"), "Comision")
                    @Html.Hidden("ID_UrlGestionarPeriodoComisionBonosRRVV", Url.Action("_GestionarPeriodoComisionBonosRRVV"), "Comision")
                    @Html.Hidden("ID_UrlGestionarPeriodoComisionBonosJefatura", Url.Action("_GestionarPeriodoComisionBonosJefatura"), "Comision")
                    @Html.Hidden("ID_UrlValidarGuardarPeriodoComision", Url.Action("ValidarGuardarPeriodoComision"), "Comision")                   
                </div>
            End Using
                <div id="tabs-partial" style="display:none">
                    @Html.Partial("_GestionarPeriodoComision", Model)
                </div>
            
        </fieldset>
    </div>
</div>
<div id="dialogGuardarRegistro" title="Mensaje de confirmación">
    <p>
        ¿Desea guardar el registro?</p>
</div>
<div id="dialogAprobarRegistro" title="Mensaje de confirmación">
    <p>
        Se procederá a aprobar el periodo de comisión, para ello se procesará el cierre
        del periodo actual ¿Desea continuar?</p>
</div>
<div id="dialogCancelarRegistro" title="Mensaje de confirmación">
    <p>
        ¿Desea cancelar el registro?</p>
</div>
<div id="dialogInformacionResultado" title="Mensaje de información">
    <p>
        Se registró correctamente...</p>
</div>

<div id="dialogGenerarJefe" title="Mensaje de información">
<center>
    <p> Nota: Se perderán los datos de Bonificación Jefatura</p>
    <p> ¿Desea Continuar?</p></center>
</div>
<div id="dialogGenerarRRVV" title="Mensaje de información">
  <center>
    <p> Nota: Se perderán los datos de Bonificación RRVV</p>
    <p> ¿Desea Continuar?</p></center>
</div>

<script type="text/javascript" language="javascript">
    $(function () {
        if ($('#IdPeriodoGlobal').val() == "" || $('#IdPeriodoGlobal').val() == 0){
            $('#ID_CancelarPeriodoComision').show();
        }
        
        InicioJPopUpConfirm("#dialogGenerarJefe", 490, false, "Mensaje de Confirmación", GenerarEscalasJefe);
        InicioJPopUpConfirm("#dialogGenerarRRVV", 490, false, "Mensaje de Confirmación", GenerarEscalasRRVV);
    });

</script>

