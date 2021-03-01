
function CargaZonasporFechas_Ventas() {
    var FechaInicio = $("#ID_FechaInicio").val();
    var FechaFin = $("#ID_FechaFin").val();
    var vUrl = $("#UrlCargaZonaPorFecha").val();
    var CargarJefe = $("#IdJefeRegional_").val();
    var CargaRRVV = $("#IdVendedor_").val();

    if (ValidaFecha()) {

        $.ajax({
            url: vUrl,
            type: "GET",
            data: {
                FechaIni: FechaInicio,
                FechaFin: FechaFin
            },
            success: function (data) {
                if (CargarJefe == null) {
                    CargarJefeRegional_Ventas();
                } else {
                    CargarRRVV_Ventas();
                }

                $("#DivZonaM").html(data);

                $("#ID_Zona").multiselect({

                    click: function (event, ui) {
                        var IdZona = new Array();
                        $("input[name='multiselect_ID_Zona']:checked").each(function () {
                            IdZona.push($(this).val());
                        });

                        $("#IdZona2").val(IdZona);

                        CargarSucursal_Reporte_Ventas();
                    },
                    checkAll: function () {
                        var IdZona = new Array();
                        $("input[name='multiselect_ID_Zona']:checked").each(function () {
                            IdZona.push($(this).val());
                        });

                        $("#IdZona2").val(IdZona);

                        CargarSucursal_Reporte_Ventas();
                    },

                    uncheckAll: function () {
                        $("#IdZona2").val('');

                        CargarSucursal_Reporte_Ventas();
                    }
                });
                $("#ID_Zona").multiselect("uncheckAll");

            }

        });
    }
}

function ExportarReporteVentas() {

    if (ValidaFecha()) {
        debugger;
        var vUrl = $("#Exportar_URL").val();
        var vFechaInicio = $("#ID_FechaInicio").val();
        var vFechaFin = $("#ID_FechaFin").val();
        var vIdSucursal = $("#IdSucursalCliente").val();
        var vRuc = 0;
        var vRazonSocial = $("#ID_RazonSocial").val();

        var vIdJefeRegional = "";
        var vIdJefeRegional1 = "" + $("#IdJefeRegional_").val();
        var vIdJefeRegional2 = "" + $("#IdJefeRegional").val();

        if (vIdJefeRegional1 == null || vIdJefeRegional1 == "undefined") {
            vIdJefeRegional = vIdJefeRegional2;
        } else {
            vIdJefeRegional = vIdJefeRegional1;
        }

        var vIdVendedor = "";
        var vIdVendedor1 = "" + $("#IdVendedor_").val();
        var vIdVendedor2 = "" + $("#IdVendedor").val();

        if (vIdVendedor1 == null || vIdVendedor1 == "undefined") {
            vIdVendedor = vIdVendedor2;
        } else {
            vIdVendedor = vIdVendedor1;
        }

        var vIdTipoCliente = $("#IdTipoCliente").val();
        var vZona = $("#ID_Zona").val();
        var vIdGrupo = $("#IdGrupo").val();

        if (vIdSucursal == null)
        { vIdSucursal = 0 }
        else { vIdSucursal = $("#IdSucursalCliente").val().toString() }
        if (vZona == null)
        { vZona = 0 }
        else { vZona = $("#ID_Zona").val().toString() }

        if (vIdVendedor == 'null') { vIdVendedor = "0" }
        if (vIdJefeRegional == 'null') { vIdJefeRegional = "0" }


        //Url = vUrl + '?FechaInicio=' + vFechaInicio + '&FechaFin=' + vFechaFin + '&Sucursal=' + vIdSucursal + '&Ruc=' + vRuc + '&JefeRegional=' + vIdJefeRegional + '&Vendedor=' + vIdVendedor + '&TipoCliente=' + vIdTipoCliente + '&RazonSocial=' + vRazonSocial + '&Zona=' + vZona + '&IdGrupo=' + vIdGrupo;
        //window.open(Url, '_self');


        /* inicio cambio */
        $.ajax({
            url: vUrl,
            type: "GET",
            data: {
                FechaInicio: vFechaInicio,
                FechaFin: vFechaFin,
                Ruc: vRuc,
                Vendedor: vIdVendedor,
                TipoCliente: vIdTipoCliente,
                JefeRegional: vIdJefeRegional,
                Sucursal: vIdSucursal,
                RazonSocial: vRazonSocial,
                Zona: vZona,
                IdGrupo: vIdGrupo
            },
            cache: false,
            success: function (data) {
                var resource = data;
                DownloadFile(resource);
            },
            error: function (data) {
                alert("Error: " + data);
            }
        });
    }
}

