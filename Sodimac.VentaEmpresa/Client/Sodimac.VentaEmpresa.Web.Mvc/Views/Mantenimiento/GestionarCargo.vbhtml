@ModelType Sodimac.VentaEmpresa.Web.Mvc.MantenimientoViewModel
@Imports Sodimac.VentaEmpresa.Web.Mvc.ParametrosView
@Code
    ViewData("Title") = "Gestionar Cargo"
End Code

@Using (Html.BeginForm("GestionarCargo_", "Mantenimiento", FormMethod.Post, New With {.id = "frmGestionarCargo"}))
    @Html.AntiForgeryToken
@<div id="ID_CopiarCurso">    
    <div class="wrapper">
        <div class="form">
            <fieldset>
                <div class="widget fluid" id="divDefinicion">
                    <div class="whead"><h6>Definición del Cargo</h6>               
                        <div class="clear"> </div>
                    </div>  
               <div class="formRow fluid">
                    <div class="grid12">               
                        <div class="grid3" style="padding-top:-30px"><label>Perfil:<span class="req">*</span></label></div>
                            <div class="grid6">
                                @Html.DropDownListFor(Function(m) m.Cargo.Perfil.IdPerfil,
                                New SelectList(Model.ListaPerfil, "IdPerfil", "NombrePerfil"),
                                "- SELECCIONE -",
                                New With {
                                    .id = "ID_IdPerfil_Cargo",
                                    .style = "cursor:default;",
                                    .onchange = "ListarCargosByPerfil();validaTipoPerfil();MostrarValorSeleccionado();MostrarNombrePerfilInferior();"
                                }) 
                                @Html.ValidationMessageFor(Function(m) m.Cargo.Perfil.IdPerfil, "", New With {.class = "reqizq"})                               
                            </div>             
                        </div>
                </div>
                <div class="formRow fluid">
                    <div class="grid12">               
                        <div class="grid3" style="padding-top:-30px"><label>Zona:<span class="req">*</span> </label></div>
                            <div class="grid6">
                                @Html.DropDownListFor(Function(m) m.Cargo.Zona.IdZona,
                                New SelectList(Model.ListaZonaMantenimiento, "IdZona", "NombreZona"),
                                "- SELECCIONE -",
                                New With {
                                    .id = "ID_ZonaCargo",
                                    .style = "cursor:default;",
                                    .onchange="MostrarZonaSeleccionado();MostrarZonaVendedor();"
                                }) 
                                 @Html.ValidationMessageFor(Function(m) m.Cargo.Zona.IdZona, "", New With {.class = "reqizq"})                                
                            </div>             
                        </div>
                    </div>  
                <div class="formRow fluid">
                    <div class="grid12">               
                        <div class="grid3" style="padding-top:-30px"><label>Cargo :<span class="req">*</span></label></div>
                            <div class="grid9" id="divIdnombrecargo">
                                @Html.TextBoxFor(Function(m) m.Cargo.NombreCargo,
                                New With
                                {
                                    .id = "NombreCargo",
                                    .name = "NombreCargo",
                                    .onkeypress = "return val_AZ(event)",
                                    .maxLength = "100",
                                    .class = "textinput",
                                    .style = "text-transform:uppercase;",
                                    .readonly = True                                        
                                })                       
                                @Html.ValidationMessageFor(Function(m) m.Cargo.NombreCargo, "", New With {.class = "reqizq"})
                            </div>             
                        </div>
                    </div>              
                    <div class="formRow fluid">
                    <div class="grid12">               
                        <div class="grid3" style="padding-top:-30px"><label>Reporta A:</label></div>
                            <div id="Div_ListaCargosByPerfil">
                                   @Html.Partial(ParametrosPartialView.ListaCargo_ByPerfil, Model)
                            </div>             
                        </div>
                    </div>
                  
                    <div class="formRow fluid">
                    <div class="grid12">               
                        <div class="grid3" style="padding-top:-30px"><label>Comisiona</label></div>
                            <div class="checker" id="">
                                 @Html.CheckBoxFor(Function(m) m.Cargo.Comisiona, New With {.id = "Id_Comisiona", .class = ""})                     
                            </div>             
                        </div>
                    </div>
                    <div class="formRow fluid">
                    <div id="divTextotodo"  class="grid12" style="display: none">
                        <div class="grid3" style="padding-top:-30px" >
                            <label> Cargo inferior :<span class="req">*</span></label>
                        </div>
                        <div class="grid9">
                            @Html.TextBoxFor(Function(m) m.Cargo.NombreCargoInferior,
                                             New With {.id = "NombreCargoInferior",
                                                       .name = "NombreCargoInferior",
                                                       .onkeypress = "return val_AZ(event)",
                                                       .maxLength = "100",
                                                       .class = "texinput",
                                                       .style = "text-transform:uppercase;",
                                                       .readonly = True
                                                      })
                                                    @Html.ValidationMessageFor(Function(m) m.Cargo.NombreCargoInferior,"", New With{.class="reqizq"}  ) 
                        </div> 
                    </div>
                    </div>

                    
                    <div class="formRow" style="margin-right:10px">
                        <button type="button" name="ActionCancelar" id="btnCancelar" style="cursor:pointer" class="buttonS bBlue formSubmit group_button" onclick="DialogCancelarRegistroCargo();" >Cancelar</button>
                        <button type="button" name="ActionAgregar" id="btnAgregarA" style="cursor:pointer" class="buttonS bBlue formSubmit group_button " onclick="RegistrarCargo();" >Guardar</button>
                        <br class="clear"/> 
                        <div class="clear"></div>
                    </div>
                </div>
            </fieldset>
        </div>
    </div>
 </div>
    @Html.HiddenFor(Function(m) m.Cargo.IdCargo, New With {.id = "HD_IdCargo"})
    @Html.Hidden("Id_NombreInferior")
End Using
  
