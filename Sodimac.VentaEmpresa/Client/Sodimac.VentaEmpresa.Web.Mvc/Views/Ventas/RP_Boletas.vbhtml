@ModelType Sodimac.VentaEmpresa.Web.Mvc.ProcesoViewModel
@If (Not Model.ListaProcesoCarga Is Nothing) Then
    If (Not Model.ListaProcesoCarga.Count = 0) Then
        Dim gridConsignaciones As New WebGrid(rowsPerPage:=Model.RegistroPorPagina, ajaxUpdateContainerId:="contenedor-grid-Servicio", ajaxUpdateCallback:="Load")
        gridConsignaciones.Bind(Model.ListaProcesoCarga, autoSortAndPage:=False, rowCount:=Model.TotalRegistros)
        @gridConsignaciones.GetHtml(
            headerStyle:="fix_head", rowStyle:="fix_td", alternatingRowStyle:="fix_td", footerStyle:="pagination",
            htmlAttributes:=New With {.id = "dgvDatos_", .class = "tDefault"},
            mode:=WebGridPagerModes.All,
            firstText:="<< Primera",
            previousText:="< Anterior",
            nextText:="Siguiente >",
            lastText:="Última >>",
            columns:=gridConsignaciones.Columns(
           gridConsignaciones.Column(header:="Sel", format:=
               Function(item)
                   If item.Valores Then
                       Return Html.Raw(String.Format("<input type='checkbox' value='{0}' class='prueba' checked name='ids'/>", item.IdCliente))
                   Else
                       Return Html.Raw(String.Format("<input type='checkbox' value='{0}' class='prueba' name='ids'/>", item.IdCliente))
                   End If
               End Function),
            gridConsignaciones.Column("Fecha", "F. Venta", canSort:=True, style:="person", Format:=@@<text>@(String.Format("{0:dd/MM/yyyy}", item("Fecha")))</text>),
            gridConsignaciones.Column("Sucursal", canSort:=False, style:="gridhide"),
            gridConsignaciones.Column("NombreSucursal", "Sucursal ", canSort:=True, style:="person"),
            gridConsignaciones.Column("NumeroDocumento", "Nro. Doc", canSort:=True, style:="person"),
            gridConsignaciones.Column("Ruc", "DNI", canSort:=True, style:="person"),
            gridConsignaciones.Column("NombreCliente", "Cliente ", canSort:=True, style:="person"),
            gridConsignaciones.Column("SKU", "Cod. SKU ", canSort:=True, style:="person"),
            gridConsignaciones.Column("Nom_Sku", "SKU ", canSort:=True, style:="person"),
            gridConsignaciones.Column("Cantidad", "Cantidad ", canSort:=True, style:="person"),
            gridConsignaciones.Column("Valor", "Valor ", canSort:=True, style:="person"),
            gridConsignaciones.Column("CostoUnitario", "C. Unit ", canSort:=True, style:="person"),
            gridConsignaciones.Column("HUA", "HUA ", canSort:=True, style:="person"),
            gridConsignaciones.Column("IGV", "IGV ", canSort:=True, style:="person"),
            gridConsignaciones.Column("CostoTotal", "Costo ", canSort:=True, style:="person"),
            gridConsignaciones.Column("Total", "Total ", canSort:=True, style:="person")
            ))

    @Html.HiddenFor(Function(m) m.DescRegistrosPorPagina, New With {.id = "hdfTotalRegistros"})
    @Html.HiddenFor(Function(m) m.Variable, New With {.id = "hdfVariable"})
Else
    @* @<span>&nbsp;&nbsp;&nbsp;Archivo vacío o se produjo un error</span>*@
    @<div>
        <p>@Model.Mensaje</p>
    </div>
    End If
    Else
    @* @<span>&nbsp;&nbsp;&nbsp;Archivo vacío o se produjo un error</span>*@
    @<div>
        <p>@Model.Mensaje</p>
    </div>
    End If
<script>
    $(document).ready(function()
    {
        debugger
        $("#dgvDatos_ th:nth-child(3)").hide();
        $("#dgvDatos_ td:nth-child(3)").hide();
    })

    $(function () {
        $(".prueba").each(function () {
            debugger
            var prueba = $(this).attr("checked")
            if (prueba == "checked") {

                var items;
                items = $("#hdfVariable").val().split(',') == "" ? new Array() : $("#hdfVariable").val().split(',');
                items.push($(this).val());
                $("#hdfVariable").val(items)

                //$("#Variable").val($(this).val())
                //    $(this).val("true")


            }
         

  
        })
    });

    $(".prueba").change(function () {
        debugger
        var prueba = $(this).attr("checked")
        if (prueba == "checked") {
            
            var items;
            items = $("#hdfVariable").val().split(',') == "" ? new Array() : $("#hdfVariable").val().split(',');
            items.push($(this).val());
            $("#hdfVariable").val(items)


            }
        else {
            var items;
            items = $("#hdfVariable").val().split(',') == "" ? new Array() : $("#hdfVariable").val().split(',');
            var index = items.indexOf($(this).val())
            items.splice(index, 1);
            $("#hdfVariable").val(items)
        }

        

        })



 


    $("#dgvDatos_ tfoot tr:last td").prepend("<a id='tfootPage' class='total_registros'></a>");
    //    $("#tfootPage").html($('#hdfTotalRegistros').val());

    function SetTotalResgitros() {

        $("#dgvDatos_ tfoot tr:last td").prepend("<a id='tfootPage' class='total_registros'></a>");
        $("#tfootPage").html($('#hdfTotalRegistros').val());
    }

    $(function () {
        $('th a, tfoot a').live('click', function () {
            $(this).attr('href', '#dgvDatos_');
            return false;
        });
       
    });
</script>