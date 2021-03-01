@Code
    ViewData("Title") = "Buscar Empleado"
End Code
@ModelType Sodimac.VentaEmpresa.Web.Mvc.VentasViewModel
@Imports Sodimac.VentaEmpresa.Web.Mvc.ParametrosView

@Html.Hidden("UrlCargos", Url.Action("PVPerfil_ComboCargo", "Ventas"))

<script type="text/javascript" src="/Scripts/View/Vendedor.js"></script>
<div class="breadLine">
    <div class="bc">
        <ul id="breadcrumbs" class="breadcrumbs">
            <li><a href="#">Inicio</a></li>
            <li><a href="#">Mantenedor</a></li>
            <li class="current"><a href="#" title="">Buscar Empleado</a></li>
        </ul>
    </div>
</div>
<div class="contentTop">
    <span class="pageTitle">
        <span id="IdAgregarTitle" class="icon-screen"></span>Buscar
        Empleado
    </span>
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
                            Criterios de Búsqueda
                        </h6>
                        <div class="clear">
                        </div>
                    </div>
                    <div class="formRow fluid">
                        <div class="grid6">
                            <div class="grid3">
                                <label class="form-label">
                                    Apellidos y Nombres:
                                </label>
                            </div>
                            <div class="grid6">
                                @Html.TextBoxFor(Function(x) x.Empleado.NombresApellidos,
                                New With {
                                    .onkeypress = "EnterSubmit(event,'btnBuscar');",
                                    .id = "ID_NombresApellidos"
                                })
                                @Html.ValidationMessageFor(Function(x) x.Empleado.NombresApellidos, "",
                                New With {
                                    .class = "reqizq"
                                })
                            </div>
                            <script type="text/javascript">
                                $('#ID_NombresApellidos').focus();
                            </script>
                        </div>
                        <div class="grid6">
                            <div class="grid3">
                                <label class="form-label">
                                    Código Ofisis:
                                </label>
                            </div>
                            <div class="grid6">
                                @Html.TextBoxFor(Function(x) x.Empleado.CodigoOfisis,
                                New With {
                                    .id = "ID_CodigoOfisis",
                                    .onkeypress = "EnterSubmit(event,'btnBuscar'); return val_09(event)",
                                    .maxlength = "44"
                                })
                                @Html.ValidationMessageFor(Function(x) x.Empleado.CodigoOfisis, "",
                                New With {
                                    .class = "reqizq"
                                })
                            </div>
                        </div>
                    </div>
                    <div class="formRow fluid">
                        <div class="grid6">
                            <div class="grid3">
                                <label class="form-label">
                                    Perfil:
                                </label>
                            </div>
                            <div class="grid6">
                                @Html.DropDownListFor(Function(m) m.Empleado.Perfil.IdPerfil,
                                  New SelectList(Model.ListaPerfil, "IdPerfil", "NombrePerfil"),
                                  "-TODOS- ",
                                          New With {
                                                   .id = "ID_Perfil",
                                                   .class = "textinput selector",
                                                   .onchange = "ListarTipoRepresentanteVenta();"
                                              })
                            </div>
                        </div>
                        <div class="grid6">
                            <div class="grid3">
                                <label class="form-label">
                                    Zona:
                                </label>
                            </div>
                            <div class="grid6">
                                @Html.DropDownListFor(Function(m) m.Empleado.ZonaMantenimiento.IdZona,
                                                      New SelectList(Model.ListaZonaMantenimiento, "IdZona", "NombreZona"),
                                                      "-TODOS-",
                                                       New With {
                                                                .id = "ID_Zona",
                                                                .class = "textinput selector"
                                                           })
                                @*     <div class="grid6">
                                      <div id="DivListarCargosPerfiles">
                                          @Html.Partial(ParametrosPartialView.PVPerfil_comboCargo, Model )
                                        </div>
                                    </div>*@
                            </div>
                        </div>
                        <div class="clear">
                        </div>
                    </div>
                    <div class="formRow fluid" id="RowTipoRepVen">
                        <div class="grid6">
                            <div class="grid3" id="lblTipoRepVen">
                                <label class="form-label">
                                    Tipo Representante:
                                </label>
                            </div>
                            <div class="grid6">
                                <div id="divListaTipoRepresentanteVenta">
                                    @Html.Partial(ParametrosPartialView.TipoRepresentanteVentaPV, Model)
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
                                    Sucursal:
                                </label>
                            </div>
                            <div class="grid6">
                                @Html.DropDownListFor(Function(m) m.Sucursal.IdSucursal,
                 New SelectList(Model.ListaSucursal, "IdSucursal", "DescripcionSucursal"),
                 "-TODOS-",
                 New With {
                     .id = "ID_IdSucursal",
                     .class = "textinput selector",
                     .onkeypress = "EnterSubmit(event,'btnBuscar')"
                 })
                                @Html.ValidationMessageFor(Function(m) m.Sucursal.IdSucursal, "",
                                New With {
                                    .class = "reqizq"
                                })
                            </div>
                        </div>
                        <div class="grid6">
                            <div class="grid3">
                                <label class="form-label">
                                    Estado:
                                </label>
                            </div>
                            <div class="grid6">
                                @Html.DropDownListFor(Function(m) m.Empleado.Estado.IdEstado,
                                                       New SelectList(Model.ListaEstado, "IdEstado", "Descripcion"),
                                                       "-TODOS-",
                                                       New With {
                                                                 .id = "ID_IdEstado",
                                                                 .class = "selector"
                                                           })
                            </div>
                        </div>
                        <div class="clear">
                        </div>
                    </div>
                    <div class="formRow noBorderB">
                        <a href="@Url.Action("GestionarEmpleado", "Ventas")" style="cursor: pointer" class="buttonS bBlue formSubmit group_button">
                            Nuevo
                        </a>
                        <button type="button" name="ActionGrabar" id="btnBuscar" style="cursor: pointer"
                                class="buttonS bBlue formSubmit group_button" onclick="BuscarVendedor()">
                            Buscar
                        </button>
                        <div class="clear">
                        </div>
                        <div class="grid6">
                        </div>
                    </div>
                </div>
            </fieldset>
        </div>
        <div class="formRow noBorderB">
            <div class="clear">
            </div>
        </div>
        <div class="widget">
            <div class="whead">
                <h6>
                    Resultados de Búsqueda
                </h6>
                <div class="clear">
                </div>
            </div>
            <div id="contenedorgrilla-ListadoEmpleados">
                @Html.Partial("_BuscarEmpleado", Model)
            </div>
        </div>
    </div>
</div>
@Html.Hidden("ID_Url_ComboListaCargo", Url.Action("_ComboListaCargo"), "Ventas")
@Html.Hidden("ID_Url_ListarTipoRepresentanteVenta", Url.Action("ListarTipoRepresentanteVenta"), "Ventas")
@Html.Hidden("ID_UrlBuscaEmpleado", Url.Action("_BuscarEmpleado"), "Ventas")

<script type="text/javascript" language="javascript">
    $(function () {
        ListarCargosPorPerfil();
        ListarTipoRepresentanteVenta();
        BuscarVendedor();
    });
</script>