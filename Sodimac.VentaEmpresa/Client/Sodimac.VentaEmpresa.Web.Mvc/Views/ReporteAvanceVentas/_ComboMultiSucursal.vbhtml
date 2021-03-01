@ModelType Sodimac.VentaEmpresa.Web.Mvc.ReporteViewModel

@Html.DropDownListFor(Function(m) m.ListaAvanceVentas.ListaSucursal,
                New SelectList(Model.ListaAvanceVentas.ListaSucursal, "IdSucursal", "DescripcionSucursal"),
                New With {
                        .class = "selector",
                        .id = "IdSucursal",
                        .multiple = "multiple"
                    })
@Html.HiddenFor(Function(m) m.CadenaSucursal, New With {.id = "CadenaSucursal"})