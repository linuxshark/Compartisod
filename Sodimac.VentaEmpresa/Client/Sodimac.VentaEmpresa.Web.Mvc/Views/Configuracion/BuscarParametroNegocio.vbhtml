@ModelType Sodimac.VentaEmpresa.Web.Mvc.ConfiguracionViewModel 

<div id="Div_grilla_Negocio">
    @Code
        @If (Model.PagConfNegocio.ListaParametro.Count < 1) Then
            @<p>No hay parámetros de configuración</p>
        Else
            Dim gridNegocio = New WebGrid(rowsPerPage:=Model.PagConfNegocio.PageSize, ajaxUpdateContainerId:="Div_grilla_Negocio", ajaxUpdateCallback:="SetTotalRegistrosNegocio")
            gridNegocio.Bind(Model.PagConfNegocio.ListaParametro, autoSortAndPage:=False, rowCount:=Model.PagConfNegocio.TotalRows)
        @gridNegocio.GetHtml(
        headerStyle:="fix_head", rowStyle:="fix_td", alternatingRowStyle:="fix_td", footerStyle:="pagination",
        htmlAttributes:=New With {.id = "grilla_Negocio", .class = "tDefault"},
        mode:=WebGridPagerModes.All,
        firstText:="<< Primera",
        previousText:="< Anterior",
        nextText:="Siguiente >",
        lastText:="Última >>",
        columns:=gridNegocio.Columns(
            gridNegocio.Column("Parametro", "Parámetro", canSort:=False, style:="person"),
            gridNegocio.Column("Valor1", "Valor1", canSort:=False, style:="person"),
            gridNegocio.Column("Descripcion1", "Descripcion1", canSort:=False, style:="person"),
            gridNegocio.Column("Valor2", "Valor2", canSort:=False, style:="person"),
            gridNegocio.Column("Descripcion2", "Descripcion2", canSort:=False, style:="person"),
            gridNegocio.Column("Valor3", "Valor3", canSort:=False, style:="person"),
            gridNegocio.Column("Descripcion3", "Descripcion3", canSort:=False, style:="person"),
            gridNegocio.Column("FechaDesde", "FechaDesde", canSort:=False, style:="person"),
            gridNegocio.Column("FechaHasta", "FechaHasta", canSort:=False, style:="person"),
            gridNegocio.Column(header:="Ver", format:=
            Function(item)
                    Return Html.ActionLink(" ", "GestionarParametro", "Configuracion", New With {.IdParametro = item.IdParametro}, New With {.class = "select_table", .title = "Ver Detalle"})
            End Function)
            )
        )
        @Html.HiddenFor(Function(m) m.PagConfNegocio.TotalRows, New With {.id = "RowCount"})
        @Html.HiddenFor(Function(m) m.PagConfNegocio.PageSize, New With {.id = "RowsPerPage"})
        @Html.HiddenFor(Function(m) m.PagConfNegocio.DescRegistrosPorPaginas, New With {.id = "FooterDesc"})
        End If
    End Code
</div>