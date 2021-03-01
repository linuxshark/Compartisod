@ModelType Sodimac.VentaEmpresa.Web.Mvc.MantenimientoViewModel
@Imports Sodimac.VentaEmpresa.Web.Mvc.ParametrosView
@Code
    ViewData("Title") = "Gestionar Zona"
End Code
@Using (Html.BeginForm("", "", FormMethod.Post, New With {.id = "frmGestionarZona"}))
    @Html.AntiForgeryToken()
    @<div id="ID_CopiarCurso">
        <div class="wrapper">
            <div class="form">
                <fieldset>
                    <div class="widget fluid" id="divDefinicion">
                        <div class="whead">
                            <h6>Definición de la Zona</h6>
                            <div class="clear"> </div>
                        </div>
                        @Html.HiddenFor(Function(m) m.Zona.IdZona, New With {.id = "HD_IdZona"})
                        <div class="formRow fluid">
                            <div class="grid12">
                                <div class="grid3" style="padding-top:-30px"><label>Zona :<span class="req">*</span></label></div>
                                <div class="grid9">
                                    @*@Html.TextBoxFor(Function(m) m.Zona.NombreZona,
                                             New With {
                                                   .id = "NombreZona",
                                                   .onkeypress = "return val_AZ(event)",
                                                   .maxLength = "50",
                                                   .class = "textinput",
                                                   .style = "text-transform:uppercase;"
                                             })*@
                                    @Html.TextBoxFor(Function(m) m.Zona.NombreZona,
                                             New With {
                                                   .id = "NombreZona",
                                                   .maxLength = "50",
                                                   .class = "textinput",
                                                   .style = "text-transform:uppercase;"
                                             })
                                    @Html.ValidationMessageFor(Function(m) m.Zona.NombreZona, "", New With {.class = "reqizq"})
                                </div>
                            </div>
                        </div>
                        <div class="formRow fluid">
                            <div class="grid12">
                                <div class="grid1">
                                    <div class="checker" id="">
                                        @Html.CheckBoxFor(Function(m) m.Zona.IsNacional, New With {.id = "Id_IsNacional", .onclick = "IsNacional();"})
                                    </div>
                                </div>
                                <div class="grid6" style="margin-top:-5px"><label>¿Es Zona Nacional?</label></div>
                            </div>
                        </div>
                        <div class="formRow fluid">
                            <div class="grid12">
                                <div class="grid3" style="padding-top:-30px"><label>Sucursal:</label></div>
                                <div class="grid9">
                                    <div id="PVZona_Combo">
                                        @Html.Partial(ParametrosPartialView.PVZona_Combo, Model)
                                    </div>
                                        @*@Html.DropDownListFor(Function(m) m.Sucursal.CodigosSucursales,
                                New SelectList(Model.ListaSucursal, "IdSucursal", "DescripcionSucursal"),
                                New With {
                                    .style = "cursor:default;",
                                    .multiple = "multiple"
                                })
                                        @Html.ValidationMessageFor(Function(m) m.Sucursal.IdSucursal, "", New With {.class = "reqizq"})
                                    @Html.HiddenFor(Function(m) m.Sucursal.CodigoSucursal, New With {.id = "IDCodigosSucursales"})*@
                                    
                                    @*End If*@ 
                                </div>
                            </div>
                        </div>

                        <div class="formRow" style="margin-right:10px">
                            <button type="button" name="ActionCancelar" id="btnCancelar" style="cursor:pointer" class="buttonS bBlue formSubmit group_button" onclick="DialogCancelarRegistroZona();">Cancelar</button>
                            <button type="button" name="ActionAgregar" id="btnAgregarA" style="cursor:pointer" class="buttonS bBlue formSubmit group_button " onclick="GuardarZona();">Guardar</button>
                            <br class="clear" />
                            <div class="clear"></div>
                        </div>
                    </div>
                </fieldset>
            </div>
        </div>
    </div>
End Using

<script type="text/javascript" language="javascript">
    var navegador = navigator.appName

    $(function () {
        var data = $("#IDCodigosSucursales").val();
        var dataarray = data.split(",");
        $("#Sucursal_CodigosSucursales").val(dataarray);
        $("#Sucursal_CodigosSucursales").multiselect("refresh");

        $("#Sucursal_CodigosSucursales").multiselect(
            {
                selectedList: 10,
                noneSelectedText: '-SELECCIONE-',
                show: ["bounce", 200],
                minWidth: 280
            }
         ).multiselectfilter();
        // $("#ID_Sucursales").multiselect("select", "1,2,3")
        $(".ui-multiselect").attr("style", "width: 280px")

        if (navegador == "Microsoft Internet Explorer") {
            $(".ui-multiselect").attr("style", "width: 250px")
        }
        $("#ui-multiselect-ID_Sucursales-option-2").attr("selected", "selected")


    });
</script>
