Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Common
Imports System.Linq
Imports System.Text
Imports Sodimac.VentaEmpresa.BusinessEntities
Imports Sodimac.VentaEmpresa.DataContracts
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common.Configuration
Public Class ClienteTipoDataAccess
    Private oDatabase As Database = EnterpriseLibraryContainer.Current.GetInstance(Of Database)(Conexion.cnsSql)
    Function ConsultarClienteTipo() As ListaClienteTipo
        Dim oListaClienteTipo As New ListaClienteTipo()
        oListaClienteTipo = New ListaClienteTipo
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_CLIENTE_TIPO)
        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim indiceIdClienteTipo As Integer = oIDataReader.GetOrdinal("IdClienteTipo")
            Dim indiceDescripcion As Integer = oIDataReader.GetOrdinal("Descripcion")
            Dim indiceDescripcionCorta As Integer = oIDataReader.GetOrdinal("DescripcionCorta")
            Dim indiceFechaDesde As Integer = oIDataReader.GetOrdinal("FechaDesde")
            Dim indiceFechaHasta As Integer = oIDataReader.GetOrdinal("FechaHasta")
            Dim indiceActivo As Integer = oIDataReader.GetOrdinal("Activo")
            Dim oClienteTipo As New ClienteTipo()
            While (oIDataReader.Read())
                oClienteTipo = New ClienteTipo()
                oClienteTipo.IdClienteTipo = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indiceIdClienteTipo))
                oClienteTipo.Descripcion = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceDescripcion))
                oClienteTipo.DescripcionCorta = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceDescripcionCorta))
                oClienteTipo.FechaDesde = DataUtil.DbValueToDefault(Of Date)(oIDataReader(indiceFechaDesde))
                oClienteTipo.FechaHasta = DataUtil.DbValueToDefault(Of Date)(oIDataReader(indiceFechaHasta))
                oClienteTipo.Activo = DataUtil.DbValueToDefault(Of Boolean)(oIDataReader(indiceActivo))
                oListaClienteTipo.Add(oClienteTipo)
            End While
        End Using
        Return oListaClienteTipo
    End Function
End Class
