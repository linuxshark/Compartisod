var checksSucursales = [];
var vIdCartera;
var vIdEstado;
var vIdCliente;
var vFechaAsig;
var vFechaDesasig;


function ListaClienteLineaCredito() {
    var vUrl = $("#ID_UrlCliente_PVHistorial").val();
    var vIdCliente = $("#IdCliente").val();
    $.ajax({
        url: vUrl,
        type: "POST",
        data: { IdCliente: vIdCliente },
        success: function (data) {
            $("#divListaClienteHistorial").html(data)
        },
        error: function (er) {
        }
    })
}

function ListarCarteraClientes() {
    var vUrl = $("#ID_UrlCartera").val();
    var vIdCliente = $("#IdCliente").val();
    $.ajax({
        url: vUrl,
        data: { IdCliente: vIdCliente },
        type: "get",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#divListaCarteraCliente").html(data)
        },
        error: function (jqXHR, status, error) {
        },
        complete: function () {

        }
    })
}



function BuscarCliente() {
    var vUrl = $("#idUrlCliente").val();    
    var RazonSocial = encodeURI($.trim($("#ID_RazonSocial").val()));
    var Estado = $("#IdEstado").val();
    var Region = $("#ID_Departamento").val();
    var Provincia = $("#ID_Provincia").val();
    var Sector = $("#IdClienteSector").val();
    var Categoria = $("#IdClienteCategoria").val();
    var ModoPago = $("#ID_ModoPago").val();
    var ClienteTipo = $("#ID_ClienteTipo").val();
    $.ajax({
        url: vUrl,
        type: "POST",
        data: {
            RazonSocial: RazonSocial,
            IdEstado: Estado,
            IdDepartamento: Region,
            IdProvincia: Provincia,
            IdClienteSector: Sector,
            IdClienteCategoria: Categoria,
            IdModoPago: ModoPago,
            IdClienteTipo: ClienteTipo
        },
        success: function (data) {
            $("#contendorgrilla-ListaClientes").html(data)
        },
        error: function (er) {
        }
    })
}

$(function () {
    $("#btnBuscar").live("click", function (e) {
        var url = ""
        url = $("#idUrlCliente").val();

        var RazonSocial = encodeURI($.trim($("#ID_RazonSocial").val()));
        var Estado = $("#IdEstado").val();
        var Region = $("#ID_Departamento").val();
        var Provincia = $("#ID_Provincia").val();
        var Sector = $("#IdClienteSector").val();
        var Categoria = $("#IdClienteCategoria").val();
        var ModoPago = $("#ID_ModoPago").val();
        var IdSucursal = $("#ID_IdSucursal").val();
        var ClienteTipo = $("#ID_ClienteTipo").val();

        var page = 1;
        var sort = "";
        var sortdir = "";
        var queue = "";
        var newurl = ""
        newurl = url + "?page=" + page + "&sort=" + sort + "&sortdir=" + sortdir +
        "&RazonSocial=" + RazonSocial +
        "&IdEstado=" + Estado +
        "&IdDepartamento=" + Region +
        "&IdProvincia=" + Provincia +
        "&IdClienteSector=" + Sector +
        "&IdClienteCategoria=" + Categoria +
        "&IdModoPago=" + ModoPago +
        "&IdSucursal=" + IdSucursal +
        "&IdClienteTipo=" + ClienteTipo

        $("#dgvDatos").append('<a href="" id="hide-link" style="display:none" >hide</a>')
        $("#hide-link").attr("data-swhglnk", true)
        $("#hide-link").attr("href", newurl).click();

        e.preventDefault();
    });
});

function SetTotalRegistrosCliente() {
    var count = $("#countListaClienteVenta").val();
    if (count == 0) {
        $(function () { $(".tDefault thead").css("display", "none"); });
    }

    $("#dgvDatos tfoot tr:last td").prepend("<a id='tfootPage' class='total_registros'></a>");
    $("#tfootPage").html($('#hdfTotalRegistros').val());
   
    $("#dgvDatos tfoot tr a, #dgvDatos thead tr a").live("click", function (e) {
        var url = $(this).attr('href');
        
        var RazonSocial = encodeURI($.trim($("#ID_RazonSocial").val()));
        var Estado = $("#IdEstado").val();
        var Region = $("#ID_Departamento").val();
        var Provincia = $("#ID_Provincia").val();
        var Sector = $("#IdClienteSector").val();
        var Categoria = $("#IdClienteCategoria").val();
        var ModoPago = $("#ID_ModoPago").val();
        var IdSucursal = $("#ID_IdSucursal").val();
        var ClienteTipo = $("#ID_ClienteTipo").val();

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
        "&RazonSocial=" + RazonSocial +
        "&IdEstado=" + Estado +
        "&IdDepartamento=" + Region +
        "&IdProvincia=" + Provincia +
        "&IdClienteSector=" + Sector +
        "&IdClienteCategoria=" + Categoria +
        "&IdModoPago=" + ModoPago +
        "&IdSucursal=" + IdSucursal +
        "&IdClienteTipo=" + ClienteTipo

        $(this).attr('href', newurl);
    });
}

function CargarModoPago() {
    var vUrl = $("#UrlModoPago").val();
    var vIdModoPago = $("#ID_ModoPago").val();
    if (vIdModoPago == "") { vIdModoPago = 0; }
    $.ajax({
        url: vUrl,
        type: "POST",
        data: {
            IdModoPago: vIdModoPago
        },
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $('#divLista').html(data);
        }
    });
}

//function CargarSucursales(vUrl) {
//    $.ajax({
//        url: vUrl,
//        type: "POST",
//        cache: false,
//        success: function (data, textStatus, jqXHR) {
//            $('#ID_DivSucursal').html(data);
//        },
//		error: function (er) {
//		}
//    });
//}

function CargarProvincia() {
    var vUrl = $("#UrlProvincia").val();
    var vIdDepartamento = $("#ID_Departamento").val();
    if (vIdDepartamento == "") {vIdDepartamento = 0; }
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
            $('#ID_Provincia').uniform();
        }
    });
}

function CargarModoPago() {
    var vUrl = $("#UrlModoPago").val();
    var vIdModoPago = $("#ID_ModoPago").val();
    if (vIdModoPago == "") { vIdModoPago = 0; }
    $.ajax({
        url: vUrl,
        type: "POST",
        data: {
            IdModoPago: vIdModoPago
        },
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $('#divListaModoPago').html(data);
        },
        complete: function () {
            $('#ID_ModoPago').uniform();
        }
    });
}

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

function RedireccionarRegistro(ParamUrl) {
    window.location = ParamUrl;
}

$(function () {
    $("#IdTipoDocumentoCliente").on("change", function () {
        var tipoDocumento = $("#IdTipoDocumentoCliente").val();
        var asterisco = $("#IdFechaVigenciaCliente").parent().prev().find("span").first();
        var fechaVigencia = "#IdFechaVigenciaCliente";
        var numDocumento = "#IdClienteRuc";
        $(fechaVigencia).val("");
        $(numDocumento).val("");
        if (tipoDocumento === '1') {
            asterisco.css("display", "none");
            $(fechaVigencia).rules("remove");
            $(fechaVigencia).prop("disabled", true);
            $(numDocumento).rules("remove","range");
            $(numDocumento).rules("add", {
                rangelength: [11,11],
                messages: {
                    rangelength: jQuery.validator.format("El campo RUC debe tener 11 caracteres")
                }
            });
        } else {
            asterisco.css("display", "");
            $(fechaVigencia).prop("disabled", false);
            $(fechaVigencia).rules("add", {
                required: true,
                messages: {
                    required: "Requerido"
                }
            });
            $(numDocumento).rules("remove", "range");
            $(numDocumento).rules("add", {
                rangelength: [8, 8],
                messages: {
                    rangelength: jQuery.validator.format("El campo DNI debe tener 8 caracteres")
                }
            });
        }
    });

    if ($("#IdTipoDocumentoCliente").val() === '1') {
        $("#IdFechaVigenciaCliente").prop("disabled", true);
    }
});

function ValidarPagoContactoCliente() {

    var valida = false;
    var FechaActivacion = $('#IdFechaActivacion').val();
    var IdRazonSocial = $('#IdRazonSocial').val();
    var IdClienteRuc = $('#IdClienteRuc').val();
    var IdNombreFantasia = $('#IdNombreFantasia').val();
    var ID_Departamento = $('#ID_Departamento').val();
    var ID_Provincia = $('#ID_Provincia').val();
    var ID_Distrito = $('#ID_Distrito').val();
    valida = Boolean( IdRazonSocial && IdClienteRuc && IdNombreFantasia && ID_Departamento && ID_Provincia && ID_Distrito);
   
    if (ValidarFecha('IdFechaActivacion')==0 && ValidarFechaMenorActual(FechaActivacion)) {
        $("#IdMsgFechaActivacion").html('La fecha no debe ser mayor a la actual');
        valida = false;
        return valida;
    }
    else {
        if (valida) {
            var className = $("#ID_tabClasificacion").attr('class');
            if (className == "") {
                if (!EsValidoTabClasificacion()) {
                    InicioJPopUpAlert('Complete la Pestaña Clasificación');
                    $("#ID_tabClasificacion").click();
                    valida = false;
                    return valida;
                }
                else
                    valida = true;
            }
        }
    
     if ($('#frmRegistrarCliente').valid()) {
            InicioJPopUpOpen('#dialogGrabarCliente');
    }
    }
}

