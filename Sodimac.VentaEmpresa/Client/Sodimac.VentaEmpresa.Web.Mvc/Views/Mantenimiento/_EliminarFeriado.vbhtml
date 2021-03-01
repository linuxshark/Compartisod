@ModelType Sodimac.VentaEmpresa.Web.Mvc.Models.ViewModel.FeriadosViewModel
@Imports Sodimac.VentaEmpresa.Web.Mvc.ParametrosView

@Using (Html.BeginForm("EliminarFeriado", "Mantenimiento", FormMethod.Post, New With {.id = "FrmEliminarFeriado"}))
    @<div class="wrapper">
        @Html.HiddenFor(Function(m) m.Feriados.IdFeriado, New With {.id = "IdFeriadoEditar"})
        @Html.HiddenFor(Function(m) m.Feriados.Activo, New With {.id = "IdFeriadoEstado"})
        <div class="form">
            <fieldset>
                <div class="formRow fluid">
                    <div class="grid12">
                        <div class="grid7">Desea @ViewBag.Estado el Feriado de Id:</div>
                        <div class="grid5">
                            @Html.DisplayFor(Function(m) m.Feriados.IdFeriado)
                        </div>
                    </div>
                </div>
                <div class="formRow fluid">
                    <div class="grid12">
                        <div class="grid7"> Mes: </div>
                        <div class="grid5">
                            @Html.DisplayFor(Function(m) m.Feriados.NombreMes)
                        </div>
                    </div>
                </div>
                <div class="formRow fluid">
                    <div class="grid12">
                        <div class="grid7"> Dia: </div>
                        <div class="grid5">
                            @Html.DisplayFor(Function(m) m.Feriados.Dia)
                        </div>
                    </div>
                </div>
                <div class="formRow fluid">
                    <div class="grid12">
                        <div class="grid7"> Descripcion: </div>
                        <div class="grid5">
                            @Html.DisplayFor(Function(m) m.Feriados.Descripcion)
                        </div>
                    </div>
                </div>
                <div class="formRow fluid">
                    <div class="grid12">
                        <div class="grid7"> Año: </div>
                        <div class="grid5">
                            @Html.DisplayFor(Function(m) m.Feriados.DescripcionAnio)
                        </div>
                    </div>
                </div>
                <div class="formRow" style="margin-right:10px">
                    <button type="button" name="ActionAgregar" id="btnEliminarFeriado" style="cursor:pointer" class="buttonS bBlue formSubmit group_button ">@ViewBag.Boton</button>
                    <br class="clear" />
                    <div class="clear"></div>
                </div>
            </fieldset>
        </div>
    </div>
End Using