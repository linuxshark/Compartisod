@ModelType Sodimac.VentaEmpresa.Web.Mvc.ClientesViewModel
@Imports Sodimac.VentaEmpresa.Web.Mvc.ParametrosView

@If (Not Model.ListaClienteVenta   Is Nothing) Then                   
       @Html.DropDownListFor(Function(m) m.ClienteVenta.IdCliente,
          New MultiSelectList(Model.ListaClienteVenta, "IdCliente", "RazonSocial"),
               New With
                  {
                   .id = "box1View",
                   .multiple = "multiple",
                   .class = "multiple",
                   .style = "height:300px;"
            })
Else
   @<select id = "box1View" multiple = "multiple" class = "multiple" style = "height:310px;"></select> 
End If
