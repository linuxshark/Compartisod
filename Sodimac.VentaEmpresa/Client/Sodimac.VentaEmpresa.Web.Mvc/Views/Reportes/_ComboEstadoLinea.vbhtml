 @ModelType Sodimac.VentaEmpresa.Web.Mvc.ReporteViewModel
 @Html.DropDownListFor(Function(m) m.ClienteEstadoLinea.IdEstado,
                                New SelectList(Model.ListaClienteEstadoLinea, "IdEstado", "Descripcion"),
                                "- TODOS -",
                                New With {
                                    .class = "selector",
                                    .id = "IdEstadoLinea"
                                })