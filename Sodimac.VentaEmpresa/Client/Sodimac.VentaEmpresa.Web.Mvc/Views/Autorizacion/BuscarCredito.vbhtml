@ModelType Sodimac.VentaEmpresa.Web.Mvc.AutorizacionesViewModel

<div id="div_grilla_Credito">
    @Code
        @If (Model.PaginacionCredito.ListaClienteVenta.Count < 1) Then
            @<p>No hay cliente(s) credito a autorizar</p>
        Else
            Dim gridVentas = New WebGrid(rowsPerPage:=Model.PaginacionCredito.PageSize, ajaxUpdateContainerId:="div_grilla_Credito", ajaxUpdateCallback:="SetTotalRegistrosCredito")
            gridVentas.Bind(Model.PaginacionCredito.ListaClienteVenta, autoSortAndPage:=False, rowCount:=Model.PaginacionCredito.TotalRows)
            @gridVentas.GetHtml(
            headerStyle:="fix_head", rowStyle:="fix_td", alternatingRowStyle:="fix_td", footerStyle:="pagination",
            htmlAttributes:=New With {.id = "grilla_Credito", .class = "tDefault"},
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
                Return Html.CheckBox("ncheck2", False,
                New With {
                    .id = "Check",
                    .IdCliente = item.IdCliente
                })
            End Function)
                )
            )
            @Html.HiddenFor(Function(m) m.PaginacionCredito.TotalRows, New With {.id = "Credito_RowCount"})
            @Html.HiddenFor(Function(m) m.PaginacionCredito.PageSize, New With {.id = "Credito_RowsPerPage"})
            @Html.HiddenFor(Function(m) m.PaginacionCredito.DescRegistrosPorPaginas, New With {.id = "Credito_FooterDesc"})        
        End If
    End Code
<div>