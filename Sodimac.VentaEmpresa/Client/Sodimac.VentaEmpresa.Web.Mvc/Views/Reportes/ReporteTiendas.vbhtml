@ModelType Sodimac.VentaEmpresa.Web.Mvc.ReporteViewModel
@Code
    ViewData("Title") = "Reporte de Tiendas"
End Code
<script type="text/javascript" src="/Scripts/View/Reportes.js"></script>
<div class="breadLine">
    <div class="bc">
        <ul id="breadcrumbs" class="breadcrumbs">
            <li><a href="#">Inicio</a> </li>
            <li><a href="#">Reportes</a> </li>
            <li class="current"><a title="" href="#">Reporte de Tiendas</a> </li>
        </ul>
    </div>
</div>
<div class="contentTop">
    <span class="pageTitle"><span id="IdAgregarTitle" class="icon-screen"></span>Reporte
        de Tiendas</span>
    <div class="clear">
    </div>
</div>
<div class="wrapper">
    <div class="main">
        <fieldset>
            <div class="widget fluid">
                <div class="whead">
                    <h6>
                        Filtros de Búsqueda</h6>
                    <div class="clear">
                    </div>
                </div>
                <div class="formRow fluid">
                    <div class="grid12">
                        <div class="grid4">
                            <div class="grid3">
                                <label class="form-label" for="tipoPersona">
                                    Fecha Inicio:</label>
                            </div>
                            <div class="grid3">
                                @Html.TextBoxFor(Function(m) (m.FechaInicio),
                                New With {
                                    .id = "ID_FechaInicio",
                                    .class = "textinput datepickerAkiraMax2",
                                    .maxlength = "10",
                                    .onchange = "CargaZonasporFechas_Tiendas()",
                                    .Value = Format("{0:d}", " ")
                                })
                                <div id="ID_MsgFechaInicio">
                                </div>
                            </div>
                        </div>
                        <div class="grid4">
                            <div class="grid3">
                                <label class="form-label" for="tipoPersona">
                                    Fecha Fin:</label>
                            </div>
                            <div class="grid3">
                                @Html.TextBoxFor(Function(m) (m.FechaFin),
                                New With {
                                    .id = "ID_FechaFin",
                                    .class = "textinput datepickerAkiraMax",
                                    .maxlength = "10",
                                    .Value = Format("{0:d}", " "),
                                    .onchange = "CargaZonasporFechas_Tiendas()"
                                })
                                <div id="ID_MsgFechaFin">
                                </div>
                            </div>
                        </div>
                         </div>
            </div>
                <div class="formRow fluid">
                    <div class="grid4">
                        <div class="grid3">
                            <label class="form-label" for="tipoPersona">
                                Zona:</label>
                        </div>
                        <div id="DivZonaM" class="grid3">
                           @* @Html.DropDownListFor(Function(m) m.ZonaMantenimiento.IdZona,
                            New SelectList(Model.ListaZonaMantenimiento, "IdZona", "NombreZona"),
                            New With {
                                .class = "selector",
                                .id = "ID_Zona",
                                .onchange = "",
                                .multiple = "multiple"*@

                                 @Html.DropDownListFor(Function(m) m.ZonaMantenimiento.IdZona,
                               New SelectList(Model.ListaZonaMantenimiento, "IdZona", "NombreZona"),
                               New With {
                                         .id = "ID_Zona",
                                         .class = "textinput selector",
                                         .multiple = "multiple"
                                })  
                                
                                @Html.HiddenFor(Function(m) m.ZonaMantenimiento.IdZona, New With {.id = "IdZona2"})      
                            
                        </div>
                    </div>
                    <div class="grid4">
                        <div class="grid3">
                            <label class="form-label" for="tipoPersona">
                                Sucursal:</label>
                        </div>
                        <div id="DivSucursalPartial" class="grid3">
                            @*@Html.DropDownListFor(Function(m) m.Sucursal.IdSucursal,
                            New SelectList(Model.ListaSucursal, "IdSucursal", "Descripcion"),
                            New With {
                                .class = "selector",
                                .id = "IdSucursal",
                                .multiple = "multiple"
                            })*@
                            @Html.DropDownListFor(Function(m) m.Sucursal.IdSucursal,
                                New SelectList(Model.ListaSucursal, "IdSucursal", "DescripcionSucursal"),
                                New With {
                                    .class = "selector",
                                    .id = "IdSucursal",
                                    .multiple = "multiple"
                                })
                                 @Html.HiddenFor(Function(m) m.Sucursal.IdSucursal, New With {.id = "Idsucursal2"})
                           
                        </div>
                    </div>
            </div>    
                <div class="formRow fluid">
                    <div class="grid12">
                        <button type="button" name="ActionGrabar" id="btnReporte" style="cursor: pointer"
                            class="buttonS bBlue formSubmit group_button " onclick="VerReporteTiendas()">
                            Ver Reporte</button>
                        @Html.Hidden("ID_URL", Url.Action("VerReporteTiendas", "Reportes"))
                    </div>
            </div>
                <div class="formRow fluid">
                    <div class="clear">
                    </div>
            </div>
                <div id="ID_Partial_ReporteTiendas" style="display: none" class="j_modal" name="Reporte de Tiendas">
                </div>                
            </div>
        </fieldset>
    </div>
</div>
 @Html.Hidden("UrlCargaZonaPorFecha", Url.Action("_ComboMultiZona", "Reportes"))
 @Html.Hidden("UrlCargaSucursalPorFecha", Url.Action("_ComboMultiSucursal", "Reportes"))


<script type="text/javascript" language="javascript">
    var navegador = navigator.appName

    $(function () {

        $("#ID_Zona").multiselect(
            {
                selectedList: 10,
                noneSelectedText: '-SELECCIONE-',
                show: ["bounce", 200],
                minWidth: 220
            }
         ).multiselectfilter();

        $("#ID_Zona").multiselect("uncheckAll");

        $("#IdSucursal").multiselect(
            {
                selectedList: 10,
                noneSelectedText: '-SELECCIONE-',
                show: ["bounce", 200],
                minWidth: 220
            }
         ).multiselectfilter();
        $(".ui-multiselect").attr("style", "width: 220px")
        if (navegador == "Microsoft Internet Explorer") {
            $(".ui-multiselect").attr("style", "width: 250px")
        }
    });

    //Esto permite que la fecha no sea mayor a la actual
         $(".datepickerAkiraMax").datepicker({
        showOtherMonths: true,
        autoSize: true,
        changeMonth: true,
        changeYear: true,
        appendText: '(DD/MM/AAAA)',
        dateFormat: 'dd/mm/yy'
//        maxDate: "0D"
    });

    $(".datepickerAkiraMax2").datepicker({
        showOtherMonths: true,
        autoSize: true,
        changeMonth: true,
        changeYear: true,
        appendText: '(DD/MM/AAAA)',
        dateFormat: 'dd/mm/yy',
    });
</script> 
