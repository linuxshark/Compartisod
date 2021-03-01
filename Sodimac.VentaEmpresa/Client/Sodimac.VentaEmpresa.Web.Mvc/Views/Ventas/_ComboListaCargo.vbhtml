@ModelType  Sodimac.VentaEmpresa.Web.Mvc.VentasViewModel

@Html.DropDownListFor(Function(m) m.EmpleadoCargo.IdEmpleadoCargo,
New SelectList(Model.ListaEmpleadoCargo, "IdEmpleadoCargo", "DescripcionCargo"),
"-TODOS-",
New With {
    .id = "ID_IdEmpleadoCargo",
    .class = "textinput selector",
    .onkeypress = "EnterSubmit(event,'btnBuscar')"
})
@Html.ValidationMessageFor(Function(m) m.EmpleadoCargo.IdEmpleadoCargo, "",
New With {
    .class = "reqizq"
})

<script type="text/javascript" language="javascript">
    $("#ID_IdEmpleadoCargo").uniform();
</script>