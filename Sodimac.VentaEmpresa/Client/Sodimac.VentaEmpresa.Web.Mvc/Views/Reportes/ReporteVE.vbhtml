@ModelType Sodimac.VentaEmpresa.Web.Mvc.ReporteViewModel
@Code
    ViewData("Title") = "Reporte VE"
End Code

<div class="breadLine">
    <div class="bc">
        <ul id="breadcrumbs" class="breadcrumbs">
            <li><a href="#">Inicio</a> </li>
            <li><a href="#">Reportes</a> </li>
            <li class="current"><a title="" href="#">Reporte VAP</a> </li>
        </ul>
    </div>
</div>
<div class="contentTop">
    <span class="pageTitle">
        <span id="IdAgregarTitle" class="icon-screen"></span>Reporte VAP
    </span>
    <div class="clear">
    </div>
</div>
@*@Using (Html.BeginForm("ExportReporteVE", "Reportes", FormMethod.Post, New With {.id = "FrmReporteVE"}))*@
    <div class="wrapper">
        <div class="main">
            <fieldset>
                <div class="form">
                    <div class="widget fluid">
                        <div class="whead">
                            <h6>
                                Criterios de Búsqueda
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
                                <button type="button" name="ActionGrabar" id="btnReporte" style="cursor: pointer"
                                        class="buttonS bBlue formSubmit group_button " onclick="VerReporteVE()">
                                    Exportar a Excel
                                </button>
                                @Html.Hidden("Url_Exportar", Url.Action("ExportReporteVE", "Reportes"))
                            </div>
                            <div class="clear">
                            </div>
                        </div>
                        <div class="formRow fluid">
                            <div class="clear">
                            </div>
                        </div>
                    </div>
                    <div id="ID_Partial_ReporteVE">
                    </div>
                </div>
            </fieldset>
        </div>
    </div>
@*End Using*@
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