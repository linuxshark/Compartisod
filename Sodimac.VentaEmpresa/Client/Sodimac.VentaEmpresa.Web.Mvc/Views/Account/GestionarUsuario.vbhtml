@ModelType Sodimac.VentaEmpresa.Web.Mvc.AccountViewModel
@Code
     ViewData("Title") =  "Gestionar Usuario"
End Code

    <!-- Breadcrumbs line -->
    <div class="breadLine">
        <div class="bc">
            <ul id="breadcrumbs" class="breadcrumbs">
                <li><a href="#">Seguridad</a></li>
                <li><a href="#">Gestionar Usuario</a></li>
                <li class="current"><a href="#" title="" ></a></li>
            </ul>
        </div>        
    </div>	
    <div id="ModelEditarUsuario" style="display:none"  class="j_modal" title="Editar Usuario"></div>
    <div id="ModelAgregarUsuario" style="display:none"  class="j_modal" title="Agregar Usuario">@Html.Partial("RegistrarUsuario", Model)</div>
    <div class="contentTop">
        <span class="pageTitle"><span class="icon-screen" id="IdAgregarTitle"></span>@ViewBag.Title</span>
        <div class="clear"></div>
    </div>     
<!--end titulo -->
    
<div class="wrapper">
    <div class="form">
        <fieldset>
           <div class="widget fluid" id="divDefinicion">
                <div class="whead"><h6>Criterios de Búsqueda</h6>               
                    <div class="clear"> </div>
                </div>
                <div class="formRow fluid"> 
                    <div class="grid6">
                        <div class="grid3"><label>Usuario : </label></div>
                            <div class="grid9 noSearch ">
                                @Html.TextBoxFor(Function(m) m.Usuario.UsuarioUsu,
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
                            <div class="grid9">
                                @Html.DropDownListFor(Function(m) m.Usuario.ActivoUsu,
                                New SelectList(Model.ListaEstados, "IdTabGen", "DescripcionLargaTabGen"),
                                "- TODOS -",
                                New With {
                                    .class = "selector",
                                    .id = "ActivoUsu",
                                    .name = "ActivoUsu"
                                })                     
                                <br class="clear"/> 
                                <div id="msg_IdEquMod"></div>     
                            </div>                    
                            <div class="clear"></div>
                    </div>
                </div>
                <div class="formRow">
                    <button type="button" 
                            name="ActionCancelar" 
                            id="btnCancelar" 
                            style="cursor:pointer" 
                            class="buttonS bBlue formSubmit group_button" 
                            onclick = "MostrarDialogAgregarUsuario();" >Nuevo</button>
                    <button type="button" 
                            name="ActionAgregar" 
                            id="btnBuscar" 
                            style="cursor:pointer" 
                            class="buttonS bBlue formSubmit group_button " 
                            onclick = "BuscarUsuario('@Url.Action("ConsultarUsuario_PVGrilla", "Account")');" >Buscar</button>
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
                    <div class="whead">
                        <h6>Resultados de Búsqueda</h6>               
                        <div class="clear">
                        </div>
                    </div>            
                    <div id="contenedor-grid-Usuario">
                        @Html.Partial("ConsultarUsuario_PVGrilla",Model)
                    </div>
                </div>
            </fieldset>
        </div>
    </div>

    <div id="dialogInformacionDesactivar" title="Mensaje de Confirmación">
       <p>¿Desea desactivar el Usuario?</p>
     </div>

     <div id="dialogInformacionGuardar" title="Mensaje de Confirmación">
       <p>¿Desea guardar el registro?</p>
     </div>

     <div id="dialogInformacionCancelar" title="Mensaje de Confirmación">
           <p>¿Desea cancelar el registro?</p>
     </div>

     <div id="dialogInformacionResultado" title="Confirmación!">
     </div>
     @Html.Hidden("IdUrl_UsuarioDestino", Url.Action("ConsultarUsuario_PVGrilla", "Account"))

    <script type="text/javascript" src="@Url.Content("~/Scripts/View/Usuario.js")"></script>

    <script type="text/javascript" language="javascript">
        $(window).load(function () {
            BuscarUsuario('@Url.Action("ConsultarUsuario_PVGrilla", "Account")')
        });
    </script>

