(function (Url) {
    $(document).ready(function () {
        DatosVaciosExcel()
        //if ($("#TipoOperacion_IdTipoOperacion").val() == "1") {
        $("#accion").val(true)
        //}
        //$("#TipoOperacion_IdTipoOperacion").change(ValidarCambio)
        $("#IdFileSelect").click(function () {
            $("#idReqFile").css("display", "none")
        })

        $("#IdFileSelect").change(CargarDoc)
        $("#registrar").click(RegistraCliente)
        $("#descargar").click(DescargarPlantilla)
    })

    DatosVaciosExcel = function () {
        var qParam = $("#mensaje").val()
        if (qParam == "") {
        }
        else {
            $("#idVentana p").text(qParam);
            $("#idVentana").dialog('open');
        }
    }

    CargarDoc = function () {
        var estado = $("#IdFileSelect").val();
        if (estado == "") {
            $("#idReqFile").css("display", "inline-block")
            return;
        }
        var extension = estado.substr((estado.lastIndexOf('.') + 1));

        if (extension == "xls" || extension == "xlsx") {
            $("#FrmClienteCartera").submit();
        }
        else {
            appendErrorMessage("#idReqFile", "Extensión no permitida(sólo *.xls o *.xlsx)", true);
            $("#idReqFile").css("display", "inline-block");
            validate = false;
        }
    }

    ValidarCambio = function () {

        var tipoOpe = $("#TipoOperacion_IdTipoOperacion").val()
        if (tipoOpe == "1") {
            $("#accion").val(true)
            $("#desAccion").val("REGISTRA")
        }
        else {
            $("#accion").val(false)
            $("#desAccion").val("DESACTIVA")
        }
    }

    RegistraCliente = function () {

        if ($("#grabar").val() == "" || $("#grabar").val() == "NO") {
            $("#idVentana p").text('No se adjuntó un archivo');
            $("#idVentana").dialog('open');
            return false
        }
        var caso1 = $("#desAccion").val()
        var caso2 = $("#desAccionAnt").val()
        if ($("#desAccion").val() == $("#desAccionAnt").val()) {
            $.ajax({
                url: UrlAction.urlRegistrarCliente,
                data: $("#FrmClienteCartera").serialize(),
                type: 'POST',
                success: function (data) {
                    var msg;
                    if (data == -1) {
                        msg = "Ocurrió un error mientras se guardaba el archivo."
                    } else {
                        msg = "Los datos se guardaron correctamente."
                    }
                    $("#idRegitrar p").text(msg);
                    $("#idRegitrar").dialog('open');
                }
            })
        } else {
            $("#idVentana p").text('El tipo de operación es diferente al que se seleccionó al hacer la carga.');
            $("#idVentana").dialog('open');
        }
    }

    Cargar = function () {
        window.location = UrlAction.urlCargarPrincipal
    }

    DescargarPlantilla = function () {
        window.location = UrlAction.urlDescargaPlantilla
    }

    //#region PopUp
    $("#idVentana").dialog({
        autoOpen: false,
        modal: true,
        resizable: true,
        width: 400,
        hide: 'fade',
        show: 'fade',
        title: "Error",
        buttons: [{
            id: "btnPopAceptar",
            text: "Aceptar",
            click: function () {
                $(this).dialog("close");

            }
        }]
    });

    $("#idRegitrar").dialog({
        autoOpen: false,
        modal: true,
        resizable: false,
        width: 400,
        hide: 'fade',
        show: 'fade',
        title: "Mensaje de Validación",
        buttons: [{
            id: "btnPopAceptar",
            text: "Aceptar",
            click: function () {
                Cargar()
                $(this).dialog("close");

            }
        }]
    });
    //#endregion PopUp
})()