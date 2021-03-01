(function (Url) {
    $(document).ready(function () {
        //#region PopUp
        InicioJPopUp("#GestionarCierre", 500, 'auto', false, "Gestionar Cierre");
        InicioJPopUpConfirm("#dialogRegistrar", 400, false, "Mensaje de Confirmación", Registrar)
        InicioJPopUpConfirm("#dialogEliminar", 400, false, "Mensaje de Confirmación", Eliminar)
        $('#dialogCancelar').dialog({
            autoOpen: false,
            width: 400,
            modal: true,
            resizable: false,
            buttons: {
                "Si": function () {
                    $('#dialogCancelar').dialog("close");
                    $('#GestionarCierre').dialog("close");
                },
                "No": function () {
                    $('#dialogCancelar').dialog("close");
                }
            }
        });
        //#endregion PopUp

        $("#btnNuevo").click(openPopUpRegistrar);
        $("#btnBuscar").click(Buscar);
        Buscar();
    })

    var idCierreEliminar
    //#region Consultar
    Buscar = function () {
        $.ajax({
            url: $("#FrmCierre").attr('action'),
            data: $("#FrmCierre").serialize(),
            type: 'GET',
            cache: false,
            success: function (data) {
                $("#contenedor-grid").html(data);
                $(".eliminar_cierre").click(openPopUpEliminar);
            },
            complete: function (req, status, error) {
                PaintFooterGrid();
            }
        });
    }

    PaintFooterGrid = function () {
        $("#contenedor-grid-GridCierre tfoot tr:last td").prepend("<a id='tfootPage'  class='total_registros'></a>");
        $("#tfootPage").html($('#FooterDesc').val());
    }

    //#endregion Consultar

    //#region Registrar
    openPopUpRegistrar = function () {
        $.ajax({
            url: Url.Nuevo,
            data:{},
            type: "GET",
            cache: false,
            success: function (data) {
                $("#GestionarCierre").html(data);
                InicioJPopUpOpen('#GestionarCierre');
                addValidattionForm('#FrmNuevoCierre');
                $('#IdañoNuevo').uniform();
                $('#IdMesNuevo').uniform();
                $("#btnRegistrar").click(ValidarRegistro);
                $("#btnCancelar").click(CancelarRegistro);
            }
        })
    }    

    ValidarRegistro = function () {
        if (validateform('#FrmNuevoCierre'))
            InicioJPopUpOpen('#dialogRegistrar');
    }

    CancelarRegistro = function () {
        $('#dialogCancelar').dialog('open');
    }

    Registrar = function(){
        $.ajax({
            url: $('#FrmNuevoCierre').attr('action'),
            data: $('#FrmNuevoCierre').serialize(),
            type: "POST",
            cache: false,
            success: function (msg) {
                $('#GestionarCierre').dialog("close");
                InicioJPopUpAlert(msg, null);
                Buscar();
            }
        });
    }

    
    //#endregion Registrar

    //#region Eliminar

    openPopUpEliminar = function () {
        debugger;
        idCierreEliminar = $(this).attr("data");
        InicioJPopUpOpen('#dialogEliminar');
    }
    Eliminar = function () {
        $.ajax({
            url: Url.Eliminar,
            data: { idCierre: idCierreEliminar },
            type: "POST",
            cache: false,
            success: function (msg) {
                debugger;
                InicioJPopUpAlert(msg, null);
                Buscar();
            }
        });
    }

    //#endregion Editar
})(Url)