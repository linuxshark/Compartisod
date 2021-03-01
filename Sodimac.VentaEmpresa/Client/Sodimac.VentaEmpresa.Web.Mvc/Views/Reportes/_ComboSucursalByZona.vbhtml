@ModelType  Sodimac.VentaEmpresa.Web.Mvc.ReporteViewModel
@Html.DropDownListFor(Function(m) m.Sucursal.IdSucursal,
                                New SelectList(Model.ListaSucursal, "IdSucursal", "DescripcionSucursal"),
                                New With {
                                    .class = "selector",
                                    .id = "IdSucursal",
                                    .onchange = "BuscarVendedor_BySucursal()",
                                    .multiple = "multiple"
                                })
    <script type="text/javascript" language="javascript">
    var navegador = navigator.appName

    $(function () {
        $("#IdSucursal").multiselect(
        {
        selectedList: 10,
        noneSelectedText: '-TODOS-',
        show: ["bounce", 200],
        minWidth: 280
        }
        ).multiselectfilter();
        $(".ui-multiselect").attr("style", "width: 280px")
        if (navegador == "Microsoft Internet Explorer") {
            $(".ui-multiselect").attr("style", "width: 250px")
        }
    });
    </script> 







@*@Html.DropDownListFor(Function(m) m.EmpleadoCargo.IdEmpleadoCargo,
New SelectList(Model.ListaEmpleadoCargo, "IdEmpleadoCargo", "DescripcionCargo"),
"-TODOS-",
New With {
    .id = "ID_IdEmpleadoCargo",
    .class = "textinput selector",
    .onkeypress = "EnterSubmit(event,'btnBuscar')"
})
@Html.ValidationMessageFor(Function(m) m.EmpleadoCargo.IdEmpleadoCargo, "",
New With {
    .class = "reqizq"
})
<script type="text/javascript" language="javascript">
    $("#IdJefeRegional").uniform();
</script>*@