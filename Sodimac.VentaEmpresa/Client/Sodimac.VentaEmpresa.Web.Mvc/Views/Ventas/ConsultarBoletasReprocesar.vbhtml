@ModelType Sodimac.VentaEmpresa.Web.Mvc.ProcesoViewModel
@Imports Sodimac.VentaEmpresa.Web.Mvc.ParametrosView
@Code
    ViewData("Title") = "ConsultarBoletasReprocesar"
    'Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<div class="breadLine">
    <div class="bc">
        <ul id="breadcrumbs" class="breadcrumbs">
            <li><a href="#">Inicio</a></li>
            <li><a href="#">Mantenedor</a></li>
            <li class="current"><a href="#" title="">Consulta Boletas a Reprocesar</a></li>
        </ul>
    </div>
</div>
<div class="contentTop">
    <span class="pageTitle">
        <span id="IdAgregarTitle" class="icon-screen"></span>Consulta Boletas a Reprocesar
    </span>
    <div class="clear">
    </div>
</div>
@Using(Html.BeginForm("Guardar", "Ventas",  FormMethod.Post, New With {.id = "ConsultarBoletasReprocesar"}))
@<div class="wrapper">


    <div class="main">
        <div class="form">
            <fieldset>
                <div class="widget fluid first_widget">
                    <div class="whead">
                        <h6>
                            Criterios de Búsqueda
                        </h6>
                        <div class="clear">
                        </div>
                    </div>

                    <div class="formRow fluid">
                        <div class="grid4">
                            <div class="grid3">
                                <label class="form-label">
                                    Sucursal:
                                </label>
                            </div>
                            <div class="grid6">
                                @Html.DropDownListFor(Function(m) m.Sucursal.IdSucursal,
                                New SelectList(Model.ListaSucursal, "IdSucursal", "DescripcionSucursal"),
                                "-  SELECCIONE -",
                                New With {
                                    .id = "ID_IdSucursal"
                                })
                                <div id="ID_MsgSucursal"></div>
                            </div>
                        
                        </div>
                        <div class="grid4">
                            <div class="grid3">
                                <label class="form-label">
                                    F. Inicio:
                                </label>
                            </div>
                            <div class="grid6">
                              @Html.TextBoxFor(Function(x) x.ProcesoCarga.Fecha,
                                New With {
                                    .id = "ID_FechaDesde",
                                    .onkeypress = "EnterSubmit(event,'btnConsultar')",
                                    .class = "datepicker maskDate"
                                })
                                <div id="ID_MsgFechaInicio"></div>
                            </div>
                        
                        </div>
                        <div class="grid4">
                            <div class="grid3">
                                <label class="form-label">
                                    F. Fin:
                                </label>
                            </div>
                            <div class="grid6">
                                @Html.TextBoxFor(Function(x) x.ProcesoCarga.fechaFin,
                                New With {
                                    .id = "ID_FechaHasta",
                                    .onkeypress = "EnterSubmit(event,'btnConsultar')",
                                    .class = "datepicker maskDate"
                                })
                                <div id="ID_MsgFechaFin"></div>
                            </div>
                        </div>
                    </div>


                    <div class="formRow fluid">
                        <div class="grid4">
                            <div class="grid3">
                                <label class="form-label">
                                    DNI:
                                </label>
                            </div>
                            <div class="grid6">
                                @Html.TextBoxFor(Function(x) x.ProcesoCarga.Ruc,
                                New With {
                                    .id = "ID_DNI",
                                    .onkeypress = "EnterSubmit(event,'btnConsultar')"
                                })
                 
                            </div>

                        </div>
                        <div class="grid4">
                            <div class="grid3">
                                <label class="form-label">
                                    N. Documento:
                                </label>
                            </div>
                            <div class="grid6">
                                @Html.TextBoxFor(Function(x) x.ProcesoCarga.NumeroDocumento,
                                New With {
                                    .id = "ID_NumDoc",
                                    .onkeypress = "EnterSubmit(event,'btnConsultar')"
                                })
                                <div id="ID_MsgNroDocumento"></div>
                            </div>
                        </div>
                        <div class="grid4">
                            <div class="grid3">
                                <button type="button" name="ActionVer" id="btnConsultar" style="cursor: pointer" onclick="BuscarBoletas()" class="buttonS bBlue formSubmit group_button">
                                    Consultar
                                </button>
                            </div>
                            <div class="grid3">
                                <button type="button" name="ActionVer" id="idGuardar" onclick="GuardarDatos()" style="cursor: pointer" class="buttonS bBlue formSubmit group_button">
                                    Guardar
                                </button>
                            </div>
                        </div>
                      
                    </div>

                    <div class="formRow fluid">
                        <div class="whead">
                            <h6>
                                Resultado de la Busqueda
                            </h6>
                            <div class="clear">
                            </div>
                        </div>
                        <div class="widget fluid">
                   
                            <div id="GrillaRBoletas" style="overflow: scroll;">
                                @Html.Partial("RP_Boletas", Model) 
                            </div>

                        </div>
                    </div>

                    </div>

            </fieldset>
        </div>
    </div>

    
 </div>
    End Using
        
 <div id="Consultar" title="Error">
    <p>
    </p>
</div>  
@Html.Hidden("ID_UrlBuscaBoleta", Url.Action("RP_Boletas"), "Ventas")
<script type="text/javascript" src="@Url.Content("~/Scripts/View/Reproceso.js")"></script>
<script type="text/javascript" language="javascript">
    $(function () {
        //ListarCargosPorPerfil();
        //BuscarBoletas();
    });

</script>
<script>
    var UrlAction = {
      
        urlCargarPrincipal: '@Url.Action("ConsultarBoletasReprocesar")',
 
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