function CancelarPagoContactoCliente() {
    $('#dialogCancelarCliente').dialog("close");
    RedireccionarConsultar();
}

function GuardarPagoContactoCliente() {
    var form = $('#frmRegistrarCliente');
    
    $.ajax({
        url: form.attr('action'),
        type: "POST",
        data: form.serializeArray(),
        success: function (data) {
            $('#dialogGrabarCliente').dialog("close");
            var msgResult = data.split('/');
            $("#dialogInformacionResultado").empty();
            $("#dialogInformacionResultado").append("<p>" + msgResult[1] + "</p>");
            $("#dialogInformacionResultado").dialog("open");
            if (msgResult[0] == "1" || msgResult[0] == "2") {
                var ParamUrl = CreateUrl('BuscarCliente', 'Cliente');
                parent.$("#btnPopAceptar").bind("click", function () { window.location = ParamUrl; });
                setTimeout('parent.$("#btnPopAceptar").click();', 3500);
            }
        },
        error: function (jqXhr, textStatus, errorThrown) {
        }
    });
}

function RedireccionarConsultar() {
    var ParamUrl = CreateUrl('BuscarCliente', 'Cliente');
    window.location = ParamUrl;
}

function EsValidoTabClasificacion() {
    var valido = false;
    var IdClienteSector = $('#IdClienteSector').val();
    var IdClienteTipo = $('#IdClienteTipo').val();
    var IdClienteCategoria = $('#IdClienteCategoria').val();
//    if (IdClienteSector == "") {
//        Editable = false;
//    }

//    if (IdClienteTipo == "") {
//        Editable = false;
//    }

//    if (IdClienteCategoria == "") {
//        Editable = false;
//    }
    Editable = Boolean(IdClienteCategoria  && IdClienteTipo && IdClienteSector);

    return Editable;
}

function EsValidoTabContacto() {
    var Editable = true;
    var ID_Departamento = $('#ID_Departamento').val();
    if (ID_Departamento == "")
        Editable = false;

    var ID_Provincia = $('#ID_Provincia').val();
    if (ID_Provincia == "")
        Editable = false;

    var ID_Distrito = $('#ID_Distrito').val();
    if (ID_Distrito == "")
        Editable = false;

    return Editable;
}

function BuscarClientePersonal() {
    var vUrl = $("#ID_Cliente_PVPersonal").val();
    var vIdCliente = $("#ID_IdCliente").val();

    $.ajax({
        url: vUrl,
        data: { IdCliente: vIdCliente },
        type: "POST",
        cache: false,
        success: function (data) {
            $("#divListaClienteContacto").html(data)
        },
        error: function (er) {
        }
    })
}

function SetTotalRegistrosContacto() {
    $("#dgvDatosContacto tfoot tr:last td").prepend("<a id='tfootPage' class='total_registros'></a>");
    $("#tfootPage").html($('#hdfTotalRegistrosPersonal').val());

    $(function () {
        $('th a, tfoot a').live('click', function () {
            $(this).attr('href', '#dgvDatosContacto');
            return false;
        });
    });

    var vIdPeriodo = $("#ID_Periodo").val();

    var url = ""
    var vIdCliente = $("#ID_IdCliente").val();

    var page = 1;
    var sort = "";
    var sortdir = "";
    var queue = "";
    var newurl = ""
    newurl = url + "?page=" + page + "&sort=" + sort + "&sortdir=" + sortdir + "&IdPeriodo=" + vIdPeriodo

    $("#dgvDatosContacto").append('<a href="" id="hide-link" style="display:none" >hide</a>')
    $("#hide-link").attr("data-swhglnk", true)
    $("#hide-link").attr("href", newurl).click();

    $("#dgvDatosContacto tfoot tr a, #dgvDatosContacto thead tr a").live("click", function (e) {
        var vIdCliente = $("#ID_IdCliente").val();

        url = $(this).attr('href');

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
        newurl = queue + "page=" + page + "&sort=" + sort + "&sortdir=" + sortdir + "&IdCliente=" + vIdCliente
        $(this).attr('href', newurl);
    });

    $(function () {
        $("#btnClose").live("click", function () {
            $("#content-nuevo-contacto").dialog("close");
        })
    });

    $(function () {
        InicioJPopUp("#content-nuevo-contacto", 800, 450, false, "Nuevo Contacto");
        InicioJPopUp("#divClienteContacto", 800, 450, false, "Editar Contacto");
    });
}

function dialogNuevoContacto() {
    $('#frmAgregarContacto').each(function () {
        this.reset();
    });

    $("#ID_IdCargoTipo option").each(function () {
        if ($(this).val() == "") {
            $(this).attr("selected", "selected").change()
        }
    });

    $("#ID_IdContactoClase option").each(function () {
        if ($(this).val() == "") {
            $(this).attr("selected", "selected").change()
        }
    });
    $("#content-nuevo-contacto").dialog("open");
}

function dialogNuevaCarteraCompartida() {
    $('#frmAgregarCarteraCompartida').each(function () {
        this.reset();
    });

    $("#content-nuevo-cartera-compartida").dialog("open");
}

