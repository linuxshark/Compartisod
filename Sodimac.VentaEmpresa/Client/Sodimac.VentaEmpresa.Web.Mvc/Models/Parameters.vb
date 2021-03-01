Public Class Parameters
    Private _page As Integer
    Public Property page() As Integer
        Get
            Return _page
        End Get
        Set(ByVal value As Integer)
            _page = value
        End Set
    End Property

    Private _sortDir As String
    Public Property sortDir() As String
        Get
            Return _sortDir
        End Get
        Set(ByVal value As String)
            _sortDir = value
        End Set
    End Property

    Private _sort As String
    Public Property sort() As String
        Get
            Return _sort
        End Get
        Set(ByVal value As String)
            _sort = value
        End Set
    End Property
End Class
