@ModelType Sodimac.VentaEmpresa.Web.Mvc.AccountViewModel
@Code
    ViewData("Title") = "Consultar Rol"
End Code

    <!-- Breadcrumbs line -->
    <div class="breadLine">
        <div class="bc">
            <ul id="breadcrumbs" class="breadcrumbs">
                <li><a href="#">Seguridad</a></li>
                <li><a href="#">Consultar Rol</a></li>
                <li class="current"><a href="#" title="" ></a></li>
            </ul>
        </div>        
    </div>
	
    <div id="ModelEditarRol" style="display:none"  class="j_modal" title="Editar Rol"></div>
    <div id="ModelAgregarRol" style="display:none"  class="j_modal" title="Agregar Rol">@Html.Partial("Agregar", Model)</div>
    <div class="contentTop">
        <span class="pageTitle"><span class="icon-screen" id="IdAgregarTitle"></span>@ViewBag.Title</span>
        <div class="clear"></div>
    </div>       
<div class="wrapper">
    <div class="form">
        <fieldset>
           <div class="widget fluid" id="divDefinicion">
                <div class="whead"><h6>Criterios de Búsqueda</h6>               
                    <div class="clear"> </div>
                </div>
            <div class="formRow fluid"> 
                <div class="grid6">
                    <div class="grid3"><label>Rol : </label></div>
                    <div class="grid9 noSearch ">
                        @Html.TextBoxFor(Function(m) m.Rol.NombreRol,
                        New With
                        {
                           .style = "text-transform:uppercase;",
                           .id = "Nombre",
                           .name = "Nombre",
                           .onkeypress = "return val_AZ(event)",
                           .onCopy = "return false;",
                           .onPaste = "return false;",
                           .maxLength = "50",
                           .class = "textinput"
                         })
                        <br class="clear"/> 
                        <div id="msg_IdProTip"></div>
                    </div>
                    <div class="clear"></div>
                </div>

                <div class="grid6">
                    <div class="grid3"><label>Estado : </label></div>
                        <div class="grid9 noSearch">
                            @Html.DropDownListFor(Function(m) m.Rol.EstadoId,
                                New SelectList(Model.ListaEstados, "IdTabGen", "DescripcionLargaTabGen"),
                                "- TODOS -",
                                New With {
                                    .class = "textinput select",
                                    .id = "ActivoRol",
                                    .name = "ActivoRol"
                                })                 
                             <br class="clear"/> 
                             <div id="msg_IdEquMod"></div>     
                        </div>                    
                        <div class="clear"></div>
                </div>
            </div>

            <div class="formRow">
                <button type="button" name="ActionCancelar" id="btnCancelar" style="cursor:pointer" class="buttonS bBlue formSubmit group_button" onclick = "MostrarDialogAgregarRol();" >Nuevo</button>
                <button type="button" name="ActionAgregar" id="btnBuscar" style="cursor:pointer" class="buttonS bBlue formSubmit group_button " onclick = "BuscarRol('@Url.Action("ConsultarRol_PVGrilla", "Account")');" >Buscar</button>
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
        <div id="contenedor-grid-Rol">
            @Html.Partial("ConsultarRol_PVGrilla",Model)
        </div>
        </div>
        </fieldset>
    </div>
    </div>

    <div id="dialogInformacionDesactivar" title="Mensaje de Confirmación">
       <p>¿Desea desactivar el rol?</p>
     </div>

     <div id="dialogInformacionGuardar" title="Mensaje de Confirmación">
       <p>¿Desea guardar el registro?</p>
     </div>

     <div id="dialogInformacionCancelar" title="Mensaje de Confirmación">
           <p>¿Desea cancelar el registro?</p>
     </div>

     <div id="dialogInformacionResultado" title="Confirmación!">
     </div>

      @Html.Hidden("IdUrl_RolDestino", Url.Action("ConsultarRol_PVGrilla", "Account"))

    <script type="text/javascript" src="@Url.Content("~/Scripts/View/Rol.js")"></script>

    <script type="text/javascript" language="javascript">
        $(window).load(function () {
            BuscarRol('@Url.Action("ConsultarRol_PVGrilla", "Account")')
        });
    </script>
