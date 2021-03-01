@ModelType Sodimac.VentaEmpresa.Web.Mvc.ProcesoViewModel
@Imports Sodimac.VentaEmpresa.Common
<div id="GrillaHistorial" style="margin: 0px;">
    @If (Not Model.ListaProcesoCargaHistorica Is Nothing) Then
        If (Not Model.ListaProcesoCargaHistorica.Count = 0) Then
            Dim gridConsignaciones As New WebGrid(rowsPerPage:=Model.RegistroPorPagina, ajaxUpdateContainerId:="GrillaHistorial", ajaxUpdateCallback:="LoadGrid")
            gridConsignaciones.Bind(Model.ListaProcesoCargaHistorica, autoSortAndPage:=False, rowCount:=Model.TotalRegistros)
        @gridConsignaciones.GetHtml(
                headerStyle:="fix_head center", rowStyle:="fix_td", alternatingRowStyle:="fix_td", footerStyle:="pagination",
                htmlAttributes:=New With {.id = "dgvDatosHistorial", .class = "tDefault"},
                mode:=WebGridPagerModes.All,
                firstText:="<< Primera",
                previousText:="< Anterior",
                nextText:="Siguiente >",
                lastText:="Última >>",
                columns:=gridConsignaciones.Columns(
                gridConsignaciones.Column("TipoCarga", "Código", canSort:=False, style:="center"),
                gridConsignaciones.Column("TotalDocumentos", "Documentos Cargados", canSort:=False, style:="center"),
                gridConsignaciones.Column("ValorDocumento", "Total(S/.)", canSort:=False, style:="center"),
                gridConsignaciones.Column("Fecha", "Fecha", canSort:=False, style:="center"),
                gridConsignaciones.Column("", "Eliminar", Style:="person", Format:=
                Function(item)
                    Dim control As String
                    If (item.Id_Estado = Constantes.EstadoCargaActivo) Then
                        control = String.Format("<a class={0}desactivar_table{0} title= {0}Eliminar carga{0} onClick={0}EliminarCargaManual('" & item.IDCarga.ToString() & "','" & item.Id_Estado.ToString() & "'){0} />", Chr(34))
                    Else
                        control = String.Format("")
                    End If
                    Return Html.Raw(control)
                End Function
                ),
                gridConsignaciones.Column("", "Ver", Style:="person", Format:=
                    Function(item)
                        Dim control As String
                        If (item.Id_Estado = Constantes.EstadoCargaActivo) Then
                            control = String.Format("<a class={0}select_table{0} title= {0}Ver Detalle{0} onClick={0}VerDetalleCarga('" & item.IDCarga.ToString() & "'){0} />", Chr(34))
                        Else
                            control = String.Format("")
                        End If
                        Return Html.Raw(control)
                    End Function
                ),
                gridConsignaciones.Column("", "Quitar", Style:="person", Format:=
                Function(item)
                    Dim control As String
                    If (item.Id_Estado = Constantes.EstadoCargaInactivo) Then
                        control = String.Format("<a class={0}basura_table{0} title= {0}Desactivar carga{0} onClick={0}QuitarCargaManual('" & item.IDCarga.ToString() & "','" & item.Id_Estado.ToString() & "'){0} />", Chr(34))
                    Else
                        control = String.Format("")
                    End If
                    Return Html.Raw(control)
                End Function
                )
            )
        )
        @Html.HiddenFor(Function(m) m.DescRegistrosPorPagina, New With {.id = "FooterDesc"})
        @Html.HiddenFor(Function(m) m.RegistroPorPagina, New With {.id = "RowsPerPage"})
        @Html.HiddenFor(Function(m) m.TotalRegistros, New With {.id = "hdfTotalRegistros"})
        Else
        @<span>&nbsp;&nbsp;&nbsp;No se han cargado archivos</span>
        End If
    Else
        @<span>&nbsp;&nbsp;&nbsp;No se han cargado archivos</span>
    End If
</div>
<div id="dialogDesactivarCargar" title="Mensaje de Confirmación">
    <p>
        ¿Desea desactivar la carga?</p>
</div>
<div id="dialogQuitarCargaManual" title="Mensaje de Confirmación">
    <p>
        ¿Desea quitar la carga desactivada?</p>
</div>
<script type="text/javascript" language="javascript">
    $(function () {
        InicioJPopUpConfirm("#dialogDesactivarCargar", 490, false, "Mensaje de Confirmación", CancelarHistorialCarga);
        InicioJPopUpConfirm("#dialogQuitarCargaManual", 490, false, "Mensaje de Confirmación", QuitarHistorialCarga);
    });
</script>
