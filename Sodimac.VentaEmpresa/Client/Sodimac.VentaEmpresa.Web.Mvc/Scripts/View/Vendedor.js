var flagCmbTipoRepVen = 0;

function BuscarVendedor() {
    var vUrl = $("#ID_UrlBuscaEmpleado").val();
    var vNombresApellidos = $("#ID_NombresApellidos").val();
    var vCodigoOfisis = $("#ID_CodigoOfisis").val();
    var vIdSucursal = $("#ID_IdSucursal ").val();
    var vIdPerfil = $("#ID_Perfil").val();
    var vIdZona = $("#ID_Zona").val();
    var vIdEstado = $("#ID_IdEstado").val();
    var vIdTipoRepVen = $("#ID_TipoRepVen").val();
    flagCmbTipoRepVen = 0;

    $.ajax({
        url: vUrl,
        data: {
            NombresApellidos: vNombresApellidos,
            CodigoOfisis: vCodigoOfisis,
            IdSucursal: vIdSucursal,
            IdPerfil: vIdPerfil,
            IdTipoRepVen: vIdTipoRepVen,
            IdZona: vIdZona,
            IdEstado: vIdEstado
        },
        type: "post",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#contenedorgrilla-ListadoEmpleados").html(data)
        },
        error: function (req, status, error) {
        }
    })
}

function SetTotalRegistros_BuscarEmpleado() {
    $("#dgvDatos_ tfoot tr td a").bind("click", function (e) {
        var url = $(this).attr('href');
        var vNombresApellidos = $("#ID_NombresApellidos").val();
        var vCodigoOfisis = $("#ID_CodigoOfisis").val();
        var vIdSucursal = $("#ID_IdSucursal ").val();
        var vIdPerfil = $("#ID_Perfil").val();
        var vIdZona = $("#ID_Zona").val();
        var vIdEstado = $("#ID_IdEstado").val();
        var vIdTipoRepVen = $("#ID_TipoRepVen").val();
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
            if (arr[i].indexOf("sort=") >= 0)
                sort = arr[i].toString().split("=")[1].toString();
            if (arr[i].indexOf("sortdir") >= 0)
                sortdir = arr[i].toString().split("=")[1].toString();
        }

        var newurl = "";
        newurl = queue + "page=" + page + "&sort=" + sort + "&sortdir=" + sortdir +
        "&NombresApellidos=" + vNombresApellidos +
        "&CodigoOfisis=" + vCodigoOfisis +
        "&IdSucursal=" + vIdSucursal +
        "&IdZona=" + vIdZona +
        "&IdPerfil=" + vIdPerfil +
        "&IdTipoRepVen=" + vIdTipoRepVen +
        "&IdEstado=" + vIdEstado
        $(this).attr('href', newurl);
    });

    var count = $("#countListaEmpleado").val();
    if (count == 0) {
        $(function () { $(".tDefault thead").css("display", "none"); });
    }
    $("#dgvDatos_ tfoot tr:last td").prepend("<a id='tfootPage' class='total_registros'></a>");
    $("#tfootPage").html($('#hdfTotalRegistros').val());
}

function cargarSucursal() {
    var vUrl = $("#UrlSucursales").val();
    var vIdcargo = $("#IdEmpleadoCargo").val();
    if (vIdcargo == "") { vIdcargo = 0; }
    $.ajax({
        url: vUrl,
        type: "POST",
        data: {
            idcargos: vIdcargo
        },
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $('#divListaSucursalporCargo').html(data);
        },
        complete: function () {
            $('#ID_Sucursal').uniform();
        }
    });
}

function cargarSucursales() {
    var vUrl = $("#UrlSucursales").val();
    var vIdzona = $("#ID_zona").val();
    if (vIdzona == "") { vIdzona = 0; }
    $.ajax({
        url: vUrl,
        type: "POST",
        data: {
            idzona: vIdzona
        },
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $('#divListaSucursalporZona').html(data);
        },
        complete: function () {
            $('#ID_Sucursal').uniform();
        }
    });
}


function cargarZonas() {
    var vUrl = $("#UrlZonas").val();
    var vIdCargo = $("#IdEmpleadoCargo").val();
    if (vIdCargo == "") { vIdCargo = 0; }
    $.ajax({
        url: vUrl,
        type: "POST",
        data: {
            idcargos: vIdCargo
        },
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#divListaZonaporCargo").html(data);
        },
        complete: function () {
            $('#ID_zona').uniform();
        }
    });
}
function CargarSupervisor() {
    var vUrl = $("#UrlSupervisor").val();
    var vIdcargo = $("#IdEmpleadoCargo").val();
    if (vIdcargo == "") { vIdcargo = 0; }
    $.ajax({
        url: vUrl,
        type: "POST",
        data: {
            idcargos: vIdcargo
        },
        cache: false,
        success: function (data, jqXHR) {
            // $("#divListaSupervisorCargo").html(data);
        },
        complete: function () {
            $('#ID_CargoSu').uniform();
        }
    });
}

