@ModelType Sodimac.VentaEmpresa.Web.Mvc.Models.ViewModel.FeriadosViewModel
@Imports Sodimac.VentaEmpresa.Web.Mvc.ParametrosView
@Code
    ViewData("Title") = "Buscar Feriados"
End Code

<div class="breadLine">
    <div class="bc">
        <ul id="breadcrumbs" class="breadcrumbs">
            <li><a href="#">Inicio</a></li>
            <li><a href="#">Mantenedor</a></li>
            <li class="current"><a href="#" title="">Buscar Feriados</a></li>
        </ul>
    </div>
</div>
<div class="contentTop">
    <span class="pageTitle"><span id="IdAgregarTitle" class="icon-screen"></span>Buscar Feriados</span>
    <div class="clear"></div>
</div>

    @Html.Hidden("UrlEliminar", Url.Action("EliminarFeriado", "Mantenimiento"))
    @Html.Hidden("UrlNuevo", Url.Action("NuevoFeriado", "Mantenimiento"))
    @Html.Hidden("UrlEditar", Url.Action("EditarFeriado", "Mantenimiento"))

<div class="wrapper">
    <div class="form" id="frmConsultarFeriados">
        @Using (Html.BeginForm("ConsultaFeriados", "Mantenimiento", FormMethod.Post, New With {.id = "FrmFeriados"}))
            @<fieldset>
                <div class="widget fluid" id="divDefinicion">
                    <div class="whead">
                        <h6>Criterios de Búsqueda</h6>
                        <div class="clear"> </div>
                    </div>
                    <div class="formRow fluid">
                        <div class="grid4">
                            @Html.LabelFor(Function(m) m.Feriados.Mes, New With {.class = "grid3"})
                            <div class="grid8">
                                @Html.DropDownListFor(Function(m) m.Feriados.BusqMes,
                                         New SelectList(Model.ListaMes, "IdMes", "Mes"),
                                         New With {
                                            .id = "Id_Mes",
                                            .class = "textinput selector",
                                            .multiple = "multiple"
                                         })
                                @Html.HiddenFor(Function(x) x.MesMulti)
                            </div>
                        </div>
                        <div class="grid4">
                            @Html.LabelFor(Function(m) m.Feriados.Anio, New With {.class = "grid3"})
                            <div class="grid8">
                                @Html.TextBoxFor(Function(m) m.Feriados.BusqModalidad,
                                         New With
                                         {
                                         .style = "text-transform:uppercase",
                                         .class = "textinput"
                                         })
                            </div>
                        </div>
                        <div class="grid4">
                            @Html.LabelFor(Function(m) m.Feriados.Activo, New With {.class = "grid3"})
                            <div class="grid9">
                                @Html.DropDownListFor(Function(m) m.Feriados.BusqEstado,
                                         New SelectList(Model.ListaEstado, "IdActivo", "Descripcion"),
                                         " TODOS ")
                            </div>
                        </div>
                    </div>
                    <div class="formRow">
                        <button type="button" name="ActionNuevo" id="btnNuevo" style="cursor:pointer" class="buttonS bBlue formSubmit group_button">Nuevo</button>
                        <button type="button" name="ActionBuscar" id="btnBuscar" style="cursor:pointer" class="buttonS bBlue formSubmit group_button">Buscar</button>
                        <br class="clear" />
                        <div class="clear"></div>
                    </div>
                </div>
            </fieldset>
        End Using
    </div>
</div>
<div class="wrapper">
    <div class="form">
        <fieldset>
            <div class="widget fluid" id="divDefinicion4">
                <div class="whead">
                    <h6>Resultados de Búsqueda</h6>
                    <div class="clear">
                    </div>
                </div>
                <div id="contenedor-grid">
                    @Html.Partial("_GridFeriados", Model)
                </div>
            </div>
        </fieldset>
    </div>
</div>

<script type="text/javascript" src="@Url.Content("~/Scripts/View/Feriados.js")"></script>

<div id="GestionarFeriado" style="display: none" class="j_modal" title="Gestionar Feriado"></div>

<div id="dialogRegistrar" title="Mensaje de Confirmación">
    <p>¿Desea registrar?</p>
</div>
<div id="dialogEditar" title="Mensaje de Confirmación">
    <p>¿Desea guardar?</p>
</div>
<div id="dialogInformacionCancelar" title="Mensaje de Confirmación">
    <p>
        ¿Desea cancelar el registro?
    </p>
</div>