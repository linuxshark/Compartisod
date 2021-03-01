@modeltype Sodimac.VentaEmpresa.Web.Mvc.AccountViewModel

            
     @If (Not Model.ListaUsuarios Is Nothing) Then
    
        @Html.DropDownListFor(Function(m) m.Usuario.IdUsu,
                         New MultiSelectList(Model.ListaUsuarios2, "IdUsu", "UsuarioUsu"),
            New With
            {
                .id = "box1View",
                .multiple = "multiple",
                .class = "multiple",
                .style = "height:300px;"
            })
    End If

     <br/>
   @If (Not Model.ListaUsuarios Is Nothing) Then
   
        @Html.DropDownListFor(Function(m) m.Usuario.IdUsu,
              New MultiSelectList(Model.ListaUsuarios, "IdUsu", "UsuarioUsu"),
            New With
            {
                .id = "box2View",
                .multiple = "multiple",
                .class = "multiple",
                .style = "height:300px;"
            })
    end if

