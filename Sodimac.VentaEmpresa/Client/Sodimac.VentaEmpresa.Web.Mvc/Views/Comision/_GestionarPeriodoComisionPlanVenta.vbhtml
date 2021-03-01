@ModelType Sodimac.VentaEmpresa.Web.Mvc.ComisionViewModel
@Imports Sodimac.VentaEmpresa.Web.Mvc.ParametrosView
<script type='text/javascript' src='@Url.Content("~/Content/js/files/functions.js")'></script>
<div id="tabb_" class="">
@Using (Html.BeginForm(Nothing, Nothing, FormMethod.Post, New With {.id = "frmPlanVenta_" & Model.PlanVenta.Cargo.IdCargoSuperior, .onsubmit = "return false;"}))
@Html.HiddenFor(Function(m) m.PlanVenta.ComisionEscala.ComisionPeriodo.IdPeriodo, New With {.id = "IDPeriodo_" & Model.PlanVenta.Cargo.IdCargoSuperior})
@Html.HiddenFor(Function(m) m.PlanVenta.ComisionEscalaRRVV.ComisionPeriodo.IdPeriodo, New With {.id = "IDPeriodoRRVV_" & Model.PlanVenta.Cargo.IdCargoSuperior})
@Html.HiddenFor(Function(m) m.PlanVenta.Cargo.IdCargo, New With {.id = "IDCargo_" & Model.PlanVenta.Cargo.IdCargo, .Value = Model.PlanVenta.Cargo.IdCargo}) 
@Html.HiddenFor(Function(m) m.PlanVenta.Cargo.IdCargoSuperior, New With {.id = "IDCargoSuperior_" & Model.PlanVenta.Cargo.IdCargoSuperior, .Value = Model.PlanVenta.Cargo.IdCargoSuperior}) 
@Html.HiddenFor(Function(m) m.PlanVenta.Cargo.Perfil.IdPerfil, New With {.id = "IDPerfil_" & Model.PlanVenta.Cargo.IdCargoSuperior, .Value = Model.PlanVenta.Cargo.Perfil.IdPerfil})
@Html.HiddenFor(Function(m) m.PlanVenta.Cargo.PerfilSuperior.IdPerfil, New With {.id = "IDPerfilSuperior_" & Model.PlanVenta.Cargo.IdCargoSuperior, .Value = Model.PlanVenta.Cargo.PerfilSuperior.IdPerfil})  
@Html.HiddenFor(Function(m) m.PlanVenta.ComisionEscala.Completo, New With {.id = "Completo_Jefes_" & Model.PlanVenta.Cargo.IdCargoSuperior, .Value = Model.PlanVenta.Cargo.PerfilSuperior.IdPerfil})  
@Html.HiddenFor(Function(m) m.PlanVenta.ComisionEscalaRRVV.Completo, New With {.id = "Completo_RRVV_" & Model.PlanVenta.Cargo.IdCargoSuperior, .Value = Model.PlanVenta.Cargo.PerfilSuperior.IdPerfil})  
    
    @<div class="widget fluid" style="width: 97%; margin: 20px auto;">
            <div class="whead">
                <h6>
                    PLAN DE VENTAS: @Model.PlanVenta.Cargo.NombreCargoSuperior
                </h6>
                <div class="clear">
                </div>
            </div>
