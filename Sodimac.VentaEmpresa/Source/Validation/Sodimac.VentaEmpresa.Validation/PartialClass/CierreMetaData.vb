Imports System.ComponentModel.DataAnnotations
Imports Sodimac.VentaEmpresa.Validation.My.Resources

Public Class CierreMetaData
    Private m_IdCierre As Integer
    Private m_Anio As Integer
    Private m_Mes As Integer
    Private m_Fecha As String
    Private m_Estado As String
    Private m_UsuarioRegistro As String
    Private m_UsuarioUpdate As String
    Private m_NombreMes As String

    Public Property IdCierre() As Integer
        Get
            Return m_IdCierre
        End Get
        Set(ByVal value As Integer)
            m_IdCierre = value
        End Set
    End Property

    <Display(Name:="Año :")>
    <Required(ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="CampoRequeridoCustom")>
    <RegularExpression("[0-9]+", ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="SoloNumeros")> _
    Public Property Año() As Integer
        Get
            Return m_Anio
        End Get
        Set(value As Integer)
            m_Anio = value
        End Set
    End Property

    <Display(Name:="Mes :")>
    <Required(ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="CampoRequeridoCustom")>
    <RegularExpression("[0-9]+", ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="SoloNumeros")> _
    Public Property Mes() As Integer
        Get
            Return m_Mes
        End Get
        Set(value As Integer)
            m_Mes = value
        End Set
    End Property

    <Display(Name:="Fecha de Cierre :")>
    <Required(ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="CampoRequeridoCustom")> _
    <RegularExpression("^(([0-9])|([0-2][0-9])|(3[0-1]))/(([1-9])|(0[1-9])|(1[0-2]))/(([0-9][0-9])|([1-2][0,9][0-9][0-9]))$", ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="FormatoIncorrecto")> _
    Public Property FechaCierre() As String
        Get
            Return m_Fecha
        End Get
        Set(value As String)
            m_Fecha = value
        End Set
    End Property

    <Display(Name:="Estado :")>
    Public Property Estado() As String
        Get
            Return m_Estado
        End Get
        Set(value As String)
            m_Estado = value
        End Set
    End Property

    Public Property UsuarioRegistro() As String
        Get
            Return m_UsuarioRegistro
        End Get
        Set(value As String)
            m_UsuarioRegistro = value
        End Set
    End Property

    Public Property UsuarioUpdate() As String
        Get
            Return m_UsuarioUpdate
        End Get
        Set(value As String)
            m_UsuarioUpdate = value
        End Set
    End Property

    Public Property NombreMes() As String
        Get
            Return m_NombreMes
        End Get
        Set(value As String)
            m_NombreMes = value
        End Set
    End Property
End Class
