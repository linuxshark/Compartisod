@ModelType Sodimac.VentaEmpresa.Web.Mvc.ClientesViewModel
@Imports Sodimac.VentaEmpresa.Web.Mvc.ParametrosView
<div class="wrapper">
    @Using (Html.BeginForm("CrearClienteAdjunto", "Cliente", FormMethod.Post, New With {.name = "frmRegistrarClienteAdjunto", .enctype = "multipart/form-data"}))
        @Html.AntiForgeryToken
        @<div class="widget fluid">
            <div class="whead">
                <h6>
                    Datos Archivos</h6>
                <div class="clear">
                </div>
            </div>
            <div id="result" style="display: none">
            </div>
            <div class="formRow fluid">
                <div class="grid4">
                    <div class="grid4">
                        <label class="form-label">
                            Nombre de Archivo:</label>
                    </div>
                    <div class="grid7">
                        @Html.HiddenFor(Function(m) m.ClienteAdjunto.IdCliente, New With {.id = "IdAdjuntoIdCliente"})
                        @Html.TextBoxFor(Function(m) m.ClienteAdjunto.NombreTemp,
                        New With {
                            .id = "IdNombreTemp",
                            .autocomplete = "off",
                            .maxlength = "100"
                        })
                        <div class="clear">
                        </div>
                        @Html.ValidationMessageFor(Function(m) m.ClienteAdjunto.NombreTemp, "", New With {.class = "reqizq"})
                    </div>
                </div>
                <div class="grid4">
                    <div class="grid4">
                        <label class="form-label">
                            Adjuntar Archivo:</label>
                    </div>
                    <div class="grid7">
                        @Html.TextBoxFor(Function(m) m.FileUploadCliente, New With {.type = "file", .onchange = "validateFileUpload(this);", .id = "ID_FileUpLoad"})
                        <div class="clear">
                        </div>
                        @Html.ValidationMessageFor(Function(m) m.FileUploadCliente, "", New With {.class = "reqizq"})
                    </div>
                </div>
                <div class="grid4" style="float: right">
                    <button onclick="InicioJPopUpOpen('#dialogCancelarClienteAdjunto');" class="buttonS bDefault formSubmit group_button"
                        style="cursor: pointer;">
                        Cancelar
                    </button>
                    <button type="submit" class="buttonS bBlue formSubmit group_button" style="cursor: pointer;">
                        Guardar
                    </button>
                    <div class="clear">
                    </div>
                </div>
            </div>
        </div>

        @<div id="dialogGrabarClienteAdjunto" title="Mensaje de Confirmación">
            <p>
                ¿Desea Generar el registro?</p>
        </div>
        @<div id="dialogCancelarClienteAdjunto" title="Mensaje de confirmación">
            <p>
                ¿Desea cancelar el registro?</p>
        </div> 
        @<div id="dialogEliminarClienteAdjunto" title="Mensaje de confirmación">
            <p>
                ¿Desea eliminar el registro?</p>
        </div>
    End Using
    <div class="widget">
        <div class="whead">
            <h6>
                Listado de Archivos</h6>
            <div class="clear">
            </div>
        </div>
        <div id="contendorgrilla-ListadoClienteAdjunto">
            @Html.Partial(ParametrosPartialView.Colsultar_Cliente_Adjunto_Grilla, Model)
        </div>
        <div class="clear">
        </div>
    </div>
    <div class="formRow fluid">
        <div class="clear">
        </div>
    </div>
</div>

@Html.HiddenFor(Function(m) m.ParametroExt.Descripcion, New With {.id = "ValorCadenaConFig"})
@Html.HiddenFor(Function(m) m.ParametroLong.Valor1, New With {.id = "ValorEnteroConFig"})
@Html.HiddenFor(Function(m) m.ClienteAdjunto.IdAdj, New With {.id = "IdAdjuntoCliente"})

<script type="text/javascript" language="javascript">
    InicioJPopUpConfirm("#dialogGrabarClienteAdjunto", 400, false, "Mensaje de Confirmación", GuardarClienteAdjunto);
    InicioJPopUpConfirm("#dialogCancelarClienteAdjunto", 400, false, "Mensaje de Confirmación", RedireccionarConsultar);
    InicioJPopUpConfirm("#dialogEliminarClienteAdjunto", 400, false, "Mensaje de Confirmación", EliminarClienteAdjunto);
</script>

@If Not Session("mensajeClienteAdjunto") Is Nothing Then
    If Session("mensajeClienteAdjunto").ToString() <> "" Then
    @<script language="javascript" type="text/javascript">
         $(window).load(
            function () {
                var mensaje = '@Session("mensajeClienteAdjunto").ToString()';
                InicioJPopUpAlert(mensaje);
            })
    </script> 
        Session("mensajeClienteAdjunto") = ""
    End If
End If