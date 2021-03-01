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
Imports System.Configuration
Imports Microsoft.SqlServer.Server

Public Class ConfiguracionDataAccess

    Private oDatabase As Database = EnterpriseLibraryContainer.Current.GetInstance(Of Database)(Conexion.cnsSql)

    Public Function ObtenerParametroPorCodigoParametro(ByVal CodigoParametro As String) As Parametro
        Dim oParametro As New Parametro
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_PARAMETRO_PORCODIGOPARAMETRO)

        oDatabase.AddInParameter(oDbCommand, "@CodigoParametro", DbType.String, CodigoParametro)
        oDbCommand.CommandTimeout = 120000

        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim indiceIdParametro As Integer = oIDataReader.GetOrdinal("IdParametro")
            Dim indiceIdParametroTipo As Integer = oIDataReader.GetOrdinal("IdParametroTipo")
            Dim indiceIdArea As Integer = oIDataReader.GetOrdinal("IdArea")
            Dim indiceCodigoParametro As Integer = oIDataReader.GetOrdinal("CodigoParametro")
            Dim indiceParametro As Integer = oIDataReader.GetOrdinal("Parametro")
            Dim indiceDescripcion As Integer = oIDataReader.GetOrdinal("Descripcion")
            Dim indiceDescripcion1 As Integer = oIDataReader.GetOrdinal("Descripcion1")
            Dim indiceValor1 As Integer = oIDataReader.GetOrdinal("Valor1")
            Dim indiceDescripcion2 As Integer = oIDataReader.GetOrdinal("Descripcion2")
            Dim indiceValor2 As Integer = oIDataReader.GetOrdinal("Valor2")
            Dim indiceDescripcion3 As Integer = oIDataReader.GetOrdinal("Descripcion3")
            Dim indiceValor3 As Integer = oIDataReader.GetOrdinal("Valor3")
            Dim indiceFechaDesde As Integer = oIDataReader.GetOrdinal("FechaDesde")
            Dim indiceFechaHasta As Integer = oIDataReader.GetOrdinal("FechaHasta")
            Dim indiceActivo As Integer = oIDataReader.GetOrdinal("Activo")

            While oIDataReader.Read()
                oParametro.IdParametro = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(indiceIdParametro))
                oParametro.IdParametroTipo = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(indiceIdParametroTipo))
                oParametro.IdArea = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(indiceIdArea))
                oParametro.CodigoParametro = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceCodigoParametro))
                oParametro.Parametro = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceParametro))
                oParametro.Descripcion = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceDescripcion))
                oParametro.Descripcion1 = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceDescripcion1))
                oParametro.Valor1 = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceValor1))
                oParametro.Descripcion2 = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceDescripcion2))
                oParametro.Valor2 = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceValor2))
                oParametro.Descripcion3 = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceDescripcion3))
                oParametro.Valor3 = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceValor3))
                oParametro.FechaDesde = DataUtil.DbValueToDefault(Of DateTime)(oIDataReader(indiceFechaDesde))
                oParametro.FechaHasta = DataUtil.DbValueToDefault(Of DateTime)(oIDataReader(indiceFechaHasta))
                oParametro.Activo = DataUtil.DbValueToDefault(Of Boolean)(oIDataReader(indiceActivo))
            End While
        End Using

        Return oParametro
    End Function

    Public Function ObtenerParametro(ByVal IdParametro As Integer) As Parametro
        Dim oParametro As New Parametro
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_PARAMETRO_PORCODIGO)

        oDatabase.AddInParameter(oDbCommand, "@IdParametro", DbType.String, IdParametro)
        oDbCommand.CommandTimeout = 120000

        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim indiceIdParametro As Integer = oIDataReader.GetOrdinal("IdParametro")
            Dim indiceIdParametroTipo As Integer = oIDataReader.GetOrdinal("IdParametroTipo")
            Dim indiceIdArea As Integer = oIDataReader.GetOrdinal("IdArea")
            Dim indiceCodigoParametro As Integer = oIDataReader.GetOrdinal("CodigoParametro")
            Dim indiceParametro As Integer = oIDataReader.GetOrdinal("Parametro")
            Dim indiceDescripcion As Integer = oIDataReader.GetOrdinal("Descripcion")
            Dim indiceDescripcion1 As Integer = oIDataReader.GetOrdinal("Descripcion1")
            Dim indiceValor1 As Integer = oIDataReader.GetOrdinal("Valor1")
            Dim indiceDescripcion2 As Integer = oIDataReader.GetOrdinal("Descripcion2")
            Dim indiceValor2 As Integer = oIDataReader.GetOrdinal("Valor2")
            Dim indiceDescripcion3 As Integer = oIDataReader.GetOrdinal("Descripcion3")
            Dim indiceValor3 As Integer = oIDataReader.GetOrdinal("Valor3")
            Dim indiceFechaDesde As Integer = oIDataReader.GetOrdinal("FechaDesde")
            Dim indiceFechaHasta As Integer = oIDataReader.GetOrdinal("FechaHasta")
            Dim indiceActivo As Integer = oIDataReader.GetOrdinal("Activo")

            While oIDataReader.Read()
                oParametro.IdParametro = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(indiceIdParametro))
                oParametro.IdParametroTipo = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(indiceIdParametroTipo))
                oParametro.IdArea = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(indiceIdArea))
                oParametro.CodigoParametro = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceCodigoParametro))
                oParametro.Parametro = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceParametro))
                oParametro.Descripcion = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceDescripcion))
                oParametro.Descripcion1 = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceDescripcion1))
                oParametro.Valor1 = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceValor1))
                oParametro.Descripcion2 = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceDescripcion2))
                oParametro.Valor2 = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceValor2))
                oParametro.Descripcion3 = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceDescripcion3))
                oParametro.Valor3 = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceValor3))
                oParametro.FechaDesde = DataUtil.DbValueToDefault(Of DateTime)(oIDataReader(indiceFechaDesde))
                oParametro.FechaHasta = DataUtil.DbValueToDefault(Of DateTime)(oIDataReader(indiceFechaHasta))
                oParametro.Activo = DataUtil.DbValueToDefault(Of Boolean)(oIDataReader(indiceActivo))
            End While
        End Using

        Return oParametro
    End Function

    Public Function Buscar_Parametros(ByVal Paginacion As Paginacion) As Paginacion
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_PARAMETROS)
        oDatabase.AddInParameter(oDbCommand, "@SortType", DbType.String, Paginacion.SortType)
        oDatabase.AddInParameter(oDbCommand, "@SortDir", DbType.String, Paginacion.SortBy)
        oDatabase.AddInParameter(oDbCommand, "@Page", DbType.Int32, Paginacion.PageNumber)
        oDatabase.AddInParameter(oDbCommand, "@RowsPerPage", DbType.Int32, Paginacion.PageSize)
        oDatabase.AddOutParameter(oDbCommand, "@RowCount", DbType.Int32, 0)
        oDbCommand.CommandTimeout = 120000

        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim indiceIdParametro As Integer = oIDataReader.GetOrdinal("IdParametro")
            Dim indiceIdParametroTipo As Integer = oIDataReader.GetOrdinal("IdParametroTipo")
            Dim indiceIdArea As Integer = oIDataReader.GetOrdinal("IdArea")
            Dim indiceCodigoParametro As Integer = oIDataReader.GetOrdinal("CodigoParametro")
            Dim indiceParametro As Integer = oIDataReader.GetOrdinal("Parametro")
            Dim indiceDescripcion As Integer = oIDataReader.GetOrdinal("Descripcion")
            Dim indiceDescripcion1 As Integer = oIDataReader.GetOrdinal("Descripcion1")
            Dim indiceValor1 As Integer = oIDataReader.GetOrdinal("Valor1")
            Dim indiceDescripcion2 As Integer = oIDataReader.GetOrdinal("Descripcion2")
            Dim indiceValor2 As Integer = oIDataReader.GetOrdinal("Valor2")
            Dim indiceDescripcion3 As Integer = oIDataReader.GetOrdinal("Descripcion3")
            Dim indiceValor3 As Integer = oIDataReader.GetOrdinal("Valor3")
            Dim indiceFechaDesde As Integer = oIDataReader.GetOrdinal("FechaDesde")
            Dim indiceFechaHasta As Integer = oIDataReader.GetOrdinal("FechaHasta")
            Dim indiceActivo As Integer = oIDataReader.GetOrdinal("Activo")

            Paginacion.ListaParametro = New ListaParametro()
            Dim obj = New Parametro()
            While oIDataReader.Read()
                obj = New Parametro()
                obj.IdParametro = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(indiceIdParametro))
                obj.IdParametroTipo = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(indiceIdParametroTipo))
                obj.IdArea = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(indiceIdArea))
                obj.CodigoParametro = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceCodigoParametro))
                obj.Parametro = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceParametro))
                obj.Descripcion = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceDescripcion))
                obj.Descripcion1 = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceDescripcion1))
                obj.Valor1 = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceValor1))
                obj.Descripcion2 = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceDescripcion2))
                obj.Valor2 = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceValor2))
                obj.Descripcion3 = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceDescripcion3))
                obj.Valor3 = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceValor3))
                obj.FechaDesde = DataUtil.DbValueToDefault(Of DateTime)(oIDataReader(indiceFechaDesde))
                obj.FechaHasta = DataUtil.DbValueToDefault(Of DateTime)(oIDataReader(indiceFechaHasta))
                obj.Activo = DataUtil.DbValueToDefault(Of Boolean)(oIDataReader(indiceActivo))
                Paginacion.ListaParametro.Add(obj)
            End While
        End Using
        Paginacion.TotalRows = Convert.ToInt32(oDatabase.GetParameterValue(oDbCommand, "@RowCount"))
        Return Paginacion
    End Function

    Public Function Actualizar_Parametro(ByVal P As Parametro) As Integer
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_ACTUALIZAR_PARAMETRO)
        oDatabase.AddInParameter(oDbCommand, "@IdParametro", DbType.Int16, P.IdParametro)
        oDatabase.AddInParameter(oDbCommand, "@Descripcion1", DbType.String, P.Descripcion1)
        oDatabase.AddInParameter(oDbCommand, "@Valor1", DbType.String, P.Valor1)
        oDatabase.AddInParameter(oDbCommand, "@Descripcion2", DbType.String, P.Descripcion2)
        oDatabase.AddInParameter(oDbCommand, "@Valor2", DbType.String, P.Valor2)
        oDatabase.AddInParameter(oDbCommand, "@Descripcion3", DbType.String, P.Descripcion3)
        oDatabase.AddInParameter(oDbCommand, "@Valor3", DbType.String, P.Valor3)
        oDatabase.AddInParameter(oDbCommand, "@FechaDesde", DbType.DateTime, P.FechaDesde)
        oDatabase.AddInParameter(oDbCommand, "@FechaHasta", DbType.DateTime, P.FechaHasta)

        Return oDatabase.ExecuteScalar(oDbCommand)
    End Function
End Class