<div class="formRow fluid noBorderB">               
    <div class="formRow fluid">  @*Linea del Factor*@
        <div class="grid12">
          
                <div class="check lineas" style="margin-right:0">
                    <span id="IDSpanFactor_@Model.PlanVenta.Cargo.IdCargoSuperior">
                        @Html.CheckBoxFor(Function(m) m.PlanVenta.ComisionEscala.PlanVentaFactorAplica, New With {.id = "IDFactorAplica_" & Model.PlanVenta.Cargo.IdCargoSuperior})
                                   
                    </span>
                </div>
                <div class="lineas">Aplicar el factor del @*<span class="req">*</span>*@</div>
         
            
                <div class="lineas">
                    @Html.TextBoxFor(Function(m) (m.PlanVenta.ComisionEscala.PlanVentaFactor),
                    New With {
                        .id = "IDPlanVentaFactor_" & Model.PlanVenta.Cargo.IdCargoSuperior,
                        .class = "textTransform",
                        .onkeypress = "return val_09_2D(event)",
                        .onclick = "selectTextInput(event)",
                        .maxlength = "6",
            .Value = IIf(Model.PlanVenta.ComisionEscala.PlanVentaFactor <> 0, Model.PlanVenta.ComisionEscala.PlanVentaFactor, "")
                    })
                    <div id="ID_MsgPlanVentaFactor_@Model.PlanVenta.Cargo.IdCargoSuperior">
                    </div>
                </div>
                <div class="lineas">
                    
                        %
                </div>
           
            <div class="lineas">
               
                    con fecha Inicio
            </div>
                                     
                    <div class="lineas">
                    @If Model.PlanVenta.ComisionEscala.PlanVentaFactorFechaInicio = Nothing Then
                            @Html.TextBoxFor(Function(m) (m.PlanVenta.ComisionEscala.PlanVentaFactorFechaInicio),
                            New With {
                            .id = "IDFechaInicio_" & Model.PlanVenta.Cargo.IdCargoSuperior,
                            .class = "datepicker maskDate",
                            .maxlength = "10",
                            .Value = String.Format("{0:d}", "")
                        })
                        Else
                            @Html.TextBoxFor(Function(m) (m.PlanVenta.ComisionEscala.PlanVentaFactorFechaInicio),
                            New With {
                            .id = "IDFechaInicio_" & Model.PlanVenta.Cargo.IdCargoSuperior,
                            .class = "datepicker maskDate",
                            .maxlength = "10",
                            .Value = String.Format("{0:d}", IIf(Model.PlanVenta.ComisionEscala.PlanVentaFactorFechaInicio.ToShortDateString() = "01/01/1900", "",Model.PlanVenta.ComisionEscala.PlanVentaFactorFechaInicio))
                        })
                            
                        End If
                        
                        <div id="IDMsgFechaInicio_@Model.PlanVenta.Cargo.IdCargoSuperior">
                        </div>                               
                    </div>
       

            <div class="lineas">
               
                    y con fecha Fin
            </div>
                                  
                    <div class="lineas">
                     @If Model.PlanVenta.ComisionEscala.PlanVentaFactorFechaFin = Nothing Then
                             @Html.TextBoxFor(Function(m) (m.PlanVenta.ComisionEscala.PlanVentaFactorFechaFin),
                        New With {
                            .id = "IDFechaFin_" & Model.PlanVenta.Cargo.IdCargoSuperior,
                            .class = "datepicker maskDate",
                            .maxlength = "10",
                            .Value = String.Format("{0:d}","")
                        })
                         Else
                             @Html.TextBoxFor(Function(m) (m.PlanVenta.ComisionEscala.PlanVentaFactorFechaFin),
                        New With {
                            .id = "IDFechaFin_" & Model.PlanVenta.Cargo.IdCargoSuperior,
                            .class = "datepicker maskDate",
                            .maxlength = "10",
                            .Value = String.Format("{0:d}", IIf(Model.PlanVenta.ComisionEscala.PlanVentaFactorFechaFin.ToShortDateString() = "01/01/1900", "",Model.PlanVenta.ComisionEscala.PlanVentaFactorFechaFin))
                        })
                         End If
                        
                        <div id="IDMsgFechaFin_@Model.PlanVenta.Cargo.IdCargoSuperior">
                        </div>                               
                    </div>
           
        </div>
    </div>
    <div class="formRow fluid">    @*3eraFila*@
        <div class="grid12">
            <div class="lineas">  
                @Html.HiddenFor(Function(m) m.PlanVenta.ComisionEscala.PlanVentaBonificacionRRVV, New With {.id = "HDBoniRRVV_" & Model.PlanVenta.Cargo.IdCargoSuperior})                       
                @Html.RadioButtonFor(Function(m) m.PlanVenta.ComisionEscala.PlanVentaBonificacionRRVV, True,
                New With {.id = "BooleanBoniRRVV_" & Model.PlanVenta.Cargo.IdCargoSuperior,
                .onclick = "chgBonificacionJefe('BooleanBoniRRVV_" & Model.PlanVenta.Cargo.IdCargoSuperior & "','RRVV','" & Model.PlanVenta.Cargo.IdCargoSuperior & "');"})
                                  
                <div class="lineas">Si cada RRVV alcanza como mínimo el @*<span class="req">*</span>*@</div>
            </div>
                        
                <div class="lineas">
                    @Html.TextBoxFor(Function(m) (m.PlanVenta.ComisionEscala.PlanVentaBonificacionRRVVPorcentaje),
                    New With {
                        .id = "IDPorcentajeRRVV_" & Model.PlanVenta.Cargo.IdCargoSuperior,
                        .class = "textTransform",
                        .onkeypress = "return val_09_2D(event)",
                        .onclick = "selectTextInput(event)",
                        .maxlength = "6",
                        .Value = IIf(Model.PlanVenta.ComisionEscala.PlanVentaBonificacionRRVVPorcentaje <> 0, Model.PlanVenta.ComisionEscala.PlanVentaBonificacionRRVVPorcentaje, "")
                    })
                <div id="IDMsgPorcentajeRRVV_@Model.PlanVenta.Cargo.IdCargoSuperior">
                </div>
                </div>
                <div class="lineas">
                    %
                </div>
          
    
                <div class="lineas">
                el Jefe de Ventas recibe una bonificación especial de S/.@*<span class="req">*</span>*@</div>
   
         
                <div class="lineas">
                    @Html.TextBoxFor(Function(m) (m.PlanVenta.ComisionEscala.PlanVentaBonificacionRRVVMonto),
                    New With {
                        .id = "IDBonoMontoRRVV_" & Model.PlanVenta.Cargo.IdCargoSuperior,
                        .class = "textTransform",
                        .onkeypress = "return val_09_2D(event)",
                        .onclick = "selectTextInput(event)",
                        .maxlength = "8",
                        .Value = IIf(CInt(Model.PlanVenta.ComisionEscala.PlanVentaBonificacionRRVVMonto) <> 0, CInt(Model.PlanVenta.ComisionEscala.PlanVentaBonificacionRRVVMonto), "")
                    })
                    <div id="IDMsgBonoMontoRRVV_@Model.PlanVenta.Cargo.IdCargoSuperior">
                    </div>
                </div>
          
                        
        </div>
    </div>
    <div class="formRow fluid">
        <div class="grid12">
            <div class="lineas">
                @Html.HiddenFor(Function(m) m.PlanVenta.ComisionEscala.PlanVentaBonificacionJefe, New With {.id = "HDBoniJefe_" & Model.PlanVenta.Cargo.IdCargoSuperior})  
                @Html.RadioButtonFor(Function(m) m.PlanVenta.ComisionEscala.PlanVentaBonificacionRRVV, False,
                New With {.id = "BooleanBoniJefe_" & Model.PlanVenta.Cargo.IdCargoSuperior,
                .onclick = "chgBonificacionJefe('BooleanBoniJefe_" & Model.PlanVenta.Cargo.IdCargoSuperior & "','Jefe','" & Model.PlanVenta.Cargo.IdCargoSuperior & "');"})

                <div class="lineas">Si el Jefe de Ventas alcanza como mínimo el @*<span class="req">*</span>*@</div>                                                        
            </div>                        
                                      
                <div class="lineas">
                    @Html.TextBoxFor(Function(m) (m.PlanVenta.ComisionEscala.PlanVentaBonificacionJefePorcentaje),
                    New With {
                        .autocomplete = "off",
                        .disabled = "disabled",
                        .id = "IDPorcentaje_" & Model.PlanVenta.Cargo.IdCargoSuperior,
                        .class = "textTransform",
                        .onkeypress = "return val_09_2D(event)",
                        .onclick = "selectTextInput(event)",
                        .maxlength = "6",
            .Value = IIf(CInt(Model.PlanVenta.ComisionEscala.PlanVentaBonificacionJefePorcentaje) <> 0, CInt(Model.PlanVenta.ComisionEscala.PlanVentaBonificacionJefePorcentaje), "")
                    })
                    <div id="IDMsgPorcentaje_@Model.PlanVenta.Cargo.IdCargoSuperior">
                    </div>
                </div>
                <div class="lineas">%
                </div>
            
            <div class="lineas">
         
                    este recibe bonificación especial de S/.
            </div>
            
                <div class="lineas">
                    @Html.TextBoxFor(Function(m) (m.PlanVenta.ComisionEscala.PlanVentaBonificacionJefeMonto),
                    New With {
                        .id = "IDBonoMontoJefe_" & Model.PlanVenta.Cargo.IdCargoSuperior,
                        .disabled = "disabled",
                        .class = "textTransform",
                        .onkeypress = "return val_09_2D(event)",
                        .onclick = "selectTextInput(event)",
                        .maxlength = "8",
                        .Value = IIf(CInt(Model.PlanVenta.ComisionEscala.PlanVentaBonificacionJefeMonto) <> 0, CInt(Model.PlanVenta.ComisionEscala.PlanVentaBonificacionJefeMonto), "")
                    })
                    <div id="IDMsgBonoMontoJefe_@Model.PlanVenta.Cargo.IdCargoSuperior">
                    </div>
                </div>
          
                        
        </div>
    </div>
    <div class="formRow fluid">
        <div class="grid12">
            <div class="grid12">
                <div class="grid8">
                    <div class="lineas" style="margin-left:28px">
                            Cantidad de Escalas:</div>
                    <div class="lineas">
                        @Html.TextBoxFor(Function(m) (m.PlanVenta.ComisionEscala.CantidadEscalas),
                        New With {
                            .id = "IDCantidadEscalasJefe_" & Model.PlanVenta.Cargo.IdCargoSuperior,
                            .class = "textTransform",
                            .onkeypress = "return val_09(event)",
                            .onclick = "selectTextInput(event)",
                            .maxlength = "2",
                            .Value = IIf(Model.PlanVenta.ComisionEscala.CantidadEscalas <> 0, Model.PlanVenta.ComisionEscala.CantidadEscalas, "")
                        })                                    
                        <div id="IDMsgCantidadEscalas_@Model.PlanVenta.Cargo.IdCargoSuperior">
                        </div>
                        <script type="text/javascript">
                            $(function () {
                                $("#IDGenerarPeriodoComision_@Model.PlanVenta.Cargo.IdCargoSuperior").click()
                            })                                
                    </script>
                    </div>
                </div>
                @Html.HiddenFor(Function(m) m.PlanVenta.ComisionEscala.Completo_, New With {.id = "HDCompletoJefe_" & Model.PlanVenta.Cargo.IdCargoSuperior})
                 @Html.HiddenFor(Function(m) m.PlanVenta.ComisionEscala.Completo, New With {.id = "HDCompletoJefe" & Model.PlanVenta.Cargo.IdCargoSuperior})
                    <div class="grid4" style="margin-left:-35px">
                            <input id="IDGuardarPeriodoComision_@Model.PlanVenta.Cargo.IdCargoSuperior" style="cursor: pointer;" type="button" class="buttonS bBlue formSubmit group_button visibleVer"
                         onclick = "GuardarPlanVentaJefe($('#frmPlanVenta_@Model.PlanVenta.Cargo.IdCargoSuperior'),@Model.PlanVenta.Cargo.IdCargoSuperior)"
                                value="Guardar"/>

                            <input id="IDGenerarPeriodoComision_@Model.PlanVenta.Cargo.IdCargoSuperior" style="cursor: pointer;" type="button" class="buttonS bBlue formSubmit group_button visibleVer"
                         onclick = "GenerarPlanVenta(@Model.PlanVenta.Cargo.IdCargoSuperior);"
                            value="Generar"/> 
                    </div>        
                <div class="clear">
                </div>
            </div>
        </div>
    </div>
    <div id="BonificacionJefatura_@Model.PlanVenta.Cargo.IdCargoSuperior">
        @Html.Partial(ParametrosPartialView.Comision_GestionarPeriodoComisionBonosJefatura, Model)
    </div>
