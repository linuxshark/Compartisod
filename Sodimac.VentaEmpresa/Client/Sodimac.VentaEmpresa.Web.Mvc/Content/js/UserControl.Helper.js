function ValidarAutocomplete(IdControl,IdMsj) {
    var IDRecirbidoPor = $(IdControl).val();

    if (IDRecirbidoPor == "" || IDRecirbidoPor == 0)
        $(IdMsj).html('No Registrado');
    else
        $(IdMsj).html('');
}

//function RedirecionURL(IDRegistro,ParamUrl){
//    window.location = ParamUrl+"/"+IDRegistro;
//}

jQuery.fn.cuentaCaracteres = function () {
    //para cada uno de los elementos del objeto jQuery
    this.each(function () {
        //creo una variable elem con el elemento actual, suponemos un textarea
        elem = $(this);
        //creo un elemento DIV sobre la marcha 
        var contador = $('<div>Contador caracteres: ' + elem.attr("value").length + '/1200 </div>');
        //inserto el DIV después del elemento textarea
        elem.after(contador);
        //guardo una referencia al elemento DIV en los datos del objeto jQuery
        elem.data("campocontador", contador);

        //creo un evento keyup para este elemento actual
        elem.keyup(function () {
            //creo una variable elem con el elemento actual, suponemos un textarea
            var elem = $(this);
            //recupero el objeto que tiene el elemento DIV contador asociado al textarea
            var campocontador = elem.data("campocontador");
            //modifico el texto del contador, para actualizarlo con el número de caracteres escritos
            campocontador.text('Contador caracteres: ' + elem.attr("value").length + '/1200');
        });
    });
    //siempre tengo que devolver this
    return this;
};


$(document).ready(function () {
    $("textarea").cuentaCaracteres();
})

//////$('textarea.limited').maxlength({
//////    'feedback': '.charsLeft' // note: looks within the current form
//////});

jQuery.fn.limitMaxlength = function(options){

  var settings = jQuery.extend({
    attribute: "maxlength",
    onLimit: function(){},
    onEdit: function(){}
  }, options);
  
  // Event handler to limit the textarea
  var onEdit = function(){
    var textarea = jQuery(this);
    var maxlength = parseInt(textarea.attr(settings.attribute));

    if(textarea.val().length > maxlength){
      textarea.val(textarea.val().substr(0, maxlength));
      
      // Call the onlimit handler within the scope of the textarea
      jQuery.proxy(settings.onLimit, this)();
    }
    
    // Call the onEdit handler within the scope of the textarea
    jQuery.proxy(settings.onEdit, this)(maxlength - textarea.val().length);
  }

  this.each(onEdit);

  return this.keyup(onEdit)
        .keydown(onEdit)
        .focus(onEdit);
}

$(document).ready(function(){
  
  var onEditCallback = function(remaining){
    $(this).siblings('.charsRemaining').text("Characters remaining: " + remaining);
    
    if(remaining > 0){
      $(this).css('background-color', 'white');
    }
  }
  
  var onLimitCallback = function(){
    $(this).css('background-color', 'white');
  }
  
  $('textarea[maxlength]').limitMaxlength({
    onEdit: onEditCallback,
    onLimit: onLimitCallback,
  });
});

function InicioJPopUp(selector, ancho, alto, resize, titulo) {
    $(selector).dialog({
        autoOpen: false,
        height: alto,
        width: ancho,
        modal: true,
        resizable: resize,
        hide: 'fade',
        show: 'fade',
        title: titulo
    });
}

function InicioJPopUpV2(selector, ancho, alto, resize, titulo, posicion) {
    $(selector).dialog({
        autoOpen: false,
        height: alto,
        width: ancho,
        modal: true,
        resizable: resize,
        hide: 'fade',
        show: 'fade',
        title: titulo,
        position: posicion
    });
}

$(window).load(
            function () {
                 $('input[type="text"]').addClass("textTransform");  
                 $("textarea").addClass("textTransform");  
            }
  );

