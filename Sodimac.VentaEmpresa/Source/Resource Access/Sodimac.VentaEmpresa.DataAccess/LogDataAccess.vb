Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Data
Imports System.Data.Odbc
Imports System.Data.OleDb
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Common.Configuration
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Sodimac.VentaEmpresa.DataContracts
Imports Sodimac.VentaEmpresa.DataAccess
Imports System.Configuration
Imports Microsoft.SqlServer.Server

Public Class LogDataAccess

    Private oDatabase As Database = EnterpriseLibraryContainer.Current.GetInstance(Of Database)(Conexion.cnsSql)

    Function Actualizar_Log(ByVal Log As Log) As Integer
        Dim Tiempo As String = Now.Hour.ToString().PadLeft(2, "0") + ":" + Now.Minute.ToString().PadLeft(2, "0") + ":" + Now.Second.ToString().PadLeft(2, "0")
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_ACTUALIZAR_LOG)
        oDbCommand.CommandTimeout = 120000
        oDatabase.AddInParameter(oDbCommand, "@Usuario", DbType.String, Log.Usuario)
        oDatabase.AddInParameter(oDbCommand, "@Administrador", DbType.Boolean, Log.Administrador)
        oDatabase.AddInParameter(oDbCommand, "@IdLogAccion", DbType.Int32, Log.IdLogAccion)
        oDatabase.AddInParameter(oDbCommand, "@IdOrigenAccion", DbType.Int32, Log.IdOrigenAccion)
        Tiempo = General.DiffTime(Tiempo, Log.TiempoNavegacion)
        oDatabase.AddInParameter(oDbCommand, "@TiempoNavegacion", DbType.String, Tiempo)
        oDatabase.AddInParameter(oDbCommand, "@NombrePc", DbType.String, Log.NombrePc)
        oDatabase.AddInParameter(oDbCommand, "@MACPc", DbType.String, Log.MACPc)
        oDatabase.AddInParameter(oDbCommand, "@DescripcionAccion", DbType.String, Log.DescripcionAccion)

        oDatabase.ExecuteScalar(oDbCommand)
        Return 1
    End Function

    Function OrigenAccion_Listar() As ListaOrigenAccion
        Dim Lista As New ListaOrigenAccion()

        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_ORIGENACCION)
        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim indIdOrigenAccion As Integer = oIDataReader.GetOrdinal("Id_OrigenAccion")
            Dim indEsquema As Integer = oIDataReader.GetOrdinal("Esquema")
            Dim indDescripcion As Integer = oIDataReader.GetOrdinal("Descripcion")
            Dim indEstado As Integer = oIDataReader.GetOrdinal("Estado")
            Dim indEsqDesc As Integer = oIDataReader.GetOrdinal("EsqDesc")

            Dim obj As New OrigenAccion()
            While (oIDataReader.Read())
                obj = New OrigenAccion()
                obj.IdOrigenAccion = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indIdOrigenAccion))
                obj.Esquema = DataUtil.DbValueToDefault(Of String)(oIDataReader(indEsquema))
                obj.Descripcion = DataUtil.DbValueToDefault(Of String)(oIDataReader(indDescripcion))
                obj.Estado = DataUtil.DbValueToDefault(Of Boolean)(oIDataReader(indEstado))
                obj.EsqDesc = DataUtil.DbValueToDefault(Of String)(oIDataReader(indEsqDesc))
                Lista.Add(obj)
            End While
        End Using
        Return Lista
    End Function

    Function LogAccion_Listar() As ListaLogAccion
        Dim Lista As New ListaLogAccion()

        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_LOGACCION)
        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim indLogAccion As Integer = oIDataReader.GetOrdinal("Id_LogAccion")
            Dim indDescripcion As Integer = oIDataReader.GetOrdinal("Descripcion")
            Dim indDescripcionCorta As Integer = oIDataReader.GetOrdinal("DescripcionCorta")
            Dim indEstado As Integer = oIDataReader.GetOrdinal("Estado")

            Dim obj As New LogAccion()
            While (oIDataReader.Read())
                obj = New LogAccion()
                obj.IdLogAccion = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indLogAccion))
                obj.Descripcion = DataUtil.DbValueToDefault(Of String)(oIDataReader(indDescripcion))
                obj.DescripcionCorta = DataUtil.DbValueToDefault(Of String)(oIDataReader(indDescripcionCorta))
                obj.Estado = DataUtil.DbValueToDefault(Of Boolean)(oIDataReader(indEstado))
                Lista.Add(obj)
            End While
        End Using
        Return Lista
    End Function

End Class
