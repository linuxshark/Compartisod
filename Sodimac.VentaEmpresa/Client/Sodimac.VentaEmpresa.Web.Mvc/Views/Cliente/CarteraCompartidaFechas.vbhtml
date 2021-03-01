@ModelType Sodimac.VentaEmpresa.Web.Mvc.ClientesViewModel
<div id="divListaCarteraCompartida">
    <div class="widget fluid">
        <div class="whead">
            <h6>
                Historial de Registros
            </h6>
            <div class="clear">
            </div>
        </div>
        @Code
            @If (Not Model.Paginacion.ListaClienteFechasCarteraCompartida Is Nothing) Then
                If (Not Model.Paginacion.ListaClienteFechasCarteraCompartida.Count = 0) Then
                    Dim gridLista = New WebGrid(rowsPerPage:=Model.Paginacion.PageSize, ajaxUpdateContainerId:="divListaCarteraCompartida", ajaxUpdateCallback:="SetTotalRegistrosFechasCarteraCompartida")
                    gridLista.Bind(Model.Paginacion.ListaClienteFechasCarteraCompartida, autoSortAndPage:=False, rowCount:=Model.Paginacion.TotalRows)

                    @gridLista.GetHtml(
               headerStyle:="fix_head", rowStyle:="fix_td", alternatingRowStyle:="fix_td", footerStyle:="pagination",
               htmlAttributes:=New With {.id = "dgvDatosFechasCartera", .class = "tDefault"},
               mode:=WebGridPagerModes.All,
               firstText:="<< Primera",
               previousText:="< Anterior",
               nextText:="Siguiente >",
               lastText:="Última >>",
                   columns:=gridLista.Columns(
                       gridLista.Column("FechaInicio", "Fecha Incio", canSort:=False, style:="person"),
                       gridLista.Column("FechaFin", "Fecha Fin", canSort:=False, style:="person"),
                       gridLista.Column("FechaRegistro", "Fecha de Registro", canSort:=False, style:="person")
               )
                                             )
                    @Html.HiddenFor(Function(m) m.Paginacion.DescRegistrosPorPaginas, New With {.id = "hdfTotalRegistrosFechas"})
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
                    id="btnNuevaCarteraCompartida" onclick="dialogNuevaCarteraCompartida()">
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
    <div id="content-nuevo-cartera-compartida" title="Gestionar Cartera">
        @Html.Partial("NuevaCarteraCompartida", Model)
    </div>
    @*<div id="divClienteContacto" title="Contacto_Cliente">
        @Html.Partial("ModificarClienteContacto", Model)
    </div>*@

    <script type="text/javascript" language="javascript">
        $(function () {
            $('th a, tfoot a').live('click', function () {
                $(this).attr('href', '#dgvDatosFechasCartera');
                return false;
            });
        });

        $(function () {
            $("#btnClose").live("click", function () {
                $("#content-nuevo-cartera-compartida").dialog("close");
            })
        });

        $("#dgvDatosFechasCartera tfoot tr:last td").prepend("<a id='tfootPage' class='total_registros'></a>");
        $("#tfootPage").html($('#hdfTotalRegistrosFechas').val());

        $(function () {
            InicioJPopUp("#content-nuevo-cartera-compartida", 800, 300, false, "Gestionar Cartera");
            //InicioJPopUp("#divClienteContacto", 800, 450, false, "Editar Contacto");
        });
    </script>
</div>