@ModelType Sodimac.VentaEmpresa.Web.Mvc.ProcesoViewModel
@If (Not Model.ListaProcesoCarga Is Nothing) Then
    If (Not Model.ListaProcesoCarga.Count = 0) Then
        Dim gridConsignaciones As New WebGrid(rowsPerPage:=Model.RegistroPorPagina, ajaxUpdateContainerId:="contenedor-grid-Servicio", ajaxUpdateCallback:="Load")
        gridConsignaciones.Bind(Model.ListaProcesoCarga, autoSortAndPage:=False, rowCount:=Model.TotalRegistros)
    @gridConsignaciones.GetHtml(
                headerStyle:="fix_head", rowStyle:="fix_td", alternatingRowStyle:="fix_td", footerStyle:="pagination",
                htmlAttributes:=New With {.id = "dgvDatos", .class = "tDefault"},
                mode:=WebGridPagerModes.All,
                firstText:="<< Primera",
                previousText:="< Anterior",
                nextText:="Siguiente >",
                lastText:="Última >>",
                columns:=gridConsignaciones.Columns(gridConsignaciones.Column("TipoDocumento", "Tipo Documento", canSort:=True, style:="person"),
                gridConsignaciones.Column("IdSucursal", "Sucursal", canSort:=True, style:="person"),
                gridConsignaciones.Column("NumeroDocumento", "Número Documento", canSort:=True, style:="person"),
                gridConsignaciones.Column("Fecha", "Fecha", canSort:=True, Style:="person", Format:=@@<text>@(String.Format("{0:dd/MM/yyyy}", item("Fecha")))</text>),
                gridConsignaciones.Column("Ruc", "RUC", canSort:=True, style:="person"),
                gridConsignaciones.Column("Sku", "SKU", canSort:=True, style:="person"),
                gridConsignaciones.Column("Cantidad", "Cantidad", canSort:=True, style:="person"),
                gridConsignaciones.Column("ValorVenta", "Valor Venta", canSort:=True, style:="person"),
                gridConsignaciones.Column("Igv", "IGV", canSort:=True, style:="person"),
                gridConsignaciones.Column("Total", "Total(S/.)", canSort:=True, style:="person"),
                gridConsignaciones.Column("Moneda", "Moneda", canSort:=True, style:="person"),
                gridConsignaciones.Column("Tc", "Tc", canSort:=True, style:="person"),
                gridConsignaciones.Column("DocumentoAfecto", "Documento Afecto", canSort:=True, style:="person"),
                gridConsignaciones.Column("CostoTotal", "Costo Total", canSort:=True, style:="person"),
                gridConsignaciones.Column("Comentario", "Comentario", canSort:=True, style:="person"),
                gridConsignaciones.Column("PercepcionPorcentaje", "% Percepcion", canSort:=True, style:="person"),
                gridConsignaciones.Column("MontoPercepcion", "Monto Percepcion", canSort:=True, style:="person"),
                gridConsignaciones.Column("TotalVtaIgvPercepcion", "Total Igv + Percepcion", canSort:=True, style:="person"))
            )
    @Html.HiddenFor(Function(m) m.DescRegistrosPorPagina, New With {.id = "hdfTotalRegistros"})
    End If
Else
@* @<span>&nbsp;&nbsp;&nbsp;Archivo vacío o se produjo un error</span>*@
    @<div>
        <p>@Model.Mensaje</p>
    </div>
End If
<script type="text/javascript" language="javascript">
    $("#dgvDatos tfoot tr:last td").prepend("<a id='tfootPage' class='total_registros'></a>");
    //    $("#tfootPage").html($('#hdfTotalRegistros').val());

    function SetTotalResgitros() {

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
