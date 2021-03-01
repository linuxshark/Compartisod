@ModelType Sodimac.VentaEmpresa.Web.Mvc.CargaMasivaClienteViewModel

<ul class="tabs">
    <li id="lnk0" class="activeTab"><a href="#tabb1">Clientes</a> </li>
    <li id="lnk1" class=""><a href="#tabb2">Empleados Asociados</a> </li>
</ul>
<div class="wrapper">
    <div class="tab-container">
        <div id="tabb1" class="tab_content" style="display: block;">
            <div class="formRow fluid">
                <div class="widget fluid">
                    <div id="GrillaCMCliente" style="overflow:auto">
                        @Html.Partial("PV_CargaMasivaCliente", Model)
                    </div>
                </div>
            </div>
        </div>
        <div id="tabb2" class="tab_content" style="display: none;">
            <div class="formRow fluid">
                <div class="widget fluid">
                    <div id="GrillaCMClienteEmpleado" style="overflow:auto">
                        @Html.Partial("PV_CargaMasivaClienteEmpleado", Model)
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>


@*<script>
    $(function(){ 
	
        $(this).find(".tab_content").hide(); //Hide all content
        $(this).find("ul.tabs li:first").addClass("activeTab").show(); //Activate first tab
        $(this).find(".tab_content:first").show(); //Show first tab content
	
        $("ul.tabs li").click(function() {
            $(this).parent().parent().find("ul.tabs li").removeClass("activeTab"); //Remove any "active" class
            $(this).addClass("activeTab"); //Add "active" class to selected tab
            $(this).parent().parent().find(".tab_content").hide(); //Hide all tab content
            var activeTab = $(this).find("a").attr("href"); //Find the rel attribute value to identify the active tab + content
            $(activeTab).show(); //Fade in the active content
            return false;
        });
	
    })

</script>*@