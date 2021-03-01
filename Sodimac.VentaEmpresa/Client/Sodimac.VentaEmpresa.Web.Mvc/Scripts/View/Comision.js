var vIdForm = "";
var vParamUrl = "";
var vValida = false;
var vBonoMontoEspecial = true;
var vPlanVentaSumatoria = true;
var vIdPeriodoDetalle = 0;

function BuscarPeriodo() {

    var vUrl = $("#ID_Url").val();
    var vIdPeriodo = $("#ID_Periodo").val();

    $.ajax({
        url: vUrl,
        data: { IdPeriodo: vIdPeriodo },
        type: "post",
        cache: false,
        success: function (data) {
            $("#contendorgrilla-ListadoNombrePeriodo").html(data)
        },
        error: function (er) {
        }
    })
}

function TerminarGestionarPeriodo() {
    window.location = "BuscarPeriodoComision"
}

function GuardarPeriodoComision(IdForm, ParamUrl) {

    var form = $('#' + IdForm);
    var data = form.serialize();
    var vIdPeriodo = 0;
    $.ajax({
        url: ParamUrl,
        data: data,
        type: "POST",
        cache: false,
        async: false,
        success: function (data, textStatus, jqXHR) {
            var msgResult = data.split('/');
            vIdPeriodo = parseInt(msgResult[2])
            $("#dialogInformacionResultado").empty();
            $("#dialogInformacionResultado").append("<p>" + msgResult[1] + "</p>");
            $("#dialogInformacionResultado").dialog("open");
            if (msgResult[0] == "1") {
                //parent.$("#btnPopAceptar").bind("click", function () {
                ListarTabsJejes(msgResult[2]);
                $("#ID_NombrePeriodo").attr("disabled", "disabled")  ///Deshabilita Cabecera
                $("#ID_FechaInicio").attr("disabled", "disabled") ///Deshabilita Cabecera
                $("#ID_FechaFin").attr("disabled", "disabled")  ///Deshabilita Cabecera
                $("#ID_CancelarPeriodoComision").css("display", "none");
                $("#ID_GuardarPeriodoComision").css("display", "none");
                $("#ID_TerminarGestionarPeriodo").css("display", "block");
                //});
            }
        },
        error: function (jqXHR, status, error) {
        }
    });
    $('#IdPeriodoGlobal').val(vIdPeriodo);
}
function ListarTabsJejes(IdPeriodo) {  // se le pasa el IdPeriodo para setear al hidden de IDPeriodo

    var ParamURL = CreateUrl("_GestionarPeriodoComision", "Comision")
    var HD_Modifica = $("#HDModificaEscala").val()
    $.ajax({
        url: ParamURL,
        data: { IdPeriodo: IdPeriodo, Modifica: HD_Modifica },
        type: "POST",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#tabs-partial").show();
            $("#tabs-partial").html(data);
        },
        error: function (jqXHR, status, error) {
        }
    });
}


$(function () {
    var HD_Modifica = $("#HDModificaEscala").val()
    var HD_IdPeriodoGlobal = $("#IdPeriodoGlobal").val()
    if (HD_Modifica == "True" && parseInt(HD_IdPeriodoGlobal) > 0) {
        ListarTabsJejes(HD_IdPeriodoGlobal)
    }

    $("#btncancelar2").bind("click", CerrarPopuPrincipal);

    var meses = new Array
    ("ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SETIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE");

    var f = new Date();
    InicioJPopUp("#AdjuntarArchivo", 800, 600, false, "Agregar documentación Sustento - PERIODO DE VENTAS " + meses[f.getMonth()] + " " + f.getFullYear());



    InicioJPopUpCancelar("#dialogMensaje", 400, false, "Mensaje de Confirmación", CerrarPopup);
    InicioJPopUpCancelar("#dialogMensaje2", 400, false, "Mensaje de Infomación", CerrarPopup2);

    $.ajaxSetup({ type: "POST" });
    var ParamUrl = $('#Listar_EmpleadoJEFEJVV').val();
    var Nombre = $('#ID_NombresApellidos').val();

    $('#ID_NombresApellidos').autocomplete(ParamUrl, {
        dataType: 'json',
        parse: function (data) {
            $('#iID_NombresApellidos').val('');
            $('#IdEmpleadoJefe').val('');
            var rows = new Array();

            for (var i = 0; i < data.length; i++) {
                rows[i] = {
                    data: data[i],
                    value: data[i].NombresApellidos,
                    result: data[i].NombresApellidos,
                    id: data[i].NombresApellidos
                };
            }
            return rows;
        },
        formatItem: function (row) {
            return row.NombresApellidos;
        },
        delay: 200,
        autofill: true,
        selectFirst: false,
        highlight: false,
        minChars: 3

    }).result(function (event, row) {
        $('#IdEmpleadoJefe').val(row.IdEmpleado);
        $('#iID_NombresApellidos').val(row.NombresApellidos);
    });

})

var CerrarPopup = function () { $('#dialogMensaje').hide() }
var CerrarPopup2 = function () { $('#dialogMensaje2').hide() }

function CerrarPopuPrincipal() {
    $('#AdjuntarArchivo').dialog("close");
    window.location.href = "/Comision/BuscarMesesComisionales?IdPeriodo=0";
}

var r = { 'special': /[\W]/g }
function valid(o, w) {
    o.value = o.value.replace(r[w], '');
}

