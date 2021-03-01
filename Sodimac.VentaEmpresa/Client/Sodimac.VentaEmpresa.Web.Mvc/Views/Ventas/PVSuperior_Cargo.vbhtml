@ModelType Sodimac.VentaEmpresa.Web.Mvc.VentasViewModel

<div class="grid4" >
     <label class="form-label">
                 Reporta :</label>
</div>
@Html.DropDownListFor(Function(v) v.Empleado.Cargo.IdCargoSuperior,
New SelectList(Model.ListaCargo , "IdCargoSuperior", "NombreCargoSuperior"),
New With {
       .id = "ID_CargoSu",
       .class = "selector"
    }) 
<div class="clear"></div>
@Html.ValidationMessageFor(Function(c) c.Cargo.IdCargoSuperior, "", New With {.class = "reqizq"}) 



