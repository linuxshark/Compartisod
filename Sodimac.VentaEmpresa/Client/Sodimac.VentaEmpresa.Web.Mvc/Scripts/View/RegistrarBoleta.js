(function (Url) {
    $(document).ready(function(){
        $("#btnRegistrar").click(openPopUpRegistrar)
        InicioJPopUpConfirm("#dialogRegistrar", 400, false, "Mensaje de Confirmación", Registrar)
    })

    openPopUpRegistrar = function () {
        InicioJPopUpOpen('#dialogRegistrar');
    }

    Registrar = function (){
        $.ajax({
            url: Url.Nuevo,
            type: "POST",
            cache: false,
            success: function (msg) {
                InicioJPopUpAlert(msg, null);
            }
        });
    }
})(Url)