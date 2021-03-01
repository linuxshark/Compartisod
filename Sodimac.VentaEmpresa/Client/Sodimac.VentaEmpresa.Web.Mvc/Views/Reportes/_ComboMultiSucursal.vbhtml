@ModelType Sodimac.VentaEmpresa.Web.Mvc.ReporteViewModel

 @Html.DropDownListFor(Function(m) m.Sucursal.IdSucursal,
                                New SelectList(Model.ListaSucursal, "IdSucursal", "DescripcionSucursal"),
                                New With {
                                    .class = "selector",
                                    .id = "IdSucursalCliente",
                                    .multiple = "multiple"
                                })
 @Html.HiddenFor(Function(m) m.Sucursal.IdSucursal, New With {.id = "Idsucursal2Cliente"})