/////////////////////////////   CARGAR ESCALAS DE COMISION  POR CARGO   ///////////////////////////////////////////////////////////////////
function cargarComisionServicios() {
    var vUrl = $("#UrlComisionDetalle").val();
    var vIdcargo = $("#IdEmpleadoCargo").val();
    if (vIdcargo == "") { vIdcargo = 0; }
    $.ajax({
        url: vUrl,
        type: "POST",
        data: {
            idcargos: vIdcargo
        },
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $('#divEscalaInicialCargo').html(data);
        },
        complete: function () {
            $('#ID_ComisionServicio').uniform();
        }
    });
}

/////////////////////////////   CARGAR ESCALAS DE COMISION  POR PERFIL Y ZONA   ///////////////////////////////////////////////////////////////////

function cargarComisionServiciosPerfilzona() {
    var vUrl = $("#UrlComisionDetalle").val();
    var vIdPerfil = $("#ID_Perfil").val();
    var vIdZona = $("#ID_zona").val();

    if (vIdPerfil == "") { vIdcargo = 0; }
    if (vIdZona == "") { vIdZona = 0; }
    $.ajax({
        url: vUrl,
        type: "POST",
        data: {
            IdPerfil: vIdPerfil,
            IdZona: vIdZona
        },
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $('#divEscalaInicialCargo').html(data);
        },
        complete: function () {
            $('#ID_ComisionServicio').uniform();
        }
    });
}
////////////////////////// FIN ////////////////////////////////////////////////////////////////

function validaTipoPerfilCargos() {
    var vtextomostrar = $("#divEscalaInicialCargo").val();
    var ParamURL = CreateUrl("ConsultartipoPerfilCargo", "Ventas")
    var vidempleado = $("#IdEmpleadoCargo").val();
    var vresultado = $("#resultado").val();

    $.ajax({
        url: ParamURL,
        data: {
            idcargos: vidempleado
        },
        type: "POST",
        cache: false,
        async: false,
        success: function (data, textStatus, jqXHR) {
            var vresultado = data;
            if (vidempleado != 0) {
                if (vresultado == 1) {
                    $("#divEscalaInicialCargo").show();
                    $("#divListaSupervisorCargo").show();
                } else {
                    $("#divEscalaInicialCargo").hide();
                    $("#divListaSupervisorCargo").hide();
                }
            }
            else {
                $("#divEscalaInicialCargo").hide();
            }
        }
    })
};

////////////////////////////////////   VALIDAR TIPO PERFIL Y ZONA          /////////////////////////////////////

function validaTipoPerfilZona() {

    var ParamURL = CreateUrl("ConsultartipoPerfilZona", "Ventas")
    var vIdPerfil = $("#ID_Perfil").val();
    var vIdZona = $("#ID_zona").val();
    var vresultado = $("#resultado").val();

    $.ajax({
        url: ParamURL,
        data: {
            IdPerfil: vIdPerfil,
            IdZona: vIdZona
        },
        type: "POST",
        cache: false,
        async: false,
        success: function (data, textStatus, jqXHR) {
            var vresultado = data;
            //            if (vidempleado != 0) {
            if (vresultado == 1) {
                $("#divEscalaInicialCargo").show();
                $("#divListaSupervisorCargo").show();
            } else {
                $("#divEscalaInicialCargo").hide();
                $("#divListaSupervisorCargo").hide();
            }
            //            }
            //            else {
            //                $("#divEscalaInicialCargo").hide();
            //            }
        }
    });
}




///////////////////////////////////  FIN  /////////////////////////////////////////////////////////////////


$(function () {
    $("#dialog-sucursal").dialog({
        modal: true,
        autoOpen: false,
        closeOnEscape: true,
        open: function (event, ui) { $(".ui-dialog-titlebar-close").hide(); },
        resizable: false,
        width: 1350,
        height: 420,
        buttons: [
            { id: "btnRegistrarSucursalEmpleado", text: "Guardar", click: function () { } },
            { text: "Cancelar", click: function () { $(this).dialog("close"); } }
        //            { text: "Cancelar", class: "buttonS bDefault formSubmit group_button", click: function () { $(this).dialog("close"); } }
        ]
    });
    $("#dialog-messages").dialog({
        autoOpen: false,
        resizable: false,
        closeOnEscape: true,
        width: 400,
        open: function (event, ui) { $(".ui-dialog-titlebar-close").hide(); },
        resizable: false,
        modal: true,
        buttons: [{
            id: "idAceptar",
            text: "Aceptar",
            click: function () {
                $(this).dialog("close");
            }
        }]
    });
    $("#dialog-confirm").dialog({
        modal: true,
        autoOpen: false,
        resizable: false,
        closeOnEscape: true,
        open: function (event, ui) { $(".ui-dialog-titlebar-close").hide(); },
        width: 400,
        buttons: [{
            id: "idSiRegistrar",
            text: "Si",
            click: function () {
            }
        },
        {
            text: "No",
            click: function () {
                $(this).dialog("close");
            }
        }]
    });
    $("#btnDesactivar").live("click", function () {

        var IdEmpleado = $("#IdEmpleado").val();
        var url = $("#returnDesactivarEmpleado").val().replace("_", "");
        $.ajax({
            url: url,
            data: { IdEmpleado: IdEmpleado },
            type: "post",
            success: function (data) {

                if (data == 1) {
                    $("#btnDesactivar").attr("value", "Activar");
                } else {
                    $("#btnDesactivar").attr("value", "Desactivar");
                }
            }
        })
    })
});




