@ModelType Sodimac.VentaEmpresa.Web.Mvc.VentasViewModel 

@Html.DropDownListFor(Function(m) m.Empleado.Cargo.IdCargo,
New SelectList(Model.ListaCargo, "IdCargo", "NombreCargo"),
"-SELECCIONE-",
New With {
          .id = "IdEmpleadoCargo",
          .onchange = "CargarSupervisor();validaTipoPerfilCargos();cargarComisionServicios();",
          .class = "selector"
         })
@* cargarSucursal();cargarZonas();CargarSupervisor();*@
<div class="clear"></div>
@Html.ValidationMessageFor(Function(x) x.Empleado.Cargo.IdCargo, "", New With {.class = "reqizq"})
