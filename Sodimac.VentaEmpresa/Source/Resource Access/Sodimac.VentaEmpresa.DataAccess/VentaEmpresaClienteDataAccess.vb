Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common.Configuration
Imports Sodimac.VentaEmpresa.DataContracts
Imports System.Data.Common

Public Class VentaEmpresaClienteDataAccess

    Private oDatabase As Database = EnterpriseLibraryContainer.Current.GetInstance(Of Database)(Conexion.cnsSql)

    Function ReporteVentaEmpresaCliente(FechaInicio As String, FechaFin As String, Sucursal As String, Ruc As String) As List(Of VentaEmpresaCliente)
        Dim oListaVentaEmpresaCliente As New List(Of VentaEmpresaCliente)

        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_VENTAEMPRESA_CLIENTE)
        oDatabase.AddInParameter(oDbCommand, "@FECINI", DbType.String, FechaInicio)
        oDatabase.AddInParameter(oDbCommand, "@FECFIN", DbType.String, FechaFin)
        oDatabase.AddInParameter(oDbCommand, "@SUCURSAL", DbType.String, Sucursal)
        oDatabase.AddInParameter(oDbCommand, "@RUC", DbType.String, Ruc)
        oDbCommand.CommandTimeout = 0
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim IRUC As Integer = oIDataReader.GetOrdinal("RUC")
            Dim IRAZONSOCIAL As Integer = oIDataReader.GetOrdinal("RAZONSOCIAL")
            Dim ITIENDAS As Integer = oIDataReader.GetOrdinal("TIENDAS")
            Dim IVENTACONTADOSOD As Integer = oIDataReader.GetOrdinal("VENTACONTADOSOD")
            Dim IVENTACREDITOSOD As Integer = oIDataReader.GetOrdinal("VENTACREDITOSOD")
            Dim IVENTASODIMAC As Integer = oIDataReader.GetOrdinal("VENTASODIMAC")
            Dim IVENTACONTADOMAE As Integer = oIDataReader.GetOrdinal("VENTACONTADOMAE")
            Dim IVENTACREDITOMAE As Integer = oIDataReader.GetOrdinal("VENTACREDITOMAE")
            Dim IVENTAMAESTRO As Integer = oIDataReader.GetOrdinal("VENTAMAESTRO")
            Dim IVENTASOD_OBRAGRUESA As Integer = oIDataReader.GetOrdinal("VENTASOD_OBRAGRUESA")
            Dim IVENTAMAE_OBRAGRUESA As Integer = oIDataReader.GetOrdinal("VENTAMAE_OBRAGRUESA")
            Dim IVENTACONTADOSODAA As Integer = oIDataReader.GetOrdinal("VENTACONTADOSODAA")
            Dim IVENTACREDITOSODAA As Integer = oIDataReader.GetOrdinal("VENTACREDITOSODAA")
            Dim IVENTASODIMACAA As Integer = oIDataReader.GetOrdinal("VENTASODIMACAA")
            Dim IVENTACONTADOMAEAA As Integer = oIDataReader.GetOrdinal("VENTACONTADOMAEAA")
            Dim IVENTACREDITOMAEAA As Integer = oIDataReader.GetOrdinal("VENTACREDITOMAEAA")
            Dim IVENTAMAESTROAA As Integer = oIDataReader.GetOrdinal("VENTAMAESTROAA")
            Dim IVENTASOD_OBRAGRUESA_AA As Integer = oIDataReader.GetOrdinal("VENTASOD_OBRAGRUESA_AA")
            Dim IVENTAMAE_OBRAGRUESA_AA As Integer = oIDataReader.GetOrdinal("VENTAMAE_OBRAGRUESA_AA")
            Dim IBOLETAS_SOD As Integer = oIDataReader.GetOrdinal("BOLETAS_SOD")
            Dim IBOLETAS_MAE As Integer = oIDataReader.GetOrdinal("BOLETAS_MAE")

            While oIDataReader.Read()
                Dim oVentaEmpresaCliente = New VentaEmpresaCliente()
                oVentaEmpresaCliente.Ruc = DataUtil.DbValueToDefault(Of String)(oIDataReader(IRUC))
                oVentaEmpresaCliente.RazonSocial = DataUtil.DbValueToDefault(Of String)(oIDataReader(IRAZONSOCIAL))
                oVentaEmpresaCliente.Tiendas = DataUtil.DbValueToDefault(Of String)(oIDataReader(ITIENDAS))
                oVentaEmpresaCliente.VentaContadoSOD = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(IVENTACONTADOSOD))
                oVentaEmpresaCliente.VentaCreditoSOD = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(IVENTACREDITOSOD))
                oVentaEmpresaCliente.VentaSODIMAC = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(IVENTASODIMAC))
                oVentaEmpresaCliente.VentaContadoMAE = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(IVENTACONTADOMAE))
                oVentaEmpresaCliente.VentaCreditoMAE = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(IVENTACREDITOMAE))
                oVentaEmpresaCliente.VentaMAESTRO = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(IVENTAMAESTRO))
                oVentaEmpresaCliente.VentaSOD_ObraGruesa = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(IVENTASOD_OBRAGRUESA))
                oVentaEmpresaCliente.VentaMAE_ObraGruesa = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(IVENTAMAE_OBRAGRUESA))
                oVentaEmpresaCliente.VentaContadoSODAA = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(IVENTACONTADOSODAA))
                oVentaEmpresaCliente.VentaCreditoSODAA = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(IVENTACREDITOSODAA))
                oVentaEmpresaCliente.VentaSodimacAA = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(IVENTASODIMACAA))
                oVentaEmpresaCliente.VentaContadoMAEAA = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(IVENTACONTADOMAEAA))
                oVentaEmpresaCliente.VentaCreditoMAEAA = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(IVENTACREDITOMAEAA))
                oVentaEmpresaCliente.VentaMaestroAA = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(IVENTAMAESTROAA))
                oVentaEmpresaCliente.VentaSOD_ObraGruesaAA = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(IVENTASOD_OBRAGRUESA_AA))
                oVentaEmpresaCliente.VentaMAE_ObraGruesaAA = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(IVENTAMAE_OBRAGRUESA_AA))
                oVentaEmpresaCliente.Boletas_SOD = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(IBOLETAS_SOD))
                oVentaEmpresaCliente.Boletas_AA = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(IBOLETAS_MAE))

                oListaVentaEmpresaCliente.Add(oVentaEmpresaCliente)
            End While
        End Using

        Return oListaVentaEmpresaCliente
    End Function
End Class
