@ModelType Sodimac.VentaEmpresa.Web.Mvc.VentasViewModel
@Imports Sodimac.VentaEmpresa.Web.Mvc.ParametrosView
@Imports Sodimac.VentaEmpresa.Common
@Html.Hidden("UrlZonas", Url.Action("ListarZona_Cargo", "Ventas"))
@*@Html.Hidden("UrlSucursales", Url.Action("UCSucursal__Combo", "Ventas")) *@
@Html.Hidden("UrlSucursales", Url.Action("PVSucursal_Combo", "Ventas"))
@Html.Hidden("UrlSupervisor", Url.Action("PVSuperior_Cargo", "Ventas"))
@Html.Hidden("UrlComisionDetalle", Url.Action("PVEscalaTiempoServicio_Combo", "Ventas"))
@Html.Hidden("UrlCargos", Url.Action("PVCargo_Combo", "Ventas"))
@Using (Html.BeginForm("RegistraSucursalEmpleado_", "Ventas", FormMethod.Get, New With {.id = "frmRegistrarSucursalEmpleado"}))
    @Html.AntiForgeryToken

    '<form action="@Url.Action("RegistraSucursalEmpleado", "Ventas")" method="post" id="frmRegistrarSucursalEmpleado">

    @<div class="wrapper">
        <div class="form">
            <fieldset>
                <div class="widget fluid">
                    <div class="formRow">
                        <div class="grid11">
                            <div class="grid2">
                                <label class="form-label">
                                    Nombre Completo:
                                </label>
                            </div>
                            <div class="grid9">
                                @Html.TextBoxFor(Function(x) x.Empleado.NombresApellidos, New With {.readOnly = True})
                            </div>
                        </div>
                        <div class="grid6">
                            <div class="grid4">
                                <label class="form-label">
                                </label>
                            </div>
                            <div class="grid7">
                            </div>
                        </div>
                        <div class="clear">
                        </div>
                    </div>
                    <div class="formRow fluid">
                        <div class="grid7">
                            <div class="grid3">
                                <label class="form-label">
                                    Perfil :
                                </label>
                            </div>
                            <div class="grid4">
                                @Html.DropDownListFor(Function(m) m.Empleado.Perfil.IdPerfil,
                    New SelectList(Model.ListaPerfil, "IdPerfil", "NombrePerfil"),
                    "-SELECCIONE- ",
                            New With {
                                     .id = "ID_Perfil",
                                     .onchange = "ObtenerNombreCargoInferior();cargarComisionServiciosPerfilzona();validaTipoPerfilZona();ObtenerCargoSuperiorVendedor();ListarTipoRepresentanteVenta();",
                                     .class = "selector"
                                })
                                @Html.ValidationMessageFor(Function(m) m.Empleado.Perfil.IdPerfil, "", New With {.class = "reqizq"})
                            </div>
                        </div>
                        <div class="grid2">
                            <div class="grid5">
                                <label class="form-label">
                                    Zona :
                                </label>
                            </div>
                            <div class="grid5">
                                <div class="grid5">
                                    @Html.DropDownListFor(Function(x) x.Empleado.Zona.IdZona,
                         New SelectList(Model.ListaZona, "IdZona", "Descripcion"),
                         "-SELECCIONE-",
                         New With {
                                   .id = "ID_zona",
                                   .onchange = "cargarSucursales();ObtenerNombreCargoInferior();cargarComisionServiciosPerfilzona();validaTipoPerfilZona();ObtenerCargoSuperiorVendedor();",
                                   .Class = "selector"
                               })
                                    @Html.ValidationMessageFor(Function(m) m.Empleado.Zona.IdZona, "", New With {.class = "reqizq"})
                                </div>
                            </div>
                        </div>
                        <div class="clear">
                        </div>
                    </div>
                    <div class="formRow fluid">
                        <div class="grid7">
                            <div class="grid3">
                                <label class="form-label">
                                    Tipo Representante :
                                </label>
                            </div>
                                <div  class="grid4" id="divListaTipoRepresentanteVenta">
                                    @Html.Partial(ParametrosPartialView.TipoRepresentanteVentaPV, Model)
                                </div>
                        </div>

                        <div class="clear">
                        </div>
                    </div>
                    <div class="formRow">
                        <div class="grid11">
                            <div class="grid2">
                                <label class="form-label">
                                    Cargo:
                                </label>
                            </div>
                            <div class="grid4">
                                @Html.TextBoxFor(Function(m) m.Empleado.Cargo.NombreCargo,
                 New With {.id = "ID_NombreCargo",
                           .readonly = True})
                            </div>
                        </div>
                        <div class="clear">
                        </div>
                    </div>
                    <div class="formRow">
                        <div class="grid11">
                            <div class="grid2">
                                <label class="form-label">
                                    Reporta A:
                                </label>
                            </div>
                            <div class="grid9">
                                @Html.TextBoxFor(Function(x) x.Empleado.Reportar, New With {.id = "Id_Reporta",
                                                                                         .readOnly = True})
                                <div style="display: none;" id="idReq">
                                    <span class="reqizq field-validation-error" id="IdError">Requerido</span>
                                </div>
                            </div>
                        </div>
                        <div class="clear">
                        </div>
                    </div>
                    <div class="formRow fluid">
                        <div class="grid11">
                            <div class="grid2">
                                <label class="form-label">
                                    Sucursales:
                                </label>
                            </div>
                            <div class="grid3">
                                <div id="divListaSucursalporZona">
                                    @Html.Partial(ParametrosPartialView.PVSucursal_Zona, Model)
                                </div>
                            </div>
                            <div class="grid6" id="divEscalaInicialCargo" style="display: none">
                                @Html.Partial(ParametrosPartialView.PVEscalaTiempoServicio, Model)
                            </div>
                            <div class="clear">
                            </div>
                        </div>
                    </div>
                    <div class="formRow fluid">
                        <div class="grid5">
                            <div class="grid4">
                                <label class="form-label">
                                    Fecha Ingreso:
                                </label>
                            </div>
                            <div class="grid6" style="margin-left: 8px">
                                @Html.TextBoxFor(Function(x) x.Empleado.SucursalEmpleado.FechaRegistro,
                                                New With {
                                                    .id = "ID_FechaIngreso",
                                                    .class = "datepicker maskDate",
                                                    .Value = Format("{0:d}", " "),
                                                    .maxlength = "10"
                                                })
                                <div id="ID_MsgFechaIngresoSucursal">
                                </div>
                                @Html.ValidationMessageFor(Function(x) x.Empleado.SucursalEmpleado.FechaRegistro, "", New With {.class = "reqizq"})
                                @* @Html.TextBoxFor(Function(m) (m.Empleado.SucursalEmpleado.FechaRegistro),
                                    New With {
                                        .id = "ID_FechaIngreso",
                                        .autocomplete = "off",
                                        .class = "datepicker maskDate",
                                        .maxlength = "10",
                                        .Value = String.Format("{0:d}", "")
                                    })
                                    <div id="ID_MsgFechaIngresoSucursal">
                                    </div>
                                    @Html.ValidationMessageFor(Function(x) x.Empleado.SucursalEmpleado.FechaRegistro, "", New With {.class = "reqizq"})*@
                            </div>
                        </div>
                    </div>
                    <div class="formRow fluid">
                        <div class="clear">
                        </div>
                    </div>
                    <div class="formRow fluid">
                        <div class="clear">
                        </div>
                    </div>
                    <div class="formRow" style="margin-right: 10px">
                        <button type="button" name="ActionCancelar" id="btnCancelar" style="cursor: pointer"
                                class="buttonS bBlue formSubmit group_button" onclick="dialogCancelarRegistroSucursalEmpleado();">
                            Cancelar
                        </button>
                        <button type="button" name="ActionAgregar" id="btnAgregarA" style="cursor: pointer"
                                class="buttonS bBlue formSubmit group_button " onclick="RegistrarSucursalEmpleado();">
                            Guardar
                        </button>
                        <br class="clear" />
                        <div class="clear">
                        </div>
                    </div>
                    <div class="formRow fluid">
                        <div class="clear">
                        </div>
                    </div>
                </div>
            </fieldset>
        </div>
    </div>
    @Html.HiddenFor(Function(x) x.Empleado.IdEmpleado)
    @Html.HiddenFor(Function(x) x.Empleado.IdEmpleadoPerfilActual, New With {.id = "HD_IdPerfilActual"})
    @Html.Hidden("ID_Url_ListarTipoRepresentanteVenta", Url.Action("ListarTipoRepresentanteVenta"), "Ventas")
End Using
@*</form>*@ @*<script type="text/javascript" src="@Url.Content("~/Scripts/View/Vendedor.js")"></script>*@
<script type="text/javascript" language="javascript">
    jQuery.validator.methods["date"] = function (value, element) { return true; }
    $("#ID_FechaIngreso").datepicker({
        showOtherMonths: true,
        autoSize: true,
        changeMonth: true,
        changeYear: true,
        appendText: '(DD/MM/AAAA)',
        dateFormat: 'dd/mm/yy'
    });
    $(".datepicker").mask("99/99/9999");
</script>
