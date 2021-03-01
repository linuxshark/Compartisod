@ModelType Sodimac.VentaEmpresa.Web.Mvc.MantenimientoViewModel
<div id="contenedor-grid-Perfil">
    @Code
        Dim gridCarteraClientes As New WebGrid(rowsPerPage:=Model.Paginacion.PageSize, ajaxUpdateContainerId:="contenedor-grid-Perfil", ajaxUpdateCallback:="SetTotalRegistrosCarteraClientes")
        gridCarteraClientes.Bind(Model.Paginacion.ListaClienteCartera, autoSortAndPage:=False, rowCount:=Model.Paginacion.TotalRows)
        @gridCarteraClientes.GetHtml(
         headerStyle:="fix_head", rowStyle:="fix_td", alternatingRowStyle:="fix_td", footerStyle:="pagination",
         htmlAttributes:=New With {.id = "GrillaPerfiles", .class = "tDefault"},
         mode:=WebGridPagerModes.All,
         firstText:="<< Primera",
         previousText:="< Anterior",
         nextText:="Siguiente >",
         lastText:="Última >>",
         columns:=gridCarteraClientes.Columns(
         gridCarteraClientes.Column("RUC", "RUC", canSort:=True, style:="person"),
         gridCarteraClientes.Column("RazonSocial", "Razón Social", canSort:=True, style:="person"),
         gridCarteraClientes.Column("Sucursal", "Código Sucursal", canSort:=True, style:="person"),
         gridCarteraClientes.Column("CodigoSucursal", "Sucursal", canSort:=True, style:="person"),
         gridCarteraClientes.Column("CodigoOfisis", "Código Ofisis", canSort:=True, style:="person"),
         gridCarteraClientes.Column("FechaInicio", "Inicio", canSort:=True, style:="person"),
         gridCarteraClientes.Column("FechaFin", "Fin", canSort:=True, style:="person"),
         gridCarteraClientes.Column("Mes", "Mes", canSort:=True, style:="person"),
         gridCarteraClientes.Column("Anio", "Año", canSort:=True, style:="person"),
         gridCarteraClientes.Column("FechaRegistro", "Fecha de Carga", canSort:=True, style:="person")
         )
         )
        @Html.HiddenFor(Function(m) m.Paginacion.DescRegistrosPorPaginas, New With {.id = "hdfTotalRegistros"})
        @Html.HiddenFor(Function(m) m.Paginacion.ListaClienteCartera.Count, New With {.id = "countListaCarteraCliente"})
    End Code
    @If (Not Model.Paginacion.ListaClienteCartera Is Nothing) Then
        If (Not Model.Paginacion.ListaClienteCartera.Count = 0) Then
            @<script type="text/javascript" language="javascript">
                 $("#GrillaCarteraClientes tfoot tr:last td").prepend("<a id='tfootPage' class='total_registros'></a>");
                 $("#tfootPage").html($('#hdfTotalRegistros').val());

            </script>
        Else
            @<span>&nbsp;&nbsp;&nbsp;No se encontraron resultados</span>
        End If
    Else
        @<span>&nbsp;&nbsp;&nbsp;No se encontraron resultados</span>
    End If
</div>