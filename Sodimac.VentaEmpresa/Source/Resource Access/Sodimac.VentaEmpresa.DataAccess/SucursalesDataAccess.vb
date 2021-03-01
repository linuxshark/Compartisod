Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Common
Imports System.Linq
Imports System.Text
Imports Sodimac.VentaEmpresa.BusinessEntities
Imports Sodimac.VentaEmpresa.DataContracts
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common.Configuration

Public Class SucursalesDataAccess
    Private oDatabase As Database = EnterpriseLibraryContainer.Current.GetInstance(Of Database)(Conexion.cnsSql)
    Public Function ListarSucursalHistorico(ByRef oPaginacion As Paginacion) As Paginacion

        oPaginacion.ListaSucursal = New ListaSucursal()

        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_HISTORICOSUCURSAL)

        oDatabase.AddInParameter(oDbCommand, "@PageSize", DbType.Int32, oPaginacion.PageSize)
        oDatabase.AddInParameter(oDbCommand, "@PageNumber", DbType.Int32, oPaginacion.PageNumber)
        oDatabase.AddInParameter(oDbCommand, "@SortBy", DbType.String, oPaginacion.SortBy)
        oDatabase.AddInParameter(oDbCommand, "@SortType", DbType.String, oPaginacion.SortType)
        oDatabase.AddOutParameter(oDbCommand, "@TotalRows", DbType.Int32, 10)
        oDbCommand.CommandTimeout = 120000

        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)

            Dim INDICE_Sucursal As Integer = oIDataReader.GetOrdinal("Sucursal")
            Dim INDICE_Zona As Integer = oIDataReader.GetOrdinal("Zona")
            Dim INDICE_Ubigueo As Integer = oIDataReader.GetOrdinal("Ubigeo")
            Dim INDICE_CargoAsignado As Integer = oIDataReader.GetOrdinal("CargoAsignado")
            Dim INDICE_EscalaTiempoAsignado As Integer = oIDataReader.GetOrdinal("EscalaTiempoAsignado")
            Dim INDICE_FechaRegistro As Integer = oIDataReader.GetOrdinal("FechaRegistro")
            Dim INDICE_FechaActivacion As Integer = oIDataReader.GetOrdinal("FechaActivacionVenta")
            Dim INDICE_FechaModificacion As Integer = oIDataReader.GetOrdinal("FechaModificacion")

            While oIDataReader.Read()

                oPaginacion.Sucursal = New Sucursal()
                oPaginacion.Sucursal.Descripcion = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_Sucursal))

                oPaginacion.Sucursal.Zona = New Zona()
                oPaginacion.Sucursal.Zona.Descripcion = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_Zona))

                oPaginacion.Sucursal.EmpleadoCargo = New EmpleadoCargo()
                oPaginacion.Sucursal.EmpleadoCargo.DescripcionCargo = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_CargoAsignado))


                oPaginacion.Sucursal.SucursalEmpleado = New SucursalEmpleado()
                oPaginacion.Sucursal.SucursalEmpleado.EscalaTiempoAsignado = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_EscalaTiempoAsignado))
                oPaginacion.Sucursal.SucursalEmpleado.Ubigeo = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_Ubigueo))
                oPaginacion.Sucursal.SucursalEmpleado.FechaRegistro = DataUtil.DbValueToDefault(Of Date)(oIDataReader(INDICE_FechaRegistro))
                oPaginacion.Sucursal.SucursalEmpleado.FechaActivacionVenta = DataUtil.DbValueToDefault(Of Date)(oIDataReader(INDICE_FechaActivacion))
                oPaginacion.Sucursal.SucursalEmpleado.FechaActualizacion = DataUtil.DbValueToDefault(Of Date)(oIDataReader(INDICE_FechaModificacion))

                oPaginacion.ListaSucursal.Add(oPaginacion.Sucursal)
            End While
        End Using
        oPaginacion.TotalRows = Convert.ToInt32(oDatabase.GetParameterValue(oDbCommand, "@TotalRows"))
        Return oPaginacion

    End Function
End Class
