@ModelType Sodimac.VentaEmpresa.Web.Mvc.Models.ViewModel.ProveedorViewModel
@Imports Sodimac.VentaEmpresa.Web.Mvc.ParametrosView


@Using (Html.BeginForm("ConsultaSku", "Mantenimiento", FormMethod.Post, New With {.id = "FrmProveedorSku"}))
    @<div class="wrapper">
        <div class="form">
            <fieldset>
                <div class="widget fluid" id="divDefinicion">
                    <div class="whead">
                        <h6>Datos Proveedor</h6>
                        <div class="clear"> </div>
                    </div>
                    <div class="formRow fluid">
                        <div class="grid12">
                            @Html.LabelFor(Function(m) m.Proveedor.IdProveedor, New With {.class = "grid3"})
                            <div class="grid6">
                                @Html.TextBoxFor(Function(m) m.Proveedor.IdProveedor,
                                                  New With
                                                  {
                                                       .style = "text-transform:uppercase",
                                                        .id = "IdProveedor",
                                                        .maxLength = "11",
                                                        .class = "textinput",
                                                        .disabled = "disabled"
                                                  })
                                @Html.HiddenFor(Function(x) x.Proveedor.IdProveedor)
                            </div>
                        </div>
                        <div class="grid12">
                            @Html.LabelFor(Function(m) m.Proveedor.RazonSocial, New With {.class = "grid3"})
                            <div class="grid6">
                                @Html.TextBoxFor(Function(m) m.Proveedor.RazonSocial,
                                                New With
                                                {
                                                .style = "text-transform:uppercase",
                                                .id = "RucIndex",
                                                .maxLength = "11",
                                                .class = "textinput",
                                                .disabled = "disabled"
                                                })
                            </div>
                        </div>                        
                        <div class="grid12">
                            @Html.LabelFor(Function(m) m.Proveedor.Sku, New With {.class = "grid3"})
                            <div class="grid6">
                                @Html.TextBoxFor(Function(m) m.Proveedor.Sku,
                                             New With
                                             {
                                             .style = "text-transform:uppercase",
                                             .id = "RucIndex",
                                             .maxLength = "11",
                                             .class = "textinput"
                                             })
                            </div>
                        </div>

                    </div>
                    <div class="formRow">
                        <button type="button" name="ActionBuscar" id="btnBuscarProveedorSku" style="cursor:pointer" class="buttonS bBlue formSubmit group_button">Buscar</button>
                        <br class="clear" />
                        <div class="clear"></div>
                    </div>
                </div>
            </fieldset>   
        </div>
    </div>
End Using
<div class="wrapper">
    <div class="form">
        <fieldset>
            <div class="widget fluid" id="divDefinicion4">
                <div class="whead">
                    <h6>Resultados de Búsqueda</h6>
                    <div class="clear">
                    </div>
                </div>
                <div id="contenedor-grid-Sku">
                    @Html.Partial("_GridSku", Model)
                </div>
            </div>
        </fieldset>
        <div class="formRow">
            <button type="button" name="ActionNuevo" id="btnCerrarModalSku" style="cursor:pointer" class="buttonS bBlue formSubmit group_button">Cerrar</button>
            <button type="button" name="ActionBuscar" id="btnAgregarSku" style="cursor:pointer" class="buttonS bBlue formSubmit group_button">Agregar Sku</button>
            <br class="clear" />
            <div class="clear"></div>
        </div>
    </div>
</div>
