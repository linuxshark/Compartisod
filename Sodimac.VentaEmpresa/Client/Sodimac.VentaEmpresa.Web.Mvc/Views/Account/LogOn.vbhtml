@modeltype Sodimac.VentaEmpresa.Web.Mvc.LoginViewModel
@code
    Layout = Nothing
end code

<!DOCTYPE html>
<html lang="es">
<head>
    <title>SODIMAC - Venta Empresa</title>
    <meta charset="utf-8" content="" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta name="description" content="" />
    <meta name="author" content="3devnet" />
    <meta http-equiv="Expires" content="0" />
    <meta http-equiv="Pragma" content="no-cache" />
    <link href="/Content/login/css/bootstrap.css" rel="stylesheet" />
    <link href="/Content/login/css/login.css" rel="stylesheet" type="text/css" />
    <link rel="shortcut icon" href="~/favicon.ico" />
    <style>
        .reqizq {
            margin-right: 5px;
            display: block;
            color: #EC6464;
            font-size: 9px;
        }
        .validation-summary-errors {
            color: #EC6464;
            margin-top: 10px;
        }
    </style>
</head>
<body style="overflow: hidden" onload="changeHashOnLoad(); ">
    <div id="alertMessage" class="error">
    </div>
    <div id="successLogin">
    </div>
    <div id="loading">
        <script type="text/javascript">

        </script>
    </div>
    <div class="text_success">
        <div class="text_message">
        </div>
    </div>
    <div class="wrapper" id="inner">
        <div class="container-fluid">
            <div class="row">
                <div style="width: 100%;">
                    <div id="login">
                        <div class="inner">
                            <div class="formLogin" style="height:100%">
                                @Using (Html.BeginForm("LogOn", "Account", FormMethod.Post, New With {.name = "frmLogin", .id = "frmLogin", .class = "form-horizontal"}))
                                    @Html.AntiForgeryToken()
                                    

                                    @*<label style="width: 225px;">
                                            USUARIO
                                            <input name="Usuario.UsuarioUsu" type="text" id="username_id" onkeypress="return repunto(event);" style=" font-size:12px; font-weight:normal;"
                                                class="loginPic_user2" />
                                        </label>
                                        <label style="width: 225px; margin-top: 50px">
                                            CLAVE
                                            <input value="" name="Usuario.PasswordUsu" type="password" autocomplete="off" id="password" onkeypress="return pulsar(event);"  style=" font-size:10px; font-weight:normal;"/>
                                        </label>
                                        <div style="clear: both; height: 90px"></div>
                                        <label style="width: 80px; height: 50px;">
                                            <a class="button_login" href="#" id="but_login">INGRESAR</a>
                                        </label>*@
                                    @<div class="formRow fluid">
                                        <div class="grid12">
                                            <div class="grid6">
                                                <div class="grid3">
                                                    @Html.LabelFor(Function(model) model.UserName,
                                                        New With
                                                        {
                                                           .style = "left: 35% !important",
                                                           .class = "form-label"
                                                        })
                                                </div>
                                                <div class="grid6">
                                                    @Html.TextBoxFor(Function(model) model.UserName,
                                                         New With
                                                         {
                                                             .onkeypress = "return repunto(event)",
                                                             .class = "loginPic_user2",
                                                             .style = "font-size:12px; font-weight:normal;"
                                                         })
                                                    <br />
                                                   @Html.ValidationMessageFor(Function(model) model.UserName, "", New With {.class = "reqizq"})
                                                </div>
                                            </div>

                                            <div class="grid6">
                                                <div class="grid3">
                                                    @Html.LabelFor(Function(model) model.Password,
                                                       New With
                                                       {
                                                           .style = "left: 35% !important",
                                                           .class = "form-label"
                                                       })
                                                </div>
                                                <div class="grid6">
                                                    @Html.TextBoxFor(Function(model) model.Password,
                                                         New With
                                                         {
                                                             .autocomplete = "off",
                                                             .type = "password",
                                                             .onkeypress = "return pulsar(event);",
                                                             .class = "loginPic_user2",
                                                             .style = "font-size:10px; font-weight:normal;"
                                                         })<br />
                                                    @Html.ValidationMessageFor(Function (model) model.Password, "", New With { .class = "reqizq" })
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    @<div style="clear: both; height: 20px"></div>
                                    @<input type="submit" value="Iniciar" class="button_login" />
                                    @Html.ValidationSummary(True)
                                End Using
                            </div>
                        </div>
                        <div class="clear">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div style="width: 10%; height: auto" class="loginPic">
        <img style=" width:100%;height:100%" src="@Url.Content("~/Content/login/img/logo.png")" alt="" />
    </div>
    <div id="versionBar" class="footer">
        <div id="subFooter" class="container-fluid">
            <div class="row-fluid">
                <div class="span3">
                    <span class="align_left"></span>
                </div>
                <div class="span9">
                    <br />
                    <p class="right align_right">
                        <a href="#" class="fade">Powered by 3Dev Business & Consulting</a>
                    </p>
                </div>
            </div>
        </div>
    </div>
    @*    <script type="text/javascript" src="@Url.Content("~/Content/login/js/jquery-1.7.2.min.js")"></script>
        <script type="text/javascript" src="@Url.Content("~/Content/js/form2js.js")"></script>
        <script type="text/javascript" src="@Url.Content("~/Content/js/json.js")"></script>
        <script type="text/javascript" src="@Url.Content("~/Content/login/js/bootstrap.min.js")"></script>
        <script type="text/javascript" src="@Url.Content("~/Content/login/js/jquery-jrumble.js")"></script>
        <script type="text/javascript" src="@Url.Content("~/Content/login/js/login.js")"></script>
        <script type="text/javascript" src="@Url.Content("~/Content/login/js/global.js")"></script>
        <script type="text/javascript" src="@Url.Content("~/Content/login/js/iphone.check.js")"></script>*@

    @Scripts.Render("~/bundles/lognjq")
    @Scripts.Render("~/bundles/formjs")
    @Scripts.Render("~/bundles/jsonjs")
    @Scripts.Render("~/bundles/lognjs")
    <script src="~/Scripts/jquery.validate.min.js"></script>
    <script src="~/Scripts/jquery.validate.unobtrusive.min.js"></script>
    <script type="text/javascript">
        $(window).load(function () {
            $("#loading").slideDown('slow', function () {
                $(this).remove();
                $('body').removeAttr('style');
            });
        });
    </script>
    <script type="text/javascript">
        function pulsar(e) {
            tecla = (document.all) ? e.keyCode : e.which;
            if (tecla == 13)
                ValidarUsuario();
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

        function repunto(e) { // 1
            tecla = (document.all) ? e.keyCode : e.which; // 2
            if (tecla == 8) return true; // 3
            else if (tecla == 0) return true;
            else if (tecla == 9) return true;
            else if (tecla == 46) return true;
            //else if (tecla == e.keyCode || tecla == e.which) return true;
            patron = /^[ 0-9-A-z]*$/;
            //patron = /\w/; // Acepta N(U)meros y Letras
            te = String.fromCharCode(tecla); // 5
            return patron.test(te); // 6
        }


        function changeHashOnLoad() {
            window.location.href += "#";
            setTimeout("changeHashAgain()", "50");
        }

        function changeHashAgain() {
            window.location.href += "1";
        }

        var storedHash = window.location.hash;
        window.setInterval(function () {
            if (window.location.hash != storedHash) {
                window.location.hash = storedHash;
            }
        }, 50);

    </script>
</body>
</html>
