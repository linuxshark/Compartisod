@ModelType Sodimac.VentaEmpresa.Web.Mvc.AutorizacionesViewModel
@Imports Sodimac.VentaEmpresa.Web.Mvc.ParametrosView

@Code
    ViewData("Title") = "Autorización de Asignaciones"
End Code
@Html.Hidden("Url_Consultar_Contado", Url.Action("BuscarContado", "Autorizacion"))
@Html.Hidden("Url_Consultar_Credito", Url.Action("BuscarCredito", "Autorizacion"))
@Html.Hidden("Url_Autorizar_Cliente", Url.Action("AsignarCliente", "Autorizacion"))

<script type="text/javascript" src="/Scripts/View/Autorizaciones.js"></script>
<div class="breadLine">
    <div class="bc">
        <ul id="breadcrumbs" class="breadcrumbs">
            <li><a href="#">Inicio</a></li>
            <li><a href="#">Autorizaciones</a></li>
            <li class="current"><a href="#" title="">Asignaciones</a></li>
        </ul>
    </div>
</div>
<div class="contentTop">
    <span class="pageTitle"><span id="IdAgregarTitle" class="icon-screen"></span>Autorización de Asignaciones</span>
    <div class="clear">
    </div>
</div>
@Html.AntiForgeryToken()
<div class="wrapper">
    <div class="main">
        <div class="form">
            <fieldset>

             <div class="widget fluid first_widget">
                    <div class="whead">
                        <h6>Criterios de Búsqueda</h6>
                        <div class="clear">
                        </div>
                    </div>
                  
                    <div class="formRow fluid">
                    <div class="grid6">
                            <div class="grid3">
                              <label class="form-label" > Razón Social / RUC:</label>
                            </div> 
                          <div class="grid6">
                        @Html.TextBoxFor(Function(x) x.ClienteVenta.RazonSocial,
                                New With {
                                    .onkeypress = "EnterSubmit(event,'btnBuscarAsignacion'); return validarNumerosLetrasV2(event)",
                                    .id = "ID_RazonSocial_RUC"
                                })
                       
                      
                          </div>     
                               
                    </div> 


                    <div class="grid6">
                            <div class="grid3">
                            <label class="form-label" > Motivo:</label>
                            </div>

                            <div class="grid6">
                         @Html.DropDownListFor(Function(m) m.ListaMotivo,
                               New SelectList(Model.ListaMotivo, "IdMotivo", "Descripcion"),
                               "-TODOS- ",
                                       New With {
                                                .id = "ID_Motivo",
                                                .class = "textinput selector"
                                           })
                            </div>
                            
                    </div>
                        
                    </div>  
                     

                     <div class="formRow fluid">
                     
                      <div class="grid6">
                            <div class="grid3">
                              <label class="form-label" > RRVV:</label>
                            </div> 
                          <div class="grid6">
                        @Html.TextBoxFor(Function(x) x.Empleado.NombresApellidos2,
                                New With {
                                    .onkeypress = "EnterSubmit(event,'btnBuscarAsignacion'); return val_AZ(event)",
                                    .id = "RRVV_NombreEmpleado"
                                })
                       

                          </div>     
                               
                    </div> 

                     </div>

                     <div class="formRow noBorderB">
                        <button type="button" name="ActionBuscarAsignacion" id="btnBuscarAsignacion" style="cursor:pointer" onclick=" return Buscar_Filto_Asignaciones();"; class="buttonS bBlue formSubmit group_button" >
                            Buscar </button>
                        <div class="clear">
                        </div>
                    </div>

                     
@* 
                    <div class="formRow noBorderB">
                        <button type="button" name="ActionAutContado" id="btnAutContado" style="cursor:pointer" onclick="return Asignar(2);" class="buttonS bBlue formSubmit group_button" >
                            Autorizar Contado</button>
                        <div class="clear">
                        </div>
                    </div>*@
                    <div class="clear">
                    </div>
                </div>


                <div class="widget fluid first_widget">
                    <div class="whead">
                        <h6>Cliente Contado</h6>
                        <span style="float:right; margin:6px 60px 0px 0px; font-weight: bold ; font-size: 11px; color: #292929;"> <label   id="lblCheckAll"> Marcar Todos </label> <input onclick="return ChecksAll();" id="CheckAll" type="checkbox" value="true" name="AllChecks" style="float:right; margin :5px 0px 0px 5px;" > </span>
                        
                        <div class="clear"> 
                        </div>
                    </div>
                    @Html.Hidden("Contado_PagePreview", 1)
                    <div id="div_grilla_Contado">
                        
                    </div>
                    <div class="formRow noBorderB">
                        <button type="button" name="ActionAutContado" id="btnAutContado" style="cursor:pointer" onclick="return Asignar(2);" class="buttonS bBlue formSubmit group_button" >
                            Autorizar Contado</button>
                        <div class="clear">
                        </div>
                    </div>
                    <div class="clear">
                    </div>
                </div>

                <div class="widget">
                    <div class="whead">
                        <h6>Cliente Credito</h6>
                        <span style="float:right; margin:6px 60px 0px 0px; font-weight: bold ; font-size: 11px; color: #292929;"> <label   id="lblCheckAll2"> Marcar Todos </label> <input onclick="return ChecksAll2();" id="CheckAll2" type="checkbox" value="true" name="AllChecks" style="float:right; margin :5px 0px 0px 5px;" > </span>
                        <div class="clear">
                        </div>
                    </div>
                    @Html.Hidden("Credito_PagePreview", 1)
                    <div id="div_grilla_Credito">
                        
                    </div>
                    <div class="formRow noBorderB">
                        <button type="button" name="ActionAutCredito" id="btnAutCredito" style="cursor:pointer" onclick="return Asignar(1);" class="buttonS bBlue formSubmit group_button" >
                            Autorizar Credito</button>
                        <div class="clear">
                        </div>
                    </div>
                    <div class="clear">
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
    $(window).load(function () {
        BuscarContado();
        BuscarCredito();
//        MemoryChecks('Contado',1,true);
//        MemoryChecks('Credito',1,true);
    });
    

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
                    case 'credito':
                        AsignarAutorizacion(1, "grilla_Credito");
                        break;
                    case 'contado':
                        AsignarAutorizacion(2, "grilla_Contado");
                        break;
                    default:
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
                $("#mensajeResultado").dialog("close");
            }
        }
    });
</script>
