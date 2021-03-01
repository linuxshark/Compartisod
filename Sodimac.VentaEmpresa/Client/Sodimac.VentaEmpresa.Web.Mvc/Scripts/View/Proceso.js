function MostrarDialogVerErrores() {
    $("#ModelVerErrores").css("display", "block");
    $('#ModelVerErrores').dialog({ autoOpen: false, width: 700, height: 350, resizable: false });
    $('#ModelVerErrores').dialog('option', 'modal', true).dialog('open');
    return true;
}

function PV_Errores() {
    $.ajax({
        url: "PV_Errores",
        data: {
        },
        type: "post",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#ModelVerErrores").empty();
            $('#ModelVerErrores').html(data);
            MostrarDialogVerErrores();
        },
        error: function (req, status, error) {
        }
    });
}

function ImportarArchivos() {
    $.ajax({
        url: "ImportarArchivos",
        data: {
        },
        type: "post",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            if (data == 1 || data == -1) {
                $('#dialogInformacionImportacion p').text("Se subieron con éxito los registros");
            }
            else if (data == 2) {
                $('#dialogInformacionImportacion p').text("Los registros ya han sido cargados previamente. Si desea volver a cargarlos deberá desactivar la carga");
            }
            else if (data == 3) {
                $('#dialogInformacionImportacion p').text("Ocurrió un error al migrar los datos, inténtelo nuevamente");
            }
            $('#dialogInformacionImportacion').dialog("open");
        },
        error: function (req, status, error) {
            alert(status.toString() + error.toString());
        }
    });
}

$(function () {
    $('#dialogInformacionImportacion').dialog({
        autoOpen: false,
        resizable: false,
        closeOnEscape: false,
        //        open: function (event, ui) { $(".ui-dialog-titlebar-close", this.parentNode).hide(); },
        width: 400,
        buttons: [{
            id: "btnPopAceptar",
            text: "Aceptar",
            click: function () {
                $(this).dialog("close");
                window.location = "Index";
            }
        }]
    });
});

$("#Actualizacion").dialog({
    autoOpen: false,
    width: 400,
    modal: true,
    resizable: false,
    hide: 'fade',
    show: 'fade',
    title: "Mensaje",
    buttons: {
        "Sí": function () {
            UpdVentasCotizacion();
            $('#Actualizacion').dialog("close");

        },
        "No": function () {
            $('#Actualizacion').dialog("close");
            return false;
        }
    }
});

function UpdVentasCotizacion() {
    $.ajax({
        url: "UpdVentasCotizacion",
        data: {
        },
        type: "post",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            if (data == 1 || data == -1) {
                $('#dialogInformacionResultado p').text("Se actualizó con exito");
                $('#dialogInformacionResultado').dialog("open");
            }
        },
        error: function (req, status, error) {
        }
    });
}

$(function () {
    $('#dialogInformacionResultado').dialog({
        autoOpen: false,
        resizable: false,
        closeOnEscape: false,
        open: function (event, ui) { $(".ui-dialog-titlebar-close", this.parentNode).hide(); },
        width: 400,
        buttons: [{
            id: "btnPopAceptar",
            text: "Aceptar",
            click: function () {
                $(this).dialog("close");
                window.location = "Index";
            }
        }]
    });
});

function BuscarHistorial(vUrl) {
    $.ajax({
        url: vUrl,
        data: {

        },
        type: "get",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $('#GrillaHistorial').html(data);
        },
        error: function (req, status, error) {
        },
        complete: function () {
            LoadGrid();
        }
    });
}

function LoadGrid() {
    PintarHeaderGrilla();
}

function PintarHeaderGrilla() {
    var RowCount = $("#hdfTotalRegistros").val();
    var RowsPerPage = $('#RowsPerPage').val();

    $("#dgvDatosHistorial tfoot tr:last td").prepend("<a id='tfootPage'  class='total_registros'></a>");
    $("#tfootPage").html($('#FooterDesc').val());

    if (RowCount <= 0) {
        $('#dgvDatosHistorial').css('display', 'none');
    } else {
        $('#dgvDatosHistorial').css('display', '');
    }
}

$(function () {
    LoadGrid();
});

function EliminarCarga(UrlSrv, IdSrv) {
    GUrlUsu = UrlSrv;
    GIdUsu = IdSrv;
    GUrlDestino = $("#IdUrl_ServicioDestino").val();
    $("#mensajeDesactivar").html("")
    $("#mensajeDesactivar").html("<b>¿Desea desactivar el registro?</b>")
    $('#dialogInformacionDesactivar').dialog('open');

    return false;
}

var vIDCargah;
var vIdEstadoh;
function EliminarCargaManual(IDCarga, Id_Estado) {
    vIDCarga = IDCarga;
    vIDCargah = vIDCarga;
    vIdEstado = Id_Estado;
    InicioJPopUpConfirmOpen('#dialogDesactivarCargar');
}