function SetTotalResgitros() {
    $("#dgvDatos tfoot tr a, #dgvDatos thead tr a").live("click", function (e) {
        var vIdCliente = $("#IdCliente").val();
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

function replaceErrorMessagge(IdDiv, Message) {
    $("#" + IdDiv).replaceWith('<div style="color:Red; font-size:9px;" id="' + IdDiv + '">' + Message + '</div>');
}

function ValidarRegistro() {

    var validacion = true;
    if (formulario == "frmAgregarContacto" || formulario == "frmRegistrarClienteContacto") {
        vNombres = $('#Nombres').val();
        vApellidos = $('#Apellidos').val();
        vTipo = $('#ID_IdCargoTipo option:selected').val()
        vClase = $('#ID_IdContactoClase option:selected').val()

        if (vTipo == "") {
            validacion = false;
            $("#msgListaContactoTipo").replaceWith('<div style="color:Red; font-size:8px;" id="msgListaContactoTipo">Seleccione un Tipo.</div>');
        }
        else {
            $("#msgListaContactoTipo").replaceWith('<div style="color:Red; font-size:8px;" id="msgListaContactoTipo"></div>');
        }

        if (vClase == "") {
            validacion = false;
            $("#msgListaContactoClase").replaceWith('<div style="color:Red; font-size:8px;" id="msgListaContactoClase">Seleccione una Clase.</div>');
        }
        else {
            $("#msgListaContactoClase").replaceWith('<div style="color:Red; font-size:8px;" id="msgListaContactoClase"></div>');
        }
        
        if (vNombres.length > 2) {
            $("#msgNombres").replaceWith('<div style="color:Red; font-size:8px;" id="msgNombres"></div>');
        } else {
            validacion = false;
            $("#msgNombres").replaceWith('<div style="color:Red; font-size:8px;" id="msgNombres">Ingrese un Nombre Válido.</div>');
        }
        if (vApellidos.length > 2) {
            $("#msgApellidos").replaceWith('<div style="color:Red; font-size:8px;" id="msgApellidos"></div>');
        } else {
            validacion = false;
            $("#msgApellidos").replaceWith('<div style="color:Red; font-size:8px;" id="msgApellidos">Ingrese un Apellido Válido.</div>');
        }                
    }
    return validacion;
}

function EditarClienteContacto() {
    if (ValidarRegistro()) {
        $('#dialogInformacionActualizar').dialog('open');
        return false;
    }
    return false;
}

$(function () {
    $('#dialogInformacionActualizar').dialog({
        autoOpen: false,
        resizable: false,
        width: 400,
        modal: true,
        buttons: {
            "Si": function () {
                var form = $('#frmRegistrarClienteContacto');
                var paramUrl = "";
                paramUrl = "ModificarClienteContacto";

                $('#dialogInformacionResultado').dialog({
                    autoOpen: false,
                    resizable: false,
                    modal: true
                });

                $.ajax({
                    url: paramUrl,
                    type: "POST",
                    data: form.serialize(),
                    success: function (data) {
                        var msgResult = data.split('/');
                        
                        $('#dialogInformacionActualizar').dialog("close");
                        $("#dialogInformacionResultado").empty();

                        if (msgResult[0] == "-1")
                            $("#dialogInformacionResultado").append("<p>El contacto ingresado ya fué registrado, ingrese otro</p>")
                        else if (msgResult[0] == "0")
                            $("#dialogInformacionResultado").append("<p>Se ha producido una excepción / Seleccione datos</p>")
                        else {
                            $("#divClienteContacto").dialog("close");
                            $(this).dialog("close");                           

                            $("#dialogInformacionResultado").append("<p>Se registró correctamente</p>")
                            parent.$("#btnPopAceptar").bind("click", function () {
                                BuscarClientePersonal();  
                            });
                        }
                        $("#dialogInformacionResultado").dialog("open");
                    },
                    error: function (jqXhr, textStatus, errorThrown) {
                    }
                });

            },
            "No": function () {
                $('#dialogInformacionActualizar').dialog("close");
            }
        }
    });
});




function CancelarRegistro() {
    $('#dialogInformacionCancelar').dialog('open');
    return false;
}

$(function () {
    $('#dialogInformacionCancelar').dialog({
        autoOpen: false,
        width: 400,
        modal: true,
        resizable: false,
        buttons: {
            "Si": function () {
                ResetearMensajes();
                $('#dialogInformacionCancelar').dialog("close");
                $('#content-nuevo-cartera-compartida').dialog("close");
                $('#content-nuevo-contacto').dialog("close");
                $("#tabbContactoCliente").click();
            },
            "No": function () {
                ResetearMensajes();
                $('#dialogInformacionCancelar').dialog("close");
            }
        }
    });
});

function CancelarUPDContacto() {
    $('#dialogInformacionCancelarActualizar').dialog('open');
    return false;
}

$(function () {
    $('#dialogInformacionCancelarActualizar').dialog({
        autoOpen: false,
        width: 400,
        modal: true,
        resizable: false,
        buttons: {
            "Si": function () {
                $('#dialogInformacionCancelarActualizar').dialog("close");
                $('#divClienteContacto').dialog("close");
                $("#TabContactoCliente").click();
            },
            "No": function () {
                $('#dialogInformacionCancelarActualizar').dialog("close");
            }
        }
    });
});

function CancelarRegistroCartera() {
    $('#dialogInformacionCancelarCartera').dialog('close');
    $('#dialogNuevaCartera').dialog('close');
}

$(function () {
    $('#dialogInformacionCancelarCartera').dialog({
        autoOpen: false,
        width: 400,
        modal: true,
        resizable: false,
        buttons: {
            "Si": function () {
                $('#dialogInformacionCancelarCartera').dialog("close");
                $('#content-nuevo-cartera').dialog("close");
                $("#TabCarteraCliente").click();
            },
            "No": function () {
                $('#dialogInformacionCancelarCartera').dialog("close");
            }
        }
    });
});

function EditarContacto(IdContacto) {
    var ParamUrl = CreateUrl('EditarClienteContacto', 'Cliente');
    $.ajax({
        url: ParamUrl,
        data: {
            IdContacto: IdContacto
        },
        type: "post",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#divClienteContacto").empty();
            $('#divClienteContacto').html(data);
            InicioJPopUpOpen('#divClienteContacto');
        },
        complete: function () {
            $('#ID_IdCargoTipoEdit').uniform();
            $('#ID_IdContactoClaseEdit').uniform();
        },
        error: function (req, status, error) {
        }
    });
}

function EditarCartera(IdCartera) {
    var ParamUrl = CreateUrl('Editar_MuestraCarteraCliente', 'Cliente');
    $.ajax({
        url: ParamUrl,
        data: {
            IdCartera: IdCartera
        },
        type: "POST",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#content-modificar-cartera").empty();
            $('#content-modificar-cartera').html(data);
            InicioJPopUpOpen('#content-modificar-cartera');
        },
        complete: function () {
            $('#cboEmpleado').uniform();
            $('#cboSucursal').uniform();
        },
        error: function (req, status, error) {
        }
    });
}

function ValidaClienteCartera(IdCliente) {

    var vIdCliente = $("#ID_IdCliente").val();
    var paramurl = CreateUrl('ValidarClienteActivoCartera', 'Cliente');
     $.ajax({
         url: paramurl,
         data: {
             IdCliente: vIdCliente
         },
         type: "POST",
         cache: false,
         success: function (data) {
             var vresultado = data;
             if (vresultado == 1) {
                 InicioJPopUpOpen('#dialogEstadoClienteconCartera');
             }else {
                 InicioJPopUpOpen('#dialogEstadoClientesinCartera');
             }
         }
     });
}

function CambiarSituacionCliente() {
    var ParamUrl = CreateUrl('ActualizarEstadoCliente', 'Cliente');
    var vIdCliente = $('#IdCliente').val();
    var vIdCodigoEstado = $('#IdCodigoEstado').val();
    var vActivo = $('#Id_Activo').val() == "0" ? false: true;
    $.ajax({
        url: ParamUrl,
        type: "POST",
        data: {
            IdCliente: vIdCliente,
            IdCodigoEstado: vIdCodigoEstado,
            Activo : vActivo
        },
        cache: false,
        success: function (data) {
            $('#dialogEstadoClienteconCartera').dialog("close");
            $('#dialogEstadoClientesinCartera').dialog("close");
            InicioJPopUpAlert(data, RedireccionarConsultar);
        }
    });
}

function GuardarClienteAdjunto() {
    $('#frmRegistrarClienteAdjunto').submit();
}

function ValidarClienteAdjunto() {
    $('#frmRegistrarClienteAdjunto').submit();
    InicioJPopUpOpen('#dialogGrabarClienteAdjunto');
}


function SetTotalResgitrosClienteAdjunto() {

    $("#GrillaClienteAdjunto tfoot tr a, #GrillaClienteAdjunto thead tr a").on("click", function (e) {
        var IdCliente = encodeURI($.trim($("#IdAdjuntoIdCliente").val()));
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
        newurl = queue + "page=" + page + "&sort=" + sort + "&sortdir=" + sortdir + "&IdCliente=" + IdCliente;

        $("#GrillaClienteAdjunto tfoot tr:last td").prepend("<a id='tfootPageAdj' class='total_registros'></a>");
        $("#tfootPageAdj").html($('#hdfTotalRegistrosAdj').val());

        $(this).attr('href', newurl);

    });

}

function EliminarClienteAdjunto() {
    var ParamUrl = CreateUrl('EliminarClienteAdjunto', 'Cliente');
    var IdAdjuntoCliente = $('#IdAdjuntoCliente').val();

    $.ajax({
        url: ParamUrl,
        type: "POST",
        data: {
            IdAdj: IdAdjuntoCliente
        },
        cache: false,
        success: function (data) {
            $('#dialogEstadoCliente').dialog("close");
            InicioJPopUpAlert(data, RedireccionarGestionClienteArchivos);
        }
    });
}

function RedireccionarGestionClienteArchivos() {
    var IdCliente = $('#IdCliente').val();
    var ParamUrl = CreateUrl('GestionarCliente', 'Cliente');
    window.location = ParamUrl + "?IdCliente=" + IdCliente + "&GuardaArchivo=True";
}

function RedireccionarGestionCliente() {
    var IdCliente = $('#IdCliente').val();
    var ParamUrl = CreateUrl('GestionarCliente', 'Cliente');
    window.location = ParamUrl + "?IdCliente=" + IdCliente;
}

function AbrirPopupEliminarCliente(IdAdj) {
    $('#IdAdjuntoCliente').val(IdAdj);
    InicioJPopUpOpen('#dialogEliminarClienteAdjunto');
}


function validateFileUpload(obj) {
    
    var fileName = new String();
    var fileExtension = new String();

    fileName = obj.value;
    fileExtension = fileName.substr(fileName.lastIndexOf('.'));

    var flag = false;
    var extension = $("#ValorCadenaConFig").val();
    var arrayExtention = new Array();
    arrayExtention = extension.split(',');

    for (var index = 0; index < arrayExtention.length; index++) {
        if (fileExtension.toLowerCase() == arrayExtention[index].toString().toLowerCase()) {
            flag = true;
        }
    }

    if (flag == false) {
        $("#FileUploadCliente").val('');
        $("#ID_FileUpLoad").val('');
       
        InicioJPopUpAlert('Solo se permite la carga de las siguientes extensiones: ' + arrayExtention);
        return false;
    }
    else {
        ValidarTamanioArchivosUpload(obj);
        return true;
    }
}

function ValidarTamanioArchivosUpload(archivo) {
    var tamanio = 0;
    var browserInfo = navigator.userAgent.toLowerCase();
  
    if (browserInfo.indexOf("msie") > -1) {
        /* IE */
//        var filepath = archivo.value;
//        var myFSO = new ActiveXObject("Scripting.FileSystemObject");
//        var thefile = myFSO.getFile(filepath);
//        tamanio = thefile.size;
        return true;
    } else {
        /* Other */
        tamanio = archivo.files[0].size;
        permitida = false;
        var longfile = $("#ValorEnteroConFig").val();
        if (tamanio <= longfile) {
            permitida = true;
        }

        if (!permitida) {
            $("#FileUploadCliente").val('');
            InicioJPopUpAlert('El archivo excede los 10Mb. ');
            archivo.value = '';
            return false;
        } else {
            return true;
        }
    }
}

function getFileSize(inputFile) {
    var size;
    if (window.ActiveXObject) {
        try {
            var strFileName = inputFile.value;
            var objFSO = new ActiveXObject("Scripting.FileSystemObject");
            var e = objFSO.getFile(strFileName);
            size = e.size;
        } catch (e) {
            return true;
        }
    } else {
        size = inputFile[0].files[0].size;
    }
    return size;
}

function SetTotalRegistrosCarteraCliente() {
    $("#dgvDatos tfoot tr:last td").prepend("<a id='tfootPage' class='total_registros'></a>");
    $("#tfootPage").html($('#hdfTotalRegistros').val());

    $(function () {
        $('th a, tfoot a').live('click', function () {
            $(this).attr('href', '#dgvDatos');
            return false;
        });
    });

    $("#dgvDatos tfoot tr a, #dgvDatos thead tr a").live("click", function (e) {
        var IdGrupo = $("#IdGrupo").val();
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
        newurl = queue + "page=" + page + "&sort=" + sort + "&sortdir=" + sortdir + "&IdGrupo=" + IdGrupo
        $(this).attr('href', newurl);
    });
}

function CargarEmpleados() {   
    var vUrl = $("#UrlEmpleado").val();
    var vIdSucursal = $("#cboSucursal").val();
    if (vIdSucursal == "") { vIdSucursal = 0; }
    $.ajax({
        url: vUrl,
        type: "POST",
        data: {
            IdSucursal: vIdSucursal
        },
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $('#divListaComboEmpleados').html(data);
        },
        complete: function () {
            $("#cboEmpleados").uniform();
        },
        error: function (er) {
        }
    });

        $("#msgListaSucursal").replaceWith('<div style="color:Red; font-size:8px;" id="msgListaSucursal"></div>');
    
}
function OnChange_ComboEmpleado() {    
        $("#msgListaEmpleado").replaceWith('<div style="color:Red; font-size:8px;" id="msgListaEmpleado"></div>'); 
}


