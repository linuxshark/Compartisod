@ModelType Sodimac.VentaEmpresa.Web.Mvc.MantenimientoViewModel
@Imports Sodimac.VentaEmpresa.Web.Mvc.ParametrosView
@Code
    ViewData("Title") = "Buscar Descuento por Sku"
End Code

<div class="breadLine">
    <div class="bc">
        <ul id="breadcrumbs" class="breadcrumbs">
            <li><a href="@Url.Action("Index", "Home")">Inicio</a></li>
            <li><a href="#">Mantenedor</a></li>
            <li class="current"><a href="@Url.Action("DescuentoSku", "Mantenimiento")" title="">@(ViewData("Title"))</a></li>
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
                            <button type="button" name="ActionNuevo" id="btnNuevo" style="cursor:pointer" class="buttonS bBlue formSubmit group_button" onclick="NuevoDescuentoSku();">Nuevo</button>
                            <button type="button" name="ActionBuscar" id="btnBuscar" style="cursor:pointer" class="buttonS bBlue formSubmit group_button " onclick="BuscarDsctoSku();">Buscar</button>
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
                @Html.Partial(ParametrosPartialView.ConsultarDsctoSku_PVGrilla, Model)
            </div>
        </fieldset>
    </div>
</div>

<div id="dialogGestionarDescuentoSku" style="display: none" class="j_modal" title="Agregar Descuento de Sku"></div>
<div id="dialogEliminarDescuentoSku" title="Mensaje de Confirmación">
    <p>¿Desea eliminar el Descuento del Sku?</p>
</div>
<div id="dialogCancelarRegistroDescuentoSku" title="Mensaje de Confirmación">
    <p>¿Desea cancelar el registro?</p>
</div>
<div id="dialogRegistrarDescuentoSku" title="Mensaje de Confirmación">
    <p>¿Desea guardar el registro?</p>
</div>

<script type="text/javascript" src="@Url.Content("~/Scripts/View/Mantenimiento.js")"></script>
<script type="text/javascript" language="javascript">
    $(function () {
        BuscarDsctoSku();
        InicioJPopUp("#dialogGestionarDescuentoSku", 400, 400, false, "Descuento Sku");
        InicioJPopUpConfirm("#dialogRegistrarDescuentoSku", 490, false, "Mensaje de Confirmación", GuardarDescuentoSku);
        InicioJPopUpConfirm("#dialogEliminarDescuentoSku", 490, false, "Mensaje de Confirmación", EliminarDescuentoSku);
        InicioJPopUpConfirm("#dialogCancelarRegistroDescuentoSku", 490, false, "Mensaje de Confirmación", CancelarRegistroDescuentoSku);
    });
</script>