function BuscarCarteraClientes() {
    var ParamUrl = CreateUrl("ConsultarCarteraCliente_PVGrilla", "Mantenimiento");
    var vRUC = $("#RUC_AutoComplete").val();
    var vCodigoSucursal = $("#ID_IdSucursal").val();
    var vAnio = $("#Anio_AutoComplete").val();
    var vMes = $("#ID_Mes").val();

    $.ajax({
        url: ParamUrl,
        data: {
            RUC: vRUC,
            CodigoSucursal: vCodigoSucursal,
            Anio: vAnio,
            Mes: vMes
        },
        type: "get",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#contenedor-grid-Perfil").html(data);
        },
        error: function (jqXHR, status, error) {
        }
    });

}

function Limpiar() {
    window.location.reload()
}


function SetTotalRegistrosCarteraClientes() {
    var count = $("#countListaCarteraCliente").val();
    if (count == 0) {
        $(function () { $(".tDefault thead").css("display", "none"); });
    }

    $("#GrillaCarteraClientes tfoot tr:last td").prepend("<a id='tfootPage' class='total_registros'></a>");
    $("#tfootPage").html($('#hdfTotalRegistros').val());
    $("#GrillaCarteraClientes tfoot tr a, #GrillaCarteraClientes thead tr a").live("click", function (e) {
        var url = $(this).attr('href');
        var vRUC = $("#RUC").val();
        var vCodigoSucursal = $("#ID_IdSucursal").val();
        var vAnio = $("#Anio_AutoComplete").val();

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
        newurl = queue + "page=" + page + "&sort=" + sort + "&sortdir=" + sortdir +
            "&RUC=" + vRUC + "&CodigoSucursal=" + vCodigoSucursal + "&Anio=" + vAnio

        $(this).attr('href', newurl);
    });
}

$(document).ready(function () {
    $("#btnExportar").click(exportarReporte);
});

exportarReporte = function () {

    var vUrl = $("#urlGenerarReporteCarteraClientes").val();

    var vRUC = $("#RUC_AutoComplete").val();
    var vCodigoSucursal = $("#ID_IdSucursal").val();
    var vAnio = $("#Anio_AutoComplete").val();
    var vMes = $("#ID_Mes").val();

    Url = vUrl + '?RUC=' + vRUC +
        '&CodigoSucursal=' + vCodigoSucursal +
        '&Anio=' + vAnio +
        '&Mes=' + vMes;
    window.open(Url, '_self');
}

function BuscarPerfil() {
    var ParamUrl = CreateUrl("ConsultarPerfil_PVGrilla", "Mantenimiento");
    var vNombrePerfil = $("#NombrePerfil_AutoComplete").val();
    $.ajax({
        url: ParamUrl,
        data: {
            NombrePerfil: vNombrePerfil
        },
        type: "get",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#contenedor-grid-Perfil").html(data);
        },
        error: function (jqXHR, status, error) {
        }
    });

}

function SetTotalRegistrosPerfiles() {
    var count = $("#countListaPerfil").val();
    if (count == 0) {
        $(function () { $(".tDefault thead").css("display", "none"); });
    }

    $("#GrillaPerfiles tfoot tr:last td").prepend("<a id='tfootPage' class='total_registros'></a>");
    $("#tfootPage").html($('#hdfTotalRegistros').val());
    $("#GrillaPerfiles tfoot tr a, #GrillaPerfiles thead tr a").live("click", function (e) {
        var url = $(this).attr('href');
        var vNombrePerfil = $("#NombrePerfil").val();
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
        newurl = queue + "page=" + page + "&sort=" + sort + "&sortdir=" + sortdir +
            "&NombrePerfil=" + vNombrePerfil

        $(this).attr('href', newurl);
    });
}

var vIdPerfil
function DialogEliminarPerfil(IdPerfil, TipoPerfil) {
    vIdPerfil = IdPerfil
    if (TipoPerfil == 2) {
        InicioJPopUpOpen('#dialogEliminarPerfilJefe');
    }
    else {
        InicioJPopUpOpen('#dialogEliminarPerfilOtros');
    }

}
function EliminarPerfil() {
    var ParamUrl = CreateUrl("EliminarPerfil", "Mantenimiento")
    $.ajax({
        url: ParamUrl,
        data: {
            IdPerfil: vIdPerfil
        },
        type: "post",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $('#dialogEliminarPerfilJefe').dialog("close");
            $('#dialogEliminarPerfilOtros').dialog("close");
            var result = data.split("/");
            if (result[0] == 1 || result[0] == "1") {
                BuscarPerfil()
            }
            InicioJPopUpAlert(result[1], null);
        },
        error: function (jqXhr, textStatus, errorThrown) {
        }
    });
}

function DialogCancelarRegistro() {
    InicioJPopUpOpen('#dialogCancelarRegistro');
}
function CancelarRegistro() {
    $('#dialogGestionarPerfil').dialog('close');
}

//dialogGestionarPerfil: Abre el popUP con el combobox actualizado, usado al dar clic en el boton Nuevo Perfil
function dialogGestionarPerfil() {
    var ParamUrl = CreateUrl("GestionarPerfil", "Mantenimiento")
    //var urla = '@Url.Action'
    $("#HD_IdPerfil").val()
    $.ajax({
        url: ParamUrl,
        data: {
        },
        type: "get",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#dialogGestionarPerfil").html(data);
            $("#ID_PerfilSuperior").uniform();
            $("#ID_PerfilTipo").uniform();
            InicioJPopUpOpen('#dialogGestionarPerfil');
        },
        error: function (jqXhr, textStatus, errorThrown) {
        }
    });

}
//dialogGestionarPerfil: Abre el popUP con el combobox actualizado, usado al dar clic en el boton editar Perfil, setea valores al perfil
function EditarPerfil(IdPerfil, IdPerfilSuperior, NombrePerfil, TipoPerfil, NombrePerfilInferior) {
    var ParamUrl = CreateUrl("GestionarPerfil", "Mantenimiento")
    $.ajax({
        url: ParamUrl,
        data: {
            IdPerfil: IdPerfil,
            TipoPerfil: TipoPerfil
        },
        type: "get",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#dialogGestionarPerfil").html(data);
            $("#ID_PerfilSuperior").uniform();
            $("#ID_PerfilTipo").uniform();
            InicioJPopUpOpen('#dialogGestionarPerfil');
            $("#HD_IdPerfil").val(IdPerfil)
            $("#NombrePerfil").val(NombrePerfil)
            $("#ID_PerfilSuperior option[value=" + IdPerfilSuperior + "]").attr("selected", "selected").change();
            $("#ID_PerfilTipo option[value=" + TipoPerfil + "]").attr("selected", "selected").change();
        },
        error: function (jqXhr, textStatus, errorThrown) {
        }
    });
}



function RegistrarPerfil() {
    $("#ID_PerfilSuperior").attr("class", "ignorefield")

    $("#frmGestionarPerfil").each(function () { $.data($(this)[0], 'validator', false); });
    $.validator.unobtrusive.parse("#frmGestionarPerfil");

    if ($('#frmGestionarPerfil').valid()) {
        $('#dialogRegistrarPerfil').dialog('open');
    }
}
function GuardarPerfil() {
    var form = $('#frmGestionarPerfil');
    $.ajax({
        url: form.attr('action'),
        type: "POST",
        data: form.serialize(),
        success: function (data) {
            var result = data.split("/");
            if (result[0] == 1 || result[0] == 2) {
                $('#dialogGestionarPerfil').dialog("close");
                BuscarPerfil()
            }
            InicioJPopUpAlert(result[1], null);
        },
        error: function (jqXhr, textStatus, errorThrown) {
        }
    });
}
function EnterSubmit(e, buttonClick) {
    tecla = (document.all) ? e.keyCode : e.which;
    if (tecla == 13) {
        var obj = document.getElementById(buttonClick);
        obj.click();
    }
}

function EnterSubmitF(e, functionname) {
    tecla = (document.all) ? e.keyCode : e.which;
    if (tecla == 13) {
        BuscarClientes_Grupo();
    }
}
//**    *///
// FIN DE PERFILES***********************************************************************************************************************************************************************************
//**************************************************************************************************************************************************************************************************

//AHORA CARGOS
$(function () {
    $.ajaxSetup({ type: "POST" });
    var ParamUrl = CreateUrl("Autocompletado_Cargo", "Mantenimiento")
    $('#NombreCargo_AutoComplete').autocomplete(ParamUrl, {
        dataType: 'json',
        parse: function (data) {
            var rows = new Array();
            for (var i = 0; i < data.length; i++) {
                rows[i] = { data: data[i], value: data[i].NombreCargo, result: data[i].NombreCargo, id: data[i].IdCargo };
            }
            return rows;
        },
        formatItem: function (row) {
            return row.NombreCargo;
        },
        delay: 400,
        autofill: true,
        selectFirst: false,
        highlight: false,
        minChars: 3
        //multiple: true
    }).result(function (event, row) {
        $('#NombreCargo_AutoComplete').val(row.NombreCargo);
    });
});
function BuscarCargo() {
    var ParamUrl = CreateUrl("ConsultarCargo_PVGrilla", "Mantenimiento");
    var vNombreCargo = $("#NombreCargo_AutoComplete").val();
    var vIdPerfil = $("#ID_IdPerfil").val();
    $.ajax({
        url: ParamUrl,
        data: {
            NombreCargo: vNombreCargo,
            IdPerfil: vIdPerfil
        },
        type: "get",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#contenedor-grid-Cargo").html(data);
        },
        error: function (jqXHR, status, error) {
        }
    });
}

function SetTotalRegistrosCargos() {

    var count = $("#countListaCargo").val();
    if (count == 0) {
        $(function () { $(".tDefault thead").css("display", "none"); });
    }

    $("#GrillaCargos tfoot tr:last td").prepend("<a id='tfootPage' class='total_registros'></a>");
    $("#tfootPage").html($('#hdfTotalRegistros').val());
    $("#GrillaCargos tfoot tr a, #GrillaCargos thead tr a").live("click", function (e) {
        var url = $(this).attr('href');
        var vIdPerfil = $("#ID_IdPerfil").val();
        var vNombreCargo = $("#NombreCargo_AutoComplete").val();
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
        newurl = queue + "page=" + page + "&sort=" + sort + "&sortdir=" + sortdir +
            "&IdPerfil=" + vIdPerfil + "&NombreCargo=" + vNombreCargo

        $(this).attr('href', newurl);
    });
}

