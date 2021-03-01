@ModelType Sodimac.VentaEmpresa.Web.Mvc.MantenimientoViewModel
<div class="grid9">
    @Html.DropDownListFor(Function(m) m.SucursalMantenimiento.Provincia.IdProvincia,
    New SelectList(Model.ListaProvincia, "IdProvincia", "Descripcion"),
    "- NINGUNO -",
    New With {
        .id = "ID_Provincia",
        .style = "cursor:default;",
        .class = "ignorefield",
        .onchange = "CargarDistrito();"
    })                                
</div>                    
                        