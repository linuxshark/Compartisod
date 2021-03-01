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
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql

Public Class ReprocesoDataAccess

    Private oDatabase As Database = EnterpriseLibraryContainer.Current.GetInstance(Of Database)(Conexion.cnsSql)

    Function ListarReprocesoBoletas(oBoletas As ProcesoCarga) As ListaProcesoCarga
        Dim _ListarReproceso As New ListaProcesoCarga


        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_LISTARREPROCESO_BOLETA)
        oDatabase.AddInParameter(oDbCommand, "@Sucursal", DbType.Int32, oBoletas.IdSucursal)
        oDatabase.AddInParameter(oDbCommand, "@FechaInicio", DbType.Date, oBoletas.fechaInicio)
        oDatabase.AddInParameter(oDbCommand, "@FechaFin", DbType.Date, oBoletas.fechaFin)
        oDatabase.AddInParameter(oDbCommand, "@DNI", DbType.String, oBoletas.Ruc)
        oDatabase.AddInParameter(oDbCommand, "@NumeroDocumento", DbType.String, oBoletas.NumeroDocumento)

        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)

            Dim INDICE_eSTADO As Integer = oIDataReader.GetOrdinal("estado")
            Dim INDICE_Codigo As Integer = oIDataReader.GetOrdinal("IdVenta")
            Dim INDICE_FechaVenta As Integer = oIDataReader.GetOrdinal("FechaVenta")
            Dim INDICE_DetalleSucursal As Integer = oIDataReader.GetOrdinal("Descripcion")
            Dim INDICE_Sucursal As Integer = oIDataReader.GetOrdinal("Sucursal")
            Dim INDICE_NumeroDoc As Integer = oIDataReader.GetOrdinal("NumeroDocumento")
            Dim INDICE_checked As Integer = oIDataReader.GetOrdinal("checked")
            Dim INDICE_DNI As Integer = oIDataReader.GetOrdinal("DNI")
            Dim INDICE_IGV As Integer = oIDataReader.GetOrdinal("IGV")
            Dim INDICE_Total As Integer = oIDataReader.GetOrdinal("Total")
            Dim INDICE_Costo As Integer = oIDataReader.GetOrdinal("Costo")
            Dim INDICE_NombreCliente As Integer = oIDataReader.GetOrdinal("NombreCliente")

            Dim INDICE_SKU As Integer = oIDataReader.GetOrdinal("SKU")
            Dim INDICE_Nom_SKU As Integer = oIDataReader.GetOrdinal("Nom_Sku")
            Dim INDICE_Cantidad As Integer = oIDataReader.GetOrdinal("Cantidad")
            Dim INDICE_Valor As Integer = oIDataReader.GetOrdinal("Valor")
            Dim INDICE_CostoUnitario As Integer = oIDataReader.GetOrdinal("CostoUnitario")
            Dim INDICE_HUA As Integer = oIDataReader.GetOrdinal("HUA")



            While oIDataReader.Read()
                Dim oProcesa As New ProcesoCarga()
                oProcesa.Estado = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_eSTADO))
                oProcesa.IdCliente = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_Codigo))
                oProcesa.Fecha = DataUtil.DbValueToDefault(Of Date)(oIDataReader(INDICE_FechaVenta))
                oProcesa.NombreSucursal = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_DetalleSucursal))
                oProcesa.Sucursal = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_Sucursal))
                oProcesa.NumeroDocumento = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_NumeroDoc))
                oProcesa.Valores = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_checked))
                oProcesa.Ruc = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_DNI))
                oProcesa.Igv = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_IGV))
                oProcesa.Total = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_Total))
                oProcesa.CostoTotal = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_Costo))
                oProcesa.NombreCliente = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_NombreCliente))

                oProcesa.Sku = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_SKU))
                oProcesa.Nom_Sku = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_Nom_SKU))
                oProcesa.Cantidad = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_Cantidad))
                oProcesa.Valor = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_Valor))
                oProcesa.CostoUnitario = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_CostoUnitario))
                oProcesa.HUA = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_HUA))


                _ListarReproceso.Add(oProcesa)
            End While
        End Using
        Return _ListarReproceso


    End Function

    Public Function RegistraBoletas(lstCliente As ListaProcesoCarga) As Integer

        Dim MapeoListaCliente As New List(Of SqlDataRecord)
        Dim MapeoListaClienteEmpleado As New List(Of SqlDataRecord)
        If (Not lstCliente Is Nothing) Then
            MapeoListaCliente = CrearSqlDataRecordsBoletas(lstCliente)
        End If

        Dim resultado As Integer = 0
        Try
            Dim oSqlDatabase As SqlDatabase = DirectCast(DatabaseFactory.CreateDatabase(Conexion.cnsSql), SqlDatabase)
            Dim oDbComand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_INSERT_BOLETAS_REPORCESAR)
            If (Not lstCliente Is Nothing) Then
                oSqlDatabase.AddInParameter(oDbComand, "@Boletas", SqlDbType.Structured, MapeoListaCliente)

            End If

            resultado = CInt(oDatabase.ExecuteScalar(oDbComand))
        Catch ex As Exception
            resultado = -1
        End Try
        Return resultado
    End Function

    Private Function CrearSqlDataRecordsBoletas(lista As ListaProcesoCarga) As IEnumerable(Of SqlDataRecord)
        Dim ListaRegistro As New List(Of SqlDataRecord)

        Try

            For Each item As ProcesoCarga In lista

                Dim SqlDataRecord = New SqlDataRecord(
                    New SqlMetaData("FechaVenta", SqlDbType.Date),
                    New SqlMetaData("IdSucursal", SqlDbType.Int),
                    New SqlMetaData("NumeroDocumento", SqlDbType.Int),
                    New SqlMetaData("DNI", SqlDbType.VarChar, 50)
                    )
                SqlDataRecord.SetDateTime(0, item.Fecha)
                SqlDataRecord.SetInt32(1, item.IdSucursal)
                SqlDataRecord.SetInt32(2, item.NumeroDocumento)
                SqlDataRecord.SetString(3, item.Ruc)
                'SqlDataRecord.SetDateTime(4, If(item.Empleado.FechaAsignacion.Equals(String.Empty), System.DateTime.Now, item.Empleado.FechaAsignacion))


                ListaRegistro.Add(SqlDataRecord)
            Next
        Catch ex As Exception
            Throw ex
        End Try
        Return ListaRegistro
    End Function


    Public Function RegistrarRBoletas(oEmpleado As ProcesoCarga) As Integer
        Try
            Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_INSERT_BOLETAS_REPORCESAR)
            oDatabase.AddInParameter(oDbCommand, "@FechaVenta", DbType.Date, oEmpleado.Fecha)
            oDatabase.AddInParameter(oDbCommand, "@idSucursal", DbType.Int32, oEmpleado.IdSucursal)
            oDatabase.AddInParameter(oDbCommand, "@numeroDoc", DbType.Int32, oEmpleado.NumeroDocumento)
            oDatabase.AddInParameter(oDbCommand, "@dni", DbType.String, oEmpleado.Ruc)


            oDatabase.ExecuteNonQuery(oDbCommand)
        Catch ex As Exception

        End Try
        Return 0
    End Function

    Public Function EliminarRBoletas(oEmpleado As ProcesoCarga) As Integer
        Try
            Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_DELTETE_BOLETAS_REPORCESAR)
            oDatabase.AddInParameter(oDbCommand, "@FechaVenta", DbType.Date, oEmpleado.fechaInicio)
            oDatabase.AddInParameter(oDbCommand, "@FechaVentaFin", DbType.Date, oEmpleado.fechaFin)
            oDatabase.AddInParameter(oDbCommand, "@idSucursal", DbType.Int32, oEmpleado.IdSucursal)
            oDatabase.AddInParameter(oDbCommand, "@NumeroDoc", DbType.Int32, oEmpleado.NumeroDocumento)
            oDatabase.AddInParameter(oDbCommand, "@dni", DbType.String, oEmpleado.Ruc)
            oDatabase.AddInParameter(oDbCommand, "@estado", DbType.Int32, oEmpleado.Estado)

            oDatabase.ExecuteNonQuery(oDbCommand)
        Catch ex As Exception

        End Try
        Return 0
    End Function

End Class