var vIdCargo
function DialogEliminarCargo(IdCargo, TipoPerfil) {
    vIdCargo = IdCargo
    if (TipoPerfil == 2) {
        InicioJPopUpOpen('#dialogEliminarCargoJefe');
    }
    else {
        InicioJPopUpOpen('#dialogEliminarCargoOtros');
    }

}
function EliminarCargo() {
    var ParamUrl = CreateUrl("EliminarCargo", "Mantenimiento")
    $.ajax({
        url: ParamUrl,
        data: {
            IdCargo: vIdCargo
        },
        type: "post",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $('#dialogEliminarCargo').dialog("close");
            var result = data.split("/");
            if (result[0] == 1 || result[0] == "1") {
                BuscarCargo()
            }
            InicioJPopUpAlert(result[1], null);
        },
        error: function (jqXhr, textStatus, errorThrown) {
        }
    });
}

function DialogCancelarRegistroCargo() {
    InicioJPopUpOpen('#dialogCancelarRegistroCargo');
}
function CancelarRegistroCargo() {
    $('#dialogGestionarCargo').dialog('close');
}
var VarIdCargoSuperior
//dialogGestionarPerfil: Abre el popUP con el combobox actualizado, usado al dar clic en el boton Nuevo Perfil
function dialogGestionarCargo() {
    VarIdCargoSuperior = 0
    var ParamUrl = CreateUrl("GestionarCargo", "Mantenimiento")
    $("#HD_IdCargo").val()
    $.ajax({
        url: ParamUrl,
        data: {
        },
        type: "get",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#dialogGestionarCargo").html(data);
            $("#ID_IdPerfil_Cargo").uniform();
            $("#ID_CargoSuperior").uniform();
            $("#Id_Comisiona").uniform();
            $("#ID_ZonaCargo").uniform();
            InicioJPopUpOpen('#dialogGestionarCargo');
        },
        error: function (jqXhr, textStatus, errorThrown) {
        }
    });

}
//dialogGestionarPerfil: Abre el popUP con el combobox actualizado, usado al dar clic en el boton editar Perfil, setea valores al perfil

function EditarCargo(IdCargo, IdCargoSuperior, NombreCargo, IdZona, Comisiona, IdPerfil, TipoPerfil) {
    var ParamUrl = CreateUrl("GestionarCargo", "Mantenimiento")
    VarIdCargoSuperior = IdCargoSuperior
    $.ajax({
        url: ParamUrl,
        data: {
            Comisiona: Comisiona,
            TipoPerfil: TipoPerfil,
            IdCargo: IdCargo
        },
        type: "get",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#dialogGestionarCargo").html(data);
            $("#ID_IdPerfil_Cargo").uniform();
            $("#ID_CargoSuperior").uniform();
            $("#ID_ZonaCargo").uniform();
            $("#Id_Comisiona").uniform();
            InicioJPopUpOpen('#dialogGestionarCargo');
            $("#HD_IdCargo").val(IdCargo)
            $("#NombreCargo").val(NombreCargo)
            $("#ID_IdPerfil_Cargo option[value=" + IdPerfil + "]").attr("selected", "selected").change();
            $("#ID_ZonaCargo option[value=" + IdZona + "]").attr("selected", "selected").change();
        },
        error: function (jqXhr, textStatus, errorThrown) {
        }
    });
}

function RegistrarCargo() {
    $("#ID_CargoSuperior").attr("class", "ignorefield");
    $("#frmGestionarCargo").each(function () { $.data($(this)[0], 'validator', false); });
    $.validator.unobtrusive.parse("#frmGestionarCargo");
    if ($('#frmGestionarCargo').valid()) {
        $('#dialogRegistrarCargo').dialog('open');
    }
}
function GuardarCargo() {
    var form = $('#frmGestionarCargo');
    $.ajax({
        url: form.attr('action'),
        type: "POST",
        data: form.serialize(),
        success: function (data) {
            var result = data.split("/");
            if (result[0] == 1 || result[0] == 2) {
                $('#dialogGestionarCargo').dialog("close");
                BuscarCargo()
            }
            InicioJPopUpAlert(result[1], null);
        },
        error: function (jqXhr, textStatus, errorThrown) {
        }
    });

}




function ListarCargosByPerfil() {
    var vIdPerfil = $("#ID_IdPerfil_Cargo").val();
    var ParamUrl = CreateUrl("ListaCargo_ByPerfil", "Mantenimiento")
    $.ajax({
        url: ParamUrl,
        data: {
            IdPerfil: vIdPerfil
        },
        type: "post",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#Div_ListaCargosByPerfil").html(data);
            $("#ID_CargoSuperior").uniform();
            $("#ID_CargoSuperior").attr("class", "ignorefield");
            if (VarIdCargoSuperior > 0)
                $("#ID_CargoSuperior option[value=" + VarIdCargoSuperior + "]").attr("selected", "selected").change();
        },
        error: function (jqXhr, textStatus, errorThrown) {
        }
    });
}

//////////////////////////////

//var vnombrecargo;
//var vnombrezona;
//function MostrarNombrePerfilInferior() {
//    var ParamURL = CreateUrl("Seleccionar_PerfilMayor_Menor", "Mantenimiento")
//    var vPerfil = $("#ID_IdPerfil_Cargo").val();
//    // var vnombrezona = $("#ID_ZonaCargo").text();

//    if (vPerfil > 0) {
//        $.ajax({
//            url: ParamURL,
//            data: {
//                IdPerfil: vPerfil
//            },
//            type: "POST",
//            cache: false,
//            success: function (data, textStatus, jqXHR) {
//                if ($("#ID_ZonaCargo").val() == "") {
//                    $("#NombreCargoInferior").val(data + ' ');
//                    $("#Id_NombreInferior").val(data);
//                } else if ($("#ID_IdPerfil_Cargo").val() == "") {
//                    $("#NombreCargoInferior").val("");
//                    $("#Id_NombreInferior").val("");
//                } else {
//                    $("#NombreCargoInferior").val(data + " - " + vnombrezona);
//                    $("#Id_NombreInferior").val(data);

//                }


//            }
//        })
//    }
//    else if (vPerfil=="") {
//        $("#NombreCargo").val("" + vnombrezonaa);
//    
//    }
//   }
// 
//function MostrarZonaVendedor() {
//    var vTextoZona = $("#ID_ZonaCargo :selected").text();
//    vnombrezona = vTextoZona;
//    vnombrecargo = $("#Id_NombreInferior").val();
//    if ($("#ID_ZonaCargo").val() == "") {
//        $("#NombreCargoInferior").val(vnombrecargo + " " + ' ')
//    } else {
//        $("#NombreCargoInferior").val(vnombrecargo + " - " + vnombrezona)
//     }
//   
// }
var vnombrecargo;
var vnombrezona;
function MostrarNombrePerfilInferior() {
    var ParamURL = CreateUrl("Seleccionar_PerfilMayor_Menor", "Mantenimiento")
    var vPerfil = $("#ID_IdPerfil_Cargo").val();
    // var vnombrezona = $("#ID_ZonaCargo").text();

    if (vPerfil > 0) {
        $.ajax({
            url: ParamURL,
            data: {
                IdPerfil: vPerfil
            },
            type: "POST",
            cache: false,
            success: function (data, textStatus, jqXHR) {
                if ($("#ID_ZonaCargo").val() == "") {
                    $("#NombreCargoInferior").val(data + ' ');
                    $("#Id_NombreInferior").val(data);
                } else if ($("#ID_IdPerfil_Cargo").val() == "") {
                    $("#NombreCargoInferior").val("");
                    $("#Id_NombreInferior").val("");
                } else {
                    $("#NombreCargoInferior").val(data + " - " + vnombrezona);
                    $("#Id_NombreInferior").val(data);

                }


            }
        })
    }
    else if (vPerfil == "") {
        $("#NombreCargo").val("" + vnombrezonaa);

    }
}

function MostrarZonaVendedor() {
    var vTextoZona = $("#ID_ZonaCargo :selected").text();
    vnombrezona = vTextoZona;
    vnombrecargo = $("#Id_NombreInferior").val();
    if ($("#ID_ZonaCargo").val() == "") {
        $("#NombreCargoInferior").val(vnombrecargo + " " + '')
    } else {
        $("#NombreCargoInferior").val(vnombrecargo + " - " + vnombrezona)
    }

}


//////////////////////////////TERMINO SCRIPT PARA MOSTRAR NOMBREPERFIL INFERIOR  /////////////////////////////////



/* AHORA ZONASSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS***********************************************************************************************************************************/
$(function () {
    $.ajaxSetup({ type: "POST" });
    var ParamUrl = CreateUrl("Autocompletado_Zona", "Mantenimiento")
    $('#NombreZona_AutoComplete').autocomplete(ParamUrl, {
        dataType: 'json',
        parse: function (data) {
            var rows = new Array();
            for (var i = 0; i < data.length; i++) {
                rows[i] = { data: data[i], value: data[i].NombreZona, result: data[i].NombreZona, id: data[i].IdZona };
            }
            return rows;
        },
        formatItem: function (row) {
            return row.NombreZona;
        },
        delay: 400,
        autofill: true,
        selectFirst: false,
        highlight: false,
        minChars: 3
        //multiple: true
    }).result(function (event, row) {
        $('#NombreZona_AutoComplete').val(row.NombreZona);
    });
});

function BuscarZona() {
    var ParamUrl = CreateUrl("ConsultarZona_PVGrilla", "Mantenimiento");
    var vNombreZona = $("#NombreZona_AutoComplete").val();
    $.ajax({
        url: ParamUrl,
        data: {
            NombreZona: vNombreZona
        },
        type: "get",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#contenedor-grid-Zona").html(data);
        },
        error: function (jqXHR, status, error) {
        }
    });
}

function SetTotalRegistrosZonas() {
    var count = $("#countListaZona").val();
    if (count == 0) {
        $(function () { $(".tDefault thead").css("display", "none"); });
    }
    $("#GrillaZonas tfoot tr:last td").prepend("<a id='tfootPage' class='total_registros'></a>");
    $("#tfootPage").html($('#hdfTotalRegistros').val());
    $("#GrillaZonas tfoot tr a, #GrillaZonas thead tr a").live("click", function (e) {
        var url = $(this).attr('href');
        var vNombreZona = $("#NombreZona_AutoComplete").val();
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
        newurl = queue + "page=" + page + "&sort=" + sort + "&sortdir=" + sortdir +
            "&NombreZona=" + vNombreZona
        $(this).attr('href', newurl);
    });
}

var vIdZona
function DialogEliminarZona(IdZona) {
    vIdZona = IdZona
    InicioJPopUpOpen('#dialogEliminarZona');
}
function EliminarZona() {
    var ParamUrl = CreateUrl("EliminarZona", "Mantenimiento")
    $.ajax({
        url: ParamUrl,
        data: {
            IdZona: vIdZona
        },
        type: "post",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $('#dialogEliminarZona').dialog("close");
            var result = data.split("/");
            if (result[0] == 1 || result[0] == "1") {
                BuscarZona()
            }
            InicioJPopUpAlert(result[1], null);
        },
        error: function (jqXhr, textStatus, errorThrown) {
        }
    });
}

