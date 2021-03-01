Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Security
Imports System.ServiceModel
Imports System.Configuration
Imports System.Security.Principal
Imports System.DirectoryServices
Imports Sodimac.VentaEmpresa.BusinessLogic
Imports Sodimac.VentaEmpresa.DataAccess
Imports Sodimac.VentaEmpresa.Web.Seguridad
Imports Microsoft.Practices.EnterpriseLibrary.Logging
Imports System.Text
Imports System.Transactions
Imports Sodimac.VentaEmpresa.BusinessEntities
Imports Sodimac.VentaEmpresa.DataContracts

Public Class UsuarioBusinessLogic

    Public Shared Function ObtenerDirectorioDominio() As DirectoryEntry
        Dim entry As DirectoryEntry = New DirectoryEntry(ConfigurationManager.AppSettings("PathDomain"))
        entry.AuthenticationType = AuthenticationTypes.Secure
        Return entry
    End Function
    Public Function BuscarNombre(username As String) As Boolean
        Dim entry As DirectoryEntry = ObtenerDirectorioDominio()
        Dim account As [String] = username.Replace("Domain\", "")
        Dim mensaje As String = ""
        Dim valor As Boolean = False

        Try
            Dim search As New DirectorySearcher(entry)
            search.Filter = "(SAMAccountName=" & account & ")"
            search.PropertiesToLoad.Add("displayName")

            Dim result As SearchResult = search.FindOne()
            '  If IsDBNull(result).ToString() = "" Then
            'If result IsNot Nothing Then
            If IsDBNull(result).ToString() = "" Then
                mensaje = "Unknown User"
                Return False     
            Else
                result.Properties("displayname")(0).ToString()
                Return True
               
            End If
            '    End If
        Catch ex As Exception
            Dim debug As String = ex.Message
            Return False
        End Try
        '   Return valor
    End Function

    Public Function ObtenerNombreCompleto(nombreUsuario As String) As Boolean
        Dim entry As DirectoryEntry = ObtenerDirectorioDominio()
        Dim account As [String] = nombreUsuario.Replace("Domain\", "")
        Dim mensaje As String = ""
        Try
            Dim search As New DirectorySearcher(entry)
            search.Filter = "(givenName=" & account & ")"
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

    'Public Function GetUsersByFirstName(fName As String) As List(Of Usuario)

    '    'UserProfile user;
    '    Dim userlist As New List(Of Usuario)()
    '    Dim filter As String = ""

    '    '_directoryEntry = Nothing
    '    Dim directorySearch As New DirectorySearcher(Usuario)
    '    directorySearch.Asynchronous = True
    '    directorySearch.CacheResults = True
    '    'directorySearch.Filter = "(&(objectClass=user)(SAMAccountName=" + userName + "))";
    '    filter = String.Format("(givenName={0}*", fName)
    '    'filter = "(&(objectClass=user)(objectCategory=person)" + filter + ")";
    '    filter = "(&(objectClass=user)(objectCategory=person)(givenName=" & fName & "*))"


    '    directorySearch.Filter = filter

    '    Dim userCollection As SearchResultCollection = directorySearch.FindAll()
    '    For Each users As SearchResult In userCollection
    '        Dim userEntry As New DirectoryEntry(users.Path, LDAPUser, LDAPPassword)
    '        Dim userInfo As Usuario = ADUserDetail.GetUser(userEntry)


    '        userlist.Add(userInfo)
    '    Next

    '    directorySearch.Filter = "(&(objectClass=group)(SAMAccountName=" & fName & "*))"
    '    Dim results As SearchResultCollection = directorySearch.FindAll()
    '    If results IsNot Nothing Then

    '        For Each r As SearchResult In results
    '            Dim deGroup As New DirectoryEntry(r.Path, LDAPUser, LDAPPassword)
    '            ' ADUserDetail dhan = new ADUserDetail();
    '            Dim agroup As ADUserDetail = ADUserDetail.GetUser(deGroup)
    '            userlist.Add(agroup)

    '        Next
    '    End If
    '    Return userlist
    'End Function

    Private ReadOnly Property LDAPPath() As String
        Get
            Return ConfigurationManager.AppSettings("PathDomain")
        End Get
    End Property


    Private ReadOnly Property LDAPUser() As [String]
        Get
            Return ConfigurationManager.AppSettings("LDAPUser")
        End Get
    End Property

    Private ReadOnly Property LDAPPassword() As [String]
        Get
            Return ConfigurationManager.AppSettings("LDAPPassword")
        End Get
    End Property

    'Private ReadOnly Property SearchRoot() As DirectoryEntry
    '    Get
    '        If _directoryEntry Is Nothing Then
    '            _directoryEntry = New DirectoryEntry(LDAPPath, LDAPUser, LDAPPassword, AuthenticationTypes.Secure)
    '        End If
    '        Return _directoryEntry
    '    End Get
    'End Property
    'Public Shared Function GetUser(directoryUser As DirectoryEntry) As Usuario
    '    Return New ADUserDetail(directoryUser)
    'End Function




End Class

