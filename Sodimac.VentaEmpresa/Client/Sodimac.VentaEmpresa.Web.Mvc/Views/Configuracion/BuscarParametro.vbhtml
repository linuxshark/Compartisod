@ModelType Sodimac.VentaEmpresa.Web.Mvc.ConfiguracionViewModel
@Imports Sodimac.VentaEmpresa.Web.Mvc.ParametrosView
@Code
    ViewData("Title") = "Listar Parámetros Sistema"
End Code
@Html.Hidden("Url_Consutar_Negocio", Url.Action("BuscarParametroNegocio", "Configuracion"))
@*@Html.Hidden("Url_Consutar_Sistema", Url.Action("BuscarParametroSistema", "Configuracion"))
@Html.Hidden("Url_Consutar_Seguridad", Url.Action("BuscarParametroSeguridad", "Configuracion"))*@

<script type="text/javascript" src="/Scripts/View/Configuracion.js"></script>
<div class="breadLine">
    <div class="bc">
        <ul id="breadcrumbs" class="breadcrumbs">
            <li><a href="#">Inicio</a> </li>
            <li class=""><a href="#">Configuración</a></li>
            <li class="current"><a title="" href="#">Parámetros</a> </li>
        </ul>
    </div>
</div>
<div class="contentTop">
    <span class="pageTitle"><span id="IdAgregarTitle" class="icon-screen"></span>Parámetros</span>
    <div class="clear">
    </div>
</div>
<div class="wrapper">
    <div class="main">
        <div class="form">
            <fieldset>
                <div class="widget fluid">
                    <div class="whead">
                        <h6>
                            Configuración de Parámetros
                        </h6>
                        <div class="clear">
                        </div>
                    </div>
                    <ul class="tabs">
                        <li class="activeTab"><a href="#tabb1">Parámetros Negocio</a> </li>
@*                        <li class=""><a href="#tabb2">Parámetros Sistema</a> </li>
                        <li class=""><a href="#tabb3">Parámetros Seguridad</a> </li>*@
                    </ul>
                    <div class="tab_container">
                        <div id="tabb1" class="tab_content" style="display: none;">
                            <div id="Div_grilla_Negocio">
                                
                            </div>
                        </div>
@*                        <div id="tabb2" class="tab_content" style="display: none;">
                        </div>
                        <div id="tabb3" class="tab_content" style="display: none;">
                        </div>*@
                    </div>
                </div>
            </fieldset>
        </div>
    </div>
</div>

<script type="text/javascript" language="javascript">
    $(window).load(function () {
        BuscarNegocio();
    });
</script>
