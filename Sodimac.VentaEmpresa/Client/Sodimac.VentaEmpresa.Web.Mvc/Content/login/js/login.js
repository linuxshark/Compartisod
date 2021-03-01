function showError(a) { $("#alertMessage").addClass("error").html(a).stop(true, true).show().animate({ opacity: 1, right: "40%" }, 500) }
function showSuccess(a) { $("#alertMessage").removeClass("error").html(a).stop(true, true).show().animate({ opacity: 1, right: "0" }, 500) }
function hideTop() { $("#alertMessage").animate({ opacity: 0, right: "-20" }, 500, function () { $(this).hide() }) }

$("#alertMessage").click(function () { hideTop() })

$(document).ready(function () {
	$("#login").show().animate({
		opacity: 1
	}, 2e3);

	$(".formLogin").show().animate({
		opacity: 1
	}, 2e3,  function () {
			$("#versionBar").animate({
				opacity: 1,
			}, 2e3);
	})
});


function Login() {
	$("#login").animate({
		opacity: 1,
		top: "50%"
	}, 400, function () {
			$(this).fadeOut(200, function () {
				$(".text_success").fadeIn();
			})
		}
	);

    var urlDestino = $("#Id_URL_DESTINO").val();

    setTimeout("window.location.href='" + urlDestino + "'", 3e3);
}

$("#but_login").click(function (a) {
    ValidarUsuario();
});

function ValidarUsuario() {
    var opcion = 0;
    var url = document.getElementById('frmLogin').action;
    
    //Capturo la data del form y parseo a JSON string!
    var formData = form2js('frmLogin', '.', true);

    //Convierto a JSON Obj
    var jsonUsuario = $.toJSON(formData.Usuario);

    if ($("#username_id").val() == "" || $("#password").val() == "") {
        $(".inner").jrumble({
                        x: 4,
                        y: 0,
                        rotation: 0
                    });
                    $(".inner").trigger("startRumble");
                    setTimeout('$(".inner").trigger("stopRumble")', 500);
                    $("input[name=clave]").css("border-color", "#FF0000");
                    showError("Ingrese su usuario y contraseña");
        return false
    }


    $.ajax({
        url: url,
        data: jsonUsuario,
        type: "post",
        cache: false,
        contentType: 'application/json; charset=utf-8',
        success: function (data, textStatus, jqXHR) {
            var msj = jqXHR.responseText;
            if (msj == 1) {
                hideTop();
                $("input[name=clave]").css("border-color", "#99FF00");
                setTimeout("Login()", 500)
                opcion = 1;
            }
            if (msj == 2) {
                $(".inner").jrumble({
                        x: 4,
                        y: 0,
                        rotation: 0
                    });
                    $(".inner").trigger("startRumble");
                    setTimeout('$(".inner").trigger("stopRumble")', 500);
                    $("input[name=clave]").css("border-color", "#FF0000");
                showError("Usuario o contraseña incorrecto");
                opcion = 2;
                return false
            }
            if (msj == 3) {
                $(".inner").jrumble({
                        x: 4,
                        y: 0,
                        rotation: 0
                    });
                    $(".inner").trigger("startRumble");
                    setTimeout('$(".inner").trigger("stopRumble")', 500);
                    $("input[name=clave]").css("border-color", "#FF0000");
                showError("Usuario no valido para acceder al sistema");
                opcion = 2;
                return false
            }

        },
        error: function (jqXHR, status, error) {

        }
    });

}

