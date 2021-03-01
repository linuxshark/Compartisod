@ModelType Sodimac.VentaEmpresa.Web.Mvc.ComisionViewModel
@Imports Sodimac.VentaEmpresa.Web.Mvc.ParametrosView
<fieldset>
    <div class="widget grid6 rightTabs" style="min-height: 2000px">
        <div id="izq">
            <div class="whead">
                <h6>
                 <div style="margin-left:80px">ZONAS</div>
                </h6>
                <div class="clear">
                </div>
            
            <ul class="tabs" id="ListaZonas">
                @If Model.ListaPlanVenta IsNot Nothing Then
                    For i As Integer = 0 To Model.ListaPlanVenta.Count - 1
                    @<li id="tabPage_@Model.ListaPlanVenta(i).Cargo.IdCargoSuperior"><a id="tabb__@Model.ListaPlanVenta(i).Cargo.IdCargoSuperior"
                       onclick="CambiarTabZona('@Model.ListaPlanVenta(i).Cargo.IdCargoSuperior','@Model.ListaPlanVenta(i).Cargo.IdCargo',
                       '@Model.ListaPlanVenta(i).Cargo.Perfil.IdPerfil','@Model.ListaPlanVenta(i).Cargo.PerfilSuperior.IdPerfil',
                       '@Model.ListaPlanVenta(i).Cargo.NombreCargo','@Model.ListaPlanVenta(i).Cargo.NombreCargoSuperior');">
                        <img src="" id="imgzone_@Model.ListaPlanVenta(i).Cargo.IdCargoSuperior" alt="" />
                        @Model.ListaPlanVenta(i).Cargo.Zona.NombreZona</a></li>
                        If i = 0 Then
                            @<script type="text/javascript">
                                 $(function () {
                                     $('#tabb__@Model.ListaPlanVenta(i).Cargo.IdCargoSuperior').click();
                                 })
                            </script>
                        End If
                        If Model.ListaPlanVenta(i).ComisionEscala.Completo = True And Model.ListaPlanVenta(i).ComisionEscalaRRVV.Completo = True Then
                            @<script type="text/javascript">
                                 $(function () {
                                     $('#imgzone_@Model.ListaPlanVenta(i).Cargo.IdCargoSuperior').attr("src", "/Content/images/botones/dot-green.png");
                                 })
                            </script>
                        Else
                            @<script type="text/javascript">
                                 $(function () {
                                     $('#imgzone_@Model.ListaPlanVenta(i).Cargo.IdCargoSuperior').attr("src", "/Content/images/botones/dot-red.png");
                                 })
                            </script>
                        End If
                    Next
                End If
                @Html.HiddenFor(Function(m) m.PlanVenta.ComisionEscala.ComisionPeriodo.IdPeriodo, New With {.id = "Hidden_IDPeriodo"})
            </ul>
            </div>
            <div class="tab_container" id="TabContenedor">
            </div>
        </div>
    </div>
    <div class="clear"></div>
</fieldset>

