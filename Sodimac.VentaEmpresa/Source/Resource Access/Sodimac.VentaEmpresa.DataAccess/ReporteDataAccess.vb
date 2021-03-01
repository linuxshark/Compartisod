Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Common
Imports System.Linq
Imports System.Text
Imports Sodimac.VentaEmpresa.BusinessEntities
Imports Sodimac.VentaEmpresa.DataContracts
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common.Configuration

Public Class ReporteDataAccess

    Private oDatabase As Database = EnterpriseLibraryContainer.Current.GetInstance(Of Database)(Conexion.cnsSql)
    Private oDataBaseSeg As Database = EnterpriseLibraryContainer.Current.GetInstance(Of Database)(Conexion.cnsSqlSeguridad)

    Public Function SelTransacVentaCreditoPorTienda(fechaIni As Date, fechaFin As Date, codigoTienda As String) As Integer
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_TRANSACVENTACREDITOPORTIENDA)
        oDatabase.AddInParameter(oDbCommand, "@FecIni", DbType.Date, fechaIni)
        oDatabase.AddInParameter(oDbCommand, "@FecFin", DbType.Date, fechaFin)
        oDatabase.AddInParameter(oDbCommand, "@CodigoTienda", DbType.String, codigoTienda)
        Dim valor As Integer
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_VALOR As Integer = oIDataReader.GetOrdinal("VALOR")
            While oIDataReader.Read()
                valor = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_VALOR))
            End While
        End Using
        Return valor
    End Function

    Public Function SelTransacVentaContadoPorTienda(fechaIni As Date, fechaFin As Date, codigoTienda As String) As Integer
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_TRANSACVENTACONTADOPORTIENDA)
        oDatabase.AddInParameter(oDbCommand, "@FecIni", DbType.Date, fechaIni)
        oDatabase.AddInParameter(oDbCommand, "@FecFin", DbType.Date, fechaFin)
        oDatabase.AddInParameter(oDbCommand, "@CodigoTienda", DbType.String, codigoTienda)
        Dim valor As Integer
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_VALOR As Integer = oIDataReader.GetOrdinal("VALOR")
            While oIDataReader.Read()
                valor = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_VALOR))
            End While
        End Using
        Return valor
    End Function


    Public Function SelMargenNetoTotalPorTienda(fechaIni As Date, fechaFin As Date, codigoTienda As String) As Decimal
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_MARGENNETOTOTALPORTIENDA)
        oDatabase.AddInParameter(oDbCommand, "@FecIni", DbType.Date, fechaIni)
        oDatabase.AddInParameter(oDbCommand, "@FecFin", DbType.Date, fechaFin)
        oDatabase.AddInParameter(oDbCommand, "@CodigoTienda", DbType.String, codigoTienda)
        Dim valor As Decimal
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_VALOR As Integer = oIDataReader.GetOrdinal("VALOR")
            While oIDataReader.Read()
                valor = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_VALOR))
            End While
        End Using
        Return valor
    End Function

    Public Function SelMargenNetoTotalPorZona(fechaIni As Date, fechaFin As Date, codigoTienda As String) As Decimal
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_MARGENNETOTOTALPORZONA)
        oDatabase.AddInParameter(oDbCommand, "@FecIni", DbType.Date, fechaIni)
        oDatabase.AddInParameter(oDbCommand, "@FecFin", DbType.Date, fechaFin)
        oDatabase.AddInParameter(oDbCommand, "@CodigoZona", DbType.String, codigoTienda)
        Dim valor As Decimal
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_VALOR As Integer = oIDataReader.GetOrdinal("VALOR")
            While oIDataReader.Read()
                valor = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_VALOR))
            End While
        End Using
        Return valor
    End Function

    Public Function SelMargenNetoTotal(fechaIni As Date, fechaFin As Date) As Decimal
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_MARGENNETOTOTAL)
        oDatabase.AddInParameter(oDbCommand, "@FecIni", DbType.Date, fechaIni)
        oDatabase.AddInParameter(oDbCommand, "@FecFin", DbType.Date, fechaFin)
        '  oDatabase.AddInParameter(oDbCommand, "@CodigoZona", DbType.String, codigoTienda)
        Dim valor As Decimal
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_VALOR As Integer = oIDataReader.GetOrdinal("VALOR")
            While oIDataReader.Read()
                valor = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_VALOR))
            End While
        End Using
        Return valor
    End Function


    Public Function SelMargenNetoCreditoPorTienda(fechaIni As Date, fechaFin As Date, codigoTienda As String) As Decimal
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_MARGENNETOCREDITOPORTIENDA)
        oDatabase.AddInParameter(oDbCommand, "@FecIni", DbType.Date, fechaIni)
        oDatabase.AddInParameter(oDbCommand, "@FecFin", DbType.Date, fechaFin)
        oDatabase.AddInParameter(oDbCommand, "@CodigoTienda", DbType.String, codigoTienda)
        Dim valor As Decimal
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_VALOR As Integer = oIDataReader.GetOrdinal("VALOR")
            While oIDataReader.Read()
                valor = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_VALOR))
            End While
        End Using
        Return valor
    End Function

    Public Function SelMargenNetoCreditoPorZona(fechaIni As Date, fechaFin As Date, codigoZona As Integer) As Decimal
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_MARGENNETOCREDITOPORZONA)
        oDatabase.AddInParameter(oDbCommand, "@FecIni", DbType.Date, fechaIni)
        oDatabase.AddInParameter(oDbCommand, "@FecFin", DbType.Date, fechaFin)
        oDatabase.AddInParameter(oDbCommand, "@CodigoZona", DbType.String, codigoZona)
        Dim valor As Decimal
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_VALOR As Integer = oIDataReader.GetOrdinal("VALOR")
            While oIDataReader.Read()
                valor = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_VALOR))
            End While
        End Using
        Return valor
    End Function

    Public Function SelMargenNetoContadoPorTienda(fechaIni As Date, fechaFin As Date, codigoTienda As String) As Decimal
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_MARGENNETOCONTADOPORTIENDA)
        oDatabase.AddInParameter(oDbCommand, "@FecIni", DbType.Date, fechaIni)
        oDatabase.AddInParameter(oDbCommand, "@FecFin", DbType.Date, fechaFin)
        oDatabase.AddInParameter(oDbCommand, "@CodigoTienda", DbType.String, codigoTienda)
        Dim valor As Decimal
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_VALOR As Integer = oIDataReader.GetOrdinal("VALOR")
            While oIDataReader.Read()
                valor = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_VALOR))
            End While
        End Using
        Return valor
    End Function

    Public Function SelMargenNetoContadoPorZona(fechaIni As Date, fechaFin As Date, codigoZona As Integer) As Decimal
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_MARGENNETOCONTADOPORZONA)
        oDatabase.AddInParameter(oDbCommand, "@FecIni", DbType.Date, fechaIni)
        oDatabase.AddInParameter(oDbCommand, "@FecFin", DbType.Date, fechaFin)
        oDatabase.AddInParameter(oDbCommand, "@CodigoZona", DbType.Int32, codigoZona)
        Dim valor As Decimal
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_VALOR As Integer = oIDataReader.GetOrdinal("VALOR")
            While oIDataReader.Read()
                valor = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_VALOR))
            End While
        End Using
        Return valor
    End Function

    Public Function SelMargenTotalContado(fechaIni As Date, fechaFin As Date) As Decimal
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_MARGENTOTALCONTADO)
        oDatabase.AddInParameter(oDbCommand, "@FecIni", DbType.Date, fechaIni)
        oDatabase.AddInParameter(oDbCommand, "@FecFin", DbType.Date, fechaFin)
        'oDatabase.AddInParameter(oDbCommand, "@CodigoZona", DbType.Int32, codigoZona)
        Dim valor As Decimal
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_VALOR As Integer = oIDataReader.GetOrdinal("VALOR")
            While oIDataReader.Read()
                valor = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_VALOR))
            End While
        End Using
        Return valor
    End Function

    Public Function SelMargenTotalCredito(fechaIni As Date, fechaFin As Date) As Decimal
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_MARGENTOTALCREDITO)
        oDatabase.AddInParameter(oDbCommand, "@FecIni", DbType.Date, fechaIni)
        oDatabase.AddInParameter(oDbCommand, "@FecFin", DbType.Date, fechaFin)
        'oDatabase.AddInParameter(oDbCommand, "@CodigoZona", DbType.Int32, codigoZona)
        Dim valor As Decimal
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_VALOR As Integer = oIDataReader.GetOrdinal("VALOR")
            While oIDataReader.Read()
                valor = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_VALOR))
            End While
        End Using
        Return valor
    End Function


    Public Function SelPlanMargenPorTienda(fecha As Date, codigoMarca As Integer) As Decimal
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_PLANMARGENPORTIENDA)
        oDatabase.AddInParameter(oDbCommand, "@ReportCreationDate", DbType.Date, fecha)
        oDatabase.AddInParameter(oDbCommand, "@CodigoEmpresa", DbType.Int16, codigoMarca)
        Dim valor As Decimal
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_VALOR As Integer = oIDataReader.GetOrdinal("VALOR")
            While oIDataReader.Read()
                valor = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_VALOR))
            End While
        End Using
        Return valor
    End Function

    Public Function SelVentaInteranual(fecIni As Date, fecFin As Date, codigoTienda As String) As Decimal
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_VENTAINTERANUAL)
        oDatabase.AddInParameter(oDbCommand, "@FecIniVI", DbType.Date, fecIni)
        oDatabase.AddInParameter(oDbCommand, "@FecFinVI", DbType.Date, fecFin)
        oDatabase.AddInParameter(oDbCommand, "@CodigoTienda", DbType.String, codigoTienda)
        Dim valor As Decimal
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_TOTAL As Integer = oIDataReader.GetOrdinal("TOTAL")
            While oIDataReader.Read()
                valor = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_TOTAL))
            End While
        End Using
        Return valor
    End Function

    Public Sub SelPeriodosVentaInteranual(fecIni As Date, fecFin As Date, ByRef fecIniVI As Date, ByRef fecFinVI As Date)
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_PERIODOSVENTAINTERANUAL)
        oDatabase.AddInParameter(oDbCommand, "@FecIniReporte", DbType.Date, fecIni)
        oDatabase.AddInParameter(oDbCommand, "@FecFinReporte", DbType.Date, fecFin)
        oDatabase.AddOutParameter(oDbCommand, "@FecIniVI", DbType.Date, 50)
        oDatabase.AddOutParameter(oDbCommand, "@FecFinVI", DbType.Date, 50)
        oDatabase.ExecuteNonQuery(oDbCommand)
        fecIniVI = oDbCommand.Parameters("@FecIniVI").Value
        fecFinVI = oDbCommand.Parameters("@FecFinVI").Value
    End Sub

    Public Function SelVentaNetaCreditoPorTienda(fecIni As Date, fecFin As Date, codigoTienda As Integer) As Decimal
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_VENTANETACREDITOPORTIENDA)
        oDatabase.AddInParameter(oDbCommand, "@FECINI", DbType.Date, fecIni)
        oDatabase.AddInParameter(oDbCommand, "@FECFIN", DbType.Date, fecFin)
        oDatabase.AddInParameter(oDbCommand, "@CODIGOTIENDA", DbType.String, codigoTienda)
        Dim valor As Decimal
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_TOTAL As Integer = oIDataReader.GetOrdinal("TOTAL")
            While oIDataReader.Read()
                valor = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_TOTAL))
            End While
        End Using
        Return valor
    End Function

    Public Function SelVentaNetaContadoPorTienda(fecIni As Date, fecFin As Date, codigoTienda As Integer) As Decimal
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_VENTANETACONTADOPORTIENDA)
        oDatabase.AddInParameter(oDbCommand, "@FECINI", DbType.Date, fecIni)
        oDatabase.AddInParameter(oDbCommand, "@FECFIN", DbType.Date, fecFin)
        oDatabase.AddInParameter(oDbCommand, "@CODIGOTIENDA", DbType.String, codigoTienda)
        oDbCommand.CommandTimeout = 0
        Dim valor As Decimal
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_TOTAL As Integer = oIDataReader.GetOrdinal("TOTAL")
            While oIDataReader.Read()
                valor = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_TOTAL))
            End While
        End Using
        Return valor
    End Function


    Public Function SelPlanVentaPorTienda(fecha As Date, codigoTienda As String) As Double
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_PLANVENTAPORTIENDA)
        oDatabase.AddInParameter(oDbCommand, "@REPORTCREATIONDATE", DbType.Date, fecha)
        oDatabase.AddInParameter(oDbCommand, "@CODIGOTIENDA", DbType.String, codigoTienda)
        Dim valor As Double
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_VALOR As Integer = oIDataReader.GetOrdinal("VALOR")
            While oIDataReader.Read()
                valor = DataUtil.DbValueToDefault(Of Double)(oIDataReader(INDICE_VALOR))
            End While
        End Using
        Return valor
    End Function

    Public Function SelDiasUtilesyDiasAvancePorMes(fecha As DateTime) As String
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_DIASUTILESYDIASAVANCEPORMES)
        oDatabase.AddInParameter(oDbCommand, "@FECHA", DbType.Date, fecha)
        Dim DiasUtiles As Integer
        Dim DiasAvance As Integer
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_DIASUTILES As Integer = oIDataReader.GetOrdinal("DIASUTILES")
            Dim INDICE_DIASAVANCE As Integer = oIDataReader.GetOrdinal("DIASAVANCE")
            While oIDataReader.Read()
                DiasUtiles = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_DIASUTILES))
                DiasAvance = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_DIASAVANCE))
            End While
        End Using
        Return DiasUtiles.ToString() & ";" & DiasAvance.ToString()
    End Function

    Public Function ListaSucursalesPorZonaReporteVE(idZona As Integer) As List(Of Sucursal)
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_LISTASUCURSALES_REPORTEVE)
        oDatabase.AddInParameter(oDbCommand, "@IDZONA", DbType.Int32, idZona)
        Dim oListaSucursal As New List(Of Sucursal)
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_IDZONA As Integer = oIDataReader.GetOrdinal("IDZONA")
            Dim INDICE_CODIGOTIENDA As Integer = oIDataReader.GetOrdinal("CODIGOTIENDA")
            Dim INDICE_TIENDA As Integer = oIDataReader.GetOrdinal("TIENDA")
            Dim INDICE_SUCURSAL As Integer = oIDataReader.GetOrdinal("IdSucursal")
            While oIDataReader.Read()
                Dim oSucursal As New Sucursal
                oSucursal.IdZona = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_IDZONA))
                oSucursal.CodigoSucursal = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_CODIGOTIENDA))
                oSucursal.Descripcion = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_TIENDA))
                oSucursal.IdSucursal = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_SUCURSAL))
                oListaSucursal.Add(oSucursal)
            End While
        End Using
        Return oListaSucursal
    End Function

    Public Function ListaZonasReporteVE() As List(Of Zona)
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_LISTAZONAS_REPORTEVE)
        Dim oListaZona As New List(Of Zona)
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_IDZONA As Integer = oIDataReader.GetOrdinal("IDZONA")
            Dim INDICE_NOMBREZONA As Integer = oIDataReader.GetOrdinal("NOMBREZONA")
            While oIDataReader.Read()
                Dim oZona As New Zona
                oZona.IdZona = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_IDZONA))
                oZona.NombreZona = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_NOMBREZONA))
                oListaZona.Add(oZona)
            End While
        End Using
        Return oListaZona
    End Function


    Public Function SelDiasUtilesDelMes(fecha As DateTime) As Integer
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_DIASUTILESDELMES)
        oDatabase.AddInParameter(oDbCommand, "@FECHA", DbType.Date, fecha)
        Dim DiasUtiles As Integer
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_DIASUTILES As Integer = oIDataReader.GetOrdinal("DIASUTILES")
            While oIDataReader.Read()
                DiasUtiles = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_DIASUTILES))
            End While
        End Using
        Return DiasUtiles
    End Function

    Public Function SelDiasDeAvance(fecha As DateTime) As Integer
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_DIASDEAVANCE)
        oDatabase.AddInParameter(oDbCommand, "@REPORTCREATIONDATE", DbType.Date, fecha)
        oDbCommand.CommandTimeout = 30
        Dim DiasDeAvance As Integer
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_DIASDEAVANCE As Integer = oIDataReader.GetOrdinal("DIASDEAVANCE")
            While oIDataReader.Read()
                DiasDeAvance = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_DIASDEAVANCE))
            End While
        End Using
        Return DiasDeAvance
    End Function

    Public Function ListaSucursalesReporteVE(idZona As Integer) As List(Of Sucursal)
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_LISTASUCURSALES_REPORTEVE)
        oDatabase.AddInParameter(oDbCommand, "@IDZONA", DbType.Int32, idZona)
        Dim oListaSucursal As New List(Of Sucursal)
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_IDZONA As Integer = oIDataReader.GetOrdinal("IDZONA")
            Dim INDICE_CODIGOTIENDA As Integer = oIDataReader.GetOrdinal("CODIGOTIENDA")
            Dim INDICE_TIENDA As Integer = oIDataReader.GetOrdinal("TIENDA")
            While oIDataReader.Read()
                Dim oSucursal As New Sucursal
                oSucursal.IdZona = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_IDZONA))
                oSucursal.CodigoSucursal = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_CODIGOTIENDA))
                oSucursal.Descripcion = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_TIENDA))
                oListaSucursal.Add(oSucursal)
            End While
        End Using
        Return oListaSucursal
    End Function



    Public Function BuscarSucursal() As ListaSucursal
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_REPORTE_GUIA_FILTROSUCURSAL)
        Dim oListaSucursal As New ListaSucursal()
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_IDSUCURSAL As Integer = oIDataReader.GetOrdinal("IdSucursal")
            Dim INDICE_CODIGOSUCURSAL As Integer = oIDataReader.GetOrdinal("CodigoSucursal")
            Dim INDICE_DESCRIPCION As Integer = oIDataReader.GetOrdinal("Descripcion")
            While oIDataReader.Read()
                Dim oSucursal As New Sucursal()
                oSucursal.IdSucursal = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_IDSUCURSAL))
                oSucursal.CodigoSucursal = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_CODIGOSUCURSAL))
                oSucursal.DescripcionSucursal = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_DESCRIPCION))
                oListaSucursal.Add(oSucursal)
            End While
        End Using
        Return oListaSucursal
    End Function

    Function BuscarSucursal3(usuario As String) As ListaSucursal
        Dim oListaSucursal As New ListaSucursal()
        Dim oSucursal As New Sucursal()
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_REPORTE_GUIA_FILTROSUCURSAL_3)
        oDatabase.AddInParameter(oDbCommand, "@IdUsuario", DbType.String, usuario)

        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)

            Dim INDICE_IDSUCURSAL As Integer = oIDataReader.GetOrdinal("IdSucursal")
            Dim INDICE_DESCRIPCION As Integer = oIDataReader.GetOrdinal("Descripcion")

            While oIDataReader.Read()
                oSucursal = New Sucursal()
                oSucursal.IdSucursal = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_IDSUCURSAL))
                oSucursal.DescripcionSucursal = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_DESCRIPCION))
                oListaSucursal.Add(oSucursal)
            End While

        End Using
        Return oListaSucursal
    End Function

    Function BuscarSucursal2(ByVal ZonaCadena As String, usuario As String, FechaIniP As String, FechaFinP As String) As ListaSucursal
        Dim oListaSucursal As New ListaSucursal()
        Dim oSucursal As New Sucursal()
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_REPORTE_GUIA_FILTROSUCURSAL)

        Dim F1, F2 As String

        If FechaIniP <> "" And FechaFinP <> "" Then
            Dim FechaInD As DateTime = Convert.ToDateTime(FechaIniP)
            Dim FechaFiD As DateTime = Convert.ToDateTime(FechaFinP)
            Dim Mes As String = Constantes.ValorDefecto
            Dim dia As String = Constantes.ValorDefecto
            Dim Mes2 As String = Constantes.ValorDefecto
            Dim dia2 As String = Constantes.ValorDefecto

            If Convert.ToString(FechaInD.Month).Length = 1 Then
                Mes = "0" & Convert.ToString(FechaInD.Month)
            Else
                Mes = Convert.ToString(FechaInD.Month)
            End If

            If Convert.ToString(FechaInD.Day).Length = 1 Then
                dia = "0" & Convert.ToString(FechaInD.Day)
            Else
                dia = Convert.ToString(FechaInD.Day)
            End If

            If Convert.ToString(FechaFiD.Month).Length = 1 Then
                Mes2 = "0" & Convert.ToString(FechaFiD.Month)
            Else
                Mes2 = Convert.ToString(FechaFiD.Month)
            End If

            If Convert.ToString(FechaFiD.Day).Length = 1 Then
                dia2 = "0" & Convert.ToString(FechaFiD.Day)
            Else
                dia2 = Convert.ToString(FechaFiD.Day)
            End If

            F1 = Convert.ToString(FechaInD.Year) & Mes & dia
            F2 = Convert.ToString(FechaFiD.Year) & Mes2 & dia2
        Else
            F1 = FechaIniP
            F2 = FechaFinP

        End If

        oDatabase.AddInParameter(oDbCommand, "@IdUsuario", DbType.String, usuario)
        oDatabase.AddInParameter(oDbCommand, "@IdZona", DbType.String, ZonaCadena)
        oDatabase.AddInParameter(oDbCommand, "@FechaIni", DbType.String, F1)
        oDatabase.AddInParameter(oDbCommand, "@FechaFin", DbType.String, F2)
        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)

            Dim INDICE_IDSUCURSAL As Integer = oIDataReader.GetOrdinal("IdSucursal")
            Dim INDICE_DESCRIPCION As Integer = oIDataReader.GetOrdinal("Descripcion")

            While oIDataReader.Read()
                oSucursal = New Sucursal()
                oSucursal.IdSucursal = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_IDSUCURSAL))
                oSucursal.DescripcionSucursal = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_DESCRIPCION))
                oListaSucursal.Add(oSucursal)
            End While

        End Using
        Return oListaSucursal
    End Function

    Public Function BuscarSucursalVentas(IdJefeRegional As Integer) As ListaSucursal
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_REPORTE_VENTAS_FILTROSUCURSAL, IdJefeRegional)
        Dim oListaSucursal As New ListaSucursal()
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_IDSUCURSAL As Integer = oIDataReader.GetOrdinal("IdSucursal")
            Dim INDICE_NOMBRESUCURSAL As Integer = oIDataReader.GetOrdinal("NombreSucursal")
            While oIDataReader.Read()
                Dim oSucursal As New Sucursal()
                oSucursal.IdSucursal = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_IDSUCURSAL))
                oSucursal.DescripcionSucursal = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_NOMBRESUCURSAL))
                oListaSucursal.Add(oSucursal)
            End While
        End Using
        Return oListaSucursal
    End Function

    Public Function BuscarSucursalVendedores() As ListaSucursal
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_REPORTE_VENDEDORES_FILTROSUCURSAL)
        Dim oListaSucursal As New ListaSucursal()
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_IDSUCURSALACTUAL As Integer = oIDataReader.GetOrdinal("IdSucursal")
            Dim INDICE_DESCRIPCION As Integer = oIDataReader.GetOrdinal("DescSucursal")
            While oIDataReader.Read()
                Dim oSucursal As New Sucursal()
                oSucursal.DescripcionSucursal = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_DESCRIPCION))
                oSucursal.IdSucursal = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_IDSUCURSALACTUAL))
                oListaSucursal.Add(oSucursal)
            End While
        End Using
        Return oListaSucursal
    End Function

    Public Function BuscarZonaJefeRegional() As ListaZona
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_REPORTE_JEFEREGIONAL_FILTROZONA)
        Dim oListaZona As New ListaZona()
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_IDZONA As Integer = oIDataReader.GetOrdinal("IdZona")
            Dim INDICE_DESCZONA As Integer = oIDataReader.GetOrdinal("DescZona")
            While oIDataReader.Read()
                Dim oZona As New Zona()
                oZona.IdZona = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_IDZONA))
                oZona.DescZona = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_DESCZONA))
                oListaZona.Add(oZona)
            End While
        End Using
        Return oListaZona
    End Function

    Public Function BuscarSucursalTiendas() As ListaSucursal
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_REPORTE_TIENDA_FILTROSUCURSAL)
        Dim oListaSucursal As New ListaSucursal()
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_IDSUCURSAL As Integer = oIDataReader.GetOrdinal("IdSucursal")
            Dim INDICE_DESCRIPCION As Integer = oIDataReader.GetOrdinal("Descripcion")
            While oIDataReader.Read()
                Dim oSucursal As New Sucursal()
                oSucursal.IdSucursal = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_IDSUCURSAL))
                oSucursal.Descripcion = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_DESCRIPCION))
                oListaSucursal.Add(oSucursal)
            End While
        End Using
        Return oListaSucursal
    End Function

    Public Function BuscarSectorClientes() As ListaClienteSector
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_REPORTE_CLIENTE_FILTROSECTOR)
        Dim oListaClienteSector As New ListaClienteSector()
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_CLIENTESECTOR As Integer = oIDataReader.GetOrdinal("IdClienteSector")
            Dim INDICE_DESCRIPCIONCORTA As Integer = oIDataReader.GetOrdinal("DescripcionCorta")
            While oIDataReader.Read()
                Dim oClienteSector As New ClienteSector()
                oClienteSector.IdClienteSector = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_CLIENTESECTOR))
                oClienteSector.DescripcionCorta = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_DESCRIPCIONCORTA))
                oListaClienteSector.Add(oClienteSector)
            End While
        End Using
        Return oListaClienteSector
    End Function

    Public Function BuscarCategoriaClientes() As ListaClienteCategoria
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_REPORTE_CLIENTE_FILTROCATEGORIA)
        Dim oListaClienteCategoria As New ListaClienteCategoria()
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_IDCLIENTECATEGORIA As Integer = oIDataReader.GetOrdinal("IdClienteCategoria")
            Dim INDICE_DESCRIPCION As Integer = oIDataReader.GetOrdinal("Descripcion")
            While oIDataReader.Read()
                Dim oClienteCategoria As New ClienteCategoria()
                oClienteCategoria.IdClienteCategoria = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_IDCLIENTECATEGORIA))
                oClienteCategoria.Descripcion = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_DESCRIPCION))
                oListaClienteCategoria.Add(oClienteCategoria)
            End While
        End Using
        Return oListaClienteCategoria
    End Function

    Public Function BuscarFormaPagoClientes() As ListaClienteModoPagoCombo
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_REPORTE_CLIENTE_FILTROFORMAPAGO)
        Dim oListaClienteModoPagoCombo As New ListaClienteModoPagoCombo()
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_IDMODOPAGO As Integer = oIDataReader.GetOrdinal("IdModoPago")
            Dim INDICE_DESCRIPCION As Integer = oIDataReader.GetOrdinal("Descripcion")
            While oIDataReader.Read()
                Dim oClienteModoPagoCombo As New ClienteModoPagoCombo()
                oClienteModoPagoCombo.IdModoPago = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_IDMODOPAGO))
                oClienteModoPagoCombo.Descripcion = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_DESCRIPCION))
                oListaClienteModoPagoCombo.Add(oClienteModoPagoCombo)
            End While
        End Using
        Return oListaClienteModoPagoCombo
    End Function

    Public Function BuscarZonaTiendas() As ListaZona
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_REPORTE_TIENDA_FILTROZONA)
        Dim oListaZona As New ListaZona()
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_IDZONA As Integer = oIDataReader.GetOrdinal("IdZona")
            Dim INDICE_DESCRIPCIONCORTA As Integer = oIDataReader.GetOrdinal("DescripcionCorta")
            While oIDataReader.Read()
                Dim oZona As New Zona()
                oZona.IdZona = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_IDZONA))
                oZona.DescripcionCorta = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_DESCRIPCIONCORTA))
                oListaZona.Add(oZona)
            End While
        End Using
        Return oListaZona
    End Function

    Public Function BuscarTipoClientes() As ListaClienteTipo
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_REPORTE_CLIENTE_FILTROTIPOCLIENTE)
        Dim oListaClienteTipo As New ListaClienteTipo()
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_IDCLIENTETIPO As Integer = oIDataReader.GetOrdinal("IdClienteTipo")
            Dim INDICE_DESCRIPCION As Integer = oIDataReader.GetOrdinal("Descripcion")
            While oIDataReader.Read()
                Dim oClienteTipo As New ClienteTipo()
                oClienteTipo.IdClienteTipo = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_IDCLIENTETIPO))
                oClienteTipo.Descripcion = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_DESCRIPCION))
                oListaClienteTipo.Add(oClienteTipo)
            End While
        End Using
        Return oListaClienteTipo
    End Function

    Public Function BuscarJefeRegionalVendedores() As ListaEmpleado
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_REPORTE_VENDEDORES_FILTROJEFEREGIONAL)
        Dim oListaEmpleado As New ListaEmpleado()
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_IDJEFEVENTAS As Integer = oIDataReader.GetOrdinal("IdJefeVentas")
            Dim INDICE_NOMBRESAPELLIDOS As Integer = oIDataReader.GetOrdinal("NombresApellidos")
            While oIDataReader.Read()
                Dim oEmpleado As New Empleado()
                oEmpleado.IdJefeVentas = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_IDJEFEVENTAS))
                oEmpleado.NombresApellidos = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_NOMBRESAPELLIDOS))
                oListaEmpleado.Add(oEmpleado)
            End While
        End Using
        Return oListaEmpleado
    End Function

    Public Function BuscarVendedoresVentas(IdSucursal As Integer) As ListaEmpleado
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_REPORTE_VENTAS_FILTROVENDEDOR, IdSucursal)
        Dim oListaEmpleado As New ListaEmpleado()
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_IDEMPLEADO As Integer = oIDataReader.GetOrdinal("IdEmpleado")
            Dim INDICE_NOMBRESAPELLIDOS As Integer = oIDataReader.GetOrdinal("NombresApellidos")
            While oIDataReader.Read()
                Dim oEmpleado As New Empleado()
                oEmpleado.IdEmpleado = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_IDEMPLEADO))
                oEmpleado.NombresApellidos = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_NOMBRESAPELLIDOS))
                oListaEmpleado.Add(oEmpleado)
            End While
        End Using
        Return oListaEmpleado
    End Function

    Public Function BuscarJefeRegionalAvanceVenta(ByVal usuario As String, subGerente As String, idZona As String) As ListaEmpleado
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_REPORTE_AVANCE_VENTA_FiltroSubGerente)
        oDatabase.AddInParameter(oDbCommand, "@UsuarioUsu", DbType.String, usuario)
        oDatabase.AddInParameter(oDbCommand, "@IdSubGerente", DbType.String, subGerente)
        oDatabase.AddInParameter(oDbCommand, "@IdZona", DbType.String, idZona)
        Dim oListaEmpleado As New ListaEmpleado()
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_IDEMPLEADO As Integer = oIDataReader.GetOrdinal("IdEmpleado")
            Dim INDICE_NOMBRESAPELLIDOS As Integer = oIDataReader.GetOrdinal("NombresApellidos")
            While oIDataReader.Read()
                Dim oEmpleado As New Empleado()
                oEmpleado.IdEmpleado = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_IDEMPLEADO))
                oEmpleado.NombresApellidos = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_NOMBRESAPELLIDOS))
                oListaEmpleado.Add(oEmpleado)
            End While
        End Using
        Return oListaEmpleado
    End Function


    Public Function BuscarJefeRegionalVentas(ByVal usuario As String, FechaIniP As String, FechaFinP As String) As ListaEmpleado

        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_REPORTE_VENTAS_FILTROJEFEREGIONAL)
        Dim oListaEmpleado As New ListaEmpleado()

        Dim F1, F2 As String

        If FechaIniP <> "" And FechaFinP <> "" Then
            Dim FechaInD As DateTime = Convert.ToDateTime(FechaIniP)
            Dim FechaFiD As DateTime = Convert.ToDateTime(FechaFinP)
            Dim Mes As String = Constantes.ValorDefecto
            Dim dia As String = Constantes.ValorDefecto
            Dim Mes2 As String = Constantes.ValorDefecto
            Dim dia2 As String = Constantes.ValorDefecto

            If Convert.ToString(FechaInD.Month).Length = 1 Then
                Mes = "0" & Convert.ToString(FechaInD.Month)
            Else
                Mes = Convert.ToString(FechaInD.Month)
            End If

            If Convert.ToString(FechaInD.Day).Length = 1 Then
                dia = "0" & Convert.ToString(FechaInD.Day)
            Else
                dia = Convert.ToString(FechaInD.Day)
            End If

            If Convert.ToString(FechaFiD.Month).Length = 1 Then
                Mes2 = "0" & Convert.ToString(FechaFiD.Month)
            Else
                Mes2 = Convert.ToString(FechaFiD.Month)
            End If

            If Convert.ToString(FechaFiD.Day).Length = 1 Then
                dia2 = "0" & Convert.ToString(FechaFiD.Day)
            Else
                dia2 = Convert.ToString(FechaFiD.Day)
            End If

            F1 = Convert.ToString(FechaInD.Year) & Mes & dia
            F2 = Convert.ToString(FechaFiD.Year) & Mes2 & dia2
        Else
            F1 = FechaIniP
            F2 = FechaFinP

        End If
        oDatabase.AddInParameter(oDbCommand, "@UsuarioUsu", DbType.String, usuario)
        oDatabase.AddInParameter(oDbCommand, "@FechaIni", DbType.String, F1)
        oDatabase.AddInParameter(oDbCommand, "@FechaFin", DbType.String, F2)
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_IDEMPLEADO As Integer = oIDataReader.GetOrdinal("IdEmpleado")
            Dim INDICE_NOMBRESAPELLIDOS As Integer = oIDataReader.GetOrdinal("NombresApellidos")
            While oIDataReader.Read()
                Dim oEmpleado As New Empleado()
                oEmpleado.IdEmpleado = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_IDEMPLEADO))
                oEmpleado.NombresApellidos = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_NOMBRESAPELLIDOS))
                oListaEmpleado.Add(oEmpleado)
            End While
        End Using
        Return oListaEmpleado
    End Function

    'Reporte de Ventas
    Public Function BuscarJefeRegionalVentas_Ventas(ByVal usuario As String, FechaIniP As String, FechaFinP As String) As ListaEmpleado

        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_REPORTE_VENTAS_FILTROJEFEREGIONAL_VENTAS)
        Dim oListaEmpleado As New ListaEmpleado()

        Dim F1, F2 As String

        If FechaIniP <> "" And FechaFinP <> "" Then
            Dim FechaInD As DateTime = Convert.ToDateTime(FechaIniP)
            Dim FechaFiD As DateTime = Convert.ToDateTime(FechaFinP)
            Dim Mes As String = Constantes.ValorDefecto
            Dim dia As String = Constantes.ValorDefecto
            Dim Mes2 As String = Constantes.ValorDefecto
            Dim dia2 As String = Constantes.ValorDefecto

            If Convert.ToString(FechaInD.Month).Length = 1 Then
                Mes = "0" & Convert.ToString(FechaInD.Month)
            Else
                Mes = Convert.ToString(FechaInD.Month)
            End If

            If Convert.ToString(FechaInD.Day).Length = 1 Then
                dia = "0" & Convert.ToString(FechaInD.Day)
            Else
                dia = Convert.ToString(FechaInD.Day)
            End If

            If Convert.ToString(FechaFiD.Month).Length = 1 Then
                Mes2 = "0" & Convert.ToString(FechaFiD.Month)
            Else
                Mes2 = Convert.ToString(FechaFiD.Month)
            End If

            If Convert.ToString(FechaFiD.Day).Length = 1 Then
                dia2 = "0" & Convert.ToString(FechaFiD.Day)
            Else
                dia2 = Convert.ToString(FechaFiD.Day)
            End If

            F1 = Convert.ToString(FechaInD.Year) & Mes & dia
            F2 = Convert.ToString(FechaFiD.Year) & Mes2 & dia2
        Else
            F1 = FechaIniP
            F2 = FechaFinP

        End If
        oDatabase.AddInParameter(oDbCommand, "@UsuarioUsu", DbType.String, usuario)
        oDatabase.AddInParameter(oDbCommand, "@FechaIni", DbType.String, F1)
        oDatabase.AddInParameter(oDbCommand, "@FechaFin", DbType.String, F2)
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_IDEMPLEADO As Integer = oIDataReader.GetOrdinal("IdEmpleado")
            Dim INDICE_NOMBRESAPELLIDOS As Integer = oIDataReader.GetOrdinal("NombresApellidos")
            While oIDataReader.Read()
                Dim oEmpleado As New Empleado()
                oEmpleado.IdEmpleado = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_IDEMPLEADO))
                oEmpleado.NombresApellidos = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_NOMBRESAPELLIDOS))
                oListaEmpleado.Add(oEmpleado)
            End While
        End Using
        Return oListaEmpleado
    End Function

    Function BuscarSucursalByZona(IdZona As Integer) As ListaSucursal
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_REPORTE_VENTAS_FILTROSUCURSAL_BYZONA, IdZona)
        Dim oListaSucursal As New ListaSucursal()
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_IDSUCURSAL As Integer = oIDataReader.GetOrdinal("IdSucursal")
            Dim INDICE_NOMBRESUCURSAL As Integer = oIDataReader.GetOrdinal("NombreSucursal")
            While oIDataReader.Read()
                Dim oSucursal As New Sucursal()
                oSucursal.IdSucursal = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_IDSUCURSAL))
                oSucursal.DescripcionSucursal = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_NOMBRESUCURSAL))
                oListaSucursal.Add(oSucursal)
            End While
        End Using
        Return oListaSucursal
    End Function

    Function ListarVendedores(ByVal usuario As String, ByVal jefe As String, ByVal FechaIniP As String, ByVal FechaFinP As String) As ListaEmpleado
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_REPORTE_VENDEDORES)
        Dim oListaEmpleado As New ListaEmpleado()

        Dim F1, F2 As String

        If FechaIniP <> "" And FechaFinP <> "" Then
            Dim FechaInD As DateTime = Convert.ToDateTime(FechaIniP)
            Dim FechaFiD As DateTime = Convert.ToDateTime(FechaFinP)
            Dim Mes As String = Constantes.ValorDefecto
            Dim dia As String = Constantes.ValorDefecto
            Dim Mes2 As String = Constantes.ValorDefecto
            Dim dia2 As String = Constantes.ValorDefecto

            If Convert.ToString(FechaInD.Month).Length = 1 Then
                Mes = "0" & Convert.ToString(FechaInD.Month)
            Else
                Mes = Convert.ToString(FechaInD.Month)
            End If

            If Convert.ToString(FechaInD.Day).Length = 1 Then
                dia = "0" & Convert.ToString(FechaInD.Day)
            Else
                dia = Convert.ToString(FechaInD.Day)
            End If

            If Convert.ToString(FechaFiD.Month).Length = 1 Then
                Mes2 = "0" & Convert.ToString(FechaFiD.Month)
            Else
                Mes2 = Convert.ToString(FechaFiD.Month)
            End If

            If Convert.ToString(FechaFiD.Day).Length = 1 Then
                dia2 = "0" & Convert.ToString(FechaFiD.Day)
            Else
                dia2 = Convert.ToString(FechaFiD.Day)
            End If

            F1 = Convert.ToString(FechaInD.Year) & Mes & dia
            F2 = Convert.ToString(FechaFiD.Year) & Mes2 & dia2
        Else
            F1 = FechaIniP
            F2 = FechaFinP

        End If
        oDatabase.AddInParameter(oDbCommand, "@UsuarioUsu", DbType.String, usuario)
        oDatabase.AddInParameter(oDbCommand, "@Jefe", DbType.String, jefe)
        oDatabase.AddInParameter(oDbCommand, "@FechaIni", DbType.String, F1)
        oDatabase.AddInParameter(oDbCommand, "@FechaFin", DbType.String, F2)
        'Dim idUsuario = Convert.ToInt32(HttpContext.Current.Session("CodigoUsuario"))
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_IDEMPLEADO As Integer = oIDataReader.GetOrdinal("IdEmpleado")
            Dim INDICE_NOMBRESAPELLIDOS As Integer = oIDataReader.GetOrdinal("NombresApellidos")
            While oIDataReader.Read()
                Dim oEmpleado As New Empleado()
                oEmpleado.IdEmpleado = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(INDICE_IDEMPLEADO))
                oEmpleado.NombresApellidos = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_NOMBRESAPELLIDOS))
                oListaEmpleado.Add(oEmpleado)

            End While
        End Using
        Return oListaEmpleado
    End Function

    Function ListarSubGerente() As ListaEmpleado
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEl_LISTASUBGERENTE)
        Dim oListaEmpleado As New ListaEmpleado()

        'Dim idUsuario = Convert.ToInt32(HttpContext.Current.Session("CodigoUsuario"))
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_IDEMPLEADO As Integer = oIDataReader.GetOrdinal("IdEmpleado")
            Dim INDICE_NOMBRESAPELLIDOS As Integer = oIDataReader.GetOrdinal("SubGerente")
            While oIDataReader.Read()
                Dim oEmpleado As New Empleado()
                oEmpleado.IdEmpleado = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(INDICE_IDEMPLEADO))
                oEmpleado.NombresApellidos = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_NOMBRESAPELLIDOS))
                oListaEmpleado.Add(oEmpleado)
            End While
        End Using
        Return oListaEmpleado
    End Function

    Function ListarVendedores_G(ByVal usuario As String, ByVal jefe As String, ByVal FechaIniP As String, ByVal FechaFinP As String) As ListaEmpleado
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_REPORTE_VENDEDORES_G)
        Dim oListaEmpleado As New ListaEmpleado()

        Dim F1, F2 As String

        If FechaIniP <> "" And FechaFinP <> "" Then
            Dim FechaInD As DateTime = Convert.ToDateTime(FechaIniP)
            Dim FechaFiD As DateTime = Convert.ToDateTime(FechaFinP)
            Dim Mes As String = Constantes.ValorDefecto
            Dim dia As String = Constantes.ValorDefecto
            Dim Mes2 As String = Constantes.ValorDefecto
            Dim dia2 As String = Constantes.ValorDefecto

            If Convert.ToString(FechaInD.Month).Length = 1 Then
                Mes = "0" & Convert.ToString(FechaInD.Month)
            Else
                Mes = Convert.ToString(FechaInD.Month)
            End If

            If Convert.ToString(FechaInD.Day).Length = 1 Then
                dia = "0" & Convert.ToString(FechaInD.Day)
            Else
                dia = Convert.ToString(FechaInD.Day)
            End If

            If Convert.ToString(FechaFiD.Month).Length = 1 Then
                Mes2 = "0" & Convert.ToString(FechaFiD.Month)
            Else
                Mes2 = Convert.ToString(FechaFiD.Month)
            End If

            If Convert.ToString(FechaFiD.Day).Length = 1 Then
                dia2 = "0" & Convert.ToString(FechaFiD.Day)
            Else
                dia2 = Convert.ToString(FechaFiD.Day)
            End If

            F1 = Convert.ToString(FechaInD.Year) & Mes & dia
            F2 = Convert.ToString(FechaFiD.Year) & Mes2 & dia2
        Else
            F1 = FechaIniP
            F2 = FechaFinP

        End If
        oDatabase.AddInParameter(oDbCommand, "@UsuarioUsu", DbType.String, usuario)
        oDatabase.AddInParameter(oDbCommand, "@Jefe", DbType.String, jefe)
        oDatabase.AddInParameter(oDbCommand, "@FechaIni", DbType.String, F1)
        oDatabase.AddInParameter(oDbCommand, "@FechaFin", DbType.String, F2)
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_IDEMPLEADO As Integer = oIDataReader.GetOrdinal("IdEmpleado")
            Dim INDICE_NOMBRESAPELLIDOS As Integer = oIDataReader.GetOrdinal("NombresApellidos")
            While oIDataReader.Read()
                Dim oEmpleado As New Empleado()
                oEmpleado.IdEmpleado = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(INDICE_IDEMPLEADO))
                oEmpleado.NombresApellidos = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_NOMBRESAPELLIDOS))
                oListaEmpleado.Add(oEmpleado)

            End While
        End Using
        Return oListaEmpleado
    End Function

    Function ListarSucursales() As ListaSucursal
        Dim oListaSucursal As New ListaSucursal()

        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_LISTARSUCURSAL)
        oDbCommand.CommandTimeout = 120000
        ' oListaSucursal = New ListaSucursal
        Dim oSucursal As New Sucursal()
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_IdSucursal As Integer = oIDataReader.GetOrdinal("IdSucursal")
            Dim INDICE_Descripcion As Integer = oIDataReader.GetOrdinal("Descripcion")
            While oIDataReader.Read()
                oSucursal = New Sucursal
                oSucursal.IdSucursal = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_IdSucursal))
                oSucursal.Descripcion = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_Descripcion))
                oListaSucursal.Add(oSucursal)
            End While
        End Using
        Return oListaSucursal
    End Function

    Function ListarSucursales_CodigoSucursal() As ListaSucursal
        Dim oListaSucursal As New ListaSucursal()

        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_LISTARSUCURSAL)
        oDbCommand.CommandTimeout = 120000
        ' oListaSucursal = New ListaSucursal
        Dim oSucursal As New Sucursal()
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_IdSucursal As Integer = oIDataReader.GetOrdinal("IdSucursal")
            Dim INDICE_Descripcion As Integer = oIDataReader.GetOrdinal("Descripcion")
            Dim INDICE_CodigoSucursal As Integer = oIDataReader.GetOrdinal("CodigoSucursal")
            While oIDataReader.Read()
                oSucursal = New Sucursal
                oSucursal.IdSucursal = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_IdSucursal))
                oSucursal.Descripcion = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_Descripcion))
                oSucursal.CodigoSucursal = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_CodigoSucursal))
                oListaSucursal.Add(oSucursal)
            End While
        End Using
        Return oListaSucursal
    End Function

    Function ListarEstados() As ListaClienteEstadoLinea

        Dim oListaEstado As New ListaClienteEstadoLinea()

        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_REPORTE_CLIENTE_FILTROESTADOLINEA)
        oDbCommand.CommandTimeout = 120000

        Dim oEstado As New Estado()
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_IdEstadoLinea As Integer = oIDataReader.GetOrdinal("IdEstadoLinea")
            Dim INDICE_Descripcion As Integer = oIDataReader.GetOrdinal("Descripcion")
            While oIDataReader.Read()
                oEstado = New Estado
                oEstado.IdEstado = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_IdEstadoLinea))
                oEstado.Descripcion = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_Descripcion))
                oListaEstado.Add(oEstado)
            End While
        End Using
        Return oListaEstado
    End Function
    Function ListaZonaMantenimiento3(usuario As String) As ListaZonaMantenimiento
        Dim oListaZonaMantenimiento As New ListaZonaMantenimiento()
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_ZONACBOREPORTE)
        oDatabase.AddInParameter(oDbCommand, "@UsuarioUsu", DbType.String, usuario)

        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_IdZona As Integer = oIDataReader.GetOrdinal("IdZona")
            Dim INDICE_NombreZona As Integer = oIDataReader.GetOrdinal("NombreZona")
            While oIDataReader.Read()
                Dim oZonaMantenimiento = New ZonaMantenimiento()
                oZonaMantenimiento.IdZona = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_IdZona))
                oZonaMantenimiento.NombreZona = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_NombreZona))
                oListaZonaMantenimiento.Add(oZonaMantenimiento)
            End While
        End Using
        Return oListaZonaMantenimiento
    End Function

    Function ListaZonaMantenimiento() As ListaZonaMantenimiento
        Dim oListaZonaMantenimiento As New ListaZonaMantenimiento()
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_ZONACBO)

        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_IdZona As Integer = oIDataReader.GetOrdinal("IdZona")
            Dim INDICE_NombreZona As Integer = oIDataReader.GetOrdinal("NombreZona")
            While oIDataReader.Read()
                Dim oZonaMantenimiento = New ZonaMantenimiento()
                oZonaMantenimiento.IdZona = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_IdZona))
                oZonaMantenimiento.NombreZona = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_NombreZona))
                oListaZonaMantenimiento.Add(oZonaMantenimiento)
            End While
        End Using
        Return oListaZonaMantenimiento
    End Function

    Public Function ListarSucursalZona_Cliente(IdZona As String, Usuario As String) As ListaSucursal
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_REPORTE_CLIENTE_FILTROSUCURSAL, IdZona, Usuario)
        Dim oListaSucursal As New ListaSucursal()
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_IDSUCURSAL As Integer = oIDataReader.GetOrdinal("IdSucursal")
            Dim INDICE_NOMBRESUCURSAL As Integer = oIDataReader.GetOrdinal("Descripcion")
            While oIDataReader.Read()
                Dim oSucursal As New Sucursal()
                oSucursal.IdSucursal = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_IDSUCURSAL))
                oSucursal.DescripcionSucursal = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_NOMBRESUCURSAL))
                oListaSucursal.Add(oSucursal)
            End While
        End Using
        Return oListaSucursal
    End Function

    Public Function ListaReporteVenta(
            fechainicio As String,
            fechafin As String,
            jeferegional As String,
            zona As String,
            sucursal As String,
            vendedor As String,
            ruc As String,
            razonsocial As String,
            tipocliente1 As String,
            idgrupo1 As String,
            usuarioUsu As String) As List(Of ReportVenta)

        Try
            Dim oListaSucursal As New List(Of ReportVenta)
            Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_REPORTE_VENTAS_EXPORTAR)
            oDatabase.AddInParameter(oDbCommand, "@FechaInicio", DbType.String, fechainicio)
            oDatabase.AddInParameter(oDbCommand, "@FechaFin", DbType.String, fechafin)
            oDatabase.AddInParameter(oDbCommand, "@JefeRegional", DbType.String, jeferegional)
            oDatabase.AddInParameter(oDbCommand, "@Zona", DbType.String, zona)
            oDatabase.AddInParameter(oDbCommand, "@Sucursal", DbType.String, sucursal)
            oDatabase.AddInParameter(oDbCommand, "@Vendedor", DbType.String, vendedor)
            oDatabase.AddInParameter(oDbCommand, "@Ruc", DbType.String, ruc)
            oDatabase.AddInParameter(oDbCommand, "@RazonSocial", DbType.String, razonsocial)
            oDatabase.AddInParameter(oDbCommand, "@TipoCliente1", DbType.String, tipocliente1)
            oDatabase.AddInParameter(oDbCommand, "@IdGrupo1", DbType.String, idgrupo1)
            oDatabase.AddInParameter(oDbCommand, "@UsuarioUsu", DbType.String, usuarioUsu)

            oDbCommand.CommandTimeout = 120000
            Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)

                Dim INDICE_1 As Integer = oIDataReader.GetOrdinal("Descripcion")
                Dim INDICE_2 As Integer = oIDataReader.GetOrdinal("NumeroDocumento")
                Dim INDICE_3 As Integer = oIDataReader.GetOrdinal("RUC")
                Dim INDICE_4 As Integer = oIDataReader.GetOrdinal("RazonSocial")
                Dim INDICE_5 As Integer = oIDataReader.GetOrdinal("CodigoProveedor")
                Dim INDICE_6 As Integer = oIDataReader.GetOrdinal("NombreProveedor")
                Dim INDICE_7 As Integer = oIDataReader.GetOrdinal("MARCA")
                Dim INDICE_8 As Integer = oIDataReader.GetOrdinal("DescZona")
                Dim INDICE_9 As Integer = oIDataReader.GetOrdinal("DescGrupo")
                Dim INDICE_10 As Integer = oIDataReader.GetOrdinal("CodigoSucursal")
                Dim INDICE_11 As Integer = oIDataReader.GetOrdinal("NombreSucursal")
                Dim INDICE_12 As Integer = oIDataReader.GetOrdinal("CodigoRRVV")
                Dim INDICE_13 As Integer = oIDataReader.GetOrdinal("RepresentanteVenta")
                Dim INDICE_14 As Integer = oIDataReader.GetOrdinal("JefeVentas")
                Dim INDICE_15 As Integer = oIDataReader.GetOrdinal("TipoCliente")
                Dim INDICE_16 As Integer = oIDataReader.GetOrdinal("Fecha1")
                Dim INDICE_17 As Integer = oIDataReader.GetOrdinal("TipoCaja")
                Dim INDICE_18 As Integer = oIDataReader.GetOrdinal("FormaPago")
                Dim INDICE_19 As Integer = oIDataReader.GetOrdinal("SKU")
                Dim INDICE_20 As Integer = oIDataReader.GetOrdinal("DescripcionSKU")
                Dim INDICE_21 As Integer = oIDataReader.GetOrdinal("ClaCom")
                Dim INDICE_22 As Integer = oIDataReader.GetOrdinal("DescripcionClaCom")
                Dim INDICE_27 As Integer = oIDataReader.GetOrdinal("Cantidad")
                Dim INDICE_28 As Integer = oIDataReader.GetOrdinal("PrecioNeto")
                Dim INDICE_29 As Integer = oIDataReader.GetOrdinal("Subtotal")
                Dim INDICE_30 As Integer = oIDataReader.GetOrdinal("IGV")
                Dim INDICE_31 As Integer = oIDataReader.GetOrdinal("Total")
                Dim INDICE_32 As Integer = oIDataReader.GetOrdinal("CostoTotal")
                Dim INDICE_33 As Integer = oIDataReader.GetOrdinal("Margen")
                Dim INDICE_34 As Integer = oIDataReader.GetOrdinal("Contribucion")
                Dim INDICE_35 As Integer = oIDataReader.GetOrdinal("PercepcionPorcentaje")
                Dim INDICE_36 As Integer = oIDataReader.GetOrdinal("MontoPercepcion")
                Dim INDICE_37 As Integer = oIDataReader.GetOrdinal("TotalVtaIgvPercepcion")
                Dim INDICE_38 As Integer = oIDataReader.GetOrdinal("COD_DEP_NUE")
                Dim INDICE_39 As Integer = oIDataReader.GetOrdinal("NOM_DEP_NUE")
                Dim INDICE_40 As Integer = oIDataReader.GetOrdinal("COD_FAM_NUE")
                Dim INDICE_41 As Integer = oIDataReader.GetOrdinal("NOM_FAM_NUE")
                Dim INDICE_42 As Integer = oIDataReader.GetOrdinal("NomEmpresa")
                Dim INDICE_43 As Integer = oIDataReader.GetOrdinal("SubGerente")
                Dim INDICE_44 As Integer = oIDataReader.GetOrdinal("CostoUnitario")
                Dim INDICE_45 As Integer = oIDataReader.GetOrdinal("NumeroDocRelacionado")
                Dim INDICE_46 As Integer = oIDataReader.GetOrdinal("TipoDocRelacionado")


                While oIDataReader.Read()
                    Dim oReportVenta As New ReportVenta()
                    oReportVenta.TipoDocumento = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_1))
                    oReportVenta.Correlativo = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_2))
                    oReportVenta.Ruc = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_3))
                    oReportVenta.RazonSocial = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_4))
                    oReportVenta.CodigoProveedor = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_5))
                    oReportVenta.NombreProveedor = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_6))
                    oReportVenta.Marca = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_7))
                    oReportVenta.Zona = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_8))
                    oReportVenta.Grupo = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_9))
                    oReportVenta.CodigoSucursal = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_10))
                    oReportVenta.DescripcionSucursal = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_11))
                    oReportVenta.CodigoRRVV = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_12))
                    oReportVenta.RepresentanteVentas = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_13))
                    oReportVenta.JefeVentas = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_14))
                    oReportVenta.TipoCliente = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_15))
                    oReportVenta.Fecha = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_16))
                    oReportVenta.TipoCaja = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_17))
                    oReportVenta.ModoPago = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_18))
                    oReportVenta.SKU = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_19))
                    oReportVenta.DescripcionSKU = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_20))
                    oReportVenta.CLACOM = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_21))
                    oReportVenta.DescripcionCLACOM = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_22))
                    oReportVenta.Cantidad = Convert.ToInt32(DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_27)))
                    oReportVenta.ValorVenta = Decimal.Round(DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_28)), 2)
                    oReportVenta.SubTotal = Decimal.Round(DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_29)), 2)
                    oReportVenta.IGV = Decimal.Round(DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_30)), 2)
                    oReportVenta.Total = Decimal.Round(DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_31)), 2)
                    oReportVenta.CostoTotal = Decimal.Round(DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_32)), 2)
                    oReportVenta.Margen = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_33)) * 100
                    oReportVenta.Contribucion = Decimal.Round(DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_34)), 2)
                    oReportVenta.Percepcion = Decimal.Round(DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_35)), 2) * 100
                    oReportVenta.MontoPercepcion = Decimal.Round(DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_36)), 2)
                    oReportVenta.TotalIGV_Percepcion = Decimal.Round(DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_37)), 2)
                    oReportVenta.DPTONuevo = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_38))
                    oReportVenta.DescDPTONuevo = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_39))
                    oReportVenta.FamiliaNueva = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_40))
                    oReportVenta.DescripcionFamiliaNueva = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_41))

                    oReportVenta.NomEmpresa = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_42))
                    oReportVenta.SubGerente = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_43))
                    oReportVenta.CostoUnitario = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_44))
                    oReportVenta.DocRelacionado = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_45))
                    oReportVenta.TipoDocRelacionado = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_46))
                    oListaSucursal.Add(oReportVenta)
                End While
            End Using
            Return oListaSucursal
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function ListarEmpresas() As ListaEmpresa
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_LISTAR_EMPRESA)
        Dim oListaEmpresa As New ListaEmpresa()
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim IndiceIdEmpresa As Integer = oIDataReader.GetOrdinal("IdEmpresa")
            Dim IndiceNomEmpresa As Integer = oIDataReader.GetOrdinal("NomEmpresa")
            While oIDataReader.Read()
                Dim oEmpresa As New Empresa()
                oEmpresa.IdEmpresa = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(IndiceIdEmpresa))
                oEmpresa.NomEmpresa = DataUtil.DbValueToDefault(Of String)(oIDataReader(IndiceNomEmpresa))
                oListaEmpresa.Add(oEmpresa)
            End While
        End Using
        Return oListaEmpresa
    End Function

    Public Function BuscarSucursal(Empresa As String) As ListaSucursal
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_LISTAR_SUCURSAL_EMPRESA)
        oDatabase.AddInParameter(oDbCommand, "@IdEmpresa", DbType.String, Empresa)
        oDbCommand.CommandTimeout = 0
        Dim oListaSucursal As New ListaSucursal()
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim IndiceIdSucursal As Integer = oIDataReader.GetOrdinal("IdSucursal")
            Dim IndiceDescripcion As Integer = oIDataReader.GetOrdinal("Descripcion")
            While oIDataReader.Read()
                Dim oSucursal As New Sucursal()
                oSucursal.IdSucursal = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(IndiceIdSucursal))
                oSucursal.DescripcionSucursal = DataUtil.DbValueToDefault(Of String)(oIDataReader(IndiceDescripcion))
                oListaSucursal.Add(oSucursal)
            End While
        End Using
        Return oListaSucursal
    End Function

    Public Function ListarMarcas() As List(Of Marca)
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_LISTAMARCAS)
        Dim oListaMarca As New List(Of Marca)
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim IndiceIdMarca As Integer = oIDataReader.GetOrdinal("IDMARCA")
            Dim IndiceNomMarca As Integer = oIDataReader.GetOrdinal("NOMBREMARCA")
            While oIDataReader.Read()
                Dim oMarca As New Marca()
                oMarca.IdMarca = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(IndiceIdMarca))
                oMarca.NomMarca = DataUtil.DbValueToDefault(Of String)(oIDataReader(IndiceNomMarca))
                oListaMarca.Add(oMarca)
            End While
        End Using
        Return oListaMarca
    End Function

    Public Function SelReporteDetalladoPorFamilia(ByVal fecIni As Date, ByVal fecFin As Date) As List(Of ReporteVentaEmpresa)
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.Usp_Sel_Detallado_Por_Familia)
        Dim oListaReporteEmpresa As New List(Of ReporteVentaEmpresa)
        oDatabase.AddInParameter(oDbCommand, "@FECHAINI", DbType.Date, fecIni)
        oDatabase.AddInParameter(oDbCommand, "@FECHAFIN", DbType.Date, fecFin)
        oDbCommand.CommandTimeout = 0
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            While oIDataReader.Read()
                Dim oReporteEmpresa As ReporteVentaEmpresa = New ReporteVentaEmpresa()
                oReporteEmpresa.IdZona = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(oIDataReader.GetOrdinal("IDZONA")))
                oReporteEmpresa.NombreZona = DataUtil.DbValueToDefault(Of String)(oIDataReader(oIDataReader.GetOrdinal("NOMBREZONA")))
                oReporteEmpresa.CodigoTienda = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(oIDataReader.GetOrdinal("CODIGOTIENDA")))
                oReporteEmpresa.Tienda = DataUtil.DbValueToDefault(Of String)(oIDataReader(oIDataReader.GetOrdinal("TIENDA")))
                oReporteEmpresa.CodigoFamilia = DataUtil.DbValueToDefault(Of String)(oIDataReader(oIDataReader.GetOrdinal("COD_FAM_NUE")))
                oReporteEmpresa.Familia = DataUtil.DbValueToDefault(Of String)(oIDataReader(oIDataReader.GetOrdinal("FAMILIA")))
                oReporteEmpresa.Venta = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(oIDataReader.GetOrdinal("VENTA")))
                oReporteEmpresa.Margen = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(oIDataReader.GetOrdinal("MARGEN")))
                oReporteEmpresa.Transacciones = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(oIDataReader.GetOrdinal("TRANSACCIONES")))
                oReporteEmpresa.TicketPromedio = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(oIDataReader.GetOrdinal("TICKETPROMEDIO")))
                oListaReporteEmpresa.Add(oReporteEmpresa)

            End While
        End Using
        Return oListaReporteEmpresa
    End Function

    Public Function SelReporteDetalladoPorFamiliaZonaContado(ByVal fecIni As Date, ByVal CodigoZona As String) As Decimal
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.Usp_Sel_ComparativoFamiliaPorZona)
        oDatabase.AddInParameter(oDbCommand, "@Fecha", DbType.Date, fecIni)
        oDatabase.AddInParameter(oDbCommand, "@CodigoZona", DbType.String, CodigoZona)
        Dim valor As Decimal
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_VALOR As Integer = oIDataReader.GetOrdinal("VALOr")
            While oIDataReader.Read()
                valor = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_VALOR))
            End While
        End Using
        Return valor
    End Function


    Public Function SelReporteTranssaccionTotal(ByVal fecIni As Date) As Decimal
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_TRANSACVENTATOTAL)
        oDatabase.AddInParameter(oDbCommand, "@Fecha", DbType.Date, fecIni)

        Dim valor As Integer
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_VALOR As Integer = oIDataReader.GetOrdinal("Valor")
            While oIDataReader.Read()
                valor = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_VALOR))
            End While
        End Using
        Return valor
    End Function


    Public Function SelReporteTranssaccionPorsucursal(ByVal fecIni As Date, ByVal CodigoSucursal As String) As Decimal
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_TRANSACVENTACONTADOPORSUCURSAL)
        oDatabase.AddInParameter(oDbCommand, "@Fecha", DbType.Date, fecIni)
        oDatabase.AddInParameter(oDbCommand, "@CodigoSucursal", DbType.String, CodigoSucursal)
        Dim valor As Integer
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_VALOR As Integer = oIDataReader.GetOrdinal("Valor")
            While oIDataReader.Read()
                valor = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_VALOR))
            End While
        End Using
        Return valor
    End Function
    Public Function SelReporteTranssaccionPorsucursalCredito(ByVal fecIni As Date, ByVal CodigoSucursal As String) As Decimal
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_TRANSACVENTACREDITOPORSUCURSAL)
        oDatabase.AddInParameter(oDbCommand, "@Fecha", DbType.Date, fecIni)
        oDatabase.AddInParameter(oDbCommand, "@CodigoSucursal", DbType.String, CodigoSucursal)
        Dim valor As Integer
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_VALOR As Integer = oIDataReader.GetOrdinal("Valor")
            While oIDataReader.Read()
                valor = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_VALOR))
            End While
        End Using
        Return valor
    End Function


    Public Function SelReporteTranssaccionPorFamilia(ByVal FechaIni As Date, ByVal FechaFin As Date, ByVal CodigoSucursal As String, ByVal CodigoFamilia As String) As Decimal
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.Usp_Sel_VentaPorFamilia)
        oDatabase.AddInParameter(oDbCommand, "@FechaIni", DbType.Date, FechaIni)
        oDatabase.AddInParameter(oDbCommand, "@FechaFin", DbType.Date, FechaFin)
        oDatabase.AddInParameter(oDbCommand, "@CodigoSucursal", DbType.String, CodigoSucursal)
        oDatabase.AddInParameter(oDbCommand, "@CodigoFamilia", DbType.String, CodigoFamilia)
        Dim valor As Integer
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_VALOR As Integer = oIDataReader.GetOrdinal("Valor")
            While oIDataReader.Read()
                valor = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_VALOR))
            End While
        End Using
        Return valor
    End Function

    Public Function SelReporteTranssaccionPorFamiliaTicket(ByVal FechaIni As Date, ByVal FechaFin As Date, ByVal CodigoSucursal As String, ByVal CodigoFamilia As String) As Decimal
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.Usp_Sel_VentaPorFamiliaTicket)
        oDatabase.AddInParameter(oDbCommand, "@FechaIni", DbType.Date, FechaIni)
        oDatabase.AddInParameter(oDbCommand, "@FechaFin", DbType.Date, FechaFin)
        oDatabase.AddInParameter(oDbCommand, "@CodigoSucursal", DbType.String, CodigoSucursal)
        oDatabase.AddInParameter(oDbCommand, "@CodigoFamilia", DbType.String, CodigoFamilia)
        Dim valor As Decimal
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_VALOR As Integer = oIDataReader.GetOrdinal("Valor")
            While oIDataReader.Read()
                valor = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_VALOR))
            End While
        End Using
        Return valor
    End Function


    Public Function SelReporteTranssaccionPorFamiliaTotalTicket(ByVal FechaIni As Date, ByVal FechaFin As Date, ByVal CodigoFamilia As String) As Decimal
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.Usp_Sel_DetalladoPorFamiliaTotalTicket)
        oDatabase.AddInParameter(oDbCommand, "@FechaIni", DbType.Date, FechaIni)
        oDatabase.AddInParameter(oDbCommand, "@FechaFin", DbType.Date, FechaFin)
        'oDatabase.AddInParameter(oDbCommand, "@CodigoSucursal", DbType.String, CodigoSucursal)
        oDatabase.AddInParameter(oDbCommand, "@CodigoFamilia", DbType.String, CodigoFamilia)
        Dim valor As Decimal
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_VALOR As Integer = oIDataReader.GetOrdinal("Valor")
            While oIDataReader.Read()
                valor = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_VALOR))
            End While
        End Using
        Return valor
    End Function


    Public Function SelReporteTotalTicketSucursalContado(ByVal FechaIni As Date, ByVal FechaFin As Date, ByVal CodigoSucursal As String) As Decimal
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_TOTALTICKETSUCURSALCONTADO)
        oDatabase.AddInParameter(oDbCommand, "@FechaIni", DbType.Date, FechaIni)
        oDatabase.AddInParameter(oDbCommand, "@FechaFin", DbType.Date, FechaFin)
        oDatabase.AddInParameter(oDbCommand, "@CodigoSucursal", DbType.String, CodigoSucursal)
        'oDatabase.AddInParameter(oDbCommand, "@CodigoFamilia", DbType.String, CodigoFamilia)
        Dim valor As Decimal
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_VALOR As Integer = oIDataReader.GetOrdinal("Valor")
            While oIDataReader.Read()
                valor = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_VALOR))
            End While
        End Using
        Return valor
    End Function

    Public Function SelReporteTotalTicketSucursalCredito(ByVal FechaIni As Date, ByVal FechaFin As Date, ByVal CodigoSucursal As String) As Decimal
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_TOTALTICKETSUCURSALCREDITO)
        oDatabase.AddInParameter(oDbCommand, "@FechaIni", DbType.Date, FechaIni)
        oDatabase.AddInParameter(oDbCommand, "@FechaFin", DbType.Date, FechaFin)
        oDatabase.AddInParameter(oDbCommand, "@CodigoSucursal", DbType.String, CodigoSucursal)
        'oDatabase.AddInParameter(oDbCommand, "@CodigoFamilia", DbType.String, CodigoFamilia)
        Dim valor As Decimal
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_VALOR As Integer = oIDataReader.GetOrdinal("Valor")
            While oIDataReader.Read()
                valor = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_VALOR))
            End While
        End Using
        Return valor
    End Function

    Public Function SelReporteTotalTicketZonaContado(ByVal FechaIni As Date, ByVal FechaFin As Date, ByVal CodigoZona As String) As Decimal
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_TOTALTICKETZONACONTADO)
        oDatabase.AddInParameter(oDbCommand, "@FechaIni", DbType.Date, FechaIni)
        oDatabase.AddInParameter(oDbCommand, "@FechaFin", DbType.Date, FechaFin)
        oDatabase.AddInParameter(oDbCommand, "@CodigoZona", DbType.String, CodigoZona)
        'oDatabase.AddInParameter(oDbCommand, "@CodigoFamilia", DbType.String, CodigoFamilia)
        Dim valor As Decimal
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_VALOR As Integer = oIDataReader.GetOrdinal("Valor")
            While oIDataReader.Read()
                valor = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_VALOR))
            End While
        End Using
        Return valor
    End Function


    Public Function SelReporteTotalTicket(ByVal FechaIni As Date, ByVal FechaFin As Date, ByVal CodigoSucursal As String) As Decimal
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_TOTALTICKETTOTAL)
        oDatabase.AddInParameter(oDbCommand, "@FechaIni", DbType.Date, FechaIni)
        oDatabase.AddInParameter(oDbCommand, "@FechaFin", DbType.Date, FechaFin)
        oDatabase.AddInParameter(oDbCommand, "@CodigoSucursal", DbType.String, CodigoSucursal)
        'oDatabase.AddInParameter(oDbCommand, "@CodigoFamilia", DbType.String, CodigoFamilia)
        Dim valor As Decimal
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_VALOR As Integer = oIDataReader.GetOrdinal("Valor")
            While oIDataReader.Read()
                valor = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_VALOR))
            End While
        End Using
        Return valor
    End Function


    Public Function SelReporteTotalTicketZonaCredito(ByVal FechaIni As Date, ByVal FechaFin As Date, ByVal CodigoZona As String) As Decimal
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_TOTALTICKETZONACREDITO)
        oDatabase.AddInParameter(oDbCommand, "@FechaIni", DbType.Date, FechaIni)
        oDatabase.AddInParameter(oDbCommand, "@FechaFin", DbType.Date, FechaFin)
        oDatabase.AddInParameter(oDbCommand, "@CodigoZona", DbType.String, CodigoZona)
        'oDatabase.AddInParameter(oDbCommand, "@CodigoFamilia", DbType.String, CodigoFamilia)
        Dim valor As Decimal
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_VALOR As Integer = oIDataReader.GetOrdinal("Valor")
            While oIDataReader.Read()
                valor = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_VALOR))
            End While
        End Using
        Return valor
    End Function




    Public Function SelReporteDetalladoPorFamiliaTotalContado(ByVal fecIni As Date) As Decimal
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.Usp_Sel_ComparativoFamiliaNetoContado)
        oDatabase.AddInParameter(oDbCommand, "@Fecha", DbType.Date, fecIni)
        ' oDatabase.AddInParameter(oDbCommand, "@CodigoZona", DbType.String, CodigoZona)
        Dim valor As Decimal
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_VALOR As Integer = oIDataReader.GetOrdinal("VALOr")
            While oIDataReader.Read()
                valor = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_VALOR))
            End While
        End Using
        Return valor
    End Function

    Public Function SelReporteDetalladoPorFamiliaZonaCredito(ByVal fecIni As Date, ByVal CodigoZona As String) As Decimal
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.Usp_Sel_ComparativoFamiliaPorZonaCredito)
        oDatabase.AddInParameter(oDbCommand, "@Fecha", DbType.Date, fecIni)
        oDatabase.AddInParameter(oDbCommand, "@CodigoZona", DbType.String, CodigoZona)
        Dim valor As Decimal
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_VALOR As Integer = oIDataReader.GetOrdinal("VALOr")
            While oIDataReader.Read()
                valor = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_VALOR))
            End While
        End Using
        Return valor
    End Function


    Public Function SelReporteTicketPorSucursal(ByVal fecIni As Date, ByVal CodigoSucursal As String) As Decimal
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.Usp_Sel_TransaccionTicket)
        oDatabase.AddInParameter(oDbCommand, "@Fecha", DbType.Date, fecIni)
        oDatabase.AddInParameter(oDbCommand, "@CodigoSucursal", DbType.String, CodigoSucursal)
        Dim valor As Decimal
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_VALOR As Integer = oIDataReader.GetOrdinal("Valor")
            While oIDataReader.Read()
                valor = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_VALOR))
            End While
        End Using
        Return valor
    End Function

    Public Function SelReporteTicketPorSucursalCredito(ByVal fecIni As Date, ByVal CodigoSucursal As String) As Decimal
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.Usp_Sel_TransaccionTicketCredito)
        oDatabase.AddInParameter(oDbCommand, "@Fecha", DbType.Date, fecIni)
        oDatabase.AddInParameter(oDbCommand, "@CodigoSucursal", DbType.String, CodigoSucursal)
        Dim valor As Decimal
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_VALOR As Integer = oIDataReader.GetOrdinal("Valor")
            While oIDataReader.Read()
                valor = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_VALOR))
            End While
        End Using
        Return valor
    End Function

    Public Function SelReporteTicketPorZonaCredito(ByVal fecIni As Date, ByVal CodigoSucursal As String) As Decimal
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.Usp_Sel_TransaccionTicketCreditoZona)
        oDatabase.AddInParameter(oDbCommand, "@Fecha", DbType.Date, fecIni)
        oDatabase.AddInParameter(oDbCommand, "@CodigoZona", DbType.String, CodigoSucursal)
        Dim valor As Decimal
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_VALOR As Integer = oIDataReader.GetOrdinal("Valor")
            While oIDataReader.Read()
                valor = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_VALOR))
            End While
        End Using
        Return valor
    End Function

    Public Function SelReporteTicketPorZonaContado(ByVal fecIni As Date, ByVal CodigoSucursal As String) As Decimal
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.Usp_Sel_TransaccionTicketContadoZona)
        oDatabase.AddInParameter(oDbCommand, "@Fecha", DbType.Date, fecIni)
        oDatabase.AddInParameter(oDbCommand, "@CodigoZona", DbType.String, CodigoSucursal)
        Dim valor As Decimal
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_VALOR As Integer = oIDataReader.GetOrdinal("Valor")
            While oIDataReader.Read()
                valor = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_VALOR))
            End While
        End Using
        Return valor
    End Function

    Public Function SelReporteTicketPorTotalContado(ByVal fecIni As Date) As Decimal
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.Usp_Sel_TransaccionTicketTotalContado)
        oDatabase.AddInParameter(oDbCommand, "@Fecha", DbType.Date, fecIni)
        ' oDatabase.AddInParameter(oDbCommand, "@CodigoSucursal", DbType.String, CodigoSucursal)
        Dim valor As Decimal
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_VALOR As Integer = oIDataReader.GetOrdinal("Valor")
            While oIDataReader.Read()
                valor = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_VALOR))
            End While
        End Using
        Return valor
    End Function


    Public Function SelReporteTicketPorTotalCredito(ByVal fecIni As Date) As Decimal
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.Usp_Sel_TransaccionTicketTotalCredito)
        oDatabase.AddInParameter(oDbCommand, "@Fecha", DbType.Date, fecIni)
        ' oDatabase.AddInParameter(oDbCommand, "@CodigoSucursal", DbType.String, CodigoSucursal)
        Dim valor As Decimal
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_VALOR As Integer = oIDataReader.GetOrdinal("Valor")
            While oIDataReader.Read()
                valor = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_VALOR))
            End While
        End Using
        Return valor
    End Function

    Public Function SelReporteTicketPorTotal(ByVal fecIni As Date) As Decimal
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.Usp_Sel_TransaccionTicketTotal)
        oDatabase.AddInParameter(oDbCommand, "@Fecha", DbType.Date, fecIni)
        ' oDatabase.AddInParameter(oDbCommand, "@CodigoSucursal", DbType.String, CodigoSucursal)
        Dim valor As Decimal
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_VALOR As Integer = oIDataReader.GetOrdinal("Valor")
            While oIDataReader.Read()
                valor = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_VALOR))
            End While
        End Using
        Return valor
    End Function

    Public Function SelReporteDetalladoPorFamiliaTotalCredito(ByVal fecIni As Date) As Decimal
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.Usp_Sel_ComparativoFamiliaNetoCredito)
        oDatabase.AddInParameter(oDbCommand, "@Fecha", DbType.Date, fecIni)
        ' oDatabase.AddInParameter(oDbCommand, "@CodigoZona", DbType.String, CodigoZona)
        Dim valor As Decimal
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_VALOR As Integer = oIDataReader.GetOrdinal("VALOr")
            While oIDataReader.Read()
                valor = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_VALOR))
            End While
        End Using
        Return valor
    End Function

    Public Function SelReporteDetalladoPorDia(ByVal fecIni As Date) As Decimal
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.Usp_Sel_ComparativoTotalDia)
        oDatabase.AddInParameter(oDbCommand, "@Fecha", DbType.Date, fecIni)
        ' oDatabase.AddInParameter(oDbCommand, "@CodigoZona", DbType.String, CodigoZona)
        Dim valor As Decimal
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_VALOR As Integer = oIDataReader.GetOrdinal("VALOr")
            While oIDataReader.Read()
                valor = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_VALOR))
            End While
        End Using
        Return valor
    End Function


    Public Function SelReporteTotalContado(ByVal fecIni As Date, ByVal fecFin As Date) As Decimal
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.Usp_Sel_TotalTicketContado)
        oDatabase.AddInParameter(oDbCommand, "@FechaIni", DbType.Date, fecIni)
        oDatabase.AddInParameter(oDbCommand, "@FechaFin", DbType.Date, fecIni)
        ' oDatabase.AddInParameter(oDbCommand, "@CodigoZona", DbType.String, CodigoZona)
        Dim valor As Decimal
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_VALOR As Integer = oIDataReader.GetOrdinal("Valor")
            While oIDataReader.Read()
                valor = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_VALOR))
            End While
        End Using
        Return valor
    End Function

    Public Function SelReporteTotalCredito(ByVal fecIni As Date, ByVal fecFin As Date) As Decimal
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.Usp_Sel_TotalTicketCredito)
        oDatabase.AddInParameter(oDbCommand, "@FechaIni", DbType.Date, fecIni)
        oDatabase.AddInParameter(oDbCommand, "@FechaFin", DbType.Date, fecIni)
        ' oDatabase.AddInParameter(oDbCommand, "@CodigoZona", DbType.String, CodigoZona)
        Dim valor As Decimal
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_VALOR As Integer = oIDataReader.GetOrdinal("Valor")
            While oIDataReader.Read()
                valor = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_VALOR))
            End While
        End Using
        Return valor
    End Function




    'Public Function SelReporteDetalladoPorFamiliaZonaContado(ByVal fecIni As Date, ByVal CodigoZona As String) As Decimal
    '    Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.Usp_Sel_Detallado_Por_Familia)
    '    Dim oListaReporteEmpresa As New List(Of ReporteVentaEmpresa)
    '    oDatabase.AddInParameter(oDbCommand, "@Fecha", DbType.Date, fecIni)
    '    oDatabase.AddInParameter(oDbCommand, "@CodigoZona", DbType.Date, CodigoZona)
    '    oDbCommand.CommandTimeout = 0

    '    'Using oIDataReader As IDataReader = oDatabase.
    '    Dim valor As Decimal
    '    Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
    '        Dim INDICE_VALOR As Integer = oIDataReader.GetOrdinal("VALOR")
    '        While oIDataReader.Read()
    '            valor = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_VALOR))
    '        End While
    '    End Using
    '    Return valor(oDbCommand)
    '    '    While oIDataReader.Read()
    '    '        Dim oReporteEmpresa As ReporteVentaEmpresa = New ReporteVentaEmpresa()
    '    '        'oReporteEmpresa.IdZona = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(oIDataReader.GetOrdinal("IDZONA")))
    '    '        'oReporteEmpresa.NombreZona = DataUtil.DbValueToDefault(Of String)(oIDataReader(oIDataReader.GetOrdinal("NOMBREZONA")))
    '    '        'oReporteEmpresa.CodigoTienda = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(oIDataReader.GetOrdinal("CODIGOTIENDA")))
    '    '        'oReporteEmpresa.Tienda = DataUtil.DbValueToDefault(Of String)(oIDataReader(oIDataReader.GetOrdinal("TIENDA")))
    '    '        'oReporteEmpresa.CodigoFamilia = DataUtil.DbValueToDefault(Of String)(oIDataReader(oIDataReader.GetOrdinal("COD_FAM_NUE")))
    '    '        'oReporteEmpresa.Familia = DataUtil.DbValueToDefault(Of String)(oIDataReader(oIDataReader.GetOrdinal("FAMILIA")))
    '    '        'oReporteEmpresa.Venta = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(oIDataReader.GetOrdinal("VENTA")))
    '    '        'oReporteEmpresa.Margen = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(oIDataReader.GetOrdinal("MARGEN")))
    '    '        'oReporteEmpresa.Transacciones = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(oIDataReader.GetOrdinal("TRANSACCIONES")))
    '    '        'oReporteEmpresa.TicketPromedio = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(oIDataReader.GetOrdinal("TICKETPROMEDIO")))
    '    '        oReporteEmpresa.Venta = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(oIDataReader.GetOrdinal("VALOr")))
    '    '        oListaReporteEmpresa.Add(oReporteEmpresa)

    '    '    End While
    '    'End Using
    '    'Return oListaReporteEmpresa
    'End Function


    Function SelReporteComps(fechaIniRep As Date, fechaFinRep As Date, idMarca As Integer) As List(Of ReporteComparativoAAAC)
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.Usp_Sel_ComparativoFamilia)
        Dim oListaReporteEmpresa As New List(Of ReporteComparativoAAAC)
        oDatabase.AddInParameter(oDbCommand, "@FecIni", DbType.Date, fechaIniRep)
        oDatabase.AddInParameter(oDbCommand, "@FecFin", DbType.Date, fechaFinRep)
        oDatabase.AddInParameter(oDbCommand, "@Marca", DbType.Int16, idMarca)
        oDbCommand.CommandTimeout = 0
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            While oIDataReader.Read()
                Dim oReporteEmpresa As ReporteComparativoAAAC = New ReporteComparativoAAAC()
                oReporteEmpresa.IdFam = DataUtil.DbValueToDefault(Of String)(oIDataReader(oIDataReader.GetOrdinal("COD_FAM_NUE")))
                oReporteEmpresa.NombreFam = DataUtil.DbValueToDefault(Of String)(oIDataReader(oIDataReader.GetOrdinal("NOM_FAM_NUE")))
                oReporteEmpresa.TotalAA = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(oIDataReader.GetOrdinal("TOTALAA")))
                oReporteEmpresa.TotalAC = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(oIDataReader.GetOrdinal("TOTALAC")))
                oReporteEmpresa.Comps = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(oIDataReader.GetOrdinal("COMPS")))
                oListaReporteEmpresa.Add(oReporteEmpresa)
            End While
        End Using
        Return oListaReporteEmpresa
    End Function


    Public Function SelReporteDetalladoPorDia(ByVal fecIni As Date, ByVal fecFin As Date) As List(Of ReporteVentaEmpresa)
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.Usp_Sel_Detallado_Por_Dia)
        Dim oListaReporteEmpresa As New List(Of ReporteVentaEmpresa)
        oDatabase.AddInParameter(oDbCommand, "@FECHAINI", DbType.Date, fecIni)
        oDatabase.AddInParameter(oDbCommand, "@FECHAFIN", DbType.Date, fecFin)
        oDbCommand.CommandTimeout = 0
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            While oIDataReader.Read()
                Dim oReporteEmpresa As ReporteVentaEmpresa = New ReporteVentaEmpresa()
                oReporteEmpresa.IdZona = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(oIDataReader.GetOrdinal("IDZONA")))
                oReporteEmpresa.NombreZona = DataUtil.DbValueToDefault(Of String)(oIDataReader(oIDataReader.GetOrdinal("NOMBREZONA")))
                oReporteEmpresa.CodigoTienda = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(oIDataReader.GetOrdinal("CODIGOTIENDA")))
                oReporteEmpresa.Tienda = DataUtil.DbValueToDefault(Of String)(oIDataReader(oIDataReader.GetOrdinal("TIENDA")))
                oReporteEmpresa.DiaNatural = DataUtil.DbValueToDefault(Of Date)(oIDataReader(oIDataReader.GetOrdinal("DIANATURAL")))

                oReporteEmpresa.VentaContado = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(oIDataReader.GetOrdinal("VENTACONTADO")))
                oReporteEmpresa.VentaCredito = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(oIDataReader.GetOrdinal("VENTACREDITO")))
                'oReporteEmpresa.MargenContado = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(oIDataReader.GetOrdinal("VALOR")))
                oReporteEmpresa.MargenContado = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(oIDataReader.GetOrdinal("MARGENCONTADO")))
                oReporteEmpresa.MargenCredito = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(oIDataReader.GetOrdinal("MARGENCREDITO")))
                oReporteEmpresa.TransaccionesContado = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(oIDataReader.GetOrdinal("TRANSACCIONESCONTADO")))
                oReporteEmpresa.TransaccionesCredito = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(oIDataReader.GetOrdinal("TRANSACCIONESCREDITO")))
                oReporteEmpresa.TicketPromedioContado = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(oIDataReader.GetOrdinal("TICKETPROMEDIOCONTADO")))
                oReporteEmpresa.TicketPromedioCredito = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(oIDataReader.GetOrdinal("TICKETPROMEDIOCREDITO")))
                oListaReporteEmpresa.Add(oReporteEmpresa)
            End While
        End Using
        Return oListaReporteEmpresa
    End Function

