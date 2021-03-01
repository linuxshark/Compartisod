$(document).ready(function () {
    $("#IdRol").multiselect(
            {
                noneSelectedText: '-SELECCIONE-',
                show: ["bounce", 200],
                minWidth: 220,
                click: function (event, ui) {
                    var idRol = new Array();
                    $("input[name='multiselect_IdRol']:checked").each(function () {
                        idRol.push($(this).val());
                    });
                    $("#IdRolVal").val(idRol);
                    replaceErrorMessagge("ID_MsgRol", "");
                },
                checkAll: function () {
                    var idRol = new Array();
                    $("input[name='multiselect_IdRol']:checked").each(function () {
                        idRol.push($(this).val());
                    });
                    $("#IdRolVal").val(idRol);
                    replaceErrorMessagge("ID_MsgRol", "");
                },
                uncheckAll: function () {
                    $("#IdRolVal").val('');
                }
            }
         ).multiselectfilter();
    $("#IdRol").multiselect("uncheckAll");
    $("#ID_FechaInicio").change(ValidaFecha);
    $("#ID_FechaFin").change(ValidaFecha);
    $("#btnExportar").click(exportarReporte);
    $("#btnLimpiar").click(Limpiar);


    //$(document).on('input', 'input, textarea', function (e) {
    //    debugger;
    //    if (e.originalEvent.inputType == 'insertFromPaste') {
    //        //alert($(this).val());
    //    }
    //});


});

exportarReporte = function () {
    //if (ValidaFecha()) {
        if ($("#IdRolVal").val() == "") {
            replaceErrorMessagge("ID_MsgRol", "Seleccione un Rol");
        }
        else {

            if (ValidaFecha()) {
                var vUrl = $("#urlGenerarReporteUsuario").val();
                var vFechaIni = $("#ID_FechaInicio").val();
                var vFechaFin = $("#ID_FechaFin").val();
                var vIdsRol = $("#IdRolVal").val();
                var vUsuario = $("#Usuario").val();
                var vEstado = $("#IdEstado").val();

                Url = vUrl + '?IdsRol=' + vIdsRol +
                             '&FechaIni=' + vFechaIni +
                             '&FechaFin=' + vFechaFin +
                             '&Estado=' + vEstado +
                             '&Usuario=' + vUsuario;
                window.open(Url, '_self');
            }
        }
    //}
}

replaceErrorMessagge = function (IdDiv, Message) {
    $("#" + IdDiv).replaceWith('<div style="color: #EC6464; font-size:9px;" id="' + IdDiv + '">' + Message + '</div>');
}

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

function Limpiar() {
    $("#ID_FechaInicio").val('')
    $("#ID_FechaFin").val('')
    $("#Usuario").val('')
    $("#IdRol").multiselect("uncheckAll")
}

//function validarSoloLetras(e, t) {
//    try {
//        if (window.event) {
//            var charcode = window.event.keycode;
//        }
//        else if (e) {
//            var charcode = e.which;
//        }
//        else { return true; }
//        if ((charcode > 64 && charcode < 91) || (charcode > 96 && charcode < 123))
//            return true;
//        else {
//            //alert("please enter only alphabets");
//            return false;
//        }

//    }
//    catch (err) {
//        alert(err.description);
//    }
//}
