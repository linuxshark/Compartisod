@ModelType Sodimac.VentaEmpresa.Web.Mvc.ReporteUsuarioViewModel
@Code
    ViewData("Title") = "Reporte Usuario"
End Code

<div class="breadLine">
    <div class="bc">
        <ul id="breadcrumbs" class="breadcrumbs">
            <li><a href="#">Inicio</a> </li>
            <li><a href="#">Reportes</a> </li>
            <li class="current"><a title="" href="#">Reporte de Usuarios</a> </li>
        </ul>
    </div>
</div>
<div class="contentTop">
    <span class="pageTitle">
        <span id="IdAgregarTitle" class="icon-screen"></span> Reporte de Usuarios
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
                            <div class="grid3">
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
                                <label class="form-label" for="tipoPersona">
                                    Fecha Inicio:
                                </label>
                            </div>
                            <div class="grid6">
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
                            <div class="grid6">
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
                    </div>
                    <div class="formRow fluid">
                        <div class="grid4">
                            <div class="grid3">
                                <label class="form-label" for="Estado">
                                    Estado:
                                </label>
                            </div>
                            <div class="grid3">
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
                            <div class="grid3">
                                <label class="form-label" for="Usuario">
                                    Usuario:
                                </label>
                            </div>
                            <div class="grid6">
                                <div class="ui-widget">
                                    @Html.TextBoxFor(Function(m) m.Usuario.UsuarioUsu, New With {
                                                     .id = "Usuario",
                                                     .class = "textinput"
                                                 })
                                    @*.onkeypress = "return validarSoloLetras(event,this)"*@
                                </div>
                                @Html.ValidationMessageFor(Function(m) m.Usuario.UsuarioUsu)
                            </div>
                        </div>

                    </div>
                    <div class="formRow">
                        @*<div class="grid12">
                            </div>
                            <div class="grid12">
                            </div>*@

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
                @*<div id="ID_Partial_ReporteMargenFierro">
                    </div>*@
            </div>
        </fieldset>
    </div>
</div>
@Html.Hidden("urlGenerarReporteUsuario", Url.Action("GenerarReporteUsuario", "Reportes"))
<script type="text/javascript" src="@Url.Content("~/Scripts/View/ReporteUsuario.js")">  </script>
<script type="text/javascript" src="@Url.Content("~/Scripts/jqval")">  </script>
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
