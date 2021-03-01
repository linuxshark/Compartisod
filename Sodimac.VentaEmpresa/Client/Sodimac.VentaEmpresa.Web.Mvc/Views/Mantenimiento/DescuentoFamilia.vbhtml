@ModelType Sodimac.VentaEmpresa.Web.Mvc.MantenimientoViewModel
@Imports Sodimac.VentaEmpresa.Web.Mvc.ParametrosView
@Code
    ViewData("Title") = "Buscar Descuento por Familia"
End Code

<div class="breadLine">
    <div class="bc">
        <ul id="breadcrumbs" class="breadcrumbs">
            <li><a href="@Url.Action("Index", "Home")">Inicio</a></li>
            <li><a href="#">Mantenedor</a></li>
            <li class="current"><a href="@Url.Action("DescuentoFamilia", "Mantenimiento")" title="">@(ViewData("Title"))</a></li>
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
                                Familia:
                            </label>
                        </div>
                        <div class="grid9">
                            @Html.DropDownListFor(Function(m) m.Familia.CodigoFamilia,
New SelectList(Model.ListaFamilia, "CodigoFamilia", "NombreFamilia"),
"- TODOS -", New With {
.id = "ID_Familia",
.onkeypress = "EnterSubmit(event,'btnBuscar');",
.style = "width:500px;"
})
                        </div>
                    </div>
                    <div class="grid4">
                        <div class="formRow">                            
                            <button type="button" name="ActionNuevo" id="btnNuevo" style="cursor:pointer" class="buttonS bBlue formSubmit group_button" onclick="NuevoDescuentoFamilia();">Nuevo</button>
                            <button type="button" name="ActionBuscar" id="btnBuscar" style="cursor:pointer" class="buttonS bBlue formSubmit group_button " onclick="BuscarDsctoFamilia();">Buscar</button>
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
                @Html.Partial(ParametrosPartialView.ConsultarDsctoFamilia_PVGrilla, Model)
            </div>
        </fieldset>
    </div>
</div>

<div id="dialogGestionarDescuentoFamilia" style="display: none" class="j_modal" title="Agregar Descuento de Familia"></div>
<div id="dialogEliminarDescuentoFamilia" title="Mensaje de Confirmación">
    <p>¿Desea eliminar el Descuento de la Familia?</p>
</div>
<div id="dialogCancelarRegistroDescuentoFamilia" title="Mensaje de Confirmación">
    <p>¿Desea cancelar el registro?</p>
</div>
<div id="dialogRegistrarDescuentoFamilia" title="Mensaje de Confirmación">
    <p>¿Desea guardar el registro?</p>
</div>

<script type="text/javascript" src="@Url.Content("~/Scripts/View/Mantenimiento.js")"></script>
<script type="text/javascript" language="javascript">
    $(function () {
        BuscarDsctoFamilia();
        InicioJPopUp("#dialogGestionarDescuentoFamilia", 400, 300, false, "Descuento Familia");
        InicioJPopUpConfirm("#dialogRegistrarDescuentoFamilia", 490, false, "Mensaje de Confirmación", GuardarDescuentoFamilia);        
        InicioJPopUpConfirm("#dialogEliminarDescuentoFamilia", 490, false, "Mensaje de Confirmación", EliminarDescuentoFamilia);
        InicioJPopUpConfirm("#dialogCancelarRegistroDescuentoFamilia", 490, false, "Mensaje de Confirmación", CancelarRegistroDescuentoFamilia);
    });
</script>