</div>
</div>            
@<div class="widget fluid" style="width: 97%; margin: 20px auto">   @*********************Aqui empieza el plan de Ventas para el VENDEDOR *********************************@
            <div class="whead">
                <h6>
                    PLAN DE VENTAS: @Model.PlanVenta.Cargo.NombreCargo
                </h6>
                <div class="clear">
                </div>
            </div>               
            <div class="formRow fluid">
            <div class="grid3">
            <div class="grid6">
                <label class="form-label">
                    Plan Venta Base (S/.):@*<span class="req">*</span>*@
                </label>
            </div>
            <div class="grid4">
                @Html.TextBoxFor(Function(m) (m.PlanVenta.ComisionEscalaRRVV.PlanVenta),
                New With {
                    .id = "IDPlanVentaBase_" & Model.PlanVenta.Cargo.IdCargoSuperior,
                    .class = "textTransform",
                    .onkeypress = "return val_09_2D(event)",
                    .onclick = "selectTextInput(event)",
                    .maxlength = "9",
                    .Value = IIf(Model.PlanVenta.ComisionEscalaRRVV.PlanVenta <> 0, Model.PlanVenta.ComisionEscalaRRVV.PlanVenta, "")
                })
                <div id="ID_MsgPlanVentaBaseRRVV_@Model.PlanVenta.Cargo.IdCargoSuperior">
                </div>
            </div>
        </div>  
            <div class="grid3">
                    <div class="grid6">
                        <label class="form-label">
                            Cantidad de Escalas:@*<span class="req">*</span>*@</label></div>
                    <div class="grid4">
                        @Html.TextBoxFor(Function(m) (m.PlanVenta.ComisionEscalaRRVV.CantidadEscalas),
                        New With {
                            .id = "IDCantidadEscalasRRVV_" & Model.PlanVenta.Cargo.IdCargoSuperior,
                            .class = "textTransform",
                            .onkeypress = "return val_09(event)",
                            .onclick = "selectTextInput(event)",
                            .maxlength = "2",
                        .Value = IIf(Model.PlanVenta.ComisionEscalaRRVV.CantidadEscalas <> 0, Model.PlanVenta.ComisionEscalaRRVV.CantidadEscalas, "")
                        })                                   
                        <div id="IDMsgCantidadBono_@Model.PlanVenta.Cargo.IdCargoSuperior">
                        </div>
                    </div>
                    <script type="text/javascript">
                        $(function () {
                            $("#IDGenerarPeriodoComisionRRVV_@Model.PlanVenta.Cargo.IdCargoSuperior").click()
                        })                                
                    </script>
        </div>                            
            <div class="grid3">
                        <div class="grid6">
                            <label class="form-label">
                                Tiempo Servicio:@*<span class="req">*</span>*@
                            </label>
                        </div>
                        <div class="grid4">
                            @Html.TextBoxFor(Function(m) (m.PlanVenta.ComisionEscalaRRVV.TiempoServicio),
                            New With {
                                .id = "IDTiempoServicio_" & Model.PlanVenta.Cargo.IdCargoSuperior,
                                .class = "textTransform",
                                .onkeypress = "return val_09_2D(event)",
                                .onclick = "selectTextInput(event)",
                                .maxlength = "2",
                            .Value = IIf(Model.PlanVenta.ComisionEscalaRRVV.TiempoServicio <> 0, Model.PlanVenta.ComisionEscalaRRVV.TiempoServicio, "")
                            })
                            <div id="IDMsgTiempoServicio_@Model.PlanVenta.Cargo.IdCargoSuperior">
                            </div>
                        </div>
                    </div>
                @Html.Hidden("HD_FirstTimeJefe_" & Model.PlanVenta.Cargo.IdCargoSuperior, True)
                @Html.Hidden("HD_FirstTimeRRVV_" & Model.PlanVenta.Cargo.IdCargoSuperior, True)
                @Html.HiddenFor(Function(m) m.PlanVenta.ComisionEscalaRRVV.Completo_, New With {.id = "HDCompletoRRVV_" & Model.PlanVenta.Cargo.IdCargoSuperior})
                @Html.HiddenFor(Function(m) m.PlanVenta.ComisionEscalaRRVV.Completo, New With {.id = "HDCompletoRRVV" & Model.PlanVenta.Cargo.IdCargoSuperior})
            <div class="grid3">
                <input id="IDGuardarPeriodoComisionRRVV_@Model.PlanVenta.Cargo.IdCargoSuperior" style="cursor: pointer;" type="button" class="buttonS bBlue formSubmit group_button visibleVer"
                    onclick="GuardarPlanVentaRRVV($('#frmPlanVenta_@Model.PlanVenta.Cargo.IdCargoSuperior'),@Model.PlanVenta.Cargo.IdCargoSuperior)"
                    value="Guardar"/>

                <input id="IDGenerarPeriodoComisionRRVV_@Model.PlanVenta.Cargo.IdCargoSuperior" style="cursor: pointer;" type="button" class="buttonS bBlue formSubmit group_button visibleVer"
                onclick="GenerarPlanVentaRRVV(@Model.PlanVenta.Cargo.IdCargoSuperior,@Model.PlanVenta.Cargo.IdCargo);"
                value="Generar"/>
            </div>                             
            </div>
                        
    <div id="BonificacionRRVV_@Model.PlanVenta.Cargo.IdCargoSuperior">
        @Html.Partial(ParametrosPartialView.Comision_GestionarPlanVentasRRVV, Model)
    </div>
 @Html.Hidden("HD_ModificaPlanRRVV",True,New With{.id="HD_ModificaPlanRRVV"})              
<div class="clear"></div></div>      
            
    '</div>           
    End Using

</div>

<script type="text/javascript" language="javascript">
    var Opcion = $("#IdEstadoComision").val();

    if (Opcion == 14 || Opcion == 18) {
        $('.visibleVer').css('display', 'none');
    }
</script>
