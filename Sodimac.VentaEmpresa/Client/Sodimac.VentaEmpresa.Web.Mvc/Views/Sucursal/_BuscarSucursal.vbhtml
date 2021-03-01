@ModelType  Sodimac.VentaEmpresa.Web.Mvc.SucursalesViewModel
@If (Not Model.Paginacion.ListaSucursal Is Nothing) Then
    If (Not Model.Paginacion.ListaSucursal.Count = 0) Then
        
        Dim gridVentas = New WebGrid(rowsPerPage:=Model.Paginacion.PageSize, ajaxUpdateContainerId:="contendor-grid-sucursal", ajaxUpdateCallback:="SetTotalRegistros")
        gridVentas.Bind(Model.Paginacion.ListaSucursal, autoSortAndPage:=False, rowCount:=Model.Paginacion.TotalRows)
    @gridVentas.GetHtml(
    headerStyle:="fix_head", rowStyle:="fix_td", alternatingRowStyle:="fix_td", footerStyle:="pagination",
    htmlAttributes:=New With {.id = "dgvDatos", .class = "tDefault"},
    mode:=WebGridPagerModes.All,
    firstText:="<< Primera",
    previousText:="< Anterior",
    nextText:="Siguiente >",
    lastText:="Última >>",
            columns:=gridVentas.Columns(
                gridVentas.Column("Descripcion", "Sucursal", canSort:=True, style:="person"),
                gridVentas.Column("Zona.DescripcionCorta", "Zona", canSort:=True, style:="person"),
                gridVentas.Column("Direccion", "Ubigeo ", canSort:=True, style:="person"),
                gridVentas.Column("EmpleadoCargo.DescripcionCargo", "Cargo Asignado", canSort:=True, style:="person")))',
        'gridVentas.Column("ClienteVenta.FechaRegistro", "Fecha Registro", canSort:=True, Style:="person", Format:=
            'Function(item)
        '    Return Format(item.ClienteVenta.FechaRegistro, "dd/MM/yyyy")
        'End Function),
    ' gridVentas.Column("ClienteVenta.FechaActivacion", "Fecha Activación", canSort:=True, Style:="person", Format:=
        'Function(item)
        '    Return Format(item.ClienteVenta.FechaActivacion, "dd/MM/yyyy")
        'End Function),
        ' gridVentas.Column("ClienteVenta.FechaModificacion", "Fecha Modificación", canSort:=True, Style:="person", Format:=
        'Function(item)
        '    Return Format(item.ClienteVenta.FechaModificacion, "dd/MM/yyyy")
        'End Function)
        ''))
             
    @Html.HiddenFor(Function(m) m.Paginacion.DescRegistrosPorPaginas, New With {.id = "hdfTotalRegistros"})
    Else
    @<span>&nbsp;&nbsp;&nbsp;No se encontraron resultados en éste periodo</span>
    End If
Else
    @<span>&nbsp;&nbsp;&nbsp;No se encontraron resultados en éste periodo</span>
End If
<script type="text/javascript" language="javascript">
    $("#dgvDatos tfoot tr:last td").prepend("<a id='tfootPage' class='total_registros'></a>");
    $("#tfootPage").html($('#hdfTotalRegistros').val());

    function SetTotalRegistros() {

        $("#dgvDatos tfoot tr:last td").prepend("<a id='tfootPage' class='total_registros'></a>");
        $("#tfootPage").html($('#hdfTotalRegistros').val());
    }

    $(function () {
        $('th a, tfoot a').live('click', function () {
            $(this).attr('href', '#dgvDatos');
            return false;
        });
    });
</script>