function ValidaRegistroPlanVentaJefe(IdCargo) {
    var valida = true;
    var validaControl = true;

    if ($("#IDFactorAplica_" + IdCargo).is(":checked")) {

        var vPorcentajeFactor = $("#IDPlanVentaFactor_" + IdCargo).val()
        if (vPorcentajeFactor != "" && vPorcentajeFactor != 0) {
            //replaceErrorMessagge("ID_MsgPlanVentaFactor_" + IdCargo, "");

        }
        else {
            //replaceErrorMessagge("ID_MsgPlanVentaFactor_" + IdCargo, "Ingrese porcentaje");
            valida = false;
        }


        if (ValidarFecha("IDFechaInicio_" + IdCargo) == 0) {
            //replaceErrorMessagge("IDMsgFechaInicio_"+IdCargo, "");

        }
        else {
            //replaceErrorMessagge("IDMsgFechaInicio_" + IdCargo, "Ingrese una fecha de inicio correcta");
            valida = false;
        }

        if (ValidarFecha("IDFechaFin_" + IdCargo) == 0) {
            //replaceErrorMessagge("IDMsgFechaFin_" + IdCargo, "");

        }
        else {
            //replaceErrorMessagge("IDMsgFechaFin_" + IdCargo, "Ingrese una fecha de fin correcta");
            valida = false;
        }

        if (ValidarFecha("IDFechaInicio_" + IdCargo) == 0 && ValidarFecha("IDFechaFin_" + IdCargo) == 0) {
            var vFechaInicio = $("#IDFechaInicio_" + IdCargo).val();
            var vFechaFin = $("#IDFechaFin_" + IdCargo).val();
            if (Comparar_Fechas(vFechaInicio, vFechaFin)) {
                //                    replaceErrorMessagge("IDMsgFechaInicio_" + IdCargo, "La Fecha Inicio no debe ser mayor a la Fecha Fin");
                //                    replaceErrorMessagge("IDMsgFechaFin_" + IdCargo, "");
                valida = false;
            }
        }
    }  //Fin si esta checkeado 2da linea


    ////////////////////////////////////////////console.log($("#BooleanBoniJefe_" + IdCargo+ ":checked").val())
    if ($("#BooleanBoniRRVV_" + IdCargo + ":checked").val()) {

        //            replaceErrorMessagge("IDMsgPorcentaje_" + IdCargo, "");
        //            replaceErrorMessagge("IDMsgBonoMontoJefe_" + IdCargo, "");


        var vPorcentajeRRVV = $("#IDPorcentajeRRVV_" + IdCargo).val()
        if (vPorcentajeRRVV != "" && vPorcentajeRRVV != 0) {
            //                replaceErrorMessagge("IDMsgPorcentajeRRVV_" + IdCargo, "");           
        }
        else {
            //                replaceErrorMessagge("IDMsgPorcentajeRRVV_" + IdCargo, "Ingrese porcentaje");
            valida = false;
        } //Fin porcentaje RRVV

        var vBonoMontoRRVV = $("#IDBonoMontoRRVV_" + IdCargo).val()
        if (vBonoMontoRRVV != "" && vBonoMontoRRVV != 0) {
            //                replaceErrorMessagge("IDMsgBonoMontoRRVV_" + IdCargo, "");
        }
        else {
            //                replaceErrorMessagge("IDMsgBonoMontoRRVV_" + IdCargo, "Ingrese bonificación.");
            valida = false;
        } //Fin montoBonif. RRVV    
    }
    else { // Cuando es la Boni JEFE

        //            replaceErrorMessagge("IDMsgPorcentajeRRVV_" + IdCargo, "");
        //            replaceErrorMessagge("IDMsgBonoMontoRRVV_" + IdCargo, "");

        var vPorcentajeJefe = $("#IDPorcentaje_" + IdCargo).val()
        if (vPorcentajeJefe != "" && vPorcentajeJefe != 0) {
            //                replaceErrorMessagge("IDMsgPorcentaje_" + IdCargo, "");
        }
        else {
            //                replaceErrorMessagge("IDMsgPorcentaje_" + IdCargo, "Ingrese porcentaje");
            valida = false;
        } //Fin porcentaje JEFE

        var vBonoMontoJEFE = $("#IDBonoMontoJefe_" + IdCargo).val()
        if (vBonoMontoJEFE != "" && vBonoMontoJEFE != 0) {
            //                replaceErrorMessagge("IDMsgBonoMontoJefe_" + IdCargo, "");
        }
        else {
            //                replaceErrorMessagge("IDMsgBonoMontoJefe_" + IdCargo, "Ingrese bonificación.");
            valida = false;
        } //Fin montoBonif. JEFE     

    }

    //    
    var vCantidadBono = $("#IDCantidadEscalasJefe_" + IdCargo).val();
    if (vCantidadBono != "") {
        if (vCantidadBono != 0) {
            //                replaceErrorMessagge("IDMsgCantidadEscalas_"+IdCargo, "");
        }
        else {
            //                replaceErrorMessagge("IDMsgCantidadEscalas_" + IdCargo, "Ingrese la cantidad de escalas");
            valida = false;
        }
    }
    else {
        //            replaceErrorMessagge("IDMsgCantidadEscalas_" + IdCargo, "Ingrese la cantidad de escalas");
        valida = false;
    } // Fin Cantidad Escalas JEFE



    //        if (valida == false) {
    //            InicioJPopUpAlert("<p>¡ Por favor ingrese los campos que son obligatorios !</p>", null);
    //        }

    validaControl = valida
    if (validaControl == true) {
        if (vCantidadBono > 0) {
            var vUrl = CreateUrl("ValidaEscalaComisionJefe", "Comision")
            var form = $("#frmPlanVenta_" + IdCargo);
            var data = form.serialize();

            $.ajax({
                url: vUrl,
                data: data,
                type: "POST",
                cache: false,
                async: false,
                success: function (data, textStatus, jqXHR) {
                    var msgResult = data.split('/');
                    if (msgResult[0] != "-1") {
                        //InicioJPopUpAlert(msgResult[1], null);
                        valida = false;
                    }
                },
                error: function (jqXHR, status, error) {
                }
            });
        }
    }

    return valida;
}

function ValidaRegistroPlanVentaRRVV(IdCargo) {
    var valida = true;
    var validaControl = true;

    var vCantidadBono = $("#IDCantidadEscalasRRVV_" + IdCargo).val();
    if (vCantidadBono != "" && vCantidadBono != 0) {
        //                replaceErrorMessagge("IDMsgCantidadBono_" + IdCargo, "");       
    }
    else {
        //            replaceErrorMessagge("IDMsgCantidadBono_" + IdCargo, "Ingrese la cantidad de escalas");
        valida = false;
    } // Fin Cantidad Escalas RRVV


    var vPlanVentaBase = $("#IDPlanVentaBase_" + IdCargo).val();
    if (vPlanVentaBase != "" && vPlanVentaBase != 0) {
        //                replaceErrorMessagge("ID_MsgPlanVentaBaseRRVV_" + IdCargo, "");        
    }
    else {
        //            replaceErrorMessagge("ID_MsgPlanVentaBaseRRVV_" + IdCargo, "Ingrese el plan de ventas");
        valida = false;
    } // Fin PlanVentaBaseRRVV

    var vTiempoServicio = $("#IDTiempoServicio_" + IdCargo).val();
    if (vTiempoServicio != "" && vTiempoServicio != 0) {
        //            replaceErrorMessagge("IDMsgTiempoServicio_" + IdCargo, "");       
    }
    else {
        //            replaceErrorMessagge("IDMsgTiempoServicio_" + IdCargo, "Ingrese el tiempo servicio");
        valida = false;
    } // Fin TiempoServicio

    //        if (valida == false) {
    //            InicioJPopUpAlert("<p>¡ Por favor ingrese los campos que son obligatorios !</p>", null);
    //        }

    validaControl = valida
    if (validaControl == true) {
        if (vCantidadBono > 0) {
            var vUrl = CreateUrl("ValidaEscalaComisionRRVV", "Comision")
            var form = $("#frmPlanVenta_" + IdCargo);
            var data = form.serialize();

            $.ajax({
                url: vUrl,
                data: data,
                type: "POST",
                cache: false,
                async: false,
                success: function (data, textStatus, jqXHR) {
                    var msgResult = data.split('/');
                    if (msgResult[0] != "-1") {
                        //InicioJPopUpAlert(msgResult[1], null);
                        valida = false;
                    }
                },
                error: function (jqXHR, status, error) {
                }
            });
        }
    }

    return valida;
}


