Imports WcfSerialization = System.Runtime.Serialization

<WcfSerialization.DataContract([Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac", Name:="ComisionBaseEscala")> _
Public Class ComisionBaseEscala

    Private m_IdComisionBaseEscala As Integer
    Private m_IdComisionBase As Integer
    Private m_IdPerfil As Integer
    Private m_PorcentajeInicial As Decimal
    Private m_PorcentajeFinal As Decimal
    Private m_Bono As Decimal
    Private m_Estado As Integer

    <WcfSerialization.DataMember(Name:="IdComisionBaseEscala", IsRequired:=False, Order:=0)> _
    Public Property IdComisionBaseEscala() As Integer
        Get
            Return m_IdComisionBaseEscala
        End Get
        Set(ByVal value As Integer)
            m_IdComisionBaseEscala = value
        End Set
    End Property


    <WcfSerialization.DataMember(Name:="IdComisionBase", IsRequired:=False, Order:=1)> _
    Public Property IdComisionBase() As Integer
        Get
            Return m_IdComisionBase
        End Get
        Set(ByVal value As Integer)
            m_IdComisionBase = value
        End Set
    End Property


    <WcfSerialization.DataMember(Name:="IdPerfil", IsRequired:=False, Order:=2)> _
    Public Property IdPerfil() As Integer
        Get
            Return m_IdPerfil
        End Get
        Set(ByVal value As Integer)
            m_IdPerfil = value
        End Set
    End Property


    <WcfSerialization.DataMember(Name:="PorcentajeInicial", IsRequired:=False, Order:=3)> _
    Public Property PorcentajeInicial() As Decimal
        Get
            Return m_PorcentajeInicial
        End Get
        Set(ByVal value As Decimal)
            m_PorcentajeInicial = value
        End Set
    End Property


    <WcfSerialization.DataMember(Name:="PorcentajeFinal", IsRequired:=False, Order:=4)> _
    Public Property PorcentajeFinal() As Decimal
        Get
            Return m_PorcentajeFinal
        End Get
        Set(ByVal value As Decimal)
            m_PorcentajeFinal = value
        End Set
    End Property


    <WcfSerialization.DataMember(Name:="Bono", IsRequired:=False, Order:=5)> _
    Public Property Bono() As Decimal
        Get
            Return m_Bono
        End Get
        Set(ByVal value As Decimal)
            m_Bono = value
        End Set
    End Property


    <WcfSerialization.DataMember(Name:="Estado", IsRequired:=False, Order:=6)> _
    Public Property Estado() As Integer
        Get
            Return m_Estado
        End Get
        Set(ByVal value As Integer)
            m_Estado = value
        End Set
    End Property

End Class
