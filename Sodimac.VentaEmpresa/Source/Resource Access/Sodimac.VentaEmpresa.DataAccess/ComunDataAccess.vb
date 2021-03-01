Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Common
Imports System.Linq
Imports System.Text
Imports Sodimac.VentaEmpresa.BusinessEntities
Imports Sodimac.VentaEmpresa.DataContracts
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common.Configuration

Public Class ComunDataAccess
    Private oDatabase As Database = EnterpriseLibraryContainer.Current.GetInstance(Of Database)(Conexion.cnsSql)
    Function ConsultarDepartamento() As ListaEmpleadoDepartamento
        Dim oListaEmpleadoDepartamento As New ListaEmpleadoDepartamento()
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_LISTADEPARTAMENTO)
        oListaEmpleadoDepartamento = New ListaEmpleadoDepartamento
        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim oEmpleadoDepartamento As New EmpleadoDepartamento()
            Dim m_IdDepartamento As Integer = oIDataReader.GetOrdinal("IdDepartamento")
            Dim m_CodigoDepartamento As Integer = oIDataReader.GetOrdinal("CodigoDepartamento")
            Dim m_Descripcion As Integer = oIDataReader.GetOrdinal("Descripcion")
            While oIDataReader.Read()
                oEmpleadoDepartamento = New EmpleadoDepartamento()
                oEmpleadoDepartamento.IdDepartamento = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(m_IdDepartamento))
                oEmpleadoDepartamento.CodigoDepartamento = DataUtil.DbValueToDefault(Of String)(oIDataReader(m_CodigoDepartamento))
                oEmpleadoDepartamento.DescripcionDepa = DataUtil.DbValueToDefault(Of String)(oIDataReader(m_Descripcion))
                oListaEmpleadoDepartamento.Add(oEmpleadoDepartamento)
            End While
        End Using
        Return oListaEmpleadoDepartamento
    End Function
    Function ListarSupervisorCargos(ByVal idcargos As Integer) As ListaCargo
        Dim oListaCargo As New ListaCargo()
        Dim oDbComand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_LISTA_SUPER_CARGOS)
        oDatabase.AddInParameter(oDbComand, "@IdCargo", DbType.Int32, idcargos)
        oListaCargo = New ListaCargo
        Using oiDataReader As IDataReader = oDatabase.ExecuteReader(oDbComand)
            Dim idcargosu As Integer = oiDataReader.GetOrdinal("IdCargo")
            Dim nombresup As Integer = oiDataReader.GetOrdinal("NombreCargo")
            Dim oCargos As New Cargo()
            While oiDataReader.Read()
                oCargos = New Cargo()
                oCargos.IdCargoSuperior = DataUtil.DbValueToDefault(Of Integer)(oiDataReader(idcargosu))
                oCargos.NombreCargoSuperior = DataUtil.DbValueToDefault(Of String)(oiDataReader(nombresup))
                oListaCargo.Add(oCargos)
            End While
        End Using
        Return oListaCargo
    End Function
    Function ListarJefes_CargosVendedor(ByVal idcargos As Integer) As ListaCargo
        Dim oListaCargo As New ListaCargo()
        Dim oDbComand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_LISTA_JEFE_CARGOS)
        oDatabase.AddInParameter(oDbComand, "@IdCargo", DbType.Int32, idcargos)
        oListaCargo = New ListaCargo
        Using oiDataReader As IDataReader = oDatabase.ExecuteReader(oDbComand)
            Dim idcargosu As Integer = oiDataReader.GetOrdinal("IdCargo")
            Dim nombresup As Integer = oiDataReader.GetOrdinal("NombreCargo")
            Dim oCargos As New Cargo()
            While oiDataReader.Read()
                oCargos = New Cargo()
                oCargos.IdCargoSuperior = DataUtil.DbValueToDefault(Of Integer)(oiDataReader(idcargosu))
                oCargos.NombreCargoSuperior = DataUtil.DbValueToDefault(Of String)(oiDataReader(nombresup))
                oListaCargo.Add(oCargos)
            End While
        End Using
        Return oListaCargo
    End Function

    Function Seleccion_tipoPerfilCargo(idcargos As Integer) As Integer
        Dim result As Integer = -1
        'Dim oListaCargos As New ListaCargo()
        Dim oDbComand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_TIPO_PERFILCARGO)
        oDatabase.AddInParameter(oDbComand, "@IDCARGO", DbType.Int32, idcargos)
        result = oDatabase.ExecuteScalar(oDbComand)
        Return result
    End Function

    Function ListarCargos_Zonas(ByVal idCargos As Integer) As ListaZona

        Dim oListaZona As New ListaZona()
        Dim oDbComand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_LISTA_CARGOS_ZONA)
        oDatabase.AddInParameter(oDbComand, "@IDCARGO", DbType.Int32, idCargos)
        ' oDbCommand.CommandTimeout = 12000
        oListaZona = New ListaZona
        Using oIDatareader As IDataReader = oDatabase.ExecuteReader(oDbComand)
            '' oDatabase.AddInParameter(oDbCommand, "")
            Dim idzona As Integer = oIDatareader.GetOrdinal("IdZona")
            Dim nombrezona As Integer = oIDatareader.GetOrdinal("NombreZona")
            Dim oZonas As New Zona()
            While oIDatareader.Read()
                oZonas = New Zona()
                oZonas.IdZona = DataUtil.DbValueToDefault(Of Integer)(oIDatareader(idzona))
                oZonas.NombreZona = DataUtil.DbValueToDefault(Of String)(oIDatareader(nombrezona))
                oListaZona.Add(oZonas)
            End While
        End Using
        Return oListaZona
    End Function
    Function ListaCargos_Sucursales(ByVal idcargos As Integer) As ListaSucursal
        Dim olistaSucursales As New ListaSucursal()
        Dim oDbComand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_LISTA_CARGOS_SUCURSALES)
        oDatabase.AddInParameter(oDbComand, "@IDCARGO", DbType.Int32, idcargos)
        olistaSucursales = New ListaSucursal
        Using iDataReader As IDataReader = oDatabase.ExecuteReader(oDbComand)
            Dim indiIdSucursal As Integer = iDataReader.GetOrdinal("IdSucursal")
            Dim indiDescripcion As Integer = iDataReader.GetOrdinal("Descripcion")

            Dim oListaCargoSucursal As New Sucursal
            While iDataReader.Read()
                oListaCargoSucursal = New Sucursal()
                oListaCargoSucursal.IdSucursal = DataUtil.DbValueToDefault(Of Integer)(iDataReader(indiIdSucursal))
                oListaCargoSucursal.DescripcionSucursal = DataUtil.DbValueToDefault(Of String)(iDataReader(indiDescripcion))
                olistaSucursales.Add(oListaCargoSucursal)
            End While
        End Using
        Return olistaSucursales

    End Function

    Function ListaZonas_Sucursales(ByVal idzona As Integer) As ListaSucursal
        Dim olistaSucursales As New ListaSucursal()
        Dim oDbComand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_LISTA_ZONAS_SUCURSALES)
        oDatabase.AddInParameter(oDbComand, "@IDZONA", DbType.Int32, idzona)
        olistaSucursales = New ListaSucursal
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbComand)
            Dim indiIdSucursal As Integer = oIDataReader.GetOrdinal("IdSucursal")
            Dim indiDescripcion As Integer = oIDataReader.GetOrdinal("Descripcion")
            Dim oSucursales = New Sucursal
            While oIDataReader.Read()
                oSucursales = New Sucursal()
                oSucursales.IdSucursal = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indiIdSucursal))
                oSucursales.DescripcionSucursal = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiDescripcion))
                olistaSucursales.Add(oSucursales)
            End While
        End Using
        Return olistaSucursales
    End Function

    Function ConsultarProvinciaDepartamento(ByVal IdDepartamento As Integer) As ListaEmpleadoProvincia
        Dim oListaEmpleadoProvincia As New ListaEmpleadoProvincia()

        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_LISTAPROVINCIA)
        oDatabase.AddInParameter(oDbCommand, "@IdDepartamento", DbType.Int32, IdDepartamento)
        oListaEmpleadoProvincia = New ListaEmpleadoProvincia
        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim indiceIdProvincia As Integer = oIDataReader.GetOrdinal("IdProvincia")
            Dim indiceCodigoProvincia As Integer = oIDataReader.GetOrdinal("CodigoProvincia")
            Dim indiceDescripcion As Integer = oIDataReader.GetOrdinal("Descripcion")

            Dim oEmpleadoProvincia As New EmpleadoProvincia()
            While oIDataReader.Read()
                oEmpleadoProvincia = New EmpleadoProvincia()
                oEmpleadoProvincia.IdProvincia = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indiceIdProvincia))
                oEmpleadoProvincia.CodigoProvincia = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceCodigoProvincia))
                oEmpleadoProvincia.DescripcionProv = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceDescripcion))
                oListaEmpleadoProvincia.Add(oEmpleadoProvincia)
            End While
        End Using
        Return oListaEmpleadoProvincia
    End Function

    Function ConsultarDistritoProvincia(ByVal IdProvincia As Integer) As ListaEmpleadoDistrito
        Dim oListaEmpleadoDistrito As New ListaEmpleadoDistrito()

        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_DISTRITO)
        oDatabase.AddInParameter(oDbCommand, "@IdProvincia", DbType.Int32, IdProvincia)
        oListaEmpleadoDistrito = New ListaEmpleadoDistrito
        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim indiceIdDistrito As Integer = oIDataReader.GetOrdinal("IdDistrito")
            Dim indiceCodigoDistrito As Integer = oIDataReader.GetOrdinal("CodigoDistrito")
            Dim indiceDescripcion As Integer = oIDataReader.GetOrdinal("Descripcion")

            Dim oEmpleadoDistrito As New EmpleadoDistrito()
            While oIDataReader.Read()
                oEmpleadoDistrito = New EmpleadoDistrito()
                oEmpleadoDistrito.IdDistrito = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indiceIdDistrito))
                oEmpleadoDistrito.CodigoDistrito = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceCodigoDistrito))
                oEmpleadoDistrito.Descripcion = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceDescripcion))
                oListaEmpleadoDistrito.Add(oEmpleadoDistrito)
            End While
        End Using
        Return oListaEmpleadoDistrito
    End Function
    Function CargarEscalas_Tiempo_Servicio(ByVal idcargos As Integer) As ListaComisionEscalaDetalle
        Dim oListaEscalaTiempoDetalle As New ListaComisionEscalaDetalle()
        Dim oDbComand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_CARGAR_ESCALAS)
        oDatabase.AddInParameter(oDbComand, "@IDCARGO", DbType.Int32, idcargos)
        oListaEscalaTiempoDetalle = New ListaComisionEscalaDetalle
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbComand)
            Dim indiIdEscalaDetalle As Integer = oIDataReader.GetOrdinal("ComisionEscalaServicio")
            'Dim indiDescripcion As Integer = oIDataReader.GetOrdinal("IdComisionEscala")
            Dim oComisionDetalle = New ComisionEscalaDetalle
            While oIDataReader.Read()
                oComisionDetalle = New ComisionEscalaDetalle()
                oComisionDetalle.IdComisionEscala = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indiIdEscalaDetalle))
                'oComisionDetalle.IdComisionEscala = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiDescripcion))
                oListaEscalaTiempoDetalle.Add(oComisionDetalle)
            End While
        End Using
        Return oListaEscalaTiempoDetalle
    End Function
    Function CargarEscalas_Tiempo_Servicios(ByVal idcargos As Integer) As ListaComisionEscalaTiempoServicio
        Dim oListaEscalaTiempoServicio As New ListaComisionEscalaTiempoServicio()
        Dim oDbComand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_CARGAR_ESCALAS)
        oDatabase.AddInParameter(oDbComand, "@IDCARGO", DbType.Int32, idcargos)
        oListaEscalaTiempoServicio = New ListaComisionEscalaTiempoServicio
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbComand)
            Dim indiIdComisionTiempoServicio As Integer = oIDataReader.GetOrdinal("IdComisionTiempoServicio")
            Dim indiIdEscalaTiempoServicio As Integer = oIDataReader.GetOrdinal("EscalaTiempoServicio")

            Dim oComisionServicio = New ComisionEscalaTiempoServicio
            While oIDataReader.Read()
                oComisionServicio = New ComisionEscalaTiempoServicio()
                oComisionServicio.IdComisionTiempoServicio = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indiIdComisionTiempoServicio))
                oComisionServicio.TiempoServicio = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indiIdEscalaTiempoServicio))
                oListaEscalaTiempoServicio.Add(oComisionServicio)
            End While
        End Using
        Return oListaEscalaTiempoServicio
    End Function
    Function CargarEscalasComision_Tiempo_Servicios(ByVal idcargos As Integer) As ListaComisionEscala
        Dim oListaEscalaTiempoServicio As New ListaComisionEscala()
        Dim oDbComand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_CARGAR_ESCALAS)
        oDatabase.AddInParameter(oDbComand, "@IDCARGO", DbType.Int32, idcargos)
        oListaEscalaTiempoServicio = New ListaComisionEscala
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbComand)
            Dim indiIdComisionTiempoServicio As Integer = oIDataReader.GetOrdinal("IdComisionEscala")
            Dim indiIdEscalaTiempoServicio As Integer = oIDataReader.GetOrdinal("EscalaTiempoServicio")
          

            Dim oComisionEscala = New ComisionEscala
            While oIDataReader.Read()
                For i As Integer = 0 To DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indiIdEscalaTiempoServicio))
                    If i <> 0 Then
                        oComisionEscala = New ComisionEscala()
                        oComisionEscala.IdComisionEscala = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indiIdComisionTiempoServicio))
                        oComisionEscala.TiempoServicio = i
                    End If
                    oListaEscalaTiempoServicio.Add(oComisionEscala)
                Next
            End While
            
        End Using
        
        Return oListaEscalaTiempoServicio
    End Function



    'Function ConsultarModoPago(ByVal IdModoPago As Integer) As ListaClienteVenta
    '    Dim oListaClienteVenta As New ListaClienteVenta()

    '    Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_DISTRITO)
    '    oDatabase.AddInParameter(oDbCommand, "@IdModoPago", DbType.Int32, IdModoPago)
    '    oListaClienteVenta = New ListaClienteVenta
    '    oDbCommand.CommandTimeout = 120000
    '    Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
    '        Dim indiceIdModoPago As Integer = oIDataReader.GetOrdinal("IdModoPago")
    '        Dim indiceDescripcionModoPago As Integer = oIDataReader.GetOrdinal("DescripcionModoPago")

    '        Dim oClienteVenta As New ClienteVenta()
    '        While oIDataReader.Read()
    '            oClienteVenta = New ClienteVenta()
    '            oClienteVenta.IdModoPago = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indiceIdModoPago))
    '            oClienteVenta.DescripcionModoPago = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceDescripcionModoPago))
    '            oListaClienteVenta.Add(oClienteVenta)
    '        End While
    '    End Using
    '    Return oListaClienteVenta
    'End Function



    Function ListaEstado(IdObjeto As Integer) As ListaProcesoEstado

        Dim oListaProcesoEstado As New ListaProcesoEstado()

        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_ESTADO)
        oDatabase.AddInParameter(oDbCommand, "@Idobjeto", DbType.Int32, IdObjeto)

        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)

            Dim m_IdEstado As Integer = oIDataReader.GetOrdinal("IdEstado")
            Dim m_Codigo As Integer = oIDataReader.GetOrdinal("Codigo")
            Dim m_Descripcion As Integer = oIDataReader.GetOrdinal("Descripcion")
            Dim m_DescripcionCorta As Integer = oIDataReader.GetOrdinal("DescripcionCorta")
            Dim m_Activo As Integer = oIDataReader.GetOrdinal("Activo")

            While oIDataReader.Read()

                Dim OProcesoEstado As New ProcesoEstado()
                OProcesoEstado = New ProcesoEstado()

                OProcesoEstado.IdEstado = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(m_IdEstado))
                OProcesoEstado.Codigo = DataUtil.DbValueToDefault(Of String)(oIDataReader(m_Codigo))
                OProcesoEstado.Descripcion = DataUtil.DbValueToDefault(Of String)(oIDataReader(m_Descripcion))
                OProcesoEstado.DescripcionCorta = DataUtil.DbValueToDefault(Of String)(oIDataReader(m_DescripcionCorta))
                OProcesoEstado.Activo = DataUtil.DbValueToDefault(Of Boolean)(oIDataReader(m_Activo))


                oListaProcesoEstado.Add(OProcesoEstado)
            End While
        End Using
        Return oListaProcesoEstado
    End Function

End Class
