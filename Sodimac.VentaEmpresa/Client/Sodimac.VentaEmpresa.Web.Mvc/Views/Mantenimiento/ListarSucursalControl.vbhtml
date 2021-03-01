@ModelType Sodimac.VentaEmpresa.Web.Mvc.MantenimientoViewModel
@Html.DropDownListFor(Function(m) m.Sucursal.IdSucursal,
                        New SelectList(Model.ListaSucursal, "IdSucursal", "DescripcionSucursal"),
                        "- TODOS -", New With {
                        .id = "Id_Sucursal",
                        .onkeypress = "EnterSubmit(event,'btnBuscar');"
                        })