function validarNumeros(e) { // 1
    //debugger;
    //tecla = (document.all) ? e.keyCode : e.which; // 2
    //if (tecla == 8) return true; // 3
    //else if (tecla == 0) return true;
    //else if (tecla == 9) return true;
    ////else if (tecla == e.keyCode || tecla == e.which) return true;
    //patron = /^[ 0-9]*$/;
    ////patron = /\w/; // Acepta N(U)meros y Letras
    //te = String.fromCharCode(tecla); // 5
    //return patron.test(te); // 6

    var key = window.event ? e.which : e.keyCode;
    if (key < 48 || key > 57) {
        //Usando la definición del DOM level 2, "return" NO funciona.
        e.preventDefault();
    }
}

function validarNumerosLetras(e) { // 1
    tecla = (document.all) ? e.keyCode : e.which; // 2
    if (tecla == 8) return true; // 3
    else if (tecla == 0) return true;
    else if (tecla == 9) return true;
    //else if (tecla == e.keyCode || tecla == e.which) return true;
    patron = /^[ 0-9-A-z]*$/;
    //patron = /\w/; // Acepta N(U)meros y Letras
    te = String.fromCharCode(tecla); // 5
    return patron.test(te); // 6
}

 function validarNumerosLetrasV2(e) { // 1
    tecla = (document.all) ? e.keyCode : e.which; // 2
    if (tecla == 8) return true; // 3
    else if (tecla == 0) return true;
    else if (tecla == 9) return true;
    //else if (tecla == e.keyCode || tecla == e.which) return true;
    patron = /^[ a-zA-Z0-9[:space:]]*$/;
    //patron = /\w/; // Acepta N(U)meros y Letras
    te = String.fromCharCode(tecla); // 5
    return patron.test(te); // 6
}


function val_Email(e) {
    tecla = (document.all) ? e.keyCode : e.which;
    if (tecla == 8) return true;

   patron = /^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;
  // patron = /^([a-zA-Z0-9_.-])+@([a-zA-Z0-9_.-])+\.([a-zA-Z])+([a-zA-Z])+/
    te = String.fromCharCode(tecla);
    return patron.test(te);
}

function val_Codigo(e) {
    tecla = (document.all) ? e.keyCode : e.which;
    if (tecla == 8) return true;
    //else if (tecla == e.keyCode || tecla == e.which) return true;
    patron = /[-0-9QWERTYUIOPASDFGHJKLÑZXCVBNMqwertyuiopñlkjhgfdsazxcvbnm\x00\s]/;
    te = String.fromCharCode(tecla);
    return patron.test(te);
}

function val_Descripcion(e) {
    tecla = (document.all) ? e.keyCode : e.which;
    if (tecla == 8) return true;
    //else if (tecla == e.keyCode || tecla == e.which) return true;
    patron = /[&-;,.0-9QWERTYUIOPASDFGHJKLÑZXCVBNMqwertyuiopñlkjhgfdsazxcvbnmáéíóúÁÉÍÓÚ\x00\s\n]/;
    te = String.fromCharCode(tecla);
    return patron.test(te);
}

function val_AZ(e) {
    tecla = (document.all) ? e.keyCode : e.which;
    if (tecla == 8) return true;
    //else if (tecla == e.keyCode || tecla == e.which) return true;
    patron = /[QWERTYUIOPASDFGHJKLÑZXCVBNMqwertyuiopñlkjhgfdsazxcvbnmáéíóúÁÉÍÓÚ\x00\s]/;
    te = String.fromCharCode(tecla);
    return patron.test(te);
}

function val_AZ_Empresa(e) {
    tecla = (document.all) ? e.keyCode : e.which;
    if (tecla == 8) return true;
    //else if (tecla == e.keyCode || tecla == e.which) return true;
    patron = /[QWERTYUIOPASDFGHJKLÑZXCVBNMqwertyuiopñlkjhgfdsazxcvbnmáéíóúÁÉÍÓÚ\x00\S]/;
    te = String.fromCharCode(tecla);
    return patron.test(te);
}

function val_09(e) {
    tecla = (document.all) ? e.keyCode : e.which;
    if (tecla == 8) return true;
    else if (tecla == 0) return true;
    else if (tecla == 9) return true;
    // else if (tecla == e.keyCode || tecla == e.which) return true;
    patron = /[0-9]/;
    te = String.fromCharCode(tecla);
    return patron.test(te);
}