/////////////////////            QUERY PARA VALIDAR SI LA SUCURSAL TIENE UNA CARTERA DE CLIENTES    /////////////////////////////////

function ValidarCarteraVendedor() {
    var vidempleado = $("#IdEmpleado").val();
    var paramurl = CreateUrl('ValidarEmpleadoCartera', 'Ventas');

    $.ajax({
        url: paramurl,
        data: {
            idempleado: vidempleado
        },
        type: "POST",
        cache: false,
        success: function (data) {
            var vresultado = data;
            if (vresultado == 1) {
                $("#dialogRegistrarSucursalEmpleado").html("<p>¿Desea registrar la Sucursal?</p>" + "<p>Nota: Si registra una nueva sucursal, se desactivará la sucursal registrada anteriormente</p>");
                $("#dialogRegistrarSucursalEmpleado").dialog("open");
            } else {
                $("#dialogRegistrarSucursalEmpleado").html("<p>¿Desea registrar la Sucursal?</p>");
                $("#dialogRegistrarSucursalEmpleado").dialog("open");
            }
        }
    });
}
////////////////////     INICIA       //////////////////////////////////////

function ValidaEmpleadoActivoCartera() {
    var vidempleado = $("#IdEmpleado").val();
    var paramurl = CreateUrl('ValidaEmpleadoActivoCartera', 'Ventas');

    $.ajax({
        url: paramurl,
        data: {
            IdEmpleado: vidempleado
        },
        type: "POST",
        cache: false,
        success: function (data) {
            var vresultado = data;
            if (vresultado == 1) {
                InicioJPopUpOpen('#dialogEliminarRegistroPersonalconCartera');
            } else {
                InicioJPopUpOpen('#dialogEliminarRegistroPersonalsinCartera');
            }
        }
    });
}


///////////////////  FIN           /////////////////////////////////////////

function ValidaEmpleadoActivoCartera(IdEmpleado) {

    var vidempleado = $("#IdEmpleado").val();
    var paramurl = CreateUrl('ValidaEmpleadoActivoCartera', 'Ventas');

    $.ajax({
        url: paramurl,
        data: {
            IdEmpleado: vidempleado
        },
        type: "POST",
        cache: false,
        success: function (data) {
            var vresultado = data;
            if (vresultado == 1) {
                InicioJPopUpOpen('#dialogEliminarRegistroPersonalconCartera');
            } else {
                InicioJPopUpOpen('#dialogEliminarRegistroPersonalsinCartera');
            }
        }
    });

}

////////////////////        FIN                 ////////////////////////////

function ActualizarSituacionVendedor() {
    var paramurl = CreateUrl('DesactivarEmpleadoporEstado', 'Ventas');
    var vEmpleado = $('#IdEmpleado').val();
    var IdEstado = $('#IdEstado').val();

    $.ajax({
        url: paramurl,
        data: {
            IdEmpleado: vEmpleado,
            IdEstado: IdEstado
        },
        type: "POST",
        cache: false,
        success: function (data) {
            var msgResult = data.split('/');
            $('#dialogEliminarRegistroPersonalconCartera').dialog("close");
            $('#dialogEliminarRegistroPersonalsinCartera').dialog("close");
            InicioJPopUpAlert(msgResult[0], RedireccionarVendedor(msgResult[1]));
        }
    });
}



$(function () {
    ValidarFechaMaskEdit(".datepicker");
});

function ListarCargosPorPerfil() {
    var vUrl = $("#ID_Url_ComboListaCargo").val();
    var vIdPerfil = $("#ID_IdPerfil").val();
    $.ajax({
        url: vUrl,
        type: "POST",
        data: { IdPerfil: vIdPerfil },
        success: function (data) {
            $("#ID_ComboListaCargo").html(data)
        },
        error: function (er) {
        }
    })
}