function DialogCancelarRegistroZona() {
    InicioJPopUpOpen('#dialogCancelarRegistroZona');
}
function CancelarRegistroZona() {
    $('#dialogGestionarZona').dialog('close');
}

//dialogGestionarPerfil: Abre el popUP con el combobox actualizado, usado al dar clic en el boton Nuevo Perfil
function dialogGestionarZona() {
    var ParamUrl = CreateUrl("GestionarZona", "Mantenimiento")
    $("#HD_IdZona").val()
    $.ajax({
        url: ParamUrl,
        data: {
        },
        type: "get",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#dialogGestionarZona").html(data);
            $("#Id_IsNacional").uniform();
            InicioJPopUpOpen('#dialogGestionarZona');
        },
        error: function (jqXhr, textStatus, errorThrown) {
        }
    });
}
//dialogGestionarPerfil: Abre el popUP con el combobox actualizado, usado al dar clic en el boton editar Perfil, setea valores al perfil

function EditarZona(IdZona, NombreZona, IsNacional) {
    var ParamUrl = CreateUrl("GestionarZona", "Mantenimiento")
    var varIdZona = IdZona
    $.ajax({
        url: ParamUrl,
        data: {
            IdZona: IdZona,
            IsNacional: IsNacional
        },
        type: "get",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#dialogGestionarZona").html(data);
            InicioJPopUpOpen("#dialogGestionarZona");
            $("#Id_IsNacional").uniform();
            $("#Id_IsNacional:checked").val();
            $("#HD_IdZona").val(varIdZona);
            $("#NombreZona").val(NombreZona);

            var $widget = $("#Sucursal_CodigosSucursales").multiselect(),
                state = true;
            if ($("#Id_IsNacional").is(":checked")) {
                state = false;
                $widget.multiselect(state ? 'disable' : 'enable');
            }
            else {
                state = false;
                $widget.multiselect(state ? 'disable' : 'enable');
            }
        },
        error: function (jqXhr, textStatus, errorThrown) {
        }
    });
}


function RegistrarZona() {
    $("#frmGestionarZona").each(function () { $.data($(this)[0], 'validator', false); });
    $.validator.unobtrusive.parse("#frmGestionarZona");
    if ($('#frmGestionarZona').valid()) {
        $('#dialogRegistrarZona').dialog('open');
    }
}
function GuardarZona() {
    var vIdZona = $("#HD_IdZona").val()
    var vIsNacional = $("#Id_IsNacional:checked").val()
    var vNombreZona = $("#NombreZona").val()
    var ArraySucursales = $("#ID_Sucursales").val()
    if (ArraySucursales == null) {
        ArraySucursales = ''
    }
    var Sucursales = ArraySucursales.toString()
    var form = $('#frmGestionarZona');
    var ParamURL = CreateUrl("GestionarZona_", "Mantenimiento")
    $.ajax({
        url: ParamURL,
        type: "POST",
        data: form.serialize(),
        success: function (data) {
            var result = data.split("/");
            if (result[0] == 1 || result[0] == 2) {
                $('#dialogGestionarZona').dialog("close");
                BuscarZona()
            }
            InicioJPopUpAlert(result[1], null);
        },
        error: function (jqXhr, textStatus, errorThrown) {
        }
    });
}

function IsNacional() {
    var $widget = $("#ID_Sucursales").multiselect(),
        state = false;
    if ($("#Id_IsNacional").is(":checked")) {
        state = true;
        $widget.multiselect(state ? 'disable' : 'enable');
        //  $("#Id_IsNacional").val(state)
    }
    else {
        state = false;
        $widget.multiselect(state ? 'disable' : 'enable');
        //   $("#Id_IsNacional").val(state)
    }

    var vIdZona = $("#HD_IdZona").val()
    var vIsNacional = $("#Id_IsNacional:checked").val()
    var Check;
    if (vIsNacional == "true") {
        Check = 1;
    } else {
        Check = 0;
    }

    var ParamUrl = CreateUrl("GestionarZonaNacional", "Mantenimiento")
    //  $("#HD_IdZona").val()
    //var ddlSucursales = $("#Sucursal_CodigosSucursales");
    //ddlSucursales.empty();    
    $.ajax({
        url: ParamUrl,
        data: {
            IdZona: vIdZona,
            IsNacional: Check
        },
        type: "get",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $('#PVZona_Combo').html(data);
            //    $("#dialogGestionarZona").html(data);          
            //    $("#Id_IsNacional").uniform();
        },
        error: function (jqXhr, textStatus, errorThrown) {
        }
    });
}



function ShowHideTextBox() {
    if ($("#ID_PerfilTipo").val() == 2) {
        $("#divmostrarid").show();
    }
    else {
        $("#divmostrarid").hide();
    }
};

//     }else if ($("#ID_PerfilTipo").val() == 4) {
//         $("#divmostrarid").show();
//     }

/////////////**********************************************        MANTENIMIENTO DE GRUPOS    *****************************************///////////////

$(function () {
    $.ajaxSetup({ type: "POST" });
    var ParamUrl = CreateUrl("Autocompletado_Grupo", "Mantenimiento")
    $('#NombreGrupo_AutoComplete').autocomplete(ParamUrl, {
        dataType: 'json',
        parse: function (data) {
            var rows = new Array();
            for (var i = 0; i < data.length; i++) {
                rows[i] = { data: data[i], value: data[i].NombreGrupo, result: data[i].NombreGrupo, id: data[i].IdGrupo };
            }
            return rows;
        },
        formatItem: function (row) {
            return row.NombreGrupo;
        },
        delay: 400,
        autofill: true,
        selectFirst: false,
        highlight: false,
        minChars: 3
    }).result(function (event, row) {
        $('#NombreGrupo_AutoComplete').val(row.NombreGrupo);
    });
});


function BuscarGrupo() {
    var ParamUrl = CreateUrl("ConsultarGrupo_PVGrilla", "Mantenimiento")
    var vNombreGrupo = $("#NombreGrupo_AutoComplete").val();
    $.ajax({
        url: ParamUrl,
        data: {
            NombreGrupo: vNombreGrupo
        },
        type: "get",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#contenedor-grid-Grupo").html(data);
        },
        error: function (jqXHR, status, error) {
        }
    });
}
function SetTotalRegistrosGrupo() {
    var count = $("#countListaGrupo").val();
    if (count == 0) {
        $(function () { $(".tDefault thead").css("display", "none"); });
    }
    $("#GrillaGrupo tfoot tr:last td").prepend("<a id='tfootPage' class='total_registros'></a>");
    $("#tfootPage").html($('#hdfTotalRegistros').val());
    $("#GrillaGrupo tfoot tr a, #GrillaGrupo thead tr a").live("click", function (e) {
        var url = $(this).attr('href');
        var vNombreZona = $("#NombreGrupo_AutoComplete").val();
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
        newurl = queue + "page=" + page + "&sort=" + sort + "&sortdir=" + sortdir +
            "&NombreGrupo=" + vNombreGrupo
        $(this).attr('href', newurl);
    });
}

function GuardarGrupo() {
    var vIdGrupo = $("#HD_IdGrupo").val();
    var vNombreGrupo = $("#NombreGrupo").val();
    var Clientes = checksClientes.toString();
    var form = $('#frmGestionarGrupo');
    var ParamURL = CreateUrl("GestionarGrupo_", "Mantenimiento")
    $.ajax({
        url: ParamURL,
        type: "POST",
        data: {
            IdGrupo: vIdGrupo,
            NombreGrupo: vNombreGrupo,
            IdClientes: Clientes
        },
        success: function (data) {
            var result = data.split("/");
            if (result[0] == 1 || result[0] == 2) {
                $('#dialogGestionarGrupo').dialog("close");
                checksClientes = null;
                BuscarGrupo();
            }
            InicioJPopUpAlert(result[1], null);
        },
        error: function (jqXhr, textStatus, errorThrown) {
        }
    });
}


function dialogGestionarGrupo() {
    var ParamUrl = CreateUrl("GestionarGrupo", "Mantenimiento")

    $.ajax({
        url: ParamUrl,
        data: {
        },
        type: "GET",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#dialogGestionarGrupo").html(data);

            InicioJPopUpOpen('#dialogGestionarGrupo');
        },
        error: function (jqXhr, textStatus, errorThrown) {
        },
    });
}

var vIdGrupo
function DialogEliminarGrupo(IdGrupo) {
    vIdGrupo = IdGrupo
    InicioJPopUpOpen('#dialogEliminarGrupo');
}
function EliminarGrupo() {
    var ParamUrl = CreateUrl("EliminarGrupo", "Mantenimiento")
    $.ajax({
        url: ParamUrl,
        data: {
            IdGrupo: vIdGrupo
        },
        type: "POST",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $('#dialogEliminarGrupo').dialog("close");
            var result = data.split("/");
            if (result[0] == 1 || result[0] == "1") {
                BuscarGrupo()
            }
            InicioJPopUpAlert(result[1], null);
        },
        error: function (jqXhr, textStatus, errorThrown) {
        }
    });
}

function EditaGrupo(IdGrupo, NombreGrupo) {
    var ParamUrl = CreateUrl("GestionarGrupo", "Mantenimiento");
    var varIdGrupo = IdGrupo;
    $.ajax({
        url: ParamUrl,
        data: {
            IdGrupo: IdGrupo
        },
        type: "get",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#dialogGestionarGrupo").html(data);
            InicioJPopUpOpen("#dialogGestionarGrupo");
            $("#HD_IdGrupo").val(varIdGrupo);
            $("#NombreGrupo").val(NombreGrupo);
            //            var $widget = $("#ID_Clientes").multiselect(),
            //            state = true;
            PintarCajaClientes();
        },
        error: function (jqXhr, textStatus, errorThrown) {
        }
    });
}


function RegistrarGrupo() {

    $("#frmGestionarGrupo").each(function () { $.data($(this)[0], 'validator', false); });
    $.validator.unobtrusive.parse("#frmGestionarGrupo");
    var IdGrupo = $("#HD_IdGrupo").val();
    var NomGrupo = $("#NombreGrupo").val();
    var valida_ = "";
    var valida_2 = "";
    // var valida_=ValidaCamposClientes();
    if (NomGrupo != "") {
        valida_2 = true;
        $("#validaNomGrupo > span").text("");
    }
    else {
        $("#validaNomGrupo > span").text("Campo requerido");
        valida_2 = false;
    }

    if ($('#chosen-choices li').length == 1) {
        $("#validaClient > span").text("Campo requerido");
        valida_ = false;
    }
    else {

        $("#validaClient > span").text("");
        valida_ = true;
    }

    if (valida_2 && valida_) {
        if (IdGrupo == 0 || IdGrupo == '0') {
            $('#dialogRegistrarGrupo').dialog('open');
        }
        else {
            $('#dialogActualizarGrupo').dialog('open');
        }

    }
}

