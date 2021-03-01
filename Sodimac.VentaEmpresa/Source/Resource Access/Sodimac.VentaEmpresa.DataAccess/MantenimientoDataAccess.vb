Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Common
Imports System.Linq
Imports System.Text
Imports Sodimac.VentaEmpresa.BusinessEntities
Imports Sodimac.VentaEmpresa.DataContracts
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common.Configuration
Imports System.Data.SqlClient
Imports Microsoft.SqlServer.Server
Imports System.Configuration
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql

Public Class MantenimientoDataAccess

    Private oDatabase As Database = EnterpriseLibraryContainer.Current.GetInstance(Of Database)(Conexion.cnsSql)


    Function ListarReporteCarteraClientes(ByVal RUC As String, ByVal CodigoSucursal As String, ByVal Anio As String, ByVal Mes As String) As ListaClienteCartera
        Dim oListaClienteCartera As New ListaClienteCartera()

        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_LISTARREPORTECARTERACLIENTE)
        oDatabase.AddInParameter(oDbCommand, "@RUC", DbType.String, RUC)
        oDatabase.AddInParameter(oDbCommand, "@CodigoSucursal", DbType.String, CodigoSucursal)
        oDatabase.AddInParameter(oDbCommand, "@Anio", DbType.String, Anio)
        oDatabase.AddInParameter(oDbCommand, "@Mes", DbType.String, Mes)
        oDbCommand.CommandTimeout = 120000

        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_RUC As Integer = oIDataReader.GetOrdinal("RUC")
            Dim INDICE_RazonSocial As Integer = oIDataReader.GetOrdinal("RazonSocial")
            Dim INDICE_CodigoSucursal As Integer = oIDataReader.GetOrdinal("CodigoSucursal")
            Dim INDICE_Sucursal As Integer = oIDataReader.GetOrdinal("Descripcion")
            Dim INDICE_CodigoOfisis As Integer = oIDataReader.GetOrdinal("CodigoOfisis")
            Dim INDICE_FechaInicio As Integer = oIDataReader.GetOrdinal("FechaInicio")
            Dim INDICE_FechaFin As Integer = oIDataReader.GetOrdinal("FechaFin")
            Dim INDICE_Mes As Integer = oIDataReader.GetOrdinal("Mes")
            Dim INDICE_Anio As Integer = oIDataReader.GetOrdinal("Anio")
            Dim INDICE_FechaRegistro As Integer = oIDataReader.GetOrdinal("FechaRegistro")

            While oIDataReader.Read()
                Dim oClienteCartera = New ClienteCartera

                oClienteCartera.RUC = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_RUC))
                oClienteCartera.RazonSocial = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_RazonSocial))
                oClienteCartera.CodigoSucursal = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_CodigoSucursal))
                oClienteCartera.Sucursal = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_Sucursal))
                oClienteCartera.CodigoOfisis = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_CodigoOfisis))
                oClienteCartera.Fechainicio = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_FechaInicio))
                oClienteCartera.FechaFin = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_FechaFin))
                oClienteCartera.Mes = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_Mes))
                oClienteCartera.Anio = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_Anio))
                oClienteCartera.FechaRegistro = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_FechaRegistro))

                oListaClienteCartera.Add(oClienteCartera)
            End While
        End Using
        Return oListaClienteCartera
    End Function


    Public Function ListarCarteraCliente(ByRef oPaginacion As Paginacion) As Paginacion
        oPaginacion.ListaClienteCartera = New ListaClienteCartera()
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_BUSCACARTERACLIENTE)

        oDatabase.AddInParameter(oDbCommand, "@RUC", DbType.String, oPaginacion.ClienteCartera.RUC)
        oDatabase.AddInParameter(oDbCommand, "@CodigoSucursal", DbType.String, oPaginacion.ClienteCartera.CodigoSucursal)
        oDatabase.AddInParameter(oDbCommand, "@Anio", DbType.String, oPaginacion.ClienteCartera.Anio)
        oDatabase.AddInParameter(oDbCommand, "@Mes", DbType.String, oPaginacion.ClienteCartera.Mes)
        oDatabase.AddInParameter(oDbCommand, "@PageSize", DbType.Int32, oPaginacion.PageSize)
        oDatabase.AddInParameter(oDbCommand, "@PageNumber", DbType.Int32, oPaginacion.PageNumber)
        oDatabase.AddInParameter(oDbCommand, "@SortBy", DbType.String, oPaginacion.SortBy)
        oDatabase.AddInParameter(oDbCommand, "@SortType", DbType.String, oPaginacion.SortType)
        oDatabase.AddOutParameter(oDbCommand, "@TotalRows", DbType.Int32, 10)
        oDbCommand.CommandTimeout = 120000

        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)

            Dim INDICE_RUC As Integer = oIDataReader.GetOrdinal("RUC")
            Dim INDICE_CodigoSucursal As Integer = oIDataReader.GetOrdinal("Descripcion")
            Dim INDICE_Anio As Integer = oIDataReader.GetOrdinal("Anio")
            Dim INDICE_Mes As Integer = oIDataReader.GetOrdinal("Mes")
            Dim INDICE_RazonSocial As Integer = oIDataReader.GetOrdinal("RazonSocial")
            Dim INDICE_Sucursal As Integer = oIDataReader.GetOrdinal("CodigoSucursal")
            Dim INDICE_CodigoOfisis As Integer = oIDataReader.GetOrdinal("CodigoOfisis")
            Dim INDICE_FechaInicio As Integer = oIDataReader.GetOrdinal("FechaInicio")
            Dim INDICE_FechaFin As Integer = oIDataReader.GetOrdinal("FechaFin")
            Dim INDICE_FechaRegistro As Integer = oIDataReader.GetOrdinal("FechaRegistro")

            While oIDataReader.Read()
                oPaginacion.ClienteCartera = New ClienteCartera()
                oPaginacion.ClienteCartera.RUC = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_RUC))
                oPaginacion.ClienteCartera.CodigoSucursal = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_CodigoSucursal))
                oPaginacion.ClienteCartera.CodigoOfisis = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_CodigoOfisis))
                oPaginacion.ClienteCartera.Fechainicio = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_FechaInicio))
                oPaginacion.ClienteCartera.FechaFin = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_FechaFin))
                oPaginacion.ClienteCartera.Anio = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_Anio))
                oPaginacion.ClienteCartera.Mes = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_Mes))
                oPaginacion.ClienteCartera.RazonSocial = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_RazonSocial))
                oPaginacion.ClienteCartera.Sucursal = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_Sucursal))
                oPaginacion.ClienteCartera.FechaRegistro = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_FechaRegistro))

                oPaginacion.ListaClienteCartera.Add(oPaginacion.ClienteCartera)
            End While
        End Using
        oPaginacion.TotalRows = Convert.ToInt32(oDatabase.GetParameterValue(oDbCommand, "@TotalRows"))
        Return oPaginacion
    End Function

    Public Function ListarPerfiles(ByRef oPaginacion As Paginacion) As Paginacion
        oPaginacion.ListaPerfil = New ListaPerfil()
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_BUSCAPERFILES)

        oDatabase.AddInParameter(oDbCommand, "@NombrePerfil", DbType.String, oPaginacion.Perfil.NombrePerfil)
        oDatabase.AddInParameter(oDbCommand, "@PageSize", DbType.Int32, oPaginacion.PageSize)
        oDatabase.AddInParameter(oDbCommand, "@PageNumber", DbType.Int32, oPaginacion.PageNumber)
        oDatabase.AddInParameter(oDbCommand, "@SortBy", DbType.String, oPaginacion.SortBy)
        oDatabase.AddInParameter(oDbCommand, "@SortType", DbType.String, oPaginacion.SortType)
        oDatabase.AddOutParameter(oDbCommand, "@TotalRows", DbType.Int32, 10)
        oDbCommand.CommandTimeout = 120000

        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)

            Dim INDICE_IdPerfil As Integer = oIDataReader.GetOrdinal("IdPerfil")
            Dim INDICE_IdPerfilSuperior As Integer = oIDataReader.GetOrdinal("IdPerfilSuperior")
            Dim INDICE_NombrePerfil As Integer = oIDataReader.GetOrdinal("NombrePerfil")
            Dim INDICE_NombrePerfilSuperior As Integer = oIDataReader.GetOrdinal("NombrePerfilSuperior")
            Dim INDICE_TipoPerfil As Integer = oIDataReader.GetOrdinal("TipoPerfil")
            Dim INDICE_NombreTipo As Integer = oIDataReader.GetOrdinal("Descripcion")
            Dim INDICE_NombrePerfilInferior As Integer = oIDataReader.GetOrdinal("NombrePerfilInferior")

            While oIDataReader.Read()
                oPaginacion.Perfil = New Perfil()
                oPaginacion.Perfil.IdPerfil = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_IdPerfil))
                oPaginacion.Perfil.IdPerfilSuperior = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_IdPerfilSuperior))
                oPaginacion.Perfil.NombrePerfil = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_NombrePerfil))
                oPaginacion.Perfil.NombrePerfilSuperior = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_NombrePerfilSuperior))
                oPaginacion.Perfil.TipoPerfil = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_TipoPerfil))
                oPaginacion.Perfil.NombrePerfilInferior = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_NombrePerfilInferior))

                'oPaginacion.Perfil.EmpleadoPerfil.DescripcionPerfil = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_NombreTipo))

                oPaginacion.ListaPerfil.Add(oPaginacion.Perfil)
            End While
        End Using
        oPaginacion.TotalRows = Convert.ToInt32(oDatabase.GetParameterValue(oDbCommand, "@TotalRows"))
        Return oPaginacion
    End Function

    Public Function RegistraClienteCartera(lstClienteCartera As List(Of ClienteCartera), log As Log) As Integer
        'Dim listaClienteCarteraExiste = ListaCliente()
        Dim mapeoListaCliente As New List(Of SqlDataRecord)
        If (Not lstClienteCartera Is Nothing) Then
            'mapeoListaCliente = CrearSqlDataRecordsCliente(lstClienteCartera, listaClienteExiste, log.Usuario)
            mapeoListaCliente = CrearSqlDataRecordsCliente(lstClienteCartera, log.Usuario)
        End If
        Dim resultado As Integer = 0
        Try
            Dim oSqlDatabase As SqlDatabase = DirectCast(DatabaseFactory.CreateDatabase(Conexion.cnsSql), SqlDatabase)
            Dim oDbComand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.SP_REGISTRAR_CLIENTE_CARTERA)
            If (Not lstClienteCartera Is Nothing) Then
                oSqlDatabase.AddInParameter(oDbComand, "@DT_EMPRESA_CLIENTE", SqlDbType.Structured, mapeoListaCliente)
            End If
            resultado = CInt(oDatabase.ExecuteScalar(oDbComand))
        Catch ex As Exception
            resultado = -1
        End Try
        Return resultado
    End Function

    Private Function CrearSqlDataRecordsCliente(lista As List(Of ClienteCartera), usuario As String) As IEnumerable(Of SqlDataRecord)
        Dim ListaRegistro As New List(Of SqlDataRecord)
        'Dim lstClienteContacto = ListaClienteContacto()
        Try
            For Each item As ClienteCartera In lista
                Dim sqlDataRecord = New SqlDataRecord(
                    New SqlMetaData("RUC", SqlDbType.VarChar, 12),
                    New SqlMetaData("CodigoSucursal", SqlDbType.VarChar, 4),
                    New SqlMetaData("Anio", SqlDbType.VarChar, 4),
                    New SqlMetaData("Mes", SqlDbType.VarChar, 15),
                    New SqlMetaData("FechaRegistro", SqlDbType.DateTime),
                    New SqlMetaData("UsuarioRegistro", SqlDbType.VarChar, 50),
                    New SqlMetaData("FechaModifica", SqlDbType.DateTime),
                    New SqlMetaData("UsuarioModifica", SqlDbType.VarChar, 50))


                sqlDataRecord.SetString(0, item.RUC)
                sqlDataRecord.SetString(1, item.CodigoSucursal)
                sqlDataRecord.SetString(2, item.Anio)
                sqlDataRecord.SetString(3, item.Mes)
                sqlDataRecord.SetDateTime(4, System.DateTime.Now)
                sqlDataRecord.SetString(5, usuario)
                sqlDataRecord.SetDateTime(6, System.DateTime.Now)
                sqlDataRecord.SetString(7, usuario)

                ListaRegistro.Add(sqlDataRecord)
            Next
        Catch ex As Exception
            Throw ex
        End Try

        Return ListaRegistro
    End Function


    Function ListarPerfil_Combo() As ListaPerfil
        Dim oListaPerfil As New ListaPerfil()
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_PERFILCBO)
        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_IdPerfil As Integer = oIDataReader.GetOrdinal("IdPerfil")
            Dim INDICE_NombrePerfil As Integer = oIDataReader.GetOrdinal("NombrePerfil")
            While oIDataReader.Read()
                Dim oPerfil = New Perfil()
                oPerfil.IdPerfil = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_IdPerfil))
                oPerfil.NombrePerfil = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_NombrePerfil))
                oListaPerfil.Add(oPerfil)
            End While
        End Using
        Return oListaPerfil
    End Function

    Function ListarEmpleadoPerfil_Combo() As ListaEmpleadoPerfil
        Dim oListaEmpleadoPerfil As New ListaEmpleadoPerfil()
        Dim oDbComand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_EMPLEADOPERFIL)
        oDbComand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbComand)
            Dim vi_idperfil As Integer = oIDataReader.GetOrdinal("IdPerfil")
            Dim vi_descperfil As Integer = oIDataReader.GetOrdinal("Descripcion")
            While oIDataReader.Read()
                Dim oEmpleadoPerfil = New EmpleadoPerfil()
                oEmpleadoPerfil.IdPerfil = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(vi_idperfil))
                oEmpleadoPerfil.DescripcionPerfil = DataUtil.DbValueToDefault(Of String)(oIDataReader(vi_descperfil))
                oListaEmpleadoPerfil.Add(oEmpleadoPerfil)
            End While
        End Using
        Return oListaEmpleadoPerfil
    End Function

    Function GestionarPerfil(oPerfil As Perfil) As Integer
        Dim result As Integer = -1
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_GESTIONAR_PERFIL)

        oDatabase.AddInParameter(oDbCommand, "@IdPerfil", DbType.Int32, oPerfil.IdPerfil)
        oDatabase.AddInParameter(oDbCommand, "@IdPerfilSuperior", DbType.Int32, oPerfil.IdPerfilSuperior)
        oDatabase.AddInParameter(oDbCommand, "@NombrePerfil", DbType.String, oPerfil.NombrePerfil)
        oDatabase.AddInParameter(oDbCommand, "@TipoPerfil", DbType.Int32, oPerfil.EmpleadoPerfil.IdPerfil)
        oDatabase.AddInParameter(oDbCommand, "@NombrePerfilInferior", DbType.String, oPerfil.NombrePerfilInferior)
        result = Integer.Parse(oDatabase.ExecuteScalar(oDbCommand))

        Return result
    End Function

    Function EliminarPerfil(IdPerfil As Integer) As Integer
        Dim result As Integer = -1
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_DESACTIVAR_PERFIL)

        oDatabase.AddInParameter(oDbCommand, "@IdPerfil", DbType.Int32, IdPerfil)
        result = Integer.Parse(oDatabase.ExecuteScalar(oDbCommand))

        Return result
    End Function

    Function Autocompletado_Perfil(NombrePerfil As String) As ListaPerfil
        Dim oListaPerfil As New ListaPerfil()
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_AUTOCOMPLETEPERFIL)
        oDatabase.AddInParameter(oDbCommand, "@NombrePerfil", DbType.String, NombrePerfil)
        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_IdPerfil As Integer = oIDataReader.GetOrdinal("IdPerfil")
            Dim INDICE_NombrePerfil As Integer = oIDataReader.GetOrdinal("NombrePerfil")
            While oIDataReader.Read()
                Dim oPerfil = New Perfil()
                oPerfil.IdPerfil = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_IdPerfil))
                oPerfil.NombrePerfil = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_NombrePerfil))
                oListaPerfil.Add(oPerfil)
            End While
        End Using
        Return oListaPerfil
    End Function

    Function Sel_Perfil_PerfilMenor(IdPerfil As Integer) As Perfil
        Dim oPerfil As New Perfil()
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(Procedimientos.USP_SEL_PERFIL_PERFILMENOR, IdPerfil)
            Dim INDICE_NombrePerfilInferior As Integer = oIDataReader.GetOrdinal("NombrePerfil")
            While oIDataReader.Read()
                oPerfil = New Perfil()
                oPerfil.NombrePerfilInferior = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_NombrePerfilInferior))
            End While
        End Using
        Return oPerfil
    End Function

    Function ListarCargos(oPaginacion As Paginacion) As Paginacion
        oPaginacion.ListaCargo = New ListaCargo()
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_BUSCACARGOS)

        oDatabase.AddInParameter(oDbCommand, "@NombreCargo", DbType.String, oPaginacion.Cargo.NombreCargo)
        oDatabase.AddInParameter(oDbCommand, "@IdPerfil", DbType.Int32, oPaginacion.Perfil.IdPerfil)
        oDatabase.AddInParameter(oDbCommand, "@PageSize", DbType.Int32, oPaginacion.PageSize)
        oDatabase.AddInParameter(oDbCommand, "@PageNumber", DbType.Int32, oPaginacion.PageNumber)
        oDatabase.AddInParameter(oDbCommand, "@SortBy", DbType.String, oPaginacion.SortBy)
        oDatabase.AddInParameter(oDbCommand, "@SortType", DbType.String, oPaginacion.SortType)
        oDatabase.AddOutParameter(oDbCommand, "@TotalRows", DbType.Int32, 10)
        oDbCommand.CommandTimeout = 120000

        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)

            Dim INDICE_IdPerfil As Integer = oIDataReader.GetOrdinal("IdPerfil")
            Dim INDICE_NombrePerfil As Integer = oIDataReader.GetOrdinal("NombrePerfil")
            Dim INDICE_IdCargo As Integer = oIDataReader.GetOrdinal("IdCargo")
            Dim INDICE_IdCargoSuperior As Integer = oIDataReader.GetOrdinal("IdCargoSuperior")
            Dim INDICE_NombreCargo As Integer = oIDataReader.GetOrdinal("NombreCargo")
            Dim INDICE_NombreCargoSuperior As Integer = oIDataReader.GetOrdinal("NombreCargoSuperior")
            Dim INDICE_NombreZona As Integer = oIDataReader.GetOrdinal("NombreZona")
            Dim INDICE_IdZona As Integer = oIDataReader.GetOrdinal("IdZona")
            Dim INDICE_Comisiona As Integer = oIDataReader.GetOrdinal("Comisiona")
            Dim INDICE_TipoPerfil As Integer = oIDataReader.GetOrdinal("TipoPerfil")

            While oIDataReader.Read()
                oPaginacion.Cargo = New Cargo()
                oPaginacion.Cargo.IdCargo = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_IdCargo))
                oPaginacion.Cargo.IdCargoSuperior = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_IdCargoSuperior))
                oPaginacion.Cargo.NombreCargo = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_NombreCargo))
                oPaginacion.Cargo.NombreCargoSuperior = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_NombreCargoSuperior))
                oPaginacion.Cargo.Comisiona = DataUtil.DbValueToDefault(Of Boolean)(oIDataReader(INDICE_Comisiona))
                oPaginacion.Cargo.Perfil = New Perfil()
                oPaginacion.Cargo.Perfil.IdPerfil = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_IdPerfil))
                oPaginacion.Cargo.Perfil.NombrePerfil = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_NombrePerfil))
                oPaginacion.Cargo.Perfil.TipoPerfil = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(INDICE_TipoPerfil))
                oPaginacion.Cargo.Zona = New ZonaMantenimiento()
                oPaginacion.Cargo.Zona.IdZona = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_IdZona))
                oPaginacion.Cargo.Zona.NombreZona = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_NombreZona))
                oPaginacion.ListaCargo.Add(oPaginacion.Cargo)
            End While
        End Using
        oPaginacion.TotalRows = Convert.ToInt32(oDatabase.GetParameterValue(oDbCommand, "@TotalRows"))
        Return oPaginacion
    End Function

    Function ListarCargoByPerfil_Combo(IdPerfil As Integer) As ListaCargo
        Dim oListaCargo As New ListaCargo()

        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_CARGOBYPERFILCBO)
        oDatabase.AddInParameter(oDbCommand, "@IdPerfil", DbType.Int32, IdPerfil)
        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)

            Dim INDICE_IdCargo As Integer = oIDataReader.GetOrdinal("IdCargo")
            Dim INDICE_NombreCargo As Integer = oIDataReader.GetOrdinal("NombreCargo")
            While oIDataReader.Read()
                Dim oCargo = New Cargo()

                oCargo.IdCargo = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_IdCargo))
                oCargo.NombreCargo = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_NombreCargo))
                oListaCargo.Add(oCargo)
            End While
        End Using
        Return oListaCargo
    End Function





    Function ListaZonaMantenimiento() As ListaZonaMantenimiento
        Dim oListaZonaMantenimiento As New ListaZonaMantenimiento()
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_ZONACBO)

        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_IdZona As Integer = oIDataReader.GetOrdinal("IdZona")
            Dim INDICE_NombreZona As Integer = oIDataReader.GetOrdinal("NombreZona")
            While oIDataReader.Read()
                Dim oZonaMantenimiento = New ZonaMantenimiento()
                oZonaMantenimiento.IdZona = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_IdZona))
                oZonaMantenimiento.NombreZona = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_NombreZona))
                oListaZonaMantenimiento.Add(oZonaMantenimiento)
            End While
        End Using
        Return oListaZonaMantenimiento
    End Function

    Function ListaZonaMantenimiento2(Usuario As String, FechaIniP As String, FechaFinP As String) As ListaZonaMantenimiento
        Dim oListaZonaMantenimiento As New ListaZonaMantenimiento()
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_ZONACBO2)

        Dim F1, F2 As String

        If FechaIniP <> "" And FechaFinP <> "" Then
            Dim FechaInD As DateTime = Convert.ToDateTime(FechaIniP)
            Dim FechaFiD As DateTime = Convert.ToDateTime(FechaFinP)
            Dim Mes As String = Constantes.ValorDefecto
            Dim dia As String = Constantes.ValorDefecto
            Dim Mes2 As String = Constantes.ValorDefecto
            Dim dia2 As String = Constantes.ValorDefecto

            If Convert.ToString(FechaInD.Month).Length = 1 Then
                Mes = "0" & Convert.ToString(FechaInD.Month)
            Else
                Mes = Convert.ToString(FechaInD.Month)
            End If

            If Convert.ToString(FechaInD.Day).Length = 1 Then
                dia = "0" & Convert.ToString(FechaInD.Day)
            Else
                dia = Convert.ToString(FechaInD.Day)
            End If

            If Convert.ToString(FechaFiD.Month).Length = 1 Then
                Mes2 = "0" & Convert.ToString(FechaFiD.Month)
            Else
                Mes2 = Convert.ToString(FechaFiD.Month)
            End If

            If Convert.ToString(FechaFiD.Day).Length = 1 Then
                dia2 = "0" & Convert.ToString(FechaFiD.Day)
            Else
                dia2 = Convert.ToString(FechaFiD.Day)
            End If

            F1 = Convert.ToString(FechaInD.Year) & Mes & dia
            F2 = Convert.ToString(FechaFiD.Year) & Mes2 & dia2
        Else
            F1 = FechaIniP
            F2 = FechaFinP

        End If

        oDatabase.AddInParameter(oDbCommand, "@UsuarioUsu", DbType.String, Usuario)
        oDatabase.AddInParameter(oDbCommand, "@FechaIni", DbType.String, F1)
        oDatabase.AddInParameter(oDbCommand, "@FechaFin", DbType.String, F2)
        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_IdZona As Integer = oIDataReader.GetOrdinal("IdZona")
            Dim INDICE_NombreZona As Integer = oIDataReader.GetOrdinal("NombreZona")
            While oIDataReader.Read()
                Dim oZonaMantenimiento = New ZonaMantenimiento()
                oZonaMantenimiento.IdZona = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_IdZona))
                oZonaMantenimiento.NombreZona = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_NombreZona))
                oListaZonaMantenimiento.Add(oZonaMantenimiento)
            End While
        End Using
        Return oListaZonaMantenimiento
    End Function

    Function GestionarCargo_(oCargo As Cargo) As Integer
        Dim result As Integer = -1
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_GESTIONAR_CARGO)

        oDatabase.AddInParameter(oDbCommand, "@IdCargo", DbType.Int32, oCargo.IdCargo)
        oDatabase.AddInParameter(oDbCommand, "@IdCargoSuperior", DbType.Int32, oCargo.IdCargoSuperior)
        oDatabase.AddInParameter(oDbCommand, "@IdPerfil", DbType.Int32, oCargo.Perfil.IdPerfil)
        oDatabase.AddInParameter(oDbCommand, "@IdZona", DbType.Int32, oCargo.Zona.IdZona)
        oDatabase.AddInParameter(oDbCommand, "@NombreCargo", DbType.String, oCargo.NombreCargo)
        oDatabase.AddInParameter(oDbCommand, "@Comisiona", DbType.Boolean, oCargo.Comisiona)
        oDatabase.AddInParameter(oDbCommand, "@NombreCargoInferior", DbType.String, oCargo.NombreCargoInferior)

        ' result = oDatabase.ExecuteNonQuery(oDbCommand)

        result = oDatabase.ExecuteScalar(oDbCommand)
        Return result
    End Function

    Function EliminarCargo(IdCargo As Integer) As Integer
        Dim result As Integer = -1
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_DESACTIVAR_CARGO)
        oDatabase.AddInParameter(oDbCommand, "@IdCargo", DbType.Int32, IdCargo)
        result = Integer.Parse(oDatabase.ExecuteScalar(oDbCommand))
        Return result
    End Function

    Function Autocompletado_Cargo(NombreCargo As String) As ListaCargo
        Dim oListaCargo As New ListaCargo()
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_AUTOCOMPLETECARGO)
        oDatabase.AddInParameter(oDbCommand, "@NombreCargo", DbType.String, NombreCargo)
        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_IdCargo As Integer = oIDataReader.GetOrdinal("IdCargo")
            Dim INDICE_NombreCargo As Integer = oIDataReader.GetOrdinal("NombreCargo")
            While oIDataReader.Read()
                Dim oCargo = New Cargo()
                oCargo.IdCargo = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_IdCargo))
                oCargo.NombreCargo = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_NombreCargo))
                oListaCargo.Add(oCargo)
            End While
        End Using
        Return oListaCargo
    End Function

    Function Seleccion_tipoPerfil(IdPerfil As Integer) As Integer
        Dim result As Integer = -1
        Dim oListaCargos As New ListaCargo()
        Dim oDbComand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_TIPOPERFIL)
        oDatabase.AddInParameter(oDbComand, "@idtipoPerfil", DbType.Int32, IdPerfil)
        result = oDatabase.ExecuteScalar(oDbComand)
        Return result

    End Function

    Function Seleccion_tipoPerfill(idcargose As Integer) As Integer
        Dim result As Integer = -1
        Dim oListaCargos As New ListaCargo()
        Dim oDbComand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_TIPOPERFIL)
        oDatabase.AddInParameter(oDbComand, "@idtipoPerfil", DbType.Int32, idcargose)
        result = oDatabase.ExecuteScalar(oDbComand)
        Return result
    End Function

    Function Seleccionar_PerfilMayor_Menor(idperfil As Integer) As String
        Dim resultado As String = ""
        Dim oDbComand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_MOSTRARPERFILMENOR)
        oDatabase.AddInParameter(oDbComand, "@IdPerfil", DbType.Int32, idperfil)
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbComand)
            Dim INDICE_NombrePerfil As Integer = oIDataReader.GetOrdinal("NombrePerfil")
            Dim oPerfil As New Perfil()
            While oIDataReader.Read()
                oPerfil = New Perfil
                resultado = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_NombrePerfil))
            End While
        End Using
        Return resultado
    End Function



    Function ListarZonas(oPaginacion As Paginacion) As Paginacion
        oPaginacion.ListaZonaMantenimiento = New ListaZonaMantenimiento()
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_BUSCAZONAS)

        oDatabase.AddInParameter(oDbCommand, "@NombreZona", DbType.String, oPaginacion.ZonaMantenimiento.NombreZona)
        oDatabase.AddInParameter(oDbCommand, "@PageSize", DbType.Int32, oPaginacion.PageSize)
        oDatabase.AddInParameter(oDbCommand, "@PageNumber", DbType.Int32, oPaginacion.PageNumber)
        oDatabase.AddInParameter(oDbCommand, "@SortBy", DbType.String, oPaginacion.SortBy)
        oDatabase.AddInParameter(oDbCommand, "@SortType", DbType.String, oPaginacion.SortType)
        oDatabase.AddOutParameter(oDbCommand, "@TotalRows", DbType.Int32, 10)
        oDbCommand.CommandTimeout = 120000

        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)

            Dim INDICE_IdZona As Integer = oIDataReader.GetOrdinal("IdZona")
            Dim INDICE_NombreZona As Integer = oIDataReader.GetOrdinal("NombreZona")
            Dim INDICE_IsNacional As Integer = oIDataReader.GetOrdinal("IsNacional")

            While oIDataReader.Read()
                oPaginacion.ZonaMantenimiento = New ZonaMantenimiento()
                oPaginacion.ZonaMantenimiento.IdZona = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_IdZona))
                oPaginacion.ZonaMantenimiento.NombreZona = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_NombreZona))
                oPaginacion.ZonaMantenimiento.IsNacional = DataUtil.DbValueToDefault(Of Boolean)(oIDataReader(INDICE_IsNacional))
                oPaginacion.ListaZonaMantenimiento.Add(oPaginacion.ZonaMantenimiento)
            End While
        End Using
        oPaginacion.TotalRows = Convert.ToInt32(oDatabase.GetParameterValue(oDbCommand, "@TotalRows"))
        Return oPaginacion
    End Function

    Function EliminarZona(IdZona As Integer) As Integer
        Dim result As Integer = -1
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_DESACTIVAR_ZONA)
        oDatabase.AddInParameter(oDbCommand, "@IdZona", DbType.Int32, IdZona)
        result = Integer.Parse(oDatabase.ExecuteScalar(oDbCommand))
        Return result
    End Function
    Function ListaSucursal_Multiselect(IdZona As Integer) As ListaSucursal
        Dim oListaSucursal As New ListaSucursal()
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_LISTASUCURSALES_MULTISELECT)
        oDatabase.AddInParameter(oDbCommand, "@IdZona", DbType.Int32, IdZona)
        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim oSucursal As New Sucursal()
            Dim idsucursal As Integer = oIDataReader.GetOrdinal("IdSucursal")
            Dim descripcion As Integer = oIDataReader.GetOrdinal("Descripcion")
            While oIDataReader.Read()
                oSucursal = New Sucursal()
                oSucursal.IdSucursal = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(idsucursal))
                oSucursal.DescripcionSucursal = DataUtil.DbValueToDefault(Of String)(oIDataReader(descripcion))
                oListaSucursal.Add(oSucursal)
            End While
        End Using
        Return oListaSucursal
    End Function

    Function ListaSucursal_Multiselect(IdZona As Integer, Nacional As Integer) As ListaSucursal
        Dim oListaSucursal As New ListaSucursal()
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_LISTASUCURSALES_MULTISELECT)
        oDatabase.AddInParameter(oDbCommand, "@IdZona", DbType.Int32, IdZona)
        oDatabase.AddInParameter(oDbCommand, "@Nacional", DbType.Int32, Nacional)
        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim oSucursal As New Sucursal()
            Dim idsucursal As Integer = oIDataReader.GetOrdinal("IdSucursal")
            Dim descripcion As Integer = oIDataReader.GetOrdinal("Descripcion")
            While oIDataReader.Read()
                oSucursal = New Sucursal()
                oSucursal.IdSucursal = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(idsucursal))
                oSucursal.DescripcionSucursal = DataUtil.DbValueToDefault(Of String)(oIDataReader(descripcion))
                oListaSucursal.Add(oSucursal)
            End While
        End Using
        Return oListaSucursal
    End Function

    Function traerEstado_Zona(IdZona As Integer) As Boolean
        Dim valor As Boolean
        Dim resulta As Integer = -1
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_ESTADO_ZONA)
        oDatabase.AddInParameter(oDbCommand, "@IdZona", DbType.Int32, IdZona)
        oDbCommand.CommandTimeout = 120000
        valor = oDatabase.ExecuteNonQuery(oDbCommand)
        If resulta = 1 Then
            Return valor
        Else
            Return valor
        End If

    End Function



    Function GestionarZona_(oListaZonaSucursal As ListaZonaSucursalMantenimiento) As Integer
        Dim result As Integer = -1
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_GESTIONAR_ZONA)

        Dim paramZona As New SqlParameter("@TZona", SqlDbType.Structured)
        Dim paramZonaSucursal As New SqlParameter("@TZonaSucursal", SqlDbType.Structured)

        paramZona.TypeName = "TZona"
        paramZona.Value = ZonaDataRecord(oListaZonaSucursal.First().ZonaMantenimiento)
        paramZonaSucursal.TypeName = "TZonaSucursal"
        paramZonaSucursal.Value = ZonaSucursalDataRecord(oListaZonaSucursal)

        oDbCommand.Parameters.Add(paramZona)
        oDbCommand.Parameters.Add(paramZonaSucursal)

        result = Integer.Parse(oDatabase.ExecuteScalar(oDbCommand))
        Return result

    End Function

    Function ZonaDataRecord(ByVal oZonaMantenimiento As ZonaMantenimiento) As IEnumerable(Of SqlDataRecord)

        Dim oListaZonaMantenimiento As List(Of ZonaMantenimiento) = New List(Of ZonaMantenimiento)
        oListaZonaMantenimiento.Add(oZonaMantenimiento)
        Dim records As List(Of SqlDataRecord) = New List(Of SqlDataRecord)
        For Each item As ZonaMantenimiento In oListaZonaMantenimiento
            Dim record As SqlDataRecord = New SqlDataRecord(
                New SqlMetaData() {
                    New SqlMetaData("IdZona", SqlDbType.Int),
                    New SqlMetaData("NombreZona", SqlDbType.VarChar, 250),
                    New SqlMetaData("IsNacional", SqlDbType.Bit)
                }
            )
            record.SetInt32(0, item.IdZona)
            record.SetString(1, item.NombreZona)
            record.SetBoolean(2, item.IsNacional)
            records.Add(record)
        Next
        Return records
    End Function

    Function ZonaSucursalDataRecord(ByVal oListaZonaSucursal As List(Of ZonaSucursalMantenimiento)) As IEnumerable(Of SqlDataRecord)

        Dim records As List(Of SqlDataRecord) = New List(Of SqlDataRecord)
        For Each item As ZonaSucursalMantenimiento In oListaZonaSucursal
            Dim record As SqlDataRecord = New SqlDataRecord(
                New SqlMetaData() {
                    New SqlMetaData("IdZonaSucursal", SqlDbType.Int),
                    New SqlMetaData("IdZona", SqlDbType.Int),
                    New SqlMetaData("IdSucursal", SqlDbType.Int)
                }
            )
            record.SetInt32(0, item.IdZonaSucursal)
            record.SetInt32(1, item.IdZona)
            record.SetInt32(2, item.IdSucursal)

            records.Add(record)
        Next
        Return records
    End Function

    Function ListaSucursalesSeleccionadas(IdZona As Integer) As ListaSucursalSeleccionadas
        Dim oListaSucursalSeleccionadas As New ListaSucursalSeleccionadas()
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_LISTASUCURSALES_SELECCIONADAS)
        oDatabase.AddInParameter(oDbCommand, "@IdZona", DbType.Int32, IdZona)
        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim oSucursal As New Sucursal()
            Dim INDICE_idsucursal As Integer = oIDataReader.GetOrdinal("IdSucursal")
            While oIDataReader.Read()
                oSucursal = New Sucursal()
                oSucursal.IdSucursal = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_idsucursal))
                oListaSucursalSeleccionadas.Add(oSucursal)
            End While
        End Using
        Return oListaSucursalSeleccionadas
    End Function

    Function ListaClientesSeleccionados(IdGrupo As Integer) As ListaClientesSeleccionadas
        Dim oListaClientesSeleccionados As New ListaClientesSeleccionadas()
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_LISTACLIENTES_SELECCIONADOS)
        oDatabase.AddInParameter(oDbCommand, "@IDGRUPO", DbType.Int32, IdGrupo)
        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim oClientes As New ClienteVenta()
            Dim INDICE_idcliente As Integer = oIDataReader.GetOrdinal("IdCliente")
            While oIDataReader.Read()
                oClientes = New ClienteVenta()
                oClientes.IdCliente = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_idcliente))
                oListaClientesSeleccionados.Add(oClientes)
            End While
        End Using
        Return oListaClientesSeleccionados
    End Function

    Function Autocompletado_Zona(NombreZona As String) As ListaZonaMantenimiento
        Dim oListaZonaMantenimiento As New ListaZonaMantenimiento()
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_AUTOCOMPLETEZONA)
        oDatabase.AddInParameter(oDbCommand, "@NombreZona", DbType.String, NombreZona)
        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_IdZona As Integer = oIDataReader.GetOrdinal("IdZona")
            Dim INDICE_NombreZona As Integer = oIDataReader.GetOrdinal("NombreZona")
            While oIDataReader.Read()
                Dim oZona = New ZonaMantenimiento()
                oZona.IdZona = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_IdZona))
                oZona.NombreZona = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_NombreZona))
                oListaZonaMantenimiento.Add(oZona)
            End While
        End Using
        Return oListaZonaMantenimiento
    End Function

    Function ConsultarDepartamento() As ListaDepartamento
        Dim oListaDepartamento As New ListaDepartamento()
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_LISTADEPARTAMENTO)
        oListaDepartamento = New ListaDepartamento
        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim oDepartamento As New Departamento()
            Dim m_IdDepartamento As Integer = oIDataReader.GetOrdinal("IdDepartamento")
            Dim m_CodigoDepartamento As Integer = oIDataReader.GetOrdinal("CodigoDepartamento")
            Dim m_Descripcion As Integer = oIDataReader.GetOrdinal("Descripcion")
            While oIDataReader.Read()
                oDepartamento = New Departamento()
                oDepartamento.IdDepartamento = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(m_IdDepartamento))
                oDepartamento.CodigoDepartamento = DataUtil.DbValueToDefault(Of String)(oIDataReader(m_CodigoDepartamento))
                oDepartamento.Descripcion = DataUtil.DbValueToDefault(Of String)(oIDataReader(m_Descripcion))
                oListaDepartamento.Add(oDepartamento)
            End While
        End Using
        Return oListaDepartamento
    End Function

    Function ConsultarProvinciaDepartamento(ByVal IdDepartamento As Integer) As ListaProvincia
        Dim oListaProvincia As New ListaProvincia()

        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_LISTAPROVINCIA)
        oDatabase.AddInParameter(oDbCommand, "@IdDepartamento", DbType.Int32, IdDepartamento)
        oListaProvincia = New ListaProvincia
        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim indiceIdProvincia As Integer = oIDataReader.GetOrdinal("IdProvincia")
            Dim indiceCodigoProvincia As Integer = oIDataReader.GetOrdinal("CodigoProvincia")
            Dim indiceDescripcion As Integer = oIDataReader.GetOrdinal("Descripcion")

            Dim oProvincia As New Provincia()
            While oIDataReader.Read()
                oProvincia = New Provincia()
                oProvincia.IdProvincia = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indiceIdProvincia))
                oProvincia.CodigoProvincia = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceCodigoProvincia))
                oProvincia.Descripcion = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceDescripcion))
                oListaProvincia.Add(oProvincia)
            End While
        End Using
        Return oListaProvincia
    End Function

    Function ConsultarDistritoProvincia(ByVal IdProvincia As Integer) As ListaDistrito
        Dim oListaDistrito As New ListaDistrito()
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_DISTRITO)
        oDatabase.AddInParameter(oDbCommand, "@IdProvincia", DbType.Int32, IdProvincia)
        oListaDistrito = New ListaDistrito
        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim indiceIdDistrito As Integer = oIDataReader.GetOrdinal("IdDistrito")
            Dim indiceCodigoDistrito As Integer = oIDataReader.GetOrdinal("CodigoDistrito")
            Dim indiceDescripcion As Integer = oIDataReader.GetOrdinal("Descripcion")

            Dim oDistrito As New Distrito()
            While oIDataReader.Read()
                oDistrito = New Distrito()
                oDistrito.IdDistrito = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indiceIdDistrito))
                oDistrito.CodigoDistrito = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceCodigoDistrito))
                oDistrito.Descripcion = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceDescripcion))
                oListaDistrito.Add(oDistrito)
            End While
        End Using
        Return oListaDistrito
    End Function

    Function Autocompletado_Sucursal(NombreSucursal As String) As ListaSucursalMantenimiento
        Dim oListaSucursalMantenimiento As New ListaSucursalMantenimiento()
        Dim oDbComand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_AUTOCOMPLETESUCURSAL)
        oDatabase.AddInParameter(oDbComand, "@NOMBRESUCURSAL", DbType.String, NombreSucursal)
        oDbComand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbComand)
            Dim INDICE_IdSucursal As Integer = oIDataReader.GetOrdinal("IdSucursal")
            Dim INDICE_NombreSucursal As Integer = oIDataReader.GetOrdinal("Descripcion")
            While oIDataReader.Read()
                Dim oSucursalMantenimiento = New SucursalMantenimiento()
                oSucursalMantenimiento.IdSucursal = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_IdSucursal))
                oSucursalMantenimiento.Descripcion = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_NombreSucursal))
                oListaSucursalMantenimiento.Add(oSucursalMantenimiento)
            End While
        End Using
        Return oListaSucursalMantenimiento
    End Function

    Public Function ListarSucursales(ByRef oPaginacion As Paginacion) As Paginacion
        oPaginacion.ListaSucursalMantenimiento = New ListaSucursalMantenimiento()
        Dim oDbComand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_BUSCARSUCURSALES)

        oDatabase.AddInParameter(oDbComand, "@NOMBRESUCURSAL", DbType.String, oPaginacion.SucursalMantenimiento.Descripcion)
        oDatabase.AddInParameter(oDbComand, "@IDZONA", DbType.Int32, oPaginacion.ZonaMantenimiento.IdZona)
        oDatabase.AddInParameter(oDbComand, "@PAGESIZE", DbType.Int32, oPaginacion.PageSize)
        oDatabase.AddInParameter(oDbComand, "PAGENUMBER", DbType.Int32, oPaginacion.PageNumber)
        oDatabase.AddInParameter(oDbComand, "@SORTBY", DbType.String, oPaginacion.SortBy)
        oDatabase.AddInParameter(oDbComand, "@SORTTYPE", DbType.String, oPaginacion.SortType)
        oDatabase.AddInParameter(oDbComand, "@TOTALROWS", DbType.Int32, oPaginacion.TotalRows)

        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbComand)

            Dim INDICE_IdSucursal As Integer = oIDataReader.GetOrdinal("IdSucursal")
            Dim INDICE_Descripcion_Sucursal As Integer = oIDataReader.GetOrdinal("Descripcion")
            Dim INDICE_IdZona As Integer = oIDataReader.GetOrdinal("IdZona")
            Dim INDICE_NombreZona As Integer = oIDataReader.GetOrdinal("NombreZona")
            Dim INDICE_DESCRIPCIONCORTA As Integer = oIDataReader.GetOrdinal("DESCRIPCIONCORTA")
            Dim INDICE_IdDepartamento As Integer = oIDataReader.GetOrdinal("IdDepartamento")
            Dim INDICE_IdProvincia As Integer = oIDataReader.GetOrdinal("IdProvincia")
            Dim INDICE_IdDistrito As Integer = oIDataReader.GetOrdinal("IdDistrito")
            Dim INDICE_Direccion As Integer = oIDataReader.GetOrdinal("Direccion")
            'Dim INDICE_Telefono As Integer = oIDataReader.GetOrdinal("Telefono")

            While oIDataReader.Read()
                oPaginacion.SucursalMantenimiento = New SucursalMantenimiento()
                oPaginacion.SucursalMantenimiento.IdSucursal = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_IdSucursal))
                oPaginacion.SucursalMantenimiento.Descripcion = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_Descripcion_Sucursal))
                oPaginacion.SucursalMantenimiento.Zona = New ZonaMantenimiento()
                oPaginacion.SucursalMantenimiento.Zona.IdZona = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_IdZona))
                oPaginacion.SucursalMantenimiento.Zona.NombreZona = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_NombreZona))
                oPaginacion.SucursalMantenimiento.DescripcionCorta = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_DESCRIPCIONCORTA))
                oPaginacion.SucursalMantenimiento.Departamento = New Departamento()
                oPaginacion.SucursalMantenimiento.Departamento.IdDepartamento = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_IdDepartamento))
                oPaginacion.SucursalMantenimiento.Provincia = New Provincia()
                oPaginacion.SucursalMantenimiento.Provincia.IdProvincia = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_IdProvincia))
                oPaginacion.SucursalMantenimiento.Distrito = New Distrito()
                oPaginacion.SucursalMantenimiento.Distrito.IdDistrito = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_IdDistrito))
                oPaginacion.SucursalMantenimiento.Direccion = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_Direccion))
                'oPaginacion.SucursalMantenimiento.Telefono = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_Telefono))
                oPaginacion.ListaSucursalMantenimiento.Add(oPaginacion.SucursalMantenimiento)
            End While
        End Using
        oPaginacion.TotalRows = Convert.ToInt32(oDatabase.GetParameterValue(oDbComand, "@TotalRows"))
        Return oPaginacion
    End Function

    Function GestionarSucursal_(oSucursalMantenimiento As SucursalMantenimiento) As Integer
        Dim result As Integer = -1
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_GESTIONAR_SUCURSAL)

        oDatabase.AddInParameter(oDbCommand, "@IDSUCURSAL", DbType.Int32, oSucursalMantenimiento.IdSucursal)
        oDatabase.AddInParameter(oDbCommand, "@IDDEPARTAMENTO", DbType.Int32, oSucursalMantenimiento.Departamento.IdDepartamento)
        oDatabase.AddInParameter(oDbCommand, "@IDPROVINCIA", DbType.Int32, oSucursalMantenimiento.Provincia.IdProvincia)
        oDatabase.AddInParameter(oDbCommand, "@IDDISTRITO", DbType.Int32, oSucursalMantenimiento.Distrito.IdDistrito)
        oDatabase.AddInParameter(oDbCommand, "@NOMBRESUCURSAL", DbType.String, oSucursalMantenimiento.Descripcion)
        oDatabase.AddInParameter(oDbCommand, "@DESCRIPCORTA", DbType.String, oSucursalMantenimiento.DescripcionCorta)
        oDatabase.AddInParameter(oDbCommand, "@DIRECCION", DbType.String, oSucursalMantenimiento.Direccion)
        oDatabase.AddInParameter(oDbCommand, "@TELEFONO", DbType.String, oSucursalMantenimiento.Telefono)
        result = Integer.Parse(oDatabase.ExecuteScalar(oDbCommand))
        Return result
    End Function

    Function EliminarSucursal(IdSucursal As Integer) As Integer
        Dim result As Integer = -1
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_DESACTIVAR_SUCURSAL)

        oDatabase.AddInParameter(oDbCommand, "@IDSUCURSAL", DbType.Int32, IdSucursal)
        result = oDatabase.ExecuteScalar(oDbCommand)
        Return result
    End Function

    Function NombreVendedor(IdCargo As Integer) As String
        Dim result As String = ""
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_VENDEDORCARGO, IdCargo)
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_NombreCargo As Integer = oIDataReader.GetOrdinal("NombreCargo")
            While oIDataReader.Read()
                result = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_NombreCargo))
            End While
        End Using
        Return result
    End Function

    Public Function ListarPerfil_Empleado(ByRef oPerfil As String) As String

        Dim oDbCommand As DbCommand = Nothing
        Dim oEmpleado As String = ""
        Try
            oDbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_CONSULTAR_PERFIL)
            oDatabase.AddInParameter(oDbCommand, "@Perfil", DbType.String, oPerfil)
            oDbCommand.CommandTimeout = 120000

            Dim cnStr As String = ConfigurationManager.ConnectionStrings(Conexion.cnsSql).ToString()

            Using SqlCn As New SqlConnection(cnStr)
                oDbCommand.Connection = SqlCn
                oDbCommand.Connection.Open()
                Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)

                    Dim INDICE_IdCargo As Integer = oIDataReader.GetOrdinal("IdPerfil")

                    While oIDataReader.Read()


                        oEmpleado = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_IdCargo))

                    End While
                End Using
            End Using
        Catch ex As Exception
            Throw ex

        Finally
            oDbCommand.Connection.Close()
            oDbCommand.Connection.Dispose()
        End Try

        Return oEmpleado
    End Function

    Public Function ListarZona_Sucursal(ByRef oZona As String) As String
        Dim oZonas As String = ""
        Dim oDbCommand As DbCommand = Nothing
        Try

            oDbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_LISTAR_ZONA_NOMBRE)
            oDatabase.AddInParameter(oDbCommand, "@zona", DbType.String, oZona)
            oDbCommand.CommandTimeout = 120000
            Dim cnStr As String = ConfigurationManager.ConnectionStrings(Conexion.cnsSql).ToString()

            Using SqlCn As New SqlConnection(cnStr)
                oDbCommand.Connection = SqlCn
                oDbCommand.Connection.Open()
                Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)

                    Dim INDICE_IdZona As Integer = oIDataReader.GetOrdinal("IdZona")

                    While oIDataReader.Read()


                        oZonas = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_IdZona))

                    End While
                End Using
            End Using
        Catch ex As Exception


            Throw ex

        Finally
            oDbCommand.Connection.Close()
            oDbCommand.Connection.Dispose()

        End Try

        Return oZonas
    End Function

    Public Function ListarSucursal_Empleado(ByRef oSucursal As String) As String
        Dim oEmpleado As String = ""
        Dim oDbCommand As DbCommand = Nothing
        Try

            oDbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_CONSULTAR_SUCURSAL)
            oDatabase.AddInParameter(oDbCommand, "@Sucursal", DbType.String, oSucursal)
            oDbCommand.CommandTimeout = 120000
            Dim cnStr As String = ConfigurationManager.ConnectionStrings(Conexion.cnsSql).ToString()

            Using SqlCn As New SqlConnection(cnStr)
                oDbCommand.Connection = SqlCn
                oDbCommand.Connection.Open()
                Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)

                    Dim INDICE_IdCargo As Integer = oIDataReader.GetOrdinal("CodigoSucursal")

                    While oIDataReader.Read()


                        oEmpleado = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(INDICE_IdCargo))

                    End While
                End Using
            End Using
        Catch ex As Exception

            Throw ex

        Finally
            oDbCommand.Connection.Close()
            oDbCommand.Connection.Dispose()

        End Try



        Return oEmpleado
    End Function

    Function ListarGrupos(oPaginacion As Paginacion) As Paginacion
        oPaginacion.ListaGrupo = New ListaGrupo()
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_BUSCAGRUPO)
        oDatabase.AddInParameter(oDbCommand, "@NombreGrupo", DbType.String, oPaginacion.Grupo.NombreGrupo)
        oDatabase.AddInParameter(oDbCommand, "@PageSize", DbType.Int32, oPaginacion.PageSize)
        oDatabase.AddInParameter(oDbCommand, "@PageNumber", DbType.Int32, oPaginacion.PageNumber)
        oDatabase.AddInParameter(oDbCommand, "@SortBy", DbType.String, oPaginacion.SortBy)
        oDatabase.AddInParameter(oDbCommand, "@SortType", DbType.String, oPaginacion.SortType)
        oDatabase.AddOutParameter(oDbCommand, "@TotalRows", DbType.Int32, 10)
        oDbCommand.CommandTimeout = 120000

        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_IDGRUPO As Integer = oIDataReader.GetOrdinal("IDGRUPO")
            Dim INDICE_NOMBREGRUPO As Integer = oIDataReader.GetOrdinal("NOMBREGRUPO")
            Dim INDICE_ACTIVO As Integer = oIDataReader.GetOrdinal("ACTIVO")

            While oIDataReader.Read()
                oPaginacion.Grupo = New Grupo()
                oPaginacion.Grupo.IdGrupo = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_IDGRUPO))
                oPaginacion.Grupo.NombreGrupo = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_NOMBREGRUPO))
                oPaginacion.Grupo.Activo = DataUtil.DbValueToDefault(Of Boolean)(oIDataReader(INDICE_ACTIVO))
                oPaginacion.ListaGrupo.Add(oPaginacion.Grupo)
            End While
        End Using
        oPaginacion.TotalRows = Convert.ToInt32(oDatabase.GetParameterValue(oDbCommand, "@TotalRows"))
        Return oPaginacion
    End Function

    Function Autocompletado_Grupo(NombreGrupo As String) As ListaGrupo
        Dim oListaGrupo As New ListaGrupo()
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USO_SEL_AUTOCOMPLETEGRUPO)
        oDatabase.AddInParameter(oDbCommand, "@NOMBREGRUPO", DbType.String, NombreGrupo)
        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_IdGrupo As Integer = oIDataReader.GetOrdinal("IDGRUPO")
            Dim INDICE_NombreGrupo As Integer = oIDataReader.GetOrdinal("NOMBREGRUPO")
            While oIDataReader.Read()
                Dim oGrupo = New Grupo()
                oGrupo.IdGrupo = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_IdGrupo))
                oGrupo.NombreGrupo = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_NombreGrupo))
                oListaGrupo.Add(oGrupo)
            End While
        End Using
        Return oListaGrupo
    End Function

    Function ListaClientes_Multiselect(IdGrupo As Integer) As ListaClienteVenta
        Dim oListaClientes As New ListaClienteVenta()
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_LISTACLIENTES_MULTISELECT)
        oDatabase.AddInParameter(oDbCommand, "@IdGrupo", DbType.Int32, IdGrupo)
        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim oCliente As New ClienteVenta()
            Dim INDICE_IdCliente As Integer = oIDataReader.GetOrdinal("IdCliente")
            Dim INDICE_Razon As Integer = oIDataReader.GetOrdinal("Razon")
            While oIDataReader.Read()
                oCliente = New ClienteVenta()
                oCliente.IdCliente = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_IdCliente))
                oCliente.RazonSocial = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_Razon))
                oListaClientes.Add(oCliente)
            End While
        End Using
        Return oListaClientes
    End Function

    Function EliminarGrupo(IdGrupo As Integer) As Integer
        Dim result As Integer = -1
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_DESACTIVAR_GRUPO)
        oDatabase.AddInParameter(oDbCommand, "@IDGrupo", DbType.Int32, IdGrupo)
        result = Integer.Parse(oDatabase.ExecuteScalar(oDbCommand))
        Return result
    End Function

    Function GestionarGrupo_(oListaGrupoCliente As ListaGrupoClienteMantenimiento) As Integer
        Dim result As Integer = -1
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_GESTIONAR_GRUPO)
        Dim paramGrupo As New SqlParameter("@TGRUPO", SqlDbType.Structured)
        Dim paramGrupoCliente As New SqlParameter("@TGRUPOCLIENTE", SqlDbType.Structured)

        paramGrupo.TypeName = "TGrupo"
        paramGrupo.Value = GrupoDataRecord(oListaGrupoCliente.First().Grupo)
        paramGrupoCliente.TypeName = "TGrupoCliente"
        paramGrupoCliente.Value = GrupoClienteDataRecord(oListaGrupoCliente)

        oDbCommand.Parameters.Add(paramGrupo)
        oDbCommand.Parameters.Add(paramGrupoCliente)

        result = Integer.Parse(oDatabase.ExecuteScalar(oDbCommand))
        Return result
    End Function

    Function GrupoClienteDataRecord(ByVal oListaGrupoCliente As List(Of GrupoClienteMantenimiento)) As IEnumerable(Of SqlDataRecord)
        Dim records As List(Of SqlDataRecord) = New List(Of SqlDataRecord)
        For Each item As GrupoClienteMantenimiento In oListaGrupoCliente
            Dim record As SqlDataRecord = New SqlDataRecord(
                New SqlMetaData() {
                    New SqlMetaData("IdGrupoCliente", SqlDbType.Int),
                    New SqlMetaData("IdGrupo", SqlDbType.Int),
                    New SqlMetaData("IdCliente", SqlDbType.Int)
                }
            )
            record.SetInt32(0, item.IdGrupoCliente)
            record.SetInt32(1, item.IdGrupo)
            record.SetInt32(2, item.IdCliente)

            records.Add(record)
        Next
        Return records
    End Function

    Function GrupoDataRecord(ByVal oGrupoMantenimiento As Grupo) As IEnumerable(Of SqlDataRecord)
        Dim oListaGrupoMantenimiento As List(Of Grupo) = New List(Of Grupo)
        oListaGrupoMantenimiento.Add(oGrupoMantenimiento)
        Dim records As List(Of SqlDataRecord) = New List(Of SqlDataRecord)
        For Each item As Grupo In oListaGrupoMantenimiento
            Dim record As SqlDataRecord = New SqlDataRecord(
                New SqlMetaData() {
                    New SqlMetaData("IdGrupo", SqlDbType.Int),
                    New SqlMetaData("NombreGrupo", SqlDbType.VarChar, 250)
                }
            )
            record.SetInt32(0, item.IdGrupo)
            record.SetString(1, item.NombreGrupo)
            records.Add(record)
        Next
        Return records
    End Function

    Function ListaClientesGrupo(oPaginacion As Paginacion) As Paginacion
        'oPaginacion.ListaGrupo = New ListaGrupo()
        oPaginacion.ListaGrupoClienteMantenimiento = New ListaGrupoClienteMantenimiento()
        ' Dim oGrupo As New Grupo()
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_LISTACLIENTES_GRUPO)

        oDatabase.AddInParameter(oDbCommand, "@IDGRUPO", DbType.Int32, oPaginacion.Grupo.IdGrupo)
        oDatabase.AddInParameter(oDbCommand, "@PageSize", DbType.Int32, oPaginacion.PageSize)
        oDatabase.AddInParameter(oDbCommand, "@PageNumber", DbType.Int32, oPaginacion.PageNumber)
        oDatabase.AddInParameter(oDbCommand, "@SortBy", DbType.String, oPaginacion.SortBy)
        oDatabase.AddInParameter(oDbCommand, "@SortType", DbType.String, oPaginacion.SortType)
        oDatabase.AddOutParameter(oDbCommand, "@TotalRows", DbType.Int32, 10)
        oDbCommand.CommandTimeout = 120000
        Try
            Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
                'Dim oGrupo As New Grupo()
                Dim INDICE_IDGRUPO As Integer = oIDataReader.GetOrdinal("IdGrupo")
                Dim INDICE_NOMBREGRUPO As Integer = oIDataReader.GetOrdinal("NombreGrupo")
                Dim INDICE_RUC As Integer = oIDataReader.GetOrdinal("ruc")
                Dim INDICE_RazonSocial As Integer = oIDataReader.GetOrdinal("RazonSocial")
                Dim INDICE_DescripcionSector As Integer = oIDataReader.GetOrdinal("DescripcionSector")
                Dim INDICE_DescripcionTipo As Integer = oIDataReader.GetOrdinal("DescripcionTipo")
                Dim INDICE_NombreZona As Integer = oIDataReader.GetOrdinal("NombreZona")
                Dim INDICE_DescripcionSucursal As Integer = oIDataReader.GetOrdinal("DescripcionSucursal")
                Dim INDICE_RRVV_PRINCIPAL As Integer = oIDataReader.GetOrdinal("RRVV_PRINCIPAL")
                Dim INDICE_NombreZonaSecundario As Integer = oIDataReader.GetOrdinal("NombreZonaSecundario")
                Dim INDICE_DescripcionSucursalSecundario As Integer = oIDataReader.GetOrdinal("DescripcionSucursalSecundario")
                Dim INDICE_RRVV_SECUNDARIO As Integer = oIDataReader.GetOrdinal("RRVV_SECUNDARIO")

                While oIDataReader.Read()
                    oPaginacion.GrupoClienteMantenimiento = New GrupoClienteMantenimiento()
                    oPaginacion.GrupoClienteMantenimiento.Grupo = New Grupo()
                    oPaginacion.GrupoClienteMantenimiento.Grupo.IdGrupo = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_IDGRUPO))
                    oPaginacion.GrupoClienteMantenimiento.Grupo.NombreGrupo = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_NOMBREGRUPO))
                    oPaginacion.GrupoClienteMantenimiento.ClienteVenta = New ClienteVenta()
                    oPaginacion.GrupoClienteMantenimiento.ClienteVenta.RUC = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_RUC))
                    oPaginacion.GrupoClienteMantenimiento.ClienteVenta.RazonSocial = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_RazonSocial))
                    oPaginacion.GrupoClienteMantenimiento.ClienteVenta.DescripcionSector = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_DescripcionSector))
                    oPaginacion.GrupoClienteMantenimiento.ClienteVenta.DescripcionTipo = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_DescripcionTipo))
                    oPaginacion.GrupoClienteMantenimiento.ClienteVenta.NombreZona = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_NombreZona))
                    oPaginacion.GrupoClienteMantenimiento.ClienteVenta.DescripcionSucursal = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_DescripcionSucursal))
                    oPaginacion.GrupoClienteMantenimiento.ClienteVenta.NombreZonaSecundario = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_NombreZonaSecundario))
                    oPaginacion.GrupoClienteMantenimiento.ClienteVenta.DescripcionSucursalSecundario = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_DescripcionSucursalSecundario))
                    oPaginacion.GrupoClienteMantenimiento.Empleado = New Empleado()
                    oPaginacion.GrupoClienteMantenimiento.Empleado.NombresApellidos = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_RRVV_PRINCIPAL))
                    oPaginacion.GrupoClienteMantenimiento.Empleado.NombresApellidos2 = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_RRVV_SECUNDARIO))
                    oPaginacion.ListaGrupoClienteMantenimiento.Add(oPaginacion.GrupoClienteMantenimiento)
                End While
            End Using
            oPaginacion.TotalRows = Convert.ToInt32(oDatabase.GetParameterValue(oDbCommand, "@TotalRows"))
        Catch ex As Exception
            Throw ex
        End Try

        Return oPaginacion
    End Function

    Public Function BuscarProveedor(ByVal proveedor As Proveedor, ByVal paginacion As Paginacion, ByRef rowCount As Integer) As List(Of Proveedor)
        Dim lista = New List(Of Proveedor)

        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.Usp_Sel_ProveedorPaginacion)
        oDatabase.AddInParameter(oDbCommand, "@IdEmpresa", DbType.Int32, proveedor.IdEmpresa)
        oDatabase.AddInParameter(oDbCommand, "@Ruc", DbType.String, If(proveedor.Ruc = Nothing, String.Empty, proveedor.Ruc))
        oDatabase.AddInParameter(oDbCommand, "@RazonSocial", DbType.String, If(proveedor.RazonSocial = Nothing, String.Empty, proveedor.RazonSocial))
        oDatabase.AddInParameter(oDbCommand, "@Estado", DbType.Int32, proveedor.EstadoP)

        oDatabase.AddInParameter(oDbCommand, "@rowsPerPage", DbType.Int32, paginacion.RowsPerPage)
        oDatabase.AddInParameter(oDbCommand, "@page", DbType.Int32, paginacion.Page)
        oDatabase.AddInParameter(oDbCommand, "@sortDir", DbType.String, paginacion.SortBy)
        oDatabase.AddInParameter(oDbCommand, "@sortType", DbType.String, paginacion.SortType)
        oDatabase.AddOutParameter(oDbCommand, "@rowCount", DbType.Int32, 10)

        oDbCommand.CommandTimeout = 120000

        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            While oIDataReader.Read()
                Dim obj As Proveedor = New Proveedor()
                obj.IdProveedor = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(oIDataReader.GetOrdinal("IdProveedor")))
                obj.Ruc = DataUtil.DbValueToDefault(Of String)(oIDataReader(oIDataReader.GetOrdinal("Ruc")))
                obj.RazonSocial = DataUtil.DbValueToDefault(Of String)(oIDataReader(oIDataReader.GetOrdinal("RazonSocial")))
                obj.Numero = DataUtil.DbValueToDefault(Of String)(oIDataReader(oIDataReader.GetOrdinal("Numero")))
                obj.Direccion = DataUtil.DbValueToDefault(Of String)(oIDataReader(oIDataReader.GetOrdinal("Direccion")))
                obj.IdEmpresa = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(oIDataReader.GetOrdinal("IdEmpresa")))
                obj.EmpresaDescripcion = DataUtil.DbValueToDefault(Of String)(oIDataReader(oIDataReader.GetOrdinal("EmpresaDescripcion")))
                obj.Estado = DataUtil.DbValueToDefault(Of Boolean)(oIDataReader(oIDataReader.GetOrdinal("Estado")))
                lista.Add(obj)
            End While
        End Using
        rowCount = Convert.ToInt32(oDatabase.GetParameterValue(oDbCommand, "@RowCount"))
        Return lista
    End Function

    Function InsertarProveedor(proveedor As Proveedor) As Integer
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.Usp_Ins_Proveedor)
        oDatabase.AddInParameter(oDbCommand, "@Ruc", DbType.String, proveedor.Ruc)
        oDatabase.AddInParameter(oDbCommand, "@RazonSocial", DbType.String, proveedor.RazonSocial)
        oDatabase.AddInParameter(oDbCommand, "@Numero", DbType.String, proveedor.Numero)
        oDatabase.AddInParameter(oDbCommand, "@Direccion", DbType.String, proveedor.Direccion)
        oDatabase.AddInParameter(oDbCommand, "@IdEmpresa", DbType.Int32, proveedor.IdEmpresa)
        Return Integer.Parse(oDatabase.ExecuteScalar(oDbCommand))
    End Function

    Function ActualizarProveedor(proveedor As Proveedor) As Integer
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.Usp_Upd_Proveedor)
        oDatabase.AddInParameter(oDbCommand, "@IdProveedor", DbType.Int32, proveedor.IdProveedor)
        oDatabase.AddInParameter(oDbCommand, "@Ruc", DbType.String, proveedor.Ruc)
        oDatabase.AddInParameter(oDbCommand, "@RazonSocial", DbType.String, proveedor.RazonSocial)
        oDatabase.AddInParameter(oDbCommand, "@Numero", DbType.String, proveedor.Numero)
        oDatabase.AddInParameter(oDbCommand, "@Direccion", DbType.String, proveedor.Direccion)
        oDatabase.AddInParameter(oDbCommand, "@IdEmpresa", DbType.Int32, proveedor.IdEmpresa)
        Return Integer.Parse(oDatabase.ExecuteScalar(oDbCommand))
    End Function

    Function ActualizarProveedorEstado(proveedor As Proveedor) As Integer
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.Usp_UpdEst_Proveedor)
        oDatabase.AddInParameter(oDbCommand, "@IdProveedor", DbType.Int32, proveedor.IdProveedor)
        oDatabase.AddInParameter(oDbCommand, "@Estado", DbType.Boolean, proveedor.Estado)
        Return Integer.Parse(oDatabase.ExecuteScalar(oDbCommand))
    End Function

    Function GetProveedor(Id As Integer) As Proveedor
        Dim obj = New Proveedor
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.Usp_Sel_Proveedor)
        oDatabase.AddInParameter(oDbCommand, "@IdProveedor", DbType.Int32, Id)
        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            While oIDataReader.Read()
                obj.IdProveedor = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(oIDataReader.GetOrdinal("IdProveedor")))
                obj.Ruc = DataUtil.DbValueToDefault(Of String)(oIDataReader(oIDataReader.GetOrdinal("Ruc")))
                obj.RazonSocial = DataUtil.DbValueToDefault(Of String)(oIDataReader(oIDataReader.GetOrdinal("RazonSocial")))
                obj.Numero = DataUtil.DbValueToDefault(Of String)(oIDataReader(oIDataReader.GetOrdinal("Numero")))
                obj.Direccion = DataUtil.DbValueToDefault(Of String)(oIDataReader(oIDataReader.GetOrdinal("Direccion")))
                obj.IdEmpresa = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(oIDataReader.GetOrdinal("IdEmpresa")))
                obj.Estado = DataUtil.DbValueToDefault(Of Boolean)(oIDataReader(oIDataReader.GetOrdinal("Estado")))
            End While
        End Using
        Return obj
    End Function

    Public Function BuscarSkuProveedor(ByVal model As Proveedor, ByVal paginacion As Paginacion, ByRef rowCount As Integer) As List(Of Producto)
        Dim lista = New List(Of Producto)
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.Usp_Sel_ProductoPaginacion)
        oDatabase.AddInParameter(oDbCommand, "@IdProveedor", DbType.Int32, model.IdProveedor)
        oDatabase.AddInParameter(oDbCommand, "@Sku", DbType.String, model.Sku)

        oDatabase.AddInParameter(oDbCommand, "@rowsPerPage", DbType.Int32, paginacion.RowsPerPage)
        oDatabase.AddInParameter(oDbCommand, "@page", DbType.Int32, paginacion.Page)
        oDatabase.AddInParameter(oDbCommand, "@sortDir", DbType.String, paginacion.SortBy)
        oDatabase.AddInParameter(oDbCommand, "@sortType", DbType.String, paginacion.SortType)
        oDatabase.AddOutParameter(oDbCommand, "@rowCount", DbType.Int32, 10)

        oDbCommand.CommandTimeout = 120000

        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            While oIDataReader.Read()
                Dim obj As Producto = New Producto()
                obj.Item = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(oIDataReader.GetOrdinal("Item")))
                obj.Sku = DataUtil.DbValueToDefault(Of String)(oIDataReader(oIDataReader.GetOrdinal("Sku")))
                obj.Descripcion = DataUtil.DbValueToDefault(Of String)(oIDataReader(oIDataReader.GetOrdinal("Descripcion")))
                obj.Estado = DataUtil.DbValueToDefault(Of Boolean)(oIDataReader(oIDataReader.GetOrdinal("Activo")))
                lista.Add(obj)
            End While
        End Using
        rowCount = Convert.ToInt32(oDatabase.GetParameterValue(oDbCommand, "@RowCount"))
        Return lista
    End Function

    Function ActualizaEstadoSkuProv(Sku As String, IdProv As Integer, Estado As Boolean) As Object
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.Usp_UpdEst_ProveedorSku)
        oDatabase.AddInParameter(oDbCommand, "@IdProveedor", DbType.Int32, IdProv)
        oDatabase.AddInParameter(oDbCommand, "@Sku", DbType.String, Sku)
        oDatabase.AddInParameter(oDbCommand, "@Estado", DbType.Boolean, Estado)
        Return Integer.Parse(oDatabase.ExecuteScalar(oDbCommand))
    End Function

    Function ListarProductosSeleccionar(producto As Producto, proveedor As Proveedor, paginacion As Paginacion, rowCount As Integer) As List(Of Producto)
        Dim lista = New List(Of Producto)
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.Usp_Sel_ProductoSeleccionar)
        oDatabase.AddInParameter(oDbCommand, "@IdProveedor", DbType.Int32, proveedor.IdProveedor)
        oDatabase.AddInParameter(oDbCommand, "@Sku", DbType.String, producto.Sku)
        oDatabase.AddInParameter(oDbCommand, "@Descripcion", DbType.String, producto.Descripcion)

        oDatabase.AddInParameter(oDbCommand, "@rowsPerPage", DbType.Int32, paginacion.RowsPerPage)
        oDatabase.AddInParameter(oDbCommand, "@page", DbType.Int32, paginacion.Page)
        oDatabase.AddInParameter(oDbCommand, "@sortDir", DbType.String, paginacion.SortBy)
        oDatabase.AddInParameter(oDbCommand, "@sortType", DbType.String, paginacion.SortType)
        oDatabase.AddOutParameter(oDbCommand, "@rowCount", DbType.Int32, 10)

        oDbCommand.CommandTimeout = 120000

        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            While oIDataReader.Read()
                Dim obj As Producto = New Producto()
                obj.Sku = DataUtil.DbValueToDefault(Of String)(oIDataReader(oIDataReader.GetOrdinal("Sku"))).Trim()
                obj.Descripcion = DataUtil.DbValueToDefault(Of String)(oIDataReader(oIDataReader.GetOrdinal("Descripcion")))
                obj.Estado = DataUtil.DbValueToDefault(Of Boolean)(oIDataReader(oIDataReader.GetOrdinal("Activo")))
                lista.Add(obj)
            End While
        End Using
        rowCount = Convert.ToInt32(oDatabase.GetParameterValue(oDbCommand, "@RowCount"))
        Return lista
    End Function

    Function InsertarProveedorSku(Sku As String, IdProv As Integer) As Object
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.Usp_Ins_ProveedorSku)
        oDatabase.AddInParameter(oDbCommand, "@IdProveedor", DbType.Int32, IdProv)
        oDatabase.AddInParameter(oDbCommand, "@Sku", DbType.String, Sku)
        Return Integer.Parse(oDatabase.ExecuteScalar(oDbCommand))
    End Function

    Public Function BuscarFeriados(ByVal feriados As Feriados, ByVal paginacion As Paginacion, ByRef rowCount As Integer) As List(Of Feriados)
        Dim lista = New List(Of Feriados)

        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.Usp_Sel_FeriadoPaginacion)
        oDatabase.AddInParameter(oDbCommand, "@IdFeriado", DbType.Int32, feriados.IdFeriado)
        oDatabase.AddInParameter(oDbCommand, "@BusqMes", DbType.String, If(feriados.BusqMes = Nothing, String.Empty, feriados.BusqMes))
        oDatabase.AddInParameter(oDbCommand, "@BusqAnio", DbType.String, If(feriados.BusqModalidad = Nothing, String.Empty, feriados.BusqModalidad))
        oDatabase.AddInParameter(oDbCommand, "@BusqEstado", DbType.String, If(feriados.BusqEstado = Nothing, String.Empty, feriados.BusqEstado))

        oDatabase.AddInParameter(oDbCommand, "@rowsPerPage", DbType.Int32, paginacion.RowsPerPage)
        oDatabase.AddInParameter(oDbCommand, "@page", DbType.Int32, paginacion.Page)
        oDatabase.AddInParameter(oDbCommand, "@sortDir", DbType.String, paginacion.SortBy)
        oDatabase.AddInParameter(oDbCommand, "@sortType", DbType.String, paginacion.SortType)
        oDatabase.AddOutParameter(oDbCommand, "@rowCount", DbType.Int32, 10)

        oDbCommand.CommandTimeout = 120000

        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            While oIDataReader.Read()
                Dim obj As Feriados = New Feriados()
                obj.IdFeriado = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(oIDataReader.GetOrdinal("IdFeriado")))
                obj.Mes = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(oIDataReader.GetOrdinal("Mes")))
                obj.NombreMes = DataUtil.DbValueToDefault(Of String)(oIDataReader(oIDataReader.GetOrdinal("nombreMes")))
                obj.Dia = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(oIDataReader.GetOrdinal("dia")))
                obj.Anio = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(oIDataReader.GetOrdinal("anio")))
                obj.DescripcionAnio = DataUtil.DbValueToDefault(Of String)(oIDataReader(oIDataReader.GetOrdinal("descripcionAnio")))
                obj.Descripcion = DataUtil.DbValueToDefault(Of String)(oIDataReader(oIDataReader.GetOrdinal("descripcion")))
                obj.Activo = DataUtil.DbValueToDefault(Of Boolean)(oIDataReader(oIDataReader.GetOrdinal("activo")))
                lista.Add(obj)
            End While
        End Using
        rowCount = Convert.ToInt32(oDatabase.GetParameterValue(oDbCommand, "@RowCount"))
        Return lista
    End Function

    Function InsertarFeriados(feriado As Feriados) As Integer
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.Usp_Ins_Feriado)
        oDatabase.AddInParameter(oDbCommand, "@Mes", DbType.Int32, feriado.Mes)
        oDatabase.AddInParameter(oDbCommand, "@dia", DbType.Int32, feriado.Dia)
        oDatabase.AddInParameter(oDbCommand, "@anio", DbType.Int32, feriado.Anio)
        oDatabase.AddInParameter(oDbCommand, "@descripcion", DbType.String, feriado.Descripcion)

        Return Integer.Parse(oDatabase.ExecuteScalar(oDbCommand))
    End Function

    Function GetFeriado(Id As Integer) As Feriados
        Dim obj = New Feriados
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.Usp_Sel_Feriado)
        oDatabase.AddInParameter(oDbCommand, "@IdFeriado", DbType.Int32, Id)
        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            While oIDataReader.Read()
                obj.IdFeriado = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(oIDataReader.GetOrdinal("IdFeriado")))
                obj.Mes = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(oIDataReader.GetOrdinal("Mes")))
                obj.NombreMes = DataUtil.DbValueToDefault(Of String)(oIDataReader(oIDataReader.GetOrdinal("nombreMes")))
                obj.Dia = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(oIDataReader.GetOrdinal("dia")))
                obj.Anio = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(oIDataReader.GetOrdinal("anio")))
                obj.DescripcionAnio = DataUtil.DbValueToDefault(Of String)(oIDataReader(oIDataReader.GetOrdinal("descripcionAnio")))
                obj.Descripcion = DataUtil.DbValueToDefault(Of String)(oIDataReader(oIDataReader.GetOrdinal("descripcion")))
                obj.Activo = DataUtil.DbValueToDefault(Of Boolean)(oIDataReader(oIDataReader.GetOrdinal("activo")))
            End While
        End Using
        Return obj
    End Function

    Function ActualizarFeriado(feriado As Feriados) As Integer
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.Usp_Upd_Feriado)
        oDatabase.AddInParameter(oDbCommand, "@IdFeriado", DbType.Int32, feriado.IdFeriado)
        oDatabase.AddInParameter(oDbCommand, "@Mes", DbType.Int32, feriado.Mes)
        oDatabase.AddInParameter(oDbCommand, "@dia", DbType.Int32, feriado.Dia)
        oDatabase.AddInParameter(oDbCommand, "@anio", DbType.Int32, feriado.Anio)
        oDatabase.AddInParameter(oDbCommand, "@descripcion", DbType.String, feriado.Descripcion)
        Return Integer.Parse(oDatabase.ExecuteScalar(oDbCommand))
    End Function

    Function ActualizarFeriadoEstado(feriado As Feriados) As Integer
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.Usp_UpdEst_Feriado)
        oDatabase.AddInParameter(oDbCommand, "@IdFeriado", DbType.Int32, feriado.IdFeriado)
        oDatabase.AddInParameter(oDbCommand, "@activo", DbType.Boolean, feriado.Activo)
        Return Integer.Parse(oDatabase.ExecuteScalar(oDbCommand))
    End Function