function ListarTipoRepresentanteVenta() {
    var vUrl = $("#ID_Url_ListarTipoRepresentanteVenta").val();
    var vIdPerfil = $("#ID_Perfil").val();

    if (vIdPerfil == "") {
        vIdPerfil = 0;
    }

    $.ajax({
        url: vUrl,
        type: "POST",
        data: {
            IdPerfil: vIdPerfil,
            FlagCmbTipoRepVen: flagCmbTipoRepVen
        },
        success: function (data) {
            $("#divListaTipoRepresentanteVenta").html(data)
        },
        error: function (er) {
        },
        complete: function () {
            $('#ID_TipoRepVen').uniform();
        }
    })
}

//////////////////////=========================== GUARDAR EMPLEADO =======================////////////////////////////////////

function GuardarVendedor() {
    var form = $('#frmRegistrarEmpleado');
    $.ajax({
        url: form.attr('action'),
        type: "POST",
        data: form.serialize(),
        success: function (data) {
            var result = data.split("/");
            if (result[0] == 1 || result[0] == 2) {
                RedireccionarConsultar();

                // BuscarVendedor()
            }
            InicioJPopUpAlert(result[1], null);
        },
        error: function (jqXhr, textStatus, errorThrown) {
        }
    });

}

function RegistrarVendedor() {

    //   var sUsuarioSistema = $("#ID_UsuarioSistema").val();
    //    var ValidaUsuarioS=true;

    //    if (sUsuarioSistema == "") {
    //        ValidaUsuarioS = false;
    //        $("#validaUsuarioUsu > span").text("Requerido");
    //    }
    //    else {
    //        $("#validaUsuarioUsu > span").text("");
    //    } 

    //if ($('#frmRegistrarEmpleado').valid() && ValidaUsuarioS) {
    if ($('#frmRegistrarEmpleado').valid()) {
        var FC = $('#ID_FechaContrato').val().toString().substring(0, 10);
        var FN = $('#ID_FechaNacimiento').val().toString().substring(0, 10);
        var Now = new Date();

        replaceErrorMessagge("ID_MsgFechaContrato", "");
        replaceErrorMessagge("ID_MsgFechaNacimiento", "");

        if (FC == FN) {
            replaceErrorMessagge("ID_MsgFechaContrato", "Fecha contrato igual a fecha nacimiento");
            replaceErrorMessagge("ID_MsgFechaNacimiento", "Fecha nacimiento igual a fecha contrato");
        } else if (Comparar_Fechas(FN, FC)) {
            replaceErrorMessagge("ID_MsgFechaContrato", "Fecha contrato menor a fecha nacimiento");
            replaceErrorMessagge("ID_MsgFechaNacimiento", "Fecha nacimiento mayor a fecha contrato");
        } else if (Comparar_Fechas(FN, DateToString(Now))) {
            replaceErrorMessagge("ID_MsgFechaNacimiento", "Fecha nacimiento mayor a fecha actual");
        } else if (DateToString(Now) == FN) {
            replaceErrorMessagge("ID_MsgFechaNacimiento", "Fecha nacimiento igual a fecha actual");
        } else {
            $("#dialogRegistrarPersonal").dialog("open");
        }
    }
}

function dialogCancelarRegistroPersonal() {
    InicioJPopUpOpen('#dialogCancelarRegistroPersonal');
    RedireccionarConsultar();

}

function RedireccionarConsultar() {
    var ParamUrl = CreateUrl('BuscarEmpleado', 'Ventas');
    window.location = ParamUrl;
    //     parent.$("#btnPopAceptar").unbind("click", function () { window.location = ParamUrl; });
    //setTimeout('parent.$("#btnPopAceptar").click();', 3500);
}


//btnPopAceptar

function EnterSubmit(e, buttonClick) {
    tecla = (document.all) ? e.keyCode : e.which;
    if (tecla == 13) {
        var obj = document.getElementById(buttonClick);
        obj.click();
    }
}

function ValidaFecha() {
    var valida = true;
    if (ValidarFecha("ID_FechaNacimiento") == 0 && ValidarFecha("ID_FechaContrato") == 0) {
        var vFechaNacimiento = $("#ID_FechaNacimiento").val();
        var vFechaContrato = $("#ID_FechaContrato").val();
        if (Comparar_Fechas(vFechaNacimiento, vFechaContrato)) {
            replaceErrorMessagge("ID_MsgFechaNacimiento", "La Fecha Nacimiento no debe ser mayor a la Fecha Contrato");
            replaceErrorMessagge("ID_MsgFechaContrato", "");
            valida = false;
        }
    }
    return valida;
}

function ValidaFechaActivacion() {
    var valida = true;
    if (ValidarFecha("ID_FechaIngreso") == 0 && ValidarFecha("ID_FechaActivacion") == 0) {
        var vFechaIngreso = $("#ID_FechaIngreso").val();
        var vFechaActivacion = $("#ID_FechaActivacion").val();
        if (Comparar_Fechas(vFechaIngreso, vFechaActivacion)) {
            replaceErrorMessagge("ID_MsgFechaIngreso", "La Fecha Ingreso no debe ser mayor a la Fecha Activación");
            replaceErrorMessagge("ID_MsgFechaActivacion", "");
            valida = false;
        }
    }
    return valida;
}

