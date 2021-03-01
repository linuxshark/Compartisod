@ModelType Sodimac.VentaEmpresa.Web.Mvc.AccountViewModel
@Code
    ViewBag.Title = "Agregar Rol"
End Code

@Using (Html.BeginForm("Agregar", "Account", FormMethod.Post, New With {.id = "frmAgregarRol"}))
@Html.AntiForgeryToken
@<div id="ID_CopiarCurso">
    <input type="hidden" value="@Url.Action("Agregar", "Account")" id="AgregarRol_URL" />
    <div class="wrapper">
        <div class="form">
            <fieldset>
                <div class="widget fluid" id="divDefinicion">
                    <div class="whead"><h6>Definición del Rol</h6>               
                        <div class="clear"> </div>
                    </div>    
                <div class="formRow fluid">
                    <div class="grid12">               
                        <div class="grid2" style="padding-top:-30px"><label>Rol :<span class="req">*</span></label></div>
                            <div class="grid9">
                                @Html.TextBoxFor(Function(m) m.Rol.NombreRol,
                                New With
                                {
                                    .id = "NombreRolA",
                                    .name = "NombreRolA",
                                    .onkeypress = "return val_AZ(event)",
                                    .onblur = "return ValidarNUll('NombreRolA');",
                                    .onCopy = "return false;",
                                    .onPaste = "return false;",
                                    .maxLength = "50",
                                    .class = "textinput"
                                })                        
                                <div id="msgRolA"></div>
                            </div>             
                        </div>
                    </div>

                    <div class="formRow fluid">
                        <div class="grid12">               
                            <div class="grid2"><label style="margin:0px; padding:0px;line-height:14px">Estado :</label></div>
                                <div class="grid9 ">
                                    <input type="radio" id="rdoRAActivoA" name="Rol.ActivoRol" checked="checked" value="True"  style="padding-top:40px" /> 
                                        <label for="rdoRAActivoA" class="mr20" style="margin-top:0px; padding:0px;line-height:14px">
                                            Activo
                                        </label>
                                    <input type="radio" id="rdoRAInactivoA" name="Rol.ActivoRol" value="False" />
                                        <label  for="rdoRAInactivoA" class="mr20" style="margin:0px; padding:0px;line-height:14px">
                                            Inactivo
                                        </label>
                                        <br class="clear"/> 
                                </div>
                                <div class="clear"></div>              
                        </div>
                    </div>
                    <div class="formRow">
                        <button type="button" name="ActionCancelar" id="btnCancelar" style="cursor:pointer" class="buttonS bBlue formSubmit group_button" onclick="CancelarRegistro();" >Cancelar</button>
                        <button type="button" name="ActionAgregar" id="btnAgregarA" style="cursor:pointer" class="buttonS bBlue formSubmit group_button " onclick="Registrar('frmAgregarRol');" >Guardar</button>
                        <br class="clear"/> 
                        <div class="clear"></div>
                    </div>
                </div>
            </fieldset>
        </div>
    </div>
 </div> 
End Using



