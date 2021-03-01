@ModelType Sodimac.VentaEmpresa.Web.Mvc.ComisionViewModel


@*sto ya no se usa*@
<div class="widget">
    <div class="whead">
        <h6>
            Bonificación RRVV</h6>
        <div class="clear">
        </div>
    </div>
    <table width="100%" cellspacing="0" cellpadding="0" class="tDefault" id="ID_TableBonosRRVV" >
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
            @If Model.PlanVenta.ListaComisionEscalaDetalleRRVV IsNot Nothing Then
                For i As Integer = 0 To (Model.PlanVenta.ListaComisionEscalaDetalleRRVV.Count) - 1
                @<tr>
                    <td>
                        @(i+1)
                    </td>
                    <td>
                        <div class="moreFields" style="text-align: center">                           
                            @Html.TextBoxFor(Function(m) m.PlanVenta.ListaComisionEscalaDetalleRRVV(i).PorcentajeInicial,
                                             New With {
                                                 .style = "width:100px; text-align:center;",
                                                 .onkeypress = "return val_09(event)",
                                                 .maxlength = "6",
                                                 .autocomplete = "off",
                                                 .id = "ID_PorcIni_" & i,
                                                 .onclick = "selectTextInput(event)",
                                                 .onpaste = "return false;",
                                                 .Value = CInt(Model.PlanVenta.ListaComisionEscalaDetalleRRVV(i).PorcentajeInicial),
                                                 .class = "block"
                                             })
                        </div>
                    </td>
                    <td>
                        <div class="moreFields" style="text-align: center">
                            @Html.TextBoxFor(Function(m) m.PlanVenta.ListaComisionEscalaDetalleRRVV(i).PorcentajeFinal,
                                             New With {
                                                 .style = "width:100px; text-align:center;",
                                                 .onkeypress = "return val_09(event)",
                                                 .maxlength = "6",
                                                 .autocomplete = "off",
                                                 .id = "ID_PorcFin_" & i,
                                                 .onclick = "selectTextInput(event)",
                                                 .onpaste = "return false;",
                                                 .Value = CInt(Model.PlanVenta.ListaComisionEscalaDetalleRRVV(i).PorcentajeFinal),
                                                 .class = "block"
                                             })
                        </div>
                    </td>
                    <td>
                        <div class="moreFields" style="text-align: center">
                            @Html.TextBoxFor(Function(m) m.PlanVenta.ListaComisionEscalaDetalleRRVV(i).Bono,
                                             New With {
                                                 .style = "width:100px; text-align:center;",
                                                 .onkeypress = "return val_09(event)",
                                                 .maxlength = "12",
                                                 .autocomplete = "off",
                                                 .id = "ID_Bono_" & i,
                                                 .onclick = "selectTextInput(event)",
                                                 .onpaste = "return false;",
                                                 .Value = IIf(CInt(Model.PlanVenta.ListaComisionEscalaDetalleRRVV(i).Bono) <> 0, CInt(Model.PlanVenta.ListaComisionEscalaDetalleRRVV(i).Bono), ""),
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


<script type="text/javascript" language="javascript">
    var Opcion = $("#IdEstadoComision").val();

    if (Opcion == 14 || Opcion == 18) {
        $('.block').attr("disabled", true).addClass("ui-state-disabled");
    }
</script>