@Code
    ViewData("Title") = "RegistroBoleta"
End Code

<div class="breadLine">
    <div class="bc">
        <ul id="breadcrumbs" class="breadcrumbs">
            <li><a href="#">Inicio</a></li>
            <li><a href="#">Mantenedor</a></li>
            <li class="current"><a href="#" title="">Registro de boletas</a></li>
        </ul>
    </div>
</div>
<div class="contentTop">
    <span class="pageTitle"><span id="IdAgregarTitle" class="icon-screen"></span>Registrar Boleta</span>
    <div class="clear"></div>
</div> 
<div class="wrapper">
    <div class="form">
        @*@Using (Html.BeginForm("RegistrarCierre", "Mantenimiento", FormMethod.Post, New With {.id = "FrmNuevoCierre"}))*@
            <fieldset>
                <div class="widget fluid" id="divDefinicion">
                    <div class="whead">
                        <h6>Registrar boleta de venta empresa</h6>
                        <div class="clear"> </div>
                    </div>
                    <div class="formRow fluid">
                        <div class="grid12">
                            <div class="grid12">
                                @Html.Label("TIENDA")
                            </div>
                            <div class="grid12">
                                <select id="test" name="test">
                                    <option selected="selected" value="0">Test</option>
                                </select>
                            </div>
                        </div>
                    </div>
                    <div class="formRow fluid">
                        <div class="grid12">
                            <div class="grid12">
                                @Html.Label("CORRELATIVO")
                            </div>
                            <div class="grid12">
                                @Html.TextBox("ass")
                            </div>
                        </div>
                    </div>
                    <div class="formRow fluid">
                        <div class="grid12">
                            <div class="grid12">
                                @Html.Label("DNI")
                            </div>
                            <div class="grid12">
                                @Html.TextBox("ass")
                            </div>
                        </div>
                    </div>
                    <div class="formRow fluid">
                        <div class="grid12">
                            <div class="grid12">
                                @Html.Label("Nombre")
                            </div>
                            <div class="grid12">
                                @Html.TextBox("ass")
                            </div>
                        </div>
                    </div>
                    <div class="formRow">
                        <button type="button" name="ActionAgregar" id="btnRegistrar" style="cursor:pointer" class="buttonS bBlue formSubmit group_button ">Guardar</button>
                        <br class="clear" />
                        <div class="clear"></div>
                    </div>
                </div>
            </fieldset>
        @*End Using*@
    </div>
</div>

    <div id="dialogRegistrar" title="Mensaje de Confirmación">
        <p>¿Desea guardar el registro?</p>
    </div>
    <script>
        var Url = {
            Nuevo: '@Url.Action("RegistrarBoleta", "Mantenimiento")'
            }
    </script>

    @Scripts.Render(
                "~/Scripts/View/RegistrarBoleta.js"
            )