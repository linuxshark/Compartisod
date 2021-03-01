@Modeltype Sodimac.VentaEmpresa.Web.Mvc.CierreViewModel

<div class="wrapper">
    <div class="form">
        @Using (Html.BeginForm("RegistrarCierre", "Mantenimiento", FormMethod.Post, New With {.id = "FrmNuevoCierre"}))
            @<fieldset>
                <div class="formRow fluid">
                    <div class="grid12">
                        @Html.LabelFor(Function(m) m.Cierre.Año, New With {.class = "grid4"})
                        <div class="grid8">
                            @Html.ValidationMessageFor(Function(m) m.Cierre.Año, String.Empty, New With {.class = "reqizq"})
                            @Html.DropDownListFor(Function(m) m.Cierre.Año,
                                         New SelectList(Model.ListaAño, "IdAño", "Año"),
                                         " SELECCIONE ", New With {
                                         .id = "IdañoNuevo"
                                         })

                        </div>
                    </div>
                </div>
                <div class="formRow fluid">
                    <div class="grid12">
                        @Html.LabelFor(Function(m) m.Cierre.Mes, New With {.class = "grid4"})
                        <div class="grid8">
                            @Html.ValidationMessageFor(Function(m) m.Cierre.Mes, String.Empty, New With {.class = "reqizq"})
                            @Html.DropDownListFor(Function(m) m.Cierre.Mes,
                                         New SelectList(Model.ListaMes, "IdMes", "Mes"),
                                         " SELECCIONE ", New With {
                                         .id = "IdMesNuevo"
                                         })
                        </div>
                    </div>
                </div>
                 <div class="formRow fluid">
                     <div class="grid12">
                         @Html.LabelFor(Function(m) m.Cierre.FechaCierre, New With {.class = "grid4"})
                         <div class="grid3">
                             @Html.ValidationMessageFor(Function(m) m.Cierre.FechaCierre, String.Empty, New With {.class = "reqizq"})
                             @Html.TextBoxFor(Function(m) (m.Cierre.FechaCierre),
                                                 New With {
                                                 .id = "IdFechaCierre",
                                                 .class = "textinput datepickerAkiraMax2",
                                                 .maxlength = "10",
                                                 .Value = String.Format("{0:dd/MM/yyyy}", System.DateTime.Now),
                                                 .readonly = true
                                                 })
                         </div>
                     </div>
                 </div>
                <div class="formRow">
                    <button type="button" name="ActionCancelar" id="btnCancelar" style="cursor:pointer" class="buttonS bDefault formSubmit group_button ">Cancelar</button>
                    <button type="button" name="ActionAgregar" id="btnRegistrar" style="cursor:pointer" class="buttonS bBlue formSubmit group_button ">Guardar</button>
                    <br class="clear" />
                    <div class="clear"></div>
                </div>
            </fieldset>
        End Using
    </div>
</div>

<script type="text/javascript" language="javascript">
    var navegador = navigator.appName
    //Esto permite que la fecha no sea mayor a la actual
    $(".datepickerAkiraMax").datepicker({
        showOtherMonths: true,
        autoSize: true,
        changeMonth: true,
        changeYear: true,
        appendText: '(DD/MM/AAAA)',
        dateFormat: 'dd/mm/yy',
        maxDate: "0D"
    });

    $(".datepickerAkiraMax2").datepicker({
        showOtherMonths: true,
        autoSize: true,
        changeMonth: true,
        changeYear: true,
        appendText: '(DD/MM/AAAA)',
        dateFormat: 'dd/mm/yy',
    });
</script>
   