function CancelarHistorialCarga() {
    var ParamUrl = CreateUrl('ActualizarEstadoCarga', 'Proceso');
    var IDCarga = vIDCarga;
    var Id_Estado = vIdEstado;
    $.ajax({
        url: ParamUrl,
        data: {
            IDCarga: IDCarga,
            IdEstado: Id_Estado
        },
        type: "POST",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            if (data == 1) {
                $('#dialogDesactivarCargar').dialog("close");
                $("#dialogActualizaComision p").text("Se ha modificado datos en las Ventas, ¿Desea reprocesar ahora?");
                $("#dialogActualizaComision").dialog("open");
            }
            else {
                InicioJPopUpConfirmOpen('#dialogDesactivarCargar');
            }
        }
    });
}


function QuitarCargaManual(IDCarga, Id_Estado) {
    vIDCargah = IDCarga;
    vIdEstadoh = Id_Estado;
    InicioJPopUpConfirmOpen('#dialogQuitarCargaManual');
}

function QuitarHistorialCarga() {
    var IDCargah = vIDCargah
    var IdEstadoh = vIdEstadoh
    var ParamUrl = CreateUrl('QuitarEstadohistorialCarga', 'Proceso');
    $.ajax({
        url: ParamUrl,
        type: "POST",
        data: {
            IDCarga: IDCargah,
            IdEstadoA: IdEstadoh
        },
        cache: false,
        success: function (data) {
            if (data == 1) {
                InicioJPopUpAlert("Se Desactivó el estado de la carga.", null);
                var ParamUrl = CreateUrl('PV_Historial', 'Proceso');
                BuscarHistorial(ParamUrl);
                $('#dialogQuitarCargaManual').dialog("close");
            }
            else {
                InicioJPopUpAlert("Hubo un error, inténtelo mas tarde", null);
            }
        }
    });
}

function RedireccionarVista() {
    window.location.href = "/Proceso/Index";
}

function RedireccionarVistaReproceso() {
    window.location.href = "/Proceso/ReprocesoVentas";
}

$("#dialogActualizaComision").dialog({
    autoOpen: false,
    width: 400,
    modal: true,
    resizable: false,
    hide: 'fade',
    show: 'fade',
    title: "Mensaje",
    buttons: {
        "Sí": function () {
            ActualizarComisiones();
            var ParamUrl = CreateUrl('PV_Historial', 'Proceso');
            BuscarHistorial(ParamUrl);
            $('#dialogActualizaComision').dialog("close");
        },
        "No": function () {
            var ParamUrl = CreateUrl('PV_Historial', 'Proceso');
            BuscarHistorial(ParamUrl);
            $('#dialogActualizaComision').dialog("close");
        }
    }
});

function ActualizarComisiones() {
    var IDCargah = vIDCargah
    var ParamUrl = CreateUrl('ActualizarComisionesManual', 'Proceso');
    $.ajax({
        url: ParamUrl,
        type: "POST",
        data: { IDCarga: IDCargah },
        cache: false,
        success: function (data) {
            if (data == 1) {
                var msj = "El reproceso se realizó exitosamente";
                $('#dialogQuitarCargaManual').dialog("close");
            }
            else if (data == -1) {
                var msj = "Hubo un error, inténtelo mas tarde.";
            }
            InicioJPopUpAlert(msj, RedireccionarVista);
        }
    });
}

function VerDetalleCarga(IdCarga) {
    var ParamUrl = CreateUrl('VerDetalleHistorial', 'Proceso');
    $.ajax({
        url: ParamUrl,
        type: "POST",
        data: {
            IDCarga: IdCarga
        },
        cache: false,
        success: function (data) {
            $("#GrillaImportar").html(data);
            $("#lnk0").click();
        }
    });
}

function ValidarReproceso() {
    var Valido = true;
    replaceErrorMessagge("ID_MsgFechaInicio", "");
    replaceErrorMessagge("ID_MsgFechaFin", "");
    replaceErrorMessagge("ID_MsgSucursal", "");

    if (ValidarFecha("ID_FechaInicio") != 0) {
        replaceErrorMessagge("ID_MsgFechaInicio", "Ingrese una fecha de inicio correcta");
        Valido = false;
    }
    if (ValidarFecha("ID_FechaFin") != 0) {
        replaceErrorMessagge("ID_MsgFechaFin", "Ingrese una fecha de fin correcta");
        Valido = false;
    }
    if (Valido) {
        var FI = $('#ID_FechaInicio').val().toString().substring(0, 10);
        var FF = $('#ID_FechaFin').val().toString().substring(0, 10)
        if (Comparar_Fechas(FI, FF)) {
            replaceErrorMessagge("ID_MsgFechaInicio", "La Fecha Inicio no debe ser mayor a la Fecha Fin");
            replaceErrorMessagge("ID_MsgFechaFin", "La Fecha Fin no debe ser menor a la Fecha Inicio");
            Valido = false;
        }
    }

    if ($("#ID_Sucursal").val() + '' == "null") {
        replaceErrorMessagge("ID_MsgSucursal", "Seleccione alguna sucursal");
        Valido = false;
    }
    return Valido;
}

