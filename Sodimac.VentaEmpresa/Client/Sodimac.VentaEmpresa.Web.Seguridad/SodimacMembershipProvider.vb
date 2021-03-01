Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Security
Imports System.ServiceModel
Imports System.Configuration
Imports System.Security.Principal
Imports System.DirectoryServices
Imports Sodimac.VentaEmpresa.Web.Seguridad.Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad
Imports Microsoft.Practices.EnterpriseLibrary.Logging

Public Class SodimacMembershipProvider
    Inherits MembershipProvider

    Public Overrides Property ApplicationName() As String
        Get
            Throw New NotImplementedException()
        End Get
        Set(value As String)
            Throw New NotImplementedException()
        End Set
    End Property

    Public Overrides Function ChangePassword(username As String, oldPassword As String, newPassword As String) As Boolean
        Throw New NotImplementedException()
    End Function

    Public Overrides Function ChangePasswordQuestionAndAnswer(username As String, password As String, newPasswordQuestion As String, newPasswordAnswer As String) As Boolean
        Throw New NotImplementedException()
    End Function

    Public Overrides Function CreateUser(username As String, password As String, email As String, passwordQuestion As String, passwordAnswer As String, isApproved As Boolean,
     providerUserKey As Object, ByRef status As MembershipCreateStatus) As MembershipUser
        Throw New NotImplementedException()
    End Function

    Public Overrides Function DeleteUser(username As String, deleteAllRelatedData As Boolean) As Boolean
        Throw New NotImplementedException()
    End Function

    Public Overrides ReadOnly Property EnablePasswordReset() As Boolean
        Get
            Throw New NotImplementedException()
        End Get
    End Property

    Public Overrides ReadOnly Property EnablePasswordRetrieval() As Boolean
        Get
            Throw New NotImplementedException()
        End Get
    End Property

    Public Overrides Function FindUsersByEmail(emailToMatch As String, pageIndex As Integer, pageSize As Integer, ByRef totalRecords As Integer) As MembershipUserCollection
        Throw New NotImplementedException()
    End Function

    Public Overrides Function FindUsersByName(usernameToMatch As String, pageIndex As Integer, pageSize As Integer, ByRef totalRecords As Integer) As MembershipUserCollection
        Throw New NotImplementedException()
    End Function

    Public Overrides Function GetAllUsers(pageIndex As Integer, pageSize As Integer, ByRef totalRecords As Integer) As MembershipUserCollection
        Throw New NotImplementedException()
    End Function

    Public Overrides Function GetNumberOfUsersOnline() As Integer
        Throw New NotImplementedException()
    End Function

    Public Overrides Function GetPassword(username As String, answer As String) As String
        Throw New NotImplementedException()
    End Function

    Public Overrides Function GetUser(username As String, userIsOnline As Boolean) As MembershipUser
        Throw New NotImplementedException()
    End Function

    Public Overrides Function GetUser(providerUserKey As Object, userIsOnline As Boolean) As MembershipUser
        Throw New NotImplementedException()
    End Function

    Public Overrides Function GetUserNameByEmail(email As String) As String
        Throw New NotImplementedException()
    End Function

    Public Overrides ReadOnly Property MaxInvalidPasswordAttempts() As Integer
        Get
            Throw New NotImplementedException()
        End Get
    End Property

    Public Overrides ReadOnly Property MinRequiredNonAlphanumericCharacters() As Integer
        Get
            Throw New NotImplementedException()
        End Get
    End Property

    Public Overrides ReadOnly Property MinRequiredPasswordLength() As Integer
        Get
            Throw New NotImplementedException()
        End Get
    End Property

    Public Overrides ReadOnly Property PasswordAttemptWindow() As Integer
        Get
            Throw New NotImplementedException()
        End Get
    End Property

    Public Overrides ReadOnly Property PasswordFormat() As MembershipPasswordFormat
        Get
            Throw New NotImplementedException()
        End Get
    End Property

    Public Overrides ReadOnly Property PasswordStrengthRegularExpression() As String
        Get
            Throw New NotImplementedException()
        End Get
    End Property

    Public Overrides ReadOnly Property RequiresQuestionAndAnswer() As Boolean
        Get
            Throw New NotImplementedException()
        End Get
    End Property

    Public Overrides ReadOnly Property RequiresUniqueEmail() As Boolean
        Get
            Throw New NotImplementedException()
        End Get
    End Property

    Public Overrides Function ResetPassword(username As String, answer As String) As String
        Throw New NotImplementedException()
    End Function

    Public Overrides Function UnlockUser(userName As String) As Boolean
        Throw New NotImplementedException()
    End Function

    Public Overrides Sub UpdateUser(user As MembershipUser)
        Throw New NotImplementedException()
    End Sub

    Public Overrides Function ValidateUser(username As [String], password As [String]) As Boolean

        Try

            Using oServicioSeguridadSoapClient As New ServicioSeguridadSoapClient()
                'comentar
                Dim entry As DirectoryEntry = New DirectoryEntry(ConfigurationManager.AppSettings("PathDomain"), username, password)
                Dim obj As Object = entry.NativeObject

                Dim flag As [Boolean] = False
                Dim oUsuario As New Usuario()
                oUsuario.UsuarioUsu = username
                oUsuario.PasswordUsu = password

                Dim oUsuario_return As New Usuario()
                oUsuario_return = oServicioSeguridadSoapClient.ValidateUser(oUsuario)

                If oUsuario_return.UsuarioUsu IsNot Nothing Then
                    HttpContext.Current.Session("Usuario") = oUsuario_return
                    HttpContext.Current.Session("UsuarioNombre") = oUsuario_return.UsuarioNom
                    HttpContext.Current.Session("CodigoUsuario") = oUsuario_return.IdUsu
                    HttpContext.Current.Session("UsuarioUsu") = oUsuario_return.UsuarioUsu
                    flag = True
                End If

                Return flag

            End Using

        Catch ex As Exception
            Logger.Write(ex)
        End Try

    End Function
End Class

