@ModelType Sodimac.VentaEmpresa.Web.Mvc.ProcesoViewModel

@If (Not Model.ListaProcesoCargaEmpleados Is Nothing) Then
    If (Not Model.ListaProcesoCargaEmpleados.Count = 0) Then
        Dim gridConsignaciones As New WebGrid(rowsPerPage:=Model.PaginacionEmpleado.RowsPerPage, ajaxUpdateContainerId:="contenedor-grid-Servicio", ajaxUpdateCallback:="Load")
        gridConsignaciones.Bind(Model.ListaProcesoCargaEmpleados, autoSortAndPage:=False, rowCount:=Model.PaginacionEmpleado.TotalRows)
           @gridConsignaciones.GetHtml(
                headerStyle:="fix_head", rowStyle:="fix_td", alternatingRowStyle:="fix_td", footerStyle:="pagination",
                htmlAttributes:=New With {.id = "dgvDatos", .class = "tDefault"},
                mode:=WebGridPagerModes.All,
                firstText:="<< Primera",
                previousText:="< Anterior",
                nextText:="Siguiente >",
                lastText:="Última >>",
                columns:=gridConsignaciones.Columns(gridConsignaciones.Column("Nombres", "Nombre", canSort:=True, style:="person"),
                gridConsignaciones.Column("Apellidos", "Apellidos", canSort:=True, style:="person"),
                gridConsignaciones.Column("DNI", "Número Documento", canSort:=True, style:="person"),
                gridConsignaciones.Column("CodigoOfisis", "CodigoOfisis", canSort:=True, style:="person"),
                gridConsignaciones.Column("FechaContrato", "FechaContrato", canSort:=True, style:="person", Format:=@@<text>@(String.Format("{0:dd/MM/yyyy}", item("FechaContrato")))</text>),
                gridConsignaciones.Column("FechaNacimiento", "FechaNacimiento", canSort:=True, style:="person", Format:=@@<text>@(String.Format("{0:dd/MM/yyyy}", item("FechaNacimiento")))</text>),
                gridConsignaciones.Column("UsuarioIngreso", "UsuarioIngreso", canSort:=True, style:="person"),
                gridConsignaciones.Column("Celular1", "Celular1", canSort:=True, style:="person"),
                gridConsignaciones.Column("Celular2", "Celular2", canSort:=True, style:="person"),
                gridConsignaciones.Column("Telefono", "Telefono", canSort:=True, style:="person"),
                gridConsignaciones.Column("Email", "Email", canSort:=True, style:="person"),
                gridConsignaciones.Column("Direccion", "Direccion", canSort:=True, style:="person"),
                gridConsignaciones.Column("EmpleadoPerfil.DescripcionPerfil", "Perfil", canSort:=True, style:="person"),
                gridConsignaciones.Column("Zona.Descripcion", "Zona", canSort:=True, style:="person"),
                gridConsignaciones.Column("Sucursal.DescripcionSucursal", "Sucursal", canSort:=True, style:="person"),
                gridConsignaciones.Column("EscalaTiempoInicial", "EscalaTiempoInicial", canSort:=True, style:="person"),
                gridConsignaciones.Column("FechaDesde", "FechaDesde", canSort:=True, style:="person", Format:=@@<text>@(String.Format("{0:dd/MM/yyyy}", item("FechaDesde")))</text>)
            ))
    @Html.HiddenFor(Function(m) m.PaginacionEmpleado.DescRegistrosPorPaginas, New With {.id = "hdfTotalRegistros"})
         @Html.HiddenFor(Function(m) m.grabar, New With {.id = "hdfgrabar"})
End If

Else
    @* @<span>&nbsp;&nbsp;&nbsp;Archivo vacío o se produjo un error</span>*@
    @<div>
        <p>@Model.Mensaje</p>
    </div>
End If
<script type="text/javascript" language="javascript">
    //$("#dgvDatos tfoot tr:last td").prepend("<a id='tfootPage' class='total_registros'></a>");
    //    $("#tfootPage").html($('#hdfTotalRegistros').val());

    $(function () {
        $("#dgvDatos tfoot tr:last td").prepend("<a id='tfootPage' class='total_registros'></a>")
        $("#tfootPage").html($('#hdfTotalRegistros').val())

    })
    //function SetTotalResgitros() {

    //    $("#dgvDatos tfoot tr:last td").prepend("<a id='tfootPage' class='total_registros'></a>");
    //    $("#tfootPage").html($('#hdfTotalRegistros').val());
    //}

    $(function () {
        $('th a, tfoot a').live('click', function () {
            $(this).attr('href', '#dgvDatos');
            return false;
        });
    });

    $(function () {
        $('#dgvDatos tfoot a').click(function () {
            if ($(this).attr('class') == undefined) {
                $("#GrillaImportarEmpleado").load("/Proceso/GrillaImportarEmpleado?page=" + $(this).attr('href').slice(-1))
                $(this).removeAttr('href');
            }
        });
    });
</script>
