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
    $("#btnExportar").click(exportarReporte);
    $("#btnLimpiar").click(Limpiar);
});


exportarReporte = function () {
    if ($("#IdRolVal").val() == "") {
        replaceErrorMessagge("ID_MsgRol", "Seleccione un Rol");
    }
    else {
        var vUrl = $("#urlGenerarReporteRolPagina").val();
        var vIdsRol = $("#IdRolVal").val();
        var vEstado = $("#IdEstado").val();
        var vNombrePag = $("#NombrePagina").val();

        Url = vUrl + '?IdsRol=' + vIdsRol +
                     '&Estado=' + vEstado +
                     '&NombrePagina=' + vNombrePag;
        window.open(Url, '_self');
    }
}


replaceErrorMessagge = function (IdDiv, Message) {
    $("#" + IdDiv).replaceWith('<div style="color: #EC6464; font-size:9px;" id="' + IdDiv + '">' + Message + '</div>');
}

function Limpiar() {
    $("#NombrePagina").val('')
    $("#IdRol").multiselect("uncheckAll")
}

//validarSoloLetras= function(e, t) {
//    try {
//        if (window.event) {
//            var charCode = window.event.keyCode;
//        }
//        else if (e) {
//            var charCode = e.which;
//        }
//        else { return true; }
//        if ((charCode > 64 && charCode < 91) || (charCode > 96 && charCode < 123))
//            return true;
//        else {
//            //alert("Please enter only alphabets");
//            return false;
//        }

//    }
//    catch (err) {
//        alert(err.Description);
//    }
//}