function DialogCancelarRegistroGrupo() {
    InicioJPopUpOpen('#dialogCancelarRegistroGrupo');
}
function CancelarRegistroGrupo() {
    $('#dialogGestionarGrupo').dialog('close');
}

function dialogRegresarMantenimientoGrupo() {
    InicioJPopUpOpen('#dialogRegresarMantenimientoGrupo');
}
function CancelarMantenimientoGrupo() {
    RedireccionarCancelarMantenimientoGrupo();
}


function RedireccionarCancelarMantenimientoGrupo() {
    window.location.href = "/Mantenimiento/BuscarGrupo";
}

///////////////////////////////////////   TERMINA GRUPO              /////////////////////////////////////////////////

function ValidaCamposClientes() {
    var valida = true;
    var validaControl = true;
    var ID_Clientes = $("#ID_Clientes").multiselect();
    //   var vId_TiempoServicio = $("#Id_TiempoNuevo").val();
    if (ID_Clientes != 'SELECCIONE') {
        replaceErrorMessagge("ID_MsgClientes", "");
        replaceErrorMessagge("ID_MsgClientes", "");
        valida = true;
    }
    else {
        replaceErrorMessagge("ID_MsgClientes", "Seleccione clientes");
        replaceErrorMessagge("ID_MsgClientes", "");
        valida = false;
    }
    return valida;
}

function replaceErrorMessagge(IdDiv, Message) {
    $("#" + IdDiv).replaceWith('<div style="color: #EC6464; font-size:9px;" id="' + IdDiv + '">' + Message + '</div>');
}

function SetTotalRegistrosClientesGrupo() {
    var count = $("#countListaGrupo").val();
    if (count == 0) {
        $(function () { $(".tDefault thead").css("display", "none"); });
    }
    $("#dgvDatos tfoot tr:last td").prepend("<a id='tfootPage' class='total_registros'></a>");
    $("#tfootPage").html($('#hdfTotalRegistros').val());

    $(function () {
        $('th a, tfoot a').live('click', function () {
            $(this).attr('href', '#dgvDatos');
            return false;
        });
    });

    $("#dgvDatos tfoot tr a, #dgvDatos thead tr a").live("click", function (e) {
        var IdCliente = $("#IdCliente").val();
        var url = $(this).attr('href');
        var page = 1;
        var sort = "";
        var sortdir = "";
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
        newurl = queue + "page=" + page + "&sort=" + sort + "&sortdir=" + sortdir + "&IdCliente=" + IdCliente
        $(this).attr('href', newurl);
    });
}


function ListarClientesGrupo() {
    var vUrl = $("#ID_UrlPVListaClientes_Grupo").val();
    var vIdGrupo = $("#ID_IdGrupo").val();
    $.ajax({
        url: vUrl,
        data: { IdGrupo: vIdGrupo },
        type: "get",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#divListaClientesGrupo").html(data)
        },
        error: function (jqXHR, status, error) {
        },
        complete: function () {

        }
    })
}

////////////***********************************************  TERMINO    ****************************************************************//////////////

//*** mostrar texto ***//////////
function validaTipoPerfil() {
    var vtextomostrar = $("#divTextotodo").val();
    var ParamURL = CreateUrl("Seleccion_tipoPerfil", "Mantenimiento")
    var vidperfil = $("#ID_IdPerfil_Cargo").val();
    var vresultado = $("#resultado").val();
    $.ajax({
        url: ParamURL,
        data: {
            IdPerfil: vidperfil
        },
        type: "POST",
        cache: false,
        async: false,
        success: function (data, textStatus, jqXHR) {
            var vresultado = data;
            if (vidperfil != 0) {
                if (vresultado == 2) {
                    $("#divTextotodo").show();
                } else {
                    $("#divTextotodo").hide();
                }
            }
            else {
                $("#divTextotodo").hide();
            }
        }
    })
};

//AHORA SUCURSAL
$(function () {
    $.ajaxSetup({ type: "POST" });
    var ParamUrl = CreateUrl("Autocompletado_Sucursal", "Mantenimiento")
    $('#NombreSucursal_AutoComplete').autocomplete(ParamUrl, {
        dataType: 'json',
        parse: function (data) {
            var rows = new Array();
            for (var i = 0; i < data.length; i++) {
                rows[i] = { data: data[i], value: data[i].Descripcion, result: data[i].Descripcion, id: data[i].IdSucursal };
            }
            return rows;
        },
        formatItem: function (row) {
            return row.Descripcion;
        },
        delay: 400,
        autofill: true,
        selectFirst: false,
        highlight: false,
        minChars: 3
        //multiple: true
    }).result(function (event, row) {
        $('#NombreSucursal_AutoComplete').val(row.Descripcion);
    });
});
function BuscarSucursal() {
    var ParamUrl = CreateUrl("ConsultarSucursales_PVGrilla", "Mantenimiento");
    var vNombreSucursal = $("#NombreSucursal_AutoComplete").val();
    var vIdZona = $("#ID_IdZona").val();
    $.ajax({
        url: ParamUrl,
        data: {
            Descripcion: vNombreSucursal,
            IdZona: vIdZona
        },
        type: "get",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#contenedor-grid-Sucursal").html(data);
        },
        error: function (jqXHR, status, error) {
        }
    });
}

function SetTotalRegistrosSucursal() {

    var count = $("#countListaSucursal").val();
    if (count == 0) {
        $(function () { $(".tDefault thead").css("display", "none"); });
    }

    $("#GrillaSucursales tfoot tr:last td").prepend("<a id='tfootPage' class='total_registros'></a>");
    $("#tfootPage").html($('#hdfTotalRegistros').val());
    $("#GrillaSucursales tfoot tr a, #GrillaSucursales thead tr a").live("click", function (e) {
        var url = $(this).attr('href');
        var vNombreSucursal = $("#NombreSucursal_AutoComplete").val();
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
        newurl = queue + "page=" + page + "&sort=" + sort + "&sortdir=" + sortdir +
            "&Descripcion=" + vNombreSucursal
        $(this).attr('href', newurl);
    });
}

/* =====   CARGAR COMBOS PROVINCIA ===============*/

function CargarProvincia() {
    var vUrl = $("#UrlProvincia").val();
    var vIdDepartamento = $("#ID_IdDepartamento").val();
    if (vIdDepartamento == "") { vIdDepartamento = 0; }
    $.ajax({
        url: vUrl,
        type: "POST",
        data: {
            IdDepartamento: vIdDepartamento
        },
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#divListaComboProvincia").html(data);
        },
        complete: function () {
            var vProv = document.getElementById("ID_Provincia");
            vProv.removeEventListener("change", CargarDistrito(), false);
            $('#ID_Provincia').uniform();
        }
    });
}



/* =====   CARGAR COMBOS DISTRITO ===============*/

function CargarDistrito() {
    var vUrl = $("#UrlDistrito").val();
    var ID_Provincia = $("#ID_Provincia").val();
    if (ID_Provincia == "") { ID_Provincia = 0; }
    $.ajax({
        url: vUrl,
        type: "POST",
        data: {
            IdProvincia: ID_Provincia
        },
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $('#divListaComboDistrito').html(data);
        },
        complete: function () {
            $('#ID_Distrito').uniform();
        }
    });
}



/*=========== ABRE EL POPUP DEL DE GESTIONAR SUCURSAL  */

function dialogGestionarSucursal() {
    VarIdCargoSuperior = 0
    var ParamUrl = CreateUrl("GestionarSucursal", "Mantenimiento")
    $("#HD_IdSucursal").val()
    $.ajax({
        url: ParamUrl,
        data: {
        },
        type: "get",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#dialogGestionarSucursal").html(data);
            $("#ID_IdDepartamento").uniform();
            $("#Direccion").uniform();
            $("#Telefono").uniform();
            // $("#ID_ZonaCargo").uniform();
            $("#ID_Provincia").uniform();
            $("#ID_Distrito").uniform();
            InicioJPopUpOpen('#dialogGestionarSucursal');
        },
        error: function (jqXhr, textStatus, errorThrown) {
        }
    });

}


/*========  ABRE EL POPUP PARA EDITAR LA SUCURSAL ==================*/
function EditarSucursal(IdSucursal, Descripcion, IdDepartamento, IdProvincia, IdDistrito, DescripcionCorta, Direccion) {
    var ParamUrl = CreateUrl("GestionarSucursal", "Mantenimiento")
    $.ajax({
        url: ParamUrl,
        data: {
            //Comisiona: Comisiona
        },
        type: "get",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#dialogGestionarSucursal").html(data);
            $("#ID_IdDepartamento").uniform();
            $("#ID_Provincia").uniform();
            $("#ID_Distrito").uniform();

            //$("#Id_Comisiona").uniform();
            InicioJPopUpOpen('#dialogGestionarSucursal');
            $("#HD_IdSucursal").val(IdSucursal)
            $("#Descripcion").val(Descripcion)
            $("#ID_IdDepartamento option[value=" + IdDepartamento + "]").attr("selected", "selected").change();
            $("#ID_Provincia option[value=" + IdProvincia + "]").attr("selected", "selected").change();
            $("#ID_Distrito option[value=" + IdDistrito + "]").attr("selected", "selected").change();
            // $("#ID_DescripcionCorta").val(DescripcionCorta)
            // $("#Direccion").val(Direccion)

            //   $("#Telefono").val(Telefono)
            //             $("#NombreCargoInferior").val(DescripcionCorta)
            //             $("#ID_IdPerfil_Cargo option[value=" + IdPerfil + "]").attr("selected", "selected").change();
            //             $("#ID_ZonaCargo option[value=" + IdZona + "]").attr("selected", "selected").change();
        },
        error: function (jqXhr, textStatus, errorThrown) {
        }
    });
}


function DialogCancelarRegistroSucursal() {
    InicioJPopUpOpen('#dialogCancelarRegistroSucursal');
}
function CancelarRegistroSucursal() {
    $('#dialogGestionarSucursal').dialog('close');
}


function dialogEliminarSucursal(IdSucursal) {
    vIdSucursal = IdSucursal
    InicioJPopUpOpen('#dialogEliminarSucursal');
}

function EliminarSucursal() {
    var ParamUrl = CreateUrl("EliminarSucursal", "Mantenimiento")
    $.ajax({
        url: ParamUrl,
        data: {
            IdSucursal: vIdSucursal
        },
        type: "post",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $('#dialogEliminarSucursal').dialog("close");
            var result = data.split("/");
            if (result[0] == 1 || result[0] == "1") {
                BuscarSucursal()
            }
            InicioJPopUpAlert(result[1], null);
        },
        error: function (jqXhr, textStatus, errorThrown) {
        }
    });
}

