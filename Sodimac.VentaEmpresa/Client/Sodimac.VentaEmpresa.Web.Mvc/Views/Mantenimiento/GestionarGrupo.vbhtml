@ModelType Sodimac.VentaEmpresa.Web.Mvc.MantenimientoViewModel
@Imports Sodimac.VentaEmpresa.Web.Mvc.ParametrosView
@Code
    ViewData("Title") = "Gestionar Grupo"
End Code
@Using (Html.BeginForm("GestionarGrupo_", "Mantenimiento", FormMethod.Post, New With {.id = "frmGestionarGrupo", .onload = "BuscarClientes_Grupo()"}))
    @Html.AntiForgeryToken
  @<div id="ID_CopiarCurso">
   @Html.Hidden("PagePreview", 1) 
    <div class="wrapper">
        <div class="form">
            <fieldset> 
                <div class="widget fluid" id="divDefinicion" />
                    <div class="whead"><h6>Definición del Grupo</h6>               
                        <div class="clear"> </div>
                    </div> 
                    @Html.HiddenFor(Function(m) m.Grupo.IdGrupo, New With {.id = "HD_IdGrupo"})  
                    <div class="formRow fluid">
                        <div class="grid12">
                             <div class="grid4" style="padding-top:-30px"><label>Grupo :<span class="req">*</span></label></div>
                              <div class="grid8">                              
                                     @Html.TextBoxFor(Function(m) m.Grupo.NombreGrupo,
                                             New With {
                                                   .id = "NombreGrupo",
                                                   .onkeypress = "return val_AZ(event)",
                                                   .maxLength = "50",
                                                   .class = "textinput",
                                                   .style = "text-transform:uppercase;"
                                             }) 
                                    @* @Html.ValidationMessageFor(Function(m) m.Grupo.NombreGrupo, "", New With {.class = "reqizq"})*@
                                     <div id="validaNomGrupo">
                                    <span class="reqizq">   </span>
                                </div>
                                   
                    </div>
                        </div>
                    </div>
                    <div class="formRow fluid">
                        <div class="grid12">
                            <div class="grid4">
                                <label class="form-label">
                                    Clientes: <span class="req">*</span></label>
                            </div>
                            <div class="grid8">
                                <div class="chosen-container chosen-container-multi" style="width: 100%;" title="" id="id_clientes_chosen">
                                    <ul class="chosen-choices" id="chosen-choices">
                                    <li id="lidefault"><span>&nbsp;</span>
                                    </li>
                                    </ul>
                                </div>
                                <div id="validaClient">
                                    <span class="reqizq">   </span>
                                </div>
                            </div>
                        </div>
                    </div>   
                    <div class="formRow fluid">
                        <div class="grid12">
                            <div class="grid4">
                                <label class="form-label">
                                    Razón Social / RUC:</label>
                            </div>
                            <div class="grid8">
                                @Html.TextBoxFor(Function(x) x.GrupoClienteMantenimiento.ClienteVenta.RazonSocial,
                                New With {
                                    .id = "ID_RazonSocial",
                                    .style = "text-transform: uppercase;",
                                    .onkeypress = "EnterSubmitF(event,'BuscarClientes_Grupo');"
                                })                              
                            </div>
                        </div>
                        </div>                     
                    <div class="formRow fluid">
                        <div class="grid12">
                            <div class="grid9">
                             @If Model.ListaClientesSeleccionadas.Count > 0 Then
                                 Dim ids As New List(Of Integer)()
                                 @<select id="ID_Clientes" multiple="multiple" style="display:none">                                
                                       @For Each item In Model.ListaClientesSeleccionadas
                                               ids.Add(item.IdCliente)
                                       Next
                                        @For Each item In Model.ListaClienteVenta 
                                                    Dim xd As Boolean = ids.Contains(item.IdCliente )
                                                    If xd Then
                                                        Dim Control As String
                                                    Control = String.Format("<option selected={0}selected{0} value={0}" & item.IdCliente.ToString() & "{0}>" & item.RazonSocial.ToString() & "</option>", Chr(34))
                                                        @Html.Raw(Control)                                                       
                                                    Else
                                                        Dim Control As String
                                            Control = String.Format("<option value={0}" & item.IdCliente.ToString() & "{0}>" & item.RazonSocial.ToString() & "</option>", Chr(34))
                                                        @Html.Raw(Control)
                                                    End If
                                    Next
                               </select>
                             End If
                            </div>
                        </div>
                           <div id="ID_MsgClientes">
                            </div>
                    </div>

                    <div class="formRow fluid">
                        <div class="grid12">
                            @*<div class="grid3" style="padding-top:-30px"><label>Clientes :<span class="req">*</span></label></div>*@
                            @Html.Partial(ParametrosPartialView.PVListaClientes,Model)
                        </div>
                    </div>                  
                   <div class="formRow fluid">
                    <div class="formRow" style="margin-right:10px">
                        <button type="button" name="ActionCancelar" id="btnCancelar" style="cursor:pointer" class="buttonS bBlue formSubmit group_button" onclick="DialogCancelarRegistroGrupo();" >Cancelar</button>
                        <button type="button" name="ActionAgregar" id="btnAgregarA" style="cursor:pointer" class="buttonS bBlue formSubmit group_button " onclick="RegistrarGrupo();" >Guardar</button>
                       @* <button type="button" name="ActionGrabar" id="btnBuscarCliente" style="cursor: pointer" class="buttonS bBlue formSubmit group_button" onclick="BuscarClientes_Grupo();" >Buscar</button>*@
                        <br class="clear"/> 
                        <div class="clear"></div>
                    </div>
             </div>
            </fieldset>
        </div>
    </div>

    <div id="dialogRegistrarGrupo" title="Mensaje de Confirmación">
       <p>¿Desea guardar el registro?</p>
     </div>
     <div id="dialogActualizarGrupo" title="Mensaje de Confirmación">
       <p>¿Desea actualizar el registro?</p>
     </div>
 </div>
