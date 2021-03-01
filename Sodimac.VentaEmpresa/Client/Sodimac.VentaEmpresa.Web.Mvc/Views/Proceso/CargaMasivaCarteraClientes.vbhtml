@ModelType Sodimac.VentaEmpresa.Web.Mvc.ProcesoViewModel

@Code
    ViewData("Title") = "CargaMasivaCarteraClientes"
End Code

<div class="breadLine">
    <div class="bc">
        <ul id="breadcrumbs" class="breadcrumbs">
            <li><a href="#">Inicio</a></li>
            <li><a href="#">Procesos</a></li>
            <li class="current"><a href="#" title="">Carga Masiva Cartera Clientes</a></li>
        </ul>
    </div>
</div>
<div class="contentTop">
    <span class="pageTitle">
        <span id="IdAgregarTitle" class="icon-screen"></span>
        Cargar Clientes de Cartera
    </span>
    <div class="clear">
    </div>
</div>

@Using (Html.BeginForm("CargarClienteCartera", "Proceso", FormMethod.Post, New With {.id = "FrmClienteCartera", .enctype = "multipart/form-data"}))
    @<div class="wrapper">
        <div class="main">
            <div class="widget fluid">
                <div class="whead">
                    <h6> Cargar Clientes</h6>
                    <div class="clear"> </div>
                </div>
                <div class="formRow fluid">
                    <div class="grid5">
                        <div class="grid3">
                            <label>
                                Adjuntar archivo:
                            </label>
                        </div>
                        <div class="grid6">
                            <input type="file" id="IdFileSelect" name="file1" />
                            <span style="display: none;" id="idReqFile" class="req">
                                Requerido
                            </span>
                        </div>
                    </div>
                    <div class="grid3">
                        <div class="grid4">
                            <button type="button" name="ActionVer" id="descargar" style="cursor: pointer" onclick="DescargarArchivo()" class="buttonS bBlue formSubmit group_button">
                                Descargar
                            </button>
                        </div>
                        <div class="grid4">
                            <button type="button" name="ActionVer" id="registrar" style="cursor: pointer" onclick="Guardar()" class="buttonS bBlue formSubmit group_button">
                                Guardar
                            </button>
                        </div>
                    </div>
                </div>
                <center>
                    @*@If Not Model.ListaProcesoCargaErrorTotales.ListaProcesoCargaErrorTotalCliente.Count.Equals(0) Then*@
                    @If Not 0 < 1 Then
                        @*@Html.Partial("PV_CargaClienteError", Model)*@
                    Else
                        @<div id="GrillaPrincipal" class="widget fluid">
                            <ul class="tabs">
                                <li id="lnk0" class="activeTab"><a href="#tabb1">Cartera de Clientes</a> </li>
                            </ul>
                            <div class="wrapper">
                                <div class="tab-container">
                                    <div id="tabb1" class="tab_content" style="display: block;">
                                        <div class="formRow fluid">
                                            <div class="widget fluid">
                                                <div id="GrillaCMCliente" style="overflow:auto">
                                                    @Html.Partial("PV_CargaMasivaCarteraClientes", Model)
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    End If
                </center>
            </div>
        </div>
    </div>

    @Html.HiddenFor(Function(m) m.Mensaje)
    @Html.HiddenFor(Function(m) m.ClienteCartera.Accion, New With {.id = "accion"})
    @Html.HiddenFor(Function(m) m.DesAccion, New With {.id = "desAccion"})
    @Html.HiddenFor(Function(m) m.DesAccionAnt, New With {.id = "desAccionAnt"})
    @Html.HiddenFor(Function(m) m.grabar)
End Using

<div id="idVentana" title="Error">
    <p>
    </p>
</div>
<div id="idRegitrar" title="Error">
    <p>
    </p>
</div>
@Scripts.Render("~/Scripts/View/CargaMasivaCarteraClientes.js")
<script>
    var UrlAction = {
        urlCargarCliente: '@Url.Action("CargarClienteCartera")',
        urlRegistrarCliente: '@Url.Action("GuardarCarteraCliente")',
        urlCargarPrincipal: '@Url.Action("CargaMasivaCarteraClientes")',
        urlDescargaPlantilla: '@Url.Action("DescargarPlantillaCarteraCliente")'
    }
</script>
