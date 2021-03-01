@ModelType Sodimac.VentaEmpresa.Web.Mvc.VentasViewModel
@Imports Sodimac.VentaEmpresa.Web.Mvc.ParametrosView
@Code
    If Model.Empleado.IdEmpleado = 0 Then
        ViewData("Title") = "Nuevo Empleado"
    Else
        ViewData("Title") = "Detalle Empleado"
    End If
End Code
<div class="breadLine">
    <div class="bc">
        <ul id="breadcrumbs" class="breadcrumbs">
            <li><a href="#">Inicio</a></li>
            <li><a href="#">Mantenedor</a></li>
            @If Model.Empleado.IdEmpleado = 0 Then
                @<li class="current"><a href="#" title="">Nuevo Empleado</a></li>
            Else
                @<li class="current"><a href="#" title="">Detalle Empleado</a></li>
            End If
        </ul>
    </div>
</div>
<div class="contentTop">
    @If Model.Empleado.IdEmpleado = 0 Then
        @<span class="pageTitle"><span id="IdAgregarTitle" class="icon-screen"></span>Nuevo
            Empleado</span>
    Else
        @<span class="pageTitle"><span id="IdAgregarTitle" class="icon-screen"></span>Detalle
            Empleado</span>
    End If
    <div class="clear">
    </div>
