var innerFrameHTML;
var isFirstLoad = true;



$(function () {

    $("#iIdBtnGuardarAdjunto").bind("click", ValidacionesExtras);

    InicioJPopUpCancelar("#dialogMensaje3", 400, false, "Mensaje de Información", CerrarPopup);
    InicioJPopUpCancelar("#dialogMensaje4", 400, false, "Mensaje de Información", CerrarPopup2);
    InicioJPopUpConfirm("#dialogConfirmarRegistro", 400, false, "Mensaje de Confirmación", SubirAdjunto);

    //    $("#IdFileUpload").change(function () {
    //        var Ruta = $(this).val();
    //    });
});
 
var CerrarPopup = function () { $('#dialogMensaje3').hide() }
var CerrarPopup2 = function () { $('#dialogMensaje4').hide() }




var ValidacionesExtras = function () {
    //Variables
    var vReturn;
    var SearchValidation = true;

    var vID_NombresApellidos = $("#ID_NombresApellidos").val()
    var vIdDescripcion = $("#iIdDescripcion").val()
    var vIdFileUpload = $("#IdFileUpload").val()
    var vTxtAprobadoPor = $("#IdTxtAprobadoPor").val()

    var NombreRRVV_ = $("#IdEmpleadoJefe").val();

    //GetValues
    vReturn = ValidationMessage(vID_NombresApellidos, "#valid-NombresApellidos");
    if (!vReturn) SearchValidation = false;
    vReturn = ValidationMessage(vIdDescripcion, "#valid-Descripcion");
    if (!vReturn) SearchValidation = false;
    vReturn = ValidationMessage(vIdFileUpload, "#valid-Archivo");
    if (!vReturn) SearchValidation = false;
    vReturn = ValidationMessage(vTxtAprobadoPor, "#valid-Aprobado");
    if (!vReturn) SearchValidation = false;

    vReturn = ValidationMessage_Texto(vID_NombresApellidos, "#valid-NombresApellidos");
    if (!vReturn) SearchValidation = false;

    if (NombreRRVV_ == "" || NombreRRVV_ == null || NombreRRVV_ == "0") {
        $("#valid-NombresApellidos" + " > span").text("Campo requerido");
        $("#valid-NombresApellidos").show();
        SearchValidation = false;
    }

    if (SearchValidation == true) {
        InicioJPopUpOpen("#dialogConfirmarRegistro");
    }
}

var SubirAdjunto = function () {
    var ValidationArchivo = SubirArchivo("IdFileUpload");
}

var ValidationMessage = function (element, divMessage) {

    var vReturn;
    if (element == "") {
        $(divMessage + " > span").text("Campo Requerido");
        $(divMessage).show();
        vReturn = false;

    } else {
        $(divMessage).hide();
        vReturn = true;
    }
    return vReturn;
}



var ValidationMessage_Texto = function (element, divMessage) {
    var vReturn;
    if (element.length <= 3) {
        $(divMessage + " > span").text("Campo Requerido");
        $(divMessage).show();
        vReturn = false;

    } else {
        $(divMessage).hide();
        vReturn = true;
    }
    return vReturn;
}


