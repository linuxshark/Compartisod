@ModelType  Sodimac.VentaEmpresa.Web.Mvc.ReporteViewModel
@Html.DropDownListFor(Function(m) m.Empleado.IdEmpleado,
                                New SelectList(Model.ListaEmpleado, "IdEmpleado", "NombresApellidos"),
                                New With {
                                    .id = "IdVendedor",
                                    .style = "cursor:default;",
                                    .multiple = "multiple",
                                    .class = "selector",
                                    .onkeypress = "EnterSubmit(event,'btnBuscar')"
                                })

                                @Html.HiddenFor(Function(m) m.Empleado.IdEmpleado, New With {.id = "ID_Empleado_V"})