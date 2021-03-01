@ModelType Sodimac.VentaEmpresa.Web.Mvc.MantenimientoViewModel
@Imports Sodimac.VentaEmpresa.Web.Mvc.ParametrosView
@Code
    ViewData("Title") = "Buscar Zona"
End Code
<div class="breadLine">
    <div class="bc">
        <ul id="breadcrumbs" class="breadcrumbs">
            <li><a href="#">Inicio</a></li>
            <li><a href="#">Mantenedor</a></li>
            <li class="current"><a href="#" title="">Buscar Zona</a></li>
        </ul>
    </div>
</div>
<div class="contentTop">
    <span class="pageTitle"><span id="IdAgregarTitle" class="icon-screen"></span>Buscar
        Zona</span>
    <div class="clear">
    </div>
</div>
	       
<div class="wrapper">
    <div class="form" id="frmConsultarZona">
        <fieldset>
           <div class="widget fluid" id="divDefinicion">
                <div class="whead"><h6>Criterios de Búsqueda</h6>               
                    <div class="clear"> </div>
                </div>
            <div class="formRow fluid"> 
                <div class="grid6">
                    <div class="grid2"><label>Zona : </label></div>
                    <div class="grid9 noSearch ">
                        @Html.TextBoxFor(Function(m) m.Zona.NombreZona,
                        New With
                        {
                           .style = "text-transform:uppercase;",
                           .id = "NombreZona_AutoComplete",
                           .name = "NombreZona_AutoComplete",
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
                <button type="button" name="ActionNuevo" id="btnNuevo" style="cursor:pointer" class="buttonS bBlue formSubmit group_button" onclick = "dialogGestionarZona();" >Nuevo</button>
                <button type="button" name="ActionBuscar" id="btnBuscar" style="cursor:pointer" class="buttonS bBlue formSubmit group_button " onclick = "BuscarZona();" >Buscar</button>
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
        <div id="contenedor-grid-Zona">
            @Html.Partial(ParametrosPartialView.ConsultarZona_PVGrilla, Model)
        </div>
        </div>
        </fieldset>
    </div>
    </div>
    
    <div id="dialogGestionarZona" style="display: none" class="j_modal" title="Agregar Zona">
       @* @Html.Partial(ParametrosPartialView.GestionarZona, Model)*@
    </div>

    <div id="dialogEliminarZona" title="Mensaje de Confirmación">
       <p>¿Desea eliminar la Zona?</p>
     </div>

     <div id="dialogRegistrarZona" title="Mensaje de Confirmación">
       <p>¿Desea guardar el registro?</p>
     </div>

     <div id="dialogActualizarZona" title="Mensaje de Confirmación">
       <p>¿Desea actualizar el registro?</p>
     </div>

     <div id="dialogCancelarRegistroZona" title="Mensaje de Confirmación">
       <p>¿Desea cancelar el registro?</p>
     </div>
     
     <script type="text/javascript" src="@Url.Content("~/Scripts/View/Mantenimiento.js")"></script>
     <script type="text/javascript" language="javascript">
        $(function () {
            BuscarZona();
            InicioJPopUp("#dialogGestionarZona", 480, 400, false, "Gestionar Zona");
            InicioJPopUpConfirm("#dialogRegistrarZona", 400, false, "Mensaje de Confirmación", GuardarZona);
            InicioJPopUpConfirm("#dialogActualizarZona", 400, false, "Mensaje de Confirmación", GuardarZona);
            InicioJPopUpConfirm("#dialogEliminarZona", 400, false, "Mensaje de Confirmación", EliminarZona);
            InicioJPopUpConfirm("#dialogCancelarRegistroZona", 400, false, "Mensaje de Confirmación", CancelarRegistroZona);
        });
    </script>
