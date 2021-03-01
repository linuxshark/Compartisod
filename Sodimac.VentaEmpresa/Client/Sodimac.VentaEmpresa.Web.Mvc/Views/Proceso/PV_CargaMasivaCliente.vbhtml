@ModelType Sodimac.VentaEmpresa.Web.Mvc.CargaMasivaClienteViewModel

@If (Not Model.ListaCliente Is Nothing) Then
    If (Not Model.ListaCliente.Count = 0) Then
        Dim gridCMCliente As New WebGrid(rowsPerPage:=Model.PaginacionCliente.RowsPerPage, ajaxUpdateContainerId:="contenedor-grid-Servicio", ajaxUpdateCallback:="Load")
        gridCMCliente.Bind(Model.ListaCliente, autoSortAndPage:=False, rowCount:=Model.PaginacionCliente.TotalRows)
    @gridCMCliente.GetHtml(
                headerStyle:="fix_head", rowStyle:="fix_td", alternatingRowStyle:="fix_td", footerStyle:="pagination",
                htmlAttributes:=New With {.id = "dgvDatosCliente", .class = "tDefault"},
                mode:=WebGridPagerModes.All,
                firstText:="<< Primera",
                previousText:="< Anterior",
                nextText:="Siguiente >",
                lastText:="Última >>",
                columns:=gridCMCliente.Columns(gridCMCliente.Column("ClienteVenta.RazonSocial", "Razon Social", canSort:=True, style:="person"),
                gridCMCliente.Column("ClienteVenta.RUC", "RUC", canSort:=True, style:="person"),
                gridCMCliente.Column("ClienteVenta.NombreComercial", "Nombre Comercial", canSort:=True, style:="person"),
                gridCMCliente.Column("Departamento.Descripcion", "Departamento", canSort:=True, style:="person"),
                gridCMCliente.Column("Provincia.Descripcion", "Provincia", canSort:=True, style:="person"),
                gridCMCliente.Column("Distrito.Descripcion", "Distrito", canSort:=True, style:="person"),
                gridCMCliente.Column("ClienteVenta.Direccion", "Dirección", canSort:=True, style:="person"),
                gridCMCliente.Column("ClienteVenta.FechaIngreso", "Fecha Ingreso", canSort:=True, style:="person"),
                gridCMCliente.Column("ClienteVenta.FechaVigencia", "Fecha Vigencia", canSort:=True, style:="person"),
                gridCMCliente.Column("ClienteVenta.Grupo.NombreGrupo", "Grupo", canSort:=True, style:="person"),
                gridCMCliente.Column("ClienteVenta.ProcedenciaCapital", "Procedencia Capital", canSort:=True, style:="person"),
                gridCMCliente.Column("ClienteSector.Descripcion", "Sector Económico", canSort:=True, style:="person"),
                gridCMCliente.Column("ClienteCategoria.Descripcion", "Categoría", canSort:=True, style:="person"),
                gridCMCliente.Column("ClienteTipo.Descripcion", "Tipo", canSort:=True, style:="person"),
                gridCMCliente.Column("ClienteVenta.Autorizar", "Autorizar", canSort:=True, style:="person"),
                gridCMCliente.Column("ClienteContacto.TipoContancto.Descripcion", "Tipo Contancto", canSort:=True, style:="person"),
                gridCMCliente.Column("ClienteContacto.ClaseContacto.Descripcion", "Clase Contacto", canSort:=True, style:="person"),
                gridCMCliente.Column("ClienteContacto.Nombres", "Nombres Contacto", canSort:=True, style:="person"),
                gridCMCliente.Column("ClienteContacto.Apellidos", "Apellidos Contacto", canSort:=True, style:="person"),
                gridCMCliente.Column("ClienteContacto.Celular1", "Celular Contacto", canSort:=True, style:="person"),
                gridCMCliente.Column("ClienteContacto.Email", "Email Contacto", canSort:=True, style:="person")
                )
            )
    @Html.HiddenFor(Function(m) m.PaginacionCliente.DescRegistrosPorPaginas, New With {.id = "hdfTotalRegistrosCliente"})

    End If
@*Else
     @<span>&nbsp;&nbsp;&nbsp;Archivo vacío o se produjo un error</span>*@
End If

<script type="text/javascript" language="javascript">
    $(function () {
        $("#dgvDatosCliente tfoot tr:last td").prepend("<a id='tfootPageC' class='total_registros'></a>")
        $("#tfootPageC").html($('#hdfTotalRegistrosCliente').val())

    })

    $(function () {
        $('#dgvDatosCliente tfoot a').click(function () {
            if ($(this).attr('class') == undefined) {
                $("#GrillaCMCliente").load("/Proceso/CargarCMCliente?page=" + $(this).attr('href').slice(-1))
                $(this).removeAttr('href');
            }
        });
    });
</script>