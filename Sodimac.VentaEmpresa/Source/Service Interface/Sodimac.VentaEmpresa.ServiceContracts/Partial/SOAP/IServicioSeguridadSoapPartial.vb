Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.ServiceModel
Imports WCF = System.ServiceModel
Imports Sodimac.VentaEmpresa.DataContracts
Imports System.Net.Security

''' <summary>
''' Service Contract Class - ServicioComun
''' </summary>
<ServiceContract()> _
Public Interface IServicioSeguridadSoap
    <WCF.FaultContract(GetType(Sodimac.VentaEmpresa.FaultContracts.Error))> _
    <WCF.OperationContract(IsTerminating:=False, IsInitiating:=True, IsOneWay:=False, AsyncPattern:=False, Action:="http://Sodimac.VentaEmpresa.Model/2013/SCSodimacVentaEmpresaSeguridad/ServicioSeguridad/ObtenerUsuarios", ProtectionLevel:=ProtectionLevel.None)> _
    Function ObtenerUsuarios(IdRol As Integer) As ListaUsuario

    <WCF.FaultContract(GetType(Sodimac.VentaEmpresa.FaultContracts.Error))> _
    <WCF.OperationContract(IsTerminating:=False, IsInitiating:=True, IsOneWay:=False, AsyncPattern:=False, Action:="http://Sodimac.VentaEmpresa.Model/2013/SCSodimacVentaEmpresaSeguridad/ServicioSeguridad/AsignarRolUsuarios", ProtectionLevel:=ProtectionLevel.None)> _
    Function AsignarRolUsuarios(oListaUsuarioRol As ListaUsuarioRol) As Integer

    <WCF.FaultContract(GetType(Sodimac.VentaEmpresa.FaultContracts.Error))> _
    <WCF.OperationContract(IsTerminating:=False, IsInitiating:=True, IsOneWay:=False, AsyncPattern:=False, Action:="http://Sodimac.VentaEmpresa.Model/2013/SCSodimacVentaEmpresaSeguridad/ServicioSeguridad/AgregarRol", ProtectionLevel:=ProtectionLevel.None)> _
    Function AgregarRol(oRol As Rol) As Integer

    <WCF.FaultContract(GetType(Sodimac.VentaEmpresa.FaultContracts.Error))> _
    <WCF.OperationContract(IsTerminating:=False, IsInitiating:=True, IsOneWay:=False, AsyncPattern:=False, Action:="http://Sodimac.VentaEmpresa.Model/2013/SCSodimacVentaEmpresaSeguridad/ServicioSeguridad/EditarRol", ProtectionLevel:=ProtectionLevel.None)> _
    Function EditarRol(oRol As Rol) As Integer

    <WCF.FaultContract(GetType(Sodimac.VentaEmpresa.FaultContracts.Error))> _
    <WCF.OperationContract(IsTerminating:=False, IsInitiating:=True, IsOneWay:=False, AsyncPattern:=False, Action:="http://Sodimac.VentaEmpresa.Model/2013/SCSodimacVentaEmpresaSeguridad/ServicioSeguridad/ListarRoles", ProtectionLevel:=ProtectionLevel.None)> _
    Function ListarRoles(oRol As Rol, sortType As String, maximumRows As Integer, startRowIndex As Integer, ByRef Total As Integer) As ListaRol

    <WCF.FaultContract(GetType(Sodimac.VentaEmpresa.FaultContracts.Error))> _
    <WCF.OperationContract(IsTerminating:=False, IsInitiating:=True, IsOneWay:=False, AsyncPattern:=False, Action:="http://Sodimac.VentaEmpresa.Model/2013/SCSodimacVentaEmpresaSeguridad/ServicioSeguridad/DesactivarRol", ProtectionLevel:=ProtectionLevel.None)> _
    Function DesactivarRol(oRol As Rol) As Integer

    <WCF.FaultContract(GetType(Sodimac.VentaEmpresa.FaultContracts.Error))> _
    <WCF.OperationContract(IsTerminating:=False, IsInitiating:=True, IsOneWay:=False, AsyncPattern:=False, Action:="http://Sodimac.VentaEmpresa.Model/2013/SCSodimacVentaEmpresaSeguridad/ServicioSeguridad/ObtenerRolPorId", ProtectionLevel:=ProtectionLevel.None)> _
    Function ObtenerRolPorId(IdRol As Integer) As Rol

    <WCF.FaultContract(GetType(Sodimac.VentaEmpresa.FaultContracts.Error))> _
    <WCF.OperationContract(IsTerminating:=False, IsInitiating:=True, IsOneWay:=False, AsyncPattern:=False, Action:="http://Sodimac.VentaEmpresa.Model/2013/SCSodimacVentaEmpresaSeguridad/ServicioSeguridad/BuscarPagina", ProtectionLevel:=ProtectionLevel.None)> _
    Function BuscarPagina(oPagina As Pagina) As ListaPagina

    <WCF.FaultContract(GetType(Sodimac.VentaEmpresa.FaultContracts.Error))> _
    <WCF.OperationContract(IsTerminating:=False, IsInitiating:=True, IsOneWay:=False, AsyncPattern:=False, Action:="http://Sodimac.VentaEmpresa.Model/2013/SCSodimacVentaEmpresaSeguridad/ServicioSeguridad/BuscarPaginaRol", ProtectionLevel:=ProtectionLevel.None)> _
    Function BuscarPaginaRol(oRol As Rol, idPagina As Integer, maximumRows As Integer, startRowIndex As Integer, ByRef Total As Integer) As ListaRol

    <WCF.FaultContract(GetType(Sodimac.VentaEmpresa.FaultContracts.Error))> _
    <WCF.OperationContract(IsTerminating:=False, IsInitiating:=True, IsOneWay:=False, AsyncPattern:=False, Action:="http://Sodimac.VentaEmpresa.Model/2013/SCSodimacVentaEmpresaSeguridad/ServicioSeguridad/AsignarPerfil", ProtectionLevel:=ProtectionLevel.None)> _
    Function AsignarPerfil(oListaPaginaRol As ListaPaginaRol) As Integer

    <WCF.FaultContract(GetType(Sodimac.VentaEmpresa.FaultContracts.Error))> _
    <WCF.OperationContract(IsTerminating:=False, IsInitiating:=True, IsOneWay:=False, AsyncPattern:=False, Action:="http://Sodimac.VentaEmpresa.Model/2013/SCSodimacVentaEmpresaSeguridad/ServicioSeguridad/ObtenerRolCheckeado", ProtectionLevel:=ProtectionLevel.None)> _
    Function ObtenerRolCheckeado(oPaginaRol As PaginaRol) As ListaRol

    <WCF.FaultContract(GetType(Sodimac.VentaEmpresa.FaultContracts.Error))> _
    <WCF.OperationContract(IsTerminating:=False, IsInitiating:=True, IsOneWay:=False, AsyncPattern:=False, Action:="http://Sodimac.VentaEmpresa.Model/2013/SCSodimacVentaEmpresaSeguridad/ServicioSeguridad/ObtenerRolesPorEstado", ProtectionLevel:=ProtectionLevel.None)> _
    Function ObtenerRolesPorEstado(oRol As Rol) As ListaRol

    <WCF.FaultContract(GetType(Sodimac.VentaEmpresa.FaultContracts.Error))> _
    <WCF.OperationContract(IsTerminating:=False, IsInitiating:=True, IsOneWay:=False, AsyncPattern:=False, Action:="http://Sodimac.VentaEmpresa.Model/2013/SCSodimacVentaEmpresaSeguridad/ServicioSeguridad/ValidateUser", ProtectionLevel:=ProtectionLevel.None)> _
    Function ValidateUser(oUsuario As Usuario) As Usuario

    <WCF.FaultContract(GetType(Sodimac.VentaEmpresa.FaultContracts.Error))> _
    <WCF.OperationContract(IsTerminating:=False, IsInitiating:=True, IsOneWay:=False, AsyncPattern:=False, Action:="http://Sodimac.VentaEmpresa.Model/2013/SCSodimacVentaEmpresaSeguridad/ServicioSeguridad/ObtenerRolPorUsuario", ProtectionLevel:=ProtectionLevel.None)> _
    Function ObtenerRolPorUsuario(username As String) As ListaRol

    <WCF.FaultContract(GetType(Sodimac.VentaEmpresa.FaultContracts.Error))> _
    <WCF.OperationContract(IsTerminating:=False, IsInitiating:=True, IsOneWay:=False, AsyncPattern:=False, Action:="http://Sodimac.VentaEmpresa.Model/2013/SCSodimacVentaEmpresaSeguridad/ServicioSeguridad/SiteMapByUser", ProtectionLevel:=ProtectionLevel.None)> _
    Function SiteMapByUser(username As String) As ListaPagina

    <WCF.FaultContract(GetType(Sodimac.VentaEmpresa.FaultContracts.Error))> _
    <WCF.OperationContract(IsTerminating:=False, IsInitiating:=True, IsOneWay:=False, AsyncPattern:=False, Action:="http://Sodimac.VentaEmpresa.Model/2013/SCSodimacVentaEmpresaSeguridad/ServicioSeguridad/ListarUsuarios", ProtectionLevel:=ProtectionLevel.None)> _
    Function ListarUsuarios(oUsuario As Usuario, sortType As String, maximumRows As Integer, startRowIndex As Integer, ByRef Total As Integer) As ListaUsuario

    <WCF.FaultContract(GetType(Sodimac.VentaEmpresa.FaultContracts.Error))> _
    <WCF.OperationContract(IsTerminating:=False, IsInitiating:=True, IsOneWay:=False, AsyncPattern:=False, Action:="http://Sodimac.VentaEmpresa.Model/2013/SCSodimacVentaEmpresaSeguridad/ServicioSeguridad/AgregarUsuario", ProtectionLevel:=ProtectionLevel.None)> _
    Function AgregarUsuario(oUsuario As Usuario) As Integer

    <WCF.FaultContract(GetType(Sodimac.VentaEmpresa.FaultContracts.Error))> _
    <WCF.OperationContract(IsTerminating:=False, IsInitiating:=True, IsOneWay:=False, AsyncPattern:=False, Action:="http://Sodimac.VentaEmpresa.Model/2013/SCSodimacVentaEmpresaSeguridad/ServicioSeguridad/EditarUsuario", ProtectionLevel:=ProtectionLevel.None)> _
    Function EditarUsuario(oUsuario As Usuario) As Integer

    <WCF.FaultContract(GetType(Sodimac.VentaEmpresa.FaultContracts.Error))> _
    <WCF.OperationContract(IsTerminating:=False, IsInitiating:=True, IsOneWay:=False, AsyncPattern:=False, Action:="http://Sodimac.VentaEmpresa.Model/2013/SCSodimacVentaEmpresaSeguridad/ServicioSeguridad/DesactivarUsuario", ProtectionLevel:=ProtectionLevel.None)> _
    Function DesactivarUsuario(oUsuario As Usuario) As Integer


    <WCF.FaultContract(GetType(Sodimac.VentaEmpresa.FaultContracts.Error))> _
    <WCF.OperationContract(IsTerminating:=False, IsInitiating:=True, IsOneWay:=False, AsyncPattern:=False, Action:="http://Sodimac.VentaEmpresa.Model/2013/SCSodimacVentaEmpresaSeguridad/ServicioSeguridad/ObtenerUsuarioPorId", ProtectionLevel:=ProtectionLevel.None)> _
    Function ObtenerUsuarioPorId(IdUsu As Integer) As Usuario
End Interface

