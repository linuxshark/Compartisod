Public Class ListaCargaMasivaCliente
    Private m_lstClienteExiste As List(Of ClienteVenta)
    Private m_lstDepartamento As List(Of Departamento)
    Private m_lstProvincia As List(Of Provincia)
    Private m_lstDistrito As List(Of Distrito)
    Private m_lstCategoria As List(Of ClienteCategoria)
    Private m_lstSector As List(Of ClienteSector)
    Private m_lstTipo As List(Of ClienteTipo)
    Private m_lstGrupo As List(Of Grupo)
    Private m_lstContacto As List(Of ClienteContacto)
    Private m_lstTipoContacto As List(Of TablaGeneral)
    Private m_lstClaseContacto As List(Of TablaGeneral)
    Private m_lstSucursal As List(Of Sucursal)
    Private m_lstEmpleado As List(Of Empleado)
    Private m_lstEmpleadoSecundario As List(Of Empleado)
    Private m_lstTipoVendedor As List(Of TablaGeneral)
    Private m_lstTipoDocumento As List(Of TipoDocumento)

    Public Property lstEmpleadoSecundario As List(Of Empleado)
        Get
            Return m_lstEmpleadoSecundario
        End Get
        Set(value As List(Of Empleado))
            m_lstEmpleadoSecundario = value
        End Set
    End Property

    Public Property lstTipoDocumento As List(Of TipoDocumento)
        Get
            Return m_lstTipoDocumento
        End Get
        Set(value As List(Of TipoDocumento))
            m_lstTipoDocumento = value
        End Set
    End Property

    Public Property lstTipoVendedor As List(Of TablaGeneral)
        Get
            Return m_lstTipoVendedor
        End Get
        Set(value As List(Of TablaGeneral))
            m_lstTipoVendedor = value
        End Set
    End Property

    Public Property lstEmpleado As List(Of Empleado)
        Get
            Return m_lstEmpleado
        End Get
        Set(value As List(Of Empleado))
            m_lstEmpleado = value
        End Set
    End Property

    Public Property lstSucursal As List(Of Sucursal)
        Get
            Return m_lstSucursal
        End Get
        Set(value As List(Of Sucursal))
            m_lstSucursal = value
        End Set
    End Property

    Public Property lstClienteExiste As List(Of ClienteVenta)
        Get
            Return m_lstClienteExiste
        End Get
        Set(value As List(Of ClienteVenta))
            m_lstClienteExiste = value
        End Set
    End Property
    Public Property lstDepartamento As List(Of Departamento)
        Get
            Return m_lstDepartamento
        End Get
        Set(value As List(Of Departamento))
            m_lstDepartamento = value
        End Set
    End Property
    Public Property lstProvincia As List(Of Provincia)
        Get
            Return m_lstProvincia
        End Get
        Set(value As List(Of Provincia))
            m_lstProvincia = value
        End Set
    End Property
    Public Property lstDistrito As List(Of Distrito)
        Get
            Return m_lstDistrito
        End Get
        Set(value As List(Of Distrito))
            m_lstDistrito = value
        End Set
    End Property
    Public Property lstCategoria As List(Of ClienteCategoria)
        Get
            Return m_lstCategoria
        End Get
        Set(value As List(Of ClienteCategoria))
            m_lstCategoria = value
        End Set
    End Property
    Public Property lstSector As List(Of ClienteSector)
        Get
            Return m_lstSector
        End Get
        Set(value As List(Of ClienteSector))
            m_lstSector = value
        End Set
    End Property
    Public Property lstTipo As List(Of ClienteTipo)
        Get
            Return m_lstTipo
        End Get
        Set(value As List(Of ClienteTipo))
            m_lstTipo = value
        End Set
    End Property
    Public Property lstGrupo As List(Of Grupo)
        Get
            Return m_lstGrupo
        End Get
        Set(value As List(Of Grupo))
            m_lstGrupo = value
        End Set
    End Property
    Public Property lstContacto As List(Of ClienteContacto)
        Get
            Return m_lstContacto
        End Get
        Set(value As List(Of ClienteContacto))
            m_lstContacto = value
        End Set
    End Property
    Public Property lstTipoContacto As List(Of TablaGeneral)
        Get
            Return m_lstTipoContacto
        End Get
        Set(value As List(Of TablaGeneral))
            m_lstTipoContacto = value
        End Set
    End Property
    Public Property lstClaseContacto As List(Of TablaGeneral)
        Get
            Return m_lstClaseContacto
        End Get
        Set(value As List(Of TablaGeneral))
            m_lstClaseContacto = value
        End Set
    End Property
End Class
