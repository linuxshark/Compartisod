@ModelType Sodimac.VentaEmpresa.Web.Mvc.ReporteViewModel
@Code
    ViewData("Title") = "Reporte Margen de Fierro"
End Code

<div class="breadLine">
    <div class="bc">
        <ul id="breadcrumbs" class="breadcrumbs">
            <li><a href="#">Inicio</a> </li>
            <li><a href="#">Reportes</a> </li>
            <li class="current"><a title="" href="#">Reporte de Margen de Fierro</a> </li>
        </ul>
    </div>
</div>
<div class="contentTop">
    <span class="pageTitle">
        <span id="IdAgregarTitle" class="icon-screen"></span>Reporte de Margen de Fierro
    </span>
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
                                                              .class = "textinput datepicker",
                                                              .maxlength = "10",
                                                              .onchange = "ValidaFecha()",
                                                              .Value = Format("{0:d}", " ")})

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
                                                              .class = "textinput datepicker",
                                                              .maxlength = "10",
                                                              .onchange = "ValidaFecha()",
                                                              .Value = Format("{0:d}", " ")})
                                <div id="ID_MsgFechaFin"></div>
                            </div>
                        </div>
                        <div class="grid4">
                            <div class="grid3">
                                <label class="form-label" for="tipoPersona">
                                    Empresa:
                                </label>
                            </div>
                            <div id="DivEmpresaPartial" class="grid3">
                                @Html.DropDownListFor(Function(m) m.Empresa.IdEmpresa,
                                                                New SelectList(Model.ListaEmpresa, "IdEmpresa", "NomEmpresa"),
                                                                New With {
                                                                    .class = "selector",
                                                                    .id = "IdEmpresa",
                                                                    .multiple = "multiple",
                                                                    .style = "width:200px"
                                                                })
                                @Html.HiddenFor(Function(m) m.Empresa.IdEmpresa, New With {.id = "IdEmpresaVal"})
                                <div id="ID_MsgEmpresa"></div>
                            </div>
                        </div>
                    </div>
                    <div class="formRow fluid">
                        <div class="grid4">
                            <div class="grid4">
                                <label class="form-label" for="tipoPersona">
                                    Sucursal:
                                </label>
                            </div>
                            <div id="DivSucursalPartial" class="grid3">
                                @Html.DropDownListFor(Function(m) m.Sucursal.IdSucursal,
                                                                New SelectList(Model.ListaSucursal, "IdSucursal", "Descripcion"),
                                                                New With {
                                                                    .class = "selector",
                                                                    .id = "IdSucursal",
                                                                    .multiple = "multiple",
                                                                    .style = "width:200px"
                                                                })
                                @Html.HiddenFor(Function(m) m.Sucursal.IdSucursal, New With {.id = "IdsucursalVal"})
                            </div>
                        </div>
                        <div class="grid4">
                            <div class="grid3">
                                <label class="form-label" for="Sku">
                                    Sku:
                                </label>
                            </div>
                            <div class="grid7">
                                <div class="ui-widget">
                                    @Html.TextBoxFor(Function(m) m.Sku, New With {.id = "Sku", .class = "textinput"})
                                </div>
                            </div>
                        </div>
                        <div class="grid4">
                            <div class="grid3">
                                <label class="form-label" for="tipoCaja">
                                    Tipo Caja:
                                </label>
                            </div>
                            <div id="DivRRVV" class="grid3">
                                @Html.DropDownListFor(Function(m) m.ClienteTipo.IdClienteTipo,
                                                    New SelectList(Model.ListaTipoCaja, "IdTipoCaja", "Descripcion"),
                                                    "- SELECCIONE -",
                                                    New With {
                                                        .class = "selector",
                                                        .id = "IdTipoCaja"
                                                    })
                            </div>
                        </div>
                    </div>
                    <div class="formRow">
                        <div class="grid12">
                            <button type="button" name="ActionGrabar" id="btnReporte" style="cursor: pointer"
                                    class="buttonS bBlue formSubmit group_button " onclick="VerReporteMargenFierro()">
                                Ver Reporte
                            </button>
                            @Html.Hidden("ID_URL", Url.Action("ReporteMargenFierro", "Reportes"))
                            @Html.Hidden("ID_URL_SUC", Url.Action("_ComboSucursal_", "Reportes"))
                            @Html.Hidden("ID_URL_MARGEN", Url.Action("_ProductosMargenFierro", "Reportes"))
                        </div>
                        <div class="clear">
                        </div>
                    </div>
                    <div class="formRow fluid">
                        <div class="clear">
                        </div>
                    </div>
                </div>
                <div id="ID_Partial_ReporteMargenFierro">
                </div>
            </div>
        </fieldset>
    </div>
</div>
<script type="text/javascript" src="@Url.Content("~/Scripts/View/Reportes.js")">  </script>
<script>
    $(".datepicker").datepicker({
        showOtherMonths: true,
        autoSize: true,
        changeMonth: true,
        changeYear: true,
        appendText: '(DD/MM/AAAA)',
        dateFormat: 'dd/mm/yy'
        //        maxDate: "0D"
    });

  
    
</script>