﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated from a template.
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Imports WcfSerialization = System.Runtime.Serialization

<WcfSerialization.DataContract([Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac", Name:="EmpleadoDistrito")> _
Public Class EmpleadoDistrito

#Region "Primitive Properties"

    <WcfSerialization.DataMember(Name:="IdClienteTipo", IsRequired:=False, Order:=0)> _
    Public Property IdDistrito() As Integer
        Get
            Return _idDistrito
        End Get
        Set(ByVal value As Integer)

            _idDistrito = value

        End Set
    End Property

    Private _idDistrito As Integer

    <WcfSerialization.DataMember(Name:="CodigoDistrito", IsRequired:=False, Order:=1)> _
    Public Property CodigoDistrito() As String
        Get
            Return _codigoDistrito
        End Get
        Set(ByVal value As String)
            _codigoDistrito = value
        End Set
    End Property

    Private _codigoDistrito As String

    <WcfSerialization.DataMember(Name:="Descripcion", IsRequired:=False, Order:=2)> _
    Public Property Descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property

    Private _descripcion As String

    <WcfSerialization.DataMember(Name:="IdProvincia", IsRequired:=False, Order:=3)> _
    Public Property IdProvincia() As Nullable(Of Integer)
        Get
            Return _idProvincia
        End Get
        Set(ByVal value As Nullable(Of Integer))

            _idProvincia = value

        End Set
    End Property

    Private _idProvincia As Nullable(Of Integer)

#End Region
#Region "Navigation Properties"

    <WcfSerialization.DataMember(Name:="EmpleadoProvincia", IsRequired:=False, Order:=4)> _
    Public Property EmpleadoProvincia() As EmpleadoProvincia
        Get
            Return _EmpleadoProvincia
        End Get
        Set(ByVal value As EmpleadoProvincia)
            _EmpleadoProvincia = value
        End Set
    End Property

    Private _EmpleadoProvincia As EmpleadoProvincia


#End Region


End Class