//$(function () {
//    $(".chk_sucursales").live("click", function () {
//       
//        arr = new Array();
//        $(".chk_sucursales").each(function () {

//            if ($(this).attr("checked") == "checked") {
//                arr.push($(this).val())
//            }
//        });

//        var vUrl = $("#UrlEmpleado").val();
//        var vIdSucursal = arr.toString();
//        if (vIdSucursal == "") { vIdSucursal = 0; }

//        $.ajax({
//            url: vUrl,
//            type: "POST",
//            data: {
//                IdSucursal: vIdSucursal
//            },
//            cache: false,
//            success: function (data, textStatus, jqXHR) {
//                $('#divListaComboEmpleados').html(data);
//            },
//            complete: function () {
//                $("#cboEmpleados").uniform();
//            },
//            error: function (er) {
//            }
//        });
//    });
//});

function EnterSubmit(e, buttonClick) {
    tecla = (document.all) ? e.keyCode : e.which;
    if (tecla == 13) {
        var obj = document.getElementById(buttonClick);
        obj.click();
    }
}


//PARA AGREGAR LA CARTERA DE CLIENTES*********************************************************************************************************************++
var formulario1;
function RegistrarCartera(form) {
    formulario1 = form;
    if (ValidarRegistroCartera()) {
        $('#dialogInformacionGuardarCartera').dialog('open');
        return false;
    }
    return false;
}

$(function () {
    $('#dialogInformacionGuardarCartera').dialog({
        autoOpen: false,
        resizable: false,
        width: 400,
        modal: true,
        buttons: {
            "Si": function () {
                var form = $('#' + formulario1);
                var paramUrl = "";
                //(formulario == 'frmAgregarCarteraCliente') ? paramUrl = "AgregarCarteraCliente": paramUrl = "GestionarCliente";
                paramUrl = CreateUrl('AgregarCarteraCliente', 'Cliente');
                $('#dialogInformacionResultadoCartera').dialog({
                    autoOpen: false,
                    resizable: false,
                    modal: true
                });                
                arr = new Array();
                $(".chk_sucursales").each(function () {
                    if ($(this).attr("checked") == "checked") {
                        arr.push($(this).val());
                    }
                });

                var vIdSucursal = arr.toString();
                $("#ID_idSucursales").val(vIdSucursal);

                $.ajax({
                    url: paramUrl,
                    type: "POST",
                    data: form.serialize(),
                    success: function (data, textStatus, jqXHR) {
                        var msgResult = data.split('/');
                        $('#dialogInformacionGuardarCartera').dialog("close");
                        $("#dialogInformacionResultadoCartera").empty();                       

                            $(this).dialog("close");
                            $("#content-nuevo-cartera").dialog("close");

                            $("#dialogInformacionResultadoCartera").append("<p>" + msgResult[1] + "</p>");
                            $("#dialogInformacionResultadoCartera").dialog("open");
                            parent.$("#btnPopAceptar1").bind("click", function () {
                                ListarCarteraClientes();    
                            });
                            if (msgResult[0] == "1") {
                                parent.$("#btnPopAceptar1").bind("click", function () { ListarCarteraClientes(); });
                                setTimeout('parent.$("#btnPopAceptar1").click();', 3000);
                                $("#dialogInformacionGuardarCartera").dialog("close");
                            }
                            
                    },
                    error: function (jqXhr, textStatus, errorThrown) {
                    }
                });

            },
            "No": function () {
                $('#dialogInformacionGuardarCartera').dialog("close");
            }
        }
    });
});




$(function () {
    $('#dialogInformacionResultadoCartera').dialog({
        autoOpen: false,
        resizable: false,
        closeOnEscape: false,
        open: function (event, ui) { $(".ui-dialog-titlebar-close", this.parentNode).hide(); },
        width: 400,
        buttons: [{
            id: "btnPopAceptar1",
            text: "Aceptar",
            click: function () {
                $(this).dialog("close");
            }
        }]
    });
});


var TipoEmpleado;

function CargarSucursales(vUrl,tipo, SiList) {    
//    vUrl = tipo == 1 ? $("#UrlEmpleado").val() : $("#UrlSucursales").val()
    $("#ID_idCarteraEmpleadoTipo").val(tipo);
    TipoEmpleado = tipo;
    $.ajax({
        url: vUrl,
        type: "POST",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $('#ID_DivSucursal').html(data);
            CargarEmpleados();
        },
        error: function (er) {
        },
        complete: function(){
            if(SiList == 1){
                checksSucursales = [];
                SetTotalRegistrosSucursales();
                MemoryChecks(1,true);
            }
        }
    });
    $("#msgListaSucursal").replaceWith('<div style="color:Red; font-size:8px;" id="msgListaSucursal"></div>');
    $("#msgListaEmpleado").replaceWith('<div style="color:Red; font-size:8px;" id="msgListaEmpleado"></div>');
}

//Para guardar el rango de fechas de cartera compartida
//listar fechas carteracompartida

function ListarFechasCarteraCompartida() {
    var vUrl = $("#ID_UrlCarteraCompartidaFechas").val();
    var vIdCliente = $("#IdCliente").val();
    $.ajax({
        url: vUrl,
        data: { IdCliente: vIdCliente },
        type: "POST",
        cache: false,
        success: function (data) {
            $("#divListaCarteraCompartida").html(data)
        },
        error: function (er) {
        }
    })
}


function ResetearMensajes() {
    $("#msgFechaInicio").replaceWith('<div style="color: Red; font - size: 8px; " id="msgFechaInicio"></div>');
    $("#msgFechaFin").replaceWith('<div style="color: Red; font - size: 8px; " id="msgFechaFin"></div>');
}

var formularioCarteraCompartida;
function RegistrarCarteraCompartida(form) {
    
    formulario = form;
    if (ValidarRegistroFechas()) {
        $('#dialogInformacionFechasCarteraGuardar').dialog('open');
        return false;
    }
    return false;
}

function ValidarRegistroFechas() {
    var validacion = true;
    if (formulario == "frmAgregarCarteraCompartida") {
        vFechaInicio = $('#FechaInicio').val();
        vFechaFin = $('#FechaFin').val();

        if (vFechaInicio == '') {
            validacion = false;
            $("#msgFechaInicio").replaceWith('<div style="color:Red; font-size:8px;" id="msgFechaInicio">Ingrese la fecha de inicio.</div>');
        }

        if (vFechaFin == '') {
            validacion = false;
            $("#msgFechaFin").replaceWith('<div style="color:Red; font-size:8px;" id="msgFechaFin">Ingrese la fecha fin.</div>');
        }

        var sFechaInicio = vFechaInicio.split("/")
        var diaI = sFechaInicio[0];
        var mesI = sFechaInicio[1];
        var anoI = sFechaInicio[2];
        var FechaInicioUnida = anoI + '' + mesI + ''+diaI


        var sFechaFin = vFechaFin.split("/")
        var diaF = sFechaFin[0];
        var mesF = sFechaFin[1];
        var anoF = sFechaFin[2];
        var FechaFinUnida = anoF + '' + mesF +''+diaF

        if (FechaFinUnida < FechaInicioUnida) {
            validacion = false;
            $("#msgFechaFin").replaceWith('<div style="color:Red; font-size:8px;" id="msgFechaFin">La fecha fin no puede ser menor a la fecha inicio.</div>');
        }
    }
    return validacion;
}

$(function () {
    $('#dialogInformacionFechasCarteraGuardar').dialog({
        autoOpen: false,
        resizable: false,
        width: 400,
        modal: true,
        buttons: {
            "Si": function () {
                var form = $('#' + formulario);
                var paramUrl = "";
                if (formulario == 'frmAgregarCarteraCompartida') { paramUrl = "AgregarFechasCarteraCompartida" }

                $('#dialogInformacionFechasResultado').dialog({
                    autoOpen: false,
                    resizable: false,
                    modal: true
                });

                $.ajax({
                    url: paramUrl,
                    type: "POST",
                    data: form.serialize(),
                    success: function (data, textStatus, jqXHR) {
                        var msgResult = data.split('/');
                        $('#dialogInformacionFechasCarteraGuardar').dialog("close");
                        $(this).dialog("close");
                        $("#content-nuevo-cartera-compartida").dialog("close");
                        $("#dialogInformacionFechasResultado").empty();
                        $("#dialogInformacionFechasResultado").append("<p>" + msgResult[1] + "</p>");

                        if (msgResult[0] == "1") {
                            ResetearMensajes();
                            $("#dialogInformacionFechasResultado").dialog("open");
                            parent.$("#btnPopAceptar2").bind("click", function () { ListarFechasCarteraCompartida(); });
                            setTimeout('parent.$("#btnPopAceptar2").click();', 3000);
                            
                            $("#dialogInformacionFechasCarteraGuardar").dialog("close");
                        }
                        else {
                            $("#dialogInformacionFechasResultado").dialog("open");
                            parent.$("#btnPopAceptar2").bind("click", function () {
                                $(this).dialog("close");
                            });
                        }
                    },
                    error: function (jqXhr, textStatus, errorThrown) {
                    }
                });

            },
            "No": function () {
                ResetearMensajes();
                $('#dialogInformacionFechasCarteraGuardar').dialog("close");
            }
        }
    });
});

