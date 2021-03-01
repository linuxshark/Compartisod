@ModelType Sodimac.VentaEmpresa.Web.Mvc.MantenimientoViewModel
@Imports Sodimac.VentaEmpresa.Web.Mvc.ParametrosView
@Imports Sodimac.VentaEmpresa.Common

@Html.Hidden("UrlProvincia", Url.Action("ListarProvincia", "Mantenimiento"))
@Html.Hidden("UrlDistrito", Url.Action("ListarDistrito", "Mantenimiento"))
@Code
    ViewData("Title") = "Gestionar Sucursal"
End Code

@Using (Html.BeginForm("GestionarSucursal_", "Mantenimiento", FormMethod.Post, New With {.id = "frmGestionarSucursal"}))
    @Html.AntiForgeryToken
@<div id="ID_CopiarCurso"> 
    <div class="wrapper">
        <div class="form">
            <fieldset>
                <div class="widget fluid" id="divDefinicionSucursal">
                <div class="whead"><h6>Definición de Sucursal</h6>
                    <div class="clear"> </div>
                </div>
                <div class="formRow fluid">
                    <div class="grid12">
                        <div class="grid3" style="padding-top:-30px" > <label> Descripción Sucursal :</label></div>
                        <div class="grid9">
                            @Html.TextBoxFor(Function(m) m.SucursalMantenimiento.Descripcion,
                                             New With {
                                                      .id = "Descripcion",
                                                      .class= "textinput",
                                                      .onkeypress = "return val_AZ(event)",
                                                      .style = "text-transform:uppercase;",
                                                      .maxLength ="50"
                                                 })
                                           @Html.ValidationMessageFor(Function(m) m.SucursalMantenimiento.Descripcion, "",New With {.class = "reqizq"}  ) 
                        </div> 
                    </div>
                </div>
                <div class="formRow fluid">
                    <div class="grid12">
                        <div class="grid3" style="padding-top:-30px" > <label> Departamento : </label></div>
                        <div class="grid6">
                            @Html.DropDownListFor(Function(m) m.SucursalMantenimiento.Departamento.IdDepartamento,
                                                  New SelectList(Model.ListaDepartamento, "IdDepartamento", "Descripcion"),
                                                  "-SELECCIONE-",
                                                  New With {
                                                        .id = "ID_IdDepartamento",
                                                        .style = "cursor:default;",
                                                        .onchange = "CargarProvincia();"
                                                      })
                           @Html.ValidationMessageFor(Function(m) m.SucursalMantenimiento.Departamento.IdDepartamento,"", New With{ .class="reqizq"})  
                        </div>
                    </div>
                </div>
                <div class="formRow fluid">
                    <div class="grid12">
                        <div class="grid3" style="padding-top:-30px"><label> Provincia : </label></div>
                    <div class="grid6">
                        <div id="divListaComboProvincia">
                            @Html.Partial(ParametrosPartialView.PVSucursal_Provincia_Dep, Model) 
                        </div>
                    </div>
                    </div>
                </div>
                 <div class="formRow fluid">
                    <div class="grid12">
                        <div class="grid3" style="padding-top:-30px"><label> Provincia : </label></div>
                    <div class="grid6">
                        <div id="divListaComboDistrito">
                            @Html.Partial(ParametrosPartialView.PVSucursal_Distrito_Combo, Model) 
                        </div>
                    </div>
                    </div>
                </div>

                <div class="formRow fluid">
                    <div class="grid12">
                        <div class="grid3" style="padding-top:-30px" > <label> Dirección Sucursal : </label></div>
                        <div class="grid9">
                            @Html.TextAreaFor(Function(m) m.SucursalMantenimiento.Direccion,
                                              New With {
                                                        .id = "Direccion",
                                                        .onkeypress = "return val_AZ(event)",
                                                        .style = "text-transform:uppercase;",
                                                        .maxLength = "100"
                                                  }) 
                                        @Html.ValidationMessageFor(Function(m) m.SucursalMantenimiento.Direccion, "", New With {.class = "reqizq"})  
                        </div>
                    </div>    
                </div>
                <div class="formRow fluid">
                    <div class="grid12">
                        <div class="grid3" style="padding-top:-30px" > <label> Descripción Corta Sucursal : </label></div>
                        <div class="grid9">
                            @Html.TextBoxFor(Function(m) m.SucursalMantenimiento.DescripcionCorta,
                                             New With {
                                                        .id = "ID_DescripcionCorta",
                                                        .maxLength = "50",
                                                        .style = "text-transform:uppercase;",
                                                        .onkeypress = "return val_AZ(event)"
                                                 })
                                    @Html.ValidationMessageFor(Function(m) m.SucursalMantenimiento.DescripcionCorta, "", New With {.class = "reqizq"}) 
                        </div>
                    </div>
                </div>
                <div class="formRow fluid">
                    <div class="grid12">
                        <div class="grid3" style="padding-top:-30px" > <label> Telefono : </label></div>
                        <div class="grid9">
                            @Html.TextBoxFor(Function(m) m.SucursalMantenimiento.Telefono,
                                             New With {
                                                        .id = "Telefono",
                                                        .maxLength = "50",
                                                        .style = "text-transform:uppercase;",
                                                        .onkeypress = "return val_AZ(event)"
                                                 })
                                    @Html.ValidationMessageFor(Function(m) m.SucursalMantenimiento.Telefono, "", New With {.class = "reqizq"}) 
                        </div>
                    </div>
                </div>
                <div class="formRow" style="margin-right:10px">
                    <button type="button" name="ActionCancelar" id="btnCancelar" style="cursor:pointer" class="buttonS bBlue formSubmit group_button" onclick="DialogCancelarRegistroSucursal();" >Cancelar</button>
                    <button type="button" name="ActionAgregar" id="btnAgregarA" style="cursor:pointer" class="buttonS bBlue formSubmit group_button " onclick="RegistrarSucursal();" >Guardar</button>
                </div>
                </div>
            </fieldset>
        </div>
    </div> 
</div>    
   @Html.HiddenFor(Function(m) m.SucursalMantenimiento.IdSucursal, New With {.id = "HD_IdSucursal"}) 
End Using


