@ModelType  Sodimac.VentaEmpresa.Web.Mvc.ComisionViewModel
<div id="contendorgrilla-ListadoNombrePeriodo">
@If (Not Model.Paginacion.ListaComisionPeriodo Is Nothing) Then
    If (Not Model.Paginacion.ListaComisionPeriodo.Count = 0) Then
        Dim gridLista = New WebGrid(rowsPerPage:=Model.Paginacion.PageSize, ajaxUpdateContainerId:="contendorgrilla-ListadoNombrePeriodo", ajaxUpdateCallback:="SetTotalRegistros")
        gridLista.Bind(Model.Paginacion.ListaComisionPeriodo, autoSortAndPage:=False, rowCount:=Model.Paginacion.TotalRows)
        @gridLista.GetHtml(
        headerStyle:="fix_head", rowStyle:="fix_td", alternatingRowStyle:="fix_td", footerStyle:="pagination",
        htmlAttributes:=New With {.id = "dgvDatos", .class = "tDefault"},
        mode:=WebGridPagerModes.All,
        firstText:="<< Primera",
        previousText:="< Anterior",
        nextText:="Siguiente >",
        lastText:="Última >>",
        columns:=gridLista.Columns(
            gridLista.Column("NombrePeriodo", "Nombre", canSort:=True, style:="person"),
            gridLista.Column("FechaInicio", "Fecha Inicio", canSort:=True, Style:="person", Format:=
            Function(item)
                Return Format(item.FechaInicio, "dd/MM/yyyy")
            End Function),
            gridLista.Column("FechaFin", "Fecha Fin", canSort:=True, Style:="person", Format:=
            Function(item)
                Return Format(item.FechaFin, "dd/MM/yyyy")
            End Function),
            gridLista.Column("Estado.Descripcion", "Estado", canSort:=True, style:="person"),
            gridLista.Column("Activo", "Activo", canSort:=False, Style:="person", Format:=
                             Function(item)
                                 Dim control As String
                                 If (item.Estado.IdEstado = 12) Then
                                     control = String.Format("<a class={0}basura_table{0} title= {0}Desactivar Periodo{0} onClick={0}EliminarPeriodoComision('" & item.IdPeriodo.ToString() & "'){0} />", Chr(34))
                                 Else
                                     control = ""
                                 End If
                                 Return Html.Raw(control)
                             End Function
                             ),
            gridLista.Column("", "Ver", canSort:=False, Format:=
            Function(item)
                Return Html.ActionLink(" ", "GestionarPeriodoComision", "Comision", New With {.IdPeriodo = item.IdPeriodo, .ModificaEscala = "True"}, New With {.class = "select_table", .title = "Ver Detalle"})
            End Function),
          gridLista.Column("", "Cierre", canSort:=False, Format:=
               Function(item)
                   If item.Estado.IdEstado = 14 Then
                       Return Html.ActionLink(" ", "BuscarMesesComisionales", "Comision", New With {.IdPeriodo = item.IdPeriodo}, New With {.class = "daralta", .title = "Cierre Periodo"})
                   Else
                      ' Return Html.Label("",New With {.class = "daralta"})
                       'Html.Label(" ", "", "", New With {.IdPeriodo = item.IdPeriodo}, New With {.class = "daralta", .title = "Cierre Periodo"})
                   End If
                     

               End Function)
            )
        )
        @Html.HiddenFor(Function(m) m.Paginacion.DescRegistrosPorPaginas, New With {.id = "hdfTotalRegistros"})
    Else
        @<span>&nbsp;&nbsp;&nbsp;No se encontraron resultados</span>
End If
Else
    @<span>&nbsp;&nbsp;&nbsp;No se encontraron resultados</span>
End If
<script type="text/javascript" language="javascript">
    $("#dgvDatos tfoot tr:last td").prepend("<a id='tfootPage' class='total_registros'></a>");
    $("#tfootPage").html($('#hdfTotalRegistros').val());

    $(function () {
        $('th a, tfoot a').live('click', function () {
            $(this).attr('href', '#dgvDatos');
            return false;
        });
    });
</script>
</div>
