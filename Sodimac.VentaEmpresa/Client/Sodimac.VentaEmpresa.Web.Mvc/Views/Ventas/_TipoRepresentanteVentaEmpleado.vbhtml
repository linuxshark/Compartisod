@ModelType  Sodimac.VentaEmpresa.Web.Mvc.VentasViewModel

@Html.DropDownListFor(Function(m) m.Empleado.TipoRepresentanteVenta.IdTipoRepVen,
                                       New SelectList(Model.ListaTipoRepresentanteVenta, "IdTipoRepVen", "NombreTipoRepVen"),
                                       "-SELECCIONE-",
                                       New With {
                                       .id = "ID_TipoRepVen",
                                       .class = "textinput selector"
                                       })
@Html.ValidationMessageFor(Function(m) m.Empleado.TipoRepresentanteVenta.IdTipoRepVen, "", New With {.class = "reqizq"})
