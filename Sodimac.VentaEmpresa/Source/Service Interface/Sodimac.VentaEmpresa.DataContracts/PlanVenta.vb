Imports WcfSerialization = System.Runtime.Serialization
Imports System.ComponentModel.DataAnnotations

<WcfSerialization.DataContract([Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac", Name:="PlanVenta")> _
Public Class PlanVenta
    Private m_cargo As Cargo
    Private m_comisionEscala As ComisionEscala
    Private m_comisionEscalaRRVV As ComisionEscala
    Private m_comisionEscalaDetalle As ComisionEscalaDetalle
    Private m_comisionEscalaTiempoServicio As ComisionEscalaTiempoServicio
    Private m_ListaComisionEscala As ListaComisionEscala
    Private m_ListaComisionEscalaDetalleJefe As ListaComisionEscalaDetalle
    Private m_ListaComisionEscalaDetalleRRVV As ListaComisionEscalaDetalle
    Private m_ListaComisionEscalaDetalleTiempoServicio As ListaComisionEscalaDetalle
    Private m_ListaComisionEscalaTiempoServicio As ListaComisionEscalaTiempoServicio

    <WcfSerialization.DataMember(Name:="Cargo", IsRequired:=False, Order:=0)> _
    Public Property Cargo() As Cargo
        Get
            Return m_cargo
        End Get
        Set(value As Cargo)
            m_cargo = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="ComisionEscala", IsRequired:=False, Order:=1)> _
    Public Property ComisionEscala() As ComisionEscala
        Get
            Return m_comisionEscala
        End Get
        Set(value As ComisionEscala)
            m_comisionEscala = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="ComisionEscalaDetalle", IsRequired:=False, Order:=2)> _
    Public Property ComisionEscalaDetalle() As ComisionEscalaDetalle
        Get
            Return m_comisionEscalaDetalle
        End Get
        Set(value As ComisionEscalaDetalle)
            m_comisionEscalaDetalle = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="ListaComisionEscala", IsRequired:=False, Order:=3)> _
    Public Property ListaComisionEscala() As ListaComisionEscala
        Get
            Return m_ListaComisionEscala
        End Get
        Set(value As ListaComisionEscala)
            m_ListaComisionEscala = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="ListaComisionEscalaDetalleJefe", IsRequired:=False, Order:=4)> _
    Public Property ListaComisionEscalaDetalleJefe() As ListaComisionEscalaDetalle
        Get
            Return m_ListaComisionEscalaDetalleJefe
        End Get
        Set(value As ListaComisionEscalaDetalle)
            m_ListaComisionEscalaDetalleJefe = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="ListaComisionEscalaDetalleRRVV", IsRequired:=False, Order:=5)> _
    Public Property ListaComisionEscalaDetalleRRVV() As ListaComisionEscalaDetalle
        Get
            Return m_ListaComisionEscalaDetalleRRVV
        End Get
        Set(value As ListaComisionEscalaDetalle)
            m_ListaComisionEscalaDetalleRRVV = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="ComisionEscalaTiempoServicio", IsRequired:=False, Order:=6)> _
    Public Property ComisionEscalaTiempoServicio() As ComisionEscalaTiempoServicio
        Get
            Return m_comisionEscalaTiempoServicio
        End Get
        Set(value As ComisionEscalaTiempoServicio)
            m_comisionEscalaTiempoServicio = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="ListaComisionEscalaTiempoServicio", IsRequired:=False, Order:=7)> _
    Public Property ListaComisionEscalaTiempoServicio() As ListaComisionEscalaTiempoServicio
        Get
            Return m_ListaComisionEscalaTiempoServicio
        End Get
        Set(value As ListaComisionEscalaTiempoServicio)
            m_ListaComisionEscalaTiempoServicio = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="ComisionEscalaRRVV", IsRequired:=False, Order:=8)> _
    Public Property ComisionEscalaRRVV() As ComisionEscala
        Get
            Return m_comisionEscalaRRVV
        End Get
        Set(value As ComisionEscala)
            m_comisionEscalaRRVV = value
        End Set
    End Property

End Class