</div>
@Using (Html.BeginForm("RegistrarEmpleado", "Ventas", FormMethod.Post, New With {.id = "frmRegistrarEmpleado", .onsubmit = "return false;"}))
    @Html.AntiForgeryToken
    @<div class="wrapper">
        <div class="form">
            <fieldset>
                <div class="widget fluid">
             <div  id="oculto" style="z-index:100">
                    <ul class="tabs" id="idtabsul">
                        <li id="TABC" class="activeTab"><a href="#tabb1">Gestionar Empleado</a> </li>
                       
                        @Code
                        If Model.Empleado.IdEmpleado <> 0 Then
                        End Code
                        <li id="tabb2"><a href="#tabb2Sucur">Trabajo Sucursal</a> </li>
                        @code
                            If Model.Empleado.Perfil.TipoPerfil = 1 Then
                        End Code
                         <li id="tabb3"><a href="#tabb3plan">Plan de Ventas</a></li>
                         @code
                             End If
                         End Code
                        @Code
                        End If
                       
                        End Code                       
                         
                    </ul>
                  

                    <div class="wrapper">
                        <div class="tab_container" id="idcontainer1">
                            <div id="tabb1" class="tab_content" style="display: block;">
                                <div class="widget fluid">
                                    <div class="whead">
                                        <h6>
                                            Datos Generales</h6>
                                        <div class="clear">
                                        </div>
                                    </div>
                                    <div class="formRow fluid">
                                        <div class="grid6">
                                            <div class="grid3">
                                                <label class="form-label">
                                                    Nombres:<span class="req">*</span></label>
                                            </div>
                                            
                                            <div class="grid6">
                                            @Html.HiddenFor(Function(m) m.Estado.IdEstado, New With {.id = "IdEstado"})  
                                                @Html.TextBoxFor(Function(x) x.Empleado.Nombres,
                                                New With {
                                                    .id = "Nombres",
                                                    .onkeypress = "return val_AZ(event)",
                                                    .maxLength = "40",
                                                    .class = "textinput"
                                                })
                                                <div class="clear">
                                                </div>
                                                @Html.ValidationMessageFor(Function(x) x.Empleado.Nombres, "", New With {.class = "reqizq"})
                                            </div>
                                        </div>
                                        <div class="grid6">
                                            <div class="grid3">
                                                <label class="form-label">
                                                    Apellidos:<span class="req">*</span></label>
                                            </div>
                                            <div class="grid6">
                                                @Html.TextBoxFor(Function(x) x.Empleado.Apellidos,
                                                New With {
                                                    .id = "Apellidos",
                                                    .onkeypress = "return val_AZ(event)",
                                                    .maxLength = "40",
                                                    .class = "textinput"
                                                })
                                                <div class="clear">
                                                </div>
                                                @Html.ValidationMessageFor(Function(x) x.Empleado.Apellidos, "", New With {.class = "reqizq"})
                                            </div>
                                        </div>
                                        <div class="clear">
                                        </div>
                                    </div>
                                    <div class="formRow fluid">
                                        <div class="grid6">
                                            <div class="grid3">
                                                <label class="form-label">
                                                    DNI:<span class="req">*</span></label>
                                            </div>
                                            <div class="grid9">
                                                <div class="grid4">
                                                    @Html.TextBoxFor(Function(x) x.Empleado.DNI,
                                                    New With {
                                                        .id = "DNI",
                                                        .onkeypress = "return val_09(event)",
                                                        .onpaste = "return false;",
                                                        .maxLength = "8",
                                                        .class = "textinput"
                                                    })
                                                </div>
                                                <div class="clear">
                                                </div>
                                                @Html.ValidationMessageFor(Function(x) x.Empleado.DNI, "", New With {.class = "reqizq"})
                                            </div>
                                        </div>
                                        <div class="grid6">
                                            <div class="grid3">
                                                <label class="form-label">
                                                    Código Ofisis:<span class="req">*</span></label>
                                            </div>
                                            <div class="grid9">
                                                <div class="grid4">
                                                    @Html.TextBoxFor(Function(x) x.Empleado.CodigoOfisis,
                                                    New With {
                                                        .id = "CodigoOfisis",
                                                        .onkeypress = "return val_09(event)",
                                                        .onpaste = "return false;",
                                                        .maxLength = "13",
                                                        .class = "textinput"
                                                    })
                                                </div>
                                                <div class="clear">
                                                </div>
                                                @Html.ValidationMessageFor(Function(x) x.Empleado.CodigoOfisis, "", New With {.class = "reqizq"})
                                            </div>
                                        </div>
                                    </div>
                                    <div class="formRow fluid">
                                        <div class="grid6">
                                            <div class="grid3">
                                                <label class="form-label">
                                                    Fecha de Contrato:<span class="req">*</span></label>
                                            </div>
                                            <div class="grid6">
                                                @Html.TextBoxFor(Function(x) x.Empleado.FechaContrato,
                                                New With {
                                                    .id = "ID_FechaContrato",
                                                    .class = "datepicker maskDate"
                                                })
                                                <div id="ID_MsgFechaContrato"></div>
                                                @Html.ValidationMessageFor(Function(x) x.Empleado.FechaContrato, "", New With {.class = "reqizq"})
                                            </div>
                                        </div>
                                        <div class="grid6">
                                            <div class="grid3">
                                                <label class="form-label">
                                                    Fecha Nacimiento:<span class="req">*</span></label>
                                            </div>
                                            <div class="grid6">
                                                @Html.TextBoxFor(Function(x) x.Empleado.FechaNacimiento,
                                                New With {
                                                    .id = "ID_FechaNacimiento",
                                                    .class = "datepicker maskDate"
                                                })
                                                <div id="ID_MsgFechaNacimiento"></div>
                                                @Html.ValidationMessageFor(Function(x) x.Empleado.FechaNacimiento, "", New With {.class = "reqizq"})
                                            </div>
                                        </div>
                                    </div>
                                
                                 <div class="formRow fluid">

                                   <div class="grid6">
                                            <div class="grid3">
                                                <label class="form-label">
                                                    Usuario Sistema :</label>
                                            </div>
                                            <div class="grid6">
                                                @Html.TextBoxFor(Function(x) x.Empleado.UsuarioIngreso,
                                                New With {
                                                    .id = "ID_UsuarioSistema",
                                                    .class = "textinput"
                                                })
                                                <div></div>
                                                  <div id="validaUsuarioUsu">
                                                    <span class="reqizq"> (Este campo es necesario para el ingreso al sistema) </span>
                                            </div>
                                        </div>

                                 </div>
                                 </div>

                                @Html.Partial(ParametrosPartialView.Empleado_DatosContacto_PV, Model)                              
                               <div class="formRow">
                                          <button type="button" name="ActionCancelar" id="btnCancelarA" style="cursor:pointer" class="buttonS bDefault formSubmit group_button " onclick="InicioJPopUpOpen('#dialogCancelarRegistroPersonal');">Cancelar</button>
                                      @If Model.Estado.IdEstado = Parametros.VENDEDOR_ESTADO_ID_ACTIVO Or Model.Empleado.IdEmpleado = 0 Then
                                              @<button type="button" name="ActionAgregar" id="btnAgregarA" style="cursor:pointer" class="buttonS bBlue formSubmit group_button " onclick="RegistrarVendedor();" >Guardar</button>
                                      Else
                                          @<button type="button" name="ActionAgregar" id="btnAgregarAA" style="cursor:pointer" class="buttonS bBlue formSubmit group_button " disabled="disabled" >Guardar</button>
                                      End If
                                    
                                      
                                    
                                   @* <input type="button" value="Guardar" class="buttonS bBlue formSubmit group_button"
                                        id="btnRegistrarEmpleado" style="cursor: pointer;" onclick="RegistrarVendedor();" />*@
                                  @*  @Code
                                        If Model.ProcesoEstado.IdEstado = Parametros.VENDEDOR_ESTADO_ID_ACTIVO Then
                                    End Code*@
                                          @CODE
                                             If Model.Empleado.IdEmpleado <> 0 Then   
                                           End Code 
                                            @code
                                                 If Model.Estado.IdEstado = Parametros.VENDEDOR_ESTADO_ID_ACTIVO Then
                                            End Code
                                          <button type="button" onclick = "ValidaEmpleadoActivoCartera();" class="buttonS
                                             bBlue formSubmit group_button" style="cursor: pointer;"> Desactivar </button>   
                                             @code
                                                 '<button type="button" onclick = "InicioJPopUpOpen('#dialogEliminarRegistroPersonal');"
                                             Else
                                             End Code    
                                                <button type="button" onclick = "ValidaEmpleadoActivoCartera();"
                                                class="buttonS bBlue formSubmit group_button" style="cursor: pointer;"> Activar
                                                </button>         
                                              @code
                                           End If
                                           End Code      
                                          @code 
                                        Else        
                                           End Code
                                                      
                                          @code 
                                          End If
                                        End Code
                                    <div class="clear">
                                    </div>
                                </div>
                            </div>
                                                       
                        </div>
                            @Code
                                If Model.Empleado.IdEmpleado <> 0 Then
                            End Code
                            <div id="tabb2Sucur" class="tab_content" style="display: none;">
                                @Html.Partial(ParametrosPartialView.Empleado_Sucursales_PV, Model)
                            </div>
                            @code
                                If Model.Empleado.Perfil.TipoPerfil = 1 Then       
                            End Code
                            <div id="tabb3plan" class="tab_content" style="display: none">
                                @Html.Partial(ParametrosPartialView.PVHistorialPlanVentas, Model)
                            </div>
                            @code
                                End If
                            End Code
                            @Code
                            End If
                            End Code 
                    </div></div>
                </div>
            </fieldset>
        </div>
    </div>
    @Html.HiddenFor(Function(x) x.Empleado.IdEmpleado, New With {.id = "IdEmpleado"})
    @Html.HiddenFor(Function(x) x.Estado.IdEstado, New With {.id = "IdEstado_Inactivo"})
