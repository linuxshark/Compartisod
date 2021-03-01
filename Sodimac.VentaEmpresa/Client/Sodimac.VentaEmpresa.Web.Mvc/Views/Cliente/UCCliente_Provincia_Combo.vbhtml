@ModelType Sodimac.VentaEmpresa.Web.Mvc.ClientesViewModel

@Html.DropDownListFor(Function(m) m.ClienteVenta.IdProvincia,
New SelectList(Model.ListaEmpleadoProvincia, "IdProvincia", "DescripcionProv"),
"-TODOS-",
New With {
    .id = "ID_Provincia",
    .onchange = "CargarDistrito();",
    .class = "textinput selector",
    .onkeypress = "EnterSubmit(event,'btnBuscar');"
 })
 <div class="clear"></div>
 @Html.ValidationMessageFor(Function(m) m.ClienteVenta.IdProvincia, "", New With {.class = "reqizq"})