Public Class ErrorLog

    Private _IDError As Integer
    Public Property IDError() As Integer
        Get
            Return _IDError
        End Get
        Set(ByVal value As Integer)
            _IDError = value
        End Set
    End Property


    Private _ErrorMessage As String
    Public Property ErrorMessage() As String
        Get
            Return _ErrorMessage
        End Get
        Set(ByVal value As String)
            _ErrorMessage = value
        End Set
    End Property

    Private _ErrorStackTrace As String
    Public Property ErrorStackTrace() As String
        Get
            Return _ErrorStackTrace
        End Get
        Set(ByVal value As String)
            _ErrorStackTrace = value
        End Set
    End Property


End Class
