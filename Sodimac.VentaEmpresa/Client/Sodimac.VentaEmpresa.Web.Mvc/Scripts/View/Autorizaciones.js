//Eliot
var DataContado = [];
var DataCredito = [];
var PrimeraVezContado = true;
var PrimeraVerCredito = true;

function Buscar_Filto_Asignaciones() {
    BuscarContado();
    BuscarCredito();
}

//efcc_inicio
function Buscar_Filto_AprobExepciones() {
    BuscarAprobExep();
}
//efcc_fin


function ChecksAll()
{
    var valCheck = $("#CheckAll").is(":checked");


    $("input[name='ncheck']").each(function () {

        if (valCheck) {
            $(this).attr('checked', true);
            $("#lblCheckAll").text("Desmarcar Todos");
        }
        else {
            $(this).attr('checked', false);
            $("#lblCheckAll").text("Marcar Todos");
        }


    });

}

function ChecksAll2() {
    var valCheck = $("#CheckAll2").is(":checked");


    $("input[name='ncheck2']").each(function () {

        if (valCheck) {
            $(this).attr('checked', true);
            $("#lblCheckAll2").text("Desmarcar Todos");
        }
        else {
            $(this).attr('checked', false);
            $("#lblCheckAll2").text("Marcar Todos");
        }


    });


}

function Asignar(ModoPago) {
    var Titulo;
    switch (ModoPago) {
        case 1:
            Titulo = 'credito';
            if ($("#Credito_RowCount").val() == "0") {
                $("#mensajeResultado p").text("No hay cliente(s) a autorizar");
                $("#mensajeResultado").dialog('open');
            } else {
                $("#mensajeConfirmacion p").text("¿Desea autorizar los registros credito?");
                $("#mensajeConfirmacion").data('Opcion', 'credito');
                $("#mensajeConfirmacion").dialog('open');
            }
            break;
        case 2:
            Titulo = 'contado';
            if ($("#Contado_RowCount").val() == "0") {
                $("#mensajeResultado p").text("No hay cliente(s) a autorizar");
                $("#mensajeResultado").dialog('open');
            } else {
                $("#mensajeConfirmacion p").text("¿Desea autorizar los registros contado?");
                $("#mensajeConfirmacion").data('Opcion', 'contado');
                $("#mensajeConfirmacion").dialog('open');
            }
            break;
    }
}

function AsignarAutorizacion(IdModoPago, grilla) {
    var ParamUrl = $("#Url_Autorizar_Cliente").val();

    if (IdModoPago == 1) {
        var array = CheckAutorizaciones(1);
    } else {
        var array = CheckAutorizaciones(2);
    }

    if (array.length > 0) {
        $.ajax({
            url: ParamUrl,
            data: { Data: JSON.stringify(array), __RequestVerificationToken: $("input[name='__RequestVerificationToken']").val() },
            type: "post",
            cache: false,
            success: function (data, textStatus, jqXHR) {
                if (IdModoPago == 1) {
                    BuscarCredito();
                } else if (IdModoPago == 2) {
                    BuscarContado();
                }
                $("#mensajeResultado p").html(data.mensaje);
                $("#mensajeResultado").dialog('open');
            },
            error: function (jqXHR, status, error) {
            },
            complete: function () {
            }
        });
    } else {
        $("#mensajeResultado p").text("No hay registros a seleccionados");
        $("#mensajeResultado").dialog('open');
    }
}
//efcc_inicio
function AsignarAutorizacionExepciones(IdModoPago, grilla) {
    var ParamUrl = $("#Url_Autorizar_ClienteExepciones").val();


    if (IdModoPago == 1) {
        var array = CheckAutorizaciones(1);
    } else {
        var array = CheckAutorizaciones(2);
    }

    if (array.length > 0) {
        $.ajax({
            url: ParamUrl,
            data: { Data: JSON.stringify(array), __RequestVerificationToken: $("input[name='__RequestVerificationToken']").val() },
            type: "post",
            cache: false,
            success: function (data, textStatus, jqXHR) {
                if (IdModoPago == 1) {
                    BuscarCredito();
                } else if (IdModoPago == 2) {
                    BuscarContado();
                }
                $("#mensajeResultado p").html(data.mensaje);
                $("#mensajeResultado").dialog('open');
            },
            error: function (jqXHR, status, error) {
            },
            complete: function () {
            }
        });
    } else {
        $("#mensajeResultado p").text("No hay registros a seleccionados");
        $("#mensajeResultado").dialog('open');
    }

}

