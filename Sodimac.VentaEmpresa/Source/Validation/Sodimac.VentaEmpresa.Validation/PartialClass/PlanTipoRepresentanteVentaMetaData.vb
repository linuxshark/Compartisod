Imports System.ComponentModel.DataAnnotations
Imports Sodimac.VentaEmpresa.Validation.My.Resources

Public Class PlanTipoRepresentanteVentaMetaData

    Private m_IdPlanTipoRepVen As Integer
    Private m_IdTipoRepVen As Integer
    Private m_IdMes As Integer
    Private m_Plan As Decimal
    Private m_FechaRegistro As String

    <Required(ErrorMessage:="Requerido")>
    <Range(1, Int32.MaxValue, ErrorMessage:="Ingrese número mayor a cero")>
    Public Property Plan() As Decimal
        Get
            Return m_Plan
        End Get
        Set(ByVal value As Decimal)
            m_Plan = value
        End Set
    End Property

    Public Property FechaRegistro() As String
        Get
            Return m_FechaRegistro
        End Get
        Set(ByVal value As String)
            m_FechaRegistro = value
        End Set
    End Property

End Class
