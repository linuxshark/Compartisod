@ModelType  Sodimac.VentaEmpresa.Web.Mvc.ClientesViewModel
@Html.HiddenFor(Function(m) m.ClienteLineaCredito.IdCliente, New With {.id = "IdCliente"})
<div id="divListaClienteHistorial">
    <div class="widget fluid">
        <div class="whead" id="whead">
            <h6>
                Historial de Líneas de Crédito del Cliente - 
             </h6>
            <div class="clear">
            </div>
        </div>
        @Code
            @If (Not Model.Paginacion.ListaClienteLineaCredito Is Nothing) Then
                If (Model.Paginacion.ListaClienteLineaCredito.Count <> 0) Then
                    Dim gridLista = New WebGrid(rowsPerPage:=Model.Paginacion.PageSize, ajaxUpdateContainerId:="divListaClienteHistorial", ajaxUpdateCallback:="SetTotalResgitros")
                    gridLista.Bind(Model.Paginacion.ListaClienteLineaCredito, autoSortAndPage:=False, rowCount:=Model.Paginacion.TotalRows)
                @gridLista.GetHtml(
                headerStyle:="fix_head", rowStyle:="fix_td", alternatingRowStyle:="fix_td", footerStyle:="pagination",
                htmlAttributes:=New With {.id = "dgvDatos", .class = "tDefault"},
                mode:=WebGridPagerModes.All,
                firstText:="<< Primera",
                previousText:="< Anterior",
                nextText:="Siguiente >",
                lastText:="Última >>",
                    columns:=gridLista.Columns(
                            gridLista.Column("LCAutorizada", "LC Autorizada", canSort:=False, style:="person"),
                            gridLista.Column("FactCentral", "Fact. Central(Suc. 7)", canSort:=False, style:="person"),
                            gridLista.Column("LCSigic", "LC Sigic", canSort:=False, style:="person"),
                            gridLista.Column("FactSigic", "Fact. Sigic", canSort:=False, style:="person"),
                            gridLista.Column("LCDisponible", "LC Disponible", canSort:=False, style:="person"),
                            gridLista.Column("FechaAperturaLinea", "Fecha Apertura", canSort:=False, Style:="person", Format:=
                            Function(item)
                                Return Format(item.FechaAperturaLinea, "dd/MM/yyyy")
                            End Function),
                            gridLista.Column("FechaExpiracion", "Fecha Expiración", canSort:=False, Style:="person", Format:=
                            Function(item)
                                Return Format(item.FechaExpiracion, "dd/MM/yyyy")
                            End Function),
                            gridLista.Column("DiasPlazo", "Días Plazo", canSort:=False, style:="person")
                            )
                )
                @Html.HiddenFor(Function(m) m.Paginacion.DescRegistrosPorPaginas, New With {.id = "hdfTotalRegistrosHistorial"})
                Else
                @<span>&nbsp;&nbsp;&nbsp;No se encontraron resultados para éste cliente</span>
                End If
            Else
                @<span>&nbsp;&nbsp;&nbsp;No se encontraron resultados para éste cliente</span>
            End If
        End Code
    </div>
</div>
<div class="formRow">
    <div class="clear"></div>
</div>

<script type="text/javascript" language="javascript">
    $("#dgvDatos tfoot tr:last td").prepend("<a id='tfootPage' class='total_registros'></a>");
    $("#tfootPage").html($('#hdfTotalRegistros').val());

    function SetTotalResgitros() {
        $("#dgvDatos tfoot tr:last td").prepend("<a id='tfootPage' class='total_registros'></a>");
        $("#tfootPage").html($('#hdfTotalRegistrosHistorial').val());
    }

    $(function () {
        $('th a, tfoot a').live('click', function () {
            $(this).attr('href', '#dgvDatos');
            return false;
        });
    });
    $("#whead h6").append($("#HdnRazonSocial").val());
</script>

