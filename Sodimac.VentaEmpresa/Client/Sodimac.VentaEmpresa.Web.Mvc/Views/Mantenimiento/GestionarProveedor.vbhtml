@ModelType Sodimac.VentaEmpresa.Web.Mvc.Models.ViewModel.ProveedorViewModel
@Imports Sodimac.VentaEmpresa.Web.Mvc.ParametrosView
@Code
    ViewData("Title") = "Buscar Proveedor"
End Code
<div class="breadLine">
    <div class="bc">
        <ul id="breadcrumbs" class="breadcrumbs">
            <li><a href="#">Inicio</a></li>
            <li><a href="#">Mantenedor</a></li>
            <li class="current"><a href="#" title="">Buscar Proveedor</a></li>
        </ul>
    </div>
</div>
<div class="contentTop">
    <span class="pageTitle"><span id="IdAgregarTitle" class="icon-screen"></span>Buscar Proveedor</span>
    <div class="clear"></div>
</div>
@Html.Hidden("UrlEliminar", Url.Action("EliminarProveedor", "Mantenimiento"))
@Html.Hidden("UrlNuevo", Url.Action("NuevoProveedor", "Mantenimiento"))
@Html.Hidden("UrlEditar", Url.Action("EditarProveedor", "Mantenimiento"))
@Html.Hidden("UrlAsociarSku", Url.Action("AsociarSku", "Mantenimiento"))
@Html.Hidden("UrlAgregarSkuProv", Url.Action("AgregarSkuProveedor", "Mantenimiento"))
@Html.Hidden("UrlEliminarSku", Url.Action("EliminarSkuProv", "Mantenimiento"))
@Html.Hidden("UrlConfirmarSkuProv", Url.Action("ConfirmarSkuProv","Mantenimiento"))

<div class="wrapper">
    <div class="form" id="frmConsultarProveedor">
        @Using (Html.BeginForm("ConsultaProveedor", "Mantenimiento", FormMethod.Post, New With {.id = "FrmProveedor"}))
            @<fieldset>
                <div class="widget fluid" id="divDefinicion">
                    <div class="whead">
                        <h6>Criterios de Búsqueda</h6>
                        <div class="clear"> </div>
                    </div>
                    <div class="formRow fluid">
                        <div class="grid4">
                            @Html.LabelFor(Function(m) m.Proveedor.IdEmpresa, New With {.class = "grid3"})
                            <div class="grid9">
                                @Html.DropDownListFor(Function(m) m.Proveedor.IdEmpresa,
                                         New SelectList(Model.ListaEmpresa, "IdEmpresa", "NomEmpresa"),
                                         "- TODOS -", New With {
                                         .id = "IdEmpresaIndex"
                                         })
                            </div>
                        </div>
                        <div class="grid4">
                            @Html.LabelFor(Function(m) m.Proveedor.Ruc, New With {.class = "grid3"})
                            <div class="grid9">
                                @Html.TextBoxFor(Function(m) m.Proveedor.Ruc,
                                         New With
                                         {
                                         .style = "text-transform:uppercase",
                                         .id = "RucIndex",
                                         .maxLength = "11",
                                         .class = "textinput"
                                         })
                            </div>
                        </div>
                        <div class="grid4">
                            @Html.LabelFor(Function(m) m.Proveedor.RazonSocial, New With {.class = "grid3"})
                            <div class="grid9">
                                @Html.TextBoxFor(Function(m) m.Proveedor.RazonSocial,
                                        New With
                                        {
                                        .style = "text-transform:uppercase",
                                        .id = "RazonSocialIndex",
                                        .maxLength = "200",
                                        .class = "textinput"
                                        })
                            </div>
                        </div>
                      
                    </div>
                    <div class="formRow fluid">
                        <div class="grid3">
                            @Html.LabelFor(Function(m) m.Proveedor.EstadoP, New With {.class = "grid4"})
                            <div class="grid2">
                                @*@Html.CheckBoxFor(Function(m) m.Proveedor.Estado,
                                        New With
                                        {
                                        .style = "text-transform:uppercase",
                                        .id = "EstadoIndex",
                                        .maxLength = "200",
                                        .class = "textinput"
                                        })*@

                                @Html.DropDownListFor(Function(m) m.Proveedor.EstadoP,
                                         New SelectList(Model.ListaEstado, "IdEstado", "Descripcion"),
                                         "- TODOS -", New With {
                                         .id = "IdEstadoIndex"
                                         })
                            </div>
                        </div>
                    </div>
                        <div class="formRow">
                            <button type="button" name="ActionNuevo" id="btnNuevo" style="cursor:pointer" class="buttonS bBlue formSubmit group_button">Nuevo</button>
                            <button type="button" name="ActionBuscar" id="btnBuscar" style="cursor:pointer" class="buttonS bBlue formSubmit group_button">Buscar</button>
                            <br class="clear" />
                            <div class="clear"></div>
                        </div>
                    </div>
            </fieldset>
        End Using
    </div>
</div>
<div class="wrapper">
    <div class="form">
        <fieldset>
            <div class="widget fluid" id="divDefinicion4">
                <div class="whead">
                    <h6>Resultados de Búsqueda</h6>
                    <div class="clear">
                    </div>
                </div>
                <div id="contenedor-grid">
                    @Html.Partial("_Grid", Model)
                </div>
            </div>
        </fieldset>
    </div>
</div>
<script type="text/javascript" src="@Url.Content("~/Scripts/View/Proveedor.js")"></script>
<div id="Gestionar" style="display: none" class="j_modal" title="Gestionar Proveedor"></div>
<div id="GestionarSku" style="display: none" class="j_modal" title="Gestionar Sku"></div>
<div id="GestionarProdSku" style="display: none" class="j_modal" title="Agregar Sku por Proveedor"></div>
<div id="dialogRegistrar" title="Mensaje de Confirmación">
    <p>¿Desea registrar?</p>
</div>
<div id="dialogEditar" title="Mensaje de Confirmación">
    <p>¿Desea guardar?</p>
</div>
@*<div id="dialogEliminar" title="Mensaje de Confirmación">
    <p>¿Desea eliminar el registro?</p>
</div>*@