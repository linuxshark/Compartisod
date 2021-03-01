Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Common
Imports System.Linq
Imports System.Text
Imports Sodimac.VentaEmpresa.DataContracts
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Data.Sql
Imports Microsoft.Practices.EnterpriseLibrary.Common.Configuration
Imports Microsoft.SqlServer.Server
Imports System.Configuration
Imports System.Data.SqlClient

Public Class ProcesoDataAccess

    Private oDatabase As Database = EnterpriseLibraryContainer.Current.GetInstance(Of Database)(Conexion.cnsSql)
    Private oDatabaseAsync As Database = New SqlDatabase(ConfigurationManager.AppSettings("cnSodimacAsync"))
    Private Timeout As Integer = ConfigurationManager.AppSettings("TimeOut")

    Public Function BuscarCliente(Ruc As Int64) As Boolean
        Dim rst As New Int32
        Dim Resultado As Boolean = False
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(Procedimientos.USP_BUSCARCLIENTERUC, Ruc)
            Dim res As Integer = oIDataReader.GetOrdinal("Resultado")
            oIDataReader.Read()
            rst = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(res))

            If rst = 1 Then
                Resultado = True
            End If

            oIDataReader.Close()
        End Using
        Return Resultado
    End Function

    Public Function BuscarProducto(Sku As String) As Boolean
        Dim rst As New Int32
        Dim Resultado As Boolean = False
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(Procedimientos.USP_BUSCARPRODUCTOSKU, Sku)
            Dim res As Integer = oIDataReader.GetOrdinal("Resultado")
            oIDataReader.Read()
            rst = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(res))

            If rst = 1 Then
                Resultado = True
            End If

            oIDataReader.Close()
        End Using
        Return Resultado
    End Function

    Public Function ImportarDatosFactura(oProcesoCarga As ProcesoCarga) As Integer
        Dim result As Integer = -1

        Try
            Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_GUARDARFACTURASEXCEL)

            Dim Fecha As String() = oProcesoCarga.Fecha.ToShortDateString().Split("/")

            oDatabase.AddInParameter(oDbCommand, "@fctr_ano", DbType.Byte, Convert.ToByte(CInt(Fecha(2).Substring(2, 2))))
            oDatabase.AddInParameter(oDbCommand, "@fctr_mes", DbType.Byte, Convert.ToByte(CInt(Fecha(1))))
            oDatabase.AddInParameter(oDbCommand, "@fctr_dia", DbType.Byte, Convert.ToByte(CInt(Fecha(0))))
            oDatabase.AddInParameter(oDbCommand, "@unor_codg", DbType.Int16, oProcesoCarga.IdSucursal)
            oDatabase.AddInParameter(oDbCommand, "@fctr_corr", DbType.Int32, Convert.ToInt32(oProcesoCarga.NumeroDocumento))
            oDatabase.AddInParameter(oDbCommand, "@clnt_rut", DbType.String, oProcesoCarga.Ruc)
            oDatabase.AddInParameter(oDbCommand, "@fctr_valr", DbType.Decimal, oProcesoCarga.ValorVenta)
            oDatabase.AddInParameter(oDbCommand, "@fctr_iva", DbType.Decimal, oProcesoCarga.Igv)
            oDatabase.AddInParameter(oDbCommand, "@fctr_totl", DbType.Decimal, oProcesoCarga.Total)
            oDatabase.AddInParameter(oDbCommand, "@fctr_tasa_cambio", DbType.Decimal, oProcesoCarga.Tc)

            oDatabase.ExecuteNonQuery(oDbCommand)

            result = ImportarDatosFacturaDetalle(oProcesoCarga)
        Catch ex As Exception
            Throw ex
            result = -1
        End Try
        Return result
    End Function


    Public Function ImportarEmpleadoMasivo(oEmpleado As Empleado) As Integer
        Dim oDbCommand As DbCommand = Nothing
        Try
            oDbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_INSERT_EMPLEADO_MASIVO)
            Dim cnStr As String = ConfigurationManager.ConnectionStrings(Conexion.cnsSql).ToString()
            Using SqlCn As New SqlConnection(cnStr)
                oDbCommand.Connection = SqlCn
                oDbCommand.Connection.Open()
                oDatabase.AddInParameter(oDbCommand, "@Nombre", DbType.String, oEmpleado.Nombres)
                oDatabase.AddInParameter(oDbCommand, "@Apellido", DbType.String, oEmpleado.Apellidos)
                oDatabase.AddInParameter(oDbCommand, "@DNI", DbType.String, oEmpleado.DNI)
                oDatabase.AddInParameter(oDbCommand, "@codigoOfisis", DbType.String, oEmpleado.CodigoOfisis)
                oDatabase.AddInParameter(oDbCommand, "@FechaContrato", DbType.Date, oEmpleado.FechaContrato)
                oDatabase.AddInParameter(oDbCommand, "@FechaNacimiento", DbType.Date, oEmpleado.FechaNacimiento)
                oDatabase.AddInParameter(oDbCommand, "@UsuarioSistema", DbType.String, oEmpleado.UsuarioIngreso)
                oDatabase.AddInParameter(oDbCommand, "@celular1", DbType.String, oEmpleado.Celular1)
                oDatabase.AddInParameter(oDbCommand, "@Celular2", DbType.String, oEmpleado.Celular2)
                oDatabase.AddInParameter(oDbCommand, "@Telefono", DbType.String, oEmpleado.Telefono)
                oDatabase.AddInParameter(oDbCommand, "@Email", DbType.String, oEmpleado.Email)
                oDatabase.AddInParameter(oDbCommand, "@Direccion", DbType.String, oEmpleado.Direccion)
                oDatabase.AddInParameter(oDbCommand, "@Perfil", DbType.Int32, oEmpleado.EmpleadoPerfil.IdPerfil)
                oDatabase.AddInParameter(oDbCommand, "@Zona", DbType.Int32, oEmpleado.Zona.IdZona)
                oDatabase.AddInParameter(oDbCommand, "@Sucursal", DbType.Int32, oEmpleado.Sucursal.IdSucursal)
                oDatabase.AddInParameter(oDbCommand, "@EscalaTiempoInicial", DbType.String, oEmpleado.EscalaTiempoInicial)
                oDatabase.AddInParameter(oDbCommand, "@FechaIngreso", DbType.Date, oEmpleado.FechaDesde)
                oDatabase.AddInParameter(oDbCommand, "@Usuario", DbType.String, oEmpleado.UsuarioRegistro)
                oDatabase.AddInParameter(oDbCommand, "@Origen", DbType.String, oEmpleado.OrigenRegistro)

                oDatabase.ExecuteNonQuery(oDbCommand)

            End Using
        Catch ex As Exception

            Throw ex

        Finally
            oDbCommand.Connection.Close()
            oDbCommand.Connection.Dispose()

        End Try
        Return 0
    End Function

    Public Function EliminarEmpleadoMasivo(oEmpleado As Empleado) As Integer
        Try
            Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_DELETE_EMPLEADO_MASIVO)
            oDatabase.AddInParameter(oDbCommand, "@codigoOfisis", DbType.String, oEmpleado.CodigoOfisis)
            oDatabase.AddInParameter(oDbCommand, "@Usuario", DbType.String, oEmpleado.UsuarioRegistro)
            oDatabase.AddInParameter(oDbCommand, "@Origen", DbType.String, oEmpleado.OrigenRegistro)
            oDatabase.ExecuteNonQuery(oDbCommand)
        Catch ex As Exception

        End Try
        Return 0
    End Function

    Protected Function ImportarDatosFacturaDetalle(oProcesoCarga As ProcesoCarga) As Integer
        Dim result As Integer = -1
        Try
            Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_GUARDARFACTURASEXCELDETALLE)

            Dim Fecha As String() = oProcesoCarga.Fecha.ToShortDateString().Split("/")

            oDatabase.AddInParameter(oDbCommand, "@fctr_ano", DbType.Byte, Convert.ToByte(CInt(Fecha(2).Substring(2, 2))))
            oDatabase.AddInParameter(oDbCommand, "@fctr_mes", DbType.Byte, Convert.ToByte(CInt(Fecha(1))))
            oDatabase.AddInParameter(oDbCommand, "@fctr_dia", DbType.Byte, Convert.ToByte(CInt(Fecha(0))))
            oDatabase.AddInParameter(oDbCommand, "@uvta_codg", DbType.Int16, oProcesoCarga.IdSucursal)
            oDatabase.AddInParameter(oDbCommand, "@fctr_corr", DbType.Int32, Convert.ToInt32(oProcesoCarga.NumeroDocumento))
            oDatabase.AddInParameter(oDbCommand, "@item_codg", DbType.String, oProcesoCarga.Sku)
            oDatabase.AddInParameter(oDbCommand, "@dtfc_ctdd", DbType.Decimal, oProcesoCarga.Cantidad)
            oDatabase.AddInParameter(oDbCommand, "@dtfc_prec", DbType.Decimal, oProcesoCarga.ValorVenta)
            oDatabase.AddInParameter(oDbCommand, "@dtfc_impuesto1", DbType.Decimal, oProcesoCarga.Igv)

            oDatabase.ExecuteNonQuery(oDbCommand)

            result = 1
        Catch ex As Exception
            Throw ex
        End Try
        Return result
    End Function

    Public Function ImportarDatosNotaCredito(oProcesoCarga As ProcesoCarga) As Integer
        Dim result As Integer = -1

        Try
            Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_GUARDARNOTACREDITOEXCEL)

            Dim Fecha As String() = oProcesoCarga.Fecha.ToShortDateString().Split("/")

            Dim x1, x2, x3 As Byte
            x1 = Convert.ToByte(CInt(Fecha(2).Substring(2)))
            x2 = Convert.ToByte(CInt(Fecha(1)))
            x3 = Convert.ToByte(CInt(Fecha(0)))

            oDatabase.AddInParameter(oDbCommand, "@ntcr_ano", DbType.Byte, x1)
            oDatabase.AddInParameter(oDbCommand, "@ntcr_mes", DbType.Byte, x2)
            oDatabase.AddInParameter(oDbCommand, "@ntcr_dia", DbType.Byte, x3)
            oDatabase.AddInParameter(oDbCommand, "@unor_codg", DbType.Int16, Convert.ToInt16(oProcesoCarga.IdSucursal))
            oDatabase.AddInParameter(oDbCommand, "@ntcr_corr", DbType.Int32, Convert.ToInt32(oProcesoCarga.NumeroDocumento))
            oDatabase.AddInParameter(oDbCommand, "@fctr_corr", DbType.Int32, Convert.ToInt32(oProcesoCarga.DocumentoAfecto)) 'docafect
            oDatabase.AddInParameter(oDbCommand, "@blta_corr", DbType.Int32, Convert.ToInt32(oProcesoCarga.DocumentoAfecto)) 'docafect
            oDatabase.AddInParameter(oDbCommand, "@clnt_rut", DbType.String, oProcesoCarga.Ruc)
            oDatabase.AddInParameter(oDbCommand, "@ntcr_valr", DbType.Decimal, oProcesoCarga.ValorVenta)
            oDatabase.AddInParameter(oDbCommand, "@ntcr_iva", DbType.Decimal, oProcesoCarga.Igv)
            oDatabase.AddInParameter(oDbCommand, "@ntcr_totl", DbType.Decimal, oProcesoCarga.Total)

            result = oDatabase.ExecuteNonQuery(oDbCommand)
            ImportarDatosNotaCreditoDetalle(oProcesoCarga)
        Catch ex As Exception
            Throw ex
            result = -1
        End Try

        Return result
    End Function

    Protected Function ImportarDatosNotaCreditoDetalle(oProcesoCarga As ProcesoCarga) As Integer
        Dim result As Integer = -1
        Try
            Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_GUARDARNOTACREDITOEXCELDETALLE)

            Dim Fecha As String() = oProcesoCarga.Fecha.ToShortDateString().Split("/")

            oDatabase.AddInParameter(oDbCommand, "@ntcr_ano", DbType.Byte, Convert.ToByte(CInt(Fecha(2).Substring(2, 2))))
            oDatabase.AddInParameter(oDbCommand, "@ntcr_mes", DbType.Byte, Convert.ToByte(CInt(Fecha(1))))
            oDatabase.AddInParameter(oDbCommand, "@ntcr_dia", DbType.Byte, Convert.ToByte(CInt(Fecha(0))))
            oDatabase.AddInParameter(oDbCommand, "@unor_codg", DbType.Int16, oProcesoCarga.IdSucursal)
            oDatabase.AddInParameter(oDbCommand, "@ntcr_corr", DbType.Int32, Convert.ToInt32(oProcesoCarga.NumeroDocumento))
            oDatabase.AddInParameter(oDbCommand, "@item_codg", DbType.String, oProcesoCarga.Sku)
            oDatabase.AddInParameter(oDbCommand, "@dnct_cntd", DbType.Decimal, oProcesoCarga.Cantidad)
            oDatabase.AddInParameter(oDbCommand, "@dnct_prec", DbType.Decimal, oProcesoCarga.ValorVenta)
            oDatabase.AddInParameter(oDbCommand, "@dnct_impuesto1", DbType.Decimal, oProcesoCarga.Igv)

            oDatabase.ExecuteNonQuery(oDbCommand)

            result = 1
        Catch ex As Exception
            Throw ex
        End Try
        Return result
    End Function

    Public Function Sincronizar() As Integer
        Dim result As Integer = -1
        Try
            Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_ACTUALIZAVENTACOMISION)
            result = oDatabase.ExecuteNonQuery(oDbCommand)
            result = 1
        Catch ex As Exception
            result = -1
        End Try

        Return result
    End Function

    Public Sub TruncarTable()
        Try
            Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_TRUNCARTABLAFACTURASNOTACREDITO)
            oDatabase.ExecuteNonQuery(oDbCommand)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function ListarHistorial(pMax As Int32, pStart As Int32, ByRef pTotal As Int32) As ListaProcesoCarga
        Dim oLista As New ListaProcesoCarga
        Dim oProceso As New ProcesoCarga
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_LISTARCARGAMANUALHISTORICA)
        'oDatabase.AddInParameter(oDbCommand, "@PageSize", DbType.Int32, pMax)
        'oDatabase.AddInParameter(oDbCommand, "@PageNumber", DbType.Int32, pStart)
        'oDatabase.AddOutParameter(oDbCommand, "@TotalRows", DbType.Int32, 10)
        oDatabase.AddInParameter(oDbCommand, "@maximumRows", DbType.Int32, pMax)
        oDatabase.AddInParameter(oDbCommand, "@startRowIndex", DbType.Int32, pStart)
        oDatabase.AddOutParameter(oDbCommand, "@Total", DbType.Int32, 3)
        oDbCommand.CommandTimeout = 120000

        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim indicecorrelativo As Integer = oIDataReader.GetOrdinal("Correlativo")
            Dim indiceidcarga As Integer = oIDataReader.GetOrdinal("IdCarga")
            Dim indicecantidad As Integer = oIDataReader.GetOrdinal("Cantidad")
            Dim indiceTotal As Integer = oIDataReader.GetOrdinal("Total")
            Dim indiceFecha As Integer = oIDataReader.GetOrdinal("Fecha")
            Dim indiceEstado As Integer = oIDataReader.GetOrdinal("Id_Estado")
            While oIDataReader.Read()
                oProceso = New ProcesoCarga
                oProceso.IDCarga = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(indiceidcarga))
                oProceso.TipoCarga = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(indicecorrelativo))
                oProceso.TotalDocumentos = DataUtil.DbValueToDefault(Of String)(oIDataReader(indicecantidad))
                oProceso.ValorDocumento = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceTotal))
                oProceso.Fecha = DataUtil.DbValueToDefault(Of DateTime)(oIDataReader(indiceFecha))
                oProceso.Id_Estado = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indiceEstado))
                oLista.Add(oProceso)
            End While
        End Using

        pTotal = Convert.ToInt32(oDatabase.GetParameterValue(oDbCommand, "@Total"))
        Return oLista
    End Function

    Public Function RegHistorial(oProcesoCarga As ProcesoCarga) As Integer
        Dim result As Integer = -1

        Try
            Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_INS_CARGAMANUAL)
            oDbCommand.CommandTimeout = 0
            oDatabase.AddInParameter(oDbCommand, "@Cantidad", DbType.String, oProcesoCarga.TotalDocumentos)
            oDatabase.AddInParameter(oDbCommand, "@Total", DbType.String, oProcesoCarga.ValorDocumento)
            oDatabase.AddInParameter(oDbCommand, "@UserCarga", DbType.String, oProcesoCarga.UserReg)

            result = oDatabase.ExecuteScalar(oDbCommand)
            'result = 1
        Catch ex As Exception
            Throw ex
        End Try

        Return result
    End Function

