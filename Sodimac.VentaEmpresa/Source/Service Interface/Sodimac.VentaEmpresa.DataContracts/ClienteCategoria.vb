'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated from a template.
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Collections.Specialized
Imports System.ComponentModel
Imports System.Globalization
Imports System.Runtime.Serialization
Imports System.Runtime.CompilerServices

Imports WcfSerialization = System.Runtime.Serialization
<WcfSerialization.DataContract([Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac", Name:="ClienteCategoria")> _
Partial Public Class ClienteCategoria

#Region "Primitive Properties"

    <WcfSerialization.DataMember(Name:="IdClienteCategoria", IsRequired:=False, Order:=0)> _
    Public Property IdClienteCategoria() As Integer
        Get
            Return _idClienteCategoria
        End Get
        Set(ByVal value As Integer)

            _idClienteCategoria = value
        End Set
    End Property

    Private _idClienteCategoria As Integer

    <WcfSerialization.DataMember(Name:="Descripcion", IsRequired:=False, Order:=1)> _
    Public Property Descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)

            _descripcion = value

        End Set
    End Property

    Private _descripcion As String

    <WcfSerialization.DataMember(Name:="DescripcionCorta", IsRequired:=False, Order:=2)> _
    Public Property DescripcionCorta() As String
        Get
            Return _descripcionCorta
        End Get
        Set(ByVal value As String)
            _descripcionCorta = value
        End Set
    End Property

    Private _descripcionCorta As String

    <WcfSerialization.DataMember(Name:="FechaDesde", IsRequired:=False, Order:=3)> _
    Public Property FechaDesde() As Nullable(Of Date)
        Get
            Return _fechaDesde
        End Get
        Set(ByVal value As Nullable(Of Date))
            _fechaDesde = value
        End Set
    End Property

    Private _fechaDesde As Nullable(Of Date)

    <WcfSerialization.DataMember(Name:="FechaHasta", IsRequired:=False, Order:=4)> _
    Public Property FechaHasta() As Nullable(Of Date)
        Get
            Return _fechaHasta
        End Get
        Set(ByVal value As Nullable(Of Date))
            _fechaHasta = value
        End Set
    End Property

    Private _fechaHasta As Nullable(Of Date)

    <WcfSerialization.DataMember(Name:="Activo", IsRequired:=False, Order:=5)> _
    Public Property Activo() As Boolean
        Get
            Return _activo
        End Get
        Set(ByVal value As Boolean)
            _activo = value
        End Set
    End Property

    Private _activo As Boolean

#End Region

End Class
