@Modeltype Sodimac.VentaEmpresa.Web.Mvc.Models.ViewModel.ProveedorViewModel
@Imports Sodimac.VentaEmpresa.Web.Mvc.ParametrosView
@Using (Html.BeginForm("ConsultaSkuProductos", "Mantenimiento", FormMethod.Post, New With {.id = "FrmProdSkuProv"}))
    @<div class="wrapper">
        <div class="form">
            <fieldset>
                <div class="widget fluid" id="divDefinicion">
                    <div class="whead">
                        <h6>Buscar Productos</h6>
                        <div class="clear"> </div>
                    </div>
                    <div class="formRow fluid">
                        <div class="grid4">
                            @Html.LabelFor(Function(m) m.Producto.Sku, New With {.class = "grid3"})
                            <div class="grid6">
                                @Html.TextBoxFor(Function(m) m.Producto.Sku,
                                                  New With
                                                  {
                                                       .style = "text-transform:uppercase",
                                                       .id = "IdProveedor",
                                                       .class = "textinput"
                                                  })
                            </div>
                        </div>
                        @Html.HiddenFor(Function(x) x.Proveedor.IdProveedor)
                        @Html.HiddenFor(Function(x) x.Producto.Item)
                        <div class="grid6">
                            @Html.LabelFor(Function(m) m.Producto.Descripcion, New With {.class = "grid3"})
                            <div class="grid6">
                                @Html.TextBoxFor(Function(m) m.Producto.Descripcion,
                                                New With
                                                {
                                                    .style = "text-transform:uppercase",
                                                    .id = "RucIndex",
                                                    .maxLength = "11",
                                                    .class = "textinput"
                                                })
                            </div>
                        </div>
                        <div class="grid2">
                            <button type="button" name="ActionBuscar" id="btnBuscarProveedorSku" style="cursor:pointer" class="buttonS bBlue formSubmit group_button">Buscar</button>
                        </div>
                    </div>
                    <div class="whead">
                        <h6>Resultados de la Busqueda</h6>
                    </div>
                    <div id="contenedor-grid-sku-prov">
                        @Html.Partial("_GridProductosBusqueda", Model)
                    </div>
                </div>
            </fieldset>
            <div class="formRow fluid">
                <br />
            </div>
            <div id="contenedor-grid-sku-prov-temp">
                <table id="GridSkuProvTemp" class="tDefault">
                    <thead>
                        <tr class="fix_head">
                            <th scope="col">
                                Sku
                            </th>
                            <th scope="col">
                                Descripción
                            </th>
                            <th scope="col">
                                Acción
                            </th>
                        </tr>
                    </thead>
                    <tbody></tbody>
                </table>
            </div>
            <div class="formRow">
                <button type="button" name="Cerrar" id="btnCerrarModalSkuProv" style="cursor:pointer" class="buttonS bBlue formSubmit group_button">Cerrar</button>
                <button type="button" name="btnAgregarTempaDB" id="btnAgregarTemp" style="cursor:pointer" class="buttonS bBlue formSubmit group_button">Guardar</button>
                <br class="clear" />
                <div class="clear"></div>
            </div>
        </div>
    </div>
End Using
