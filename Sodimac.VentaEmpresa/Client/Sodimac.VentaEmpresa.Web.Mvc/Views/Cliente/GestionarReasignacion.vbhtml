@ModelType Sodimac.VentaEmpresa.Web.Mvc.ClientesViewModel
@Imports Sodimac.VentaEmpresa.Web.Mvc.ParametrosView
@Html.Hidden("UrlZonaInactiva", Url.Action("PVSucursalporZona", "Cliente"))
@Html.Hidden("UrlZonaActiva", Url.Action("PVSucursalporZonaActiva", "Cliente"))
@Html.Hidden("UrlVendedor", Url.Action("PVVendedorPorSucursal", "Cliente"))
@Html.Hidden("UrlVendedorActivo", Url.Action("PVVendedorPorSucursalActivos", "Cliente"))
<div class="breadLine">
    <div class="bc">
        <ul id="breadcrumbs" class="breadcrumbs">
            <li><a href="#">Inicio</a></li>
            <li><a href="#">Mantenedor</a></li>
            <li class="current"><a href="#" title="">Reasignar cliente</a></li>
        </ul>
    </div>
</div>
<div class="contentTop">
    <span class="pageTitle"><span class="icon-screen" id="IdAgregarTitle"></span>Reasignar
        Clientes VVEE :</span>
    <div class="clear">
    </div>
</div>
<div class="wrapper">
    @Html.AntiForgeryToken()
    <div class="form">        
        <fieldset>
            <div class="widget fluid" id="divDefinicion">
                <div class="whead">
                    <h6>
                        Reasignación Clientes</h6>
                    <div class="clear">
                    </div>
                </div>
                <div class="body">
                    <div class="widget">
                        <div class="formRow fluid">
                            <div class="grid6">
                                <div class="grid4">
                                    <label class="form-label" style="float: right">
                                        Zona :</label>
                                </div>
                                <div class="grid4" style="margin-left: 10%">
                                    @Html.DropDownListFor(Function(m) m.ZonaMantenimiento.IdZona,
                                                  New SelectList(Model.ListaZonaMantenimiento, "IdZona", "NombreZona"),
                                                  "-SELECCIONE-",
                                                  New With {
                                                            .id = "ID_IdzonaInactiva",
                                                            .class = "selector",
                                                            .onchange = "CargarSucursalesporZona();"
                                                      }
                                                  )
                                </div>
                            </div>
                            <div class="grid6">
                                <div class="grid5">
                                    <label class="form-label" style="float: right">
                                        Zona :</label>
                                </div>
                                <div class="grid4" style="margin-left: 10%">
                                    @Html.DropDownListFor(Function(m) m.ZonaMantenimiento.IdZona,
                                                  New SelectList(Model.ListaZonaMantenimiento, "IdZona", "NombreZona"),
                                                  "-SELECCIONE-",
                                                  New With {
                                                            .id = "ID_IdzonaActiva",
                                                            .class = "selector",
                                                            .onchange = "CargarSucursalesporZonaActiva();"
                                                      }
                                                  )
                                </div>
                            </div>
                        </div>
                        <div class="formRow fluid">
                            <div class="grid6">
                                <div class="grid4">
                                    <label class="form-label" style="float: right">
                                        Sucursal :</label>
                                </div>
                                <div class="grid4" style="margin-left: 10%">
                                    <div id="DivListaSucursalporZona">
                                        @Html.Partial(ParametrosPartialView.PVSucursal_ZonaReasignar, Model)
                                    </div>
                                </div>
                            </div>
                            <div class="grid6">
                                <div class="grid5">
                                    <label class="form-label" style="float: right">
                                        Sucursal :</label>
                                </div>
                                <div class="grid6" style="margin-left: 10%">
                                    <div id="DivListaSucursalporZonaActiva">
                                        @Html.Partial(ParametrosPartialView.PVSucursalporZonaReasignarActiva, Model)
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="formRow fluid">
                            <div class="grid6">
                                <div class="grid4">
                                    <label class="form-label" style="float: right">
                                        Vendedor :</label>
                                </div>
                                <div class="grid6" style="margin-left: 10%">
                                    <div id="divListaVendedorInactivo">
                                        @Html.Partial(ParametrosPartialView.PVVendedor_Sucursal, Model)
                                    </div>
                                </div>
                            </div>
                            <div class="grid6">
                                <div class="grid5">
                                    <label class="form-label" style="float: right">
                                        Vendedor :</label>
                                </div>
                                <div class="grid6" style="margin-left: 10%">
                                    <div id="divListaVendedorActivo">
                                        @Html.Partial(ParametrosPartialView.PVVendedor_SucursalActivos, Model)
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="formRow fluid">
                            <div class="grid6">
                                <div class="grid4">
                                    <label class="form-label" style="float: right">
                                    </label>
                                </div>
                                <div class="grid6" style="margin-left: 10%">
                                </div>
                            </div>
                            <div class="grid6">
                                <div class="grid5">
                                    <label class="form-label" style="float: right">
                                        Fecha de Activación :</label>
                                </div>
                                <div class="grid6" style="margin-left: 10%">
                                    @Html.TextBoxFor(Function(m) (m.VentaCartera.FechaActivacion),
                                New With {
                                    .id = "ID_FechaActivacion",
                                    .class = "datepicker maskDate",
                                    .value = String.Format("{0:d}", " ")
                                })
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="leftPart">
                        CLIENTE NO ASIGNADOS
                        <div class="filter">
                            <span>Filtro: </span>
                            @Html.TextBox("txtFiltro", "", New With {.id = "box1Filter", .class = "boxFilter upperclass", .maxlength = "30", .onkeypress = "return val_AZ(event)"})
                            <input type="button" id="box1Clear" class="fBtn" value="x" /><div class="clear">
                            </div>
                        </div>
                        <div id="lstclienteVenta">
                            @Html.Partial(ParametrosPartialView.PVCliente_Vendedor, Model)
                        </div>
                        <br />
                        <span id="box1Counter" class="countLabel"></span>
                        <div class="dn">
                            <select id="box1Storage" name="box1Storage">
                            </select></div>
                    </div>
                    <div class="dualControl">
                        <button id="to2" type="button" class="basic mr5 mb15" title="Agregar Usuario">
                            &nbsp;&gt;&nbsp;</button>
                        <button id="allTo2" type="button" class="basic" title="Agregar Todos">
                            &nbsp;&gt;&gt;&nbsp;</button><br />
                        <button id="to1" type="button" class="basic mr5" title="Quitar Usuario">
                            &nbsp;&lt;&nbsp;</button>
                        <button id="allTo1" type="button" class="basic" title="Quitar Todos">
                            &nbsp;&lt;&lt;&nbsp;</button>
                    </div>
                    <div class="rightPart">
                        CLIENTES ASIGNADOS AL VENDEDOR
                        <div class="filter">
                            <span>Filtro: </span>
                            @Html.TextBox("txtFiltro2", "", New With {.id = "box2Filter", .class = "boxFilter upperclass", .maxlength = "30", .onkeypress = "return val_AZ(event)"})
                            <input type="button" id="box2Clear" class="fBtn" value="x" /><div class="clear">
                            </div>
                        </div>
                        <div id="lstclienteventa2">
                            @* @Html.Partial(ParametrosPartialView.PVCliente_VendedorActivo,Model) *@
                            <script type="text/javascript" src="@Url.Content("~/Content/js/plugins/forms/jquery.dualListBox.js")"></script>
                            <select id="box2View" multiple="multiple" class="multiple" style="height: 300px;">
                            </select>
                            <br />
                        </div>
                        <br />
                        <span id="box2Counter" class="countLabel"></span>
                        <div class="dn">
                            <select id="box2Storage" name="box1Storage">
                            </select></div>
                        <div class="clear">
                        </div>
                    </div>
                    <div class="clear">
                    </div>
                    <div class="formRow">
                        <button type="button" name="ActionAgregar" id="btnAsignar" style="cursor:pointer" class="buttonS bBlue formSubmit group_button" onclick="AsignarClienteVendedor('@Url.Action("AsignarClientesVendedor", "Cliente")');" >
                            Asignar</button>
                        <button type="button" name="ActionCancelar" id="btnCancelar" style="cursor: pointer"
                            class="buttonS bDefault formSubmit group_button" onclick="dialogCancelarGestionReasignar();">
                            Cancelar</button>
                        <br class="clear" />
                        <div class="clear">
                        </div>
                    </div>
                    <div class="formRow fluid">
                    </div>
                </div>
            </div>
        </fieldset>
    </div>
