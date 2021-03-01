Imports System.ComponentModel.DataAnnotations
Imports Sodimac.VentaEmpresa.Validation.My.Resources

Public Class VentaCarteraMetadata

    Private _Porcentaje As Decimal

    <Required(ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="SoloDecimal")> _
    Public Property Porcentaje() As Decimal
        Get
            Return _Porcentaje
        End Get
        Set(value As Decimal)
            _Porcentaje = value
        End Set
    End Property

    <Required(ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="CampoRequeridoCustom")> _
  <RegularExpression("^(([0-9])|([0-2][0-9])|(3[0-1]))/(([1-9])|(0[1-9])|(1[0-2]))/(([0-9][0-9])|([1-2][0,9][0-9][0-9]))$", ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="FormatoIncorrecto")> _
    Public Property FechaActivacion() As Date
        Get
            Return _fechaActivacion
        End Get
        Set(ByVal value As Date)
            _fechaActivacion = value
        End Set
    End Property
    Private _fechaActivacion As Date

    <Required(ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="CampoRequeridoCustom")> _
  <RegularExpression("^(([0-9])|([0-2][0-9])|(3[0-1]))/(([1-9])|(0[1-9])|(1[0-2]))/(([0-9][0-9])|([1-2][0,9][0-9][0-9]))$", ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="FormatoIncorrecto")> _
    Public Property FechaAsignacion() As Date
        Get
            Return _FechaAsignacion
        End Get
        Set(ByVal value As Date)
            _FechaAsignacion = value
        End Set
    End Property
    Private _FechaAsignacion As Date


End Class
