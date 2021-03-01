Public Class ListaErrorCargaMasiva
    Private m_ListaProcesoCargaErrorTotalClienteEmpleado As List(Of CargaMasivaCliente)
    Private m_ListaProcesoCargaErrorTotalCliente As List(Of CargaMasivaCliente)

    Public Property ListaProcesoCargaErrorTotalClienteEmpleado As List(Of CargaMasivaCliente)
        Get
            Return m_ListaProcesoCargaErrorTotalClienteEmpleado
        End Get
        Set(value As List(Of CargaMasivaCliente))
            m_ListaProcesoCargaErrorTotalClienteEmpleado = value
        End Set
    End Property

    Public Property ListaProcesoCargaErrorTotalCliente As List(Of CargaMasivaCliente)
        Get
            Return m_ListaProcesoCargaErrorTotalCliente
        End Get
        Set(value As List(Of CargaMasivaCliente))
            m_ListaProcesoCargaErrorTotalCliente = value
        End Set
    End Property

End Class
