@ModelType Sodimac.VentaEmpresa.Web.Mvc.ReporteViewModel

@*@Imports Sodimac.VentaEmpresa.Web.Mvc.ParametrosView*@
@Code
    ViewData("Title") = "Reporte de Cartera de Clientes"
End Code

<div class="breadLine">
    <div class="bc">
        <ul id="breadcrumbs" class="breadcrumbs">
            <li><a href="#">Inicio</a> </li>
            <li><a href="#">Reportes</a> </li>
            <li class="current"><a title="" href="#">Reporte de Cartera de Clientes</a> </li>
        </ul>
    </div>
</div>
<div class="contentTop">
    <span class="pageTitle">
        <span id="IdAgregarTitle" class="icon-screen"></span>
        Reporte Cartera de Clientes
    </span>
    <div class="clear">
    </div>
</div>
<form name="FrmReporteCarteraCliente" id="FrmReporteCarteraCliente" action="" method="post">
    <div class="wrapper">
        <div class="main">
            <fieldset>
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
                            <div class="grid4">
                                <div class="grid4">
                                    <label class="form-label" for="tipoPersona">
                                        Fecha Inicio:
                                    </label>
                                </div>
                                <div class="grid3">
                                    @Html.TextBoxFor(Function(m) (m.FechaInicio),
                                        New With {
                                            .id = "ID_FechaInicio",
                                            .class = "textinput datepickerAkiraMax",
                                            .maxlength = "10",
                                            .Value = Format("{0:d}", " "),
                                            .onchange = "CargaZonasporFechas_Ventas()"
                                        })
                                    <div id="ID_MsgFechaInicio"></div>
                                </div>
                            </div>
                            <div class="grid4">
                                <div class="grid3">
                                    <label class="form-label" for="tipoPersona">
                                        Fecha Fin:
                                    </label>
                                </div>
                                <div class="grid3">
                                    @Html.TextBoxFor(Function(m) (m.FechaFin),
                                        New With {
                                            .id = "ID_FechaFin",
                                            .class = "textinput datepickerAkiraMax",
                                            .maxlength = "10",
                                            .Value = Format("{0:d}", " "),
                                            .onchange = "CargaZonasporFechas_Ventas()"
                                        })
                                    <div id="ID_MsgFechaFin"></div>
                                </div>
                            </div>
                            <div class="grid4">
                                <div class="grid3">
                                    <label class="form-label" for="tipoPersona">
                                        Jefe de Ventas:
                                    </label>
                                </div>
                                <div class="grid3">
                                    <div id="ID_ComboJefeRegional">
                                        @Html.DropDownListFor(Function(m) m.Empleado.IdEmpleado,
                                        New SelectList(Model.ListaJefeRegional, "IdEmpleado", "NombresApellidos"),
                                            New With {
                                                .class = "selector",
                                                .id = "IdJefeRegional_",
                                                .onkeypress = "EnterSubmit(event,'btnBuscar')",
                                                .onchange = "",
                                                .multiple = "multiple"
                                            })
                                        @Html.HiddenFor(Function(m) m.Empleado.IdEmpleado, New With {.id = "iIdJefeRegional"})
                                    </div>
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
                                        Sucursal:
                                    </label>
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
                            <div class="grid4">
                                <div class="grid3">
                                    <label class="form-label" for="tipoPersona">
                                        RRVV:
                                    </label>
                                </div>
                                <div id="DivRRVV" class="grid3">
                                    @Html.DropDownListFor(Function(m) m.Empleado.IdEmpleado,
                                        New SelectList(Model.ListaEmpleado, "IdEmpleado", "NombresApellidos"),
                                        New With {
                                            .id = "IdVendedor_",
                                            .style = "cursor:default;",
                                            .multiple = "multiple",
                                            .class = "selector",
                                            .onkeypress = "EnterSubmit(event,'btnBuscar')"
                                        })
                                    @Html.HiddenFor(Function(m) m.Empleado.IdEmpleado, New With {.id = "ID_Empleado_V"})
                                </div>
                            </div>
                        </div>
                        <div class="formRow fluid">
                            <div class="grid4">
                                <div class="grid4">
                                    <label class="form-label" for="tipoPersona">
                                        Razón Social / RUC:
                                    </label>
                                </div>
                                <div class="grid6">
                                    <input id="ID_RazonSocial" name="Cargo.RegistrarCorrelativo" style="text-transform: uppercase;"
                                           type="text" onkeypress="" maxlength="50" />
                                </div>
                            </div>
                            <div class="grid4">
                                <div class="grid3">
                                    <label class="form-label" for="tipoPersona">
                                        Tipo Cliente:
                                    </label>
                                </div>
                                <div class="grid9">
                                    @Html.DropDownListFor(Function(m) m.ClienteTipo.IdClienteTipo,
                                        New SelectList(Model.ListaClienteTipo, "IdClienteTipo", "Descripcion"),
                                        "- TODOS -",
                                        New With {
                                            .class = "selector",
                                            .id = "IdTipoCliente"
                                        })
                                </div>
                            </div>
                            <div class="grid4">
                                <div class="grid3">
                                    <label class="form-label" for="tipoPersona">
                                        Grupo:
                                    </label>
                                </div>
                                <div class="grid9">
                                    @Html.DropDownListFor(Function(m) m.Grupo.IdGrupo,
                                        New SelectList(Model.ListaGrupo, "IdGrupo", "NombreGrupo"),
                                        "- TODOS -",
                                        New With {
                                            .class = "selector",
                                            .id = "IdGrupo"
                                        })
                                </div>
                            </div>
                        </div>
                        <div class="formRow">
                            <div class="grid12">
                                <button type="button" name="ActionGrabar" id="btnExportarReporte" style="cursor: pointer"
                                        class="buttonS bBlue formSubmit group_button " onclick="ExportarReporteVentas()">
                                    Exportar Excel
                                </button>
                                @Html.Hidden("Exportar_URL", Url.Action("ExportarReporteVentas", "ReporteCarteraCliente"))
                            </div>
                            <div class="clear">
                            </div>
                        </div>
                        <div class="formRow fluid">
                            <div class="clear">
                            </div>
                        </div>
                    </div>
                </div>
            </fieldset>
        </div>
    </div>