#Region "Esquema Venta - Carga Manual"

    Public Function ImportarDatosVentaCabecera(oProcesoCarga As ProcesoCarga) As Integer
        Dim result As Integer = -1
        Try

            Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_INS_VENTACABECERA)
            oDbCommand.CommandTimeout = 0
            oDatabase.AddInParameter(oDbCommand, "@IdTipoDocumento", DbType.Int32, oProcesoCarga.IdTipoDocumento)
            oDatabase.AddInParameter(oDbCommand, "@NumeroDocumento", DbType.Int32, oProcesoCarga.NumeroDocumento)
            oDatabase.AddInParameter(oDbCommand, "@RUC", DbType.String, oProcesoCarga.Ruc)
            oDatabase.AddInParameter(oDbCommand, "@FechaVenta", DbType.Date, oProcesoCarga.Fecha)
            oDatabase.AddInParameter(oDbCommand, "@SKU", DbType.String, oProcesoCarga.Sku)
            oDatabase.AddInParameter(oDbCommand, "@Cantidad", DbType.Int32, oProcesoCarga.Cantidad)
            oDatabase.AddInParameter(oDbCommand, "@ValorVenta", DbType.Decimal, oProcesoCarga.ValorVenta)
            oDatabase.AddInParameter(oDbCommand, "@IGV", DbType.Decimal, oProcesoCarga.Igv)
            oDatabase.AddInParameter(oDbCommand, "@Total", DbType.Decimal, oProcesoCarga.Total)
            oDatabase.AddInParameter(oDbCommand, "@DocumentoAfecto", DbType.String, oProcesoCarga.DocumentoAfecto)
            oDatabase.AddInParameter(oDbCommand, "@Descripcion", DbType.String, oProcesoCarga.Comentario)
            oDatabase.AddInParameter(oDbCommand, "@IdCarga", DbType.Int32, oProcesoCarga.IDCarga)
            oDatabase.AddInParameter(oDbCommand, "@IdMoneda", DbType.Int32, oProcesoCarga.IdMoneda)
            oDatabase.AddInParameter(oDbCommand, "@TipoCambio", DbType.Decimal, oProcesoCarga.Tc)
            oDatabase.AddInParameter(oDbCommand, "@IdSucursalReferencia", DbType.Int32, oProcesoCarga.IdSucursal)
            oDatabase.AddInParameter(oDbCommand, "@RazonSocial", DbType.String, oProcesoCarga.RazonSocial)

            oDatabase.ExecuteNonQuery(oDbCommand)

            result = 1
        Catch ex As Exception
            Throw ex
        End Try
        Return result
    End Function

    Public Function ImportarDatosVentaDetalle(oProcesoCarga As ProcesoCarga) As Integer
        Dim result As Integer = 0
        Try
            Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_INS_VENTADETALLE)
            oDbCommand.CommandTimeout = 0
            'oDatabase.AddInParameter(oDbCommand, "@TipoDocumento", DbType.String, oProcesoCarga.TipoDocumento)
            oDatabase.AddInParameter(oDbCommand, "@IdTipoDocumento", DbType.Int32, oProcesoCarga.IdTipoDocumento)
            oDatabase.AddInParameter(oDbCommand, "@NumeroDocumento", DbType.Int32, CInt(oProcesoCarga.NumeroDocumento))
            oDatabase.AddInParameter(oDbCommand, "@RUC", DbType.String, oProcesoCarga.Ruc)
            oDatabase.AddInParameter(oDbCommand, "@FechaVenta", DbType.Date, oProcesoCarga.Fecha)
            oDatabase.AddInParameter(oDbCommand, "@SKU", DbType.String, oProcesoCarga.Sku)
            oDatabase.AddInParameter(oDbCommand, "@Cantidad", DbType.Int32, oProcesoCarga.Cantidad)
            oDatabase.AddInParameter(oDbCommand, "@ValorVenta", DbType.Decimal, oProcesoCarga.ValorVenta)
            oDatabase.AddInParameter(oDbCommand, "@IGV", DbType.Decimal, oProcesoCarga.Igv)
            oDatabase.AddInParameter(oDbCommand, "@IdCarga", DbType.Int32, oProcesoCarga.IDCarga)
            oDatabase.AddInParameter(oDbCommand, "@IdSucursalReferencia", DbType.Int32, oProcesoCarga.IdSucursal)
            oDatabase.ExecuteNonQuery(oDbCommand)

            result = 1
        Catch ex As Exception
            Throw ex
        End Try
        Return result
    End Function

    Public Function ImportarDatosVenta(oProcesoCarga As ProcesoCarga) As Integer
        Dim result As Integer = -1
        Try

            Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_INS_VENTA)
            oDbCommand.CommandTimeout = 0
            'oDatabase.AddInParameter(oDbCommand, "@TipoDocumento", DbType.String, oProcesoCarga.TipoDocumento)
            oDatabase.AddInParameter(oDbCommand, "@IdTipoDocumento", DbType.Int32, oProcesoCarga.IdTipoDocumento)
            oDatabase.AddInParameter(oDbCommand, "@NumeroDocumento", DbType.Int32, oProcesoCarga.NumeroDocumento)
            oDatabase.AddInParameter(oDbCommand, "@RUC", DbType.String, oProcesoCarga.Ruc)
            oDatabase.AddInParameter(oDbCommand, "@FechaVenta", DbType.Date, oProcesoCarga.Fecha)
            oDatabase.AddInParameter(oDbCommand, "@SKU", DbType.String, oProcesoCarga.Sku)
            oDatabase.AddInParameter(oDbCommand, "@Cantidad", DbType.Int32, oProcesoCarga.Cantidad)
            oDatabase.AddInParameter(oDbCommand, "@ValorVenta", DbType.Decimal, oProcesoCarga.ValorVenta)
            oDatabase.AddInParameter(oDbCommand, "@IGV", DbType.Decimal, oProcesoCarga.Igv)
            oDatabase.AddInParameter(oDbCommand, "@Total", DbType.Decimal, oProcesoCarga.Total)
            oDatabase.AddInParameter(oDbCommand, "@IdCarga", DbType.Int32, oProcesoCarga.IDCarga)
            oDatabase.AddInParameter(oDbCommand, "@IdSucursalReferencia", DbType.Int32, oProcesoCarga.IdSucursal)
            oDatabase.AddInParameter(oDbCommand, "@IdCliente", DbType.Int32, oProcesoCarga.IdCliente)
            oDatabase.ExecuteNonQuery(oDbCommand)

            result = 1
        Catch ex As Exception
            Throw ex
        End Try
        Return result
    End Function

    Public Function ListarCargasManuales() As ListaProcesoCarga
        Dim oLista As New ListaProcesoCarga
        Dim oProceso As New ProcesoCarga
        Dim result As Integer = -1
        Try
            Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_LISTARCARGASMANUALES)

            Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
                Dim indicetipodoc As Integer = oIDataReader.GetOrdinal("TipoDocumento")
                Dim indicenumerodoc As Integer = oIDataReader.GetOrdinal("NumeroDocumento")
                Dim indiceFecha As Integer = oIDataReader.GetOrdinal("Fecha")
                Dim indiceruc As Integer = oIDataReader.GetOrdinal("Ruc")

                While oIDataReader.Read()
                    oProceso = New ProcesoCarga
                    oProceso.TipoDocumento = DataUtil.DbValueToDefault(Of String)(oIDataReader(indicetipodoc))
                    oProceso.NumeroDocumento = DataUtil.DbValueToDefault(Of String)(oIDataReader(indicenumerodoc))
                    oProceso.Fecha = DataUtil.DbValueToDefault(Of DateTime)(oIDataReader(indiceFecha))
                    oProceso.Ruc = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceruc))
                    'oProceso.Id_Estado = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indiceidestado))
                    oLista.Add(oProceso)
                End While
            End Using
            result = 1
        Catch ex As Exception
            Throw ex
        End Try
        Return oLista
    End Function

    Public Function ActualizarComisionesManual(Fecha As Date) As Integer
        Dim result As Integer = -1
        Try
            Dim oDbCommand As DbCommand = oDatabaseAsync.GetStoredProcCommand(Procedimientos.USP_ACTUALIZAVENTACOMISIONMANUAL)
            oDbCommand.CommandTimeout = Timeout
            oDatabase.AddInParameter(oDbCommand, "@Fecha", DbType.Date, Fecha)
            oDatabase.ExecuteNonQuery(oDbCommand)
            result = 1
            Return result
        Catch ex As Exception
            Return result = -1
        End Try
    End Function

    Public Function OtenerFechas(IdCarga As Integer) As ComisionEscala
        Try
            Dim result As Integer = -1
            Dim oProceso As New ComisionEscala
            Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_OBTENERFECHAS)

            oDatabase.AddInParameter(oDbCommand, "@IdCarga", DbType.Int32, IdCarga)

            Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
                Dim indicefecmin As Integer = oIDataReader.GetOrdinal("FecMin")
                Dim indicefecmax As Integer = oIDataReader.GetOrdinal("FecMax")

                While oIDataReader.Read()
                    oProceso = New ComisionEscala
                    oProceso.PlanVentaFactorFechaInicio = DataUtil.DbValueToDefault(Of DateTime)(oIDataReader(indicefecmin))
                    oProceso.PlanVentaFactorFechaFin = DataUtil.DbValueToDefault(Of DateTime)(oIDataReader(indicefecmax))
                End While
            End Using
            Return oProceso
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    'METODO ANTERIOR 
    Public Function ImportarVenta_Detalle(ListaProcesoCarga As ListaProcesoCarga, ListaAgrupada As ListaProcesoCarga) As Int32
        Dim result As Integer
        Try
            Dim oSqlDatabase As SqlDatabase = DirectCast(DatabaseFactory.CreateDatabase(Conexion.cnsSql), SqlDatabase)
            Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_INS_VENTA_DETALLE)
            oSqlDatabase.AddInParameter(oDbCommand, "@TVenta", SqlDbType.Structured, MapearListaVenta(ListaProcesoCarga))
            oSqlDatabase.AddInParameter(oDbCommand, "@TVentaDetalle", SqlDbType.Structured, MapearListaVentaDetalle(ListaProcesoCarga))
            oSqlDatabase.AddInParameter(oDbCommand, "@TVentaCabecera", SqlDbType.Structured, MapearListaVentaCabecera(ListaAgrupada))
            result = CInt(oDatabase.ExecuteScalar(oDbCommand))
            Return result
        Catch ex As Exception
            Return -1
        End Try
    End Function

    'METODO ACTUAL
    Public Function ImportarVenta_Venta(ListaProcesoCarga As ListaProcesoCarga) As Int32
        Dim result As Integer
        Try
            Dim oSqlDatabase As SqlDatabase = DirectCast(DatabaseFactory.CreateDatabase(Conexion.cnsSql), SqlDatabase)
            Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_INS_VENTA_VENTA)
            oSqlDatabase.AddInParameter(oDbCommand, "@TVenta", SqlDbType.Structured, MapearListaVenta(ListaProcesoCarga))
            result = CInt(oDatabase.ExecuteScalar(oDbCommand))
            Return result
        Catch ex As Exception
            Return -1
        End Try
    End Function

    Private Function MapearListaVenta(oListaProcesoCarga As ListaProcesoCarga) As IEnumerable(Of SqlDataRecord)
        Dim ListaRegistro As New List(Of SqlDataRecord)
        Try
            For Each item In oListaProcesoCarga
                Dim Registro As New SqlDataRecord(New SqlMetaData() {
                                New SqlMetaData("IdTipoDocumento", SqlDbType.Int) _
                              , New SqlMetaData("NumeroDocumento", SqlDbType.Int) _
                              , New SqlMetaData("IdCliente", SqlDbType.Int) _
                              , New SqlMetaData("RUC", SqlDbType.VarChar, 12) _
                              , New SqlMetaData("RazonSocial", SqlDbType.VarChar, 100) _
                              , New SqlMetaData("IdSucursal", SqlDbType.Int) _
                              , New SqlMetaData("NombreSucursal", SqlDbType.VarChar, 50) _
                              , New SqlMetaData("Dia", SqlDbType.TinyInt) _
                              , New SqlMetaData("Mes", SqlDbType.TinyInt) _
                              , New SqlMetaData("Ano", SqlDbType.TinyInt) _
                              , New SqlMetaData("FechaVenta", SqlDbType.DateTime) _
                              , New SqlMetaData("TipoCaja", SqlDbType.VarChar, 20) _
                              , New SqlMetaData("FormaPago", SqlDbType.VarChar, 50) _
                              , New SqlMetaData("SKU", SqlDbType.VarChar, 15) _
                              , New SqlMetaData("DescripcionSKU", SqlDbType.VarChar, 100) _
                              , New SqlMetaData("ClaCom", SqlDbType.VarChar, 255) _
                              , New SqlMetaData("DescripcionClaCom", SqlDbType.VarChar, 255) _
                              , New SqlMetaData("CodDepAnt", SqlDbType.VarChar, 50) _
                              , New SqlMetaData("NomDepAnt", SqlDbType.VarChar, 255) _
                              , New SqlMetaData("CodFamAnt", SqlDbType.VarChar, 255) _
                              , New SqlMetaData("NomFamAnt", SqlDbType.VarChar, 255) _
                              , New SqlMetaData("Cantidad", SqlDbType.Decimal, 11, 2) _
                              , New SqlMetaData("PrecioIGV", SqlDbType.Decimal, 11, 2) _
                              , New SqlMetaData("CostoUnitario", SqlDbType.Decimal, 11, 2) _
                              , New SqlMetaData("IGV", SqlDbType.Decimal, 10, 2) _
                              , New SqlMetaData("Total", SqlDbType.Decimal, 11, 2) _
                              , New SqlMetaData("PrecioNeto", SqlDbType.Decimal, 11, 2) _
                              , New SqlMetaData("Margen", SqlDbType.Decimal, 11, 4) _
                              , New SqlMetaData("Contribucion", SqlDbType.Decimal, 11, 2) _
                              , New SqlMetaData("ClienteEspecial", SqlDbType.Bit) _
                              , New SqlMetaData("IdCarga", SqlDbType.Int) _
                              , New SqlMetaData("Activo", SqlDbType.Bit) _
                              , New SqlMetaData("CostoTotal", SqlDbType.Decimal, 11, 2) _
                              , New SqlMetaData("PercepcionPorcentaje", SqlDbType.Decimal, 5, 2) _
                              , New SqlMetaData("MontoPercepcion", SqlDbType.Decimal, 11, 2) _
                              , New SqlMetaData("TotalVtaIgvPercepcion", SqlDbType.Decimal, 11, 2) _
                              , New SqlMetaData("IdSucursalReal", SqlDbType.Int)})

                Registro.SetInt32(0, item.IdTipoDocumento)
                Registro.SetInt32(1, item.NumeroDocumento)
                Registro.SetInt32(2, item.IdCliente)
                Registro.SetString(3, item.Ruc)
                Registro.SetString(4, item.RazonSocial)
                Registro.SetInt32(5, item.IdSucursal)
                Registro.SetString(6, item.NombreSucursal)
                Registro.SetByte(7, item.Fecha.Day)
                Registro.SetByte(8, item.Fecha.Month)
                Registro.SetByte(9, item.Fecha.Year Mod 100) 'Solo los dos ultimos digitos del año
                Registro.SetDateTime(10, item.Fecha)
                Registro.SetString(11, item.TipoCaja)
                Registro.SetString(12, "0") 'Por definir forma de pago
                Registro.SetString(13, item.Sku)
                Registro.SetString(14, item.DescripcionSku)
                Registro.SetString(15, item.ClaCom)
                Registro.SetString(16, item.DescripcionClaCom)
                Registro.SetString(17, item.CodDepAnt)
                Registro.SetString(18, item.NomDepAnt)
                Registro.SetString(19, item.CodFamAnt)
                Registro.SetString(20, item.NomFamAnt)
                Registro.SetDecimal(21, item.Cantidad)
                Registro.SetDecimal(22, item.PrecioIGV)
                Registro.SetDecimal(23, item.CostoUnitario)
                Registro.SetDecimal(24, item.VVIGV)
                Registro.SetDecimal(25, item.VVTotal)
                Registro.SetDecimal(26, item.VVPrecioNeto)
                Registro.SetDecimal(27, item.Margen)
                Registro.SetDecimal(28, item.Contribucion)
                Registro.SetBoolean(29, True)
                Registro.SetInt32(30, item.IDCarga)
                Registro.SetBoolean(31, True)
                Registro.SetDecimal(32, item.CostoTotal)
                Registro.SetDecimal(33, item.PercepcionPorcentaje)
                Registro.SetDecimal(34, item.MontoPercepcion)
                Registro.SetDecimal(35, item.TotalVtaIgvPercepcion)
                Registro.SetInt32(36, item.IdSucursalReal)


                ListaRegistro.Add(Registro)
            Next
        Catch ex As Exception
            Throw ex
        End Try

        Return ListaRegistro
    End Function

    Private Function MapearListaVentaDetalle(oListaProcesoCarga As ListaProcesoCarga) As IEnumerable(Of SqlDataRecord)
        Dim ListaRegistro As New List(Of SqlDataRecord)
        Try
            For Each item In oListaProcesoCarga
                Dim Registro As New SqlDataRecord(New SqlMetaData() {
                                New SqlMetaData("IdTipoDocumento", SqlDbType.Int) _
                              , New SqlMetaData("Ano", SqlDbType.TinyInt) _
                              , New SqlMetaData("Mes", SqlDbType.TinyInt) _
                              , New SqlMetaData("Dia", SqlDbType.TinyInt) _
                              , New SqlMetaData("FechaVenta", SqlDbType.DateTime) _
                              , New SqlMetaData("Sucursal", SqlDbType.SmallInt) _
                              , New SqlMetaData("NumeroDocumento", SqlDbType.Int) _
                              , New SqlMetaData("ContadorSKU", SqlDbType.TinyInt) _
                              , New SqlMetaData("SKU", SqlDbType.VarChar, 15) _
                              , New SqlMetaData("Cantidad", SqlDbType.Decimal, 11, 2) _
                              , New SqlMetaData("Valor", SqlDbType.Decimal, 11, 2) _
                              , New SqlMetaData("CostoUnitario", SqlDbType.Decimal, 11, 2) _
                              , New SqlMetaData("IGV", SqlDbType.Decimal, 10, 2) _
                              , New SqlMetaData("HUA", SqlDbType.Char, 6) _
                              , New SqlMetaData("AfectoIGV", SqlDbType.VarChar, 1) _
                              , New SqlMetaData("CantidadValor", SqlDbType.Decimal, 11, 2) _
                              , New SqlMetaData("CantidadIGV", SqlDbType.Decimal, 11, 2) _
                              , New SqlMetaData("FechaRegistro", SqlDbType.DateTime) _
                              , New SqlMetaData("Activo", SqlDbType.Bit) _
                              , New SqlMetaData("IdCarga", SqlDbType.Int)
                             })

                Registro.SetInt32(0, item.IdTipoDocumento)
                Registro.SetByte(1, item.Fecha.Year Mod 100) 'Solo los dos ultimos digitos del año
                Registro.SetByte(2, item.Fecha.Month)
                Registro.SetByte(3, item.Fecha.Day)
                Registro.SetDateTime(4, item.Fecha)
                Registro.SetInt16(5, item.IdSucursal)
                Registro.SetInt32(6, item.NumeroDocumento)
                Registro.SetByte(7, item.ContadorSKU)
                Registro.SetString(8, item.Sku)
                Registro.SetDecimal(9, item.Cantidad)
                Registro.SetDecimal(10, item.Valor) 'Valor
                Registro.SetDecimal(11, item.CostoUnitario)
                Registro.SetDecimal(12, item.VDIGV)
                Registro.SetString(13, "HUA") 'Por definir HUA
                Registro.SetString(14, "1") 'AfectoIGV
                Registro.SetDecimal(15, item.Total)
                Registro.SetDecimal(16, item.Igv)
                Registro.SetDateTime(17, Date.Now) 'GETDATE()
                Registro.SetBoolean(18, True)
                Registro.SetInt32(19, item.IDCarga)

                ListaRegistro.Add(Registro)
            Next
        Catch ex As Exception
            Throw ex
        End Try

        Return ListaRegistro
    End Function

    Private Function MapearListaVentaCabecera(oListaAgrupada As ListaProcesoCarga) As Object
        Dim ListaRegistro As New List(Of SqlDataRecord)
        Try
            For Each item In oListaAgrupada
                Dim Registro As New SqlDataRecord(New SqlMetaData() {
                                New SqlMetaData("IdTipoDocumento", SqlDbType.Int) _
                              , New SqlMetaData("Ano", SqlDbType.TinyInt) _
                              , New SqlMetaData("Mes", SqlDbType.TinyInt) _
                              , New SqlMetaData("Dia", SqlDbType.TinyInt) _
                              , New SqlMetaData("FechaVenta", SqlDbType.DateTime) _
                              , New SqlMetaData("Sucursal", SqlDbType.SmallInt) _
                              , New SqlMetaData("NumeroDocumento", SqlDbType.Int) _
                              , New SqlMetaData("Hora", SqlDbType.TinyInt) _
                              , New SqlMetaData("Minuto", SqlDbType.TinyInt) _
                              , New SqlMetaData("RUC", SqlDbType.VarChar, 20) _
                              , New SqlMetaData("Valor", SqlDbType.Decimal, 11, 2) _
                              , New SqlMetaData("IGV", SqlDbType.Decimal, 11, 2) _
                              , New SqlMetaData("Total", SqlDbType.Decimal, 11, 2) _
                              , New SqlMetaData("Costo", SqlDbType.Decimal, 11, 2) _
                              , New SqlMetaData("NombreCliente", SqlDbType.VarChar, 50) _
                              , New SqlMetaData("NumeroTarjeta", SqlDbType.VarChar, 50) _
                              , New SqlMetaData("CajeMeson", SqlDbType.Decimal, 5, 0) _
                              , New SqlMetaData("Redondeo", SqlDbType.Decimal, 7, 2) _
                              , New SqlMetaData("FechaRegistro", SqlDbType.DateTime) _
                              , New SqlMetaData("Activo", SqlDbType.Bit) _
                              , New SqlMetaData("IdTipoCarga", SqlDbType.TinyInt) _
                              , New SqlMetaData("IdCarga", SqlDbType.Int) _
                              , New SqlMetaData("DocumentoAfecto", SqlDbType.VarChar, 12) _
                              , New SqlMetaData("Descripcion", SqlDbType.VarChar, 200) _
                              , New SqlMetaData("IdMoneda", SqlDbType.Int) _
                              , New SqlMetaData("TipoCambio", SqlDbType.Decimal, 12, 6)
                             })

                Registro.SetInt32(0, item.IdTipoDocumento)
                Registro.SetByte(1, item.Fecha.Year Mod 100) 'Solo los dos ultimos digitos del año
                Registro.SetByte(2, item.Fecha.Month)
                Registro.SetByte(3, item.Fecha.Day)
                Registro.SetDateTime(4, item.Fecha)
                Registro.SetInt16(5, item.IdSucursal)
                Registro.SetInt32(6, item.NumeroDocumento)
                Registro.SetByte(7, item.Hora)
                Registro.SetByte(8, item.Minuto)
                Registro.SetString(9, item.Ruc)
                Registro.SetDecimal(10, item.Valor)
                Registro.SetDecimal(11, item.Igv)
                Registro.SetDecimal(12, item.Total)
                Registro.SetDecimal(13, item.CostoUnitario)
                Registro.SetString(14, item.NombreCliente)
                Registro.SetString(15, item.NumeroTarjeta)
                Registro.SetDecimal(16, item.CajeMeson)
                Registro.SetDecimal(17, item.Redondeo)
                Registro.SetDateTime(18, Date.Now) 'FechaRegistro=GETDATE()
                Registro.SetBoolean(19, True)
                Registro.SetByte(20, item.IdTipoCarga)
                Registro.SetInt32(21, item.IDCarga)
                Registro.SetString(22, item.DocumentoAfecto)
                Registro.SetString(23, item.Comentario)
                Registro.SetInt32(24, item.IdMoneda)
                Registro.SetDecimal(25, item.Tc)

                ListaRegistro.Add(Registro)
            Next
        Catch ex As Exception
            Throw ex
        End Try

        Return ListaRegistro
    End Function
