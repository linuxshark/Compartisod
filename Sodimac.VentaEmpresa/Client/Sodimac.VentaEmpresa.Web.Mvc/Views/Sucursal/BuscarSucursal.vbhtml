@ModelType  Sodimac.VentaEmpresa.Web.Mvc.SucursalesViewModel
@Code
    ViewData("Title") = "Buscar Sucursal"
End Code

<div class="breadLine">
    <div class="bc">
        <ul id="breadcrumbs" class="breadcrumbs">
            <li><a href="#">Inicio</a></li>
            <li><a href="#">Mantenedor</a></li>
            <li class="current"><a href="#" title="">Buscar Sucursal</a></li>
        </ul>
    </div>
</div>
<div class="contentTop">
    <span class="pageTitle"><span id="IdAgregarTitle" class="icon-screen"></span>Buscar
        Sucursal</span>
    <div class="clear">
    </div>
</div>
<div class="wrapper">
    <div class="main">
        <div class="form">
            <fieldset>
                <div class="widget fluid first_widget">
                    <div class="whead">
                        <h6>
                            Criterios de Búsqueda</h6>
                        <div class="clear">
                        </div>
                    </div>
                    <div class="formRow fluid">
                        <div class="grid6">
                            <div class="grid3">
                                <label class="form-label">
                                    Sucursal:</label>
                            </div>
                            <div class="grid6">
                                <div id="uniform-uniform-IdSucursal" class="selector">
                                    <span style="-moz-user-select: none;" disabled="disabled">-SELECCIONE-</span>
                                    <select id="uniform-IdSucursal" class="field-validation-valid" name="Sucursal.IdSucursal"
                                        data-val-required="El campo IdSucursal es obligatorio." data-val-number="El campo IdSucursal debe ser un número."
                                        data-val="true" style="opacity: 0;">
                                        <option value="">-SELECCIONE-</option>
                                        <option value="1">Oficina de Apoyo </option>
                                    </select>
                                </div>
                            </div>
                        </div>
                        <div class="grid6">
                            <div class="grid3">
                                <label class="form-label">
                                    Zona:</label>
                            </div>
                            <div class="grid6">
                                <div id="uniform-uniform-IdSucursal" class="selector">
                                    <span style="-moz-user-select: none;">-SELECCIONE-</span>
                                    <select id="uniform-IdSucursal" class="field-validation-valid" name="Sucursal.IdSucursal"
                                        data-val-required="El campo IdSucursal es obligatorio." data-val-number="El campo IdSucursal debe ser un número."
                                        data-val="true" style="opacity: 0;">
                                        <option value="">-SELECCIONE-</option>
                                        <option value="1">Oficina de Apoyo </option>
                                    </select>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="formRow fluid">
                        <div class="grid6">
                            <div class="grid3">
                                <label class="form-label">
                                    Ubigeo:</label>
                            </div>
                            <div class="grid6">
                                <input id="Ubigeo" class="textTransform" type="text" value="" name="Ubigeo">
                            </div>
                        </div>
                        <div class="clear">
                        </div>
                    </div>
                    <div class="formRow noBorderB">
                        <a class="buttonS bBlue formSubmit group_button" style="cursor: pointer" href="/Ventas/GestionarEmpleado">
                            Nuevo</a> <a id="btnBuscar" class="buttonS bBlue formSubmit group_button" onclick="BuscarVendedor(event)"
                                style="cursor: pointer">Buscar</a>
                        <div class="clear">
                        </div>
                        <div class="grid6">
                        </div>
                    </div>
                </div>
            </fieldset>
        </div>
        <div class="widget">
            <div class="whead">
                <div class="whead">
                    <h6>
                        Resultados de Búsqueda</h6>
                </div>
                <div class="clear">
                </div>
            </div>
            <div id="contendor-grid-sucursal">
                @Html.Partial("_BuscarSucursal", Model)
            </div>
        </div>
    </div>
</div>