function ValidaRegistroPeriodoComision_Nuevo() {

    var valida = true;
    var vNombrePeriodo = $("#ID_NombrePeriodo").val();
    if (vNombrePeriodo != "") {
        replaceErrorMessagge("ID_MsgNombrePeriodo", "");
    }
    else {
        replaceErrorMessagge("ID_MsgNombrePeriodo", "Ingrese un nombre para el periodo");
        valida = false;
    }

    if (ValidarFecha("ID_FechaInicio") == 0) {
        replaceErrorMessagge("ID_MsgFechaInicio", "");
    }
    else {
        replaceErrorMessagge("ID_MsgFechaInicio", "Ingrese una fecha de inicio correcta");
        valida = false;
    }

    if (ValidarFecha("ID_FechaFin") == 0) {
        replaceErrorMessagge("ID_MsgFechaFin", "");
    }
    else {
        replaceErrorMessagge("ID_MsgFechaFin", "Ingrese una fecha de fin correcta");
        valida = false;
    }

    if (ValidarFecha("ID_FechaInicio") == 0 && ValidarFecha("ID_FechaFin") == 0) {
        var vFechaInicio = $("#ID_FechaInicio").val();
        var vFechaFin = $("#ID_FechaFin").val();
        if (Comparar_Fechas(vFechaInicio, vFechaFin)) {
            replaceErrorMessagge("ID_MsgFechaInicio", "La Fecha Inicio no debe ser mayor a la Fecha Fin");
            replaceErrorMessagge("ID_MsgFechaFin", "");
            valida = false;
        }
    }

    var FecIni = $.datepicker.parseDate('dd/mm/yy', $("#ID_FechaInicio").val().toString().substring(0, 10));
    var FecFin = $.datepicker.parseDate('dd/mm/yy', $("#ID_FechaFin").val().toString().substring(0, 10));

    if ((FecFin.getMonth() == FecIni.getMonth()) && (FecIni.getYear() == FecFin.getYear()) && valida) {
        replaceErrorMessagge("ID_MsgFechaInicio", "Mes Inicio igual a mes final");
        replaceErrorMessagge("ID_MsgFechaFin", "Mes Inicio igual a mes final");
        valida = false;
    }
    return valida;
}


function GuardarRegistro(IdForm, ParamUrl) {

    vIdForm = IdForm;
    vParamUrl = ParamUrl;
    if (ValidaRegistroPeriodoComision_Nuevo()) {
        $('#dialogGuardarRegistro').dialog("open");
    }
}

$(function () {

    $('#dialogGuardarRegistro').dialog({
        autoOpen: false,
        width: 400,
        modal: true,
        resizable: false,
        closeOnEscape: true,
        buttons: {
            "Sí": function () {
                GuardarPeriodoComision(vIdForm, vParamUrl);
                $('#dialogGuardarRegistro').dialog("close");
            },
            "No": function () {
                $('#dialogGuardarRegistro').dialog("close");
            }
        }
    });
});

function ApruebaRegistro(ParamUrl) {
    var valido = true;

    $("#ListaZonas li a img").each(function (i, element) {
        if (element.attributes[2].nodeValue == "/Content/images/botones/dot-red.png") {
            $("#dialogInformacionResultado").empty();
            $("#dialogInformacionResultado").append("<p>Debe completar los planes de venta por cada zona</p>");
            $("#dialogInformacionResultado").dialog("open");
            valido = false;
        }
    });
    if (valido) {
        vParamUrl = ParamUrl;
        $('#dialogAprobarRegistro').dialog("open");
    }
}

$(function () {
    $('#dialogAprobarRegistro').dialog({
        autoOpen: false,
        width: 400,
        modal: true,
        resizable: false,
        closeOnEscape: true,
        buttons: {
            "Sí": function () {
                AprobarPeriodoComision(vParamUrl);
                $('#dialogAprobarRegistro').dialog("close");
            },
            "No": function () {
                $('#dialogAprobarRegistro').dialog("close");
            }
        }
    });
});

function AprobarPeriodoComision(ParamUrl) {
    var vIdPeriodo = $('#IdPeriodo').val();

    $.ajax({
        url: ParamUrl,
        data: { IdPeriodo: vIdPeriodo },
        type: "POST",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            var msgResult = data.split('/');
            $("#dialogInformacionResultado").empty();
            $("#dialogInformacionResultado").append("<p>" + msgResult[1] + "</p>");
            $("#dialogInformacionResultado").dialog("open");
            if (msgResult[0] == "1") {
                parent.$("#btnPopAceptar").bind("click", function () { window.location = $("#ID_UrlBuscarPeriodoComision").val(); });
                setTimeout('parent.$("#btnPopAceptar").click();', 3500);
            }
        },
        error: function (jqXHR, status, error) {
        }
    });
}

function CancelarRegistro() {
    $('#dialogCancelarRegistro').dialog("open");
}

$(function () {
    $('#dialogCancelarRegistro').dialog({
        autoOpen: false,
        width: 400,
        modal: true,
        resizable: false,
        closeOnEscape: true,
        buttons: {
            "Sí": function () {
                window.location = $("#ID_UrlBuscarPeriodoComision").val();
            },
            "No": function () {
                $('#dialogCancelarRegistro').dialog("close");
            }
        }
    });
});

$(function () {
    $('#dialogInformacionResultado').dialog({
        autoOpen: false,
        resizable: false,
        closeOnEscape: true,
        timeout: 1000,
        open: function (event, ui) { $(".ui-dialog-titlebar-close", this.parentNode).hide(); },
        width: 400,
        buttons: [{
            id: "btnPopAceptar",
            text: "Aceptar",
            click: function () {
                $(this).dialog("close");
            }
        }]
    });
});

function MuestraValorPorcInicial(TiempoServicio, Fila, id) {

    var Id_ = id + TiempoServicio + "_" + Fila;
    var valor = $('#' + Id_).val();
    if (Fila == 0) {
        $("#PorcInicial_" + TiempoServicio).html(valor);
        $("#PorcInicial__" + TiempoServicio).val(parseInt(valor));
    }
    return true;
}

function MuestraValorPorcFinal(TiempoServicio, Fila, id, TotalFilas) {

    var Id_ = id + TiempoServicio + "_" + Fila;
    var valor = $('#' + Id_).val();
    if (Fila == TotalFilas) {
        $("#PorcFinal_" + TiempoServicio).html(parseInt(valor));
        $("#PorcFinal__" + TiempoServicio).val(parseInt(valor));
    }
    return true;
}
function MuestraValorBono(TiempoServicio, Fila, id, TotalFilas) {

    var Id_ = id + TiempoServicio + "_" + Fila;
    var valor = $('#' + Id_).val();
    if (Fila == 0) {
        $("#BonoMin_" + TiempoServicio).html(valor);
        $("#BonoMin__" + TiempoServicio).val(valor);
    }
    if (Fila == TotalFilas) {
        $("#BonoMax_" + TiempoServicio).html(valor);
        $("#BonoMax__" + TiempoServicio).val(valor);
    }
    return true;
}

