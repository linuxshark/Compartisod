@ModelType  Sodimac.VentaEmpresa.Web.Mvc.ComisionViewModel

@Html.DropDownListFor(Function(m) m.ComisionPeriodo.IdPeriodoPlantilla,
New SelectList(Model.ListaComisionPeriodo, "IdPeriodoPlantilla", "NombrePeriodo"),
"- EN BLANCO -",
New With {
    .id = "Id_PeriodoPlantilla",
    .class = "textinput selector"
})

