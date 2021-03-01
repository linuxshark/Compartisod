(function (Url) {
    $(document).ready(function(){
        $("#consultar").click(Buscar)
        //Buscar()
    })

    Buscar = function () {
        $.ajax({
            url: Url.UrlConsultarClienteVendedorAsociado,
            data: $("#frmClienteVendedorAsociado").serialize(),
            type: 'GET',
            cache: false,
            success: function (data) {
                $("#contenedor-grid").html(data);
            },
            complete: function () {
                PaintFooterGrid()
            }
        })
    }

    PaintFooterGrid = function () {
        $("#contenedor-grid-ClienteVendedorAsociado tfoot tr:last td").prepend("<a id='tfootPage'  class='total_registros'></a>");
        $("#tfootPage").html($('#hdfTotalRegistros').val());
    }
})(Url)