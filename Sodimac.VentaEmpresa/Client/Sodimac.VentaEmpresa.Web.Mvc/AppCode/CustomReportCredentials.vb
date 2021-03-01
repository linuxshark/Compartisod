Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Security.Principal
Imports System.Net
Imports Microsoft.Reporting.WebForms

Namespace Sodimac.VentaEmpresa.Web.Mvc
    Public Class CustomReportCredentials
        Implements IReportServerCredentials

        Private _UserName As String
        Private _PassWord As String
        Private _DomainName As String

        Public Sub New(UserName As String, PassWord As String, DomainName As String)
            _UserName = UserName
            _PassWord = PassWord
            _DomainName = DomainName
        End Sub

        Public ReadOnly Property ImpersonationUser() As WindowsIdentity _
            Implements IReportServerCredentials.ImpersonationUser
            Get
                Return Nothing
            End Get
        End Property

        Public ReadOnly Property NetworkCredentials() As System.Net.ICredentials _
            Implements IReportServerCredentials.NetworkCredentials
            Get
                Return New NetworkCredential(_UserName, _PassWord, _DomainName)
            End Get
        End Property

        Public Function GetFormsCredentials(ByRef authCookie As Cookie, ByRef user As String, ByRef password As String, ByRef authority As String) As Boolean _
            Implements IReportServerCredentials.GetFormsCredentials
            authCookie = Nothing
            user = password = authority = Nothing
            Return False
        End Function

    End Class
End Namespace