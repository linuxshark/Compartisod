@modeltype Sodimac.VentaEmpresa.Web.Mvc.AccountViewModel
  <div id="contenedor-grid-Rol">
@If (Not Model.ListaRoles Is Nothing) Then

    If (Not Model.ListaRoles.Count = 0) Then
 
        Dim act As Boolean = False
        Dim wgRol As New WebGrid(rowsPerPage:=Model.RegistroPorPagina, ajaxUpdateContainerId:="contenedor-grid-Rol", ajaxUpdateCallback:="SetTotalResgitros")
        wgRol.Bind(Model.ListaRoles, autoSortAndPage:=False, rowCount:=Model.TotalRegistros)
      
            @wgRol.GetHtml(
                headerStyle:="fix_head", rowStyle:="fix_td", alternatingRowStyle:="fix_td", footerStyle:="pagination",
                htmlAttributes:=New With {.id = "dgvDatos", .class = "tDefault checkAll"},
                mode:=WebGridPagerModes.All,
                firstText:="<< Primera",
                previousText:="< Anterior",
                nextText:="Siguiente >",
                lastText:="Última >>",
                columns:=wgRol.Columns(wgRol.Column("Sel.", Format:=Function(item) Html.CheckBox("checkRol", False, New With {.id = item.IdRol, .value = item.IdRol, .style = "float:=left", .class = "chk_rols", .onclick = "CheckboxTempId(this);"})),
                       wgRol.Column("Rol", Format:=
                       Function(item)
                           Dim control As String
                           control = "<label style='float:left' for='" & item.IdRol & "'>" + item.NombreRol + "</label> "
                           Return Html.Raw(control)
                       End Function)
                       ))

        @Html.HiddenFor(Function(m) m.DescRegistrosPorPagina, New With {.id = "hdfTotalRegistros"})
       

    else

        @<span>&nbsp;&nbsp;&nbsp;No se encontraron resultados para ésta búsqueda</span>

End If

Else

    @<span>&nbsp;&nbsp;&nbsp;No se encontraron resultados para ésta búsqueda</span>
End If
@Html.HiddenFor(Function(m) m.arrayRoles)
</div>
<script type="text/javascript" language="javascript">
    $(document).ready(function () {
        $("#dgvDatos tfoot tr:last td").prepend("<a id='tfootPage' class='total_registros'></a>");
        $("#tfootPage").html($('#hdfTotalRegistros').val());       
    });

    function SetTotalResgitros() {
        $("#dgvDatos tfoot tr:last td").prepend("<a id='tfootPage' class='total_registros'></a>");
        $("#tfootPage").html($('#hdfTotalRegistros').val());
        $(".chk_rols").uniform();
        PintarGrilla();
    }

    $(function () {
        $('th a, tfoot a').live('click', function () {
            $(this).attr('href', '#dgvDatos');
            return false;
        });
    });

    function PintarGrilla() {
        var arrayRoles = $('#arrayRoles').val().split(',');
        for (var i = 0; i < arrayRoles.length; i++) {
            $('#' + arrayRoles[i]).closest('.checker > span').addClass('checked');
        }
    }
</script>