#Region "Mantenimiento Cierre"

    Function RegistrarCierre(cierre As Cierre) As Integer
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.Usp_Registrar_Cierre)
        oDatabase.AddInParameter(oDbCommand, "@Año", DbType.Int32, cierre.Año)
        oDatabase.AddInParameter(oDbCommand, "@Mes", DbType.Int32, cierre.Mes)
        oDatabase.AddInParameter(oDbCommand, "@Fecha_Cierre", DbType.DateTime, cierre.FechaCierre)
        oDatabase.AddInParameter(oDbCommand, "@UsuarioRegistro", DbType.String, cierre.UsuarioRegistro)
        oDatabase.AddInParameter(oDbCommand, "@UsuarioEdicion", DbType.String, cierre.UsuarioUpdate)

        Return Integer.Parse(oDatabase.ExecuteScalar(oDbCommand))
    End Function

    Public Function BuscarCierre(ByVal cierre As Cierre, ByVal paginacion As Paginacion, ByRef rowCount As Integer) As List(Of Cierre)
        Dim lista = New List(Of Cierre)

        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.Usp_Buscar_CierrePaginacion)
        oDatabase.AddInParameter(oDbCommand, "@Mes", DbType.Int32, cierre.Mes)
        oDatabase.AddInParameter(oDbCommand, "@Anio", DbType.String, cierre.Año)
        oDatabase.AddInParameter(oDbCommand, "@FechaCierre", DbType.String, If(cierre.FechaCierre = "#12:00:00 AM#", String.Empty, cierre.FechaCierre))

        oDatabase.AddInParameter(oDbCommand, "@rowsPerPage", DbType.Int32, paginacion.RowsPerPage)
        oDatabase.AddInParameter(oDbCommand, "@page", DbType.Int32, paginacion.Page)
        oDatabase.AddInParameter(oDbCommand, "@sortDir", DbType.String, paginacion.SortBy)
        oDatabase.AddInParameter(oDbCommand, "@sortType", DbType.String, paginacion.SortType)
        oDatabase.AddOutParameter(oDbCommand, "@rowCount", DbType.Int32, 10)

        oDbCommand.CommandTimeout = 120000

        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            While oIDataReader.Read()
                Dim obj As Cierre = New Cierre()
                obj.IdCierre = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(oIDataReader.GetOrdinal("Id_Cierre")))
                obj.Año = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(oIDataReader.GetOrdinal("Año")))
                obj.Mes = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(oIDataReader.GetOrdinal("Mes")))
                obj.NombreMes = DataUtil.DbValueToDefault(Of String)(oIDataReader(oIDataReader.GetOrdinal("NombreMes")))
                obj.FechaCierre = DataUtil.DbValueToDefault(Of String)(oIDataReader(oIDataReader.GetOrdinal("Fecha_Cierre")))
                obj.Estado = DataUtil.DbValueToDefault(Of String)(oIDataReader(oIDataReader.GetOrdinal("Estado")))
                lista.Add(obj)
            End While
        End Using
        rowCount = Convert.ToInt32(oDatabase.GetParameterValue(oDbCommand, "@RowCount"))
        Return lista
    End Function

    Public Function EliminarCierre(idCierre As Integer) As Cierre
        Dim _model = New Cierre
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.Usp_Eliminar_Cierre)
        oDatabase.AddInParameter(oDbCommand, "@ID_CIERRE", DbType.Int32, idCierre)
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            While oIDataReader.Read()
                _model.Cont = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(oIDataReader.GetOrdinal("Cont")))
                _model.Msg = DataUtil.DbValueToDefault(Of String)(oIDataReader(oIDataReader.GetOrdinal("Msg")))
            End While
        End Using
        Return _model
    End Function