@Html.Hidden("HdnUrlClienteGrupo", Url.Action("PVListaClientes", "Mantenimiento"))
@<script type="text/javascript">
     var checksClientes = [];
     InicioJPopUp("#dialogGestionarGrupo", 500, 350, false, "Gestionar Grupo");
     InicioJPopUpConfirm("#dialogRegistrarGrupo", 350, false, "Mensaje de Confirmación", GuardarGrupo);
     InicioJPopUpConfirm("#dialogActualizarGrupo", 350, false, "Mensaje de Confirmación", GuardarGrupo);
     $(function () {
         $.ajaxSetup({ type: "POST" });
         var ParamUrl = CreateUrl("Autocompletado_Perfil", "Mantenimiento")
         $('#NombrePerfil_AutoComplete').autocomplete(ParamUrl, {
             dataType: 'json',
             parse: function (data) {
                 var rows = new Array();
                 for (var i = 0; i < data.length; i++) {
                     rows[i] = { data: data[i], value: data[i].NombrePerfil, result: data[i].NombrePerfil, id: data[i].IdPerfil };
                 }
                 return rows;
             },
             formatItem: function (row) {
                 return row.NombrePerfil;
             },
             delay: 400,
             autofill: true,
             selectFirst: false,
             highlight: false,
             minChars: 3
             //multiple: true
         }).result(function (event, row) {
             $('#NombrePerfil_AutoComplete').val(row.NombrePerfil);
         });
     });
     //    var navegador = navigator.appName;
     //    $(function () {
     //        $("#ID_Clientes").multiselect(
     //            {
     //                selectedList: 10,
     //                noneSelectedText: '-SELECCIONE-',
     //                show: ["bounce", 200],
     //                minWidth: 280
     //            }
     //         ).multiselectfilter();
     //        $(".ui-multiselect").attr("style", "width: 280px");
     //        if (navegador == "Microsoft Internet Explorer") {
     //            $(".ui-multiselect").attr("style", "width: 250px")
     //        }
     //        $("#ui-multiselect-ID_Clientes-option-2").attr("selected", "selected");
     //    });
</script>
End Using