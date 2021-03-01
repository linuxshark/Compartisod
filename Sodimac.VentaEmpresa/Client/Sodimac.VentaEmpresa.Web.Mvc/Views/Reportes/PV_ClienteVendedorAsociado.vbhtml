@ModelType Sodimac.VentaEmpresa.Web.Mvc.ClienteVendedorAsociadoViewModel
<div id="contenedor-grid-ClienteVendedorAsociado">
    @If (Not Model.listaClienteVenta Is Nothing) Then
        If (Not Model.listaClienteVenta.Count = 0) Then
            Dim gridClienteVendedorAsociado As New WebGrid(rowsPerPage:=Model.Paginacion.RowsPerPage, ajaxUpdateContainerId:="contenedor-grid-ClienteVendedorAsociado", ajaxUpdateCallback:="PaintFooterGrid")
            gridClienteVendedorAsociado.Bind(Model.listaClienteVenta, autoSortAndPage:=False, rowCount:=Model.Paginacion.TotalRows)
        @gridClienteVendedorAsociado.GetHtml(
                headerStyle:="fix_head", rowStyle:="fix_td", alternatingRowStyle:="fix_td", footerStyle:="pagination",
                htmlAttributes:=New With {.id = "dgvDatos", .class = "tDefault"},
                mode:=WebGridPagerModes.All,
                firstText:="<< Primera",
                previousText:="< Anterior",
                nextText:="Siguiente >",
                lastText:="Última >>",
                columns:=gridClienteVendedorAsociado.Columns(
                gridClienteVendedorAsociado.Column("RUC", "RUC", canSort:=True, style:="person"),
                gridClienteVendedorAsociado.Column("RazonSocial", "Razón Social", canSort:=True, style:="person"),
                gridClienteVendedorAsociado.Column("NombresApellidos", "Asignado A:", canSort:=True, style:="person"),
                gridClienteVendedorAsociado.Column("NombreZona", "Zona", canSort:=True, style:="center"),
                gridClienteVendedorAsociado.Column("RepresentanteVenta", "Jefe Regional", canSort:=True, style:="person"),
            gridClienteVendedorAsociado.Column("FActivacion", "F. Activación", canSort:=True, style:="center")
                )
            )
        @Html.HiddenFor(Function(m) m.Paginacion.DescRegistrosPorPaginas, New With {.id = "hdfTotalRegistros"})
        @Html.HiddenFor(Function(m) m.Paginacion.TotalRows, New With {.id = "TotalRows"})
        End If
        @*Else
            @<span>&nbsp;&nbsp;&nbsp;Archivo vacío o se produjo un error</span>*@
        'gridClienteVendedorAsociado.Column("IdEmpleadoPrincipal", "Asignado A:", canSort:=True, style:="center"),
    End If
</div>