#End Region

    Function InsertaVentasporConsulta(IdZona As Integer, IdSucursal As String, FechaInicio As String, FechaFin As String) As Integer
        Dim resultado As Integer = 0
        Try
            Dim oDbComand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_INSERTAREPROCESOVENTAS)
            oDatabase.AddInParameter(oDbComand, "@IdZona", DbType.Int32, IdZona)
            oDatabase.AddInParameter(oDbComand, "@IdSucursal", DbType.String, IdSucursal)
            oDatabase.AddInParameter(oDbComand, "@FechaIni", DbType.Date, FechaInicio)
            oDatabase.AddInParameter(oDbComand, "@FechaFin", DbType.Date, FechaFin)
            resultado = oDatabase.ExecuteScalar(oDbComand)
        Catch ex As Exception
            resultado = -1
        End Try
        Return resultado
    End Function

    Function ActualizarEstadoCargaManual(IDCarga As Integer, IdEstado As Integer) As Integer
        Dim resultado As Integer = 0
        Dim oDbComand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_DEL_ELIMINARCARGARMANUAL)
        oDatabase.AddInParameter(oDbComand, "@IdCarga", DbType.Int32, IDCarga)
        oDatabase.AddInParameter(oDbComand, "@IdEstado", DbType.Int32, IdEstado)
        resultado = oDatabase.ExecuteScalar(oDbComand)
        Return resultado
    End Function

    Function QuitarEstadoCargaManual(IDCarga As Integer, IdEstado As Integer) As Integer
        Dim resultado As Integer = 0
        Dim oDbComand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_DEL_QUITARHISTORIALCARGA)
        oDatabase.AddInParameter(oDbComand, "@IdCarga", DbType.Int32, IDCarga)
        oDatabase.AddInParameter(oDbComand, "@IdEstado", DbType.Int32, IdEstado)
        resultado = oDatabase.ExecuteScalar(oDbComand)
        Return resultado
    End Function

    Public Function ListaDetalleHistorial(IDCarga As Integer) As ListaProcesoCarga
        Dim oLista As New ListaProcesoCarga
        Dim oProceso As New ProcesoCarga
        Dim result As Integer = -1
        Try
            Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_VENTAPORIDCARGA)
            oDatabase.AddInParameter(oDbCommand, "@IdCarga", DbType.Int32, IDCarga)

            Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
                Dim indicetipodoc As Integer = oIDataReader.GetOrdinal("TipoDocumento")
                Dim indicesucursal As Integer = oIDataReader.GetOrdinal("Sucursal")
                Dim indicenumerodoc As Integer = oIDataReader.GetOrdinal("NumeroDocumento")
                Dim indiceFecha As Integer = oIDataReader.GetOrdinal("Fecha")
                Dim indiceruc As Integer = oIDataReader.GetOrdinal("Ruc")
                Dim indicesku As Integer = oIDataReader.GetOrdinal("SKU")
                Dim indicecantidad As Integer = oIDataReader.GetOrdinal("Cantidad")
                Dim indicevalorventa As Integer = oIDataReader.GetOrdinal("ValorVenta")
                Dim indiceigv As Integer = oIDataReader.GetOrdinal("IGV")
                Dim indicetotal As Integer = oIDataReader.GetOrdinal("Total")
                Dim indicedocafecto As Integer = oIDataReader.GetOrdinal("DocumentoAfecto")
                Dim indicecomentario As Integer = oIDataReader.GetOrdinal("Comentario")
                Dim indicemoneda As Integer = oIDataReader.GetOrdinal("Moneda")
                Dim indicetipocambio As Integer = oIDataReader.GetOrdinal("TipoCambio")
                Dim indiceCostoTotal As Integer = oIDataReader.GetOrdinal("CostoTotal")
                Dim indicePercepcionPorcentaje As Integer = oIDataReader.GetOrdinal("PercepcionPorcentaje")
                Dim indiceMontoPercepcion As Integer = oIDataReader.GetOrdinal("MontoPercepcion")
                Dim indiceTotalVtaIgvPercepcion As Integer = oIDataReader.GetOrdinal("TotalVtaIgvPercepcion")
                While oIDataReader.Read()
                    oProceso = New ProcesoCarga
                    oProceso.TipoDocumento = DataUtil.DbValueToDefault(Of String)(oIDataReader(indicetipodoc))
                    oProceso.IdSucursal = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indicesucursal))
                    oProceso.NumeroDocumento = CStr(DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indicenumerodoc)))
                    oProceso.Fecha = DataUtil.DbValueToDefault(Of DateTime)(oIDataReader(indiceFecha)).Date
                    oProceso.Ruc = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceruc))
                    oProceso.Sku = DataUtil.DbValueToDefault(Of String)(oIDataReader(indicesku))
                    oProceso.Cantidad = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(indicecantidad))
                    oProceso.ValorVenta = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(indicevalorventa))
                    oProceso.Igv = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(indiceigv))
                    oProceso.Total = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(indicetotal))
                    oProceso.DocumentoAfecto = DataUtil.DbValueToDefault(Of String)(oIDataReader(indicedocafecto))
                    oProceso.Comentario = DataUtil.DbValueToDefault(Of String)(oIDataReader(indicecomentario))
                    oProceso.Moneda = DataUtil.DbValueToDefault(Of String)(oIDataReader(indicemoneda))
                    oProceso.Tc = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(indicetipocambio))
                    oProceso.CostoTotal = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(indiceCostoTotal))
                    oProceso.PercepcionPorcentaje = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(indicePercepcionPorcentaje))
                    oProceso.MontoPercepcion = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(indiceMontoPercepcion))
                    oProceso.TotalVtaIgvPercepcion = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(indiceTotalVtaIgvPercepcion))
                    oLista.Add(oProceso)
                End While
            End Using

            result = 1
        Catch ex As Exception
            Throw ex
        End Try
        Return oLista
    End Function

    Public Function BuscarMoneda(Moneda As String) As Integer
        Dim rst As Integer = 0
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(Procedimientos.USP_BUSCARMONEDA, Moneda)

            While oIDataReader.Read()
                Dim res As Integer = oIDataReader.GetOrdinal("Resultado")
                rst = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(res))
            End While
        End Using
        Return rst
    End Function

    Public Function ListaDocumentoTipo() As ListaProcesoCarga
        Dim oListaProcesoCarga As New ListaProcesoCarga
        Dim oProcesoCarga As ProcesoCarga
        Dim result As Integer = -1
        Try
            Using oIDataReader As IDataReader = oDatabase.ExecuteReader(Procedimientos.USP_LISTARDOCUMENTOTIPO)
                Dim indiceidtipodocumento As Integer = oIDataReader.GetOrdinal("IdDocumentoTipo")
                Dim indicedescdocumento As Integer = oIDataReader.GetOrdinal("DescripcionCorta")

                While oIDataReader.Read()
                    oProcesoCarga = New ProcesoCarga
                    oProcesoCarga.IdTipoDocumento = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indiceidtipodocumento))
                    oProcesoCarga.TipoDocumento = DataUtil.DbValueToDefault(Of String)(oIDataReader(indicedescdocumento))
                    oListaProcesoCarga.Add(oProcesoCarga)
                End While
            End Using
            result = 1
        Catch ex As Exception
            Throw ex
        End Try
        Return oListaProcesoCarga
    End Function

    Public Function ListaSucursalVenta() As ListaProcesoCarga
        Dim oListaProcesoCarga As New ListaProcesoCarga
        Dim oProcesoCarga As ProcesoCarga
        Dim result As Integer = -1
        Try
            Using oIDataReader As IDataReader = oDatabase.ExecuteReader(Procedimientos.USP_LISTARSUCURSAL)
                Dim indiceidsucursal As Integer = oIDataReader.GetOrdinal("IdSucursal")
                Dim indicecodigosucursal As Integer = oIDataReader.GetOrdinal("CodigoSucursal")
                Dim indicedescripcion As Integer = oIDataReader.GetOrdinal("Descripcion")

                While oIDataReader.Read()
                    oProcesoCarga = New ProcesoCarga
                    oProcesoCarga.IdSucursal = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indiceidsucursal))
                    oProcesoCarga.IdSucursalReal = Convert.ToUInt32(DataUtil.DbValueToDefault(Of String)(oIDataReader(indicecodigosucursal)))
                    oProcesoCarga.NombreSucursal = DataUtil.DbValueToDefault(Of String)(oIDataReader(indicedescripcion))
                    oListaProcesoCarga.Add(oProcesoCarga)
                End While
            End Using
            result = 1
        Catch ex As Exception
            Throw ex
        End Try
        Return oListaProcesoCarga
    End Function