#End Region

#Region "Mantenimiento Cotizacion - DescuentoFamilia"
    Function ListarFamilia_Combo() As ListaFamilia
        Dim oListaFamilia As New ListaFamilia()
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_FAMILIACBO)
        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim indiceCodigoFamilia As Integer = oIDataReader.GetOrdinal("CodigoFamilia")
            Dim indiceNombreFamilia As Integer = oIDataReader.GetOrdinal("NombreFamilia")
            While oIDataReader.Read()
                Dim oFamilia = New Familia With {
                    .CodigoFamilia = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceCodigoFamilia)),
                    .NombreFamilia = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceNombreFamilia))
                }
                oListaFamilia.Add(oFamilia)
            End While
        End Using
        Return oListaFamilia
    End Function

    Function ListarDescuentoFamilia(oPaginacion As Paginacion) As Paginacion
        oPaginacion.ListaDescuentoFamilia = New ListaDescuentoFamilia()

        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_BUSCADESCUENTOFAMILIA)

        oDatabase.AddInParameter(oDbCommand, "@CodigoFamilia", DbType.String, oPaginacion.DescuentoFamilia.CodigoFamilia)
        oDatabase.AddInParameter(oDbCommand, "@PageSize", DbType.Int32, oPaginacion.PageSize)
        oDatabase.AddInParameter(oDbCommand, "@PageNumber", DbType.Int32, oPaginacion.PageNumber)
        oDatabase.AddInParameter(oDbCommand, "@SortBy", DbType.String, oPaginacion.SortBy)
        oDatabase.AddInParameter(oDbCommand, "@SortType", DbType.String, oPaginacion.SortType)
        oDatabase.AddOutParameter(oDbCommand, "@TotalRows", DbType.Int32, 10)
        oDbCommand.CommandTimeout = 120000

        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim indiceCodigoFamilia As Integer = oIDataReader.GetOrdinal("CodigoFamilia")
            Dim indiceNombreFamilia As Integer = oIDataReader.GetOrdinal("NombreFamilia")
            Dim indiceMargenDscto As Integer = oIDataReader.GetOrdinal("MargenDscto")
            Dim indiceDescuento As Integer = oIDataReader.GetOrdinal("Descuento")

            While oIDataReader.Read()
                oPaginacion.DescuentoFamilia = New DescuentoFamilia With {
                    .CodigoFamilia = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceCodigoFamilia)),
                    .NombreFamilia = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceNombreFamilia)),
                    .MargenDscto = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(indiceMargenDscto)),
                    .Descuento = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(indiceDescuento))
                }
                oPaginacion.ListaDescuentoFamilia.Add(oPaginacion.DescuentoFamilia)
            End While
        End Using
        oPaginacion.TotalRows = Convert.ToInt32(oDatabase.GetParameterValue(oDbCommand, "@TotalRows"))
        Return oPaginacion
    End Function

    Function EliminarDescuentoFamilia(codigoFamilia As String) As Integer
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_DESACTIVAR_DESCUENTOFAMILIA)
        oDatabase.AddInParameter(oDbCommand, "@CodigoFamilia", DbType.String, codigoFamilia)
        Dim result = Integer.Parse(oDatabase.ExecuteScalar(oDbCommand))
        Return result
    End Function

    Function GestionarDescuentoFamilia(oDescuentoFamilia As DescuentoFamilia) As Integer
        Dim result As Integer = -1
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_GESTIONAR_DESCUENTOFAMILIA)

        oDatabase.AddInParameter(oDbCommand, "@CodigoFamilia", DbType.String, oDescuentoFamilia.CodigoFamilia)
        oDatabase.AddInParameter(oDbCommand, "@MargenDscto", DbType.Decimal, oDescuentoFamilia.MargenDscto)
        oDatabase.AddInParameter(oDbCommand, "@Descuento", DbType.Decimal, oDescuentoFamilia.Descuento)
        result = oDatabase.ExecuteScalar(oDbCommand)
        Return result
    End Function