function CalculaNumeroBonos(IdCantidadBonos, Cargo, IdCargoSuperior) {

    if (Cargo == "JEFE") {
        var vNumeroBonos = $('#' + IdCantidadBonos).val();
        if (vNumeroBonos != "") {
            if (vNumeroBonos == 0) {
                $("#BonificacionJefatura_" + IdCargoSuperior).empty();
                return false;
            }
            var vUrlBonosJefatura = $("#ID_UrlGestionarPeriodoComisionBonosJefatura").val();

            $.ajax({
                url: vUrlBonosJefatura,
                data: { NumeroBonos: vNumeroBonos },
                type: "POST",
                cache: false,
                success: function (data, textStatus, jqXHR) {
                    $("#BonificacionJefatura_" + IdCargoSuperior).empty();
                    $("#BonificacionJefatura_" + IdCargoSuperior).html(data);
                },
                error: function (jqXHR, status, error) {
                }
            });

            return true;
        }
        else {
            $("#BonificacionJefatura_" + IdCargoSuperior).empty();
            return false;
        }

    }
    else { //Aqui entra cuando se escribe en la caja de texto de cant de bonos para Vendedores

        var vNumeroBonos = $('#' + IdCantidadBonos).val();
        if (vNumeroBonos != "") {
            if (vNumeroBonos == 0) {
                $("#BonificacionRRVV_" + IdCargoSuperior).empty();
                return false;
            }
            var vUrlBonosRRVV = $("#ID_UrlGestionarPeriodoComisionBonosRRVV").val();
            $.ajax({
                url: vUrlBonosRRVV,
                data: { NumeroBonos: vNumeroBonos },
                type: "POST",
                cache: false,
                success: function (data, textStatus, jqXHR) {
                    $("#BonificacionRRVV_" + IdCargoSuperior).empty();
                    $("#BonificacionRRVV_" + IdCargoSuperior).html(data);
                },
                error: function (jqXHR, status, error) {
                }
            });

            return true;
        }
        else {
            $("#BonificacionRRVV_" + IdCargoSuperior).empty();
            return false;
        }
    }
}

function SubmitButton(event) {
    if (event.keyCode == 13) {
        document.getElementById('ID_GuardarPeriodoComision').click();
        return true;
    }
    else {
        return false;
    }
}

$(function () {

    $("#btnBuscar").bind("click", BuscarPeriodoComisional);
    //    $("#btnBuscar").live("click", function (e) {

    //        var vFechaIni = $("#ID_FechaInicio").val();
    //        var vFechaFin = $("#ID_FechaFin").val();

    //        var vIdPeriodo = $("#Hdn_IdPeriodo").val(); // ID_Periodo
    //        var IdNombreMesComisional = $("#Id_NombreMesComisional").val();
    //        var IdEstado = $("#Id_Estado").val();

    //        var url = ""
    //        url = $("#ID_Url").val();
    //        
    //        var page = 1;
    //        var sort = "";
    //        var sortdir = ""; 
    //        var queue = ""; 
    //        var newurl = ""
    //        newurl = url + "?page=" + page + "&IdNombreMesComisional=" + IdNombreMesComisional +
    //        "&IdEstado=" + IdEstado + "&FechaIni=" + vFechaIni + "&FechaFin=" + vFechaFin + "&IdPeriodo=" + vIdPeriodo

    //        $("#dgvDatos").append('<a href="" id="hide-link" style="display:none" >hide</a>')
    //        $("#hide-link").attr("data-swhglnk", true)
    //        $("#hide-link").attr("href", newurl).click();
    //        $(this).attr('href', newurl);

    //        e.preventDefault();
    //    });

});



/////////////////////////////////////////////////////////////////////////////////////////////////////////////////

function BuscarPeriodoComisional() {

    var vUrl = $("#ID_Url").val();
    var vFechaIni = $("#ID_FechaInicio").val();
    var vFechaFin = $("#ID_FechaFin").val();
    var vIdPeriodo = $("#Hdn_IdPeriodo").val(); // ID_Periodo
    var IdNombreMesComisional = $("#Id_NombreMesComisional").val();
    var IdEstado = $("#Id_Estado").val();
    $.ajax({
        url: vUrl,
        type: "POST",
        cache: false,
        data: {
            IdNombreMesComisional: IdNombreMesComisional,
            IdEstado: IdEstado,
            FechaIni: vFechaIni,
            FechaFin: vFechaFin,
            IdPeriodo: vIdPeriodo
        },
        success: function (data) {
            $("#contendorgrilla-ListadoMesComisional").html(data)
        },
        error: function (er) {
        }
    })
}


function SetTotalRegistrosComisional() {

    $("#contendorgrilla-ListadoMesComisional tfoot tr a, #contendorgrilla-ListadoMesComisional thead tr a").on("click", function (e) {

        var vFechaIni = encodeURI($.trim($("#ID_FechaInicio").val()));
        var vFechaFin = encodeURI($.trim($("#ID_FechaFin").val()));
        var vIdPeriodo = encodeURI($.trim($("#Hdn_IdPeriodo").val())); // ID_Periodo
        var IdNombreMesComisional = encodeURI($.trim($("#Id_NombreMesComisional").val()));
        var IdEstado = encodeURI($.trim($("#Id_Estado").val()));

        //pagination parameters
        var page = 1;
        var queue = "";

        //logic for url action
        var url = $(this).attr('href');

        var arr = new Array()
        arr = url.split("?")
        queue = arr[0].toString() + "?";
        arr = arr[1].toString().split("&")

        for (var i = 0; i <= arr.length - 1; i++) {
            if (arr[i].indexOf("page") >= 0)
                page = arr[i].toString().split("=")[1].toString();
        }

        //adding filter and pagination parameters
        var newurl = "";
        newurl = queue +

            "&IdNombreMesComisional=" + IdNombreMesComisional +
            "&IdEstado=" + IdEstado +
            "&FechaIni=" + vFechaIni +
            "&FechaFin=" + vFechaFin +
            "&IdPeriodo=" + vIdPeriodo +
            "&page=" + page;
        $(this).attr('href', newurl);

    });

    PintarHeaderGrillaComisional();
}

function PintarHeaderGrillaComisional() {

    $("#dgvDatos .detail").attr("href", "#");
    $("#dgvDatos tfoot tr:last td").prepend("<a id='tfootPage2'  class='total_registros'></a>");
    var Reg = $('#hdfTotalRegistros').val();

    $("#tfootPage2").html(Reg);
}


function SetTotalRegistros() {


    $("#dgvDatos tfoot tr a, #dgvDatos thead tr a").on("click", function (e) {

        var vFechaIni = encodeURI($.trim($("#ID_FechaInicio").val()));
        var vFechaFin = encodeURI($.trim($("#ID_FechaFin").val()));
        var vIdPeriodo = encodeURI($.trim($("#Hdn_IdPeriodo").val())); // ID_Periodo
        var IdNombreMesComisional = encodeURI($.trim($("#Id_NombreMesComisional").val()));
        var IdEstado = encodeURI($.trim($("#Id_Estado").val()));

        //pagination parameters
        var sortdir = "";
        var sort = "";
        var page = 1;
        var queue = "";

        //logic for url action
        var url = $(this).attr('href');

        var arr = new Array()
        arr = url.split("?")
        queue = arr[0].toString() + "?";
        arr = arr[1].toString().split("&")

        for (var i = 0; i <= arr.length - 1; i++) {
            if (arr[i].indexOf("page") >= 0)
                page = arr[i].toString().split("=")[1].toString();
        }

        //adding filter and pagination parameters
        var newurl = "";
        newurl = queue +
            "&page=" + page +
            "&IdNombreMesComisional=" + IdNombreMesComisional +
            "&IdEstado=" + IdEstado +
            "&FechaIni=" + vFechaIni +
            "&FechaFin=" + vFechaFin +
            "&IdPeriodo=" + vIdPeriodo;
        $(this).attr('href', newurl);
    });

    PintarHeader();
}

