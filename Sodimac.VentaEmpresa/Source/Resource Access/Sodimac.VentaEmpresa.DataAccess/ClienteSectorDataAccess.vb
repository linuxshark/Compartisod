Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Common
Imports System.Linq
Imports System.Text
Imports Sodimac.VentaEmpresa.BusinessEntities
Imports Sodimac.VentaEmpresa.DataContracts
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common.Configuration

Public Class ClienteSectorDataAccess
    Private oDatabase As Database = EnterpriseLibraryContainer.Current.GetInstance(Of Database)(Conexion.cnsSql)

    Function ConsultarClienteSector() As ListaClienteSector
        Dim oListaClienteSector As New ListaClienteSector()
        oListaClienteSector = New ListaClienteSector
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_CLIENTE_SECTOR)
        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim indiceIdClienteSector As Integer = oIDataReader.GetOrdinal("IdClienteSector")
            Dim indiceDescripcion As Integer = oIDataReader.GetOrdinal("Descripcion")
            Dim indiceDescripcionCorta As Integer = oIDataReader.GetOrdinal("DescripcionCorta")
            Dim indiceFechaDesde As Integer = oIDataReader.GetOrdinal("FechaDesde")
            Dim indiceFechaHasta As Integer = oIDataReader.GetOrdinal("FechaHasta")
            Dim indiceActivo As Integer = oIDataReader.GetOrdinal("Activo")
            Dim oClienteSector As New ClienteSector()
            While (oIDataReader.Read())
                oClienteSector = New ClienteSector()
                oClienteSector.IdClienteSector = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indiceIdClienteSector))
                oClienteSector.Descripcion = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceDescripcion))
                oClienteSector.DescripcionCorta = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceDescripcionCorta))
                oClienteSector.FechaDesde = DataUtil.DbValueToDefault(Of Date)(oIDataReader(indiceFechaDesde))
                oClienteSector.FechaHasta = DataUtil.DbValueToDefault(Of Date)(oIDataReader(indiceFechaHasta))
                oClienteSector.Activo = DataUtil.DbValueToDefault(Of Boolean)(oIDataReader(indiceActivo))
                oListaClienteSector.Add(oClienteSector)
            End While
        End Using
        Return oListaClienteSector
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

End Class