function replaceErrorMessagge(IdDiv, Message) {
    $("#" + IdDiv).replaceWith('<div style="color: #EC6464; font-size:9px;" id="' + IdDiv + '">' + Message + '</div>');
}

///////////////////////////////////////////// TAB PLAN DE VENTAS  //////////////////////////////////////////////////////////////////////////////////////
//////================= resetear ==============================00/////////////////

function DialogNuevoPlanVenta() {
    $('#frmRegistrarPlanVenta').each(function () {
        this.reset();
    });
    $("#dialog-PlanVenta").dialog("open");
}

$("#btnNuevoPlan").live("click", function () {
    $("#frmRegistrarPlanVenta").each(function () {
        this.reset();
    });
    $("#dialog-PlanVenta").dialog("open");
})

/////////////////////////////////////////  FIN  //////////////////////////////////////////////////////////////////

///////////////////////////////////////////// TAB SUCURSAL EMPLEADO  ///////////////////////////////////////////////////////////////////////////////////

function DialogNuevoSucursalEmpleado() {
    $('#frmRegistrarSucursalEmpleado').each(function () {
        this.reset();
    });
    $("#dialog-Sucursal").dialog("open");
}

$("#btnNuevoSucursal").live("click", function () {
    $("#frmRegistrarSucursalEmpleado").each(function () {
        this.reset();
    });
    $("#dialog-Sucursal").dialog("open");
})


/////////////////////////////////////////  FIN  //////////////////////////////////////////////////////////////////

/////================   NUEVAS FUNCIONES J ===========================//////////////////////

//function ListaCargosporPerfil() {
//    var vIdPerfil = $("#ID_Perfil").val();
//    var ParamUrl = CreateUrl("PVCargo_Combo", "Ventas")
//    $.ajax({
//        url: ParamUrl,
//        data: {
//            IdPerfil: vIdPerfil
//        },
//        type: "post",
//        cache: false,
//        success: function (data, textStatus, jqXHR) {
//            $("#IdEmpleadoCargo").html(data);
//            $("#IdEmpleadoCargo").uniform();
//            $("#IdEmpleadoCargo").attr("class", "ignorefield");
//            $("#IdEmpleadoCargo option[value=" + VarIdCargoSuperior + "]").attr("selected", "selected").change();
//        },
//        error: function (jqXhr, textStatus, errorThrown) {
//        }
//    });
//}

function ListaCargosporPerfil() {
    var vUrl = $("#UrlCargos").val();
    var vIdperfil = $("#ID_Perfil").val();
    if (vIdperfil == "") { vIdperfil = 0; }
    $.ajax({
        url: vUrl,
        type: "POST",
        data: {
            idPerfil: vIdperfil
        },
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $('#DivListarCargosPerfiles').html(data);
        },
        complete: function () {
            $('#IdEmpleadoCargo').uniform();
        }
    });
}


//////// ===========================         PAGINACION DE HISTORIAL DE SUCURSALES EMPLEADO  ==================================////////////////////////////////

function SetTotalRegistrosSucursales() {
    $("#dgvSucursalEmpleado tfoot tr:last td").prepend("<a id='tfootPage' class='total_registros'></a>");
    $("#tfootPage").html($('#hdfTotalRegistros').val());
    $("#dgvSucursalEmpleado tfoot tr a, #dgvSucursalEmpleado thead tr a").live("click", function (e) {
        var sortdir = "";
        var sort = "";
        var page = 1;
        var queue = "";
        var arr = new Array()
        arr = url.split("?")
        queue = arr[0].toString() + "?";
        arr = arr[1].toString().split("&")
        for (var i = 0; i <= arr.length - 1; i++) {
            if (arr[i].indexOf("page") >= 0)
                page = arr[i].toString().split("=")[1].toString();
            if (arr[i].indexOf("sort=") >= 0)
                sort = arr[i].toString().split("=")[1].toString();
            if (arr[i].indexOf("sortdir") >= 0)
                sortdir = arr[i].toString().split("=")[1].toString();
        }
        var newurl = "";
        newurl = queue + "page=" + page + "&sort=" + sort + "&sortdir=" + sortdir// +

        $(this).attr('href', newurl);
    });
}










///////////  =================================  PLAN DE VENTAS EMPLEADO  ====================================////////////////////////


function replaceErrorMessagge(IdDiv, Message) {
    $("#" + IdDiv).replaceWith('<div style="color: #EC6464; font-size:9px;" id="' + IdDiv + '">' + Message + '</div>');
}

