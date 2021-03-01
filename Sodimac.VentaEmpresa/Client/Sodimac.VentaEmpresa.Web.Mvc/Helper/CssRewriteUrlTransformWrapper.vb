Imports System.Web.Optimization

Public Class CssRewriteUrlTransformWrapper : Implements IItemTransform
    Public Function Process(includedVirtualPath As String, input As String) As String Implements IItemTransform.Process
        Return New CssRewriteUrlTransform().Process("~" + VirtualPathUtility.ToAbsolute(includedVirtualPath), input)
    End Function
End Class