function PintarHeader() {

    $("#dgvDatos .detail").attr("href", "#");
    $("#dgvDatos tfoot tr:last td").prepend("<a id='tfootPage2'  class='total_registros'></a>");
    var Reg = $('#hdfTotalRegistros').val();

    $("#tfootPage2").html(Reg);
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////


function GuardarRegistroEscala(IdForm, ParamUrl) {
    vIdForm = IdForm;
    vParamUrl = ParamUrl;
    if (ValidaRegistroEscalaComision()) {
        $('#dialogGuardarRegistroEscala').dialog("open");
    }
}

$(function () {
    $('#dialogGuardarRegistroEscala').dialog({
        autoOpen: false,
        width: 400,
        modal: true,
        buttons: {
            "Sí": function () {
                GuardarEscalaComision(vIdForm, vParamUrl);
                $('#dialogGuardarRegistroEscala').dialog("close");
            },
            "No": function () {
                $('#dialogGuardarRegistroEscala').dialog("close");
            }
        }
    });
});

function GuardarEscalaComision(IdForm, ParamUrl) {
    var form = $('#' + IdForm);
    var data = form.serialize();

    $.ajax({
        url: ParamUrl,
        data: data,
        type: "POST",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            var msgResult = data.split('/');
            $("#dialogInformacionResultado").empty();
            $("#dialogInformacionResultado").append("<p>" + msgResult[1] + "</p>");
            $("#dialogInformacionResultado").dialog("open");
            if (msgResult[0] == "1") {
                var vUrl = $('#ID_UrlGestionarPeriodoComision').val();
                var vIdPeriodo = $('#ID_IdPeriodo').val();
                var vModificaEscala = true;
                vUrl = vUrl + "?IdPeriodo=" + vIdPeriodo + "&ModificaEscala=" + vModificaEscala;
                parent.$("#btnPopAceptar").bind("click", function () { window.location = vUrl; });
                setTimeout('parent.$("#btnPopAceptar").click();', 3500);
            }
        },
        error: function (jqXHR, status, error) {
        }
    });
}

function CancelarRegistroEscala() {
    $('#dialogCancelarRegistroEscala').dialog("open");
}

$(function () {

    InicioJPopUpConfirm("#dialogConfirmarEliminar", 400, false, "Mensaje de Confirmación", Eliminar_PeriodoComision2);
    InicioJPopUpConfirm("#dialogConfirmarCerrarMes", 400, false, "Mensaje de Confirmación", CerrarMes);
    InicioJPopUpCancelar("#dialogMensaje", 400, false, "Mensaje de Confirmación", CerrarPopup);
    $('#dialogCancelarRegistroEscala').dialog({
        autoOpen: false,
        width: 400,
        modal: true,
        resizable: false,
        buttons: {
            "Sí": function () {
                var vUrl = $('#ID_UrlGestionarPeriodoComision').val();
                var vIdPeriodo = $('#ID_IdPeriodo').val();
                var vModificaEscala = true;
                vUrl = vUrl + "?IdPeriodo=" + vIdPeriodo + "&ModificaEscala=" + vModificaEscala;
                window.location = vUrl;
            },
            "No": function () {
                $('#dialogCancelarRegistroEscala').dialog("close");
            }
        }
    });
});


function ValidaFecha() {
    var valida = true;
    if (ValidarFecha("ID_FechaInicio") == 0) {
        replaceErrorMessagge("ID_MsgFechaInicio", "");
    }
    else {
        replaceErrorMessagge("ID_MsgFechaInicio", "Ingrese una fecha de inicio correcta");
        valida = false;
    }
    if (ValidarFecha("ID_FechaFin") == 0) {
        replaceErrorMessagge("ID_MsgFechaFin", "");
    }
    else {
        replaceErrorMessagge("ID_MsgFechaFin", "Ingrese una fecha de fin correcta");
        valida = false;
    }
    if (ValidarFecha("ID_FechaInicio") == 0 && ValidarFecha("ID_FechaFin") == 0) {
        var vFechaInicio = $("#ID_FechaInicio").val();
        var vFechaFin = $("#ID_FechaFin").val();
        if (Comparar_Fechas(vFechaInicio, vFechaFin)) {
            replaceErrorMessagge("ID_MsgFechaInicio", "La Fecha Inicio no debe ser mayor a la Fecha Fin");
            replaceErrorMessagge("ID_MsgFechaFin", "");
            valida = false;
        }
    }
    return valida;
}


function AceptarEscalaComision() {
    var vUrl = $('#ID_UrlGestionarPeriodoComision').val();
    var vIdPeriodo = $('#ID_IdPeriodo').val();
    var vModificaEscala = true;
    vUrl = vUrl + "?IdPeriodo=" + vIdPeriodo + "&ModificaEscala=" + vModificaEscala;
    window.location = vUrl;
}

function ValidaRegistroEscalaComision() {
    var valida = true;

    var vPlanVenta = $("#ID_PlanVenta").val();
    if (vPlanVenta != "") {
        if (vPlanVenta != 0) {
            replaceErrorMessagge("ID_MsgPlanVenta", "");
        }
        else {
            replaceErrorMessagge("ID_MsgPlanVenta", "Ingrese el plan de venta");
            valida = false;
        }
    }
    else {
        replaceErrorMessagge("ID_MsgPlanVenta", "Ingrese el plan de venta");
        valida = false;
    }

    var vIngresoBasicoMensual = $("#ID_IngresoBasicoMensual").val();
    if (vIngresoBasicoMensual != "") {
        if (vIngresoBasicoMensual != 0) {
            replaceErrorMessagge("ID_MsgIngresoBasicoMensual", "");
        }
        else {
            replaceErrorMessagge("ID_MsgIngresoBasicoMensual", "Ingrese el ingreso básico mensual");
            valida = false;
        }
    }
    else {
        replaceErrorMessagge("ID_MsgIngresoBasicoMensual", "Ingrese el ingreso básico mensual");
        valida = false;
    }

    if (valida == false) {
        $("#dialogInformacionResultado").empty();
        $("#dialogInformacionResultado").append("<p>¡ Por favor ingrese los campos que son obligatorios !</p>");
        $("#dialogInformacionResultado").dialog("open");
    }
    else {
        var vUrl = $('#ID_UrlValidarGuardarEscalaComision').val();
        var form = $('#ID_ComisionEscalaDetalle');
        var data = form.serialize();

        $.ajax({
            url: vUrl,
            data: data,
            type: "POST",
            cache: false,
            async: false,
            success: function (data, textStatus, jqXHR) {
                var msgResult = data.split('/');
                if (msgResult[0] != "-1") {
                    $("#dialogInformacionResultado").empty();
                    $("#dialogInformacionResultado").append("<p>" + msgResult[1] + "</p>");
                    $("#dialogInformacionResultado").dialog("open");
                    valida = false;
                }
                else {
                    valida = true;
                }
            },
            error: function (jqXHR, status, error) {
            }
        });
    }

    return valida;
}

