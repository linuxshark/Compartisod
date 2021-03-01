@modeltype Sodimac.VentaEmpresa.Web.Mvc.ProcesoViewModel
@Imports Sodimac.VentaEmpresa.Web.Mvc.ParametrosView
@Code
    ViewData("Title") = "CargarMasivaEmpleado"
    'Layout = "~/Views/Shared/_Layout.vbhtml"
End Code


<div class="breadLine">
    <div class="bc">
        <ul id="breadcrumbs" class="breadcrumbs">
            <li><a href="#">Inicio</a> </li>
            <li><a href="#">Reproceso ventas</a> </li>
            <li class="current"><a title="" href="#">Carga Masiva de Empleados</a> </li>
        </ul>
    </div>
</div>
<div class="contentTop">
    <span class="pageTitle">
        <span id="IdAgregarTitle" class="icon-screen"></span>Carga
        Masiva de Empleado
    </span>
    <div class="clear">
    </div>
</div>

<form action="@Url.Action("AdjuntarDataEmpleado")" id="frm" method="post"  enctype="multipart/form-data">
    <div class="widget fluid" style="width: 90%">
        <div class="wrapper">
            <div class="tab_container">

                <div id="tabb1" class="tab_content" style="display: block;">
                    <div class="formRow fluid">

                        <div class="grid4">
                            <div class="grid3">
                                <label style="">
                                    T. Operacion
                                </label>
                            </div>
                            <div class="grid5">

                                @Html.DropDownListFor(Function(m) m.Operacion.Operacion,
                                         New SelectList(Model.ListaOperacion, "IdOperacion", "Operacion"))
                                
                            </div>
                        </div>
                        <div class="grid5">
                            <div class="grid3">
                                <label>
                                    Adjuntar archivo:
                                </label>
                            </div>
                            <div class="grid6">
                                <input type="file" id="IdFileSelect" name="file1"  />
                                @*<span style="display: none;" id="idReqFile" class="req">Requerido</span>*@
                                <span style="display: none;" id="idReqFile" class="req"></span>


                            </div>

                        </div>
                        <div class="grid3">
                            <div class="grid4">

                                <button type="button" name="ActionVer" id="idDes" style="cursor: pointer" onclick="DescargarArchivo()" class="buttonS bBlue formSubmit group_button">
                                    Descargar
                                </button>
                            </div>
                            <div class="grid4">
                                <button type="button" name="ActionVer" id="idGuardar" style="cursor: pointer" onclick="Guardar()" class="buttonS bBlue formSubmit group_button">
                                    Guardar
                                </button>
                            </div>


                        </div>

                    </div>
                    @*<div class="formRow fluid">
                        <button type="button" name="ActionVer" id="idVer" style="cursor: pointer" class="buttonS bBlue formSubmit group_button">
                            Visualizar()
                        </button>
                        <div class="clear">
                        </div>
                    </div>*@
                    <div class="formRow fluid">
                        @If Not (Model.ListarProcesoCargaEErrores Is Nothing) AndAlso (Model.ListarProcesoCargaEErrores.Count > 0) Then
                            @<div class="whead">
                                 @*<div class="tab-container">
                                     <div id="tabb1" class="tab_content" style="display: block;">

                                         </div>
                                     </div>*@
                                     <h6>
                                         Errores del archivo
                                     </h6>
                                     <div class="clear">
                                     </div>
                                 </div>
                            @<div class="widget fluid">

                                <div id="GrillaImportarEmpleado" style="overflow: scroll;">
                                    @Html.Partial("CE_Errores", Model)
                                </div>

                            </div>
                        ElseIf Not (Model.ListarProcesoCargaEErrores Is Nothing) AndAlso (Model.ListarProcesoCargaEErrores.Count = 0 AndAlso Model.ListaProcesoCargaE.Count <> 0) Then
                            @<div class="whead">
                                <h6>
                                    Resultados del archivo
                                </h6>
                                <div class="clear">
                                </div>
                            </div>
                            @<div class="widget fluid">

                                <div id="GrillaImportarEmpleado" style="overflow: scroll;">
                                    @Html.Partial("PV_GrillaEmpleado", Model)
                                </div>

                            </div>
                            @<div class="clear">
                            </div>
                        Else
                            
                             @<div class="whead">
                                <h6>
                                    Resultados del archivo
                                </h6>
                                <div class="clear">
                                </div>
                            </div>
                            @<div class="widget fluid">

                                <div id="GrillaImportarEmpleado" style="overflow: scroll;">
                                    @Html.Partial("PV_GrillaEmpleado", Model)
                                 
                                </div>

                            </div>
                            @<div class="clear">
                            </div>
                        End If

                    </div>
                       
                        </div>
                        <div class="clear">
                     
                    </div>
                    <div class="formRow fluid">

                    </div>

                </div>



            </div>
        </div>
    </div>
    <p>@Model.Mensaje</p>
    
