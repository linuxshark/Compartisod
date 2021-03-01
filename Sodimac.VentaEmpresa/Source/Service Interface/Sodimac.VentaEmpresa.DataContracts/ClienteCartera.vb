Imports WcfSerialization = System.Runtime.Serialization

<WcfSerialization.DataContract([Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac", Name:="ClienteCartera")>
Public Class ClienteCartera

    Private m_IdEmpresaCliente As Integer
    Private m_RazonSocial As String
    Private m_RUC As String
    Private m_Sucursal As String
    Private m_CodigoSucursal As String
    Private m_Anio As String
    Private m_Mes As String
    Private m_FechaRegistro As String
    Private m_UsuarioRegistro As String
    Private m_FechaModifica As DateTime
    Private m_UsuarioModifica As String
    Private m_Accion As Boolean
    Private m_DesAccion As String
    Private m_CodigoOfisis As String
    Private m_Fechainicio As String
    Private m_FechaFin As String




    <WcfSerialization.DataMember(Name:="IdEmpresaCliente", IsRequired:=False, Order:=0)>
    Public Property IdEmpresaCliente() As Integer
        Get
            Return m_IdEmpresaCliente
        End Get
        Set(ByVal value As Integer)
            m_IdEmpresaCliente = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="RUC", IsRequired:=False, Order:=1)>
    Public Property RUC() As String
        Get
            Return m_RUC
        End Get
        Set(ByVal value As String)
            m_RUC = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="CodigoSucursal", IsRequired:=False, Order:=2)>
    Public Property CodigoSucursal() As String
        Get
            Return m_CodigoSucursal
        End Get
        Set(ByVal value As String)
            m_CodigoSucursal = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="Anio", IsRequired:=False, Order:=3)>
    Public Property Anio() As String
        Get
            Return m_Anio
        End Get
        Set(ByVal value As String)
            m_Anio = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="Mes", IsRequired:=False, Order:=4)>
    Public Property Mes() As String
        Get
            Return m_Mes
        End Get
        Set(ByVal value As String)
            m_Mes = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="FechaRegistro", IsRequired:=False, Order:=5)>
    Public Property FechaRegistro() As String
        Get
            Return m_FechaRegistro
        End Get
        Set(ByVal value As String)
            m_FechaRegistro = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="UsuarioRegistro", IsRequired:=False, Order:=6)>
    Public Property UsuarioRegistro() As String
        Get
            Return m_UsuarioRegistro
        End Get
        Set(ByVal value As String)
            m_UsuarioRegistro = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="FechaModifica", IsRequired:=False, Order:=7)>
    Public Property FechaModifica() As DateTime
        Get
            Return m_FechaModifica
        End Get
        Set(ByVal value As DateTime)
            m_FechaModifica = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="UsuarioModifica", IsRequired:=False, Order:=8)>
    Public Property UsuarioModifica() As String
        Get
            Return m_UsuarioModifica
        End Get
        Set(ByVal value As String)
            m_UsuarioModifica = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="RazonSocial", IsRequired:=False, Order:=9)>
    Public Property RazonSocial() As String
        Get
            Return m_RazonSocial
        End Get
        Set(ByVal value As String)
            m_RazonSocial = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="Sucursal", IsRequired:=False, Order:=10)>
    Public Property Sucursal() As String
        Get
            Return m_Sucursal
        End Get
        Set(ByVal value As String)
            m_Sucursal = value
        End Set
    End Property

    Public Property Accion As Boolean
        Get
            Return m_Accion
        End Get
        Set(value As Boolean)
            m_Accion = value
        End Set
    End Property

    Public Property DesAccion As String
        Get
            Return m_DesAccion
        End Get
        Set(value As String)
            m_DesAccion = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="DescError", IsRequired:=False, Order:=11)>
    Public Property DescError() As String
        Get
            Return _DescError
        End Get
        Set(value As String)
            _DescError = value
        End Set
    End Property
    Protected _DescError As String

    <WcfSerialization.DataMember(Name:="CodigoOfisis", IsRequired:=False, Order:=12)>
    Public Property CodigoOfisis() As String
        Get
            Return m_CodigoOfisis
        End Get
        Set(ByVal value As String)
            m_CodigoOfisis = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="Fechainicio", IsRequired:=False, Order:=13)>
    Public Property Fechainicio() As String
        Get
            Return m_Fechainicio
        End Get
        Set(ByVal value As String)
            m_Fechainicio = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="FechaFin", IsRequired:=False, Order:=14)>
    Public Property FechaFin() As String
        Get
            Return m_FechaFin
        End Get
        Set(ByVal value As String)
            m_FechaFin = value
        End Set
    End Property
End Class
