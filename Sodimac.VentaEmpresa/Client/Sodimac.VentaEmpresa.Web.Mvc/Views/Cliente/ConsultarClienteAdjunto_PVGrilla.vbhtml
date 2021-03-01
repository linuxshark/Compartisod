@ModelType  Sodimac.VentaEmpresa.Web.Mvc.ClientesViewModel
@Code 
    @If (Not Model.PaginacionClienteAdjunto.ListaClienteAdjunto Is Nothing) Then
        If (Model.PaginacionClienteAdjunto.ListaClienteAdjunto.Count <> 0) Then
            Dim gridVentas = New WebGrid(rowsPerPage:=Model.PaginacionClienteAdjunto.PageSize, ajaxUpdateContainerId:="contendorgrilla-ListadoClienteAdjunto", ajaxUpdateCallback:="SetTotalResgitrosClienteAdjunto")
            gridVentas.Bind(Model.PaginacionClienteAdjunto.ListaClienteAdjunto, autoSortAndPage:=False, rowCount:=Model.PaginacionClienteAdjunto.TotalRows)
        @gridVentas.GetHtml(
        headerStyle:="fix_head", rowStyle:="fix_td", alternatingRowStyle:="fix_td", footerStyle:="pagination",
        htmlAttributes:=New With {.id = "GrillaClienteAdjunto", .class = "tDefault"},
        mode:=WebGridPagerModes.All,
        firstText:="<< Primera",
        previousText:="< Anterior",
        nextText:="Siguiente >",
        lastText:="Última >>",
             columns:=gridVentas.Columns(
                 gridVentas.Column("NombreTemp", "Nombre Archivo", canSort:=False, style:="person"),
                 gridVentas.Column("Tamanio", "Tamaño (MB)", canSort:=False, style:="person"),
                 gridVentas.Column("TipoContenidoAdj", "Tipo ", canSort:=False, style:="person"),
                 gridVentas.Column(header:="Nombre Original", Style:="person", Format:=
                        Function(item)
                            Dim control As String
                            control = String.Format("<a href = " + Url.Action("DownLoadClienteAdjuntoFile", "Cliente", New With {.IdAdj = item.IdAdj}) + " title= {0}Descargar Archivo{0} >" + item.NombreAdj + "</a>", Chr(34))
                            Return Html.Raw(control)
                        End Function
                    ),
                gridVentas.Column("FechaRegistro", "Registrado", Format:=
                                  Function(item)
                                      Return String.Format("{0:d}", item.FechaRegistro)
                                  End Function, canSort:=True, Style:="person"),
                gridVentas.Column(header:="Eliminar", Style:="person", Format:=
                        Function(item)
                            Dim control As String
                            control = String.Format("<a class={0}delete_table{0} title= {0}Editar Usuario{0} onClick={0}AbrirPopupEliminarCliente('" + item.IdAdj.ToString() + "'){0}/>", Chr(34))
                            Return Html.Raw(control)
                        End Function)
                 ))
             
       
            Html.HiddenFor(Function(m) m.Paginacion.DescRegistrosPorPaginas, New With {.id = "hdfTotalRegistrosAdj"})
        Else
        @<span>&nbsp;&nbsp;&nbsp;No se encontraron resultados</span>
        End If
       
    Else
        @<span>&nbsp;&nbsp;&nbsp;No se encontraron resultados</span>
    End If
End Code