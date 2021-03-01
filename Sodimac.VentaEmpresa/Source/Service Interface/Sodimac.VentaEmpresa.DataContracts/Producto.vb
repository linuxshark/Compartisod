Imports WcfSerialization = System.Runtime.Serialization
Imports System.ComponentModel.DataAnnotations
Imports Sodimac.VentaEmpresa.DataContracts

<WcfSerialization.DataContract([Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac", Name:="Producto")>
Partial Public Class Producto
    Public m_Item As String
    Public m_Sku As String
    Public m_Descripcion As String
    Public m_Estado As Boolean
    Public m_Seleccion As Boolean

    <WcfSerialization.DataMember(Name:="Item", IsRequired:=False, Order:=0)>
    Public Property Item() As String
        Get
            Return m_Item
        End Get
        Set(value As String)
            m_Item = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="Sku", IsRequired:=False, Order:=1)>
    Public Property Sku() As String
        Get
            Return m_Sku
        End Get
        Set(value As String)
            m_Sku = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="Descripcion", IsRequired:=False, Order:=2)>
    Public Property Descripcion() As String
        Get
            Return m_Descripcion
        End Get
        Set(value As String)
            m_Descripcion = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="Estado", IsRequired:=False, Order:=3)>
    Public Property Estado() As Boolean
        Get
            Return m_Estado
        End Get
        Set(value As Boolean)
            m_Estado = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="Seleccion", IsRequired:=False, Order:=4)>
    Public Property Seleccion() As Boolean
        Get
            Return m_Seleccion
        End Get
        Set(value As Boolean)
            m_Seleccion = value
        End Set
    End Property


    Public Shared Widening Operator CType(v As Producto) As List(Of Object)
        Throw New NotImplementedException()
    End Operator
End Class

