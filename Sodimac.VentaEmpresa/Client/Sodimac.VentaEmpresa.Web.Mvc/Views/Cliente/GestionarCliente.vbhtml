@ModelType Sodimac.VentaEmpresa.Web.Mvc.ClientesViewModel
@Imports Sodimac.VentaEmpresa.Web.Mvc.ParametrosView
@Imports Sodimac.VentaEmpresa.Common
@Code
    If Model.ClienteVenta.IdCliente = 0 Then
        ViewData("Title") = "Nuevo Cliente"
    Else
        ViewData("Title") = "Detalle Cliente"
    End If
End Code
<script type="text/javascript" src="@Url.Content("~/Scripts/View/Cliente.js")"></script>
<div class="breadLine">
    <div class="bc">
        <ul id="breadcrumbs" class="breadcrumbs">
            <li><a href="#">Inicio</a></li>
            <li><a href="#">Mantenedor</a></li>
            @If Model.ClienteVenta.IdCliente = 0 Then
                @<li class="current"><a href="#" title="">Nuevo Cliente</a></li>
            Else
                @<li class="current"><a href="#" title="">Detalle Cliente</a></li>
            End If
        </ul>
    </div>
</div>
<div class="contentTop">
    @If Model.ClienteVenta.IdCliente = 0 Then
        @<span class="pageTitle">
            <span id="IdAgregarTitle" class="icon-screen"></span>Nuevo
            Cliente
        </span>
        @Html.Hidden("Id_Activo", 1)
    Else
        @<span class="pageTitle">
            <span id="IdAgregarTitle" class="icon-screen"></span>Detalle
            Cliente
        </span>
        @Html.Hidden("Id_Activo", CInt(Model.ClienteVenta.Activo))
    End If
    <div class="clear">
    </div>
    </div>
    <div class="wrapper">
        <div class="main">
            <div class="form">
                <fieldset>
                    <div class="widget fluid" id="tabsDemo" style="z-index: 100">
                        @*  <div id="tabs">*@
                        <ul class="tabs">
                            <li id="tabPage1" class="activeTab"><a href="#TabDatosCliente">Datos Generales</a></li>
                            @*@If (Model.ClienteVenta.Activo) Then*@
                            @If (Model.ClienteVenta.IdCliente <> 0) Then
                                @<li id="tabPage3" class=""><a href="#TabContactoCliente">Personal Contacto</a></li>
                                @<li id="tabPage2" class=""><a href="#TabCarteraCliente">Representante Ventas</a></li>
                                @If Model.ClienteVenta.IdModoPago = Constantes.ID_MODOPAGO_CREDITO Then
                                    @<li id="tabPage4" class="">
                                        <a href="#TabHistorialCredito">
                                            Historial de Líneas
                                            de Créditos
                                        </a>
                                    </li>
                                End If
                                @<li id="tabPage5" class=""><a href="#TabListaArchivo">Archivos Adjuntos</a> </li>
                                @*@<li id="tabPage6" class=""><a href="#TabCarteraCompartida">Cartera Compartida</a> </li>*@
                            End If
                        </ul>
                        <div class="tab_container">
                            <div id="TabDatosCliente" class="tab_content">
                                @Html.Partial(ParametrosPartialView.Datos_Cliente_Ruta_Tab, Model)
                            </div>
                            @If (Model.ClienteVenta.Activo) Then
                                @<div id="TabCarteraCliente" class="tab_content">
                                    <div class="wrapper">
                                        @Html.Partial(ParametrosPartialView.CarteraCliente_TAB, Model)
                                    </div>
                                </div>
                                @<div id="TabContactoCliente" class="tab_content">
                                    <div class="wrapper">
                                        <div id="divListaClienteContacto">
                                        </div>
                                    </div>
                                </div>
                                @<div id="TabHistorialCredito" class="tab_content">
                                    @If Model.ClienteVenta.IdModoPago = Constantes.ID_MODOPAGO_CREDITO Then
                                        @<div class="wrapper">
                                            @Html.Partial(ParametrosPartialView.Historial_Credito_Cliente_Ruta_Tab, Model.ListaClienteLineaCredito)
                                        </div>
                                    End If
                                </div>
                                @<div id="TabListaArchivo" class="tab_content">
                                    @Html.Partial(ParametrosPartialView.Archivos_Cliente_Ruta_Tab, Model)
                                </div>
                                @*@<div id="TabCarteraCompartida" class="tab_content">
                                    <div class="wrapper">
                                        @Html.Partial(ParametrosPartialView.CarteraCompartida_TAB, Model)
                                    </div>
                                </div>*@
                            End If
                        </div>
                        @*    </div>*@
                    </div>
                </fieldset>
            </div>
        </div>
    </div>
    <div id="dialogInformacionGuardar" title="Mensaje de Confirmación">
        <p>
            ¿Desea guardar el registro?
        </p>
    </div>
    <div id="dialogInformacionGuardarCartera" title="Mensaje de Confirmación">
        <p>
            ¿Desea guardar el registro de cartera de cliente?
        </p>
    </div>
    <div id="dialogInformacionFechasCarteraGuardar" title="Mensaje de Confirmación">
        <p>
            ¿Desea guardar las fechas para la cartera de cliente?
        </p>
    </div>
    <div id="dialogInformacionCancelar" title="Mensaje de Confirmación">
        <p>
            ¿Desea cancelar el registro?
        </p>
    </div>
    <div id="dialogInformacionCancelarCartera" title="Mensaje de Confirmación">
        <p>
            ¿Desea cancelar el registro?
        </p>
    </div>
    <div id="dialogInformacionActualizar" title="Mensaje de Confirmación">
        <p>
            ¿Desea actualizar el registro?
        </p>
    </div>
    <div id="dialogInformacionCancelarActualizar" title="Mensaje de Confirmación">
        <p>
            ¿Desea cancelar la actualización?
        </p>
    </div>
    <div id="dialogInformacionResultado" title="Confirmación!">
    </div>
    <div id="dialogInformacionFechasResultado" title="Confirmación!">
    </div>
    <div id="dialogInformacionResultadoCartera" title="Confirmación!">
    </div>
    <div id="dialogEstadoCartera" title="Mensaje de confirmación">
        <div class="widget fluid">
            <div class="formRow">




                <div style="">
                    <label>
                        ¿Desea actualizar el estado?
                    </label>
                    <br />
                    <div class="grid12">
                        <div class="grid6">
                            <label>Ingrese la fecha desasignación : </label>
                        </div>
                        <div class="grid3">
                            <input id="iIdFechaDesasignacion" type="text" class="textinput datepicker" onpaste="return false" />
                        </div>
                    </div>

                    <div class="grid12">
                        <div id="MsgErrorFec" style="color:Red; margin-bottom:5px;">

                        </div>
                    </div>

                    <div class="grid12">
                        <div style="float:right; margin-bottom:10px;" class="grid6">
                            <input type="button" id="iIdButtonNo" value="No" onclick="CerrarPopUp()" class="buttonS bBlue formSubmit group_button" style="cursor: pointer;"></input>
                            <input type="button" id="iIdButtonSi" value="Si" onclick="ActualizarEstadoCartera()" class="buttonS bBlue formSubmit group_button" style="cursor: pointer;"></input>
                        </div>
                    </div>
                </div>


            </div>
        </div>
    </div>
    <div id="dialogEstadoCarteraCliente" title="Mensaje de Confirmación">
        <p>
            ¿Desea eliminar la cartera?
        </p>
    </div>
    @Html.HiddenFor(Function(m) m.ClienteVenta.IdCliente, New With {.id = "ID_IdCliente"})
    @Html.HiddenFor(Function(m) m.ClienteVenta.Estado.Codigo, New With {.id = "Id_CodigoEstado"})
    @*@Html.HiddenFor(Function(m) m.ClienteVenta.Activo, New With {.id = "Id_Activo"})*@
    @Html.Hidden("UrlVerificarMeson", Url.Action("VerificarMesonActivo", "Cliente"))
    @Html.HiddenFor(Function(m) m.GuardaArchivo, New With {.id = "ID_GuardaArchivo"})
    @Html.Hidden("ID_UrlCliente_PVHistorial", Url.Action("Cliente_PVHistorial"), "Cliente")
    @Html.Hidden("ID_UrlCartera", Url.Action("CarteraClientes"), "Cliente")
    @Html.Hidden("ID_UrlCarteraCompartida", Url.Action("CarteraCompartida"), "Cliente")
    @Html.Hidden("ID_UrlCarteraCompartidaFechas", Url.Action("CarteraCompartidaFechas"), "Cliente")
    @Html.Hidden("ID_Cliente_PVPersonal", Url.Action("Cliente_PVPersonal"), "Cliente")
    <script type="text/javascript" language="javascript">
        $(function () {
            ListaClienteLineaCredito();
            ListarCarteraClientes();
            BuscarClientePersonal();
            ListarFechasCarteraCompartida();
            //        InicioJPopUpConfirm("#dialogEstadoCartera", 490, false, "Mensaje de Confirmación", ActualizarEstadoCartera);
            InicioJPopUpConfirm("#dialogEstadoCarteraCliente", 490, false, "Mensaje de Confirmación", DesactivarCarteraCliente);

            InicioJPopUp("#dialogEstadoCartera", 490, 230, false, "Mensaje de Confirmación");

            var vGuardaArchivo = $("#ID_GuardaArchivo").val();
            if (vGuardaArchivo == "True") {
                $("#TabDatosCliente").hide();
                $("#TabCarteraCliente").hide();
                $("#TabContactoCliente").hide();
                $("#TabHistorialCredito").hide();
                $("#TabCarteraCompartida").hide();
                $("#TabListaArchivo").show();
                $("#tabPage1").prop('class', '');
                $("#tabPage2").prop('class', '');
                $("#tabPage3").prop('class', '');
                $("#tabPage4").prop('class', '');
                $("#tabPage6").prop('class', '');
                $("#tabPage5").prop('class', 'activeTab');
            }
            else {
                $("#TabDatosCliente").show();
                $("#TabCarteraCliente").hide();
                $("#TabContactoCliente").hide();
                $("#TabHistorialCredito").hide();
                $("#TabCarteraCompartida").hide();
                $("#TabListaArchivo").hide();
                $("#tabPage1").prop('class', 'activeTab');
                $("#tabPage2").prop('class', '');
                $("#tabPage3").prop('class', '');
                $("#tabPage4").prop('class', '');
                $("#tabPage5").prop('class', '');
                $("#tabPage6").prop('class', '');
            }


        });
    </script>
    <script type="text/javascript" language="javascript">
        $(function () {
            var vIdEstado = $("#Id_CodigoEstado").val();
            var vActivo = parseInt($("#Id_Activo").val());
            //        if (vIdEstado == "INACTIVO" || !vActivo) {
            if (!vActivo) {
                $(function () {
                    var $tabs = $("#tabsDemo");
                    $tabs.tabs();
                    $tabs.tabs("option", 'enable', [0, 1, 2]);
                    $tabs.tabs("option", 'disabled', [1, 2, 3, 4]);
                    $("#TabDatosCliente select").prop('disabled', true);
                    $("#TabDatosCliente input").prop('disabled', true);
                });
            }
        });

    </script>
