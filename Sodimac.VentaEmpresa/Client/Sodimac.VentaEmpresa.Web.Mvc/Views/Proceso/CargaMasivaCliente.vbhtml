@ModelType Sodimac.VentaEmpresa.Web.Mvc.CargaMasivaClienteViewModel
@Code
    ViewData("Title") = "CargaMasivaCliente"
End Code

<div class="breadLine">
    <div class="bc">
        <ul id="breadcrumbs" class="breadcrumbs">
            <li><a href="#">Inicio</a> </li>
            <li><a href="#">Procesos</a> </li>
            <li class="current"><a title="" href="#">Carga Masiva Clientes</a> </li>
        </ul>
    </div>
</div>
<div class="contentTop">
    <span class="pageTitle">
        <span id="IdAgregarTitle" class="icon-screen"></span>
        Carga Masiva Clientes
    </span>
    <div class="clear">
    </div>
</div>
@Using (Html.BeginForm("CargarClientePri", "Proceso", FormMethod.Post, New With {.id = "FrmCargaMasivaCliente", .enctype = "multipart/form-data"}))
    @<div class="wrapper">
        <div class="main">
                <div class="widget fluid">
                    <div class="whead">
                        <h6>
                            Filtros de Búsqueda
                        </h6>
                        <div class="clear"></div>
                    </div>
                    <div class="formRow fluid">
                        <div class="grid4">
                            <div class="grid3">T. Operación: </div>
                            @Html.DropDownListFor(Function(m) m.TipoOperacion.IdTipoOperacion,
                                                  New SelectList(Model.ListaTipoOperacion, "IdTipoOperacion", "Descripcion"))
                        </div>
                        <div class="grid6">
                            <div class="grid3">Adjuntar Archivo: </div>
                            <div class="grid9">
                                <input type="file" id="IdFileSelect" name="file1" />
                                <span style="display: none;" id="idReqFile" class="req">Requerido</span>
                            </div>
                        </div>
                        <div class="grid2">
                            <button type="button" id="descargar" style="cursor: pointer" class="buttonS bBlue">
                                Descargar
                            </button>
                            <button type="button" id="registrar" style="cursor: pointer" class="buttonS bBlue formSubmit group_button">
                                Guardar
                            </button>
                        </div>
                    </div>
                    <center>
                        @If Not Model.ListaProcesoCargaErrorTotales.ListaProcesoCargaErrorTotalCliente.Count.Equals(0) Or
                            Not Model.ListaProcesoCargaErrorTotales.ListaProcesoCargaErrorTotalClienteEmpleado.Count.Equals(0) Then
                            @Html.Partial("PV_CargaClienteError", Model)
                        Else
                            @<div id ="GrillaPrincipal"class="widget fluid">
                                <ul class="tabs">
                                    <li id="lnk0" class="activeTab"><a href="#tabb1">Clientes</a> </li>
                                    <li id="lnk1" class=""><a href="#tabb2">Empleados Asociados</a> </li>
                                </ul>
                                <div class="wrapper">
                                    <div class="tab-container">
                                        <div id="tabb1" class="tab_content" style="display: block;">
                                            <div class="formRow fluid">
                                                <div class="widget fluid">
                                                    <div id="GrillaCMCliente" style="overflow:auto">
                                                        @Html.Partial("PV_CargaMasivaCliente", Model)
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div id="tabb2" class="tab_content" style="display: none;">
                                            <div class="formRow fluid">
                                                <div class="widget fluid">
                                                    <div id="GrillaCMClienteEmpleado" style="overflow:auto">
                                                        @Html.Partial("PV_CargaMasivaClienteEmpleado", Model)
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
@Html.HiddenFor(Function(m) m.mensaje)
@Html.HiddenFor(Function(m) m.CargaMasivaCliente.Accion, New With {.id = "accion"})
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
@Scripts.Render(
            "~/Scripts/View/CargaMasivoCliente.js"
        )
<script>
    var UrlAction = {
        urlCargarCliente: '@Url.Action("CargarClientePri")',
        urlRegistrarCliente: '@Url.Action("GuardarCliente")',
        urlCargarPrincipal: '@Url.Action("CargaMasivaCliente")',
        urlDescargaPlantilla: '@Url.Action("DescargarPlantilla")'
    }
    //$("#idVentana").dialog({
    //    autoOpen: false,
    //    width: 250,
    //    height: 100,
    //    modal: true,
    //    resizable: true,
    //    hide: 'fade',
    //    show: 'fade',
    //    title: "Transacción"

    //});

</script>

@*<script type="text/javascript">
    var qParam = $("#mensaje").val()
    //var qParam = getParameterByName('mensage');
    if (qParam == "")
        {}
    else
    {
        $("#idVentana p").text(qParam);
        $("#idVentana").dialog('open');
    }
</script>*@