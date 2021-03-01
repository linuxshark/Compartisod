Imports System.ComponentModel.DataAnnotations
Imports Sodimac.VentaEmpresa.Validation.My.Resources

Public Class CargoMetadata
    <Required(ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="CampoRequeridoCustom")> _
    <StringLength(100, MinimumLength:=3, ErrorMessageResourceName:="LongitudCadena", ErrorMessageResourceType:=GetType(Validaciones))> _
    Public Property NombreCargo() As String
        Get
            Return m_nombreCargo
        End Get
        Set(value As String)
            m_nombreCargo = value
        End Set
    End Property
    Private m_nombreCargo As String
    <Required(ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="CampoRequeridoCustom")> _
    <StringLength(100, MinimumLength:=3, ErrorMessageResourceName:="LongitudCadena", ErrorMessageResourceType:=GetType(Validaciones))> _
    Public Property NombreCargoInferior() As String
        Get
            Return m_NombreCargoInferior
        End Get
        Set(value As String)
            m_NombreCargoInferior = value
        End Set
    End Property
    Private m_NombreCargoInferior As String
End Class
