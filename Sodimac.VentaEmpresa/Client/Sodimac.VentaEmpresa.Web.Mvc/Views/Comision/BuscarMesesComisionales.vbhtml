@modeltype Sodimac.VentaEmpresa.Web.Mvc.ComisionViewModel
@Imports Sodimac.VentaEmpresa.Web.Mvc.UtilFile
@Imports Sodimac.VentaEmpresa.Web.Mvc.ParametrosView
@Code
    ViewData("Title") = "Cierre Mes Comisional"
End Code
<script type="text/javascript" src="/Scripts/View/Comision.js"></script>
<script type="text/javascript" src="/Scripts/View/ComisionAdjunto.js"></script>
@Html.Hidden("ID_UrlInicio", Url.Action("BuscarMesesComisionales"), "Comision") 
@Html.Hidden("ID_Url", Url.Action("_BuscarMesesComisionales"), "Comision") 
@Html.Hidden("Url_Listar_Periodo", Url.Action("Listar_Periodos"), "Comision")
@Html.Hidden("Url_Cerrar_Mes_Comisional", Url.Action("CerrarMesComisional"), "Comision") 
@Html.Hidden("Url_BuscarMesesComisional", Url.Action("_BuscarMesesComisionales"), "Comision")
@Html.Hidden("Listar_EmpleadoJEFEJVV", Url.Action("FiltrarEmpleadoJEFEVV"), "Comision")
@Html.Hidden("Url_ListarAdjuntoComisional", Url.Action("ListarAdjuntoComisional"), "Comision")
@Html.Hidden("Url_EliminarComisionAdjunto", Url.Action("EliminarComisionAdjunto"), "Comision")
@Html.Hidden("Url_Descargar_Adjunto", Url.Action("Descargar_PDF"), "Comision")
@Html.Hidden("Url_Descargar_Adjunto2", Url.Action("Descargar_Archivo"), "Comision")
@Html.Hidden("Hdn_IdPeriodo", Model.ComisionPeriodo.IdPeriodo)
@Html.Hidden("Hdn_IdAdjunto")
@Html.Hidden("Hdn_IdPeriodo")
@Html.Hidden("Hdn_IdPeriodoDetalle")

<div class="breadLine"> 
    <div class="bc">
        <ul id="breadcrumbs" class="breadcrumbs">
            <li><a href="#">Inicio</a> </li>
            <li class=""><a href="#">Planificación</a></li>
            <li class="current"><a title="" href="#">Cerrar Periodo Comisión</a> </li>
        </ul>
    </div>
</div>
<div class="contentTop">
    <span class="pageTitle"><span id="IdAgregarTitle" class="icon-screen"></span>Cerrar
        Periodo Comisión</span>
    <div class="clear">
    </div>
