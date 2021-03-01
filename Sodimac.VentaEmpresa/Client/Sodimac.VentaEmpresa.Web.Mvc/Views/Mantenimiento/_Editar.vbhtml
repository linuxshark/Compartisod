@ModelType Sodimac.VentaEmpresa.Web.Mvc.Models.ViewModel.ProveedorViewModel
@Imports Sodimac.VentaEmpresa.Web.Mvc.ParametrosView
@Code
    ViewData("Title") = "Editar Proovedor"
End Code

@Using (Html.BeginForm("ActualizarProveedor", "Mantenimiento", FormMethod.Post, New With {.id = "FrmEditarProveedor"}))
    @<div class="wrapper">
        @Html.HiddenFor(Function(m) m.Proveedor.IdProveedor, New With {.id = "IdProveedorEditar"})
        <div class="form">
            <fieldset>
                <div class="formRow fluid">
                    <div class="grid12">
                        @Html.LabelFor(Function(m) m.Proveedor.IdEmpresa, New With {.class = "grid4"})
                        <div class="grid8">
                            @Html.DropDownListFor(Function(m) m.Proveedor.IdEmpresa,
        New SelectList(Model.ListaEmpresa, "IdEmpresa", "NomEmpresa"),
        "- TODOS -", New With {
            .id = "IdEmpresaEditar"
        })
                            @Html.ValidationMessageFor(Function(m) m.Proveedor.IdEmpresa, String.Empty, New With {.class = "reqizq"})
                        </div>
                    </div>
                </div>
                <div class="formRow fluid">
                    <div class="grid12">
                        @Html.LabelFor(Function(m) m.Proveedor.Ruc, New With {.class = "grid4"})
                        <div class="grid8">
                            @Html.TextBoxFor(Function(m) m.Proveedor.Ruc,
 New With {
     .style = "text-transform:uppercase",
     .id = "RucEditar",
     .maxLength = "11",
     .class = "textinput"
 })
                            @Html.ValidationMessageFor(Function(m) m.Proveedor.Ruc, String.Empty, New With {.class = "reqizq"})
                        </div>
                    </div>
                </div>
                <div class="formRow fluid">
                    <div class="grid12">
                        @Html.LabelFor(Function(m) m.Proveedor.RazonSocial, New With {.class = "grid4"})
                        <div class="grid8">
                            @Html.TextBoxFor(Function(m) m.Proveedor.RazonSocial,
 New With
 {
 .style = "text-transform:uppercase",
 .id = "RazonSocialEditar",
 .maxLength = "200",
 .class = "textinput"
 })
                            @Html.ValidationMessageFor(Function(m) m.Proveedor.RazonSocial, String.Empty, New With {.class = "reqizq"})
                        </div>
                    </div>
                </div>
                <div class="formRow fluid">
                    <div class="grid12">
                        @Html.LabelFor(Function(m) m.Proveedor.Numero, New With {.class = "grid4"})
                        <div class="grid8">
                            @Html.TextBoxFor(Function(m) m.Proveedor.Numero,
 New With
 {
 .style = "text-transform:uppercase",
 .id = "NumeroEditar",
 .maxLength = "200",
 .class = "textinput"
 })
                            @Html.ValidationMessageFor(Function(m) m.Proveedor.Numero, String.Empty, New With {.class = "reqizq"})
                        </div>
                    </div>
                </div>
                <div class="formRow fluid">
                    <div class="grid12">
                        @Html.LabelFor(Function(m) m.Proveedor.Direccion, New With {.class = "grid4"})
                        <div class="grid8">
                            @Html.TextBoxFor(Function(m) m.Proveedor.Direccion,
 New With
 {
 .style = "text-transform:uppercase",
 .id = "NumeroEditar",
 .maxLength = "200",
 .class = "textinput"
 })
                            @Html.ValidationMessageFor(Function(m) m.Proveedor.Direccion, String.Empty, New With {.class = "reqizq"})
                        </div>
                    </div>
                </div>
                <div class="formRow" style="margin-right:10px">
                    <button type="button" name="ActionNuevo" id="btnCerrarModalEditar" style="cursor:pointer" class="buttonS bBlue formSubmit group_button">Cerrar</button>
                    <button type="button" name="ActionAgregar" id="btnGuardarProveedor" style="cursor:pointer" class="buttonS bBlue formSubmit group_button ">Guardar</button>
                    <br class="clear" />
                    <div class="clear"></div>
                </div>

            </fieldset>
        </div>
    </div>
End Using



