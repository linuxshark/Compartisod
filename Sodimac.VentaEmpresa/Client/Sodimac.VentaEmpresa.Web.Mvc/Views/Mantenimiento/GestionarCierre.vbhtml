@ModelType Sodimac.VentaEmpresa.Web.Mvc.CierreViewModel

@Code
    ViewData("Title") = "GestionarCierre"
End Code

<div class="breadLine">
    <div class="bc">
        <ul id="breadcrumbs" class="breadcrumbs">
            <li><a href="#">Inicio</a></li>
            <li><a href="#">Mantenedor</a></li>
            <li class="current"><a href="#" title="">Calendario de Cierre</a></li>
        </ul>
    </div>
</div>
<div class="contentTop">
    <span class="pageTitle"><span id="IdAgregarTitle" class="icon-screen"></span>Buscar Fecha de Cierre</span>
    <div class="clear"></div>
</div> 
<div class="wrapper">
    <div class="form" id="frmConsultarCierre">
        @Using (Html.BeginForm("ConsultarCierre", "Mantenimiento", FormMethod.Post, New With {.id = "FrmCierre"}))
            @<fieldset>
                <div class="widget fluid" id="divDefinicion">
                    <div class="whead">
                        <h6>Criterios de Búsqueda</h6>
                        <div class="clear"> </div>
                    </div>
                    <div class="formRow fluid">
                        <div class="grid4">
                            @Html.LabelFor(Function(m) m.Cierre.Año, New With {.class = "grid2"})
                            <div class="grid8">
                                @Html.DropDownListFor(Function(m) m.Cierre.Año,
                                         New SelectList(Model.ListaAño, "IdAño", "Año"))
                            </div>
                        </div>
                        <div class="grid4">
                            @Html.LabelFor(Function(m) m.Cierre.Mes, New With {.class = "grid2"})
                            @Html.DropDownListFor(Function(m) m.Cierre.Mes,
                                         New SelectList(Model.ListaMes, "IdMes", "Mes"), " TODOS ")
                        </div>
                        <div class="grid4">
                            @Html.LabelFor(Function(m) m.Cierre.FechaCierre, New With {.class = "grid5"})
                            <div class="grid5">
                                @Html.TextBoxFor(Function(m) (m.Cierre.FechaCierre),
                                                 New With {
                                                 .id = "ID_FechaCierre",
                                                 .class = "textinput datepickerAkiraMax2",
                                                 .maxlength = "10",
                                                 .Value = Format("{0:d}", " ")
                                                 })
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
                    @Html.Partial("_GridCierre", Model)
                </div>
            </div>
        </fieldset>
    </div>
</div>


    <div id="GestionarCierre" style="display: none" class="j_modal" title="Gestionar Cierre"></div>
    <div id="dialogRegistrar" title="Mensaje de Confirmación">
        <p>¿Desea guardar el registro?</p>
    </div>
    <div id="dialogCancelar" title="Mensaje de Confirmación">
        <p> ¿Desea cancelar el registro? </p>
    </div>
    <div id="dialogEliminar" title="Mensaje de Confirmación">
        <p>¿Desea eliminar el registro?</p>
    </div>
    <script>
        var Url = {
            Nuevo: '@Url.Action("RegistrarCierre", "Mantenimiento")',
            Eliminar: '@Url.Action("EliminarCierre", "Mantenimiento")'
            }
    </script>

    @Scripts.Render(
            "~/Scripts/View/Cierre.js"
        )

    <script type="text/javascript" language="javascript">
        var navegador = navigator.appName
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
 


