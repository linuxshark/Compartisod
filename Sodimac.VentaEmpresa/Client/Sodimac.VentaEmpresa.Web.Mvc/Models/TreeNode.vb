Imports System.Collections.Generic
Imports System.Linq
Imports System.Web

Public Class TreeNode
    Public Sub New()
        Me.ChildNodes = New List(Of TreeNode)()
    End Sub
    Public Property Value() As String
        Get
            Return m_Value
        End Get
        Set(value As String)
            m_Value = Value
        End Set
    End Property
    Private m_Value As String
    Public Property Name() As String
        Get
            Return m_Name
        End Get
        Set(value As String)
            m_Name = Value
        End Set
    End Property
    Private m_Name As String
    Public Property Padre() As String
        Get
            Return m_Padre
        End Get
        Set(value As String)
            m_Padre = Value
        End Set
    End Property
    Private m_Padre As String
    Public Property Editable() As Boolean
        Get
            Return m_Editable
        End Get
        Set(value As Boolean)
            m_Editable = Value
        End Set
    End Property
    Private m_Editable As Boolean
    Public Property Max() As Integer
        Get
            Return m_Max
        End Get
        Set(value As Integer)
            m_Max = Value
        End Set
    End Property
    Private m_Max As Integer
    Public Property ChildNodes() As List(Of TreeNode)
        Get
            Return m_ChildNodes
        End Get
        Set(value As List(Of TreeNode))
            m_ChildNodes = Value
        End Set
    End Property
    Private m_ChildNodes As List(Of TreeNode)


End Class
