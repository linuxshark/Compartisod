@ModelType Sodimac.VentaEmpresa.Web.Mvc.AutorizacionesViewModel
<div id="div_grilla_Contado">
    @Code
        @If (Model.PaginacionContado.ListaClienteVenta.Count < 1) Then
            @<p>No hay cliente(s) contado a autorizar</p>
        Else
            Dim gridVentas = New WebGrid(rowsPerPage:=Model.PaginacionContado.PageSize, ajaxUpdateContainerId:="div_grilla_Contado", ajaxUpdateCallback:="SetTotalRegistrosContado")
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
                gridVentas.Column(header:="Anotación", Format:=
                Function(item)
                    Return Html.TextBox(" ", Nothing,
                    New With {
                        .id = "Tb_" & item.IdCliente,
                        .maxlength = 1200
                    })
                End Function),
                gridVentas.Column(header:="Aprobar", Format:=
                Function(item)
                    Return Html.CheckBox("ncheck", False,
                    New With {
                        .id = "Check",
                        .IdCliente = item.IdCliente,
                        .Class = "clCheck"
                    })
                End Function)
                )
            )
            @Html.HiddenFor(Function(m) m.PaginacionContado.TotalRows, New With {.id = "Contado_RowCount"})
            @Html.HiddenFor(Function(m) m.PaginacionContado.PageSize, New With {.id = "Contado_RowsPerPage"})
            @Html.HiddenFor(Function(m) m.PaginacionContado.DescRegistrosPorPaginas, New With {.id = "Contado_FooterDesc"})   
        End If
    End Code
</div>
