 @ModelType Sodimac.VentaEmpresa.Web.Mvc.ReporteViewModel
@Code
    ViewData("Title") = "Reporte de Guías"
End Code
<script type="text/javascript" src="/Scripts/View/Reportes.js"></script>
<div class="breadLine">
    <div class="bc">
        <ul id="breadcrumbs" class="breadcrumbs">
            <li><a href="#">Inicio</a> </li>
            <li><a href="#">Reportes</a> </li>
            <li class="current"><a title="" href="#">Reporte de Guías</a> </li>
        </ul>
    </div> 
</div>
<div class="contentTop">
    <span class="pageTitle"><span id="IdAgregarTitle" class="icon-screen"></span>Reporte
        de Guías</span>
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
                                                 .Value = Format("{0:d}", " "),
                                                 .onchange = "CargaZonasporFechas_Guia()"
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
                                                 .class = "textinput datepickerAkiraMax2",
                                                 .maxlength = "10",
                                                 .Value = Format("{0:d}", " "),
                                                 .onchange = "CargaZonasporFechas_Guia()"
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
                                    Zona:</label>
                            </div>
                            <div id="DivZonaM" class="grid9">
                              

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
                            <div id="DivSucursalPartial" class="grid9">
                           

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

                        <div class="grid6">
                            <div class="grid3">
                                <label class="form-label" for="tipoPersona">
                                    Correlativo:</label>
                            </div>
                            <div class="grid3">
                                <input id="ID_Correlativo" name="Cargo.RegistrarCorrelativo" style="text-transform: uppercase;"
                                    type="text" onkeypress="return val_09(event)" maxlength="15" />
                            </div>
                        </div>
                        <div class="grid6">
                            <div class="grid3">
                                <label class="form-label" for="tipoPersona">
                                    Tipo Pedido:</label>
                            </div>
                            <div class="grid3">
                                <input id="ID_TipoPedido" name="Cargo.RegistrarCorrelativo" style="text-transform: uppercase;"
                                    type="text" onkeypress="return val_AZ(event)" maxlength="15" />
                            </div>
                        </div>
                       
                    </div>
                    <div class="formRow fluid">
                        <div class="grid6">
                            <div class="grid3">
                                <label class="form-label" for="tipoPersona">
                                    RRVV:</label>
                            </div>
                            <div id="DivRRVV" class="grid3">
                                @Html.DropDownListFor(Function(m) m.Empleado.IdEmpleado,
                                                      New SelectList(Model.ListaEmpleado, "IdEmpleado", "NombresApellidos"),
                                                      New With {
                                                                .id = "ID_Empleado_G",
                                                                .style = "cursor:default;",
                                                                .multiple = "multiple",
                                                                .class = "selector"
                                                              })

                                

                                @Html.HiddenFor(Function(m) m.Empleado.IdEmpleado, New With {.id = "ID_Empleado_L"})

                            </div>
                        </div>
                         <div class="grid6">
                            <div class="grid3">
                                <label class="form-label" for="tipoPersona">
                                    Caja:</label>
                            </div>
                            <div class="grid3">
                                <input id="ID_Caja" name="Cargo.RegistrarCorrelativo" style="text-transform: uppercase;"
                                    type="text" onkeypress="return val_09(event)" maxlength="15" />
                            </div>
                        </div>
                    </div>
                    <div class="formRow">
                        <div class="grid12">
                            <button type="button" name="ActionGrabar" id="btnReporte" style="cursor: pointer"
                                class="buttonS bBlue formSubmit group_button " onclick="VerReporteGuia()">
                                Ver Reporte</button>
                            @Html.Hidden("ID_URL", Url.Action("VerReporteGuias", "Reportes"))
                        </div>
                        <div class="clear">
                        </div>
                    </div>
                    <div class="formRow fluid">
                        <div class="clear">
                        </div>
                    </div>
                </div>
                <div id="ID_Partial_ReporteGuia" style="display: none" class="j_modal" name="Reporte de Guias">
                </div>
            </div>
        </fieldset>
    </div>
</div>
 @Html.Hidden("UrlCargaZonaPorFecha", Url.Action("_ComboMultiZona", "Reportes"))
  @Html.Hidden("UrlCargaSucursalPorFecha", Url.Action("_ComboMultiSucursal", "Reportes"))
@Html.Hidden("UrlCargaRRVV", Url.Action("_ComboRRVV", "Reportes"))
 <script type="text/javascript" language="javascript">
    var navegador = navigator.appName

    $(function () {
        // $("#ID_FechaFin").bind("change", CargaZonasporFechas);
        // $(inputselector).datepicker('show')
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
         
            $("#ID_Empleado_G").multiselect( 
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
    $("#ID_Empleado_G > option ").each(function () {
        Contador_JefeVentas++;
    });


    if (Contador_JefeVentas > 0) {
        $("#ID_Empleado_G > option").each(function () {
            $(this).removeAttr("selected");
            $("#ID_Empleado_G").removeAttr("disabled", "false");
        });
    }

    if (Contador_JefeVentas == 1) {
        $("#ID_Empleado_G > option ").first().attr("selected", "selected");
        $("#ID_Empleado_G").prop("disabled", "disabled");
    }
       //Esto permite que la fecha no sea mayor a la actual
    $(".datepickerAkiraMax").datepicker({
        showOtherMonths: true,
        autoSize: true,
        changeMonth: true,
        changeYear: true,
        appendText: '(DD/MM/AAAA)',
        dateFormat: 'dd/mm/yy',
        maxDate: "0D"
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