function DownloadFile(resource) {
    if (resource.length > 0) {
        window.open(resource, '_blank');
    }
    else {
        alert('No se realizó la carga de ningún archivo.');
    }
}

function CargarSucursal_Reporte_Ventas() {
    var FechaInicio = $("#ID_FechaInicio").val();
    var FechaFin = $("#ID_FechaFin").val();
    var vZonaCadena = $("#IdZona2").val();
    var vUrl = $("#UrlCargaSucursalPorFecha").val();

    $.ajax({
        url: vUrl,
        type: "GET",
        data: {
            IdZonaCadena: vZonaCadena,
            FechaIni: FechaInicio,
            FechaFin: FechaFin
        },
        success: function (data) {
            $("#DivSucursalPartial").html(data);

            //Sucursal
            $("#IdSucursalCliente").multiselect({

                click: function (event, ui) {
                    var idSucursal = new Array();
                    $("input[name='multiselect_IdSucursalCliente']:checked").each(function () {
                        idSucursal.push($(this).val());
                    });

                    $("#Idsucursal2Cliente").val(idSucursal);
                },
                checkAll: function () {
                    var idSucursal = new Array();
                    $("input[name='multiselect_IdSucursalCliente']:checked").each(function () {
                        idSucursal.push($(this).val());
                    });

                    $("#Idsucursal2Cliente").val(idSucursal);
                },
                uncheckAll: function () {
                    $("#Idsucursal2Cliente").val('');

                }
            });
            $("#IdSucursalCliente").multiselect("uncheckAll");

        }

    });
}

function CargarJefeRegional_Ventas() {
    var FechaInicio = $("#ID_FechaInicio").val();
    var FechaFin = $("#ID_FechaFin").val();
    var vUrl = $("#UrlCargaJefeRegional").val();
    var CargaRRVV = $("#IdVendedor_").val();

    $.ajax({
        url: vUrl,
        type: "GET",
        data: {
            FechaIni: FechaInicio,
            FechaFin: FechaFin
        },
        success: function (data) {
            $("#ID_ComboJefeRegional").html(data);

            $("#IdJefeRegional").multiselect({

                click: function (event, ui) {
                    var idVendedor = new Array();
                    $("input[name='multiselect_IdJefeRegional']:checked").each(function () {
                        idVendedor.push($(this).val());
                    });

                    $("#iIdJefeRegional").val(idVendedor);
                    if (CargaRRVV == null) {
                        CargarRRVV_Ventas();
                    }
                },
                checkAll: function () {
                    var idVendedor = new Array();
                    $("input[name='multiselect_IdJefeRegional']:checked").each(function () {
                        idVendedor.push($(this).val());
                    });

                    $("#iIdJefeRegional").val(idVendedor);
                    if (CargaRRVV == null) {
                        CargarRRVV_Ventas();
                    }
                },
                uncheckAll: function () {
                    $("#iIdJefeRegional").val('');
                    if (CargaRRVV == null) {
                        CargarRRVV_Ventas();
                    }
                }
            });
            $("#IdJefeRegional").multiselect("uncheckAll");
        }

    });
}

function CargarRRVV_Ventas() {
    var vjefe = "";
    var vjefe1 = "" + $("#IdJefeRegional_").val();
    var vjefe2 = "" + $("#iIdJefeRegional").val();

    if (vjefe1 == null || vjefe1 == "undefined") {
        vjefe = vjefe2;
    } else {
        vjefe = vjefe1;
    }

    var FechaInicio = $("#ID_FechaInicio").val();
    var FechaFin = $("#ID_FechaFin").val();
    var vUrl = $("#UrlCargaRRVV").val();

    $.ajax({
        url: vUrl,
        type: "GET",
        data: {
            jefe: vjefe,
            FechaIni: FechaInicio,
            FechaFin: FechaFin

        },
        cache: false,
        success: function (data) {
            $("#DivRRVV").html(data);

            $("#IdVendedor").multiselect({

                click: function (event, ui) {
                    var idVendedor = new Array();
                    $("input[name='multiselect_IdVendedor']:checked").each(function () {
                        idVendedor.push($(this).val());
                    });

                    $("#ID_Empleado_V").val(idVendedor);

                },
                checkAll: function () {
                    var idVendedor = new Array();
                    $("input[name='multiselect_IdVendedor']:checked").each(function () {
                        idVendedor.push($(this).val());
                    });

                    $("#ID_Empleado_V").val(idVendedor);

                },
                uncheckAll: function () {
                    $("#ID_Empleado_V").val('');

                }
            });
            $("#IdVendedor").multiselect("uncheckAll");
        }
    });
}

