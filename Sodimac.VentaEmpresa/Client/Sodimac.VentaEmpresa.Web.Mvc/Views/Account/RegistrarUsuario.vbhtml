@modeltype Sodimac.VentaEmpresa.Web.Mvc.AccountViewModel
@Code
    ViewData("Title") = "Agregar Rol"
End Code

@Using (Html.BeginForm("AgregarUsuario", "Account", FormMethod.Post, New With {.id = "frmAgregarUsuario"}))
@Html.AntiForgeryToken 
@<div id="ID_CopiarCurso">
    
<input type="hidden" value="@Url.Action("AgregarUsuario", "Account")" id="AgregarUsu_URL" />
<div class="wrapper">
    <div class="form">
        <fieldset>
           <div class="widget fluid" id="divDefinicion">
                <div class="whead"><h6>Registro de Usuario</h6>               
                <div class="clear">
            </div>
    </div>    
            <div class="formRow fluid"> 

                <div class="grid12">
                    
                    <div class="grid2" style="padding-top:-30px"><label>Usuario :<span class="red">*</span></label></div>
                    <div class="grid9 noSearch ">
                        @Html.TextBoxFor(Function(m) m.Usuario.UsuarioUsu,
                                    New With
                                    {
                                        .style = "text-transform:uppercase;",
                                        .id = "UsuarioUsu",
                                        .name = "UsuarioUsu",
                                        .onkeypress = "return val_AZ(event)",
                                        .onblur = "return ValidarNUll('UsuarioUsu');",
                                        .onCopy = "return false;",
                                        .onPaste = "return false;",
                                        .maxLength = "50",
                                        .class = "textinput"
                                    })                        
                        <div id="msgUsuarioUsu"></div>
                    </div>              
                </div>
            </div>
            <div class="formRow fluid"> 

                <div class="grid12">
               
                    <div class="grid2" style="padding-top:-30px"><label>Nombre :<span class="red">*</span></label></div>
                    <div class="grid9 noSearch ">
                        @Html.TextBoxFor(Function(m) m.Usuario.UsuarioNom,
                                    New With
                                    {
                                        .style = "text-transform:uppercase;",
                                        .id = "UsuarioNom",
                                        .name = "UsuarioNom",
                                        .onkeypress = "return val_AZ(event)",
                                        .onblur = "return ValidarNUll('UsuarioNom');",
                                        .onCopy = "return false;",
                                        .onPaste = "return false;",
                                        .maxLength = "50",
                                        .class = "textinput"
                                    })                        
                        <div id="msgUsuarioNom"></div>
                    </div>              
                </div>
            </div>

            <div class="formRow fluid"> 
                <div class="grid12">               
                    <div class="grid2"><label style="margin:0px; padding:0px;line-height:14px">Estado :</label></div>
                    <div class="grid9  ">
                        <input type="radio" id="rdoRAActivoA" class="ActivoUsuClass" name="Usuario.ActivoUsu" checked="checked" value="1"  style="padding-top:40px" /> <label for="rdoRAActivoA" class="mr20" style="margin-top:0px; padding:0px;line-height:14px">Activo</label>
                        <input type="radio" id="rdoRAInactivoA" class="ActivoUsuClass" name="Usuario.ActivoUsu" value="0" /> <label  for="rdoRAInactivoA" class="mr20" style="margin:0px; padding:0px;line-height:14px">Inactivo</label>
                        @Html.HiddenFor(Function(m) m.Usuario.ActivoUsu, New With {.value = "1", .id = "idActivoUsu"})
                        <br class="clear"/> 
                    </div>
                    <div class="clear"></div>              
                </div>
            </div>
            <div class="formRow">
               <div class="grid8">
                <div class="grid4">
                    <button type="button"
                     name="ActionValidar"
                     id="btnValidar"
                     style="cursor:pointer"
                     class="buttonS bBlue formSubmit group_button"
                     onclick="ValidarUsuarioBDexiste();"
                    >Validar
                    </button>
                </div>
                 
             <br class="clear"/> 
            <div class="clear"></div>
            <div id="msgValidar"></div>
            <div class="clear"></div>
                </div>
              <div class="grid4">
                <div class="grid1">
                     <button type="button" 
                                    name="ActionAgregar" 
                                    id="btnAgregarA"
                                    style="cursor:pointer" 
                                    disabled="disabled"
                                    @*class="buttonS bBlue formSubmit group_button" *@
                                    class="buttonS bBlue formSubmit group_button"
                                    onclick="ValidarGuardarUsuarioBDexiste();RegistrarUsuario('frmAgregarUsuario');" >Guardar</button>
                </div>

                <div id="idbutones" class="grid11">
                            <button type="button" 
                                    name="ActionCancelar" 
                                    id="btnCancelar" 
                                    style="cursor:pointer" 
                                    class="buttonS bDefault formSubmit group_button" 
                                    onclick="CancelarRegistro();" >Cancelar</button>
                </div>
                
            <br class="clear"/> 
            <div class="clear"></div>
             <div id="msgValidarguardar"></div>
             <div class="clear"></div>
             </div>     
            </div>
            </div>
        </fieldset>
          
    </div>
    </div>
 </div> 

  End Using 