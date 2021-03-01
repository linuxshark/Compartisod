@ModelType Sodimac.VentaEmpresa.Web.Mvc.ReporteViewModel
@Imports Sodimac.VentaEmpresa.Web.Mvc.ParametrosView
@Code
    ViewData("Title") = "Reporte de Clientes"
End Code
<script type="text/javascript" src="/Scripts/View/Reportes.js"></script>
<div class="breadLine">
    <div class="bc">
        <ul id="breadcrumbs" class="breadcrumbs">
            <li><a href="#">Inicio</a> </li>
            <li><a href="#">Reportes</a> </li>
            <li class="current"><a title="" href="#">Reporte de Clientes</a> </li>
        </ul>
    </div>
</div> 
<div class="contentTop">
    <span class="pageTitle"><span id="IdAgregarTitle" class="icon-screen"></span>Reporte
        de Clientes</span>
    <div class="clear">
    </div>
</div>
<div class="wrapper">
    <div class="main">
        <fieldset>
            <div class="form">
                <div class="widget fluid">
                    <div class="whead">
                        <h6>
                            Filtros de Búsqueda</h6>
                        <div class="clear">
                        </div>
                    </div>
                    <div class="formRow fluid">
                        <div class="grid4">
                            <div class="grid4">
                                <label class="form-label" for="tipoPersona">
                                    Zona:</label>
                            </div>
                            <div id="DivZonaM" class="grid8">
                                @Html.DropDownListFor(Function(m) m.ZonaMantenimiento.IdZona,
                               New SelectList(Model.ListaZonaMantenimiento, "IdZona", "NombreZona"),
                               New With {
                                         .id = "ID_ZonaCliente",
                                         .class = "textinput selector",
                                         .multiple = "multiple"
                                })  
                                
                                @Html.HiddenFor(Function(m) m.ZonaMantenimiento.IdZona, New With {.id = "IdZona2Cliente"})      
                            </div>
                        </div>
                        <div class="grid4">
                            <div class="grid3">
                                <label class="form-label" for="tipoPersona">
                                    Sucursal:</label>
                            </div>
                            <div id="DivSucursalPartial" class="grid9">
                              
                                @Html.DropDownListFor(Function(m) m.Sucursal.IdSucursal,
                                New SelectList(Model.ListaSucursal, "IdSucursal", "DescripcionSucursal"),
                                New With {
                                    .id = "IdSucursalCliente",
                                    .class = "textinput selector",
                                    .multiple = "multiple"
                                })
                                 @Html.HiddenFor(Function(m) m.Sucursal.IdSucursal, New With {.id = "Idsucursal2Cliente"})
                            </div>
                        </div>
                        <div class="grid4">
                            <div class="grid3">
                                <label class="form-label" for="tipoPersona">
                                    Sector:</label>
                            </div>
                            <div class="grid9">
                                @Html.DropDownListFor(Function(m) m.ClienteSector.IdClienteSector,
                                New SelectList(Model.ListaClienteSector, "IdClienteSector", "DescripcionCorta"),
                                "- TODOS -",
                                New With
                                {
                                    .class = "selector",
                                    .id = "IdClienteSector"
                                })
                            </div>
                        </div>
                    </div>
                    <div class="formRow fluid">
                        <div class="grid4">
                            <div class="grid4">
                                <label class="form-label" for="tipoPersona">
                                    Categoría:</label>
                            </div>
                            <div class="grid8">
                                @Html.DropDownListFor(Function(m) m.ClienteCategoria.IdClienteCategoria,
                                New SelectList(Model.ListaClienteCategoria, "IdClienteCategoria", "Descripcion"),
                                "- TODOS -",
                                New With
                                {
                                    .class = "selector",
                                    .id = "IdCategoria"
                                })
                            </div>
                        </div>
                        <div class="grid4">
                            <div class="grid3">
                                <label class="form-label" for="tipoPersona">
                                    Forma Pago:</label>
                            </div>
                            <div class="grid3">
                                @Html.DropDownListFor(Function(m) m.ClienteModoPagoCombo.IdModoPago,
                                New SelectList(Model.ListaClienteModoPagoCombo, "IdModoPago", "Descripcion"),
                                "- TODOS -",
                                New With
                                {
                                    .class = "selector",
                                    .id = "IdFormaPago"
                                })
                            </div>
                        </div>
                        <div class="grid4">
                            <div class="grid3">
                                <label class="form-label" for="tipoPersona">
                                    Tipo Cliente:</label>
                            </div>
                            <div class="grid3">
                                @Html.DropDownListFor(Function(m) m.ClienteTipo.IdClienteTipo,
                                New SelectList(Model.ListaClienteTipo, "IdClienteTipo", "Descripcion"),
                                "- TODOS -",
                                New With
                                {
                                    .class = "selector",
                                    .id = "IdTipoCliente"
                                })
                            </div>
                        </div>
                    </div>
                    <div class="formRow fluid">
                        <div class="grid4">
                            <div class="grid4">
                                <label class="form-label" for="EstadoLinea">
                                    Estado de Línea de Crédito:</label>
                            </div>
                            <div class="grid3">
                                @Html.Partial(ParametrosPartialView.PVClienteEstadoLinea, Model)
                            </div>
                        </div>
                        <div class="grid4">
                            <div class="grid3">
                                <label class="form-label" for="EstadoLinea">
                                    Vendedor Principal:</label>
                            </div>
                            <div class="grid3">
                                @Html.Partial(ParametrosPartialView.PVVendedorPrincipal, Model)
                            </div>
                        </div>
                        <div class="formRow">
                            <div class="grid12">
                                <button type="button" name="ActionGrabar" id="btnReporte" style="cursor: pointer"
                                    class="buttonS bBlue formSubmit group_button " onclick="VerReporteClientes()">
                                    Ver Reporte</button>
                                @Html.Hidden("ID_URL", Url.Action("VerReporteClientes", "Reportes"))
                            </div>
                            <div class="clear">
                            </div>
                        </div>
                        <div class="formRow fluid noBorderB">
                            <div class="clear">
                            </div>
                        </div>
                    </div>
                </div>
                <div id="ID_Partial_ReporteClientes" style="display: none" class="j_modal" name="Reporte Detalle de Clientes">
                </div>
            </div>
        </fieldset>
    </div>
</div>
 @Html.Hidden("UrlCargaSucursalZona", Url.Action("_ComboMultiSucursalCliente", "Reportes"))


<script type="text/javascript" language="javascript">
    var navegador = navigator.appName

//    $(function () {

//        $("#ID_ZonaCliente").multiselect(
//            {
//                selectedList: 10,
//                noneSelectedText: '-SELECCIONE-',
//                show: ["bounce", 50],
//                minWidth: 220
//            }
//         ).multiselectfilter();

//        $("#ID_ZonaCliente").multiselect("uncheckAll");

//        $("#IdSucursalCliente").multiselect(
//            {
//                selectedList: 10,
//                noneSelectedText: '-SELECCIONE-',
//                show: ["bounce", 50],
//                minWidth: 220
//            }
//         ).multiselectfilter();
//        $(".ui-multiselect").attr("style", "width: 220px")
//        if (navegador == "Microsoft Internet Explorer") {
//            $(".ui-multiselect").attr("style", "width: 250px")
//        }
//    });

</script> 
