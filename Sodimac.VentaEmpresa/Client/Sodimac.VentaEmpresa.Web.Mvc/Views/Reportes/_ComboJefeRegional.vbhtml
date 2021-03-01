@ModelType  Sodimac.VentaEmpresa.Web.Mvc.ReporteViewModel

  @Html.DropDownListFor(Function(m) m.Empleado.IdEmpleado,
                                New SelectList(Model.ListaJefeRegional, "IdEmpleado", "NombresApellidos"),
                                New With {
                                    .class = "selector",
                                    .id = "IdJefeRegional",
                                    .onkeypress = "EnterSubmit(event,'btnBuscar')",
                                    .onchange = "",
                                    .multiple = "multiple"
                                })

 @Html.HiddenFor(Function(m) m.Empleado.IdEmpleado, New With {.id = "iIdJefeRegional"})


