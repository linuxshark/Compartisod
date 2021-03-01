@ModelType Sodimac.VentaEmpresa.Web.Mvc.Models.ViewModel.ProveedorViewModel
@Imports Sodimac.VentaEmpresa.Web.Mvc.ParametrosView
@Code
    ViewData("Title") = "Eliminar Proveedor"
End Code

@Using (Html.BeginForm("EliminarProveedor", "Mantenimiento", FormMethod.Post, New With {.id = "FrmEliminarProveedor"}))
    @<div class="wrapper">
        @Html.HiddenFor(Function(m) m.Proveedor.IdProveedor, New With {.id = "IdProveedorEditar"})
        @Html.HiddenFor(Function(m) m.Proveedor.Estado, New With {.id = "IdProveedorEstado"})
        <div class="form">
            <fieldset>
                <div class="formRow fluid">
                    <div class="grid12">
                        <div class="grid7">Desea @Viewbag.Estado el Proveedor de Id:</div>
                        <div class="grid5">
                            @Html.DisplayFor(Function(m) m.Proveedor.IdProveedor)
                        </div>
                    </div>
                </div>
                <div class="formRow fluid">
                    <div class="grid12">
                        <div class="grid7"> Razón Social: </div>
                        <div class="grid5">
                            @Html.DisplayFor(Function(m) m.Proveedor.RazonSocial)
                        </div>
                    </div>
                </div>
                <div class="formRow fluid">
                    <div class="grid12">
                        <div class="grid7"> Ruc: </div>
                        <div class="grid5">
                            @Html.DisplayFor(Function(m) m.Proveedor.Ruc)
                        </div>
                    </div>
                </div>                
                <div class="formRow" style="margin-right:10px">
                    <button type="button" name="ActionAgregar" id="btnEliminarProveedor" style="cursor:pointer" class="buttonS bBlue formSubmit group_button ">@Viewbag.Boton</button>
                    <br class="clear" />
                    <div class="clear"></div>
                </div>
            </fieldset>
        </div>
    </div>
End Using




