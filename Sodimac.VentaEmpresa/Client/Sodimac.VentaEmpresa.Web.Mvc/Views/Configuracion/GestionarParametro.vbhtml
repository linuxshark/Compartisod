@ModelType Sodimac.VentaEmpresa.Web.Mvc.ConfiguracionViewModel
@Imports Sodimac.VentaEmpresa.Web.Mvc.ParametrosView
@Imports Sodimac.VentaEmpresa.Common
@Code
    If Model.Parametro.IdParametro = 0 Then
        ViewData("Title") = "Nuevo Parametro"
    Else
        ViewData("Title") = "Modificar Parametro"
    End If
End Code

@Html.HiddenFor(Function(m) m.Parametro.IdParametro, New With {.id = "IdParametro"})
@Html.Hidden("Url_Actualizar_Parametro", Url.Action("ActualizarParametro", "Configuracion"))
<script type="text/javascript" src="@Url.Content("~/Scripts/View/Configuracion.js")"></script>
<div class="breadLine">
    <div class="bc">
        <ul id="breadcrumbs" class="breadcrumbs">
            <li><a href="#">Inicio</a></li>
            <li><a href="#">Configuración</a></li>
            @If Model.Parametro.IdParametro = 0 Then
                @<li class="current"><a href="#" title="">Nuevo Parametro</a></li>
            Else
                @<li class="current"><a href="#" title="">Modificar Parametro</a></li>
            End If
        </ul>
    </div>
</div>
<div class="contentTop">
    @If Model.Parametro.IdParametro = 0 Then
        @<span class="pageTitle"><span id="IdAgregarTitle" class="icon-screen"></span>Nuevo
            Parametro</span>
    Else
        @<span class="pageTitle"><span id="IdAgregarTitle" class="icon-screen"></span>Modificar
            Parametro</span>
    End If
    <div class="clear">
    </div>
