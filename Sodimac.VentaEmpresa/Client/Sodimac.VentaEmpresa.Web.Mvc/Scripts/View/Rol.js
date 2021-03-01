function CancelarRegistro() {
    $('#dialogInformacionCancelar').dialog('open');
    return false;
}

$(function () {
    $('#dialogInformacionCancelar').dialog({
        autoOpen: false,
        width: 400,
        resizable: false,
        buttons: {
            "Si": function () {
                $('#dialogInformacionCancelar').dialog("close");
                $('#ModelEditarRol').dialog("close");
                $('#ModelAgregarRol').dialog("close");
            },
            "No": function () {
                $('#dialogInformacionCancelar').dialog("close");
            }
        }
    });
});

var formulario;
function Registrar(form) {
    formulario = form;
    if (ValidarRegistro()) {
        $('#dialogInformacionGuardar').dialog('open');
        return false;
    }
    return false;
}

function EditarRol(ParamUrl, IdRol) {
    $.ajax({
        url: ParamUrl,
        data: {
            IdRol: IdRol
        },
        type: "post",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#ModelEditarRol").empty();
            $('#ModelEditarRol').html(data);
            $("#rdoRAActivo").uniform();
            $("#rdoRAInactivo").uniform();
            MostrarDialogEditarRol();
        },
        error: function (req, status, error) {
        }
    });
}

var GUrlRol;
var GIdRol;
var GUrlDestino;
function DesactivarRol(UrlRol, IdRol) {
    GUrlRol = UrlRol;
    GIdRol = IdRol;
    GUrlDestino = $("#IdUrl_RolDestino").val();

    $('#dialogInformacionDesactivar').dialog("open");
    return false;
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
            }
        }]
    });
});

$(function () {
    $('#dialogInformacionResultado2').dialog({
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
            }
        }]
    });
});

$(function () {
    $('#dialogInformacionGuardar').dialog({
        autoOpen: false,
        resizable: false,
        width: 400,
        modal: true,
        buttons: {
            "Si": function () {
                var form = $('#' + formulario);
                var paramUrl = "";
                (formulario == 'frmAgregarRol') ? paramUrl = "Agregar" : paramUrl = "EditarRol";

                var nombreRol = $("#NombreRol").val();
                if (nombreRol != "" || nombreRol != undefined) {
                    $.ajax({
                        url: paramUrl,
                        type: "POST",
                        data: form.serialize(),
                        success: function (data) {
                            $('#dialogInformacionGuardar').dialog("close");

                            $("#dialogInformacionResultado").empty();

                            if (data == "-1")
                                $("#dialogInformacionResultado").append("<p>El nombre ingresado ya fué registrado, ingrese otro</p>")
                            else if (data == "0")
                                $("#dialogInformacionResultado").append("<p>Se ha producido una excepción / Seleccione datos</p>")
                            else {
                                $("#dialogInformacionResultado").append("<p>Se registró correctamente</p>")
                                parent.$("#btnPopAceptar").bind("click", function () { window.location = "Consultar"; });
                            }
                            $("#dialogInformacionResultado").dialog("open");
                        },
                        error: function (jqXhr, textStatus, errorThrown) {
                            alert(jqXhr.responseText);
                        }
                    });
                } else {
                    alert("ERROR")
                }
            },
            "No": function () {
                $('#dialogInformacionGuardar').dialog("close");
            }
        }
    });
});

$(function () {
    $('#dialogInformacionDesactivar').dialog({
        autoOpen: false,
        resizable: false,
        width: 400,
        modal: true,
        buttons: {
            "Si": function () {
                $.ajax({
                    url: GUrlRol,
                    data: {
                        pIdRol: GIdRol
                    },
                    type: "post",
                    cache: false,
                    success: function (data, textStatus, jqXHR) {
                        $('#dialogInformacionDesactivar').dialog("close");
                        $("#dialogInformacionResultado").empty();
                        if (data == "0")
                            $("#dialogInformacionResultado").append("<p>Se ha producido una excepción</p>")
                        else {
                            $("#dialogInformacionResultado").append("<p>Se desactivó correctamente</p>")
                                parent.$("#btnPopAceptar").bind("click", function () {
                                $("#dialogInformacionResultado").dialog("close"); BuscarRol(GUrlDestino); 
                            });
                        }
                        $("#dialogInformacionResultado").dialog("open");
                    },
                    error: function (jqXhr, textStatus, errorThrown) {
                        alert(jqXhr.responseText);
                    }
                });
            },
            "No": function () {
                $('#dialogInformacionDesactivar').dialog("close");
            }
        }
    });
});