function RegistrarSucursal() {

    $("#frmGestionarSucursal").each(function () { $.data($(this)[0], 'validator', false); });
    $.validator.unobtrusive.parse("#frmGestionarSucursal");

    if ($('#frmGestionarSucursal').valid()) {
        $('#dialogRegistrarSucursal').dialog('open');
    }
}

function GuardarSucursal() {
    var form = $('#frmGestionarSucursal');
    $.ajax({
        url: form.attr('action'),
        type: "POST",
        data: form.serialize(),
        success: function (data) {
            var result = data.split("/");
            if (result[0] == 1 || result[0] == 2) {
                $('#dialogGestionarSucursal').dialog("close");
                BuscarCargo()
            }
            InicioJPopUpAlert(result[1], null);
        },
        error: function (jqXhr, textStatus, errorThrown) {
        }
    });
}

// 
//function SetTotalRegistrosClientes() {
//    var count = $("#countListaGrupo").val();
//    if (count == 0) {
//        $(function () { $(".tDefault thead").css("display", "none"); });
//    }
//    $("#dgvDatos tfoot tr:last td").prepend("<a id='tfootPage' class='total_registros'></a>");
//    $("#tfootPage").html($('#hdfTotalRegistros').val());

//    $(function() {
//        $('th a, tfoot a').live('click', function () {
//            $(this).attr('href', '#dgvDatos');
//            return false;
//        });
//    });

//    $("#dgvDatos tfoot tr a, #dgvDatos thead tr a").live("click", function (e) {
//        var IdCliente = $("#IdCliente").val();
//        var url = $(this).attr('href');
//        var page = 1;
//        var sort = "";
//        var sortdir = "";
//        var queue = "";

//        var arr = new Array()
//        arr = url.split("?")
//        queue = arr[0].toString() + "?";
//        arr = arr[1].toString().split("&")

//        for (var i = 0; i <= arr.length - 1; i++) {
//            if (arr[i].indexOf("page") >= 0)
//                page = arr[i].toString().split("=")[1].toString();
//            if (arr[i].indexOf("sort=") >= 0)
//                sort = arr[i].toString().split("=")[1].toString();
//            if (arr[i].indexOf("sortdir") >= 0)
//                sortdir = arr[i].toString().split("=")[1].toString();

//        }
//        var newurl = "";
//        newurl = queue + "page=" + page + "&sort=" + sort + "&sortdir=" + sortdir + "&IdCliente=" + IdCliente
//        $(this).attr('href', newurl);
//    });
//}

/////////////////////========================         NUEVAS QUERYS CARGOS  =====================================////////////////////////

var vperfilsele;
var vnombrezonaa;
function MostrarValorSeleccionado() {
    //var vvalorPerfil = $("#ID_IdPerfil_Cargo").val(vTexto);
    var vTexto = $("#ID_IdPerfil_Cargo :selected").text();
    vperfilsele = vTexto;
    if ($("#ID_ZonaCargo").val() == "") {
        $("#NombreCargo").val(vperfilsele + ' ')
    } else if ($("#NombreCargo").val() == "") {
        $("#NombreCargo").val(vnombrezonaa)
    } else {
        $("#NombreCargo").val(vperfilsele + " - " + vnombrezonaa)
    }
}

function MostrarZonaSeleccionado() {
    var vTextoZona = $("#ID_ZonaCargo :selected").text();
    vnombrezonaa = vTextoZona;
    if ($("#ID_ZonaCargo").val() == "") {
        $("#NombreCargo").val(vperfilsele + " " + '')
    } else {
        $("#NombreCargo").val(vperfilsele + " - " + vnombrezonaa)
    }

}

//Modificación Mantenimiento Grupo 06 01 2014

function BuscarClientes_Grupo() {
    var vUrl = $("#HdnUrlClienteGrupo").val();
    //    var vRazonSocial = encodeURI($.trim($("#ID_RazonSocial").val()));
    var vRazonSocial = $.trim($("#ID_RazonSocial").val());
    var page = 1;
    var sort = "";
    var sortdir = "";
    var queue = "";
    var newurl = ""
    $.ajax({
        url: vUrl,
        type: "POST",
        data: {
            RazonSocial: vRazonSocial
        },
        success: function (data) {
            $("#divListaClientes").html(data);
            PreSetting();
        },
        error: function (er) {
        },
        complete: function () {
        }
    });
}

function PreSetting() {
    var vUrl = $("#HdnUrlClienteGrupo").val();
    var vRazonSocial = encodeURI($.trim($("#ID_RazonSocial").val()));
    //        var vRazonSocial = $.trim($("#ID_RazonSocial").val());
    var page = 1;
    var sort = "";
    var sortdir = "";
    var queue = "";
    var newurl = ""
    newurl = vUrl + "?page=" + page + "&sort=" + sort + "&sortdir=" + sortdir +
        "&RazonSocial=" + vRazonSocial;
    $("#dgvDatosClienteGrupo").append('<a href="" id="hide-link" style="display:none" >hide</a>')
    $("#hide-link").attr("data-swhglnk", true)
    $("#hide-link").attr("href", newurl).click();
}

function SetTotalRegistrosClientes() {
    var count = $("#Cli_RowCount").val();
    if (count == 0) {
        $(function () { $(".tDefault thead").css("display", "none"); });
        $("#dgvDatosClienteGrupo").css('display', 'none');
        $("#dialogGestionarGrupo").dialog("option", "height", 350);
    } else {
        var height = count >= 5 ? 650 : 350 + 50 * count;
        $("#dgvDatosClienteGrupo thead tr th:nth-child(1)").hide();
        $("#dgvDatosClienteGrupo").css('display', '');
        $("#dialogGestionarGrupo").dialog("option", "height", height);
    }
    $("#dialogGestionarGrupo").dialog("option", "position", "center");
    $("#dgvDatosClienteGrupo tfoot tr:last td").prepend("<a id='tfootPage' class='total_registros'></a>");
    $("#tfootPage").html($('#HdnTotalRegistros').val());
    PintarChecksGrillaClientes();
    $(function () {
        $('th a, tfoot a').live('click', function () {
            $(this).attr('href', '#dgvDatosClienteGrupo');
            return false;
        });
    });

    $("#dgvDatosClienteGrupo tfoot tr a, #dgvDatosClienteGrupo thead tr a").live("click", function (e) {
        //        var RazonSocial = encodeURI($.trim($("#ID_RazonSocial").val()));
        var RazonSocial = $.trim($("#ID_RazonSocial").val());
        var url = $(this).attr('href');
        var page = 1;
        var sort = "";
        var sortdir = "";
        var queue = "";

        var arr = new Array();
        arr = url.split("?");
        queue = arr[0].toString() + "?";
        arr = arr[1].toString().split("&");

        for (var i = 0; i <= arr.length - 1; i++) {
            if (arr[i].indexOf("page") >= 0)
                page = arr[i].toString().split("=")[1].toString();
            if (arr[i].indexOf("sort=") >= 0)
                sort = arr[i].toString().split("=")[1].toString();
            if (arr[i].indexOf("sortdir") >= 0)
                sortdir = arr[i].toString().split("=")[1].toString();

        }
        var newurl = "";
        newurl = queue + "page=" + page + "&sort=" + sort + "&sortdir=" + sortdir + "&RazonSocial=" + RazonSocial;
        $(this).attr('href', newurl);
        if (checksClientes.length > 0) {
            MemoryChecks($("#PagePreview").val(), false);
        }
        //        $("#PagePreview").val(page);        
        //        $(".chosen-select").chosen();
        e.preventDefault();
    });
    //    if (checksClientes.length > 0) {
    //        CargarChecks($("#PagePreview").val());
    //    }
}

function PintarHeaderGrillaClientes() {
    var RowCount = $("#Cli_RowCount").val();
    var RowsPerPage = $('#Cli_RowsPerPage').val();
    if (RowCount <= 0) {
        $("#dgvDatosClienteGrupo").css('display', 'none');
        $("#dialogGestionarGrupo").dialog("option", "height", 350);
    } else {
        var height = RowCount >= 5 ? 650 : 350 + 50 * RowCount;
        $("#dgvDatosClienteGrupo").css('display', '');
        $("#dialogGestionarGrupo").dialog("option", "height", height);
        $("#dialogGestionarGrupo").dialog("option", "position", "center");
    }
}

function CargarChecks(page) {
    var Total = parseInt($('#Cli_RowCount').val());
    var RegPag = parseInt($('#Cli_RowsPerPage').val());

    var TotalPage = 1;
    if ((Total / RegPag) > Math.round(Total / RegPag)) {
        TotalPage = Math.round(Total / RegPag) + 1;
    }
    else {
        TotalPage = Math.round(Total / RegPag);
    }

    //    for (var j = 1; j < TotalPage + 1; j++) {
    //        if (j == page) {
    //            $("#dgvDatosClienteGrupo tbody tr").each(function (i, element) {
    //                ($(element).find('td:nth-child(2) input[type=checkbox]')[0]).checked = checksClientes[((page - 1) * RegPag) + i].Check;
    //            });
    //        } 
    //    }

}

function MemoryChecks(page, PrimeraVez) {
    if (PrimeraVez) {
        var checks = [];
    } else {
        checks = checksClientes;
    }
    var Total = parseInt($('#Cli_RowCount').val());
    var RegPag = parseInt($('#Cli_RowsPerPage').val());

    var TotalPage = 1;
    if ((Total / RegPag) > Math.round(Total / RegPag)) {
        TotalPage = Math.round(Total / RegPag) + 1;
    }
    else {
        TotalPage = Math.round(Total / RegPag);
    }

    for (var w = 1; w < TotalPage + 1; w++) {
        if (w == page) {
            $("#dgvDatosClienteGrupo tbody tr").each(function (i, element) {
                var IdSucursal = ($(element).find('td:nth-child(1)')[0]).innerHTML;
                var check = ($(element).find('td:nth-child(2) input[type=checkbox]')[0]).checked;

                var Data = {
                    IdSucursal: IdSucursal,
                    Check: check
                };
                if (PrimeraVez) {
                    checks.push(Data)
                } else {
                    checks[((page - 1) * RegPag) + i] = Data;
                }
            });
        } else {
            if (TotalPage == w) {
                RegPag = RegPag + (Total - (w * RegPag));
            }
            if (PrimeraVez) {
                for (var j = 0; j < RegPag; j++) {
                    var Data = {
                        IdSucursal: '',
                        Check: false
                    };
                    checks.push(Data)
                }
            }
        }
    }
    checksClientes = checks;
}