function SubirArchivo(inputFileId) {

    var vreturn;
    var validate = true;
    isFirstLoad = false;

    var IdFileSelect = $("#IdFileUpload").val();
    var IdFileSelectDesc = $("#uniform-IdFileUpload .filename").text();
    var messageFileEmpty = "Seleccione un archivo";

    if (IdFileSelect == null || IdFileSelect == "" || IdFileSelectDesc == messageFileEmpty) {
        appendErrorMessage("#msgIdFileSelectError", $("#IdMessageCampoRequerido").val(), true);
        validate = false;
    }
    else {
        appendErrorMessage("#msgIdFileSelectError", "", false);
    }

    if (validate == false)
        return validate;

    var iframe = document.getElementById("UploadTarget");
    var innerDoc = iframe.contentDocument || iframe.contentWindow.document;
    innerFrameHTML = innerDoc.getElementsByTagName('html')[0].innerHTML

    var inputFile = document.getElementById(inputFileId);
    var divFiles = document.getElementById("IdGestionarArchivosComision");

    $("#IdGestionarArchivosComision").html("");

    var fileName = $("#IdFileUpload").val();
    var fileInput = $("#IdFileUpload");
    var IdJefe_ = $("#IdEmpleadoJefe").val();
    var IdJefe = $("#IdJefe").val(IdJefe_);
    var IdDescripcion_ = $("#iIdDescripcion").val();
    var IdDescripcion = $("#iDescripcion").val(IdDescripcion_);
    var IdAprobadoPor_ = $("#IdTxtAprobadoPor").val();
    var IdAprobadoPor = $("#iAprobado").val(IdAprobadoPor_);
    var IdPeriodoComision = $("#iPeriodoComision").val();

    $("#IdArchivoNameComision").val(fileName);

    divFiles.appendChild(inputFile);

    //--------------------Captura el Tamaño del archivo---------------------------------------------
    var inputs = document.getElementById(inputFileId);

    //    var explore9 = inputs.files;
    //    if (explore9 == undefined) {
    //        var file = 0;
    //        var total = file;
    //    }
    //    else {
    //        var file = inputs.files[0];
    //        var total = file.size;
    //        var extension = file.name.substring(file.name.lastIndexOf('.') + 1);
    //    }

    // ----------------------------------------------------------------------------------------------


    //----------------------Calculando en MB----------------------------------------------------------
    //var ValorCifrado = total / 1024;
    // var ValorCifrado = document.getElementById(inputFileId).value;
    //var FileMaxSizeAllowKB = 10485760;
    // var FileMaxSizeAllowKB = innerDoc.getElementById(inputFileId).value;
    //var FileMaxPorFile = 10485760;
    // ----------------------------------------------------------------------------------------------

    var extension = IdFileSelect.substring(IdFileSelect.lastIndexOf(".") + 1).toLowerCase();
    //---------------Comparación de la extencion del archivo----------
    if (!(extension == 'pdf' || extension == 'xlsx' || extension == 'xls' || extension == 'docx' || extension == 'doc' || extension == 'png' || extension == 'jpg' || extension == 'jpge')) {
        vreturn = false;
        InicioJPopUpOpen("#dialogMensaje3");
        //        alert('"Extensión de archivo PDF no permitida"');
    }
    else {
        //---------------Compracion tamaño del archivo con el valor asignado del FileMaxSizeAllowKB-----
        //        if (ValorCifrado > FileMaxPorFile) {
        //            vreturn = false;
        //            InicioJPopUpOpen("#dialogMensaje4");

        //        }
        //        else {

        //            if (ValorCifrado > FileMaxSizeAllowKB) {
        //                vreturn = false;
        //                InicioJPopUpOpen("#dialogMensaje4");

        //            } else {
        //                vreturn = true;
        //                $("#frmComisionAdjuntar").submit();
        //                InicioJPopUpAlert("Registro guardado correctamente", null);

        //            }
        //        }

        vreturn = true;
        $("#frmComisionAdjuntar").submit();

        //        InicioJPopUpAlert("Registro guardado correctamente", null);
    }

    //    InicioJPopUpAlert("Registro guardado correctamente", null);

    $("#divIdFileSelect").html(fileInput);
    $("#IdFileUpload").uniform();

    return vreturn;
}


function UploadImage_Complete() {

    if (isFirstLoad == true) {
        isFirstLoad = false;
        return false;
    }

    var iframe = document.getElementById("UploadTarget");
    var innerDoc = iframe.contentDocument || iframe.contentWindow.document;

    if (innerDoc != null) {

        var FileAceptSize = innerDoc.getElementById("IdFileAceptSizeAttached").value;

        if (FileAceptSize == "False") {
            InicioJPopUpAlert("El máximo tamaño permitido para los archivos es 10 Mb", null);
        } else {
            window.location.href = "/Comision/BuscarMesesComisionales?IdPeriodo=0";
        }


    }

}
