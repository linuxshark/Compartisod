@ModelType Sodimac.VentaEmpresa.Web.Mvc.VentasViewModel
@Imports Sodimac.VentaEmpresa.Web.Mvc.ParametrosView

@Code
    ViewData("Title") = "Gestionar Plan Ventas Empleado"
End Code

<script type="text/javascript" src="/Scripts/View/Vendedor.js"></script>
@Using (Html.BeginForm("GestionarPlanVentaEmpleado_", "Ventas", FormMethod.Post, New With {.id = "frmRegistrarPlanVentaEmpleado", .onsubmit = "return false;"}))
    @Html.AntiForgeryToken
    @<div class="wrapper">
        <div class="form">
            <fieldset>
                <div class="widget fluid"> 
                      <div class="formRow fluid">
                        <div class="grid10">
                           <div class="grid2">
                                <label class="form-label">
                                    Nombre Completo:</label>
                            </div>
                            <div class="grid10" style="margin-left:8px">
                                @Html.TextBoxFor(Function(m) m.SucursalEmpleado.Empleado.NombresApellidos, New With {.readOnly = True})
                            </div>
                        </div>
                        <div class="grid6">
                            <div class="grid4">
                                <label class="form-label">
                                    </label>
                            </div>
                            <div class="grid7">
                            
                            </div>
                        </div>
                        <div class="clear">
                        </div>
                    </div>
                     <div class="formRow fluid">
                       <div class="grid4">
                         <div class="grid5">
                                <label class="form-label">
                                    Plan Base General :
                                </label>
                            </div>
                         <div class="grid4">
                                @Html.TextBoxFor(Function(m) m.SucursalEmpleado.ComisionEscalaTiempoServicio.PlanVenta , New With {.disabled = "disabled"})
                            </div>
                        </div>
                        <div class="grid4">
                            <div class="grid4">
                                <label class="form-label">
                                    Tiempo Servicio :</label>
                            </div>
                            <div class="grid3">
                                @Html.TextBoxFor(Function(m) m.SucursalEmpleado.ComisionEscalaTiempoServicio.TiempoServicio,
                                           New With {.id = "ID_EscalaAsignado",
                                                     .disabled = "disabled"
                                                    })
                            </div>
                            <div id="ID_MsgEscalaAsignado">
                            </div>
                        </div>
                        <div class="clear"></div>
                    </div>
                   
                     <div class="formRow fluid">
                          <div class="grid4">
                            <div class="grid5">
                                <label class="form-label">
                                    Nuevo Plan Base :
                                </label>
                            </div>
                         <div class="grid4">
                                @Html.TextBoxFor(Function(m) m.Empleado.PlanVentaEmpleado.PlanVentaBase,
                                New With {
                                    .id = "Id_NuevoPlan",
                                    .onkeypress = "return val_09_2D(event)",
                                    .maxlength = "9"
                                })
                                @Html.ValidationMessageFor(Function(m) m.Empleado.PlanVentaEmpleado.PlanVentaBase, "", New With {.class = "reqizq"})
                            </div>
                          
                          </div>  
                          <div class="grid4">
                               <div class="grid4">
                                <label class="form-label">
                                    Aplicar desde Mes :
                                </label>
                            </div>
                            <div class="grid4">
                                  @Html.DropDownListFor(Function(m) m.Empleado.PlanVentaEmpleado.comboTiempoServicio,
                                                  New SelectList(Model.ListaComsionPeriodoDetalle, "IdPeriodoDetalle", "Descripcion"),
                                                  "-SELECCIONE-",
                                                   New With {
                                                             .id = "Id_TiempoNuevo",
                                                             .class = "selector"
                                                       }) 
                                      @Html.ValidationMessageFor(Function(m) m.Empleado.PlanVentaEmpleado.comboTiempoServicio, "", New With {.class = "reqizq"})
                            </div>
                             @*<div id="ID_MsgEscalaTiempo">
                            </div>*@
                          </div>
                           <div class="grid4">
                                 <div class="grid5">
                                <label class="form-label">
                                    Ingreso Básico Mensual :
                                </label>
                            </div>
                         <div class="grid4">
                                @Html.TextBoxFor(Function(m) m.Empleado.PlanVentaEmpleado.IngresoBasicoMensual,
                                New With {
                                    .id = "Id_IngresoBasicoMensual",
                                    .onkeypress = "return val_09_2D(event)",
                                    .maxlength = "9"
                                  })
                                @Html.ValidationMessageFor(Function(m) m.Empleado.PlanVentaEmpleado.IngresoBasicoMensual, "", New With {.class = "reqizq"})
                            </div>
                          </div>
                           <div class="clear">
                        </div>
                     </div> 
             
                    <div class="formRow fluid">
                        <div class="grid7">
                            <div class="grid3">
                                <label class="form-label">
                                    Perfil :
                                </label>
                            </div>
                            <div class="grid5" style="margin-left:-05px" >
                                @Html.TextBoxFor(Function(m) m.SucursalEmpleado.Perfil.NombrePerfil,
                                           New With {.disabled = "disabled"})
                            </div>
                        </div>
                        <div class="grid5">
                                <div class="grid3">
                                    <label class="form-label">
                                        Zona :
                                    </label>
                                </div>
                                <div class="grid6">
                                        @Html.TextBoxFor(Function(m) m.SucursalEmpleado.ZonaMantenimiento.NombreZona,
                                           New With {.disabled = "disabled"}) 
                                </div>
                          </div>
                    
                        <div class="clear">
                        </div>
                    </div>
                  <div class="formRow fluid">
                     <div class="grid4">
                         <div class="grid5">
                                <label class="form-label">
                                    Sucursal :
                                </label>
                            </div>
                         <div class="grid4">
                                @Html.TextBoxFor(Function(m) m.SucursalEmpleado.Sucursal.Descripcion , New With {.disabled = "disabled"})
                            </div>
                     </div>
                    <div class="clear"></div>
                  </div>
                   
                   

                     <div class="formRow fluid">
                        <div class="grid10">
                           <div class="grid2">
                                <label class="form-label">
                                    Reporta A:</label>
                            </div>
                            <div class="grid10" style="margin-left:8px"> 
                                @Html.TextBoxFor(Function(m) m.SucursalEmpleado.Cargo.NombreCargoSuperior, New With {.readOnly = True})
                            </div>
                        </div>
                        <div class="grid6">
                            <div class="grid4">
                                <label class="form-label">
                                    </label>
                            </div>
                            <div class="grid7">
                            
                            </div>
                        </div>
                        <div class="clear">
                        </div>
                    </div>               
                    <div class="formRow fluid">
                        <div class="clear"></div>
                    </div>
                          <div class="formRow" style="margin-right:10px">
                            <button type="button" name="ActionCancelar" id="btnCancelar" style="cursor:pointer" class="buttonS bBlue formSubmit group_button" onclick="DialogCancelarRegistroPlanVenta();" >Cancelar</button>
                            <button type="button" name="ActionAgregar" id="btnAgregarAPlan" style="cursor:pointer" class="buttonS bBlue formSubmit group_button " onclick="RegistrarPlanVenta();" >Guardar</button>
                            <br class="clear"/> 
                            <div class="clear"></div>
                    </div>
                </div>
            </fieldset>
        </div>
    </div>
    @Html.HiddenFor(Function(m) m.Empleado.IdEmpleado)
End Using
@*</form>*@