function ValidaCampos() {
    var valida = true;
    var validaControl = true;
    var vEscalatiempo = $("#ID_EscalaAsignado").val();
    var vId_TiempoServicio = $("#Id_TiempoNuevo").val();
    if (vEscalatiempo < vId_TiempoServicio) {
        replaceErrorMessagge("ID_MsgEscalaTiempo", "");
        replaceErrorMessagge("ID_MsgEscalaTiempo", "");
        valida = true;
    }
    else {
        replaceErrorMessagge("ID_MsgEscalaTiempo", "La Escala de tiempo no debe ser igual a la actual");
        replaceErrorMessagge("ID_MsgEscalaAsignado", "");
        valida = false;
    }
    return valida;
}





////// ====================================  Dialogo     ==================================================///////////////////////////////////
function dialogGestionarPlanVenta() {

    var ParamUrl = CreateUrl("GestionarPlanVentaEmpleado", "Ventas")
    var IdEmpleado = $("#IdEmpleado").val();

    $.ajax({
        url: ParamUrl,
        data: {
            IdEmpleado: IdEmpleado
        },
        type: "get",
        cache: false,
        success: function (data, textStatus, jqXHR) {

            $("#dialogGestionarPlanVenta").html(data);
            $("#Id_NombreSuperior").uniform();
            $("#Id_NuevoPlan").uniform();
            $("#Id_Mes").uniform();
            $("#Id_TiempoNuevo").uniform();
            $("#Id_IngresoBasicoMensual").uniform();

            //var item = $("#Id_TiempoNuevo")[0].options[1].value;
            // var item = $("#Id_TiempoNuevo");

            //            if (item == -1) {

            // InicioJPopUpAlert("El Empleado ya tiene configurado su plan de ventas hasta el fin del periodo.", null);
            //            }
            //            else {
            //              
            InicioJPopUpOpen('#dialogGestionarPlanVenta');
            //            }
        },
        error: function (jqXhr, textStatus, errorThrown) {
        }
    });
}

function GuardarPlanVenta() {

    var form = $('#frmRegistrarPlanVentaEmpleado');

    $.ajax({
        url: form.attr('action'),
        type: "POST",
        data: form.serialize(),
        success: function (data) {
            var result = data.split("/");
            if (result[0] == 1 || result[0] == 2) {
                $('#dialogGestionarPlanVenta').dialog("close");
                ObtenerPlanVentaPorIdEmpleado()
            }
            InicioJPopUpAlert(result[1], null);
        },
        error: function (jqXhr, textStatus, errorThrown) {

        }
    });
}

function RegistrarPlanVenta() {

    $("#frmRegistrarPlanVentaEmpleado").each(function () { $.data($(this)[0], 'validator', false); })
    $.validator.unobtrusive.parse("#frmRegistrarPlanVentaEmpleado");

    //var valida_ = ValidaCampos();

    if ($('#frmRegistrarPlanVentaEmpleado').valid()) {
        $('#dialogRegistrarPlanVenta').dialog('open');
    }
}

function DialogCancelarRegistroPlanVenta() {
    InicioJPopUpOpen('#dialogCancelarRegistroPlanventa');
}
function CancelarRegistroPlanVenta() {
    $('#dialogGestionarPlanVenta').dialog('close');
}
function ObtenerPlanVentaPorIdEmpleado() {
    var IdEmpleado = $("#IdEmpleado").val();
    var ParamUrl = CreateUrl("ListarPlanVentaEmpleado", "Ventas");
    $.ajax({
        url: ParamUrl,
        data: {
            IdEmpleado: IdEmpleado
        },
        type: "get",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#contendor-grid-planventa").html(data)  /// id de la grilla parcial
        },
        error: function (jqXHR, status, error) {
        },
        complete: function () {

        }
    });
}

function SetTotalRegistrosPlanventa() {
    $("#dgvPlanventaEmpleado tfoot tr:last td").prepend("<a id='tfootPage' class='total_registros'></a>");
    $("#tfootPage").html($('#hdfTotalRegistros').val());
    $("#dgvPlanventaEmpleado tfoot tr a, #dgvPlanventaEmpleado thead tr a").live("click", function (e) {
        var sortdir = "";
        var sort = "";
        var page = 1;
        var queue = "";
        var arr = new Array()
        arr = url.split("?")
        queue = arr[0].toString() + "?";
        arr = arr[1].toString().split("&")
        for (var i = 0; i <= arr.length - 1; i++) {
            if (arr[i].indexOf("page") >= 0)
                page = arr[i].toString().split("=")[1].toString();
            if (arr[i].indexOf("sort=") >= 0)
                sort = arr[i].toString().split("=")[1].toString();
            if (arr[i].indexOf("sortdir") >= 0)
                sortdir = arr[i].toString().split("=")[1].toString();
        }
        var newurl = "";
        newurl = queue + "page=" + page + "&sort=" + sort + "&sortdir=" + sortdir// +

        $(this).attr('href', newurl);
    });
}

