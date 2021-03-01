Imports Sodimac.VentaEmpresa.DataContracts

Public Class CargaMasivaCliente
    'Private m_RazonSocial As String
    'Private m_RUC As String
    'Private m_NombreComercial As String
    Private m_ClienteVenta As ClienteVenta
    Private m_Departamento As Departamento
    Private m_Provincia As Provincia
    Private m_Distrito As Distrito
    Private m_ClienteSector As ClienteSector
    Private m_ClienteCategoria As ClienteCategoria
    Private m_ClienteTipo As ClienteTipo
    Private m_ClienteContacto As ClienteContacto
    Private m_Empleado As Empleado
    Private m_ProcesoCarga As ProcesoCarga
    Private m_Accion As Boolean
    Private m_DesAccion As String
    Private m_TieneRuc As String

    Public Property TieneRuc As String
        Get
            Return m_TieneRuc
        End Get
        Set(value As String)
            m_TieneRuc = value
        End Set
    End Property

    Public Property DesAccion As String
        Get
            Return m_DesAccion
        End Get
        Set(value As String)
            m_DesAccion = value
        End Set
    End Property

    Public Property Accion As Boolean
        Get
            Return m_Accion
        End Get
        Set(value As Boolean)
            m_Accion = value
        End Set
    End Property

    Public Property ProcesoCarga As ProcesoCarga
        Get
            Return m_ProcesoCarga
        End Get
        Set(value As ProcesoCarga)
            m_ProcesoCarga = value
        End Set
    End Property

    Public Property ClienteVenta As ClienteVenta
        Get
            Return m_ClienteVenta
        End Get
        Set(value As ClienteVenta)
            m_ClienteVenta = value
        End Set
    End Property

    Public Property Departamento As Departamento
        Get
            Return m_Departamento
        End Get
        Set(value As Departamento)
            m_Departamento = value
        End Set
    End Property

    Public Property Provincia As Provincia
        Get
            Return m_Provincia
        End Get
        Set(value As Provincia)
            m_Provincia = value
        End Set
    End Property

    Public Property Distrito As Distrito
        Get
            Return m_Distrito
        End Get
        Set(value As Distrito)
            m_Distrito = value
        End Set
    End Property

    Public Property ClienteSector As ClienteSector
        Get
            Return m_ClienteSector
        End Get
        Set(value As ClienteSector)
            m_ClienteSector = value
        End Set
    End Property

    Public Property ClienteCategoria As ClienteCategoria
        Get
            Return m_ClienteCategoria
        End Get
        Set(value As ClienteCategoria)
            m_ClienteCategoria = value
        End Set
    End Property

    Public Property ClienteTipo As ClienteTipo
        Get
            Return m_ClienteTipo
        End Get
        Set(value As ClienteTipo)
            m_ClienteTipo = value
        End Set
    End Property

    Public Property ClienteContacto As ClienteContacto
        Get
            Return m_ClienteContacto
        End Get
        Set(value As ClienteContacto)
            m_ClienteContacto = value
        End Set
    End Property

    Public Property Empleado As Empleado
        Get
            Return m_Empleado
        End Get
        Set(value As Empleado)
            m_Empleado = value
        End Set
    End Property
End Class
