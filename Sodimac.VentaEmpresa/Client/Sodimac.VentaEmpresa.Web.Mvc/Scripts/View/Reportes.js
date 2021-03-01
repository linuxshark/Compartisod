function SaveLogExport(TipoExport, IdOrigenAccion) {

    var ParamUrl = "/Reportes/GuardarLogExport";

    //server request
    $.ajax({
        url: ParamUrl,
        data: { TipoExport: TipoExport, IdOrigenAccion: IdOrigenAccion },
        type: "post",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            //var Mensaje = data.Mensaje;
            //Mensaje correctamente; no es necesario
        },
        error: function (jqXHR, status, error) {
        },
        complete: function () {
        }
    });
}


//----------------------------------------- REPORTE GUIA -------------------------------------------------------

function CargaZonasporFechas_Guia() {
    var FechaInicio = $("#ID_FechaInicio").val();
    var FechaFin = $("#ID_FechaFin").val();
    var vUrl = $("#UrlCargaZonaPorFecha").val();
    var CargaRRVV = $("#ID_Empleado_G").val();

    if (ValidaFecha()) {

        $.ajax({
            url: vUrl,
            type: "GET",
            data: {
                FechaIni: FechaInicio,
                FechaFin: FechaFin
            },
            success: function (data) {

                if (CargaRRVV == null) {
                    CargarRRVV_Guia();
                }

                $("#DivZonaM").html(data);

                $("#ID_Zona").multiselect({

                    click: function (event, ui) {
                        var IdZona = new Array();
                        $("input[name='multiselect_ID_Zona']:checked").each(function () {
                            IdZona.push($(this).val());
                        });

                        $("#IdZona2").val(IdZona);
                        CargarSucursal_Reporte_Guia();
                    },
                    checkAll: function () {
                        var IdZona = new Array();
                        $("input[name='multiselect_ID_Zona']:checked").each(function () {
                            IdZona.push($(this).val());
                        });

                        $("#IdZona2").val(IdZona);
                        CargarSucursal_Reporte_Guia();
                    },

                    uncheckAll: function () {
                        $("#IdZona2").val('');
                        CargarSucursal_Reporte_Guia();
                    }
                });
                $("#ID_Zona").multiselect("uncheckAll");

            }

        });
    }
}

