<!DOCTYPE html>
<html lang="es">
<head>
    <title>@ViewBag.Title</title>
    <meta name="viewport" content="width=device-width" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <link href="/Content/css/forms.css" rel="stylesheet">
    <link href="/Content/css/ie.css" rel="stylesheet">
    <link href="/Content/css/jquery.autocomplete.css" rel="stylesheet">
    <link href="/Content/css/styles.css" rel="stylesheet">

    @Scripts.Render("~/bundles/jqjs")
    @Scripts.Render("~/bundles/spinnjs")
    @Scripts.Render("~/bundles/msljs")
    @Scripts.Render("~/bundles/jquijs")
    @Scripts.Render("~/bundles/jqall/js")
    @Styles.Render("~/bundle/Msctcss")
    @Scripts.Render("~/bundles/Msctcjs")
    @Styles.Render("~/bundle/jquicss")
    @Styles.Render("~/bundle/3devcss")
    @Scripts.Render("~/bundles/chosjs")
    @Styles.Render("~/bundle/choscss")
    @Scripts.Render("~/bundle/jquery-ui/bundle")
    @Scripts.Render("~/Scripts/jqval")
</head>
<body>
    @*<div id="modalContainer">*@
    <div id="loading">
        <script type="text/javascript">
            document.write("<div id='loading-container'><p id='loading-content'>" +
                       "Cargando...</p></div>");
        </script>
    </div>
    <div class="text_success">
        <div class="text_message">
            <img alt="Cargando" src='@Url.Content("~/Content/images/elements/loaders/10s.gif")'><span>
                Espere
                un momento por favor...
            </span>
        </div>
    </div>
    <div id="top">
        <div class="wrapper">
            <a href="/" title="" class="logo">
                <img src='@Url.Content("~/Content/images/sodimac-logo.png")' alt="" height="31" />
            </a>
            <div class="topNav">
                <ul class="userNav">
                    <li><a class="profile" title="Usuario en Sesión" href="#">@Session("UsuarioNombre")</a></li>
                    <li>
                        <a class="logout" title="Cerrar Sesión" href="@Url.Action("LogOff", "Account")">
                            Cerrar Sesión
                        </a>
                    </li>
                </ul>
            </div>
            <div class="clear">
            </div>
        </div>
    </div>
    <div id="sidebar">
        <div class="mainNav">

            @Html.MvcSiteMap().Menu(False, True, False)

            <script type="text/javascript">
                $("#menu").attr("class", "nav");
            </script>
        </div>
    </div>
    <div id="dialogAlert" style="display:none">
        <p id="buttonAlert"></p>
    </div>
    @Html.Hidden("UrlActionGen", Url.Action("Index", "Home"))
    <div id="content" style="height: 100%; width: auto;">
        @RenderBody()
    </div>


    <script type="text/javascript" language="javascript">
        $(window).load(function () {
            $("#loading").slideDown('slow', function () {
                $(this).remove();
                $('body').removeAttr('style');
            });
        });

        $(".text_success").hide();
        $(".text_message").hide();

        $(".text_success").ajaxStart(function () {
            $(".text_message").show();
            $(this).show();
        })

        $(".text_success").ajaxComplete(function () {
            $(".text_message").hide();
            $(this).hide();
        });


    </script>


    @*</div>*@
</body>
</html>
