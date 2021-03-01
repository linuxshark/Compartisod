Imports Sodimac.VentaEmpresa.DataContracts

Public Class CierreViewModel

    Inherits Parameters
    Private m_Cierre As Cierre
    Private m_ListaMes As List(Of Mes)
    Private m_ListaAño As List(Of Año)
    Private _Paginacion As Paginacion
    Private m_Listacierre As List(Of Cierre)

    Public Property Cierre() As Cierre
        Get
            Return m_Cierre
        End Get
        Set(value As Cierre)
            m_Cierre = value
        End Set
    End Property

    Public Property ListaMes As List(Of Mes)
        Get
            Return m_ListaMes
        End Get
        Set(value As List(Of Mes))
            m_ListaMes = value
        End Set
    End Property

    Public Property ListaAño As List(Of Año)
        Get
            Return m_ListaAño
        End Get
        Set(value As List(Of Año))
            m_ListaAño = value
        End Set
    End Property

    Public Property Paginacion() As Paginacion
        Get
            Return _Paginacion
        End Get
        Set(ByVal value As Paginacion)
            _Paginacion = value
        End Set
    End Property

    Public Property ListaCierre() As List(Of Cierre)
        Get
            Return m_Listacierre
        End Get
        Set(ByVal value As List(Of Cierre))
            m_Listacierre = value
        End Set
    End Property
End Class