function replaceErrorMessagge(IdDiv, Message) {
    $("#" + IdDiv).replaceWith('<div style="color: #EC6464; font-size:9px;" id="' + IdDiv + '">' + Message + '</div>');
}


function EnterSubmit(e, buttonClick) {
    tecla = (document.all) ? e.keyCode : e.which;
    if (tecla == 13) {
        var obj = document.getElementById(buttonClick);
        obj.click();
    }
}

//function ValidarPlanVenta(IdCargo) {
//    

//    if (parseInt(Fechatoyyyymmdd($('#IDFechaInicio_' + IdCargo).val().toString().substring(0, 10))) > parseInt(Fechatoyyyymmdd($('#IDFechaFin_' + IdCargo).val().toString().substring(0, 10)))) {
//        $("#dialogInformacionResultado").empty();
//        $("#dialogInformacionResultado").append("<p>Fecha Inicio mayor a fecha final</p>");
//        $("#dialogInformacionResultado").dialog("open");
//        return false;
//    } else if (FICom > FIPlan || FFCom < FFPlan) {
//        $("#dialogInformacionResultado").empty();
//        $("#dialogInformacionResultado").append("<p>Fecha inicio, fin deben estar en rango de Fechas de comisión</p>");
//        $("#dialogInformacionResultado").dialog("open");
//        return false;
//    }
//}

function GuardarPlanVentaJefe(frm, IdCargo) {
    var SiCheck = $("#IDFactorAplica_" + IdCargo).is(":checked");

    if (SiCheck) {
        var FICom = $('#ID_FechaInicio').val().toString().substring(0, 10);
        var FFCom = $('#ID_FechaFin').val().toString().substring(0, 10);
        var FIPlan = $('#IDFechaInicio_' + IdCargo).val().toString().substring(0, 10);
        var FFPlan = $('#IDFechaFin_' + IdCargo).val().toString().substring(0, 10);

        if (ValidarFecha('IDFechaInicio_' + IdCargo) != 0) {
            $("#dialogInformacionResultado").empty();
            $("#dialogInformacionResultado").append("<p>Fecha inicio incorrecta</p>");
            $("#dialogInformacionResultado").dialog("open");
            return false;
        } else if (ValidarFecha('IDFechaFin_' + IdCargo) != 0) {
            $("#dialogInformacionResultado").empty();
            $("#dialogInformacionResultado").append("<p>Fecha fin incorrecta</p>");
            $("#dialogInformacionResultado").dialog("open");
            return false;
        }
        else if (Comparar_Fechas(FIPlan, FFPlan)) {
            $("#dialogInformacionResultado").empty();
            $("#dialogInformacionResultado").append("<p>Fecha Inicio mayor a fecha final</p>");
            $("#dialogInformacionResultado").dialog("open");
            return false;
        } else if (Comparar_Fechas(FICom, FIPlan) || Comparar_Fechas(FFPlan, FFCom)) {
            $("#dialogInformacionResultado").empty();
            $("#dialogInformacionResultado").append("<p>Fecha inicio, fin deben estar en rango de Fechas de comisión</p>");
            $("#dialogInformacionResultado").dialog("open");
            return false;
        }
    }

    if (ValidaRegistroPlanVentaJefe(IdCargo)) {
        $("#HDCompletoJefe_" + IdCargo).val("True")
        $("#Completo_Jefes_" + IdCargo).val("True")
    }
    else {
        $("#HDCompletoJefe_" + IdCargo).val("False")
        $("#Completo_Jefes_" + IdCargo).val("False")
    }

    if (ValidaRegistroPlanVentaRRVV(IdCargo)) {
        $("#HDCompletoRRVV_" + IdCargo).val("True")
        $("#Completo_RRVV_" + IdCargo).val("True");
    }
    else {
        $("#HDCompletoRRVV_" + IdCargo).val("False")
        $("#Completo_RRVV_" + IdCargo).val("False");
    }

    var ParamURL = CreateUrl("GuardarPlanVentaCargoJefe", "Comision")
    $.ajax({
        url: ParamURL,
        data: frm.serialize(),
        type: "POST",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            var msgResult = data.split('/');
            if (msgResult[1] == "1") {
                InicioJPopUpAlert(msgResult[0], null);
                //                $("#Completo_Jefes_" + IdCargo).val(msgResult[2]);
                updateStateZone(IdCargo);
            }
            else {
                InicioJPopUpAlert("Sucedió un error, vuelva a intentarlo por favor.", null);
            }
        },
        error: function (jqXHR, status, error) {
        }
    });
}

function GuardarPlanVentaRRVV(frm, IdCargo) {

    if (ValidaRegistroPlanVentaJefe(IdCargo)) {
        $("#HDCompletoJefe_" + IdCargo).val("True")
        $("#Completo_Jefes_" + IdCargo).val("True")
    }
    else {
        $("#HDCompletoJefe_" + IdCargo).val("False")
        $("#Completo_Jefes_" + IdCargo).val("False")
    }

    if (ValidaRegistroPlanVentaRRVV(IdCargo)) {
        $("#HDCompletoRRVV_" + IdCargo).val("True")
        $("#Completo_RRVV_" + IdCargo).val("True");
    }
    else {
        $("#HDCompletoRRVV_" + IdCargo).val("False")
        $("#Completo_RRVV_" + IdCargo).val("False");
    }
    var ParamURL = CreateUrl("GuardarPlanVentaCargoRRVV", "Comision")
    $.ajax({
        url: ParamURL,
        data: frm.serialize(),
        type: "POST",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            var msgResult = data.split('/');
            if (msgResult[1] == "1") {
                $("#frmPlanVenta_" + IdCargo).attr("disabled");
                $("#IDCantidadEscalasJefe_" + IdCargo).attr("disabled");
                //$("#Completo_RRVV_" + IdCargo).val(msgResult[2]);
                updateStateZone(IdCargo)
            }
            InicioJPopUpAlert(msgResult[0], null);

        },
        error: function (jqXHR, status, error) {
        }
    });

}


function updateStateZone(IdCargo) {
    Completo = $("#Completo_Jefes_" + IdCargo).val();
    CompletoRRVV = $("#Completo_RRVV_" + IdCargo).val();

    if (Completo == "True" && CompletoRRVV == "True") {
        $('#imgzone_' + IdCargo).attr("src", "/Content/images/botones/dot-green.png");
    }
    else {
        $('#imgzone_' + IdCargo).attr("src", "/Content/images/botones/dot-red.png");
    }
}


