@ModelType  Sodimac.VentaEmpresa.Web.Mvc.ComisionViewModel
@Imports Sodimac.VentaEmpresa.Common

<div id="contendorgrilla-ListadoMesComisional">
@If (Model.Paginacion.ListaComisionPeriodoDetalle IsNot Nothing AndAlso Not( Model.Paginacion.ListaComisionPeriodoDetalle.Count = 0)) Then
    
    Dim gridLista = New WebGrid(rowsPerPage:=Model.Paginacion.RowsPerPage, ajaxUpdateContainerId:="contendorgrilla-ListadoMesComisional", ajaxUpdateCallback:="SetTotalRegistrosComisional")
    gridLista.Bind(Model.Paginacion.ListaComisionPeriodoDetalle, autoSortAndPage:=False, rowCount:=Model.Paginacion.TotalRows)
    
     @Html.Hidden("iIdPeriodoComision", Model.ComisionPeriodoDetalle.IdPeriodoDetalle)  
      
        @gridLista.GetHtml(
        headerStyle:="fix_head", rowStyle:="fix_td", alternatingRowStyle:="fix_td", footerStyle:="pagination",
        htmlAttributes:=New With {.id = "dgvDatos", .class = "tDefault"},
        mode:=WebGridPagerModes.All,
        firstText:="<< Primera",
        previousText:="< Anterior",
        nextText:="Siguiente >",
        lastText:="Última >>",
        columns:=gridLista.Columns(
            gridLista.Column("Descripcion", "Descripción", canSort:=True, style:="person"),
            gridLista.Column("FechaInicio", "Fecha Inicio", canSort:=True, Style:="person", Format:=
            Function(item)
                Return Format(item.FechaIni, "dd/MM/yyyy")
            End Function),
            gridLista.Column("FechaFin", "Fecha Fin", canSort:=True, Style:="person", Format:=
            Function(item)
                Return Format(item.FechaFin, "dd/MM/yyyy")
            End Function),
        gridLista.Column("DescripcionEstado", "Estado", canSort:=True, style:="person"),
        gridLista.Column("", "Adjuntar", canSort:=False, Format:=
            Function(item)
                Dim adjuntar As String
                If item.Contador > 0 Then
                    adjuntar = String.Format("<a class={0}cheklist2{0} title= {0}Adjuntar Archivo{0} onClick={0}AjuntarArchivo('" + item.IdPeriodoDetalle.ToString() + "','" + item.IdEstado.ToString() + "','" + item.Descripcion.ToString() + "'){0}/>", Chr(34))
                Else
                    adjuntar = String.Format("<a class={0}cheklist{0} title= {0}Adjuntar Archivo{0} onClick={0}AjuntarArchivo('" + item.IdPeriodoDetalle.ToString() + "','" + item.IdEstado.ToString() + "','" + item.Descripcion.ToString() + "' ){0}/>", Chr(34))
                End If
                Return Html.Raw(adjuntar)
            End Function),
            gridLista.Column("", "Cierre", canSort:=False, Format:=
                Function(item)
                    Dim Cerrar As String
                    
                    If item.IdEstado <> 32 Then
                        Cerrar = String.Format("<a class={0}daralta{0} title= {0}Cerrar Mes{0} onClick={0}MensajeCerrarMes('" + item.IdPeriodoDetalle.ToString() + "'){0}/>", Chr(34))
                    Else
                        Cerrar = ""
                    End If

                    ' Return Html.ActionLink(" ", "BuscarMesesComisionales", "Comision", New With {.IdPeriodoDetalle = item.IdPeriodoDetalle}, New With {.class = "daralta", .title = "Cierre Periodo"})
                    Return Html.Raw(Cerrar)
                End Function)))

        @Html.HiddenFor(Function(m) m.Paginacion.DescRegistrosPorPaginas, New With {.id = "hdfTotalRegistros"})
End If

@If (Not Model.Paginacion.ListaComisionPeriodoDetalle Is Nothing) Then
    If (Not Model.Paginacion.ListaComisionPeriodoDetalle.Count = 0) Then
        @<script type="text/javascript" language="javascript">
             $("#dgvDatos tfoot tr:last td").prepend("<a id='tfootPage' class='total_registros'></a>");
             $("#tfootPage").html($('#hdfTotalRegistros').val());

             $(function () {
                 $('th a, tfoot a').live('click', function () {
                     $(this).attr('href', '#dgvDatos');
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