function BuscarAprobExep(){
    var ParamUrl = $("#Url_Autorizar_ClienteExepciones").val();
    var sRazonSocialRUc = $("#ID_RazonSocial_RUC").val();

    //server request
    $.ajax({
        url: ParamUrl,
        data: {
            RazonSocialRUc: sRazonSocialRUc
        },
        type: "post",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            PrimeraVezContado = true;
            $("#div_grilla_Contado").html(data);
        },
        error: function (jqXHR, status, error) {
        },
        complete: function () {
            SetTotalRegistrosContado();
        }
    });   
}
//efcc_fin

function BuscarContado() {
    //url
    var ParamUrl = $("#Url_Consultar_Contado").val();
    var sRazonSocialRUc = $("#ID_RazonSocial_RUC").val();
     var sIdMotivo = $("#ID_Motivo").val();
 
    var sRRVV = $("#RRVV_NombreEmpleado").val();

    //server request
    $.ajax({
        url: ParamUrl,
        data: {
            RazonSocialRUc: sRazonSocialRUc,
            IdMotivo: sIdMotivo,
            sRRVV: sRRVV
        },
        type: "post",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            PrimeraVezContado = true;
            $("#div_grilla_Contado").html(data);
        },
        error: function (jqXHR, status, error) {
        },
        complete: function () {
            SetTotalRegistrosContado();
        }
    });   
}

function ConsultaAsignacionContado_Credito() {
    //url
    
    var ParamUrl = $("#Url_Consultar_Contado").val();
    var sRazonSocialRUc = $("#ID_RazonSocial_RUC").val();
  //  var sIdMotivo = $("#ID_Motivo").val();
    var sIdMotivo = $("#ID_Motivo option:selected").text()
    var sRRVV_NombreEmpleado = $("#RRVV_NombreEmpleado").val();
    var IdModoPago = $("#ID_ModoPago").val();

    if (sIdMotivo == "-TODOS-") {
        sIdMotivo == "";
    }
    //server request
    $.ajax({
        url: ParamUrl,
        data: {
            RazonSocialRUc: sRazonSocialRUc,
            IdMotivo: sIdMotivo,
            sRRVV_NombreEmpleado: sRRVV_NombreEmpleado,
            IdModoPago: IdModoPago
        },
        type: "post",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            PrimeraVezContado = true;
            $("#div_grilla_Contado").html(data);
        },
        error: function (jqXHR, status, error) {
        },
        complete: function () {
          SetTotalRegistros_Consulta_Contado_Credito();
        }
    });
}

function BuscarContado2() {
    //url
    var ParamUrl = $("#Url_Consultar_Contado").val();
    var sRazonSocialRUc = $("#ID_RazonSocial_RUC").val();
    var sIdMotivo = $("#ID_Motivo").val();

    //server request
    $.ajax({
        url: ParamUrl,
        data: {
            RazonSocialRUc: sRazonSocialRUc,
            IdMotivo: sIdMotivo
        },
        type: "post",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            PrimeraVezContado = true;
            $("#div_grilla_Contado").html(data);
        },
        error: function (jqXHR, status, error) {
        },
        complete: function () {
            SetTotalRegistrosContado();
        }
    });
}


function BuscarCredito() {
    //url
    var ParamUrl = $("#Url_Consultar_Credito").val();
    var sRazonSocialRUc = $("#ID_RazonSocial_RUC").val();
    var sIdMotivo = $("#ID_Motivo").val();
    var sRRVV = $("#RRVV_NombreEmpleado").val();
    
    //server request
    $.ajax({
        url: ParamUrl,
        data: {
            RazonSocialRUc: sRazonSocialRUc,
            IdMotivo: sIdMotivo,
            sRRVV: sRRVV
        },
        type: "post",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            PrimeraVezCredito = true;
            $("#div_grilla_Credito").html(data);
        },
        error: function (jqXHR, status, error) {
        },
        complete: function () {
            SetTotalRegistrosCredito();
        }
    });   
}

function SetTotalRegistrosContado() {
    var page = 1;
    $("#grilla_Contado tfoot tr a, #grilla_Contado thead tr a").on("click", function (e) {
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
        if (PrimeraVezContado) {
            MemoryChecks('Contado', 1, true);
            PrimeraVezContado = false;
        }
        else if (DataContado.length > 0) {
            MemoryChecks('Contado', $("#Contado_PagePreview").val(), false);
        }
        $("#Contado_PagePreview").val(page);
        e.preventDefault();
    });

    PintarHeaderGrillaContado();
    if (DataContado.length > 0) {
        CargarChecks('Contado', $("#Contado_PagePreview").val(), DataContado);
    }
}


