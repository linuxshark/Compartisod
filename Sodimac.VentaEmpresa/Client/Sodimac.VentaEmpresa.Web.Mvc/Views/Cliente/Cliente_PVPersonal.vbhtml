@ModelType Sodimac.VentaEmpresa.Web.Mvc.ClientesViewModel
<div id="divListaClienteContacto">
    <div class="widget fluid">
        <div class="whead">
            <h6>
                Personal de Contacto del Cliente -  @Model.Paginacion.ClienteVenta.RazonSocial
               </h6>  
            <div class="clear">
            </div>
        </div>
        @Code
            @If (Not Model.Paginacion.ListaClienteContacto Is Nothing) Then
                If (Not Model.Paginacion.ListaClienteContacto.Count = 0) Then
                    Dim gridLista = New WebGrid(rowsPerPage:=Model.Paginacion.PageSize, ajaxUpdateContainerId:="divListaClienteContacto", ajaxUpdateCallback:="SetTotalRegistrosContacto")
                    gridLista.Bind(Model.Paginacion.ListaClienteContacto, autoSortAndPage:=False, rowCount:=Model.Paginacion.TotalRows)
        
                @gridLista.GetHtml(
                    headerStyle:="fix_head", rowStyle:="fix_td", alternatingRowStyle:="fix_td", footerStyle:="pagination",
                    htmlAttributes:=New With {.id = "dgvDatosContacto", .class = "tDefault"},
                    mode:=WebGridPagerModes.All,
                    firstText:="<< Primera",
                    previousText:="< Anterior",
                    nextText:="Siguiente >",
                    lastText:="Última >>",
                        columns:=gridLista.Columns(
                            gridLista.Column("Nombres", "Nombres", canSort:=False, style:="person"),
                            gridLista.Column("Apellidos", "Apellidos", canSort:=False, style:="person"),
                            gridLista.Column("Telefono", "Telefono", canSort:=False, style:="person"),
                            gridLista.Column("Email", "Email", canSort:=False, style:="person"),
                            gridLista.Column("Cargo", "Clase", canSort:=False, style:="person"),
                            gridLista.Column("", "Acciones", canSort:=False, Format:=
                            Function(item)
                                Dim control As String
                                control = String.Format("<a class={0}edit_table{0} title= {0}Editar Contacto{0} onClick={0}EditarContacto('" + item.IdContacto.ToString() + "');{0}/>", Chr(34))
                                Return Html.Raw(control)
                            End Function)
                        )
                    )
                @Html.HiddenFor(Function(m) m.Paginacion.DescRegistrosPorPaginas, New With {.id = "hdfTotalRegistrosPersonal"})
                Else
                @<span>&nbsp;&nbsp;&nbsp;No se encontraron resultados para éste cliente</span>
                End If
            Else
                @<span>&nbsp;&nbsp;&nbsp;No se encontraron resultados para éste cliente</span>
            End If

        End Code
    </div>
    <div class="formRow" style="text-align: right;">
        <div class="grid12">
            <button class="buttonS bBlue formSubmit group_button" style="cursor: pointer; float: right"
                id="btnNuevoContacto" onclick="dialogNuevoContacto()">
                Agregar
            </button>
            <div class="clear">
            </div>
        </div>
    </div>
    <div class="formRow">
        <div class="clear">
        </div>
    </div>
    <div id="content-nuevo-contacto" title="Nuevo Contacto">
        @Html.Partial("NuevoContacto", Model)
    </div>
    <div id="divClienteContacto" title="Contacto_Cliente">
        @Html.Partial("ModificarClienteContacto", Model)
    </div>

    <script type="text/javascript" language="javascript">
        $(function () {
            $('th a, tfoot a').live('click', function () {
                $(this).attr('href', '#dgvDatosContacto');
                return false;
            });
        });

        $(function () {
            $("#btnClose").live("click", function () {
                $("#content-nuevo-contacto").dialog("close");
            })
        });

        $("#dgvDatosContacto tfoot tr:last td").prepend("<a id='tfootPage' class='total_registros'></a>");
        $("#tfootPage").html($('#hdfTotalRegistrosPersonal').val());

        $(function () {
            InicioJPopUp("#content-nuevo-contacto", 800, 450, false, "Nuevo Contacto");
            InicioJPopUp("#divClienteContacto", 800, 450, false, "Editar Contacto");
        });
    </script>
</div>