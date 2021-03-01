@ModelType Sodimac.VentaEmpresa.Web.Mvc.MantenimientoViewModel
@Imports Sodimac.VentaEmpresa.Web.Mvc.ParametrosView
@Code
    ViewData("Title") = "BuscarCarteraClientes"
End Code
<div class="breadLine">
    <div class="bc">
        <ul id="breadcrumbs" class="breadcrumbs">
            <li><a href="#">Inicio</a></li>
            <li><a href="#">Mantenedor</a></li>
            <li class="current"><a href="#" title="">Buscar Cartera Clientes</a></li>
        </ul>
    </div>
</div>
<div class="contentTop">
    <span class="pageTitle">
        <span id="IdAgregarTitle" class="icon-screen"></span>Buscar
        Cliente
    </span>
    <div class="clear">
    </div>
</div>

<div class="wrapper">
    <div class="form" id="frmConsultarCarteraCliente">
        <fieldset>
            <div class="widget fluid" id="divDefinicion">
                <div class="whead">
                    <h6>Criterios de Búsqueda</h6>
                    <div class="clear"> </div>
                </div>
                <div class="formRow fluid">
                    <div class="grid4">
                        <div class="grid4"><label>Razón Social/Ruc</label></div>
                        <div class="grid8 noSearch ">
                            @Html.TextBoxFor(Function(m) m.ClienteCartera.RUC,
New With
{
.style = "text-transform:uppercase;",
.id = "RUC_AutoComplete",
.name = "RUC_AutoComplete",
.onkeypress = "return val_AZ(event),EnterSubmit(event,'btnBuscar');",
.class = "textinput"
})
                            @*<small class="note" style="margin-left:0px">Se debe ingresar como mínimo tres caracteres</small>*@
                            <br class="clear" />
                        </div>
                        <div class="clear"></div>
                    </div>

                    <div class="grid3">
                        <div class="grid3">
                            <label class="form-label">
                                Sucursal
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

                    <div class="grid2" style="padding-left: 20px;">
                        <div class="grid2"><label>Año</label></div>
                        <div class="grid9 noSearch" style="padding-left: 10px;">
                            @Html.TextBoxFor(Function(m) m.ClienteCartera.Anio,
New With
{
.style = "text-transform:uppercase; width: 60%;",
.id = "Anio_AutoComplete",
.name = "Anio_AutoComplete",
.onkeypress = "return val_AZ(event),EnterSubmit(event,'btnBuscar');",
.maxLength = "4",
.class = "textinput"
})
                            @*<small class="note" style="margin-left:0px">Se debe ingresar como mínimo tres caracteres</small>*@
                            <br class="clear" />
                        </div>
                        <div class="clear"></div>
                    </div>

                    <div class="grid3">
                        <div class="grid2"><label class="form-label">Mes</label></div>
                        <div class="grid6">
                            @Html.DropDownListFor(Function(m) m.Mes.IdMes,
New SelectList(Model.ListaMes, "IdMes", "Mes"),
"-TODOS-",
New With {
.id = "ID_Mes",
.class = "textinput selector",
.onkeypress = "EnterSubmit(event,'btnBuscar')"
})
                            @Html.ValidationMessageFor(Function(m) m.Mes.IdMes, "",
                 New With {
                     .class = "reqizq"
                 })
                        </div>

                    </div>
                    <br />
                    <br />
                    <div class="row">
                        <div class="formRow">
                            <button type="button" name="ActionLimpiar" id="btnLimpiar" style="cursor: pointer"
                                    class="buttonS bBlue formSubmit group_button " onclick="Limpiar();">
                                Limpiar
                            </button>
                            <button type="button" name="ActionExportar" id="btnExportar" style="cursor: pointer"
                                    class="buttonS bBlue formSubmit group_button ">
                                Exportar Excel
                            </button>
                            <button type="button" name="ActionBuscar" id="btnBuscar" style="cursor:pointer" class="buttonS bBlue formSubmit group_button " onclick="BuscarCarteraClientes();">Buscar</button>
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
            <div class="widget fluid" id="divDefinicion4">
                <div class="whead">
                    <h6>Resultados de Búsqueda</h6>
                    <div class="clear">
                    </div>
                </div>
                <div id="contenedor-grid-Perfil">
                    @Html.Partial(ParametrosPartialView.ConsultarCarteraCliente_PVGrilla, Model)
                </div>
            </div>
        </fieldset>
    </div>
</div>

<div id="dialogGestionarPerfil" style="display: none" class="j_modal" title="Agregar Perfil">

</div>
@Html.Hidden("urlGenerarReporteCarteraClientes", Url.Action("GenerarReporteCarteraClientes", "Mantenimiento"))
<script type="text/javascript" src="@Url.Content("~/Scripts/View/Mantenimiento.js")"></script>
<script type="text/javascript" language="javascript">
    $(function () {
        BuscarCarteraClientes();
    });
</script>