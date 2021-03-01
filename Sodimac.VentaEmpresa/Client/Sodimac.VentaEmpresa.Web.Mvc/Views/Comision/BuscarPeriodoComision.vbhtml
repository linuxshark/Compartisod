@ModelType Sodimac.VentaEmpresa.Web.Mvc.ComisionViewModel
@Code
    ViewData("Title") = "Buscar Periodo Comisión"
End Code
<script type="text/javascript" src="/Scripts/View/Comision.js"></script>
@Html.Hidden("ID_Url", Url.Action("_BuscarPeriodoComision"), "Comision")
@Html.Hidden("Url_Listar_Periodo", Url.Action("Listar_Periodos"), "Comision")

<div class="breadLine">
    <div class="bc">
        <ul id="breadcrumbs" class="breadcrumbs">
            <li><a href="#">Inicio</a> </li>
            <li class=""><a href="#">Planificación</a></li>
            <li class="current"><a title="" href="#">Buscar Periodo Comisión</a> </li>
        </ul>
    </div>
</div>
<div class="contentTop">
    <span class="pageTitle"><span id="IdAgregarTitle" class="icon-screen"></span>Buscar
        Periodo Comisión</span>
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
                            Criterios de Búsqueda</h6>
                        <div class="clear">
                        </div>
                    </div>
                    <div class="formRow fluid">
                        <div class="clear">
                        </div>
                    </div>
                    <div class="formRow fluid">
                        <div class="grid6">
                            <div class="grid3">
                                <label class="form-label" for="tipoPersona">
                                    Nombre:</label>
                            </div>
                            <div class="grid9" id="DivPeriodo">
                                @Html.DropDownListFor(Function(m) m.ComisionPeriodo.IdPeriodo,
                                New SelectList(Model.ListaNombrePeriodo, "IdPeriodo", "NombrePeriodo"),
                                "- TODOS -", New With {
                                    .id = "ID_Periodo",
                                    .onkeypress = "EnterSubmit(event,'btnBuscar');"
                                })
                            </div>
                        </div>
                    </div>
                    <div class="formRow fluid">
                        <button class="buttonS bBlue formSubmit group_button" style="cursor: pointer;"
                            id="btnNuevo" onclick="window.location = '@Url.Action("GestionarPeriodoComision", "Comision")'">
                            Nuevo
                        </button>
                        <button class="buttonS bBlue formSubmit group_button" style="cursor: pointer;" id="btnBuscar">
                            Buscar
                        </button>
                        <div class="clear">
                        </div>
                    </div>
                </div>
                <div class="widget">
                    <div class="whead">
                        <div class="whead">
                            <h6>
                                Resultados de Búsqueda</h6>
                        </div>
                        <div class="clear">
                        </div>
                    </div>
                    
                    <div id="contendorgrilla-ListadoNombrePeriodo">
                        @Html.Partial("_BuscarPeriodoComision", Model)
                    </div>
                </div>
            </div>
        </fieldset>
    </div>
</div>

@* <div id="dialogGenerarEscalas" title="Mensaje de Confirmación">
       <p>¿Desea generar las escalas de comisión?</p>
     </div>*@
     
  <div id="dialogEliminarPeriodoComision" title="Mensaje de Confirmación">
       <p>¿Desea eliminar el periodo?</p>
  </div>
<script type="text/javascript" language="javascript">
    $(window).load(function () {
        BuscarPeriodo();
        InicioJPopUpConfirm("#dialogEliminarPeriodoComision", 400, false, "Mensaje de Confirmación", DesactivarPeriodoComision); ;
    });
</script>

 