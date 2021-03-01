@ModelType Sodimac.VentaEmpresa.Web.Mvc.MantenimientoViewModel
@Imports Sodimac.VentaEmpresa.Web.Mvc.ParametrosView
@Code
    ViewData("Title") = "Buscar Perfil"
End Code
<div class="breadLine">
    <div class="bc">
        <ul id="breadcrumbs" class="breadcrumbs">
            <li><a href="#">Inicio</a></li>
            <li><a href="#">Mantenedor</a></li>
            <li class="current"><a href="#" title="">Buscar Perfil</a></li>
        </ul>
    </div>
</div>
<div class="contentTop">
    <span class="pageTitle"><span id="IdAgregarTitle" class="icon-screen"></span>Buscar
        Perfil</span>
    <div class="clear">
    </div>
</div>
	       
<div class="wrapper">
    <div class="form" id="frmConsultarPerfil">
        <fieldset>
           <div class="widget fluid" id="divDefinicion">
                <div class="whead"><h6>Criterios de Búsqueda</h6>               
                    <div class="clear"> </div>
                </div>
            <div class="formRow fluid"> 
                <div class="grid6">
                    <div class="grid2"><label>Perfil : </label></div>
                    <div class="grid9 noSearch ">
                        @Html.TextBoxFor(Function(m) m.Perfil.NombrePerfil,
                        New With
                        {
                           .style = "text-transform:uppercase;",
                           .id = "NombrePerfil_AutoComplete",
                           .name = "NombrePerfil_AutoComplete",
                           .onkeypress = "return val_AZ(event),EnterSubmit(event,'btnBuscar');",
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
                <button type="button" name="ActionNuevo" id="btnNuevo" style="cursor:pointer" class="buttonS bBlue formSubmit group_button" onclick = "dialogGestionarPerfil();" >Nuevo</button>
                <button type="button" name="ActionBuscar" id="btnBuscar" style="cursor:pointer" class="buttonS bBlue formSubmit group_button " onclick = "BuscarPerfil();" >Buscar</button>
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
            @Html.Partial(ParametrosPartialView.ConsultarPerfil_PVGrilla, Model)
        </div>
        </div>
        </fieldset>
    </div>
    </div>
    
    <div id="dialogGestionarPerfil" style="display: none" class="j_modal" title="Agregar Perfil">
       @* @Html.Partial(ParametrosPartialView.GestionarPerfil, Model)*@
    </div>
 
    <div id="dialogEliminarPerfilJefe" title="Mensaje de Confirmación">     
        <p>¿Desea eliminar el perfil?</p>   
        <p>Nota : También se eliminará el vendedor asociado</p>        
     </div>
     <div id="dialogEliminarPerfilOtros" title="Mensaje de Confirmación">     
        <p>¿Desea eliminar el perfil?</p>              
     </div>

    
     <div id="dialogRegistrarPerfil" title="Mensaje de Confirmación">
       <p>¿Desea guardar el registro?</p>
     </div>

     <div id="dialogActualizarPerfil" title="Mensaje de Confirmación">
       <p>¿Desea actualizar el registro?</p>
     </div>

     <div id="dialogCancelarRegistro" title="Mensaje de Confirmación">
       <p>¿Desea cancelar el registro?</p>
     </div>
     
     <script type="text/javascript" src="@Url.Content("~/Scripts/View/Mantenimiento.js")"></script>
     <script type="text/javascript" language="javascript">
        $(function () {
            BuscarPerfil();
            InicioJPopUp("#dialogGestionarPerfil", 475, 400, false, "Gestionar Perfil");
            InicioJPopUpConfirm("#dialogRegistrarPerfil", 400, false, "Mensaje de Confirmación", GuardarPerfil);
            InicioJPopUpConfirm("#dialogActualizarPerfil", 400, false, "Mensaje de Confirmación", GuardarPerfil);
            InicioJPopUpConfirm("#dialogEliminarPerfilJefe", 400, false, "Mensaje de Confirmación", EliminarPerfil);
            InicioJPopUpConfirm("#dialogEliminarPerfilOtros", 400, false, "Mensaje de Confirmación", EliminarPerfil);
            InicioJPopUpConfirm("#dialogCancelarRegistro", 400, false, "Mensaje de Confirmación", CancelarRegistro);
        });
    </script>
