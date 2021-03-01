Imports WcfSerialization = System.Runtime.Serialization

<WcfSerialization.DataContract([Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac", Name:="Paginacion")>
Public Class Paginacion

    Private _PageSize As Integer
    <WcfSerialization.DataMember(Name:="PageSize", IsRequired:=False, Order:=0)>
    Public Property PageSize() As Integer
        Get
            Return _PageSize
        End Get
        Set(ByVal value As Integer)
            _PageSize = value
        End Set
    End Property

    Private _PageNumber As Integer
    <WcfSerialization.DataMember(Name:="PageNumber", IsRequired:=False, Order:=1)>
    Public Property PageNumber() As Integer
        Get
            Return _PageNumber
        End Get
        Set(ByVal value As Integer)
            _PageNumber = value
        End Set
    End Property

    Private _SortType As String
    <WcfSerialization.DataMember(Name:="SortType", IsRequired:=False, Order:=2)>
    Public Property SortType() As String
        Get
            Return _SortType
        End Get
        Set(ByVal value As String)
            _SortType = value
        End Set
    End Property

    Private _SortBy As String
    <WcfSerialization.DataMember(Name:="SortBy", IsRequired:=False, Order:=3)>
    Public Property SortBy() As String
        Get
            Return _SortBy
        End Get
        Set(ByVal value As String)
            _SortBy = value
        End Set
    End Property

    Private _TotalRows As Integer
    <WcfSerialization.DataMember(Name:="TotalRows", IsRequired:=False, Order:=4)>
    Public Property TotalRows() As Integer
        Get
            Return _TotalRows
        End Get
        Set(ByVal value As Integer)
            _TotalRows = value
        End Set
    End Property

    Private _RowsPerPage As Integer
    <WcfSerialization.DataMember(Name:="Page", IsRequired:=False, Order:=49)>
    Public Property RowsPerPage() As Integer
        Get
            Return _RowsPerPage
        End Get
        Set(ByVal value As Integer)
            _RowsPerPage = value
        End Set
    End Property

    Private _Page As Integer
    <WcfSerialization.DataMember(Name:="Page", IsRequired:=False, Order:=50)>
    Public Property Page() As Integer
        Get
            Return _Page
        End Get
        Set(ByVal value As Integer)
            _Page = value
        End Set
    End Property

    Private _ErrorLog As ErrorLog
    <WcfSerialization.DataMember(Name:="TotalRows", IsRequired:=False, Order:=5)>
    Public Property ErrorLog() As ErrorLog
        Get
            Return _ErrorLog
        End Get
        Set(ByVal value As ErrorLog)
            _ErrorLog = value
        End Set
    End Property

    Private m_ComisionPeriodo As ComisionPeriodo
    <WcfSerialization.DataMember(Name:="ComisionPeriodo", IsRequired:=False, Order:=6)>
    Public Property ComisionPeriodo() As ComisionPeriodo
        Get
            Return m_ComisionPeriodo
        End Get
        Set(ByVal value As ComisionPeriodo)
            m_ComisionPeriodo = value
        End Set
    End Property

    Private m_ListaComisionPeriodo As List(Of ComisionPeriodo)
    <WcfSerialization.DataMember(Name:="ListaComisionPeriodo", IsRequired:=False, Order:=7)>
    Public Property ListaComisionPeriodo() As List(Of ComisionPeriodo)
        Get
            Return m_ListaComisionPeriodo
        End Get
        Set(ByVal value As List(Of ComisionPeriodo))
            m_ListaComisionPeriodo = value
        End Set
    End Property

    Private m_ClienteVenta As ClienteVenta
    <WcfSerialization.DataMember(Name:="ClienteVenta", IsRequired:=False, Order:=8)>
    Public Property ClienteVenta() As ClienteVenta
        Get
            Return m_ClienteVenta
        End Get
        Set(ByVal value As ClienteVenta)
            m_ClienteVenta = value
        End Set
    End Property

    Private m_ClienteContacto As ClienteContacto
    <WcfSerialization.DataMember(Name:="ClienteContacto", IsRequired:=False, Order:=9)>
    Public Property ClienteContacto() As ClienteContacto
        Get
            Return m_ClienteContacto
        End Get
        Set(ByVal value As ClienteContacto)
            m_ClienteContacto = value
        End Set
    End Property

    Private m_ListaClienteContacto As List(Of ClienteContacto)
    <WcfSerialization.DataMember(Name:="ListaComisionPeriodo", IsRequired:=False, Order:=10)>
    Public Property ListaClienteContacto() As List(Of ClienteContacto)
        Get
            Return m_ListaClienteContacto
        End Get
        Set(ByVal value As List(Of ClienteContacto))
            m_ListaClienteContacto = value
        End Set
    End Property

    Dim m_Empleado As Empleado
    <WcfSerialization.DataMember(Name:="Empleado", IsRequired:=False, Order:=11)>
    Public Property Empleado() As Empleado
        Get
            Return m_Empleado
        End Get
        Set(ByVal value As Empleado)
            m_Empleado = value
        End Set
    End Property

    Dim m_SucursalEmpleado As SucursalEmpleado
    <WcfSerialization.DataMember(Name:="SucursalEmpleado", IsRequired:=False, Order:=35)>
    Public Property SucursalEmpleado() As SucursalEmpleado
        Get
            Return m_SucursalEmpleado
        End Get
        Set(ByVal value As SucursalEmpleado)
            m_SucursalEmpleado = value
        End Set
    End Property

    Private m_ListaClienteLineaCredito As List(Of ClienteLineaCredito)
    <WcfSerialization.DataMember(Name:="ListaClienteLineaCredito", IsRequired:=False, Order:=12)>
    Public Property ListaClienteLineaCredito() As List(Of ClienteLineaCredito)
        Get
            Return m_ListaClienteLineaCredito
        End Get
        Set(ByVal value As List(Of ClienteLineaCredito))
            m_ListaClienteLineaCredito = value
        End Set
    End Property

    Private m_ClienteLineaCredito As ClienteLineaCredito
    <WcfSerialization.DataMember(Name:="ClienteLineaCredito", IsRequired:=False, Order:=13)>
    Public Property ClienteLineaCredito() As ClienteLineaCredito
        Get
            Return m_ClienteLineaCredito
        End Get
        Set(ByVal value As ClienteLineaCredito)
            m_ClienteLineaCredito = value
        End Set
    End Property

    Private m_ListaEmpleado As ListaEmpleado
    <WcfSerialization.DataMember(Name:="ListaEmpleado", IsRequired:=False, Order:=14)>
    Public Property ListaEmpleado() As ListaEmpleado
        Get
            Return m_ListaEmpleado
        End Get
        Set(ByVal value As ListaEmpleado)
            m_ListaEmpleado = value
        End Set
    End Property

    Private _ListaVentaCliente As ListaClienteVenta
    <WcfSerialization.DataMember(Name:="ListaClienteVenta", IsRequired:=False, Order:=15)>
    Public Property ListaClienteVenta() As List(Of ClienteVenta)
        Get
            Return _ListaVentaCliente
        End Get
        Set(ByVal value As List(Of ClienteVenta))
            _ListaVentaCliente = value
        End Set
    End Property

    Private _DescRegistrosPorPaginas As String
    <WcfSerialization.DataMember(Name:="DescRegistrosPorPaginas", IsRequired:=False, Order:=16)>
    Public Property DescRegistrosPorPaginas() As String
        Get
            Return _DescRegistrosPorPaginas
        End Get
        Set(ByVal value As String)
            _DescRegistrosPorPaginas = value
        End Set
    End Property

    Private __Sucursal As Sucursal
    <WcfSerialization.DataMember(Name:="Sucursal", IsRequired:=False, Order:=17)>
    Public Property Sucursal() As Sucursal
        Get
            Return __Sucursal
        End Get
        Set(ByVal value As Sucursal)
            __Sucursal = value
        End Set
    End Property

    Private __ListaSucursal As ListaSucursal
    <WcfSerialization.DataMember(Name:="ListaSucursal", IsRequired:=False, Order:=18)>
    Public Property ListaSucursal() As ListaSucursal
        Get
            Return __ListaSucursal
        End Get
        Set(ByVal value As ListaSucursal)
            __ListaSucursal = value
        End Set
    End Property

    Private __Zona As Zona
    <WcfSerialization.DataMember(Name:="Zona", IsRequired:=False, Order:=19)>
    Public Property Zona() As Zona
        Get
            Return __Zona
        End Get
        Set(ByVal value As Zona)
            __Zona = value
        End Set
    End Property

    Private __EmpleadoCargo As EmpleadoCargo
    <WcfSerialization.DataMember(Name:="EmpleadoCargo", IsRequired:=False, Order:=20)>
    Public Property EmpleadoCargo() As EmpleadoCargo
        Get
            Return __EmpleadoCargo
        End Get
        Set(ByVal value As EmpleadoCargo)
            __EmpleadoCargo = value
        End Set
    End Property

    Private _ClienteAdjunto As ClienteAdjunto
    <WcfSerialization.DataMember(Name:="ClienteAdjunto", IsRequired:=False, Order:=21)>
    Public Property ClienteAdjunto() As ClienteAdjunto
        Get
            Return _ClienteAdjunto
        End Get
        Set(ByVal value As ClienteAdjunto)
            _ClienteAdjunto = value
        End Set
    End Property
    Private _ListaClienteAdjunto As ListaClienteAdjunto
    <WcfSerialization.DataMember(Name:="ListaClienteAdjunto", IsRequired:=False, Order:=22)>
    Public Property ListaClienteAdjunto() As ListaClienteAdjunto
        Get
            Return _ListaClienteAdjunto
        End Get
        Set(ByVal value As ListaClienteAdjunto)
            _ListaClienteAdjunto = value
        End Set
    End Property


    Private _TabGeneral As TablaGeneral
    <WcfSerialization.DataMember(Name:="TabGeneral", IsRequired:=False, Order:=23)>
    Public Property TabGeneral() As TablaGeneral
        Get
            Return _TabGeneral
        End Get
        Set(ByVal value As TablaGeneral)
            _TabGeneral = value
        End Set
    End Property

    Private _TabGru As TablaGrupo
    <WcfSerialization.DataMember(Name:="TabGru", IsRequired:=False, Order:=24)>
    Public Property TabGru() As TablaGrupo
        Get
            Return _TabGru
        End Get
        Set(ByVal value As TablaGrupo)
            _TabGru = value
        End Set
    End Property


    Private _Perfil As Perfil
    <WcfSerialization.DataMember(Name:="Perfil", IsRequired:=False, Order:=25)>
    Public Property Perfil() As Perfil
        Get
            Return _Perfil
        End Get
        Set(ByVal value As Perfil)
            _Perfil = value
        End Set
    End Property

    Private m_ListaPerfil As ListaPerfil
    <WcfSerialization.DataMember(Name:="ListaPerfil", IsRequired:=False, Order:=26)>
    Public Property ListaPerfil() As ListaPerfil
        Get
            Return m_ListaPerfil
        End Get
        Set(ByVal value As ListaPerfil)
            m_ListaPerfil = value
        End Set
    End Property


    Private _Cargo As Cargo
    <WcfSerialization.DataMember(Name:="Cargo", IsRequired:=False, Order:=27)>
    Public Property Cargo() As Cargo
        Get
            Return _Cargo
        End Get
        Set(ByVal value As Cargo)
            _Cargo = value
        End Set
    End Property

    Private m_ListaSucursalMantenimiento As ListaSucursalMantenimiento
    <WcfSerialization.DataMember(Name:="ListaSucursalMantenimiento", IsRequired:=False, Order:=32)>
    Public Property ListaSucursalMantenimiento() As ListaSucursalMantenimiento
        Get
            Return m_ListaSucursalMantenimiento
        End Get
        Set(ByVal value As ListaSucursalMantenimiento)
            m_ListaSucursalMantenimiento = value
        End Set
    End Property
    Private m_ListaCargo As ListaCargo
    <WcfSerialization.DataMember(Name:="ListaCargo", IsRequired:=False, Order:=28)>
    Public Property ListaCargo() As ListaCargo
        Get
            Return m_ListaCargo
        End Get
        Set(ByVal value As ListaCargo)
            m_ListaCargo = value
        End Set
    End Property

    Private _Zona As ZonaMantenimiento
    <WcfSerialization.DataMember(Name:="ZonaMantenimiento", IsRequired:=False, Order:=29)>
    Public Property ZonaMantenimiento() As ZonaMantenimiento
        Get
            Return _Zona
        End Get
        Set(ByVal value As ZonaMantenimiento)
            _Zona = value
        End Set
    End Property

    Private m_ListaZonaMantenimiento As ListaZonaMantenimiento
    <WcfSerialization.DataMember(Name:="ListaZonaMantenimiento", IsRequired:=False, Order:=30)>
    Public Property ListaZonaMantenimiento() As ListaZonaMantenimiento
        Get
            Return m_ListaZonaMantenimiento
        End Get
        Set(ByVal value As ListaZonaMantenimiento)
            m_ListaZonaMantenimiento = value
        End Set
    End Property

    Private m_Sucursal As SucursalMantenimiento
    <WcfSerialization.DataMember(Name:="SucursalMantenimiento", IsRequired:=False, Order:=31)>
    Public Property SucursalMantenimiento() As SucursalMantenimiento
        Get
            Return m_Sucursal
        End Get
        Set(ByVal value As SucursalMantenimiento)
            m_Sucursal = value
        End Set
    End Property

    Private m_PlanVenta As PlanVenta
    <WcfSerialization.DataMember(Name:="PlanVenta", IsRequired:=False, Order:=32)>
    Public Property PlanVenta() As PlanVenta
        Get
            Return m_PlanVenta
        End Get
        Set(ByVal value As PlanVenta)
            m_PlanVenta = value
        End Set
    End Property

    Private m_ListaPlanVenta As ListaPlanVenta
    <WcfSerialization.DataMember(Name:="ListaPlanVenta", IsRequired:=False, Order:=33)>
    Public Property ListaPlanVenta() As ListaPlanVenta
        Get
            Return m_ListaPlanVenta
        End Get
        Set(ByVal value As ListaPlanVenta)
            m_ListaPlanVenta = value
        End Set
    End Property
    Private m_ListaSucursalEmpleado As List(Of SucursalEmpleado)
    <WcfSerialization.DataMember(Name:="ListaSucursalEmpleado", IsRequired:=False, Order:=34)>
    Public Property ListaSucursalEmpleado() As List(Of SucursalEmpleado)
        Get
            Return m_ListaSucursalEmpleado
        End Get
        Set(ByVal value As List(Of SucursalEmpleado))
            m_ListaSucursalEmpleado = value
        End Set
    End Property

    Private m_PlanVentaEmpleado As PlanVentaEmpleado
    <WcfSerialization.DataMember(Name:="PlanVentaEmpleado", IsRequired:=False, Order:=39)>
    Public Property PlanVentaEmpleado() As PlanVentaEmpleado
        Get
            Return m_PlanVentaEmpleado
        End Get
        Set(ByVal value As PlanVentaEmpleado)
            m_PlanVentaEmpleado = value
        End Set
    End Property

    Private m_ListaPlanVentaEmpleado As ListaPlanVentaEmpleado
    <WcfSerialization.DataMember(Name:="ListaPlanVentaEmpleado", IsRequired:=False, Order:=40)>
    Public Property ListaPlanVentaEmpleado() As ListaPlanVentaEmpleado
        Get
            Return m_ListaPlanVentaEmpleado
        End Get
        Set(ByVal value As ListaPlanVentaEmpleado)
            m_ListaPlanVentaEmpleado = value
        End Set
    End Property

    Private m_Estado As Estado
    <WcfSerialization.DataMember(Name:="Estado", IsRequired:=False, Order:=41)>
    Public Property Estado() As Estado
        Get
            Return m_Estado
        End Get
        Set(value As Estado)
            m_Estado = value
        End Set
    End Property

    Private m_ListaEstado As ListaProcesoEstado
    <WcfSerialization.DataMember(Name:="ListaProcesoEstado", IsRequired:=False, Order:=42)>
    Public Property ListaProcesoEstado() As ListaProcesoEstado
        Get
            Return m_ListaEstado
        End Get
        Set(value As ListaProcesoEstado)
            m_ListaEstado = value
        End Set
    End Property
    Private m_Grupo As Grupo
    <WcfSerialization.DataMember(Name:="Grupo", IsRequired:=False, Order:=43)>
    Public Property Grupo() As Grupo
        Get
            Return m_Grupo
        End Get
        Set(ByVal value As Grupo)
            m_Grupo = value
        End Set
    End Property

    Private m_ListaGrupo As ListaGrupo
    <WcfSerialization.DataMember(Name:="ListaGrupo", IsRequired:=False, Order:=44)>
    Public Property ListaGrupo() As ListaGrupo
        Get
            Return m_ListaGrupo
        End Get
        Set(ByVal value As ListaGrupo)
            m_ListaGrupo = value
        End Set
    End Property

    Private m_GrupoClienteMantenimiento As GrupoClienteMantenimiento
    <WcfSerialization.DataMember(Name:="GrupoClienteMantenimiento", IsRequired:=False, Order:=45)>
    Public Property GrupoClienteMantenimiento() As GrupoClienteMantenimiento
        Get
            Return m_GrupoClienteMantenimiento
        End Get
        Set(ByVal value As GrupoClienteMantenimiento)
            m_GrupoClienteMantenimiento = value
        End Set
    End Property

    Private m_ListaGrupoClienteMantenimiento As ListaGrupoClienteMantenimiento
    <WcfSerialization.DataMember(Name:="ListaGrupoClienteMantenimiento", IsRequired:=False, Order:=46)>
    Public Property ListaGrupoClienteMantenimiento() As ListaGrupoClienteMantenimiento
        Get
            Return m_ListaGrupoClienteMantenimiento
        End Get
        Set(ByVal value As ListaGrupoClienteMantenimiento)
            m_ListaGrupoClienteMantenimiento = value
        End Set
    End Property

    Private m_Parametro As Parametro
    <WcfSerialization.DataMember(Name:="Parametro", IsRequired:=False, Order:=47)>
    Public Property Parametro() As Parametro
        Get
            Return m_Parametro
        End Get
        Set(ByVal value As Parametro)
            m_Parametro = value
        End Set
    End Property

    Private m_ListaParametro As ListaParametro
    <WcfSerialization.DataMember(Name:="ListaParametro", IsRequired:=False, Order:=48)>
    Public Property ListaParametro() As ListaParametro
        Get
            Return m_ListaParametro
        End Get
        Set(ByVal value As ListaParametro)
            m_ListaParametro = value
        End Set
    End Property

    'se agrego para listar las fechas de cartera compartida
    Dim m_ClienteCartera As ClienteCartera
    <WcfSerialization.DataMember(Name:="ClienteCartera", IsRequired:=False, Order:=49)>
    Public Property ClienteCartera() As ClienteCartera
        Get
            Return m_ClienteCartera
        End Get
        Set(ByVal value As ClienteCartera)
            m_ClienteCartera = value
        End Set
    End Property

    Private m_ListaClienteCartera As ListaClienteCartera
    <WcfSerialization.DataMember(Name:="ListaClienteCartera", IsRequired:=False, Order:=50)>
    Public Property ListaClienteCartera() As ListaClienteCartera
        Get
            Return m_ListaClienteCartera
        End Get
        Set(ByVal value As ListaClienteCartera)
            m_ListaClienteCartera = value
        End Set
    End Property

    Private _ListaComisionPeriodoDetalle As ListaComisionPeriodoDetalle
    Public Property ListaComisionPeriodoDetalle() As ListaComisionPeriodoDetalle
        Get
            Return _ListaComisionPeriodoDetalle
        End Get
        Set(ByVal value As ListaComisionPeriodoDetalle)
            _ListaComisionPeriodoDetalle = value
        End Set
    End Property

    Private m_ListaArchivo_ As ListaArchivo
    Public Property ListarArchivoComision() As ListaArchivo
        Get
            Return m_ListaArchivo_
        End Get
        Set(ByVal value As ListaArchivo)
            m_ListaArchivo_ = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="Familia", IsRequired:=False, Order:=49)>
    Public Property Familia As Familia

    <WcfSerialization.DataMember(Name:="ListaDescuentoFamilia", IsRequired:=False, Order:=50)>
    Public Property ListaDescuentoFamilia As ListaDescuentoFamilia

    <WcfSerialization.DataMember(Name:="DescuentoFamilia", IsRequired:=False, Order:=51)>
    Public Property DescuentoFamilia As DescuentoFamilia

    <WcfSerialization.DataMember(Name:="ListaDescuentoSku", IsRequired:=False, Order:=52)>
    Public Property ListaDescuentoSku As ListaDescuentoSku

    <WcfSerialization.DataMember(Name:="DescuentoSku", IsRequired:=False, Order:=53)>
    Public Property DescuentoSku As DescuentoSku

    <WcfSerialization.DataMember(Name:="ListaCotizacion", IsRequired:=False, Order:=54)>
    Public Property ListaCotizacion As ListaCotizacion

    <WcfSerialization.DataMember(Name:="Cotizacion", IsRequired:=False, Order:=55)>
    Public Property Cotizacion As Cotizacion

    <WcfSerialization.DataMember(Name:="BusquedaCotizacion", IsRequired:=False, Order:=56)>
    Public Property BusquedaCotizacion As BusquedaCotizacion

    <WcfSerialization.DataMember(Name:="ListaDetalleCotizacion", IsRequired:=False, Order:=57)>
    Public Property ListaDetalleCotizacion As ListaDetalleCotizacion

    <WcfSerialization.DataMember(Name:="DetalleCotizacion", IsRequired:=False, Order:=58)>
    Public Property DetalleCotizacion As DetalleCotizacion

    <WcfSerialization.DataMember(Name:="ListaProducto", IsRequired:=False, Order:=59)>
    Public Property ListaProducto As ListaProducto

    <WcfSerialization.DataMember(Name:="Producto", IsRequired:=False, Order:=60)>
    Public Property Producto As Producto

    Private m_PlanTipoRepresentanteVenta As PlanTipoRepresentanteVenta
    <WcfSerialization.DataMember(Name:="PlanTipoRepresentanteVenta", IsRequired:=False, Order:=30)>
    Public Property PlanTipoRepresentanteVenta() As PlanTipoRepresentanteVenta
        Get
            Return m_PlanTipoRepresentanteVenta
        End Get
        Set(ByVal value As PlanTipoRepresentanteVenta)
            m_PlanTipoRepresentanteVenta = value
        End Set
    End Property

    Private m_ListaPlanTipoRepresentanteVenta As ListaPlanTipoRepresentanteVenta
    <WcfSerialization.DataMember(Name:="ListaPlanTipoRepresentanteVenta", IsRequired:=False, Order:=31)>
    Public Property ListaPlanTipoRepresentanteVenta() As ListaPlanTipoRepresentanteVenta
        Get
            Return m_ListaPlanTipoRepresentanteVenta
        End Get
        Set(ByVal value As ListaPlanTipoRepresentanteVenta)
            m_ListaPlanTipoRepresentanteVenta = value
        End Set
    End Property

End Class
