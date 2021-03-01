Imports System.Net
Imports System.Security.Principal
Imports Microsoft.Reporting.WebForms

<Serializable()> _
Public NotInheritable Class ReportServerCredentials
    Implements IReportServerCredentials

    Public ReadOnly Property ImpersonationUser() As WindowsIdentity _
            Implements IReportServerCredentials.ImpersonationUser
        Get

            'Use the default windows user.  Credentials will be
            'provided by the NetworkCredentials property.
            Return Nothing

        End Get
    End Property


    Public ReadOnly Property NetworkCredentials() As ICredentials _
            Implements IReportServerCredentials.NetworkCredentials
        Get
            ' User name
            Dim userName = ConfigurationManager.AppSettings("ReportUser")

            If String.IsNullOrEmpty(userName) Then
                Throw New Exception("Missing user name from web.config file")
            End If

            ' Password
            Dim password = ConfigurationManager.AppSettings("ReportPassword")

            If String.IsNullOrEmpty(password) Then
                Throw New Exception("Missing password from web.config file")
            End If

            ' Domain
            Dim domain = ConfigurationManager.AppSettings("dominioReporte")

            If String.IsNullOrEmpty(domain) Then
                Throw New Exception("Missing domain from web.config file")
            End If

            Return New NetworkCredential(userName, password, domain)
        End Get
    End Property

    Public Function GetFormsCredentials(ByRef authCookie As Cookie, _
                                        ByRef userName As String, _
                                        ByRef password As String, _
                                        ByRef authority As String) _
                                        As Boolean _
            Implements IReportServerCredentials.GetFormsCredentials

        authCookie = Nothing
        userName = Nothing
        password = Nothing
        authority = Nothing

        'Not using form credentials
        Return False

    End Function
End Class
