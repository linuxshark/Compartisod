@ModelType Sodimac.VentaEmpresa.Web.Mvc.AutorizacionesViewModel
@Imports Sodimac.VentaEmpresa.Web.Mvc.ParametrosView

@Code
    ViewData("Title") = "Consultar Autorización de Asignación"
End Code
 @Html.Hidden("Url_Consultar_Contado", Url.Action("BuscarContado2", "Autorizacion"))
<script type="text/javascript" src="/Scripts/View/Autorizaciones.js"></script>
<div class="breadLine">
    <div class="bc"> 
        <ul id="breadcrumbs" class="breadcrumbs">
            <li><a href="#">Inicio</a></li> 
            <li><a href="#">Autorizaciones</a></li>
            <li class="current"><a href="#" title="">Consultar Asignaciones</a></li>
        </ul>
    </div>
</div>

<div class="contentTop"> 
    <span class="pageTitle"><span id="IdAgregarTitle" class="icon-screen"></span>Consultar Autorización de Asignaciones</span>
    <div class="clear">
    </div>
</div>
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
                                    .onkeypress = "EnterSubmit(event,'btnBuscarAsignacion')",
                                    .id = "ID_RazonSocial_RUC"
                                })
                       
                       @*.onkeypress = "EnterSubmit(event,'btnBuscarAsignacion'); return val_AZ(event)",*@ 
                          </div>    
                               
                    </div> 


                    <div class="grid6">
                            <div class="grid3">
                            <label class="form-label" > Motivo:</label>
                            </div>

                            <div class="grid6">
                         @Html.DropDownListFor(Function(m) m.ListaMotivo,
                               New SelectList(Model.ListaMotivo, "IdMotivo", "Descripcion"),
                               "-TODOS-",
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


                       <div class="grid6">
                            <div class="grid3">
                              <label class="form-label" > Modo Pago:</label>
                            </div> 
                          <div class="grid6">
                      @Html.DropDownListFor(Function(m) m.ListaModoPago,
                               New SelectList(Model.ListaModoPago, "IdModoPago", "Descripcion"),
                               "-TODOS-",
                                       New With {
                                                .id = "ID_ModoPago",
                                                .class = "textinput selector"
                                           })
                       

                          </div>     
                               

                    </div> 

                     </div>
                     
                     <div class="formRow noBorderB">
                        <button type="button" name="ActionBuscarAsignacion" id="btnBuscarAsignacion" style="cursor:pointer" onclick=" return ConsultaAsignacionContado_Credito();"; class="buttonS bBlue formSubmit group_button" >
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
                        <h6>Clientes</h6>
                        
                        
                        <div class="clear">
                        </div>
                    </div>
                    @Html.Hidden("Contado_PagePreview", 1)
                    <div id="div_grilla_Contado">
                        
                    </div>
                    <div class="formRow noBorderB">
                
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

<script type="text/javascript" language="javascript">
    $(window).load(function () {
        ConsultaAsignacionContado_Credito();


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
