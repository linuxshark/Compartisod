@ModelType Sodimac.VentaEmpresa.Web.Mvc.ReporteViewModel

@Html.DropDownListFor(Function(m) m.ListaAvanceVentas.ListaRrvv,
                                    New SelectList(Model.ListaAvanceVentas.ListaRrvv, "IdEmpleado", "NombresApellidos"),
                                    New With {
                                            .id = "IdVendedor_",
                                            .style = "cursor:default;",
                                            .multiple = "multiple",
                                            .class = "selector",
                                            .onkeypress = "EnterSubmit(event,'btnBuscar')"
                                        })
@Html.HiddenFor(Function(m) m.CadenaRrvv, New With {.id = "CadenaRrvv"})