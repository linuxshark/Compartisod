@modeltype Sodimac.VentaEmpresa.Web.Mvc.AccountViewModel


@code
    ViewData("Title") = "Asignar Roles"
end code   
 <div class="breadLine">
        <div class="bc">
            <ul id="breadcrumbs" class="breadcrumbs">
                <li><a href="#">Seguridad</a></li>
                <li><a href="#">Agregar Rol</a></li>
                <li class="current"><a href="#" title="" ></a></li>
            </ul>
        </div>        
    </div>	

    <div class="contentTop">
        <span class="pageTitle"><span class="icon-screen" id="IdAgregarTitle"></span>Agregar Rol:</span>
        <div class="clear"></div>
    </div>     

<div id="ID_CopiarCurso">
 @Html.AntiForgeryToken()   
<div class="wrapper">
    <div class="form">
        <fieldset>
           <div class="widget fluid" id="divDefinicion">
                <div class="whead"><h6>Usuario Rol</h6>               
                <div class="clear"></div>
                </div>
    
            <div class="body">
            <div class="widget">

            <div class="formRow">
                <label class="form-label" style="text-align:right;margin-left:40%">Rol :</label> 
                    <div class="formleft" style="margin-left:30%">
                        @If (Not Model.ListaRoles Is Nothing) Then    
                           @Html.DropDownListFor(Function(m) m.Rol.IdRol,
                               New SelectList(Model.ListaRoles, "IdRol", "NombreRol"),
                            "- SELECCIONE -", New With
                            {
                               .id = "cboIdRol"
                            })
                        End If
                        
                    </div>

                <div class="clear"></div>
            </div>
            </div>

            <div class="leftPart">
                    <div class="filter"><span>Filtro: </span>              
                    @Html.TextBox("txtFiltro", "", New With {.id = "box1Filter", .class = "boxFilter upperclass", .maxlength = "30", .onkeypress = "return val_AZ(event)"})
                    <input type="button" id="box1Clear" class="fBtn" value="x" /><div class="clear"></div></div>
                    USUARIOS DEL SISTEMA
                        <div id="lstUsuarios2">                            
                            @If (Not Model.ListaUsuarios Is Nothing) Then
                           
                                @Html.DropDownListFor(Function(m) m.Usuario.IdUsu,
                                         New MultiSelectList(Model.ListaUsuarios, "IdUsu", "UsuarioUsu"),
                                    New With
                                    {
                                        .id = "box1View",
                                        .multiple = "multiple",
                                        .class = "multiple",
                                        .style = "height:300px;"
                                    })
                            Else
                             @<select id = "box1View" multiple = "multiple" class = "multiple" style = "height:300px;"></select> 
                            End If
                            
                        </div>
                        <br/>
                        <span id="box1Counter" class="countLabel"></span>                        
                        <div class="dn"><select id="box1Storage" name="box1Storage"></select></div>
            </div>

            <div class="dualControl">
                <button id="to2" type="button" class="basic mr5 mb15" title ="Agregar Usuario">&nbsp;&gt;&nbsp;</button>
                <button id="allTo2" type="button" class="basic" title ="Agregar Todos">&nbsp;&gt;&gt;&nbsp;</button><br />
                <button id="to1" type="button" class="basic mr5" title ="Quitar Usuario">&nbsp;&lt;&nbsp;</button>
                <button id="allTo1" type="button" class="basic" title ="Quitar Todos">&nbsp;&lt;&lt;&nbsp;</button>
            </div>

            <div class="rightPart">
                    <div class="filter"><span>Filtro: </span>               
                    @Html.TextBox("txtFiltro2", "", New With {.id = "box2Filter", .class = "boxFilter upperclass", .maxlength = "30", .onkeypress = "return val_AZ(event)"})
                    <input type="button" id="box2Clear" class="fBtn" value="x" /><div class="clear"></div></div>
                    USUARIOS ASIGNADOS AL ROL
                        <div id="lstUsuarios">
                            <script type="text/javascript" src="@Url.Content("~/Content/js/plugins/forms/jquery.dualListBox.js")"></script>
                            <select id = "box2View" multiple = "multiple" class = "multiple" style = "height:300px;"></select>
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
            </div>
            </div>           
        </fieldset>
    </div>
    </div>
 </div>
 </div>
    
 <input type="hidden" value="@Url.Action("VistaUsuarioRol", "Account")" id="paramUrl_Account"/>
 <div id="dialogInformacionResultado"></div>
 <script type="text/javascript" src="@Url.Content("~/Scripts/View/Usuario.js")"></script>
     <script type="text/javascript" src="@Url.Content("~/Content/js/plugins/forms/jquery.dualListBox.js")"></script>

 <script type="text/javascript">
     $(function () {
         $("#cboIdRol").live("change", function () {

             $.ajax({
                 url: $("#paramUrl_Account").val(),
                 data: { IdRol: $(this).val() },
                 type: "post",
                 success: function (data) {



                     var combos = data.toString().split('<br/>');
                     $("#lstUsuarios2").html(combos[0]);
                     $("#lstUsuarios").html(combos[1]);

                     var count1 = $("#box1View option").size();
                     var count2 = $("#box2View option").size();

                     $("#box1Counter").text('Showing ' + count1 + ' of ' + count1);

                     $("#box2Counter").text('Showing ' + count2 + ' of ' + count2);

                 }
             });
         })
     });
     $(function () {
         $("#lblNomApl").text($("#NomApl").val());
     });

     function UpdateLabel(group) {
         var showingCount = $("#" + group.view + " option").size();
         var hiddenCount = $("#" + group.storage + " option").size();
         $("#" + group.counter).text('Showing ' + showingCount + ' of ' + (showingCount + hiddenCount));
     }
 </script>
