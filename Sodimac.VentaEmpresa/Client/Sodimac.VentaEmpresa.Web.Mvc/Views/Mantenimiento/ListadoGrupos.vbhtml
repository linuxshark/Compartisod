@ModelType Sodimac.VentaEmpresa.Web.Mvc.MantenimientoViewModel
@Imports Sodimac.VentaEmpresa.Web.Mvc.ParametrosView
@Imports Sodimac.VentaEmpresa.Common

@Code
    ViewData("Title") = "Listado Grupo por Clientes"
End Code
<div class="wrapper">
    <div class="main">
        <div class="form">
            <fieldset>
                <div class="widget fluid">
                    <div class="tab_container">    
                        @If Model.Grupo.IdGrupo <> 0 Then
                            @<div id="TabGrupoCliente" class="tab_content">
                                <div class="wrapper">
                                    @Html.Partial(ParametrosPartialView.PVClientesGrupos, Model)
                                </div>
                            </div>
                        End If
                    </div>
                </div>
            </fieldset>
        </div>
    </div>
</div>

@Html.HiddenFor(Function(m) m.Grupo.IdGrupo, New With {.id = "ID_IdGrupo"})

@Html.Hidden("ID_UrlPVListaClientes_Grupo", Url.Action("PVListaClientes_Grupo"), "Mantenimiento")
<script type="text/javascript" src="@Url.Content("~/Scripts/View/Mantenimiento.js")"></script>
<script type="text/javascript" language="javascript">
    $(function () {
        ListarClientesGrupo();
        var IdGrupo = $("#ID_IdGrupo").val();
        if (IdGrupo == "True") {
            $("#TabGrupoCliente").show();
        }
        else {
            $("#TabGrupoCliente").show();
        }
    });
</script>