</div>
<div id="dialogCancelarGestionReasignar" title="Mensaje de Confirmación">
    <p>
        ¿Desea cancelar el registro?</p>
</div>
<div id="dialogInformacionResultado">
</div>
@Html.Hidden("ID_UrlClienteporVendedor", Url.Action("VistaClienteporVendedor"), "Cliente")
@Html.Hidden("ID_UrlClienteporVendedorActivos", Url.Action("VistaClienteporVendedorActivos"), "Cliente")
@* @Html.Hidden("IdUrl_RolDestino", Url.Action("ConsultarRol_PVGrilla", "Account"))*@
@* <input type="hidden" value="@Url.Action("VistaClienteporVendedor", "Cliente")" id="paramUrl_Account"/>*@
<script type="text/javascript" src="@Url.Content("~/Scripts/View/Cliente.js")"></script>
<script type="text/javascript" src="@Url.Content("~/Content/js/plugins/forms/jquery.dualListBox.js")"></script>
<script type="text/javascript" language="javascript">
    $(window).load(function () {

    });

    function UpdateLabel(group) {
        var showingCount = $("#" + group.view + " option").size();
        var hiddenCount = $("#" + group.storage + " option").size();
        $("#" + group.counter).text('Showing ' + showingCount + ' of ' + (showingCount + hiddenCount));
    }
    $("#ID_FechaActivacion").datepicker({
        showOtherMonths: true,
        autoSize: true,
        changeMonth: true,
        changeYear: true,
        appendText: '(DD/MM/AAAA)',
        dateFormat: 'dd/mm/yy'
    });
    InicioJPopUpConfirm("#dialogCancelarGestionReasignar", 490, false, "Mensaje de Confirmación", CancelarRegistroReasignar);

</script>
