@ModelType Sodimac.VentaEmpresa.Web.Mvc.AccountViewModel
@Code
    ViewData("Title") = "Editar Rol"
End Code

@Using (Html.BeginForm("EditarRol", "Account", FormMethod.Post, New With {.id = "frmEditarRol"}))
@Html.AntiForgeryToken
@<div id="ID_CopiarCurso">
    <input type="hidden" value="@Url.Action("EditarRol", "Account")" id="EditarRol_URL" />
<div class="wrapper">
    <div class="form">
        <fieldset>
           <div class="widget fluid" id="divDefinicion">
                <div class="whead"><h6>Modificación del Rol</h6>               
                    <div class="clear"></div>
                </div>    
            <div class="formRow fluid">                 
                @Html.HiddenFor(Function(m) m.Rol.IdRol, New With {.id = "IdRol"})
                <div class="grid12">
                    <div class="grid2" style="padding-top:-30px"><label>Rol :<span class="req">*</span></label></div>
                    <div class="grid9">
                        @Html.TextBoxFor(Function(m) m.Rol.NombreRol,
                        New With
                        {
                            .style = "text-transform:uppercase;",
                            .id = "NombreRol",
                            .name = "NombreRol",
                            .onkeypress = "return val_AZ(event)",
                            .onblur = "return ValidarNUll('NombreRol');",
                            .onCopy = "return false;",
                            .onPaste = "return false;",
                            .maxLength = "50",
                            .class = "textinput"
                         })
                        <br class="clear"/> 
                        <div id="msgRol"></div>
                    </div>
                    <div class="clear"></div>
                </div>
            </div>
            <div class="formRow fluid"> 
                <div class="grid12">               
                    <div class="grid2"><label style="margin:0px; padding:0px;line-height:14px">Estado :</label></div>
                    <div class="grid9  ">
                        @If (Not Model.Rol Is Nothing) Then
                            Model.Rol.ActivoRol = Model.Rol.ActivoRol = True
                        End If
                        @Html.RadioButtonFor(Function(m) m.Rol.ActivoRol, True,
                        New With
                        {
                            .id = "rdoRAActivo",
                            .name = "rdoActivoRol"
                        }) 
                        <label for="rdoRAActivo" style="margin-top:0px;margin-right:5px; padding:0px;line-height:14px">
                            Activo
                        </label>
                        @Html.RadioButtonFor(Function(m) m.Rol.ActivoRol, False,
                        New With
                        {
                            .id = "rdoRAInactivo",
                            .name = "rdoActivoRol"
                        }) 
                        <label  for="rdoRAInactivo" style="margin:0px; padding:0px;line-height:14px">
                            Inactivo
                        </label>
                        <br class="clear"/> 
                    </div>
                    <div class="clear"></div>              
                </div>
            </div>
                <div class="formRow">
                    <button type="button" name="ActionCancelar" id="btnCancelar" style="cursor:pointer" class="buttonS bBlue formSubmit group_button" onclick="CancelarRegistro();" >Cancelar</button>
                    <button type="button" name="ActionAgregar" id="btnEditar" style="cursor:pointer" class="buttonS bBlue formSubmit group_button " onclick="Registrar('frmEditarRol');" >Guardar</button>
                    <br class="clear"/> 
                    <div class="clear"></div>
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

