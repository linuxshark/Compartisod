(function () {
    $(document).ready(function () {
        configMultiselect("#ID_Zona");
        configMultiselect("#IdSucursal");
        configMultiselect("#IdSubGerente_");
        configMultiselect("#IdJefeRegional_");
        configMultiselect("#IdVendedor_");

        tamañoMultiSelect();

        $("#ID_Zona").change(function () {
            cargarSucursalReporteVentas($(this).val());
            cargarJefeVentaReporteVentas($(this).val(), "#ID_Zona");
        });
        $("#IdSubGerente_").change(function () {
            cargarJefeVentaReporteVentas($(this).val(), "#IdSubGerente_");
        });
        $("#IdJefeRegional_").change(function () {
            cargarRRVVReporteVentas($(this).val());
        });

        $("#btnExportarReporte").click(exportarReporte);
    });

    function replaceErrorMessagge(IdDiv, Message) {
        $("#" + IdDiv).replaceWith('<div style="color: #EC6464; font-size:9px;" id="' + IdDiv + '">' + Message + '</div>');
    }

    function validaFecha() {
        var valida = true;
        //if (ValidarFecha("ID_FechaInicio") == 0) {
        //    replaceErrorMessagge("ID_MsgFechaInicio", "");
        //}
        //else {
        //    replaceErrorMessagge("ID_MsgFechaInicio", "Ingrese una fecha de inicio correcta");
        //    valida = false;
        //}
        if (ValidarFecha("ID_FechaFin") == 0) {
            replaceErrorMessagge("ID_MsgFechaFin", "");
        }
        else {
            replaceErrorMessagge("ID_MsgFechaFin", "Ingrese una fecha correcta");
            valida = false;
        }
        //if (ValidarFecha("ID_FechaInicio") == 0 && ValidarFecha("ID_FechaFin") == 0) {
        //if (ValidarFecha("ID_FechaFin") == 0) {
        //    var vFechaInicio = $("#ID_FechaInicio").val();
        //    var vFechaFin = $("#ID_FechaFin").val();
        //    if (Comparar_Fechas(vFechaInicio, vFechaFin)) {
        //        replaceErrorMessagge("ID_MsgFechaInicio", "La Fecha Inicio no debe ser mayor a la Fecha Fin");
        //        replaceErrorMessagge("ID_MsgFechaFin", "");
        //        valida = false;
        //    }
        //}
        return valida;
    }

    var exportarReporte = function() {
        if (validaFecha()) {
            $("#CadenaZona").val($("#ID_Zona").val());
            $("#CadenaSucursal").val($("#IdSucursal").val());
            $("#CadenaSubGerente").val($("#IdSubGerente_").val());
            $("#CadenaJefeVenta").val($("#IdJefeRegional_").val());
            $("#CadenaRrvv").val($("#IdVendedor_").val());
            //var frm = $("#FrmAvanceVenta");
            var vUrl = $("#UrlGenerarReporte").val(); 
            $.ajax({
                url: vUrl,
                type: "POST",
                //data: frm.serialize(),
                data: {
                    //fechaInicio: $("#ID_FechaInicio").val(),
                    fechaFin : $("#ID_FechaFin").val(),
                    zona : $("#CadenaZona").val(),
                    sucursal : $("#CadenaSucursal").val(),
                    subGerente : $("#CadenaSubGerente").val(),
                    jefeVenta : $("#CadenaJefeVenta").val(),
                    rrvv : $("#CadenaRrvv").val()
                },
                success: function (data) {
                    if (data.error) {
                        alert(data.msj);
                    } else {
                        window.location = $("#UrlDescargarReporte").val() + "?nameFile=" + data.nameFile;
                    }
                }
            });
        }
    }

    var tamañoMultiSelect = function() {
        $(".ui-multiselect").attr("style", "width: 220px");
        if (navigator.appName === "Microsoft Internet Explorer") {
            $(".ui-multiselect").attr("style", "width: 250px");
        }
    }

    var configMultiselect = function (selector) {
        $(selector).multiselect(
            {
                selectedList: 10,
                noneSelectedText: "-SELECCIONE-",
                show: ["bounce", 200],
                minWidth: 220,
                selectedText: function (numChecked, numTotal, checkedItems) {
                    return "Seleccionados (" + numChecked + ") de " + numTotal;
                },
                checkAll: function () {
                    if (selector === "#ID_Zona") {
                        cargarSucursalReporteVentas($(selector).val());
                        cargarJefeVentaReporteVentas($(this).val(), "#ID_Zona");
                    }
                    if (selector === "#IdSubGerente_") {
                        cargarJefeVentaReporteVentas($(selector).val(), selector);
                    }
                    if (selector === "#IdJefeRegional_") {
                        cargarRRVVReporteVentas($(selector).val());
                    }
                    tamañoMultiSelect();
                },

                uncheckAll: function () {
                    if (selector === "#ID_Zona") {
                        cargarSucursalReporteVentas($(selector).val());
                        cargarJefeVentaReporteVentas($(this).val(), "#ID_Zona");
                    }
                    if (selector === "#IdSubGerente_") {
                        cargarJefeVentaReporteVentas($(selector).val(), selector);
                    }
                    if (selector === "#IdJefeRegional_") {
                        cargarRRVVReporteVentas($("#JefeCadena").val());
                    }
                    tamañoMultiSelect();
                }
            }
        ).multiselectfilter();
    }

    var cargarSucursalReporteVentas = function (e) {
        var vUrl = $("#UrlCargaSucursalPorFecha").val();
        var vZonaCadena = "";
        if(e)
            vZonaCadena= e.toString();

        $.ajax({
            url: vUrl,
            type: "GET",
            data: {
                IdZonaCadena: vZonaCadena
            },
            success: function (data) {
                $("#DivSucursalPartial").html(data);
                configMultiselect("#IdSucursal");

                //$("#IdSucursalCliente").multiselect("uncheckAll");
            }
        });
    }

    var cargarJefeVentaReporteVentas = function (val, name) {
        var vUrl = $("#UrlCargaJefeVenta").val();
        var vZona = String.empty;
        var vSubGerenteCadena = String.empty;
        if (val) {
            if (name === "#IdSubGerente_") {
                if ($("#ID_Zona").val())
                    vZona = $("#ID_Zona").val().toString();
                vSubGerenteCadena = val.toString();
            } else {
                vZona = val.toString();
                if($("#IdSubGerente_").val())
                    vSubGerenteCadena =  $("#IdSubGerente_").val().toString();
            }
        } else {
            if ($("#ID_Zona").val())
                vZona = $("#ID_Zona").val().toString();
            if ($("#IdSubGerente_").val())
                vSubGerenteCadena = $("#IdSubGerente_").val().toString();            
        }
        
        $.ajax({
            url: vUrl,
            type: "GET",
            data: {
                idZona: vZona,
                SubGerente: vSubGerenteCadena
            },
            success: function (data) {
                $("#ID_ComboJefeRegional").html(data);
                configMultiselect("#IdJefeRegional_");
                cargarRRVVReporteVentas($("#JefeCadena").val());
                
                tamañoMultiSelect();

                $("#IdJefeRegional_").change(function () {
                    cargarRRVVReporteVentas($("#IdJefeRegional_").val());
                });
            }
        });
    }

    var cargarRRVVReporteVentas = function (e) {
        var vUrl = $("#UrlCargaRRVV").val();
        var vJefeVentaCadena = "";
        if (e)
            vJefeVentaCadena = e.toString();

        $.ajax({
            url: vUrl,
            type: "GET",
            data: {
                jefe: vJefeVentaCadena
            },
            success: function (data) {
                $("#DivRRVV").html(data);
                configMultiselect("#IdVendedor_");
                tamañoMultiSelect();
            }
        });
    }
})()