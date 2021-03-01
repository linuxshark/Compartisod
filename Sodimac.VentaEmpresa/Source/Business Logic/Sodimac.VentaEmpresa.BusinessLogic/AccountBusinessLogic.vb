Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Transactions
Imports Sodimac.VentaEmpresa.BusinessEntities
Imports Sodimac.VentaEmpresa.DataAccess
Imports Sodimac.VentaEmpresa.DataContracts

Public Class AccountBusinessLogic


    'Public Function ValidarUsuarioBD(UsuarioUsu As String) As Integer
    '    Return New AccountDataAccess().ValidarUsuarioBD(UsuarioUsu)
    'End Function

    Public Function ValidateUser(oUsuario As Usuario) As Usuario
        Return New AccountDataAccess().ValidateUser(oUsuario)
    End Function

    Public Function ObtenerUsuarios(IdRol As Integer) As ListaUsuario
        Return New AccountDataAccess().ObtenerUsuarios(IdRol)
    End Function

    Public Function AsignarRolUsuarios(oListaUsuarioRol As ListaUsuarioRol) As Integer

        Dim resultado As Integer = 1

        Using oTransactionScope As New TransactionScope()
            resultado = New AccountDataAccess().DesasignarRolUsuarios(oListaUsuarioRol.First())

            If oListaUsuarioRol.First().Usuario.IdUsu <> 0 Then

                For Each item As UsuarioRol In oListaUsuarioRol
                    resultado = New AccountDataAccess().AsignarRolUsuarios(item)
                Next
            End If
            oTransactionScope.Complete()
        End Using

        Return resultado
    End Function

    Public Function AgregarRol(oRol As Rol) As Integer
        Return New AccountDataAccess().AgregarRol(oRol)
    End Function

    Public Function EditarRol(oRol As Rol) As Integer
        Return New AccountDataAccess().EditarRol(oRol)
    End Function

    Public Function ListarRoles(oRol As Rol, sortType As String, maximumRows As Integer, startRowIndex As Integer, ByRef Total As Integer) As ListaRol
        Return New AccountDataAccess().ListarRoles(oRol, sortType, maximumRows, startRowIndex, Total)
    End Function

    Public Function DesactivarRol(oRol As Rol) As Integer
        Return New AccountDataAccess().DesactivarRol(oRol)
    End Function

    Public Function ObtenerRolPorId(IdRol As Integer) As Rol
        Return New AccountDataAccess().ObtenerRolPorId(IdRol)
    End Function

    Public Function BuscarPagina(oPagina As Pagina) As ListaPagina
        Return New AccountDataAccess().BuscarPagina(oPagina)
    End Function

    Public Function BuscarPaginaRol(oRol As Rol, idPagina As Integer, maximumRows As Integer, startRowIndex As Integer, ByRef Total As Integer) As ListaRol
        Return New AccountDataAccess().BuscarPaginaRol(oRol, idPagina, maximumRows, startRowIndex, Total)
    End Function

    Public Function AsignarPerfil(oListaPaginaRol As ListaPaginaRol) As Integer
        Dim resultado As Integer = 0

        Using oTransactionScope As New TransactionScope()
            resultado = New AccountDataAccess().DesasignarPerfil(oListaPaginaRol.First())

            If resultado >= 0 Then

                For Each item As PaginaRol In oListaPaginaRol
                    resultado = New AccountDataAccess().AsignarPerfil(item)
                Next
            End If
            oTransactionScope.Complete()
        End Using

        Return resultado
    End Function

    Public Function ObtenerRolCheckeado(oPaginaRol As PaginaRol) As ListaRol
        Return New AccountDataAccess().ObtenerRolCheckeado(oPaginaRol)
    End Function

    Public Function ObtenerRolesPorEstado(oRol As Rol) As ListaRol
        Return New AccountDataAccess().ObtenerRolesPorEstado(oRol)
    End Function

    Public Function ObtenerRolPorUsuario(username As String) As ListaRol
        Return New AccountDataAccess().ObtenerRolPorUsuario(username)
    End Function

    Public Function SiteMapByUser(username As String) As ListaPagina
        Return New AccountDataAccess().SiteMapByUser(username)
    End Function

    Public Function ListarUsuarios(oUsuario As Usuario, sortType As String, maximumRows As Integer, startRowIndex As Integer, ByRef Total As Integer) As ListaUsuario
        Return New AccountDataAccess().ListarUsuarios(oUsuario, sortType, maximumRows, startRowIndex, Total)
    End Function

    Public Function AgregarUsuario(oUsuario As Usuario) As Integer
        Return New AccountDataAccess().AgregarUsuario(oUsuario)
    End Function

    Public Function EditarUsuario(oUsuario As Usuario) As Integer
        Return New AccountDataAccess().EditarUsuario(oUsuario)
    End Function

    Public Function DesactivarUsuario(oUsuario As Usuario) As Integer
        Return New AccountDataAccess().DesactivarUsuario(oUsuario)
    End Function

    Public Function ObtenerUsuarioPorId(IdUsu As Integer) As Usuario
        Return New AccountDataAccess().ObtenerUsuarioPorId(IdUsu)
    End Function

    Public Function ValidaEmpleado_NombreUsuarioUsu(UsuarioUsu As String) As Boolean
        Return New AccountDataAccess().ValidaEmpleado_NombreUsuarioUsu(UsuarioUsu)
    End Function

    Public Function ValidaEmpleado_NombreUsuarioUsu_(UsuarioUsu As String) As Integer
        Return New AccountDataAccess().ValidaEmpleado_NombreUsuarioUsu_(UsuarioUsu)
    End Function

    Public Function ListarRol() As ListaRol
        Return New AccountDataAccess().ListarRol()
    End Function

    Public Function EditarSesionUsuario(usuarioUsu As String) As Integer
        Return New AccountDataAccess().EditarSesionUsuario(usuarioUsu)
    End Function

End Class

