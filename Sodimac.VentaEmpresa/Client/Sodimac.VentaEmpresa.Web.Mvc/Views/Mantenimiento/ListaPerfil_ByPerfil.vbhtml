@ModelType Sodimac.VentaEmpresa.Web.Mvc.MantenimientoViewModel

<div class="grid9">
    @Html.DropDownListFor(Function(m) m.Cargo.Perfil.IdPerfil,
    New SelectList(Model.ListaCargo, "Perfil.IdPerfil", "Perfil.NombrePerfil"),
    "- NINGUNO -",
    New With {
        .id = "ID_CargoSuperior",
        .style = "cursor:default;",
        .class = "ignorefield"
    })                                
</div>                        
                        