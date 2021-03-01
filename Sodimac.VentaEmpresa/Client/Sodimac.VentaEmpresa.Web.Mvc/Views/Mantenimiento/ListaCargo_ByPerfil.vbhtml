@ModelType Sodimac.VentaEmpresa.Web.Mvc.MantenimientoViewModel
<div class="grid9">
    @Html.DropDownListFor(Function(m) m.Cargo.IdCargoSuperior,
    New SelectList(Model.ListaCargo, "IdCargo", "NombreCargo"),
    "- NINGUNO -",
    New With {
        .id = "ID_CargoSuperior",
        .style = "cursor:default;",
        .class = "ignorefield"
    })                                
</div>
               