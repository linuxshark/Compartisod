@ModelType Sodimac.VentaEmpresa.Web.Mvc.MantenimientoViewModel
<div class="grid9">
    @Html.DropDownListFor(Function(m) m.Sucursal.CodigosSucursales,
                                New SelectList(Model.ListaSucursal, "IdSucursal", "DescripcionSucursal"),
                                New With {
                                    .style = "cursor:default;",
                                    .multiple = "multiple"
                                })
    @Html.ValidationMessageFor(Function(m) m.Sucursal.IdSucursal, "", New With {.class = "reqizq"})
    @Html.HiddenFor(Function(m) m.Sucursal.CodigoSucursal, New With {.id = "IDCodigosSucursales"})
</div>

<script type="text/javascript" language="javascript">
    var navegador = navigator.appName

    $(function () {
        var data = $("#IDCodigosSucursales").val();
        var dataarray = data.split(",");
        $("#Sucursal_CodigosSucursales").val(dataarray);
        $("#Sucursal_CodigosSucursales").multiselect("refresh");

        $("#Sucursal_CodigosSucursales").multiselect(
            {
                selectedList: 10,
                noneSelectedText: '-SELECCIONE-',
                show: ["bounce", 200],
                minWidth: 280
            }
         ).multiselectfilter();
        // $("#ID_Sucursales").multiselect("select", "1,2,3")
        $(".ui-multiselect").attr("style", "width: 280px")

        if (navegador == "Microsoft Internet Explorer") {
            $(".ui-multiselect").attr("style", "width: 250px")
        }
        $("#ui-multiselect-ID_Sucursales-option-2").attr("selected", "selected")


    });
</script>