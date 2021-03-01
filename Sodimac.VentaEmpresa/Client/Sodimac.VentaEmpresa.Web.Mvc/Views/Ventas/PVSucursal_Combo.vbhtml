﻿@ModelType Sodimac.VentaEmpresa.Web.Mvc.VentasViewModel 

@Html.DropDownListFor(Function(m) m.Empleado.Sucursal.IdSucursal,
New SelectList(Model.ListaSucursal, "IdSucursal", "DescripcionSucursal"),
"-SELECCIONE-",
New With {
    .id = "ID_Sucursal",
    .class = "selector"
 })
 @Html.ValidationMessageFor(Function(m) m.Empleado.Sucursal.IdSucursal, "", New With {.class = "reqizq"})