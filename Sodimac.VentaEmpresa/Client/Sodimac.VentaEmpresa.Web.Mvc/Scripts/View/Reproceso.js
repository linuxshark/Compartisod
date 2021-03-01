$(function () {
    ValidarFechaMaskEdit(".datepicker");
});


function ValidaFechaActivacion() {
    var valida = true;
    if (ValidarFecha("ID_FechaDesde") == 0 && ValidarFecha("ID_FechaHasta") == 0) {
        var vFechaIngreso = $("#ID_FechaDesde").val();
        var vFechaActivacion = $("#ID_FechaHasta").val();
        if (Comparar_Fechas(vFechaIngreso, vFechaActivacion)) {
            replaceErrorMessagge("ID_MsgFechaDesd", "La Fecha Ingreso no debe ser mayor a la Fecha Activación");
            replaceErrorMessagge("ID_MsgFechaHasta", "");
            valida = false;
        }
    }
    return valida;
}

function BuscarBoletas() {
    if (ValidaFecha()) {
        var vUrl = $("#ID_UrlBuscaBoleta").val();
        var vSucursal = $("#ID_IdSucursal").val();
        var vFechaIni = $("#ID_FechaDesde").val();
        var vFechaFin = $("#ID_FechaHasta ").val();
        var vDNI = $("#ID_DNI").val();
        var vNumDoc = $("#ID_NumDoc").val();

        $.ajax({
            url: vUrl,
            data: {

                Sucursal: vSucursal,
                FechaInicio: vFechaIni,
                FechaFin: vFechaFin,
                Dni: vDNI,
                NumeroDocumento: vNumDoc
            },
            type: "post",
            cache: false,
            success: function (data, textStatus, jqXHR) {
                $("#GrillaRBoletas").html(data)
            },
            error: function (req, status, error) {
            }
        })
    }
}

function ValidaFecha() {
    var valida = true;
    var sucursal = $("#ID_IdSucursal").val()
    if (ValidarFecha("ID_FechaDesde") == 0) {
        replaceErrorMessagge("ID_MsgFechaInicio", "");
    }
    else {
        replaceErrorMessagge("ID_MsgFechaInicio", "Ingrese una fecha de inicio correcta");
        valida = false;
    }
    if (ValidarFecha("ID_FechaHasta") == 0) {
        replaceErrorMessagge("ID_MsgFechaFin", "");
    }
    else {
        replaceErrorMessagge("ID_MsgFechaFin", "Ingrese una fecha de fin correcta");
        valida = false;
    }
    if ($("#ID_IdSucursal").val() == "") {
        replaceErrorMessagge("ID_MsgSucursal", "Ingrese una Sucursal");
        valida = false;
        
    }
  
    else {
        replaceErrorMessagge("ID_MsgSucursal", "");
    }
    if ($("#ID_NumDoc").val() >= 2147483648) {
        replaceErrorMessagge("ID_MsgNroDocumento", "El valor máximo es: 2147483647");
        valida = false;
    }
    else {
        replaceErrorMessagge("ID_MsgNroDocumento", "");
    }

    if (ValidarFecha("ID_FechaDesde") == 0 && ValidarFecha("ID_FechaHasta") == 0) {
        var vFechaInicio = $("#ID_FechaDesde").val();
        var vFechaFin = $("#ID_FechaHasta").val();
        if (Comparar_Fechas(vFechaInicio, vFechaFin)) {
            replaceErrorMessagge("ID_MsgFechaInicio", "La Fecha Inicio no debe ser mayor a la Fecha Fin");
            replaceErrorMessagge("ID_MsgFechaFin", "");
            valida = false;
        }
    }
    return valida;
}

function replaceErrorMessagge(IdDiv, Message) {
    $("#" + IdDiv).replaceWith('<div style="color: #EC6464; font-size:9px;" id="' + IdDiv + '">' + Message + '</div>');
}


function GuardarDatos() {debugger
    var Valor = $("#dgvDatos_").length
    if (Valor == "0") {
        var msg;
        msg = "No se encontro ningun registro"
        $("#Consultar p").text(msg);
        $("#Consultar").dialog('open');
        return;
    }
    $.ajax({ 
        url: "/Ventas/Guardar",
        data: $("#ConsultarBoletasReprocesar").serialize(),
        type: "post",
        success: function (data) {
            var msg;
            if (data == -1) {
                msg = "Seleccion Boletas a Registrar"
            }
            else if (data ==2) {
                msg = "No se encontro ningun registro"
            }

            else {
                msg = "Los datos se guardaron correctamente."
            }
            $("#Consultar p").text(msg);
            $("#Consultar").dialog('open');
        }
    })
}

$("#Consultar").dialog({
    autoOpen: false,
    modal: true,
    resizable: false,
    width: 400,
    hide: 'fade',
    show: 'fade',
    title: "Mensaje de Validación",
    buttons: [{
        id: "btnPopAceptar",
        text: "Aceptar",
        click: function () {
            //Cargar()
            $(this).dialog("close");

        }
    }]
});
Cargar = function () {
    window.location = UrlAction.urlCargarPrincipal
}