function val_09D(e) {
    tecla = (document.all) ? e.keyCode : e.which;

    if (tecla == 8) return true;
    else if (tecla == 0) return true;
    else if (tecla == 9) return true;
    else if (tecla == 46) return true;
    // else if (tecla == e.keyCode || tecla == e.which) return true;
    patron = /^[-+]?[0-9]+(\.[0-9]{2})?$/;
    te = String.fromCharCode(tecla);
    return patron.test(te);
}

function val_09_2D(e) {
    tecla = (document.all) ? e.keyCode : e.which;

    if (tecla == 8) return true;
    else if (tecla == 0) return true;
    else if (tecla == 9) return true;
    patron = /^[0-9]+(\.[0-9]?[0-9]?)?$/;
    
    var text;
    te = String.fromCharCode(tecla);
    inputText = document.getElementById(''+(e.target || e.srcElement).id);
    
    if (inputText.value == 0 || inputText.value == "") {
        text = te;
    }
    else {
        text = inputText.value;
        strlength = text.length;
        strf = text.substr(0 , inputText.selectionStart);
        strb = text.substr(inputText.selectionStart , strlength);
        text = strf + te + strb;
    }

    return patron.test(text);
}

function val_TelefonoFax(e) {
    tecla = (document.all) ? e.keyCode : e.which;

    if (tecla == 8) return true;
    else if (tecla == 0) return true;
    else if (tecla == 9) return true;
    patron = /^([0-9]+|\*|\-|\+|\#)+$/;
    
    var text;
    te = String.fromCharCode(tecla);
    inputText = document.getElementById(''+(e.target || e.srcElement).id);
    
    if (inputText.value == 0 || inputText.value == "") {
        text = te;
    }
    else {
        text = inputText.value;
        strlength = text.length;
        strf = text.substr(0 , inputText.selectionStart);
        strb = text.substr(inputText.selectionStart , strlength);
        text = strf + te + strb;
    }

    return patron.test(text);
}

function val_Telefono(e) {
    tecla = (document.all) ? e.keyCode : e.which;
    if (tecla == 8) return true;
    else if (tecla == 0) return true;
    else if (tecla == 9) return true;
    // else if (tecla == e.keyCode || tecla == e.which) return true;
    patron = /^[-+]?[0-9]+(\-)?$/;
    te = String.fromCharCode(tecla);
    return patron.test(te);
}

function val_Hora(e) {
    tecla = (document.all) ? e.keyCode : e.which;
    if (tecla == 8) return true;
    else if (tecla == 0) return true;
    else if (tecla == 9) return true;
    else if (tecla == 58) return true;
    patron = /[0-9]/;
    te = String.fromCharCode(tecla);
    return patron.test(te);

}
function lTrim(sStr) {
    while (sStr.charAt(0) == " ")
        sStr = sStr.substr(1, sStr.length - 1);
    return sStr;
}

function rTrim(sStr) {
    while (sStr.charAt(sStr.length - 1) == " ")
        sStr = sStr.substr(0, sStr.length - 1);
    return sStr;
}

function allTrim(sStr) {
    return rTrim(lTrim(sStr));
}

function validarNull1(e) {
    return (allTrim(e));
}

function ValidarNUll(ID_Textto) {
    var texto = document.getElementById(ID_Textto);
    $("input[id$='" + ID_Textto + "']").val(allTrim(texto.value));
}

function UI_Select(DisplayControl, DropDownControl) {
    $('#' + DisplayControl).text($('#' + DropDownControl + ' option:selected').text());
}

function UI_Select_ClearSubLevel(ArrayControl) {
    var Controls = ArrayControl.split(';');
    for (i = 0; i < Controls.length; i++) {
        //document.getElementById(Controls[i]).options[0].selected = true;
        //$("select#elem")[0].selectedIndex = 0;
    }
}

//Funcion para cargar combos con 0 elementos: 02-04-12
function Load_EmptyDDL(ParamUrl, destino) {

    $.ajax({
        url: ParamUrl,
        type: "post",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $(destino).html(data);
        },
        error: function (req, status, error) {
        }
    });
}

function msjRequerido(control) {
//    if ($(control).val()=='') {
    //alert($(control).parent().parent().children().get());
//    }
}

