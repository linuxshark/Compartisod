@ModelType Sodimac.VentaEmpresa.Web.Mvc.AccountViewModel
    <div id="contenedor-grid-Rol">
    @If (Not Model.ListaRoles Is Nothing) Then
        If (Not Model.ListaRoles.Count = 0) Then
            Dim gridConsignaciones As New WebGrid(rowsPerPage:=Model.RegistroPorPagina, ajaxUpdateContainerId:="contenedor-grid-Rol", ajaxUpdateCallback:="SetTotalResgitros")
            gridConsignaciones.Bind(Model.ListaRoles, autoSortAndPage:=False, rowCount:=Model.TotalRegistros)
            @gridConsignaciones.GetHtml(
                headerStyle:="fix_head", rowStyle:="fix_td", alternatingRowStyle:="fix_td", footerStyle:="pagination",
                htmlAttributes:=New With {.id = "dgvDatos", .class = "tDefault"},
                mode:=WebGridPagerModes.All,
                firstText:="<< Primera",
                previousText:="< Anterior",
                nextText:="Siguiente >",
                lastText:="Última >>",
                columns:=gridConsignaciones.Columns(
                gridConsignaciones.Column("NombreRol", "Nombre Rol", canSort:=True, style:="person"),
                gridConsignaciones.Column("ActivoRol", "Estado", canSort:=True, Style:="person", Format:=
                    Function(item)
                        If (Convert.ToBoolean(item.ActivoRol)) Then
                            Return "Activo"
                        Else
                            Return "Inactivo"
                        End If
                    End Function
                ),
            gridConsignaciones.Column(header:="Editar", Style:="person", Format:=
                    Function(item)
                        Dim control As String
                        control = String.Format("<a class={0}edit_table{0} title= {0}Editar Rol{0} onClick={0}EditarRol('" + Url.Action("Editar", "Account") + "','" + item.IdRol.ToString() + "'){0}/>", Chr(34))
                        Return Html.Raw(control)
                    End Function
                ),
            gridConsignaciones.Column("", "Desactivar", Style:="person", Format:=
                Function(item)
                    Dim control As String
                    If (Convert.ToBoolean(item.ActivoRol)) Then
                        control = String.Format("<a class={0}desactivar_table{0} title= {0}Desactivar Rol{0} onClick={0}DesactivarRol('" + Url.Action("DesactivarRol", "Account") + "','" + item.IdRol.ToString() + "'){0}/>", Chr(34))
                    Else
                        control = ""
                    End If
                    Return Html.Raw(control)
                End Function
                ))
            )
            @Html.HiddenFor(Function(m) m.DescRegistrosPorPagina,New With{.id = "hdfTotalRegistros"})
        End If
    Else
    @<span>&nbsp;&nbsp;&nbsp;No se encontraron resultados para éste periodo</span>
    End If
</div>

<script type="text/javascript" language="javascript">
    $("#dgvDatos tfoot tr:last td").prepend("<a id='tfootPage' class='total_registros'></a>");
    $("#tfootPage").html($('#hdfTotalRegistros').val());

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