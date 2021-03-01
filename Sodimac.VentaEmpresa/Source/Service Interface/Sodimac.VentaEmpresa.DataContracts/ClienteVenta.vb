﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated from a template.
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Collections.Specialized
Imports System.ComponentModel
Imports System.Globalization
Imports System.Runtime.Serialization
Imports System.Runtime.CompilerServices
Imports System.ComponentModel.DataAnnotations
Imports WcfSerialization = System.Runtime.Serialization

<WcfSerialization.DataContract([Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac", Name:="ClienteVenta")> _
<MetadataType(GetType(Validation.ClienteVentaMetadata))> _
Public Class ClienteVenta

#Region "Primitive Properties"

    <WcfSerialization.DataMember(Name:="IdCliente", IsRequired:=False, Order:=0)> _
    Public Property IdCliente() As Integer
        Get
            Return _idCliente
        End Get
        Set(ByVal value As Integer)
            _idCliente = value
        End Set
    End Property

    Private _idCliente As Integer

    <WcfSerialization.DataMember(Name:="IdClienteCategoria", IsRequired:=False, Order:=1)> _
    Public Property IdClienteCategoria() As Nullable(Of Integer)
        Get
            Return _idClienteCategoria
        End Get
        Set(ByVal value As Nullable(Of Integer))
            _idClienteCategoria = value
        End Set
    End Property

    Private _idClienteCategoria As Nullable(Of Integer)


    <WcfSerialization.DataMember(Name:="IdClienteSector", IsRequired:=False, Order:=2)> _
    Public Property IdClienteSector() As Nullable(Of Integer)
        Get
            Return _idClienteSector
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_idClienteSector, value) Then
                _idClienteSector = value
            End If
        End Set
    End Property

    Private _idClienteSector As Nullable(Of Integer)

    <WcfSerialization.DataMember(Name:="IdClienteTipo", IsRequired:=False, Order:=3)> _
    Public Property IdClienteTipo() As Nullable(Of Integer)
        Get
            Return _idClienteTipo
        End Get
        Set(ByVal value As Nullable(Of Integer))
            _idClienteTipo = value
        End Set
    End Property

    Private _idClienteTipo As Nullable(Of Integer)

    <WcfSerialization.DataMember(Name:="SigicCliente", IsRequired:=False, Order:=4)> _
    Public Property SigicCliente() As Nullable(Of Integer)
        Get
            Return _sigicCliente
        End Get
        Set(ByVal value As Nullable(Of Integer))
            _sigicCliente = value
        End Set
    End Property

    Private _sigicCliente As Nullable(Of Integer)

    <WcfSerialization.DataMember(Name:="SigicFechaRegistro", IsRequired:=False, Order:=5)> _
    Public Property SigicFechaRegistro() As Nullable(Of DateTime)
        Get
            Return _sigicFechaRegistro
        End Get
        Set(ByVal value As Nullable(Of DateTime))
            _sigicFechaRegistro = value
        End Set
    End Property

    Private _sigicFechaRegistro As Nullable(Of DateTime)

    <WcfSerialization.DataMember(Name:="SigicFechaActivacion", IsRequired:=False, Order:=6)> _
    Public Property SigicFechaActivacion() As Nullable(Of DateTime)
        Get
            Return _sigicFechaActivacion
        End Get
        Set(ByVal value As Nullable(Of DateTime))
            _sigicFechaActivacion = value
        End Set
    End Property

    Private _sigicFechaActivacion As Nullable(Of DateTime)

    <WcfSerialization.DataMember(Name:="FechaActivacion", IsRequired:=False, Order:=7)> _
    Public Property FechaActivacion() As DateTime
        Get
            Return _fechaActivacion
        End Get
        Set(ByVal value As DateTime)
            _fechaActivacion = value
        End Set
    End Property
    Private _fechaActivacion As DateTime   
     Private _fechaVigencia As DateTime  

    <WcfSerialization.DataMember(Name:="FechaVigenciaCliente", IsRequired:=False, Order:=56)> _
    Public Property FechaVigenciaCliente() As Nullable(Of Date)
        Get
            Return _fechaVigencia
        End Get
        Set(ByVal value As Nullable(Of Date))
            _fechaVigencia = value
        End Set
    End Property
   

    Private _IdTipoDocumentoCliente As Nullable(Of Integer)

    <WcfSerialization.DataMember(Name:="IdTipoDocumentoCliente", IsRequired:=False, Order:=55)> _
    Public Property IdTipoDocumentoCliente() As Nullable(Of Integer)
        Get
            Return _IdTipoDocumentoCliente
        End Get
        Set(ByVal value As Nullable(Of Integer))
            _IdTipoDocumentoCliente = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="RUC", IsRequired:=False, Order:=8)> _
    Public Property RUC() As String
        Get
            Return _rUC
        End Get
        Set(ByVal value As String)
            _rUC = value
        End Set
    End Property

    Private _rUC As String

    Private _nombreCuenta As String

    <WcfSerialization.DataMember(Name:="NombreRepresentanteLegal", IsRequired:=False, Order:=9)> _
    Public Property NombreRepresentanteLegal() As String
        Get
            Return _nombreRepresentanteLegal
        End Get
        Set(ByVal value As String)
            _nombreRepresentanteLegal = value

        End Set
    End Property

    Private _nombreRepresentanteLegal As String

    <WcfSerialization.DataMember(Name:="ClasificadorExterno", IsRequired:=False, Order:=10)> _
    Public Property ClasificadorExterno() As String
        Get
            Return _clasificadorExterno
        End Get
        Set(ByVal value As String)
            _clasificadorExterno = value
        End Set
    End Property

    Private _clasificadorExterno As String

    <WcfSerialization.DataMember(Name:="Canje", IsRequired:=False, Order:=11)> _
    Public Property Canje() As String
        Get
            Return _canje
        End Get
        Set(ByVal value As String)
            _canje = value
        End Set
    End Property

    Private _canje As String

    <WcfSerialization.DataMember(Name:="IdSucursalResponsable", IsRequired:=False, Order:=12)> _
    Public Property IdSucursalResponsable() As Nullable(Of Integer)
        Get
            Return _idSucursalResponsable
        End Get
        Set(ByVal value As Nullable(Of Integer))

            _idSucursalResponsable = value

        End Set
    End Property

    Private _idSucursalResponsable As Nullable(Of Integer)

    <WcfSerialization.DataMember(Name:="IdEmpleadoPrincipal", IsRequired:=False, Order:=13)> _
    Public Property IdEmpleadoPrincipal() As Nullable(Of Integer)
        Get
            Return _idEmpleadoPrincipal
        End Get
        Set(ByVal value As Nullable(Of Integer))

            _idEmpleadoPrincipal = value

        End Set
    End Property

    Private _idEmpleadoPrincipal As Nullable(Of Integer)

    <WcfSerialization.DataMember(Name:="IdContactoPrincipal", IsRequired:=False, Order:=14)> _
    Public Property IdContactoPrincipal() As String
        Get
            Return _idContactoPrincipal
        End Get
        Set(ByVal value As String)

            _idContactoPrincipal = value

        End Set
    End Property

    Private _idContactoPrincipal As String

    <WcfSerialization.DataMember(Name:="IdDepartamento", IsRequired:=False, Order:=15)> _
    Public Property IdDepartamento() As Nullable(Of Integer)
        Get
            Return _idDepartamento
        End Get
        Set(ByVal value As Nullable(Of Integer))

            _idDepartamento = value

        End Set
    End Property

    Private _idDepartamento As Nullable(Of Integer)

    <WcfSerialization.DataMember(Name:="IdProvincia", IsRequired:=False, Order:=16)> _
    Public Property IdProvincia() As Nullable(Of Integer)
        Get
            Return _idProvincia
        End Get
        Set(ByVal value As Nullable(Of Integer))

            _idProvincia = value

        End Set
    End Property

    Private _idProvincia As Nullable(Of Integer)

    <WcfSerialization.DataMember(Name:="IdDistrito", IsRequired:=False, Order:=17)> _
    Public Property IdDistrito() As Nullable(Of Integer)
        Get
            Return _idDistrito
        End Get
        Set(ByVal value As Nullable(Of Integer))

            _idDistrito = value

        End Set
    End Property

    Private _idDistrito As Nullable(Of Integer)

    <WcfSerialization.DataMember(Name:="Calle", IsRequired:=False, Order:=18)> _
    Public Property Calle() As String
        Get
            Return _calle
        End Get
        Set(ByVal value As String)

            _calle = value

        End Set
    End Property

    Private _calle As String

    <WcfSerialization.DataMember(Name:="Telefono", IsRequired:=False, Order:=19)> _
    Public Property Telefono() As String
        Get
            Return _telefono
        End Get
        Set(ByVal value As String)

            _telefono = value

        End Set
    End Property

    Private _telefono As String

    <WcfSerialization.DataMember(Name:="Fax", IsRequired:=False, Order:=20)> _
    Public Property Fax() As String
        Get
            Return _fax
        End Get
        Set(ByVal value As String)

            _fax = value

        End Set
    End Property

    Private _fax As String

    <WcfSerialization.DataMember(Name:="Email", IsRequired:=False, Order:=21)> _
    Public Property Email() As String
        Get
            Return _email
        End Get
        Set(ByVal value As String)
            _email = value
        End Set
    End Property

    Private _email As String

    <WcfSerialization.DataMember(Name:="FechaDesde", IsRequired:=False, Order:=22)> _
    Public Property FechaDesde() As Nullable(Of Date)
        Get
            Return _fechaDesde
        End Get
        Set(ByVal value As Nullable(Of Date))

            _fechaDesde = value

        End Set
    End Property

    Private _fechaDesde As Nullable(Of Date)

    <WcfSerialization.DataMember(Name:="FechaHasta", IsRequired:=False, Order:=23)> _
    Public Property FechaHasta() As Nullable(Of Date)
        Get
            Return _fechaHasta
        End Get
        Set(ByVal value As Nullable(Of Date))

            _fechaHasta = value

        End Set
    End Property

    Private _fechaHasta As Nullable(Of Date)

    <WcfSerialization.DataMember(Name:="IdEstadoActual", IsRequired:=False, Order:=24)> _
    Public Property IdEstadoActual() As Nullable(Of Integer)
        Get
            Return _IdEstadoActual
        End Get
        Set(ByVal value As Nullable(Of Integer))

            _IdEstadoActual = value

        End Set
    End Property

    Private _IdEstadoActual As Nullable(Of Integer)

    <WcfSerialization.DataMember(Name:="Activo", IsRequired:=False, Order:=25)> _
    Public Property Activo() As Boolean
        Get
            Return _activo
        End Get
        Set(ByVal value As Boolean)

            _activo = value

        End Set
    End Property

    Private _activo As Boolean

    <WcfSerialization.DataMember(Name:="FechaAniversario", IsRequired:=False, Order:=26)> _
    Public Property FechaAniversario() As Nullable(Of Date)
        Get
            Return _FechaAniversario
        End Get
        Set(ByVal value As Nullable(Of Date))
            _FechaAniversario = value
        End Set
    End Property

    Private _FechaAniversario As Nullable(Of Date)
    Public Property UsuarioRegistro() As String
        Get
            Return _UsuarioRegistro
        End Get
        Set(ByVal value As String)
            _UsuarioRegistro = value
        End Set
    End Property

    Private _UsuarioRegistro As String

    Private _ProcesoEstado As ProcesoEstado

    <WcfSerialization.DataMember(Name:="ProcesoEstado", IsRequired:=False, Order:=27)> _
    Public Property ProcesoEstado() As ProcesoEstado
        Get
            Return _ProcesoEstado
        End Get
        Set(ByVal value As ProcesoEstado)
            _ProcesoEstado = value
        End Set
    End Property

    Private _EmpleadoDepartamento As EmpleadoDepartamento

    <WcfSerialization.DataMember(Name:="EmpleadoDepartamento", IsRequired:=False, Order:=28)> _
    Public Property EmpleadoDepartamento() As EmpleadoDepartamento
        Get
            Return _EmpleadoDepartamento
        End Get
        Set(ByVal value As EmpleadoDepartamento)
            _EmpleadoDepartamento = value
        End Set
    End Property

    Private _EmpleadoProvincia As EmpleadoProvincia

    <WcfSerialization.DataMember(Name:="EmpleadoProvincia", IsRequired:=False, Order:=29)> _
    Public Property EmpleadoProvincia() As EmpleadoProvincia
        Get
            Return _EmpleadoProvincia
        End Get
        Set(ByVal value As EmpleadoProvincia)
            _EmpleadoProvincia = value
        End Set
    End Property

    Private _ClienteSector As ClienteSector

    <WcfSerialization.DataMember(Name:="ClienteSector", IsRequired:=False, Order:=30)> _
    Public Property ClienteSector() As ClienteSector
        Get
            Return _ClienteSector
        End Get
        Set(ByVal value As ClienteSector)
            _ClienteSector = value
        End Set
    End Property

    Private _ClienteCategoria As ClienteCategoria

    <WcfSerialization.DataMember(Name:="ClienteCategoria", IsRequired:=False, Order:=31)> _
    Public Property ClienteCategoria() As ClienteCategoria
        Get
            Return _ClienteCategoria
        End Get
        Set(ByVal value As ClienteCategoria)
            _ClienteCategoria = value
        End Set
    End Property

    Private _ClienteTipo As ClienteTipo

    <WcfSerialization.DataMember(Name:="ClienteTipo", IsRequired:=False, Order:=32)> _
    Public Property ClienteTipo() As ClienteTipo
        Get
            Return _ClienteTipo
        End Get
        Set(ByVal value As ClienteTipo)
            _ClienteTipo = value
        End Set
    End Property

    Private __FechaRegistro As Date

    <WcfSerialization.DataMember(Name:="FechaRegistro", IsRequired:=False, Order:=33)> _
    Public Property FechaRegistro() As Date
        Get
            Return __FechaRegistro
        End Get
        Set(ByVal value As Date)
            __FechaRegistro = value
        End Set
    End Property

    Private __FechaModificacion As Date

    <WcfSerialization.DataMember(Name:="FechaModificacion", IsRequired:=False, Order:=35)> _
    Public Property FechaModificacion() As Date
        Get
            Return __FechaModificacion
        End Get
        Set(ByVal value As Date)
            __FechaModificacion = value
        End Set
    End Property

    Private _Estado As Estado

    <WcfSerialization.DataMember(Name:="Estado", IsRequired:=False, Order:=36)> _
    Public Property Estado() As Estado
        Get
            Return _Estado
        End Get
        Set(ByVal value As Estado)
            _Estado = value
        End Set
    End Property



    Private _IdModoPago As Nullable(Of Integer)

    <WcfSerialization.DataMember(Name:="IdModoPago", IsRequired:=False, Order:=37)> _
    Public Property IdModoPago() As Nullable(Of Integer)
        Get
            Return _IdModoPago
        End Get
        Set(ByVal value As Nullable(Of Integer))
            _IdModoPago = value
        End Set
    End Property

    Private _DescripcionModoPago As String

    <WcfSerialization.DataMember(Name:="DescripcionModoPago", IsRequired:=False, Order:=38)> _
    Public Property DescripcionModoPago() As String
        Get
            Return _DescripcionModoPago
        End Get
        Set(ByVal value As String)
            _DescripcionModoPago = value
        End Set
    End Property


    Private _ClienteModoPagoCombo As ClienteModoPagoCombo

    <WcfSerialization.DataMember(Name:="ClienteModoPagoCombo", IsRequired:=False, Order:=39)> _
    Public Property ClienteModoPagoCombo() As ClienteModoPagoCombo
        Get
            Return _ClienteModoPagoCombo
        End Get
        Set(ByVal value As ClienteModoPagoCombo)
            _ClienteModoPagoCombo = value
        End Set
    End Property

    Private _TabGeneral As TablaGeneral
    <WcfSerialization.DataMember(Name:="TabGeneral", IsRequired:=False, Order:=40)> _
    Public Property TabGeneral() As TablaGeneral
        Get
            Return _TabGeneral
        End Get
        Set(ByVal value As TablaGeneral)
            _TabGeneral = value
        End Set
    End Property

    Private _ClienteVenta As ClienteVenta
    <WcfSerialization.DataMember(Name:="ClienteVenta", IsRequired:=False, Order:=41)> _
    Public Property ClienteVenta() As ClienteVenta
        Get
            Return _ClienteVenta
        End Get
        Set(ByVal value As ClienteVenta)
            _ClienteVenta = value
        End Set
    End Property

    Private _DescripcionSucursal As String
    <WcfSerialization.DataMember(Name:="DescripcionSucursal", IsRequired:=False, Order:=42)> _
    Public Property DescripcionSucursal() As String
        Get
            Return _DescripcionSucursal
        End Get
        Set(ByVal value As String)
            _DescripcionSucursal = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="Cuenta", IsRequired:=False, Order:=43)> _
    Public Property Cuenta() As Nullable(Of Byte)
        Get
            Return _cuenta
        End Get
        Set(ByVal value As Nullable(Of Byte))
            _cuenta = value
        End Set
    End Property

    Private _cuenta As Nullable(Of Byte)

    <WcfSerialization.DataMember(Name:="RazonSocial", IsRequired:=False, Order:=44)> _
    Public Property RazonSocial() As String
        Get
            Return _razonSocial
        End Get
        Set(ByVal value As String)
            _razonSocial = value
        End Set
    End Property

    Private _razonSocial As String

    <WcfSerialization.DataMember(Name:="NombreFantasia", IsRequired:=False, Order:=45)> _
    Public Property NombreFantasia() As String
        Get
            Return _nombreFantasia
        End Get
        Set(ByVal value As String)
            _nombreFantasia = value
        End Set
    End Property

    Private _nombreFantasia As String

    <WcfSerialization.DataMember(Name:="NombreCuenta", IsRequired:=False, Order:=46)> _
    Public Property NombreCuenta() As String
        Get
            Return _nombreCuenta
        End Get
        Set(ByVal value As String)
            _nombreCuenta = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="NombresApellidos", IsRequired:=False, Order:=47)> _
    Public Property NombresApellidos() As String
        Get
            Return _nombresapellidos
        End Get
        Set(ByVal value As String)
            _nombresapellidos = value
        End Set
    End Property

    Private _nombresapellidos As String

    Private _FechaRango As Integer
    <WcfSerialization.DataMember(Name:="FechaRango", IsRequired:=False, Order:=48)> _
    Public Property FechaRango() As Integer
        Get
            Return _FechaRango
        End Get
        Set(ByVal value As Integer)
            _FechaRango = value
        End Set
    End Property
    Private _FechaResultado As Integer
    <WcfSerialization.DataMember(Name:="FechaResultado", IsRequired:=False, Order:=49)> _
    Public Property FechaResultado() As Integer
        Get
            Return _FechaResultado
        End Get
        Set(ByVal value As Integer)
            _FechaResultado = value
        End Set
    End Property
    Private _Grupo As Grupo
    <WcfSerialization.DataMember(Name:="Grupo", IsRequired:=False, Order:=50)> _
    Public Property Grupo() As Grupo
        Get
            Return _Grupo
        End Get
        Set(value As Grupo)
            _Grupo = value
        End Set
    End Property

    Private _IdGrupo As Nullable(Of Integer)
    <WcfSerialization.DataMember(Name:="IdGrupo", IsRequired:=False, Order:=51)> _
    Public Property IdGrupo() As Nullable(Of Integer)
        Get
            Return _IdGrupo
        End Get
        Set(value As Nullable(Of Integer))
            _IdGrupo = value
        End Set
    End Property

    Private _RepresentanteVenta As String
    <WcfSerialization.DataMember(Name:="RepresentanteVenta", IsRequired:=False, Order:=52)> _
    Public Property RepresentanteVenta() As String
        Get
            Return _RepresentanteVenta
        End Get
        Set(ByVal value As String)
            _RepresentanteVenta = value
        End Set
    End Property

    Private _DescripcionSector As String
    Public Property DescripcionSector() As String
        Get
            Return _DescripcionSector
        End Get
        Set(value As String)
            _DescripcionSector = value
        End Set
    End Property

    Private _DescripcionTipo As String
    Public Property DescripcionTipo() As String
        Get
            Return _DescripcionTipo
        End Get
        Set(value As String)
            _DescripcionTipo = value
        End Set
    End Property

    Private _NombreZona As String
    Public Property NombreZona() As String
        Get
            Return _NombreZona
        End Get
        Set(value As String)
            _NombreZona = value
        End Set
    End Property
    Private _NombreZonaSecundario As String
    Public Property NombreZonaSecundario() As String
        Get
            Return _NombreZonaSecundario
        End Get
        Set(value As String)
            _NombreZonaSecundario = value
        End Set
    End Property

    Private _DescripcionSucursalSecundario As String
    Public Property DescripcionSucursalSecundario() As String
        Get
            Return _DescripcionSucursalSecundario
        End Get
        Set(value As String)
            _DescripcionSucursalSecundario = value
        End Set
    End Property

    Private _ProcedenciaCapital As String
    Public Property ProcedenciaCapital() As String
        Get
            Return _ProcedenciaCapital
        End Get
        Set(value As String)
            _ProcedenciaCapital = value
        End Set
    End Property

    Private m_Motivo As String
    Public Property Motivo() As String
        Get
            Return m_Motivo
        End Get
        Set(ByVal value As String)
            m_Motivo = value
        End Set
    End Property


    Private m_ModoPagoDes As String
    Public Property ModoPagoDes() As String
        Get
            Return m_ModoPagoDes
        End Get
        Set(ByVal value As String)
            m_ModoPagoDes = value
        End Set
    End Property

    Private m_IdAprobado As String
    Public Property IdAprobado() As String
        Get
            Return m_IdAprobado
        End Get
        Set(ByVal value As String)
            m_IdAprobado = value
        End Set
    End Property


    Private _NumeroTarjeta As String
    Public Property NumeroTarjeta() As String
        Get
            Return _NumeroTarjeta
        End Get
        Set(ByVal value As String)
            _NumeroTarjeta = value
        End Set
    End Property


    Private _Anotacion As String
    Public Property Anotacion() As String
        Get
            Return _Anotacion
        End Get
        Set(ByVal value As String)
            _Anotacion = value
        End Set
    End Property

    Private m_NombreComercial As String
    Public Property NombreComercial As String
        Get
            Return m_NombreComercial
        End Get
        Set(value As String)
            m_NombreComercial = value
        End Set
    End Property

    Private m_Direccion As String
    Public Property Direccion As String
        Get
            Return m_Direccion
        End Get
        Set(value As String)
            m_Direccion = value
        End Set
    End Property

    Private m_FechaIngreso As String
    Public Property FechaIngreso As String
        Get
            Return m_FechaIngreso
        End Get
        Set(value As String)
            m_FechaIngreso = value
        End Set
    End Property

    Private m_FechaVigencia As String
    Public Property FechaVigencia As String
        Get
            Return m_FechaVigencia
        End Get
        Set(value As String)
            m_FechaVigencia = value
        End Set
    End Property

    Private m_Autorizar As String
    Public Property Autorizar As String
        Get
            Return m_Autorizar
        End Get
        Set(value As String)
            m_Autorizar = value
        End Set
    End Property

    Private m_FActivacion As String
    Public Property FActivacion As String
        Get
            Return m_FActivacion
        End Get
        Set(value As String)
            m_FActivacion = value
        End Set
    End Property

#End Region
End Class