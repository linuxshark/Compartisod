@ModelType Sodimac.VentaEmpresa.Web.Mvc.VentasViewModel 
@Code
    ViewData("Title") = "Reproceso Ventas"
End Code



<div class="breadLine">
    <div class="bc">
        <ul id="breadcrumbs" class="breadcrumbs">
            <li><a href="#">Inicio</a> </li>
            <li><a href="#">Reproceso ventas</a> </li>
            <li class="current"><a title="" href="#">Procesar Ventas y Comisiones</a> </li>
        </ul>
    </div>
</div>
<div class="contentTop">
    <span class="pageTitle"><span id="IdAgregarTitle" class="icon-screen"></span>Procesar Ventas y Comisiones
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
                        Filtros de Búsqueda</h6>
                    <div class="clear">
                    </div>
                </div>
            <div class="formRow fluid">
                    <div class="grid12">
                        <div class="grid4">
                            <div class="grid3">
                                <label class="form-label" for="tipoPersona">
                                    Fecha Inicio:</label>
                            </div>
                            <div class="grid9">
                            @Html.TextBoxFor(Function(m) (m.ClienteVenta.FechaDesde),
                                 New With {
                                    .id = "ID_FechaInicio",
                                    .class = "textinput datepicker",
                                    .value = String.Format("{0:d}"," ")
                                 })
                                <div id="ID_MsgFechaInicio">
                                </div>
                            </div>
                        </div>
                        <div class="grid4">
                            <div class="grid3">
                                <label class="form-label" for="tipoPersona">
                                    Fecha Fin:</label>
                            </div>
                            <div class="grid9">
                                @Html.TextBoxFor(Function(m) (m.ClienteVenta.FechaHasta),
                                New With {
                                    .id = "ID_FechaFin",
                                    .class = "textinput datepicker",
                                    .maxlength = "10",
                                    .value = String.Format("{0:d}"," ")
                                })
                                <div id="ID_MsgFechaFin">
                                </div>
                            </div>
                        </div>
                         </div>
                             </div>
                  <div class="formRow fluid">       
                       <div class="grid4">
                            <div class="grid3">
                                <label class="form-label" for="tipoPersona">
                                    Zona:</label>
                            </div>
                            <div class="grid3">
                                @Html.DropDownListFor(Function(m) m.Zona.IdZona,
                                New SelectList(Model.ListaZona, "IdZona", "Descripcion"),
                                "- TODOS -",
                                New With {
                                    .class = "selector",
                                    .id = "ID_Zona"
                                })
                            </div>
                        </div>
                        <div class="grid4">
                            <div class="grid3">
                                <label class="form-label" for="tipoPersona">
                                    Sucursal:</label>
                            </div>
                            <div class="grid3">                              
                                    @Html.DropDownListFor(Function(m) m.Sucursal.IdSucursal,
                                        New SelectList(Model.ListaSucursal, "IdSucursal", "DescripcionSucursal"),
                                        "- TODOS -",
                                        New With {
                                                  .class = "selector",
                                                  .id = "ID_Sucursal",
                                                  .multiple = "multiple"
                                                })
                            </div>
                        </div>
                    </div>    
            <div class="formRow fluid">
                    <div class="grid12">
                        <button type="button" name="ActionGrabar" id="btnReporte" style="cursor: pointer"
                            class="buttonS bBlue formSubmit group_button" onclick="ReprocesoVentasAnteriores();">
                           Reprocesar Venta</button>
                    </div>
                </div>
            <div class="formRow fluid">            
                        <div class="clear">
                        </div>
                   </div>
            </div>
           
           
        </fieldset>
    </div>
 </div>
 <script type="text/javascript" src="@Url.Content("~/Scripts/View/Vendedor.js")"></script>
 <script type="text/javascript" language="javascript">
     var navegador = navigator.appName

     $(function () {
            $("#ID_Sucursal").multiselect(
            {
                selectedList: 10,
                noneSelectedText: '-TODOS-',
                show: ["bounce", 200],
                minWidth: 280
            }
         ).multiselectfilter();

         $(".ui-multiselect").attr("style", "width: 280px")
         if (navegador == "Microsoft Internet Explorer") {
             $(".ui-multiselect").attr("style", "width: 250px")
         }
     });
</script> 




