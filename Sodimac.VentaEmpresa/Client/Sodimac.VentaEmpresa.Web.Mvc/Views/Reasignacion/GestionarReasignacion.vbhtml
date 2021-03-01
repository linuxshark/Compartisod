@ModelType Sodimac.VentaEmpresa.Web.Mvc.ClientesViewModel
@Imports Sodimac.VentaEmpresa.Web.Mvc.ParametrosView
@Code
    ViewData("Title") = "Reasignación de Clientes VVEE"
End Code
@Html.Hidden("UrlVendedor", Url.Action("PVVendedorPorSucursal", "Cliente"))  
    <!-- Breadcrumbs line -->
    <div class="breadLine">
        <div class="bc">
            <ul id="breadcrumbs" class="breadcrumbs">
                <li><a href="#">Inicio</a></li>
                <li><a href="#">Mantenedor</a></li>
                <li class="current"><a href="#" title="">Reasignar cliente</a></li>
            </ul>
        </div>        
    </div>
      <div class="contentTop">
        <span class="pageTitle"><span class="icon-screen" id="IdAgregarTitle"></span>Reasignar Clientes VVEE :</span>
        <div class="clear"></div>
    </div>

<div class="wrapper">
    <div class="form">
        <fieldset>
            <div class="widget fluid" id="divDefinicion">
              <div class="whead"><h6>Reasignación Clientes</h6>               
                <div class="clear"></div>
                </div>
                <div class="body">
                <div class="widget">

                <div class="formRow fluid">
                    <div class="grid6">
                        <div class="grid3">
                            <label class="form-label" style="text-align:left;margin-left:40%">Sucursal :</label> 
                        </div>
                        <div class="grid4" style="margin-left:10%">
                        @Html.DropDownListFor(Function(m) m.Sucursal.IdSucursal,
                                               New SelectList(Model.ListaSucursal, "IdSucursal", "Descripcion"),
                                               "-SELECCIONE-",
                                               New With {
                                                        .id = "ID_IdSucursal",
                                                        .onchange= "CargarVendedorporSucursal();",
                                                        .class="selector"
                                                   }
                                              )  
                        </div>

                    </div>

                     <div class="grid6">
                        <div class="grid3">
                            <label class="form-label" style="text-align:rigth;margin-left:30%">Sucursal :</label> 
                        </div>
                       <div class="grid6" style="margin-left:10%">
                        @Html.DropDownListFor(Function(m) m.Sucursal.IdSucursal,
                                               New SelectList(Model.ListaSucursal, "IdSucursal", "Descripcion"),
                                               "-SELECCIONE-",
                                               New With {
                                                        .id = "ID_IdSucursaless"
                                                   }
                                              )  
                       </div>
                     </div>
                </div>
            <div class="formRow fluid">
                    <div class="grid6">
                        <div class="grid3">
                            <label class="form-label" style="text-align:left;margin-left:40%">Vendedor :</label> 
                        </div>
                        <div class="grid4" style="margin-left:10%" id="divListaVendedorInactivo">
                            @Html.Partial(ParametrosPartialView.PVVendedor_Sucursal, Model)  
                       @* @Html.DropDownListFor(Function(m) m.Sucursal.IdSucursal,
                                               New SelectList(Model.ListaSucursal, "IdSucursal", "Descripcion"),
                                               "-SELECCIONE-",
                                               New With {
                                                        .id = "ID_IdSucursal"
                                                   }
                                              )  *@
                        </div>

                    </div>

                     <div class="grid6">
                        <div class="grid3">
                            <label class="form-label" style="text-align:rigth;margin-left:30%">Vendedor :</label> 
                        </div>
                       <div class="grid6" style="margin-left:10%" id="divListaVendedorActivo">
                           @* @Html.Partial(ParametrosPartialView.PVVendedor_Sucursal, Model)  *@
                       </div>
                     </div>
                </div>
                 

                 <div class="leftPart">
                 @*   <div class="filter"><span>Filtro: </span>              
                    @Html.TextBox("txtFiltro", "", New With {.id = "box1Filter", .class = "boxFilter upperclass", .maxlength = "30", .onkeypress = "return val_AZ(event)"})
                    <input type="button" id="box1Clear" class="fBtn" value="x" /><div class="clear"></div></div>*@
                    CLIENTE NO ASIGNADOS
                        <div id="lstUsuarios2">                            
                            @If (Not Model.ListaVentaCartera  Is Nothing) Then
                           
                                @Html.DropDownListFor(Function(m) m.VentaCartera.IdCartera ,
                                         New MultiSelectList(Model.ListaVentaCartera , "IdUsu", "UsuarioUsu"),
                                    New With
                                    {
                                        .id = "box1View",
                                        .multiple = "multiple",
                                        .class = "multiple",
                                        .style = "height:300px;"
                                    })
                            Else
                             @<select id = "box1View" multiple = "multiple" class = "multiple" style = "height:200px;"></select> 
                            End If
                            
                        </div>
                        <br/>
                        <span id="box1Counter" class="countLabel"></span>                        
                        <div class="dn"><select id="box1Storage" name="box1Storage"></select></div>
            </div>

             
        

            <div class="dualControl">
                <button id="to2" type="button" class="basic mr5 mb15" title ="Agregar Usuario">&nbsp;&gt;&nbsp;</button>
                <br />
                <button id="allTo2" type="button" class="basic" title ="Agregar Todos">&nbsp;&gt;&gt;&nbsp;</button>

            </div>

            <div class="rightPart">
                    @*<div class="filter"><span>Filtro: </span>               
                    @Html.TextBox("txtFiltro2", "", New With {.id = "box2Filter", .class = "boxFilter upperclass", .maxlength = "30", .onkeypress = "return val_AZ(event)"})
                    <input type="button" id="box2Clear" class="fBtn" value="x" /><div class="clear"></div></div>*@
                    CLIENTES ASIGNADOS AL VENDEDOR
                        <div id="lstUsuarios">
                            <script type="text/javascript" src="@Url.Content("~/Content/js/plugins/forms/jquery.dualListBox.js")"></script>
                            <select id = "box2View" multiple = "multiple" class = "multiple" style = "height:200px;"></select>
                            <br/>
                        </div>
                        <br/>
                        <span id="box2Counter" class="countLabel"></span>                        
                        <div class="dn"><select id="box2Storage" name="box1Storage"></select></div>                        
                        <div class="clear"></div>
            </div>
             <div class="clear"></div>
            <div class="formRow">
                <button type="button" name="ActionAgregar" id="btnAsignar" style="cursor:pointer" class="buttonS bBlue formSubmit group_button " onclick="AsignarRolUsu('@Url.Action("AsignarUsuarioRol", "Account")');" >Asignar</button>
                <br class="clear"/> 
                <div class="clear"></div>
            </div>

                <div class="formRow fluid">
                    
                
                </div>


</div>
            </div> 
            </div>
        </fieldset>
    </div>
</div>
      


  

   

      @Html.Hidden("IdUrl_RolDestino", Url.Action("ConsultarRol_PVGrilla", "Account"))

    <script type="text/javascript" src="@Url.Content("~/Scripts/View/Rol.js")"></script>

    <script type="text/javascript" language="javascript">
        $(window).load(function () {
            BuscarRol('@Url.Action("ConsultarRol_PVGrilla", "Account")')
        });
    </script>
