@ModelType Sodimac.VentaEmpresa.Web.Mvc.ComisionViewModel
<style>
.inactive{background:#CCCCE0!important;filter:none}
</style>
<div style="width:98.6%;margin:0 auto;">
 @If Model.PlanVenta.ListaComisionEscalaTiempoServicio.Count > 0 Then
    @<div class="formRow fluid" style="margin-bottom:-20px">
    <div class="grid2"><b>Periodo</b></div>
    <div class="grid1"><b>Mes</b></div>
    <div class="grid2"><b>Plan Mes</b></div>
    <div class="grid2"><b>% Inicial</b></div>
    <div class="grid2"><b>Bono Min.</b></div>
    <div class="grid2"><b>% Final</b></div>
    <div class="grid2"><b>Bono Max.</b></div>
    </div>
     
   @<div class="widget togglesGroup">
  
       @For j As Integer = 0 To Model.PlanVenta.ListaComisionEscalaTiempoServicio.Count - 1
          
                @<div class="whead closed formRow" id="toggleOpened">
                    <div class="grid2"><h6>@Model.PlanVenta.ListaComisionEscalaTiempoServicio(j).ComisionPeriodo.NombrePeriodo</h6></div>
                    <div class="grid1">@(j)</div>
                    <div class="grid2">@Html.TextBoxFor(Function(m) m.PlanVenta.ListaComisionEscalaTiempoServicio(j).PlanVenta,
                                                        New With {.onkeypress = "return val_09(event)",
                                                                 .maxlength = "9",
                                                                  .class = "textTransform bur block",
                                                                 .onclick = "selectTextInput(event)"
                                                                 })</div>
                    <div class="grid2"> <label id=@String.Concat("PorcInicial_", j)>@CInt(Model.PlanVenta.ListaComisionEscalaTiempoServicio(j).PorcInicial)</label></div>
                    <div class="grid2"> <label id=@String.Concat("BonoMin_", j)>@CInt(Model.PlanVenta.ListaComisionEscalaTiempoServicio(j).BonoMin)</label></div>
                    <div class="grid2"><label id=@String.Concat("PorcFinal_", j)>@CInt(Model.PlanVenta.ListaComisionEscalaTiempoServicio(j).PorcFinal)</label></div>
                    <div class="grid2"><label id=@String.Concat("BonoMax_", j)>@CInt(Model.PlanVenta.ListaComisionEscalaTiempoServicio(j).BonoMax)</label></div>

                    @Html.HiddenFor(Function(m) m.PlanVenta.ListaComisionEscalaTiempoServicio(j).PorcInicial, New With {.id = "PorcInicial__" & j})
                    @Html.HiddenFor(Function(m) m.PlanVenta.ListaComisionEscalaTiempoServicio(j).BonoMin, New With {.id = "BonoMin__" & j})
                    @Html.HiddenFor(Function(m) m.PlanVenta.ListaComisionEscalaTiempoServicio(j).PorcFinal, New With {.id = "PorcFinal__" & j})
                    @Html.HiddenFor(Function(m) m.PlanVenta.ListaComisionEscalaTiempoServicio(j).BonoMax, New With {.id = "BonoMax__" & j})
                    @*Estos Hidden son para poder serializar el modelo*@

                    <div class="clear"></div>
                </div>
                @<div class="body formRow"  style="margin-bottom:20px;margin-top:-10px"> @*Aquí empieza el cuerpo del Toogle*@               
                <div class="widget">    
                     <table width="100%" cellspacing="0" cellpadding="0" class="tDefault" id="ID_TableBonosRRVV">
                        <thead>
                            <tr>
                                <td>
                                    Escala
                                </td>
                                <td>
                                    (%) Inicial
                                </td>
                                <td>
                                    (%) Final
                                </td>
                                <td>
                                    Bono (S/.)
                                </td>
                            </tr>
                        </thead>
                        <tbody align="center">
                            @If Model.PlanVenta.ListaComisionEscalaTiempoServicio IsNot Nothing Then
                            For i As Integer = 0 To (Model.PlanVenta.ListaComisionEscalaTiempoServicio(j).ListaComisionEscalaDetalleRRVV.Count) - 1
                                @<tr>
                                    <td>
                                        @(i+1)
                                    </td>
                                    <td>
                                        <div class="moreFields" style="text-align: center">                           
                                            @Html.TextBoxFor(Function(m) m.PlanVenta.ListaComisionEscalaTiempoServicio(j).ListaComisionEscalaDetalleRRVV(i).PorcentajeInicial,
                                                             New With {
                                                                 .style = "width:100px; text-align:center;",
                                                                 .onkeypress = "return val_09(event)",
                                                                 .onkeyup = "return MuestraValorPorcInicial('" & j & "','" & i & "','ID_PorcIni_')",
                                                                 .maxlength = "6",
                                                                 .autocomplete = "off",
                                                                 .id = "ID_PorcIni_" & j & "_" & i,
                                                                 .onclick = "selectTextInput(event)",
                                                                 .onpaste = "return false;",
                                                                 .Value = CInt(Model.PlanVenta.ListaComisionEscalaTiempoServicio(j).ListaComisionEscalaDetalleRRVV(i).PorcentajeInicial),
                                                                 .class = "block"
                                                             })
                                        </div>
                                    </td>
                                    <td>
                                        <div class="moreFields" style="text-align: center">
                                            @Html.TextBoxFor(Function(m) m.PlanVenta.ListaComisionEscalaTiempoServicio(j).ListaComisionEscalaDetalleRRVV(i).PorcentajeFinal,
                                                             New With {
                                                                 .style = "width:100px; text-align:center;",
                                                                 .onkeypress = "return val_09(event)",
                                                                 .onkeyup = "return MuestraValorPorcFinal('" & j & "','" & i & "','ID_PorcFin_','" & Model.PlanVenta.ListaComisionEscalaTiempoServicio(j).ListaComisionEscalaDetalleRRVV.Count - 1 & "')",
                                                                 .maxlength = "6",
                                                                 .autocomplete = "off",
                                                                 .id = "ID_PorcFin_" & j & "_" & i,
                                                                 .onclick = "selectTextInput(event)",
                                                                 .onpaste = "return false;",
                                                                 .Value = CInt(Model.PlanVenta.ListaComisionEscalaTiempoServicio(j).ListaComisionEscalaDetalleRRVV(i).PorcentajeFinal),
                                                                 .class = "block"
                                                             })
                                        </div>
                                    </td>
                                    <td>
                                        <div class="moreFields" style="text-align: center">
                                            @Html.TextBoxFor(Function(m) m.PlanVenta.ListaComisionEscalaTiempoServicio(j).ListaComisionEscalaDetalleRRVV(i).Bono,
                                                             New With {
                                                                 .style = "width:100px; text-align:center;",
                                                                 .onkeypress = "return val_09(event)",
                                                                 .onkeyup = "return MuestraValorBono('" & j & "','" & i & "','ID_Bono_','" & Model.PlanVenta.ListaComisionEscalaTiempoServicio(j).ListaComisionEscalaDetalleRRVV.Count - 1 & "')",
                                                                 .maxlength = "12",
                                                                 .autocomplete = "off",
                                                                 .id = "ID_Bono_" & j & "_" & i,
                                                                 .onclick = "selectTextInput(event)",
                                                                 .onpaste = "return false;",
                                                                 .Value = IIf(CInt(Model.PlanVenta.ListaComisionEscalaTiempoServicio(j).ListaComisionEscalaDetalleRRVV(i).Bono) <> 0, CInt(Model.PlanVenta.ListaComisionEscalaTiempoServicio(j).ListaComisionEscalaDetalleRRVV(i).Bono), ""),
                                                                 .class = "block"
                                                             })
                                        </div>
                                    </td>
                                </tr>
                            Next
                            End If
                        </tbody>
                    </table>
                </div> 
                </div>          
     Next
   </div> 
     End If       
</div>
<script type="text/javascript" language="javascript">
    var Opcion = $("#IdEstadoComision").val();

    if (Opcion == 14 || Opcion == 18) {
        $('.block').attr("disabled", true).addClass("ui-state-disabled");
    }
</script>