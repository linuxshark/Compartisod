@ModelType Sodimac.VentaEmpresa.Web.Mvc.MantenimientoViewModel
@Imports Sodimac.VentaEmpresa.Web.Mvc.ParametrosView
@Code
    ViewData("Title") = "Buscar Cotización"
End Code
<style>
    .selector {
        width: 250px !important;
    }
</style>
<div class="breadLine">
    <div class="bc">
        <ul id="breadcrumbs" class="breadcrumbs">
            <li><a href="@Url.Action("Index", "Home")">Inicio</a></li>
            <li><a href="#">Mantenedor</a></li>
            <li class="current"><a href="@Url.Action("Cotizacion", "Mantenimiento")" title="">@(ViewData("Title"))</a></li>
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
    <div class="form" id="frmCotizacion">
        <fieldset>
            <div class="widget fluid" id="divDefinicionHead">
                <div class="whead">
                    <h6>Criterios de Búsqueda</h6>
                    <div class="clear"> </div>
                </div>
                <div class="formRow fluid">
                    <div class="grid2">
                        <label class="form-label" for="marca">
                            Marca:
                        </label>
                    </div>
                    <div class="grid4">
                        @Html.DropDownListFor(Function(m) m.Marca.IdMarca,
New SelectList(Model.ListaMarca, "IdMarca", "NomMarca"),
"- TODOS -", New With {
.id = "Id_Marca",
.onkeypress = "EnterSubmit(event,'btnBuscar');"
})
                    </div>
                    <div class="grid2">
                        <label class="form-label" for="sucursal">
                            Sucursal:
                        </label>
                    </div>
                    <div id="container-sucursal" class="grid4">
                        @Html.DropDownListFor(Function(m) m.Sucursal.IdSucursal,
New SelectList(Model.ListaSucursal, "IdSucursal", "DescripcionSucursal"),
"- TODOS -", New With {
.id = "Id_Sucursal",
.onkeypress = "EnterSubmit(event,'btnBuscar');"
})
                    </div>
                </div>
                <div class="formRow fluid">
                    <div class="grid2">
                        <label class="form-label" for="marca">
                            Fecha Inicio:
                        </label>
                    </div>
                    <div class="grid4">
                        @Html.TextBoxFor(Function(m) m.FechaIni,
New With
{
.id = "Id_FechaIni",
.class = "textinput datepickerAkiraMax",
.maxlength = "10",
.Value = Format("{0:d}", " "),
.style = "width: 260px;margin-right: 10px;"
})
                    </div>
                    <div class="grid2">
                        <label class="form-label" for="sucursal">
                            Fecha Fin:
                        </label>
                    </div>
                    <div class="grid4">
                        @Html.TextBoxFor(Function(m) m.FechaFin,
New With
{
.id = "Id_FechaFin",
.class = "textinput datepickerAkiraMax",
.maxlength = "10",
.Value = Format("{0:d}", " "),
.style = "width: 260px;margin-right: 10px;"
})
                    </div>
                </div>
                <div class="formRow fluid">
                    <div class="grid2">
                        <label class="form-label" for="marca">
                            RUC / Razón Social:
                        </label>
                    </div>
                    <div class="grid10">
                        @Html.TextBoxFor(Function(m) m.RucRazSoc,
New With
{
.maxLength = "100",
.class = "textinput",
.style = "width: 810px;"
})
                    </div>
                </div>
                <div class="formRow fluid">
                    <div class="grid2">
                        <label class="form-label" for="marca">
                            SubGerente:
                        </label>
                    </div>
                    <div class="grid4">
                        @Html.DropDownListFor(Function(m) m.SubGerente.IdEmpleado,
New SelectList(Model.ListaSubGerente, "IdEmpleado", "NombresApellidos"),
"- TODOS -", New With {
.id = "Id_SubGerente",
.onkeypress = "EnterSubmit(event,'btnBuscar');"
})
                    </div>
                    <div class="grid2">
                        <label class="form-label" for="sucursal">
                            Jefe Regional:
                        </label>
                    </div>
                    <div class="grid4">
                        @Html.DropDownListFor(Function(m) m.JefeRegional.IdEmpleado,
New SelectList(Model.ListaJefeRegional, "IdEmpleado", "NombresApellidos"),
"- TODOS -", New With {
.id = "Id_JefeRegional",
.onkeypress = "EnterSubmit(event,'btnBuscar');"
})
                    </div>
                </div>
                <div class="formRow fluid">
                    <div class="grid2">
                        <label class="form-label" for="marca">
                            Cod. Ofisis / Vendedor:
                        </label>
                    </div>
                    <div class="grid10">
                        @Html.TextBoxFor(Function(m) m.CodOfisisEmpleado,
New With
{
.maxLength = "100",
.class = "textinput",
.style = "width: 810px;"
})
                    </div>
                </div>
                <div class="formRow fluid">
                    <div class="grid2">
                        <label class="form-label" for="marca">
                            Familia:
                        </label>
                    </div>
                    <div class="grid4">
                        @Html.DropDownListFor(Function(m) m.Familia.CodigoFamilia,
New SelectList(Model.ListaFamilia, "CodigoFamilia", "NombreFamilia"),
"- TODOS -", New With {
.id = "Id_Familia",
.onkeypress = "EnterSubmit(event,'btnBuscar');"
})
                    </div>
                    <div class="grid2">
                        <label class="form-label" for="marca">
                            Sku / Producto:
                        </label>
                    </div>
                    <div class="grid4">
                        @Html.TextBoxFor(Function(m) m.SkuProducto,
New With
{
.maxLength = "100",
.class = "textinput",
.style = "width: 260px;"
})
                    </div>
                </div>
                <div class="formRow fluid">
                    <div class="grid2">
                        <label class="form-label" for="marca">
                            N° Proforma:
                        </label>
                    </div>
                    <div class="grid4">
                        @Html.TextBoxFor(Function(m) m.NroCotizacion,
New With
{
.maxLength = "100",
.class = "textinput",
.style = "width: 260px;"
})
                    </div>
                    <div class="grid2">
                        <label class="form-label" for="sucursal">
                            Es Preporforma:
                        </label>
                    </div>
                    <div class="grid4">
                        @Html.DropDownListFor(Function(m) m.TipoProforma,
New SelectList(Model.ListaTipoProforma, "IdTipo", "Descripcion"),
"- AMBOS -", New With {
.id = "Id_TipoProforma",
.onkeypress = "EnterSubmit(event,'btnBuscar');"
})
                    </div>
                </div>
                <div class="formRow fluid">
                    <div class="grid12">
                        <div class="formRow">
                            <button type="button" name="ActionExportar" id="btnExportar" style="cursor:pointer" class="buttonS bBlue formSubmit group_button " onclick="ExportarCotizacion();">Exportar Excel</button>
                            <button type="button" name="ActionBuscar" id="btnBuscar" style="cursor:pointer" class="buttonS bBlue formSubmit group_button " onclick="BuscarCotizacion();">Buscar</button>
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
                @Html.Partial(ParametrosPartialView.ConsultarCotizacion_PVGrilla, Model)
            </div>
        </fieldset>
    </div>