function chgBonificacionJefe(idBoni, NombreCargo, IdCargo) {

    if (NombreCargo == "RRVV") {
        $("#IDPorcentajeRRVV_" + IdCargo).removeAttr("disabled")
        $("#IDBonoMontoRRVV_" + IdCargo).removeAttr("disabled")
        $("#IDPorcentaje_" + IdCargo).attr("disabled", "disabled")
        $("#IDBonoMontoJefe_" + IdCargo).attr("disabled", "disabled")

        $("#IDPorcentaje_" + IdCargo).val("")
        $("#IDBonoMontoJefe_" + IdCargo).val("")

        $("#HDBoniJefe_" + IdCargo).val(false)
        $("#HDBoniRRVV_" + IdCargo).val(true)


    }
    else {  //Caso cuadno se hace click en Radio bhutton del JEFE
        $("#IDPorcentajeRRVV_" + IdCargo).attr("disabled", "disabled")
        $("#IDBonoMontoRRVV_" + IdCargo).attr("disabled", "disabled")
        $("#IDPorcentajeRRVV_" + IdCargo).val("")
        $("#IDBonoMontoRRVV_" + IdCargo).val("")

        $("#IDPorcentaje_" + IdCargo).removeAttr("disabled")
        $("#IDBonoMontoJefe_" + IdCargo).removeAttr("disabled")

        $("#HDBoniJefe_" + IdCargo).val(true)
        $("#HDBoniRRVV_" + IdCargo).val(false)

    }

}
var vvIdCargoSuperior;
function GenerarPlanVenta(IdCargoSuperior) {
    var vNumeroBonos = $('#IDCantidadEscalasJefe_' + IdCargoSuperior).val();
    var vIdPeriodo = $('#IdPeriodoGlobal').val()
    var HD_Modifica = $("#HD_FirstTimeJefe_" + IdCargoSuperior).val()
    if (vNumeroBonos != "") {
        if (vNumeroBonos == 0) {
            $("#BonificacionJefatura_" + IdCargoSuperior).empty();
            return false;
        }
        vvIdCargoSuperior = IdCargoSuperior
        if (HD_Modifica == "True") {
            $("#HD_FirstTimeJefe_" + IdCargoSuperior).val("False")
            GenerarEscalasJefe();
        }
        else {
            $('#dialogGenerarJefe').dialog('open');
        }
        return true;
    }
    else {
        $("#BonificacionJefatura_" + IdCargoSuperior).empty();
        return false;
    }
}

function GenerarEscalasJefe() {
    var vUrlBonosJefatura = $("#ID_UrlGestionarPeriodoComisionBonosJefatura").val();
    var vNumeroBonos = $('#IDCantidadEscalasJefe_' + vvIdCargoSuperior).val();
    var vIdPeriodo = $('#IdPeriodoGlobal').val()
    $.ajax({
        url: vUrlBonosJefatura,
        data: {
            NumeroBonos: vNumeroBonos,
            IdPeriodo: vIdPeriodo,
            IdCargoSuperior: vvIdCargoSuperior
        },
        type: "POST",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#BonificacionJefatura_" + vvIdCargoSuperior).empty();
            $("#BonificacionJefatura_" + vvIdCargoSuperior).html(data);
        },
        error: function (jqXHR, status, error) {
        }
    });

}
var vvvIdCargoJefe;
var vvvIdCargoRRVV;
function GenerarPlanVentaRRVV(IdCargoJefe, IdCargoRRVV) {

    vvvIdCargoJefe = IdCargoJefe
    vvvIdCargoRRVV = IdCargoRRVV
    var vCantidadEscalas = $("#IDCantidadEscalasRRVV_" + IdCargoJefe).val()
    var vCantidadTiempo = $("#IDTiempoServicio_" + IdCargoJefe).val()
    var vIdPeriodo = $("#IdPeriodoGlobal").val()
    var vModifica = $("#HD_ModificaPlanRRVV").val()
    var vNombrePeriodo = $("#ID_NombrePeriodo").val()
    var HD_Modifica = $("#HD_FirstTimeRRVV_" + IdCargoJefe).val()
    if (vCantidadEscalas > 0 && vCantidadTiempo > 0) {
        if (HD_Modifica == "True") {
            $("#HD_FirstTimeRRVV_" + IdCargoJefe).val("False")
            GenerarEscalasRRVV()
        }
        else {
            $('#dialogGenerarRRVV').dialog('open');
        }

    }
}

function GenerarEscalasRRVV() {

    var vCantidadEscalas = $("#IDCantidadEscalasRRVV_" + vvvIdCargoJefe).val()
    var vCantidadTiempo = $("#IDTiempoServicio_" + vvvIdCargoJefe).val()
    var vIdPeriodo = $("#IdPeriodoGlobal").val()
    var vModifica = $("#HD_ModificaPlanRRVV").val()
    var vNombrePeriodo = $("#ID_NombrePeriodo").val()
    var vParamURL = CreateUrl("_GestionarPlanVentasRRVV", "Comision")
    $.ajax({
        url: vParamURL,
        data: {
            CantidadTiempo: vCantidadTiempo,
            CantidadEscalas: vCantidadEscalas,
            IdPeriodo: vIdPeriodo,
            IdCargoRRVV: vvvIdCargoRRVV,
            Modifica: vModifica,
            NombrePeriodo: vNombrePeriodo
        },
        type: "POST",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#HD_ModificaPlanRRVV").val(false)
            $("#BonificacionRRVV_" + vvvIdCargoJefe).empty();
            $("#BonificacionRRVV_" + vvvIdCargoJefe).html(data);
            Toogle();

        },
        error: function (jqXHR, status, error) {
        }
    });

}

function Toogle() {
    $('.opened').collapsible({
        defaultOpen: 'opened,toggleOpened',
        cssOpen: 'inactive',
        cssClose: 'normal',
        speed: 200
    });

    $('.closed').collapsible({
        defaultOpen: '',
        cssOpen: 'inactive',
        cssClose: 'normal',
        speed: 200
    });

}

function CambiarTabZona(IdCargoSuperior, IdCargo, IdPerfil, IdPerfilSuperior, NombreCargo, NombreCargoSuperior) {
    var HD_Modifica = $("#HDModificaEscala").val()
    var HD_IdPeriodo = $("#Hidden_IDPeriodo").val()

    var vParamURL = CreateUrl("_GestionarPeriodoComisionPlanVenta", "Comision")
    $.ajax({
        url: vParamURL,
        data: {
            IdPeriodo: HD_IdPeriodo,
            IdCargoSuperior: IdCargoSuperior,
            IdCargo: IdCargo,
            Modifica: HD_Modifica,
            IdPerfil: IdPerfil,
            IdPerfilSuperior: IdPerfilSuperior,
            NombreCargo: NombreCargo,
            NombreCargoSuperior: NombreCargoSuperior
        },
        type: "POST",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#TabContenedor").empty();
            $("#TabContenedor").html(data);

            var Opcion = $("#IdEstadoComision").val();

            if (Opcion == 14 || Opcion == 18) {
                $('#TabContenedor').find('input').each(function (index, elem) {
                    $(elem).attr("disabled", true).addClass("ui-state-disabled");
                });
            }
        },
        error: function (jqXHR, status, error) {
        }
    });

}


//////////////////////////////////////  CAMBIAR ESTADO DE COMISION  /////////////////////////////////////////////////////////////
var vIdPeriodo;
//var vIdCliente;
function EliminarPeriodoComision(IdPeriodo) {
    vIdPeriodo = IdPeriodo
    InicioJPopUpConfirmOpen('#dialogEliminarPeriodoComision');

}