////////////////////////////////////////////////  NUEVO QUERY PARA MOSTRAR EL TAB POR PERFIL  ///////////////////////////////////////////////////

function RedireccionarVendedor(id) {
    if (id == "4") {
        window.location.href = "/Account/LogOff";
    } else {
        window.location.href = "/Ventas/BuscarEmpleado";
    }

}


//function MostrarTab(){
//    if($("#ID_IdTipoRepVen").val() == 1 ){
//       $("#tabb3").show();
//   }else{
//        $("#divmostrarid").hide();
//   }
//};

/////////////////////////////////////////  OBTENER NOMBRE CARGO VENDEDOR    /////////////////////////////////////////////////////////////

//function ObtenerNombreCargoVendedor() {
//    var vID_Perfil = $("#ID_Perfil :selected").val();
//    var vID_zona = $("#ID_zona :selected").val();
//    var vUrl = CreateUrl('comboCargoVendedor', 'Ventas');

//    $.ajax({
//        url: vUrl,
//        data: {
//            IdPerfil: vID_Perfil,
//            IdZona: vID_zona
//        },
//        type: "POST",
//        cache: false,
//        success: function (data) {
//            $("#ID_NombreCargo").html(data);
//        },

//    });
// }


///////////////////////////////////////     REGISTRAR SUCURSAL EMPLEADO   /////////////////////////////////////////////////////////////////////////


function dialogGestionarSucursalEmpleado() {
    flagCmbTipoRepVen = 1;
    var ParamUrl = CreateUrl("RegistraSucursalEmpleado", "Ventas")
    var IdEmpleado = $("#IdEmpleado").val();

    $.ajax({
        url: ParamUrl,
        data: {
            IdEmpleado: IdEmpleado
        },
        type: "get",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#dialogGestionarSucursalEmpleado").html(data);
            $("#ID_Perfil").uniform();
            var IdPerfilActual = $("#HD_IdPerfilActual").val()
            $("#ID_Perfil option[value=" + IdPerfilActual + "]").attr("selected", "selected").change();
            $("#ID_zona").uniform();
            $("#ID_NombreCargo").uniform();
            $("#ID_Sucursal").uniform();
            $("#ID_FechaIngreso").uniform();
            $("#ID_FechaActivacion").uniform();
            $("#ID_TipoRepVen").uniform();
            InicioJPopUpOpen("#dialogGestionarSucursalEmpleado");
        },
        error: function (jqXhr, textStatus, errorThrown) {
        }
    });

}

function GuardarSucursalEmpleado() {

    var form = $('#frmRegistrarSucursalEmpleado');

    $.ajax({
        url: form.attr('action'),
        type: "POST",
        data: form.serialize(),
        success: function (data) {
            var result = data.split("/");
            if (result[0] == 1 || result[0] == 2) {
                $('#dialogGestionarSucursalEmpleado').dialog("close");
                BuscarSucursalPersonal()
                $("#dialog-messages").html("<p>Se registró la sucursal correctamente</p>");
                $("#dialog-messages").dialog("open");

            } else {
                InicioJPopUpAlert(result[1], null);
            }
        },
        error: function (jqXhr, textStatus, errorThrown) {

        }
    });
}


function RegistrarSucursalEmpleado() {
    var estado = $("#Id_Reporta").val();
    var IdPerfil = $("#ID_Perfil").val();
    $("#frmRegistrarSucursalEmpleado").each(function () {
        $.data($(this)[0], 'validator', false);
    })
    $.validator.unobtrusive.parse("#frmRegistrarSucursalEmpleado");

    if (IdPerfil == 6 && estado == "") {
        $("#idReq").css("display", "inline-block")
    } else {
        $("#idReq").css("display", "none")
    }

    if ($('#frmRegistrarSucursalEmpleado').valid()) {
        var FI = $('#ID_FechaIngreso').val().toString().substring(0, 10);
        var FC = $('#ID_FechaContrato').val().toString().substring(0, 10);
        var FN = $('#ID_FechaNacimiento').val().toString().substring(0, 10);

        if (ValidarFecha("ID_FechaIngreso") != 0) {
            replaceErrorMessagge("ID_MsgFechaIngresoSucursal", "Ingrese una fecha ingreso correcta");
            return false;
        }
        if (FI == FN) {
            replaceErrorMessagge("ID_MsgFechaIngresoSucursal", "Fecha ingreso igual a fecha nacimiento");
        } else if (Comparar_Fechas(FN, FI)) {
            replaceErrorMessagge("ID_MsgFechaIngresoSucursal", "Fecha ingreso mayor a fecha nacimiento");
        } else if (Comparar_Fechas(FC, FI) && FI != FC) {
            replaceErrorMessagge("ID_MsgFechaIngresoSucursal", "Fecha ingreso menor a fecha contrato");
        } else {
            replaceErrorMessagge("ID_MsgFechaIngresoSucursal", "");
            ValidarCarteraVendedor();
        }

        if (IdPerfil == 6 && estado == "") {
            $("#idReq").css("display", "inline-block")
            return false;
        }
        else {
            return true;
        }
    }
}

