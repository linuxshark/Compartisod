@ModelType  Sodimac.VentaEmpresa.Web.Mvc.VentasViewModel
<div id="grid-planventas">
    @Code 
        Dim gridPlanventas = New WebGrid(rowsPerPage:=Model.Paginacion.PageSize, ajaxUpdateContainerId:="grid-planventas", ajaxUpdateCallback:="SetTotalRegistrosPlanventa")
        gridPlanventas.Bind(Model.Paginacion.ListaPlanVentaEmpleado, autoSortAndPage:=False, rowCount:=Model.Paginacion.TotalRows)
                @gridPlanventas.GetHtml(
                headerStyle:="fix_head", rowStyle:="fix_td", alternatingRowStyle:="fix_td", footerStyle:="pagination",
                htmlAttributes:=New With {.id = "dgvPlanventaEmpleado", .class = "tDefault"},
                mode:=WebGridPagerModes.All,
                firstText:="<< Primera",
                previousText:="< Anterior",
                nextText:="Siguiente >",
                lastText:="Última >>",
                columns:=gridPlanventas.Columns(
                    gridPlanventas.Column("ComisionPeriodo.NombrePeriodo", "Nombre Periodo", canSort:=False, style:="person"),
                    gridPlanventas.Column("ComisionPeriodo.FechaPeriodo", "Fecha Inicio - Fecha Fin", canSort:=False, style:="person"),
                    gridPlanventas.Column("ComisionEscala.TiempoServicio", "Tiempo Servicio", canSort:=False, style:="person"),
                    gridPlanventas.Column("ComisionEscala.PlanVenta", "Plan Base", canSort:=False, style:="person"),
                    gridPlanventas.Column("Cargo.NombreCargo", "Cargo Completo", canSort:=False, style:="person"),
                    gridPlanventas.Column("PlanVentaBase", "Nuevo Plan Venta ", canSort:=False, style:="person"),
                    gridPlanventas.Column("DescripcionMes", "Aplicar Desde Mes ", canSort:=False, style:="person"),
                    gridPlanventas.Column("FechaRegistro", "Fecha Registro", canSort:=False, style:="person", format:=
                    Function(item)
                            Return Format(item.FechaActivacion, "dd/MM/yyyy")
                    End Function),
                    gridPlanventas.Column("Activo", "Vigente", canSort:=False, style:="person", format:=
                    Function(item)
                            Return IIf(item.Activo = True, "SI", "NO")
                    End Function),
                    gridPlanventas.Column("Empleado.Activo", "Estado", canSort:=False, style:="person", format:=
                    Function(item)
                            Return IIf(item.Empleado.Activo = True, "Registrado", "Inactivo")
                    End Function))
                )
                @Html.HiddenFor(Function(m) m.Paginacion.DescRegistrosPorPaginas, New With {.id = "hdfTotalRegistros"})
                @Html.HiddenFor(Function(m) m.Paginacion.ListaPlanVentaEmpleado.Count, New With {.id = "countListaPlanVenta"})
     
    End Code
      @If (Not Model.Paginacion.ListaPlanVentaEmpleado Is Nothing) Then
          If (Not Model.Paginacion.ListaPlanVentaEmpleado.Count = 0) Then
              @<script type="text/javascript" language="javascript">
        $("#dgvPlanventaEmpleado tfoot tr:last td").prepend("<a id='tfootPage' class='total_registros'></a>");
        $("#tfootPage").html($('#hdfTotalRegistros').val());

//    function SetTotalRegistros() {
//        $("#dgvPlanventaEmpleado tfoot tr:last td").prepend("<a id='tfootPage' class='total_registros'></a>");
//        $("#tfootPage").html($('#hdfTotalRegistros').val());
//    }

    $(function () {
        $('th a, tfoot a').live('click', function () {
            $(this).attr('href', '#dgvPlanventaEmpleado');
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