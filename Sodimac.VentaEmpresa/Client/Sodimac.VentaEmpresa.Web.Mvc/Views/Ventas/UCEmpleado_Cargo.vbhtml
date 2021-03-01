@ModelType Sodimac.VentaEmpresa.Web.Mvc.VentasViewModel
  
@Html.DropDownListFor(Function(x) x.Empleado.Zona.IdZona,
New SelectList(Model.ListaZona, "IdZona", "NombreZona"),
"-SELECCIONE-",
New With {
         .id = "ID_zona",
         .onchange = "cargarSucursales();ObtenerNombreCargoVendedor();",
         .Class = "selector"}) 
 <div class="clear"></div>
 @Html.ValidationMessageFor(Function(x) x.Zona.IdZona, "", New With {.class = "reqizq"})
