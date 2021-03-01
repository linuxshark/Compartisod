Imports Sodimac.VentaEmpresa.DataContracts

Public Class ClienteVendedorAsociadoViewModel
    Inherits Parameters
    Private m_clienteVenta As ClienteVenta
    Private m_listaClienteVenta As List(Of ClienteVenta)
    Private _Paginacion As Paginacion
    Private m_listaClienteVentaTemp As List(Of ClienteVenta)

    Public Property Paginacion() As Paginacion
        Get
            Return _Paginacion
        End Get
        Set(ByVal value As Paginacion)
            _Paginacion = value
        End Set
    End Property

    Public Property clienteVenta As ClienteVenta
        Get
            Return m_clienteVenta
        End Get
        Set(value As ClienteVenta)
            m_clienteVenta = value
        End Set
    End Property

    Public Property listaClienteVenta As List(Of ClienteVenta)
        Get
            Return m_listaClienteVenta
        End Get
        Set(value As List(Of ClienteVenta))
            m_listaClienteVenta = value
        End Set
    End Property

    Public Property listaClienteVentaTemp As List(Of ClienteVenta)
        Get
            Return m_listaClienteVentaTemp
        End Get
        Set(value As List(Of ClienteVenta))
            m_listaClienteVentaTemp = value
        End Set
    End Property
End Class