End Using
<div id="dialog-confirm" title="Confirmar">
</div>
<div id="dialog-messages" title="Confirmar">
</div>
<input type="hidden" name="urlreturn" value="@Url.Action("BuscarEmpleado_", "Ventas")" id="returnBuscarEmpleado" />
<input type="hidden" name="urlreturn2" value="@Url.Action("DesactivarEmpleado_", "Ventas")" id="returnDesactivarEmpleado" />



     <div id="dialogRegistrarPersonal" title="Mensaje de Confirmación">
       <p>¿Desea guardar el registro?</p>
     </div>
     <div id="dialogEliminarRegistroPersonalconCartera" title="Mensaje de Confirmación">
       <p>¿Desea actualizar el registro?</p>
       <p>¿Este empleado esta asociado a cartera?</p>
     </div>
     <div id="dialogEliminarRegistroPersonalsinCartera" title="Mensaje de Confirmación">
       <p>¿Desea actualizar el registro?</p>
     </div>
     <div id="dialogCancelarRegistroPersonal" title="Mensaje de Confirmación">
       <p>¿Desea cancelar el registro?</p>
     </div>

      <script type="text/javascript" src="@Url.Content("~/Scripts/View/Vendedor.js")"></script>
<script type="text/javascript" language="javascript">
    $(function () {
        var vIdEmpleado = $("#IdEmpleado").val();
        if (vIdEmpleado != 0) {
           
            BuscarSucursalPersonal();
            ObtenerPlanVentaPorIdEmpleado();
            //            $('#tabb2').attr("disabled", true);
            //            $('#tabb3').attr("disabled", true);
        }
        InicioJPopUpConfirm("#dialogRegistrarPersonal", 490, false, "Mensaje de Confirmación", GuardarVendedor);
        InicioJPopUpConfirm("#dialogCancelarRegistroPersonal", 400, false, "Mensaje de Confirmación", dialogCancelarRegistroPersonal);
        InicioJPopUpConfirm("#dialogEliminarRegistroPersonalconCartera", 400, false, "Mensaje de Confirmación", ActualizarSituacionVendedor);
        InicioJPopUpConfirm("#dialogEliminarRegistroPersonalsinCartera", 400, false, "Mensaje de Confirmación", ActualizarSituacionVendedor);


    });
</script>

<script type="text/javascript" language="javascript">
    $(function () {

        var vIdEstado = $("#IdEstado_Inactivo").val();

        if (vIdEstado == 27) {

            $(function () {
                var $tabs = $("#oculto");
                //var $tabs = $(ul.tabs > li.noactiveTab);
                $tabs.tabs();
                $tabs.tabs("option", 'enable', [0, 1, 2]);
                $tabs.tabs("option", 'disabled', [1, 2]);
                $("#tabb1 select").prop('disabled', true);
                $("#tabb1 input").prop('disabled', true);
            });
        }
    });
    </script>
    <script type="text/javascript">


        $("ul.ui-tabs-nav").removeClass("ui-tabs-nav");
 </script>
