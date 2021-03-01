@ModelType Sodimac.VentaEmpresa.Web.Mvc.MantenimientoViewModel
 <div class="grid4" style="padding-top:-30px">
                            <label>Perfil Vendedor:<span class="req">*</span></label>
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
                        