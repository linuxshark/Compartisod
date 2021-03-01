function AsignarRolUsu(paramUrl) {
    if ($("#cboIdRol").val() == '') {
        scrollTo(0, 0);
        return false;
    }
    var usuarios = $("#box2View option");
    idUsuarios = new Array();
    $(usuarios).each(function (i) {
        idUsuarios[i] = $(this).val();
    });
    $.ajax({
        url: paramUrl,
        data: { idUsuarios: idUsuarios.toString(),
            IdRol: $("#cboIdRol").val(),
            __RequestVerificationToken: $("input[name='__RequestVerificationToken']").val()
        },
        type: "post",
        success: function (data) {
            scrollTo(0, 0);
            if (data == '-1') {
                $("#dialogInformacionResultado").empty();
                $("#dialogInformacionResultado").append("<p>Hubo errores al realizar esta operación, por favor consulte con su administrador</p>")
                parent.$("#btnPopAceptar").bind("click", function () { $("#dialogInformacionResultado").dialog("close"); });
                $("#dialogInformacionResultado").dialog("open");
            } else {
                $("#dialogInformacionResultado").empty();
                $("#dialogInformacionResultado").append("<p>Roles asignados correctamente</p>")
                parent.$("#btnPopAceptar").bind("click", function () { $("#dialogInformacionResultado").dialog("close"); });
                $("#dialogInformacionResultado").dialog("open");
            }
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
            }
        }]
    });
});

function MostrarDialogAgregarUsuario() {
    $("#ModelEditarUsuario").empty();
    $("#ModelAgregarUsuario").css("display", "block");
    $('#ModelAgregarUsuario').dialog({ autoOpen: false, width: 600, height: 350, resizable: false });
    $('#ModelAgregarUsuario').dialog('option', 'modal', true).dialog('open');
    return true;
}

function MostrarDialogEditarUsuario() {
    $("#ModelEditarUsuario").css("display", "block");
    $('#ModelEditarUsuario').dialog({ autoOpen: false, width: 600, height: 350, resizable: false });
    $('#ModelEditarUsuario').dialog('option', 'modal', true).dialog('open');
    return true;
}

function BuscarUsuario(vUrl) {
    var NombreUsu = $("#Nombre").val();
    var EstadoUsu = $("#ActivoUsu").val();
    page = -1;
    $.ajax({
        url: vUrl,
        data: {
            pNombreUsu: NombreUsu,
            pEstadoUsu: EstadoUsu,
            page: page
        },
        type: "post",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $('#contenedor-grid-Usuario').html(data);
        },
        error: function (req, status, error) {
        }
    });
}

function EditarUsuario(ParamUrl, IdUsu) {
    $.ajax({
        url: ParamUrl,
        data: {
            IdUsu: IdUsu
        },
        type: "post",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#ModelEditarUsuario").empty();
            $('#ModelEditarUsuario').html(data);
            MostrarDialogEditarUsuario();
        },
        error: function (req, status, error) {
        }
    });
}

function DesactivarUsuario(UrlUsu, IdUsu) {
    GUrlUsu = UrlUsu;
    GIdUsu = IdUsu;
    GUrlDestino = $("#IdUrl_UsuarioDestino").val();
    $('#dialogInformacionDesactivar').dialog("open");
    return false;
}

function RegistrarUsuario(form) {
    formulario = form;

    if (ValidarRegistroUsuario()) {

        $('#dialogInformacionGuardar').dialog('open');
        return false;
    }
    return false;
}

function ValidarRegistroUsuario() {
    var validacion = true;
    var usuarioUsu = $("#UsuarioUsu").val();
    var usuarioNom = $("#UsuarioNom").val();

    if (formulario == "frmAgregarUsuario") {
        if (usuarioUsu.length > 2) {
            $("#msgUsuarioUsu").html('');
        } else {
            validacion = false;
            $("#msgUsuarioUsu").html('<div style="color:Red; font-size:9px;" id="msgUsuarioUsu">Ingrese un Login de Usuario Válido.</div>');
        }

        if (usuarioNom.length > 2) {
            $("#msgUsuarioNom").replaceWith('<div style="color:Red; font-size:9px;" id="msgUsuarioNom"></div>');
        } else {
            validacion = false;
            $("#msgUsuarioNom").replaceWith('<div style="color:Red; font-size:9px;" id="msgUsuarioNom">Ingrese un Nombre de Usuario Válido.</div>');
        }
    } else {
        usuarioUsu = $("#UsuarioUsu_e").val();
        usuarioNom = $("#UsuarioNom_e").val();
        if (usuarioUsu.length >= 2) {
            $("#msgUsuarioUsu_e").html('');
        } else {
            $("#msgUsuarioUsu_e").html('Ingrese un Login de Usuario Válido.');
            validacion = false;
        }

        if (usuarioNom.length >= 2) {
            $("#msgUsuarioNom_e").html('');
        } else {
            $("#msgUsuarioNom_e").html('Ingrese un Nombre de Usuario Válido.');
            validacion = false;
            
        }       
    }
    return validacion;
}