$(function () {
    $(".chk_clientes").live("click", function () {
        $("#dgvDatosClienteGrupo tbody tr").each(function (i, element) {
            var IdCliente = ($(element).find('td:nth-child(1)')[0]).innerHTML;
            var RazonSocial = ($(element).find('label')[0]).innerHTML;
            var check = ($(element).find('td:nth-child(2) input[type=checkbox]')[0]).checked;
            if (check) {
                AgregarCliente(IdCliente, RazonSocial);
            }
            else {
                QuitarCliente(IdCliente);
            }
        });
    });
})

function AgregarCliente(IdCliente, RazonSocial) {
    //    if (checksClientes.indexOf(IdCliente)==-1){
    if ($.inArray(IdCliente, checksClientes) == -1) {
        checksClientes.push(IdCliente);
        $("#chosen-choices").append('<li id="li' + IdCliente + '"class="search-choice">');
        $("#li" + IdCliente).append('<span id="' + IdCliente + '">' + RazonSocial + '</span>');
        $("#li" + IdCliente).append('<a id="a' + IdCliente + '"class="search-choice-close" data-option-array-index=' + IdCliente + '></a>');
        $("#chosen-choices").append('</li>');
        $("#a" + IdCliente).live("click", function () {
            QuitarCliente(IdCliente);
        });
        $("#lidefault").css('display', 'none');
    }
}

function QuitarCliente(IdCliente) {
    //    var index = checksClientes.indexOf(IdCliente);
    var index = $.inArray(IdCliente, checksClientes);
    if (index > -1) {
        checksClientes.splice(index, 1);
        $("#a" + IdCliente).click();
        $("#li" + IdCliente).remove();
        $("#chk" + IdCliente).attr('checked', false);
        if (checksClientes.length == 0) {
            $("#lidefault").css('display', 'block');
        }
    }
    else
        return false;
}

function PintarChecksGrillaClientes() {
    $("#dgvDatosClienteGrupo tbody tr").each(function (i, element) {
        var IdCliente = ($(element).find('td:nth-child(1)')[0]).innerHTML;
        var check = ($(element).find('td:nth-child(2) input[type=checkbox]')[0]);
        var index = $.inArray(IdCliente, checksClientes);
        if (index > -1) {
            $("#chk" + IdCliente).attr('checked', true);
        }
    });
}

function PintarCajaClientes() {
    $("#ID_Clientes option:selected").each(function () {
        var $this = $(this);
        AgregarCliente($this.val(), $this.text());
    });

}

//SECTION COTIZACION - DescuentoFamilia

function BuscarDsctoFamilia() {
    var paramUrl = CreateUrl("ConsultarDsctoFamilia_PVGrilla", "Mantenimiento");
    var vIdFamilia = $("#ID_Familia").val();
    $.ajax({
        url: paramUrl,
        data: {
            codigoFamilia: vIdFamilia
        },
        type: "get",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#contenedor-grid-DescuentoFamilia").html(data);
        },
        error: function (jqXHR, status, error) {
        }
    });
}

function SetTotalRegistrosDescuentoFamilia() {

    var count = $("#countListaDescuentoFamilia").val();
    if (count === 0) {
        $(function () { $(".tDefault thead").css("display", "none"); });
    }

    $("#GrillaDescuentoFamilia tfoot tr:last td").prepend("<a id='tfootPage' class='total_registros'></a>");
    $("#tfootPage").html($("#hdfTotalRegistros").val());
    $("#GrillaDescuentoFamilia tfoot tr a, #GrillaDescuentoFamilia thead tr a").live("click", function (e) {
        var url = $(this).attr("href");
        var vIdFamilia = $("#ID_Familia").val();
        var sortdir = "";
        var sort = "";
        var page = 1;
        var queue = "";
        var arr = new Array();
        arr = url.split("?");
        queue = arr[0].toString() + "?";
        arr = arr[1].toString().split("&");
        for (var i = 0; i <= arr.length - 1; i++) {
            if (arr[i].indexOf("page") >= 0)
                page = arr[i].toString().split("=")[1].toString();
            if (arr[i].indexOf("sort=") >= 0)
                sort = arr[i].toString().split("=")[1].toString();
            if (arr[i].indexOf("sortdir") >= 0)
                sortdir = arr[i].toString().split("=")[1].toString();
        }
        var newurl = "";
        newurl = queue +
            "page=" +
            page +
            "&sort=" +
            sort +
            "&sortdir=" +
            sortdir +
            "&codigoFamilia=" +
            vIdFamilia;

        $(this).attr("href", newurl);
    });
}

var vIdDescuentoFamilia;
function DialogEliminarDescuentoFamilia(idDescuentoFamilia) {
    vIdDescuentoFamilia = idDescuentoFamilia;
    InicioJPopUpOpen("#dialogEliminarDescuentoFamilia");

}
function EliminarDescuentoFamilia() {
    var paramUrl = CreateUrl("EliminarDescuentoFamilia", "Mantenimiento");
    $.ajax({
        url: paramUrl,
        data: {
            codigoFamilia: vIdDescuentoFamilia
        },
        type: "post",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#dialogEliminarDescuentoFamilia").dialog("close");
            var result = data.split("/");
            if (result[0] === 1 || result[0] === "1") {
                BuscarDsctoFamilia();
            }
            InicioJPopUpAlert(result[1], null);
        },
        error: function (jqXhr, textStatus, errorThrown) {
        }
    });
}

function EditarDescuentoFamilia(codigoFamilia, margenDscto, descuento) {
    var paramUrl = CreateUrl("EditarDescuentoFamilia", "Mantenimiento");
    $.ajax({
        url: paramUrl,
        data: {
            codigoFamilia: codigoFamilia,
            margenDscto: margenDscto,
            descuento: descuento
        },
        type: "get",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#dialogGestionarDescuentoFamilia").html(data);
            $("#ID_Familia_Edit").uniform();
            InicioJPopUpOpen("#dialogGestionarDescuentoFamilia");
        },
        error: function (jqXhr, textStatus, errorThrown) {
        }
    });
}

function NuevoDescuentoFamilia() {
    var paramUrl = CreateUrl("EditarDescuentoFamilia", "Mantenimiento");
    $.ajax({
        url: paramUrl,
        data: {
            codigoFamilia: "",
            margenDscto: 0,
            descuento: 0
        },
        type: "get",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#dialogGestionarDescuentoFamilia").html(data);
            $("#ID_Familia_Edit").uniform();
            InicioJPopUpOpen("#dialogGestionarDescuentoFamilia");
        },
        error: function (jqXhr, textStatus, errorThrown) {
        }
    });
}

function DialogCancelarRegistroDescuentoFamilia() {
    InicioJPopUpOpen("#dialogCancelarRegistroDescuentoFamilia");
}

function CancelarRegistroDescuentoFamilia() {
    $("#dialogGestionarDescuentoFamilia").dialog("close");
}

function RegistrarDescuentoFamilia() {
    $("#frmEditarDescuentoFamilia").each(function () { $.data($(this)[0], "validator", false); });
    $.validator.unobtrusive.parse("#frmEditarDescuentoFamilia");
    if ($("#frmEditarDescuentoFamilia").valid()) {
        $("#dialogRegistrarDescuentoFamilia").dialog("open");
    }
}

function GuardarDescuentoFamilia() {
    var form = $("#frmEditarDescuentoFamilia");
    $.ajax({
        url: form.attr("action"),
        type: "POST",
        data: form.serialize(),
        success: function (data) {
            var result = data.split("/");
            if (result[0] === 1 || result[0] === "1" || result[0] === 2 || result[0] === "2") {
                $("#dialogGestionarDescuentoFamilia").dialog("close");
                BuscarDsctoFamilia();
            }
            InicioJPopUpAlert(result[1], null);
        },
        error: function (jqXhr, textStatus, errorThrown) {
        }
    });

}

//END SECTION COTIZACION

//SECTION COTIZACION - DescuentoSku
function BuscarDsctoSku() {
    var paramUrl = CreateUrl("ConsultarDsctoSku_PVGrilla", "Mantenimiento");
    var vIdSku = $("#Cod_Sku").val();
    $.ajax({
        url: paramUrl,
        data: {
            codigoSku: vIdSku
        },
        type: "get",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#contenedor-grid-DescuentoSku").html(data);
        },
        error: function (jqXHR, status, error) {
        }
    });
}

function SetTotalRegistrosDescuentoSku() {

    var count = $("#countListaDescuentoSku").val();
    if (count === 0) {
        $(function () { $(".tDefault thead").css("display", "none"); });
    }

    $("#GrillaDescuentoSku tfoot tr:last td").prepend("<a id='tfootPage' class='total_registros'></a>");
    $("#tfootPage").html($("#hdfTotalRegistros").val());
    $("#GrillaDescuentoSku tfoot tr a, #GrillaDescuentoSku thead tr a").live("click", function (e) {
        var url = $(this).attr("href");
        var vIdSku = $("#Cod_Sku").val();
        var sortdir = "";
        var sort = "";
        var page = 1;
        var queue = "";
        var arr = new Array();
        arr = url.split("?");
        queue = arr[0].toString() + "?";
        arr = arr[1].toString().split("&");
        for (var i = 0; i <= arr.length - 1; i++) {
            if (arr[i].indexOf("page") >= 0)
                page = arr[i].toString().split("=")[1].toString();
            if (arr[i].indexOf("sort=") >= 0)
                sort = arr[i].toString().split("=")[1].toString();
            if (arr[i].indexOf("sortdir") >= 0)
                sortdir = arr[i].toString().split("=")[1].toString();
        }
        var newurl = "";
        newurl = queue +
            "page=" +
            page +
            "&sort=" +
            sort +
            "&sortdir=" +
            sortdir +
            "&codigoSku=" +
            vIdSku;

        $(this).attr("href", newurl);
    });
}

var vIdDescuentoSku;
function DialogEliminarDescuentoSku(idDescuentoSku) {
    vIdDescuentoSku = idDescuentoSku;
    InicioJPopUpOpen("#dialogEliminarDescuentoSku");

}
function EliminarDescuentoSku() {
    var paramUrl = CreateUrl("EliminarDescuentoSku", "Mantenimiento");
    $.ajax({
        url: paramUrl,
        data: {
            codigoSku: vIdDescuentoSku
        },
        type: "post",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#dialogEliminarDescuentoSku").dialog("close");
            var result = data.split("/");
            if (result[0] === 1 || result[0] === "1") {
                BuscarDsctoSku();
            }
            InicioJPopUpAlert(result[1], null);
        },
        error: function (jqXhr, textStatus, errorThrown) {
        }
    });
}

function NuevoDescuentoSku() {
    var paramUrl = CreateUrl("EditarDescuentoSku", "Mantenimiento");
    $.ajax({
        url: paramUrl,
        data: null,
        type: "get",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#dialogGestionarDescuentoSku").html(data);
            InicioJPopUpOpen("#dialogGestionarDescuentoSku");
        },
        error: function (jqXhr, textStatus, errorThrown) {
        }
    });
}

