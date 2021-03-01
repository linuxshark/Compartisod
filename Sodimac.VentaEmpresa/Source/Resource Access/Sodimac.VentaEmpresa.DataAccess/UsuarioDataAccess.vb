Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Security
Imports System.ServiceModel
Imports System.Configuration
Imports System.Security.Principal
Imports System.DirectoryServices
Imports Sodimac.VentaEmpresa.DataAccess
Imports Sodimac.VentaEmpresa.Web.Seguridad.Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad
Imports Microsoft.Practices.EnterpriseLibrary.Logging
Imports System.Text
Imports Sodimac.VentaEmpresa.BusinessEntities
Imports Sodimac.VentaEmpresa.DataContracts

Public Class UsuarioDataAccess

    ' Private oDatabase As Database = EnterpriseLibraryContainer.Current.GetInstance(Of Database)(Conexion.cnsSqlSeguridad)


     Public Shared Function ObtenerDirectorioDominio() As DirectoryEntry
        Dim entry As DirectoryEntry = New DirectoryEntry(ConfigurationManager.AppSettings("PathDomain"))
        entry.AuthenticationType = AuthenticationTypes.Secure
        Return entry
    End Function
    Public Function BuscarNombre(username As String) As Boolean
        Dim entry As DirectoryEntry = ObtenerDirectorioDominio()
        Dim account As [String] = username.Replace("Domain\", "")
        Dim mensaje As String = ""
        Try
            Dim search As New DirectorySearcher(entry)
            search.Filter = "(SAMAccountName=" & account & ")"
            search.PropertiesToLoad.Add("displayName")
            Dim result As SearchResult = search.FindOne()
            If result IsNot Nothing Then
                result.Properties("displayname")(0).ToString()
                Return True
            Else
                mensaje = "Unknown User"
                Return False
            End If
        Catch ex As Exception
            Dim debug As String = ex.Message
            Return ""
        End Try

    End Function



End Class
