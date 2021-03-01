<div class="widget">
    <div class="whead">
        <div class="whead">
            <h6>
                Historial de Plan Venta</h6>
        </div>
        <div class="clear">
        </div>
    </div>
    <div id="contendor-grid-planventa">
    </div>
</div>
<div class="formRow noBorderB">
    <input type="button" style="cursor: pointer" id="btnNuevaPlanVenta" class="buttonS bBlue formSubmit group_button" 
        value="Nuevo" onclick="dialogGestionarPlanVenta();" />
    <div class="clear">
    </div>
</div>
<div class="formRow">
    <div class="clear">
    </div>
</div>

<div id="dialogGestionarPlanVenta" style="display: none" class="j_modal" title="Agregar Cargo">      

</div>

<div id="dialogRegistrarPlanVenta" title="Mensaje de Confirmación">
       <p>¿Desea guardar el registro?</p>
</div>

   <div id="dialogCancelarRegistroPlanventa" title="Mensaje de Confirmación">
       <p>¿Desea cancelar el registro?</p>
     </div>

 <script type="text/javascript" src="@Url.Content("~/Scripts/View/Vendedor.js")"></script>
     <script type="text/javascript" language="javascript">
         $(function () {
             //BuscarPlanVentaPersonal();
             InicioJPopUp("#dialogGestionarPlanVenta", 1300, 500, false, "Gestionar Plan Venta");
             InicioJPopUpConfirm("#dialogRegistrarPlanVenta", 500, false, "Gestionar Plan Venta", GuardarPlanVenta);
             InicioJPopUpConfirm("#dialogCancelarRegistroPlanventa", 500, false, "Mensaje de Confirmación", CancelarRegistroPlanVenta); ;
         });
    </script>




