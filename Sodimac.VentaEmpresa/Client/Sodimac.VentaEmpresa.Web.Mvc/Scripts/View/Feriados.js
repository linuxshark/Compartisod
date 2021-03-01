(function () {
    $(document).ready(function () {

        //var navegador = navigator.appName

        $('#dialogInformacionCancelar').dialog({
            autoOpen: false,
            width: 400,
            modal: true,
            resizable: false,
            buttons: {
                "Si": function () {
                    $('#dialogInformacionCancelar').dialog("close");
                    $('#GestionarFeriado').dialog("close");
                },
                "No": function () {
                    $('#dialogInformacionCancelar').dialog("close");
                }
            }
        });

        $("#Id_Mes").multiselect(
            {
                selectedList: 10,
                noneSelectedText: ' SELECCIONE ',
                show: ["bounce", 200],
                minWidth: 220,
                click: function (event, ui) {
                    var idMes = new Array();
                    $("input[name='multiselect_Id_Mes']:checked").each(function () {
                        idMes.push($(this).val());
                    });
                    $("#MesMulti").val(idMes);
                },
                checkAll: function () {
                    var idMes = new Array();
                    $("input[name='multiselect_Id_Mes']:checked").each(function () {
                        idMes.push($(this).val());
                    });
                    $("#MesMulti").val(idMes);
                },
                uncheckAll: function () {
                    $("#MesMulti").val('');
                }
            }
         ).multiselectfilter();

       
        InicioJPopUp("#GestionarFeriado", 500, 'auto', false, "Gestionar Feriado");
        InicioJPopUpConfirm("#dialogRegistrar", 400, false, "Mensaje de Confirmación", Registrar)
        InicioJPopUpConfirm("#dialogEditar", 400, false, "Mensaje de Confirmación", Editar)
        
        $("#btnBuscar").click(Buscar);
        $("#btnNuevo").click(DialogNuevo);
        Buscar();
    })
})()

function PaintFooterGrid() {
    $(".edit_table").click(DialogEditar);
    $(".delete-register").click(DialogEliminar);
    $("#contenedor-grid-GridFeriados tfoot tr:last td").prepend("<a id='tfootPage'  class='total_registros'></a>");
    $("#tfootPage").html($('#FooterDesc').val());
}

function Buscar() {
    $.ajax({
        url: $("#FrmFeriados").attr('action'),
        data: $("#FrmFeriados").serialize(),
        type: 'GET',
        cache: false,
        success: function (data) {
            $("#contenedor-grid").html(data);
        },
        complete: function (req, status, error) {
            PaintFooterGrid();
        }
    });
}

function DialogNuevo() {
    $.ajax({
        url: $('#UrlNuevo').val(),
        data: {},
        type: "GET",
        cache: false,
        success: function (data) {
            $("#GestionarFeriado").html(data);
            InicioJPopUpOpen('#GestionarFeriado');
            $('#IdMesNuevo').uniform();
            $('#rdoTodoAnio').uniform();
            $('#rdoAnio').uniform();
            addValidattionForm('#FrmNuevoFeriado');
            activateAnio();
            $(".solonumero").keypress(numericValidate);
            $("#Feriados_Anio").prop('disabled', true);
            $("#Feriados_Anio").val('1900');
            $("#btnRegistrarFeriado").click(validFormNuevo);
        }
    });

}

function validFormNuevo() {
    if (validateform('#FrmNuevoFeriado'))
        InicioJPopUpOpen('#dialogRegistrar');
}


function Registrar() {
    $.ajax({
        url: $('#FrmNuevoFeriado').attr('action'),
        data: $('#FrmNuevoFeriado').serialize(),
        type: "POST",
        cache: false,
        success: function (msg) {
            $('#GestionarFeriado').dialog("close");
            InicioJPopUpAlert(msg, null);
            Buscar();
        }
    });
    
}

function DialogEditar() {
    $.ajax({
        url: $('#UrlEditar').val(),
        data: { id: $(this).attr("data") },
        type: "GET",
        cache: false,
        success: function (data) {
            $("#GestionarFeriado").html(data);
            InicioJPopUpOpen('#GestionarFeriado');
            $('#IdMesEditar').uniform();
            $('#rdoTodoAnio').uniform();
            $('#rdoAnio').uniform();
            addValidattionForm('#FrmEditarFeriado');
            $(".solonumero").keypress(numericValidate);
            $("#Feriados_Anio").prop('disabled', true);
            $("#Feriados_Anio").val('1900');
            activateAnio();
            $("#btnGuardarFeriado").click(validFormEditar);
        }
    });

    
}

function Editar() {
    $.ajax({
       url: $('#FrmEditarFeriado').attr('action'),
        data: $('#FrmEditarFeriado').serialize(),
        type: "POST",
        cache: false,
        success: function (msg) {
            $('#GestionarFeriado').dialog("close");
            InicioJPopUpAlert(msg, null);
            Buscar();
        }
    });
}

function validFormEditar() {
    if (validateform('#FrmEditarFeriado'))
        InicioJPopUpOpen('#dialogEditar');
}

function DialogEliminar() {
    $.ajax({
        url: $('#UrlEliminar').val(),
        data: { id: $(this).attr("data") },
        type: "GET",
        cache: false,
        success: function (data) {
            $("#GestionarFeriado").html(data);
            InicioJPopUpOpen('#GestionarFeriado');
            $("#btnEliminarFeriado").click(Eliminar);
        }
    });
}

function Eliminar() {
    $.ajax({
        url: $('#FrmEliminarFeriado').attr('action'),
        data: $('#FrmEliminarFeriado').serialize(),
        type: "POST",
        cache: false,
        success: function (msg) {
            $('#GestionarFeriado').dialog("close");
            InicioJPopUpAlert(msg, null);
            Buscar();
        }
    });
}

function CancelarRegistro() {
    $('#dialogInformacionCancelar').dialog('open');
    return false;
}

var numericValidate = function (e) {
    var tecla = (document.all) ? e.keyCode : e.which;
    if (tecla == 8) return true;
    else if (tecla == 0) return true;
    else if (tecla == 9) return true;
    else if (tecla == 190) return true;

    patron = /[0-9]/;
    te = String.fromCharCode(tecla);
    return patron.test(te);
}

var activateAnio = function () {
    $("#rdoTodoAnio").change(function () {
        if ($("#rdoTodoAnio").prop('checked', true)) {
            $("#Feriados_Anio").prop('disabled', true);
            $("#Feriados_Anio").val('1900');
        }
        
    })

    $("#rdoAnio").change(function () {
        if ($("#rdoAnio").prop('checked', true)) {
            $("#Feriados_Anio").prop('disabled', false);
            $("#Feriados_Anio").val('1900');
        }
    })
    
}