﻿'------------------------------------------------------------------------------
' <auto-generated>
'     Este código fue generado por una herramienta.
'     Versión del motor en tiempo de ejecución:2.0.50727.6400
'
'     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
'     se vuelve a generar el código.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports System.Runtime.Serialization

Namespace Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad

    <System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0"), _
     System.Runtime.Serialization.CollectionDataContractAttribute(Name:="ListaUsuario", [Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac", ItemName:="Usuario")> _
    Public Class ListaUsuario
        Inherits System.Collections.Generic.List(Of Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.Usuario)
    End Class

    <System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0"), _
     System.Runtime.Serialization.DataContractAttribute(Name:="Usuario", [Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac")> _
    Partial Public Class Usuario
        Inherits Object
        Implements System.Runtime.Serialization.IExtensibleDataObject

        Private extensionDataField As System.Runtime.Serialization.ExtensionDataObject

        Private IdUsuField As Integer

        Private UsuarioUsuField As String

        Private ActivoUsuField As Integer

        Private UsuarioNomField As String

        Private PasswordUsuField As String

        Public Property ExtensionData() As System.Runtime.Serialization.ExtensionDataObject Implements System.Runtime.Serialization.IExtensibleDataObject.ExtensionData
            Get
                Return Me.extensionDataField
            End Get
            Set(value As System.Runtime.Serialization.ExtensionDataObject)
                Me.extensionDataField = value
            End Set
        End Property

        <System.Runtime.Serialization.DataMemberAttribute()> _
        Public Property IdUsu() As Integer
            Get
                Return Me.IdUsuField
            End Get
            Set(value As Integer)
                Me.IdUsuField = value
            End Set
        End Property

        <System.Runtime.Serialization.DataMemberAttribute()> _
        Public Property UsuarioUsu() As String
            Get
                Return Me.UsuarioUsuField
            End Get
            Set(value As String)
                Me.UsuarioUsuField = value
            End Set
        End Property

        <System.Runtime.Serialization.DataMemberAttribute(Order:=2)> _
        Public Property ActivoUsu() As Integer
            Get
                Return Me.ActivoUsuField
            End Get
            Set(value As Integer)
                Me.ActivoUsuField = value
            End Set
        End Property

        <System.Runtime.Serialization.DataMemberAttribute(Order:=3)> _
        Public Property UsuarioNom() As String
            Get
                Return Me.UsuarioNomField
            End Get
            Set(value As String)
                Me.UsuarioNomField = value
            End Set
        End Property

        <System.Runtime.Serialization.DataMemberAttribute(Order:=4)> _
        Public Property PasswordUsu() As String
            Get
                Return Me.PasswordUsuField
            End Get
            Set(value As String)
                Me.PasswordUsuField = value
            End Set
        End Property
    End Class

    <System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0"), _
     System.Runtime.Serialization.CollectionDataContractAttribute(Name:="ListaUsuarioRol", [Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac", ItemName:="UsuarioRol")> _
    Public Class ListaUsuarioRol
        Inherits System.Collections.Generic.List(Of Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.UsuarioRol)
    End Class

    <System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0"), _
     System.Runtime.Serialization.DataContractAttribute(Name:="UsuarioRol", [Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac")> _
    Partial Public Class UsuarioRol
        Inherits Object
        Implements System.Runtime.Serialization.IExtensibleDataObject

        Private extensionDataField As System.Runtime.Serialization.ExtensionDataObject

        Private RolField As Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.Rol

        Private UsuarioField As Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.Usuario

        Public Property ExtensionData() As System.Runtime.Serialization.ExtensionDataObject Implements System.Runtime.Serialization.IExtensibleDataObject.ExtensionData
            Get
                Return Me.extensionDataField
            End Get
            Set(value As System.Runtime.Serialization.ExtensionDataObject)
                Me.extensionDataField = value
            End Set
        End Property

        <System.Runtime.Serialization.DataMemberAttribute()> _
        Public Property Rol() As Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.Rol
            Get
                Return Me.RolField
            End Get
            Set(value As Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.Rol)
                Me.RolField = value
            End Set
        End Property

        <System.Runtime.Serialization.DataMemberAttribute()> _
        Public Property Usuario() As Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.Usuario
            Get
                Return Me.UsuarioField
            End Get
            Set(value As Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.Usuario)
                Me.UsuarioField = value
            End Set
        End Property
    End Class

    <System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0"), _
     System.Runtime.Serialization.DataContractAttribute(Name:="Rol", [Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac")> _
    Partial Public Class Rol
        Inherits Object
        Implements System.Runtime.Serialization.IExtensibleDataObject

        Private extensionDataField As System.Runtime.Serialization.ExtensionDataObject

        Private IdRolField As Integer

        Private NombreRolField As String

        Private ActivoRolField As Boolean

        Private EstadoIdField As Integer

        Public Property ExtensionData() As System.Runtime.Serialization.ExtensionDataObject Implements System.Runtime.Serialization.IExtensibleDataObject.ExtensionData
            Get
                Return Me.extensionDataField
            End Get
            Set(value As System.Runtime.Serialization.ExtensionDataObject)
                Me.extensionDataField = value
            End Set
        End Property

        <System.Runtime.Serialization.DataMemberAttribute()> _
        Public Property IdRol() As Integer
            Get
                Return Me.IdRolField
            End Get
            Set(value As Integer)
                Me.IdRolField = value
            End Set
        End Property

        <System.Runtime.Serialization.DataMemberAttribute()> _
        Public Property NombreRol() As String
            Get
                Return Me.NombreRolField
            End Get
            Set(value As String)
                Me.NombreRolField = value
            End Set
        End Property

        <System.Runtime.Serialization.DataMemberAttribute(Order:=2)> _
        Public Property ActivoRol() As Boolean
            Get
                Return Me.ActivoRolField
            End Get
            Set(value As Boolean)
                Me.ActivoRolField = value
            End Set
        End Property

        <System.Runtime.Serialization.DataMemberAttribute(Order:=3)> _
        Public Property EstadoId() As Integer
            Get
                Return Me.EstadoIdField
            End Get
            Set(value As Integer)
                Me.EstadoIdField = value
            End Set
        End Property
    End Class

    <System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0"), _
     System.Runtime.Serialization.CollectionDataContractAttribute(Name:="ListaRol", [Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac", ItemName:="Rol")> _
    Public Class ListaRol
        Inherits System.Collections.Generic.List(Of Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.Rol)
    End Class

    <System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0"), _
     System.Runtime.Serialization.DataContractAttribute(Name:="Pagina", [Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac")> _
    Partial Public Class Pagina
        Inherits Object
        Implements System.Runtime.Serialization.IExtensibleDataObject

        Private extensionDataField As System.Runtime.Serialization.ExtensionDataObject

        Private IdPaginaField As Integer

        Private NombrePaginaField As String

        Private UrlPaginaField As String

        Private PadrePaginaField As Integer

        Private NivelPaginaField As Integer

        Private ActivoPaginaField As Boolean

        Private VisiblePaginaField As Integer

        Private UrlImagePaginaField As String

        Public Property ExtensionData() As System.Runtime.Serialization.ExtensionDataObject Implements System.Runtime.Serialization.IExtensibleDataObject.ExtensionData
            Get
                Return Me.extensionDataField
            End Get
            Set(value As System.Runtime.Serialization.ExtensionDataObject)
                Me.extensionDataField = value
            End Set
        End Property

        <System.Runtime.Serialization.DataMemberAttribute()> _
        Public Property IdPagina() As Integer
            Get
                Return Me.IdPaginaField
            End Get
            Set(value As Integer)
                Me.IdPaginaField = value
            End Set
        End Property

        <System.Runtime.Serialization.DataMemberAttribute()> _
        Public Property NombrePagina() As String
            Get
                Return Me.NombrePaginaField
            End Get
            Set(value As String)
                Me.NombrePaginaField = value
            End Set
        End Property

        <System.Runtime.Serialization.DataMemberAttribute()> _
        Public Property UrlPagina() As String
            Get
                Return Me.UrlPaginaField
            End Get
            Set(value As String)
                Me.UrlPaginaField = value
            End Set
        End Property

        <System.Runtime.Serialization.DataMemberAttribute(Order:=3)> _
        Public Property PadrePagina() As Integer
            Get
                Return Me.PadrePaginaField
            End Get
            Set(value As Integer)
                Me.PadrePaginaField = value
            End Set
        End Property

        <System.Runtime.Serialization.DataMemberAttribute(Order:=4)> _
        Public Property NivelPagina() As Integer
            Get
                Return Me.NivelPaginaField
            End Get
            Set(value As Integer)
                Me.NivelPaginaField = value
            End Set
        End Property

        <System.Runtime.Serialization.DataMemberAttribute(Order:=5)> _
        Public Property ActivoPagina() As Boolean
            Get
                Return Me.ActivoPaginaField
            End Get
            Set(value As Boolean)
                Me.ActivoPaginaField = value
            End Set
        End Property

        <System.Runtime.Serialization.DataMemberAttribute(Order:=6)> _
        Public Property VisiblePagina() As Integer
            Get
                Return Me.VisiblePaginaField
            End Get
            Set(value As Integer)
                Me.VisiblePaginaField = value
            End Set
        End Property

        <System.Runtime.Serialization.DataMemberAttribute(Order:=7)> _
        Public Property UrlImagePagina() As String
            Get
                Return Me.UrlImagePaginaField
            End Get
            Set(value As String)
                Me.UrlImagePaginaField = value
            End Set
        End Property
    End Class

    <System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0"), _
     System.Runtime.Serialization.CollectionDataContractAttribute(Name:="ListaPagina", [Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac", ItemName:="Pagina")> _
    Public Class ListaPagina
        Inherits System.Collections.Generic.List(Of Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.Pagina)
    End Class

    <System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0"), _
     System.Runtime.Serialization.CollectionDataContractAttribute(Name:="ListaPaginaRol", [Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac", ItemName:="PaginaRol")> _
    Public Class ListaPaginaRol
        Inherits System.Collections.Generic.List(Of Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.PaginaRol)
    End Class

    <System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0"), _
     System.Runtime.Serialization.DataContractAttribute(Name:="PaginaRol", [Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac")> _
    Partial Public Class PaginaRol
        Inherits Object
        Implements System.Runtime.Serialization.IExtensibleDataObject

        Private extensionDataField As System.Runtime.Serialization.ExtensionDataObject

        Private RolField As Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.Rol

        Private PaginaField As Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.Pagina

        Public Property ExtensionData() As System.Runtime.Serialization.ExtensionDataObject Implements System.Runtime.Serialization.IExtensibleDataObject.ExtensionData
            Get
                Return Me.extensionDataField
            End Get
            Set(value As System.Runtime.Serialization.ExtensionDataObject)
                Me.extensionDataField = value
            End Set
        End Property

        <System.Runtime.Serialization.DataMemberAttribute()> _
        Public Property Rol() As Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.Rol
            Get
                Return Me.RolField
            End Get
            Set(value As Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.Rol)
                Me.RolField = value
            End Set
        End Property

        <System.Runtime.Serialization.DataMemberAttribute(Order:=1)> _
        Public Property Pagina() As Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.Pagina
            Get
                Return Me.PaginaField
            End Get
            Set(value As Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.Pagina)
                Me.PaginaField = value
            End Set
        End Property
    End Class

    <System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0"), _
     System.Runtime.Serialization.DataContractAttribute(Name:="Error", [Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac")> _
    Partial Public Class [Error]
        Inherits Object
        Implements System.Runtime.Serialization.IExtensibleDataObject

        Private extensionDataField As System.Runtime.Serialization.ExtensionDataObject

        Private GUIDField As System.Guid

        Private MensajeField As String

        Public Property ExtensionData() As System.Runtime.Serialization.ExtensionDataObject Implements System.Runtime.Serialization.IExtensibleDataObject.ExtensionData
            Get
                Return Me.extensionDataField
            End Get
            Set(value As System.Runtime.Serialization.ExtensionDataObject)
                Me.extensionDataField = value
            End Set
        End Property

        <System.Runtime.Serialization.DataMemberAttribute()> _
        Public Property GUID() As System.Guid
            Get
                Return Me.GUIDField
            End Get
            Set(value As System.Guid)
                Me.GUIDField = value
            End Set
        End Property

        <System.Runtime.Serialization.DataMemberAttribute()> _
        Public Property Mensaje() As String
            Get
                Return Me.MensajeField
            End Get
            Set(value As String)
                Me.MensajeField = value
            End Set
        End Property
    End Class

    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0"), _
     System.ServiceModel.ServiceContractAttribute(ConfigurationName:="Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.IServicioSeguridadSoap")> _
    Public Interface IServicioSeguridadSoap

        <System.ServiceModel.OperationContractAttribute(Action:="http://Sodimac.VentaEmpresa.Model/2013/SCSodimacVentaEmpresaSeguridad/ServicioSeg" & _
            "uridad/ObtenerUsuarios", ReplyAction:="http://tempuri.org/IServicioSeguridadSoap/ObtenerUsuariosResponse"), _
         System.ServiceModel.FaultContractAttribute(GetType(Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.[Error]), Action:="http://tempuri.org/IServicioSeguridadSoap/ObtenerUsuariosErrorFault", Name:="Error", [Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac")> _
        Function ObtenerUsuarios(ByVal IdRol As Integer) As Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.ListaUsuario

        <System.ServiceModel.OperationContractAttribute(Action:="http://Sodimac.VentaEmpresa.Model/2013/SCSodimacVentaEmpresaSeguridad/ServicioSeg" & _
            "uridad/AsignarRolUsuarios", ReplyAction:="http://tempuri.org/IServicioSeguridadSoap/AsignarRolUsuariosResponse"), _
         System.ServiceModel.FaultContractAttribute(GetType(Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.[Error]), Action:="http://tempuri.org/IServicioSeguridadSoap/AsignarRolUsuariosErrorFault", Name:="Error", [Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac")> _
        Function AsignarRolUsuarios(ByVal oListaUsuarioRol As Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.ListaUsuarioRol) As Integer

        <System.ServiceModel.OperationContractAttribute(Action:="http://Sodimac.VentaEmpresa.Model/2013/SCSodimacVentaEmpresaSeguridad/ServicioSeg" & _
            "uridad/AgregarRol", ReplyAction:="http://tempuri.org/IServicioSeguridadSoap/AgregarRolResponse"), _
         System.ServiceModel.FaultContractAttribute(GetType(Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.[Error]), Action:="http://tempuri.org/IServicioSeguridadSoap/AgregarRolErrorFault", Name:="Error", [Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac")> _
        Function AgregarRol(ByVal oRol As Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.Rol) As Integer

        <System.ServiceModel.OperationContractAttribute(Action:="http://Sodimac.VentaEmpresa.Model/2013/SCSodimacVentaEmpresaSeguridad/ServicioSeg" & _
            "uridad/EditarRol", ReplyAction:="http://tempuri.org/IServicioSeguridadSoap/EditarRolResponse"), _
         System.ServiceModel.FaultContractAttribute(GetType(Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.[Error]), Action:="http://tempuri.org/IServicioSeguridadSoap/EditarRolErrorFault", Name:="Error", [Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac")> _
        Function EditarRol(ByVal oRol As Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.Rol) As Integer

        <System.ServiceModel.OperationContractAttribute(Action:="http://Sodimac.VentaEmpresa.Model/2013/SCSodimacVentaEmpresaSeguridad/ServicioSeg" & _
            "uridad/ListarRoles", ReplyAction:="http://tempuri.org/IServicioSeguridadSoap/ListarRolesResponse"), _
         System.ServiceModel.FaultContractAttribute(GetType(Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.[Error]), Action:="http://tempuri.org/IServicioSeguridadSoap/ListarRolesErrorFault", Name:="Error", [Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac")> _
        Function ListarRoles(ByVal oRol As Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.Rol, ByVal sortType As String, ByVal maximumRows As Integer, ByVal startRowIndex As Integer, ByRef Total As Integer) As Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.ListaRol

        <System.ServiceModel.OperationContractAttribute(Action:="http://Sodimac.VentaEmpresa.Model/2013/SCSodimacVentaEmpresaSeguridad/ServicioSeg" & _
            "uridad/DesactivarRol", ReplyAction:="http://tempuri.org/IServicioSeguridadSoap/DesactivarRolResponse"), _
         System.ServiceModel.FaultContractAttribute(GetType(Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.[Error]), Action:="http://tempuri.org/IServicioSeguridadSoap/DesactivarRolErrorFault", Name:="Error", [Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac")> _
        Function DesactivarRol(ByVal oRol As Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.Rol) As Integer

        <System.ServiceModel.OperationContractAttribute(Action:="http://Sodimac.VentaEmpresa.Model/2013/SCSodimacVentaEmpresaSeguridad/ServicioSeg" & _
            "uridad/ObtenerRolPorId", ReplyAction:="http://tempuri.org/IServicioSeguridadSoap/ObtenerRolPorIdResponse"), _
         System.ServiceModel.FaultContractAttribute(GetType(Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.[Error]), Action:="http://tempuri.org/IServicioSeguridadSoap/ObtenerRolPorIdErrorFault", Name:="Error", [Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac")> _
        Function ObtenerRolPorId(ByVal IdRol As Integer) As Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.Rol

        <System.ServiceModel.OperationContractAttribute(Action:="http://Sodimac.VentaEmpresa.Model/2013/SCSodimacVentaEmpresaSeguridad/ServicioSeg" & _
            "uridad/BuscarPagina", ReplyAction:="http://tempuri.org/IServicioSeguridadSoap/BuscarPaginaResponse"), _
         System.ServiceModel.FaultContractAttribute(GetType(Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.[Error]), Action:="http://tempuri.org/IServicioSeguridadSoap/BuscarPaginaErrorFault", Name:="Error", [Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac")> _
        Function BuscarPagina(ByVal oPagina As Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.Pagina) As Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.ListaPagina

        <System.ServiceModel.OperationContractAttribute(Action:="http://Sodimac.VentaEmpresa.Model/2013/SCSodimacVentaEmpresaSeguridad/ServicioSeg" & _
            "uridad/BuscarPaginaRol", ReplyAction:="http://tempuri.org/IServicioSeguridadSoap/BuscarPaginaRolResponse"), _
         System.ServiceModel.FaultContractAttribute(GetType(Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.[Error]), Action:="http://tempuri.org/IServicioSeguridadSoap/BuscarPaginaRolErrorFault", Name:="Error", [Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac")> _
        Function BuscarPaginaRol(ByVal oRol As Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.Rol, ByVal idPagina As Integer, ByVal maximumRows As Integer, ByVal startRowIndex As Integer, ByRef Total As Integer) As Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.ListaRol

        <System.ServiceModel.OperationContractAttribute(Action:="http://Sodimac.VentaEmpresa.Model/2013/SCSodimacVentaEmpresaSeguridad/ServicioSeg" & _
            "uridad/AsignarPerfil", ReplyAction:="http://tempuri.org/IServicioSeguridadSoap/AsignarPerfilResponse"), _
         System.ServiceModel.FaultContractAttribute(GetType(Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.[Error]), Action:="http://tempuri.org/IServicioSeguridadSoap/AsignarPerfilErrorFault", Name:="Error", [Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac")> _
        Function AsignarPerfil(ByVal oListaPaginaRol As Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.ListaPaginaRol) As Integer

        <System.ServiceModel.OperationContractAttribute(Action:="http://Sodimac.VentaEmpresa.Model/2013/SCSodimacVentaEmpresaSeguridad/ServicioSeg" & _
            "uridad/ObtenerRolCheckeado", ReplyAction:="http://tempuri.org/IServicioSeguridadSoap/ObtenerRolCheckeadoResponse"), _
         System.ServiceModel.FaultContractAttribute(GetType(Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.[Error]), Action:="http://tempuri.org/IServicioSeguridadSoap/ObtenerRolCheckeadoErrorFault", Name:="Error", [Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac")> _
        Function ObtenerRolCheckeado(ByVal oPaginaRol As Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.PaginaRol) As Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.ListaRol

        <System.ServiceModel.OperationContractAttribute(Action:="http://Sodimac.VentaEmpresa.Model/2013/SCSodimacVentaEmpresaSeguridad/ServicioSeg" & _
            "uridad/ObtenerRolesPorEstado", ReplyAction:="http://tempuri.org/IServicioSeguridadSoap/ObtenerRolesPorEstadoResponse"), _
         System.ServiceModel.FaultContractAttribute(GetType(Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.[Error]), Action:="http://tempuri.org/IServicioSeguridadSoap/ObtenerRolesPorEstadoErrorFault", Name:="Error", [Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac")> _
        Function ObtenerRolesPorEstado(ByVal oRol As Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.Rol) As Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.ListaRol

        <System.ServiceModel.OperationContractAttribute(Action:="http://Sodimac.VentaEmpresa.Model/2013/SCSodimacVentaEmpresaSeguridad/ServicioSeg" & _
            "uridad/ValidateUser", ReplyAction:="http://tempuri.org/IServicioSeguridadSoap/ValidateUserResponse"), _
         System.ServiceModel.FaultContractAttribute(GetType(Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.[Error]), Action:="http://tempuri.org/IServicioSeguridadSoap/ValidateUserErrorFault", Name:="Error", [Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac")> _
        Function ValidateUser(ByVal oUsuario As Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.Usuario) As Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.Usuario

        <System.ServiceModel.OperationContractAttribute(Action:="http://Sodimac.VentaEmpresa.Model/2013/SCSodimacVentaEmpresaSeguridad/ServicioSeg" & _
            "uridad/ObtenerRolPorUsuario", ReplyAction:="http://tempuri.org/IServicioSeguridadSoap/ObtenerRolPorUsuarioResponse"), _
         System.ServiceModel.FaultContractAttribute(GetType(Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.[Error]), Action:="http://tempuri.org/IServicioSeguridadSoap/ObtenerRolPorUsuarioErrorFault", Name:="Error", [Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac")> _
        Function ObtenerRolPorUsuario(ByVal username As String) As Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.ListaRol

        <System.ServiceModel.OperationContractAttribute(Action:="http://Sodimac.VentaEmpresa.Model/2013/SCSodimacVentaEmpresaSeguridad/ServicioSeg" & _
            "uridad/SiteMapByUser", ReplyAction:="http://tempuri.org/IServicioSeguridadSoap/SiteMapByUserResponse"), _
         System.ServiceModel.FaultContractAttribute(GetType(Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.[Error]), Action:="http://tempuri.org/IServicioSeguridadSoap/SiteMapByUserErrorFault", Name:="Error", [Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac")> _
        Function SiteMapByUser(ByVal username As String) As Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.ListaPagina

        <System.ServiceModel.OperationContractAttribute(Action:="http://Sodimac.VentaEmpresa.Model/2013/SCSodimacVentaEmpresaSeguridad/ServicioSeg" & _
            "uridad/ListarUsuarios", ReplyAction:="http://tempuri.org/IServicioSeguridadSoap/ListarUsuariosResponse"), _
         System.ServiceModel.FaultContractAttribute(GetType(Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.[Error]), Action:="http://tempuri.org/IServicioSeguridadSoap/ListarUsuariosErrorFault", Name:="Error", [Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac")> _
        Function ListarUsuarios(ByVal oUsuario As Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.Usuario, ByVal sortType As String, ByVal maximumRows As Integer, ByVal startRowIndex As Integer, ByRef Total As Integer) As Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.ListaUsuario

        <System.ServiceModel.OperationContractAttribute(Action:="http://Sodimac.VentaEmpresa.Model/2013/SCSodimacVentaEmpresaSeguridad/ServicioSeg" & _
            "uridad/AgregarUsuario", ReplyAction:="http://tempuri.org/IServicioSeguridadSoap/AgregarUsuarioResponse"), _
         System.ServiceModel.FaultContractAttribute(GetType(Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.[Error]), Action:="http://tempuri.org/IServicioSeguridadSoap/AgregarUsuarioErrorFault", Name:="Error", [Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac")> _
        Function AgregarUsuario(ByVal oUsuario As Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.Usuario) As Integer

        <System.ServiceModel.OperationContractAttribute(Action:="http://Sodimac.VentaEmpresa.Model/2013/SCSodimacVentaEmpresaSeguridad/ServicioSeg" & _
            "uridad/EditarUsuario", ReplyAction:="http://tempuri.org/IServicioSeguridadSoap/EditarUsuarioResponse"), _
         System.ServiceModel.FaultContractAttribute(GetType(Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.[Error]), Action:="http://tempuri.org/IServicioSeguridadSoap/EditarUsuarioErrorFault", Name:="Error", [Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac")> _
        Function EditarUsuario(ByVal oUsuario As Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.Usuario) As Integer

        <System.ServiceModel.OperationContractAttribute(Action:="http://Sodimac.VentaEmpresa.Model/2013/SCSodimacVentaEmpresaSeguridad/ServicioSeg" & _
            "uridad/DesactivarUsuario", ReplyAction:="http://tempuri.org/IServicioSeguridadSoap/DesactivarUsuarioResponse"), _
         System.ServiceModel.FaultContractAttribute(GetType(Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.[Error]), Action:="http://tempuri.org/IServicioSeguridadSoap/DesactivarUsuarioErrorFault", Name:="Error", [Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac")> _
        Function DesactivarUsuario(ByVal oUsuario As Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.Usuario) As Integer

        <System.ServiceModel.OperationContractAttribute(Action:="http://Sodimac.VentaEmpresa.Model/2013/SCSodimacVentaEmpresaSeguridad/ServicioSeg" & _
            "uridad/ObtenerUsuarioPorId", ReplyAction:="http://tempuri.org/IServicioSeguridadSoap/ObtenerUsuarioPorIdResponse"), _
         System.ServiceModel.FaultContractAttribute(GetType(Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.[Error]), Action:="http://tempuri.org/IServicioSeguridadSoap/ObtenerUsuarioPorIdErrorFault", Name:="Error", [Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac")> _
        Function ObtenerUsuarioPorId(ByVal IdUsu As Integer) As Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.Usuario
    End Interface

    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")> _
    Public Interface IServicioSeguridadSoapChannel
        Inherits Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.IServicioSeguridadSoap, System.ServiceModel.IClientChannel
    End Interface

    <System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")> _
    Partial Public Class ServicioSeguridadSoapClient
        Inherits System.ServiceModel.ClientBase(Of Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.IServicioSeguridadSoap)
        Implements Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.IServicioSeguridadSoap

        Public Sub New()
            MyBase.New()
        End Sub

        Public Sub New(ByVal endpointConfigurationName As String)
            MyBase.New(endpointConfigurationName)
        End Sub

        Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As String)
            MyBase.New(endpointConfigurationName, remoteAddress)
        End Sub

        Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
            MyBase.New(endpointConfigurationName, remoteAddress)
        End Sub

        Public Sub New(ByVal binding As System.ServiceModel.Channels.Binding, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
            MyBase.New(binding, remoteAddress)
        End Sub

        Public Function ObtenerUsuarios(ByVal IdRol As Integer) As Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.ListaUsuario Implements Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.IServicioSeguridadSoap.ObtenerUsuarios
            Return MyBase.Channel.ObtenerUsuarios(IdRol)
        End Function

        Public Function AsignarRolUsuarios(ByVal oListaUsuarioRol As Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.ListaUsuarioRol) As Integer Implements Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.IServicioSeguridadSoap.AsignarRolUsuarios
            Return MyBase.Channel.AsignarRolUsuarios(oListaUsuarioRol)
        End Function

        Public Function AgregarRol(ByVal oRol As Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.Rol) As Integer Implements Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.IServicioSeguridadSoap.AgregarRol
            Return MyBase.Channel.AgregarRol(oRol)
        End Function

        Public Function EditarRol(ByVal oRol As Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.Rol) As Integer Implements Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.IServicioSeguridadSoap.EditarRol
            Return MyBase.Channel.EditarRol(oRol)
        End Function

        Public Function ListarRoles(ByVal oRol As Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.Rol, ByVal sortType As String, ByVal maximumRows As Integer, ByVal startRowIndex As Integer, ByRef Total As Integer) As Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.ListaRol Implements Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.IServicioSeguridadSoap.ListarRoles
            Return MyBase.Channel.ListarRoles(oRol, sortType, maximumRows, startRowIndex, Total)
        End Function

        Public Function DesactivarRol(ByVal oRol As Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.Rol) As Integer Implements Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.IServicioSeguridadSoap.DesactivarRol
            Return MyBase.Channel.DesactivarRol(oRol)
        End Function

        Public Function ObtenerRolPorId(ByVal IdRol As Integer) As Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.Rol Implements Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.IServicioSeguridadSoap.ObtenerRolPorId
            Return MyBase.Channel.ObtenerRolPorId(IdRol)
        End Function

        Public Function BuscarPagina(ByVal oPagina As Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.Pagina) As Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.ListaPagina Implements Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.IServicioSeguridadSoap.BuscarPagina
            Return MyBase.Channel.BuscarPagina(oPagina)
        End Function

        Public Function BuscarPaginaRol(ByVal oRol As Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.Rol, ByVal idPagina As Integer, ByVal maximumRows As Integer, ByVal startRowIndex As Integer, ByRef Total As Integer) As Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.ListaRol Implements Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.IServicioSeguridadSoap.BuscarPaginaRol
            Return MyBase.Channel.BuscarPaginaRol(oRol, idPagina, maximumRows, startRowIndex, Total)
        End Function

        Public Function AsignarPerfil(ByVal oListaPaginaRol As Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.ListaPaginaRol) As Integer Implements Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.IServicioSeguridadSoap.AsignarPerfil
            Return MyBase.Channel.AsignarPerfil(oListaPaginaRol)
        End Function

        Public Function ObtenerRolCheckeado(ByVal oPaginaRol As Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.PaginaRol) As Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.ListaRol Implements Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.IServicioSeguridadSoap.ObtenerRolCheckeado
            Return MyBase.Channel.ObtenerRolCheckeado(oPaginaRol)
        End Function

        Public Function ObtenerRolesPorEstado(ByVal oRol As Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.Rol) As Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.ListaRol Implements Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.IServicioSeguridadSoap.ObtenerRolesPorEstado
            Return MyBase.Channel.ObtenerRolesPorEstado(oRol)
        End Function

        Public Function ValidateUser(ByVal oUsuario As Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.Usuario) As Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.Usuario Implements Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.IServicioSeguridadSoap.ValidateUser
            Return MyBase.Channel.ValidateUser(oUsuario)
        End Function

        Public Function ObtenerRolPorUsuario(ByVal username As String) As Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.ListaRol Implements Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.IServicioSeguridadSoap.ObtenerRolPorUsuario
            Return MyBase.Channel.ObtenerRolPorUsuario(username)
        End Function

        Public Function SiteMapByUser(ByVal username As String) As Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.ListaPagina Implements Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.IServicioSeguridadSoap.SiteMapByUser
            Return MyBase.Channel.SiteMapByUser(username)
        End Function

        Public Function ListarUsuarios(ByVal oUsuario As Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.Usuario, ByVal sortType As String, ByVal maximumRows As Integer, ByVal startRowIndex As Integer, ByRef Total As Integer) As Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.ListaUsuario Implements Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.IServicioSeguridadSoap.ListarUsuarios
            Return MyBase.Channel.ListarUsuarios(oUsuario, sortType, maximumRows, startRowIndex, Total)
        End Function

        Public Function AgregarUsuario(ByVal oUsuario As Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.Usuario) As Integer Implements Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.IServicioSeguridadSoap.AgregarUsuario
            Return MyBase.Channel.AgregarUsuario(oUsuario)
        End Function

        Public Function EditarUsuario(ByVal oUsuario As Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.Usuario) As Integer Implements Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.IServicioSeguridadSoap.EditarUsuario
            Return MyBase.Channel.EditarUsuario(oUsuario)
        End Function

        Public Function DesactivarUsuario(ByVal oUsuario As Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.Usuario) As Integer Implements Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.IServicioSeguridadSoap.DesactivarUsuario
            Return MyBase.Channel.DesactivarUsuario(oUsuario)
        End Function

        Public Function ObtenerUsuarioPorId(ByVal IdUsu As Integer) As Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.Usuario Implements Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad.IServicioSeguridadSoap.ObtenerUsuarioPorId
            Return MyBase.Channel.ObtenerUsuarioPorId(IdUsu)
        End Function
    End Class
End Namespace