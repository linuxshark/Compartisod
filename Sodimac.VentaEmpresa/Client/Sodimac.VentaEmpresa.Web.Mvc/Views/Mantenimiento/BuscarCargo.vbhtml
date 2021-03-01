@ModelType Sodimac.VentaEmpresa.Web.Mvc.MantenimientoViewModel
@Imports Sodimac.VentaEmpresa.Web.Mvc.ParametrosView
@Code
    ViewData("Title") = "Buscar Cargo"
End Code
<div class="breadLine">
    <div class="bc">
        <ul id="breadcrumbs" class="breadcrumbs">
            <li><a href="#">Inicio</a></li>
            <li><a href="#">Mantenedor</a></li>
            <li class="current"><a href="#" title="">Buscar Cargo</a></li>
        </ul>
    </div>
</div>
<div class="contentTop">
    <span class="pageTitle"><span id="IdAgregarTitle" class="icon-screen"></span>Buscar
        Cargo</span>
    <div class="clear">     
    </div>
</div>
	       
<div class="wrapper">
    <div class="form" id="frmConsultarCargo">
        <fieldset>
           <div class="widget fluid" id="divDefinicion">
                <div class="whead"><h6>Criterios de Búsqueda</h6>               
                    <div class="clear"> </div>
                </div>
            <div class="formRow fluid"> 
                <div class="grid6">
                    <div class="grid2"><label>Cargo : </label></div>
                    <div class="grid6 noSearch ">
                        @Html.TextBoxFor(Function(m) m.Cargo.NombreCargo,
                        New With
                        {
                           .style = "text-transform:uppercase;",
                           .id = "NombreCargo_AutoComplete",
                           .name = "NombreCargo_AutoComplete",
                           .onkeypress = "return val_AZ(event),EnterSubmit(event,'btnBuscar');",
                           .maxLength = "50",
                           .class = "textinput"
                         })
                         <small class="note" style="margin-left:0px">Se debe ingresar como mínimo tres caracteres</small>
                        <br class="clear"/>                         
                    </div>
                    <div class="clear"></div>
                </div> 
                <div class="grid6">
                            <div class="grid2">
                                <label class="form-label" for="tipoPersona">
                                    Perfil:</label>
                            </div>
                            <div class="grid9">
                                @Html.DropDownListFor(Function(m) m.Perfil.IdPerfil,
                                New SelectList(Model.ListaPerfil, "IdPerfil", "NombrePerfil"),
                                "- TODOS -", New With {
                                    .id = "ID_IdPerfil",
                                    .onkeypress = "EnterSubmit(event,'btnBuscar');"
                                })
                            </div>
                        </div>            
            </div>           
            <div class="formRow">
                <button type="button" name="ActionNuevo" id="btnNuevo" style="cursor:pointer" class="buttonS bBlue formSubmit group_button" onclick = "dialogGestionarCargo();" >Nuevo</button>
                <button type="button" name="ActionBuscar" id="btnBuscar" style="cursor:pointer" class="buttonS bBlue formSubmit group_button " onclick = "BuscarCargo();" >Buscar</button>
                <br class="clear"/> 
                <div class="clear"></div>
            </div>
        </div>
    </fieldset>
</div>
</div>
    <div class="wrapper">
    <div class="form">
        <fieldset>
           <div class="widget fluid" id="divDefinicion4">
                <div class="whead"><h6>Resultados de Búsqueda</h6>               
                    <div class="clear">
                    </div>
                </div>            
        <div id="contenedor-grid-Perfil">
            @Html.Partial(ParametrosPartialView.ConsultarCargo_PVGrilla, Model)
        </div>
        </div>
        </fieldset>
    </div>
    </div>
    
    <div id="dialogGestionarCargo" style="display: none" class="j_modal" title="Agregar Cargo">      
    </div>

    <div id="dialogEliminarCargoJefe" title="Mensaje de Confirmación">
       <p>¿Desea eliminar el cargo?</p>
       <p>Nota : También se eliminará el cargo del vendedor asociado</p> 
     </div>
      <div id="dialogEliminarCargoOtros" title="Mensaje de Confirmación">
       <p>¿Desea eliminar el cargo?</p>       
     </div>

     <div id="dialogRegistrarCargo" title="Mensaje de Confirmación">
       <p>¿Desea guardar el registro?</p>
     </div>

     <div id="dialogActualizarCargo" title="Mensaje de Confirmación">
       <p>¿Desea actualizar el registro?</p>
     </div>

     <div id="dialogCancelarRegistroCargo" title="Mensaje de Confirmación">
       <p>¿Desea cancelar el registro?</p>
     </div>
     
     <script type="text/javascript" src="@Url.Content("~/Scripts/View/Mantenimiento.js")"></script>
     <script type="text/javascript" language="javascript">
        $(function () {
            BuscarCargo();
            InicioJPopUp("#dialogGestionarCargo", 500, 490, false, "Gestionar Cargo");
            InicioJPopUpConfirm("#dialogRegistrarCargo", 490, false, "Mensaje de Confirmación", GuardarCargo);
            InicioJPopUpConfirm("#dialogActualizarCargo", 490, false, "Mensaje de Confirmación", GuardarCargo);
            InicioJPopUpConfirm("#dialogEliminarCargoJefe", 490, false, "Mensaje de Confirmación", EliminarCargo);
            InicioJPopUpConfirm("#dialogEliminarCargoOtros", 490, false, "Mensaje de Confirmación", EliminarCargo);
            InicioJPopUpConfirm("#dialogCancelarRegistroCargo", 490, false, "Mensaje de Confirmación", CancelarRegistroCargo);
        });
    </script>
