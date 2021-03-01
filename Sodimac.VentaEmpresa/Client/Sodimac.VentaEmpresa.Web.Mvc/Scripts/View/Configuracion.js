function Guardar() {
    var Valido = true;
    replaceErrorMessagge("ID_MsgFechaInicio", "");
    replaceErrorMessagge("ID_MsgFechaFin", "");
    
    if (ValidarFecha("FechaDesde") != 0) {
        replaceErrorMessagge("ID_MsgFechaInicio", "Ingrese una fecha de inicio correcta");
        Valido = false;
    } 
    if (ValidarFecha("FechaHasta") != 0) {
        replaceErrorMessagge("ID_MsgFechaFin", "Ingrese una fecha de fin correcta");
        Valido = false;    
    }

    if (Valido) {
        $("#mensajeConfirmacion p").text("¿Desea guardar el registro?");
        $("#mensajeConfirmacion").data('Opcion', 'GuardarParametro');
        $("#mensajeConfirmacion").dialog('open');
    }
}

function GuardarParametro() {
    var ParamUrl = $("#Url_Actualizar_Parametro").val();

    var Desde = $.datepicker.parseDate('dd/mm/yy', $("#FechaDesde").val().toString().substring(0, 10));
    var Hasta = $.datepicker.parseDate('dd/mm/yy', $("#FechaHasta").val().toString().substring(0, 10));

    var D = {
        IdParametro: $("#IdParametro").val(),
        Valor1: $("#Id_Valor1").val(),
        Descripcion1: $("#Descripcion1").val(),
        Valor2: $("#Id_Valor2").val(),
        Descripcion2: $("#Descripcion2").val(),
        Valor3: $("#Id_Valor3").val(),
        Descripcion3: $("#Descripcion3").val(),
        FechaDesde: Desde,
        FechaHasta: Hasta
    };

    $.ajax({
        url: ParamUrl,
        data: { Data: JSON.stringify(D), __RequestVerificationToken: $("input[name='__RequestVerificationToken']").val() },
        type: "post",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#mensajeResultado p").html(data.mensaje);
            $("#mensajeResultado").data('Opcion', 'Consultar');
            $("#mensajeResultado").dialog('open');
        },
        error: function (jqXHR, status, error) {
        },
        complete: function () {
        }
    });
}

function Cancelar() {
    $("#mensajeConfirmacion p").text("¿Desea cancelar el registro?");
    $("#mensajeConfirmacion").data('Opcion', 'Cancelar');
    $("#mensajeConfirmacion").dialog('open');
}

function BuscarNegocio() {
    var ParamUrl = $("#Url_Consutar_Negocio").val();

    $.ajax({
        url: ParamUrl,
        data: {},
        type: "post",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#Div_grilla_Negocio").html(data);
        },
        error: function (jqXHR, status, error) {
        },
        complete: function () {
            SetTotalRegistrosNegocio();
        }
    });
}

function SetTotalRegistrosNegocio() {
    $("#grilla_Negocio tfoot tr a, #grilla_Negocio thead tr a").on("click", function (e) {
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

        //adding filter and pagination parameters
        var newurl = "";
        newurl = queue +
            "&sortdir=" + sortdir +
            "&sort=" + sort +
            "&page=" + page;
        $(this).attr('href', newurl);

        e.preventDefault();
    });

    PintarHeaderGrillaNegocio();
}

function PintarHeaderGrillaNegocio() {
    var RowCount = $("#RowCount").val();
    var RowsPerPage = $('#RowsPerPage').val();

    $("#grilla_Negocio tfoot tr:last td").prepend("<a id='tfootPage'  class='total_registros'></a>");
    $("#tfootPage").html($('#FooterDesc').val());

    if (RowCount <= 0) {
        $('#grilla_Negocio').css('display', 'none');
    } else {
        $('#grilla_Negocio').css('display', '');
    }
}

$(function () {
    SetTotalRegistrosNegocio();
});

function replaceErrorMessagge(IdDiv, Message) {
    $("#" + IdDiv).replaceWith('<div style="color: #EC6464; font-size:9px;" id="' + IdDiv + '">' + Message + '</div>');
}