function ValidarRegistro() {

    var validacion = true;
    if (formulario == "frmAgregarRol") {
        vRol = $('#NombreRolA').val();
        if (vRol.length > 2) {
            $("#msgRolA").replaceWith('<div style="color:Red; font-size:8px;" id="msgRol"></div>');
        } else {
            validacion = false;
            $("#msgRolA").replaceWith('<div style="color:Red; font-size:8px;" id="msgRol">Ingrese un Nombre de Rol Válido.</div>');
        }
    } else {
        vRol = $('#NombreRol').val();

        if (vRol.length > 2) {
            $("#msgRol").replaceWith('<div style="color:Red; font-size:8px;" id="msgRol"></div>');
        } else {
            validacion = false;
            $("#msgRol").replaceWith('<div style="color:Red; font-size:8px;" id="msgRol">Ingrese un Nombre de Rol Válido.</div>');
        }
    }
    return validacion;
}

function BuscarRol(vUrl) {
    var NombreRol = $("#Nombre").val();
    var EstadoRol = $("#ActivoRol").val();
    page = -1;
    $.ajax({
        url: vUrl,
        data: {
            pNombreRol: NombreRol,
            pEstadoRol: EstadoRol,
            page: page
        },
        type: "post",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $('#contenedor-grid-Rol').html(data);
        },
        error: function (req, status, error) {
        }
    });
}

function MostrarDialogEditarRol() {
    $("#ModelEditarRol").css("display", "block");
    $('#ModelEditarRol').dialog({ autoOpen: false, width: 500, height: 280, resizable: false });
    $('#ModelEditarRol').dialog('option', 'modal', true).dialog('open');
    return true;
}

function MostrarDialogAgregarRol() {
    $("#ModelEditarRol").empty();
    $("#ModelAgregarRol").css("display", "block");
    $('#ModelAgregarRol').dialog({ autoOpen: false, width: 500, height: 280, resizable: false });
    $('#ModelAgregarRol').dialog('option', 'modal', true).dialog('open');
    return true;
}

var isCheck = false;
function getLateralMenu(paramUrl, valor, titulo) {
    isCheck = false;
    $('#IdPagina').val(valor);
    GUrlRol = paramUrl;
    mostrarRolesCheck(paramUrl, valor);
    return false;
}

function mostrarRolesCheck(paramUrl, valor){
    $.ajax({
        url: paramUrl,
        data: {
            codigoPagina: valor,
            page: -1
        },
        type: "post",
        success: function (data) {
            if (true) {
                $("#DivRoles").html(data);
                $(".chk_rols").uniform();
                PintarGrilla();
            } else {
                $("#EditarMen").html(data);
                PopUp();
            }
        },

        complete: function () {

            $("#dgvDatos tbody > tr").click(function () {
                var $trs = $("#dgvDatos tbody > tr");
                var $tr = $(this);

                $("table.dgvDatos tbody > tr").filter(".highlight").removeClass("highlight");
                $trs.filter(".highlight").removeClass("highlight");
                $tr.addClass("highlight");

            });
        }




    });
        return false;
}

function PopUp() {
    $("#EditarMen").css("display", "block");
    $('#EditarMen').dialog({ autoOpen: false, width: 450, height: 400, resizable: false, hide: 'fade', show: 'fade', close: function () {
    }
    });
    $('#EditarMen').dialog('option', 'modal', true).dialog('open');
}

function getPadres(checkbx) {
   var li = $(checkbx[0]).parent().parent().parent().parent().parent();
    checkPadr = $(li).children("div").find("input[type='checkbox']"); //
    if ($(checkPadr).val() == undefined) {
        return;
    }
    idMenP += $(checkPadr).val() + ",";
    getPadres(checkPadr);
}

