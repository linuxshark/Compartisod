Imports System.ComponentModel.DataAnnotations
Imports Sodimac.VentaEmpresa.Validation.My.Resources

Public Class PlanVentaEmpleadoMetadata

    Private _PlanVentaBase As Decimal
    Private _IngresoBasicoMensual As Decimal
    Private m_FechaActivacion As DateTime
    Private _TiempoServicio As Integer


    <Required(ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="SoloDecimal")> _
    Public Property PlanVentaBase() As Decimal
        Get
            Return _PlanVentaBase
        End Get
        Set(value As Decimal)
            _PlanVentaBase = value
        End Set
    End Property
    <Required(ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="SoloDecimal")> _
    Public Property IngresoBasicoMensual() As Decimal
        Get
            Return _IngresoBasicoMensual
        End Get
        Set(value As Decimal)
            _IngresoBasicoMensual = value
        End Set
    End Property
    <Required(ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="CampoRequeridoCustom")> _
    <RegularExpression("^(([0-9])|([0-2][0-9])|(3[0-1]))/(([1-9])|(0[1-9])|(1[0-2]))/(([0-9][0-9])|([1-2][0,9][0-9][0-9]))$", ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="FormatoIncorrecto")> _
    Public Property FechaActivacion() As Nullable(Of Date)
        Get
            Return m_FechaActivacion
        End Get
        Set(value As Nullable(Of Date))
            m_FechaActivacion = value
        End Set
    End Property
    <Required(ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="SoloNumeros")> _
    Public Property TiempoServicio() As Integer
        Get
            Return _TiempoServicio
        End Get
        Set(value As Integer)
            _TiempoServicio = value
        End Set
    End Property
    Private _comboTiempoServicio As Integer
    <Required(ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="SeleccionNecesaria")> _
     Public Property comboTiempoServicio() As Integer
        Get
            Return _comboTiempoServicio
        End Get
        Set(value As Integer)
            _comboTiempoServicio = value
        End Set
    End Property

End Class
