@ModelType Sodimac.VentaEmpresa.Web.Mvc.ClientesViewModel 


    @Html.DropDownListFor(Function(m) m.Empleado.IdEmpleado,
     New SelectList(Model.ListaEmpleado, "IdEmpleado", "NombresApellidos"),
      "-SELECCIONE-",
        New With {
                  .id = "ID_IdEmpleado",
                  .onchange="CargarClienteporVendedores();",
                  .class = "selector"
             })


