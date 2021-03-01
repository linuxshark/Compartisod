@ModelType Sodimac.VentaEmpresa.Web.Mvc.ReporteViewModel

@Html.DropDownListFor(Function(m) m.ListaAvanceVentas.ListaJefeVenta,
                New SelectList(Model.ListaAvanceVentas.ListaJefeVenta, "IdEmpleado", "NombresApellidos"),
                New With {
                    .class = "selector",
                    .id = "IdJefeRegional_",
                    .onkeypress = "EnterSubmit(event,'btnBuscar')",
                    .onchange = "",
                    .multiple = "multiple"
                })
@Html.HiddenFor(Function(m) m.CadenaJefeVenta, New With {.id = "CadenaJefeVenta"})
@Html.HiddenFor(Function(m) m.JefeCadena, New With {.id = "JefeCadena"})