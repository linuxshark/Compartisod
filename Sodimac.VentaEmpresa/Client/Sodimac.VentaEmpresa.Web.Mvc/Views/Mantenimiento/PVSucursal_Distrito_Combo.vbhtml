@ModelType Sodimac.VentaEmpresa.Web.Mvc.MantenimientoViewModel
<div class="grid9">
    @Html.DropDownListFor(Function(m) m.SucursalMantenimiento.Distrito.IdDistrito,
    New SelectList(Model.ListaDistrito, "IdDistrito", "Descripcion"),
    "- NINGUNO -",
    New With {
        .id = "ID_Distrito",
        .style = "cursor:default;",
        .class = "ignorefield"
    })                                
</div>                    
                        