$(function () {
    $('#dialogInformacionDesactivar').dialog({
        autoOpen: false,
        resizable: false,
        width: 450,
        modal: true,
        buttons: {
            "Si": function () {
                $.ajax({
                    url: GUrlUsu,
                    data: {
                        pIdUsu: GIdUsu
                    },
                    type: "post",
                    cache: false,
                    success: function (data, textStatus, jqXHR) {
                        $('#dialogInformacionDesactivar').dialog("close");
                        $("#dialogInformacionResultado").empty();
                        if (data == "0")
                            $("#dialogInformacionResultado").append("<p>Se ha producido una excepción</p>")
                        else {
                            $("#dialogInformacionResultado").append("<p>Se desactivó correctamente</p>");
                            $("#dialogInformacionResultado").dialog("close");
                            BuscarUsuario(GUrlDestino);
                        }
                        $("#dialogInformacionResultado").dialog("open");
                    },
                    error: function (jqXhr, textStatus, errorThrown) {
                    }
                });
            },
            "No": function () {
                $(this).dialog("close");
            }
        }
    });
});

$(function () {
    $('#dialogInformacionGuardar').dialog({
        autoOpen: false,
        resizable: false,
        width: 450,
        modal: true,
        buttons: {
            "Si": function () {
                var form = $('#' + formulario);
                var paramUrl = "";
                (formulario == 'frmAgregarUsuario') ? paramUrl = "AgregarUsuario" : paramUrl = "EditarUsuario_";
                $.ajax({
                    url: paramUrl,
                    type: "POST",
                    data: form.serialize(),
                    success: function (data) {
                        $('#dialogInformacionGuardar').dialog("close");
                        $("#dialogInformacionResultado").empty();

                        if (data == "-1")
                            $("#dialogInformacionResultado").append("<p>El usuario ingresado ya fué registrañdo, ingrese otro</p>")
                        else if (data == "0")
                            $("#dialogInformacionResultado").append("<p>Se ha producido una excepción / Seleccione datos</p>")
                        else {
                            $("#dialogInformacionResultado").append("<p>Se registró correctamente</p>")
                            parent.$("#btnPopAceptar").bind("click", function () { window.location = "GestionarUsuario"; });
                        }
                        $("#dialogInformacionResultado").dialog("open");
                    },
                    error: function (jqXhr, textStatus, errorThrown) {
                    }
                });
            },
            "No": function () {
                $('#dialogInformacionGuardar').dialog("close");
            }
        }
    });
});

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
    $('#dialogInformacionCancelar').dialog({
        autoOpen: false,
        width: 400,
        resizable: false,
        buttons: {
            "Si": function () {
                $('#dialogInformacionCancelar').dialog("close");
                window.location = "GestionarUsuario";
            },
            "No": function () {
                $('#dialogInformacionCancelar').dialog("close");
            }
        }
    });
});

function CancelarRegistro() {
    $('#dialogInformacionCancelar').dialog('open');
    return false;
}

$(function () {
    $(".ActivoUsuClass").each(function () {

       $(this).click(function(){
           $("#idActivoUsu").val($(this).val())
       })
    })
})


//////////////////////*****************    VALIDAR USUARIO     ************************///////////////////////////


function ValidarUsuarioBDexiste() {
    var ParamUrl = CreateUrl("ValidarUsuarioBD", "Account")
    var vUsuarioNom = $("#UsuarioUsu").val();
    if (vUsuarioNom.length > 2) {
        $("#msgUsuarioUsu").html('');
        $.ajax({
            url: ParamUrl,
            data: {
                UsuarioUsu: vUsuarioNom
            },
            type: "post",
            cache: false,
            success: function (data) {
                if (data == 1) {
                    $("#msgValidar").html('<div style="color:green; font-size:9px;" id="msgUsuarioUsu"> Usuario existe.</div>');
                    $("#btnAgregarA").css({ color: "#FFFFFF", background: "#3A70AB" });
                    $('#btnAgregarA').attr('disabled', false);
                } else {
                    $("#msgValidar").html(' <div style="color:red; font-size:9px;" id="msgUsuarioUsu"> Usuario no existe.</div>');
                    $('#btnAgregarA').attr('disabled', true);
                }
            }
        });

    } else {
        validacion = false;
        $("#msgUsuarioUsu").html('<div style="color:Red; font-size:9px;" id="msgUsuarioUsu">Ingrese un Login de Usuario Válido.</div>');
    
        $.ajax({
            url: ParamUrl,
            data: {
                UsuarioUsu: vUsuarioNom
            },
            type: "post",
            cache: false,
            success: function (data) {
                if (data == 1) {
                    $("#msgValidar").html('<div style="color:green; font-size:9px;" id="msgUsuarioUsu"> Usuario existe.</div>');
                    $("#btnAgregarA").css({ color: "#FFFFFF", background: "#3A70AB" });
                    $('#btnAgregarA').attr('disabled', false);
                } else {
                    $("#msgValidar").html(' <div style="color:red; font-size:9px;" id="msgUsuarioUsu"> Usuario no existe.</div>');
                    $('#btnAgregarA').attr('disabled', true);
                }
            }
        });
    }
}


