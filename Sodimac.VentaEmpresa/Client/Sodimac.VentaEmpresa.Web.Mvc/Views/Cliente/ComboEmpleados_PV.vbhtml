@ModelType Sodimac.VentaEmpresa.Web.Mvc.ClientesViewModel
@*@If (Not Model.ListaEmpleado Is Nothing) Then*@
    @Html.DropDownListFor(Function(m) m.Empleado.IdEmpleado,
    New SelectList(Model.ListaEmpleado, "IdEmpleado", "Nombres"),
    "- SELECCIONE -",
    New With {
        .id = "cboEmpleados",
        .class = "selector",
        .onchange = "OnChange_ComboEmpleado();ObtenerFechaActivacionEmpleado();ValidaTipoCarteraporEmpleadoTipo();"
    })
    <div id="ID_MsgcboEmpleados">
    </div>
@*End If*@
@*ComboValidaTipoMeson();*@ 