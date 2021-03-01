@ModelType Sodimac.VentaEmpresa.Web.Mvc.ReporteViewModel
@Imports Sodimac.VentaEmpresa.Web.Mvc.ParametrosView

@Code
    ViewData("Title") = "Reporte de Representante de Ventas"
End Code
<script type="text/javascript" src="/Scripts/View/Reportes.js"></script>
<div class="breadLine">
    <div class="bc">
        <ul id="breadcrumbs" class="breadcrumbs">
            <li><a href="#">Inicio</a> </li>
            <li><a href="#">Reportes</a> </li>
            <li class="current"><a title="" href="#">Reporte de Representante de Ventas</a> </li>
        </ul>
    </div>
</div>
<div class="contentTop">
    <span class="pageTitle"><span id="IdAgregarTitle" class="icon-screen"></span>Reporte de
        Representante de Ventas</span>
    <div class="clear">
    </div>
</div>
@* @Html.HiddenFor(model => model.IdPerfilActual, new { @id = "hdnPerfil" })*@
 @*@Html.HiddenFor(m => m.IdPerfilActual, new with { @value="1"})*@
   @Html.HiddenFor(Function(m) m.IdPerfilActual, New With {.id = "hdnIdPerfilActual"})
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
                        <div class="grid6">
                            <div class="grid3">
                                <label class="form-label" for="tipoPersona">
                                    Fecha Inicio:</label>
                            </div>
                            <div class="grid2">
                                @Html.TextBoxFor(Function(m) (m.FechaInicio),
                                New With {
                                    .id = "ID_FechaInicio",
                                    .class = "textinput datepickerAkiraMax2",
                                    .maxlength = "10",
                                    .onchange = "CargaZonasporFechas_RptVendedores()",
                                    .Value = Format("{0:d}", " ")
                                })
                                <div id="ID_MsgFechaInicio">
                                </div>
                            </div>
                        </div>
                        <div class="grid6">
                            <div class="grid3">
                                <label class="form-label" for="tipoPersona">
                                    Fecha Fin:</label>
                            </div>
                            <div class="grid2">
                                @Html.TextBoxFor(Function(m) (m.FechaFin),
                                New With {
                                    .id = "ID_FechaFin",
                                    .class = "textinput datepickerAkiraMax",
                                    .maxlength = "10",
                                    .Value = Format("{0:d}", " "),
                                    .onchange = "CargaZonasporFechas_RptVendedores()"
                                })
                                
                                <div id="ID_MsgFechaFin">
                                </div>
                            </div>
                        </div>
                        </div>
                    <div class="formRow fluid">
                        <div class="grid6">
                            <div class="grid3">
                                <label class="form-label" for="tipoPersona">
                                    Jefe de Ventas:</label>
                            </div>
                            <div class="grid3">
                                <div id="ID_ComboJefeRegional">

                                    @Html.DropDownListFor(Function(m) m.Empleado.IdEmpleado,
                                        New SelectList(Model.ListaJefeRegional, "IdEmpleado", "NombresApellidos"),
                                        New With {
                                            .class = "selector",
                                            .id = "IdJefeRegional",
                                            .onkeypress = "EnterSubmit(event,'btnBuscar')",
                                            .onchange = "",
                                            .multiple = "multiple"
                                        })

                                    @Html.HiddenFor(Function(m) m.Empleado.IdEmpleado, New With {.id = "iIdJefeRegional"})

                                   @* @Html.Partial("_ComboJefeRegional",Model)*@

                                </div>                              
                            </div>
                        </div>
                        <div>
                        </div>       
                     </div>
                     <div class="formRow fluid">
                        <div class="grid6">
                            <div class="grid3">
                                <label class="form-label">
                                    Zona:
                                </label>
                            </div>
                            <div id="DivZonaM" class="grid3">
                                 
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
                        <div class="grid6">
                            <div class="grid3">
                                <label class="form-label" for="tipoPersona">
                                    Sucursal:</label>
                            </div>
                            <div id="DivSucursalPartial" class="grid3">
                                
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
                    <div class="formRow">
                        <div class="grid12">
                            <button type="button" name="ActionGrabar" id="btnReporte" style="cursor: pointer"
                                class="buttonS bBlue formSubmit group_button " onclick="VerReporteVendedores()">
                                Ver Reporte</button>
                            @Html.Hidden("ID_URL", Url.Action("VerReporteVendedores", "Reportes"))
                        </div>
                        <div class="clear">
                        </div>
                    </div>
                    <div class="formRow fluid">
                        <div class="clear">
                        </div>
                    </div>
                </div>
                <div id="ID_Partial_ReporteVendedores" style="display: none" class="j_modal" name="Reporte de Representante de Ventas">
                </div>
            </div>
        </fieldset>
    </div>
</div>
 @Html.Hidden("UrlCargaZonaPorFecha", Url.Action("_ComboMultiZona", "Reportes"))
 @Html.Hidden("UrlCargaSucursalPorFecha", Url.Action("_ComboMultiSucursal", "Reportes"))
 @Html.Hidden("UrlCargaJefeRegional", Url.Action("_ComboJefeRegional", "Reportes"))

@* @Html.Hidden("UrlCargaRRVV", Url.Action("_ComboRRVV", "Reportes"))*@
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
         $("#IdJefeRegional").multiselect(
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

    var Contador_JefeVentas = 0;
    $("#IdJefeRegional > option ").each(function () {
        Contador_JefeVentas++;
    });

//       var Cont = 1;
//    $("#IdJefeRegional > option").each(function () {
//      
//        if (Cont > 2) {
//            
//            $("#IdJefeRegional").removeAttr("disabled", "false");

//        }
//        else if (Cont == 2) {
//            $(this).attr("selected", "true");
//            $("#IdJefeRegional").prop("disabled", "disabled");
//        }
//        Cont++;

    if (Contador_JefeVentas > 0) {
        $("#IdJefeRegional > option").each(function () {
            $(this).removeAttr("selected");
            $("#IdJefeRegional").removeAttr("disabled", "false");
        });
    }

    if (Contador_JefeVentas == 1) {
        $("#IdJefeRegional > option ").first().attr("selected", "selected");
        $("#IdJefeRegional").prop("disabled", "disabled");
    }

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