</div>

<div id="dialogGestionarCotizacion" style="display: none" class="j_modal" title="Agregar Nro. Cotizacion Uxpos"></div>
<div id="dialogDetalleCotizacion" style="display: none" class="j_modal" title="Detalle de Cotización"></div>
<div id="dialogCancelarRegistroCotizacion" title="Mensaje de Confirmación">
    <p>¿Desea cancelar el registro?</p>
</div>
<div id="dialogRegistrarCotizacion" title="Mensaje de Confirmación">
    <p>¿Desea guardar el registro?</p>
</div>

<script type="text/javascript" src="@Url.Content("~/Scripts/View/Mantenimiento.js")"></script>
<script type="text/javascript" language="javascript">
    $(function () {
        $(".datepickerAkiraMax").datepicker({
            showOtherMonths: true,
            autoSize: true,
            changeMonth: true,
            changeYear: true,
            appendText: '(DD/MM/AAAA)',
            dateFormat: 'dd/mm/yy',
            maxDate: "0D"
        });
        $("#Id_Marca").change(getSucursal);
        $("#Id_Marca").trigger('change');
        BuscarCotizacion();
        InicioJPopUp("#dialogGestionarCotizacion", 400, 400, false, "Cotización");
        InicioJPopUp("#dialogDetalleCotizacion", 1000, 400, false, "Detalle Cotización");
        InicioJPopUpConfirm("#dialogRegistrarCotizacion", 490, false, "Mensaje de Confirmación", GuardarCotizacion);
        InicioJPopUpConfirm("#dialogCancelarRegistroCotizacion", 490, false, "Mensaje de Confirmación", CancelarRegistroCotizacion);
    });
</script>