function ValidarUsuarioBDexiste2() {

    var ParamUrl = CreateUrl("ValidarUsuarioBD", "Account")
    var vUsuarioNom = $("#UsuarioUsu_e").val();
    if (vUsuarioNom.length > 2) {
        $("#msgUsuarioUsu").html('');
        
        $.ajax({
            url: ParamUrl,
            data: {
                UsuarioUsu: vUsuarioNom
            },
            type: "post",
            cache: false,
            success: function (data) {
                if (data == 1) {
                    $("#msgValidar1").html('<div style="color:green; font-size:9px;" id="msgUsuarioUsu"> Usuario existe.</div>');
                    $('#btnAgregarUsu').attr('disabled', false);

                } else {
                    $("#msgValidar1").html(' <div style="color:red; font-size:9px;" id="msgUsuarioUsu"> Usuario no existe.</div>');
                    $('#btnAgregarUsu').attr('disabled', true);
                }
            }
        });
    }else {
        validacion = false;
        $("#msgUsuarioUsu").html('<div style="color:Red; font-size:9px;" id="msgUsuarioUsu">Ingrese un Login de Usuario Válido.</div>');
        $.ajax({
            url: ParamUrl,
            data: {
                UsuarioUsu: vUsuarioNom
            },
            type: "post",
            cache: false,
            success: function (data) {
                if (data == 1) {
                    $("#msgValidar1").html('<div style="color:green; font-size:9px;" id="msgUsuarioUsu"> Usuario existe.</div>');
                    $('#btnAgregarUsu').attr('disabled', false);

                } else {
                    $("#msgValidar1").html(' <div style="color:red; font-size:9px;" id="msgUsuarioUsu"> Usuario no existe.</div>');
                    $('#btnAgregarUsu').attr('disabled', true);
                }
            }
        });
     }
}

function ValidarEditarUsuario() {
    var ParamUrl = CreateUrl("ValidarUsuarioBD", "Account")

    var vUsuarioNom = $("#UsuarioUsu_e").val();

    $.ajax({
        url: ParamUrl,
        data: {
            UsuarioUsu: vUsuarioNom
        },
        type: "post",
        cache: false,
        success: function (data) {
            if (data == 1) {
                $("#msgValidarEditar").html('<div style="color:green; font-size:9px;" id="msgUsuarioUsu"> Usuario existe.</div>');
                $("#btnAgregarA").css({ color: "#FFFFFF", background: "#3A70AB" });
                $('#btnAgregarUsu').attr('disabled', false);
                $("#msgValidar1").css("display", "none");
                $("#msgUsuarioUsu").css("display", "none");
                $('#msgUsuarioUsu').hide();

            } else {
                $("#msgValidarEditar").html(' <div style="color:red; font-size:9px;" id="msgUsuarioUsu"> Usuario no existe.</div>');
                $('#btnAgregarUsu').attr('disabled', true);
                $("#msgValidar1").css("display", "none");
                $("#msgUsuarioUsu").css("display", "none");
                $('#msgUsuarioUsu').hide();
            }
        }
    });
}

function ValidarGuardarUsuarioBDexiste() {
    var ParamUrl = CreateUrl("ValidarUsuarioBD", "Account")

    var vUsuarioNom = $("#UsuarioUsu").val();

    $.ajax({
        url: ParamUrl,
        data: {
            UsuarioUsu: vUsuarioNom
        },
        type: "post",
        cache: false,
        success: function (data) {
            if (data == 1) {
                $("#msgValidarguardar").html('<div style="color:green; font-size:9px;" id="msgUsuarioUsu"> Usuario existe.</div>');
                $('#btnAgregarA').attr('disabled', false);
                $("#msgValidar").css("display","none");
                $("#msgUsuarioUsu").css("display","none");
                $('#msgUsuarioUsu').hide();
            } else {
                $("#msgValidarguardar").html(' <div style="color:red; font-size:9px;" id="msgUsuarioUsu"> Usuario no existe.</div>');
                // $('#btnAgregarA').attr('disabled', true);
                $("#msgValidar").css("display", "none");
                $("#msgUsuarioUsu").css("display", "none");
                $('#msgUsuarioUsu').hide();
            }
        }
    });

}

















