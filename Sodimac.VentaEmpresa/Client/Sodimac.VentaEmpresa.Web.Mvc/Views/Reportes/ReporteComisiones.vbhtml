@ModelType Sodimac.VentaEmpresa.Web.Mvc.ReporteViewModel
@Code
    ViewData("Title") = "Reporte de Comisiones"
End Code

<div class="breadLine">
    <div class="bc">
        <ul id="breadcrumbs" class="breadcrumbs">
            <li><a href="#">Inicio</a> </li>
            <li><a href="#">Reportes</a> </li>
            <li class="current"><a title="" href="#">Reporte de Comisiones</a> </li>
        </ul>
    </div>
</div> 
<div class="contentTop">
    <span class="pageTitle"><span id="IdAgregarTitle" class="icon-screen"></span>Reporte
        de Comisiones</span>
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
                                        .onchange = "CargaZonasporFechas_Comision()",
                                        .Value = Format("{0:d}", " ")
                                        })  
                               <div id="ID_MsgFechaInicio"></div>              
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
                                        .class = "textinput datepickerAkiraMax2",
                                        .maxlength = "10",
                                        .Value = Format("{0:d}", " "),
                                        .onchange = "CargaZonasporFechas_Comision()"
                                       })
                               <div id="ID_MsgFechaFin"></div>
                            </div>
                        </div>
                    </div>
                    <div class="formRow fluid">                        
                        <div class="grid6">
                            <div class="grid3">
                                <label class="form-label" for="tipoPersona">
                                  Zona:  </label>
                            </div>
                            <div id="DivZonaM" class="grid9">
                               @* @Html.DropDownListFor(Function(m) m.ZonaMantenimiento.IdZona,
                                New SelectList(Model.ListaZonaMantenimiento, "IdZona", "NombreZona"),
                                New With {
                                    .class = "textinput selector",
                                    .id = "ID_Zona",
                                    .onchange = "",
                                    .multiple = "multiple"
                                })*@

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
                             @*   @Html.DropDownListFor(Function(m) m.Sucursal.IdSucursal,
                                New SelectList(Model.ListaSucursal, "IdSucursal", "Descripcion"),
                                New With {
                                    .class = "selector",
                                    .id = "IdSucursal",
                                    .onchange = "",
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
                    <div class="formRow">
                        <div class="grid12">
                            <button type="button" name="ActionGrabar" id="btnReporte" style="cursor: pointer"
                                class="buttonS bBlue formSubmit group_button " onclick="VerReporteComisiones()">
                                Ver Reporte</button>
                            @Html.Hidden("ID_URL", Url.Action("VerReporteComisiones", "Reportes"))
                        </div>
                        <div class="clear">
                        </div>
                    </div>
                    <div class="formRow fluid">
                        <div class="clear">
                        </div>
                    </div>
                </div>
                <div id="ID_Partial_ReporteComisiones" style="display: none" class="j_modal" name="Reporte de Comisiones">
                </div>
            </div>
        </fieldset>
    </div>
</div>
 @Html.Hidden("UrlCargaZonaPorFecha", Url.Action("_ComboMultiZona", "Reportes"))
  @Html.Hidden("UrlCargaSucursalPorFecha", Url.Action("_ComboMultiSucursal", "Reportes"))
<script type="text/javascript" src="@Url.Content("~/Scripts/View/Reportes.js")">  </script>

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