#End Region

#Region "Mantenimiento Cotizacion - DescuentoSku"

    Function ListarDescuentoSku(oPaginacion As Paginacion) As Paginacion
        oPaginacion.ListaDescuentoSku = New ListaDescuentoSku()

        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_BUSCADESCUENTOSKU)

        oDatabase.AddInParameter(oDbCommand, "@CodigoSku", DbType.String, oPaginacion.DescuentoSku.CodigoSku)
        oDatabase.AddInParameter(oDbCommand, "@PageSize", DbType.Int32, oPaginacion.PageSize)
        oDatabase.AddInParameter(oDbCommand, "@PageNumber", DbType.Int32, oPaginacion.PageNumber)
        oDatabase.AddInParameter(oDbCommand, "@SortBy", DbType.String, oPaginacion.SortBy)
        oDatabase.AddInParameter(oDbCommand, "@SortType", DbType.String, oPaginacion.SortType)
        oDatabase.AddOutParameter(oDbCommand, "@TotalRows", DbType.Int32, 10)
        oDbCommand.CommandTimeout = 120000

        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim indiceIdDescuentoSku As Integer = oIDataReader.GetOrdinal("IdDescuentoSku")
            Dim indiceCodigoSku As Integer = oIDataReader.GetOrdinal("CodigoSku")
            Dim indiceNombreSku As Integer = oIDataReader.GetOrdinal("NombreSku")
            Dim indiceCantidadDesde As Integer = oIDataReader.GetOrdinal("CantidadDesde")
            Dim indiceCantidadHasta As Integer = oIDataReader.GetOrdinal("CantidadHasta")
            Dim indiceMargenDscto As Integer = oIDataReader.GetOrdinal("MargenDscto")
            Dim indiceDescuento As Integer = oIDataReader.GetOrdinal("Descuento")

            While oIDataReader.Read()
                oPaginacion.DescuentoSku = New DescuentoSku With {
                    .IdDescuentoSku = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indiceIdDescuentoSku)),
                    .CodigoSku = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceCodigoSku)),
                    .NombreSku = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceNombreSku)),
                    .CantidadDesde = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(indiceCantidadDesde)),
                    .CantidadHasta = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(indiceCantidadHasta)),
                    .MargenDscto = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(indiceMargenDscto)),
                    .Descuento = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(indiceDescuento))
                }
                oPaginacion.ListaDescuentoSku.Add(oPaginacion.DescuentoSku)
            End While
        End Using
        oPaginacion.TotalRows = Convert.ToInt32(oDatabase.GetParameterValue(oDbCommand, "@TotalRows"))
        Return oPaginacion
    End Function

    Function EliminarDescuentoSku(codigoSku As Integer) As Integer
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_DESACTIVAR_DESCUENTOSKU)
        oDatabase.AddInParameter(oDbCommand, "@IdDescuentoSku", DbType.Int32, codigoSku)
        Dim result = Integer.Parse(oDatabase.ExecuteScalar(oDbCommand))
        Return result
    End Function

    Function GestionarDescuentoSku(oDescuentoSku As DescuentoSku) As Integer
        Dim result As Integer = -1
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_GESTIONAR_DESCUENTOSKU)

        oDatabase.AddInParameter(oDbCommand, "@CodigoSku", DbType.String, oDescuentoSku.CodigoSku)
        oDatabase.AddInParameter(oDbCommand, "@CantidadDesde", DbType.Decimal, oDescuentoSku.CantidadDesde)
        oDatabase.AddInParameter(oDbCommand, "@CantidadHasta", DbType.Decimal, oDescuentoSku.CantidadHasta)
        oDatabase.AddInParameter(oDbCommand, "@MargenDscto", DbType.Decimal, oDescuentoSku.MargenDscto)
        oDatabase.AddInParameter(oDbCommand, "@Descuento", DbType.Decimal, oDescuentoSku.Descuento)
        result = oDatabase.ExecuteScalar(oDbCommand)
        Return result
    End Function

    Function ValidaExiteSku(codigoSku As String) As Integer
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_VALIDA_EXISTESKU)
        oDatabase.AddInParameter(oDbCommand, "@Sku", DbType.String, codigoSku)
        Dim result = Integer.Parse(oDatabase.ExecuteScalar(oDbCommand))
        Return result
    End Function