#Region "CONSULTA CLIENTES VENDEDORES ASOCIADOS"

    Public Function ListarClienteVendedorAsociado(ByVal _clienteVenta As ClienteVenta, paginacion As Paginacion, ByRef rowCount As Integer) As List(Of ClienteVenta)
        Dim lista As New List(Of ClienteVenta)
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.Usp_Clientes_Vendedores_Asociados)
        oDatabase.AddInParameter(oDbCommand, "@FiltroBusqueda", DbType.String, If(_clienteVenta.RUC Is Nothing, String.Empty, _clienteVenta.RUC))

        oDatabase.AddInParameter(oDbCommand, "@rowsPerPage", DbType.Int32, paginacion.RowsPerPage)
        oDatabase.AddInParameter(oDbCommand, "@page", DbType.Int32, paginacion.Page)
        oDatabase.AddInParameter(oDbCommand, "@sortDir", DbType.String, paginacion.SortBy)
        oDatabase.AddInParameter(oDbCommand, "@sortType", DbType.String, paginacion.SortType)
        oDatabase.AddOutParameter(oDbCommand, "@rowCount", DbType.Int32, 10)

        oDbCommand.CommandTimeout = 0
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            While oIDataReader.Read()
                Dim oClienteVenta As ClienteVenta = New ClienteVenta()
                oClienteVenta.RUC = DataUtil.DbValueToDefault(Of String)(oIDataReader(oIDataReader.GetOrdinal("RUC")))
                oClienteVenta.RazonSocial = DataUtil.DbValueToDefault(Of String)(oIDataReader(oIDataReader.GetOrdinal("RazonSocial")))
                oClienteVenta.IdEmpleadoPrincipal = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(oIDataReader.GetOrdinal("IdEmpleado")))
                oClienteVenta.NombresApellidos = DataUtil.DbValueToDefault(Of String)(oIDataReader(oIDataReader.GetOrdinal("AsignadoA")))
                oClienteVenta.NombreZona = DataUtil.DbValueToDefault(Of String)(oIDataReader(oIDataReader.GetOrdinal("Zona")))
                oClienteVenta.RepresentanteVenta = DataUtil.DbValueToDefault(Of String)(oIDataReader(oIDataReader.GetOrdinal("JefeRegional")))
                oClienteVenta.FActivacion = DataUtil.DbValueToDefault(Of String)(oIDataReader(oIDataReader.GetOrdinal("FechaActivacion")))
                lista.Add(oClienteVenta)
            End While
        End Using
        rowCount = Convert.ToInt32(oDatabase.GetParameterValue(oDbCommand, "@RowCount"))
        Return lista
    End Function

