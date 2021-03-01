@ModelType  Sodimac.VentaEmpresa.Web.Mvc.ComisionViewModel
@Imports Sodimac.VentaEmpresa.Common
@If (Model.Paginacion.ListarArchivoComision IsNot Nothing AndAlso Not (Model.Paginacion.ListarArchivoComision.Count = 0)) Then
    
    Dim gridLista = New WebGrid(rowsPerPage:=Model.Paginacion.RowsPerPage, ajaxUpdateContainerId:="Id_Listado_Mes_Condicional", ajaxUpdateCallback:="SetTotalRegistrosMesComisional")
    gridLista.Bind(Model.Paginacion.ListarArchivoComision, autoSortAndPage:=False, rowCount:=Model.Paginacion.TotalRows)
 
    
    
       @<div id="Id_Listado_Mes_Condicional" >       
     
    
        @gridLista.GetHtml(
        headerStyle:="fix_head", rowStyle:="fix_td", alternatingRowStyle:="fix_td", footerStyle:="pagination",
        htmlAttributes:=New With {.id = "dgvDatosComisional", .class = "tDefault"},
        mode:=WebGridPagerModes.All,
        firstText:="<< Primera",
        previousText:="< Anterior",
        nextText:="Siguiente >",
        lastText:="Última >>",
        columns:=gridLista.Columns(
            gridLista.Column("IdJefeRRVV.NombresApellidos", "Nombre JEFE/RRVV", canSort:=True, style:="person"),
            gridLista.Column("Descripcion", "Descripción", canSort:=True, style:="person"),
            gridLista.Column("OriginalName", "Nombre Original", canSort:=True, style:="person"),
        gridLista.Column("FechaRegistro", "Registrado", canSort:=True, Style:="person", Format:=
            Function(item)
                Return Format(item.FechaRegistro, "dd/MM/yyyy")
            End Function),
        gridLista.Column("AprobadoPor", "Aprobado Por", canSort:=True, style:="person"),
        gridLista.Column("IdUsuario.UsuarioUsu", "Subido Por", canSort:=True, style:="person"),
        gridLista.Column("", "Descargar", canSort:=False, Format:=
            Function(item)
                'Return Html.ActionLink(" ", "AdjuntarDocumento", "Comision", New With {.IdPeriodoDetalle = item.IdPeriodoDetalle}, New With {.class = "cheklist", .title = "Cierre Periodo"})
                Dim adjuntar As String = ""
                adjuntar = String.Format("<a class={0}DescargarAdjunto{0} title= {0}DescargarAdjunto{0} onClick={0}Descargar_Adjunto('" + item.IdArchivo.ToString() + "'){0}/>", Chr(34))
                Return Html.Raw(adjuntar)
            End Function),
        gridLista.Column("", "Eliminar", canSort:=False, Format:=
            Function(item)
                'Return Html.ActionLink(" ", "AdjuntarDocumento", "Comision", New With {.IdPeriodoDetalle = item.IdPeriodoDetalle}, New With {.class = "cheklist", .title = "Cierre Periodo"})
                Dim adjuntar As String = ""
                adjuntar = String.Format("<a class={0}deleteCo{0} title= {0}Cierre Periodo{0} onClick={0}Eliminar_PeriodoComision('" + item.IdArchivo.ToString() + "','" + item.IdPeriodoComision.ToString() + "'){0}/>", Chr(34))
                Return Html.Raw(adjuntar)
            End Function)))

        @Html.HiddenFor(Function(m) m.Paginacion.TotalRows, New With {.id = "RowCount"})
        @Html.HiddenFor(Function(m) m.Paginacion.RowsPerPage, New With {.id = "RowsPerPage"})
        @Html.HiddenFor(Function(m) m.Paginacion.DescRegistrosPorPaginas, New With {.id = "TotalRegistrosComision"})


        </div>

    Else
        @<span>&nbsp;&nbsp;&nbsp;No se encontraron resultados</span>
End If
