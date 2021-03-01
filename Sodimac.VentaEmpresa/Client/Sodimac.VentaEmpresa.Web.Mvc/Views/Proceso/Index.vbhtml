@modeltype Sodimac.VentaEmpresa.Web.Mvc.ProcesoViewModel
@Code
    ViewData("Title") = "Index"
End Code
<script type="text/javascript">
    $(function () {
        $("#frm :submit").click(function () {
            var file = $("#file1").get();
            return false;
        });
    });    
</script>
<div class="breadLine">
    <div class="bc">
        <ul id="breadcrumbs" class="breadcrumbs">
            <li><a href="#" style="cursor: default">Proceso</a></li>
            <li><a href="#" style="cursor: default">Subir Archivo</a></li>
            <li class="current"><a href="#" title=""></a></li>
        </ul>
    </div>
</div>

        

<div id="ModelVerErrores" style="display: none" class="j_modal" title="Errores del archivo">@Html.Partial("PV_Errores", Model)</div>
<form action="@Url.Action("AdjuntarDataMensual")"
     
      id="frm" method="post" enctype="multipart/form-data">
    <center>
        <div class="widget fluid" style="width: 90%">
            <ul class="tabs">
                <li id="lnk0" class="activeTab"><a href="#tabb1">Carga Manual</a> </li>
                <li id="lnk1" class=""><a href="#tabb2">Historial</a> </li>
            </ul>
            <div class="wrapper">
                <div class="tab_container">
                    <div id="tabb1" class="tab_content" style="display: block;">
                        <div class="formRow fluid">
                            <div class="grid6">
                                <div class="grid3">
                                    <label>
                                        Adjuntar archivo:
                                    </label>
                                </div>
                                <div class="grid5">
                                    <input type="file" id="IdFileSelect" name="file1" />
                                    <span style="display: none;" id="idReqFile" class="req">Requerido</span>
                                </div>
                            </div>
                            <div class="grid6">
                                <div class="grid2">
                                    <label style="">
                                        Hoja:
                                    </label>
                                </div>
                                <div class="grid5">
                                    @Html.TextBoxFor(Function(m) m.Hoja,
                                    New With
                                    {
                                        .style = "text-transform:uppercase;",
                                        .id = "txtHoja",
                                        .name = "txtHoja",
                                        .onkeypress = "return val_AZ(event)",
                                        .maxLength = "100",
                                        .class = "textinput"
                                    })
                                    <span style="display: none;" id="idReqFile" class="req">Requerido</span>
                                </div>
                            </div>
                        </div>
                        <div class="formRow fluid">
                            <button type="button" name="ActionVer" id="idVer" style="cursor: pointer" class="buttonS bBlue formSubmit group_button">
                                Visualizar
                            </button>
                            <div class="clear">
                            </div>
                        </div>
                        <div class="formRow fluid">
                            <div class="whead">
                                <h6>
                                    Resultados del archivo
                                </h6>
                                <div class="clear">
                                </div>
                            </div>
                            <div class="widget fluid">
                                @*<div class="wrapper">*@
                                <div id="GrillaImportar" style="overflow: scroll; width: 1050px">
                                    @Html.Partial("PV_Grilla", Model)
                                </div>
                                @*</div>*@
                            </div>
                            <div class="clear">
                            </div>
                        </div>
                        <div class="formRow fluid">
                            @If Not (Model.ListaProcesoCargaErrorTotales Is Nothing) AndAlso (Model.ListaProcesoCargaErrorTotales.Count > 0) Then
                                @<font color="red"> @Html.DisplayTextFor(Function(m) m.DescripcionErrores) </font>
                                @<button type="button" name="btnVerDetalle" id="btnVerDetalle" style="cursor: pointer"
                                         class="buttonS bBlue formSubmit group_button" onclick="PV_Errores();">
                                    Ver detalle
                                </button>
                            ElseIf Not (Model.ListaProcesoCargaErrorTotales Is Nothing) AndAlso (Model.ListaProcesoCargaErrorTotales.Count = 0 AndAlso Model.ListaProcesoCarga.Count <> 0) Then
                                @Html.DisplayTextFor(Function(m) m.DescripcionCorrectos)
                                @<button type="button" name="btnGuardar" id="btnGuardar" style="cursor: pointer" class="buttonS bBlue formSubmit group_button"
                                         onclick="ImportarArchivos();">
                                    Guardar
                                </button>
                            End If
                        </div>
                    </div>
                    <div id="tabb2" class="tab_content" style="display: none;">
                        <div class="widget fluid">
                            <div class="wrapper">
                                <div id="GrillaHistorial">
                                    @Html.Partial("PV_Historial", Model)
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div>
            <p>@Model.Mensaje</p>
        </div>
    </center>
