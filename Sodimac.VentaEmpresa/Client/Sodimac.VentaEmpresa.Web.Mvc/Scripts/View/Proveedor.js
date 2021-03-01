(function () {
    $(document).ready(function () {
        InicioJPopUp("#Gestionar", 500, 'auto', false, "Gestionar Proveedor");
        InicioJPopUp("#GestionarProdSku",800, 'auto', false, "Asignar Proveedor Sku");
        InicioJPopUpV2("#GestionarSku", 800, 'auto', false, "Gestionar Sku", { my: 'top', at: 'top+150' });
        InicioJPopUpConfirm("#dialogRegistrar", 400, false, "Mensaje de Confirmación", Registrar)
        InicioJPopUpConfirm("#dialogEditar", 400, false, "Mensaje de Confirmación", Editar)

        $("#btnBuscar").click(Buscar);
        $("#btnNuevo").click(DialogNuevo);
        Buscar();
    })
})()

function PaintFooterGrid() {
    $(".edit_table").click(DialogEditar);
    $(".delete-register").click(DialogEliminar);
    $(".bGridProvAct").click(DialogNProvSku)
    $("#contenedor-grid-GridProovedor tfoot tr:last td").prepend("<a id='tfootPage'  class='total_registros'></a>");
    $("#tfootPage").html($('#FooterDesc').val());
}

function Buscar() {
    $.ajax({
        url: $("#FrmProveedor").attr('action'),
        data: $("#FrmProveedor").serialize(),
        type: 'GET',
        cache: false,
        success: function (data) {
            $("#contenedor-grid").html(data);
            if ($("#FooterDesc").val() == "") {
                InicioJPopUpAlert("No se encontraron Registros", null);
            }
        },
        complete: function (req, status, error) {
            PaintFooterGrid();
        }
    });
}



/************* NUEVO REGISTRO *****************/
function DialogNuevo() {
    $.ajax({
        url: $('#UrlNuevo').val(),
        data: {},
        type: "GET",
        cache: false,
        success: function (data) {
            $("#Gestionar").html(data);
            InicioJPopUpOpen('#Gestionar');
            $('#IdEmpresaNuevo').uniform()
            addValidattionForm('#FrmNuevoProveedor');
            $("#btnRegistrarProveedor").click(validFormNuevo);
            $("#btnCerrarModalNuevo").click(function () { $("#Gestionar").dialog("close") });

        }
    });
}

function validFormNuevo() {
    if (validateform('#FrmNuevoProveedor'))
        InicioJPopUpOpen('#dialogRegistrar');
}

function Registrar() {
    $.ajax({
        url: $('#FrmNuevoProveedor').attr('action'),
        data: $('#FrmNuevoProveedor').serialize(),
        type: "POST",
        cache: false,
        success: function (msg) {
            $('#Gestionar').dialog("close");
            InicioJPopUpAlert(msg, null);
            Buscar();
        }
    });
}




/*************** EDICIÓN DE REGISTRO ****************/
function DialogEditar() {
    $.ajax({
        url: $('#UrlEditar').val(),
        data: { id: $(this).attr("data") },
        type: "GET",
        cache: false,
        success: function (data) {
            $("#Gestionar").html(data);
            InicioJPopUpOpen('#Gestionar');
            $('#IdEmpresaEditar').uniform()
            addValidattionForm('#FrmEditarProveedor');
            $("#btnGuardarProveedor").click(validFormEditar);
            $("#btnCerrarModalEditar").click(function () { $("#Gestionar").dialog("close") });
        }
    });
}

function validFormEditar() {
    if (validateform('#FrmEditarProveedor'))
        InicioJPopUpOpen('#dialogEditar');
}

function Editar() {
    $.ajax({
        url: $('#FrmEditarProveedor').attr('action'),
        data: $('#FrmEditarProveedor').serialize(),
        type: "POST",
        cache: false,
        success: function (msg) {
            $('#Gestionar').dialog("close");
            InicioJPopUpAlert(msg, null);
            Buscar();
        }
    });
}



/*************** ELIMINAR REGISTRO ****************/

function Eliminar() {
    $.ajax({
        url: $('#FrmEliminarProveedor').attr('action'),
        data: $('#FrmEliminarProveedor').serialize(),
        type: "POST",
        cache: false,
        success: function (msg) {
            $('#Gestionar').dialog("close");
            InicioJPopUpAlert(msg, null);
            Buscar();
        }
    });
}


function DialogEliminar() {
    $.ajax({
        url: $('#UrlEliminar').val(),
        data: { id: $(this).attr("data") },
        type: "GET",
        cache: false,
        success: function (data) {
            $("#Gestionar").html(data);
            InicioJPopUpOpen('#Gestionar');
            $("#btnEliminarProveedor").click(Eliminar);
        }
    });
}


/******************POP UP AGREGAR SKU***************************/

function BuscarSku() {
    $.ajax({
        url: $("#FrmProveedorSku").attr('action'),
        data: $("#FrmProveedorSku").serialize(),
        type: 'GET',
        cache: false,
        success: function (data) {
            $("#contenedor-grid-Sku").html(data);
            if ($("#FooterDescSku").val() == "") {
                InicioJPopUpAlert("No se encontraron Registros", null);
            }
        },
        complete: function (req, status, error) {
            PaintFooterGridSku();
        }
    });
}

