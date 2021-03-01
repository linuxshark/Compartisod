(function (Url) {

    $(document).ready(function () {
        //#region MultiSelect
        $("#IdEmpresa").multiselect({
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
        }).multiselectfilter();
        $("#IdEmpresa").multiselect("uncheckAll");


        $("#IdSucursal").multiselect(
                {
                    noneSelectedText: '-SELECCIONE-',
                    show: ["bounce", 200],
                    minWidth: 220
                }
             ).multiselectfilter();
        $("#IdSucursal").multiselect("uncheckAll");
        //#endregion MultiSelect

        $("#ID_FechaInicio").change(ValidaFecha);
        $("#ID_FechaFin").change(ValidaFecha);
        $("#btnExportar").click(reporteVentaEmpresatienda);
    })

    replaceErrorMessagge = function (IdDiv, Message) {
        $("#" + IdDiv).replaceWith('<div style="color: #EC6464; font-size:9px;" id="' + IdDiv + '">' + Message + '</div>');
    }

    CargarComboSucursalEmpresa = function () {
        replaceErrorMessagge("ID_MsgEmpresa", "");
        //var vUrl = $("#ID_URL_SUC").val();
        var Ids = ($("#IdEmpresaVal").val() == "" ? "0" : $("#IdEmpresaVal").val());
        $.ajax({
            url: Url.ListaSucursal,
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
                        replaceErrorMessagge("ID_MsgSucursal", "");
                    },
                    checkAll: function () {
                        var idSucursal = new Array();
                        $("input[name='multiselect_IdSucursalCliente']:checked").each(function () {
                            idSucursal.push($(this).val());
                        });
                        $("#Idsucursal2Cliente").val(idSucursal);
                        replaceErrorMessagge("ID_MsgSucursal", "");
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

    reporteVentaEmpresatienda = function () {
        if (ValidaFecha()) {
            if ($("#IdEmpresaVal").val() == "") {
                replaceErrorMessagge("ID_MsgEmpresa", "Seleccione una Empresa");
            }
            else if ($("#Idsucursal2Cliente").val() == "") {
                replaceErrorMessagge("ID_MsgSucursal", "Seleccione una Sucursal");
            }
            else {
                var vFechaInicio = $("#ID_FechaInicio").val();
                var vFechaFin = $("#ID_FechaFin").val();
                var vIdEmpresa = $("#IdEmpresaVal").val();
                var vIdSucursal = $("#Idsucursal2Cliente").val();

                $.ajax({
                    url: Url.GenerarExcel,
                    type: "GET",
                    data: {
                        FechaInicio: vFechaInicio,
                        FechaFin: vFechaFin,
                        Empresa: vIdEmpresa,
                        Sucursal: vIdSucursal
                    },
                    cache: false,
                    success: function (data) {
                        
                        //alert('data:' + data);
                        var arr = data.split(";");
                        var Path = arr[0].toString().replace("~", "");
                        var FileName = arr[1].toString().replace("~", "");
                        DownloadFile(Path, FileName);
                    },
                    error: function (data) {
                        alert("Error: " + data);
                    }
                });
            }
        }
    }

    var DownloadFile = function (filePath, fileName) {
        if (fileName.length > 0) {
            window.open(filePath + fileName, '_blank');
        }
        else {
            alert('No se realizó la carga de ningún archivo.');
        }
    }

    ValidaFecha = function () {
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

})(Url)