#End Region

#Region "Cartera Cliente"

    Public Function ListarReporteClienteCartera(
            fechainicio As String,
            fechafin As String,
            jeferegional As String,
            zona As String,
            sucursal As String,
            vendedor As String,
            ruc As String,
            razonsocial As String,
            tipocliente1 As String,
            idgrupo1 As String,
            perfil As String) As List(Of ReporteClienteCartera)

        Try
            Dim oListaSucursal As New List(Of ReporteClienteCartera)
            Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.UspReporteCarteraCliente)
            oDatabase.AddInParameter(oDbCommand, "@FechaInicio", DbType.String, fechainicio)
            oDatabase.AddInParameter(oDbCommand, "@FechaFin", DbType.String, fechafin)
            oDatabase.AddInParameter(oDbCommand, "@JefeRegional", DbType.String, jeferegional)
            oDatabase.AddInParameter(oDbCommand, "@Zona", DbType.String, zona)
            oDatabase.AddInParameter(oDbCommand, "@Sucursal", DbType.String, sucursal)
            oDatabase.AddInParameter(oDbCommand, "@Vendedor", DbType.String, vendedor)
            'oDatabase.AddInParameter(oDbCommand, "@Ruc", DbType.String, ruc)
            oDatabase.AddInParameter(oDbCommand, "@RazonSocial", DbType.String, razonsocial)
            oDatabase.AddInParameter(oDbCommand, "@TipoCliente1", DbType.String, tipocliente1)
            oDatabase.AddInParameter(oDbCommand, "@IdGrupo1", DbType.String, idgrupo1)
            oDatabase.AddInParameter(oDbCommand, "@p_Perfil", DbType.String, perfil)

            oDbCommand.CommandTimeout = 120000
            Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)

                Dim INDICE_1 As Integer = oIDataReader.GetOrdinal("Empresa")
                Dim INDICE_2 As Integer = oIDataReader.GetOrdinal("RUC")
                Dim INDICE_3 As Integer = oIDataReader.GetOrdinal("RazonSocial")
                Dim INDICE_4 As Integer = oIDataReader.GetOrdinal("Sector")
                Dim INDICE_5 As Integer = oIDataReader.GetOrdinal("FechaAsignacion")
                Dim INDICE_6 As Integer = oIDataReader.GetOrdinal("ModoPago")
                Dim INDICE_7 As Integer = oIDataReader.GetOrdinal("LcSigic")
                Dim INDICE_8 As Integer = oIDataReader.GetOrdinal("FactSigic")
                Dim INDICE_9 As Integer = oIDataReader.GetOrdinal("LcDisponible")
                Dim INDICE_10 As Integer = oIDataReader.GetOrdinal("FechaAperturaLinea")
                Dim INDICE_11 As Integer = oIDataReader.GetOrdinal("FechaExpiracion")
                Dim INDICE_12 As Integer = oIDataReader.GetOrdinal("DiasPlazo")
                Dim INDICE_13 As Integer = oIDataReader.GetOrdinal("CodigoEmpleado")
                Dim INDICE_14 As Integer = oIDataReader.GetOrdinal("NombreRRVV")
                Dim INDICE_15 As Integer = oIDataReader.GetOrdinal("AsignRRVV")
                Dim INDICE_16 As Integer = oIDataReader.GetOrdinal("Sucursal")
                Dim INDICE_17 As Integer = oIDataReader.GetOrdinal("Zona")
                Dim INDICE_18 As Integer = oIDataReader.GetOrdinal("JefeVenta")
                Dim INDICE_19 As Integer = oIDataReader.GetOrdinal("VentaSodimac")
                Dim INDICE_20 As Integer = oIDataReader.GetOrdinal("CostoSodimac")
                Dim INDICE_21 As Integer = oIDataReader.GetOrdinal("VentaMaestro")
                Dim INDICE_22 As Integer = oIDataReader.GetOrdinal("CostoMaestro")
                Dim INDICE_23 As Integer = oIDataReader.GetOrdinal("TotalVenta")
                Dim INDICE_24 As Integer = oIDataReader.GetOrdinal("TotalCosto")
                Dim INDICE_25 As Integer = oIDataReader.GetOrdinal("TotalContribucion")
                Dim INDICE_26 As Integer = oIDataReader.GetOrdinal("MargenContribucion")
                Dim INDICE_27 As Integer = oIDataReader.GetOrdinal("SubGerente")
                Dim INDICE_28 As Integer = oIDataReader.GetOrdinal("FechaCreacion")
                Dim INDICE_29 As Integer = oIDataReader.GetOrdinal("PorcentajeUtilizacion")
                Dim INDICE_30 As Integer = oIDataReader.GetOrdinal("EstadoLC")
                Dim INDICE_31 As Integer = oIDataReader.GetOrdinal("EstadoCliente")
                Dim INDICE_32 As Integer = oIDataReader.GetOrdinal("VentaTotalCredito")
                Dim INDICE_33 As Integer = oIDataReader.GetOrdinal("VentaTotalOracleCredito")
                Dim INDICE_34 As Integer = oIDataReader.GetOrdinal("VentaTotalOracleContado")
                Dim INDICE_35 As Integer = oIDataReader.GetOrdinal("VentaTotalContado")
                Dim INDICE_36 As Integer = oIDataReader.GetOrdinal("TotalVentasAvance")

                While oIDataReader.Read()
                    Dim oReportVenta As New ReporteClienteCartera With {
                        .Empresa = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_1)),
                        .ruc = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_2)),
                        .razonsocial = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_3)),
                        .Sector = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_4)),
                        .FechaAsignacion = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_5)),
                        .ModoPago = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_6)),
                        .LcSigic = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_7)),
                        .FactSigic = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_8)),
                        .LcDisponible = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_9)),
                        .FechaApertura = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_10)),
                        .FechaExpiracion = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_11)),
                        .DiasPlazo = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_12)),
                        .CodigoEmpleado = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_13)),
                        .NombreRrvv = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_14)),
                        .AsignRrvv = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_15)),
                        .sucursal = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_16)),
                        .zona = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_17)),
                        .JefeVenta = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_18)),
                        .VentaSodimac = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_19)),
                        .CostoSodimac = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_20)),
                        .VentaMaestro = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_21)),
                        .CostoMaestro = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_22)),
                        .TotalVenta = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_23)),
                        .TotalCosto = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_24)),
                        .TotalContribucion = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_25)),
                        .MargenContribucion = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_26)),
                        .SubGerente = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_27)),
                        .FechaCreacion = DataUtil.DbValueToDefault(Of DateTime)(oIDataReader(INDICE_28)).ToString("dd/MM/yyyy"),
                        .PorcentajeUtilizacion = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_29)),
                        .EstadoLC = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_30)),
                        .EstadoCliente = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_31)),
                        .VentaTotalCredito = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_32)),
                        .VentaTotalOracleCredito = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_33)),
                        .VentaTotalOracleContado = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_34)),
                        .VentaTotalContado = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_35)),
                        .TotalVentasAvance = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(INDICE_36))
                    }

                    oListaSucursal.Add(oReportVenta)
                End While
            End Using
            Return oListaSucursal
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