#Region "Mapeo de lista procesa carga"
    Private Function MapearParametroListaProcesaCarga(oListaProcesoCarga As ListaProcesoCarga) As IEnumerable(Of SqlDataRecord)
        Dim ListaRegistro As New List(Of SqlDataRecord)
        Try
            For Each item In oListaProcesoCarga
                Dim Registro As New SqlDataRecord(New SqlMetaData() {
                                New SqlMetaData("IdTipoDocumento", SqlDbType.Int) _
                              , New SqlMetaData("IdSucursal", SqlDbType.Int) _
                              , New SqlMetaData("NumeroDocumento", SqlDbType.Int) _
                              , New SqlMetaData("FechaVenta", SqlDbType.DateTime) _
                              , New SqlMetaData("RUC", SqlDbType.VarChar, 12) _
                              , New SqlMetaData("SKU", SqlDbType.VarChar, 15)})

                Registro.SetInt32(0, item.IdTipoDocumento)
                Registro.SetInt32(1, item.IdSucursal)
                Registro.SetInt32(2, item.NumeroDocumento)
                Registro.SetDateTime(3, item.Fecha)
                Registro.SetString(4, item.Ruc)
                Registro.SetString(5, item.Sku)

                ListaRegistro.Add(Registro)
            Next
        Catch ex As Exception
            Throw ex
        End Try

        Return ListaRegistro
    End Function