$(function () {
    $('#dialogInformacionFechasResultado').dialog({
        autoOpen: false,
        resizable: false,
        closeOnEscape: false,
        open: function (event, ui) { $(".ui-dialog-titlebar-close", this.parentNode).hide(); },
        width: 400,
        buttons: [{
            id: "btnPopAceptar2",
            text: "Aceptar",
            click: function () {
                $(this).dialog("close");
            }
        }]
    });
});

function SetTotalRegistrosFechasCarteraCompartida() {
    $("#dgvDatosFechasCartera tfoot tr:last td").prepend("<a id='tfootPage' class='total_registros'></a>");
    $("#tfootPage").html($('#hdfTotalRegistrosFechas').val());

    $(function () {
        $('th a, tfoot a').live('click', function () {
            $(this).attr('href', '#dgvDatosFechasCartera');
            return false;
        });
    });

    var vIdPeriodo = $("#ID_Periodo").val();

    var url = ""
    var vIdCliente = $("#ID_IdCliente").val();

    var page = 1;
    var sort = "";
    var sortdir = "";
    var queue = "";
    var newurl = ""
    newurl = url + "?page=" + page + "&sort=" + sort + "&sortdir=" + sortdir + "&IdPeriodo=" + vIdPeriodo

    $("#dgvDatosFechasCartera").append('<a href="" id="hide-link" style="display:none" >hide</a>')
    $("#hide-link").attr("data-swhglnk", true)
    $("#hide-link").attr("href", newurl).click();

    $("#dgvDatosFechasCartera tfoot tr a, #dgvDatosFechasCartera thead tr a").live("click", function (e) {
        var vIdCliente = $("#ID_IdCliente").val();

        url = $(this).attr('href');

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
        newurl = queue + "page=" + page + "&sort=" + sort + "&sortdir=" + sortdir + "&IdCliente=" + vIdCliente
        $(this).attr('href', newurl);
    });

    $(function () {
        $("#btnClose").live("click", function () {
            $("#content-nuevo-cartera-compartida").dialog("close");
        })
    });

    $(function () {
        InicioJPopUp("#content-nuevo-cartera-compartida", 800, 300, false, "Gestionar Cartera");
        //InicioJPopUp("#divClienteContacto", 800, 450, false, "Editar Contacto");
    });
}
//fIN guardar el personal contacto