#End Region

#Region "Mantenimiento Cotizacion - Uxpos"
    Function ListarMarca_Combo() As ListaMarca
        Dim oListaMarca As New ListaMarca()
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_MARCACBO)
        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim indiceIdMarca As Integer = oIDataReader.GetOrdinal("IdMarca")
            Dim indiceNomMarca As Integer = oIDataReader.GetOrdinal("NomMarca")
            While oIDataReader.Read()
                Dim oMarca = New Marca With {
                        .IdMarca = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indiceIdMarca)),
                        .NomMarca = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceNomMarca))
                        }
                oListaMarca.Add(oMarca)
            End While
        End Using
        Return oListaMarca
    End Function

    Function ListarEmpleadoxPerfil_Combo(perfil As String) As ListaEmpleado
        Dim oListaEmpleado As New ListaEmpleado()
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_EMPLEADOXPERFILCBO)
        oDatabase.AddInParameter(oDbCommand, "@Perfil", DbType.String, perfil)
        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim indiceIdEmpleado As Integer = oIDataReader.GetOrdinal("IdEmpleado")
            Dim indiceNombresApellidos As Integer = oIDataReader.GetOrdinal("NombresApellidos")
            While oIDataReader.Read()
                Dim oEmpleado = New Empleado() With {
                        .IdEmpleado = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indiceIdEmpleado)),
                        .NombresApellidos = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceNombresApellidos))
                        }
                oListaEmpleado.Add(oEmpleado)
            End While
        End Using
        Return oListaEmpleado
    End Function

    Function ListaCotizacion(oPaginacion As Paginacion) As Paginacion
        oPaginacion.ListaCotizacion = New ListaCotizacion()

        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_BUSCACOTIZACION)

        oDatabase.AddInParameter(oDbCommand, "@IdMarca", DbType.Int32, oPaginacion.BusquedaCotizacion.Marca)
        oDatabase.AddInParameter(oDbCommand, "@IdSucursal", DbType.Int32, oPaginacion.BusquedaCotizacion.Sucursal)
        oDatabase.AddInParameter(oDbCommand, "@FechaIni", DbType.String, oPaginacion.BusquedaCotizacion.FechaIni)
        oDatabase.AddInParameter(oDbCommand, "@FechaFin", DbType.String, oPaginacion.BusquedaCotizacion.FechaFin)
        oDatabase.AddInParameter(oDbCommand, "@RucRazSoc", DbType.String, oPaginacion.BusquedaCotizacion.RucRazSoc)
        oDatabase.AddInParameter(oDbCommand, "@SubGerente", DbType.Int32, oPaginacion.BusquedaCotizacion.SubGerente)
        oDatabase.AddInParameter(oDbCommand, "@JefeRegional", DbType.Int32, oPaginacion.BusquedaCotizacion.JefeRegional)
        oDatabase.AddInParameter(oDbCommand, "@CodOfisisEmpleado", DbType.String, oPaginacion.BusquedaCotizacion.OfisisEmpleado)
        oDatabase.AddInParameter(oDbCommand, "@CodigoFamilia", DbType.String, oPaginacion.BusquedaCotizacion.CodigoFamilia)
        oDatabase.AddInParameter(oDbCommand, "@SkuProducto", DbType.String, oPaginacion.BusquedaCotizacion.SkuProducto)
        oDatabase.AddInParameter(oDbCommand, "@NroCotizacion", DbType.Int32, oPaginacion.BusquedaCotizacion.NroCotizacion)
        oDatabase.AddInParameter(oDbCommand, "@EsPreProforma", DbType.Int32, oPaginacion.BusquedaCotizacion.EsPreProforma)
        oDatabase.AddInParameter(oDbCommand, "@Usuario", DbType.String, oPaginacion.BusquedaCotizacion.Usuario)
        oDatabase.AddInParameter(oDbCommand, "@PageSize", DbType.Int32, oPaginacion.PageSize)
        oDatabase.AddInParameter(oDbCommand, "@PageNumber", DbType.Int32, oPaginacion.PageNumber)
        oDatabase.AddInParameter(oDbCommand, "@SortBy", DbType.String, oPaginacion.SortBy)
        oDatabase.AddInParameter(oDbCommand, "@SortType", DbType.String, oPaginacion.SortType)
        oDatabase.AddOutParameter(oDbCommand, "@TotalRows", DbType.Int32, 10)
        oDbCommand.CommandTimeout = 120000

        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim indiceNroCotizacion As Integer = oIDataReader.GetOrdinal("NroCotizacion")
            Dim indiceNroCotizacionUxpos As Integer = oIDataReader.GetOrdinal("NroCotizacionUxpos")
            Dim indiceFecha As Integer = oIDataReader.GetOrdinal("Fecha")
            Dim indiceVendedor As Integer = oIDataReader.GetOrdinal("Vendedor")
            Dim indiceRuc As Integer = oIDataReader.GetOrdinal("Ruc")
            Dim indiceCliente As Integer = oIDataReader.GetOrdinal("Cliente")
            Dim indiceTienda As Integer = oIDataReader.GetOrdinal("Tienda")
            Dim indiceSubTotal As Integer = oIDataReader.GetOrdinal("SubTotal")
            Dim indiceDescuentoTotal As Integer = oIDataReader.GetOrdinal("DescuentoTotal")
            Dim indiceTotalGeneral As Integer = oIDataReader.GetOrdinal("TotalGeneral")
            Dim indiceEsPreProforma As Integer = oIDataReader.GetOrdinal("EsPreProforma")

            While oIDataReader.Read()
                oPaginacion.Cotizacion = New Cotizacion With {
                    .NroCotizacion = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(indiceNroCotizacion)),
                    .NroCotizacionUxpos = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(indiceNroCotizacionUxpos)),
                    .Fecha = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceFecha)),
                    .Vendedor = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceVendedor)),
                    .Ruc = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceRuc)),
                    .Cliente = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceCliente)),
                    .Tienda = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceTienda)),
                    .SubTotal = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(indiceSubTotal)),
                    .DescuentoTotal = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(indiceDescuentoTotal)),
                    .TotalGeneral = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(indiceTotalGeneral)),
                    .EsPreProforma = DataUtil.DbValueToDefault(Of Boolean)(oIDataReader(indiceEsPreProforma))
                }
                oPaginacion.ListaCotizacion.Add(oPaginacion.Cotizacion)
            End While
        End Using
        oPaginacion.TotalRows = Convert.ToInt32(oDatabase.GetParameterValue(oDbCommand, "@TotalRows"))
        Return oPaginacion
    End Function

    Function GestionarCotizacion(oCotizacion As Cotizacion) As Integer
        Dim result As Integer = -1
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_GESTIONAR_COTIZACION)

        oDatabase.AddInParameter(oDbCommand, "@NroCotizacion", DbType.Int32, oCotizacion.NroCotizacion)
        oDatabase.AddInParameter(oDbCommand, "@NroCotizacionUxpos", DbType.Int32, oCotizacion.NroCotizacionUxpos)
        result = oDatabase.ExecuteScalar(oDbCommand)
        Return result
    End Function

    Function ListaDetalleCotizacion(oPaginacion As Paginacion) As Paginacion
        oPaginacion.ListaDetalleCotizacion = New ListaDetalleCotizacion()

        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_BUSCADETALLECOTIZACION)

        oDatabase.AddInParameter(oDbCommand, "@NroCotizacion", DbType.Int32, oPaginacion.DetalleCotizacion.NroCotizacion)
        oDatabase.AddInParameter(oDbCommand, "@PageSize", DbType.Int32, oPaginacion.PageSize)
        oDatabase.AddInParameter(oDbCommand, "@PageNumber", DbType.Int32, oPaginacion.PageNumber)
        oDatabase.AddInParameter(oDbCommand, "@SortBy", DbType.String, oPaginacion.SortBy)
        oDatabase.AddInParameter(oDbCommand, "@SortType", DbType.String, oPaginacion.SortType)
        oDatabase.AddOutParameter(oDbCommand, "@TotalRows", DbType.Int32, 10)
        oDbCommand.CommandTimeout = 120000

        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim indiceNroCotizacion As Integer = oIDataReader.GetOrdinal("NroCotizacion")
            Dim indiceSku As Integer = oIDataReader.GetOrdinal("Sku")
            Dim indiceProducto As Integer = oIDataReader.GetOrdinal("Producto")
            Dim indicePrecioTienda As Integer = oIDataReader.GetOrdinal("PrecioTienda")
            Dim indicePrecioVolumen As Integer = oIDataReader.GetOrdinal("PrecioVolumen")
            Dim indicePrecioSinIgv As Integer = oIDataReader.GetOrdinal("PrecioSinIgv")
            Dim indiceCantidad As Integer = oIDataReader.GetOrdinal("Cantidad")
            Dim indiceTotal As Integer = oIDataReader.GetOrdinal("Total")

            While oIDataReader.Read()
                oPaginacion.DetalleCotizacion = New DetalleCotizacion With {
                    .NroCotizacion = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(indiceNroCotizacion)),
                    .Sku = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceSku)),
                    .Producto = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceProducto)),
                    .PrecioTienda = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(indicePrecioTienda)),
                    .PrecioVolumen = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(indicePrecioVolumen)),
                    .PrecioSinIgv = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(indicePrecioSinIgv)),
                    .Cantidad = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(indiceCantidad)),
                    .Total = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(indiceTotal))
                }
                oPaginacion.ListaDetalleCotizacion.Add(oPaginacion.DetalleCotizacion)
            End While
        End Using
        oPaginacion.TotalRows = Convert.ToInt32(oDatabase.GetParameterValue(oDbCommand, "@TotalRows"))
        Return oPaginacion
    End Function

    Function ListarSucursalControl(idMarca As Integer) As ListaSucursal
        Dim oListaSucursal As New ListaSucursal()
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_LISTASUCURSALES_XMARCA)
        oDatabase.AddInParameter(oDbCommand, "@IdMarca", DbType.Int32, idMarca)
        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim oSucursal As New Sucursal()
            Dim idsucursal As Integer = oIDataReader.GetOrdinal("IdSucursal")
            Dim descripcion As Integer = oIDataReader.GetOrdinal("Descripcion")
            While oIDataReader.Read()
                oSucursal = New Sucursal()
                oSucursal.IdSucursal = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(idsucursal))
                oSucursal.DescripcionSucursal = DataUtil.DbValueToDefault(Of String)(oIDataReader(descripcion))
                oListaSucursal.Add(oSucursal)
            End While
        End Using
        Return oListaSucursal
    End Function

    Function ListaReporteCotizacion(oBusquedaCotizacion As BusquedaCotizacion) As List(Of ReporteCotizacion)
        Dim reporteCotizacions = New List(Of ReporteCotizacion)

        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_REPORTECOTIZACION)

        oDatabase.AddInParameter(oDbCommand, "@IdMarca", DbType.Int32, oBusquedaCotizacion.Marca)
        oDatabase.AddInParameter(oDbCommand, "@IdSucursal", DbType.Int32, oBusquedaCotizacion.Sucursal)
        oDatabase.AddInParameter(oDbCommand, "@FechaIni", DbType.String, oBusquedaCotizacion.FechaIni)
        oDatabase.AddInParameter(oDbCommand, "@FechaFin", DbType.String, oBusquedaCotizacion.FechaFin)
        oDatabase.AddInParameter(oDbCommand, "@RucRazSoc", DbType.String, oBusquedaCotizacion.RucRazSoc)
        oDatabase.AddInParameter(oDbCommand, "@SubGerente", DbType.Int32, oBusquedaCotizacion.SubGerente)
        oDatabase.AddInParameter(oDbCommand, "@JefeRegional", DbType.Int32, oBusquedaCotizacion.JefeRegional)
        oDatabase.AddInParameter(oDbCommand, "@CodOfisisEmpleado", DbType.String, oBusquedaCotizacion.OfisisEmpleado)
        oDatabase.AddInParameter(oDbCommand, "@CodigoFamilia", DbType.String, oBusquedaCotizacion.CodigoFamilia)
        oDatabase.AddInParameter(oDbCommand, "@SkuProducto", DbType.String, oBusquedaCotizacion.SkuProducto)
        oDatabase.AddInParameter(oDbCommand, "@NroCotizacion", DbType.Int32, oBusquedaCotizacion.NroCotizacion)
        oDatabase.AddInParameter(oDbCommand, "@EsPreProforma", DbType.Int32, oBusquedaCotizacion.EsPreProforma)
        oDatabase.AddInParameter(oDbCommand, "@Usuario", DbType.String, oBusquedaCotizacion.Usuario)
        oDbCommand.CommandTimeout = 120000

        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim indiceNroCotizacion As Integer = oIDataReader.GetOrdinal("NroCotizacion")
            Dim indiceNroCotizacionUxpos As Integer = oIDataReader.GetOrdinal("NroCotizacionUxpos")
            Dim indiceFecha As Integer = oIDataReader.GetOrdinal("Fecha")
            Dim indiceVendedor As Integer = oIDataReader.GetOrdinal("Vendedor")
            Dim indiceRuc As Integer = oIDataReader.GetOrdinal("Ruc")
            Dim indiceCliente As Integer = oIDataReader.GetOrdinal("Cliente")
            Dim indiceCcosto As Integer = oIDataReader.GetOrdinal("Ccosto")
            Dim indiceTienda As Integer = oIDataReader.GetOrdinal("Tienda")
            Dim indiceSku As Integer = oIDataReader.GetOrdinal("Sku")
            Dim indiceProducto As Integer = oIDataReader.GetOrdinal("Producto")
            Dim indicePrecioTienda As Integer = oIDataReader.GetOrdinal("PrecioTienda")
            Dim indicePrecioVvEe As Integer = oIDataReader.GetOrdinal("PrecioVvEe")
            Dim indicePrecioVvEeSinIgv As Integer = oIDataReader.GetOrdinal("PrecioVvEeSinIgv")
            Dim indiceCantidad As Integer = oIDataReader.GetOrdinal("Cantidad")
            Dim indiceTotal As Integer = oIDataReader.GetOrdinal("Total")
            Dim indiceEsPreProforma As Integer = oIDataReader.GetOrdinal("EsPreProforma")

            While oIDataReader.Read()
                Dim reporteCotizacion = New ReporteCotizacion With {
                        .NroCotizacion = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(indiceNroCotizacion)),
                        .NroCotizacionUxpos = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(indiceNroCotizacionUxpos)),
                        .Fecha = DataUtil.DbValueToDefault(Of DateTime)(oIDataReader(indiceFecha)),
                        .Vendedor = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceVendedor)),
                        .Ruc = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceRuc)),
                        .Cliente = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceCliente)),
                        .Ccosto = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceCcosto)),
                        .Tienda = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceTienda)),
                        .Sku = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceSku)),
                        .Producto = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceProducto)),
                        .PrecioTienda = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(indicePrecioTienda)),
                        .PrecioVvEe = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(indicePrecioVvEe)),
                        .PrecioVvEeSinIgv = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(indicePrecioVvEeSinIgv)),
                        .Cantidad = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(indiceCantidad)),
                        .Total = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(indiceTotal)),
                        .EsPreProforma = DataUtil.DbValueToDefault(Of Boolean)(oIDataReader(indiceEsPreProforma))
                }
                reporteCotizacions.Add(reporteCotizacion)
            End While
        End Using

        Return reporteCotizacions
    End Function