function InicioJPopUp(selector, ancho, alto, resize, titulo) {
    $(selector).dialog({
        autoOpen: false,
        height: alto,
        width: ancho,
        modal: true,
        resizable: resize,
        hide: 'fade',
        show: 'fade',
        title: titulo
    });
}

function InicioJPopUpOpen(selector) {
    $(selector).dialog("open");
}

function InicioJPopUpOpenV2(selector,titulo) {
    $(selector).dialog("option", "closeOnEscape", false );
    $(".ui-dialog-titlebar-close").hide(); 
    $(selector).dialog("open");
    $(selector).dialog({ title: titulo });
}

function InicioJPopUpClose(selector) {
    $(selector).dialog("close");
}

function InicioJPopUpConfirm(selector, ancho, resize, titulo,actionfunction) {
    $(selector).dialog({
        autoOpen: false,
        width: ancho,
        modal: true,
        resizable: resize,
        hide: 'fade',
        show: 'fade',
        title: titulo,
        buttons: {
            "Sí": function () {

                if (actionfunction != null) {
                    actionfunction();
                }
                $(selector).dialog("close");
            },
            "No": function () {
                $(selector).dialog("close");
            }
        }
    });
}

function InicioJPopUpCancelar(selector, ancho, resize, titulo,actionfunction) {
    $(selector).dialog({
        autoOpen: false,
        width: ancho,
        modal: true,
        resizable: resize,
        hide: 'fade',
        show: 'fade',
        title: titulo,
        buttons: {            
            "Aceptar": function () {
                $(selector).dialog("close");                
            }
        }
    });
}

function InicioJPopUpConfirmOpen(selector) {
    $(selector).dialog('open');
    return false;
}

//CAMBIAR ESTILO ALERT
var ALERT_TITLE = "Confirmación!";
var ALERT_BUTTON_TEXT = "Aceptar";

//Anular el método de alerta
if (document.getElementById) {
    window.alert = function (txt) {
        MyAlert(txt);
    }
}

function MyAlert(txt) {
    //Atajo referencia al objeto documento
    d = document;

    // if the modalContainer object already exists in the DOM, bail out.

    if (d.getElementById("modalContainer")) return;

    // create the modalContainer div as a child of the BODY element
    mObj = d.getElementsByTagName("body")[0].appendChild(d.createElement("div"));
    mObj.id = "modalContainer";
    // make sure its as tall as it needs to be to overlay all the content on the page
    mObj.style.height = document.documentElement.scrollHeight + "px";

    // create the DIV that will be the alert 
    alertObj = mObj.appendChild(d.createElement("div"));
    alertObj.id = "alertBox";
    // MSIE doesnt treat position:fixed correctly, so this compensates for positioning the alert
    if (d.all && !window.opera) alertObj.style.top = document.documentElement.scrollTop + "px";
    // center the alert box
    alertObj.style.left = (d.documentElement.scrollWidth - alertObj.offsetWidth) / 2 + "px";

    // create an H1 element as the title bar
    h1 = alertObj.appendChild(d.createElement("h1"));
    h1.appendChild(d.createTextNode(ALERT_TITLE));

    // create a paragraph element to contain the txt argument
    msg = alertObj.appendChild(d.createElement("p"));
    msg.innerHTML = txt;

    // create an anchor element to use as the confirmation button.
    btn = alertObj.appendChild(d.createElement("a"));
    btn.id = "closeBtn";
    btn.appendChild(d.createTextNode(ALERT_BUTTON_TEXT));
    btn.href = "#";
    // set up the onclick event to remove the alert when the anchor is clicked
    btn.onclick = function () { removeCustomAlert(); window.location.reload();}


}

// removes the custom alert from the DOM
function removeCustomAlert() {
    document.getElementsByTagName("body")[0].removeChild(document.getElementById("modalContainer"));
}

////CAMBIAR ESTILO ALERT END

