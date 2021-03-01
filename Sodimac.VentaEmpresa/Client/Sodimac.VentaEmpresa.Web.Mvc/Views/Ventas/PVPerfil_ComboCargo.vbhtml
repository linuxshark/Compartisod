@ModelType Sodimac.VentaEmpresa.Web.Mvc.VentasViewModel 

@Html.DropDownListFor(Function(m) m.Empleado.Cargo.IdCargo,   
New SelectList(Model.ListaCargo, "IdCargo", "NombreCargo"),
"-TODOS-",
New With {
          .id = "IdEmpleadoCargo",
          .class = "selector"
         })

<div class="clear"></div>
@Html.ValidationMessageFor(Function(m) m.Empleado.Cargo.IdCargo, "", New With {.class = "reqizq"})