function CargarSucursal_Reporte_Guia() {
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
                        //idSucursal.push($(this).val());
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

function CargarRRVV_Guia() {
    var FechaInicio = $("#ID_FechaInicio").val();
    var FechaFin = $("#ID_FechaFin").val();
    var vUrl = $("#UrlCargaRRVV").val();

    $.ajax({
        url: vUrl,
        type: "GET",
        data: {
            jefe: "",
            FechaIni: FechaInicio,
            FechaFin: FechaFin

        },
        cache: false,
        success: function (data) {
            $("#DivRRVV").html(data);
            //Jefe
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

function VerReporteGuia() {
    var ArraySucursales = $("#IdSucursalCliente").val()
    if (ArraySucursales == null) {
        ArraySucursales = '0'
    }

    var ArrayZonas = $("#ID_Zona").val()
    if (ArrayZonas == null) {
        ArrayZonas = '0'
    }

    var ArrayRRVV = $("#IdVendedor").val()
    if (ArrayRRVV == null) {
        ArrayRRVV = '0'
    }

    if (ValidaFecha()) {
        var vUrl = $("#ID_URL").val();
        var vFechaInicio = $("#ID_FechaInicio").val();
        var vFechaFin = $("#ID_FechaFin").val();
        var Sucursales = ArraySucursales.toString();
        var Zonas = ArrayZonas.toString();
        //var vCodigoSucursal = $("#IdSucursal").val();
        var vIdCorrelativo = $("#ID_Correlativo").val();
        var vTipoPedido = $("#ID_TipoPedido").val();
        var vCaja = $("#ID_Caja").val();
        var vIdEmpleado = ArrayRRVV.toString();  //$("#ID_Empleado").val();
        $.ajax({
            url: vUrl,
            type: "POST",
            data: {
                FechaInicio: vFechaInicio,
                FechaFin: vFechaFin,
                Sucursal: Sucursales,
                Zona: Zonas,
                Correlativo: vIdCorrelativo,
                TipoPedido: vTipoPedido,
                Caja: vCaja,
                Vendedor: vIdEmpleado
            },
            cache: false,
            success: function (data, textStatus, jqXHR) {
                $("#ID_Partial_ReporteGuia").empty();
                $('#ID_Partial_ReporteGuia').html(data);
                $("#ID_Partial_ReporteGuia").css("display", "block");
                $("#ID_Partial_ReporteGuia").dialog("open");
            }
        });
    }
}


//----------------------------------------- REPORTE VENTAS -------------------------------------------------------

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

//----------------------------------------- EXPORTAR EXCEL  --º-----------------------------------------------------
function ExportarReporteVentas() {
    
    if (ValidaFecha()) {

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


        Url = vUrl + '?FechaInicio=' + vFechaInicio + '&FechaFin=' + vFechaFin + '&Sucursal=' + vIdSucursal + '&Ruc=' + vRuc + '&JefeRegional=' + vIdJefeRegional + '&Vendedor=' + vIdVendedor + '&TipoCliente=' + vIdTipoCliente + '&RazonSocial=' + vRazonSocial + '&Zona=' + vZona + '&IdGrupo=' + vIdGrupo;

        window.open(Url, '_self');


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
    debugger;
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

//----------------------------------------- REPORTE COMISIONES -------------------------------------------------------

function CargaZonasporFechas_Comision() {
    var FechaInicio = $("#ID_FechaInicio").val();
    var FechaFin = $("#ID_FechaFin").val();
    var vUrl = $("#UrlCargaZonaPorFecha").val();

    if (ValidaFecha()) {

        $.ajax({
            url: vUrl,
            type: "GET",
            data: {
                FechaIni: FechaInicio,
                FechaFin: FechaFin
            },
            success: function (data) {

                $("#DivZonaM").html(data);

                $("#ID_Zona").multiselect({

                    click: function (event, ui) {
                        var IdZona = new Array();
                        $("input[name='multiselect_ID_Zona']:checked").each(function () {
                            IdZona.push($(this).val());
                        });

                        $("#IdZona2").val(IdZona);

                        CargarSucursal_Reporte_Comision();
                    },
                    checkAll: function () {
                        var IdZona = new Array();
                        $("input[name='multiselect_ID_Zona']:checked").each(function () {
                            IdZona.push($(this).val());
                        });

                        $("#IdZona2").val(IdZona);

                        CargarSucursal_Reporte_Comision();
                    },

                    uncheckAll: function () {
                        $("#IdZona2").val('');

                        CargarSucursal_Reporte_Comision();
                    }
                });
                $("#ID_Zona").multiselect("uncheckAll");

            }

        });
    }
}

function CargarSucursal_Reporte_Comision() {
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

function VerReporteComisiones() {
    if (ValidaFecha()) {

        var vUrl = $("#ID_URL").val();
        var vFechaInicio = $("#ID_FechaInicio").val();
        var vFechaFin = $("#ID_FechaFin").val();
        var vIdSucursal = $("#IdSucursalCliente").val()
        var vZona = $("#ID_Zona").val()
        if (vIdSucursal == null)
        { vIdSucursal = 0 }
        else { vIdSucursal = $("#IdSucursalCliente").val().toString() }
        if (vZona == null)
        { vZona = 0 }
        else { vZona = $("#ID_Zona").val().toString() }

        $.ajax({
            url: vUrl,
            type: "POST",
            data: {
                FechaInicio: vFechaInicio,
                FechaFin: vFechaFin,
                Sucursal: vIdSucursal,
                Zona: vZona
            },
            cache: false,
            success: function (data, textStatus, jqXHR) {
                $("#ID_Partial_ReporteComisiones").empty();
                $('#ID_Partial_ReporteComisiones').html(data);
                $("#ID_Partial_ReporteComisiones").css("display", "block");
                $("#ID_Partial_ReporteComisiones").dialog("open");
            }
        });
    }
}

//----------------------------------------- REPORTE TIENDAS -------------------------------------------------------

function CargaZonasporFechas_Tiendas() {
    var FechaInicio = $("#ID_FechaInicio").val();
    var FechaFin = $("#ID_FechaFin").val();
    var vUrl = $("#UrlCargaZonaPorFecha").val();

    if (ValidaFecha()) {

        $.ajax({
            url: vUrl,
            type: "GET",
            data: {
                FechaIni: FechaInicio,
                FechaFin: FechaFin
            },
            success: function (data) {

                $("#DivZonaM").html(data);

                $("#ID_Zona").multiselect({

                    click: function (event, ui) {
                        var IdZona = new Array();
                        $("input[name='multiselect_ID_Zona']:checked").each(function () {
                            IdZona.push($(this).val());
                        });

                        $("#IdZona2").val(IdZona);

                        CargarSucursal_Reporte_Tienda();
                    },
                    checkAll: function () {
                        var IdZona = new Array();
                        $("input[name='multiselect_ID_Zona']:checked").each(function () {
                            IdZona.push($(this).val());
                        });

                        $("#IdZona2").val(IdZona);

                        CargarSucursal_Reporte_Tienda();
                    },

                    uncheckAll: function () {
                        $("#IdZona2").val('');

                        CargarSucursal_Reporte_Tienda();
                    }
                });
                $("#ID_Zona").multiselect("uncheckAll");

            }

        });
    }
}

function CargarSucursal_Reporte_Tienda() {
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

function VerReporteTiendas() {
    if (ValidaFecha()) {
        var vUrl = $("#ID_URL").val();
        var vFechaInicio = $("#ID_FechaInicio").val();
        var vFechaFin = $("#ID_FechaFin").val();
        var vIdSucursal = $("#IdSucursal").val();
        var vIdZona = $("#ID_Zona").val();

        $.ajax({
            url: vUrl,
            type: "POST",
            data: {
                FechaInicio: vFechaInicio,
                FechaFin: vFechaFin,
                Sucursal: vIdSucursal.toString(),
                Zona: vIdZona.toString()
            },
            cache: false,
            success: function (data, textStatus, jqXHR) {
                $("#ID_Partial_ReporteTiendas").empty();
                $('#ID_Partial_ReporteTiendas').html(data);
                $("#ID_Partial_ReporteTiendas").css("display", "block");
                $("#ID_Partial_ReporteTiendas").dialog("open");
            }
        });
    }
}

//----------------------------------------- REPORTE REPRESENTANTE DE VENTAS -------------------------------------------------------

function CargaZonasporFechas_RptVendedores() {
    var FechaInicio = $("#ID_FechaInicio").val();
    var FechaFin = $("#ID_FechaFin").val();
    var vUrl = $("#UrlCargaZonaPorFecha").val();
    var CargarJefe = $("#IdJefeRegional").val();

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
                    CargarJefeRegional_Rpt_Vendedores();
                }

                $("#DivZonaM").html(data);

                $("#ID_Zona").multiselect({

                    click: function (event, ui) {
                        var IdZona = new Array();
                        $("input[name='multiselect_ID_Zona']:checked").each(function () {
                            IdZona.push($(this).val());
                        });

                        $("#IdZona2").val(IdZona);

                        CargarSucursal_Reporte_RptVendedores();
                    },
                    checkAll: function () {
                        var IdZona = new Array();
                        $("input[name='multiselect_ID_Zona']:checked").each(function () {
                            IdZona.push($(this).val());
                        });

                        $("#IdZona2").val(IdZona);

                        CargarSucursal_Reporte_RptVendedores();
                    },

                    uncheckAll: function () {
                        $("#IdZona2").val('');

                        CargarSucursal_Reporte_RptVendedores();
                    }
                });
                $("#ID_Zona").multiselect("uncheckAll");

            }

        });
    }
}

function CargarSucursal_Reporte_RptVendedores() {
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

function CargarJefeRegional_Rpt_Vendedores() {

    var FechaInicio = $("#ID_FechaInicio").val();
    var FechaFin = $("#ID_FechaFin").val();
    var vUrl = $("#UrlCargaJefeRegional").val();

    $.ajax({
        url: vUrl,
        type: "GET",
        data: {
            FechaIni: FechaInicio,
            FechaFin: FechaFin
        },
        success: function (data) {
            $("#ID_ComboJefeRegional").html(data);
            //Jefe
            $("#IdJefeRegional").multiselect({

                click: function (event, ui) {
                    var idVendedor = new Array();
                    $("input[name='multiselect_IdJefeRegional']:checked").each(function () {
                        idVendedor.push($(this).val());
                    });

                    $("#iIdJefeRegional").val(idVendedor);

                },
                checkAll: function () {
                    var idVendedor = new Array();
                    $("input[name='multiselect_IdJefeRegional']:checked").each(function () {
                        idVendedor.push($(this).val());
                    });

                    $("#iIdJefeRegional").val(idVendedor);

                },
                uncheckAll: function () {
                    $("#iIdJefeRegional").val('');

                }
            });
            $("#IdJefeRegional").multiselect("uncheckAll");

        }

    });

}

function VerReporteVendedores() {
    if (ValidaFecha()) {
        var vUrl = $("#ID_URL").val();
        var vFechaInicio = $("#ID_FechaInicio").val();
        var vFechaFin = $("#ID_FechaFin").val();
        var vIdSucursal = $("#IdSucursalCliente").val();
        var vZona = $("#ID_Zona").val();
        var vIdJefeRegional = $("#IdJefeRegional").val();

        if (vIdSucursal == null) { vIdSucursal = '0' }
        else { vIdSucursal = $("#IdSucursalCliente").val().toString() }
        if (vZona == null) { vZona = '0' }
        else { vZona = $("#ID_Zona").val().toString() }
        if (vIdJefeRegional == null) { vIdJefeRegional = '0' }
        else { vIdJefeRegional = $("#IdJefeRegional").val().toString() }
        $.ajax({
            url: vUrl,
            type: "POST",
            data: {
                FechaInicio: vFechaInicio,
                FechaFin: vFechaFin,
                Sucursal: vIdSucursal,
                JefeRegional: vIdJefeRegional,
                IdZona: vZona
            },
            cache: false,
            success: function (data, textStatus, jqXHR) {
                $("#ID_Partial_ReporteVendedores").empty();
                $('#ID_Partial_ReporteVendedores').html(data);
                $("#ID_Partial_ReporteVendedores").css("display", "block");
                $("#ID_Partial_ReporteVendedores").dialog("open");
            }
        });
    }
}

//----------------------------------------- REPORTE JEFE DE VENTAS -------------------------------------------------------

function CargaZonasporFechas_JefeVentas() {
    var FechaInicio = $("#ID_FechaInicio").val();
    var FechaFin = $("#ID_FechaFin").val();
    var vUrl = $("#UrlCargaZonaPorFecha").val();

    if (ValidaFecha()) {

        $.ajax({
            url: vUrl,
            type: "GET",
            data: {
                FechaIni: FechaInicio,
                FechaFin: FechaFin
            },
            success: function (data) {
                $("#DivZonaM").html(data);

                $("#ID_Zona").multiselect({

                    click: function (event, ui) {
                        var IdZona = new Array();
                        $("input[name='multiselect_ID_Zona']:checked").each(function () {
                            IdZona.push($(this).val());
                        });

                        $("#IdZona2").val(IdZona);

                        CargarSucursal_Reporte_JefeVentas();
                    },
                    checkAll: function () {
                        var IdZona = new Array();
                        $("input[name='multiselect_ID_Zona']:checked").each(function () {
                            IdZona.push($(this).val());
                        });

                        $("#IdZona2").val(IdZona);

                        CargarSucursal_Reporte_JefeVentas();
                    },

                    uncheckAll: function () {
                        $("#IdZona2").val('');

                        CargarSucursal_Reporte_JefeVentas();
                    }
                });
                $("#ID_Zona").multiselect("uncheckAll");

            }

        });
    }
}

function CargarSucursal_Reporte_JefeVentas() {
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

function VerReporteJefeRegional() {
    if (ValidaFecha()) {
        var vUrl = $("#ID_URL").val();
        var vFechaInicio = $("#ID_FechaInicio").val();
        var vFechaFin = $("#ID_FechaFin").val();
        var vIdSucursal = $("#IdSucursalCliente").val();
        var vIdZona = $("#ID_Zona").val();

        if (vIdZona == null) { vIdZona = '0' }
        else { vIdZona = $("#ID_Zona").val().toString() }
        if (vIdSucursal == null) { vIdSucursal = '0' }
        else { vIdSucursal = $("#IdSucursalCliente").val().toString() }

        $.ajax({
            url: vUrl,
            type: "POST",
            data: {
                FechaInicio: vFechaInicio,
                FechaFin: vFechaFin,
                Zona: vIdZona,
                Sucursal: vIdSucursal
            },
            cache: false,
            success: function (data, textStatus, jqXHR) {
                $("#ID_Partial_ReporteJefeRegional").empty();
                $('#ID_Partial_ReporteJefeRegional').html(data);
                $("#ID_Partial_ReporteJefeRegional").css("display", "block");
                $("#ID_Partial_ReporteJefeRegional").dialog("open");
            }
        });
    }
}


//----------------------------------------- REPORTE CLIENTES -------------------------------------------------------

$(function () {

    $("#ID_ZonaCliente").multiselect(
        {

        click: function (event, ui) {
            var IdZona = new Array();
            $("input[name='multiselect_ID_ZonaCliente']:checked").each(function () {
                IdZona.push($(this).val());
            });

            $("#IdZona2Cliente").val(IdZona);
            CargarSucursal2_Cliente();
        },
        checkAll: function () {
            var IdZona = new Array();
            $("input[name='multiselect_ID_ZonaCliente']:checked").each(function () {
                IdZona.push($(this).val());
            });

            $("#IdZona2Cliente").val(IdZona);
            CargarSucursal2_Cliente();
        },

        uncheckAll: function () {
            $("#IdZona2Cliente").val('');
            CargarSucursal2_Cliente();
        }
    });
    $("#ID_ZonaCliente").multiselect("uncheckAll");


    $("#IdSucursalCliente").multiselect(
        {

        click: function (event, ui) {
            var IdSucursal = new Array();
            $("input[name='multiselect_IdSucursalCliente']:checked").each(function () {
                IdZona.push($(this).val());
            });

            $("#Idsucursal2Cliente").val(IdSucursal);
        },
        checkAll: function () {
            var IdSucursal = new Array();
            $("input[name='multiselect_IdSucursalCliente']:checked").each(function () {
                IdZona.push($(this).val());
            });

            $("#Idsucursal2Cliente").val(IdSucursal);
        },

        uncheckAll: function () {
            $("#Idsucursal2Cliente").val('');
        }
    });
    $("#IdSucursalCliente").multiselect("uncheckAll");
})

function CargarSucursal2_Cliente() {
    var IdZona = new Array();
    $("input[name='multiselect_ID_ZonaCliente']:checked").each(function () {
        IdZona.push($(this).val());
    });

    $("#IdZona2Cliente").val(IdZona);
    var vZonaCadena = $("#IdZona2Cliente").val();

    var vUrl = $("#UrlCargaSucursalZona").val();

    $.ajax({
        url: vUrl,
        type: "GET",
        data: {
            IdZonaCadena: vZonaCadena
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

function VerReporteClientes() {

    var vUrl = $("#ID_URL").val();
    var vIdClienteSector = $("#IdClienteSector").val();
    var vIdClienteCategoria = $("#IdCategoria").val();
    var vIdModoPago = $("#IdFormaPago").val();
    var vIdSucursal = $("#IdSucursalCliente").val();
    var vIdClienteTipo = $("#IdTipoCliente").val();
    var vZona = $("#ID_ZonaCliente").val();
    var vIdEstadoLinea = $("#IdEstadoLinea").val();
    var vIdVendedor = $("#IdVendedor").val();

    if (vIdSucursal == null) { vIdSucursal = '0' }
    else { vIdSucursal = $("#IdSucursalCliente").val().toString() }
    if (vZona == null) { vZona = '0' }
    else { vZona = $("#ID_ZonaCliente").val().toString() }

    $.ajax({
        url: vUrl,
        type: "POST",
        data: {
            Sector: vIdClienteSector,
            Categoria: vIdClienteCategoria,
            FormaPago: vIdModoPago,
            Sucursal: vIdSucursal,
            TipoCliente: vIdClienteTipo,
            Zona: vZona,
            EstadoLinea: vIdEstadoLinea,
            Vendedor: vIdVendedor
        },
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#ID_Partial_ReporteClientes").empty();
            $('#ID_Partial_ReporteClientes').html(data);
            $("#ID_Partial_ReporteClientes").css("display", "block");
            $("#ID_Partial_ReporteClientes").dialog("open");
        }
    });
}

//----------------------------------------- REPORTE CLIENTES HISTORIAL -------------------------------------------------------

function CargaZonasporFechas_ClienteHistorial() {
    var FechaInicio = $("#ID_FechaInicio").val();
    var FechaFin = $("#ID_FechaFin").val();
    var vUrl = $("#UrlCargaZonaPorFecha").val();

    if (ValidaFecha()) {

        $.ajax({
            url: vUrl,
            type: "GET",
            data: {
                FechaIni: FechaInicio,
                FechaFin: FechaFin
            },
            success: function (data) {
                $("#DivZonaM").html(data);

                $("#ID_Zona").multiselect({

                    click: function (event, ui) {
                        var IdZona = new Array();
                        $("input[name='multiselect_ID_Zona']:checked").each(function () {
                            IdZona.push($(this).val());
                        });

                        $("#IdZona2").val(IdZona);

                        CargarSucursal_Reporte_ClienteHistorial();
                    },
                    checkAll: function () {
                        var IdZona = new Array();
                        $("input[name='multiselect_ID_Zona']:checked").each(function () {
                            IdZona.push($(this).val());
                        });

                        $("#IdZona2").val(IdZona);

                        CargarSucursal_Reporte_ClienteHistorial();
                    },

                    uncheckAll: function () {
                        $("#IdZona2").val('');

                        CargarSucursal_Reporte_ClienteHistorial();
                    }
                });
                $("#ID_Zona").multiselect("uncheckAll");

            }

        });
    }
}

function CargarSucursal_Reporte_ClienteHistorial() {
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

function VerReporteClientesHistorial() {
    if (ValidaFecha()) {
        var vUrl = $("#ID_URL").val();
        var vFechaInicio = $("#ID_FechaInicio").val();
        var vFechaFin = $("#ID_FechaFin").val();
        var vIdModoPago = $("#IdFormaPago").val();
        var vZona = $("#ID_Zona").val();
        var vIdSucursal = $("#IdSucursalCliente").val();
        var vIdClienteSector = $("#IdClienteSector").val();
        var vIdClienteCategoria = $("#IdCategoria").val();
        var vRazonSocialRUC = $("#ID_RazonSocial").val();

        if (vIdSucursal == null) { vIdSucursal = '0' }
        else { vIdSucursal = $("#IdSucursalCliente").val().toString() }
        if (vZona == null) { vZona = '0' }
        else { vZona = $("#ID_Zona").val().toString() }

        $.ajax({
            url: vUrl,
            type: "POST",
            data: {
                FechaInicio: vFechaInicio,
                FechaFin: vFechaFin,
                Zona: vZona,
                Sucursal: vIdSucursal,
                Sector: vIdClienteSector,
                Categoria: vIdClienteCategoria,
                FormaPago: vIdModoPago,
                RazonSocialRUC: vRazonSocialRUC
            },
            cache: false,
            success: function (data, textStatus, jqXHR) {
                $("#ID_Partial_ReporteClientesHistorial").empty();
                $('#ID_Partial_ReporteClientesHistorial').html(data);
                $("#ID_Partial_ReporteClientesHistorial").css("display", "block");
                $("#ID_Partial_ReporteClientesHistorial").dialog("open");
            }
        });
    }
}

//----------------------------------------- REPORTE LOG -------------------------------------------------------

function VerReporteLog() {
    if (ValidaFecha()) {
        var vUrl = $("#ID_URL").val();
        var vFechaInicio = $("#ID_FechaInicio").val();
        var vFechaFin = $("#ID_FechaFin").val();
        var vIdLogAccion = !$("#ID_LogAccion").val() ? "" : $("#ID_LogAccion").val() + '';
        var vIdOrigenAccion = !$("#ID_OrigenAccion").val() ? "" : $("#ID_OrigenAccion").val() + '';
        $.ajax({
            url: vUrl,
            type: "POST",
            data: {
                FechaInicio: vFechaInicio,
                FechaFin: vFechaFin,
                IdLogAccion: vIdLogAccion,
                IdOrigenAccion: vIdOrigenAccion
            },
            cache: false,
            success: function (data, textStatus, jqXHR) {
                $("#ID_Partial_ReporteLog").empty();
                $('#ID_Partial_ReporteLog').html(data);
                $("#ID_Partial_ReporteLog").css("display", "block");
                $("#ID_Partial_ReporteLog").dialog("open");
            }
        });
    }
}

//----------------------------------------- REPORTE COMISION DETALLE ----------------------------------------------------

function CargaZonasporFechas_ComisionDetalle() {
    var FechaInicio = $("#ID_FechaInicio").val();
    var FechaFin = $("#ID_FechaFin").val();
    var vUrl = $("#UrlCargaZonaPorFecha").val();
    var CargarJefe_CD = $("#IdJefeRegional_CD").val();
    var CargaRRVV_CD = $("#IdVendedor_CD").val();

    if (ValidaFecha()) {

        $.ajax({
            url: vUrl,
            type: "GET",
            data: {
                FechaIni: FechaInicio,
                FechaFin: FechaFin
            },
            success: function (data) {

                if (CargarJefe_CD == null) {
                    CargarJefeRegional_ComisionDetalle();
                } else {
                    CargarRRVV_ComisionDetalle();
                }

                $("#DivZonaM").html(data);

                $("#ID_Zona").multiselect({

                    click: function (event, ui) {
                        var IdZona = new Array();
                        $("input[name='multiselect_ID_Zona']:checked").each(function () {
                            IdZona.push($(this).val());
                        });

                        $("#IdZona2").val(IdZona);

                        CargarSucursal_Reporte_ComisionDetalle();
                    },
                    checkAll: function () {
                        var IdZona = new Array();
                        $("input[name='multiselect_ID_Zona']:checked").each(function () {
                            IdZona.push($(this).val());
                        });

                        $("#IdZona2").val(IdZona);

                        CargarSucursal_Reporte_ComisionDetalle();
                    },

                    uncheckAll: function () {
                        $("#IdZona2").val('');

                        CargarSucursal_Reporte_ComisionDetalle();
                    }
                });
                $("#ID_Zona").multiselect("uncheckAll");

            }

        });
    }
}

function CargarSucursal_Reporte_ComisionDetalle() {
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

function CargarJefeRegional_ComisionDetalle() {

    var FechaInicio = $("#ID_FechaInicio").val();
    var FechaFin = $("#ID_FechaFin").val();
    var vUrl = $("#UrlCargaJefeRegional").val();
    var CargaRRVV_CD = $("#IdVendedor_CD").val();

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
                    if (CargaRRVV_CD == null) {
                        CargarRRVV_ComisionDetalle();
                    }
                },
                checkAll: function () {
                    var idVendedor = new Array();
                    $("input[name='multiselect_IdJefeRegional']:checked").each(function () {
                        idVendedor.push($(this).val());
                    });

                    $("#iIdJefeRegional").val(idVendedor);
                    if (CargaRRVV_CD == null) {
                        CargarRRVV_ComisionDetalle();
                    }
                },
                uncheckAll: function () {
                    $("#iIdJefeRegional").val('');
                    if (CargaRRVV_CD == null) {
                        CargarRRVV_ComisionDetalle();
                    }
                }
            });
            $("#IdJefeRegional").multiselect("uncheckAll");
        }

    });
}

function CargarRRVV_ComisionDetalle() {
    var vjefe = "";
    var vjefe1 = "" + $("#IdJefeRegional_CD").val();
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

function VerReporteComisionesDetallado() {
    if (ValidaFecha()) {

        var vUrl = $("#ID_URL").val();
        var vFechaInicio = $("#ID_FechaInicio").val();
        var vFechaFin = $("#ID_FechaFin").val();
        var vIdSucursal = $("#IdSucursalCliente").val()
        var vZona = $("#ID_Zona").val()
        if (vIdSucursal == null)
        { vIdSucursal = 0 }
        else { vIdSucursal = $("#IdSucursalCliente").val().toString() }
        if (vZona == null)
        { vZona = 0 }
        else { vZona = $("#ID_Zona").val().toString() }

        var vIdJefeRegional = "";
        var vIdJefeRegional1 = "" + $("#IdJefeRegional_CD").val();
        var vIdJefeRegional2 = "" + $("#IdJefeRegional").val();

        if (vIdJefeRegional1 == null || vIdJefeRegional1 == "undefined") {
            vIdJefeRegional = vIdJefeRegional2;
        } else {
            vIdJefeRegional = vIdJefeRegional1;
        }

        var vIdVendedor = "";
        var vIdVendedor1 = "" + $("#IdVendedor_CD").val();
        var vIdVendedor2 = "" + $("#IdVendedor").val();

        if (vIdVendedor1 == null || vIdVendedor1 == "undefined") {
            vIdVendedor = vIdVendedor2;
        } else {
            vIdVendedor = vIdVendedor1;
        }

        $.ajax({
            url: vUrl,
            type: "POST",
            data: {
                FechaInicio: vFechaInicio,
                FechaFin: vFechaFin,
                Sucursal: vIdSucursal,
                Zona: vZona,
                IdRRVV: vIdVendedor,
                IdJefe: vIdJefeRegional
            },
            cache: false,
            success: function (data, textStatus, jqXHR) {
                $("#ID_Partial_ReporteComisionesDetallado").empty();
                $('#ID_Partial_ReporteComisionesDetallado').html(data);
                $("#ID_Partial_ReporteComisionesDetallado").css("display", "block");
                $("#ID_Partial_ReporteComisionesDetallado").dialog("open");
            }
        });
    }
}

//----------------------------------------------------------------------------------------------------------------------------------------------

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




//function ListarSucursalporZona() {
//    var vUrl = CreateUrl("ListarSucursal_By_Zona", "Reportes");
//    var vIdZona = $("#ID_Zona").val();
//    var vIdSucursal = $("#IdSucursal").val();
//    if (vIdZona == "") {
//        vIdZona = 0;
//        vIdSucursal = 0;
//    }
//    $.ajax({
//        url: vUrl,
//        type: "POST",
//        data: {
//            IdZona: vIdZona
//        },
//        cache: false,
//        success: function (data, textStatus, jqXHR) {
//            $('#ID_ComboSucursal').html(data);
//            $('#IdSucursal').uniform();
//            $('#IdSucursal').removeAttr("onChange")
//        },
//        complete: function () {

//        }
//    });
//}



//function BuscarSucursal_ByJefeRegional() {
//    var vIDJefeRegional = $('#IdJefeRegional').val();
//    if (vIDJefeRegional == '') {
//        vIDJefeRegional = 0;
//    }

//    var vReporte = $('#ID_URL').val();
//    var vUrl = CreateUrl('_ComboSucursal', 'Reportes');
//    $.ajax({
//        url: vUrl,
//        type: "POST",
//        data: {
//            IdJefeRegional: vIDJefeRegional
//        },
//        cache: false,
//        success: function (data, textStatus, jqXHR) {
//            $('#ID_ComboSucursal').html(data);
//            $("#IdSucursal").uniform();
//            if (vReporte == "/Reportes/VerReporteVendedores") {
//                $("#IdSucursal").removeAttr("onchange")
//            }
//            else {
//                if (vIDJefeRegional == 0)
//                    BuscarVendedor_BySucursal();
//            }
//        }
//    });
//}

//function BuscarVendedor_BySucursal() {
//    var vIDSucursal = $('#IdSucursal').val();
//    if (vIDSucursal == '') {
//        vIDSucursal = 0;
//    }
//    var vUrl = CreateUrl('_ComboVendedor', 'Reportes');
//    $.ajax({
//        url: vUrl,
//        type: "POST",
//        data: {
//            IdSucursal: vIDSucursal
//        },
//        cache: false,
//        success: function (data, textStatus, jqXHR) {
//            $('#ID_ComboVendedor').html(data);
//            $("#IdVendedor").uniform();
//        }
//    });
//}

//function BuscarSucursal_ByZona() {
//    var vIdZona = $('#ID_Zona').val();
//    if (vIdZona == '') {
//        vIdZona = 0;
//    }

//    var vUrl = CreateUrl('ListarSucursal_By_Zona', 'Reportes');
//    $.ajax({
//        url: vUrl,
//        type: "POST",
//        data: {
//            IdZona: vIdZona
//        },
//        cache: false,
//        success: function (data, textStatus, jqXHR) {
//            $('#ID_ComboSucursal').html(data);
//            $("#IdSucursal").uniform();
//            if ($('#ID_URL').val() == '/Reportes/VerReporteComisiones') {
//                $("#IdSucursal").removeAttr("onChange")
//            }
//        }
//    });
//}

//function CargarSucursal() {

//    var vZonaCadena = $("#IdZona2").val();
//    var vUrl = $("#UrlCargaSucursalPorFecha").val();

//    $.ajax({
//        url: vUrl,
//        type: "GET",
//        data: {
//            IdZonaCadena: vZonaCadena
//        },
//        success: function (data) {
//            $("#DivSucursalPartial").html(data);

//            //Sucursal
//            $("#IdSucursal").multiselect({

//                click: function (event, ui) {
//                    var idSucursal = new Array();
//                    $("input[name='multiselect_IdSucursal']:checked").each(function () {
//                        idSucursal.push($(this).val());
//                    });

//                    $("#Idsucursal2").val(idSucursal);

//                },
//                checkAll: function () {
//                    var idSucursal = new Array();
//                    $("input[name='multiselect_IdSucursal']:checked").each(function () {
//                        idSucursal.push($(this).val());
//                    });

//                    $("#Idsucursal2").val(idSucursal);

//                },
//                uncheckAll: function () {
//                    $("#Idsucursal2").val('');

//                }
//            });
//            $("#IdSucursal").multiselect("uncheckAll");

//        }

//    });

//}



//function CargaZonasporFechas2() {
//    //    var vUrl = $("#UrlCargaZonaPorFecha").val();
//    $.ajax({
//        url: vUrl,
//        type: "GET",
//        data: {

//        },
//        success: function (data) {
//            $("#DivZonaM").html(data);

//            $("#ID_Zona").multiselect({

//                click: function (event, ui) {
//                    var IdZona = new Array();
//                    $("input[name='multiselect_ID_Zona']:checked").each(function () {
//                        IdZona.push($(this).val());
//                    });

//                    $("#IdZona2").val(IdZona);

//                    //                    CargarSucursal2();
//                },
//                checkAll: function () {
//                    var IdZona = new Array();
//                    $("input[name='multiselect_ID_Zona']:checked").each(function () {
//                        IdZona.push($(this).val());
//                    });

//                    $("#IdZona2").val(IdZona);
//                    //                    CargarSucursal2();
//                },

//                uncheckAll: function () {
//                    $("#IdZona2").val('');
//                    //                    CargarSucursal2();
//                }
//            });
//            $("#ID_Zona").multiselect("uncheckAll");

//        }

//    });

//}


//function CargarJefeRegional() {

//    var FechaInicio = $("#ID_FechaInicio").val();
//    var FechaFin = $("#ID_FechaFin").val();
//    var vUrl = $("#UrlCargaJefeRegional").val();

//    $.ajax({
//        url: vUrl,
//        type: "GET",
//        data: {
//            FechaIni: FechaInicio,
//            FechaFin: FechaFin
//        },
//        success: function (data) {
//            $("#ID_ComboJefeRegional").html(data);
//            //Jefe
//            $("#IdJefeRegional").multiselect({

//                click: function (event, ui) {
//                    var idVendedor = new Array();
//                    $("input[name='multiselect_IdJefeRegional']:checked").each(function () {
//                        idVendedor.push($(this).val());
//                    });

//                    $("#iIdJefeRegional").val(idVendedor);

//                    CargarRRVV();

//                },
//                checkAll: function () {
//                    var idVendedor = new Array();
//                    $("input[name='multiselect_IdJefeRegional']:checked").each(function () {
//                        idVendedor.push($(this).val());
//                    });

//                    $("#iIdJefeRegional").val(idVendedor);

//                    CargarRRVV();
//                },
//                uncheckAll: function () {
//                    $("#iIdJefeRegional").val('');
//                    CargarRRVV();
//                }
//            });
//            $("#IdJefeRegional").multiselect("uncheckAll");

//        }

//    });

//}


//function CargarRRVV() {
//    debugger;
//    var vjefe = $("#iIdJefeRegional").val();
//    var FechaInicio = $("#ID_FechaInicio").val();
//    var FechaFin = $("#ID_FechaFin").val();
//    var vUrl = $("#UrlCargaRRVV").val();


//    $.ajax({
//        url: vUrl,
//        type: "GET",
//        data: {
//            jefe: vjefe,
//            FechaIni: FechaInicio,
//            FechaFin: FechaFin

//        },
//        success: function (data) {
//            $("#DivRRVV").html(data);
//            //Jefe
//            $("#IdVendedor").multiselect({

//                click: function (event, ui) {
//                    var idVendedor = new Array();
//                    $("input[name='multiselect_IdVendedor']:checked").each(function () {
//                        idVendedor.push($(this).val());
//                    });

//                    $("#ID_Empleado_V").val(idVendedor);

//                },
//                checkAll: function () {
//                    var idVendedor = new Array();
//                    $("input[name='multiselect_IdVendedor']:checked").each(function () {
//                        idVendedor.push($(this).val());
//                    });

//                    $("#ID_Empleado_V").val(idVendedor);

//                },
//                uncheckAll: function () {
//                    $("#ID_Empleado_V").val('');

//                }
//            });
//            $("#IdVendedor").multiselect("uncheckAll");

//        }

//    });

//}

function VerReporteEstadoCuenta() {
    var vUrl = $("#ID_URL").val();
    var vIdRUC = $("#ID_RUC").val();
    var vIdRazonSocial = $("#ID_RUC").val();
    $.ajax({
        url: vUrl,
        type: "POST",
        data: {
            RUC: vIdRUC,
            RazonSocial: vIdRazonSocial
        },
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#ID_Partial_ReporteEstadoCuenta").empty();
            $('#ID_Partial_ReporteEstadoCuenta').html(data);
            $("#ID_Partial_ReporteEstadoCuenta").css("display", "block");
            $("#ID_Partial_ReporteEstadoCuenta").dialog("open");
        }
    });
}


function validateIframe() {
    var iframe = document.getElementById("ifrReport");
    var iframeDoc = iframe.contentDocument || iframe.contentWindow.document;
    $(".text_message").show();
    $(".text_success").show();
    if (iframeDoc.readyState == "complete") {
        iframe.contentWindow.onload = function () {
            
        };
        $(".text_message").hide();
        $(".text_success").hide();
        return;
    }
    window.setTimeout('validateIframe();', 100);
}

function VerReporteMargenFierro() {
    if (ValidaFecha()) {
        if ($("#IdEmpresaVal").val() != "") {
            var vUrl = $("#ID_URL").val();
            var vFechaInicio = $("#ID_FechaInicio").val();
            var vFechaFin = $("#ID_FechaFin").val();
            var vIdEmpresa = $("#IdEmpresaVal").val();
            var vIdSucursal = $("#Idsucursal2Cliente").val();
            var vSku = $("#Sku").val();
            var vTipoCaja = $("#IdTipoCaja").val();

            $.ajax({
                url: vUrl,
                type: "POST",
                data: {
                    FechaInicio: vFechaInicio,
                    FechaFin: vFechaFin,
                    Empresa: vIdEmpresa,
                    Sucursal: vIdSucursal,
                    Sku: vSku,
                    TipoCaja: vTipoCaja
                },
                cache: false,
                async: false,
                success: function (data) {
                    $('#ID_Partial_ReporteMargenFierro').html(data);
                    validateIframe();
                }
            });
        }
        else {
            replaceErrorMessagge("ID_MsgEmpresa", "Seleccione una Empresa");
        }
    }
}

function VerReporteVAP() {
    if (ValidaFecha()) {
        if ($("#IdMarcaVal").val() != "") {


            $.ajax({
                url: $("#FrmReporteVap").attr('action'),
                type: "POST",
                data: $("#FrmReporteVap").serialize(),
                cache: false,
                success: function (data) {
                    $('#ID_Partial_ReporteMargenFierro').html(data);
                }
            });
        }
        else {
            replaceErrorMessagge("ID_MsgEmpresa", "Seleccione una Empresa");
        }
    }
}

function CargarComboSucursalEmpresa() {
    replaceErrorMessagge("ID_MsgEmpresa", "");
    var vUrl = $("#ID_URL_SUC").val();
    var Ids = ($("#IdEmpresaVal").val() == "" ? "0" : $("#IdEmpresaVal").val());
    $.ajax({
        url: vUrl,
        type: "GET",
        data: {
            empresa: Ids
        },
        cache: false,
        success: function (data) {
            $("#DivSucursalPartial").empty()
            $("#DivSucursalPartial").html(data);
            $("#IdSucursalCliente").multiselect(
            {
                noneSelectedText: '-SELECCIONE-',
                show: ["bounce", 200],
                minWidth: 220,
                click: function (event, ui) {
                    var idSucursal = new Array();
                    $("input[name='multiselect_IdSucursalCliente']:checked").each(function () {
                        idSucursal.push($(this).val());
                    });
                    $("#Idsucursal2Cliente").val(idSucursal);
                },
                checkAll: function () {
                    var idSucursal = '';
                    //$("input[name='multiselect_IdSucursalCliente']:checked").each(function () {
                    //    idSucursal.push($(this).val());
                    //});
                    //$("#Idsucursal2Cliente").val(idSucursal);
                    $("#Idsucursal2Cliente").val(idSucursal);
                },
                uncheckAll: function () {
                    $("#Idsucursal2Cliente").val('');
                }
            }
         ).multiselectfilter();
            $("#IdSucursalCliente").multiselect("uncheckAll");

        }
    });
}


$(function () {
    var Skus = $.map(ListaSku(), function (e) { return e.Sku });
    //var arr = $.map(obj, function (el) { return el });
    //$("#Sku")
    //    //.keydown( function (event) {
    //    //    if ( event.keyCode === $.ui.keyCode.TAB &&
    //    //        $(this).autocomplete( "instance" ).menu.active ) {
    //    //        event.preventDefault();
    //    //    }
    //    //})
    //    .autocomplete({
    //        source: ["java", "C++"],
    //        delay: 200
    //        //minLength: 0,
    //        //source: function (request, response) {
    //        //    response($.ui.autocomplete.filter(
    //        //      Skus, extractLast(request.term)));
    //        //},
    //        //focus: function () {
    //        //    return false;
    //        //},
    //        //select: function (event, ui) {
    //        //    var terms = split(this.value);
    //        //    terms.pop();
    //        //    terms.push(ui.item.value);
    //        //    terms.push("");
    //        //    this.value = terms.join(", ");
    //        //    return false;
    //        //}
    //    })
})

function ListaSku() {
    var obj = new Object();
    $.ajax($("#ID_URL_MARGEN").val()
        , {
            type: "GET",
            cache: false,
            async: false,
            success: function (data) {
                obj = data
            }
        })
    return obj
}

function split(val) {
    return val.split(/,\s*/);
}
function extractLast(term) {
    return split(term).pop();
}

//MargenFierro


$(document).ready(function () {
    $("#IdEmpresa").multiselect(
        {
            noneSelectedText: '-SELECCIONE-',
            show: ["bounce", 200],
            minWidth: 220,
            click: function (event, ui) {
                var idEmpresa = new Array();
                $("input[name='multiselect_IdEmpresa']:checked").each(function () {
                    idEmpresa.push($(this).val());
                });
                $("#IdEmpresaVal").val(idEmpresa);
                CargarComboSucursalEmpresa()
            },
            checkAll: function (event, ui) {
                debugger;
                var idEmpresa = new Array();
                $("input[name='multiselect_IdEmpresa']:checked").each(function () {
                    idEmpresa.push($(this).val());
                });
                $("#IdEmpresaVal").val(idEmpresa);
                CargarComboSucursalEmpresa()
            },
            uncheckAll: function (event, ui) {
                $("#IdEmpresaVal").val('');
                CargarComboSucursalEmpresa()
            }
        }
     ).multiselectfilter();
    $("#IdEmpresa").multiselect("uncheckAll");


    $("#IdSucursal").multiselect(
            {
                noneSelectedText: '-SELECCIONE-',
                show: ["bounce", 200],
                minWidth: 220
                //click: function (event, ui) {
                //    var idSucursal = new Array();
                //    $("input[name='multiselect_IdSucursal']:checked").each(function () {
                //        idSucursal.push($(this).val());
                //    });
                //    $("#IdsucursalVal").val(idSucursal);
                //},
                //checkAll: function () {
                //    var idSucursal = new Array();
                //    $("input[name='multiselect_IdSucursal']:checked").each(function () {
                //        idSucursal.push($(this).val());
                //    });
                //    $("#IdsucursalVal").val(idSucursal);
                //},
                //uncheckAll: function () {
                //    $("#IdsucursalVal").val('');
                //}
            }
         ).multiselectfilter();
    $("#IdSucursal").multiselect("uncheckAll");
});

////


//////////////REPORTE VE

function ValidaFecha_ReporteVE() {
    var valida = true;
    valida = ValidaFecha();
    if (valida) {
        var vFechaInicio = $("#ID_FechaInicio").val();
        var vFechaFin = $("#ID_FechaFin").val();

        var FecIniYear = vFechaInicio.substring(6, 10);
        var FecFinYear = vFechaFin.substring(6, 10);

        var FecIniMonth = vFechaInicio.substring(3, 5);
        var FecFinMonth = vFechaFin.substring(3, 5);

        if (FecIniYear == FecFinYear && FecIniMonth == FecFinMonth) {
            replaceErrorMessagge("ID_MsgFechaInicio", "");
            replaceErrorMessagge("ID_MsgFechaFin", "");
            valida = true;
        }
        else {
            replaceErrorMessagge("ID_MsgFechaFin", "El rango de fechas debe pertenecer al mismo mes y año");
            valida = false;
        }
    }
    return valida;
}

function VerReporteVE() {
    if ($("#IdMarca").val() != "") {
        if (ValidaFecha_ReporteVE()) {
            //$.ajax({
            //    url: $("#FrmReporteVE").attr('action'),
            //    type: "POST",
            //    data: $("#FrmReporteVE").serialize(),
            //    cache: false,
            //    success: function (data) {
            //        $('#ID_Partial_ReporteVE').html(data);
            //    }
            //});
            //window.open($("#FrmReporteVE").attr('action') + '?IdMarca=' + $("#IdMarca").val() + '&NomMarca=' + $("#IdMarca").children("option:selected").text() + '&FechaInicio=' + $("#ID_FechaInicio").val() + '&FechaFin=' + $('#ID_FechaFin').val() + '&uri=');
            window.open($("#Url_Exportar").val() + '?IdMarca=' + $("#IdMarca").val() + '&NomMarca=' + $("#IdMarca").children("option:selected").text() + '&FechaInicio=' + $("#ID_FechaInicio").val() + '&FechaFin=' + $('#ID_FechaFin').val() + '&uri=');
        }
    }
    else {
        replaceErrorMessagge("ID_MsgMarca", "Seleccione una Marca");
    }
}


///////////////////////////////////   REPORTE NUEVO VAP
function ExportarReporteVAP() {
    var vUrl = $("#Exportar_URL").val();
    if ($("#IdMarca").val() != "") {
        if (ValidaFecha_ReporteVE()) {
            Url = vUrl + '?IdMarca=' + $("#IdMarca").val() + '&NomMarca=' + $("#IdMarca").children("option:selected").text() + '&FechaInicio=' + $("#ID_FechaInicio").val() + '&FechaFin=' + $('#ID_FechaFin').val()
            window.open(Url, '_self');
        }
    }
    else {
        replaceErrorMessagge("ID_MsgMarca", "Seleccione una Marca");
    }
    
    //Url = vUrl + '?FechaInicio=' + vFechaInicio + '&FechaFin=' + vFechaFin + '&Sucursal=' + vIdSucursal + '&Ruc=' + vRuc + '&JefeRegional=' + vIdJefeRegional + '&Vendedor=' + vIdVendedor + '&TipoCliente=' + vIdTipoCliente + '&RazonSocial=' + vRazonSocial + '&Zona=' + vZona + '&IdGrupo=' + vIdGrupo;
    
    
}

//////////////////