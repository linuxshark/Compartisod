@ModelType Sodimac.VentaEmpresa.Web.Mvc.MantenimientoViewModel
@Imports Sodimac.VentaEmpresa.Web.Mvc.ParametrosView
@Code
    ViewData("Title") = "Gestionar Perfil"
End Code

@Using (Html.BeginForm("GestionarPerfil_", "Mantenimiento", FormMethod.Post, New With {.id = "frmGestionarPerfil"}))
    @Html.AntiForgeryToken
@<div id="ID_CopiarCurso">    
    <div class="wrapper">
        <div class="form">
            <fieldset>
                <div class="widget fluid" id="divDefinicion">
                    <div class="whead"><h6>Definición del Perfil</h6>               
                        <div class="clear"> </div>
                    </div>    
                <div class="formRow fluid">
                    <div class="grid12">               
                        <div class="grid4" style="padding-top:-30px"><label>Perfil :<span class="req">*</span></label></div>
                            <div class="grid8">
                                @Html.TextBoxFor(Function(m) m.Perfil.NombrePerfil,
                                New With
                                {
                                    .id = "NombrePerfil",
                                    .name = "NombrePerfil",
                                    .onkeypress = "return val_AZ(event)",
                                    .maxLength = "50",
                                    .class = "textinput",
                                    .style = "text-transform:uppercase;"
                                })                       
                                @Html.ValidationMessageFor(Function(m) m.Perfil.NombrePerfil, "", New With {.class = "reqizq"})
                            </div>             
                        </div>
                    </div>

                    <div class="formRow fluid">
                    <div class="grid12">               
                        <div class="grid4" style="padding-top:-30px"><label>Reporta A:</label></div>
                            <div class="grid4">
                                @Html.DropDownListFor(Function(m) m.Perfil.IdPerfilSuperior,
                                New SelectList(Model.ListaPerfil, "IdPerfil", "NombrePerfil"),
                                "- NINGUNO -",
                                New With {
                                    .id = "ID_PerfilSuperior",
                                    .style = "cursor:default;",
                                    .class = "ignorefield"
                                })                                
                            </div>             
                        </div>
                    </div>
                    <div class="formRow fluid">
                    <div class="grid12">
                        <div class="grid4" style="padding-top:-30px" ><label> Tipo :<span class="req">*</span></label> </div>
                        <div class="grid4">
                             @Html.DropDownListFor(Function(m) m.Perfil.EmpleadoPerfil.IdPerfil,
                             New SelectList(Model.ListaEmpleadoPerfil, "IdPerfil", "DescripcionPerfil"),
                             "-NINGUNO-",
                             New With {
                                 .id = "ID_PerfilTipo",
                                 .onchange = "ShowHideTextBox();",
                                 .style = "cursor:default;"
                             })
                             @Html.ValidationMessageFor(Function(m) m.Perfil.EmpleadoPerfil.IdPerfil, "", New With {.class = "reqizq"}) 
                        </div>
                    </div>
                    </div>
                    <div class="formRow fluid">
                    <div id="divmostrarid" class="grid12"  style="display: none">
                       <div class="grid4" style="padding-top:-30px">
                            <label>Perfil Inferior:<span class="req">*</span></label>
                       </div>
                       <div class="grid8">
                            @Html.TextBoxFor(Function(m) m.Perfil.NombrePerfilInferior,
                                             New With {
                                                        .id = "NombrePerfilInferior",
                                                        .onkeypress = "return val_AZ(event)",
                                                        .maxLength = "50",
                                                        .class = "textinput",
                                                        .style = "text-transform:uppercase;"
                                                 })  
                            @Html.ValidationMessageFor(Function(m) m.Perfil.NombrePerfilInferior, "", New With {.class = "reqizq"})          
                        </div>                        
                    </div>
                    </div> 
                    <div class="formRow" style="margin-right:10px">
                        <button type="button" name="ActionCancelar" id="btnCancelar" style="cursor:pointer" class="buttonS bBlue formSubmit group_button" onclick="DialogCancelarRegistro();" >Cancelar</button>
                        <button type="button" name="ActionAgregar" id="btnAgregarA" style="cursor:pointer" class="buttonS bBlue formSubmit group_button " onclick="RegistrarPerfil();" >Guardar</button>
                        <br class="clear"/> 
                        <div class="clear"></div>
                    </div>
                </div>
            </fieldset>
        </div>
    </div>
 </div>
    @Html.HiddenFor(Function(m) m.Perfil.IdPerfil, New With {.id = "HD_IdPerfil"})
  End Using