function DialogEliminarSku() {
    $.ajax({
        url: $('#UrlEliminarSku').val(),
        data: {
            Sku: $(this).attr("data"),
            Estado: $(this).attr("estado"),
            IdProv: $("#Proveedor_IdProveedor").val()
        },
        type: "GET",
        cache: false,
        success: function (data) {
            InicioJPopUpAlert(data, null);
            BuscarSku()
        }
    });
}

function PaintFooterGridSku() {
    $(".delete-registerSku").click(DialogEliminarSku);
    $("#contenedor-grid-GridSku tfoot tr:last td").prepend("<a id='tfootPageSku'  class='total_registros'></a>");
    $("#tfootPageSku").html($('#FooterDescSku').val());
}


/***************AGREGAR NUEVO PROVEEDOR SKU*******************/

function selectProducts() {
    if ($(this).attr("checked")) {
        var r = $(this).parent().parent()
        $("#GridSkuProvTemp tbody").append("<tr><td>" + r.find("td").eq(1).html() + "</td>" +
                                           "<td>" + r.find("td").eq(2).html() + "</td>" +
                                           "<td><a class='desactivar_table deleteRowTemp' title='Eliminar' data='{0}'></a></td></tr>");
        var items;
        items = $("#Producto_Item").val().split(',') == "" ? new Array() : $("#Producto_Item").val().split(',');
        items.push(r.find("td").eq(1).html());
        $("#Producto_Item").val(items)

        $("#GridSkuProvTemp tbody .deleteRowTemp").click(function () {
            var uncheckRow;
            uncheckRow = $(this).parent().parent();
            uncheckRow.remove();
            var items;
            items = $("#Producto_Item").val().split(',') == "" ? new Array() : $("#Producto_Item").val().split(',');  
            var sku = uncheckRow.find("td").eq(0).html()
            var index = items.indexOf(sku)
            items.splice(index, 1);
            $("#Producto_Item").val(items)
            $("#GridSkuProv tbody tr").each(function (i) {
                if ($(this).find("td").eq(1).html() == sku) {
                    $(this).find("input").attr("checked", false);
                }
            });
        });
    }
    else {
        var r = $(this).parent().parent()
        var sku = r.find("td").eq(1).html();
        var items;
        items = $("#Producto_Item").val().split(',') == "" ? new Array() : $("#Producto_Item").val().split(',');
        var index = items.indexOf(sku)
        items.splice(index, 1);
        $("#Producto_Item").val(items)
        $("#GridSkuProvTemp tbody tr").each(function (i) {
            if ($(this).find("td").eq(0).html() == sku) {
                $(this).remove()
            }
        })
    }
}

function PaintFooterGridSkuProv() {
    $(".selectCheck").change(selectProducts)
    $("#contenedor-grid-GridSkuProv tfoot tr:last td").prepend("<a id='tfootPageSkuProv'  class='total_registros'></a>");
    $("#tfootPageSkuProv").html($('#FooterDescSkuProv').val());
}

function BuscarProds() {
    $.ajax({
        url: $("#FrmProdSkuProv").attr('action'),
        data: $("#FrmProdSkuProv").serialize(),
        type: 'GET',
        cache: false,
        success: function (data) {
            $("#contenedor-grid-sku-prov").html(data);
        },
        complete: function (req, status, error) {
            PaintFooterGridSkuProv();
        }
    });
}

function AgregarProdProv() {
    $.ajax({
        url: $("#UrlConfirmarSkuProv").val(),
        data: $("#FrmProdSkuProv").serialize(),
        type: 'POST',
        cache: false,
        success: function (data) {
            InicioJPopUpAlert(data, null);
            BuscarSku();
            $("#GestionarProdSku").dialog("close");            
        }
    })
}

function DialogNAgregarSkuProveedor() {
    $.ajax({
        url: $("#UrlAgregarSkuProv").val(),
        data: $("#FrmProveedorSku").serialize(),
        type: "GET",
        cache: false,
        success: function (data) {
            $("#GestionarProdSku").html(data);
            InicioJPopUpOpen("#GestionarProdSku");
            $("#btnBuscarProveedorSku").click(BuscarProds);
            $("#btnCerrarModalSkuProv").click(function () { $("#GestionarProdSku").dialog("close") });
            $("#btnAgregarTemp").click(AgregarProdProv);
        }
    });
}

function DialogNProvSku() {
    $.ajax({
        url: $('#UrlAsociarSku').val(),
        data: { id: $(this).attr("data") },
        type: "GET",
        cache: false,
        success: function (data) {
            $("#GestionarSku").html(data);
            InicioJPopUpOpen('#GestionarSku');
            BuscarSku()
            //$('#IdEmpresaEditar').uniform()
            //addValidattionForm('#FrmEditarProveedor');
            $("#btnBuscarProveedorSku").click(BuscarSku);
            $("#btnCerrarModalSku").click(function () { $("#GestionarSku").dialog("close") });
            $("#btnAgregarSku").click(DialogNAgregarSkuProveedor);
        }
    });
}


