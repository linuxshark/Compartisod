@ModelType  Sodimac.VentaEmpresa.Web.Mvc.ComisionViewModel

@Html.DropDownListFor(Function(m) m.ComisionPeriodo.IdPeriodo,
New SelectList(Model.ListaNombrePeriodo, "IdPeriodo", "NombrePeriodo"),
"- TODOS -", New With {
    .id = "ID_Periodo",
    .onkeypress = "EnterSubmit(event,'btnBuscar');"
})

<script type="text/javascript" language="javascript">
    uniformPartialList("ID_Periodo");
</script>