</div>
@Html.AntiForgeryToken()
<div class="wrapper">
    <div class="main">
        <div class="form">
            <fieldset>
                <div class="widget fluid" id="tabsDemo" style="z-index:100">
                    <ul class="tabs">
                        <li class="activeTab"><a href="#tabb1">Parámetro : @Model.Parametro.Parametro</a> </li>
                    </ul>
       
                    <div class="tab_container">
                        <div id="tabb1" class="tab_content" style="display: none;">
                            <div class="formRow fluid">
                                <div class="grid3">
                                    <label>Descripción: </label>
                                </div> 
                                <div class="grid3"> 
                                    @Html.TextBoxFor(Function(m) m.Parametro.Descripcion1,
                                    New With
                                    {
                                        .id = "Descripcion1",
                                        .maxLength = "100",
                                        .class = "textinput",
                                        .onkeypress = "return val_AZ(event)"
                                    })   
                                </div> 
                                <div class="grid3">  
                                    <label>Variable 1: </label>
                                </div>
                                <div class="grid3">  
                                    @Html.TextBoxFor(Function(m) m.Parametro.Valor1,
                                    New With
                                    {
                                        .id = "Id_Valor1",
                                        .maxLength = "100",
                                        .class = "textinput"
                                    })     
                                </div>
                                <div class="clear"></div>
                            </div>
                            <div class="formRow fluid">
                                <div class="grid3">
                                    <label>Descripción: </label>
                                </div> 
                                <div class="grid3"> 
                                    @Html.TextBoxFor(Function(m) m.Parametro.Descripcion2,
                                    New With
                                    {
                                        .id = "Descripcion2",
                                        .maxLength = "100",
                                        .class = "textinput",
                                        .onkeypress = "return val_AZ(event)"
                                    })   
                                </div> 
                                <div class="grid3">  
                                    <label>Variable 2: </label>
                                </div>
                                <div class="grid3">  
                                    @Html.TextBoxFor(Function(m) m.Parametro.Valor2,
                                    New With
                                    {
                                        .id = "Id_Valor2",
                                        .maxLength = "100",
                                        .class = "textinput"
                                    })     
                                </div>
                                <div class="clear"></div>
                            </div>
                            <div class="formRow fluid">
                                <div class="grid3">
                                    <label>Descripción: </label>
                                </div> 
                                <div class="grid3"> 
                                    @Html.TextBoxFor(Function(m) m.Parametro.Descripcion3,
                                    New With
                                    {
                                        .id = "Descripcion3",
                                        .maxLength = "100",
                                        .class = "textinput",
                                        .onkeypress = "return val_AZ(event)"
                                    })   
                                </div> 
                                <div class="grid3">  
                                    <label>Variable 3: </label>
                                </div>
                                <div class="grid3">  
                                    @Html.TextBoxFor(Function(m) m.Parametro.Valor3,
                                    New With
                                    {
                                        .id = "Id_Valor3",
                                        .maxLength = "100",
                                        .class = "textinput"
                                    })     
                                </div>
                                <div class="clear"></div>
                            </div>
                            <div class="formRow fluid">
                                <div class="grid3">
                                    <label>Fecha Desde: </label>
                                </div> 
                                <div class="grid3"> 
                                    @Html.TextBoxFor(Function(m) (m.Parametro.FechaDesde),
                                    New With {
                                              .id = "FechaDesde",
                                              .class = "datepicker maskDate",
                                              .maxlength = "10"
                                    })
                                    <br class="clear" />
                                    <div id="ID_MsgFechaInicio"></div>
                                </div> 
                                <div class="grid3">  
                                    <label>Fecha Hasta: </label>
                                </div>
                                <div class="grid3">  
                                    @Html.TextBoxFor(Function(m) (m.Parametro.FechaHasta),
                                    New With {
                                              .id = "FechaHasta",
                                              .class = "datepicker maskDate",
                                              .maxlength = "10"
                                    })
                                    <br class="clear" />
                                    <div id="ID_MsgFechaFin"></div>
                                </div>
                                <div class="clear"></div>
                            </div>
                            <div class="formRow noBorderB">
                                <div class="formSubmit">
                                    <input class="buttonM bBlue ui-wizard-content" id="btnGuardar" value="Guardar" 
                                            type="reset" onclick="Guardar()" />
                                    <input class="buttonM bDefault ui-wizard-content" id="IdCancelar" value="Cancelar"
                                            type="reset" onclick="Cancelar()" />
                                </div>
                                <div class="clear">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </fieldset>
        </div>
    </div>
</div>

<div id="mensajeResultado" title="@Sodimac.VentaEmpresa.Validation.Messages.Aviso" style="display: none">
    <p></p>
</div>

<div id="mensajeConfirmacion" title="@Sodimac.VentaEmpresa.Validation.Messages.Confirmacion_Titulo" style="display: none">
    <p></p>
</div>

<script type="text/javascript" language="javascript">
    $("#mensajeConfirmacion").dialog({
        autoOpen: false,
        width: 400,
        modal: true,
        resizable: false,
        hide: 'fade',
        show: 'fade',
        buttons: {
            "Sí": function () {
                var data = $(this).data('Opcion');
                $('#mensajeConfirmacion').dialog("close");
                switch (data) {
                    case 'GuardarParametro':
                        GuardarParametro();
                        break;
                    case 'Cancelar':
                        setTimeout(window.location.href = '/Configuracion/BuscarParametro', 100);
                        break;
                }
            },
            "No": function () {
                $('#mensajeConfirmacion').dialog("close");
            }
        }
    });

    $("#mensajeResultado").dialog({
        autoOpen: false,
        width: 400,
        modal: true,
        resizable: false,
        hide: 'fade',
        show: 'fade',
        buttons: {
            "Aceptar": function () {
                var data = $(this).data('Opcion');
                $("#mensajeResultado").dialog("close");
                switch (data) {
                    case 'Consultar':
                        setTimeout(window.location.href = '/Configuracion/BuscarParametro', 100);
                        break;
                }
            }
        }
    });
</script>