function dialogCancelarRegistroSucursalEmpleado() {
    InicioJPopUpOpen('#dialogCancelarRegistroSucursalEmpleado');
}
function CancelarRegistroSucursalEmpleado() {
    $('#dialogGestionarSucursalEmpleado').dialog('close');
}

//CAMBIANDO
function BuscarSucursalPersonal() {
    // var vUrl = $("#RegistrarSucursalEmpleado").val(); 
    var ParamUrl = CreateUrl("RegistrarSucursalEmpleado", "Ventas");
    var vIdEmpleado = $("#IdEmpleado").val();
    $.ajax({
        url: ParamUrl,
        data: { IdEmpleado: vIdEmpleado },
        type: "get",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#contendor-grid-sucursal").html(data)
        },
        error: function (jqXHR, status, error) {
        },
        complete: function () {
            // SetTotalRegistrosSucursales();
        }
    })
}

/////////////////////================= EJEMPLO =========================================////////////////////////////////////
///////////////////////////////////    FIN REGISTRAR SUCURSAL EMPLEADO    //////////////////////////////////////////////////////////////////////


var vperfilsele;
function SeleccionarJefe() {
    var vTexto = $("#ID_Perfil :selected").text();
    vperfilsele = vTexto;
    if ($("#ID_Perfil").val() == "") {
        $("#ID_NombreCargo").val('')
    } else {
        $("#ID_NombreCargo").val(vperfilsele)
    }
}

function ObtenerNombreCargoInferior() {
    var vID_Perfil = $("#ID_Perfil").val();
    var vID_zona = $("#ID_zona").val();
    var vUrl = CreateUrl('comboCargoVendedor', 'Ventas')
    if (vID_Perfil == "") { vID_Perfil = 0 }
    if (vID_zona == "") { vID_zona = 0 }

    $.ajax({
        url: vUrl,
        data: {
            IdPerfil: vID_Perfil,
            IdZona: vID_zona
        },
        type: "POST",
        cache: false,
        success: function (data) {
            if ($("#ID_Perfil").val() == "") {
                $("#ID_NombreCargo").val("");
            } else if ($("#ID_zona").val() == "") {
                $("#ID_NombreCargo").val("");
            } else {
                $("#ID_NombreCargo").val(data);
            }
            if ($("#ID_NombreCargo").val() == "[object XMLDocument]") {
                $("#ID_NombreCargo").val("");
            }
        }
    });

}

///////////////////////////////////  OBTENER CARGO SUPERIOR DEL EMPLEADO    //////////////////////////////

function ObtenerCargoSuperiorVendedor() {
    var vIdPerfil = $("#ID_Perfil").val();
    var vIdZona = $("#ID_zona").val();
    var vUrl = CreateUrl('comboCargarCargoSuperior', 'Ventas')
    if (vIdPerfil == "") { vID_Perfil = 0 }
    if (vIdZona == "") { vID_zona = 0 }
    $.ajax({
        url: vUrl,
        data: {
            IdPerfil: vIdPerfil,
            IdZona: vIdZona
        },
        type: "get",
        cache: false,
        success: function (data) {
            if ($("#ID_Perfil").val() == "") {
                $("#Id_Reporta").val("");
            } else if ($("#ID_zona").val() == "") {
                $("#Id_Reporta").val("");
            } else {
                $("#Id_Reporta").val(data);
            }
            if ($("#Id_Reporta").val() == "[object XMLDocument]") {
                $("#Id_Reporta").val("");
            }
        }
    });
}


//////////////////////////////////////////////        Consulta reproceso de Ventas   ////////////////////////////////
function ReprocesoVentasAnteriores() {
    var ArraySucursales = $("#ID_Sucursal").val()
    if (ArraySucursales == null) {
        ArraySucursales = ''
    }
    var vIdZona = $("#ID_Zona").val();
    ///var vIdSucursal = $("#ID_Sucursal").val();
    var vIdSucursal = ArraySucursales.toString();
    var vFechaInicio = $("#ID_FechaInicio").val();
    var vFechaFin = $("#ID_FechaFin").val();
    var ParamUrl = CreateUrl("ReprocesoVentas_", "Ventas");
    $.ajax({
        url: ParamUrl,
        type: "POST",
        data: {
            IdZona: vIdZona,
            IdSucursal: vIdSucursal,
            FechaInicio: vFechaInicio,
            FechaFin: vFechaFin
        },
        cache: false,
        success: function (data) {
            var vresultado = data;
            InicioJPopUpAlert(result[1], null);
        }
    });
}

///// valida el empleado que este registrado  ////////////////////////////////////////
