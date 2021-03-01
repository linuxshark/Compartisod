@ModelType Sodimac.VentaEmpresa.Web.Mvc.ReporteViewModel
@Code
    ViewData("Title") = "ReporteVAP"
End Code

<div class="breadLine">
    <div class="bc">
        <ul id="breadcrumbs" class="breadcrumbs">
            <li><a href="#">Inicio</a> </li>
            <li><a href="#">Reportes</a> </li>
            <li class="current"><a title="" href="#">Reporte de Ventas</a> </li>
        </ul>
    </div>
</div>
<div class="contentTop">
    <span class="pageTitle">
        <span id="IdAgregarTitle" class="icon-screen"></span>Reporte
        de Ventas
    </span>
    <div class="clear">
    </div>
</div>

<div class="wrapper">
    <div class="main">
        <fieldset>
            @Using (Html.BeginForm("", "Reportes", FormMethod.Post, New With {.id = "FrmReporteVE"}))
            @<div class="form">
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
                            <div class="grid3">
                                <label class="form-label" for="tipoPersona">
                                    Marca:
                                </label>
                            </div>
                            <div id="DivMarcaPartial" class="grid3">
                                @Html.DropDownListFor(Function(m) m.Marca.IdMarca,
                                    New SelectList(Model.ListaMarca, "IdMarca", "NomMarca"),
                                    "Seleccione",
                                    New With {
                                        .id = "IdMarca"
                                    })
                                @Html.HiddenFor(Function(m) m.Marca.IdMarca, New With {.id = "IdMarcaVal"})
                                <div id="ID_MsgMarca"></div>
                            </div>
                        </div>
                        <div class="grid4">
                            <div class="grid4">
                                <label class="form-label" for="tipoPersona">
                                    Fecha Inicio
                                </label>
                            </div>
                            <div class="grid3">
                                @Html.TextBoxFor(Function(m) (m.FechaInicio),
                                New With {
                                    .id = "ID_FechaInicio",
                                    .class = "textinput datepicker",
                                    .maxlength = "10",
                                    .onchange = "ValidaFecha_ReporteVE()",
                                    .Value = Format("{0:d}", " ")})

                                <div id="ID_MsgFechaInicio"></div>
                            </div>
                        </div>
                        <div class="grid4">
                            <div class="grid3">
                                <label class="form-label" for="tipoPersona">
                                    Fecha Fin
                                </label>
                            </div>
                            <div class="grid3">
                                @Html.TextBoxFor(Function(m) (m.FechaFin),
                                  New With {
                                      .id = "ID_FechaFin",
                                      .class = "textinput datepicker",
                                      .maxlength = "10",
                                      .onchange = "ValidaFecha_ReporteVE()",
                                      .Value = Format("{0:d}", " ")})
                                <div id="ID_MsgFechaFin"></div>
                            </div>
                        </div>
                    </div>
                    <div class="formRow">
                        <div class="grid12">
                            <button type="button" name="ActionGrabar" id="btnExportarReporteVAP" style="cursor: pointer"
                                    class="buttonS bBlue formSubmit group_button " onclick="ExportarReporteVAP()">
                                Exportar Excel
                            </button>    
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
            End Using
            @Html.Hidden("Exportar_URL", Url.Action("ExportarVAP", "Reportes"))
        </fieldset>
    </div>
</div>


<script type="text/javascript" src="@Url.Content("~/Scripts/View/Reportes.js")">  </script>