</div>
<div class="wrapper">
    <div class="main">
        <fieldset>
            <div class="form">
                <div class="widget fluid">
                    <div class="whead">
                        <h6>
                            Criterios de Búsqueda</h6>
                        <div class="clear">
                        </div>
                    </div>
                       <div class="formRow">
                            <div class="grid6">
                                <div class="grid3">
                                    <label class="form-label">
                                        Nombre :<span class="req"></span></label>
                                </div>
                                <div class="grid7">
                                
                                @Html.TextBoxFor(Function(m) m.ComisionPeriodo.NombrePeriodo,
                                New With {
                                    .id = "Id_NombreMesComisional",
                                    .onkeypress = "EnterSubmit(event,'btnBuscar');", 
                                    .maxlength = "44"
                                })
                                @Html.ValidationMessageFor(Function(m) m.ComisionPeriodo.NombrePeriodo, "",
                                New With {
                                    .class = "reqizq"
                                })
                                </div>
                            </div>
                            <div class="grid6">
                                <div class="grid3">
                                    <label class="form-label">
                                        Estado :<span class="req"></span></label>
                                </div>
                                <div class="grid9">

                              @Html.DropDownListFor(Function(m) m.ProcesoEstado.IdEstado,
                               New SelectList(Model.ListadoProcesoEstado, "IdEstado", "Descripcion"),
                               "-TODOS- ",
                                       New With {
                                                .id = "Id_Estado",
                                                .class = "textinput selector"
                                           })
                                   </div>
                            </div>
                            <div class="clear">
                            </div>
                        </div>
                       <div class="formRow">
                            <div class="grid6">
                                <div class="grid3">
                                    <label class="form-label">
                                        Fecha Inicio:<span class="req"></span></label>
                                </div>
                                <div class="grid9">
                                @If Model.ComisionPeriodoDetalle.FechaIni = Nothing Then
                                 @Html.TextBoxFor(Function(m) (m.ComisionPeriodo.FechaInicio),
                                    New With {
                                        .id = "ID_FechaInicio",
                                        .autocomplete = "off",
                                        .onkeypress = "SubmitButton(event)",
                                        .class = "datepicker maskDate",
                                        .maxlength = "10",
                                        .Value = String.Format("{0:d}", "")
                                    })
                                Else
                                @Html.TextBoxFor(Function(m) (m.ComisionPeriodo.FechaInicio),
                                    New With {
                                        .id = "ID_FechaInicio",
                                        .autocomplete = "off",
                                        .onkeypress = "SubmitButton(event)",
                                        .class = "datepicker maskDate",
                                        .maxlength = "10",
                                        .Value = String.Format("{0:d}", Model.ComisionPeriodoDetalle.FechaIni)
                                    })                                
                                End If
                                   
                                    <div id="ID_MsgFechaInicio">
                                    </div>
                                </div>
                            </div>
                            <div class="grid6">
                                <div class="grid3">
                                    <label class="form-label">
                                        Fecha Fin:<span class="req"></span></label>
                                </div>
                                <div class="grid9">
                                @If Model.ComisionPeriodoDetalle.FechaFin = Nothing Then
                                @Html.TextBoxFor(Function(m) (m.ComisionPeriodo.FechaFin),
                                    New With {
                                        .id = "ID_FechaFin",
                                        .autocomplete = "off",
                                        .onkeypress = "SubmitButton(event)",
                                        .class = "datepicker maskDate",
                                        .maxlength = "10",
                                        .Value = String.Format("{0:d}", "")
                                    })
                                Else
                                @Html.TextBoxFor(Function(m) (m.ComisionPeriodo.FechaFin),
                                    New With {
                                        .id = "ID_FechaFin",
                                        .autocomplete = "off",
                                        .onkeypress = "SubmitButton(event)",
                                        .class = "datepicker maskDate",
                                        .maxlength = "10",
                                        .Value = String.Format("{0:d}", Model.ComisionPeriodoDetalle.FechaFin)
                                    })
                                End If
                                    
                                    <div id="ID_MsgFechaFin">
                                    </div>
                                </div>
                            </div>
                            <div class="clear">
                            </div>
                        </div> 
                    <div class="formRow fluid">
                        <div class="clear">
                        </div>
                    </div>                 
                    <div class="formRow fluid">
                       @* <button class="buttonS bBlue formSubmit group_button" style="cursor: pointer;"
                            id="btnNuevo" onclick="window.location = '@Url.Action("GestionarPeriodoComision", "Comision")'">
                            Nuevo
                        </button>*@
                        <button class="buttonS bBlue formSubmit group_button" style="cursor: pointer;" id="btnBuscar">
                            Buscar
                        </button>
                        <div class="clear">
                        </div>
                    </div>
                </div>
                <div class="widget">
                    <div class="whead">
                        <div class="whead">
                            <h6>Resultados de Búsqueda</h6>
                        </div>
                        <div class="clear">
                        </div>
                    </div>
                    <div id="contendorgrilla-ListadoMesComisional">
                        @*@Html.Partial(ParametrosPartialView._BuscarMesesComisionales, Model)*@
                         @Html.Partial("_BuscarMesesComisionales", Model)
                    </div>
                </div>
            </div>
        </fieldset>
    </div>
</div>
<div title="Información" id="dialogMensaje">
    <p>Registro eliminado correctamente</p>
</div>
<div title="Información" id="dialogMensaje2">
    <p>Se produjo un error al eliminar el registro</p>
</div>
<div title="Información" id="dialogMensaje3">
    <p>Extensión de archivo no permitida, los formatos permitidos son : .pdf ; .xlsx ; .xls ; .docx ; .doc ; .png ; .jpg ; .jpge</p>
</div> 
<div title="Información" id="dialogMensaje4">
    <p>El máximo tamaño total permitido para el Archivo es de 10 Mb</p>
</div>

<div title="Información" id="dialogConfirmarRegistro">
    <p>¿Desea guardar el siguiente registro?</p>
</div>

<div title="Información" id="dialogConfirmarEliminar">
    <p>¿Desea eliminar el siguiente registro?</p>
</div>

<div title="Información" id="dialogConfirmarCerrarMes">
    <p>¿Desea cerrar el mes comisional?</p> 
