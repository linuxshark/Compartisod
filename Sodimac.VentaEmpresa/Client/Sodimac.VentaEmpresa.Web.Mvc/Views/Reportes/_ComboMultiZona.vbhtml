@ModelType Sodimac.VentaEmpresa.Web.Mvc.ReporteViewModel

@Html.DropDownListFor(Function(m) m.ZonaMantenimiento.IdZona,
        New SelectList(Model.ListaZonaMantenimiento, "IdZona", "NombreZona"),
    New With
    {
        .id = "ID_Zona",
        .class = "textinput selector",
    .multiple = "multiple"
    })
 
 @Html.HiddenFor(Function(m) m.ZonaMantenimiento.IdZona, New With {.id = "IdZona2"})
   