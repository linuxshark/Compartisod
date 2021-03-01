Imports WcfSerialization = System.Runtime.Serialization
Imports System.ComponentModel.DataAnnotations
<WcfSerialization.DataContract([Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac", Name:="BoletaCargadas")> _
Public Class ReprocesoBoletas


    Private _ListarBoletas As List(Of ReprocesoBoletas)
    Public Property ListarBoletas() As List(Of ReprocesoBoletas)
        Get
            Return _ListarBoletas
        End Get
        Set(ByVal value As List(Of ReprocesoBoletas))
            _ListarBoletas = value
        End Set
    End Property


    Private _Anio As Integer
    <WcfSerialization.DataMember(Name:="Ano", IsRequired:=False, Order:=0)> _
    Public Property Anio() As Integer
        Get
            Return _Anio
        End Get
        Set(ByVal value As Integer)
            _Anio = value
        End Set
    End Property

    Private _Mes As Integer
    <WcfSerialization.DataMember(Name:="Mes", IsRequired:=False, Order:=0)> _
    Public Property Mes() As Integer
        Get
            Return _Mes
        End Get
        Set(ByVal value As Integer)
            _Mes = value
        End Set
    End Property

    Private _Dia As Integer
    <WcfSerialization.DataMember(Name:="Dia", IsRequired:=False, Order:=0)> _
    Public Property Dia() As Integer
        Get
            Return _Dia
        End Get
        Set(ByVal value As Integer)
            _Dia = value
        End Set
    End Property
    Private _FechaVenta As Date
    <WcfSerialization.DataMember(Name:="FechaVenta", IsRequired:=False, Order:=0)> _
    Public Property FechaVenta() As Date
        Get
            Return _FechaVenta
        End Get
        Set(ByVal value As Date)
            _FechaVenta = value
        End Set
    End Property

    Private _IdSucursal As Sucursal
    <WcfSerialization.DataMember(Name:="IdSucursal", IsRequired:=False, Order:=0)> _
    Public Property IdSucursal() As Sucursal
        Get
            Return _IdSucursal
        End Get
        Set(ByVal value As Sucursal)
            _IdSucursal = value
        End Set
    End Property

    Private _NumeroDocumento As String
    <WcfSerialization.DataMember(Name:="NumeroDocumento", IsRequired:=False, Order:=0)> _
    Public Property NumeroDocumento() As String
        Get
            Return _NumeroDocumento
        End Get
        Set(ByVal value As String)
            _NumeroDocumento = value
        End Set
    End Property

    Private _Dni As String
    <WcfSerialization.DataMember(Name:="DNI", IsRequired:=False, Order:=0)> _
    Public Property Dni() As String
        Get
            Return _Dni
        End Get
        Set(ByVal value As String)
            _Dni = value
        End Set
    End Property

    Private _FechaFin As Date
    Public Property FechaFin() As Date
        Get
            Return _FechaFin
        End Get
        Set(ByVal value As Date)
            _FechaFin = value
        End Set
    End Property


    Private _ProcesoCarga As ProcesoCarga
    Public Property ProcesoCarga() As ProcesoCarga
        Get
            Return _ProcesoCarga
        End Get
        Set(ByVal value As ProcesoCarga)
            _ProcesoCarga = value
        End Set
    End Property

End Class