function VerReporteVentas() {
    if (ValidaFecha()) {

        var vUrl = $("#ID_URL").val();
        var vFechaInicio = $("#ID_FechaInicio").val();
        var vFechaFin = $("#ID_FechaFin").val();
        var vIdSucursal = $("#IdSucursalCliente").val();
        var vRuc = $("#ID_Ruc").val();
        var vRazonSocial = $("#ID_RazonSocial").val();

        var vIdJefeRegional = "";
        var vIdJefeRegional1 = "" + $("#IdJefeRegional_").val();
        var vIdJefeRegional2 = "" + $("#IdJefeRegional").val();

        if (vIdJefeRegional1 == null || vIdJefeRegional1 == "undefined") {
            vIdJefeRegional = vIdJefeRegional2;
        } else {
            vIdJefeRegional = vIdJefeRegional1;
        }

        var vIdVendedor = "";
        var vIdVendedor1 = "" + $("#IdVendedor_").val();
        var vIdVendedor2 = "" + $("#IdVendedor").val();

        if (vIdVendedor1 == null || vIdVendedor1 == "undefined") {
            vIdVendedor = vIdVendedor2;
        } else {
            vIdVendedor = vIdVendedor1;
        }

        var vIdTipoCliente = $("#IdTipoCliente").val();
        var vZona = $("#ID_Zona").val();
        var vIdGrupo = $("#IdGrupo").val();

        if (vIdSucursal == null)
        { vIdSucursal = 0 }
        else { vIdSucursal = $("#IdSucursalCliente").val().toString() }
        if (vZona == null)
        { vZona = 0 }
        else { vZona = $("#ID_Zona").val().toString() }

        if (vIdVendedor == 'null') { vIdVendedor = "0" }
        if (vIdJefeRegional == 'null') { vIdJefeRegional = "0" }

        $.ajax({
            url: vUrl,
            type: "POST",
            data: {
                FechaInicio: vFechaInicio,
                FechaFin: vFechaFin,
                Sucursal: vIdSucursal,
                Ruc: vRuc,
                JefeRegional: vIdJefeRegional,
                Vendedor: vIdVendedor,
                TipoCliente: vIdTipoCliente,
                RazonSocial: vRazonSocial,
                Zona: vZona,
                IdGrupo: vIdGrupo
            },
            cache: false,
            success: function (data, textStatus, jqXHR) {
                $("#ID_Partial_ReporteVentas").empty();
                $('#ID_Partial_ReporteVentas').html(data);
                $("#ID_Partial_ReporteVentas").css("display", "block");
                $("#ID_Partial_ReporteVentas").dialog("open");
            }
        });
    }
}

function ValidaFecha() {
    var valida = true;
    if (ValidarFecha("ID_FechaInicio") == 0) {
        replaceErrorMessagge("ID_MsgFechaInicio", "");
    }
    else {
        replaceErrorMessagge("ID_MsgFechaInicio", "Ingrese una fecha de inicio correcta");
        valida = false;
    }
    if (ValidarFecha("ID_FechaFin") == 0) {
        replaceErrorMessagge("ID_MsgFechaFin", "");
    }
    else {
        replaceErrorMessagge("ID_MsgFechaFin", "Ingrese una fecha de fin correcta");
        valida = false;
    }
    if (ValidarFecha("ID_FechaInicio") == 0 && ValidarFecha("ID_FechaFin") == 0) {
        var vFechaInicio = $("#ID_FechaInicio").val();
        var vFechaFin = $("#ID_FechaFin").val();
        if (Comparar_Fechas(vFechaInicio, vFechaFin)) {
            replaceErrorMessagge("ID_MsgFechaInicio", "La Fecha Inicio no debe ser mayor a la Fecha Fin");
            replaceErrorMessagge("ID_MsgFechaFin", "");
            valida = false;
        }
    }
    return valida;
}

function replaceErrorMessagge(IdDiv, Message) {
    $("#" + IdDiv).replaceWith('<div style="color: #EC6464; font-size:9px;" id="' + IdDiv + '">' + Message + '</div>');
}

