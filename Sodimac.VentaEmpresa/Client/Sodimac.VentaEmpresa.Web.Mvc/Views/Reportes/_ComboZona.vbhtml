@ModelType  Sodimac.VentaEmpresa.Web.Mvc.ReporteViewModel
     @Html.DropDownListFor(Function(m) m.ZonaMantenimiento.IdZona,
                       New SelectList(Model.ListaZonaMantenimiento, "IdZona", "NombreZona"),
                       New With {
                                 .id = "ID_Zona",
                                 .class = "textinput selector",
                                 .onchange = "ListarSucursalporZona();",
         .multiple = "multiple"
                      }) 
<script type="text/javascript" language="javascript">
    var navegador = navigator.appName

    $(function () {
        $("#ID_Zona").multiselect(
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




