@ModelType Sodimac.VentaEmpresa.Web.Mvc.MantenimientoViewModel
@Imports Sodimac.VentaEmpresa.Web.Mvc.ParametrosView
@Code
    ViewData("Title") = "Buscar Grupo"
End Code
<div class="breadLine">
    <div class="bc">
        <ul id="breadcrumbs" class="breadcrumbs">
            <li><a href="#">Inicio</a></li>
            <li><a href="#">Mantenedor</a></li>
            <li class="current"><a href="#" title="">Buscar Grupo</a></li>
        </ul>
    </div>
</div>
<div class="contentTop">
    <span class="pageTitle"><span id="IdAgregarTitle" class="icon-screen"></span>Buscar
        Grupo</span>
    <div class="clear">
    </div>
</div>
	       
<div class="wrapper">
    <div class="form" id="frmConsultarGrupo">
        <fieldset>
           <div class="widget fluid" id="divDefinicion">
                <div class="whead"><h6>Criterios de Búsqueda</h6>               
                    <div class="clear"> </div>
                </div>
            <div class="formRow fluid"> 
                <div class="grid6">
                    <div class="grid2"><label>Grupo : </label></div>
                    <div class="grid9 noSearch ">
                       @Html.TextBoxFor(Function(m) m.Grupo.NombreGrupo,
                        New With
                        {
                           .style = "text-transform:uppercase;",
                           .id = "NombreGrupo_AutoComplete",
                           .name = "NombreGrupo_AutoComplete",
                           .onkeypress = "return val_AZ(event);",
                           .maxLength = "50",
                           .class = "textinput"
                         })

                         <small class="note" style="margin-left:0px">Se debe ingresar como mínimo tres caracteres</small>
                         <br class="clear"/>                        
                    </div>
                    <div class="clear"></div>
                </div>             
            </div>

            <div class="formRow">
                <button type="button" name="ActionNuevo" id="btnNuevo" style="cursor:pointer" class="buttonS bBlue formSubmit group_button" onclick = "dialogGestionarGrupo();" >Nuevo</button>
                <button type="button" name="ActionBuscar" id="btnBuscar" style="cursor:pointer" class="buttonS bBlue formSubmit group_button " onclick = "BuscarGrupo();" >Buscar</button>
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
        <div id="contenedor-grid-Grupo">
              @Html.Partial(ParametrosPartialView.ConsultarGrupo_PVGrilla, Model)
        </div>
        </div>
        </fieldset>
    </div>
    </div>
        
    <div id="dialogGestionarGrupo" style="display: none" class="j_modal" title="Agregar Grupo">
    </div>

    <div id="dialogEliminarGrupo" title="Mensaje de Confirmación">
       <p>¿Desea eliminar el Grupo?</p>
     </div>

     <div id="dialogCancelarRegistroGrupo" title="Mensaje de Confirmación">
       <p>¿Desea cancelar el registro?</p>
     </div>
     
     <script type="text/javascript" src="@Url.Content("~/Scripts/View/Mantenimiento.js")"></script>
     <script type="text/javascript" language="javascript">
         $(function () {
             BuscarGrupo();
             InicioJPopUpConfirm("#dialogEliminarGrupo", 350, false, "Mensaje de Confirmación", EliminarGrupo);
             InicioJPopUpConfirm("#dialogCancelarRegistroGrupo", 350, false, "Mensaje de Confirmación", CancelarRegistroGrupo);
         });
    </script>