var chk = false;
function clearChecks() {
    $("#sitemap").find("input:checked").each(function () {
        $(this).attr("checked", false);
        $(this).parent().removeAttr("class");
    });
}

function SelPadre(check) {
    var ul = $(check).parent().parent().parent().parent();
    var checkss = $(ul).find("input[type='checkbox']");
    des = false;
    $(checkss).each(function () {
        if ($(this).attr("checked")) {
            des = true;
            return false;
        }
    });
    checkPadres(ul, des);

}

function checkPadres(ul, des) {
    sw = false;
    if ($(ul).attr("id") == "sitemap") {
        sw = true;
    }

    var chec = false;
    var clas = "";
    li = $(ul).parent();
    check = $(li).children("div").find("span input[type='checkbox']");
    if (des) {
        chec = true;
        clas = "checked";
    }
    $(check).attr("checked", chec);
    $(check).parent().attr("class", clas);
    if (sw) {
        return false;
    }

    checksH = $("#sitemap").find("li ul").find("input:checked");
    if ((checksH.length > 0) && (!des)) {
        return false;
    }
    checkPadres($(li).parent(), des);
}

function ValidarAsignarPerfil() {
    $("#dialogInformacionResultado").empty();
    var Editable = true;
    var idsRol = $('#arrayRoles').val();
    var IdPagina = $("#IdPagina").val();
    if (IdPagina.length == 0) {
        $("#dialogInformacionResultado").append("<p>Debe seleccionar al menos un módulo o página</p>")
            parent.$("#btnPopAceptar").bind("click", function () {
            $("#dialogInformacionResultado").dialog("close");
        })
        $("#dialogInformacionResultado").dialog("open");
        Editable  = false;
    }
    if (idsRol.length == 0) {
        $("#dialogInformacionResultado2").empty();
        $("#dialogInformacionResultado2").append("<p>Debe seleccionar al menos un rol</p>")
        parent.$("#btnPopAceptar").bind("click", function () {
            $("#dialogInformacionResultado").dialog("close"); 
        })
        $("#dialogInformacionResultado2").dialog("open");
        Editable = false;
    }

    return Editable;
}

function AsignarPerfil(paramUrl, urlDestino) {
    if (ValidarAsignarPerfil()) {
        var idsRol = $('#arrayRoles').val();
        var IdPagina = $("#IdPagina").val();

        $.ajax({
            data: {
                IdRoles: idsRol.toString(),
                IdPagina: IdPagina,
                __RequestVerificationToken: $("input[name='__RequestVerificationToken']").val()
            },
            url: paramUrl,
            type: "post",
            success: function (data) {
                $('#arrayRoles').val('');
                $("#IdPagina").val('');
                $("#dialogInformacionResultado").empty();
                $("#dialogInformacionResultado").append("<p>" + data + "</p>")
                $("#dialogInformacionResultado").dialog("open")
            }
        });
    }
}

function CheckboxTempId(obj) {    
    var arrayRol = $(obj).val(); 
    var arrayId = $('#arrayRoles').val().split(',');
    var arrayIdFN = new Array();

    if (arrayId == "") {
        arrayIdFN[0] = arrayRol;
    } else {
        var cont = 0;
        for (var x = 0; x < arrayId.length; x++) {   
            if (arrayId[cont] != arrayRol) {
                arrayIdFN[cont] = arrayId[cont];                
            }
            cont++;
        }

        if ($(obj).is(':checked')) {
            arrayIdFN[cont] = arrayRol;
        }
  }

    arrayIdFN = cleanArray(arrayIdFN);
    $('#arrayRoles').val(arrayIdFN);
  }

  function cleanArray(actual) {
    var newArray = new Array();
    for (var i = 0; i < actual.length; i++) {
        if (actual[i]) {
            newArray.push(actual[i]);
        }
    }
    return newArray;
}

var resaltarOpt=function(bool,element) {
    $("a[style*='red']").css("color","");
    $("#nomMenuSel").html("");
    if (bool)
    $(element).css("color","red");
};