#End Region

    Public Function ListaPatronVentas(ListaProcesoCarga As ListaProcesoCarga) As ListaProcesoCarga
        Dim oProcesoCarga As ProcesoCarga
        Dim oListaProcesoCarga As New ListaProcesoCarga
        Dim result As Integer = -1
        Try

            Dim oSqlDatabase As SqlDatabase = DirectCast(DatabaseFactory.CreateDatabase(Conexion.cnsSql), SqlDatabase)
            Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_LISTARVENTAS)
            oSqlDatabase.AddInParameter(oDbCommand, "@TLISTARPROCESOCARGA", SqlDbType.Structured, MapearParametroListaProcesaCarga(ListaProcesoCarga))

            Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
                Dim indiceidtipodocumento As Integer = oIDataReader.GetOrdinal("IdTipoDocumento")
                Dim indiceidsucursal As Integer = oIDataReader.GetOrdinal("IdSucursal")
                Dim indicenumdocumento As Integer = oIDataReader.GetOrdinal("NumeroDocumento")
                Dim indicefecha As Integer = oIDataReader.GetOrdinal("FechaVenta")
                Dim indiceruc As Integer = oIDataReader.GetOrdinal("RUC")
                Dim indicesku As Integer = oIDataReader.GetOrdinal("SKU")

                While oIDataReader.Read()
                    oProcesoCarga = New ProcesoCarga
                    oProcesoCarga.IdTipoDocumento = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indiceidtipodocumento))
                    oProcesoCarga.IdSucursal = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indiceidsucursal))
                    oProcesoCarga.NumeroDocumento = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indicenumdocumento))
                    oProcesoCarga.Fecha = DataUtil.DbValueToDefault(Of Date)(oIDataReader(indicefecha))
                    oProcesoCarga.Ruc = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceruc))
                    oProcesoCarga.Sku = DataUtil.DbValueToDefault(Of String)(oIDataReader(indicesku))
                    oListaProcesoCarga.Add(oProcesoCarga)
                End While
            End Using
            result = 1
        Catch ex As Exception
            Throw ex
        End Try
        Return oListaProcesoCarga
    End Function

    Public Function ListaMoneda() As ListaProcesoCarga
        Dim oProcesoCarga As ProcesoCarga
        Dim oListaProcesoCarga As New ListaProcesoCarga
        Dim result As Integer = -1
        Try
            Using oIDataReader As IDataReader = oDatabase.ExecuteReader(Procedimientos.USP_LISTAMONEDA)
                Dim indiceidmoneda As Integer = oIDataReader.GetOrdinal("IdMoneda")
                Dim indicenombre As Integer = oIDataReader.GetOrdinal("Nombre")

                While oIDataReader.Read()
                    oProcesoCarga = New ProcesoCarga
                    oProcesoCarga.IdMoneda = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indiceidmoneda))
                    oProcesoCarga.Moneda = DataUtil.DbValueToDefault(Of String)(oIDataReader(indicenombre))
                    oListaProcesoCarga.Add(oProcesoCarga)
                End While
            End Using
            result = 1
        Catch ex As Exception
            Throw ex
        End Try
        Return oListaProcesoCarga
    End Function

    Public Function ListaSKU() As ListaProcesoCarga
        Dim oProcesoCarga As ProcesoCarga
        Dim oListaProcesoCarga As New ListaProcesoCarga
        Dim result As Integer = -1
        Try
            Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_LISTASKU)
            oDbCommand.Connection = oDatabase.CreateConnection()
            oDbCommand.CommandTimeout = Timeout
            oDbCommand.Connection.Open()
            Using oIDataReader As IDataReader = oDatabase.ExecuteReader(Procedimientos.USP_LISTASKU)
                Dim indiceidproducto As Integer = oIDataReader.GetOrdinal("IdProducto")
                Dim indicesku As Integer = oIDataReader.GetOrdinal("Sku")
                Dim indicedescproducto As Integer = oIDataReader.GetOrdinal("DescProducto")
                Dim indiceclacom As Integer = oIDataReader.GetOrdinal("Clacom")
                Dim indicedesclacom As Integer = oIDataReader.GetOrdinal("DescClacom")
                Dim indicecoddepant As Integer = oIDataReader.GetOrdinal("CodigoDepAnt")
                Dim indicenomdepant As Integer = oIDataReader.GetOrdinal("NombreDepAnt")
                Dim indicecodfamant As Integer = oIDataReader.GetOrdinal("CodigoFamAnt")
                Dim indicenomfamant As Integer = oIDataReader.GetOrdinal("NombreFamAnt")
                Dim indicecostoprom As Integer = oIDataReader.GetOrdinal("CostoUnitario")

                While oIDataReader.Read()
                    oProcesoCarga = New ProcesoCarga
                    oProcesoCarga.IdProducto = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indiceidproducto))
                    oProcesoCarga.Sku = DataUtil.DbValueToDefault(Of String)(oIDataReader(indicesku))
                    oProcesoCarga.DescripcionSku = DataUtil.DbValueToDefault(Of String)(oIDataReader(indicedescproducto))
                    oProcesoCarga.ClaCom = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceclacom))
                    oProcesoCarga.DescripcionClaCom = DataUtil.DbValueToDefault(Of String)(oIDataReader(indicedesclacom))
                    oProcesoCarga.CodDepAnt = DataUtil.DbValueToDefault(Of String)(oIDataReader(indicecoddepant))
                    oProcesoCarga.NomDepAnt = DataUtil.DbValueToDefault(Of String)(oIDataReader(indicenomdepant))
                    oProcesoCarga.CodFamAnt = DataUtil.DbValueToDefault(Of String)(oIDataReader(indicecodfamant))
                    oProcesoCarga.NomFamAnt = DataUtil.DbValueToDefault(Of String)(oIDataReader(indicenomfamant))
                    oProcesoCarga.CostoUnitario = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(indicecostoprom))
                    oListaProcesoCarga.Add(oProcesoCarga)
                End While
            End Using
            oDbCommand.Connection.Close()
            result = 1
        Catch ex As Exception
            Throw ex
        End Try
        Return oListaProcesoCarga
    End Function

    Public Function ListaParametrosCargaManual() As ListaParametro
        Dim oParametro As Parametro
        Dim oListaParametro As New ListaParametro
        Dim result As Integer = -1
        Try
            Using oIDataReader As IDataReader = oDatabase.ExecuteReader(Procedimientos.USP_LISTAPARAMETROSCARGA)
                Dim indicevalor As Integer = oIDataReader.GetOrdinal("ValorParametro")
                Dim indicecodigo As Integer = oIDataReader.GetOrdinal("CodigoParametro")

                While oIDataReader.Read()
                    oParametro = New Parametro
                    oParametro.Valor1 = DataUtil.DbValueToDefault(Of String)(oIDataReader(indicevalor))
                    oParametro.CodigoParametro = DataUtil.DbValueToDefault(Of String)(oIDataReader(indicecodigo))
                    oListaParametro.Add(oParametro)
                End While
            End Using
            result = 1
        Catch ex As Exception
            Throw ex
        End Try

        Return oListaParametro
    End Function

    Public Function ListaCliente() As ListaClienteVenta
        Dim oClienteVenta As ClienteVenta
        Dim oListaClienteVenta As New ListaClienteVenta
        Dim result As Integer = -1
        Try
            Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_LISTACLIENTE)
            oDbCommand.Connection = oDatabase.CreateConnection()
            oDbCommand.CommandTimeout = Timeout
            oDbCommand.Connection.Open()
            'Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Using oIDataReader As IDataReader = oDatabase.ExecuteReader(Procedimientos.USP_LISTACLIENTE)
                Dim indiceidcliente As Integer = oIDataReader.GetOrdinal("IdCliente")
                Dim indiceruc As Integer = oIDataReader.GetOrdinal("RUC")
                Dim indicerazonsocial As Integer = oIDataReader.GetOrdinal("RazonSocial")
                Dim indicenomcliente As Integer = oIDataReader.GetOrdinal("NombreCliente")
                Dim indicenumtarjeta As Integer = oIDataReader.GetOrdinal("NumeroTarjeta")
                While oIDataReader.Read()
                    oClienteVenta = New ClienteVenta
                    oClienteVenta.IdCliente = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indiceidcliente))
                    oClienteVenta.RUC = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceruc))
                    oClienteVenta.RazonSocial = DataUtil.DbValueToDefault(Of String)(oIDataReader(indicerazonsocial))
                    oClienteVenta.NombreFantasia = DataUtil.DbValueToDefault(Of String)(oIDataReader(indicenomcliente))
                    oClienteVenta.NumeroTarjeta = DataUtil.DbValueToDefault(Of String)(oIDataReader(indicenumtarjeta))
                    oListaClienteVenta.Add(oClienteVenta)
                End While
            End Using
            oDbCommand.Connection.Close()
            result = 1
        Catch ex As Exception
            Throw ex
        End Try
        Return oListaClienteVenta
    End Function

    Public Function ListaClienteRuc(ByRef Ruc As String) As ListaClienteVenta
        Dim oClienteVenta As ClienteVenta
        Dim oListaClienteVenta As New ListaClienteVenta
        Dim result As Integer
        Dim oDbCommand As DbCommand = Nothing

        Try
            oDbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USPLSISTARUC)
            oDatabase.AddInParameter(oDbCommand, "@ruc", DbType.String, Ruc)
            Dim cnStr As String = ConfigurationManager.ConnectionStrings(Conexion.cnsSql).ToString()

            Using SqlCn As New SqlConnection(cnStr)
                oDbCommand.Connection = SqlCn
                oDbCommand.Connection.Open()

                Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
                    Dim indiceidcliente As Integer = oIDataReader.GetOrdinal("IdCliente")
                    Dim indiceruc As Integer = oIDataReader.GetOrdinal("RUC")
                    Dim indicerazonsocial As Integer = oIDataReader.GetOrdinal("RazonSocial")

                    While oIDataReader.Read()
                        oClienteVenta = New ClienteVenta
                        oClienteVenta.IdCliente = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indiceidcliente))
                        oClienteVenta.RUC = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceruc))
                        oClienteVenta.RazonSocial = DataUtil.DbValueToDefault(Of String)(oIDataReader(indicerazonsocial))
                        oListaClienteVenta.Add(oClienteVenta)
                    End While
                End Using
            End Using

            result = 1

        Catch ex As Exception
            result = -1
            Throw ex

        Finally
            oDbCommand.Connection.Close()
            oDbCommand.Connection.Dispose()
        End Try

        Return oListaClienteVenta
    End Function


    Public Function ObtenerResultadoReprocesoVenta() As String
        Dim result As String
        Try
            Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_OBTENERRESULTADOREPROCESO)
            oDbCommand.CommandTimeout = 0
            result = oDatabase.ExecuteScalar(oDbCommand)
        Catch ex As Exception
            Throw ex
        End Try
        Return result
    End Function

