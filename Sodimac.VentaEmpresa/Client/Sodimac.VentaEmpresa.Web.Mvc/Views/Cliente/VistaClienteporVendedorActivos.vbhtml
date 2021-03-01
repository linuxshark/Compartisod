@ModelType Sodimac.VentaEmpresa.Web.Mvc.ClientesViewModel
@Imports Sodimac.VentaEmpresa.Web.Mvc.ParametrosView

@If (Not Model.ListaClienteVenta2 Is Nothing) Then
       @Html.DropDownListFor(Function(m) m.ClienteVenta.IdCliente,
          New MultiSelectList(Model.ListaClienteVenta2, "IdCliente", "RazonSocial"),
               New With
                  {
                   .id = "box2View",
                   .multiple = "multiple",
                   .class = "multiple",
                   .style = "height:300px;"
            })
Else
   @<select id = "box2View" multiple = "multiple" class = "multiple" style = "height:200px;"></select> 
End If
