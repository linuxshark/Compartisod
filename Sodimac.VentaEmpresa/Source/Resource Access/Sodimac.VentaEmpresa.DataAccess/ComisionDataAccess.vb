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

Public Class ComisionDataAccess : Implements IComisionDataAccess

    Private oDatabase As Database = EnterpriseLibraryContainer.Current.GetInstance(Of Database)(Conexion.cnsSql)

    Public Function ListaComisionPeriodo(ByVal oPaginacion As Paginacion) As Paginacion Implements IComisionDataAccess.ListaComisionPeriodo

        Dim oListaComisionPeriodo As New ListaComisionPeriodo()
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_LISTAPERIODOPAGINADO)

        oDatabase.AddInParameter(oDbCommand, "@IdPeriodo", DbType.Int32, oPaginacion.ComisionPeriodo.IdPeriodo)
        oDatabase.AddInParameter(oDbCommand, "@PageSize", DbType.Int32, oPaginacion.PageSize)
        oDatabase.AddInParameter(oDbCommand, "@PageNumber", DbType.Int32, oPaginacion.PageNumber)
        oDatabase.AddInParameter(oDbCommand, "@SortBy", DbType.String, oPaginacion.SortBy)
        oDatabase.AddInParameter(oDbCommand, "@SortType", DbType.String, oPaginacion.SortType)
        oDatabase.AddOutParameter(oDbCommand, "@TotalRows", DbType.Int32, 10)
        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim indiceIdPeriodo As Integer = oIDataReader.GetOrdinal("IdPeriodo")
            Dim indiceNombrePeriodo As Integer = oIDataReader.GetOrdinal("NombrePeriodo")
            Dim indiceFechaInicio As Integer = oIDataReader.GetOrdinal("FechaInicio")
            Dim indiceFechaFin As Integer = oIDataReader.GetOrdinal("FechaFin")
            Dim indicePlanVentaBase As Integer = oIDataReader.GetOrdinal("PlanVentaBase")
            Dim indiceCantidadTiempoServicio As Integer = oIDataReader.GetOrdinal("CantidadTiempoServicio")
            Dim indiceCantidadBono As Integer = oIDataReader.GetOrdinal("CantidadBono")
            Dim indiceIdEstado As Integer = oIDataReader.GetOrdinal("IdEstado")
            Dim indiceDescripcion As Integer = oIDataReader.GetOrdinal("Descripcion")
            Dim indiceActivo As Integer = oIDataReader.GetOrdinal("Activo")
            While oIDataReader.Read()
                Dim oComisionPeriodo As ComisionPeriodo
                oComisionPeriodo = New ComisionPeriodo()
                oComisionPeriodo.IdPeriodo = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indiceIdPeriodo))
                oComisionPeriodo.NombrePeriodo = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceNombrePeriodo))
                oComisionPeriodo.FechaInicio = DataUtil.DbValueToDefault(Of Date)(oIDataReader(indiceFechaInicio))
                oComisionPeriodo.FechaFin = DataUtil.DbValueToDefault(Of Date)(oIDataReader(indiceFechaFin))
                oComisionPeriodo.PlanVentaBase = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(indicePlanVentaBase))
                oComisionPeriodo.CantidadTiempoServicio = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indiceCantidadTiempoServicio))
                oComisionPeriodo.CantidadBono = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indiceCantidadBono))
                oComisionPeriodo.Activo = DataUtil.DbValueToDefault(Of Boolean)(oIDataReader(indiceActivo))

                oComisionPeriodo.Estado = New Estado()
                oComisionPeriodo.Estado.IdEstado = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indiceIdEstado))
                oComisionPeriodo.Estado.Descripcion = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceDescripcion))
                oListaComisionPeriodo.Add(oComisionPeriodo)
            End While
        End Using
        oPaginacion.ListaComisionPeriodo = New List(Of ComisionPeriodo)
        oPaginacion.ListaComisionPeriodo = oListaComisionPeriodo
        oPaginacion.TotalRows = Convert.ToInt32(oDatabase.GetParameterValue(oDbCommand, "@TotalRows"))
        Return oPaginacion
    End Function

    Function ListaNombrePeriodo() As ListaNombrePeriodo
        Dim oListaNombrePeriodo As New ListaNombrePeriodo

        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_NOMBRECOMISIONPERIODO)
        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim oNombrePeriodo As New NombrePeriodo
            Dim idPeriodo As Integer = oIDataReader.GetOrdinal("IdPeriodo")
            Dim nombrePeriodo As Integer = oIDataReader.GetOrdinal("NombrePeriodo")
            While oIDataReader.Read()
                oNombrePeriodo = New NombrePeriodo
                oNombrePeriodo.IdPeriodo = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(idPeriodo))
                oNombrePeriodo.NombrePeriodo = DataUtil.DbValueToDefault(Of String)(oIDataReader(nombrePeriodo))
                oListaNombrePeriodo.Add(oNombrePeriodo)
            End While
        End Using
        Return oListaNombrePeriodo
    End Function

    Function RegistrarEscalaComision(ByVal oListaComisionEscalaDetalle As List(Of ComisionEscalaDetalle)) As Integer
        Dim result As Integer
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_UPD_ESCALACOMISION)

        Dim paramComisionEscala As New SqlParameter("@ComisionEscala", SqlDbType.Structured)
        Dim paramComisionEscalaDetalle As New SqlParameter("@ComisionEscalaDetalle", SqlDbType.Structured)

        paramComisionEscala.TypeName = "TComisionEscala"
        paramComisionEscala.Value = ComisionEscalaDataRecord(oListaComisionEscalaDetalle.First().ComisionEscala)
        paramComisionEscalaDetalle.TypeName = "TComisionEscalaDetalle"
        paramComisionEscalaDetalle.Value = ComisionEscalaDetalleDataRecord(oListaComisionEscalaDetalle)

        oDbCommand.Parameters.Add(paramComisionEscala)
        oDbCommand.Parameters.Add(paramComisionEscalaDetalle)

        result = oDatabase.ExecuteScalar(oDbCommand)
        Return result

    End Function

    Function ComisionEscalaDataRecord(ByVal oComisionEscala As ComisionEscala) As IEnumerable(Of SqlDataRecord)

        Dim oListaComisionEscala As List(Of ComisionEscala) = New List(Of ComisionEscala)
        oListaComisionEscala.Add(oComisionEscala)
        Dim records As List(Of SqlDataRecord) = New List(Of SqlDataRecord)
        For Each item As ComisionEscala In oListaComisionEscala
            Dim record As SqlDataRecord = New SqlDataRecord(
                New SqlMetaData() {
                    New SqlMetaData("IdComisionEscala", SqlDbType.Int),
                    New SqlMetaData("PlanVenta", SqlDbType.Decimal, 12, 2),
                    New SqlMetaData("IngresoBasicoMensual", SqlDbType.Decimal, 12, 2)
                }
            )
            If (item.IdComisionEscala <> 0) Then
                record.SetInt32(0, item.IdComisionEscala)
            End If
            If (item.PlanVenta <> 0) Then
                record.SetDecimal(1, item.PlanVenta)
            End If
            If (item.IngresoBasicoMensual <> 0) Then
                record.SetDecimal(2, item.IngresoBasicoMensual)
            End If
            records.Add(record)
        Next
        Return records

    End Function

    Function ComisionEscalaDetalleDataRecord(ByVal oListaComisionEscalaDetalle As List(Of ComisionEscalaDetalle)) As IEnumerable(Of SqlDataRecord)

        Dim records As List(Of SqlDataRecord) = New List(Of SqlDataRecord)
        For Each item As ComisionEscalaDetalle In oListaComisionEscalaDetalle
            Dim record As SqlDataRecord = New SqlDataRecord(
                New SqlMetaData() {
                    New SqlMetaData("IdComisionEscalaDetalle", SqlDbType.Int),
                    New SqlMetaData("IdComisionEscala", SqlDbType.Int),
                    New SqlMetaData("PorcentajeInicial", SqlDbType.Decimal, 12, 2),
                    New SqlMetaData("PorcentajeFinal", SqlDbType.Decimal, 12, 2),
                    New SqlMetaData("Bono", SqlDbType.Decimal, 12, 2),
                    New SqlMetaData("Estado", SqlDbType.Int)
                }
            )
            If (item.IdComisionEscalaDetalle <> 0) Then
                record.SetInt32(0, item.IdComisionEscalaDetalle)
            End If
            If (item.IdComisionEscala <> 0) Then
                record.SetInt32(1, item.ComisionEscala.IdComisionEscala)
            End If
            If (item.PorcentajeInicial <> 0) Then
                record.SetDecimal(2, item.PorcentajeInicial)
            End If
            If (item.PorcentajeFinal <> 0) Then
                record.SetDecimal(3, item.PorcentajeFinal)
            End If
            If (item.Bono <> 0) Then
                record.SetDecimal(4, item.Bono)
            End If
            If (item.Estado <> 0) Then
                record.SetDecimal(5, 1)
            End If
            records.Add(record)
        Next
        Return records

    End Function

    Function ListaCargo() As ListaEmpleadoCargo
        Dim oListaEmpleadoCargo As New ListaEmpleadoCargo()
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.Usp_ListaCargo)
        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim oEmpleadoCargo As New EmpleadoCargo()
            Dim indiceIdCargo As Integer = oIDataReader.GetOrdinal("IdEmpleadoCargo")
            Dim indiceDescripcionCargo As Integer = oIDataReader.GetOrdinal("Descripcion")
            While oIDataReader.Read()
                oEmpleadoCargo = New EmpleadoCargo()
                oEmpleadoCargo.IdEmpleadoCargo = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(indiceIdCargo))
                oEmpleadoCargo.DescripcionCargo = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceDescripcionCargo))
                oListaEmpleadoCargo.Add(oEmpleadoCargo)
            End While
        End Using
        Return oListaEmpleadoCargo
    End Function

    Function ListaPerfil() As ListaEmpleadoPerfil
        Dim oListaEmpleadoPerfil As New ListaEmpleadoPerfil()
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.Usp_ListaPerfil)
        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim oEmpleadoPerfil As New EmpleadoPerfil()
            Dim indiceIdPerfil As Integer = oIDataReader.GetOrdinal("IdPerfil")
            Dim indiceDescripcionPerfil As Integer = oIDataReader.GetOrdinal("Descripcion")
            While oIDataReader.Read()
                oEmpleadoPerfil = New EmpleadoPerfil()
                oEmpleadoPerfil.IdPerfil = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(indiceIdPerfil))
                oEmpleadoPerfil.DescripcionPerfil = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceDescripcionPerfil))
                oListaEmpleadoPerfil.Add(oEmpleadoPerfil)
            End While
        End Using
        Return oListaEmpleadoPerfil
    End Function

    Function ListaTiempoServicio(IdComisionEscala As Integer)
        Dim oListaTiempoServicio As New ListaComisionEscala()
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.Usp_ListaTiempoServicio)
        oDatabase.AddInParameter(oDbCommand, "@IdComisionEscala", DbType.Int32, IdComisionEscala)
        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim oTiempoServicio As New ComisionEscala()
            Dim IndiceTiempoServicio As Integer = oIDataReader.GetOrdinal("TiempoServicio")
            While oIDataReader.Read()
                oTiempoServicio = New ComisionEscala()
                oTiempoServicio.TiempoServicio = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(IndiceTiempoServicio))
                oListaTiempoServicio.Add(oTiempoServicio)
            End While
        End Using
        Return oListaTiempoServicio
    End Function

    Function ListaPeriodoCbo()
        Dim oListaPeriodo As New ListaComisionPeriodo()
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.Usp_ListaPeriodo)
        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim oPeriodo As New ComisionPeriodo()
            Dim indiceIdPeriodo As Integer = oIDataReader.GetOrdinal("IdPeriodo")
            Dim indiceNomPeriodo As Integer = oIDataReader.GetOrdinal("NombrePeriodo")
            While oIDataReader.Read()
                oPeriodo = New ComisionPeriodo()
                oPeriodo.IdPeriodoPlantilla = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(indiceIdPeriodo))
                oPeriodo.NombrePeriodo = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceNomPeriodo))
                oListaPeriodo.Add(oPeriodo)
            End While
        End Using
        Return oListaPeriodo
    End Function

    Function ListaComisionEscala_PorIdPeriodo(ByVal IdPeriodo As Integer) As ListaComisionEscala
        Dim oListaComisionEscala As New ListaComisionEscala
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_ESCALACOMISION_PORIDPERIODO)
        oDatabase.AddInParameter(oDbCommand, "@IdPeriodo", DbType.Int32, IdPeriodo)
        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim oComisionEscala As New ComisionEscala()
            Dim indiceEscalaID As Integer = oIDataReader.GetOrdinal("IdComisionEscala")
            Dim indiceIdPeriodo As Integer = oIDataReader.GetOrdinal("IdPeriodo")
            Dim indiceNombrePeriodo As Integer = oIDataReader.GetOrdinal("NombrePeriodo")
            Dim indiceDescripcionPerfil As Integer = oIDataReader.GetOrdinal("DescripcionP")
            Dim indiceDescripcionCargo As Integer = oIDataReader.GetOrdinal("Descripcion")
            Dim indiceTiempoServicio As Integer = oIDataReader.GetOrdinal("TiempoServicio")
            Dim indiceFechaActualizacion As Integer = oIDataReader.GetOrdinal("FechaActualizacion")
            Dim indicePlanVenta As Integer = oIDataReader.GetOrdinal("PlanVenta")
            Dim indiceIngresoBasicoMensual As Integer = oIDataReader.GetOrdinal("IngresoBasicoMensual")
            While oIDataReader.Read()
                oComisionEscala = New ComisionEscala()
                oComisionEscala.IdComisionEscala = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indiceEscalaID))
                oComisionEscala.ComisionPeriodo = New ComisionPeriodo()
                oComisionEscala.ComisionPeriodo.IdPeriodo = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indiceIdPeriodo))
                oComisionEscala.ComisionPeriodo.NombrePeriodo = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceNombrePeriodo))
                oComisionEscala.Cargo = New Cargo()
                oComisionEscala.Perfil = New Perfil()
                oComisionEscala.Perfil.NombrePerfil = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceDescripcionPerfil))
                oComisionEscala.Cargo.NombreCargo = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceDescripcionCargo))
                oComisionEscala.TiempoServicio = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indiceTiempoServicio))
                oComisionEscala.FechaActualizacion = DataUtil.DbValueToDefault(Of DateTime)(oIDataReader(indiceFechaActualizacion))
                oComisionEscala.PlanVenta = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(indicePlanVenta))
                oComisionEscala.IngresoBasicoMensual = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(indiceIngresoBasicoMensual))
                oListaComisionEscala.Add(oComisionEscala)
            End While
        End Using
        Return oListaComisionEscala
    End Function

    Function ListaComisionPeriodoDetalle_PorIdPeriodo(ByVal IdPeriodo As Integer) As ListaComisionPeriodoDetalle
        Dim oListaComisionPeriodoDetalle As New ListaComisionPeriodoDetalle
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_PERIODOCOMISIONDETALLE_PORIDPERIODO)
        oDatabase.AddInParameter(oDbCommand, "@IdPeriodo", DbType.Int32, IdPeriodo)
        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim oComisionPeriodoDetalle As New ComisionPeriodoDetalle()
            Dim indiceIdPeriodoDetalle As Integer = oIDataReader.GetOrdinal("IdPeriodoDetalle")
            Dim indiceIdPeriodo As Integer = oIDataReader.GetOrdinal("IdPeriodo")
            Dim indiceIdPerfil As Integer = oIDataReader.GetOrdinal("IdPerfil")
            Dim indicePorcentajeInicial As Integer = oIDataReader.GetOrdinal("PorcentajeInicial")
            Dim indicePorcentajeFinal As Integer = oIDataReader.GetOrdinal("PorcentajeFinal")
            Dim indiceBono As Integer = oIDataReader.GetOrdinal("Bono")
            Dim indiceEstado As Integer = oIDataReader.GetOrdinal("Estado")
            While oIDataReader.Read()
                oComisionPeriodoDetalle = New ComisionPeriodoDetalle()
                oComisionPeriodoDetalle.IdPeriodoDetalle = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indiceIdPeriodoDetalle))
                oComisionPeriodoDetalle.IdPeriodo = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indiceIdPeriodo))
                oComisionPeriodoDetalle.IdPerfil = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indiceIdPerfil))
                oComisionPeriodoDetalle.PorcentajeInicial = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(indicePorcentajeInicial))
                oComisionPeriodoDetalle.PorcentajeFinal = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(indicePorcentajeFinal))
                oComisionPeriodoDetalle.Bono = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(indiceBono))
                oComisionPeriodoDetalle.Estado = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indiceEstado))
                oListaComisionPeriodoDetalle.Add(oComisionPeriodoDetalle)
            End While
        End Using
        Return oListaComisionPeriodoDetalle
    End Function

    Function ListaComisionEscalaDetalle(ByVal IdEscalaComision As Integer)
        Dim oListaComisionEscalaDetalle As New ListaComisionEscalaDetalle
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_LISTARESCALACOMISIONDETALLE_PORIDESCALA)
        oDatabase.AddInParameter(oDbCommand, "@IdComisionEscala", DbType.Int32, IdEscalaComision)
        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim oComisionEscalaDetalle As New ComisionEscalaDetalle()
            Dim indiceIdComisionEscalaDetalle As Integer = oIDataReader.GetOrdinal("IdComisionEscalaDetalle")
            Dim indiceIdComisionEscala As Integer = oIDataReader.GetOrdinal("IdComisionEscala")
            Dim indicePorcInicial As Integer = oIDataReader.GetOrdinal("PorcentajeInicial")
            Dim indicePorcFinal As Integer = oIDataReader.GetOrdinal("PorcentajeFinal")
            Dim indiceBono As Integer = oIDataReader.GetOrdinal("Bono")

            While oIDataReader.Read()
                oComisionEscalaDetalle = New ComisionEscalaDetalle
                oComisionEscalaDetalle.IdComisionEscalaDetalle = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(indiceIdComisionEscalaDetalle))
                oComisionEscalaDetalle.IdComisionEscala = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(indiceIdComisionEscala))
                oComisionEscalaDetalle.PorcentajeInicial = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(indicePorcInicial))
                oComisionEscalaDetalle.PorcentajeFinal = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(indicePorcFinal))
                oComisionEscalaDetalle.Bono = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(indiceBono))
                oListaComisionEscalaDetalle.Add(oComisionEscalaDetalle)
            End While
        End Using
        Return oListaComisionEscalaDetalle
    End Function

    Function CabeceraComisionEscala(ByVal IdEscalaComision As Integer)
        Dim oComisionEscala As New ComisionEscala
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_ESCALACOMISION_PORID)
        oDatabase.AddInParameter(oDbCommand, "@IdComisionEscala", DbType.Int32, IdEscalaComision)
        oDbCommand.CommandTimeout = 120000

        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim indiceIdComisionEscala As Integer = oIDataReader.GetOrdinal("IdComisionEscala")
            Dim indiceIdPeriodo As Integer = oIDataReader.GetOrdinal("IdPeriodo")
            Dim indiceNombrePeriodo As Integer = oIDataReader.GetOrdinal("NombrePeriodo")
            Dim indiceIdEmpleadoCargo As Integer = oIDataReader.GetOrdinal("IdEmpleadoCargo")
            Dim indiceDescripcionEmpleadoCargo As Integer = oIDataReader.GetOrdinal("DescripcionEmpleadoCargo")
            Dim indiceIdPerfil As Integer = oIDataReader.GetOrdinal("IdPerfil")
            Dim indiceDescripcionEmpleadoPerfil As Integer = oIDataReader.GetOrdinal("DescripcionEmpleadoPerfil")
            Dim indiceTiempoServicio As Integer = oIDataReader.GetOrdinal("TiempoServicio")
            Dim indicePlanVenta As Integer = oIDataReader.GetOrdinal("PlanVenta")
            Dim indiceIngresoBasico As Integer = oIDataReader.GetOrdinal("IngresoBasicoMensual")
            Dim indiceEstado As Integer = oIDataReader.GetOrdinal("Estado")
            Dim indiceFechaActualizacion As Integer = oIDataReader.GetOrdinal("FechaActualizacion")

            While oIDataReader.Read()
                oComisionEscala.IdComisionEscala = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indiceIdComisionEscala))
                oComisionEscala.TiempoServicio = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indiceTiempoServicio))
                oComisionEscala.PlanVenta = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(indicePlanVenta))
                oComisionEscala.IngresoBasicoMensual = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(indiceIngresoBasico))
                oComisionEscala.Estado = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indiceEstado))
                oComisionEscala.FechaActualizacion = DataUtil.DbValueToDefault(Of DateTime)(oIDataReader(indiceFechaActualizacion))

                oComisionEscala.ComisionPeriodo = New ComisionPeriodo()
                oComisionEscala.ComisionPeriodo.IdPeriodo = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indiceIdPeriodo))
                oComisionEscala.ComisionPeriodo.NombrePeriodo = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceNombrePeriodo))

                oComisionEscala.Cargo = New Cargo()
                oComisionEscala.Cargo.IdCargo = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indiceIdEmpleadoCargo))
                oComisionEscala.Cargo.NombreCargo = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceDescripcionEmpleadoCargo))

                oComisionEscala.Perfil = New Perfil()
                oComisionEscala.Perfil.IdPerfil = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indiceIdPerfil))
                oComisionEscala.Perfil.NombrePerfil = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceDescripcionEmpleadoPerfil))
            End While
        End Using

        Return oComisionEscala
    End Function

    Function CabeceraPeriodoComision(ByVal IdPeriodo As Integer)
        Dim oPeriodoComision = New ComisionPeriodo
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_PERIODO_PORID)
        oDatabase.AddInParameter(oDbCommand, "@IdPeriodo", DbType.Int32, IdPeriodo)
        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim indiceIdPeriodo As Integer = oIDataReader.GetOrdinal("IdPeriodo")
            Dim indiceNombrePeriodo As Integer = oIDataReader.GetOrdinal("NombrePeriodo")
            Dim indiceFechaInicio As Integer = oIDataReader.GetOrdinal("FechaInicio")
            Dim indiceFechaFin As Integer = oIDataReader.GetOrdinal("FechaFin")
            Dim indiceCantidadBono As Integer = oIDataReader.GetOrdinal("CantidadBono")
            Dim indiceCantidadTiempoServicio As Integer = oIDataReader.GetOrdinal("CantidadTiempoServicio")
            Dim indicePlanVentaBase As Integer = oIDataReader.GetOrdinal("PlanVentaBase")
            While oIDataReader.Read()
                oPeriodoComision.IdPeriodo = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(indiceIdPeriodo))
                oPeriodoComision.NombrePeriodo = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceNombrePeriodo))
                oPeriodoComision.FechaInicio = DataUtil.DbValueToDefault(Of Date)(oIDataReader(indiceFechaInicio))
                oPeriodoComision.FechaFin = DataUtil.DbValueToDefault(Of Date)(oIDataReader(indiceFechaFin))
                oPeriodoComision.CantidadBono = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(indiceCantidadBono))
                oPeriodoComision.CantidadTiempoServicio = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(indiceCantidadTiempoServicio))
                oPeriodoComision.PlanVentaBase = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(indicePlanVentaBase))

            End While
        End Using
        Return oPeriodoComision
    End Function

    Function RegistrarPeriodoComision(ByVal pComisionPeriodo As ComisionPeriodo, ByRef IdPeriodo As Integer) As Integer
        Dim result As Integer
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_INS_PERIODOCOMISION)

        oDatabase.AddInParameter(oDbCommand, "@NombrePeriodo", DbType.String, pComisionPeriodo.NombrePeriodo)
        oDatabase.AddInParameter(oDbCommand, "@FechaInicio", DbType.Date, pComisionPeriodo.FechaInicio)
        oDatabase.AddInParameter(oDbCommand, "@FechaFin", DbType.Date, pComisionPeriodo.FechaFin)
        oDatabase.AddInParameter(oDbCommand, "@IdPeriodoPlantilla", DbType.Int32, pComisionPeriodo.IdPeriodoPlantilla)
        oDatabase.AddOutParameter(oDbCommand, "@IdPeriodo", DbType.Int32, 10)
        result = oDatabase.ExecuteScalar(oDbCommand)
        IdPeriodo = Convert.ToInt32(oDatabase.GetParameterValue(oDbCommand, "@IdPeriodo"))

        Return result
    End Function

    Function ObtenerPeriodoPorId(ByVal IdPeriodo As Integer) As ComisionPeriodo
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_COMISIONPERIODO_PORID)
        Dim oComisionPeriodo As New ComisionPeriodo

        oDatabase.AddInParameter(oDbCommand, "@IdPeriodo", DbType.Int32, IdPeriodo)
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)

            Dim indiceIdPeriodo = oIDataReader.GetOrdinal("IdPeriodo"),
                indiceNombrePeriodo = oIDataReader.GetOrdinal("NombrePeriodo"),
                indiceFechaInicio = oIDataReader.GetOrdinal("FechaInicio"),
                indiceFechaFin = oIDataReader.GetOrdinal("FechaFin"),
                indicePlanVentaBase = oIDataReader.GetOrdinal("PlanVentaBase"),
                indiceCantidadTiempoServicio = oIDataReader.GetOrdinal("CantidadTiempoServicio"),
                indiceCantidadBono = oIDataReader.GetOrdinal("CantidadBono"),
                indicePlanVentaSumatoria = oIDataReader.GetOrdinal("PlanVentaSumatoria"),
                indiceBonoEspecial = oIDataReader.GetOrdinal("BonoEspecial"),
                indiceBonoMontoEspecial = oIDataReader.GetOrdinal("BonoMontoEspecial"),
                indicePorcentaje = oIDataReader.GetOrdinal("Porcentaje"),
                indiceIdEstado = oIDataReader.GetOrdinal("IdEstado"),
                indiceDescripcion = oIDataReader.GetOrdinal("Descripcion")

            If oIDataReader.Read() Then
                oComisionPeriodo = New ComisionPeriodo
                oComisionPeriodo.IdPeriodo = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indiceIdPeriodo))
                oComisionPeriodo.NombrePeriodo = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceNombrePeriodo))
                oComisionPeriodo.FechaInicio = DataUtil.DbValueToDefault(Of DateTime)(oIDataReader(indiceFechaInicio))
                oComisionPeriodo.FechaFin = DataUtil.DbValueToDefault(Of DateTime)(oIDataReader(indiceFechaFin))
                oComisionPeriodo.PlanVentaBase = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(indicePlanVentaBase))
                oComisionPeriodo.CantidadTiempoServicio = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indiceCantidadTiempoServicio))
                oComisionPeriodo.CantidadBono = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indiceCantidadBono))                
                oComisionPeriodo.PlanVentaSumatoria = DataUtil.DbValueToDefault(Of Boolean)(oIDataReader(indicePlanVentaSumatoria))
                oComisionPeriodo.BonoEspecial = DataUtil.DbValueToDefault(Of Boolean)(oIDataReader(indiceBonoEspecial))
                oComisionPeriodo.BonoMontoEspecial = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(indiceBonoMontoEspecial))
                oComisionPeriodo.Porcentaje = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(indicePorcentaje))
                oComisionPeriodo.Estado = New Estado()
                oComisionPeriodo.Estado.IdEstado = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indiceIdEstado))
                oComisionPeriodo.Estado.Descripcion = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceDescripcion))
            End If
        End Using
        Return oComisionPeriodo
    End Function

    Function DataRecordComisionPeriodo(ByVal pComisionPeriodo As ComisionPeriodo) As IEnumerable(Of SqlDataRecord)
        Dim recordList As New List(Of SqlDataRecord)
        Dim record As New SqlDataRecord(
            New SqlMetaData() {
                New SqlMetaData("NombrePeriodo", SqlDbType.VarChar, 50),
                New SqlMetaData("FechaInicio", SqlDbType.DateTime),
                New SqlMetaData("FechaFin", SqlDbType.DateTime),
                New SqlMetaData("PlanVentaBase", SqlDbType.Decimal, 18, 2),
                New SqlMetaData("CantidadTiempoServicio", SqlDbType.Int),
                New SqlMetaData("CantidadBono", SqlDbType.Int),
                New SqlMetaData("PlanVentaSumatoria", SqlDbType.Bit),
                New SqlMetaData("BonoEspecial", SqlDbType.Bit),
                New SqlMetaData("BonoMontoEspecial", SqlDbType.Decimal, 18, 2),
                New SqlMetaData("Estado", SqlDbType.Int),
                New SqlMetaData("Porcentaje", SqlDbType.Decimal, 18, 2)
            }
        )

        With record
            .SetString(0, pComisionPeriodo.NombrePeriodo)
            .SetDateTime(1, pComisionPeriodo.FechaInicio)
            .SetDateTime(2, pComisionPeriodo.FechaFin)
            .SetDecimal(3, pComisionPeriodo.PlanVentaBase)
            .SetInt32(4, pComisionPeriodo.CantidadTiempoServicio)
            .SetInt32(5, pComisionPeriodo.CantidadBono)
            .SetBoolean(6, pComisionPeriodo.PlanVentaSumatoria)
            .SetBoolean(7, pComisionPeriodo.BonoEspecial)
            .SetDecimal(8, pComisionPeriodo.BonoMontoEspecial)
            .SetInt32(9, pComisionPeriodo.Estado.IdEstado)
            .SetDecimal(10, pComisionPeriodo.Porcentaje)
        End With
        recordList.Add(record)
        Return recordList
    End Function

    Function DataRecordComisionPeriodoDetalle(ByVal pListaComisionPeriodoDetalle As ListaComisionPeriodoDetalle) As IEnumerable(Of SqlDataRecord)
        Dim recordList As List(Of SqlDataRecord) = New List(Of SqlDataRecord)
        For Each iComisionPeriodoDetalle As ComisionPeriodoDetalle In pListaComisionPeriodoDetalle
            Dim record As New SqlDataRecord(
                    New SqlMetaData() {
                    New SqlMetaData("IdPeriodoDetalle", SqlDbType.Int),
                    New SqlMetaData("IdPeriodo", SqlDbType.Int),
                    New SqlMetaData("IdPerfil", SqlDbType.Int),
                    New SqlMetaData("PorcentajeInicial", SqlDbType.Decimal, 12, 2),
                    New SqlMetaData("PorcentajeFinal", SqlDbType.Decimal, 12, 2),
                    New SqlMetaData("Bono", SqlDbType.Decimal, 18, 2),
                    New SqlMetaData("Estado", SqlDbType.Int)
                }
            )
            With record
                .SetInt32(0, iComisionPeriodoDetalle.IdPeriodoDetalle)
                .SetInt32(1, iComisionPeriodoDetalle.IdPeriodo)
                .SetInt32(2, iComisionPeriodoDetalle.IdPerfil)
                .SetDecimal(3, iComisionPeriodoDetalle.PorcentajeInicial)
                .SetDecimal(4, iComisionPeriodoDetalle.PorcentajeFinal)
                .SetDecimal(5, iComisionPeriodoDetalle.Bono)
                .SetInt32(6, iComisionPeriodoDetalle.Estado)
            End With
            recordList.Add(record)
        Next
        Return recordList
    End Function

    Function AprobarPeriodoComision(ByVal IdPeriodo As Integer) As Integer
        Dim result As Integer = -1
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_UPD_APROBARPERIODOCOMISION)

        oDatabase.AddInParameter(oDbCommand, "@IdPeriodo", DbType.Int32, IdPeriodo)
        result = Integer.Parse(oDatabase.ExecuteScalar(oDbCommand))

        Return result
    End Function

    Function ListarTabsJefes(IdPeriodo As Integer) As ListaPlanVenta
        Dim oListaPlanVenta As New ListaPlanVenta
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_LISTACARGOS_TABS, IdPeriodo)
        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim oPlanVenta As New PlanVenta()
            Dim indiceIdPerfil As Integer = oIDataReader.GetOrdinal("IdPerfil")
            Dim indiceIdCargo As Integer = oIDataReader.GetOrdinal("IdCargo")
            Dim indiceNombreCargo As Integer = oIDataReader.GetOrdinal("NombreCargo")
            Dim indiceIdPerfilSuperior As Integer = oIDataReader.GetOrdinal("IdPerfilSuperior")
            Dim indiceIdCargoSuperior As Integer = oIDataReader.GetOrdinal("IdCargoSuperior")
            Dim indiceNombreCargoSuperior As Integer = oIDataReader.GetOrdinal("NombreCargoSuperior")
            Dim indiceNombreZona As Integer = oIDataReader.GetOrdinal("NombreZona")

            While oIDataReader.Read()
                oPlanVenta = New PlanVenta()
                oPlanVenta.Cargo = New Cargo()
                oPlanVenta.Cargo.Perfil = New Perfil()
                oPlanVenta.Cargo.PerfilSuperior = New Perfil()
                oPlanVenta.Cargo.Perfil.IdPerfil = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(indiceIdPerfil))
                oPlanVenta.Cargo.PerfilSuperior.IdPerfil = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(indiceIdPerfilSuperior))
                oPlanVenta.Cargo.IdCargo = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(indiceIdCargo))
                oPlanVenta.Cargo.NombreCargo = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceNombreCargo))  'Nombre del Cargo del Vendedor
                oPlanVenta.Cargo.IdCargoSuperior = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(indiceIdCargoSuperior))
                oPlanVenta.Cargo.NombreCargoSuperior = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceNombreCargoSuperior)) 'Nombre del Cargo del Jefe
                oPlanVenta.Cargo.Zona = New ZonaMantenimiento()
                oPlanVenta.Cargo.Zona.NombreZona = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceNombreZona))
                oPlanVenta.ComisionEscala = ObtenerComisionEscala(IdPeriodo, oPlanVenta.Cargo.IdCargoSuperior)
                oPlanVenta.ComisionEscalaRRVV = ObtenerComisionEscala(IdPeriodo, oPlanVenta.Cargo.IdCargo)
                oListaPlanVenta.Add(oPlanVenta)
            End While
        End Using
        Return oListaPlanVenta
    End Function

    Function Registrar_ComisionEscala(ByVal oComisionEscala As ComisionEscala, ByRef IdComisionEscala_ As Integer) As Integer
        Dim result As Integer

        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_INS_COMISIONESCALA)
        oDatabase.AddInParameter(oDbCommand, "@IdPeriodo", DbType.Int32, oComisionEscala.ComisionPeriodo.IdPeriodo)
        oDatabase.AddInParameter(oDbCommand, "@IdPerfil", DbType.Int32, oComisionEscala.Perfil.IdPerfil)
        oDatabase.AddInParameter(oDbCommand, "@IdCargo", DbType.Int32, oComisionEscala.Cargo.IdCargo)
        oDatabase.AddInParameter(oDbCommand, "@PlanVentaSumatoria", DbType.Boolean, oComisionEscala.PlanVentaSumatoria)
        oDatabase.AddInParameter(oDbCommand, "@PlanVentaFactorAplica", DbType.Boolean, oComisionEscala.PlanVentaFactorAplica)
        oDatabase.AddInParameter(oDbCommand, "@PlanVentaFactor", DbType.Decimal, oComisionEscala.PlanVentaFactor)
        oDatabase.AddInParameter(oDbCommand, "@PlanVentaFactorFechaInicio", DbType.DateTime, IIf(oComisionEscala.PlanVentaFactorFechaInicio = "#12:00:00 AM#", "01/01/1900", oComisionEscala.PlanVentaFactorFechaInicio))
        oDatabase.AddInParameter(oDbCommand, "@PlanVentaFactorFechaFin", DbType.DateTime, IIf(oComisionEscala.PlanVentaFactorFechaFin = "#12:00:00 AM#", "01/01/1900", oComisionEscala.PlanVentaFactorFechaFin))
        'oDatabase.AddInParameter(oDbCommand, "@PlanVentaFactorFechaInicio", DbType.DateTime, oComisionEscala.PlanVentaFactorFechaInicio)
        'oDatabase.AddInParameter(oDbCommand, "@PlanVentaFactorFechaFin", DbType.DateTime, oComisionEscala.PlanVentaFactorFechaFin)
        oDatabase.AddInParameter(oDbCommand, "@PlanVentaBonificacionRRVV", DbType.Boolean, oComisionEscala.PlanVentaBonificacionRRVV)
        oDatabase.AddInParameter(oDbCommand, "@PlanVentaBonificacionRRVVPorcentaje", DbType.Decimal, oComisionEscala.PlanVentaBonificacionRRVVPorcentaje)
        oDatabase.AddInParameter(oDbCommand, "@PlanVentaBonificacionRRVVMonto", DbType.Decimal, oComisionEscala.PlanVentaBonificacionRRVVMonto)
        oDatabase.AddInParameter(oDbCommand, "@PlanVentaBonificacionJefe", DbType.Boolean, oComisionEscala.PlanVentaBonificacionJefe)
        oDatabase.AddInParameter(oDbCommand, "@PlanVentaBonificacionJefePorcentaje", DbType.Decimal, oComisionEscala.PlanVentaBonificacionJefePorcentaje)
        oDatabase.AddInParameter(oDbCommand, "@PlanVentaBonificacionJefeMonto", DbType.Decimal, oComisionEscala.PlanVentaBonificacionJefeMonto)
        oDatabase.AddInParameter(oDbCommand, "@CantidadEscalas", DbType.Int32, oComisionEscala.CantidadEscalas)
        oDatabase.AddInParameter(oDbCommand, "@TiempoServicio", DbType.Int32, oComisionEscala.TiempoServicio)
        oDatabase.AddInParameter(oDbCommand, "@PlanVenta", DbType.Decimal, oComisionEscala.PlanVenta)
        oDatabase.AddInParameter(oDbCommand, "@IngresoBasicoMensual", DbType.Decimal, oComisionEscala.IngresoBasicoMensual)
        oDatabase.AddInParameter(oDbCommand, "@Completo", DbType.Boolean, oComisionEscala.Completo)
        oDatabase.AddOutParameter(oDbCommand, "@IdComisionEscala_", DbType.Int32, 10)
        result = Int32.Parse(oDatabase.ExecuteScalar(oDbCommand).ToString())
        IdComisionEscala_ = Convert.ToInt32(oDatabase.GetParameterValue(oDbCommand, "@IdComisionEscala_"))
        Return result

    End Function

    Function Registrar_ComisionEscalaTiempoServicio(ByVal oComisionEscalaTiempoServicio As ComisionEscalaTiempoServicio) As Integer
        Dim result As Integer

        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_INS_COMISIONESCALATIEMPOSERVICIO)
        oDatabase.AddInParameter(oDbCommand, "@IdPeriodo", DbType.Int32, oComisionEscalaTiempoServicio.ComisionPeriodo.IdPeriodo)
        oDatabase.AddInParameter(oDbCommand, "@IdPerfil", DbType.Int32, oComisionEscalaTiempoServicio.Perfil.IdPerfil)
        oDatabase.AddInParameter(oDbCommand, "@IdCargo", DbType.Int32, oComisionEscalaTiempoServicio.Cargo.IdCargo)
        oDatabase.AddInParameter(oDbCommand, "@TiempoServicio", DbType.Int32, oComisionEscalaTiempoServicio.TiempoServicio)
        oDatabase.AddInParameter(oDbCommand, "@PlanVenta", DbType.Decimal, oComisionEscalaTiempoServicio.PlanVenta)
        oDatabase.AddInParameter(oDbCommand, "@IngresoBasico", DbType.Decimal, oComisionEscalaTiempoServicio.IngresoBasico)
        oDatabase.AddInParameter(oDbCommand, "@Activo", DbType.Boolean, oComisionEscalaTiempoServicio.Activo)
        oDatabase.AddInParameter(oDbCommand, "@PorcInicial", DbType.Decimal, oComisionEscalaTiempoServicio.PorcInicial)
        oDatabase.AddInParameter(oDbCommand, "@PorcFinal", DbType.Decimal, oComisionEscalaTiempoServicio.PorcFinal)
        oDatabase.AddInParameter(oDbCommand, "@BonoMin", DbType.Decimal, oComisionEscalaTiempoServicio.BonoMin)
        oDatabase.AddInParameter(oDbCommand, "@BonoMax", DbType.Decimal, oComisionEscalaTiempoServicio.BonoMax)


        result = Int32.Parse(oDatabase.ExecuteScalar(oDbCommand).ToString())
        Return result

    End Function

    Function Registrar_ComisionEscalaDetalle(ByVal oComisionEscalaDetalle As ComisionEscalaDetalle) As Integer
        Dim result As Integer

        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_INS_COMISIONESCALADETALLE)
        oDatabase.AddInParameter(oDbCommand, "@IdComisionEscala", DbType.Int32, oComisionEscalaDetalle.ComisionEscala.IdComisionEscala)
        oDatabase.AddInParameter(oDbCommand, "@IdComisionEscalaTipo", DbType.Int32, oComisionEscalaDetalle.IdComisionEscalaTipo)
        oDatabase.AddInParameter(oDbCommand, "@PorcentajeInicial", DbType.Decimal, oComisionEscalaDetalle.PorcentajeInicial)
        oDatabase.AddInParameter(oDbCommand, "@PorcentajeFinal", DbType.Decimal, oComisionEscalaDetalle.PorcentajeFinal)
        oDatabase.AddInParameter(oDbCommand, "@Bono", DbType.Decimal, oComisionEscalaDetalle.Bono)

        result = Int32.Parse(oDatabase.ExecuteScalar(oDbCommand).ToString())
        Return result

    End Function

    Function ListaComisionEscalaTiempoServicio(IdPeriodo As Integer) As ListaComisionEscalaTiempoServicio
        Dim oListaComisionEscalaTiempoServicio As New ListaComisionEscalaTiempoServicio
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_LISTARESCALACOMISIONTIEMPOSERVICIO_BYPERIODO)
        oDatabase.AddInParameter(oDbCommand, "@IdPeriodo", DbType.Int32, IdPeriodo)
        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim oComisionEscalaTiempoServicio As New ComisionEscalaTiempoServicio()

            Dim indiceNombrePeriodo As Integer = oIDataReader.GetOrdinal("NombrePeriodo")
            Dim indiceIdPeriodo As Integer = oIDataReader.GetOrdinal("IdPeriodo")
            Dim indiceIdCargo As Integer = oIDataReader.GetOrdinal("IdCargo")
            Dim indiceNombreCargo As Integer = oIDataReader.GetOrdinal("NombreCargoCompleto")
            Dim indiceIdComisionTiempoServicio As Integer = oIDataReader.GetOrdinal("IdComisionTiempoServicio")
            Dim indicePlanVenta As Integer = oIDataReader.GetOrdinal("PlanVenta")
            Dim indiceIngresoBasico As Integer = oIDataReader.GetOrdinal("IngresoBasico")
            Dim indiceTiempoServicio As Integer = oIDataReader.GetOrdinal("TiempoServicio")

            While oIDataReader.Read()
                oComisionEscalaTiempoServicio = New ComisionEscalaTiempoServicio

                oComisionEscalaTiempoServicio.ComisionPeriodo = New ComisionPeriodo
                oComisionEscalaTiempoServicio.ComisionPeriodo.NombrePeriodo = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceNombrePeriodo))
                oComisionEscalaTiempoServicio.ComisionPeriodo.IdPeriodo = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(indiceIdPeriodo))

                oComisionEscalaTiempoServicio.Cargo = New Cargo
                oComisionEscalaTiempoServicio.Cargo.IdCargo = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(indiceIdCargo))
                oComisionEscalaTiempoServicio.Cargo.NombreCargo = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceNombreCargo))

                oComisionEscalaTiempoServicio.IdComisionTiempoServicio = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(indiceIdComisionTiempoServicio))
                oComisionEscalaTiempoServicio.PlanVenta = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(indicePlanVenta))
                oComisionEscalaTiempoServicio.IngresoBasico = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(indiceIngresoBasico))
                oComisionEscalaTiempoServicio.TiempoServicio = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(indiceTiempoServicio))

                oListaComisionEscalaTiempoServicio.Add(oComisionEscalaTiempoServicio)
            End While
        End Using
        Return oListaComisionEscalaTiempoServicio
    End Function

    Function Eliminar_ComisionEscalaDetalle(IdComisionEscalaJefe_ As Integer, IdComisionEscalaTipo As Integer) As Integer
        Dim result As Integer

        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_DLT_COMISIONESCALADETALLE)
        oDatabase.AddInParameter(oDbCommand, "@IdComisionEscala", DbType.Int32, IdComisionEscalaJefe_)
        oDatabase.AddInParameter(oDbCommand, "@IdComisionEscalaTipo", DbType.Int32, IdComisionEscalaTipo)

        result = Int32.Parse(oDatabase.ExecuteScalar(oDbCommand).ToString())
        Return result
    End Function

    Function ObtenerComisionEscala(IdPeriodo As Integer, IdCargo As Integer) As ComisionEscala
        Dim oComisionEscala As New ComisionEscala
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_COMISIONESCALA)
        oDatabase.AddInParameter(oDbCommand, "@IdPeriodo", DbType.Int32, IdPeriodo)
        oDatabase.AddInParameter(oDbCommand, "@IdCargo", DbType.Int32, IdCargo)
        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_IdComisionEscala As Integer = oIDataReader.GetOrdinal("IdComisionEscala")
            Dim INDICE_IdPeriodo As Integer = oIDataReader.GetOrdinal("IdPeriodo")
            Dim INDICE_IdCargo As Integer = oIDataReader.GetOrdinal("IdCargo")
            Dim INDICE_PlanVentaFactorAplica As Integer = oIDataReader.GetOrdinal("PlanVentaFactorAplica")
            Dim INDICE_PlanVentaFactor As Integer = oIDataReader.GetOrdinal("PlanVentaFactor")
            Dim INDICE_PlanVentaFactorFechaInicio As Integer = oIDataReader.GetOrdinal("PlanVentaFactorFechaInicio")
            Dim INDICE_PlanVentaFactorFechaFin As Integer = oIDataReader.GetOrdinal("PlanVentaFactorFechaFin")
            Dim INDICE_PlanVentaBonificacionRRVV As Integer = oIDataReader.GetOrdinal("PlanVentaBonificacionRRVV")
            Dim INDICE_PlanVentaBonificacionRRVVPorcentaje As Integer = oIDataReader.GetOrdinal("PlanVentaBonificacionRRVVPorcentaje")
            Dim INDICE_PlanVentaBonificacionRRVVMonto As Integer = oIDataReader.GetOrdinal("PlanVentaBonificacionRRVVMonto")
            Dim INDICE_PlanVentaBonificacionJefe As Integer = oIDataReader.GetOrdinal("PlanVentaBonificacionJefe")
            Dim INDICE_PlanVentaBonificacionJefePorcentaje As Integer = oIDataReader.GetOrdinal("PlanVentaBonificacionJefePorcentaje")
            Dim INDICE_PlanVentaBonificacionJefeMonto As Integer = oIDataReader.GetOrdinal("PlanVentaBonificacionJefeMonto")
            Dim INDICE_CantidadEscalas As Integer = oIDataReader.GetOrdinal("CantidadEscalas")
            Dim INDICE_TiempoServicio As Integer = oIDataReader.GetOrdinal("TiempoServicio")
            Dim INDICE_PlanVenta As Integer = oIDataReader.GetOrdinal("PlanVenta")
            Dim INDICE_Completo As Integer = oIDataReader.GetOrdinal("Completo")

            While oIDataReader.Read()
                oComisionEscala = New ComisionEscala()
                oComisionEscala.IdComisionEscala = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(INDICE_IdComisionEscala))
                oComisionEscala.IdPeriodo = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(INDICE_IdPeriodo))
                'oComisionEscala.Cargo = New Cargo
                'oComisionEscala.Cargo.IdCargo = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(INDICE_IdCargo))
                oComisionEscala.PlanVentaFactorAplica = DataUtil.DbValueToDefault(Of Boolean)(oIDataReader(INDICE_PlanVentaFactorAplica))
                oComisionEscala.PlanVentaFactor = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_PlanVentaFactor))
                oComisionEscala.PlanVentaFactorFechaInicio = DataUtil.DbValueToDefault(Of DateTime)(oIDataReader(INDICE_PlanVentaFactorFechaInicio))
                oComisionEscala.PlanVentaFactorFechaFin = DataUtil.DbValueToDefault(Of DateTime)(oIDataReader(INDICE_PlanVentaFactorFechaFin))
                oComisionEscala.PlanVentaBonificacionRRVV = DataUtil.DbValueToDefault(Of Boolean)(oIDataReader(INDICE_PlanVentaBonificacionRRVV))
                oComisionEscala.PlanVentaBonificacionRRVVPorcentaje = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_PlanVentaBonificacionRRVVPorcentaje))
                oComisionEscala.PlanVentaBonificacionRRVVMonto = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_PlanVentaBonificacionRRVVMonto))
                oComisionEscala.PlanVentaBonificacionJefe = DataUtil.DbValueToDefault(Of Boolean)(oIDataReader(INDICE_PlanVentaBonificacionJefe))
                oComisionEscala.PlanVentaBonificacionJefePorcentaje = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_PlanVentaBonificacionJefePorcentaje))
                oComisionEscala.PlanVentaBonificacionJefeMonto = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_PlanVentaBonificacionJefeMonto))
                oComisionEscala.CantidadEscalas = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(INDICE_CantidadEscalas))
                oComisionEscala.TiempoServicio = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(INDICE_TiempoServicio))
                oComisionEscala.PlanVenta = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_PlanVenta))
                oComisionEscala.Completo = DataUtil.DbValueToDefault(Of Boolean)(oIDataReader(INDICE_Completo))
            End While
        End Using
        Return oComisionEscala
    End Function

    Function ListarComisionEscalaDetalleJefe(IdPeriodo As Integer, IdCargoSuperior As Integer) As ListaComisionEscalaDetalle
        Dim oListaComisionEscalaDetalle As New ListaComisionEscalaDetalle
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_LISTARESCALACOMISIONJEFE)
        oDatabase.AddInParameter(oDbCommand, "@IdPeriodo", DbType.Int32, IdPeriodo)
        oDatabase.AddInParameter(oDbCommand, "@IdCargoSuperior", DbType.Int32, IdCargoSuperior)
        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim oComisionEscalaDetalle As New ComisionEscalaDetalle()

            Dim INDICE_IdComisionEscalaDetalle As Integer = oIDataReader.GetOrdinal("IdComisionEscalaDetalle")
            Dim INDICE_IdComisionEscala As Integer = oIDataReader.GetOrdinal("IdComisionEscala")
            Dim INDICE_PorcentajeInicial As Integer = oIDataReader.GetOrdinal("PorcentajeInicial")
            Dim INDICE_PorcentajeFinal As Integer = oIDataReader.GetOrdinal("PorcentajeFinal")
            Dim INDICE_Bono As Integer = oIDataReader.GetOrdinal("Bono")
            While oIDataReader.Read()
                oComisionEscalaDetalle = New ComisionEscalaDetalle
                oComisionEscalaDetalle.IdComisionEscalaDetalle = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(INDICE_IdComisionEscalaDetalle))
                oComisionEscalaDetalle.IdComisionEscala = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(INDICE_IdComisionEscala))
                oComisionEscalaDetalle.PorcentajeInicial = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_PorcentajeInicial))
                oComisionEscalaDetalle.PorcentajeFinal = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_PorcentajeFinal))
                oComisionEscalaDetalle.Bono = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_Bono))
                oListaComisionEscalaDetalle.Add(oComisionEscalaDetalle)
            End While
        End Using
        Return oListaComisionEscalaDetalle
    End Function

    Function ListarComisionEscalaTiempoServicio(IdPeriodo As Integer, IdCargoRRVV As Integer) As DataContracts.ListaComisionEscalaTiempoServicio
        Dim oListaComisionEscalaTiempoServicio As New ListaComisionEscalaTiempoServicio
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_LISTARTIEMPOSERVICIORRVV)
        oDatabase.AddInParameter(oDbCommand, "@IdPeriodo", DbType.Int32, IdPeriodo)
        oDatabase.AddInParameter(oDbCommand, "@IdCargoRRVV", DbType.Int32, IdCargoRRVV)
        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim oComisionEscalaTiempoServicio As New ComisionEscalaTiempoServicio()

            Dim INDICE_idcomisiontiemposervicio As Integer = oIDataReader.GetOrdinal("idcomisiontiemposervicio")
            Dim INDICE_IdPeriodo As Integer = oIDataReader.GetOrdinal("IdPeriodo")
            Dim INDICE_NombrePeriodo As Integer = oIDataReader.GetOrdinal("NombrePeriodo")
            Dim INDICE_IdCargo As Integer = oIDataReader.GetOrdinal("IdCargo")
            Dim INDICE_TiempoServicio As Integer = oIDataReader.GetOrdinal("TiempoServicio")
            Dim INDICE_PlanVenta As Integer = oIDataReader.GetOrdinal("PlanVenta")
            Dim INDICE_PorcInicial As Integer = oIDataReader.GetOrdinal("PorcInicial")
            Dim INDICE_BonoMin As Integer = oIDataReader.GetOrdinal("BonoMin")
            Dim INDICE_PorcFinal As Integer = oIDataReader.GetOrdinal("PorcFinal")
            Dim INDICE_BonoMax As Integer = oIDataReader.GetOrdinal("BonoMax")

            While oIDataReader.Read()
                oComisionEscalaTiempoServicio = New ComisionEscalaTiempoServicio
                oComisionEscalaTiempoServicio.IdComisionTiempoServicio = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(INDICE_idcomisiontiemposervicio))
                oComisionEscalaTiempoServicio.IdPeriodo = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(INDICE_IdPeriodo))
                oComisionEscalaTiempoServicio.Cargo = New Cargo
                oComisionEscalaTiempoServicio.Cargo.IdCargo = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(INDICE_IdCargo))
                oComisionEscalaTiempoServicio.TiempoServicio = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(INDICE_TiempoServicio))
                oComisionEscalaTiempoServicio.PlanVenta = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_PlanVenta))
                oComisionEscalaTiempoServicio.PorcInicial = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_PorcInicial))
                oComisionEscalaTiempoServicio.BonoMin = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_BonoMin))
                oComisionEscalaTiempoServicio.PorcFinal = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_PorcFinal))
                oComisionEscalaTiempoServicio.BonoMax = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_BonoMax))

                oComisionEscalaTiempoServicio.ComisionPeriodo = New ComisionPeriodo
                oComisionEscalaTiempoServicio.ComisionPeriodo.IdPeriodo = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(INDICE_IdPeriodo))
                oComisionEscalaTiempoServicio.ComisionPeriodo.NombrePeriodo = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_NombrePeriodo))

                oListaComisionEscalaTiempoServicio.Add(oComisionEscalaTiempoServicio)
            End While
        End Using
        Return oListaComisionEscalaTiempoServicio
    End Function

    Function ListarComisionEscalaDetalleRRVV(IdComisionTiempoServicio As Integer) As ListaComisionEscalaDetalle
        Dim oListaComisionEscalaDetalle As New ListaComisionEscalaDetalle
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_LISTARCOMISIONESCALADETALLERRVV)

        oDatabase.AddInParameter(oDbCommand, "@IdComisionTiempoServicio", DbType.Int32, IdComisionTiempoServicio)
        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim oComisionEscalaDetalle As New ComisionEscalaDetalle()

            Dim INDICE_idcomisionescaladetalle As Integer = oIDataReader.GetOrdinal("idcomisionescaladetalle")
            Dim INDICE_idcomisionescalatipo As Integer = oIDataReader.GetOrdinal("idcomisionescalatipo")
            Dim INDICE_idcomisionescala As Integer = oIDataReader.GetOrdinal("idcomisionescala")
            Dim INDICE_porcentajeinicial As Integer = oIDataReader.GetOrdinal("porcentajeinicial")
            Dim INDICE_porcentajefinal As Integer = oIDataReader.GetOrdinal("porcentajefinal")
            Dim INDICE_bono As Integer = oIDataReader.GetOrdinal("bono")
            
            While oIDataReader.Read()
                oComisionEscalaDetalle = New ComisionEscalaDetalle
                oComisionEscalaDetalle.IdComisionEscalaDetalle = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(INDICE_idcomisionescaladetalle))
                oComisionEscalaDetalle.IdComisionEscalaTipo = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(INDICE_idcomisionescalatipo))
                oComisionEscalaDetalle.IdComisionEscala = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(INDICE_idcomisionescala))
                oComisionEscalaDetalle.PorcentajeInicial = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_porcentajeinicial))
                oComisionEscalaDetalle.PorcentajeFinal = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_porcentajefinal))
                oComisionEscalaDetalle.Bono = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_bono))

                oListaComisionEscalaDetalle.Add(oComisionEscalaDetalle)
            End While
        End Using
        Return oListaComisionEscalaDetalle
    End Function

    Function DesactivarEstadoPeriodoComision(IdPeriodo As Integer) As Integer
        Dim resultado As Integer = 0
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_DEL_COMISIONPERIODO)
        oDatabase.AddInParameter(oDbCommand, "@IDPERIODO", DbType.Int32, IdPeriodo)
        resultado = Integer.Parse(oDatabase.ExecuteScalar(oDbCommand))
        Return resultado
    End Function

    Function ListarMesesComisionales(IdNombreMesComisional As String, IdEstado As Integer, FechaIni As String, FechaFin As String, IdPeriodo As Integer, oPaginacion As Paginacion) As ListaComisionPeriodoDetalle
        Dim oListaComisionPeriodoDetalle As New ListaComisionPeriodoDetalle
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_LISTARMESESCOMISIONALES)
        oDatabase.AddInParameter(oDbCommand, "@FechaIni", DbType.String, FechaIni)
        oDatabase.AddInParameter(oDbCommand, "@FechaFin", DbType.String, FechaFin)
        oDatabase.AddInParameter(oDbCommand, "@NombreMesComisional", DbType.String, IdNombreMesComisional)
        oDatabase.AddInParameter(oDbCommand, "@IdEstado", DbType.Int32, IdEstado)

        oDatabase.AddInParameter(oDbCommand, "@page", DbType.Int32, oPaginacion.Page)
        oDatabase.AddInParameter(oDbCommand, "@rowsPerPage", DbType.Int32, oPaginacion.RowsPerPage)
        oDatabase.AddInParameter(oDbCommand, "@IdPeriodo", DbType.Int32, IdPeriodo)
        oDatabase.AddOutParameter(oDbCommand, "@rowCount", DbType.Int32, 0)

        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim oComisionPeriodoDetalle As ComisionPeriodoDetalle

            Dim INDICE_IdPeriodoDetalle As Integer = oIDataReader.GetOrdinal("IdPeriodoDetalle")
            Dim INDICE_Descripcion As Integer = oIDataReader.GetOrdinal("Descripcion")
            Dim INDICE_FechaInicio As Integer = oIDataReader.GetOrdinal("FechaInicio")
            Dim INDICE_FechaFin As Integer = oIDataReader.GetOrdinal("FechaFin")
            Dim INDICE_DescripcionEstado As Integer = oIDataReader.GetOrdinal("Estado")
            Dim INDICE_IdEstado As Integer = oIDataReader.GetOrdinal("IdEstado")
            Dim INDICE_Contador As Integer = oIDataReader.GetOrdinal("Cant")

            While oIDataReader.Read()
                oComisionPeriodoDetalle = New ComisionPeriodoDetalle
                oComisionPeriodoDetalle.IdPeriodoDetalle = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_IdPeriodoDetalle))
                oComisionPeriodoDetalle.Descripcion = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_Descripcion))
                oComisionPeriodoDetalle.FechaIni = DataUtil.DbValueToDefault(Of Date)(oIDataReader(INDICE_FechaInicio))
                oComisionPeriodoDetalle.FechaFin = DataUtil.DbValueToDefault(Of Date)(oIDataReader(INDICE_FechaFin))
                oComisionPeriodoDetalle.DescripcionEstado = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_DescripcionEstado))
                oComisionPeriodoDetalle.IdEstado = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_IdEstado))
                oComisionPeriodoDetalle.Contador = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_Contador))
                oListaComisionPeriodoDetalle.Add(oComisionPeriodoDetalle)
            End While
        End Using
        oPaginacion.TotalRows = Convert.ToInt32(oDatabase.GetParameterValue(oDbCommand, "@rowCount"))
        Return oListaComisionPeriodoDetalle
    End Function

    Function CerrarMesComisional(IdPeriodoDetalle As Integer) As Integer
        Dim resultado As Integer
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_CERRARMESCOMISIONAL)

        oDatabase.AddInParameter(oDbCommand, "@IdPeriodoDetalle", DbType.Int32, IdPeriodoDetalle)
        resultado = Integer.Parse(oDatabase.ExecuteScalar(oDbCommand))
        Return resultado
    End Function

    Function ListarEmpleado(ByVal Cadena As String) As ListaEmpleado
        Dim oListarEmpleado As New ListaEmpleado
        Dim oEmpleado As New Empleado
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_FILTRAR_EMPLEADO_VENTA)
        oDatabase.AddInParameter(oDbCommand, "@Cadena", DbType.String, Cadena)
        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)

            Dim INDICE_IdEmpleado As Integer = oIDataReader.GetOrdinal("IdEmpleado")
            Dim INDICE_NombreApellido As Integer = oIDataReader.GetOrdinal("NombresApellidos")

            While oIDataReader.Read()
                oEmpleado = New Empleado
                oEmpleado.IdEmpleado = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_IdEmpleado))
                oEmpleado.NombresApellidos = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_NombreApellido))
                oListarEmpleado.Add(oEmpleado)
            End While
        End Using
        Return oListarEmpleado
    End Function


    Public Function GuardarComisionAdjunto(ByVal oComisionAdjunto As Archivo, usuario As Integer) As Integer
        Dim Resultado As Integer = 0
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_INS_COMISION_ADJUNTO)
        oDatabase.AddInParameter(oDbCommand, "@IdPeriodo", DbType.Int32, oComisionAdjunto.IdPeriodoComision)
        oDatabase.AddInParameter(oDbCommand, "@IdJefeRRVV", DbType.Int32, oComisionAdjunto.IdJefeRRVV.IdEmpleado)
        oDatabase.AddInParameter(oDbCommand, "@Descripcion", DbType.String, oComisionAdjunto.Descripcion)
        oDatabase.AddInParameter(oDbCommand, "@NombreAdjunto", DbType.String, oComisionAdjunto.OriginalName)
        oDatabase.AddInParameter(oDbCommand, "@TipoContenidoAdj", DbType.String, oComisionAdjunto.ContentType)
        oDatabase.AddInParameter(oDbCommand, "@TamanioAdj", DbType.Int64, oComisionAdjunto.Size)
        oDatabase.AddInParameter(oDbCommand, "@Data", DbType.Binary, oComisionAdjunto.Data)
        oDatabase.AddInParameter(oDbCommand, "@RutaAdj", DbType.String, oComisionAdjunto.Path)
        oDatabase.AddInParameter(oDbCommand, "@AprobadoPor", DbType.String, oComisionAdjunto.AprobadoPor)
        oDatabase.AddInParameter(oDbCommand, "@IdUsuario", DbType.Int32, usuario)
        Resultado = Convert.ToInt32(oDatabase.ExecuteScalar(oDbCommand))
        Return Resultado

    End Function

    Function ListarAdjuntoComision(ByVal IdPeriodo As Integer, oPaginacion As Paginacion, RowCount As Integer) As ListaArchivo
        Dim oListaArchivo As New ListaArchivo
        Dim oArchivo As New Archivo
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_LISTAR_ADJUNTO_COMISION)
        oDatabase.AddInParameter(oDbCommand, "@IdPeriodo", DbType.Int32, IdPeriodo)
        oDatabase.AddInParameter(oDbCommand, "@page", DbType.Int32, oPaginacion.Page)
        oDatabase.AddInParameter(oDbCommand, "@rowsPerPage", DbType.Int32, oPaginacion.RowsPerPage)
        oDatabase.AddOutParameter(oDbCommand, "@rowCount", DbType.Int32, 0)
        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)

            Dim INDICE_IdAdj As Integer = oIDataReader.GetOrdinal("IdAdj")
            Dim INDICE_IdPeriodoComision As Integer = oIDataReader.GetOrdinal("IdPeriodoComision")
            Dim INDICE_NombreApellido As Integer = oIDataReader.GetOrdinal("NombresApellidos")
            Dim INDICE_Descripcion As Integer = oIDataReader.GetOrdinal("Descripcion")
            Dim INDICE_NombreAdj As Integer = oIDataReader.GetOrdinal("NombreAdj")
            Dim INDICE_FechaRegistro As Integer = oIDataReader.GetOrdinal("FechaRegistro")
            Dim INDICE_AprobadoPor As Integer = oIDataReader.GetOrdinal("AprobadoPor")
            Dim INDICE_IdUsuario As Integer = oIDataReader.GetOrdinal("UsuarioUsu")

            While oIDataReader.Read()
                oArchivo = New Archivo
                oArchivo.IdArchivo = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_IdAdj))
                oArchivo.IdPeriodoComision = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_IdPeriodoComision))
                oArchivo.IdJefeRRVV = New Empleado
                oArchivo.IdJefeRRVV.NombresApellidos = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_NombreApellido))
                oArchivo.Descripcion = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_Descripcion))
                oArchivo.OriginalName = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_NombreAdj))
                oArchivo.FechaRegistro = DataUtil.DbValueToDefault(Of Date)(oIDataReader(INDICE_FechaRegistro))
                oArchivo.AprobadoPor = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_AprobadoPor))
                oArchivo.IdUsuario = New Usuario
                oArchivo.IdUsuario.UsuarioUsu = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_IdUsuario))
                oListaArchivo.Add(oArchivo)
            End While
        End Using
        oPaginacion.TotalRows = Convert.ToInt32(oDatabase.GetParameterValue(oDbCommand, "@rowCount"))

        Return oListaArchivo
    End Function

    Public Function EliminarComisionAdjunto(ByVal IdAdjunto As Integer, IdPeriodo As Integer) As Integer
        Dim Resultado As Integer = 0
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_UPDATE_ADJUNTO_COMISION)
        oDatabase.AddInParameter(oDbCommand, "@IdAdjunto", DbType.Int32, IdAdjunto)
        oDatabase.AddInParameter(oDbCommand, "@IdPeriodo", DbType.Int32, IdPeriodo)
        Resultado = Convert.ToInt32(oDatabase.ExecuteScalar(oDbCommand))
        Return Resultado

    End Function

    Function DescargarAdjuntoComision(ByVal IdAdj As Integer) As Archivo
        Dim oArchivo As New Archivo
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_DESCARGAR_ADJUNTO_COMISION)
        oDatabase.AddInParameter(oDbCommand, "@IdAdj", DbType.Int32, IdAdj)
        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)

            Dim INDICE_IdAdj As Integer = oIDataReader.GetOrdinal("IdAdj")
            Dim INDICE_IdPeriodoComision As Integer = oIDataReader.GetOrdinal("IdPeriodoComision")
            Dim INDICE_NombreTemp As Integer = oIDataReader.GetOrdinal("NombreTemp")
            Dim INDICE_NombreAdj As Integer = oIDataReader.GetOrdinal("NombreAdj")
            Dim INDICE_TipoContenidoAdj As Integer = oIDataReader.GetOrdinal("TipoContenidoAdj")
            Dim INDICE_Data As Integer = oIDataReader.GetOrdinal("Data")

            While oIDataReader.Read()
                oArchivo = New Archivo
                oArchivo.IdArchivo = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_IdAdj))
                oArchivo.IdPeriodoComision = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_IdPeriodoComision))
                oArchivo.Name = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_NombreTemp))
                oArchivo.OriginalName = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_NombreAdj))
                oArchivo.ContentType = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_TipoContenidoAdj))
                oArchivo.Data = DataUtil.DbValueToDefault(Of Byte())(oIDataReader(INDICE_Data))
            End While
        End Using

        Return oArchivo
    End Function

    Public Function Actualiza_Estados_MesesComisionales() As Integer
        Dim Resultado As Integer = 0
        Dim OdbcCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_ACTUALIZA_ESTADOPROCESADO_MESCOMISIONAL)
        Resultado = Convert.ToInt32(oDatabase.ExecuteScalar(OdbcCommand))
        Return Resultado
    End Function


    Function CierreMesReporteGuia(IdPeriodoDetalle As Integer) As Integer
        Dim resultado As Integer
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_CIERREMES_REPORTE_GUIA)
        oDatabase.AddInParameter(oDbCommand, "@IdPeriodoDetalle", DbType.Int32, IdPeriodoDetalle)
        oDbCommand.CommandTimeout = 7200000
        resultado = Integer.Parse(oDatabase.ExecuteScalar(oDbCommand))
        Return resultado
    End Function


    Function CierreMesReporteVentas(IdPeriodoDetalle As Integer) As Integer
        Dim resultado As Integer
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_CIERREMES_REPORTE_VENTAS)
        oDatabase.AddInParameter(oDbCommand, "@IdPeriodoDetalle", DbType.Int32, IdPeriodoDetalle)
        oDbCommand.CommandTimeout = 7200000
        resultado = Integer.Parse(oDatabase.ExecuteScalar(oDbCommand))
        Return resultado
    End Function


    Function CierreMesReporteComision(IdPeriodoDetalle As Integer) As Integer
        Dim resultado As Integer
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_CIERREMES_REPORTE_COMISIONES)
        oDatabase.AddInParameter(oDbCommand, "@IdPeriodoDetalle", DbType.Int32, IdPeriodoDetalle)
        oDbCommand.CommandTimeout = 7200000
        resultado = Integer.Parse(oDatabase.ExecuteScalar(oDbCommand))
        Return resultado
    End Function


    Function CierreMesReporteVendedor(IdPeriodoDetalle As Integer) As Integer
        Dim resultado As Integer
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_CIERREMES_REPORTE_RRVV)
        oDatabase.AddInParameter(oDbCommand, "@IdPeriodoDetalle", DbType.Int32, IdPeriodoDetalle)
        oDbCommand.CommandTimeout = 7200000
        resultado = Integer.Parse(oDatabase.ExecuteScalar(oDbCommand))
        Return resultado
    End Function


    Function CierreMesReporteJefeVentas(IdPeriodoDetalle As Integer) As Integer
        Dim resultado As Integer
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_CIERREMES_REPORTE_JEFE_VENTAS)
        oDatabase.AddInParameter(oDbCommand, "@IdPeriodoDetalle", DbType.Int32, IdPeriodoDetalle)
        oDbCommand.CommandTimeout = 7200000
        resultado = Integer.Parse(oDatabase.ExecuteScalar(oDbCommand))
        Return resultado
    End Function

    Function CierreMesReporteHistorialCliente(IdPeriodoDetalle As Integer) As Integer
        Dim resultado As Integer
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_CIERREMES_REPORTE_HISTORIALCLIENTE)
        oDbCommand.CommandTimeout = 7200000
        oDatabase.AddInParameter(oDbCommand, "@IdPeriodoDetalle", DbType.Int32, IdPeriodoDetalle)
        resultado = Integer.Parse(oDatabase.ExecuteScalar(oDbCommand))
        Return resultado
    End Function

    Function CierreMesReporteComisionDetalle(IdPeriodoDetalle As Integer) As Integer
        Dim resultado As Integer
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_CIERREMES_REPORTE_COMISIONESDETALLADO)
        oDatabase.AddInParameter(oDbCommand, "@IdPeriodoDetalle", DbType.Int32, IdPeriodoDetalle)
        oDbCommand.CommandTimeout = 7200000
        resultado = Integer.Parse(oDatabase.ExecuteScalar(oDbCommand))
        Return resultado
    End Function



End Class

