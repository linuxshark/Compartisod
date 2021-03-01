@ModelType Sodimac.VentaEmpresa.Web.Mvc.ClientesViewModel
@Imports Sodimac.VentaEmpresa.Web.Mvc.ParametrosView
@Code
    ViewData("Title") = "Buscar Cliente"
End Code
@Html.Hidden("UrlProvincia", Url.Action("ListarProvincia", "Cliente"))
@Html.Hidden("UrlModoPago", Url.Action("GestionarCliente", "Cliente"))
<script type="text/javascript" src="/Scripts/View/Cliente.js"></script>
<div class="breadLine">
    <div class="bc">
        <ul id="breadcrumbs" class="breadcrumbs">
            <li><a href="#">Inicio</a></li>
            <li><a href="#">Mantenedor</a></li>
            <li class="current"><a href="#" title="">Buscar Cliente</a></li>
        </ul>
    </div>
</div>
<div class="contentTop">
    <span class="pageTitle"><span id="IdAgregarTitle" class="icon-screen"></span>Buscar
        Cliente</span>
    <div class="clear">
    </div>
</div>
<div class="wrapper">
    <div class="main">
        <div class="form">
            <fieldset>
                <div class="widget fluid first_widget">
                    <div class="whead">
                        <h6>
                            Criterios de Búsqueda</h6>
                        <div class="clear">
                        </div>
                    </div>
                    <div class="clear">
                    </div>
                    <div class="formRow fluid">
                        <div class="grid6">
                            <div class="grid3">
                                <label class="form-label">
                                    Razón Social / RUC:</label>
                            </div>
                            <div class="grid6">
                                @Html.TextBoxFor(Function(x) x.Empleado.CodigoOfisis,
                                New With {
                                    .id = "ID_RazonSocial",
                                    .style = "text-transform: uppercase;",
                                    .onkeypress = "EnterSubmit(event,'btnBuscar');"
                                })
                                <script type="text/javascript">
                                    $('#ID_RazonSocial').focus();
                                </script>
                            </div>
                        </div>
                        <div class="grid6">
                            <div class="grid3">
                                <label class="form-label">
                                    Modo Pago:</label>
                            </div>
                            <div class="grid6">
                                <div id="divListaModoPago">
                                    @Html.DropDownListFor(Function(m) m.ClienteModoPagoCombo.IdModoPago,
                                    New SelectList(Model.ListaClienteModoPagoCliente, "IdModoPago", "DescripcionModoPago"),
                                    "-TODOS-",
                                    New With {
                                        .id = "ID_ModoPago",
                                        .class = "textinput selector",
                                        .onkeypress = "EnterSubmit(event,'btnBuscar');"
                                    })
                                    @Html.ValidationMessageFor(Function(m) m.ClienteModoPagoCombo.IdModoPago)
                                </div>
                            </div>
                        </div>
                        <div class="clear">
                        </div>
                    </div>
                    <div class="formRow fluid">
                        <div class="grid6">
                            <div class="grid3">
                                <label class="form-label">
                                    Sector:</label>
                            </div>
                            <div class="grid6 ">
                                @Html.DropDownListFor(Function(m) m.ClienteVenta.IdClienteSector,
                                New SelectList(Model.ListaClienteSector, "IdClienteSector", "Descripcion"),
                                "-TODOS-",
                                New With {
                                    .id = "IdClienteSector",
                                    .class = "textinput selector",
                                    .onkeypress = "EnterSubmit(event,'btnBuscar');"
                                })
                                @Html.ValidationMessageFor(Function(m) m.ClienteVenta.IdClienteSector)
                            </div>
                        </div>
                        <div class="grid6">
                            <div class="grid3">
                                <label class="form-label">
                                    Estado:</label>
                            </div>
                            <div class="grid6 ">
                                @Html.DropDownListFor(Function(m) m.ClienteVenta.IdEstadoActual,
                                New SelectList(Model.ListaProcesoEstado, "IdEstado", "Descripcion"),
                                "-TODOS-",
                                New With {
                                    .id = "IdEstado",
                                    .class = "textinput selector",
                                    .onkeypress = "EnterSubmit(event,'btnBuscar');"
                                })
                            </div>
                        </div>
                        <div class="clear">
                        </div>
                    </div>
                    <div class="formRow fluid">
                        <div class="grid6">
                            <div class="grid3">
                                <label class="form-label">
                                    Categoría:</label>
                            </div>
                            <div class="grid6 ">
                                @Html.DropDownListFor(Function(m) m.ClienteVenta.IdClienteCategoria,
                                New SelectList(Model.ListaClienteCategoria, "IdClienteCategoria", "Descripcion"),
                                "-TODOS-",
                                New With {
                                    .id = "IdClienteCategoria",
                                    .class = "textinput selector",
                                    .onkeypress = "EnterSubmit(event,'btnBuscar');"
                                })
                            </div>
                        </div>
                        <div class="grid6">
                            <div class="grid3">
                                <label class="form-label">
                                    Departamento:</label>
                            </div>
                            <div class="grid6  ">
                                <div id="divListaComboModoPago">
                                    @Html.DropDownListFor(Function(m) m.ClienteVenta.IdDepartamento,
                                    New SelectList(Model.ListaEmpleadoDepartamento, "IdDepartamento", "DescripcionDepa"),
                                    "-TODOS-",
                                    New With {
                                        .id = "ID_Departamento",
                                        .onchange = "CargarProvincia();",
                                        .class = "selector",
                                        .onkeypress = "EnterSubmit(event,'btnBuscar');"
                                    })
                                </div>
                            </div>
                        </div>
                        <div class="clear">
                        </div>
                    </div>
                    <div class="formRow fluid">
                        <div class="grid6">
                            <div class="grid3">
                                <label class="form-label">
                                    Tipo:</label>
                            </div>
                            <div class="grid6">
                                <div id="divListaClienteTipo">
                                    @Html.DropDownListFor(Function(m) m.ClienteVenta.ClienteTipo.IdClienteTipo,
                                    New SelectList(Model.ListaClienteTipo, "IdClienteTipo", "Descripcion"),
                                    "-TODOS-",
                                    New With {
                                        .id = "ID_ClienteTipo",
                                        .class = "textinput selector",
                                        .onkeypress = "EnterSubmit(event,'btnBuscar');"
                                    })
                                    @Html.ValidationMessageFor(Function(m) m.ClienteVenta.ClienteTipo.IdClienteTipo)
                                </div>
                            </div>
                        </div>
                        <div class="grid6">
                            <div class="grid3">
                                <label class="form-label">
                                    Provincia:</label>
                            </div>
                            <div class="grid6 ">
                                <div id="divListaComboProvincia">
                                    @Html.Partial(ParametrosPartialView.UCCLiente_Provincia_Combo, Model)
                                </div>
                            </div>
                        </div>
                        <div class="clear">
                        </div>
                    </div>
                    <div class="formRow noBorderB">
                        <button type="button" name="ActionCancelar" id="btnCancelar" style="cursor:pointer"onclick="RedireccionarRegistro('@Url.Action("GestionarCliente", "Cliente")');"  class="buttonS bBlue formSubmit group_button" >
                            Nuevo</button>
                        <button type="button" name="ActionGrabar" id="btnBuscar" style="cursor: pointer"
                            class="buttonS bBlue formSubmit group_button">
                            Buscar</button>
                        <div class="clear">
                        </div>
                        <div class="grid6">
                        </div>
                    </div>
                </div>
                <div class="widget">
                    <div class="whead">
                        <h6>
                            Resultados de la Búsqueda</h6>
                        <div class="clear">
                        </div>
                    </div>
                    <div id="contendorgrilla-ListaClientes">
                        @Html.Partial("_BuscarCliente", Model)
                    </div>
                </div>
            </fieldset>
        </div>
    </div>
</div>
@Html.Hidden("idUrlCliente", Url.Action("_BuscarCliente"), "Cliente")
<script type="text/javascript">
    $(window).load(function () {
        BuscarCliente();
    });
</script>