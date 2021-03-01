Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Common
Imports System.Linq
Imports System.Text
Imports Sodimac.VentaEmpresa.BusinessEntities
Imports Sodimac.VentaEmpresa.DataContracts
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common.Configuration
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql
Imports Microsoft.SqlServer.Server


Public Class ClienteDataAccess : Implements IClienteDataAccess

    Private oDatabase As Database = EnterpriseLibraryContainer.Current.GetInstance(Of Database)(Conexion.cnsSql)

    Public Function CarteraClientes_LIST(ByRef oPaginacion As Paginacion) As Paginacion
        oPaginacion.ListaEmpleado = New ListaEmpleado()
        Dim oCarteraCliente As New VentaCartera

        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_CARTERACLIENTE_LISTA)

        oDatabase.AddInParameter(oDbCommand, "@IdCliente", DbType.Int32, oPaginacion.Empleado.IdCliente)
        oDatabase.AddInParameter(oDbCommand, "@PageSize", DbType.Int32, oPaginacion.PageSize)
        oDatabase.AddInParameter(oDbCommand, "@PageNumber", DbType.Int32, oPaginacion.PageNumber)
        oDatabase.AddInParameter(oDbCommand, "@SortBy", DbType.String, oPaginacion.SortBy)
        oDatabase.AddInParameter(oDbCommand, "@SortType", DbType.String, oPaginacion.SortType)
        oDatabase.AddOutParameter(oDbCommand, "@TotalRows", DbType.Int32, 10)
        oDbCommand.CommandTimeout = 120000

        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)

            Dim INDICE_IdCartera As Integer = oIDataReader.GetOrdinal("IdCartera")
            Dim INDICE_IdCliente As Integer = oIDataReader.GetOrdinal("IdCliente")
            Dim INDICE_IdEmpleado As Integer = oIDataReader.GetOrdinal("IdEmpleado")
            Dim INDICE_Nombres As Integer = oIDataReader.GetOrdinal("Nombres")
            Dim INDICE_Telefono As Integer = oIDataReader.GetOrdinal("Telefono")
            Dim INDICE_Email As Integer = oIDataReader.GetOrdinal("Email")
            Dim INDICE_Celular1 As Integer = oIDataReader.GetOrdinal("Celular1")
            Dim INDICE_CargoEmpleado As Integer = oIDataReader.GetOrdinal("CargoEmpleado")
            Dim INDICE_Tipo As Integer = oIDataReader.GetOrdinal("DescripcionCortaTabGen")
            Dim INDICE_DescripcionSucursal As Integer = oIDataReader.GetOrdinal("Sucursal")
            Dim INDICE_FechaActivacion As Integer = oIDataReader.GetOrdinal("FechaActivacion")
            Dim INDICE_Porcentaje As Integer = oIDataReader.GetOrdinal("Porcentaje")
            Dim INDICE_FechaDesignacion As Integer = oIDataReader.GetOrdinal("FechaDesignacion")
            Dim INDICE_Estado As Integer = oIDataReader.GetOrdinal("Estado")
            Dim INDICE_Activo As Integer = oIDataReader.GetOrdinal("Activo")
            While oIDataReader.Read()

                oPaginacion.Empleado = New Empleado()
                oPaginacion.Empleado.Activo = DataUtil.DbValueToDefault(Of Boolean)(oIDataReader(INDICE_Activo))
                oPaginacion.Empleado.VentaCartera = New VentaCartera()
                oPaginacion.Empleado.VentaCartera.IdCartera = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_IdCartera))
                oPaginacion.Empleado.VentaCartera.FechaActivacion = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_FechaActivacion))
                oPaginacion.Empleado.VentaCartera.Porcentaje = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_Porcentaje))
                oPaginacion.Empleado.VentaCartera.FechaDesignacion = DataUtil.DbValueToDefault(Of DateTime)(oIDataReader(INDICE_FechaDesignacion))
                'oPaginacion.Empleado.Porcentaje = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_Porcentaje))

                oPaginacion.Empleado.IdEmpleado = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_IdEmpleado))
                oPaginacion.Empleado.Nombres = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_Nombres))
                oPaginacion.Empleado.Telefono = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_Telefono))
                oPaginacion.Empleado.Email = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_Email))
                oPaginacion.Empleado.Celular1 = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_Celular1))

                oPaginacion.Empleado.TablaGeneral = New TablaGeneral()
                oPaginacion.Empleado.TablaGeneral.DescripcionTabGen = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_Tipo))

                oPaginacion.EmpleadoCargo = New EmpleadoCargo()
                oPaginacion.EmpleadoCargo.DescripcionCargo = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_CargoEmpleado))

                oPaginacion.Empleado.Sucursal = New Sucursal()
                oPaginacion.Empleado.Sucursal.DescripcionSucursal = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_DescripcionSucursal))

                oPaginacion.Empleado.ClienteVenta = New ClienteVenta()
                oPaginacion.Empleado.ClienteVenta.IdCliente = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_IdCliente))
                oPaginacion.Empleado.ProcesoEstado = New ProcesoEstado()
                oPaginacion.Empleado.ProcesoEstado.IdEstado = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_Estado))


                oPaginacion.ListaEmpleado.Add(oPaginacion.Empleado)
            End While
        End Using
        oPaginacion.TotalRows = Convert.ToInt32(oDatabase.GetParameterValue(oDbCommand, "@TotalRows"))
        Return oPaginacion

    End Function

    Public Function BuscarCliente(ByRef oPaginacion As Paginacion) As Paginacion
        Dim fechaActual As Date = Date.Now

        oPaginacion.ListaClienteVenta = New ListaClienteVenta()

        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_BUSCACLIENTE)

        oDatabase.AddInParameter(oDbCommand, "@RazonSocial", DbType.String, oPaginacion.ClienteVenta.RazonSocial)
        oDatabase.AddInParameter(oDbCommand, "@IdModoPago", DbType.Int32, oPaginacion.ClienteVenta.IdModoPago)
        oDatabase.AddInParameter(oDbCommand, "@IdEstado", DbType.Int32, oPaginacion.ClienteVenta.ProcesoEstado.IdEstado)
        oDatabase.AddInParameter(oDbCommand, "@IdDepartamento", DbType.Int32, oPaginacion.ClienteVenta.EmpleadoDepartamento.IdDepartamento)
        oDatabase.AddInParameter(oDbCommand, "@IdProvincia", DbType.Int32, oPaginacion.ClienteVenta.EmpleadoProvincia.IdProvincia)
        oDatabase.AddInParameter(oDbCommand, "@IdSector", DbType.Int32, oPaginacion.ClienteVenta.ClienteSector.IdClienteSector)
        oDatabase.AddInParameter(oDbCommand, "@IdCategoria", DbType.Int32, oPaginacion.ClienteVenta.ClienteCategoria.IdClienteCategoria)
        oDatabase.AddInParameter(oDbCommand, "@IdClienteTipo", DbType.Int32, oPaginacion.ClienteVenta.ClienteTipo.IdClienteTipo)
        oDatabase.AddInParameter(oDbCommand, "@PageSize", DbType.Int32, oPaginacion.PageSize)
        oDatabase.AddInParameter(oDbCommand, "@PageNumber", DbType.Int32, oPaginacion.PageNumber)
        oDatabase.AddInParameter(oDbCommand, "@SortBy", DbType.String, oPaginacion.SortBy)
        oDatabase.AddInParameter(oDbCommand, "@SortType", DbType.String, oPaginacion.SortType)
        oDatabase.AddOutParameter(oDbCommand, "@TotalRows", DbType.Int32, 10)
        oDbCommand.CommandTimeout = 120000

        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)

            Dim INDICE_RUC As Integer = oIDataReader.GetOrdinal("RUC")
            Dim INDICE_RazonSocial As Integer = oIDataReader.GetOrdinal("RazonSocial")
            Dim INDICE_NombresApellidos As Integer = oIDataReader.GetOrdinal("NombresApellidos")
            Dim INDICE_Region As Integer = oIDataReader.GetOrdinal("Region")
            Dim INDICE_Provincia As Integer = oIDataReader.GetOrdinal("Provincia")
            Dim INDICE_Sector As Integer = oIDataReader.GetOrdinal("Sector")
            Dim INDICE_Categoria As Integer = oIDataReader.GetOrdinal("Categoria")
            Dim INDICE_Tipo As Integer = oIDataReader.GetOrdinal("Tipo")
            Dim INDICE_Telefono As Integer = oIDataReader.GetOrdinal("Telefono")
            Dim INDICE_Estado As Integer = oIDataReader.GetOrdinal("Estado")
            Dim INDICE_IdCliente As Integer = oIDataReader.GetOrdinal("IdCliente")
            Dim INDICE_ModoPago As Integer = oIDataReader.GetOrdinal("ModoPago")
            Dim INDICE_EstadoCliente As Integer = oIDataReader.GetOrdinal("EstadoCliente")
            Dim INDICE_ACTIVO As Integer = oIDataReader.GetOrdinal("ACTIVO")
            Dim INDICE_FechaModifica As Integer = oIDataReader.GetOrdinal("FechaModifica")
            Dim INDICE_FechaRango As Integer = oIDataReader.GetOrdinal("FechaRango")
            Dim INDICE_IdModoPago As Integer = oIDataReader.GetOrdinal("IdModoPago")

            While oIDataReader.Read()

                oPaginacion.ClienteVenta = New ClienteVenta()

                oPaginacion.ClienteVenta.IdCliente = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_IdCliente))
                oPaginacion.ClienteVenta.RUC = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_RUC))
                oPaginacion.ClienteVenta.RazonSocial = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_RazonSocial))
                oPaginacion.ClienteVenta.NombresApellidos = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_NombresApellidos))
                oPaginacion.ClienteVenta.Telefono = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_Telefono))
                oPaginacion.ClienteVenta.DescripcionModoPago = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_ModoPago))
                oPaginacion.ClienteVenta.FechaModificacion = DataUtil.DbValueToDefault(Of Date)(oIDataReader(INDICE_FechaModifica))
                oPaginacion.ClienteVenta.FechaRango = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_FechaRango))
                'oPaginacion.ClienteVenta.FechaResultado = fechaActual.Day - oPaginacion.ClienteVenta.FechaModificacion.Day
                oPaginacion.ClienteVenta.ProcesoEstado = New ProcesoEstado()
                oPaginacion.ClienteVenta.ProcesoEstado.Codigo = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_Estado))
                oPaginacion.ClienteVenta.ProcesoEstado.IdEstado = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_EstadoCliente))
                oPaginacion.ClienteVenta.EmpleadoDepartamento = New EmpleadoDepartamento()
                oPaginacion.ClienteVenta.EmpleadoDepartamento.DescripcionDepa = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_Region))
                oPaginacion.ClienteVenta.EmpleadoProvincia = New EmpleadoProvincia()
                oPaginacion.ClienteVenta.EmpleadoProvincia.DescripcionProv = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_Provincia))
                oPaginacion.ClienteVenta.ClienteSector = New ClienteSector()
                oPaginacion.ClienteVenta.ClienteSector.Descripcion = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_Sector))
                oPaginacion.ClienteVenta.ClienteCategoria = New ClienteCategoria()
                oPaginacion.ClienteVenta.ClienteCategoria.Descripcion = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_Categoria))
                oPaginacion.ClienteVenta.ClienteTipo = New ClienteTipo()
                oPaginacion.ClienteVenta.ClienteTipo.Descripcion = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_Tipo))
                oPaginacion.ClienteVenta.Activo = DataUtil.DbValueToDefault(Of Boolean)(oIDataReader(INDICE_ACTIVO))
                oPaginacion.ClienteVenta.ClienteModoPagoCombo = New ClienteModoPagoCombo()
                oPaginacion.ClienteVenta.ClienteModoPagoCombo.IdModoPago = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_IdModoPago))

                oPaginacion.ListaClienteVenta.Add(oPaginacion.ClienteVenta)
            End While
        End Using

        oPaginacion.TotalRows = Convert.ToInt32(oDatabase.GetParameterValue(oDbCommand, "@TotalRows"))

        Return oPaginacion

    End Function

    Public Function CrearCarteraClientes(ByRef oVentaCartera As VentaCartera) As Int32
        Dim resultado As Integer = -1
        resultado = DirectCast(oDatabase.ExecuteScalar(Procedimientos.USP_INSERT_CARTERA,
                                                      oVentaCartera.IdCliente,
                                                      oVentaCartera.IdEmpleado,
                                                      oVentaCartera.IdCarteraEmpleadoTipo,
                                                      oVentaCartera.IdSucursal,
                                                      oVentaCartera.FechaActivacion,
                                                      oVentaCartera.Porcentaje,
                                                      oVentaCartera.Usuario
                                                      ), Int32)
        Return resultado
    End Function
    ' , ByRef activo As Integer
    Public Function ActualizarEstadoCartera(ByVal IdCartera As Integer, ByVal IdCliente As Integer, ByVal FechaDesasignacion As DateTime) As Int32
        Dim result As Integer = 0
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_UPD_ACTUALIZARCARTERA)
        oDatabase.AddInParameter(oDbCommand, "@IDCartera", DbType.Int32, IdCartera)
        'oDatabase.AddInParameter(oDbCommand, "@IdActivo", DbType.Boolean, IdEstado)
        oDatabase.AddInParameter(oDbCommand, "@IdCliente", DbType.Int32, IdCliente)
        oDatabase.AddInParameter(oDbCommand, "@FECHADESASIGNACION", DbType.DateTime, FechaDesasignacion)
        result = Integer.Parse(oDatabase.ExecuteScalar(oDbCommand))

        Return result
    End Function



    Public Function CrearCliente(ByVal oClienteVenta As ClienteVenta) As Int32
        Dim resultado As Int32
        resultado = DirectCast(oDatabase.ExecuteScalar(Procedimientos.USP_INS_CLIENTE,
                                                       oClienteVenta.IdClienteCategoria, oClienteVenta.IdClienteSector,
                                                       oClienteVenta.IdClienteTipo, oClienteVenta.IdModoPago,
                                                       oClienteVenta.FechaActivacion, oClienteVenta.FechaVigenciaCliente,
                                                       oClienteVenta.IdTipoDocumentoCliente, oClienteVenta.RUC,
                                                       oClienteVenta.RazonSocial, oClienteVenta.NombreFantasia,
                                                       oClienteVenta.NombreCuenta, oClienteVenta.NombreRepresentanteLegal,
                                                        oClienteVenta.ClasificadorExterno, oClienteVenta.IdDepartamento,
                                                        oClienteVenta.IdProvincia, oClienteVenta.IdDistrito,
                                                        oClienteVenta.Calle, oClienteVenta.Telefono,
                                                        oClienteVenta.Fax, oClienteVenta.Email,
                                                        oClienteVenta.FechaAniversario,
                                                       oClienteVenta.UsuarioRegistro,
                                                        oClienteVenta.Grupo.IdGrupo,
                                                        oClienteVenta.ProcedenciaCapital
                                                       ), Int32)
        Return resultado
    End Function
    'oClienteVenta.Grupo.IdGrupo,

    Public Function ModificarCliente(ByVal oClienteVenta As ClienteVenta) As Int32
        Dim resultado As Int32
        resultado = DirectCast(oDatabase.ExecuteScalar(Procedimientos.USP_UPD_CLIENTE, oClienteVenta.IdCliente,
                                                       oClienteVenta.IdClienteCategoria, oClienteVenta.IdClienteSector,
                                                       oClienteVenta.IdClienteTipo, oClienteVenta.IdModoPago,
                                                       oClienteVenta.FechaActivacion, oClienteVenta.FechaVigenciaCliente,
                                                       oClienteVenta.IdTipoDocumentoCliente, oClienteVenta.RUC,
                                                       oClienteVenta.RazonSocial, oClienteVenta.NombreFantasia,
                                                       oClienteVenta.NombreCuenta, oClienteVenta.NombreRepresentanteLegal,
                                                       oClienteVenta.ClasificadorExterno, oClienteVenta.IdDepartamento,
                                                       oClienteVenta.IdProvincia, oClienteVenta.IdDistrito,
                                                       oClienteVenta.Calle, oClienteVenta.Telefono,
                                                       oClienteVenta.Fax, oClienteVenta.Email,
                                                       oClienteVenta.FechaAniversario, oClienteVenta.UsuarioRegistro, oClienteVenta.Grupo.IdGrupo,
                                                       oClienteVenta.ProcedenciaCapital), Int32)
        Return resultado
    End Function

    Public Function ModificarClienteContacto(ByVal oClienteContacto As ClienteContacto) As Int32
        Dim resul As Int32
        resul = DirectCast(oDatabase.ExecuteScalar(Procedimientos.USP_UPD_CLIENTECONTACTO,
                                                 oClienteContacto.IdContacto, oClienteContacto.ContactoTipo,
                                                 oClienteContacto.Nombres, oClienteContacto.Apellidos,
                                                 oClienteContacto.Telefono, oClienteContacto.Email,
                                                 oClienteContacto.IdContactoClase, oClienteContacto.Fax,
                                                 oClienteContacto.Celular1, oClienteContacto.Celular2,
                                                 oClienteContacto.FechaNacimiento), Int32)
        Return resul
    End Function

    Public Function AgregarContacto(ByVal oClienteContacto As ClienteContacto) As Int32
        Dim res As Int32
        res = DirectCast(oDatabase.ExecuteScalar(Procedimientos.USP_CONTACTOAGREGAR,
                                                 oClienteContacto.IdCliente, oClienteContacto.IdCargoTipo,
                                                 oClienteContacto.Nombres, oClienteContacto.Apellidos,
                                                 oClienteContacto.Telefono, oClienteContacto.Email,
                                                 oClienteContacto.IdContactoClase, oClienteContacto.Fax,
                                                 oClienteContacto.Celular1, oClienteContacto.Celular2,
                                                 oClienteContacto.FechaNacimiento), Int32)
        Return res

    End Function

    Public Function ListaClienteContacto(ByVal oPaginacion As Paginacion) As Paginacion
        Dim oListaClienteContacto As New ListaClienteContacto()
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_LISTACONTACTO)
        oDatabase.AddInParameter(oDbCommand, "@IdCliente", DbType.Int32, oPaginacion.ClienteContacto.IdCliente)
        oDatabase.AddInParameter(oDbCommand, "@PageSize", DbType.Int32, oPaginacion.PageSize)
        oDatabase.AddInParameter(oDbCommand, "@PageNumber", DbType.Int32, oPaginacion.PageNumber)
        oDatabase.AddInParameter(oDbCommand, "@SortBy", DbType.String, oPaginacion.SortBy)
        oDatabase.AddInParameter(oDbCommand, "@SortType", DbType.String, oPaginacion.SortType)
        oDatabase.AddOutParameter(oDbCommand, "@TotalRows", DbType.Int32, 10)
        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim indiceIdContacto As Integer = oIDataReader.GetOrdinal("IdContacto")
            Dim indiceIdCliente As Integer = oIDataReader.GetOrdinal("IdCliente")
            Dim indiceNombres As Integer = oIDataReader.GetOrdinal("Nombres")
            Dim indiceApellidos As Integer = oIDataReader.GetOrdinal("Apellidos")
            Dim indiceTelefono As Integer = oIDataReader.GetOrdinal("Telefono")
            Dim indiceEmail As Integer = oIDataReader.GetOrdinal("Email")
            Dim indiceIdContactoClase As Integer = oIDataReader.GetOrdinal("IdContactoClase")
            Dim indiceIdContactoTipo As Integer = oIDataReader.GetOrdinal("IdContactoTipo")
            Dim indiceDescripcion As Integer = oIDataReader.GetOrdinal("DescripcionCortaTabGen")
            While oIDataReader.Read()
                Dim oClienteContacto As ClienteContacto
                oClienteContacto = New ClienteContacto()
                oClienteContacto.IdContacto = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(indiceIdContacto))
                oClienteContacto.IdCliente = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(indiceIdCliente))
                oClienteContacto.Nombres = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceNombres))
                oClienteContacto.Apellidos = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceApellidos))
                oClienteContacto.Telefono = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceTelefono))
                oClienteContacto.Email = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceEmail))
                oClienteContacto.IdContactoClase = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(indiceIdContactoClase))
                oClienteContacto.IdCargoTipo = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(indiceIdContactoTipo))
                oClienteContacto.Cargo = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceDescripcion))
                oListaClienteContacto.Add(oClienteContacto)
            End While
        End Using
        oPaginacion.ListaClienteContacto = New List(Of ClienteContacto)
        oPaginacion.ListaClienteContacto = oListaClienteContacto
        oPaginacion.TotalRows = Convert.ToInt32(oDatabase.GetParameterValue(oDbCommand, "@TotalRows"))
        Return oPaginacion
    End Function

    Function ListaContactoClase() As ListaContactoClase
        Dim oListaContactoClase As New ListaContactoClase()
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_LISTACLASECONTACTO)
        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim oContactoClase As New ContactoClase()
            Dim indiceIdContactoClase As Integer = oIDataReader.GetOrdinal("IdTabGen")
            Dim indiceDescripcion As Integer = oIDataReader.GetOrdinal("DescripcionCortaTabGen")
            While oIDataReader.Read()
                oContactoClase = New ContactoClase()
                oContactoClase.IdContactoClase = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(indiceIdContactoClase))
                oContactoClase.Descripcion = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceDescripcion))
                oListaContactoClase.Add(oContactoClase)
            End While
        End Using
        Return oListaContactoClase
    End Function

    Function ListaClienteModoPago() As ListaClienteModoPagoCombo
        Dim oListaClienteModoPagoCombo As New ListaClienteModoPagoCombo()
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_CLIENTEMODOPAGO)
        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim oClienteModoPagoCombo As New ClienteModoPagoCombo
            Dim indiceIdModoPago As Integer = oIDataReader.GetOrdinal("IdModoPago")
            Dim indiceDescripcion As Integer = oIDataReader.GetOrdinal("Descripcion")
            While oIDataReader.Read()
                oClienteModoPagoCombo = New ClienteModoPagoCombo()
                oClienteModoPagoCombo.IdModoPago = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(indiceIdModoPago))
                oClienteModoPagoCombo.DescripcionModoPago = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceDescripcion))
                oListaClienteModoPagoCombo.Add(oClienteModoPagoCombo)
            End While
        End Using
        Return oListaClienteModoPagoCombo
    End Function

    Function ListaContactoTipo() As ListaContactoTipo
        Dim oListaContactoTipo As New ListaContactoTipo()
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_LIST_TIPOCONTACTO)
        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim oContactoTipo As New ContactoTipo()
            Dim indiceIdContactoTipo As Integer = oIDataReader.GetOrdinal("IdTabGen")
            Dim indiceDescripcion As Integer = oIDataReader.GetOrdinal("DescripcionLargaTabGen")
            While oIDataReader.Read()
                oContactoTipo = New ContactoTipo()
                oContactoTipo.IdContactoTipo = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(indiceIdContactoTipo))
                oContactoTipo.Descripcion = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceDescripcion))
                oListaContactoTipo.Add(oContactoTipo)
            End While
        End Using
        Return oListaContactoTipo
    End Function

    Public Function ListarHistorialLineaCliente(oPaginacion As Paginacion) As Paginacion Implements IClienteDataAccess.ListarHistorialLineaCliente

        Dim oListaClienteLineaCreadito As New ListaClienteLineaCredito()
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_LISTACLIENTELINEACREDITO_NUEVO)

        oDatabase.AddInParameter(oDbCommand, "@IdCliente", DbType.Int32, oPaginacion.ClienteLineaCredito.IdCliente)
        oDatabase.AddInParameter(oDbCommand, "@PageSize", DbType.Int32, oPaginacion.PageSize)
        oDatabase.AddInParameter(oDbCommand, "@PageNumber", DbType.Int32, oPaginacion.PageNumber)
        oDatabase.AddInParameter(oDbCommand, "@SortBy", DbType.String, oPaginacion.SortBy)
        oDatabase.AddInParameter(oDbCommand, "@SortType", DbType.String, oPaginacion.SortType)
        oDatabase.AddOutParameter(oDbCommand, "@TotalRows", DbType.Int32, 10)
        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)

            Dim indiceLCAutorizada As Integer = oIDataReader.GetOrdinal("LCAutorizada")
            Dim indiceFactCentral As Integer = oIDataReader.GetOrdinal("FactCentral")
            Dim indiceLCSigic As Integer = oIDataReader.GetOrdinal("LCSigic")
            Dim indiceFactSigic As Integer = oIDataReader.GetOrdinal("FactSigic")
            Dim indiceLCDisponible As Integer = oIDataReader.GetOrdinal("LCDisponible")
            Dim indiceFechaAperturaLinea As Integer = oIDataReader.GetOrdinal("FechaAperturaLinea")
            Dim indiceFechaExpiracion As Integer = oIDataReader.GetOrdinal("FechaExpiracion")
            Dim indiceDiasPlazo As Integer = oIDataReader.GetOrdinal("DiasPlazo")


            While oIDataReader.Read()
                Dim oClienteLineaCredito As ClienteLineaCredito
                oClienteLineaCredito = New ClienteLineaCredito()
                oClienteLineaCredito.IdCliente = oPaginacion.ClienteLineaCredito.IdCliente
                oClienteLineaCredito.LCAutorizada = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(indiceLCAutorizada))
                oClienteLineaCredito.FactCentral = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(indiceFactCentral))
                oClienteLineaCredito.LCSigic = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(indiceLCSigic))
                oClienteLineaCredito.FactSigic = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(indiceFactSigic))
                oClienteLineaCredito.LCDisponible = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(indiceLCDisponible))
                oClienteLineaCredito.FechaAperturaLinea = DataUtil.DbValueToDefault(Of DateTime)(oIDataReader(indiceFechaAperturaLinea))
                oClienteLineaCredito.FechaExpiracion = DataUtil.DbValueToDefault(Of DateTime)(oIDataReader(indiceFechaExpiracion))
                oClienteLineaCredito.DiasPlazo = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indiceDiasPlazo))

                oListaClienteLineaCreadito.Add(oClienteLineaCredito)
            End While
        End Using
        oPaginacion.ListaClienteLineaCredito = New ListaClienteLineaCredito()
        oPaginacion.ListaClienteLineaCredito = oListaClienteLineaCreadito
        oPaginacion.TotalRows = Convert.ToInt32(oDatabase.GetParameterValue(oDbCommand, "@TotalRows"))
        Return oPaginacion

    End Function

    Public Function ConsultarClienteID(ByVal IdCliente As Int32) As ClienteVenta
        Dim oClienteVenta As New ClienteVenta
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(Procedimientos.USP_SEL_CLIENTE_ID, IdCliente)
            Dim indiceIdCliente As Integer = oIDataReader.GetOrdinal("IdCliente")
            Dim indiceIdClienteCategoria As Integer = oIDataReader.GetOrdinal("IdClienteCategoria")
            Dim indiceIdClienteSector As Integer = oIDataReader.GetOrdinal("IdClienteSector")
            Dim indiceIdClienteTipo As Integer = oIDataReader.GetOrdinal("IdClienteTipo")
            Dim indiceSigicCliente As Integer = oIDataReader.GetOrdinal("SigicCliente")
            Dim indiceSigicFechaRegistro As Integer = oIDataReader.GetOrdinal("SigicFechaRegistro")
            Dim indiceSigicFechaActivacion As Integer = oIDataReader.GetOrdinal("SigicFechaActivacion")
            Dim indiceFechaActivacion As Integer = oIDataReader.GetOrdinal("FechaActivacion")
            Dim indiceRUC As Integer = oIDataReader.GetOrdinal("RUC")
            Dim indiceCuenta As Integer = oIDataReader.GetOrdinal("Cuenta")
            Dim indiceRazonSocial As Integer = oIDataReader.GetOrdinal("RazonSocial")
            Dim indiceNombreFantasia As Integer = oIDataReader.GetOrdinal("NombreFantasia")
            Dim indiceNombreCuenta As Integer = oIDataReader.GetOrdinal("NombreCuenta")
            Dim indiceNombreRepresentanteLegal As Integer = oIDataReader.GetOrdinal("NombreRepresentanteLegal")
            Dim indiceClasificadorExterno As Integer = oIDataReader.GetOrdinal("NombreRepresentanteLegal")
            Dim indiceCanje As Integer = oIDataReader.GetOrdinal("Canje")
            Dim indiceIdSucursalResponsable As Integer = oIDataReader.GetOrdinal("IdSucursalResponsable")
            Dim indiceIdEmpleadoPrincipal As Integer = oIDataReader.GetOrdinal("IdEmpleadoPrincipal")
            Dim indiceIdContactoPrincipal As Integer = oIDataReader.GetOrdinal("IdContactoPrincipal")
            Dim indiceIdDepartamento As Integer = oIDataReader.GetOrdinal("IdDepartamento")
            Dim indiceIdProvincia As Integer = oIDataReader.GetOrdinal("IdProvincia")
            Dim indiceIdDistrito As Integer = oIDataReader.GetOrdinal("IdDistrito")
            Dim indiceCalle As Integer = oIDataReader.GetOrdinal("Calle")
            Dim indiceTelefono As Integer = oIDataReader.GetOrdinal("Telefono")
            Dim indiceFax As Integer = oIDataReader.GetOrdinal("Fax")
            Dim indiceEmail As Integer = oIDataReader.GetOrdinal("Email")
            Dim indiceFechaDesde As Integer = oIDataReader.GetOrdinal("FechaDesde")
            Dim indiceFechaHasta As Integer = oIDataReader.GetOrdinal("FechaHasta")
            Dim indiceIdEstadoActual As Integer = oIDataReader.GetOrdinal("IdEstadoActual")
            Dim indiceCodigoEstado As Integer = oIDataReader.GetOrdinal("CodigoEstado")
            Dim indiceActivo As Integer = oIDataReader.GetOrdinal("Activo")
            Dim indiceFechaAniversario As Integer = oIDataReader.GetOrdinal("FechaAniversario")
            Dim indiceIdModoPago As Integer = oIDataReader.GetOrdinal("IdModoPago")
            Dim indiceIdGrupo As Integer = oIDataReader.GetOrdinal("IdGrupo")
            Dim indiceprocCapital As Integer = oIDataReader.GetOrdinal("ProcedenciaCapital")
            Dim indiceIdTipoDocumentoCliente As Integer = oIDataReader.GetOrdinal("IdTipoDocumentoCliente")
            Dim indiceFechaVigencia As Integer = oIDataReader.GetOrdinal("FechaVigencia")


            While oIDataReader.Read()
                oClienteVenta = New ClienteVenta()
                oClienteVenta.IdCliente = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(indiceIdCliente))
                oClienteVenta.IdClienteCategoria = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(indiceIdClienteCategoria))
                oClienteVenta.IdClienteSector = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(indiceIdClienteSector))
                oClienteVenta.IdClienteTipo = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(indiceIdClienteTipo))
                oClienteVenta.SigicCliente = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indiceIdClienteSector))
                oClienteVenta.SigicFechaRegistro = DataUtil.DbValueToDefault(Of DateTime)(oIDataReader(indiceSigicFechaRegistro))
                oClienteVenta.SigicFechaActivacion = DataUtil.DbValueToDefault(Of DateTime)(oIDataReader(indiceSigicFechaActivacion))
                oClienteVenta.FechaActivacion = DataUtil.DbValueToDefault(Of DateTime)(oIDataReader(indiceFechaActivacion))
                oClienteVenta.RUC = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceRUC))
                oClienteVenta.Cuenta = DataUtil.DbValueToDefault(Of Byte)(oIDataReader(indiceCuenta))
                oClienteVenta.RazonSocial = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceRazonSocial))
                oClienteVenta.NombreFantasia = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceNombreFantasia))
                oClienteVenta.NombreCuenta = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceNombreCuenta))
                oClienteVenta.NombreRepresentanteLegal = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceNombreRepresentanteLegal))
                oClienteVenta.ClasificadorExterno = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceClasificadorExterno))
                oClienteVenta.Canje = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceCanje))
                oClienteVenta.IdSucursalResponsable = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(indiceIdSucursalResponsable))
                oClienteVenta.IdEmpleadoPrincipal = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(indiceIdEmpleadoPrincipal))
                oClienteVenta.IdContactoPrincipal = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceIdContactoPrincipal))
                oClienteVenta.IdDepartamento = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(indiceIdDepartamento))
                oClienteVenta.IdProvincia = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(indiceIdProvincia))
                oClienteVenta.IdDistrito = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(indiceIdDistrito))
                oClienteVenta.Calle = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceCalle))
                oClienteVenta.Telefono = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceTelefono))
                oClienteVenta.Fax = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceFax))
                oClienteVenta.Email = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceEmail))
                oClienteVenta.FechaDesde = DataUtil.DbValueToDefault(Of Date)(oIDataReader(indiceFechaDesde))
                oClienteVenta.FechaHasta = DataUtil.DbValueToDefault(Of Date)(oIDataReader(indiceFechaHasta))
                oClienteVenta.Estado = New Estado()
                oClienteVenta.Estado.IdEstado = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(indiceIdEstadoActual))
                oClienteVenta.Estado.Codigo = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceCodigoEstado))
                oClienteVenta.Activo = DataUtil.DbValueToDefault(Of Boolean)(oIDataReader(indiceActivo))
                oClienteVenta.FechaAniversario = DataUtil.DbValueToDefault(Of Date)(oIDataReader(indiceFechaAniversario))
                oClienteVenta.IdModoPago = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(indiceIdModoPago))
                oClienteVenta.Grupo = New Grupo()
                oClienteVenta.Grupo.IdGrupo = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indiceIdGrupo))
                oClienteVenta.ProcedenciaCapital = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceprocCapital))
                oClienteVenta.IdTipoDocumentoCliente = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indiceIdTipoDocumentoCliente))
                oClienteVenta.FechaVigenciaCliente = DataUtil.DbValueToDefault(Of DateTime)(oIDataReader(indiceFechaVigencia))
            End While
        End Using

        Return oClienteVenta
    End Function

    Public Function ActualizarClienteEstado(ByVal IdCliente As Integer, ByVal IdEstado As Integer, ByVal Activo As Boolean, ByVal Usuario As String) As Int32
        Dim result As Int32
        result = DirectCast(oDatabase.ExecuteScalar(Procedimientos.USP_UPD_CLIENTE_ESTADO, IdCliente, IdEstado, Activo, Usuario), Int32)
        Return result
    End Function

    Public Function CrearClienteAdjunto(ByVal oClienteAdjunto As ClienteAdjunto)
        Dim resultado = 0
        resultado = DirectCast(oDatabase.ExecuteScalar(Procedimientos.USP_INS_CLIENTE_ADJUNTO, oClienteAdjunto.IdCliente,
                                                                                               oClienteAdjunto.NombreTemp,
                                                                                               oClienteAdjunto.NombreAdj,
                                                                                               oClienteAdjunto.TipoContenidoAdj,
                                                                                               oClienteAdjunto.TamanioAdj,
                                                                                               oClienteAdjunto.RutaAdj), Int32)

        Return resultado
    End Function

    Public Function ConsultarClienteAdjunto(ByRef oPaginacion As Paginacion) As Paginacion

        oPaginacion.ListaClienteVenta = New ListaClienteVenta()

        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_CLIENTE_ADJUNTO)


        oDatabase.AddInParameter(oDbCommand, "@IdCliente", DbType.Int32, oPaginacion.ClienteAdjunto.IdCliente)
        oDatabase.AddInParameter(oDbCommand, "@PageSize", DbType.Int32, oPaginacion.PageSize)
        oDatabase.AddInParameter(oDbCommand, "@PageNumber", DbType.Int32, oPaginacion.PageNumber)
        oDatabase.AddInParameter(oDbCommand, "@SortBy", DbType.String, oPaginacion.SortBy)
        oDatabase.AddInParameter(oDbCommand, "@SortType", DbType.String, oPaginacion.SortType)
        oDatabase.AddOutParameter(oDbCommand, "@TotalRows", DbType.Int32, 10)

        oDbCommand.CommandTimeout = 120000

        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)

            Dim indiceIdAdj As Integer = oIDataReader.GetOrdinal("IdAdj")
            Dim indiceNombreTemp As Integer = oIDataReader.GetOrdinal("NombreTemp")
            Dim indiceNombreAdj As Integer = oIDataReader.GetOrdinal("NombreAdj")
            Dim indiceTipoContenidoAdj As Integer = oIDataReader.GetOrdinal("TipoContenidoAdj")
            Dim indiceTamanioAdj As Integer = oIDataReader.GetOrdinal("TamanioAdj")
            Dim indiceRutaAdj As Integer = oIDataReader.GetOrdinal("RutaAdj")
            Dim indiceFechaRegistro As Integer = oIDataReader.GetOrdinal("FechaRegistro")
            Dim indiceActivoAdj As Integer = oIDataReader.GetOrdinal("ActivoAdj")
            oPaginacion.ListaClienteAdjunto = New ListaClienteAdjunto()

            While oIDataReader.Read()

                oPaginacion.ClienteAdjunto = New ClienteAdjunto()

                oPaginacion.ClienteAdjunto.IdAdj = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indiceIdAdj))
                oPaginacion.ClienteAdjunto.NombreTemp = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceNombreTemp))
                oPaginacion.ClienteAdjunto.NombreAdj = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceNombreAdj))
                oPaginacion.ClienteAdjunto.TipoContenidoAdj = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceTipoContenidoAdj))
                oPaginacion.ClienteAdjunto.Tamanio = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(indiceTamanioAdj))
                oPaginacion.ClienteAdjunto.FechaRegistro = DataUtil.DbValueToDefault(Of Date)(oIDataReader(indiceFechaRegistro))
                oPaginacion.ClienteAdjunto.ActivoAdj = DataUtil.DbValueToDefault(Of Boolean)(oIDataReader(indiceActivoAdj))



                oPaginacion.ListaClienteAdjunto.Add(oPaginacion.ClienteAdjunto)
            End While
        End Using

        oPaginacion.TotalRows = Convert.ToInt32(oDatabase.GetParameterValue(oDbCommand, "@TotalRows"))

        Return oPaginacion

    End Function

    Function ConsultarClienteAdjuntoId(IdAdj As Integer) As ClienteAdjunto
        Dim oClienteAdjunto As New ClienteAdjunto
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(Procedimientos.USP_SEL_CLIENTE_ADJUNTOID, IdAdj)
            Dim indiceIdCliente As Integer = oIDataReader.GetOrdinal("IdCliente")
            Dim indiceNombreTemp As Integer = oIDataReader.GetOrdinal("NombreTemp")
            Dim indiceNombreAdj As Integer = oIDataReader.GetOrdinal("NombreAdj")
            Dim indiceTipoContenidoAdj As Integer = oIDataReader.GetOrdinal("TipoContenidoAdj")
            Dim indiceTamanioAdj As Integer = oIDataReader.GetOrdinal("TamanioAdj")
            Dim indiceRutaAdj As Integer = oIDataReader.GetOrdinal("RutaAdj")
            Dim indiceFechaRegistro As Integer = oIDataReader.GetOrdinal("FechaRegistro")
            Dim indiceActivoAdj As Integer = oIDataReader.GetOrdinal("ActivoAdj")
            While oIDataReader.Read()
                oClienteAdjunto = New ClienteAdjunto()
                oClienteAdjunto.IdCliente = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indiceIdCliente))
                oClienteAdjunto.NombreTemp = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceNombreTemp))
                oClienteAdjunto.NombreAdj = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceNombreAdj))
                oClienteAdjunto.TipoContenidoAdj = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceTipoContenidoAdj))
                oClienteAdjunto.TamanioAdj = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(indiceTamanioAdj))
                oClienteAdjunto.RutaAdj = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceRutaAdj))
                oClienteAdjunto.FechaRegistro = DataUtil.DbValueToDefault(Of Date)(oIDataReader(indiceFechaRegistro))
                oClienteAdjunto.ActivoAdj = DataUtil.DbValueToDefault(Of Boolean)(oIDataReader(indiceActivoAdj))
            End While
        End Using
        Return oClienteAdjunto
    End Function

    Function EliminarClienteAdjunto(IdAdj As Integer) As Integer
        Dim resultado As Integer
        resultado = DirectCast(oDatabase.ExecuteScalar(Procedimientos.USP_DEL_CLIENTEADJUNTO, IdAdj), Integer)
        Return resultado
    End Function


    Public Function ObtenerClienteContactoPorId(IdContacto As Int32) As ClienteContacto

        Dim oClienteContacto As New ClienteContacto
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(Procedimientos.USP_SEL_CLIENTECONTACTOID, IdContacto)

            Dim indiceIdContactoTipo As Integer = oIDataReader.GetOrdinal("IdContactoTipo")
            Dim indiceIdContactoClase As Integer = oIDataReader.GetOrdinal("IdContactoClase")
            Dim indiceNombres As Integer = oIDataReader.GetOrdinal("Nombres")
            Dim indiceApellidos As Integer = oIDataReader.GetOrdinal("Apellidos")
            Dim indiceTelefono As Integer = oIDataReader.GetOrdinal("Telefono")
            Dim indiceFax As Integer = oIDataReader.GetOrdinal("Fax")
            Dim indiceCelular1 As Integer = oIDataReader.GetOrdinal("Celular1")
            Dim indiceCelular2 As Integer = oIDataReader.GetOrdinal("Celular2")
            Dim indiceEmail As Integer = oIDataReader.GetOrdinal("Email")
            Dim indiceFechaNacimiento As Integer = oIDataReader.GetOrdinal("FechaNacimiento")
            While oIDataReader.Read()
                oClienteContacto = New ClienteContacto()
                oClienteContacto.ContactoTipo = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(indiceIdContactoTipo))
                oClienteContacto.IdContactoClase = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(indiceIdContactoClase))
                oClienteContacto.Nombres = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceNombres))
                oClienteContacto.Apellidos = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceApellidos))
                oClienteContacto.Telefono = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceTelefono))
                oClienteContacto.Fax = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceFax))
                oClienteContacto.Celular1 = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceCelular1))
                oClienteContacto.Celular2 = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceCelular2))
                oClienteContacto.Email = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceEmail))
                oClienteContacto.FechaNacimiento = DataUtil.DbValueToDefault(Of DateTime)(oIDataReader(indiceFechaNacimiento))
            End While
        End Using

        Return oClienteContacto
    End Function


    Function ConsultarEstado() As ListaProcesoEstado
        Dim oListaProcesoEstado As New ListaProcesoEstado()
        oListaProcesoEstado = New ListaProcesoEstado
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_CLIENTECONSULTARESTADO)
        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim indiceIdEstado As Integer = oIDataReader.GetOrdinal("IdTabGen")
            Dim indiceDescripcion As Integer = oIDataReader.GetOrdinal("DescripcionLargaTabGen")
            Dim oProcesoEstado As New ProcesoEstado()
            While (oIDataReader.Read())
                oProcesoEstado = New ProcesoEstado()
                oProcesoEstado.IdEstado = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indiceIdEstado))
                oProcesoEstado.Descripcion = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceDescripcion))

                oListaProcesoEstado.Add(oProcesoEstado)
            End While
        End Using
        Return oListaProcesoEstado
    End Function

    Function ListarEmpleadosBySucursal(ByVal IdSucursal As String) As ListaEmpleado
        Dim oListaEmpleado As New ListaEmpleado()

        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(Procedimientos.USP_LISTACOMBO_EMPLEADOS_BYSUCURSAL, IdSucursal)
            Dim oEmpleado As New Empleado()
            Dim indiceIdEmpleado As Integer = oIDataReader.GetOrdinal("IdEmpleado")
            Dim indiceNombres As Integer = oIDataReader.GetOrdinal("Nombres")
            While oIDataReader.Read()
                oEmpleado = New Empleado()
                oEmpleado.IdEmpleado = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(indiceIdEmpleado))
                oEmpleado.Nombres = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceNombres))
                oListaEmpleado.Add(oEmpleado)
            End While
        End Using
        Return oListaEmpleado
    End Function

    Function ListaClienteTipo() As ListaClienteTipo
        Dim oListaClienteTipo As New ListaClienteTipo()
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_CLIENTETIPO)
        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim oClienteTipo As New ClienteTipo
            Dim indiceIdClienteTipo As Integer = oIDataReader.GetOrdinal("IdClienteTipo")
            Dim indiceDescripcion As Integer = oIDataReader.GetOrdinal("Descripcion")
            While oIDataReader.Read()
                oClienteTipo = New ClienteTipo()
                oClienteTipo.IdClienteTipo = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(indiceIdClienteTipo))
                oClienteTipo.Descripcion = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceDescripcion))
                oListaClienteTipo.Add(oClienteTipo)
            End While
        End Using
        Return oListaClienteTipo
    End Function

    Function TraerCliente(IdCliente As Integer) As String
        Dim oClienteVenta As New ClienteVenta()
        Dim resultado As String = ""
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_OBT_TRAERRAZONSOCIAL, IdCliente)

        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim indiceRazonSocial As Integer = oIDataReader.GetOrdinal("RazonSocial")
            While oIDataReader.Read()
                resultado = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceRazonSocial))
            End While
        End Using
        Return resultado
    End Function

    '//////////////////////////////////////////////////////////// REASIGNACION DE CLIENTE VVEE   //////////////////////////////////////////////

    '//////////////////////////////////////////////////  LISTAR SUCURSALES  ///////////////////////////////////////////////////

    Function ListarSucursales_Zona(IdZona As Integer) As ListaSucursal
        Dim oListaSucursal As New ListaSucursal()
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_LISTASUCURSALPORZONA, IdZona)
        oDbCommand.CommandTimeout = 120000
        Dim oSucursal As New Sucursal()
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_IdSucursal As Integer = oIDataReader.GetOrdinal("IdSucursal")
            Dim INDICE_Descripcion As Integer = oIDataReader.GetOrdinal("Descripcion")
            While oIDataReader.Read()
                oSucursal = New Sucursal
                oSucursal.IdSucursal = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_IdSucursal))
                oSucursal.Descripcion = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_Descripcion))
                oListaSucursal.Add(oSucursal)
            End While
        End Using
        Return oListaSucursal
    End Function


    Function ListarSucursales() As ListaSucursal
        Dim oListaSucursal As New ListaSucursal()

        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_LISTARSUCURSAL)
        oDbCommand.CommandTimeout = 120000
        ' oListaSucursal = New ListaSucursal
        Dim oSucursal As New Sucursal()
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_IdSucursal As Integer = oIDataReader.GetOrdinal("IdSucursal")
            Dim INDICE_Descripcion As Integer = oIDataReader.GetOrdinal("Descripcion")
            While oIDataReader.Read()
                oSucursal = New Sucursal
                oSucursal.IdSucursal = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_IdSucursal))
                oSucursal.Descripcion = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_Descripcion))
                oListaSucursal.Add(oSucursal)
            End While
        End Using
        Return oListaSucursal
    End Function

    '/////////////////////////////////////////////// LISTAR EMPLEADOS POR SUCURSAL  ///////////////////////////////////////////////////////////

    Function ListarEmpleadoporSucursales(IdSucursal As Integer, Idestado As Boolean) As ListaEmpleado
        Dim oListaEmpleados As New ListaEmpleado
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_LISTAEMPLEADOSPORSUCURSAL)
        oDatabase.AddInParameter(oDbCommand, "@IdSucursal", DbType.Int32, IdSucursal)
        oDatabase.AddInParameter(oDbCommand, "@IdEstado", DbType.Int32, Idestado)

        oDbCommand.CommandTimeout = 120000

        Dim oEmpleado As New Empleado()
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_IdEmpleado As Integer = oIDataReader.GetOrdinal("IdEmpleado")
            Dim INDICE_NombresApellidos As Integer = oIDataReader.GetOrdinal("NombresApellidos")
            While oIDataReader.Read()
                oEmpleado = New Empleado()
                oEmpleado.IdEmpleado = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_IdEmpleado))
                oEmpleado.NombresApellidos = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_NombresApellidos))
                oListaEmpleados.Add(oEmpleado)
            End While
        End Using
        Return oListaEmpleados
    End Function

    Function ListarEmpleadoporSucursalesFiltroVendedor(IdSucursal As Integer, Idestado As Boolean, IdVendedor As Integer) As ListaEmpleado
        Dim oListaEmpleados As New ListaEmpleado
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_LISTAEMPLEADOSPORSUCURSALFILTROIDVENDEDOR)
        oDatabase.AddInParameter(oDbCommand, "@IdSucursal", DbType.Int32, IdSucursal)
        oDatabase.AddInParameter(oDbCommand, "@IdEstado", DbType.Int32, Idestado)
        oDatabase.AddInParameter(oDbCommand, "@IdVendedor", DbType.Int32, IdVendedor)

        oDbCommand.CommandTimeout = 120000

        Dim oEmpleado As New Empleado()
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_IdEmpleado As Integer = oIDataReader.GetOrdinal("IdEmpleado")
            Dim INDICE_NombresApellidos As Integer = oIDataReader.GetOrdinal("NombresApellidos")
            While oIDataReader.Read()
                oEmpleado = New Empleado()
                oEmpleado.IdEmpleado = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_IdEmpleado))
                oEmpleado.NombresApellidos = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_NombresApellidos))
                oListaEmpleados.Add(oEmpleado)
            End While
        End Using
        Return oListaEmpleados
    End Function

    '////////////////////////////////////////// LISTAR USUARIOS POR EMPLEADO INACTIVOS   //////////////////////////////////////////////////////

    Function ListarUsuariosporEmpleadoInactivos(IdEmpleado As Integer) As ListaClienteVenta
        Dim oListaClienteVenta As New ListaClienteVenta
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_LISTAUSUARIOSPOREMPLEADOSACTIVOS)
        oDatabase.AddInParameter(oDbCommand, "@IDEMPLEADO", DbType.Int32, IdEmpleado)
        oDbCommand.CommandTimeout = 120000
        Dim oClienteVenta As New ClienteVenta()
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_IdCliente As Integer = oIDataReader.GetOrdinal("IdCliente")
            Dim INDICE_RazonSocial As Integer = oIDataReader.GetOrdinal("RazonSocial")
            While oIDataReader.Read()
                oClienteVenta = New ClienteVenta()
                oClienteVenta.IdCliente = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_IdCliente))
                oClienteVenta.RazonSocial = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_RazonSocial))
                oListaClienteVenta.Add(oClienteVenta)
            End While
        End Using
        Return oListaClienteVenta
    End Function

    '///////////////////////////////////////// LISTAR USUARIOS POR EMPLEADOS ACTIVOS   /////////////////////////////////////////////////////////
    Function ListarUsuariosporEmpleadosActivos(IdEmpleado As Integer) As ListaClienteVenta
        Dim oListaClienteVenta As New ListaClienteVenta
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_LISTAUSUARIOSPOREMPLEADOSACTIVOS)
        oDatabase.AddInParameter(oDbCommand, "@IDEMPLEADO", DbType.Int32, IdEmpleado)
        oDbCommand.CommandTimeout = 120000
        Dim oClienteVenta As New ClienteVenta()
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_IdCliente As Integer = oIDataReader.GetOrdinal("IdCliente")
            Dim INDICE_RazonSocial As Integer = oIDataReader.GetOrdinal("RazonSocial")
            While oIDataReader.Read()
                oClienteVenta = New ClienteVenta()
                oClienteVenta.IdCliente = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_IdCliente))
                oClienteVenta.RazonSocial = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_RazonSocial))
                oListaClienteVenta.Add(oClienteVenta)
            End While
        End Using
        Return oListaClienteVenta
    End Function
    '/////////////////////////////////////////   ASIGNAR CLIENTE A EMPLEADOS   ///////////////////////////////////////////////////////////////////
    Public Function AsignarClientesVendedor(oClienteCartera As VentaCartera) As Integer
        Dim resultado As Integer = -1
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_INS_CARTERACLIENTEVENDEDOR)
        oDatabase.AddInParameter(oDbCommand, "@IDCARTERA", DbType.Int32, oClienteCartera.IdCartera)
        oDatabase.AddInParameter(oDbCommand, "@IDCLIENTE", DbType.Int32, oClienteCartera.ClienteVenta.IdCliente)
        oDatabase.AddInParameter(oDbCommand, "@IDEMPLEADO", DbType.Int32, oClienteCartera.Empleado.IdEmpleado)
        oDatabase.AddInParameter(oDbCommand, "@IDSUCURSAL", DbType.Int32, oClienteCartera.Sucursal.IdSucursal)
        oDatabase.AddInParameter(oDbCommand, "@FECHAACTIVACION", DbType.Date, oClienteCartera.FechaActivacion)

        resultado = Integer.Parse(oDatabase.ExecuteScalar(oDbCommand))
        Return resultado
    End Function
    Public Function AsignarClientesVendedor1(oClienteCartera As VentaCartera) As Integer
        Dim resultado As Integer = -1
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_INS_CARTERACLIENTEVENDEDOR)
        oDatabase.AddInParameter(oDbCommand, "@IDCARTERA", DbType.Int32, oClienteCartera.IdCartera)
        oDatabase.AddInParameter(oDbCommand, "@IDCLIENTE", DbType.Int32, oClienteCartera.ClienteVenta.IdCliente)
        oDatabase.AddInParameter(oDbCommand, "@IDEMPLEADO", DbType.Int32, oClienteCartera.Empleado.IdEmpleado)
        oDatabase.AddInParameter(oDbCommand, "@IDSUCURSAL", DbType.Int32, oClienteCartera.Sucursal.IdSucursal)
        oDatabase.AddInParameter(oDbCommand, "@FECHAACTIVACION", DbType.Date, oClienteCartera.FechaActivacion)
        resultado = Integer.Parse(oDatabase.ExecuteScalar(oDbCommand))
        Return resultado
    End Function

    Public Function DesasignarClienteVendedor(oClienteCartera As VentaCartera) As Integer
        Dim resultado As Integer = -1
        Using oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_UPD_CARTERACLIENTEVENDEDOR)
            oDatabase.AddInParameter(oDbCommand, "@IdCliente", DbType.Int32, oClienteCartera.ClienteVenta.IdCliente)
            oDatabase.AddInParameter(oDbCommand, "@IDEMPLEADO", DbType.Int32, oClienteCartera.Empleado.IdEmpleadoAnterior)
            oDbCommand.CommandTimeout = 120000
            resultado = Integer.Parse(oDatabase.ExecuteScalar(oDbCommand))
        End Using
        Return resultado
    End Function

    '/////////////////////////////////////  VALIDA FECHA OBTENER   ///////////////////////////////////////////////////////////////////////////////
    Public Function ValidaFechaActivacion(IdCliente As Integer, IdEmpleado As Integer) As DateTime
        Dim resultado As Date = Date.Now

        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_OBTENERFECHAACTIVACION)
        oDatabase.AddInParameter(oDbCommand, "@IDCLIENTE", DbType.Int32, IdCliente)
        oDatabase.AddInParameter(oDbCommand, "@IDEMPLEADO", DbType.Int32, IdEmpleado)
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_FechaActivacion As Integer = oIDataReader.GetOrdinal("FechaActivacion")
            While oIDataReader.Read()
                resultado = DataUtil.DbValueToDefault(Of Date)(oIDataReader(INDICE_FechaActivacion))
            End While
        End Using
        Return resultado
    End Function
    '/////////////////////////////////////  VERIFICAR CARTERA   ///////////////////////////////////////////////////////////////////////////////////
    Function VerificarCartera(IdCliente As Integer) As Integer
        Dim resultado As Integer = -1
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_VERIFICARCARTERA)
        oDatabase.AddInParameter(oDbCommand, "@IDCLIENTE", DbType.Int32, IdCliente)
        resultado = oDatabase.ExecuteScalar(oDbCommand)
        Return resultado
    End Function

    Function ComboValidaMeson(IdEmpleado As Integer) As Integer
        Dim resultado As Integer = -1
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_VERIFICAREMPLEADOMESON)
        oDatabase.AddInParameter(oDbCommand, "@IDEMPLEADO", DbType.Int32, IdEmpleado)
        resultado = oDatabase.ExecuteScalar(oDbCommand)
        Return resultado
    End Function

    Function ComboValidaTipoMesonEmpleado(IdtipoCarteraEmpledo As Integer, IdEmpleado As Integer) As Integer
        Dim resultado As Integer = -1
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_VERIFICARTIPOEMPLEADOMESON)
        oDatabase.AddInParameter(oDbCommand, "@IDEMPLEADO", DbType.Int32, IdEmpleado)
        oDatabase.AddInParameter(oDbCommand, "@IDTIPOCARTERA", DbType.Int32, IdtipoCarteraEmpledo)
        resultado = oDatabase.ExecuteScalar(oDbCommand)
        Return resultado
    End Function

    Function ValidarClienteCartera(ByVal IdCliente As Integer, ByVal IdEmpleado As Integer) As Integer
        Dim resultado As Integer = 0
        Dim oDbComand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_VALIDARCARTERAPRINCIPAL)
        oDatabase.AddInParameter(oDbComand, "@IdCliente", DbType.Int32, IdCliente)
        oDatabase.AddInParameter(oDbComand, "@IdEmpleado", DbType.Int32, IdEmpleado)
        resultado = oDatabase.ExecuteScalar(oDbComand)
        Return resultado
    End Function

    Function ValidarTipoVendedorCartera(IdCliente As Integer, IdEmpleado As Integer) As Integer
        Dim resultado As Integer = 0
        Dim oDbComand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_VALIDAVENDEDORCARTERA)
        oDatabase.AddInParameter(oDbComand, "@IDCLIENTE", DbType.Int32, IdCliente)
        oDatabase.AddInParameter(oDbComand, "@IDEMPLEADO", DbType.Int32, IdEmpleado)
        resultado = oDatabase.ExecuteScalar(oDbComand)
        Return resultado
    End Function

    Function ValidarTipoEmpleadoCartera(IdTipoCartera As Integer, IdEmpleado As Integer) As Integer
        Dim resultado As Integer = 0
        Dim oDbComand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_VALIDAEMPLEADOTIPOCARTERA)
        oDatabase.AddInParameter(oDbComand, "@IDEMPLEADO", DbType.Int32, IdEmpleado)
        oDatabase.AddInParameter(oDbComand, "@IDTIPOCARTERA", DbType.Int32, IdTipoCartera)
        resultado = oDatabase.ExecuteScalar(oDbComand)
        Return resultado
    End Function

    Function CambiarEstadoCarteraCliente(IdCliente As Integer, IdCartera As Integer) As Integer
        Dim result As Integer = 0
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_DEL_ACTUALIZAESTADOCARTERA)
        oDatabase.AddInParameter(oDbCommand, "@IDCartera", DbType.Int32, IdCartera)
        oDatabase.AddInParameter(oDbCommand, "@IdCliente", DbType.Int32, IdCliente)
        result = Integer.Parse(oDatabase.ExecuteScalar(oDbCommand))
        Return result
    End Function

    Function ValidaClienteActivoCartera(IdCliente As Integer) As Integer
        Dim resultado As Integer = -1
        Dim oDbComand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_VAL_CLIENTECARTERA)
        oDatabase.AddInParameter(oDbComand, "@IdCliente", DbType.Int32, IdCliente)
        resultado = oDatabase.ExecuteScalar(oDbComand)
        Return resultado
    End Function

    '/////////////////////////////////////// LISTAR GRUPOS     //////////////////////////////////////////////////////////
    Function ListarGrupo() As ListaGrupo
        Dim oListaGrupo As New ListaGrupo()
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_LISTARGRUPO_CLIENTE)
        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_IdGrupo As Integer = oIDataReader.GetOrdinal("IdGrupo")
            Dim INDICE_NombreGrupo As Integer = oIDataReader.GetOrdinal("NombreGrupo")
            Dim oGrupoMantenimiento As New Grupo()
            While oIDataReader.Read()
                oGrupoMantenimiento = New Grupo()
                oGrupoMantenimiento.IdGrupo = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_IdGrupo))
                oGrupoMantenimiento.NombreGrupo = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_NombreGrupo))
                oListaGrupo.Add(oGrupoMantenimiento)
            End While
        End Using
        Return oListaGrupo

    End Function

    Public Function VerificarExistenciaMeson(IdCliente As Integer) As Integer
        Dim resultado As Integer = -1
        Dim oDbComand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_EXISTENCIAMESON)
        oDatabase.AddInParameter(oDbComand, "@IdCliente", DbType.Int32, IdCliente)
        resultado = oDatabase.ExecuteScalar(oDbComand)
        Return resultado
    End Function
    '////////////////////////////////////// TERMINO     ////////////////////////////////////////////////////////////////

    Function BuscarClienteXModoPago(ByVal IdModoPago As Integer, ByVal oPaginacion As Paginacion, ByVal RazonSocialRUc As String, ByVal IdMotivo As String, ByVal sRRVV As String) As Paginacion
        Dim Lista As New ListaClienteVenta()
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_CLIENTESXMODOPAGO)
        oDatabase.AddInParameter(oDbCommand, "@IdModoPago", DbType.Int32, IdModoPago)

        oDatabase.AddInParameter(oDbCommand, "@SortType", DbType.String, oPaginacion.SortType)
        oDatabase.AddInParameter(oDbCommand, "@SortDir", DbType.String, oPaginacion.SortBy)
        oDatabase.AddInParameter(oDbCommand, "@Page", DbType.Int32, oPaginacion.PageNumber)
        oDatabase.AddInParameter(oDbCommand, "@RowsPerPage", DbType.Int32, oPaginacion.PageSize)
        oDatabase.AddOutParameter(oDbCommand, "@RowCount", DbType.Int32, 0)

        oDatabase.AddInParameter(oDbCommand, "@RazonSocialRuc", DbType.String, RazonSocialRUc)
        oDatabase.AddInParameter(oDbCommand, "@IdMotivo", DbType.String, IdMotivo)
        oDatabase.AddInParameter(oDbCommand, "@sRRVV", DbType.String, sRRVV)

        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim IndIdCliente As Integer = oIDataReader.GetOrdinal("IdCliente")
            Dim IndIdClienteCategoria As Integer = oIDataReader.GetOrdinal("IdClienteCategoria")
            Dim IndIdClienteSector As Integer = oIDataReader.GetOrdinal("IdClienteSector")
            Dim IndIdClienteTipo As Integer = oIDataReader.GetOrdinal("IdClienteTipo")
            Dim IndIdModoPago As Integer = oIDataReader.GetOrdinal("IdModoPago")
            Dim IndSigicCliente As Integer = oIDataReader.GetOrdinal("SigicCliente")
            Dim IndSigicFechaRegistro As Integer = oIDataReader.GetOrdinal("SigicFechaRegistro")
            Dim IndSigicFechaActivacion As Integer = oIDataReader.GetOrdinal("SigicFechaActivacion")
            Dim IndFechaActivacion As Integer = oIDataReader.GetOrdinal("FechaActivacion")
            Dim IndRUC As Integer = oIDataReader.GetOrdinal("RUC")
            Dim IndCuenta As Integer = oIDataReader.GetOrdinal("Cuenta")
            Dim IndRazonSocial As Integer = oIDataReader.GetOrdinal("RazonSocial")
            Dim IndNombreFantasia As Integer = oIDataReader.GetOrdinal("NombreFantasia")
            Dim IndNombreCuenta As Integer = oIDataReader.GetOrdinal("NombreCuenta")
            Dim IndNombreRepresentanteLegal As Integer = oIDataReader.GetOrdinal("NombreRepresentanteLegal")
            Dim IndClasificadorExterno As Integer = oIDataReader.GetOrdinal("ClasificadorExterno")
            Dim IndCanje As Integer = oIDataReader.GetOrdinal("Canje")
            Dim IndIdSucursalResponsable As Integer = oIDataReader.GetOrdinal("IdSucursalResponsable")
            Dim IndIdEmpleadoPrincipal As Integer = oIDataReader.GetOrdinal("IdEmpleadoPrincipal")
            Dim IndIdContactoPrincipal As Integer = oIDataReader.GetOrdinal("IdContactoPrincipal")
            Dim IndIdDepartamento As Integer = oIDataReader.GetOrdinal("IdDepartamento")
            Dim IndIdProvincia As Integer = oIDataReader.GetOrdinal("IdProvincia")
            Dim IndIdDistrito As Integer = oIDataReader.GetOrdinal("IdDistrito")
            Dim IndCalle As Integer = oIDataReader.GetOrdinal("Calle")
            Dim IndTelefono As Integer = oIDataReader.GetOrdinal("Telefono")
            Dim IndFax As Integer = oIDataReader.GetOrdinal("Fax")
            Dim IndEmail As Integer = oIDataReader.GetOrdinal("Email")
            Dim IndFechaDesde As Integer = oIDataReader.GetOrdinal("FechaDesde")
            Dim IndFechaHasta As Integer = oIDataReader.GetOrdinal("FechaHasta")
            Dim IndIdEstadoActual As Integer = oIDataReader.GetOrdinal("IdEstadoActual")
            Dim IndActivo As Integer = oIDataReader.GetOrdinal("Activo")
            Dim IndFechaAniversario As Integer = oIDataReader.GetOrdinal("FechaAniversario")
            Dim IndFechaRegistro As Integer = oIDataReader.GetOrdinal("FechaRegistro")
            Dim IndUsuarioRegistro As Integer = oIDataReader.GetOrdinal("UsuarioRegistro")
            Dim IndFechaModifica As Integer = oIDataReader.GetOrdinal("FechaModifica")
            'Dim IndUsuarioModifica As Integer = oIDataReader.GetOrdinal("UsuarioModifica")
            Dim IndIdGrupo As Integer = oIDataReader.GetOrdinal("IdGrupo")
            Dim IndMotivo As Integer = oIDataReader.GetOrdinal("Motivo")
            Dim IndRepresentanteVenta As Integer = oIDataReader.GetOrdinal("RepresentanteVenta")

            oPaginacion.ListaClienteVenta = New ListaClienteVenta
            Dim obj As New ClienteVenta
            While oIDataReader.Read()
                obj = New ClienteVenta()
                obj.IdCliente = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(IndIdCliente))
                obj.IdClienteCategoria = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(IndIdClienteCategoria))
                obj.IdClienteSector = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(IndIdClienteSector))
                obj.IdClienteTipo = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(IndIdClienteTipo))
                obj.IdModoPago = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(IndIdModoPago))
                obj.SigicCliente = DataUtil.DbValueToDefault(Of Boolean)(oIDataReader(IndSigicCliente))
                obj.SigicFechaRegistro = DataUtil.DbValueToDefault(Of Date)(oIDataReader(IndSigicFechaRegistro))
                obj.SigicFechaActivacion = DataUtil.DbValueToDefault(Of Date)(oIDataReader(IndSigicFechaActivacion))
                obj.RUC = DataUtil.DbValueToDefault(Of String)(oIDataReader(IndRUC))
                obj.Cuenta = DataUtil.DbValueToDefault(Of Byte)(oIDataReader(IndCuenta))
                obj.RazonSocial = DataUtil.DbValueToDefault(Of String)(oIDataReader(IndRazonSocial))
                obj.NombreFantasia = DataUtil.DbValueToDefault(Of String)(oIDataReader(IndNombreFantasia))
                obj.NombreCuenta = DataUtil.DbValueToDefault(Of String)(oIDataReader(IndNombreCuenta))
                obj.NombreRepresentanteLegal = DataUtil.DbValueToDefault(Of String)(oIDataReader(IndNombreRepresentanteLegal))
                obj.ClasificadorExterno = DataUtil.DbValueToDefault(Of String)(oIDataReader(IndClasificadorExterno))
                obj.Canje = DataUtil.DbValueToDefault(Of String)(oIDataReader(IndCanje))
                obj.IdSucursalResponsable = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(IndIdSucursalResponsable))
                obj.IdEmpleadoPrincipal = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(IndIdEmpleadoPrincipal))
                obj.IdContactoPrincipal = DataUtil.DbValueToDefault(Of String)(oIDataReader(IndIdContactoPrincipal))
                obj.IdDepartamento = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(IndIdDepartamento))
                obj.IdProvincia = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(IndIdProvincia))
                obj.IdDistrito = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(IndIdDistrito))
                obj.Calle = DataUtil.DbValueToDefault(Of String)(oIDataReader(IndCalle))
                obj.Telefono = DataUtil.DbValueToDefault(Of String)(oIDataReader(IndTelefono))
                obj.Fax = DataUtil.DbValueToDefault(Of String)(oIDataReader(IndFax))
                obj.Email = DataUtil.DbValueToDefault(Of String)(oIDataReader(IndEmail))
                obj.FechaDesde = DataUtil.DbValueToDefault(Of Date)(oIDataReader(IndFechaDesde))
                obj.FechaHasta = DataUtil.DbValueToDefault(Of Date)(oIDataReader(IndFechaHasta))
                obj.IdEstadoActual = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(IndIdEstadoActual))
                obj.Activo = DataUtil.DbValueToDefault(Of Boolean)(oIDataReader(IndActivo))
                obj.FechaAniversario = DataUtil.DbValueToDefault(Of Date)(oIDataReader(IndFechaAniversario))
                obj.FechaRegistro = DataUtil.DbValueToDefault(Of Date)(oIDataReader(IndFechaRegistro))
                obj.UsuarioRegistro = DataUtil.DbValueToDefault(Of String)(oIDataReader(IndUsuarioRegistro))
                obj.FechaModificacion = DataUtil.DbValueToDefault(Of Date)(oIDataReader(IndFechaModifica))
                obj.IdGrupo = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(IndIdGrupo))
                obj.Motivo = DataUtil.DbValueToDefault(Of String)(oIDataReader(IndMotivo))
                obj.RepresentanteVenta = DataUtil.DbValueToDefault(Of String)(oIDataReader(IndRepresentanteVenta))

                oPaginacion.ListaClienteVenta.Add(obj)
            End While
        End Using
        oPaginacion.TotalRows = Convert.ToInt32(oDatabase.GetParameterValue(oDbCommand, "@RowCount"))
        Return oPaginacion
    End Function



    Function BuscarClienteXModoPago_C_Autorizacion(ByVal IdModoPago As Integer, ByVal oPaginacion As Paginacion, ByVal RazonSocialRUc As String, ByVal IdMotivo As String, ByVal sRRVV_NombreEmpleado As String) As Paginacion
        Dim Lista As New ListaClienteVenta()
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_CLIENTESXMODOPAGO_CONSULTAAUTORIZACION)
        oDatabase.AddInParameter(oDbCommand, "@IdModoPago", DbType.Int32, IdModoPago)

        oDatabase.AddInParameter(oDbCommand, "@SortType", DbType.String, oPaginacion.SortType)
        oDatabase.AddInParameter(oDbCommand, "@SortDir", DbType.String, oPaginacion.SortBy)
        oDatabase.AddInParameter(oDbCommand, "@Page", DbType.Int32, oPaginacion.PageNumber)
        oDatabase.AddInParameter(oDbCommand, "@RowsPerPage", DbType.Int32, oPaginacion.PageSize)
        oDatabase.AddOutParameter(oDbCommand, "@RowCount", DbType.Int32, 0)

        oDatabase.AddInParameter(oDbCommand, "@RazonSocialRuc", DbType.String, RazonSocialRUc)
        oDatabase.AddInParameter(oDbCommand, "@IdMotivo", DbType.String, IdMotivo)
        oDatabase.AddInParameter(oDbCommand, "@RRVV", DbType.String, sRRVV_NombreEmpleado)


        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            'Dim IndIdModoPago As Integer = oIDataReader.GetOrdinal("IdModoPago")

            'Dim IndFechaActivacion As Integer = oIDataReader.GetOrdinal("FechaActivacion")
            Dim IndRUC As Integer = oIDataReader.GetOrdinal("RUC")
            Dim IndFechaRegistro As Integer = oIDataReader.GetOrdinal("FechaRegistro")
            Dim IndRazonSocial As Integer = oIDataReader.GetOrdinal("RazonSocial")
            ' Dim IndNombreFantasia As Integer = oIDataReader.GetOrdinal("NombreFantasia")
            ' Dim IndNombreCuenta As Integer = oIDataReader.GetOrdinal("NombreCuenta")
            'Dim IndNombreRepresentanteLegal As Integer = oIDataReader.GetOrdinal("NombreRepresentanteLegal")
            ' Dim IndClasificadorExterno As Integer = oIDataReader.GetOrdinal("ClasificadorExterno")
            'Dim IndCanje As Integer = oIDataReader.GetOrdinal("Canje")
            ' Dim IndIdSucursalResponsable As Integer = oIDataReader.GetOrdinal("IdSucursalResponsable")

            'Dim IndFechaDesde As Integer = oIDataReader.GetOrdinal("FechaDesde")
            ' Dim IndFechaHasta As Integer = oIDataReader.GetOrdinal("FechaHasta")
            '  Dim IndIdEstadoActual As Integer = oIDataReader.GetOrdinal("IdEstadoActual")

            Dim IndMotivo As Integer = oIDataReader.GetOrdinal("Motivo")
            Dim IndModoPago As Integer = oIDataReader.GetOrdinal("MododePago")
            Dim IndIdAprobado As Integer = oIDataReader.GetOrdinal("IdAprobar")
            Dim IndRepresentanteVenta As Integer = oIDataReader.GetOrdinal("RepresentanteVenta")
            Dim IndAnotacion As Integer = oIDataReader.GetOrdinal("Anotacion")

            oPaginacion.ListaClienteVenta = New ListaClienteVenta
            Dim obj As New ClienteVenta
            While oIDataReader.Read()
                obj = New ClienteVenta()


                '  obj.IdModoPago = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(IndIdModoPago))

                obj.RUC = DataUtil.DbValueToDefault(Of String)(oIDataReader(IndRUC))
                ' obj.Cuenta = DataUtil.DbValueToDefault(Of Byte)(oIDataReader(IndCuenta))
                obj.RazonSocial = DataUtil.DbValueToDefault(Of String)(oIDataReader(IndRazonSocial))
                'obj.NombreFantasia = DataUtil.DbValueToDefault(Of String)(oIDataReader(IndNombreFantasia))
                'obj.NombreCuenta = DataUtil.DbValueToDefault(Of String)(oIDataReader(IndNombreCuenta))
                ' obj.NombreRepresentanteLegal = DataUtil.DbValueToDefault(Of String)(oIDataReader(IndNombreRepresentanteLegal))
                ' obj.ClasificadorExterno = DataUtil.DbValueToDefault(Of String)(oIDataReader(IndClasificadorExterno))
                'obj.Canje = DataUtil.DbValueToDefault(Of String)(oIDataReader(IndCanje))
                'obj.IdSucursalResponsable = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(IndIdSucursalResponsable))

                'obj.FechaDesde = DataUtil.DbValueToDefault(Of Date)(oIDataReader(IndFechaDesde))
                ' obj.FechaHasta = DataUtil.DbValueToDefault(Of Date)(oIDataReader(IndFechaHasta))
                'obj.IdEstadoActual = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(IndIdEstadoActual))

                obj.Motivo = DataUtil.DbValueToDefault(Of String)(oIDataReader(IndMotivo))
                obj.ModoPagoDes = DataUtil.DbValueToDefault(Of String)(oIDataReader(IndModoPago))
                obj.IdAprobado = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(IndIdAprobado))
                obj.RepresentanteVenta = DataUtil.DbValueToDefault(Of String)(oIDataReader(IndRepresentanteVenta))
                obj.RepresentanteVenta = DataUtil.DbValueToDefault(Of String)(oIDataReader(IndRepresentanteVenta))
                obj.Anotacion = DataUtil.DbValueToDefault(Of String)(oIDataReader(IndAnotacion))
                obj.FechaRegistro = DataUtil.DbValueToDefault(Of Date)(oIDataReader(IndFechaRegistro))

                oPaginacion.ListaClienteVenta.Add(obj)
            End While
        End Using
        oPaginacion.TotalRows = Convert.ToInt32(oDatabase.GetParameterValue(oDbCommand, "@RowCount"))
        Return oPaginacion
    End Function



    Public Function ActivarCliente(ByVal A As Autorizaciones) As Integer
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_ACTIVARCLIENTE)
        oDatabase.AddInParameter(oDbCommand, "@RUC", DbType.String, A.RUC)
        oDatabase.AddInParameter(oDbCommand, "@IdModoPago", DbType.Int32, A.IdModoPago)
        oDatabase.AddInParameter(oDbCommand, "@Anotacion", DbType.String, A.Anotacion)
        oDatabase.AddInParameter(oDbCommand, "@Motivo", DbType.String, A.Motivo)

        Return oDatabase.ExecuteScalar(oDbCommand)
    End Function

    Function ListarVendedorPrincipal() As ListaEmpleado
        Dim oListaEmpleado As New ListaEmpleado()
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_REPORTE_CLIENTE_FILTROVENDEDORPRINCIPAL)
        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim indiceidemp As Integer = oIDataReader.GetOrdinal("IdEmpleado")
            Dim indicenombres As Integer = oIDataReader.GetOrdinal("NombresApellidos")
            Dim oEmpleado As Empleado
            While oIDataReader.Read()
                oEmpleado = New Empleado()
                oEmpleado.IdEmpleado = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indiceidemp))
                oEmpleado.NombresApellidos = DataUtil.DbValueToDefault(Of String)(oIDataReader(indicenombres))
                oListaEmpleado.Add(oEmpleado)
            End While
        End Using
        Return oListaEmpleado
    End Function

    Function ListaCliente_Grilla(oPaginacion As Paginacion) As Paginacion
        oPaginacion.ListaClienteVenta = New ListaClienteVenta()
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_BUSCACLIENTE)

        oDatabase.AddInParameter(oDbCommand, "@RazonSocial", DbType.String, oPaginacion.ClienteVenta.RazonSocial)
        oDatabase.AddInParameter(oDbCommand, "@IdModoPago", DbType.Int32, oPaginacion.ClienteVenta.IdModoPago)
        oDatabase.AddInParameter(oDbCommand, "@IdEstado", DbType.Int32, oPaginacion.ClienteVenta.ProcesoEstado.IdEstado)
        oDatabase.AddInParameter(oDbCommand, "@IdDepartamento", DbType.Int32, oPaginacion.ClienteVenta.EmpleadoDepartamento.IdDepartamento)
        oDatabase.AddInParameter(oDbCommand, "@IdProvincia", DbType.Int32, oPaginacion.ClienteVenta.EmpleadoProvincia.IdProvincia)
        oDatabase.AddInParameter(oDbCommand, "@IdSector", DbType.Int32, oPaginacion.ClienteVenta.ClienteSector.IdClienteSector)
        oDatabase.AddInParameter(oDbCommand, "@IdCategoria", DbType.Int32, oPaginacion.ClienteVenta.ClienteCategoria.IdClienteCategoria)
        oDatabase.AddInParameter(oDbCommand, "@IdClienteTipo", DbType.Int32, oPaginacion.ClienteVenta.ClienteTipo.IdClienteTipo)
        oDatabase.AddInParameter(oDbCommand, "@PageSize", DbType.Int32, oPaginacion.PageSize)
        oDatabase.AddInParameter(oDbCommand, "@PageNumber", DbType.Int32, oPaginacion.PageNumber)
        oDatabase.AddInParameter(oDbCommand, "@SortBy", DbType.String, oPaginacion.SortBy)
        oDatabase.AddInParameter(oDbCommand, "@SortType", DbType.String, oPaginacion.SortType)
        oDatabase.AddOutParameter(oDbCommand, "@TotalRows", DbType.Int32, 10)
        oDbCommand.CommandTimeout = 120000

        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)

            Dim INDICE_RUC As Integer = oIDataReader.GetOrdinal("RUC")
            Dim INDICE_RazonSocial As Integer = oIDataReader.GetOrdinal("RazonSocial")
            Dim INDICE_NombresApellidos As Integer = oIDataReader.GetOrdinal("NombresApellidos")
            Dim INDICE_Region As Integer = oIDataReader.GetOrdinal("Region")
            Dim INDICE_Provincia As Integer = oIDataReader.GetOrdinal("Provincia")
            Dim INDICE_Sector As Integer = oIDataReader.GetOrdinal("Sector")
            Dim INDICE_Categoria As Integer = oIDataReader.GetOrdinal("Categoria")
            Dim INDICE_Tipo As Integer = oIDataReader.GetOrdinal("Tipo")
            Dim INDICE_Telefono As Integer = oIDataReader.GetOrdinal("Telefono")
            Dim INDICE_Estado As Integer = oIDataReader.GetOrdinal("Estado")
            Dim INDICE_IdCliente As Integer = oIDataReader.GetOrdinal("IdCliente")
            Dim INDICE_ModoPago As Integer = oIDataReader.GetOrdinal("ModoPago")
            Dim INDICE_EstadoCliente As Integer = oIDataReader.GetOrdinal("EstadoCliente")
            Dim INDICE_ACTIVO As Integer = oIDataReader.GetOrdinal("ACTIVO")
            Dim INDICE_FechaModifica As Integer = oIDataReader.GetOrdinal("FechaModifica")
            Dim INDICE_FechaRango As Integer = oIDataReader.GetOrdinal("FechaRango")
            Dim INDICE_IdModoPago As Integer = oIDataReader.GetOrdinal("IdModoPago")

            While oIDataReader.Read()

                oPaginacion.ClienteVenta = New ClienteVenta()

                oPaginacion.ClienteVenta.IdCliente = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_IdCliente))
                oPaginacion.ClienteVenta.RUC = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_RUC))
                oPaginacion.ClienteVenta.RazonSocial = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_RazonSocial))
                oPaginacion.ClienteVenta.NombresApellidos = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_NombresApellidos))
                oPaginacion.ClienteVenta.Telefono = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_Telefono))
                oPaginacion.ClienteVenta.DescripcionModoPago = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_ModoPago))
                oPaginacion.ClienteVenta.FechaModificacion = DataUtil.DbValueToDefault(Of Date)(oIDataReader(INDICE_FechaModifica))
                oPaginacion.ClienteVenta.FechaRango = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_FechaRango))
                'oPaginacion.ClienteVenta.FechaResultado = fechaActual.Day - oPaginacion.ClienteVenta.FechaModificacion.Day
                oPaginacion.ClienteVenta.ProcesoEstado = New ProcesoEstado()
                oPaginacion.ClienteVenta.ProcesoEstado.Codigo = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_Estado))
                oPaginacion.ClienteVenta.ProcesoEstado.IdEstado = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_EstadoCliente))
                oPaginacion.ClienteVenta.EmpleadoDepartamento = New EmpleadoDepartamento()
                oPaginacion.ClienteVenta.EmpleadoDepartamento.DescripcionDepa = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_Region))
                oPaginacion.ClienteVenta.EmpleadoProvincia = New EmpleadoProvincia()
                oPaginacion.ClienteVenta.EmpleadoProvincia.DescripcionProv = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_Provincia))
                oPaginacion.ClienteVenta.ClienteSector = New ClienteSector()
                oPaginacion.ClienteVenta.ClienteSector.Descripcion = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_Sector))
                oPaginacion.ClienteVenta.ClienteCategoria = New ClienteCategoria()
                oPaginacion.ClienteVenta.ClienteCategoria.Descripcion = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_Categoria))
                oPaginacion.ClienteVenta.ClienteTipo = New ClienteTipo()
                oPaginacion.ClienteVenta.ClienteTipo.Descripcion = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_Tipo))
                oPaginacion.ClienteVenta.Activo = DataUtil.DbValueToDefault(Of Boolean)(oIDataReader(INDICE_ACTIVO))
                oPaginacion.ClienteVenta.ClienteModoPagoCombo = New ClienteModoPagoCombo()
                oPaginacion.ClienteVenta.ClienteModoPagoCombo.IdModoPago = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_IdModoPago))

                oPaginacion.ListaClienteVenta.Add(oPaginacion.ClienteVenta)
            End While
        End Using

        oPaginacion.TotalRows = Convert.ToInt32(oDatabase.GetParameterValue(oDbCommand, "@TotalRows"))

        Return oPaginacion
    End Function

    Public Function ListarVendedores_Autocomplete(ByVal NombreRRVV As String, ByVal IdCliente As Integer) As ListaEmpleado
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_AUTOCOMPLETERRVV)
        oDatabase.AddInParameter(oDbCommand, "@NombreRRVV", DbType.String, NombreRRVV)
        oDatabase.AddInParameter(oDbCommand, "@IdCliente", DbType.Int32, IdCliente)
        Dim oListaEmpleado As New ListaEmpleado()
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_IDEMPLEADO As Integer = oIDataReader.GetOrdinal("IdEmpleado")
            Dim INDICE_NOMBRESAPELLIDOS As Integer = oIDataReader.GetOrdinal("NombresApellidos")
            Dim INDICE_FECHAINGRESO As Integer = oIDataReader.GetOrdinal("FechaIngreso")
            While oIDataReader.Read()
                Dim oEmpleado As New Empleado()
                oEmpleado.IdEmpleado = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(INDICE_IDEMPLEADO))
                oEmpleado.NombresApellidos = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_NOMBRESAPELLIDOS))
                oEmpleado.FechaSucursalUltimo = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_FECHAINGRESO))
                oListaEmpleado.Add(oEmpleado)
            End While
        End Using
        Return oListaEmpleado
    End Function

    Public Function CrearCarteraSecundariaClientes(ByVal oVentaCartera As VentaCartera, ByVal oPaginacion As Paginacion) As Int32
        Dim result As Integer = -1
        Try
            Dim oSqlDatabase As SqlDatabase = DirectCast(DatabaseFactory.CreateDatabase(Conexion.cnsSql), SqlDatabase)
            Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_INS_CARTERA)

            oSqlDatabase.AddInParameter(oDbCommand, "@IdCliente", SqlDbType.Int, oVentaCartera.IdCliente)
            oSqlDatabase.AddInParameter(oDbCommand, "@IdEmpleado", SqlDbType.Int, oVentaCartera.IdEmpleado)
            oSqlDatabase.AddInParameter(oDbCommand, "@TCompartida", SqlDbType.Int, oVentaCartera.TCompartida)
            oSqlDatabase.AddInParameter(oDbCommand, "@UsuarioLogin", SqlDbType.VarChar, oVentaCartera.Usuario)
            oSqlDatabase.AddInParameter(oDbCommand, "@TCartera", SqlDbType.Structured, MapearListaVenta(oPaginacion.ListaSucursal))
            result = CInt(oDatabase.ExecuteScalar(oDbCommand))
            Return result
        Catch ex As Exception
            Return -1
        End Try
    End Function

    Private Function MapearListaVenta(ByVal oListaSucursal As ListaSucursal) As IEnumerable(Of SqlDataRecord)
        Dim ListaRegistro As New List(Of SqlDataRecord)
        Try
            For Each item In oListaSucursal
                Dim Registro As New SqlDataRecord(New SqlMetaData() {
                                New SqlMetaData("IdCarteraEmpleadoTipo", SqlDbType.Int) _
                              , New SqlMetaData("IdSucursal", SqlDbType.Int) _
                              , New SqlMetaData("FechaActivacion", SqlDbType.Date) _
                              , New SqlMetaData("FechaDesde", SqlDbType.DateTime) _
                              , New SqlMetaData("FechaHasta", SqlDbType.DateTime) _
                              , New SqlMetaData("IdEstadoActual", SqlDbType.Int) _
                              , New SqlMetaData("Activo", SqlDbType.Bit) _
                              , New SqlMetaData("Porcentaje", SqlDbType.Decimal, 18, 2) _
                              , New SqlMetaData("FechaDesignacion", SqlDbType.DateTime)})

                Registro.SetInt32(0, 2)
                Registro.SetInt32(1, item.IdSucursal)
                Registro.SetDateTime(2, item.FechaAsignacion)
                Registro.SetDateTime(3, item.FechaAsignacion)
                Registro.SetDateTime(4, Date.Now)
                Registro.SetInt32(5, 26)
                Registro.SetBoolean(6, True)
                Registro.SetDecimal(7, item.Porcentaje)
                If IsNothing(item.FechaDesasignacion) Then
                    Registro.SetDBNull(8)
                Else
                    Registro.SetDateTime(8, item.FechaDesasignacion)
                End If

                ListaRegistro.Add(Registro)
            Next
        Catch ex As Exception
            Throw ex
        End Try

        Return ListaRegistro
    End Function

    Function ListaSucursalesDisponibles(IdCliente As Integer, IdEmpleado As Integer) As ListaSucursal
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_SUCURSALESDISPONIBLES)
        oDatabase.AddInParameter(oDbCommand, "@IdCliente", DbType.Int32, IdCliente)
        oDatabase.AddInParameter(oDbCommand, "@IdEmpleado", DbType.Int32, IdEmpleado)
        oDbCommand.CommandTimeout = 120000
        Dim oListaSucursal As New ListaSucursal()
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim idsucursal As Integer = oIDataReader.GetOrdinal("IdSucursal")
            Dim descripcion As Integer = oIDataReader.GetOrdinal("Descripcion")
            Dim codigosucursal As Integer = oIDataReader.GetOrdinal("CodigoSucursal")
            While oIDataReader.Read()
                Dim oSucursal As New Sucursal()
                oSucursal.IdSucursal = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(idsucursal))
                oSucursal.DescripcionSucursal = DataUtil.DbValueToDefault(Of String)(oIDataReader(descripcion))
                oSucursal.CodigoSucursal = DataUtil.DbValueToDefault(Of String)(oIDataReader(codigosucursal))
                oListaSucursal.Add(oSucursal)
            End While
        End Using
        Return oListaSucursal
    End Function


    Function ListarMotivos() As ListaMotivo
        Dim oListaMotivo As New ListaMotivo()
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_MOTIVO_CLIENTE)
        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim indiceIdMotivo As Integer = oIDataReader.GetOrdinal("IdMotivo")
            Dim indiceDescripcion As Integer = oIDataReader.GetOrdinal("Descripcion")
            Dim oMotivo As Motivo
            While oIDataReader.Read()
                oMotivo = New Motivo()
                oMotivo.IdMotivo = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indiceIdMotivo))
                oMotivo.Descripcion = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceDescripcion))
                oListaMotivo.Add(oMotivo)
            End While
        End Using
        Return oListaMotivo
    End Function



    Function ListaModoPago() As ListaModoPago
        Dim oListaModoPago As New ListaModoPago()
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_MODOPAGO)
        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim indiceIdModoPago As Integer = oIDataReader.GetOrdinal("IdModoPago")
            Dim indiceDescripcion As Integer = oIDataReader.GetOrdinal("Descripcion")
            Dim oModoPago As ModoPago
            While oIDataReader.Read()
                oModoPago = New ModoPago()
                oModoPago.IdModoPago = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indiceIdModoPago))
                oModoPago.Descripcion = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceDescripcion))
                oListaModoPago.Add(oModoPago)
            End While
        End Using
        Return oListaModoPago
    End Function


    Public Function InsertarCliente_HA(ByVal oClienteVenta As ClienteVenta) As Int32
        Dim resultado As Int32
        resultado = oDatabase.ExecuteScalar(Procedimientos.USP_INSERTAR_CLIENTE_HA,
                                                        oClienteVenta.RUC,
                                                        oClienteVenta.RazonSocial,
                                                        "",
                                                        oClienteVenta.Motivo,
                                                        oClienteVenta.ModoPagoDes,
                                                        oClienteVenta.Anotacion,
                                                        Integer.Parse(oClienteVenta.IdAprobado))
        Return resultado
    End Function

    Function Obtener_IdPerfilActualEmpleado(UsuarioUsu As String) As Integer
        Dim IdPerfilActual As Integer
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_IDEMPLEADOPERFILACTUAL, UsuarioUsu)
        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim indiceIdEmpleadoPerfilActual As Integer = oIDataReader.GetOrdinal("IdEmpleadoPerfilActual")

            Dim oEmpleado As Empleado
            While oIDataReader.Read()
                oEmpleado = New Empleado()
                oEmpleado.IdEmpleadoPerfilActual = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indiceIdEmpleadoPerfilActual))

                IdPerfilActual = oEmpleado.IdEmpleadoPerfilActual
            End While
        End Using
        Return IdPerfilActual
    End Function

    Function ListaTipoDocumentoCliente() As ListaTipoDocumento
        Dim oListaTipoDocumentoCliente As New ListaTipoDocumento()
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_TIPODOCUMENTOCLIENTE)
        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim oTipoDocumentoCliente As New TipoDocumento
            Dim indiceIdTipoDocumentoCliente As Integer = oIDataReader.GetOrdinal("IdTipoDocumentoCliente")
            Dim indiceDescripcion As Integer = oIDataReader.GetOrdinal("Descripcion")
            Dim indiceDescripcionCorta As Integer = oIDataReader.GetOrdinal("DescripcionCorta")
            Dim indiceEstado As Integer = oIDataReader.GetOrdinal("Activo")
            While oIDataReader.Read()
                oTipoDocumentoCliente = New TipoDocumento()
                oTipoDocumentoCliente.IdTipoDocumento = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(indiceIdTipoDocumentoCliente))
                oTipoDocumentoCliente.Descripcion = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceDescripcion))
                oTipoDocumentoCliente.DescripcionCorta = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceDescripcionCorta))
                oTipoDocumentoCliente.Estado = DataUtil.DbValueToDefault(Of Boolean)(oIDataReader(indiceEstado))
                oListaTipoDocumentoCliente.Add(oTipoDocumentoCliente)
            End While
        End Using
        Return oListaTipoDocumentoCliente
    End Function
End Class
