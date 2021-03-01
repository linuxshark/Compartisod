Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Common
Imports System.Linq
Imports System.Text
Imports Sodimac.VentaEmpresa.BusinessEntities
Imports Sodimac.VentaEmpresa.DataContracts
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common.Configuration

Public Class ClienteCategoriaDataAccess

    Private oDatabase As Database = EnterpriseLibraryContainer.Current.GetInstance(Of Database)(Conexion.cnsSql)

    Function ConsultarClienteCategoria() As ListaClienteCategoria
        Dim oListaClienteCategoria As New ListaClienteCategoria()
        oListaClienteCategoria = New ListaClienteCategoria
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_CLIENTE_CATEGORIA)
        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim indiceIdClienteCategoria As Integer = oIDataReader.GetOrdinal("IdClienteCategoria")
            Dim indiceDescripcion As Integer = oIDataReader.GetOrdinal("Descripcion")
            Dim indiceDescripcionCorta As Integer = oIDataReader.GetOrdinal("DescripcionCorta")
            Dim indiceFechaDesde As Integer = oIDataReader.GetOrdinal("FechaDesde")
            Dim indiceFechaHasta As Integer = oIDataReader.GetOrdinal("FechaHasta")
            Dim indiceActivo As Integer = oIDataReader.GetOrdinal("Activo")
            Dim oClienteCategoria As New ClienteCategoria()
            While (oIDataReader.Read())
                oClienteCategoria = New ClienteCategoria()
                oClienteCategoria.IdClienteCategoria = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indiceIdClienteCategoria))
                oClienteCategoria.Descripcion = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceDescripcion))
                oClienteCategoria.DescripcionCorta = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceDescripcionCorta))
                oClienteCategoria.FechaDesde = DataUtil.DbValueToDefault(Of Date)(oIDataReader(indiceFechaDesde))
                oClienteCategoria.FechaHasta = DataUtil.DbValueToDefault(Of Date)(oIDataReader(indiceFechaHasta))
                oClienteCategoria.Activo = DataUtil.DbValueToDefault(Of Boolean)(oIDataReader(indiceActivo))
                oListaClienteCategoria.Add(oClienteCategoria)
            End While
        End Using
        Return oListaClienteCategoria
    End Function
End Class
