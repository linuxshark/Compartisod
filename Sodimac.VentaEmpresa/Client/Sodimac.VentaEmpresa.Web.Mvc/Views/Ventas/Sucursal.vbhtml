<div class="widget">
    <div class="whead">
        <div class="whead">
            <h6>
                Historial de Sucursales</h6>
        </div>
        <div class="clear">
        </div>
    </div>
    <div id="contendor-grid-sucursal">
    </div>
</div>
<div class="formRow noBorderB">
    <input type="button" style="cursor: pointer" id="btnNuevaSucursal" class="buttonS bBlue formSubmit group_button" 
    onclick="dialogGestionarSucursalEmpleado();" value="Nuevo" />
    <div class="clear">
    </div>
</div>
<div class="formRow">
    <div class="clear">
    </div>
</div>
<div id="dialogGestionarSucursalEmpleado" style="display: none" class="j_modal" title="Agregar Cargo">      

</div>

<div id="dialogRegistrarSucursalEmpleado" title="Mensaje de Confirmación">
       <p>¿Desea guardar el registro?</p>
</div>

   <div id="dialogCancelarRegistroSucursalEmpleado" title="Mensaje de Confirmación">
       <p>¿Desea cancelar el registro?</p>
     </div>

 <script type="text/javascript" src="@Url.Content("~/Scripts/View/Vendedor.js")"></script>
     <script type="text/javascript" language="javascript">
         $(function () {
             //BuscarPlanVentaPersonal();
             InicioJPopUp("#dialogGestionarSucursalEmpleado", 1200, 500, false, "Gestionar Sucursal Empleado");
             InicioJPopUpConfirm("#dialogRegistrarSucursalEmpleado", 500, false, "Gestionar Sucursal Empleado", GuardarSucursalEmpleado);
             InicioJPopUpConfirm("#dialogCancelarRegistroSucursalEmpleado", 500, false, "Mensaje de Confirmación", CancelarRegistroSucursalEmpleado); ;
         });
    </script>