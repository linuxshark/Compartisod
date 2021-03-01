@ModelType Sodimac.VentaEmpresa.Web.Mvc.VentasViewModel
<div class="widget fluid">
        <div class="whead">
            <h6> Registro de Nuevo Plan de Ventas</h6>
                <div class="clear"></div>
        </div>

        <div class="formRow fluid">
        <div class="grid6">
            <div class="grid3">
                <label class="form-label">
                Plan Base Actual(S/.) : 
            </label>
            </div>
            <div class="grid6">
                @Html.TextBoxFor(Function(x) x.Empleado.PlanVenta,
                New With {.id = "PlanVenta",
                                            .onkeypress = "return val_09D(event)",
                                            .Class = "textinput",
                                            .Value = IIf(Model.Empleado.PlanVenta <> 0, Model.Empleado.PlanVenta, ""),
                                            .disabled = "disabled"
                                        })
            </div>
        </div>
        <div class="grid6">
            <div class="grid5">
                <label "form-label">
                    Tiempo de Servicio
                </label>
            </div>
            <div class="grid5" style="margin-left:-60px">
                @Html.TextBoxFor(Function(x) x.Empleado.IngresoBasicoMensual,
                                    New With {.id = "IngresoBasicoMensual",
                                            .onkeypress = "return val_09D(event)",
                                            .Class = "textinput",
                                            .Value = IIf(Model.Empleado.IngresoBasicoMensual <> 0, Model.Empleado.IngresoBasicoMensual, ""),
                                            .disabled = "disabled"  
                                        })
            </div>    
        </div>
 
        </div>
        <div class="formRow fluid">
        <div class="grid6">
            <div class="grid3">
                <label class="form-label">
                Nuevo Plan Base(S/.) : 
            </label>
            </div>
            <div class="grid6">
                @Html.TextBoxFor(Function(x) x.Empleado.PlanVenta,
                New With {.id = "PlanVenta",
                                            .onkeypress = "return val_09D(event)",
                                            .Class = "textinput",
                                            .Value = IIf(Model.Empleado.PlanVenta <> 0, Model.Empleado.PlanVenta, "")
                                        })
            </div>
        </div>
        <div class="grid6">
            <div class="grid5">
                <label "form-label">
                    Aplicar Desde :
                </label>
            </div>
            <div class="grid5" style="margin-left:-60px">
                @Html.DropDownListFor(Function(m) m.Cargo.Perfil.IdPerfil,
                                New SelectList(Model.ListaCargo, "IdPerfil", "NombrePerfil"),
                                "- SELECCIONE -",
                                New With {
                                    .id = "ID_IdPerfil_Cargo",
                                    .style = "cursor:default;"
                                }) 
            </div>    
        </div>
 
        </div>
        <div class="formRow fluid">       
        <div class="grid6">
            <div class="grid5">
                <label "form-label">
                    Ingreso Basico Mensual (S/.)
                </label>
            </div>
            <div class="grid5" style="margin-left:-60px">
                @Html.TextBoxFor(Function(x) x.Empleado.IngresoBasicoMensual,
                                    New With {.id = "IngresoBasicoMensual",
                                            .onkeypress = "return val_09D(event)",
                                            .Class = "textinput",
                                            .Value = IIf(Model.Empleado.IngresoBasicoMensual <> 0, Model.Empleado.IngresoBasicoMensual, "")
                                        })
            </div>    
        </div>
 
        </div>
</div>

<div id="contendor-grid-PlanVenta">
</div>
<br />


