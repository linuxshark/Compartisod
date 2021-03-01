@ModelType Sodimac.VentaEmpresa.Web.Mvc.MantenimientoViewModel
@Imports Sodimac.VentaEmpresa.Web.Mvc.ParametrosView
<div class="breadLine">
    <div class="bc">
        <ul id="breadcrumbs" class="breadcrumbs">
            <li><a href="#">Inicio</a></li>
            <li><a href="#">Mantenedor</a></li>
            <li class="current"><a href="#" title="">Buscar Sucursal</a></li>
        </ul>
    </div>
</div>

<div class="contentTop">
    <span class="pageTitle"><span id="IdAgregarTitle" class="icon-screen"></span>Buscar
        Sucursal </span>
    <div class="clear">     
    </div>
</div>
<div class="wrapper">
    <div class="form" id="frmConsultarSucursal">
        <fieldset >
            <div class="widget fluid" id="divDefinicion">
                 <div class="whead"><h6>Criterios de Búsqueda</h6>               
                    <div class="clear"> </div>
                </div>
                <div class="formRow fluid">
                     <div class="grid6">
                           <div class="grid2"><label>Sucursal : </label></div> 
                           <div class="grid6 noSearch ">
                            @Html.TextBoxFor(Function(m) m.SucursalMantenimiento.Descripcion,
                                             New With {
                                                   .style = "text-transform:uppercase;",
                                                   .id = "NombreSucursal_AutoComplete",
                                                   .name = "NombreSucursal_AutoComplete",
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
                                    Zona:</label>
                            </div>
                             <div class="grid9">
                                @Html.DropDownListFor(Function(m) m.Zona.IdZona,
                                New SelectList(Model.ListaZonaMantenimiento, "IdZona", "NombreZona"),
                                                "- TODOS -", New With {
                                                                     .id = "ID_IdZona",
                                                                     .onkeypress = "EnterSubmit(event,'btnBuscar');"
                                                    }) 
                             </div>
                     </div>
                 </div>
                <div class="formRow">
                <button type="button" name="ActionNuevo" id="btnNuevo" style="cursor:pointer" class="buttonS bBlue formSubmit group_button" onclick = "dialogGestionarSucursal();" >Nuevo</button>
                <button type="button" name="ActionBuscar" id="btnBuscar" style="cursor:pointer" class="buttonS bBlue formSubmit group_button " onclick = "BuscarSucursal();" >Buscar</button>
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
           @Html.Partial(ParametrosPartialView.ConsultarSucursal_PVGrilla, Model)
        </div>
        </div>
        </fieldset>
    </div>
    </div>
 <div id="dialogGestionarSucursal" style="display: none" class="j_modal" title="Agregar Cargo">      
    </div>

    <div id="dialogEliminarSucursal" title="Mensaje de Confirmación">
       <p>¿Desea eliminar la Sucursal?</p>
       
     </div>

     <div id="dialogRegistrarSucursal" title="Mensaje de Confirmación">
       <p>¿Desea guardar el registro?</p>
     </div>

     <div id="dialogActualizarSucursal" title="Mensaje de Confirmación">
       <p>¿Desea actualizar el registro?</p>
     </div>

     <div id="dialogCancelarRegistroSucursal" title="Mensaje de Confirmación">
       <p>¿Desea cancelar el registro?</p>
     </div>
     <script type="text/javascript" src="@Url.Content("~/Scripts/View/Mantenimiento.js")"></script>
     <script type="text/javascript" language="javascript">
         $(function () {
             BuscarSucursal();
             InicioJPopUp("#dialogGestionarSucursal", 620, 600, false, "Gestionar Sucursal");
             InicioJPopUpConfirm("#dialogRegistrarSucursal", 490, false, "Mensaje de Confirmación", GuardarSucursal)
             InicioJPopUpConfirm("#dialogActualizarSucursal", 490, false, "Mensaje de Confirmación", GuardarSucursal);
             InicioJPopUpConfirm("#dialogEliminarSucursal", 490, false, "Mensaje de Confirmación", EliminarSucursal);
             InicioJPopUpConfirm("#dialogCancelarRegistroSucursal", 490, false, "Mensaje de Confirmación", CancelarRegistroSucursal);
         });
    </script>