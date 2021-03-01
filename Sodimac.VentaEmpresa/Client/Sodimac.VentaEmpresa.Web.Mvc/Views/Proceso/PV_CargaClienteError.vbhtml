@ModelType Sodimac.VentaEmpresa.Web.Mvc.CargaMasivaClienteViewModel


<div id="GrillaPrincipal" class="widget fluid">
    <ul class="tabs">
        <li id="lnk0" class="activeTab"><a href="#tabb1">Clientes</a> </li>
        <li id="lnk1" class=""><a href="#tabb2">Empleados Asociados</a> </li>
    </ul>
    <div class="wrapper">
        <div class="tab-container">
            <div id="tabb1" class="tab_content" style="display: block;">
                <div class="formRow fluid">
                    <div class=" fluid">
                        @For i As Int32 = 0 To (Model.ListaProcesoCargaErrorTotales.ListaProcesoCargaErrorTotalCliente.Count) - 1
                            @<span>
                                El registro con RUC @Html.DisplayTextFor(Function(m) m.ListaProcesoCargaErrorTotales.ListaProcesoCargaErrorTotalCliente(i).ClienteVenta.RUC),
                                @Html.DisplayTextFor(Function(m) m.ListaProcesoCargaErrorTotales.ListaProcesoCargaErrorTotalCliente(i).ProcesoCarga.DescError)
                            </span>
                            @<br>
                        Next
                    </div>
                </div>
            </div>
            <div id="tabb2" class="tab_content" style="display: none;">
                <div class="formRow fluid">
                    <div class=" fluid">
                        @For i As Int32 = 0 To (Model.ListaProcesoCargaErrorTotales.ListaProcesoCargaErrorTotalClienteEmpleado.Count) - 1
                            @<span>
                                El registro con RUC @Html.DisplayTextFor(Function(m) m.ListaProcesoCargaErrorTotales.ListaProcesoCargaErrorTotalClienteEmpleado(i).ClienteVenta.RUC),
                                @Html.DisplayTextFor(Function(m) m.ListaProcesoCargaErrorTotales.ListaProcesoCargaErrorTotalClienteEmpleado(i).ProcesoCarga.DescError)
                            </span>
                            @<br>
                        Next
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

@*@For i As Int32 = 0 To (Model.ListaProcesoCargaErrorTotales.Count) - 1
    @<span>
        El registro con RUC @Html.DisplayTextFor(Function(m) m.ListaProcesoCargaErrorTotales(i).ClienteVenta.RUC),
        @Html.DisplayTextFor(Function(m) m.ListaProcesoCargaErrorTotales(i).ProcesoCarga.DescError)
    </span>
    @<br>
Next*@