</form>

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
    $(function () {
        $("#frm :submit").click(function () {
            var file = $("#file1").get();
            return false;
        });
    });

</script>
<script>

    var Url ={Archivo: '@Url.Action("Descargar")'}
</script>
<script type="text/javascript">
    
    $(window).load(function () {

        //$("#Operacion_Operacion").val() == "0"
        $("#IdFileSelect").click(function () {
            $("#idReqFile").css("display", "none")
        })
        var estado = $("#IdFileSelect").val();
        if (estado == "") {
            $("#idReqFile").css("display", "inline-block")
            return;
      

        }
        else {
            if (estado != "") {
                $("#idReqFile ").css("display", "inline-block")
                
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
        }
       

    });

    $("#IdFileSelect").change(function () {
        var estado = $("#IdFileSelect").val();
        var IdOperacion = $("#IdOperacionIndex").val();
        if (estado == "") {
            $("#idReqFile").css("display", "inline-block")
            return;


        }
        var extension = estado.substr((estado.lastIndexOf('.') + 1));

        if (extension == "xls" || extension == "xlsx") {
            //{ Operacion: Operacion }
            $("#frm").submit();
        }
        else {
            appendErrorMessage("#idReqFile", "Extensión no permitida(sólo *.xls o *.xlsx)", true);
            $("#idReqFile").css("display", "inline-block");
            validate = false;
        }
    })

    function Guardar() {

        var prueba = $("#hdfgrabar").val()
        if ($("#hdfgrabar").val() == undefined || $("#hdfgrabar").val() == "NO") {
            $("#idVentana p").text('No se adjuntó un archivo');
            $("#idVentana").dialog('open');
            return false
        }



        var Operacion = $("#Operacion_Operacion").val()
        var Tabla = $("#dgvDatos").val();
        $.post(
        "/Proceso/Guardar",
         { Operacion: Operacion },
         function (json) {
             alert(json);

         }, "json"

        );
        window.location = "/Proceso/CargarMasivaEmpleado"
    }
  
    //function Guardar() {
    //    debugger
    //    var prueba = $("#hdfgrabar").val()
    //    if ($("#hdfgrabar").val() == undefined || $("#hdfgrabar").val() == "NO") {
    //        $("#idVentana p").text('No se adjuntó un archivo');
    //        $("#idVentana").dialog('open');
    //        return false
    //    }

  

    //    var Operacion = $("#Operacion_Operacion").val()
    //    var Tabla = $("#dgvDatos").val();
    //    $.post(
    //    "/Proceso/Guardar",
    //     { Operacion: Operacion },
    //     function (json) {
    //         alert(json);
    //     }, "json"
    //    );
    //}

    function DescargarArchivo() {
   
        window.location = Url.Archivo
      
    }
  
    $("#idVentana").dialog({
        autoOpen: false,
        modal: true,
        resizable: true,
        width: 400,
        hide: 'fade',
        show: 'fade',
        title: "Error",
        buttons: [{
            id: "btnPopAceptar",
            text: "Aceptar",
            click: function () {
                $(this).dialog("close");

            }
        }]
    });
    
</script>
@Code
    Dim message As String = ""
    If Request.QueryString("mensage") IsNot Nothing Then
        message = Request.QueryString("mensage")
        If (message.Length > 1) Then
End code
@*<script type="text/javascript">
    var qParam = getParameterByName('mensage');
    $("#idVentana p").text(qParam);
    $("#idVentana").dialog('open');

</script>*@
@Code
End If
End If

End Code