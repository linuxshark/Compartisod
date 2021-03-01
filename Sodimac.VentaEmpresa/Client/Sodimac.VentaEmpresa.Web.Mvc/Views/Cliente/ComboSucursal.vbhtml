@ModelType Sodimac.VentaEmpresa.Web.Mvc.ClientesViewModel

<div class="grid12">
    <div class="grid3" style="padding-top: -30px">
        <label>
            Sucursal :<span class="req">*</span>
        </label>
    </div>
    <div class="grid8" style="padding-top: -30px">
        @If (Not Model.ListaSucursal Is Nothing) Then
            @Html.DropDownListFor(Function(m) m.Sucursal.IdSucursal,
            New SelectList(Model.ListaSucursal, "IdSucursal", "DescripcionSucursal"),
            "- SELECCIONE -", New With {
                .id = "cboSucursal",
                .onchange = "CargarEmpleados();",
                .class = "selector"
            })
        End If
        <div class="clear"></div>
        <div id="msgListaSucursal">
        </div>
    </div>
</div>        
<script type="text/javascript" language="javascript">
    $(function () {
        $("#cboSucursal").uniform();
    });
</script>