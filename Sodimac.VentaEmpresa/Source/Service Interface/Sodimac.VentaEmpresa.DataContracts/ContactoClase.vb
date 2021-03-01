Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Collections.Specialized
Imports System.ComponentModel
Imports System.Globalization
Imports System.Runtime.Serialization
Imports System.Runtime.CompilerServices
Imports WcfSerialization = System.Runtime.Serialization

<WcfSerialization.DataContract([Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac", Name:="ContactoClase")> _
Public Class ContactoClase
#Region "Primitive Properties"

    Private _IdContactoClase As Integer
    <WcfSerialization.DataMember(Name:="IdTabGen", IsRequired:=False, Order:=0)> _
    Public Property IdContactoClase() As Integer
        Get
            Return _IdContactoClase
        End Get
        Set(ByVal value As Integer)
            _IdContactoClase = value

        End Set
    End Property

    Private _descripcion As String
    <WcfSerialization.DataMember(Name:="DescripcionCortaTabGen", IsRequired:=False, Order:=1)> _
    Public Property Descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property

#End Region
End Class