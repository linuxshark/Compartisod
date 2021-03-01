Imports System.ComponentModel.DataAnnotations
Imports Sodimac.VentaEmpresa.Validation.My.Resources
Public Class SucursalMetadata
    <Required(ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="CampoRequeridoCustom")> _
    <StringLength(100, MinimumLength:=3, ErrorMessageResourceName:="LongitudCadena", ErrorMessageResourceType:=GetType(Validaciones))> _
    Public Property Descripcion() As String
        Get
            Return m_Descripcion
        End Get
        Set(value As String)
            m_Descripcion = value
        End Set
    End Property
    Private m_Descripcion As String
    <Required(ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="CampoRequeridoCustom")> _
    <StringLength(100, MinimumLength:=3, ErrorMessageResourceName:="LongitudCadena", ErrorMessageResourceType:=GetType(Validaciones))> _
    Public Property DescripcionCorta() As String
        Get
            Return m_DescripcionCorta
        End Get
        Set(value As String)
            m_DescripcionCorta = value
        End Set
    End Property
    Private m_DescripcionCorta As String

    Private _IdSucursal As Integer
    <Required(ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="CampoRequeridoCustom")> _
    Public Property IdSucursal() As Nullable(Of Integer)
        Get
            Return _IdSucursal
        End Get
        Set(ByVal value As Nullable(Of Integer))
            _IdSucursal = value
        End Set
    End Property
End Class
