@ModelType Sodimac.VentaEmpresa.Web.Mvc.AutorizacionesViewModel
<div id="div_grilla_Contado">
    @Code
        @If (Model.PaginacionContado.ListaClienteVenta.Count < 1) Then
            @<p>No hay cliente(s) contado a autorizar</p>
        Else
            Dim gridVentas = New WebGrid(rowsPerPage:=Model.PaginacionContado.PageSize, ajaxUpdateContainerId:="div_grilla_Contado", ajaxUpdateCallback:="SetTotalRegistros_Consulta_Contado_Credito")
            gridVentas.Bind(Model.PaginacionContado.ListaClienteVenta, autoSortAndPage:=False, rowCount:=Model.PaginacionContado.TotalRows)
            @gridVentas.GetHtml(
            headerStyle:="fix_head", rowStyle:="fix_td", alternatingRowStyle:="fix_td", footerStyle:="pagination",
            htmlAttributes:=New With {.id = "grilla_Contado", .class = "tDefault"},
            mode:=WebGridPagerModes.All,
            firstText:="<< Primera",
            previousText:="< Anterior",
            nextText:="Siguiente >",
            lastText:="Última >>",
            columns:=gridVentas.Columns(
                gridVentas.Column("RUC", "RUC", canSort:=False, style:="person"),
                gridVentas.Column("RazonSocial", "Razón Social", canSort:=False, style:="person"),
                gridVentas.Column("RepresentanteVenta", "RRVV", canSort:=False, style:="person"),
                gridVentas.Column("Motivo", "Motivo", canSort:=False, style:="person"),
                gridVentas.Column("ModoPagoDes", "Modo de Pago", canSort:=False, style:="person"),
                gridVentas.Column(header:="Acción", Format:=
                Function(item)
                    
                    Return Html.TextBox("Anotacion", item.Anotacion,
                    New With {
                        .id = "Tb_" & item.IdCliente,
                        .maxlength = 1200,
                        .disabled = "disabled"
                    })
                End Function),
                gridVentas.Column("FechaRegistro", "FechaRegistro"),
                gridVentas.Column("IdAprobado", "Aprobado / Por Aprobar", Format:=
                Function(item)
                   
                    If item.IdAprobado = 8 Then
                        Return Html.CheckBox("ncheck", True,
                        New With {
                            .id = "Check",
                           .Class = "clCheck",
                           .disabled = "disabled"
                        })
                    Else
                        Return Html.CheckBox("ncheck", False,
                        New With {
                            .id = "Check",
                            .Class = "clCheck",
                            .disabled = "disabled"
                        })
                        
                    End If
                    
                    
                End Function)
                )
            )
            @Html.HiddenFor(Function(m) m.PaginacionContado.TotalRows, New With {.id = "Contado_RowCount"})
            @Html.HiddenFor(Function(m) m.PaginacionContado.PageSize, New With {.id = "Contado_RowsPerPage"})
            @Html.HiddenFor(Function(m) m.PaginacionContado.DescRegistrosPorPaginas, New With {.id = "Contado_FooterDesc"})   
        End If
    End Code


@*@If (Not Model.PaginacionContado.ListaClienteVenta Is Nothing) Then
    If (Not Model.PaginacionContado.ListaClienteVenta.Count = 0) Then
        @<script type="text/javascript" language="javascript">
             $("#grilla_Contado tfoot tr:last td").prepend("<a id='tfootPage' class='total_registros'></a>");
             $("#tfootPage").html($('#Contado_FooterDesc').val());

             $(function () {
                 $('th a, tfoot a').live('click', function () {
                     $(this).attr('href', '#grilla_Contado');
                     return false;
                 });
             });
        </script>
    Else
        @<span>&nbsp;&nbsp;&nbsp;No se encontraron resultados</span>
    End If
Else
    @<span>&nbsp;&nbsp;&nbsp;No se encontraron resultados</span>
End If*@

</div>