</form>

@* <div>
    <form name="frm" method="post" enctype="multipart/form-data">
        <input type="file" name="file1"/>
        <input type="submit" id="idEnviar" value="enviar"/>
    </form>
    </div>*@
<div id="idVentana" title="Registrar">
    <p>
    </p>
</div>
<div id="Seguridad" title="Confirmar">
    <p>
    </p>
</div>
<div id="Actualizacion" title="Confirmar">
    <p>
    </p>
</div>
<div id="dialogInformacionResultado" title="Confirmar">
    <p>
    </p>
</div>
<div id="dialogInformacionImportacion" title="Confirmar">
    <p>
    </p>
</div>
<div id="dialogActualizaComision" title="Confirmar">
    <p>
    </p>
</div>
<script type="text/javascript" src="@Url.Content("~/Scripts/View/Proceso.js")"></script>
<script type="text/javascript">


    $("#IdFileSelect").live("click", function () {
        $("#idReqFile").css("display", "none");
    });
    $("#idVer").live("click", function () {
        var estado = $("#IdFileSelect").val();
        if (estado == "") {
            $("#idReqFile").css("display", "inline-block")
            return;
        }
        var extension = estado.substr((estado.lastIndexOf('.') + 1));

        if (extension == "xls" || extension == "xlsx") {
            $('#Seguridad p').text("Sólo se mostrará los datos del excel.");
            $('#Seguridad').dialog("open");
        }
        else {
            appendErrorMessage("#idReqFile", "Extensión no permitida(sólo *.xls o *.xlsx)", true);
            $("#idReqFile").css("display", "inline-block");
            validate = false;
        }

    });
    $(window).load(function () {
        BuscarHistorial('@Url.Action("PV_Historial", "Proceso")');
        $("#IdFileSelect").val("");

    });
    $("#idVentana").dialog({
        autoOpen: false,
        width: 250,
        height: 100,
        modal: true,
        resizable: false,
        hide: 'fade',
        show: 'fade',
        title: "Transacción"

    });

    $(function () {
        InicioJPopUp("#dialogGestionarCargo", 500, 490, false, "Gestionar Cargo");
    })

    function getParameterByName(name) {
        name = name.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
        var regexS = "[\\?&]" + name + "=([^&#]*)";
        var regex = new RegExp(regexS);
        var results = regex.exec(window.location.href);
        if (results == null)
            return "";
        else
            return decodeURIComponent(results[1].replace(/\+/g, " "));
    }

    $("#Seguridad").dialog({
        autoOpen: false,
        width: 400,
        modal: true,
        resizable: false,
        hide: 'fade',
        show: 'fade',
        title: "Mensaje",
        buttons: {
            "Sí": function () {
                //                    var fileLeo = $("#IdFileSelect");
                $("#frm").submit();

                //                           var form = $("#frm");
                //                        $.ajax({
                //                        url: $("#frm").attr("action"),
                //                        data: fileLeo,
                //                        type: "POST",
                //                        headers: { "Content-Type": "multipart/form-data"},
                //                        success: function (data) {
                //                                        
                //                        
                //                        }
                //                        });



                $('#Seguridad').dialog("close");

            },
            "No": function () {
                $('#Seguridad').dialog("close");
                return false;
            }

        }
    });
</script>
@Code
        Dim message As String = ""
    If Request.QueryString("mensage") IsNot Nothing Then
        message = Request.QueryString("mensage")
        If (message.Length > 1) Then
End code
<script type="text/javascript">
    var qParam = getParameterByName('mensage');
    $("#idVentana p").text(qParam);
    $("#idVentana").dialog('open');

</script>
@Code
        End If
    End If
   
End Code
