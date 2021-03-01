@ModelType Sodimac.VentaEmpresa.Web.Mvc.ClientesViewModel
@Imports Sodimac.VentaEmpresa.Web.Mvc.ParametrosView
@If Not(Model.VentaCartera Is Nothing) AndAlso Model.VentaCartera.IdCarteraEmpleadoTipo = 1 Then
    @<div class="formRow fluid">
        <div id="ID_DivSucursal" title="ComboSucursal">
            @Html.Partial(ParametrosPartialView.ListarSucursales_ComboBox, Model)
        </div>
    </div>
    @<div class="formRow fluid">
        <div class="grid12">
            <div class="grid3" style="padding-top: -30px">
                <label>
                    RRVV :<span class="req">*</span></label>
            </div>
            <div class="grid9">
                <div id="divListaComboEmpleados">
                    @Html.Partial(ParametrosPartialView.ComboEmpleados_PV, Model)
                </div>
                <div class="clear">
                </div>
                <div id="msgListaEmpleado">
                </div>
            </div>
        </div>
    </div>
    @<div class="formRow fluid">
        <div class="grid6">
            <div class="grid6" style="padding-top: -30px">
                <label>
                    Fecha Asignación :</label>
            </div>
            <div class="grid5">
                <div id="divListaFechaActivacion">
                    @Html.Partial(ParametrosPartialView.PVFechaActivaporEmpleado, Model)
                </div>
            </div>
        </div>
        <div class="grid6">
            <div class="grid4" style="padding-top: -30px">
                <label>
                    Porcentaje :</label></div>
            <div class="grid6">
                @Html.TextBoxFor(Function(m) (m.VentaCartera.Porcentaje),
                    New With {
                        .id = "ID_Porcentaje",
                        .class = "textinput digit-validation",
                        .onkeypress = "return val_09_2D(event)",
                        .maxlength = 5,
                        .onkeyup = "this.value = minmax(this.value, 0, 100)"
                        })
            </div>
            <div class="clear">
            </div>
            <div id="msgPorcentaje">
            </div>
        </div>
    </div>
    @<script type="text/javascript">
         $("#cboEmpleados").uniform();
    </script>
Else
    @Html.Hidden("UrlClientesAutoComplete", Url.Action("ListaVendedoresAutoComplete", "Cliente"))
    @Html.Hidden("UrlSucursalesDisponibles", Url.Action("ListaSucursalesDisponibles", "Cliente"))
    @Html.HiddenFor(Function(m) m.Empleado.SucursalEmpleado.FechaIngresoSucursal, New With {.id = "HdnFechaIngresoSucursal"})
    @Html.HiddenFor(Function(m) m.Empleado.IdEmpleado, New With {.id = "HdnIdEmpleado"})    
    @<div class="formRow fluid">
        <div class="grid12">
            <div class="grid3" style="margin-top: -10px;">
                <label>
                    T. Compartida:
                </label>
            </div>
            <div class="grid3">
                <input type="radio" class="radio" id="rbtHoreca" name="VentaCartera.TCompartida" checked="checked" value="Horeca" onclick="DesHabilitarPorcentajeTCompartida()" />
                <label for="rbtHoreca" class="mr20" style="margin-top: -5px;">
                    Horeca
                </label>
            </div>
            <div class="grid3">
                <input type="radio" id="rbtNormal" name="VentaCartera.TCompartida" value="Normal" onclick="DesHabilitarPorcentajeTCompartida()" />
                <label for="rbtNormal" class="mr20" style="margin-top: -5px;">
                    Normal
                </label>
                <br class="clear" />
            </div>
        </div>
    </div>
    @<div class="formRow fluid">
        <div class="grid12">
            <div class="grid3" style="padding-top: -30px">
                <label>
                    RRVV :<span class="req">*</span></label>
            </div>
            <div class="grid9">
                <div id="divIdEmpleado">
                    @Html.TextBoxFor(Function(m) m.Empleado.IdEmpleado,
                    New With
                    {
                        .style = "text-transform:uppercase;",
                        .id = "NombreEmpleado_AutoComplete",
                        .name = "txtEmpleado",
                        .onkeypress = "return val_AZ(event)",
                        .maxLength = "50",
                        .class = "textinput"
                    })
                    <small class="note" style="margin-left: 0px">Se debe ingresar como mínimo tres caracteres</small>
                    <br class="clear" />
                </div>
                @Html.ValidationMessageFor(Function(m) m.Empleado.Nombres, "", New With {.id = "msgEmpleado", .Style = "color:red", .class = "reqizq"})
            </div>
        </div>
    </div>
    @<div class="formRow fluid">
        <div class="grid12">
            <div class="grid2" style="padding-top: -30px">
                <label>
                    Sucursales Disponibles:<span class="req">*</span>
                </label>
            </div>
            <div class="grid8" style="padding-top: -30px">                   
                <div id="SucursalesDisponibles">
                @Html.Partial(ParametrosPartialView.PV_SucursalesDisponibles,Model)
                </div>
                <div class="clear"></div>
                @Html.ValidationMessageFor(Function(m) m.Sucursal.IdSucursalActual, "", New With {.id = "msgSucursal", .Style = "color:red", .class = "reqizq"})
            </div>
        </div>
    </div>
    @<div class="formRow fluid">
        <div id="contenedor-grid-Sucursales">
        </div>
    </div>
    @<script type="text/javascript">
         $(function () {
             $.ajaxSetup({ type: "POST", cache: false });
             var ParamUrl = $("#UrlClientesAutoComplete").val();
             var vIdCliente = $("#IdCliente").val();
             $('#NombreEmpleado_AutoComplete').autocomplete(ParamUrl, {
                 dataType: 'json',
                 parse: function (data) {
                     $("#HdnIdEmpleado").val('');
                     rows = new Array();
                     for (var i = 0; i < data.length; i++) {
                         rows[i] = { data: data[i], value: data[i].NombresApellidos, result: data[i].NombresApellidos, id: data[i].IdEmpleado, label: data[i].FechaSucursalUltimo };
                     }
                     return rows;
                 },
                 formatItem: function (row) {
                     return row.NombresApellidos;
                 },
                 delay: 400,
                 autofill: true,
                 selectFirst: false,
                 highlight: false,
                 minChars: 3,
                 extraParams: { IdCliente: function () { return $("#IdCliente").val(); }
             }
             }).result(function (event, row) {
                 $('#NombreEmpleado_AutoComplete').val(row.NombresApellidos);
                 $("#HdnFechaIngresoSucursal").val(row.FechaSucursalUltimo);
                 $("#HdnIdEmpleado").val(row.IdEmpleado);
                 if (esEmpleadoValido()) {
                     CargarSucursalesDisponibles();
                 }

             });
         });
    </script>
End If