@ModelType Sodimac.VentaEmpresa.Web.Mvc.MantenimientoViewModel
@Imports Sodimac.VentaEmpresa.Web.Mvc.ParametrosView
@Code
    ViewData("Title") = "Buscar Plan de Ventas por Tipo Representante"
End Code

<div class="breadLine">
    <div class="bc">
        <ul id="breadcrumbs" class="breadcrumbs">
            <li><a href="#">Inicio</a></li>
            <li><a href="#">Mantenedor</a></li>
            <li class="current"><a href="#" title="">Buscar Plan de Ventas por Tipo Representante</a></li>
        </ul>
    </div>
</div>

<div class="contentTop">
    <span class="pageTitle">
        <span id="IdAgregarTitle" class="icon-screen"></span>
        Buscar Plan de Ventas por Tipo Representante
    </span>
    <div class="clear">
    </div>
</div>

<div class="wrapper">
    <div class="form" id="frmConsultarPlanVenta">
        <fieldset>
            <div class="widget fluid" id="divDefinicion">
                <div class="whead">
                    <h6>Criterios de Búsqueda</h6>
                    <div class="clear"> </div>
                </div>

                <div class="formRow fluid">
                    <div class="grid6">
                        <div class="grid3">
                            <label class="form-label">Tipo Representante: </label>
                        </div>
                        <div class="grid6">
                            @Html.DropDownListFor(Function(m) m.PlanTipoRepresentanteVenta.TipoRepresentanteVenta.IdTipoRepVen,
                                       New SelectList(Model.PlanTipoRepresentanteVenta.ListaTipoRepresentanteVenta, "IdTipoRepVen", "NombreTipoRepVen"),
                                       "-TODOS- ",
                                       New With {
                                       .id = "ID_TipoRepVen",
                                       .class = "textinput selector"
                                       })
                        </div>
                        <div class="clear"></div>
                    </div>

                    <div class="grid6">
                        <div class="grid3">
                            <label class="form-label">Mes: </label>
                        </div>
                        <div class="grid6">
                            @Html.DropDownListFor(Function(m) m.PlanTipoRepresentanteVenta.MesPlan.IdMes,
                                       New SelectList(Model.PlanTipoRepresentanteVenta.ListaMesPlan, "IdMes", "OrdenMes"),
                                       "-TODOS- ",
                                       New With {
                                       .id = "ID_MesPlan",
                                       .class = "textinput selector"
                                       })
                        </div>
                        <div class="clear"></div>
                    </div>
                </div>
                <div class="formRow">
                    <button type="button" name="ActionNuevo" id="btnNuevo" style="cursor:pointer" class="buttonS bBlue formSubmit group_button" onclick="dialogGestionarPlanTipoRepVen();">Nuevo</button>
                    <button type="button" name="ActionBuscar" id="btnBuscar" style="cursor:pointer" class="buttonS bBlue formSubmit group_button " onclick="BuscarPlanTipoRepVen();">Buscar</button>
                    <br class="clear" />
                    <div class="clear"></div>
                </div>
            </div>
        </fieldset>
    </div>
</div>

<div class="wrapper">
    <div class="form">
        <fieldset>
            <div class="widget fluid" id="divDefinicion4">
                <div class="whead">
                    <h6>Resultados de Búsqueda</h6>
                    <div class="clear">
                    </div>
                </div>
                <div id="contenedor-grid-Zona">
                    @Html.Partial(ParametrosPartialView.ConsultarPlanTipoRepresentanteVenta_PVGrilla, Model)
                </div>
            </div>
        </fieldset>
    </div>
</div>

<div id="dialogGestionarPlanTipoRepVen" style="display: none" class="j_modal" title="Agregar Plan venta">
    @* @Html.Partial(ParametrosPartialView.GestionarZona, Model)*@
</div>

<div id="dialogRegistrarPlanTipoRepVen" title="Mensaje de Confirmación">
    <p>¿Desea guardar el registro?</p>
</div>

@*<div id="dialogActualizarPlanTipoRepVen" title="Mensaje de Confirmación">
    <p>¿Desea actualizar el registro?</p>
</div>*@

<div id="dialogEliminarPlanTipoRepVen" title="Mensaje de Confirmación">
    <p>¿Desea eliminar el registro?</p>
</div>

<div id="dialogCancelarRegistroPlanTipoRepVen" title="Mensaje de Confirmación">
    <p>¿Desea cancelar el registro?</p>
</div>

<script type="text/javascript" src="@Url.Content("~/Scripts/View/Mantenimiento.js")"></script>
<script type="text/javascript" language="javascript">
    $(function () {
        BuscarPlanTipoRepVen();
        InicioJPopUp("#dialogGestionarPlanTipoRepVen", 480, 400, false, "Gestionar Plan Venta");
        InicioJPopUpConfirm("#dialogRegistrarPlanTipoRepVen", 400, false, "Mensaje de Confirmación", GuardarPlanTipoRepVen);
        //InicioJPopUpConfirm("#dialogActualizarPlanTipoRepVen", 400, false, "Mensaje de Confirmación", GuardarPlanTipoRepVen);
        InicioJPopUpConfirm("#dialogEliminarPlanTipoRepVen", 400, false, "Mensaje de Confirmación", EliminarPlanTipoRepVen);
        InicioJPopUpConfirm("#dialogCancelarRegistroPlanTipoRepVen", 400, false, "Mensaje de Confirmación", CancelarRegistroPlanTipoRepVen);
    });
</script>
