@ModelType Sodimac.VentaEmpresa.Web.Mvc.VentasViewModel 
@Code
    ViewData("Title") = "Mapa del Sitio"
End Code

<style type="text/css">
#sitemap li {float: left; width: 125px;}
#sitemap li a{ font-weight: bold;padding-right:5px;}
#sitemap ul li a{background:red font-size: 10px; font-weight: normal; color:black}
#sitemap ul li a:hover{color:red!important}
/*ul#menu > li{
    float:left;
    margin:1em;
    min-height:160px;padding:10px}*/
    
.site{background:red}
</style>
<script type="text/javascript" src="/Scripts/View/Vendedor.js"></script>
<div class="breadLine">
    <div class="bc">
        <ul id="breadcrumbs" class="breadcrumbs">
            <li><a href="#">Inicio</a> </li>
            <li><a href="#">Mapa Sitio</a> </li>
            <li class="current"><a title="" href="#">Mapa del Sitio</a> </li>
        </ul>
    </div>
</div>
<div class="contentTop">
    <span class="pageTitle"><span id="IdAgregarTitle" class="icon-screen"></span>Mapa del Sitio
     </span>
    <div class="clear">
    </div>
</div>

<div class="wrapper">
    <div class="main">
        <fieldset>
            <div class="widget fluid">
                <div class="whead">
                    <h6>
                        Mapa</h6>
                    <div class="clear">
                    </div>
                </div>
            <div class="formRow fluid" id="MapaSitio">                    
                        @Html.MvcSiteMap("SodimacSiteMapProvider").Menu(False, True, False)
                        <div class="clear">
                        </div>
                   </div>
            </div>
            
        </fieldset>
    </div>

</div>

<script type="text/javascript">
    $("#MapaSitio ul").attr("id", "sitemap");

</script>