#End Region

#Region "Reporte Usuarios"
    Function ListarReporteUsuario(ByVal usuario As Usuario, ByVal idsRol As String, ByVal fechaIni As String, ByVal fechaFin As String) As ListaUsuario
        Dim oListaUsuario As New ListaUsuario()

        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.Usp_ListarReporteUsuario)
        oDatabase.AddInParameter(oDbCommand, "@IdsRol", DbType.String, idsRol)
        oDatabase.AddInParameter(oDbCommand, "@FechaIni", DbType.String, fechaIni)
        oDatabase.AddInParameter(oDbCommand, "@FechaFin", DbType.String, fechaFin)
        oDatabase.AddInParameter(oDbCommand, "@Estado", DbType.Int32, usuario.ActivoUsu)
        oDatabase.AddInParameter(oDbCommand, "@UsuarioUsu", DbType.String, usuario.UsuarioUsu)
        oDbCommand.CommandTimeout = 120000

        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_NombreRol As Integer = oIDataReader.GetOrdinal("NombreRol")
            Dim INDICE_UsuarioUsu As Integer = oIDataReader.GetOrdinal("UsuarioUsu")
            Dim INDICE_UsuarioNom As Integer = oIDataReader.GetOrdinal("UsuarioNom")
            Dim INDICE_Email As Integer = oIDataReader.GetOrdinal("Email")
            Dim INDICE_DNI As Integer = oIDataReader.GetOrdinal("DNI")
            Dim INDICE_Estado As Integer = oIDataReader.GetOrdinal("Estado")
            Dim INDICE_FechaUltSes As Integer = oIDataReader.GetOrdinal("FechaUltSes")
            While oIDataReader.Read()
                Dim oUsuario = New Usuario
                oUsuario.Rol = New Rol
                oUsuario.Empleado = New Empleado

                oUsuario.Rol.NombreRol = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_NombreRol))
                oUsuario.UsuarioUsu = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_UsuarioUsu))
                oUsuario.UsuarioNom = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_UsuarioNom))
                oUsuario.Empleado.Email = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_Email))
                oUsuario.Empleado.DNI = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_DNI))
                oUsuario.Estado = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_Estado))
                oUsuario.FechaSesion = DataUtil.DbValueToDefault(Of DateTime)(oIDataReader(INDICE_FechaUltSes))
                oListaUsuario.Add(oUsuario)
            End While
        End Using
        Return oListaUsuario
    End Function
