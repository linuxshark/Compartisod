@ModelType Sodimac.VentaEmpresa.Web.Mvc.ClienteVendedorAsociadoViewModel

@Code
    ViewData("Title") = "ClienteVendedorAsociado"
End Code

<div class="breadLine">
    <div class="bc">
        <ul id="breadcrumbs" class="breadcrumbs">
            <li><a href="#">Inicio</a></li>
            <li><a href="#">Reportes</a></li>
            <li class="current"><a href="#" title="">Consulta de Clientes</a></li>
        </ul>
    </div>
</div>
<div class="contentTop">
    <span class="pageTitle"><span id="IdAgregarTitle" class="icon-screen"></span>Consulta Clientes</span>
    <div class="clear"></div>
</div>

<div class="wrapper">
    @Using (Html.BeginForm("", "", FormMethod.Post, New With {.id = "frmClienteVendedorAsociado", .onkeydown = "return event.keyCode!=13"}))
        @<fieldset>
            <div class="widget fluid" id="divDefinicion">
                <div class="whead">
                    <h6>Criterios de Búsqueda</h6>
                    <div class="clear"> </div>
                </div>
                <div class="formRow fluid">
                    <div class="grid">
                        @Html.Label("Razón Social / RUC: ", New With {.class = "grid2"})
                        <div class="grid8">
                            @Html.TextBoxFor(Function(m) m.clienteVenta.RUC,
                                             New With {
                                                .id = "RUC"
                                             })
                        </div>
                        <div class="grid1">
                            <button type="button" name="ActionConsulta" id="consultar" style="cursor:pointer" class="buttonS bBlue  group_button">Consultar</button>
                        </div>
                    </div>
                </div>
            </div>
        </fieldset>
    End Using
</div>

<div class="wrapper">
    <div class="form">
        <fieldset>
            <div class="widget fluid" id="divDefinicion4">
                <div class="whead">
                    <h6>Resultados de Búsqueda</h6>
                    <div class="clear">
                    </div>
                </div>
                <div id="contenedor-grid">
                    @Html.Partial("PV_ClienteVendedorAsociado", Model)
                </div>
            </div>
        </fieldset>
    </div>
</div>

<script>
    var Url = {
        UrlConsultarClienteVendedorAsociado: '@Url.Action("ConsultarClienteVendedorAsociado")'
    }
</script>
@Scripts.Render(
            "~/Scripts/View/ClienteVendedorAsociado.js"
        )