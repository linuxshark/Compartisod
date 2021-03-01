Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports System.Web.UI
Imports System.Web.WebPages
Imports System.Runtime.CompilerServices

Namespace MvcTreeView.Helpers

    Public Module TreeViewHelper
        Sub New()
        End Sub
        ''' <summary>
        ''' Create an HTML tree from a recursive collection of items
        ''' </summary>
        <System.Runtime.CompilerServices.Extension()> _
        Public Function TreeView(Of T)(html As HtmlHelper, items As IEnumerable(Of T)) As TreeView(Of T)
            Return New TreeView(Of T)(html, items)
        End Function
    End Module

    ''' <summary>
    ''' Create an HTML tree from a resursive collection of items
    ''' </summary>
    Public Class TreeView(Of T)
        Implements IHtmlString
        Private ReadOnly _html As HtmlHelper
        Private ReadOnly _items As IEnumerable(Of T) = Enumerable.Empty(Of T)()
        Private _displayProperty As Func(Of T, String) = Function(item) item.ToString()
        Private _childrenProperty As Func(Of T, IEnumerable(Of T))
        Private _emptyContent As String = "No children"
        Private _htmlAttributes As IDictionary(Of String, Object) = New Dictionary(Of String, Object)()
        Private _childHtmlAttributes As IDictionary(Of String, Object) = New Dictionary(Of String, Object)()
        Private _itemTemplate As Func(Of T, HelperResult)

        Public Sub New(html As HtmlHelper, items As IEnumerable(Of T))
            If html Is Nothing Then
                Throw New ArgumentNullException("html")
            End If
            _html = html
            _items = items
            ' The ItemTemplate will default to rendering the DisplayProperty
            Dim expression = Function(writer, item) writer.Write(_displayProperty(item))
            _itemTemplate = Function(item) New HelperResult(Function(writer) expression(writer, item))

        End Sub

        ''' <summary>
        ''' The property which will display the text rendered for each item
        ''' </summary>
        Public Function ItemText(selector As Func(Of T, String)) As TreeView(Of T)
            If selector Is Nothing Then
                Throw New ArgumentNullException("selector")
            End If
            _displayProperty = selector
            Return Me
        End Function


        ''' <summary>
        ''' The template used to render each item in the tree view
        ''' </summary>
        Public Function ItemTemplate(itemTemplate__1 As Func(Of T, HelperResult)) As TreeView(Of T)
            If itemTemplate__1 Is Nothing Then
                Throw New ArgumentNullException("itemTemplate")
            End If
            _itemTemplate = itemTemplate__1
            Return Me
        End Function


        ''' <summary>
        ''' The property which returns the children items
        ''' </summary>
        Public Function Children(selector As Func(Of T, IEnumerable(Of T))) As TreeView(Of T)
            If selector Is Nothing Then
                Throw New ArgumentNullException("selector")
            End If
            _childrenProperty = selector
            Return Me
        End Function

        ''' <summary>
        ''' Content displayed if the list is empty
        ''' </summary>
        Public Function EmptyContent(emptyContent__1 As String) As TreeView(Of T)
            If emptyContent__1 Is Nothing Then
                Throw New ArgumentNullException("emptyContent")
            End If
            _emptyContent = emptyContent__1
            Return Me
        End Function

        ''' <summary>
        ''' HTML attributes appended to the root ul node
        ''' </summary>
        Public Function HtmlAttributes(htmlAttributes__1 As Object) As TreeView(Of T)
            HtmlAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes__1))
            Return Me
        End Function

        ''' <summary>
        ''' HTML attributes appended to the root ul node
        ''' </summary>
        Public Function HtmlAttributes(htmlAttributes__1 As IDictionary(Of String, Object)) As TreeView(Of T)
            If htmlAttributes__1 Is Nothing Then
                Throw New ArgumentNullException("htmlAttributes")
            End If
            _htmlAttributes = htmlAttributes__1
            Return Me
        End Function

        ''' <summary>
        ''' HTML attributes appended to the children items
        ''' </summary>
        Public Function ChildrenHtmlAttributes(htmlAttributes As Object) As TreeView(Of T)
            ChildrenHtmlAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes))
            Return Me
        End Function

        ''' <summary>
        ''' HTML attributes appended to the children items
        ''' </summary>
        Public Function ChildrenHtmlAttributes(htmlAttributes As IDictionary(Of String, Object)) As TreeView(Of T)
            If htmlAttributes Is Nothing Then
                Throw New ArgumentNullException("htmlAttributes")
            End If
            _childHtmlAttributes = htmlAttributes
            Return Me
        End Function

        Public Function ToHtmlString() As String Implements IHtmlString.ToHtmlString
            Return ToString()
        End Function

        Public Sub Render()
            Dim writer = _html.ViewContext.Writer
            Using textWriter = New HtmlTextWriter(writer)
                textWriter.Write(ToString())
            End Using
        End Sub

        Private Sub ValidateSettings()
            If _childrenProperty Is Nothing Then
                Throw New InvalidOperationException("You must call the Children() method to tell the tree view how to find child items")
            End If
        End Sub


        Public Overrides Function ToString() As String
            ValidateSettings()

            Dim listItems = _items.ToList()

            Dim ul = New TagBuilder("ul")
            ul.MergeAttributes(_htmlAttributes)

            If listItems.Count = 0 Then
                Dim li = New TagBuilder("li")
                li.InnerHtml = _emptyContent

                ul.InnerHtml += li.ToString()
            End If

            For Each item As T In listItems
                BuildNestedTag(ul, item, _childrenProperty)
            Next

            Return ul.ToString()
        End Function

        Private Sub AppendChildren(parentTag As TagBuilder, parentItem As T, childrenProperty As Func(Of T, IEnumerable(Of T)))
            Dim children = childrenProperty(parentItem).ToList()
            If children.Count() = 0 Then
                Return
            End If

            Dim innerUl = New TagBuilder("ul")
            innerUl.MergeAttributes(_childHtmlAttributes)

            For Each item As T In children
                BuildNestedTag(innerUl, item, childrenProperty)
            Next

            parentTag.InnerHtml += innerUl.ToString()
        End Sub

        Private Sub BuildNestedTag(parentTag As TagBuilder, parentItem As T, childrenProperty As Func(Of T, IEnumerable(Of T)))
            Dim li = GetLi(parentItem)
            parentTag.InnerHtml += li.ToString(TagRenderMode.StartTag)
            AppendChildren(li, parentItem, childrenProperty)
            parentTag.InnerHtml += li.InnerHtml + li.ToString(TagRenderMode.EndTag)
        End Sub

        Private Function GetLi(item As T) As TagBuilder
            Dim li = New TagBuilder("li")
            li.InnerHtml = _itemTemplate(item).ToHtmlString()

            Return li
        End Function
    End Class



End Namespace


