@ModelType Sodimac.VentaEmpresa.Web.Mvc.MantenimientoViewModel
@Imports Sodimac.VentaEmpresa.Web.Mvc.ParametrosView
@Code
    ViewData("Title") = "Buscar Sku Bloqueados"
End Code

<div class="breadLine">
    <div class="bc">
        <ul id="breadcrumbs" class="breadcrumbs">
            <li><a href="@Url.Action("Index", "Home")">Inicio</a></li>
            <li><a href="#">Mantenedor</a></li>
            <li class="current"><a href="@Url.Action("SkuBloqueados", "Mantenimiento")" title="">@(ViewData("Title"))</a></li>
        </ul>
    </div>
</div>
<div class="contentTop">
    <span class="pageTitle">
        <span id="IdAgregarTitle" class="icon-screen"></span>@(ViewData("Title"))
    </span>
    <div class="clear"></div>
</div>
<div class="wrapper">
    <div class="form" id="frmDescuentoFamilia">
        <fieldset>
            <div class="widget fluid" id="divDefinicionHead">
                <div class="whead">
                    <h6>Criterios de Búsqueda</h6>
                    <div class="clear"> </div>
                </div>
                <div class="formRow fluid">
                    <div class="grid8">
                        <div class="grid3">
                            <label class="form-label" for="tipoPersona">
                                Sku:
                            </label>
                        </div>
                        <div class="grid9">
                            @Html.TextBoxFor(Function(m) m.Producto.Sku,
New With
{
.id = "Cod_Sku",
.name = "Cod_Sku",
.maxLength = "15",
.class = "textinput"
})
                        </div>
                    </div>
                    <div class="grid4">
                        <div class="formRow">
                            <button type="button" name="ActionNuevo" id="btnNuevo" style="cursor:pointer" class="buttonS bBlue formSubmit group_button" onclick="NuevoSkuBloqueado();">Nuevo</button>
                            <button type="button" name="ActionBuscar" id="btnBuscar" style="cursor:pointer" class="buttonS bBlue formSubmit group_button " onclick="BuscarSkuBloqueado();">Buscar</button>
                            <br class="clear" />
                            <div class="clear"></div>
                        </div>
                    </div>
                </div>
            </div>
        </fieldset>
    </div>
</div>
<div class="wrapper">
    <div class="form">
        <fieldset>
            <div class="widget fluid" id="divDefinicionBody">
                <div class="whead">
                    <h6>Resultados de Búsqueda</h6>
                    <div class="clear">
                    </div>
                </div>
                @Html.Partial(ParametrosPartialView.ConsultarSkuBloqueados_PVGrilla, Model)
            </div>
        </fieldset>
    </div>
</div>

<div id="dialogGestionarSkuBloqueado" style="display: none" class="j_modal" title="Agregar Sku Bloqueado"></div>
<div id="dialogEliminarSkuBloqueado" title="Mensaje de Confirmación">
    <p>¿Desea eliminar el Sku Bloqueado?</p>
</div>
<div id="dialogCancelarRegistroSkuBloqueado" title="Mensaje de Confirmación">
    <p>¿Desea cancelar el registro?</p>
</div>
<div id="dialogRegistrarSkuBloqueado" title="Mensaje de Confirmación">
    <p>¿Desea guardar el registro?</p>
</div>

<script type="text/javascript" src="@Url.Content("~/Scripts/View/Mantenimiento.js")"></script>
<script type="text/javascript" language="javascript">
    $(function () {
        BuscarSkuBloqueado();
        InicioJPopUp("#dialogGestionarSkuBloqueado", 400, 225, false, "Sku Bloqueado");
        InicioJPopUpConfirm("#dialogRegistrarSkuBloqueado", 490, false, "Mensaje de Confirmación", GuardarSkuBloqueado);
        InicioJPopUpConfirm("#dialogEliminarSkuBloqueado", 490, false, "Mensaje de Confirmación", EliminarSkuBloqueado);
        InicioJPopUpConfirm("#dialogCancelarRegistroSkuBloqueado", 490, false, "Mensaje de Confirmación", CancelarRegistroSkuBloqueado);
    });
</script>