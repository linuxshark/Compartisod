@*@ModelType Sodimac.VentaEmpresa.Web.Mvc.VentasViewModel *@
@Code
    ViewData("Title") = "Sucursal"
End Code
<div class="breadLine">
    <div class="bc">
        <ul id="breadcrumbs" class="breadcrumbs">
            <li><a href="#">Inicio</a></li>
            <li><a href="#">Mantenedor</a></li>
            <li class="current"><a href="#" title="">Agregar Representantes de Ventas</a></li>
        </ul>
    </div>
</div>
<div class="contentTop">
    <span class="pageTitle"><span id="IdAgregarTitle" class="icon-screen"></span>Agregar Representantes de Ventas</span>
    <div class="clear">
    </div>
</div>
<div class="wrapper">
    <div class="main">
        <div class="form">
            <fieldset>
                <div class="widget fluid">
                    <div class="whead">
                        <h6>
                           Sucursal
                        </h6>
                        <div class="clear">
                        </div>
                    </div>
                    <div class="formRow" style="text-align: left;">
                        <button class="buttonS bBlue formSubmit group_button" style="cursor: pointer; float: left">
                            Nuevo
                        </button>
                        <button class="buttonS bBlue formSubmit group_button" style="cursor: pointer; float: left">
                            Editar
                        </button>
                        <button class="buttonS bBlue formSubmit group_button" style="cursor: pointer; float: left">
                            Guardar
                        </button>
                        <button class="buttonS bDefault formSubmit group_button" style="cursor: pointer;
                            float: left">
                            Cancelar
                        </button>
                        <div class="clear">
                        </div>
                    </div>
                    <div class="formRow fluid">
                        <div class="grid6">
                            <div class="grid3">
                                <label class="form-label">
                                    Nombres:</label>
                            </div>
                            <div class="grid6">
                                <input name="Nombres.RegistrarVendedor" style="text-transform: uppercase;" type="text" />
                            </div>
                        </div>
                      
                        <div class="clear">
                        </div>
                    </div>
               
                  
                    <div class="formRow fluid">
                    </div>
                </div>
                <div class="widget fluid">
                    <ul class="tabs">
                        <li class="activeTab"><a href="#tabb1">Representante de Ventas</a> </li>
                        <li class=""><a href="#tabb2">----------</a> </li>
                    </ul>
                    <div class="tab_container">
                        <div id="tabb1" class="tab_content" style="display: none;">
                            <div class="formRow fluid">
                                
                                
                                <div class="grid4">
                                    <div class="grid12">
                                        <button class="buttonS bBlue formSubmit group_button" onclick="window.location='/Ventas/RegistrarVendedor'"
                                            style="cursor: pointer">
                                            Agregar</button>
                                    </div>
                                </div>
                            </div>
                            <div class="widget">
                                <div class="whead">
                                    <h6>
                                        Resultados de la Búsqueda</h6>
                                    <div class="titleOpt">
                                        <a data-toggle="dropdown" href="#"><span class="icos-cog3"></span><span class="clear">
                                        </span></a>
                                        <ul class="dropdown-menu pull-right">
                                            <li><a href="#"><span class="icos-add"></span>Agregar</a></li>
                                            <li><a href="#"><span class="icos-trash"></span>Editar</a></li>
                                            <li><a class="" href="#"><span class="icos-pencil"></span>Eliminar</a></li>
                                        </ul>
                                    </div>
                                    <div class="clear">
                                    </div>
                                </div>
                                <table width="100%" cellspacing="0" cellpadding="0" class="tDefault checkAll check">
                                    <thead>
                                        <tr>
                                            <td>
                                            </td>
                                            <td>
                                                Codigo
                                            </td>
                                            <td>
                                                Personal 
                                            </td>
                                            <td>
                                                Fecha Ingreso
                                            </td>
                                            <td>
                                                Fecha Activación
                                            </td>
                                            <td>
                                                Escala Comision Inicial
                                            </td>
                                         
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td>
                                                <div class="checker" id="uniform-titleCheck2">
                                                    <span>
                                                        <input type="checkbox" name="checkRow" id="titleCheck2" style="opacity: 0;" /></span></div>
                                            </td>
                                            <td>
                                                54216477102
                                            </td>
                                            <td>
                                                RAZÓN SOCIAL CLIENTE 01
                                            </td>
                                            <td>
                                                RUBRO 001
                                            </td>
                                            <td>
                                                REPRESENTANTE LEGAL 0001
                                            </td>
                                            <td>
                                                LIMA
                                            </td>
                                         
                                        </tr>
                                        <tr>
                                            <td>
                                                <div class="checker" id="uniform-titleCheck2">
                                                    <span>
                                                        <input type="checkbox" name="checkRow" id="titleCheck2" style="opacity: 0;" /></span></div>
                                            </td>
                                            <td>
                                                54213456712
                                            </td>
                                            <td>
                                                RAZÓN SOCIAL CLIENTE 02
                                            </td>
                                            <td>
                                                RUBRO 002
                                            </td>
                                            <td>
                                                REPRESENTANTE LEGAL 0002
                                            </td>
                                            <td>
                                                LIMA
                                            </td>
                                       
                                        </tr>
                                        <tr>
                                            <td>
                                                <div class="checker" id="uniform-titleCheck2">
                                                    <span>
                                                        <input type="checkbox" name="checkRow" id="titleCheck2" style="opacity: 0;" /></span></div>
                                            </td>
                                            <td>
                                                54254417711
                                            </td>
                                            <td>
                                                RAZÓN SOCIAL CLIENTE 03
                                            </td>
                                            <td>
                                                RUBRO 003
                                            </td>
                                            <td>
                                                REPRESENTANTE LEGAL 0003
                                            </td>
                                            <td>
                                                LIMA
                                            </td>
                                       
                                        </tr>                                    
                                    </tbody>
                                </table>
                            </div>
                        </div>
                        <div id="tabb2" class="tab_content" style="display: block;">
                            <div class="whead">
                                <h6>
                                    Tienda</h6>
                                <div class="clear">
                                </div>
                            </div>
                          
                            <div class="formRow fluid">
                            
                                <div class="grid6">
                                    <div class="grid3">
                                        <label class="form-label">
                                            Departamento:</label>
                                    
                             
                             </div>
                                   @* <div class="grid9 noSearch">
                                        <select class="textinput select" id="IdDepar" name="Departamento.IdDepar">
                                            <option value="">- SELECCIONE -</option>
                                            <option value="1">GERENCIA VENTA EMPRESA</option>
                                            <option value="2">PROYECTOS</option>
                                            <option value="2">PROYECTOS VENTA EMPRESA</option>
                                            <option value="2">VENTA EMPRESA</option>
                                            <option value="2">PROYECTO -VENTA EMPRESA</option>
                                            <option value="2">CENTRO DE ATENCION PARA PROYECTOS</option>
                                        </select>
                                    </div>*@
                                </div>
                                <div class="clear">
                                </div>
                            </div>
                            <div class="formRow fluid">
                                <div class="grid6">
                                    <div class="grid3">
                                        <label class="form-label">
                                            Fecha Inicio :</label>
                                    </div>
                                    <div class="grid4">
                                        <input id="ID_FechaInicio" class="datepicker" name="Fecha.Inicio" style="text-transform: uppercase;"
                                            type="text" />
                                    </div>
                                </div>
                                <div class="grid6">
                                    <div class="grid3">
                                        <label class="form-label">
                                            Fecha Activación:</label>
                                    </div>
                                    <div class="grid4">
                                        <input id="ID_FechaActivacion" class="datepicker" name="Fecha.Activacion" style="text-transform: uppercase;"
                                            type="text" />
                                    </div>
                                </div>
                            </div>
                            <div class="whead">
                                <h6>
                                    Responsable
                                </h6>
                                <div class="clear">
                                </div>
                            </div>
                            <div class="formRow fluid">
                                <div class="grid6">
                                    <div class="grid3">
                                        <label class="form-label">
                                            Jefe :</label>
                                    </div>
                                    <div class="grid9 noSearch">
                                        <select class="textinput select" id="IdJefes" name="Jefe.IdJefes">
                                            <option value="">- SELECCIONE -</option>
                                            <option value="1">TORRES RODRIGUES</option>
                                            <option value="2">QUISPE SANCHEZ</option>
                                            <option value="2">cc</option>
                                        </select>
                                    </div>
                                </div>
                                <div class="grid6">
                                    <div class="grid3">
                                        <label class="form-label">
                                            Cargo:</label>
                                    </div>
                                    <div class="grid6">
                                        <div class="grid9 noSearch">
                                            <select class="textinput select" id="IdCar" name="Cargo.IdCar">
                                                <option value="">- SELECCIONE -</option>
                                                <option value="1">JEFE VENTAS</option>
                                                <option value="2">JEFE REGIONAL</option>
                                                <option value="2">REPRESENTANTES DE VENTA</option>
                                            </select>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="whead">
                                <h6>
                                    Historico
                                </h6>
                                <div class="clear">
                                </div>
                            </div>
                            <div class="widget">
                                <div class="whead">
                                    <h6>
                                        Static table</h6>
                                    <div class="clear">
                                    </div>
                                </div>
                                <table class="tDefault" width="100%" cellspacing="0" cellpadding="0">
                                    <thead>
                                        <tr>
                                            <td>
                                                Zona
                                            </td>
                                            <td>
                                                Region
                                            </td>
                                            <td>
                                                Sucursal
                                            </td>
                                            <td>
                                                Area
                                            </td>
                                            <td>
                                                Fecha Inicio
                                            </td>
                                            <td>
                                                Fecha Activación
                                            </td>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td>
                                                NORTE
                                            </td>
                                            <td>
                                                PIURA
                                            </td>
                                            <td>
                                                CASTILLA
                                            </td>
                                            <td>
                                                VENTAS
                                            </td>
                                            <td>
                                                05/08/2012
                                            </td>
                                            <td>
                                                12/09/2012
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                CENTRO
                                            </td>
                                            <td>
                                                LIMA
                                            </td>
                                            <td>
                                                MIRAFLORES
                                            </td>
                                            <td>
                                                VENTAS
                                            </td>
                                            <td>
                                                22/01/2011
                                            </td>
                                            <td>
                                                28/01/2011
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </fieldset>
        </div>
    </div>
</div>
