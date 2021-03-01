Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common.Configuration
Imports Sodimac.VentaEmpresa.DataContracts
Imports System.Data.Common

Public Class VentaEmpresaTiendaDataAccess

    Private oDatabase As Database = EnterpriseLibraryContainer.Current.GetInstance(Of Database)(Conexion.cnsSql)

    Function ReporteVentaEmpresaTienda(FechaInicio As String, FechaFin As String, Empresa As String, Sucursal As String) As List(Of VentaEmpresaTienda)
        Dim oListaVentaEmpresaTienda As New List(Of VentaEmpresaTienda)

        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.Usp_VentaEmpresaTienda)
        oDatabase.AddInParameter(oDbCommand, "@FECINI", DbType.String, FechaInicio)
        oDatabase.AddInParameter(oDbCommand, "@FECFIN", DbType.String, FechaFin)
        oDatabase.AddInParameter(oDbCommand, "@SUCURSAL", DbType.String, Sucursal)
        oDbCommand.CommandTimeout = 0
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim ICODSUCURSAL As Integer = oIDataReader.GetOrdinal("CODSUCURSAL")
            Dim INOMSUCURSAL As Integer = oIDataReader.GetOrdinal("NOMSUCURSAL")
            Dim IDIA As Integer = oIDataReader.GetOrdinal("DIA")
            Dim ICOD_FAM_NUE As Integer = oIDataReader.GetOrdinal("COD_FAM_NUE")
            Dim INOM_FAM_NUE As Integer = oIDataReader.GetOrdinal("NOM_FAM_NUE")
            Dim IMARCA As Integer = oIDataReader.GetOrdinal("MARCA")
            Dim IVENTACONTADO As Integer = oIDataReader.GetOrdinal("VENTACONTADO")
            Dim IVENTACREDITO As Integer = oIDataReader.GetOrdinal("VENTACREDITO")
            Dim IVENTANETATOTAL As Integer = oIDataReader.GetOrdinal("VENTANETATOTAL")
            Dim IVENTANETATOTALCIA As Integer = oIDataReader.GetOrdinal("VENTANETATOTALCIA")
            Dim IPLANVENTAVVEE As Integer = oIDataReader.GetOrdinal("PLANVENTAVVEE")
            Dim IVENTACONTADOAA As Integer = oIDataReader.GetOrdinal("VENTACONTADOAA")
            Dim IVENTACREDITOAA As Integer = oIDataReader.GetOrdinal("VENTACREDITOAA")
            Dim IVENTANETATOTALAA As Integer = oIDataReader.GetOrdinal("VENTANETATOTALAA")
            Dim IPLANMARGENVVEE As Integer = oIDataReader.GetOrdinal("PLANMARGENVVEE")
            Dim IMARGENCREDITO As Integer = oIDataReader.GetOrdinal("MARGENCREDITO")
            Dim IMARGENCONTADO As Integer = oIDataReader.GetOrdinal("MARGENCONTADO")
            Dim IMARGENTOTAL As Integer = oIDataReader.GetOrdinal("MARGENTOTAL")
            Dim IMARGENCREDITOAA As Integer = oIDataReader.GetOrdinal("MARGENCREDITOAA")
            Dim IMARGENCONTADOAA As Integer = oIDataReader.GetOrdinal("MARGENCONTADOAA")
            Dim IMARGENTOTALAA As Integer = oIDataReader.GetOrdinal("MARGENTOTALAA")
            Dim ITRANCREDITO As Integer = oIDataReader.GetOrdinal("TRANCREDITO")
            Dim ITRANCONTADO As Integer = oIDataReader.GetOrdinal("TRANCONTADO")
            Dim ITRANTOTAL As Integer = oIDataReader.GetOrdinal("TRANTOTAL")
            Dim ITRANCREDITOAA As Integer = oIDataReader.GetOrdinal("TRANCREDITOAA")
            Dim ITRANCONTADOAA As Integer = oIDataReader.GetOrdinal("TRANCONTADOAA")
            Dim ITRANTOTALAA As Integer = oIDataReader.GetOrdinal("TRANTOTALAA")

            While oIDataReader.Read()
                Dim oVentaEmpresaTienda = New VentaEmpresaTienda()
                oVentaEmpresaTienda.CodSucursal = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(ICODSUCURSAL))
                oVentaEmpresaTienda.NomSucursal = DataUtil.DbValueToDefault(Of String)(oIDataReader(INOMSUCURSAL))
                oVentaEmpresaTienda.Dia = DataUtil.DbValueToDefault(Of String)(oIDataReader(IDIA))
                oVentaEmpresaTienda.CodFamilia = DataUtil.DbValueToDefault(Of String)(oIDataReader(ICOD_FAM_NUE))
                oVentaEmpresaTienda.NombreFamilia = DataUtil.DbValueToDefault(Of String)(oIDataReader(INOM_FAM_NUE))
                oVentaEmpresaTienda.Marca = DataUtil.DbValueToDefault(Of String)(oIDataReader(IMARCA))
                oVentaEmpresaTienda.VentaContado = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(IVENTACONTADO))
                oVentaEmpresaTienda.VentaCredito = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(IVENTACREDITO))
                oVentaEmpresaTienda.VentaNetaTotal = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(IVENTANETATOTAL))
                oVentaEmpresaTienda.VentaNetaTotalCIA = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(IVENTANETATOTALCIA))
                oVentaEmpresaTienda.PlanVentaVVEE = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(IPLANVENTAVVEE))
                oVentaEmpresaTienda.VentaContadoAA = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(IVENTACONTADOAA))
                oVentaEmpresaTienda.VentaCreditoAA = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(IVENTACREDITOAA))
                oVentaEmpresaTienda.VentaNetaTotalAA = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(IVENTANETATOTALAA))
                oVentaEmpresaTienda.PlanMargenVVEE = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(IPLANMARGENVVEE))
                oVentaEmpresaTienda.MargenCredito = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(IMARGENCREDITO))
                oVentaEmpresaTienda.MargenContado = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(IMARGENCONTADO))
                oVentaEmpresaTienda.MargenTotal = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(IMARGENTOTAL))
                oVentaEmpresaTienda.MargenCreditoAA = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(IMARGENCREDITOAA))
                oVentaEmpresaTienda.MargenContadoAA = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(IMARGENCONTADOAA))
                oVentaEmpresaTienda.MargenTotalAA = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(IMARGENTOTALAA))
                oVentaEmpresaTienda.TranCredito = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(ITRANCREDITO))
                oVentaEmpresaTienda.TranContado = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(ITRANCONTADO))
                oVentaEmpresaTienda.TranTotal = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(ITRANTOTAL))
                oVentaEmpresaTienda.TranCreditoAA = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(ITRANCREDITOAA))
                oVentaEmpresaTienda.TranContadoAA = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(ITRANCONTADOAA))
                oVentaEmpresaTienda.TranTotalAA = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(ITRANTOTALAA))

                oListaVentaEmpresaTienda.Add(oVentaEmpresaTienda)
            End While
        End Using

        Return oListaVentaEmpresaTienda
    End Function
End Class
