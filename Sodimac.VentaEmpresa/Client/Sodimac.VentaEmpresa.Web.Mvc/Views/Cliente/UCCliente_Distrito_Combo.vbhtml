@ModelType Sodimac.VentaEmpresa.Web.Mvc.ClientesViewModel

@Html.DropDownListFor(Function(m) m.ClienteVenta.IdDistrito,
New SelectList(Model.ListaEmpleadoDistrito, "IdDistrito", "Descripcion"),
"-SELECCIONE-",
New With {
    .id = "ID_Distrito",
    .class = "selector"
})
<div class="clear"></div>
@Html.ValidationMessageFor(Function(m) m.ClienteVenta.IdDistrito, "", New With {.class = "reqizq"})

