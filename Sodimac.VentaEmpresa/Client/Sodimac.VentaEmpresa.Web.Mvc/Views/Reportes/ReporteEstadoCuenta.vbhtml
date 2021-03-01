@ModelType Sodimac.VentaEmpresa.Web.Mvc.ReporteViewModel
@Code
    ViewData("Title") = "Reporte Estado de Cuenta"
End Code

<script type="text/javascript" src="/Scripts/View/Reportes.js"></script>
<div class="breadLine">
    <div class="bc">
        <ul id="breadcrumbs" class="breadcrumbs">
            <li><a href="#">Inicio</a> </li>
            <li><a href="#">Reportes</a> </li>
            <li class="current"><a title="" href="#">Reporte Estado de Cuenta</a> </li>
        </ul>
    </div>
</div>

<div class="contentTop">
    <span class="pageTitle"><span id="IdAgregarTitle" class="icon-screen"></span>Reporte
    Estado de Cuenta</span>
    <div class="clear">
    </div>
</div>

<div class="wrapper">
    <div class="main">
        <fieldset>
            <div class="form">
                <div class="widget fluid">
                    <div class="whead">
                        <h6>Filtros de Búsqueda</h6>
                        <div class="clear">
                        </div>
                    </div>
                    <div class="formRow fluid">
                        <div class="grid4">
                            <div class="grid4">
                                <label class="form-label" for="tipoPersona">Razón Social / RUC:</label>
                            </div>
                            <div class="grid6">
                                <input id="ID_RUC" name="Numero.RUC" style="text-transform: uppercase;"
                                type="text" onkeypress="" maxlength="50" />
                            </div>
                        </div>
                    </div>
                    <div class="formRow">
                        <div class="grid12">
                            <button type="button" name="VerReporte" id="btnReporte" style="cursor: pointer"
                            class="buttonS bBlue formSubmit group_button " onclick="VerReporteEstadoCuenta()">
                            Ver Reporte</button>
                            @Html.Hidden("ID_URL", Url.Action("VerReporteEstadoCuenta", "Reportes"))
                        </div>
                        <div class="clear">
                        </div>
                    </div>
                </div>
                <div id="ID_Partial_ReporteEstadoCuenta" style="display: none" class="j_modal" name="Reporte Estado de Cuenta">
                </div>
            </div>
        </fieldset>
    </div>
</div>