function DialogCancelarRegistroDescuentoSku() {
    InicioJPopUpOpen("#dialogCancelarRegistroDescuentoSku");
}

function CancelarRegistroDescuentoSku() {
    $("#dialogGestionarDescuentoSku").dialog("close");
}

function RegistrarDescuentoSku() {
    $("#frmEditarDescuentoSku").each(function () { $.data($(this)[0], "validator", false); });
    $.validator.unobtrusive.parse("#frmEditarDescuentoSku");
    if ($("#frmEditarDescuentoSku").valid()) {
        $("#dialogRegistrarDescuentoSku").dialog("open");
    }
}

function GuardarDescuentoSku() {
    var form = $("#frmEditarDescuentoSku");
    $.ajax({
        url: form.attr("action"),
        type: "POST",
        data: form.serialize(),
        success: function (data) {
            var result = data.split("/");
            if (result[0] === 1 || result[0] === "1") {
                $("#dialogGestionarDescuentoSku").dialog("close");
                BuscarDsctoSku();
            }
            InicioJPopUpAlert(result[1], null);
        },
        error: function (jqXhr, textStatus, errorThrown) {
        }
    });

}
//END SECTION COTIZACION

//SECTION COTIZACION - Cotizacion Uxpos
function BuscarCotizacion() {
    var paramUrl = CreateUrl("ConsultarCotizacion_PVGrilla", "Mantenimiento");
    var vIdMarca = $("#Id_Marca").val();
    var vIdSucursal = $("#Id_Sucursal").val();
    var vIdFechaIni = $("#Id_FechaIni").val();
    var vIdFechaFin = $("#Id_FechaFin").val();
    var vIdRucRazSoc = $("#RucRazSoc").val();
    var vIdSubGerente = $("#Id_SubGerente").val();
    var vIdJefeRegional = $("#Id_JefeRegional").val();
    var vIdCodOfisisEmpleado = $("#CodOfisisEmpleado").val();
    var vIdFamilia = $("#Id_Familia").val();
    var vIdSkuProducto = $("#SkuProducto").val();
    var vIdNroCotizacion = $("#NroCotizacion").val();
    var vIdTipoProforma = $("#Id_TipoProforma").val();
    $.ajax({
        url: paramUrl,
        data: {
            codMarca: vIdMarca,
            codSucursal: vIdSucursal,
            codFechaIni: vIdFechaIni,
            codFechaFin: vIdFechaFin,
            codRucRazSoc: vIdRucRazSoc,
            codSubGerente: vIdSubGerente,
            codJefeRegional: vIdJefeRegional,
            codOfisisEmpleado: vIdCodOfisisEmpleado,
            codFamilia: vIdFamilia,
            codSkuProducto: vIdSkuProducto,
            codNroCotizacion: vIdNroCotizacion,
            codIdTipoProforma: vIdTipoProforma
        },
        type: "get",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#contenedor-grid-Cotizacion").html(data);
        },
        error: function (jqXHR, status, error) {
        }
    });
}

function SetTotalRegistrosCotizacion() {

    var count = $("#countListaCotizacion").val();
    if (count === 0) {
        $(function () { $(".tDefault thead").css("display", "none"); });
    }

    $("#GrillaCotizacion tfoot tr:last td").prepend("<a id='tfootPage' class='total_registros'></a>");
    $("#tfootPage").html($("#hdfTotalRegistros").val());
    $("#GrillaCotizacion tfoot tr a, #GrillaCotizacion thead tr a").live("click", function (e) {
        var url = $(this).attr("href");
        var vIdMarca = $("#Id_Marca").val();
        var vIdSucursal = $("#Id_Sucursal").val();
        var vIdFechaIni = $("#Id_FechaIni").val();
        var vIdFechaFin = $("#Id_FechaFin").val();
        var vIdRucRazSoc = $("#RucRazSoc").val();
        var vIdSubGerente = $("#Id_SubGerente").val();
        var vIdJefeRegional = $("#Id_JefeRegional").val();
        var vIdCodOfisisEmpleado = $("#CodOfisisEmpleado").val();
        var vIdFamilia = $("#Id_Familia").val();
        var vIdSkuProducto = $("#SkuProducto").val();
        var vIdNroCotizacion = $("#NroCotizacion").val();
        var vIdTipoProforma = $("#Id_TipoProforma").val();
        var sortdir = "";
        var sort = "";
        var page = 1;
        var queue = "";
        var arr = new Array();
        arr = url.split("?");
        queue = arr[0].toString() + "?";
        arr = arr[1].toString().split("&");
        for (var i = 0; i <= arr.length - 1; i++) {
            if (arr[i].indexOf("page") >= 0)
                page = arr[i].toString().split("=")[1].toString();
            if (arr[i].indexOf("sort=") >= 0)
                sort = arr[i].toString().split("=")[1].toString();
            if (arr[i].indexOf("sortdir") >= 0)
                sortdir = arr[i].toString().split("=")[1].toString();
        }
        var newurl = "";
        newurl = queue +
            "page=" +
            page +
            "&sort=" +
            sort +
            "&sortdir=" +
            sortdir +
            "&codMarca=" +
            vIdMarca +
            "&codSucursal=" +
            vIdSucursal +
            "&codFechaIni=" +
            vIdFechaIni +
            "&codFechaFin=" +
            vIdFechaFin +
            "&codRucRazSoc=" +
            vIdRucRazSoc +
            "&codSubGerente=" +
            vIdSubGerente +
            "&codJefeRegional=" +
            vIdJefeRegional +
            "&codOfisisEmpleado=" +
            vIdCodOfisisEmpleado +
            "&codFamilia=" +
            vIdFamilia +
            "&codSkuProducto=" +
            vIdSkuProducto +
            "&codNroCotizacion=" +
            vIdNroCotizacion +
            "&codIdTipoProforma=" +
            vIdTipoProforma;

        $(this).attr("href", newurl);
    });
}

function EditarCotizacion(nroCotizacion) {
    var paramUrl = CreateUrl("EditarCotizacion", "Mantenimiento");
    $.ajax({
        url: paramUrl,
        data: {
            nroCotizacion: nroCotizacion
        },
        type: "get",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#dialogGestionarCotizacion").html(data);
            InicioJPopUpOpen("#dialogGestionarCotizacion");
        },
        error: function (jqXhr, textStatus, errorThrown) {
        }
    });
}


function DialogCancelarRegistroCotizacion() {
    InicioJPopUpOpen("#dialogCancelarRegistroCotizacion");
}

function CancelarRegistroCotizacion() {
    $("#dialogGestionarCotizacion").dialog("close");
}

function RegistrarCotizacion() {
    $("#frmEditarCotizacion").each(function () { $.data($(this)[0], "validator", false); });
    $.validator.unobtrusive.parse("#frmEditarCotizacion");
    if ($("#frmEditarCotizacion").valid()) {
        $("#dialogRegistrarCotizacion").dialog("open");
    }
}

function GuardarCotizacion() {
    var form = $("#frmEditarCotizacion");
    $.ajax({
        url: form.attr("action"),
        type: "POST",
        data: form.serialize(),
        success: function (data) {
            var result = data.split("/");
            if (result[0] === 1 || result[0] === "1") {
                $("#dialogGestionarCotizacion").dialog("close");
                BuscarCotizacion();
            }
            InicioJPopUpAlert(result[1], null);
        },
        error: function (jqXhr, textStatus, errorThrown) {
        }
    });

}

function VerDetalleCotizacion(nroCotizacion) {
    var paramUrl = CreateUrl("VerDetalleCotizacion", "Mantenimiento");
    var vNroCotizacion = nroCotizacion;
    $.ajax({
        url: paramUrl,
        data: {
            nroCotizacion: vNroCotizacion
        },
        type: "get",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#dialogDetalleCotizacion").html(data);
            InicioJPopUpOpen("#dialogDetalleCotizacion");
        },
        error: function (jqXHR, status, error) {
        }
    });
}

function SetTotalRegistrosDetalleCotizacion() {

    var count = $("#countListaDetalleCotizacion").val();
    if (count === 0) {
        $(function () { $(".tDefault thead").css("display", "none"); });
    }

    $("#GrillaDetalleCotizacion tfoot tr:last td").prepend("<a id='tfootPage' class='total_registros'></a>");
    $("#tfootPage").html($("#hdfTotalRegistros").val());
    $("#GrillaDetalleCotizacion tfoot tr a, #GrillaDetalleCotizacion thead tr a").live("click", function (e) {
        var url = $(this).attr("href");
        var vNroCotizacion = $("#hdfNroCotizacion").val();
        var sortdir = "";
        var sort = "";
        var page = 1;
        var queue = "";
        var arr = new Array();
        arr = url.split("?");
        queue = arr[0].toString() + "?";
        arr = arr[1].toString().split("&");
        for (var i = 0; i <= arr.length - 1; i++) {
            if (arr[i].indexOf("page") >= 0)
                page = arr[i].toString().split("=")[1].toString();
            if (arr[i].indexOf("sort=") >= 0)
                sort = arr[i].toString().split("=")[1].toString();
            if (arr[i].indexOf("sortdir") >= 0)
                sortdir = arr[i].toString().split("=")[1].toString();
        }
        var newurl = "";
        newurl = queue +
            "page=" +
            page +
            "&sort=" +
            sort +
            "&sortdir=" +
            sortdir +
            "&nroCotizacion=" +
            vNroCotizacion;

        $(this).attr("href", newurl);
    });
}

var getSucursal = function () {
    $.ajax({
        url: CreateUrl("ListarSucursalControl", "Mantenimiento"),
        data: { idMarca: $(this).val() },
        type: "GET",
        cache: false,
        success: function (data) {
            $("#container-sucursal").html(data);
            $("#Id_Sucursal").uniform();
        }
    });
};

function DownloadFile(resource) {
    if (resource.length > 0) {
        window.open(resource, "_blank");
    }
    else {
        alert("No se pudo exportar el archivo.");
    }
}

function ExportarCotizacion() {
    var paramUrl = CreateUrl("ExportarCotizacion", "Mantenimiento");
    var vIdMarca = $("#Id_Marca").val();
    var vIdSucursal = $("#Id_Sucursal").val();
    var vIdFechaIni = $("#Id_FechaIni").val();
    var vIdFechaFin = $("#Id_FechaFin").val();
    var vIdRucRazSoc = $("#RucRazSoc").val();
    var vIdSubGerente = $("#Id_SubGerente").val();
    var vIdJefeRegional = $("#Id_JefeRegional").val();
    var vIdCodOfisisEmpleado = $("#CodOfisisEmpleado").val();
    var vIdFamilia = $("#Id_Familia").val();
    var vIdSkuProducto = $("#SkuProducto").val();
    var vIdNroCotizacion = $("#NroCotizacion").val();
    $.ajax({
        url: paramUrl,
        data: {
            codMarca: vIdMarca,
            codSucursal: vIdSucursal,
            codFechaIni: vIdFechaIni,
            codFechaFin: vIdFechaFin,
            codRucRazSoc: vIdRucRazSoc,
            codSubGerente: vIdSubGerente,
            codJefeRegional: vIdJefeRegional,
            codOfisisEmpleado: vIdCodOfisisEmpleado,
            codFamilia: vIdFamilia,
            codSkuProducto: vIdSkuProducto,
            codNroCotizacion: vIdNroCotizacion
        },
        type: "get",
        cache: false,
        success: function (data) {
            var resource = data;
            DownloadFile(resource);
        },
        error: function (data) {
            alert("Error: " + data);
        }
    });
}
//END SECTION COTIZACION

