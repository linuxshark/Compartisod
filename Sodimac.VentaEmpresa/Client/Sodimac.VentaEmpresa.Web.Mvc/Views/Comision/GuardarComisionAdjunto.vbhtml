@ModelType  Sodimac.VentaEmpresa.Web.Mvc.ComisionViewModel
@Imports Sodimac.VentaEmpresa.Common
<html>
<head>

</head>
<body style=" background-color: White;">
   <div class="wrapper" style="margin: 20px;/*text-align:center;width:400px;*/">

   @Html.HiddenFor(Function(m) m.FileAttached.FileAceptSize, New With {.id = "IdFileAceptSizeAttached"})

@*        @Html.HiddenFor(function(m) m.FileAttached.IsLoadDetail,  New With { @id = "IdFileIsLoadDetailAttached" })
        @Html.HiddenFor(function(m) m.FileAttached.FileAceptExtension,  New With { @id = "IdFileAceptExtensionAttached" })*@
        @*@Html.HiddenFor(function(m) m.FileAttached.FileAceptSize,  New With { @id = "IdFileAceptSizeAttached" })*@
        @*@Html.HiddenFor(function(m) m.FileAttached.FileMaxSizeAllowKB,  New With { @id = "IdFileMaxSizeAllowKBAttached" })
        @Html.HiddenFor(function(m) m.FileAttached.FileMaxSizeAllowKBTotal2,  New With { @id = "IdFileMaxSizeAllowKBAttachedTotal2" })
        @Html.HiddenFor(function(m) m.FileAttached.FileCount,  New With { @id = "IdFileCountFileAttached" })
        @Html.HiddenFor(function(m) m.FileAttached.FileMaxAmount,  New With { @id = "IdFileMaxAmountFileAttached" })
        @Html.HiddenFor(function(m) m.FileAttached.FileMaxAmountFill,  New With { @id = "IdFileMaxAmountFillFileAttached" })*@

    </div>
</body>
</html>