#End Region

#Region "Mantenimiento Cotizacion - Productos Bloqueados"
    Function ListarSkuBloqueados(oPaginacion As Paginacion) As Paginacion
        oPaginacion.ListaProducto = New ListaProducto()

        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_BUSCASKUBLOQUEADOS)

        oDatabase.AddInParameter(oDbCommand, "@CodigoSku", DbType.String, oPaginacion.Producto.Sku)
        oDatabase.AddInParameter(oDbCommand, "@PageSize", DbType.Int32, oPaginacion.PageSize)
        oDatabase.AddInParameter(oDbCommand, "@PageNumber", DbType.Int32, oPaginacion.PageNumber)
        oDatabase.AddInParameter(oDbCommand, "@SortBy", DbType.String, oPaginacion.SortBy)
        oDatabase.AddInParameter(oDbCommand, "@SortType", DbType.String, oPaginacion.SortType)
        oDatabase.AddOutParameter(oDbCommand, "@TotalRows", DbType.Int32, 10)
        oDbCommand.CommandTimeout = 120000

        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim indiceCodigoSku As Integer = oIDataReader.GetOrdinal("CodigoSku")
            Dim indiceNombreSku As Integer = oIDataReader.GetOrdinal("NombreSku")

            While oIDataReader.Read()
                oPaginacion.Producto = New Producto With {
                    .Sku = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceCodigoSku)),
                    .Descripcion = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceNombreSku))
                }
                oPaginacion.ListaProducto.Add(oPaginacion.Producto)
            End While
        End Using
        oPaginacion.TotalRows = Convert.ToInt32(oDatabase.GetParameterValue(oDbCommand, "@TotalRows"))
        Return oPaginacion
    End Function

    Function EliminarSkuBloqueado(codigoSku As String) As Integer
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_DESACTIVAR_SKUBLOQUEADO)
        oDatabase.AddInParameter(oDbCommand, "@CodigoSku", DbType.String, codigoSku)
        Dim result = Integer.Parse(oDatabase.ExecuteScalar(oDbCommand))
        Return result
    End Function

    Function GestionarSkuBloqueado(oProducto As Producto) As Integer
        Dim result As Integer = -1
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_GESTIONAR_SKUBLOQUEADO)

        oDatabase.AddInParameter(oDbCommand, "@CodigoSku", DbType.String, oProducto.Sku)
        result = oDatabase.ExecuteScalar(oDbCommand)
        Return result
    End Function