function SetTotalRegistros_Consulta_Contado_Credito() {
 
//    $("#grilla_Contado tfoot tr:last td").prepend("<a id='tfootPage' class='total_registros'></a>");
//    $("#tfootPage").html($('#Contado_FooterDesc').val());
//    $("#grilla_Contado tfoot tr a, #grilla_Contado thead tr a").live("click", function (e) {

    $("#grilla_Contado tfoot tr a, #grilla_Contado thead tr a").on("click", function (e) {
        debugger;
        var ParamUrl = $("#Url_Consultar_Contado").val();
        var sRazonSocialRUc = $("#ID_RazonSocial_RUC").val();
        var sIdMotivo = $("#ID_Motivo option:selected").text()
        var sRRVV_NombreEmpleado = $("#RRVV_NombreEmpleado").val();
        var IdModoPago = $("#ID_ModoPago").val();
        if (sIdMotivo == "-TODOS-") {
            sIdMotivo == "";
        }

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
        newurl = queue + "page=" + page + "&sort=" + sort + "&sortdir=" + sortdir +
        "&RazonSocialRUc=" + sRazonSocialRUc +
        "&IdMotivo=" + sIdMotivo +
        "&sRRVV_NombreEmpleado=" + sRRVV_NombreEmpleado +
        "&IdModoPago=" + IdModoPago

        $(this).attr('href', newurl);
    });
    PintarHeaderGrillaContado_Credito();
}



function SetTotalRegistrosCredito() {
    var page = 1;
    $("#grilla_Credito tfoot tr a, #grilla_Credito thead tr a").on("click", function (e) {
        //pagination parameters
        var sortdir = "";
        var sort = "";
        var page = 1;
        var queue = "";

        //logic for url action
        var url = $(this).attr('href');

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

        //adding filter and pagination parameters
        var newurl = "";
        newurl = queue +
            "&sortdir=" + sortdir +
            "&sort=" + sort +
            "&page=" + page;
        $(this).attr('href', newurl);

        if (PrimeraVezCredito) {
            MemoryChecks('Credito', 1, true);
            PrimeraVezCredito = false;
        }
        else if (DataCredito.length > 0) {
            MemoryChecks('Credito', $("#Credito_PagePreview").val(), false);
        }
        $("#Credito_PagePreview").val(page);
        e.preventDefault();
    });
    PintarHeaderGrillaCredito();
    if (DataCredito.length > 0) {
        CargarChecks('Credito', $("#Credito_PagePreview").val(), DataCredito);
    }
}


function PintarHeaderGrillaContado_Credito() {
    var RowCount = $("#Contado_RowCount").val();
    var RowsPerPage = $('#Contado_RowsPerPage').val();

    $("#grilla_Contado tfoot tr:last td").prepend("<a id='contado_tfootPage'  class='total_registros'></a>");
    $("#contado_tfootPage").html($('#Contado_FooterDesc').val());

    if (RowCount <= 0) {
        $('#grilla_Contado').css('display', 'none');
    } else {
        $('#grilla_Contado').css('display', '');
    }
}


function PintarHeaderGrillaContado() {
    var RowCount = $("#contado_RowCount").val();
    var RowsPerPage = $('#contado_RowsPerPage').val();

    $("#grilla_Contado tfoot tr:last td").prepend("<a id='contado_tfootPage'  class='total_registros'></a>");
    $("#contado_tfootPage").html($('#Contado_FooterDesc').val());

    if (RowCount <= 0) {
        $('#grilla_Contado').css('display', 'none');
    } else {
        $('#grilla_Contado').css('display', '');
    }
}

function PintarHeaderGrillaCredito() {
    var RowCount = $("#credito_RowCount").val();
    var RowsPerPage = $('#credito_RowsPerPage').val();
    
    $("#grilla_Credito tfoot tr:last td").prepend("<a id='credito_tfootPage'  class='total_registros'></a>");
    $("#credito_tfootPage").html($('#Credito_FooterDesc').val());

    if (RowCount <= 0) {
        $('#grilla_Credito').css('display', 'none');
    } else {
        $('#grilla_Credito').css('display', '');
    }
}

$(function () {
    SetTotalRegistrosContado();
    SetTotalRegistrosCredito();
});


function CargarChecks(grid, page, checks) {
    var Total = parseInt($('#' + grid + '_RowCount').val());
    var RegPag = parseInt($('#' + grid + '_RowsPerPage').val());

    var TotalPage = 1;
    if ((Total / RegPag) > Math.round(Total / RegPag)) {
        TotalPage = Math.round(Total / RegPag) + 1;
    }
    else {
        TotalPage = Math.round(Total / RegPag);
    }
    
    for (var j = 1; j < TotalPage + 1; j++) {
        if (j == page) {
            $("#grilla_" + grid + " tbody tr").each(function (i, element) {
                ($(element).find('td:nth-child(5) input[type=text]')[0]).value = checks[((page - 1) * RegPag) + i].Anotacion;
                ($(element).find('td:nth-child(6) input[type=checkbox]')[0]).checked = checks[((page - 1) * RegPag) + i].Check;
            });
            break;
        } 
    }
}

