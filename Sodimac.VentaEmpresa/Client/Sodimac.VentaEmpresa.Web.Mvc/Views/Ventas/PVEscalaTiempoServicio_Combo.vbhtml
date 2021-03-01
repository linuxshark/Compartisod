@ModelType Sodimac.VentaEmpresa.Web.Mvc.VentasViewModel 

<div class="grid5" >
     <label class="form-label">
                 Escala de Tiempo Inicial:</label>
</div>   
<div class="grid7">
    @Html.DropDownListFor(Function(m) m.Empleado.SucursalEmpleado.EscalaTiempoAsignado,
        New SelectList(Model.ListaComisionEscala, "TiempoServicio", "TiempoServicio"),
        "-SELECCIONE-",
        New With {
                    .id = "ID_ComisionServicio",
                    .class = "selector"
                 })
 </div>
 @Html.ValidationMessageFor(Function(m) m.Empleado.SucursalEmpleado.EscalaTiempoAsignado, "", New With {.class = "reqizq"})