</form>


@Html.Hidden("UrlCargaZonaPorFecha", Url.Action("_ComboMultiZona", "ReporteCarteraCliente"))
@Html.Hidden("UrlCargaSucursalPorFecha", Url.Action("_ComboMultiSucursal", "ReporteCarteraCliente"))
@Html.Hidden("UrlCargaJefeRegional", Url.Action("_ComboJefeRegional", "ReporteCarteraCliente"))
@Html.Hidden("UrlCargaRRVV", Url.Action("_ComboRRVV", "ReporteCarteraCliente"))
<script type="text/javascript" src="@Url.Content("~/Scripts/View/ReporteCarteraCliente.js")">  </script>
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

        $("#IdVendedor_").multiselect(
        {
            selectedList: 10,
            noneSelectedText: '-SELECCIONE-',
            show: ["bounce", 200],
            minWidth: 220
        }
     ).multiselectfilter();

        $("#IdJefeRegional_").multiselect(
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


    var Contador_RRVV = 0;
    $("#IdVendedor_ > option").each(function () {
        Contador_RRVV++;
    });

    if (Contador_RRVV > 0) {

        $("#IdVendedor_ > option").each(function () {
            $(this).removeAttr("selected");
            $("#IdVendedor_").removeAttr("disabled", "false");
        });
    }

    if (Contador_RRVV == 1) {
        $("#IdVendedor_ > option ").first().attr("selected", "selected");
        $("#IdVendedor_").prop("disabled", "disabled");
    }

    var Contador_JefeVentas = 0;
    $("#IdJefeRegional_ > option ").each(function () {
        Contador_JefeVentas++;
    });


    if (Contador_JefeVentas > 0) {
        $("#IdJefeRegional_ > option").each(function () {
            $(this).removeAttr("selected");
            $("#IdJefeRegional_").removeAttr("disabled", "false");
        });
    }

    if (Contador_JefeVentas == 1) {
        $("#IdJefeRegional_ > option ").first().attr("selected", "selected");
        $("#IdJefeRegional_").prop("disabled", "disabled");
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
        dateFormat: 'dd/mm/yy'
    });
</script>
