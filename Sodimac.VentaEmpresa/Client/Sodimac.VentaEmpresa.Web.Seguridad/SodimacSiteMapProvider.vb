Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports MvcSiteMapProvider.Extensibility
Imports System.Web
Imports System.Web.Mvc
Imports System.Web.Routing
Imports System.Web.Security
Imports System.Configuration
Imports System.Security.Principal
Imports Sodimac.VentaEmpresa.Web.Seguridad.Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad
Imports MvcSiteMapProvider

Public Class SodimacNodeProvider
    Inherits DynamicNodeProviderBase

    'Public Overrides Function GetDynamicNodeCollection() As IEnumerable(Of DynamicNode)

    '    Using oServicioSeguridadSoapClient As New ServicioSeguridadSoapClient()

    '        Dim url As String = ""
    '        Dim listaMenu As New ListaPagina()

    '        If HttpContext.Current.Session("Usuario") IsNot Nothing Then
    '            Dim oUsuario As Usuario = DirectCast(HttpContext.Current.Session("Usuario"), Usuario)
    '            listaMenu = oServicioSeguridadSoapClient.SiteMapByUser(oUsuario.UsuarioUsu)
    '            'listaMenu = oServicioSeguridadSoapClient.SiteMapByUser("jpanocca")
    '        End If

    '        Dim listDynamicNode As New List(Of DynamicNode)

    '        For Each item As Pagina In listaMenu
    '            If String.IsNullOrEmpty(item.UrlPagina) Then
    '                url += "#"

    '                Dim oDynamicNode As New DynamicNode()

    '                oDynamicNode.Key = item.IdPagina.ToString()
    '                oDynamicNode.ParentKey = If(item.PadrePagina <> 0, item.PadrePagina.ToString(), Nothing)
    '                oDynamicNode.Title = item.NombrePagina
    '                oDynamicNode.Controller = Nothing
    '                oDynamicNode.Action = Nothing
    '                oDynamicNode.RouteValues = New Dictionary(Of String, Object)() From {{"url", url}}
    '                oDynamicNode.Attributes = New Dictionary(Of String, String)() From {{"imageUrl", item.UrlImagePagina}}

    '                listDynamicNode.Add(oDynamicNode)
    '            Else

    '                Dim oDynamicNode As New DynamicNode()

    '                oDynamicNode.Key = item.IdPagina.ToString()
    '                oDynamicNode.ParentKey = If(item.PadrePagina <> 0, item.PadrePagina.ToString(), Nothing)
    '                oDynamicNode.Title = item.NombrePagina
    '                oDynamicNode.Controller = item.UrlPagina.Substring(0, item.UrlPagina.IndexOf("/"))
    '                oDynamicNode.Action = item.UrlPagina.Substring(item.UrlPagina.IndexOf("/") + 1)
    '                oDynamicNode.Attributes = New Dictionary(Of String, String)() From {{"visibility", If(Convert.ToInt32(item.VisiblePagina) = 1, "SiteMapPathHelper", "!*")}, {"imageUrl", If(Not String.IsNullOrEmpty(item.UrlImagePagina), item.UrlImagePagina, Nothing)}}

    '                listDynamicNode.Add(oDynamicNode)
    '            End If
    '        Next

    '        Return listDynamicNode

    '    End Using

    'End Function


    Public Overrides Function GetDynamicNodeCollection(node As ISiteMapNode) As IEnumerable(Of DynamicNode)
        Using oServicioSeguridadSoapClient As New ServicioSeguridadSoapClient()

            Dim url As String = ""
            Dim listaMenu As New ListaPagina()

            If HttpContext.Current.Session("Usuario") IsNot Nothing Then
                Dim oUsuario As Usuario = DirectCast(HttpContext.Current.Session("Usuario"), Usuario)
                listaMenu = oServicioSeguridadSoapClient.SiteMapByUser(oUsuario.UsuarioUsu)

            End If

            Dim listDynamicNode As New List(Of DynamicNode)

            For Each item As Pagina In listaMenu

                Dim attr As Dictionary(Of String, Object) = New Dictionary(Of String, Object)
                attr.Add("level", If(Convert.ToInt32(item.VisiblePagina) = 1, "SiteMapPathHelper", "!*"))

                Dim urlImg = New Dictionary(Of String, Object)() From {{"img", item.UrlImagePagina}}

                If String.IsNullOrEmpty(item.UrlPagina) Then
                    url += "#"

                    Dim oDynamicNode As New DynamicNode()

                    oDynamicNode.Key = item.IdPagina.ToString()
                    oDynamicNode.ParentKey = If(item.PadrePagina <> 0, item.PadrePagina.ToString(), Nothing)
                    oDynamicNode.Title = item.NombrePagina
                    oDynamicNode.Url = url
                    oDynamicNode.ImageUrl = If(item.UrlImagePagina <> Nothing, item.UrlImagePagina, Nothing)
                    oDynamicNode.Attributes = attr

                    listDynamicNode.Add(oDynamicNode)
                Else

                    Dim oDynamicNode As New DynamicNode()

                    oDynamicNode.Key = item.IdPagina.ToString()
                    oDynamicNode.ParentKey = If(item.PadrePagina <> 0, item.PadrePagina.ToString(), Nothing)
                    oDynamicNode.Title = item.NombrePagina
                    oDynamicNode.Controller = item.UrlPagina.Substring(0, item.UrlPagina.IndexOf("/"))
                    oDynamicNode.Action = item.UrlPagina.Substring(item.UrlPagina.IndexOf("/") + 1)
                    oDynamicNode.Url = ""
                    oDynamicNode.ImageUrl = If(item.UrlImagePagina <> Nothing, item.UrlImagePagina, Nothing)
                    'oDynamicNode.Attributes = New Dictionary(Of String, String)() From {{"visibility", If(Convert.ToInt32(item.VisiblePagina) = 1, "SiteMapPathHelper", "!*")}, {"imageUrl", If(Not String.IsNullOrEmpty(item.UrlImagePagina), item.UrlImagePagina, Nothing)}}
                    ' oDynamicNode.Attributes.Add(

                    listDynamicNode.Add(oDynamicNode)
                End If
            Next

            Return listDynamicNode

        End Using

    End Function

End Class

