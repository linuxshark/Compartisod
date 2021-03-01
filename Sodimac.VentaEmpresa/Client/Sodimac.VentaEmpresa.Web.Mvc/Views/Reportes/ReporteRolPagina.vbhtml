@ModelType Sodimac.VentaEmpresa.Web.Mvc.ReporteRolPaginaViewModel
@Code
    ViewData("Title") = "Reporte Rol"
End Code

<div class="breadLine">
    <div class="bc">
        <ul id="breadcrumbs" class="breadcrumbs">
            <li><a href="#">Inicio</a> </li>
            <li><a href="#">Reportes</a> </li>
            <li class="current"><a title="" href="#">Reporte de Roles y Paginas</a> </li>
        </ul>
    </div>
</div>
<div class="contentTop">
    <span class="pageTitle">
        <span id="IdAgregarTitle" class="icon-screen"></span> Reporte de Roles y Páginas
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
                                    Nombre de Rol:
                                </label>
                            </div>
                            <div id="DivRolPartial" class="grid3">
                                @Html.DropDownListFor(Function(m) m.Rol.IdRol,
                                                                New SelectList(Model.ListaRol, "IdRol", "NombreRol"),
                                                                New With {
                                                                    .class = "selector",
                                                                    .id = "IdRol",
                                                                    .multiple = "multiple",
                                                                    .style = "width:200px"
                                                                })
                                @Html.HiddenFor(Function(m) m.Rol.IdRol, New With {.id = "IdRolVal"})
                                <div id="ID_MsgRol"></div>
                            </div>
                        </div>

                        <div class="grid4">
                            <div class="grid3">
                                <label class="form-label" for="Estado">
                                    Estado:
                                </label>
                            </div>
                            <div class="grid8">
                                @Html.DropDownListFor(Function(m) m.Estado.IdEstado,
                                New SelectList(Model.ListaEstado, "IdEstado", "Descripcion"),
                                New With
                                {
                                    .class = "selector",
                                    .id = "IdEstado"
                                })
                            </div>
                        </div>

                        <div class="grid4">
                            <div class="grid4">
                                <label class="form-label" for="NombrePag">
                                    Nombre de la Página:
                                </label>
                            </div>
                            <div class="grid8">
                                <div class="ui-widget">
                                    @Html.TextBoxFor(Function(m) m.Pagina.NombrePagina, New With {.id = "NombrePagina", .class = "textinput"})
                                </div>
                                @Html.ValidationMessageFor(Function(m) m.Pagina.NombrePagina)
                            </div>
                        </div>

                    </div>

                    <div class="formRow">
                        <button type="button" name="ActionExportar" id="btnExportar" style="cursor: pointer"
                                class="buttonS bBlue formSubmit group_button ">
                            Exportar Excel
                        </button>

                        <button type="button" name="ActionLimpiar" id="btnLimpiar" style="cursor: pointer"
                                class="buttonS bBlue formSubmit group_button ">
                            Limpiar
                        </button>

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
@Html.Hidden("urlGenerarReporteRolPagina", Url.Action("GenerarReporteRolPagina", "Reportes"))
<script type="text/javascript" src="@Url.Content("~/Scripts/View/ReporteRolPagina.js")">  </script>
<script type="text/javascript" src="@Url.Content("~/Scripts/jqval")">  </script>
<script>
    $(".datepicker").datepicker({
        showOtherMonths: true,
        autoSize: true,
        changeMonth: true,
        changeYear: true,
        appendText: '(DD/MM/AAAA)',
        dateFormat: 'dd/mm/yy'
    });
</script>
