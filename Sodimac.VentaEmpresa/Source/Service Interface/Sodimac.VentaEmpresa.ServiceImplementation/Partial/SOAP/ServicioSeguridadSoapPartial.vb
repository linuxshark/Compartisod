Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports Sodimac.VentaEmpresa.ServiceContracts
Imports Sodimac.VentaEmpresa.DataContracts
Imports Sodimac.VentaEmpresa.BusinessLogic
Imports WCF = System.ServiceModel
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.WCF

<ExceptionShielding("Service Policy")> _
Partial Public Class ServicioSeguridadSoap
    Implements IServicioSeguridadSoap
    Public Function ObtenerUsuarios(IdRol As Integer) As ListaUsuario Implements IServicioSeguridadSoap.ObtenerUsuarios
        Return New AccountBusinessLogic().ObtenerUsuarios(IdRol)
    End Function

    Public Function AsignarRolUsuarios(oListaUsuarioRol As ListaUsuarioRol) As Integer Implements IServicioSeguridadSoap.AsignarRolUsuarios
        Return New AccountBusinessLogic().AsignarRolUsuarios(oListaUsuarioRol)
    End Function

    Public Function AgregarRol(oRol As Rol) As Integer Implements IServicioSeguridadSoap.AgregarRol
        Return New AccountBusinessLogic().AgregarRol(oRol)
    End Function

    Public Function EditarRol(oRol As Rol) As Integer Implements IServicioSeguridadSoap.EditarRol
        Return New AccountBusinessLogic().EditarRol(oRol)
    End Function

    Public Function ListarRoles(oRol As Rol, sortType As String, maximumRows As Integer, startRowIndex As Integer, ByRef Total As Integer) As ListaRol Implements IServicioSeguridadSoap.ListarRoles
        Return New AccountBusinessLogic().ListarRoles(oRol, sortType, maximumRows, startRowIndex, Total)
    End Function

    Public Function DesactivarRol(oRol As Rol) As Integer Implements IServicioSeguridadSoap.DesactivarRol
        Return New AccountBusinessLogic().DesactivarRol(oRol)
    End Function

    Public Function ObtenerRolPorId(IdRol As Integer) As Rol Implements IServicioSeguridadSoap.ObtenerRolPorId
        Return New AccountBusinessLogic().ObtenerRolPorId(IdRol)
    End Function

    Public Function BuscarPagina(oPagina As Pagina) As ListaPagina Implements IServicioSeguridadSoap.BuscarPagina
        Return New AccountBusinessLogic().BuscarPagina(oPagina)
    End Function

    Public Function BuscarPaginaRol(oRol As Rol, idPagina As Integer, maximumRows As Integer, startRowIndex As Integer, ByRef Total As Integer) As ListaRol Implements IServicioSeguridadSoap.BuscarPaginaRol
        Return New AccountBusinessLogic().BuscarPaginaRol(oRol, idPagina, maximumRows, startRowIndex, Total)
    End Function

    Public Function AsignarPerfil(oListaPaginaRol As ListaPaginaRol) As Integer Implements IServicioSeguridadSoap.AsignarPerfil
        Return New AccountBusinessLogic().AsignarPerfil(oListaPaginaRol)
    End Function

    Public Function ObtenerRolCheckeado(oPaginaRol As PaginaRol) As ListaRol Implements IServicioSeguridadSoap.ObtenerRolCheckeado
        Return New AccountBusinessLogic().ObtenerRolCheckeado(oPaginaRol)
    End Function

    Public Function ObtenerRolesPorEstado(oRol As Rol) As ListaRol Implements IServicioSeguridadSoap.ObtenerRolesPorEstado
        Return New AccountBusinessLogic().ObtenerRolesPorEstado(oRol)
    End Function


    Public Function ValidateUser(oUsuario As Usuario) As Usuario Implements IServicioSeguridadSoap.ValidateUser
        Return New AccountBusinessLogic().ValidateUser(oUsuario)
    End Function

    Public Function ObtenerRolPorUsuario(username As String) As ListaRol Implements IServicioSeguridadSoap.ObtenerRolPorUsuario
        Return New AccountBusinessLogic().ObtenerRolPorUsuario(username)
    End Function

    Public Function SiteMapByUser(username As String) As ListaPagina Implements IServicioSeguridadSoap.SiteMapByUser
        Return New AccountBusinessLogic().SiteMapByUser(username)
    End Function

    Public Function ListarUsuarios(oUsuario As Usuario, sortType As String, maximumRows As Integer, startRowIndex As Integer, ByRef Total As Integer) As ListaUsuario Implements IServicioSeguridadSoap.ListarUsuarios
        Return New AccountBusinessLogic().ListarUsuarios(oUsuario, sortType, maximumRows, startRowIndex, Total)
    End Function

    Public Function AgregarUsuario(oUsuario As Usuario) As Integer Implements IServicioSeguridadSoap.AgregarUsuario
        Return New AccountBusinessLogic().AgregarUsuario(oUsuario)
    End Function

    Public Function EditarUsuario(oUsuario As Usuario) As Integer Implements IServicioSeguridadSoap.EditarUsuario
        Return New AccountBusinessLogic().EditarUsuario(oUsuario)
    End Function

    Public Function DesactivarUsuario(oUsuario As Usuario) As Integer Implements IServicioSeguridadSoap.DesactivarUsuario
        Return New AccountBusinessLogic().DesactivarUsuario(oUsuario)
    End Function

    Public Function ObtenerUsuarioPorId(IdUsu As Integer) As Usuario Implements IServicioSeguridadSoap.ObtenerUsuarioPorId
        Return New AccountBusinessLogic().ObtenerUsuarioPorId(IdUsu)
    End Function
End Class

