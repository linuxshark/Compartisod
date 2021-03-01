@ModelType Sodimac.VentaEmpresa.Web.Mvc.ClientesViewModel
@Imports Sodimac.VentaEmpresa.Web.Mvc.ParametrosView
@Html.HiddenFor(Function(m) m.Empleado.FechaSucursalUltimo, New With {.id = "FechaSucursalUltimoRRVV"})
@Html.HiddenFor(Function(m) m.Empleado.FechaContrato, New With {.id = "FechaContratoRRVV"})
@Html.TextBoxFor(Function(m) (m.VentaCartera.FechaActivacion),
New With {
    .id = "ID_FechaActivacion",
    .autocomplete = "off",
    .class = "datepicker maskDate",
    .maxlength = "10",
    .Value = String.Format("{0:d}", "")
})
@Html.ValidationMessageFor(Function(x) x.VentaCartera.FechaActivacion, "", New With {.id = "ID_MsgFechaActivacion", .class = "reqizq"})
@*<div id="ID_MsgFechaActivacion">
</div>*@
<script type="text/javascript" language="javascript">
    $("#ID_FechaActivacion").datepicker({
        showOtherMonths: true,
        autoSize: true,
        changeMonth: true,
        changeYear: true,
        appendText: '(DD/MM/AAAA)',
        dateFormat: 'dd/mm/yy'
    });
    $(".datepicker").mask("99/99/9999");
</script>
