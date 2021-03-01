@ModelType Sodimac.VentaEmpresa.Web.Mvc.ReporteViewModel
@Code
    ViewData("Title") = "Reporte Log"
End Code

<div class="breadLine">
    <div class="bc">
        <ul id="breadcrumbs" class="breadcrumbs">
            <li><a href="#">Inicio</a> </li>
            <li><a href="#">Reportes</a> </li>
            <li class="current"><a title="" href="#">Reporte Log</a> </li>
        </ul>
    </div>
</div>
<div class="contentTop">
    <span class="pageTitle"><span id="IdAgregarTitle" class="icon-screen"></span>Reporte
        de Ventas</span>
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
                                    Fecha Inicio:</label>
                            </div>
                            <div class="grid7">
                                @Html.TextBoxFor(Function(m) (m.FechaInicio),
                                New With {
                                          .id = "ID_FechaInicio",
                                          .class = "datepicker maskDate",
                                          .maxlength = "10",
                                          .Value = Format("{0:d}", " ")
                                })
                                <div id="ID_MsgFechaInicio"></div>
                            </div>
                        </div>
                        <div class="grid4">
                            <div class="grid3">
                                <label class="form-label" for="tipoPersona">
                                    Fecha Fin:</label>
                            </div>
                            <div class="grid9">
                                @Html.TextBoxFor(Function(m) (m.FechaFin),
                                New With {
                                    .id = "ID_FechaFin",
                                    .class = "datepicker maskDate",
                                    .maxlength = "10",
                                    .Value = Format("{0:d}", " ")
                                })
                                <div id="ID_MsgFechaFin"></div>
                            </div>
                        </div>
                        <div class="grid4">
                            <div class="grid4">
                                <label class="form-label" for="tipoPersona">
                                    Acciones:</label>
                            </div>
                            <div class="grid3">
                                @Html.DropDownListFor(Function(m) m.LogAccion.IdLogAccion,
                               New SelectList(Model.ListaLogAccion, "IdLogAccion", "Descripcion"),
                               New With {
                                         .id = "ID_LogAccion",
                                         .class = "textinput selector",
                                         .multiple = "multiple"
                                })                               
                            </div>
                        </div>
                    </div>
                    <div class="formRow fluid">
                        <div class="grid4">
                            <div class="grid4">
                                <label class="form-label" for="tipoPersona">
                                    Origen:</label>
                            </div>
                            <div class="grid3">
                                @Html.DropDownListFor(Function(m) m.OrigenAccion.IdOrigenAccion,
                               New SelectList(Model.ListaOrigenAccion, "IdOrigenAccion", "Descripcion"),
                               New With {
                                         .id = "ID_OrigenAccion",
                                         .class = "textinput selector",
                                         .multiple = "multiple"
                                })                               
                            </div>
                        </div>
                    </div>
                    <div class="formRow">
                        <div class="grid12">
                            <button type="button" name="ActionGrabar" id="btnReporte" style="cursor: pointer"
                                class="buttonS bBlue formSubmit group_button " onclick="VerReporteLog()">
                                Ver Reporte</button>
                           @Html.Hidden("ID_URL", Url.Action("VerReporteLog", "Reportes"))
                        </div>
                        <div class="clear">
                        </div>
                    </div>
                    <div class="formRow fluid">
                        <div class="clear">
                        </div>
                    </div>
                </div>
                <div id="ID_Partial_ReporteLog" style="display: none" class="j_modal" name="Reporte Log">
                </div>
            </div>
        </fieldset>
    </div>
</div>

<script type="text/javascript" src="@Url.Content("~/Scripts/View/Reportes.js")">  </script>
<script type="text/javascript" language="javascript">
    var navegador = navigator.appName

    $(function () {
        $("#ID_LogAccion").multiselect(
            {
                selectedList: 10,
                noneSelectedText: '-TODOS-',
                show: ["bounce", 200],
                minWidth: 280
            }
         ).multiselectfilter();

            $("#ID_OrigenAccion").multiselect(
            {
                selectedList: 10,
                noneSelectedText: '-TODOS-',
                show: ["bounce", 200],
                minWidth: 280
            }
         ).multiselectfilter();

        $(".ui-multiselect").attr("style", "width: 280px")
        if (navegador == "Microsoft Internet Explorer") {
            $(".ui-multiselect").attr("style", "width: 250px")
        }
    });
</script> 
