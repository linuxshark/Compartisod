Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports Sodimac.VentaEmpresa.BusinessLogic
Imports Sodimac.VentaEmpresa.Web.Mvc.Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad

Public Class ServicioAccountController

    Public Shared Function ObtenerUsuarios(IdRol As Integer) As ListaUsuario
        Using oServicioSeguridadSoapClient As New ServicioSeguridadSoapClient()
            Return oServicioSeguridadSoapClient.ObtenerUsuarios(IdRol)
        End Using
    End Function

    Public Shared Function AsignarRolUsuarios(oListaUsuarioRol As ListaUsuarioRol) As Integer
        Using oServicioSeguridadSoapClient As New ServicioSeguridadSoapClient()
            Return oServicioSeguridadSoapClient.AsignarRolUsuarios(oListaUsuarioRol)
        End Using
    End Function

    Public Shared Function AgregarRol(oRol As Rol) As Integer
        Using oServicioSeguridadSoapClient As New ServicioSeguridadSoapClient()
            Return oServicioSeguridadSoapClient.AgregarRol(oRol)
        End Using
    End Function

    Public Shared Function EditarRol(oRol As Rol) As Integer
        Using oServicioSeguridadSoapClient As New ServicioSeguridadSoapClient()
            Return oServicioSeguridadSoapClient.EditarRol(oRol)
        End Using
    End Function

    Public Shared Function ListarRoles(oRol As Rol, sortType As String, maximumRows As Integer, startRowIndex As Integer, ByRef Total As Integer) As ListaRol
        Using oServicioSeguridadSoapClient As New ServicioSeguridadSoapClient()
            Return oServicioSeguridadSoapClient.ListarRoles(oRol, sortType, maximumRows, startRowIndex, Total)
        End Using
    End Function

    Public Shared Function DesactivarRol(oRol As Rol) As Integer
        Using oServicioSeguridadSoapClient As New ServicioSeguridadSoapClient()
            Return oServicioSeguridadSoapClient.DesactivarRol(oRol)
        End Using
    End Function

    Public Shared Function ObtenerRolPorId(IdRol As Integer) As Rol
        Using oServicioSeguridadSoapClient As New ServicioSeguridadSoapClient()
            Return oServicioSeguridadSoapClient.ObtenerRolPorId(IdRol)
        End Using
    End Function

    Public Shared Function BuscarPagina(oPagina As Pagina) As ListaPagina
        Using oServicioSeguridadSoapClient As New ServicioSeguridadSoapClient()
            Return oServicioSeguridadSoapClient.BuscarPagina(oPagina)
        End Using
    End Function

    Public Shared Function BuscarPaginaRol(oRol As Rol, idPagina As Integer, maximumRows As Integer, startRowIndex As Integer, ByRef Total As Integer) As ListaRol
        Using oServicioSeguridadSoapClient As New ServicioSeguridadSoapClient()
            Return oServicioSeguridadSoapClient.BuscarPaginaRol(oRol, idPagina, maximumRows, startRowIndex, Total)
        End Using
    End Function

    Public Shared Function AsignarPerfil(oListaPaginaRol As ListaPaginaRol) As Integer
        Using oServicioSeguridadSoapClient As New ServicioSeguridadSoapClient()
            Return oServicioSeguridadSoapClient.AsignarPerfil(oListaPaginaRol)
        End Using
    End Function

    Public Shared Function ObtenerRolCheckeado(oPaginaRol As PaginaRol) As ListaRol
        Using oServicioSeguridadSoapClient As New ServicioSeguridadSoapClient()
            Return oServicioSeguridadSoapClient.ObtenerRolCheckeado(oPaginaRol)
        End Using
    End Function

    Public Shared Function ObtenerRolesPorEstado(oRol As Rol) As ListaRol
        Using oServicioSeguridadSoapClient As New ServicioSeguridadSoapClient()
            Return oServicioSeguridadSoapClient.ObtenerRolesPorEstado(oRol)
        End Using
    End Function

    Public Shared Function ListarUsuarios(oUsuario As Usuario, sortType As String, maximumRows As Integer, startRowIndex As Integer, ByRef Total As Integer) As ListaUsuario
        Using oServicioSeguridadSoapClient As New ServicioSeguridadSoapClient()
            Return oServicioSeguridadSoapClient.ListarUsuarios(oUsuario, sortType, maximumRows, startRowIndex, Total)
        End Using
    End Function

    Public Shared Function AgregarUsuario(oUsuario As Usuario) As Integer
        Using oServicioSeguridadSoapClient As New ServicioSeguridadSoapClient()
            Return oServicioSeguridadSoapClient.AgregarUsuario(oUsuario)
        End Using
    End Function

    Public Shared Function EditarUsuario(oUsuario As Usuario) As Integer
        Using oServicioSeguridadSoapClient As New ServicioSeguridadSoapClient()
            Return oServicioSeguridadSoapClient.EditarUsuario(oUsuario)
        End Using
    End Function

    Public Shared Function DesactivarUsuario(oUsuario As Usuario) As Integer
        Using oServicioSeguridadSoapClient As New ServicioSeguridadSoapClient()
            Return oServicioSeguridadSoapClient.DesactivarUsuario(oUsuario)
        End Using
    End Function

    Public Shared Function ObtenerUsuarioPorId(IdUsu As Integer) As Usuario
        Using oServicioSeguridadSoapClient As New ServicioSeguridadSoapClient()
            Return oServicioSeguridadSoapClient.ObtenerUsuarioPorId(IdUsu)
        End Using
    End Function


    Public Shared Function ValidaEmpleado_NombreUsuarioUsu(UsuarioUsu As String) As Boolean
        Return New AccountBusinessLogic().ValidaEmpleado_NombreUsuarioUsu(UsuarioUsu)
    End Function

 

End Class
