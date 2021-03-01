Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Web.Security
Imports System.Collections.Specialized
Imports System.Configuration
Imports System.Security.Principal
Imports System.Web
Imports Sodimac.VentaEmpresa.Web.Seguridad.Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad

Public Class SodimacRoleProvider
    Inherits RoleProvider
    Public Overrides Sub AddUsersToRoles(usernames As String(), roleNames As String())
        Throw New NotImplementedException()
    End Sub
    Public Overrides Property ApplicationName() As String
        Get
            Throw New NotImplementedException()
        End Get
        Set(value As String)
            Throw New NotImplementedException()
        End Set
    End Property

    Public Overrides Sub CreateRole(roleName As String)
        Throw New NotImplementedException()
    End Sub

    Public Overrides Function DeleteRole(roleName As String, throwOnPopulatedRole As Boolean) As Boolean
        Throw New NotImplementedException()
    End Function

    Public Overrides Function FindUsersInRole(roleName As String, usernameToMatch As String) As String()
        Throw New NotImplementedException()
    End Function

    Public Overrides Function GetAllRoles() As String()
        Throw New NotImplementedException()
    End Function

    Public Overrides Function GetRolesForUser(username As String) As String()
        Using oServicioSeguridadSoapClient As New ServicioSeguridadSoapClient()
            Dim roles As New List(Of String)()
            Dim ListaRol As ListaRol = Nothing
            ListaRol = oServicioSeguridadSoapClient.ObtenerRolPorUsuario(username)
            For Each item As Rol In ListaRol
                roles.Add(item.NombreRol)
            Next
            Return roles.ToArray()
        End Using
    End Function

    Public Overrides Function GetUsersInRole(roleName As String) As String()
        Throw New NotImplementedException()
    End Function

    Public Overrides Function IsUserInRole(username As String, roleName As String) As Boolean
        Throw New NotImplementedException()
    End Function

    Public Overrides Sub RemoveUsersFromRoles(usernames As String(), roleNames As String())
        Throw New NotImplementedException()
    End Sub

    Public Overrides Function RoleExists(roleName As String) As Boolean
        Throw New NotImplementedException()
    End Function
End Class