</div>
<div id="AdjuntarArchivo" style="height:100%">
    <div class="wrapper">
        <div class="widget">
            
            @Using (Html.BeginForm("GuardarComisionAdjunto", "Comision", FormMethod.Post, New With {.id = "frmComisionAdjuntar", .name = "frmComisionAdjuntar", .enctype = "multipart/form-data", .target = "UploadTarget"}))
                            
                @Html.HiddenFor(Function(m) m.ComisionArchivo.Name, New With {.id = "IdArchivoNameComision"}) 
                @Html.HiddenFor(Function(m) m.Empleado.IdEmpleado, New With {.id = "IdEmpleadoJefe"}) 
                @Html.HiddenFor(Function(m) m.ComisionArchivo.IdJefeRRVV.IdEmpleado, New With {.id = "IdJefe"}) 
                @Html.HiddenFor(Function(m) m.ComisionArchivo.Descripcion, New With {.id = "iDescripcion"})
                @Html.HiddenFor(Function(m) m.ComisionArchivo.AprobadoPor, New With {.id = "iAprobado"})
                @Html.HiddenFor(Function(m) m.ComisionArchivo.IdPeriodoComision, New With {.id = "iPeriodoComision"})
                @Html.HiddenFor(Function(m) (m.Id_maxRequestLengthDEV), New With {.id = "Id_maxRequestLengthPDF"})
                @<div id="IdGestionarArchivosComision" style="display: none">
                </div>
                
            End Using
            <div class="whead">
                <h6>Datos Archivos</h6>
                <div class="clear"> </div>
            </div>
            <div class="formRow noBorderB fluid">
                <div class="grid12">
                    <div class="grid3">             
                        <label>JEFE / RRVV :</label>
                    </div>
                    <div class="grid9">
                        @*<input type="text" id="TxtJefe" class="textinput" style = "text-transform:uppercase; width: 510px; "/>  *@  
                        @Html.TextBoxFor(Function(m) (m.Empleado.NombresApellidos),
                                    New With {
                                        .id = "ID_NombresApellidos",
                                        .class = "textinput",
                                        .style = "text-transform:uppercase;  "
                                    })  
                      
                        @Html.HiddenFor(Function(m) m.Empleado.NombresApellidos, New With {.id = "iID_NombresApellidos"})  
                        <div class="clear"></div>  
                        <div style="display: block;  width: 100%;" id="valid-NombresApellidos" >
                             <span id="iIdValidationNombresApellidos" class="error"></span>
                        </div>     
                    </div>
                </div>
                
            </div>
            <div class="formRow noBorderB fluid">
                <div class="grid12">
                    <div class="grid3">             
                        <label>Descripción :</label>
                    </div>
                    <div class="grid9"> 
                        @Html.TextAreaFor(Function(m) (m.ComisionArchivo.Descripcion), 3, 400,
                                    New With
                                    {
                                        .id = "iIdDescripcion",
                                        .style = "text-transform:uppercase; padding:10px;",
                                        .maxLength = "1200"
                                    })  
                        <div class="clear"></div>  
                        <div style="display: block;  width: 100%;" id="valid-Descripcion">
                             <span id="iIdDescripcion" class="error"></span>
                        </div>    
                    </div>
                </div>
            </div>
            <div class="formRow noBorderB fluid">
                <div class="grid12">
                    <div class="grid3">             
                        <label>Adjuntar Archivo :</label>
                    </div>
                    <div class="grid9"> 
                        <div id="divIdFileSelect">
                                @Html.TextBoxFor(Function(m) (m.FileAttached.File),
                                    New With {
                                        .id = "IdFileUpload",
                                        .class = "ignore",
                                        .type = "file"
                                    })
                        </div>
                        <div class="clear"></div>  
                        <div style="display: block;  width: 100%;" id="valid-Archivo">
                             <span id="iIdArchivo" class="error"></span>
                        </div>  
                        <div id="ContainerFrame" style="height: 1px;">
                            <iframe id="UploadTarget" name="UploadTarget" onload="return UploadImage_Complete();"
                                                 onerror="return UploadImage_Error();" class="frameGalery" style="width:100%;height:100%;">
                            </iframe> 
                        </div>
                    </div>
                </div>
            </div>
            <div class="formRow noBorderB fluid">
                <div class="grid12">
                    <div class="grid3">             
                        <label>Aprobado por :</label>
                    </div>
                    <div class="grid9"> 
                        @Html.TextBoxFor(Function(m) (m.ComisionArchivo.AprobadoPor),
                                    New With {
                                        .id = "IdTxtAprobadoPor",
                                        .class = "textinput",
                                        .style = "text-transform:uppercase; width: 253px; ",
                                        .onkeypress = "return val_AZ(event)"
                                    })  
                        <div class="formSubmit">
                            <input id="btncancelar2" class="buttonM bBlue ml10 ui-wizard-content" type="button" style="float: right; margin-right: 10px;" value="Cancelar"/>
                            <input id="iIdBtnGuardarAdjunto" class="buttonM bBlue ml10 ui-wizard-content" type="button" style="float: right; margin-right: 10px;" value="Guardar"/>                   
                        </div>
                        <div class="clear"></div>  
                        <div style="display: block;  width: 100%;" id="valid-Aprobado">
                             <span id="iIdAprobado" class="error"></span>
                        </div>   
                    </div>
                </div>
            </div>
            
        </div>
        <div class="widget">
            <div class="whead">
                    <h6>Listado de Archivos</h6>
                <div class="clear">
                </div>
            </div>
            <div id="Id_Listado_Mes_Condicional">
                @Html.Partial(ParametrosPartialView._ListaAdjuntoComisionales, Model)
            </div>
        </div>
    </div>
</div>

<script type="text/javascript">
    $(window).load(function () {
        BuscarPeriodoComisional();
    });
</script>
