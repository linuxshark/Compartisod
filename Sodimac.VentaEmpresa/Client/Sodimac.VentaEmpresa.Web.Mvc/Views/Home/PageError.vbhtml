@ModelType System.Web.Mvc.HandleErrorInfo
@code
    Layout = Nothing
end code
<!DOCTYPE html>
<html lang="es">
<head>
    <title>SODIMAC - Ocurrió un error... </title>
    <meta charset="utf-8" content="" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta name="description" content="" />
    <meta name="author" content="3devnet" />
    <meta http-equiv="Expires" content="0" />
    <meta http-equiv="Pragma" content="no-cache" />
    <link href="/Content/login/css/bootstrap.css" rel="stylesheet" />
    <link href="/Content/login/css/login.css" rel="stylesheet" type="text/css" />
    <link rel="shortcut icon" href="~/favicon.ico" />
</head>
<body style="overflow: hidden">
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
                            <div class="formLogin" style="height: 100%">
                                <div class="wrapper">
                                    <div class="main">
                                        <fieldset>
                                            <div class="form fluid">
                                                <div class="widget fluid" style="width: 50%; margin: 30px;">
                                                    <div class="whead">
                                                        <h6>
                                                            Ha ocurrido un error mientras se procesaba la peticion al servidor</h6>
                                                        <div class="clear">
                                                        </div>
                                                    </div>
                                                    <div class="formRow">
                                                        @If Not Model Is Nothing Then
                                                            @Model.Exception.Message
                                                        End If
                                                    </div>
                                                    <div class="clear">
                                                    </div>
                                                </div>
                                                <div class="widget fluid" style="width: 50%; margin: 30px;">
                                                    <div class="whead">
                                                        <h6>
                                                            Descripción del Error</h6>
                                                        <div class="clear">
                                                        </div>
                                                    </div>
                                                    <div class="formRow">
                                                        <div class="grid12">
                                                            <label>
                                                                Para mayor información por favor contacte con su administador</label>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="formRow">
                                                    <div class="grid12">
                                                        @If Not Model Is Nothing Then
                                                            @Model.Exception.HelpLink
                                                        End If
                                                    </div>
                                                </div>
                                            </div>
                                        </fieldset>
                                    </div>
                                </div>
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
        <img style=" width:100%;height:100%" src="@Url.Content("~/Content/login/img/logo.png")" alt="" /></div>
    <div id="versionBar" class="footer">
        <div id="subFooter" class="container-fluid">
            <div class="row-fluid">
                <div class="span3">
                    <span class="align_left"></span>
                </div>
                <div class="span9">
                    <br />
                    <p class="right align_right">
                        <a href="#" class="fade">Powered by 3Dev Business & Consulting</a></p>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript" src="@Url.Content("~/Content/login/js/jquery-1.7.2.min.js")"></script>
    <script type="text/javascript" src="@Url.Content("~/Content/js/form2js.js")"></script>
    <script type="text/javascript" src="@Url.Content("~/Content/js/json.js")"></script>
    <script type="text/javascript" src="@Url.Content("~/Content/login/js/bootstrap.min.js")"></script>
    <script type="text/javascript" src="@Url.Content("~/Content/login/js/jquery-jrumble.js")"></script>
    <script type="text/javascript" src="@Url.Content("~/Content/login/js/login.js")"></script>
    <script type="text/javascript" src="@Url.Content("~/Content/login/js/global.js")"></script>
    <script type="text/javascript" src="@Url.Content("~/Content/login/js/iphone.check.js")"></script>
    <script type="text/javascript">
        $(window).load(function () {
            $("#loading").slideDown('slow', function () {
                $(this).remove();
                $('body').removeAttr('style');
            });
        });
    </script>
</body>
</html>
