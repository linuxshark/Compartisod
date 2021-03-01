@modeltype Sodimac.VentaEmpresa.Web.Mvc.ClientesViewModel
@If (Not Model.ListaSucursal Is Nothing) Then
    @Html.DropDownListFor(Function(m) m.Sucursal.IdSucursal,
    New SelectList(Model.ListaSucursal, "IdSucursal", "DescripcionSucursal"),
    New With {
        .id = "cboSucursal",
        .style = "cursor:default;",
        .multiple = "multiple",
        .class = "selector"
    })
End If
<script type="text/javascript">
    $(function () {
        $("#cboSucursal").multiselect(
            {
                selectedList: 10,
                noneSelectedText: '-SELECCIONE-',
                show: ["bounce", 200],
                minWidth: 220,
                beforeclose: function (event, ui) {
                    esSucursalValida();
                },
                close: function (event, ui) {
                    $('#contenedor-grid-Sucursales').html('');
                    var arrSucursales = $(this).multiselect("getChecked").map(function () {
                        return this.value;
                    }).get();
                    if (arrSucursales.toString()) {
                        var vUrl = $("#UrlSucursales").val();
                        $.ajax({
                            url: vUrl,
                            type: "POST",
                            data: { IdsSucursal: arrSucursales.toString() },
                            cache: false,
                            success: function (data, textStatus, jqXHR) {
                                $('#contenedor-grid-Sucursales').html(data);
                                PintarGrillaSucursales();
                                DesHabilitarPorcentajeTCompartida();
                            },
                            error: function (er) {
                            },
                            complete: function () {
                            }
                        });
                    }
                }
            }
            ).multiselectfilter();
        $(".ui-multiselect").attr("style", "width: 280px");
        var navegador = navigator.appName;
        if (navegador == "Microsoft Internet Explorer") {
            $(".ui-multiselect").attr("style", "width: 220px");
        }
    });
</script>