#Region "Carga Masiva Cliente"
    Public Function ListaTablaGeneral(IdTabGrup As Integer) As List(Of TablaGeneral)
        Dim lista As List(Of TablaGeneral) = New List(Of TablaGeneral)
        Dim oModel As TablaGeneral
        Try
            Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_LISTA_TABLA_GENERAL)
            oDatabase.AddInParameter(oDbCommand, "@IdTabGrup", DbType.Int32, IdTabGrup)
            oDbCommand.CommandTimeout = Timeout
            Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
                Dim iIdTabGen As Integer = oIDataReader.GetOrdinal("IdTabGen")
                Dim iDescripcionCortaTabGen As Integer = oIDataReader.GetOrdinal("DescripcionCortaTabGen")
                While oIDataReader.Read()
                    oModel = New TablaGeneral
                    oModel.IdTabGen = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(iIdTabGen))
                    oModel.DescripcionTabGen = DataUtil.DbValueToDefault(Of String)(oIDataReader(iDescripcionCortaTabGen))
                    lista.Add(oModel)
                End While
            End Using
        Catch ex As Exception
            Throw ex
        End Try
        Return lista
    End Function

    Public Function ListaClienteCategoria() As List(Of ClienteCategoria)
        Dim olista As List(Of ClienteCategoria) = New List(Of ClienteCategoria)
        Dim oModel As ClienteCategoria
        Try
            Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_LISTA_CLIENTE_CATEGORIA)
            oDbCommand.CommandTimeout = Timeout
            Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
                Dim iIdclienteCategoria As Integer = oIDataReader.GetOrdinal("idclienteCategoria")
                Dim iDescripcionCorta As Integer = oIDataReader.GetOrdinal("DescripcionCorta")
                While oIDataReader.Read()
                    oModel = New ClienteCategoria
                    oModel.IdClienteCategoria = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(iIdclienteCategoria))
                    oModel.Descripcion = DataUtil.DbValueToDefault(Of String)(oIDataReader(iDescripcionCorta))
                    olista.Add(oModel)
                End While
            End Using
        Catch ex As Exception
            Throw ex
        End Try
        Return olista
    End Function

    Public Function ListaDepartamento() As List(Of Departamento)
        Dim olista As List(Of Departamento) = New List(Of Departamento)
        Dim oModel As Departamento
        Try
            Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_LISTA_DEPARTAMENTO)
            oDbCommand.CommandTimeout = Timeout
            Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
                Dim iIdDepartamento As Integer = oIDataReader.GetOrdinal("IdDepartamento")
                Dim iDescripcion As Integer = oIDataReader.GetOrdinal("Descripcion")
                While oIDataReader.Read()
                    oModel = New Departamento
                    oModel.IdDepartamento = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(iIdDepartamento))
                    oModel.Descripcion = DataUtil.DbValueToDefault(Of String)(oIDataReader(iDescripcion))
                    olista.Add(oModel)
                End While
            End Using
        Catch ex As Exception
            Throw ex
        End Try
        Return olista
    End Function

    Public Function ListaDistrito() As List(Of Distrito)
        Dim olista As List(Of Distrito) = New List(Of Distrito)
        Dim oModel As Distrito
        Try
            Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_LISTA_DISTRITO)
            oDbCommand.CommandTimeout = Timeout
            Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
                Dim iIdDistrito As Integer = oIDataReader.GetOrdinal("IdDistrito")
                Dim iDescripcion As Integer = oIDataReader.GetOrdinal("Descripcion")
                While oIDataReader.Read()
                    oModel = New Distrito
                    oModel.IdDistrito = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(iIdDistrito))
                    oModel.Descripcion = DataUtil.DbValueToDefault(Of String)(oIDataReader(iDescripcion))
                    olista.Add(oModel)
                End While
            End Using
        Catch ex As Exception
            Throw ex
        End Try
        Return olista
    End Function

    Public Function ListaGrupo() As List(Of Grupo)
        Dim olista As List(Of Grupo) = New List(Of Grupo)
        Dim oModel As Grupo
        Try
            Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_LISTA_GRUPO)
            oDbCommand.CommandTimeout = Timeout
            Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
                Dim iIdGrupo As Integer = oIDataReader.GetOrdinal("IdGrupo")
                Dim iNombreGrupo As Integer = oIDataReader.GetOrdinal("NombreGrupo")
                While oIDataReader.Read()
                    oModel = New Grupo
                    oModel.IdGrupo = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(iIdGrupo))
                    oModel.NombreGrupo = DataUtil.DbValueToDefault(Of String)(oIDataReader(iNombreGrupo))
                    olista.Add(oModel)
                End While
            End Using
        Catch ex As Exception
            Throw ex
        End Try
        Return olista
    End Function

    Public Function ListaProvincia() As List(Of Provincia)
        Dim olista As List(Of Provincia) = New List(Of Provincia)
        Dim oModel As Provincia
        Try
            Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_LISTA_PROVINCIA)
            oDbCommand.CommandTimeout = Timeout
            Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
                Dim iIdProvincia As Integer = oIDataReader.GetOrdinal("IdProvincia")
                Dim iDescripcion As Integer = oIDataReader.GetOrdinal("Descripcion")
                While oIDataReader.Read()
                    oModel = New Provincia
                    oModel.IdProvincia = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(iIdProvincia))
                    oModel.Descripcion = DataUtil.DbValueToDefault(Of String)(oIDataReader(iDescripcion))
                    olista.Add(oModel)
                End While
            End Using
        Catch ex As Exception
            Throw ex
        End Try
        Return olista
    End Function

    Public Function ListaSector() As List(Of ClienteSector)
        Dim olista As List(Of ClienteSector) = New List(Of ClienteSector)
        Dim oModel As ClienteSector
        Try
            Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_LISTA_SECTOR)
            oDbCommand.CommandTimeout = Timeout
            Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
                Dim iIdClienteSector As Integer = oIDataReader.GetOrdinal("IdClienteSector")
                Dim iDescripcionCorta As Integer = oIDataReader.GetOrdinal("DescripcionCorta")
                While oIDataReader.Read()
                    oModel = New ClienteSector
                    oModel.IdClienteSector = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(iIdClienteSector))
                    oModel.Descripcion = DataUtil.DbValueToDefault(Of String)(oIDataReader(iDescripcionCorta))
                    olista.Add(oModel)
                End While
            End Using
        Catch ex As Exception
            Throw ex
        End Try
        Return olista
    End Function

    Public Function ListaClienteTipo() As List(Of ClienteTipo)
        Dim olista As List(Of ClienteTipo) = New List(Of ClienteTipo)
        Dim oModel As ClienteTipo
        Try
            Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_LISTA_TIPO)
            oDbCommand.CommandTimeout = Timeout
            Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
                Dim iIdClienteTipo As Integer = oIDataReader.GetOrdinal("IdClienteTipo")
                Dim iDescripcionCorta As Integer = oIDataReader.GetOrdinal("DescripcionCorta")
                While oIDataReader.Read()
                    oModel = New ClienteTipo
                    oModel.IdClienteTipo = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(iIdClienteTipo))
                    oModel.Descripcion = DataUtil.DbValueToDefault(Of String)(oIDataReader(iDescripcionCorta))
                    olista.Add(oModel)
                End While
            End Using
        Catch ex As Exception
            Throw ex
        End Try
        Return olista
    End Function

    Public Function ListaEmpleadoSecundario() As List(Of Empleado)
        Dim olista As List(Of Empleado) = New List(Of Empleado)
        Dim oModel As Empleado
        Try
            Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_LISTA_EMPLEADO_SECUNDARIO)
            oDbCommand.CommandTimeout = Timeout
            Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
                Dim iIdEmpleado As Integer = oIDataReader.GetOrdinal("IdEmpleado")
                Dim iCodigoOfisis As Integer = oIDataReader.GetOrdinal("CodigoOfisis")
                Dim iApellidos As Integer = oIDataReader.GetOrdinal("Apellidos")
                Dim iIdSucursalActual As Integer = oIDataReader.GetOrdinal("IdSucursalActual")
                Dim ICodigoSucursal As Integer = oIDataReader.GetOrdinal("CodigoSucursal")
                While oIDataReader.Read()
                    oModel = New Empleado
                    oModel.IdEmpleado = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(iIdEmpleado))
                    oModel.CodigoOfisis = DataUtil.DbValueToDefault(Of String)(oIDataReader(iCodigoOfisis))
                    oModel.Apellidos = DataUtil.DbValueToDefault(Of String)(oIDataReader(iApellidos))
                    oModel.IdSucursalActual = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(iIdSucursalActual))
                    oModel.CodigoSucursal = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(ICodigoSucursal))
                    olista.Add(oModel)
                End While
            End Using
        Catch ex As Exception
            Throw ex
        End Try
        Return olista
    End Function

    Public Function ListaEmpleado() As List(Of Empleado)
        Dim olista As List(Of Empleado) = New List(Of Empleado)
        Dim oModel As Empleado
        Try
            Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_LISTA_EMPLEADO)
            oDbCommand.CommandTimeout = Timeout
            Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
                Dim iIdEmpleado As Integer = oIDataReader.GetOrdinal("IdEmpleado")
                Dim iCodigoOfisis As Integer = oIDataReader.GetOrdinal("CodigoOfisis")
                Dim iApellidos As Integer = oIDataReader.GetOrdinal("Apellidos")
                Dim iIdSucursalActual As Integer = oIDataReader.GetOrdinal("IdSucursalActual")
                While oIDataReader.Read()
                    oModel = New Empleado
                    oModel.IdEmpleado = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(iIdEmpleado))
                    oModel.CodigoOfisis = DataUtil.DbValueToDefault(Of String)(oIDataReader(iCodigoOfisis))
                    oModel.Apellidos = DataUtil.DbValueToDefault(Of String)(oIDataReader(iApellidos))
                    oModel.IdSucursalActual = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(iIdSucursalActual))
                    olista.Add(oModel)
                End While
            End Using
        Catch ex As Exception
            Throw ex
        End Try
        Return olista
    End Function

    Public Function ListaClienteEmpleado() As List(Of Empleado)
        Dim olista As List(Of Empleado) = New List(Of Empleado)
        Dim oModel As Empleado
        Try
            Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_LISTA_CLIENTE_EMPLEADO)
            oDbCommand.CommandTimeout = Timeout
            Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
                Dim iIdCliente As Integer = oIDataReader.GetOrdinal("IdCliente")
                Dim iIdRuc As Integer = oIDataReader.GetOrdinal("RUC")
                Dim iCodigoOfisis As Integer = oIDataReader.GetOrdinal("CodigoOfisis")
                While oIDataReader.Read()
                    oModel = New Empleado
                    oModel.ClienteVenta = New ClienteVenta
                    oModel.IdCliente = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(iIdCliente))
                    oModel.ClienteVenta.RUC = DataUtil.DbValueToDefault(Of String)(oIDataReader(iIdRuc))
                    oModel.CodigoOfisis = DataUtil.DbValueToDefault(Of String)(oIDataReader(iCodigoOfisis))
                    olista.Add(oModel)
                End While
            End Using
        Catch ex As Exception
            Throw ex
        End Try
        Return olista
    End Function

    Public Function ListaSucursal() As List(Of Sucursal)
        Dim olista As List(Of Sucursal) = New List(Of Sucursal)
        Dim oModel As Sucursal
        Try
            Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_LISTASUCURSAL)
            oDbCommand.CommandTimeout = Timeout
            Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
                Dim iCodigoSucursal As Integer = oIDataReader.GetOrdinal("CodigoSucursal")
                Dim iDescripcion As Integer = oIDataReader.GetOrdinal("Descripcion")
                While oIDataReader.Read()
                    oModel = New Sucursal
                    oModel.CodigoSucursal = DataUtil.DbValueToDefault(Of String)(oIDataReader(iCodigoSucursal))
                    oModel.Descripcion = DataUtil.DbValueToDefault(Of String)(oIDataReader(iDescripcion))
                    olista.Add(oModel)
                End While
            End Using
        Catch ex As Exception
            Throw ex
        End Try
        Return olista
    End Function

    Public Function ListaTipoDocumentoCliente() As List(Of TipoDocumento)
        Dim lista As List(Of TipoDocumento) = New List(Of TipoDocumento)
        Dim oModel As TipoDocumento
        Try
            Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_LISTA_TIPO_DOCUMENTO)
            oDbCommand.CommandTimeout = Timeout
            Using oIDataReaer As IDataReader = oDatabase.ExecuteReader(oDbCommand)
                While oIDataReaer.Read()
                    oModel = New TipoDocumento
                    oModel.IdTipoDocumento = DataUtil.DbValueToDefault(Of Integer)(oIDataReaer(oIDataReaer.GetOrdinal("IdTipoDocumento")))
                    oModel.Descripcion = DataUtil.DbValueToDefault(Of String)(oIDataReaer(oIDataReaer.GetOrdinal("Descripcion")))
                    lista.Add(oModel)
                End While
            End Using
        Catch ex As Exception
            Throw ex
        End Try
        Return lista
    End Function

    Public Function ListaClienteContacto() As List(Of ClienteContacto)
        Dim lsta As List(Of ClienteContacto) = New List(Of ClienteContacto)
        Dim oModel As ClienteContacto
        Try
            Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_LISTA_CLIENTE_CONTACTO)
            oDbCommand.CommandTimeout = Timeout
            Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
                Dim iIdContactoTipo As Integer = oIDataReader.GetOrdinal("IdContactoTipo")
                Dim iIdContactoClase As Integer = oIDataReader.GetOrdinal("IdContactoClase")
                Dim iNombres As Integer = oIDataReader.GetOrdinal("Nombres")
                Dim iApellidos As Integer = oIDataReader.GetOrdinal("Apellidos")
                While oIDataReader.Read()
                    oModel = New ClienteContacto
                    oModel.ContactoTipo = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(iIdContactoTipo))
                    oModel.IdContactoClase = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(iIdContactoClase))
                    oModel.Nombres = DataUtil.DbValueToDefault(Of String)(oIDataReader(iNombres))
                    oModel.Apellidos = DataUtil.DbValueToDefault(Of String)(oIDataReader(iApellidos))
                    lsta.Add(oModel)
                End While
            End Using
        Catch ex As Exception
            Throw ex
        End Try
        Return lsta
    End Function

    Public Function RegistraCliente(lstCliente As List(Of CargaMasivaCliente), lstClienteEmpleado As List(Of CargaMasivaCliente), log As Log) As Integer
        Dim listaClienteExiste = ListaCliente()
        Dim mapeoListaCliente As New List(Of SqlDataRecord)
        Dim mapeoListaClienteEmpleado As New List(Of SqlDataRecord)
        If (Not lstCliente Is Nothing) Then
            mapeoListaCliente = CrearSqlDataRecordsCliente(lstCliente, listaClienteExiste, log.Usuario)
        End If
        If (Not lstClienteEmpleado Is Nothing) Then
            mapeoListaClienteEmpleado = CrearSqlDataRecordsClienteEmpleado(lstClienteEmpleado, listaClienteExiste)
        End If
        Dim resultado As Integer = 0
        Try
            Dim oSqlDatabase As SqlDatabase = DirectCast(DatabaseFactory.CreateDatabase(Conexion.cnsSql), SqlDatabase)
            Dim oDbComand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.SP_REGISTRAR_CLIENTE)
            If (Not lstCliente Is Nothing) Then
                oSqlDatabase.AddInParameter(oDbComand, "@DT_CLIENTE", SqlDbType.Structured, mapeoListaCliente)
            End If
            If (Not lstClienteEmpleado Is Nothing) Then
                oSqlDatabase.AddInParameter(oDbComand, "@DT_CLIENTEEMPLEADO", SqlDbType.Structured, mapeoListaClienteEmpleado)
            End If
            resultado = CInt(oDatabase.ExecuteScalar(oDbComand))
        Catch ex As Exception
            resultado = -1
        End Try
        Return resultado
    End Function

    Public Function DesactivaCliente(lstCliente As List(Of CargaMasivaCliente), lstClienteEmpleado As List(Of CargaMasivaCliente), log As Log) As Integer
        Dim listaClienteExiste = ListaCliente()
        Dim MapeoListaCliente As New List(Of SqlDataRecord)
        Dim MapeoListaClienteEmpleado As New List(Of SqlDataRecord)
        If (Not lstCliente Is Nothing) Then
            MapeoListaCliente = CrearSqlDataRecordsCliente(lstCliente, listaClienteExiste, log.Usuario)
        End If
        If (Not lstClienteEmpleado Is Nothing) Then
            MapeoListaClienteEmpleado = CrearSqlDataRecordsClienteEmpleado(lstClienteEmpleado, listaClienteExiste)
        End If
        Dim resultado As Integer = 0
        Try
            Dim oSqlDatabase As SqlDatabase = DirectCast(DatabaseFactory.CreateDatabase(Conexion.cnsSql), SqlDatabase)
            Dim oDbComand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.SP_DESACTIVAR_CLIENTE)
            If (Not lstCliente Is Nothing) Then
                oSqlDatabase.AddInParameter(oDbComand, "@DT_CLIENTE", SqlDbType.Structured, MapeoListaCliente)
            End If
            If (Not lstClienteEmpleado Is Nothing) Then
                oSqlDatabase.AddInParameter(oDbComand, "@DT_CLIENTEEMPLEADO", SqlDbType.Structured, MapeoListaClienteEmpleado)
            End If
            resultado = CInt(oDatabase.ExecuteScalar(oDbComand))
        Catch ex As Exception
            resultado = -1
        End Try
        Return resultado
    End Function

    Private Function CrearSqlDataRecordsClienteEmpleado(lista As List(Of CargaMasivaCliente), listaClienteExiste As ListaClienteVenta) As IEnumerable(Of SqlDataRecord)
        Dim ListaRegistro As New List(Of SqlDataRecord)
        'Dim lstClienteEmpleado = ListaClienteEmpleado()
        Try

            For Each item As CargaMasivaCliente In lista

                Dim SqlDataRecord = New SqlDataRecord(
                    New SqlMetaData("IdCliente", SqlDbType.VarChar, 50),
                    New SqlMetaData("IdEmpleado", SqlDbType.VarChar, 50),
                    New SqlMetaData("IdCarteraEmpleadoTipo", SqlDbType.Int),
                    New SqlMetaData("IdSucursal", SqlDbType.VarChar, 50),
                    New SqlMetaData("FechaActivacion", SqlDbType.DateTime),
                    New SqlMetaData("FechaDesde", SqlDbType.DateTime),
                    New SqlMetaData("IdEstadoActual", SqlDbType.Int),
                    New SqlMetaData("Activo", SqlDbType.Bit),
                    New SqlMetaData("Porcentaje", SqlDbType.Decimal, 18, 2),
                    New SqlMetaData("SucursalSecundario", SqlDbType.Int),
                    New SqlMetaData("Accion", SqlDbType.VarChar, 100)
                    )
                SqlDataRecord.SetString(0, item.Empleado.IdCliente)
                SqlDataRecord.SetString(1, item.Empleado.IdEmpleado)
                SqlDataRecord.SetInt32(2, item.Empleado.TablaGeneral.IdTabGen)
                SqlDataRecord.SetString(3, item.Empleado.Sucursal.CodigoSucursal)
                'SqlDataRecord.SetDateTime(4, If(item.Empleado.FechaAsignacion.Equals(String.Empty), System.DateTime.Now, item.Empleado.FechaAsignacion))
                If (item.Empleado.FechaAsignacion.Equals(String.Empty)) Then
                    SqlDataRecord.SetDBNull(4)
                Else
                    SqlDataRecord.SetDateTime(4, item.Empleado.FechaAsignacion)
                End If
                SqlDataRecord.SetDateTime(5, System.DateTime.Now)
                SqlDataRecord.SetInt32(6, 26)
                SqlDataRecord.SetBoolean(7, 1)
                SqlDataRecord.SetDecimal(8, If(item.Empleado.Porcentaje.Equals(String.Empty), 0, item.Empleado.Porcentaje))

                'If (Not lstClienteEmpleado.Where(Function(m) m.ClienteVenta.RUC.Equals(item.ClienteVenta.RUC) And m.CodigoOfisis.Equals(item.Empleado.CodigoOfisis)).ToList().Count().Equals(0)) Then
                '    'SqlDataRecord.SetString(0, lstClienteEmpleado.Where(Function(m) m.ClienteVenta.RUC.Equals(item.ClienteVenta.RUC) And m.CodigoOfisis.Equals(item.Empleado.CodigoOfisis)).Select(Function(m) m.IdCliente).FirstOrDefault())
                '    SqlDataRecord.SetString(9, "ACTUALIZA")
                'Else
                '    'SqlDataRecord.SetString(0, lstClienteEmpleado.Where(Function(m) m.ClienteVenta.RUC.Equals(item.ClienteVenta.RUC) And m.CodigoOfisis.Equals(item.Empleado.CodigoOfisis)).Select(Function(m) m.IdCliente).FirstOrDefault())
                '    SqlDataRecord.SetString(9, "REGISTRA")
                'End If
                'SqlDataRecord.SetString(9, If(listaClienteExiste.Select(Function(m) m.RUC).Contains(item.ClienteVenta.RUC), "ACTUALIZA", "REGISTRA"))
                SqlDataRecord.SetString(10, "REGISTRA")
                ListaRegistro.Add(SqlDataRecord)
            Next
        Catch ex As Exception
            Throw ex
        End Try
        Return ListaRegistro
    End Function

    Private Function CrearSqlDataRecordsCliente(lista As List(Of CargaMasivaCliente), listaClienteExiste As ListaClienteVenta, usuario As String) As IEnumerable(Of SqlDataRecord)
        Dim ListaRegistro As New List(Of SqlDataRecord)
        Dim lstClienteContacto = ListaClienteContacto()
        Try
            For Each item As CargaMasivaCliente In lista
                Dim sqlDataRecord = New SqlDataRecord(
                    New SqlMetaData("IdClienteCategoria", SqlDbType.Int),
                    New SqlMetaData("IdClienteSector", SqlDbType.Int),
                    New SqlMetaData("IdClienteTipo", SqlDbType.Int),
                    New SqlMetaData("IdModoPago", SqlDbType.Int),
                    New SqlMetaData("FechaActivacion", SqlDbType.DateTime),
                    New SqlMetaData("RUC", SqlDbType.VarChar, 13),
                    New SqlMetaData("RazonSocial", SqlDbType.VarChar, 400),
                    New SqlMetaData("NombreFantasia", SqlDbType.VarChar, 400),
                    New SqlMetaData("IdDepartamento", SqlDbType.Int),
                    New SqlMetaData("IdProvincia", SqlDbType.Int),
                    New SqlMetaData("IdDistrito", SqlDbType.Int),
                    New SqlMetaData("Calle", SqlDbType.VarChar, 400),
                    New SqlMetaData("FechaDesde", SqlDbType.DateTime),
                    New SqlMetaData("IdEstadoActual", SqlDbType.Int),
                    New SqlMetaData("Activo", SqlDbType.Bit),
                    New SqlMetaData("FechaRegistro", SqlDbType.DateTime),
                    New SqlMetaData("UsuarioRegistro", SqlDbType.VarChar, 400),
                    New SqlMetaData("IdGrupo", SqlDbType.Int),
                    New SqlMetaData("ProcedenciaCapital", SqlDbType.VarChar, 400),
                    New SqlMetaData("SiNuevo", SqlDbType.Bit),
                    New SqlMetaData("FechaVigencia", SqlDbType.DateTime),
                    New SqlMetaData("TipoContacto", SqlDbType.Int),
                    New SqlMetaData("NombresContacto", SqlDbType.VarChar, 400),
                    New SqlMetaData("ApellidosContacto", SqlDbType.VarChar, 400),
                    New SqlMetaData("Email", SqlDbType.VarChar, 400),
                    New SqlMetaData("ClaseContacto", SqlDbType.Int),
                    New SqlMetaData("Celular", SqlDbType.VarChar, 100),
                    New SqlMetaData("Accion", SqlDbType.VarChar, 100),
                    New SqlMetaData("AccionClienteContacto", SqlDbType.VarChar, 100)
                )

                sqlDataRecord.SetInt32(0, item.ClienteCategoria.IdClienteCategoria)
                sqlDataRecord.SetInt32(1, item.ClienteSector.IdClienteSector)
                sqlDataRecord.SetInt32(2, item.ClienteTipo.IdClienteTipo)
                sqlDataRecord.SetInt32(3, 2)
                'sqlDataRecord.SetDateTime(4, If(item.ClienteVenta.FechaIngreso.Equals(String.Empty), DBNull.Value, item.ClienteVenta.FechaIngreso))
                If (item.ClienteVenta.FechaIngreso.Equals(String.Empty)) Then
                    sqlDataRecord.SetDBNull(4)
                    sqlDataRecord.SetDBNull(12)
                Else
                    sqlDataRecord.SetDateTime(4, item.ClienteVenta.FechaIngreso)
                    sqlDataRecord.SetDateTime(12, item.ClienteVenta.FechaIngreso)
                End If
                sqlDataRecord.SetString(5, item.ClienteVenta.RUC)
                sqlDataRecord.SetString(6, item.ClienteVenta.RazonSocial)
                sqlDataRecord.SetString(7, item.ClienteVenta.NombreComercial)
                sqlDataRecord.SetInt32(8, item.Departamento.IdDepartamento)
                sqlDataRecord.SetInt32(9, item.Provincia.IdProvincia)
                sqlDataRecord.SetInt32(10, item.Distrito.IdDistrito)
                sqlDataRecord.SetString(11, item.ClienteVenta.Direccion)
                'sqlDataRecord.SetDateTime(12, If(item.ClienteVenta.FechaIngreso.Equals(String.Empty), DBNull.Value, item.ClienteVenta.FechaIngreso))
                sqlDataRecord.SetInt32(13, If(item.ClienteVenta.Autorizar.ToUpper().Equals("SI"), 8, 9))
                sqlDataRecord.SetBoolean(14, 1)
                sqlDataRecord.SetDateTime(15, System.DateTime.Now)
                sqlDataRecord.SetString(16, usuario)
                sqlDataRecord.SetInt32(17, If(item.ClienteVenta.Grupo.IdGrupo Is Nothing, 0, item.ClienteVenta.Grupo.IdGrupo))
                sqlDataRecord.SetString(18, item.ClienteVenta.ProcedenciaCapital)
                sqlDataRecord.SetBoolean(19, 1)
                'sqlDataRecord.SetDateTime(20, If(item.ClienteVenta.FechaVigencia.Equals(String.Empty), DBNull.Value, item.ClienteVenta.FechaVigencia))
                If (item.ClienteVenta.FechaVigencia.Equals(String.Empty)) Then
                    sqlDataRecord.SetDBNull(20)
                Else
                    sqlDataRecord.SetDateTime(20, item.ClienteVenta.FechaVigencia)
                End If

                sqlDataRecord.SetInt32(21, item.ClienteContacto.TipoContancto.IdContactoTipo)
                sqlDataRecord.SetString(22, If(item.ClienteContacto.Nombres Is Nothing, String.Empty, item.ClienteContacto.Nombres))
                sqlDataRecord.SetString(23, If(item.ClienteContacto.Apellidos Is Nothing, String.Empty, item.ClienteContacto.Apellidos))
                sqlDataRecord.SetString(24, item.ClienteContacto.Email)
                sqlDataRecord.SetInt32(25, item.ClienteContacto.ClaseContacto.IdContactoClase)
                sqlDataRecord.SetString(26, item.ClienteContacto.Celular1)
                sqlDataRecord.SetString(27, If(listaClienteExiste.Select(Function(m) m.RUC).Contains(item.ClienteVenta.RUC), "ACTUALIZA", "REGISTRA"))
                If (Not lstClienteContacto.Where(Function(m) m.ContactoTipo.Equals(item.ClienteContacto.TipoContancto.IdContactoTipo) And m.IdContactoClase.Equals(item.ClienteContacto.ClaseContacto.IdContactoClase) And m.Nombres.Equals(item.ClienteContacto.Nombres) And m.Apellidos.Equals(item.ClienteContacto.Apellidos)).ToList().Count().Equals(0)) Then
                    sqlDataRecord.SetString(28, "ACTUALIZA")
                Else
                    sqlDataRecord.SetString(28, "REGISTRA")
                End If
                ListaRegistro.Add(sqlDataRecord)
            Next
        Catch ex As Exception
            Throw ex
        End Try

        Return ListaRegistro
    End Function