function replaceErrorMessagge(IdDiv, Message) {
    $("#" + IdDiv).replaceWith('<div style="color: #EC6464; font-size:9px;" id="' + IdDiv + '">' + Message + '</div>');
}

//////////////////////////////////////////////        Consulta reproceso de Ventas   ////////////////////////////////
function ReprocesoVentasAnteriores() {
     
    if (!ValidarReproceso()) {
        return false;
    }
    var ArraySucursales = $("#ID_Sucursal").val();
    if (ArraySucursales == null) {
        ArraySucursales = ''
    }
    var vIdZona = $("#ID_Zona").val();
    ///var vIdSucursal = $("#ID_Sucursal").val();
    var vIdSucursal = ArraySucursales.toString();
    var vFechaInicio = $("#ID_FechaInicio").val();
    var vFechaFin = $("#ID_FechaFin").val();
    var ParamUrl = CreateUrl("ReprocesoVentas_", "Proceso");
    $.ajax({
        url: ParamUrl,
        type: "POST",
        data: {
            IdZona: vIdZona,
            IdSucursal: vIdSucursal,
            FechaInicio: vFechaInicio,
            FechaFin: vFechaFin,
            __RequestVerificationToken: $("input[name='__RequestVerificationToken']").val()
        },
        cache: false,
        success: function (data) {
            var result = data.split("/");
//            InicioJPopUpAlert(result[1], null);
            if (result[0]==1){
                $("#dialogInformacionReproceso p").text(result[1]);
                $("#dialogInformacionReproceso").dialog("open");
                $(".text_message").show();
                $(".text_success").show();
            }else {
                  $("#dialogInformacionInicioReproceso p").text(result[1]);
                  $("#dialogInformacionInicioReproceso").dialog("open");
            }
//            setTimeout(function () { IniciarTimer(); }, 2000);
        }
        ,async: false
    });
}

//var secs;
var timerID = null;
var timerRunning = false;
var delay = 60000;

function IniciarTimer() {
    $(".text_message").show();
    $(".text_success").show();
    DetenerTimer();
    ArrancarTimer();
}

function DetenerTimer() {
    if (timerRunning) {
        clearTimeout(timerID);
        $(".text_message").hide();
        $(".text_success").hide();
    }
    timerRunning = false;
}

function ArrancarTimer() {
    var result;
    var ParamUrl = CreateUrl('ObtenerResultadoReproceso', 'Proceso');    
    $.ajax({
        url: ParamUrl,
        type: "POST",
        data: {},
        cache: false,
        async: false,
        success: function (data) {
            var tmp = data.split("/");
            result = tmp[0];
            if (result == "1") {
                DetenerTimer();
                InicioJPopUpAlert(tmp[1], RedireccionarVistaReproceso);
            }
            else {
//                self.status = secs;
//                secs = secs - 1;
                timerRunning = true;
                timerID = self.setTimeout("ArrancarTimer()", delay);
            }
        }
    });
    if (result == "1") {
        $(".text_message").hide();
        $(".text_success").hide();
    }else {
        $(".text_message").show();
        $(".text_success").show();
    }
}

$(function () {
    $('#dialogInformacionReproceso').dialog({
        autoOpen: false,
        resizable: false,
        closeOnEscape: false,
        open: function (event, ui) { $(".ui-dialog-titlebar-close", this.parentNode).hide(); },
        width: 400,
        buttons: [{
            id: "btnAceptar",
            text: "Aceptar",
            click: function () {
                $(this).dialog("close");
               IniciarTimer();
            }
        }]
    });
});

$(function () {
    $('#dialogInformacionInicioReproceso').dialog({
        autoOpen: false,
        resizable: false,
        closeOnEscape: false,
        open: function (event, ui) { $(".ui-dialog-titlebar-close", this.parentNode).hide(); },
        width: 400,
        buttons: [{
            id: "btnAceptar",
            text: "Aceptar",
            click: function () {
                $(this).dialog("close");
            }
        }]
    });
});

function ImportarEmpleados() {
    $.ajax({
        url: "ImportarArchivos",
        data: {
        },
        type: "post",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            if (data == 1 || data == -1) {
                $('#dialogInformacionImportacion p').text("Se subieron con éxito los registros");
            }
            else if (data == 2) {
                $('#dialogInformacionImportacion p').text("Los registros ya han sido cargados previamente. Si desea volver a cargarlos deberá desactivar la carga");
            }
            else if (data == 3) {
                $('#dialogInformacionImportacion p').text("Ocurrió un error al migrar los datos, inténtelo nuevamente");
            }
            $('#dialogInformacionImportacion').dialog("open");
        },
        error: function (req, status, error) {
            alert(status.toString() + error.toString());
        }
    });
}