@ModelType Sodimac.VentaEmpresa.Web.Mvc.AccountViewModel
@Code
    ViewData("Title") = "Editar Usuario"
End Code

@Using (Html.BeginForm("EditarUsuario_", "Account", FormMethod.Post, New With {.id = "frmEditarUsuario"}))
@Html.AntiForgeryToken 
@<div id="ID_CopiarCurso">
<input type="hidden" value="@Url.Action("EditarUsuario", "Account")" id="EditarUsu_URL" />
<div class="wrapper">
    <div class="form">
        <fieldset>
           <div class="widget fluid" id="divDefinicion">
                <div class="whead"><h6>Edicion de Usuario</h6>               
                <div class="clear"></div>
            </div>    
            <div class="formRow fluid"> 
                <div class="grid12">
                    @Html.HiddenFor(Function(m) m.Usuario.IdUsu, New With {.id = "IdUsu"})
                    <div class="grid2" style="padding-top:-30px"><label>Usuario : *</label></div>
                    <div class="grid9 noSearch ">
                        @Html.TextBoxFor(Function(m) m.Usuario.UsuarioUsu,
                        New With
                        {
                            .style = "text-transform:uppercase;",
                            .id = "UsuarioUsu_e",
                            .name = "UsuarioUsu_e",
                            .onkeypress = "return val_AZ(event)",
                            .onCopy = "return false;",
                            .onPaste = "return false;",
                            .maxLength = "50",
                            .class = "textinput"
                        })                        
                        <div id="msgUsuarioUsu_e" style="color:Red; font-size:9px;"></div>
                    </div>              
                </div>
            </div>
            <div class="formRow fluid"> 
                <div class="grid12">               
                    <div class="grid2" style="padding-top:-30px"><label>Nombre : *</label></div>
                    <div class="grid9 noSearch ">
                        @Html.TextBoxFor(Function(m) m.Usuario.UsuarioNom,
                        New With
                        {
                            .style = "text-transform:uppercase;",
                            .id = "UsuarioNom_e",
                            .name = "UsuarioNom_e",
                            .onkeypress = "return val_AZ(event)",
                            .onblur = "return ValidarNUll('UsuarioNom_e');",
                            .onCopy = "return false;",
                            .onPaste = "return false;",
                            .maxLength = "50",
                            .class = "textinput"
                        })                        
                        <div id="msgUsuarioNom_e" style="color:Red; font-size:9px;"></div>
                    </div>              
                </div>
            </div>

            <div class="formRow fluid"> 
                <div class="grid12">               
                    <div class="grid2"><label style="margin:0px; padding:0px;line-height:14px">Estado :</label></div>
                    <div class="grid9  ">


                        @Html.RadioButtonFor(Function(m) m.Usuario.ActivoUsu, 1,
                        New With
                        {
                            .id = "rdoRAActivo",
                            .name = "rdoActivoRol"
                        })
                        <label for="rdoRAActivo" style="margin-top:0px;margin-right:5px; padding:0px;line-height:14px">Activo</label>
                        @Html.RadioButtonFor(Function(m) m.Usuario.ActivoUsu, 0,
                        New With
                        {
                            .id = "rdoRAInactivo",
                            .name = "rdoActivoRol"
                        }) 
                        <label  for="rdoRAInactivo" style="margin:0px; padding:0px;line-height:14px">Inactivo</label>
                        <br class="clear"/> 
                    </div>
                    <div class="clear"></div>              
                </div>
            </div>

          <div class="formRow">
             <div class="grid8">  
             <div class="grid3">
                    <button type="button"
                     name="ActionValidar"
                     id="btnValidar"
                     style="cursor:pointer"
                     class="buttonS bBlue formSubmit group_button"
                     onclick="ValidarUsuarioBDexiste2();"
                    >Validar
                    </button>
                </div>
            <br class="clear"/> 
            <div class="clear"></div>
            <div id="msgValidar1"></div>
            <div class="clear"></div>
               </div>
            <div class="grid4">
              <div class="grid1">
               <button type="button" 
                                    name="ActionAgregar" 
                                    id="btnAgregarUsu"
                                    style="cursor:pointer"
                                    disabled="disabled"
                                    class="buttonS bBlue formSubmit group_button" 
                                    onclick="ValidarEditarUsuario();RegistrarUsuario('frmEditarUsuario');" >Guardar</button>
                           
                </div>
                <div>
                     <button type="button" 
                                    name="ActionCancelar" 
                                    id="btnCancelarUsu" 
                                    style="cursor:pointer" 
                                    class="buttonS bDefault formSubmit group_button" 
                                    onclick="CancelarRegistro();" >Cancelar</button>        
                </div>
               <br class="clear"/> 
            <div class="clear"></div>
             <div id="msgValidarEditar"></div>
             <div class="clear"></div>
            </div>
            </div>
            </div>
        </fieldset>
    </div>
    </div>
 </div>

 End Using
 <script type="text/javascript">
     $(function () {
         $("#rdoRAActivo").uniform();
         $("#rdoRAInactivo").uniform();
     });
 </script>





