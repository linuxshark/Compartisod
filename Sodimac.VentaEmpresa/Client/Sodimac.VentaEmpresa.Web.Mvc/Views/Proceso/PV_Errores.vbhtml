@modeltype Sodimac.VentaEmpresa.Web.Mvc.ProcesoViewModel
@Code 
    ViewData("Title") = "Errores del Archivo"
End Code
@Using (Html.BeginForm("ImportarArchivos", "Proceso", FormMethod.Post, New With {.id = "frmVerDetalle"}))
    @If Not (Model.ListaProcesoCargaErrorTotales Is Nothing) Then
            @If Not (Model.ListaProcesoCargaErrorTotales Is Nothing) Then
                     @For i As Int32 = 0 To (Model.ListaProcesoCargaErrorTotales.Count) - 1
                        @<span> El registro de tipo @Html.DisplayTextFor(Function(m) m.ListaProcesoCargaErrorTotales(i).TipoDocumento)
                            con Número de documento; @Html.DisplayTextFor(Function(m) m.ListaProcesoCargaErrorTotales(i).NumeroDocumento),
                            tiene un error en la columna @Html.DisplayTextFor(Function(m) m.ListaProcesoCargaErrorTotales(i).DescError)
                        </span>
                        @<br />
                    Next
                End If
       
         End If
End Using