#End Region

    Public Function RegistraClienteCartera(lstClienteCartera As List(Of ClienteCartera), log As Log) As Integer
        'Dim listaClienteCarteraExiste = ListaCliente()
        Dim mapeoListaCliente As New List(Of SqlDataRecord)
        If (Not lstClienteCartera Is Nothing) Then
            'mapeoListaCliente = CrearSqlDataRecordsCliente(lstClienteCartera, listaClienteExiste, log.Usuario)
            mapeoListaCliente = CrearSqlDataRecordsCliente(lstClienteCartera, log.Usuario)
        End If
        Dim resultado As Integer = 0
        Try
            Dim oSqlDatabase As SqlDatabase = DirectCast(DatabaseFactory.CreateDatabase(Conexion.cnsSql), SqlDatabase)
            Dim oDbComand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.SP_REGISTRAR_CLIENTE_CARTERA)
            If (Not lstClienteCartera Is Nothing) Then
                oSqlDatabase.AddInParameter(oDbComand, "@DT_EMPRESA_CLIENTE", SqlDbType.Structured, mapeoListaCliente)
            End If
            resultado = CInt(oDatabase.ExecuteScalar(oDbComand))
        Catch ex As Exception
            resultado = -1
        End Try
        Return resultado
    End Function

    Private Function CrearSqlDataRecordsCliente(lista As List(Of ClienteCartera), usuario As String) As IEnumerable(Of SqlDataRecord)
        Dim ListaRegistro As New List(Of SqlDataRecord)
        'Dim lstClienteContacto = ListaClienteContacto()
        Try
            For Each item As ClienteCartera In lista
                Dim sqlDataRecord = New SqlDataRecord(
                    New SqlMetaData("RUC", SqlDbType.VarChar, 12),
                    New SqlMetaData("CodigoSucursal", SqlDbType.VarChar, 4),
                    New SqlMetaData("CodigoOfisis", SqlDbType.VarChar, 15),
                    New SqlMetaData("FechaInicio", SqlDbType.VarChar, 2),
                    New SqlMetaData("FechaFin", SqlDbType.VarChar, 2),
                    New SqlMetaData("Mes", SqlDbType.VarChar, 15),
                    New SqlMetaData("Anio", SqlDbType.VarChar, 4),
                    New SqlMetaData("FechaRegistro", SqlDbType.DateTime),
                    New SqlMetaData("UsuarioRegistro", SqlDbType.VarChar, 50),
                    New SqlMetaData("FechaModifica", SqlDbType.DateTime),
                    New SqlMetaData("UsuarioModifica", SqlDbType.VarChar, 50))

                sqlDataRecord.SetString(0, item.RUC)
                sqlDataRecord.SetString(1, item.CodigoSucursal)
                sqlDataRecord.SetString(2, item.CodigoOfisis)
                sqlDataRecord.SetString(3, item.Fechainicio)
                sqlDataRecord.SetString(4, item.FechaFin)
                sqlDataRecord.SetString(5, item.Mes)
                sqlDataRecord.SetString(6, item.Anio)
                sqlDataRecord.SetDateTime(7, System.DateTime.Now)
                sqlDataRecord.SetString(8, usuario)
                sqlDataRecord.SetDateTime(9, System.DateTime.Now)
                sqlDataRecord.SetString(10, usuario)

                ListaRegistro.Add(sqlDataRecord)
            Next
        Catch ex As Exception
            Throw ex
        End Try

        Return ListaRegistro
    End Function


End Class