@ModelType Sodimac.VentaEmpresa.Web.Mvc.ClientesViewModel
<div id="divListaCarteraCliente">
    <div class="widget fluid">
        <div class="whead">
            <h6>
                Representate de Ventas Asignado - @Model.Paginacion.ClienteVenta.RazonSocial </h6> 
            
            <div class="clear">
            </div>
        </div>
        @Code
            @If (Not Model.Paginacion.ListaEmpleado Is Nothing) Then
                If (Not Model.Paginacion.ListaEmpleado.Count = 0) Then
                    Dim gridLista = New WebGrid(rowsPerPage:=Model.Paginacion.PageSize, ajaxUpdateContainerId:="divListaCarteraCliente", ajaxUpdateCallback:="SetTotalRegistrosCarteraCliente")
                    gridLista.Bind(Model.Paginacion.ListaEmpleado, autoSortAndPage:=False, rowCount:=Model.Paginacion.TotalRows)
                @gridLista.GetHtml(
                headerStyle:="fix_head", rowStyle:="fix_td", alternatingRowStyle:="fix_td", footerStyle:="pagination",
                htmlAttributes:=New With {.id = "dgvDatos", .class = "tDefault"},
                mode:=WebGridPagerModes.All,
                firstText:="<< Primera",
                previousText:="< Anterior",
                nextText:="Siguiente >",
                lastText:="Última >>",
                    columns:=gridLista.Columns(
                        gridLista.Column("Nombres", "Nombres", canSort:=False, style:="person"),
                        gridLista.Column("Email", "Email", canSort:=False, style:="person"),
                        gridLista.Column("Celular1", "Celular", canSort:=False, style:="person"),
                        gridLista.Column("Telefono", "Teléfono", canSort:=False, style:="person"),
                        gridLista.Column("TablaGeneral.DescripcionTabGen", "Tipo", canSort:=False, style:="person"),
                        gridLista.Column("Sucursal.DescripcionSucursal", "Sucursal", canSort:=False, style:="person"),
                        gridLista.Column("VentaCartera.Porcentaje", "Porcentaje", canSort:=False, style:="person"),
                        gridLista.Column("VentaCartera.FechaActivacion", "Fecha Asignación", canSort:=False, style:="person"),
                        gridLista.Column("VentaCartera.FechaDesignacion", "Fecha Desasignación", canSort:=False, Style:="person", Format:=
                                         Function(item)
                                             If (item.VentaCartera.FechaDesignacion = "01/01/1900" Or item.VentaCartera.FechaDesignacion = "01/01/0001") Then
                                                 Return Format("-")
                                             Else
                                                 Return Format(item.VentaCartera.FechaDesignacion, "dd/MM/yyyy")
                                             End If
                                         End Function
                                         ),
                        gridLista.Column("ProcesoEstado.IdEstado", "Estado Registro", canSort:=False, Style:="person", Format:=
                                        Function(item)
                                            If (item.ProcesoEstado.IdEstado = 26) Then
                                                Return "Activo"
                                            Else
                                                Return "Desactivado"
                                            End If
                                        End Function
                                        ),
                        gridLista.Column("", "Acciones", canSort:=False, Format:=
                            Function(item)
                                Dim control As String
                                If (item.ProcesoEstado.IdEstado = 26) Then
                                    control = String.Format("<a class={0}desactivar_table{0} title= {0}Desactivar Cartera{0} onClick={0}CambiarSituacionCartera('" & item.VentaCartera.IdCartera.ToString() & "','" & item.ClienteVenta.IdCliente.ToString() & "','" & String.Format("{0:dd/MM/yyyy}", item.VentaCartera.FechaActivacion) & "'){0}/>", Chr(34))
                                Else
                                    control = String.Format("")
                                    'control = String.Format("<a class={0}Asistio{0} title= {0}Desactivar Cartera{0} onClick={0}CambiarSituacionCartera('" & item.VentaCartera.IdCartera.ToString() & "','" & item.ClienteVenta.IdCliente.ToString() & "'){0}/>", Chr(34))
                                End If
                                Return Html.Raw(control)
                            End Function),
                    gridLista.Column("", "Eliminar", canSort:=False, Format:=
                                     Function(item)
                                         Dim control As String
                                         If (item.ProcesoEstado.IdEstado = 27) Then
                                             control = String.Format("<a class={0}basura_table{0} title= {0}Desactivar Cartera{0} onClick={0}CambiarEstadoCarteraCliente('" & item.VentaCartera.IdCartera.ToString() & "','" & item.ClienteVenta.IdCliente.ToString() & "'){0}/>", Chr(34))
                                         Else
                                             control = ""
                                         End If
                                         Return Html.Raw(control)
                                     End Function
                                )
                )
                )
                @Html.HiddenFor(Function(m) m.Paginacion.DescRegistrosPorPaginas, New With {.id = "hdfTotalRegistros"})
                Else
                @<span>No se encontraron vendedores para este cliente</span>
                End If
            Else
                @<span>No se Encontraron vendedores en este cliente</span>
            End If

        End Code
    </div>
    <div class="formRow" style="text-align: right;">
        <div class="grid12">
            <button class="buttonS bBlue formSubmit group_button" style="cursor: pointer; float: right" id="btnNuevoCartera" onclick="existeMesonActivo();" >
            Agregar
            </button>
            <div class="clear">
            </div>
        </div>
    </div>
    <div class="formRow">
    <div class="clear"></div>
    </div></div>
    
<div id="content-nuevo-cartera" title="Nueva Cartera">
  @*  @Html.Partial("NuevaCarteraCliente", Model)*@
</div> 

<div id="dialogNuevaCartera" style="display: none" class="j_modal" title="Agregar Cartera" >      
    </div>

     <div id="dialogRegistrarCartera" title="Mensaje de Confirmación">
     @*  <p>¿Desea guardar el registro?</p>*@
     </div>

     <div id="dialogCancelarCartera" title="Mensaje de Confirmación">
       <p>¿Desea cancelar el registro?</p>
     </div>

<script type="text/javascript" language="javascript">
    $("#dgvDatos tfoot tr:last td").prepend("<a id='tfootPage' class='total_registros'></a>");
    $("#tfootPage").html($('#hdfTotalRegistros').val());

    $(function () {
        $('th a, tfoot a').live('click', function () {
            $(this).attr('href', '#dgvDatos');
            return false;
        });
    });

    function dialogNuevaCarteracliente() {
        $("#cboSucursal option").each(function () {
            if ($(this).val() == "") {
                $(this).attr("selected", "selected").change()
            }
        });

        $("#cboEmpleados option").each(function () {
            if ($(this).val() == "") {
                $(this).attr("selected", "selected").change()
            }
        });
    }
    InicioJPopUp("#dialogNuevaCartera", 600, 500, false, "Gestionar Cartera");
    InicioJPopUpConfirm("#dialogRegistrarCartera", 490, false, "Mensaje de Confirmación", GuardarCartera);
    InicioJPopUpConfirm("#dialogCancelarCartera", 490, false, "Mensaje de Confirmación", CancelarRegistroCartera);
       
</script>



@*<div id="content-modificar-cartera" title="Contacto_Cliente">
    @Html.Partial("ModificarCartera", Model)
</div>*@

