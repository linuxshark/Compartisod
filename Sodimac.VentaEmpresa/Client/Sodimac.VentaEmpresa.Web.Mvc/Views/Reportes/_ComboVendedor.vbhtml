@ModelType  Sodimac.VentaEmpresa.Web.Mvc.ReporteViewModel
@Html.DropDownListFor(Function(m) m.Empleado.IdEmpleado,
                                New SelectList(Model.ListaEmpleado, "IdEmpleado", "NombresApellidos"),
                                "- TODOS -",
                                New With {
                                    .class = "selector",
                                    .id = "IdVendedor"
                                })
@*<script type="text/javascript" language="javascript">
    $("#IdJefeRegional").uniform();
</script>*@