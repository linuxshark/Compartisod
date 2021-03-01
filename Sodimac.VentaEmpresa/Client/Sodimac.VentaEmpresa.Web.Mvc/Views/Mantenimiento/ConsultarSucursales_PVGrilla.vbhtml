@ModelType Sodimac.VentaEmpresa.Web.Mvc.MantenimientoViewModel
    <div id="contenedor-grid-Sucursal">
    @Code
        Dim gridSucursal As New WebGrid(rowsPerPage:=Model.Paginacion.PageSize, ajaxUpdateContainerId:="contenedor-grid-Sucursal", ajaxUpdateCallback:="SetTotalRegistrosSucursal")
        gridSucursal.Bind(Model.Paginacion.ListaSucursalMantenimiento, autoSortAndPage:=False, rowCount:=Model.Paginacion.TotalRows)
            @gridSucursal.GetHtml(
                headerStyle:="fix_head", rowStyle:="fix_td", alternatingRowStyle:="fix_td", footerStyle:="pagination",
                htmlAttributes:=New With {.id = "GrillaSucursales", .class = "tDefault"},
                mode:=WebGridPagerModes.All,
                firstText:="<< Primera",
                previousText:="< Anterior",
                nextText:="Siguiente >",
                lastText:="Última >>",
                columns:=gridSucursal.Columns(
                gridSucursal.Column("Descripcion", "Nombre Sucursal", canSort:=True, style:="person"),
                gridSucursal.Column("Zona.NombreZona", "Nombre Zona", canSort:=True, style:="person"),
                gridSucursal.Column("DescripcionCorta", "Nombre Zona", canSort:=True, style:="person"),
                gridSucursal.Column("", "Editar", style:="center", format:=
                Function(item)
                        Dim control As String
                        control = String.Format("<a class={0}edit_table{0} title={0}Editar Sucursal{0} onClick={0}EditarSucursal('" & item.IdSucursal.ToString() & "','" & item.Descripcion.ToString() & "','" & item.Departamento.IdDepartamento.ToString() & "','" & item.Provincia.IdProvincia.ToString() & "','" & item.Distrito.IdDistrito.ToString() & "','" & item.Zona.IdZona.ToString() & "','" + item.Zona.NombreZona.ToString() & "','" + item.DescripcionCorta.ToString()  & "','"  & item.Direccion.ToString() & "'){0}    />", Chr(34))
                        Return Html.Raw(control)
                End Function
                ),
                gridSucursal.Column("", "Eliminar", style:="person", format:=
                Function(item)
                        Dim control As String
                        control = String.Format("<a class={0}desactivar_table{0} title= {0}Eliminar Sucursal{0} onClick={0}dialogEliminarSucursal('" & item.IdSucursal.ToString() & "'){0}/>", Chr(34))
                        Return Html.Raw(control)
                End Function
                )
            )
            )            
            @Html.HiddenFor(Function(m) m.Paginacion.DescRegistrosPorPaginas, New With {.id = "hdfTotalRegistros"})
            @Html.HiddenFor(Function(m) m.Paginacion.ListaSucursalMantenimiento.Count, New With {.id = "countListaSucursal"})
   End Code
@If (Not Model.Paginacion.ListaSucursalMantenimiento Is Nothing) Then
   If (Not Model.Paginacion.ListaSucursalMantenimiento.Count = 0) Then
        @<script type="text/javascript" language="javascript">
             $("#GrillaSucursales tfoot tr:last td").prepend("<a id='tfootPage' class='total_registros'></a>");
             $("#tfootPage").html($('#hdfTotalRegistros').val());

             $(function () {
                 $('th a, tfoot a').live('click', function () {
                     $(this).attr('href', '#GrillaSucursales');
                     return false;
                 });
             });
        </script>
    Else
        @<span>&nbsp;&nbsp;&nbsp;No se encontraron resultados</span>
    End If
Else
    @<span>&nbsp;&nbsp;&nbsp;No se encontraron resultados</span>
End If  
 </div>



