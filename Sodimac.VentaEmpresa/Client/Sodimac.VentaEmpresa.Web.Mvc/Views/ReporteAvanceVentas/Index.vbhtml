@ModelType Sodimac.VentaEmpresa.Web.Mvc.ReporteViewModel

@Code
    ViewData("Title") = "Reporte Avance de Ventas"
End Code

<div class="breadLine">
    <div class="bc">
        <ul id="breadcrumbs" class="breadcrumbs">
            <li><a href="#">Inicio</a> </li>
            <li><a href="#">Reportes</a> </li>
            <li class="current"><a title="" href="#">Reporte Avance de Ventas</a> </li>
        </ul>
    </div>
</div>
<div class="contentTop">
    <span class="pageTitle">
        <span id="IdAgregarTitle" class="icon-screen"></span>
        Reporte Avance de Ventas
    </span>
    <div class="clear"> </div>
</div>
<div class="wrapper">
        @Using (Html.BeginForm("", "", FormMethod.Post, New With {.id = "FrmAvanceVenta"}))
            @<fieldset>
                <div class="form">
                    <div class="widget fluid">
                        <div class="whead">
                            <h6>
                                Filtros de Búsqueda
                            </h6>
                            <div class="clear">
                            </div>
                        </div>
                        <div class="formRow fluid">
                            @*<div class="grid4">
                                <div class="grid4">
                                    <label class="form-label" for="tipoPersona">
                                    Fecha Inicio
                                    </label>
                                </div>
                                <div class="grid3">
                                    @Html.TextBoxFor(Function(m) (m.FechaInicio),
                                    New With {
                                            .id = "ID_FechaInicio",
                                            .class = "textinput datepickerAkiraMax",
                                            .maxlength = "10",
                                            .Value = Format("{0:d}", " ")
                                        })
                                    <div id="ID_MsgFechaInicio"></div>
                                </div>
                            </div>*@
                            <div class="grid4">
                                <div class="grid4">
                                    <label class="form-label" for="tipoPersona">
                                        Fecha:
                                    </label>
                                </div>
                                <div class="grid3">
                                    @Html.TextBoxFor(Function(m) (m.FechaFin),
                            New With {
                                    .id = "ID_FechaFin",
                                    .class = "textinput datepickerAkiraMax",
                                    .maxlength = "10",
                                    .Value = Format("{0:d}", " ")
                                })
                                    <div id="ID_MsgFechaFin"></div>
                                </div>
                            </div>
                        </div>
                        <div class="formRow fluid">
                            <div class="grid4">
                                <div class="grid4">
                                    <label class="form-label" for="tipoPersona">
                                        Zona:
                                    </label>
                                </div>
                                <div id="DivZonaM" class="grid3">
                                    @Html.DropDownListFor(Function(m) m.ListaAvanceVentas.ListaZonaMantenimiento,
                                    New SelectList(Model.ListaAvanceVentas.ListaZonaMantenimiento, "IdZona", "NombreZona"),
                                    New With {
                                            .id = "ID_Zona",
                                            .class = "textinput selector",
                                            .multiple = "multiple"
                                        })
                                    @Html.HiddenFor(Function(m) m.CadenaZona, New With {.id = "CadenaZona"})
                                </div>
                            </div>
                            <div class="grid4">
                                <div class="grid4">
                                    <label class="form-label" for="tipoPersona">
                                        Sucursal:
                                    </label>
                                </div>
                                <div id="DivSucursalPartial" class="grid3">
                                    @Html.Partial("_ComboMultiSucursal", Model)
                                </div>
                            </div>
                        </div>
                        <div class="formRow fluid">
                            <div class="grid4">
                                <div class="grid4">
                                    <label class="form-label" for="tipoPersona">
                                        Sub - Gerente:
                                    </label>
                                </div>
                                <div class="grid3">
                                    <div id="ID_ComboSubGerente">
                                        @Html.DropDownListFor(Function(m) m.ListaAvanceVentas.ListaSubGerente,
                                        New SelectList(Model.ListaAvanceVentas.ListaSubGerente, "IdEmpleado", "NombresApellidos"),
                                        New With {
                                                .class = "selector",
                                                .id = "IdSubGerente_",
                                                .onkeypress = "EnterSubmit(event,'btnBuscar')",
                                                .onchange = "",
                                                .multiple = "multiple"
                                            })
                                        @Html.HiddenFor(Function(m) m.CadenaSubGerente, New With {.id = "CadenaSubGerente"})
                                    </div>
                                </div>
                            </div>
                            <div class="grid4">
                                <div class="grid4">
                                    <label class="form-label" for="tipoPersona">
                                        Jefe de Ventas:
                                    </label>
                                </div>
                                <div class="grid3">
                                    <div id="ID_ComboJefeRegional">
                                        @Html.Partial("_ComboMultiJefeVenta", Model)
                                    </div>
                                </div>
                            </div>
                            <div class="grid4">
                                <div class="grid4">
                                    <label class="form-label" for="tipoPersona">
                                        RRVV:
                                    </label>
                                </div>
                                <div id="DivRRVV" class="grid3">
                                    @Html.Partial("_ComboMultiRRVV", Model)
                                </div>
                            </div>
                        </div>
                        <div class="formRow">
                            <div class="grid12">
                                <button type="button" name="ActionGrabar" id="btnExportarReporte" style="cursor: pointer"
                                        class="buttonS bBlue formSubmit group_button ">
                                    Exportar Excel
                                </button>
                            </div>
                            <div class="clear">
                            </div>
                        </div>
                    </div>
                </div>
            </fieldset>
        End Using
</div>
        @Html.Hidden("UrlCargaSucursalPorFecha", Url.Action("_ComboMultiSucursal", "ReporteAvanceVentas"))
        @Html.Hidden("UrlCargaJefeVenta", Url.Action("_ComboJefeRegional", "ReporteAvanceVentas"))
        @Html.Hidden("UrlCargaRRVV", Url.Action("_ComboRRVV", "ReporteAvanceVentas"))
        @Html.Hidden("UrlGenerarReporte", Url.Action("GenerarReporte", "ReporteAvanceVentas"))
        @Html.Hidden("UrlDescargarReporte", Url.Action("DescargarExcel", "ReporteAvanceVentas"))

        <script type="text/javascript" src="@Url.Content("~/Scripts/View/ReporteAvanceVentas.js")">  </script>

        <script type="text/javascript" language="javascript">
            //Esto permite que la fecha no sea mayor a la actual
            $(".datepickerAkiraMax").datepicker({
                showOtherMonths: true,
                autoSize: true,
                changeMonth: true,
                changeYear: true,
                appendText: '(DD/MM/AAAA)',
                dateFormat: 'dd/mm/yy'
                //maxDate: "0D"
            });
        </script>
