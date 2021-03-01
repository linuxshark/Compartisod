Imports WcfSerialization = System.Runtime.Serialization
Imports System.ComponentModel.DataAnnotations

<WcfSerialization.DataContract([Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac", Name:="Feriados")>
<MetadataType(GetType(Validation.FeriadosMetaData))>
Public Class Feriados

    Private _IdFeriado As Integer
    Private _Mes As Integer
    Private _Dia As Integer
    Private _Anio As Integer
    Private _Descripcion As String
    Private _Activo As Boolean

    Private _NombreMes As String
    Private _DescripcionAnio As String

    Private _busqMes As String
    Private _busqModalidad As String
    Private _busqEstado As String

    Public Property IdFeriado() As Integer
        Get
            Return _IdFeriado
        End Get
        Set(ByVal value As Integer)
            _IdFeriado = value
        End Set
    End Property

    Public Property Mes() As Integer
        Get
            Return _Mes
        End Get
        Set(ByVal value As Integer)
            _Mes = value
        End Set
    End Property

    Public Property Dia() As Integer
        Get
            Return _Dia
        End Get
        Set(ByVal value As Integer)
            _Dia = value
        End Set
    End Property

    Public Property Anio() As Integer
        Get
            Return _Anio
        End Get
        Set(ByVal value As Integer)
            _Anio = value
        End Set
    End Property

    Public Property Descripcion() As String
        Get
            Return _Descripcion
        End Get
        Set(ByVal value As String)
            _Descripcion = value
        End Set
    End Property

    Public Property Activo() As Boolean
        Get
            Return _Activo
        End Get
        Set(ByVal value As Boolean)
            _Activo = value
        End Set
    End Property

    Public Property NombreMes() As String
        Get
            Return _NombreMes
        End Get
        Set(ByVal value As String)
            _NombreMes = value
        End Set
    End Property

    Public Property DescripcionAnio() As String
        Get
            Return _DescripcionAnio
        End Get
        Set(ByVal value As String)
            _DescripcionAnio = value
        End Set
    End Property

    Public Property BusqMes() As String
        Get
            Return _busqMes
        End Get
        Set(ByVal value As String)
            _busqMes = value
        End Set
    End Property

    Public Property BusqModalidad() As String
        Get
            Return _busqModalidad
        End Get
        Set(ByVal value As String)
            _busqModalidad = value
        End Set
    End Property

    Public Property BusqEstado() As String
        Get
            Return _busqEstado
        End Get
        Set(ByVal value As String)
            _busqEstado = value
        End Set
    End Property

End Class
