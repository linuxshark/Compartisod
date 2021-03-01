@ModelType Sodimac.VentaEmpresa.Web.Mvc.ClientesViewModel 
@Imports Sodimac.VentaEmpresa.Web.Mvc.ParametrosView

 @Html.DropDownListFor(Function(m) m.Sucursal.IdSucursal,
          New SelectList(Model.ListaSucursal, "IdSucursal", "Descripcion"),
          "-SELECCIONE-",
          New With {
                    .id = "ID_IdSucursalActivo",
                    .onchange = "CargarVendedorporSucursalActivo()",
                    .class = "selector"
   }
)  