function DesactivarPeriodoComision() {
    var IdPeriodo = vIdPeriodo
    // var IdCartera = vIdCartera
    var ParamUrl = CreateUrl('ActualizarEstadoPeriodoComision', 'Comision');

    $.ajax({
        url: ParamUrl,
        type: "POST",
        data: {
            IdPeriodo: IdPeriodo
        },
        cache: false,
        success: function (data) {
            Listar_PeriodoComision();
            $('#dialogEliminarPeriodoComision').dialog("close");
            InicioJPopUpAlert(data, BuscarPeriodo);
        }
    });
}

function Listar_PeriodoComision() {
    var url = $("#Url_Listar_Periodo").val();

    $.ajax({
        url: url,
        data: {},
        cache: false,
        success: function (data) {
            $("#DivPeriodo").html(data);
        }
    });
}

function AjuntarArchivo(id, IdEstado,PeriodoVentaDescripcion) {

    $('#iID_NombresApellidos').val('');
    $('#ID_NombresApellidos').val('');
    $('#textarea').val('');
    $("#IdFileUpload").val('');
    $('#iIdDescripcion').val('');
    $('#IdTxtAprobadoPor').val('');
    $('#iPeriodoComision').val(id);

    var vID_NombresApellidos = $("#ID_NombresApellidos").val()
    var vIdDescripcion = $("#iIdDescripcion").val()
    var vIdFileUpload = $("#IdFileUpload").val()
    var vTxtAprobadoPor = $("#IdTxtAprobadoPor").val()

    LimpiarMessageError(vID_NombresApellidos, "#valid-NombresApellidos");
    LimpiarMessageError(vIdDescripcion, "#valid-Descripcion");
    LimpiarMessageError(vIdFileUpload, "#valid-Archivo");
    LimpiarMessageError(vTxtAprobadoPor, "#valid-Aprobado");

    ListarArchivoComisional(id, IdEstado, PeriodoVentaDescripcion);

}

var LimpiarMessageError = function (element, divMessage) {
    $(divMessage).hide();
}

function ListarArchivoComisional(id, IdEstado, PeriodoVentaDescripcion) {
    var url = $("#Url_ListarAdjuntoComisional").val();

    $.ajax({
        url: url,
        data: { IdPeriodo: id },
        type: "get",
        cache: false,
        success: function (data) {

            if (IdEstado == 32) {
                $("#iIdBtnGuardarAdjunto").hide();
            }

            $("#Id_Listado_Mes_Condicional").html(data);
            InicioJPopUpOpenV2('#AdjuntarArchivo', "Agregar documentación Sustento - " + PeriodoVentaDescripcion);
            
//            InicioJPopUp("#AdjuntarArchivo", 800, 600, false, "Agregar documentación Sustento - PERIODO DE VENTAS " + meses[f.getMonth()] + " " + f.getFullYear());


        },
        error: function (req, status, error) {
            //console.log(error.error);
        },
        complete: function (req, status, error) {

            SetTotalRegistrosMesComisional();
        }
    });
}


function SetTotalRegistrosMesComisional() {

    $("#dgvDatosComisional tfoot tr a, #dgvDatos thead tr a").on("click", function (e) {

        var idPeriodo = encodeURI($.trim($("#iPeriodoComision").val()));

        var page = 1;
        var queue = "";

        var url = $(this).attr('href');

        var arr = new Array()
        arr = url.split("?")
        queue = arr[0].toString() + "?";
        arr = arr[1].toString().split("&")


        for (var i = 0; i <= arr.length - 1; i++) {
            if (arr[i].indexOf("page") >= 0)
                page = arr[i].toString().split("=")[1].toString();
        }

        var newurl = "";
        newurl = queue +

            "&IdPeriodo=" + idPeriodo +
            "&page=" + page;
        $(this).attr('href', newurl);

    });

    PintarHeaderGrillaConsultaEquipo();
}


function PintarHeaderGrillaConsultaEquipo() {

    var RowCount = $("#RowCount").val();
    var RowsPerPage = $('#RowsPerPage').val();

    $("#dgvDatosComisional .detail").attr("href", "#");
    $("#dgvDatosComisional tfoot tr:last td").prepend("<a id='tfootPage2'  class='total_registros'></a>");

    var Reg = $('#TotalRegistrosComision').val();

    $("#tfootPage2").html(Reg);

    if (RowCount <= 0) {
        $('#dgvDatosComisional').css('display', 'none');

    } else {
        $('#dgvDatosComisional').css('display', '');

    }
}


function Eliminar_PeriodoComision(idAdjunto, IdPeriodo) {
    $('#Hdn_IdAdjunto').val('');
    $('#Hdn_IdPeriodo').val('');
    $('#Hdn_IdAdjunto').val(idAdjunto);
    $('#Hdn_IdPeriodo').val(IdPeriodo);
    InicioJPopUpOpen("#dialogConfirmarEliminar");
}

function Eliminar_PeriodoComision2() {
    var idAdjunto = $('#Hdn_IdAdjunto').val();
    var IdPeriodo = $('#Hdn_IdPeriodo').val();
    var url = $("#Url_EliminarComisionAdjunto").val();

    $.ajax({
        url: url,
        data: { IdAdjunto: idAdjunto, IdPeriodo: IdPeriodo },
        cache: false,
        success: function (data) {
            if (data == 1) {

                InicioJPopUpOpen("#dialogMensaje");

                AjuntarArchivo(IdPeriodo);

            } else {

                InicioJPopUpOpen("#dialogMensaje2");
                InicioJPopUpOpen('#AdjuntarArchivo');
            }
        }
    });
}


function Descargar_Adjunto(vIdAj) {

    var ParamUrl = $("#Url_Descargar_Adjunto").val();

    $.ajax({
        url: ParamUrl,
        data: {
            IdAj: vIdAj
        },
        type: "get",
        cache: false,
        success: function (data) {
            var result = data.split("/");

            if (result[0] == 1 || result[0] == "1") {

                DescargaArchivo(vIdAj);

            }
            else {
                alert("Se produjo un error al descargar el archivo");
            }

        },
        error: function (jqXHR, status, error) {
        },
        complete: function () {

        }
    });

}


var DescargaArchivo = function (vIdAj) {

    var parametro = vIdAj;
    var ParamUrl = $("#Url_Descargar_Adjunto2").val();

    window.location = ParamUrl + "?IdAj=" + parametro;
}


function MensajeCerrarMes(IdPeriodoDetalle) {
    $("#Hdn_IdPeriodoDetalle").val(IdPeriodoDetalle);
    $('#dialogConfirmarCerrarMes').dialog("open");

}

function CerrarMes(IdPeriodoDetalle) {

    var ParamUrl = $("#Url_Cerrar_Mes_Comisional").val();
    var IdPeriodoDetalle = $("#Hdn_IdPeriodoDetalle").val();
    $.ajax({
        url: ParamUrl,
        data: {
            IdPeriodoDetalle: IdPeriodoDetalle
        },
        type: "set",
        cache: false,
        success: function (data) {
            var msgResult = data.toString();
            InicioJPopUpAlert(msgResult, null);
            BuscarPeriodoComisional();

        },
        error: function (jqXHR, status, error) {
        },
        complete: function () {

        }
    });


}
