@ModelType Sodimac.VentaEmpresa.Web.Mvc.AccountViewModel
@Code
    ViewBag.Title = "Asignar Paginas Rol"
End Code

    <!-- Breadcrumbs line -->
    <div class="breadLine">  
        <div class="bc">
            <ul id="breadcrumbs" class="breadcrumbs">
                <li><a href="#">Seguridad</a></li>
                <li><a href="#">Asignar Paginas Rol</a></li>
                <li class="current"><a href="#" title="" ></a></li>
            </ul>
        </div>        
    </div>	

    <div class="contentTop">
        <span class="pageTitle"><span class="icon-screen" id="IdAgregarTitle"></span>Asignar Rol:</span>
        <div class="clear"></div>
    </div>     
<!--end titulo -->

<div id="EditarMen"></div>
<div id="ID_CopiarCurso">
@Html.AntiForgeryToken()    
<div class="wrapper">
    <div class="form" style="overflow:auto">
        <fieldset>
           <div class="widget fluid" id="divDefinicion">
                <div class="whead">
                    <h6>Asignación de Roles</h6>
                    <div class="clear"></div>
                </div>
    
            <div class="formRow fluid"> 
                    @* Aqui va la lista de paginas *@
                    <div class="form">
                    <div class="left two_cols" style="width:30%">
                        <fieldset>
                            <div class="widget">
                                <div class="whead">
                                    <h6>Menú de Paginas</h6>
                                    <div class="clear"></div>
                                </div>
                                <div class="formRow" style="min-height: 364px">
                                        @Html.Partial("loadTreeView", Model)
                                    <div class="clear"></div>
                                </div>

                            </div>
                    </fieldset>
                    </div>
                    </div>
                    @* Fin de lista de paginas *@

                    <div class="form">
                    <div class="right two_cols" style="width:68%">
                        <fieldset>
                            <div class="widget">
                                <div class="whead">
                                    <h6>Asignar Roles<label id="nomMenuSel"></label></h6>
                                    <div class="clear"></div>
                                </div>

                                <div id="DivRoles" style="">
                                   <span style="margin-left:7px;">Debe seleccionar un Menú de la Aplicación</span>
                                </div>
                            </div>
                        </fieldset>
                    </div>
@*
                     <div class="right two_cols" style="width:68%">
                        <fieldset>
                            <div class="widget">
                                <div class="whead">
                                    <h6>Asignar Zona y Sucursal <label id="nomMenuSel_Zona_Sucursal"></label></h6>
                                    <div class="clear"></div>
                                </div>

                                <div id="DivZona_Sucursal" style="">
                                   <span style="margin-left:7px;">Debe seleccionar una Zona o Sucursal de la Aplicación</span>
                                </div>
                            </div>
                        </fieldset>
                    </div>
*@
                    </div>
                    <div class="clear"></div>
                </div>
                <div class="formRow">
                    <input id="IdPagina" type="hidden"  value="" />               
                    <button type="button" name="ActionAgregar" id="btnAsignar" style="cursor:pointer" class="buttonS bBlue formSubmit group_button " onclick="AsignarPerfil('@Url.Action("AsignarPerfil", "Account")', '@Url.Action("AsignarPagina", "Account")')" >Asociar</button>
                    <br class="clear"/> 
                    <div class="clear"></div>
                </div>
            </div>

           
        </fieldset>
    </div>
    </div>
 </div>

     <div id="dialogInformacionResultado" title="Confirmación!">
     </div>
     <div id="dialogInformacionResultado2" title="Confirmación!">
     </div>

<script type="text/javascript" src="@Url.Content("~/Scripts/View/Rol.js")"></script>

<link href="@Url.Content("~/Content/css/treeview/jquery.treeview.css")" rel="stylesheet" type="text/css" />
<script src="@Url.Content("~/Content/js/sitemapstyler.js")" type="text/javascript"></script>