function MemoryChecks(grid, page, PrimeraVez) {
    if (PrimeraVez) {
        var checks = [];
    } else {
        if (grid == 'Contado') {
            checks = DataContado;
        } else {
            checks = DataCredito;
        }
    }
    
    var Total = parseInt($('#' + grid + '_RowCount').val());
    var RegPag = parseInt($('#' + grid + '_RowsPerPage').val());
    
    var TotalPage = 1;
    if ((Total / RegPag) > Math.round(Total / RegPag)) {
        TotalPage = Math.round(Total / RegPag) + 1;
    }
    else {
        TotalPage = Math.round(Total / RegPag);
    }
    
    for (var w = 1; w < TotalPage + 1; w++) {
        if (w == page) {
            $("#grilla_" + grid + " tbody tr").each(function (i, element) {
                var RUC = ($(element).find('td:nth-child(1)')[0]).innerHTML;
                var Motivo = ($(element).find('td:nth-child(4)')[0]).innerHTML;
                var Anotacion = ($(element).find('td:nth-child(5) input[type=text]')[0]).value;
                var check = ($(element).find('td:nth-child(6) input[type=checkbox]')[0]).checked;

                var Data = {
                    RUC: RUC,
                    Check: check,
                    Anotacion: Anotacion,
                    Motivo: Motivo
                };
                if (PrimeraVez) {
                    checks.push(Data);
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
                        RUC: '',
                        Check: false,
                        Anotacion: ''
                    };
                    checks.push(Data)
                }
            }
        }
    }

    if (grid == 'Contado') {
        DataContado = checks;
    } else {
        DataCredito = checks;
    }
}

function CheckAutorizaciones(IdModoPago) {
    var Array = [];
    if (IdModoPago == 1) {
        var ListaData = DataCredito;
        var grid = 'Credito';
    } else {
        var ListaData = DataContado;
        var grid = 'Contado';
    }
    
    var PageAct = $("#" + grid + "_PagePreview").val();
    var Total = parseInt($("#" + grid + "_RowCount").val());
    var RegPag = parseInt($("#" + grid + "_RowsPerPage").val());
    var RegEnPag = RegPag;
    var TotalPage = 1;
    if ((Total / RegPag) > Math.round(Total / RegPag)) {
        TotalPage = Math.round(Total / RegPag) + 1;
    }
    else {
        TotalPage = Math.round(Total / RegPag);
    }

    for (var j = 1; j < TotalPage + 1; j++) {
        if (TotalPage == j) {
            RegEnPag = RegPag + (Total - (j * RegPag));
        }
        else {
            RegEnPag = RegPag;
        }

        if (j == PageAct) {
            $("#grilla_" + grid + " tbody tr").each(function (i, element) {
                var check = ($(element).find('td:nth-child(6) input[type=checkbox]')[0]).checked;

                if (check) {
                    var RUC = ($(element).find('td:nth-child(1)')[0]).innerHTML;
                    var Motivo = ($(element).find('td:nth-child(4)')[0]).innerHTML;
                    var Anotacion = ($(element).find('td:nth-child(5) input[type=text]')[0]).value;

                    var Data = {
                        RUC: RUC,
                        Check: check,
                        Anotacion: Anotacion,
                        Motivo: Motivo
                    };
                    Array.push(Data);
                }
            });
        } else {
            if (ListaData.length > 0) {
                for (var i = 0; i < RegEnPag; i++) {
                    var Check = ListaData[(j - 1) * RegPag + i].Check;

                    if (Check) {
                        var RUC = ListaData[(j - 1) * RegPag + i].RUC;
                        var Motivo = ListaData[(j - 1) * RegPag + i].Motivo;
                        var Anotacion = ListaData[(j - 1) * RegPag + i].Anotacion;

                        var Data = {
                            IdAprobaciones: 0,
                            Motivo: Motivo,
                            IdModoPago: IdModoPago,
                            Activo: 1,
                            RUC: RUC,
                            Anotacion: Anotacion
                        };
                        Array.push(Data);
                    }
                }
            }
        }
    }
    return Array;


   
}


function EnterSubmit(e, buttonClick) {
    tecla = (document.all) ? e.keyCode : e.which;
    if (tecla == 13) {
        var obj = document.getElementById(buttonClick);
        obj.click();
    }
}
