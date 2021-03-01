Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Collections.Specialized
Imports System.ComponentModel
Imports System.Globalization
Imports System.Runtime.Serialization
Imports System.Runtime.CompilerServices
Imports WcfSerialization = System.Runtime.Serialization

<WcfSerialization.DataContract([Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac", Name:="ClienteModoPagoCombo")> _
Public Class ClienteModoPagoCombo

    Private m_IdModoPago As Integer
    Private m_DescripcionModoPago As String
    Private m_Descripcion As String


    <WcfSerialization.DataMember(Name:="IdModoPago", IsRequired:=False, Order:=0)> _
    Public Property IdModoPago() As Integer
        Get
            Return m_IdModoPago
        End Get
        Set(ByVal value As Integer)
            m_IdModoPago = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="DescripcionModoPago", IsRequired:=False, Order:=1)> _
    Public Property DescripcionModoPago() As String
        Get
            Return m_DescripcionModoPago
        End Get
        Set(ByVal value As String)
            m_DescripcionModoPago = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="Descripcion", IsRequired:=False, Order:=2)> _
    Public Property Descripcion() As String
        Get
            Return m_Descripcion
        End Get
        Set(ByVal value As String)
            m_Descripcion = value
        End Set
    End Property
End Class