function ValidarFecha(ID_Fecha) {
    var resultBool = 0; ;
    var f = document.getElementById(ID_Fecha).value
    re = /^[0-9][0-9]\/[0-9][0-9]\/[0-9][0-9][0-9][0-9]$/
    if (f.length == 0 || !re.exec(f)) {
        resultBool = 1;
        return 1;
    }
    var d = new Date()
    d.setFullYear(f.substring(6, 10),
	f.substring(3, 5) - 1,
		f.substring(0, 2))

    if (d.getMonth() != f.substring(3, 5) - 1
	|| d.getDate() != f.substring(0, 2)) {
        resultBool = 2;
        return 2;
    }
    return 0;
}

function ValidarFechaMaskEdit(styleDate) {

    $(styleDate).datepicker({
        onClose: function validate() {

            var frm = $(this).parents("form");

            if ($.data(frm[0], 'validator')) {
                var validator = $(this).parents("form").validate();
                validator.settings.onfocusout.apply(validator, [this]);
            }
        }
    });

    $(styleDate).mask("99/99/9999");

    $(styleDate).bind("blur", function () {
        var frm = $(this).parents("form");

        if ($.data(frm[0], 'validator')) {
            var validator = $(this).parents("form").validate();
            validator.settings.onfocusout.apply(validator, [this]);
        }
    });

    $(styleDate).each(function () {
        if (this.value == "01/01/0001") {
            this.value = '';
        }
    });

    $("form").each(function () { $.data($(this)[0], 'validator', false); });

    $("input[data-val-date]").removeAttr("data-val-date");

    $.validator.unobtrusive.parse("form");

}

function InicioJPopUpAlert(text,actionfunction) {
    $('#buttonAlert').html(text);
    $("#dialogAlert").dialog({
        autoOpen: false,
        resizable: false,
        closeOnEscape: false,
        open: function (event, ui) { $(".ui-dialog-titlebar-close", this.parentNode).hide(); },
        width: 400,
        modal: true,
        title:"Mensaje de Validación",
        buttons: [{
            id: "btnPopAceptar",
            text: "Aceptar",
            click: function () {
                if(actionfunction != null)
                    actionfunction();

                $(this).dialog("close");

            }
        }]

    });
 $('#dialogAlert').dialog('option', 'modal', true).dialog('open');
}

function CreateUrl(Action,Controller) {
    var Url = '';
    var UrlAcionResult = '';
    var ParamUrl = $('#UrlActionGen').val();
    Url = ParamUrl.toString().replace('Home', Controller);
    UrlAcionResult = Url.toString().replace('Index', Action);
    return UrlAcionResult;
}

function Comparar_Fechas(fecha, fecha2) {  
    var xMonth=fecha.substring(3, 5);  
    var xDay=fecha.substring(0, 2);  
    var xYear=fecha.substring(6,10);  
    var yMonth=fecha2.substring(3, 5);  
    var yDay=fecha2.substring(0, 2);  
    var yYear=fecha2.substring(6,10);  
    if (xYear> yYear) {  
        return(true)  
    }
    else {
      if (xYear == yYear) {
        if (xMonth> yMonth) {  
            return(true)  
        }  
        else {   
          if (xMonth == yMonth) {  
            if (xDay> yDay)  
              return(true);  
            else  
              return(false);  
          }
          else  
            return(false);  
        }
      }
      else
        return(false);
    }
}

function selectTextInput(event) {
    var source = event.target || event.srcElement;
    source.select();
}

function validateEmail(IdInputTextEmail) {
    var EMail = $('#'+IdInputTextEmail).val();
    var pattern=/^([a-zA-Z0-9_.-])+@([a-zA-Z0-9_.-])+\.([a-zA-Z])+([a-zA-Z])+/;
    return pattern.test(EMail);
}
function LimpiaFormularios(formulario) {
$(formulario).find(':input').each(function(){
	var type = this.type, tag = this.tagName.toLowerCase();
	if (type == 'text' || type == 'password' || tag == 'textarea')
		this.value = '';
	else if (type == 'checkbox' || type == 'radio')
		this.checked = false;
	else if (tag == 'select')
		this.selectedIndex = -1;
})
}

