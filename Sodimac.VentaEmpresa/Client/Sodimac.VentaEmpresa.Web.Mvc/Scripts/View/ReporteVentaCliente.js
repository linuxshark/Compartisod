$(document).ready(function () {
    $("#IdSucursal").multiselect(
            {
                noneSelectedText: '-SELECCIONE-',
                show: ["bounce", 200],
                minWidth: 220,
                click: function (event, ui) {
                    var idSucursal = new Array();
                    $("input[name='multiselect_IdSucursal']:checked").each(function () {
                        idSucursal.push($(this).val());
                    });
                    $("#IdsucursalVal").val(idSucursal);
                    replaceErrorMessagge("ID_MsgSucursal", "");
                },
                checkAll: function () {
                    var idSucursal = new Array();
                    $("input[name='multiselect_IdSucursal']:checked").each(function () {
                        idSucursal.push($(this).val());
                    });
                    $("#IdsucursalVal").val(idSucursal);
                    replaceErrorMessagge("ID_MsgSucursal", "");
                },
                uncheckAll: function () {
                    $("#IdsucursalVal").val('');
                }
            }
         ).multiselectfilter();
    $("#IdSucursal").multiselect("uncheckAll");
    $("#ID_FechaInicio").change(ValidaFecha);
    $("#ID_FechaFin").change(ValidaFecha);
    $("#btnReporte").click(reporteVentaEmpresacliente);

    $("#RUC").keydown(function (e) {
        // Allow: backspace, delete, tab, escape, enter and .
        if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
            // Allow: Ctrl+A
            (e.keyCode == 65 && e.ctrlKey === true) ||
            // Allow: Ctrl+C
            (e.keyCode == 67 && e.ctrlKey === true) ||
            // Allow: Ctrl+X
            (e.keyCode == 88 && e.ctrlKey === true) ||
            // Allow: home, end, left, right
            (e.keyCode >= 35 && e.keyCode <= 39)) {
            // let it happen, don't do anything
            return;
        }
        // Ensure that it is a number and stop the keypress
        if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
            e.preventDefault();
        }
    });
});

reporteVentaEmpresacliente = function () {
    debugger;
    if (ValidaFecha()) {
        if ($("#IdsucursalVal").val() == "") {
            replaceErrorMessagge("ID_MsgSucursal", "Seleccione una Sucursal");
        }
        else {
            var vURL = $("#ID_Generar").val();
            var vFechaInicio = $("#ID_FechaInicio").val();
            var vFechaFin = $("#ID_FechaFin").val();
            var vIdSucursal = $("#IdsucursalVal").val();
            var vRUC = $("#RUC").val();

            $.ajax({
                url: vURL,
                type: "GET",
                data: {
                    FechaInicio: vFechaInicio,
                    FechaFin: vFechaFin,
                    Sucursal: vIdSucursal,
                    RUC: vRUC
                },
                cache: false,
                success: function (data) {
                    var arr = data.split(";");
                    var Path = arr[0].toString().replace("~", "");
                    var FileName = arr[1].toString().replace("~", "");
                    DownloadFile(Path, FileName);
                },
                error: function (data) {
                    alert("Error: " + data);
                }
            });
        }
    }
}

replaceErrorMessagge = function (IdDiv, Message) {
    $("#" + IdDiv).replaceWith('<div style="color: #EC6464; font-size:9px;" id="' + IdDiv + '">' + Message + '</div>');
}

DownloadFile = function (filePath, fileName) {
    if (fileName.length > 0) {
        window.open(filePath + fileName, '_blank');
    }
    else {
        alert('No se realizó la carga de ningún archivo.');
    }
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
