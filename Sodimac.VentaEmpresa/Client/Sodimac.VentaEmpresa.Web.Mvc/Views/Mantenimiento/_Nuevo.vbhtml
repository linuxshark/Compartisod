@ModelType Sodimac.VentaEmpresa.Web.Mvc.Models.ViewModel.ProveedorViewModel
@Imports Sodimac.VentaEmpresa.Web.Mvc.ParametrosView
@Code
    ViewData("Title") = "Registrar Proveedor"
End Code

@Using (Html.BeginForm("RegistrarProveedor", "Mantenimiento", FormMethod.Post, New With {.id = "FrmNuevoProveedor"}))
    @<div class="wrapper">
        <div class="form">
            <fieldset>
                <div class="formRow fluid">
                    <div class="grid12">
                        @Html.LabelFor(Function(m) m.Proveedor.IdEmpresa, New With {.class = "grid4"})
                        <div class="grid8">
                            @Html.DropDownListFor(Function(m) m.Proveedor.IdEmpresa,
                                                     New SelectList(Model.ListaEmpresa, "IdEmpresa", "NomEmpresa"),
                                                     "- TODOS -", New With {
                                                         .id = "IdEmpresaNuevo"
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
                                                     .id = "RucNuevo",
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
                                                 .id = "RazonSocialNuevo",
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
                                                .id = "NumeroNuevo",
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
                                                .id = "NumeroNuevo",
                                                .maxLength = "200",
                                                .class = "textinput"
                                                })
                            @Html.ValidationMessageFor(Function(m) m.Proveedor.Direccion, String.Empty, New With {.class = "reqizq"})
                        </div>
                    </div>
                </div>
                <div class="formRow" style="margin-right:10px">
                    <button type="button" name="ActionNuevo" id="btnCerrarModalNuevo" style="cursor:pointer" class="buttonS bBlue formSubmit group_button">Cerrar</button>
                    <button type="button" name="ActionAgregar" id="btnRegistrarProveedor" style="cursor:pointer" class="buttonS bBlue formSubmit group_button ">Registrar</button>
                    <br class="clear" />
                    <div class="clear"></div>
                </div>

            </fieldset>
        </div>
    </div>
End Using