//Joel Panocca- Limpia Formulario
function LimpiaFormulario(formulario) {
    /* Se encarga de leer todas las etiquetas input del formulario*/
    $(formulario).find('input').each(function () {
        switch (this.type) {
            case 'password':
            case 'text':
            case 'hidden':
                $(this).val('');
                break;
            case 'checkbox':
            case 'radio':
                this.checked = false;
        }
    });

    /* Se encarga de leer todas las etiquetas select del formulario */
    $(formulario).find('select').each(function () {
        $("#" + this.id + " option[value=0]").attr("selected", true);
    });
    /* Se encarga de leer todas las etiquetas textarea del formulario */
    $(formulario).find('textarea').each(function () {
        $(this).val('');
    });
}
//PAra ignorar las validaciones del  dataanotation
function validateform(selector) {
    var valid = true;
    $(selector).find('input,select,textarea').each(function (index, elem) {
        var item = $(elem).hasClass('ignorefield');
        if (!item) {
            var isElemValid = $(selector).validate().element($(this));
            if (isElemValid != null) {
                valid = valid & isElemValid;
            }
        }
    });
    return valid;
}

function appendErrorMessage(selector, message, visible) {
    message = "<span>" + message + "</span>";
    $(selector).html(message);
    if(visible == true) {
        $(selector).css('display', '');
    }
    else {
        $(selector).css('display', 'none');
    }
}

function uniformPartialList(selector) {
    var combo = document.getElementById(selector);
    var uniformSelect = document.getElementById("uniform-" + combo.id);
    if (uniformSelect == null) {
        $("#" + combo.id).uniform();
    }

    var text = $("#"+selector + " option:selected").text();
    var divParent = $("#"+selector).closest('div');

    $(divParent).attr("original-title", text);
    $(divParent).addClass('tipS');
    $(divParent).tipsy({ gravity: 's', fade: true, html: true });

    $("#"+selector).on('change', function () {
        var IdSelect = $(this).attr("id");
        var text = $("#" + IdSelect + " option:selected").text();
        var divParent = $('#' + IdSelect).closest('div');

        $(divParent).attr("original-title", text);
        $(divParent).addClass('tipS');
        $(divParent).tipsy({ gravity: 's', fade: true, html: true });
    });
}

function CalculateDateDiff(dateFrom, dateTo, Type) {
    var diferencia = (dateTo - dateFrom);
    var anio = Math.floor(diferencia / (1000 * 60 * 60 * 24 * 365));
        diferencia -= anio * (1000 * 60 * 60 * 24 * 365);
    var meses = Math.floor(diferencia / (1000 * 60 * 60 * 24 * 30.4375));

    /////////////////////
    diferencia=(dateTo.getTime()-dateFrom.getTime())/1000;

    var dias=Math.floor(diferencia/86400)
        diferencia=diferencia-(86400*dias)

    var horas=Math.floor(diferencia/3600)
        diferencia=diferencia-(3600*horas)

    var minutos=Math.floor(diferencia/60)
        diferencia=diferencia-(60*minutos)

    var segundos=Math.floor(diferencia)

    if(Type == null || Type == 4){
        return dias;
    }
    else if(Type == 1){
        return segundos;
    }
    else if(Type == 2){
        return minutos;
    }
    else if(Type == 3){
        return horas;
    }
    else if(Type == 5){
        return meses;   
    }    
    else if(Type == 6){
        return anio;
    }
        return dias; 
}

function padLeft(Data, Left) {
    var str = "" + Data;
    var pad = "" + Left;
    return pad.substring(0, pad.length - str.length) + str;
}

function DateToString(Date) {
    var d = padLeft(Date.getDate(),'00');
    var m = padLeft(Date.getMonth() + 1,'00');
	var y = padLeft(Date.getFullYear(),'0000');
    var Fecha = d + "/" + m + "/" +  y;

    return Fecha;
}

function Fechatoyyyymmdd(date) {
    var d = date.split('/');
    var a = padLeft(d[2],'0000');
    var m = padLeft(d[1],'00');
    var d = padLeft(d[0],'00');

    return a + m + d;
}
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

function Fechatoyyyymmdd(date) {
    var d = date.split('/');
    var a = padLeft(d[2],'0000');
    var m = padLeft(d[1],'00');
    var d = padLeft(d[0],'00');

    return a + m + d;
}
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

function addValidattionForm(selector) {
    var form = $(selector).closest("form");
    form.removeData('validator');
    form.removeData('unobtrusiveValidation');
    $.validator.unobtrusive.parse(form);
}