//SECTION COTIZACION - SkuBloqueado
function BuscarSkuBloqueado() {
    var paramUrl = CreateUrl("ConsultarSkuBloqueados_PVGrilla", "Mantenimiento");
    var vIdSku = $("#Cod_Sku").val();
    $.ajax({
        url: paramUrl,
        data: {
            codigoSku: vIdSku
        },
        type: "get",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#contenedor-grid-SkuBloqueado").html(data);
        },
        error: function (jqXHR, status, error) {
        }
    });
}

function SetTotalRegistrosSkuBloqueado() {

    var count = $("#countListaSkuBloqueado").val();
    if (count === 0) {
        $(function () { $(".tDefault thead").css("display", "none"); });
    }

    $("#GrillaSkuBloqueado tfoot tr:last td").prepend("<a id='tfootPage' class='total_registros'></a>");
    $("#tfootPage").html($("#hdfTotalRegistros").val());
    $("#GrillaSkuBloqueado tfoot tr a, #GrillaSkuBloqueado thead tr a").live("click", function (e) {
        var url = $(this).attr("href");
        var vIdSku = $("#Cod_Sku").val();
        var sortdir = "";
        var sort = "";
        var page = 1;
        var queue = "";
        var arr = new Array();
        arr = url.split("?");
        queue = arr[0].toString() + "?";
        arr = arr[1].toString().split("&");
        for (var i = 0; i <= arr.length - 1; i++) {
            if (arr[i].indexOf("page") >= 0)
                page = arr[i].toString().split("=")[1].toString();
            if (arr[i].indexOf("sort=") >= 0)
                sort = arr[i].toString().split("=")[1].toString();
            if (arr[i].indexOf("sortdir") >= 0)
                sortdir = arr[i].toString().split("=")[1].toString();
        }
        var newurl = "";
        newurl = queue +
            "page=" +
            page +
            "&sort=" +
            sort +
            "&sortdir=" +
            sortdir +
            "&codigoSku=" +
            vIdSku;

        $(this).attr("href", newurl);
    });
}

var vIdSkuBloqueado;
function DialogEliminarSkuBloqueado(idSkuBloqueado) {
    vIdSkuBloqueado = idSkuBloqueado;
    InicioJPopUpOpen("#dialogEliminarSkuBloqueado");

}
function EliminarSkuBloqueado() {
    var paramUrl = CreateUrl("EliminarSkuBloqueado", "Mantenimiento");
    $.ajax({
        url: paramUrl,
        data: {
            codigoSku: vIdSkuBloqueado
        },
        type: "post",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#dialogEliminarSkuBloqueado").dialog("close");
            var result = data.split("/");
            if (result[0] === 1 || result[0] === "1") {
                BuscarSkuBloqueado();
            }
            InicioJPopUpAlert(result[1], null);
        },
        error: function (jqXhr, textStatus, errorThrown) {
        }
    });
}

function NuevoSkuBloqueado() {
    var paramUrl = CreateUrl("EditarSkuBloqueado", "Mantenimiento");
    $.ajax({
        url: paramUrl,
        data: null,
        type: "get",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#dialogGestionarSkuBloqueado").html(data);
            InicioJPopUpOpen("#dialogGestionarSkuBloqueado");
        },
        error: function (jqXhr, textStatus, errorThrown) {
        }
    });
}

function DialogCancelarRegistroSkuBloqueado() {
    InicioJPopUpOpen("#dialogCancelarRegistroSkuBloqueado");
}

function CancelarRegistroSkuBloqueado() {
    $("#dialogGestionarSkuBloqueado").dialog("close");
}

function RegistrarSkuBloqueado() {
    $("#frmEditarSkuBloqueado").each(function () { $.data($(this)[0], "validator", false); });
    $.validator.unobtrusive.parse("#frmEditarSkuBloqueado");
    if ($("#frmEditarSkuBloqueado").valid()) {
        $("#dialogRegistrarSkuBloqueado").dialog("open");
    }
}

function GuardarSkuBloqueado() {
    var form = $("#frmEditarSkuBloqueado");
    $.ajax({
        url: form.attr("action"),
        type: "POST",
        data: form.serialize(),
        success: function (data) {
            var result = data.split("/");
            if (result[0] === 1 || result[0] === "1") {
                $("#dialogGestionarSkuBloqueado").dialog("close");
                BuscarSkuBloqueado();
            }
            InicioJPopUpAlert(result[1], null);
        },
        error: function (jqXhr, textStatus, errorThrown) {
        }
    });

}
//END SECTION COTIZACION

//INICIO - MANTENIMIENTO PLAN POR TIPO REPRESENTANTE VENTA

function BuscarPlanTipoRepVen() {
    var ParamUrl = CreateUrl("ConsultarPlanTipoRepresentanteVenta_PVGrilla", "Mantenimiento");
    var vIdTipoRepVen = $("#ID_TipoRepVen").val();
    var vIdMes = $("#ID_MesPlan").val();
    $.ajax({
        url: ParamUrl,
        data: {
            IdTipoRepVen: vIdTipoRepVen,
            IdMes: vIdMes
        },
        type: "get",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#contenedor-grid-PlanTipoRepVen").html(data);
        },
        error: function (jqXHR, status, error) {
        }
    });
}

function SetTotalRegistrosPlanTipoRepVen() {
    var count = $("#countListaPlanTipoRepVen").val();
    if (count == 0) {
        $(function () { $(".tDefault thead").css("display", "none"); });
    }
    $("#GrillaPlanTipoRepVen tfoot tr:last td").prepend("<a id='tfootPage' class='total_registros'></a>");
    $("#tfootPage").html($('#hdfTotalRegistros').val());
    $("#GrillaPlanTipoRepVen tfoot tr a, #GrillaPlanTipoRepVen thead tr a").live("click", function (e) {
        var url = $(this).attr('href');
        var vIdTipoRepVen = $("#ID_TipoRepVen").val();
        var vIdMes = $("#ID_MesPlan").val();
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
        newurl = queue + "page=" + page + "&sort=" + sort + "&sortdir=" + sortdir +
            "&IdTipoRepVen=" + vIdTipoRepVen +
            "&IdMes=" + vIdMes +
            $(this).attr('href', newurl);
    });
}

//1.Nuevo Plan Venta

function dialogGestionarPlanTipoRepVen() {
    var ParamUrl = CreateUrl("GestionarPlanTipoRepresentanteVenta", "Mantenimiento")

    $.ajax({
        url: ParamUrl,
        data: {
        },
        type: "get",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#dialogGestionarPlanTipoRepVen").html(data);
            $("#ID_CmbTipoRepVen").uniform();
            $("#ID_CmbMesPlan").uniform();
            InicioJPopUpOpen('#dialogGestionarPlanTipoRepVen');
            $("#Plan").val("")
        },
        error: function (jqXhr, textStatus, errorThrown) {
        }
    });
}

//2.Editar Plan Venta

function EditarPlanTipoRepVen(pIdPlanTipoRepVen) {
    var ParamUrl = CreateUrl("GestionarPlanTipoRepresentanteVenta", "Mantenimiento")
    $.ajax({
        url: ParamUrl,
        data: {
            IdPlanTipoRepVen: pIdPlanTipoRepVen
        },
        type: "get",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#dialogGestionarPlanTipoRepVen").html(data);
            $("#ID_CmbTipoRepVen").uniform();
            $("#ID_CmbMesPlan").uniform();
            $('#ID_CmbTipoRepVen').attr('disabled', true);
            $('#ID_CmbMesPlan').attr('disabled', true);
            InicioJPopUpOpen('#dialogGestionarPlanTipoRepVen');
        },
        error: function (jqXhr, textStatus, errorThrown) {
        }
    });
}

function RegistrarPlanTipoRepVen() {
    //$("#ID_PerfilSuperior").attr("class", "ignorefield")

    $("#frmGestionarPlanTipoRepVen").each(function () { $.data($(this)[0], 'validator', false); });
    $.validator.unobtrusive.parse("#frmGestionarPlanTipoRepVen");

    if ($('#frmGestionarPlanTipoRepVen').valid()) {
        $('#dialogRegistrarPlanTipoRepVen').dialog('open');
    }
}

function GuardarPlanTipoRepVen() {
    var form = $('#frmGestionarPlanTipoRepVen');

    $.ajax({
        url: form.attr('action'),
        type: "POST",
        data: form.serialize(),
        success: function (data) {
            var result = data.split("/");
            if (result[0] == 1 || result[0] == 2) {
                $('#dialogGestionarPlanTipoRepVen').dialog('close');
                BuscarPlanTipoRepVen()
            }
            InicioJPopUpAlert(result[1], null);
        },
        error: function (jqXhr, textStatus, errorThrown) {
        }
    });
}

function ConfirmarCancelarRegistroPlanTipoRepVen() {
    InicioJPopUpOpen('#dialogCancelarRegistroPlanTipoRepVen');
}

function CancelarRegistroPlanTipoRepVen() {
    $('#dialogGestionarPlanTipoRepVen').dialog('close');
}

//3.Eliminar Plan Venta

var vIdPlanTipoRepVen;
function ConfirmarEliminarPlanTipoRepVen(pIdPlanTipoRepVen) {
    vIdPlanTipoRepVen = pIdPlanTipoRepVen;
    InicioJPopUpOpen('#dialogEliminarPlanTipoRepVen');
}

function EliminarPlanTipoRepVen() {
    var ParamUrl = CreateUrl("EliminarPlanTipoRepresentanteVenta", "Mantenimiento")
    $.ajax({
        url: ParamUrl,
        data: {
            IdPlanTipoRepVen: vIdPlanTipoRepVen
        },
        type: "post",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $('#dialogEliminarPlanTipoRepVen').dialog("close");
            var result = data.split("/");
            if (result[0] == 1 || result[0] == "1") {
                BuscarPlanTipoRepVen()
            }
            InicioJPopUpAlert(result[1], null);
        },
        error: function (jqXhr, textStatus, errorThrown) {
        }
    });
}

//FIN - MANTENIMIENTO PLAN POR TIPO REPRESENTANTE VENTA