#End Region

#Region "Plan Ventas por Tipo Representante - SOD13068"

    Function ListarTipoRepresentanteVenta() As ListaTipoRepresentanteVenta
        Dim oListaTipoRepresentanteVenta As New ListaTipoRepresentanteVenta()
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.Usp_ListarTipoRepresentanteVenta)
        oDbCommand.CommandTimeout = 120000

        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim iIdTipoRepVen As Integer = oIDataReader.GetOrdinal("IdTipoRepVen")
            Dim iNombreTipoRepVen As Integer = oIDataReader.GetOrdinal("NombreTipoRepVen")

            Dim oTipoRepresentanteVenta = New TipoRepresentanteVenta()
            While oIDataReader.Read()
                oTipoRepresentanteVenta = New TipoRepresentanteVenta()
                oTipoRepresentanteVenta.IdTipoRepVen = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(iIdTipoRepVen))
                oTipoRepresentanteVenta.NombreTipoRepVen = DataUtil.DbValueToDefault(Of String)(oIDataReader(iNombreTipoRepVen))
                oListaTipoRepresentanteVenta.Add(oTipoRepresentanteVenta)
            End While
        End Using
        Return oListaTipoRepresentanteVenta
    End Function

    Function ListarMesPlan() As ListaMesPlan
        Dim oListaMesPlan As New ListaMesPlan()
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.Usp_ListarMesPlan)
        oDbCommand.CommandTimeout = 120000

        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim iIdMes As Integer = oIDataReader.GetOrdinal("IdMes")
            Dim iOrdenMes As Integer = oIDataReader.GetOrdinal("OrdenMes")

            Dim oMesPlan As New MesPlan()
            While oIDataReader.Read()
                oMesPlan = New MesPlan()
                oMesPlan.IdMes = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(iIdMes))
                oMesPlan.OrdenMes = DataUtil.DbValueToDefault(Of String)(oIDataReader(iOrdenMes))
                oListaMesPlan.Add(oMesPlan)
            End While
        End Using
        Return oListaMesPlan
    End Function

    Function ListarPlanTipoRepresentanteVenta(oPaginacion As Paginacion) As Paginacion
        oPaginacion.ListaPlanTipoRepresentanteVenta = New ListaPlanTipoRepresentanteVenta()
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.Usp_ListarPlanTipoRepresentanteVenta)

        oDatabase.AddInParameter(oDbCommand, "@IdTipoRepVen", DbType.Int32, oPaginacion.PlanTipoRepresentanteVenta.TipoRepresentanteVenta.IdTipoRepVen)
        oDatabase.AddInParameter(oDbCommand, "@IdMes", DbType.Int32, oPaginacion.PlanTipoRepresentanteVenta.MesPlan.IdMes)
        oDatabase.AddInParameter(oDbCommand, "@PageSize", DbType.Int32, oPaginacion.PageSize)
        oDatabase.AddInParameter(oDbCommand, "@PageNumber", DbType.Int32, oPaginacion.PageNumber)
        oDatabase.AddInParameter(oDbCommand, "@SortBy", DbType.String, oPaginacion.SortBy)
        oDatabase.AddInParameter(oDbCommand, "@SortType", DbType.String, oPaginacion.SortType)
        oDatabase.AddOutParameter(oDbCommand, "@TotalRows", DbType.Int32, 10)
        oDbCommand.CommandTimeout = 120000

        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)

            Dim iIdPlanTipoRepVen As Integer = oIDataReader.GetOrdinal("IdPlanTipoRepVen")
            Dim iNombreTipoRepVen As Integer = oIDataReader.GetOrdinal("NombreTipoRepVen")
            Dim iOrdenMes As Integer = oIDataReader.GetOrdinal("OrdenMes")
            Dim iPlan As Integer = oIDataReader.GetOrdinal("Plan")
            Dim iFechaRegistro As Integer = oIDataReader.GetOrdinal("FechaRegistro")

            While oIDataReader.Read()
                oPaginacion.PlanTipoRepresentanteVenta = New PlanTipoRepresentanteVenta()
                oPaginacion.PlanTipoRepresentanteVenta.TipoRepresentanteVenta = New TipoRepresentanteVenta()
                oPaginacion.PlanTipoRepresentanteVenta.MesPlan = New MesPlan()

                oPaginacion.PlanTipoRepresentanteVenta.IdPlanTipoRepVen = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(iIdPlanTipoRepVen))
                oPaginacion.PlanTipoRepresentanteVenta.TipoRepresentanteVenta.NombreTipoRepVen = DataUtil.DbValueToDefault(Of String)(oIDataReader(iNombreTipoRepVen))
                oPaginacion.PlanTipoRepresentanteVenta.MesPlan.OrdenMes = DataUtil.DbValueToDefault(Of String)(oIDataReader(iOrdenMes))
                oPaginacion.PlanTipoRepresentanteVenta.Plan = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(iPlan))
                oPaginacion.PlanTipoRepresentanteVenta.FechaRegistro = DataUtil.DbValueToDefault(Of String)(oIDataReader(iFechaRegistro))
                oPaginacion.ListaPlanTipoRepresentanteVenta.Add(oPaginacion.PlanTipoRepresentanteVenta)
            End While
        End Using
        oPaginacion.TotalRows = Convert.ToInt32(oDatabase.GetParameterValue(oDbCommand, "@TotalRows"))
        Return oPaginacion
    End Function

    Function ObtenerPlanTipoRepresentanteVenta(idPlanTipoRepVen As Integer) As PlanTipoRepresentanteVenta
        Dim oPlanTipoRepresentanteVenta As New PlanTipoRepresentanteVenta
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.Usp_ObtenerPlanTipoRepresentanteVenta)
        oDatabase.AddInParameter(oDbCommand, "@IdPlanTipoRepVen", DbType.Int32, idPlanTipoRepVen)
        oDbCommand.CommandTimeout = 120000

        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim iIdPlanTipoRepVen As Integer = oIDataReader.GetOrdinal("IdPlanTipoRepVen")
            Dim iIdTipoRepVen As Integer = oIDataReader.GetOrdinal("IdTipoRepVen")
            Dim iNombreTipoRepVen As Integer = oIDataReader.GetOrdinal("NombreTipoRepVen")
            Dim iIdMes As Integer = oIDataReader.GetOrdinal("IdMes")
            Dim iOrdenMes As Integer = oIDataReader.GetOrdinal("OrdenMes")
            Dim iPlan As Integer = oIDataReader.GetOrdinal("Plan")
            Dim iFechaRegistro As Integer = oIDataReader.GetOrdinal("FechaRegistro")

            While oIDataReader.Read()
                oPlanTipoRepresentanteVenta.TipoRepresentanteVenta = New TipoRepresentanteVenta()
                oPlanTipoRepresentanteVenta.MesPlan = New MesPlan()

                oPlanTipoRepresentanteVenta.IdPlanTipoRepVen = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(iIdPlanTipoRepVen))
                oPlanTipoRepresentanteVenta.TipoRepresentanteVenta.IdTipoRepVen = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(iIdTipoRepVen))
                oPlanTipoRepresentanteVenta.TipoRepresentanteVenta.NombreTipoRepVen = DataUtil.DbValueToDefault(Of String)(oIDataReader(iNombreTipoRepVen))
                oPlanTipoRepresentanteVenta.MesPlan.IdMes = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(iIdMes))
                oPlanTipoRepresentanteVenta.MesPlan.OrdenMes = DataUtil.DbValueToDefault(Of String)(oIDataReader(iOrdenMes))
                oPlanTipoRepresentanteVenta.Plan = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(iPlan))
                oPlanTipoRepresentanteVenta.FechaRegistro = DataUtil.DbValueToDefault(Of String)(oIDataReader(iFechaRegistro))
            End While
        End Using

        Return oPlanTipoRepresentanteVenta
    End Function

    Function GestionarPlanTipoRepresentanteVenta(planTipoRepresentanteVenta As PlanTipoRepresentanteVenta) As String
        Dim result As String = String.Empty
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.Usp_GestionarPlanTipoRepresentanteVenta)

        oDatabase.AddInParameter(oDbCommand, "@IdPlanTipoRepVen", DbType.Int32, planTipoRepresentanteVenta.IdPlanTipoRepVen)
        oDatabase.AddInParameter(oDbCommand, "@IdTipoRepVen", DbType.Int32, planTipoRepresentanteVenta.TipoRepresentanteVenta.IdTipoRepVen)
        oDatabase.AddInParameter(oDbCommand, "@IdMes", DbType.Int32, planTipoRepresentanteVenta.MesPlan.IdMes)
        oDatabase.AddInParameter(oDbCommand, "@Plan", DbType.Decimal, planTipoRepresentanteVenta.Plan)
        result = Convert.ToString(oDatabase.ExecuteScalar(oDbCommand))

        Return result
    End Function

    Function EliminarPlanTipoRepresentanteVenta(idPlanTipoRepVen As Integer) As Integer
        Dim result As Integer = 0
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.Usp_EliminarPlanTipoRepresentanteVenta)

        oDatabase.AddInParameter(oDbCommand, "@IdPlanTipoRepVen", DbType.Int32, idPlanTipoRepVen)
        result = Integer.Parse(oDatabase.ExecuteScalar(oDbCommand))

        Return result
    End Function

#End Region
End Class
