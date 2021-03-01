Imports System.ComponentModel.DataAnnotations
Imports Sodimac.VentaEmpresa.Validation.My.Resources

Public Class FeriadosMetaData

    Private _IdFeriado As Integer
    Private _Mes As Integer
    Private _Dia As Integer
    Private _Anio As Integer
    Private _Descripcion As String
    Private _Activo As Boolean

    Public Property IdFeriado() As Integer
        Get
            Return _IdFeriado
        End Get
        Set(ByVal value As Integer)
            _IdFeriado = value
        End Set
    End Property

    <Display(Name:="Mes :")>
    <Required(ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="CampoRequeridoCustom")>
    <RegularExpression("[0-9]+", ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="SoloNumeros")> _
    Public Property Mes() As Integer
        Get
            Return _Mes
        End Get
        Set(ByVal value As Integer)
            _Mes = value
        End Set
    End Property

    <Display(Name:="Dia :")>
    <Required(ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="CampoRequeridoCustom")>
    <RegularExpression("[0-9]+", ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="SoloNumeros")> _
    Public Property Dia() As Integer
        Get
            Return _Dia
        End Get
        Set(ByVal value As Integer)
            _Dia = value
        End Set
    End Property

    <Display(Name:="Modalidad :")>
    <RegularExpression("[0-9]+", ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="SoloNumeros")> _
    <Range(1900, 2099, ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="RangeDateWeb")> _
    Public Property Anio() As Integer
        Get
            Return _Anio
        End Get
        Set(ByVal value As Integer)
            _Anio = value
        End Set
    End Property

    <Display(Name:="Descripcion :")>
    <Required(ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="CampoRequeridoCustom")>
    Public Property Descripcion() As String
        Get
            Return _Descripcion
        End Get
        Set(ByVal value As String)
            _Descripcion = value
        End Set
    End Property

    <Display(Name:="Estado :")>
    Public Property Activo() As Boolean
        Get
            Return _Activo
        End Get
        Set(ByVal value As Boolean)
            _Activo = value
        End Set
    End Property

End Class