#End Region

#Region "Reporte Roles y Páginas"

    Function ListarReporteRolPagina(ByVal idsRol As String, ByVal estadoPag As Integer, ByVal nombrePag As String) As ListaPaginaRol
        Dim oListaPaginaRol As New ListaPaginaRol()

        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.Usp_ListarReporteRolPagina)
        oDatabase.AddInParameter(oDbCommand, "@IdsRol", DbType.String, idsRol)
        oDatabase.AddInParameter(oDbCommand, "@EstadoPag", DbType.Int32, estadoPag)
        oDatabase.AddInParameter(oDbCommand, "@NombrePag", DbType.String, nombrePag)
        oDbCommand.CommandTimeout = 120000

        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_NombreRol As Integer = oIDataReader.GetOrdinal("NombreRol")
            Dim INDICE_NombrePagina As Integer = oIDataReader.GetOrdinal("NombrePagina")
            Dim INDICE_EstadoPagina As Integer = oIDataReader.GetOrdinal("EstadoPagina")
            While oIDataReader.Read()
                Dim oPaginaRol = New PaginaRol
                oPaginaRol.Rol = New Rol
                oPaginaRol.Pagina = New Pagina

                oPaginaRol.Rol.NombreRol = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_NombreRol))
                oPaginaRol.Pagina.NombrePagina = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_NombrePagina))
                oPaginaRol.Pagina.EstadoPagina = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_EstadoPagina))
                oListaPaginaRol.Add(oPaginaRol)
            End While
        End Using
        Return oListaPaginaRol
    End Function
#End Region
End Class


