@modeltype Sodimac.VentaEmpresa.Web.Mvc.ProcesoViewModel


@If (Not Model.ListarProcesoCargaEErrores Is Nothing) Then
    If (Not Model.ListarProcesoCargaEErrores.Count = 0) Then
        If Not Model.Empleado.DescError = "" Then
    @For i As Int32 = 0 To (Model.ListarProcesoCargaEErrores.Count) - 1
        @<center>
            <span>
                El codigo Ofisis @Html.DisplayTextFor(Function(m) m.ListarProcesoCargaEErrores(i).CodigoOfisis)
                tiene un error en la columna @Html.DisplayTextFor(Function(m) m.ListarProcesoCargaEErrores(i).DescError)

            </span>
        </center>
        @<br />
    Next
       Else
    @<center>
        <span>

            El Formato es incorrecto

        </span>
    </center>
    @<br />
End If


End If
Else

End If