//Para guardar el personal contacto ******************************************************************************************
var formulario;
function RegistrarContacto(form) {
    formulario = form;
    if (ValidarRegistro()) {
        $('#dialogInformacionGuardar').dialog('open');
        return false;
    }
    return false;
}

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
                (formulario == 'frmAgregarContacto') ? paramUrl = "AgregarContacto" : paramUrl = "GestionarCliente";

                $('#dialogInformacionResultado').dialog({
                    autoOpen: false,
                    resizable: false,
                    modal: true
                });

                $.ajax({
                    url: paramUrl,
                    type: "POST",
                    data: form.serialize(),
                    success: function (data, textStatus, jqXHR) {
                        var msgResult = data.split('/');
                        $('#dialogInformacionGuardar').dialog("close");
                        $(this).dialog("close");
                        $("#content-nuevo-contacto").dialog("close");
                        $("#dialogInformacionResultado").empty();
                        $("#dialogInformacionResultado").append("<p>" + msgResult[1] + "</p>");
                        if (msgResult[0] == "1") {
                            $("#dialogInformacionResultado").dialog("open");
                            parent.$("#btnPopAceptar").bind("click", function () { BuscarClientePersonal(); });
                            setTimeout('parent.$("#btnPopAceptar").click();', 3000);
                            $("#dialogInformacionGuardarCartera").dialog("close");
                        }
                        else {
                            $("#dialogInformacionResultado").dialog("open");
                            parent.$("#btnPopAceptar").bind("click", function () {
                                $(this).dialog("close");
                            });
                        }

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
//fIN guardar el personal contacto ****************************************************************************************


function ValidarRegistroCartera() {
    var validacion = true;
    if (formulario1 == "frmAgregarCarteraCliente" || formulario1 == "frmActualizarCarteraCliente") {
        var vTipo = TipoEmpleado;
        if (vTipo == "1") {
            var vSucursal = $('#cboSucursal option:selected').val();
            if (vSucursal == "") {
                validacion = false;
                $("#msgListaSucursal").replaceWith('<div style="color:Red; font-size:8px;" id="msgListaSucursal">Seleccione Sucursal(es).</div>');
            }
            else {
                $("#msgListaSucursal").replaceWith('<div style="color:Red; font-size:8px;" id="msgListaSucursal"></div>');
            }
        }
        else {
            arr = new Array();
            $(".chk_sucursales").each(function () {
                if ($(this).attr("checked") == "checked") {
                    arr.push($(this).val())
                }
            });
            var vIdSucursales = arr.toString();
            if (vIdSucursales == "") {
                validacion = false;
                $("#msgListaSucursal").replaceWith('<div style="color:Red; font-size:8px;" id="msgListaSucursal">Seleccione Sucursal(es).</div>');
            }
            else {
                $("#msgListaSucursal").replaceWith('<div style="color:Red; font-size:8px;" id="msgListaSucursal"></div>');
            }
        }
        var vEmpleado = $('#cboEmpleados option:selected').val();
        if (vEmpleado == "") {
            validacion = false;
            $("#msgListaEmpleado").replaceWith('<div style="color:Red; font-size:8px;" id="msgListaEmpleado">Seleccione un empleado.</div>');
        }
        else {
            $("#msgListaEmpleado").replaceWith('<div style="color:Red; font-size:8px;" id="msgListaEmpleado"></div>');
        }
    }
    return validacion;
}


//////////============================================= ACTIVAR  Y DESACTIVAR CARTERA CON EMPLEADO ASIGNADO =============================//////////////////////////////////////

 function DesactivarCarteraCliente(UrlUsu, IdUsu) {
     GUrlUsu = UrlUsu;
     GIdUsu = IdUsu;
     GUrlDestino = $("#ID_UrlCartera").val();
     $('#dialogInformacionDesactivar').dialog("open");
     return false;
 }
// function CambiarSituacionCartera(IdCartera, activo,IdCliente) {
 function CambiarSituacionCartera(IdCartera,IdCliente,FechaAsignacion) {
     vIdCartera = IdCartera;
    // vIdEstado = activo
     vIdCliente = IdCliente;
     vFechaAsig = FechaAsignacion;
     $("#MsgErrorFec").html("");
     $("#iIdFechaDesasignacion").val("");
     InicioJPopUpConfirmOpen('#dialogEstadoCartera');
 }

function ActualizarEstadoCartera() {
    var ParamUrl = CreateUrl('ActualizarEstadoCartera', 'Cliente');
    var IdCartera = vIdCartera;
  //  var IdEstado = vIdEstado
    var IdCliente = vIdCliente;      
    var FechaAsig = vFechaAsig;
    
    var FechaDesg = $("#iIdFechaDesasignacion").val();

    if ( FechaDesg != "__/__/____")
    {
        $.ajax({
            url: ParamUrl,
            data: {
                IdCartera: IdCartera,
                IdCliente : IdCliente,
                FechaAsignacion: FechaAsig,
                FecDesasignacion: FechaDesg
            },
            type: "POST",
            cache: false,
            success: function (data, textStatus, jqXHR) {
                
                    var SplitMsg = data.split("/");
                    if ( SplitMsg[0].toString() == "1")
                    {
                        $("#MsgErrorFec").html("<label class='error'> " +SplitMsg[1].toString() + "</label>");
                    }else{

                         $('#dialogEstadoCartera').dialog("close");
 
                         InicioJPopUpAlert(data, ListarCarteraClientes);

                    }

              
            }
        });

    }else{
        $("#MsgErrorFec").html("<label class='error'>Ingrese fecha desasignación. </label>");
    }
}

var CerrarPopUp = function()
{
     $("#MsgErrorFec").html("");
     $('#dialogEstadoCartera').dialog("close");
}
    ///////////////////////////////////     DESACTIVAR EL ESTA DE LA CARTERA   ///////////////////////////////////////////////////
//var vIdCartera;
//var vIdCliente;

function CambiarEstadoCarteraCliente(IdCartera,IdCliente) {
        vIdCartera = IdCartera;
        vIdCliente = IdCliente;
        InicioJPopUpConfirmOpen('#dialogEstadoCarteraCliente');
 }


function DesactivarCarteraCliente(){
    var IdCliente = vIdCliente
    var IdCartera = vIdCartera
    var ParamUrl = CreateUrl('ActualizarEstadoCarteraCliente', 'Cliente');

     $.ajax({
        url : ParamUrl,
        type: "POST",
        data:{
            IdCliente : IdCliente,
            IdCartera : IdCartera
        },
        cache : false,
        success : function(data){
            $('#dialogEstadoCarteraCliente').dialog("close");
            InicioJPopUpAlert(data, ListarCarteraClientes);
        }     
     });
}

/////////////////////======================   QUERY PARA MOSTRAR SUCURSALES POR ZONA   =======================////////////////////////////////////

function CargarSucursalesporZona() {

   var vUrl = $("#UrlZonaInactiva").val();
   var vIdZona = $("#ID_IdzonaInactiva").val();
   if (vIdZona == "") {
       vIdZona = 0;
       CargarVendedorporSucursalInactivo();
       CargarClienteporVendedores();
   
   }
   $.ajax({
       url: vUrl,
       data: {
           IdZona: vIdZona
       },
       type: "POST",
       cache: false,
       success: function (data, textStatus, jqXHR) {
           $("#DivListaSucursalporZona").html(data);

       },
       complete: function () {
           $('#ID_IdSucursalInactivo').uniform();

       }
   });
}
function CargarSucursalesporZonaActiva() {
    var vUrl = $("#UrlZonaActiva").val();
    var vIdZona = $("#ID_IdzonaActiva").val();
    if (vIdZona == "") 
    {
        vIdZona = 0;
        CargarVendedorporSucursalActivo();
        CargarClienteporVendedorActivo();
     }
    $.ajax({
        url: vUrl,
        data: {
            IdZona: vIdZona
        },
        type: "POST",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#DivListaSucursalporZonaActiva").html(data);
        },
        complete: function () {
            $('#ID_IdSucursalActivo').uniform();
        }
    });
}

 ////////////////////======================= MOSTRAR EMPLEADO POR ESTADO, YA SEA ACTIVO O INACTIVO   ==============================//////////////////////////

 function CargarVendedorporSucursalInactivo() {
     var vUrl = $("#UrlVendedor").val();
     var vIdSucursal = $("#ID_IdSucursalInactivo").val();
     var vestado = true;
     if (vIdSucursal == "") { vIdSucursal=0 }
     $.ajax({
         url: vUrl,
         type: "POST",
         data: {
             IdSucursal: vIdSucursal,
             Idestado: vestado
         },
         cache: false,
         success: function (data, textStatus, jqXHR) {
             $('#divListaVendedorInactivo').html(data);
         },
         complete: function () {
             $('#ID_IdEmpleado').uniform();
         }
     });
 }

 function CargarVendedorporSucursalActivo() {
     var vUrl = $("#UrlVendedorActivo").val();
     var vIdSucursal = $("#ID_IdSucursalActivo").val();
     var IdEmpleado = $("#ID_IdEmpleado").val();
     if (IdEmpleado=="") 
     {IdEmpleado=0}
     var vestadoa = true;
     if (vIdSucursal == "") { vIdSucursal=0 }
     $.ajax({
         url: vUrl,
         type: "POST",
         data: {
             IdSucursal: vIdSucursal,
             Idestado: vestadoa,
             IdVendedor : IdEmpleado
         },
         cache: false,
         success: function (data, textStatus, jqXHR) {
             $('#divListaVendedorActivo').html(data);
         },
         complete: function () {
             $('#ID_IdEmpleadoActivo').uniform();
         }
     });
 }


 ///////////////////////////////////////////////////   NUEVO JQUERY PARA LISTAR CLIENTES  ////////////////////////////////////////////////////

 function CargarClienteporVendedores() {
     var vUrl = $("#ID_UrlClienteporVendedor").val();
     var vIdEmpleado = $("#ID_IdEmpleado").val();
     if(vIdEmpleado == ""){ vIdEmpleado=0 }
     $.ajax({
         url: vUrl,
         data: {
             IdEmpleado: vIdEmpleado
         },
         type: "POST",
         cache: false,
         success: function (data, textStatus, jqXHR) {
            var combos = data.toString().split('<br/>');
              $("#lstclienteVenta").html(combos[0]);
         },
         complete: function () {
             $('#box1View').uniform();
             var count1 = $("#box1View option").size();
             $("#box1Counter").text('Mostrando ' + count1 + ' de ' + count1);
         }
     });
 }

 function CargarClienteporVendedorActivo() {
     var vUrl = $("#ID_UrlClienteporVendedorActivos").val();
     var vIdEmpleado = $("#ID_IdEmpleadoActivo").val();
     if(vIdEmpleado == ""){vIdEmpleado =0}
     $.ajax({
         url: vUrl,
         data: {
             IdEmpleado: vIdEmpleado
         },
         type: "POST",
         cache: false,
         success: function (data, textStatus, jqXHR) {
             $('#lstclienteventa2').html(data);
         },
         complete: function () {
             $('#box2View').uniform();
             var count2 = $("#box2View option").size();
             $("#box2Counter").text('Mostrando ' + count2 + ' de ' + count2);
         }
     });

  }

  function UpdateLabel(group) {
      var showingCount = $("#" + group.view + " option").size();
      var hiddenCount = $("#" + group.storage + " option").size();
      $("#" + group.counter).text('Mostrando ' + showingCount + ' de ' + (showingCount + hiddenCount));
  }
  //////////////////////////////////////////////  CREAR JQUERY PARA INSERTAR VENDEDOR ACTIVO CON CLIENTES  ////////////////////////////////////////////////

  function AsignarClienteVendedor(paramUrl) {
      if ($("#ID_IdEmpleadoActivo").val() == '') {
          scrollTo(0, 0);
          return false;
       }else if($("#ID_IdSucursalActivo").val() == ''){
          scrollTo(0, 0);
          return false;
       }

       if($("#ID_IdSucursalInactivo").val() == ''){
           scrollTo(0, 0);
           return false;
       }

      var clientes = $("#box2View option");
      idClientes = new Array();
      $(clientes).each(function (i) {
          idClientes[i] = $(this).val();
      });

      var clientes1 = $("#box1View option");
      idClientes1 = new Array();
      $(clientes1).each(function (i) {
          idClientes1[i] = $(this).val();
      });
  
      $.ajax({
          url: paramUrl,
          data: {
              idClientes: idClientes.toString(),
              idClientes1: idClientes1.toString(), 
              idEmpleado: $("#ID_IdEmpleadoActivo").val(),
              idempleadoantiguo: $("#ID_IdEmpleado").val(),
              //idEmpleado1: $("#ID_IdEmpleado").val(),
              idSucursal: $("#ID_IdSucursalActivo").val(),
              idSucursal1:$("#ID_IdSucursalInactivo").val(),
              IdFechaActivacion: $("#ID_FechaActivacion").val(),
              __RequestVerificationToken: $("input[name='__RequestVerificationToken']").val()
          },
          type: "POST",
          success: function (data) {
            var result = data.split("/");
            if (result[0] == 1 || result[0] == 2) {
              } 
              InicioJPopUpAlert(result[1], null);
              },
             error: function (jqXhr, textStatus, errorThrown) {
             }
      });
  }


  function dialogCancelarGestionReasignar() {
      InicioJPopUpOpen('#dialogCancelarGestionReasignar');
  }
  function CancelarRegistroReasignar() {
      RedireccionarCancelarReasignacion();
  }


  function RedireccionarCancelarReasignacion() {
      window.location.href = "/Cliente/BuscarCliente";
  }



/////////////////////////////////////////   QUERY PARA OBTENER FECHA DE ACTIVACION EN CASO EL EMPLEADO HAYA SIDO DESACTIVADO ////////////////////

  function ObtenerFechaActivacionEmpleado() {
      var ParamUrl = CreateUrl('PVFechaActivacionporEmpleado', 'Cliente');
      var vIdCliente = $("#ID_IdCliente").val();
      var vIdEmpleado = $("#cboEmpleados").val();

      $.ajax({
          url: ParamUrl,
          data: {
              IdCliente: vIdCliente,
              IdEmpleado: vIdEmpleado
          },
          type: "POST",
          cache: false,
          success: function (data) {
              $('#divListaFechaActivacion').html(data);
          },
          complete: function () {
              $("#ID_FechaActivacion").uniform();
          },
          error: function (er) {
          }
      });
  }

   ///////////////////////////////////       MODIFICAR CARTERA CLIENTES POR EMPLEADO               /////////////////////////////////////////////


   function GuardarCartera() {
//   var arrays = new Array();
//   arrays = $('#cboSucursal').val()
//   if(arrays == null){
//        arrays=''
//   }else{
//     arrays = $('#cboSucursal').val()
//   }
//   var vSucursal = arrays.toString();
    var vTipo = TipoEmpleado
    var vIdSucursal;
    var arr;
   if (vTipo == "1") {
       arr = new Array();
       arr = $('#cboSucursal').val();
     if (vIdSucursal == "") {
            
        }
    }
    else{
          arr = new Array();
       $(".chk_sucursales").each(function() {
           if ($(this).attr("checked") == "checked") {
               arr.push($(this).val());
           }
       });
   }
    vIdSucursal = arr.toString();
    $("#ID_idSucursales").val(vIdSucursal);
    if ($("#ID_TCompartida").val() === 0) {
        $("#ID_TCompartida").val(1);
    }        
       var form = $('#frmAgregarCarteraClientes');
       $.ajax({
           url: form.attr('action'),
           type: "POST",
           data: form.serialize(),
           success: function (data) {
               var result = data.split("/");
               if (result[0] == 1 || result[0] == 2) {
                   $('#dialogNuevaCartera').dialog("close");
                   ListarCarteraClientes()
               }            
               InicioJPopUpAlert(result[1], null);
//                $("#dialogRegistrarCartera").html("<p>¿Desea registrar la cartera?</p>");
//                $("#dialogRegistrarCartera").dialog("open");
           },
           error: function (jqXhr, textStatus, errorThrown) {
           }
       });
          
    }
    

    function dialogNuevaCartera() { 
        var ParamUrl = CreateUrl("NuevaCarteraCliente", "Cliente")
        var vIdCliente = $("#ID_IdCliente").val();
        $.ajax({
            url: ParamUrl,
            data: {
                IdCliente: vIdCliente
            },
            type: "get",
            cache: false,
            success: function (data, textStatus, jqXHR) {
                $("#dialogNuevaCartera").html(data);
                $("#IdRazonSocial").uniform();
                $("#rbtPrincipal").uniform();
                $("#rbtSecundario").uniform();
                $("#ID_idSucursales").val();
                $("#cboEmpleados").uniform();
                $("#ID_FechaActivacion").uniform();
                InicioJPopUpOpen('#dialogNuevaCartera');
                VerificarRegistroCartera();                
            },
            error: function (jqXhr, textStatus, errorThrown) {
            }
        });
    }

    function RegistrarNuevaCartera() {
        var valido = true;
        $("#frmAgregarCarteraClientes").each(function () { 
            $.data($(this)[0], 'validator', false); 
        });
        $.validator.unobtrusive.parse("#frmAgregarCarteraClientes");
        if ($('#rbtSecundario').is(':checked')){
            valido = Boolean(esFechaAsignacionValida() & esEmpleadoValido() & esSucursalValida());
            if (valido){
                 ValidarCarteraPrincipal();
            }
        }
        else{
        
            if ($('#cboSucursal').val() == ""){
            replaceErrorMessagge("msgListaSucursal", "Seleccione alguna sucursal");
            valido = false;
            }
            if ($('#cboEmpleados').val() == ""){
                replaceErrorMessagge("ID_MsgcboEmpleados", "Seleccione algún empleado");
                valido = false;
            }
            if(!$('#ID_Porcentaje').val()){
                replaceErrorMessagge("msgPorcentaje", "Ingrese un porcentaje");
                valido = false;
            }else{
                if (!(0 <= $("#ID_Porcentaje").val() && $('#ID_Porcentaje').val() <= 100)) {
                    //64
                    //36336
                    replaceErrorMessagge("msgPorcentaje", "Porcentaje debe estar entre 0 y 100");
                    valido = false;
                }else{
                     replaceErrorMessagge("msgPorcentaje", "");
                    valido = true;
                }               
             }
             if(document.getElementById("ID_FechaActivacion").value.trim() != ''){
                if (ValidarFecha("ID_FechaActivacion") != 0){
                    replaceErrorMessagge("ID_MsgFechaActivacion", "Ingrese una fecha de asignación correcta");
                }else {
                    var FSRRVV = $('#FechaSucursalUltimoRRVV').val().toString().substring(0, 10);
                    var FCRRVV = $('#FechaContratoRRVV').val().toString().substring(0, 10);
                    var FA = $('#ID_FechaActivacion').val().toString().substring(0, 10);

                    replaceErrorMessagge("ID_MsgFechaActivacion", "");
                    if(Comparar_Fechas(FSRRVV, FA)){
                        replaceErrorMessagge("ID_MsgFechaActivacion", "Fecha asignación debe ser mayor a fecha ingreso empleado");
                    } else if(Comparar_Fechas(FSRRVV, FA)){
                        replaceErrorMessagge("ID_MsgFechaActivacion", "Fecha asignación debe ser mayor a fecha contrato empleado");
                    } else if (valido) {
                        ValidarCarteraPrincipal();
                    }
                }
             }else {
                 replaceErrorMessagge("ID_MsgFechaActivacion", "Ingrese una fecha");
             }
        }        
    }

function DialogCancelarRegistroCargo() {
    InicioJPopUpOpen('#dialogCancelarCartera');
}

//function CancelarRegistroCartera() {
//    $('#dialogNuevaCartera').dialog('close');
//}

     ///////////////////////////////////   VALIDAR CARTERA PRINCIPAL    //////////////////////////////////////////////

function ValidarCarteraPrincipal() {
    var vIdCliente = $("#ID_IdCliente").val();
    var vIdEmpleado = $("#rbtPrincipal").is(":checked") ? $("#cboEmpleados").val() : $("#HdnIdEmpleado").val();
    var ParamUrl = CreateUrl('ValidarClienteCarteraPrincipal','Cliente');

      $.ajax({
        url : ParamUrl,
        data: {
            IdCliente : vIdCliente,
            IdEmpleado : vIdEmpleado
        },
        type: "POST",
        cache: false,
        success: function (data, textStatus, jqXHR) {
 
         var result = data;
            if (result == 1) {
                $("#dialogRegistrarCartera").html("<p>¿Desea registrar la cartera?</p>" + "<p>Nota: Si registra una nueva sucursal, se desactivará la sucursal registrada anteriormente.</p>");     
                $("#dialogRegistrarCartera").dialog("open");
            }else if (result == 2){
                $("#dialogRegistrarCartera").html("<p>¿Desea registrar la cartera?</p>");
                $("#dialogRegistrarCartera").dialog("open");
            }else if (result == 3){
                $("#dialogRegistrarCartera").html("<p>¿Desea registrar la cartera?</p>");
                $("#dialogRegistrarCartera").dialog("open");
            }else {
                $("#dialogInformacionResultadoCartera").html("<p>Existe un Mesón en la cartera de este cliente,para asignar un empleado debe desactivarlo </p>");
                $("#dialogInformacionResultadoCartera").dialog("open");
                $("#dialogNuevaCartera").dialog("close");
            }
        },
          error: function (jqXhr, textStatus, errorThrown) {
        }
    });
 }



    //////   VALIDAR CARTERA    ////////////////

    function ValidarCartera() {
        var vtipoPrincipal = $("#rbtPrincipal").val();
        var vtipoSecundario = $("#rbtSecundario").val();
        if ($("#rbtPrincipal").is(":checked")) {
            state = true;
            $("#rbtSecundario").attr(state ? 'disabled' : 'disabled');
        } else {
            state = false;
            $("#rbtSecundario").attr(state ? 'enable' : 'enable');
         }
    }

    function DesHabilitarPorcentaje() {
        if ($("#rbtPrincipal").is(":checked") === true) {
            $("#ID_Porcentaje").attr("readonly", true);
            //$("#ID_Porcentaje").prop("disabled", false);
            $("#ID_Porcentaje").val(100);
            $("#ID_MsgFechaActivacion").html("");
            $("#msgPorcentaje").html("");
        } else {
            $("#ID_Porcentaje").attr("readonly", false);
            $("#ID_Porcentaje").val("");
            $("#ID_MsgFechaActivacion").html('');
             $("#msgPorcentaje").html('');
         }
    }

    function DesHabilitarPorcentajeTCompartida() {
        if ($("#rbtSecundario").is(":checked")) {
            if ($("#rbtHoreca").is(":checked") === true) {
                $(".cPorcentaje").attr("readonly", true);
                //$("#ID_Porcentaje").prop("disabled", false);
                $(".cPorcentaje").val(100);
                $("#ID_TCompartida").val(1);
                $("#msgPorcentaje").html("");
            } else {
                $(".cPorcentaje").attr("readonly", false);
                $(".cPorcentaje").val("");
                $("#ID_MsgFechaActivacion").html('');
                $("#msgPorcentaje").html('');
                $("#ID_TCompartida").val(2);
            }
        }
    }

    function HabilitarPorcentaje() {
        if ($("#rbtSecundario").is(":checked") == true) {
            $("#ID_Porcentaje").attr("enabled", "enabled");
        } else {
            $("#ID_Porcentaje").attr("enabled", "enabled");
        }
     }

//     function DeshabilitarRadioSecundario() {
//         if($("#rbtSecundario").attr("disabled") == false) {
//             $('#rbtSecundario').attr('disabled', true);
//          }
//     }

     ////////////////////    FUNCION PARA VERIFICAR ESTADO DE LA CARTERA   /////////////////////////////

     function VerificarRegistroCartera() {
         var vIdCliente = $("#ID_IdCliente").val();
         var ParamUrl = CreateUrl("VerificarCartera", "Cliente")
         $.ajax({
             url: ParamUrl,
             data: {
                 IdCliente: vIdCliente
             },
             type: "GET",
             cache: false,
             success: function (data) {
                var vresultado = data;
                if(vresultado == 1){
                    $('#rbtSecundario').attr('disabled', true);
                }else{
                    $("#rbtSecundario").attr('disabled', false);
                }
              },
         });
      }


/////////////////////////////////////////////   QUERY PARA VALIDAR MESON EMPLEADO    ////////////////////////////////////////////////////////

function ComboValidaTipoMeson(){
    var vUrl = CreateUrl('ComboValidaMeson', 'Cliente');
    var vIdEmpleado = $("#cboEmpleados").val();
    $.ajax ({
        url: vUrl,
        data: {
            IdEmpleado : vIdEmpleado
        },
        type: "POST",
        cache: false,
        success: function (data) {
            if(data == 1){
                $("#ID_Porcentaje").attr("readonly", true);
                $("#ID_Porcentaje").val(0);
             }else if(data == 2) {
                 $("#ID_Porcentaje").attr("readonly", true);
                 $("#ID_Porcentaje").val(100);
             }else{
                $("#ID_Porcentaje").attr("readonly", false);
                $("#ID_Porcentaje").val("");
             }
             //}       
         },
          error: function (jqXhr, textStatus, errorThrown) {
         }
    });
 }

function ValidaTipoVendedor(){
    var vIdCliente = $("#ID_IdCliente").val();
    var vIdEmpleado = $("#cboEmpleados").val();

    var vUrl = CreateUrl('ValidarTipoVendedorCartera', 'Cliente');

    $.ajax({
        url : vUrl,
        data : {
            IdCliente : vIdCliente,
            IdEmpleado : vIdEmpleado
        },
        type : "GET",
        cache : false,
        success : function(data){
            if(data == 1){
                $("#ID_Porcentaje").attr("readonly", true);
                $("#ID_Porcentaje").val(0);
            }else if(data == 2 ) {
                $("#ID_Porcentaje").attr("readonly", true);
                $("#ID_Porcentaje").val(100);
            }else{
                $("#ID_Porcentaje").attr("readonly", false);
                $("#ID_Porcentaje").val("");
            }
        },
         error: function (jqXhr, textStatus, errorThrown) {
         }
    });
}

function ValidaTipoCarteraporEmpleadoTipo(){
    var tipo =  $("#ID_idCarteraEmpleadoTipo").val();
    var vEmpleado = $("#cboEmpleados").val();
    var vUrl = CreateUrl('ValidarTipoEmpleadoCartera', 'Cliente');

     $.ajax({
        url : vUrl,
        data : {
            IdTipoCartera : tipo,
            IdEmpleado : vEmpleado
        },
        type : "GET",
        cache : false,
        success : function(data){
            if(data == 1){
                $("#ID_Porcentaje").attr("readonly", true);
                $("#ID_Porcentaje").val(0);
            }else if(data == 2 ) {
                $("#ID_Porcentaje").attr("readonly", true);
                $("#ID_Porcentaje").val(100);
            }else{
                $("#ID_Porcentaje").attr("readonly", false);
                $("#ID_Porcentaje").val("");
            }
          },
         error: function (jqXhr, textStatus, errorThrown) {
         }
    });
}   

function SetTotalRegistrosSucursales() {
}

function PintarHeaderGrillaSucursal() {
}

function ValidarFechaMenorActual(fecha) {
    var fechaActual = $("#HdnFechaActual").val();
    var ParteFecha = fecha.split('/');
    var fec = ParteFecha[2] + ParteFecha[1]+ ParteFecha[0];
    return fec > fechaActual;
}

function CargarVistaporVendedor(tipo) {      
    vUrl = $("#UrlVistaCartera").val();
    $("#ID_idCarteraEmpleadoTipo").val(tipo);
    TipoEmpleado = tipo;
    $.ajax({
        url: vUrl,
        type: "POST",
        data : {IdTipoVendedor : tipo},
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $('#IdVistaCartera').html(data);
            DesHabilitarPorcentaje();
        },
        error: function (er) {
        },
        complete: function(){
        }
    });
}

function PintarGrillaSucursales() {    
    $("#dgvDatosPagSucursal").find('td:nth-child(1),th:nth-child(1)').hide();
    $("#dgvDatosPagSucursal").find('td:nth-child(2),th:nth-child(2)').css('width', '35%');
    $(".cFechaAsignacion, .cFechaDesasignacion").datepicker({
        showOtherMonths: true,
        autoSize: true,
        changeMonth: true,
        changeYear: true,
        dateFormat : 'dd/mm/yy'
    });
    $(".cFechaAsignacion, .cFechaDesasignacion").mask("99/99/9999");
    $(".cFechaAsignacion, .cFechaDesasignacion").datepicker("setDate", "");
    $(".cFechaDesasignacion").attr('disabled',true);
    $(".cPorcentaje").val("");
    $(".cFechaDesasignacion").each(function(){
        if ($(this).parents('tr').find('td').eq(0).find('input').val() == "7") {
            $(this).attr('disabled',false);
        }
    });
    AjustarTamañoPopUp();
}

$(function() {
    AjustarTamañoPopUp();
})

function AjustarTamañoPopUp() {    
    var tot = $("#HdnTotalSucursales").val();
    if (tot > 6) {
        $("#dialogNuevaCartera").dialog("option", "height", 650);
    }else{
        $("#dialogNuevaCartera").dialog("option", "height", "auto");
        $("#dialogNuevaCartera").dialog("option", "maxHeight", 650);
    }
        $("#dialogNuevaCartera").dialog("option", "position", "center");
}

function esFechaAsignacionValida() {
    var valido = Boolean(esFechaDesasignacionValida() & esPorcentajeValido());
    $(".cFechaAsignacion").each(function(){
        $this = $(this);
        var tr = $this.parent('tr').find('td');//obtenemos las celdas de la fila actual
        var id=($this.attr('id')); //id de la celda actual(FehaAsignacion)
        var vspan = $("#"+id).next(); //span para mostrar mensaje de error;
        if (ValidarFecha(id) != 0){
           $(vspan).html('Fecha Incorrecta');
           valido=false;
        }else {
            $(vspan).html('');
            $(vspanfechades).html('');
            var fechaAsi = $("#"+id).val().toString().substring(0, 10);
            var vidfechades = $("#"+id).parents('td').next().find('input').attr('id');//obtenemos el siguiente input de la fila actual(fechadesasignacion)
            var vspanfechades =  $("#"+vidfechades).next()
            var fechaDes = $("#"+vidfechades).val().toString().substring(0, 10);
            var fechaIng = $("#HdnFechaIngresoSucursal").val();
            if (Comparar_Fechas(fechaIng,fechaAsi)){
                valido=false;
                $(vspan).html('Fecha asignación debe ser mayor a fecha asignación sucursal empleado');
            }else if(fechaDes){
                if (ValidarFecha(vidfechades) != 0){
                   $(vspanfechades).html('Fecha Incorrecta');
                   valido=false;
                }else if(Comparar_Fechas(fechaAsi, fechaDes)){
                    valido=false;
                    $(vspanfechades).html('Fecha Deasignación debe ser mayor a fecha de asignación');
                }else {
                    $(vspanfechades).html('');
                }
            }
        }
    });
    return valido;

    function esFechaDesasignacionValida() {
        var valido = true;
        $(".cFechaDesasignacion").each(function(){
            $this = $(this);
            var id = ($this.attr('id'));
            var vspan = $("#"+id).next(); //span para mostrar mensaje de error;
            $(vspan).html('');
            var a = Boolean($this.parents('tr').find('td').eq(0).find('input').val() == "7");
            if (a) $(".cFechaDesasignacion").attr('disabled',false);
            var b = !Boolean($this.text());
            if(a && b){
                  $("#msgFechaDeasignacion_7").html('Ingrese la fecha de Desasignación');
                  valido= false;
            }
            if ($("#"+id).val()) {                
                if (ValidarFecha(id) != 0 ){
                   $(vspan).html('Fecha Incorrecta');
                   valido=false;
                }else{ 
                  $(vspan).html('');
                  valido= true;
                }
            }
        })
        return valido;
    }
 
    function esPorcentajeValido() {
        var valido = true;
        $(".cPorcentaje").each(function(){
            $this = $(this);
            var id=($this.attr('id'));
            var vspan = $("#"+id).next(); //span para mostrar mensaje de error;
            $(vspan).html('');
            if (!$this.val()){
               $(vspan).html('Ingrese un porcentaje');
               valido=false;
            }else if($this.val() >100 || $this.val() == 0){
                $(vspan).html('Porcentaje debe estar entre 0 y 100');
                valido=false;
            }
        });
        return valido;
    }
}

function esSucursalValida() {
    var valido =  Boolean($("#cboSucursal").val());    
    $("#msgSucursal").html(valido ? '':'Seleccione una sucursal');
    return valido;
}

function esEmpleadoValido(){
    var valido = Boolean($("#HdnIdEmpleado").val() && $("#NombreEmpleado_AutoComplete").val().length > 2);
    $("#msgEmpleado").html(valido ? '':'Seleccione un empleado válido');
    return valido;
}

function CargarSucursalesDisponibles(){
    vUrl = $("#UrlSucursalesDisponibles").val();
    vIdEmpleado = $("#HdnIdEmpleado").val();
    vIdCliente = $("#IdCliente").val();
    $.ajax({
        url: vUrl,
        type: "POST",
        data : { IdCliente  : vIdCliente
                ,IdEmpleado : vIdEmpleado},
        cache: false,
        success: function(data, textStatus, jqXHR){
            $('#SucursalesDisponibles').html(data);
        },
        error: function (er) {
        },
        complete: function(){
        }
    });
}

function existeMesonActivo(){
    valid = false
    vUrl = $("#UrlVerificarMeson").val();
    vIdCliente = $("#IdCliente").val();
    $.ajax({
        url : vUrl,
        type: "GET",
        cache: false,
        data: {IdCliente : vIdCliente},
        success: function(data, textStatus, jqXHR){
            if (data == -1){
                $("#dialogInformacionResultadoCartera").html("<p>Existe un Mesón en la cartera de este cliente,para asignar un empleado debe desactivarlo </p>");
                $("#dialogInformacionResultadoCartera").dialog("open");
            }else{
                dialogNuevaCartera();
            }
        }
    })
    return valid;
}

function minmax(value, min, max) {
    if (parseInt(value) < min || isNaN(parseInt(value)))
        return "";
    else if (parseInt(value) > max)
        return 100;
    else return value;
}
//Number.prototype.between = function (a, b, inclusive) {
//    var min = Math.min.apply(Math, [a, b]),
//        max = Math.max.apply(Math, [a, b]);
//    return inclusive ? this >= min && this <= max : this > min && this < max;
//};

//$('.digit-validation').keydown(function (event) {
//    var v = parseFloat(this.value + String.fromCharCode(event.which));
//    return parseFloat(v).between(0, 100, true);
//});