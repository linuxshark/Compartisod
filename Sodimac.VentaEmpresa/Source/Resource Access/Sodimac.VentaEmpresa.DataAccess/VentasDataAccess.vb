Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Common
Imports System.Linq
Imports System.Text
Imports Sodimac.VentaEmpresa.BusinessEntities
Imports Sodimac.VentaEmpresa.DataContracts
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common.Configuration

Public Class VentasDataAccess

    Private oDatabase As Database = EnterpriseLibraryContainer.Current.GetInstance(Of Database)(Conexion.cnsSql)

    Public Function BuscarVendedorPorFiltros(ByRef oPaginacion As Paginacion) As Paginacion
        'Dim oListaEmpleado As New ListaEmpleado
        oPaginacion.ListaEmpleado = New ListaEmpleado()

        Dim oDbComand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_BUSCAEMPLEADOPORFILTROS)
        oDatabase.AddInParameter(oDbComand, "@CodigoOfisis", DbType.String, oPaginacion.Empleado.CodigoOfisis)
        oDatabase.AddInParameter(oDbComand, "@NombresApellidos", DbType.String, oPaginacion.Empleado.NombresApellidos)
        oDatabase.AddInParameter(oDbComand, "@IdSucursal", DbType.Int32, oPaginacion.Empleado.Sucursal.IdSucursal)
        oDatabase.AddInParameter(oDbComand, "@IdPerfil", DbType.Int32, oPaginacion.Empleado.Perfil.IdPerfil)
        oDatabase.AddInParameter(oDbComand, "@IdTipoRepVen", DbType.Int32, oPaginacion.Empleado.TipoRepresentanteVenta.IdTipoRepVen) '13068
        oDatabase.AddInParameter(oDbComand, "@IdZona", DbType.Int32, oPaginacion.Empleado.ZonaMantenimiento.IdZona)
        'oDatabase.AddInParameter(oDbComand, "@Activo", DbType.Int32, oPaginacion.Empleado.ProcesoEstado.IdEstado)
        oDatabase.AddInParameter(oDbComand, "@Activo", DbType.Int32, oPaginacion.Empleado.Estado.IdEstado)
        oDatabase.AddInParameter(oDbComand, "@PageSize", DbType.Int32, oPaginacion.PageSize)
        oDatabase.AddInParameter(oDbComand, "@PageNumber", DbType.Int32, oPaginacion.PageNumber)
        oDatabase.AddInParameter(oDbComand, "@SortBy", DbType.String, oPaginacion.SortBy)
        oDatabase.AddInParameter(oDbComand, "@SortType", DbType.String, oPaginacion.SortType)
        oDatabase.AddOutParameter(oDbComand, "@TotalRows", DbType.Int32, 10)
        oDbComand.CommandTimeout = 120000

        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbComand)
            Dim indice_CodEmpleado As Integer = oIDataReader.GetOrdinal("CodEmpleado")
            Dim indice_CodOfisis As Integer = oIDataReader.GetOrdinal("CodOfisis")
            Dim indice_NombresApellidos As Integer = oIDataReader.GetOrdinal("NomApe")
            Dim indice_IdPerfil As Integer = oIDataReader.GetOrdinal("IdPerfil")
            Dim indice_NombrePerfil As Integer = oIDataReader.GetOrdinal("NombrePerfil")
            Dim indice_NombreTipoRepVen As Integer = oIDataReader.GetOrdinal("NombreTipoRepVen") '13068
            Dim indice_NombreCargo As Integer = oIDataReader.GetOrdinal("NombreCargo")
            Dim indice_NombreSucursal As Integer = oIDataReader.GetOrdinal("NombreSucursal")
            Dim indice_TipoPerfil As Integer = oIDataReader.GetOrdinal("TipoPerfil")
            'Dim indice_Activo As Integer = oIDataReader.GetOrdinal("Activo")
            Dim indice_NombreZona As Integer = oIDataReader.GetOrdinal("NombreZona")
            Dim indice_Codigo As Integer = oIDataReader.GetOrdinal("Codigo")
            Dim indice_CodigoEstado As Integer = oIDataReader.GetOrdinal("CodigoEstado")
            Dim indice_DescripcionEstado As Integer = oIDataReader.GetOrdinal("DescripcionEstado")


            While oIDataReader.Read()
                oPaginacion.Empleado = New Empleado()
                oPaginacion.Empleado.IdEmpleado = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indice_CodEmpleado))
                oPaginacion.Empleado.CodigoOfisis = DataUtil.DbValueToDefault(Of String)(oIDataReader(indice_CodOfisis))
                oPaginacion.Empleado.NombresApellidos = DataUtil.DbValueToDefault(Of String)(oIDataReader(indice_NombresApellidos))
                'oPaginacion.Empleado.Activo = DataUtil.DbValueToDefault(Of Boolean)(oIDataReader(indice_Activo))
                oPaginacion.Empleado.Perfil = New Perfil()
                oPaginacion.Empleado.Perfil.IdPerfil = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indice_IdPerfil))
                oPaginacion.Empleado.Perfil.NombrePerfil = DataUtil.DbValueToDefault(Of String)(oIDataReader(indice_NombrePerfil))
                oPaginacion.Empleado.Perfil.TipoPerfil = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indice_TipoPerfil))
                oPaginacion.Empleado.TipoRepresentanteVenta = New TipoRepresentanteVenta()
                oPaginacion.Empleado.TipoRepresentanteVenta.NombreTipoRepVen = DataUtil.DbValueToDefault(Of String)(oIDataReader(indice_NombreTipoRepVen)) '13068
                oPaginacion.Empleado.Cargo = New Cargo()
                oPaginacion.Empleado.Cargo.NombreCargo = DataUtil.DbValueToDefault(Of String)(oIDataReader(indice_NombreCargo))
                oPaginacion.Empleado.Sucursal = New Sucursal()
                oPaginacion.Empleado.Sucursal.Descripcion = DataUtil.DbValueToDefault(Of String)(oIDataReader(indice_NombreSucursal))
                oPaginacion.Empleado.ZonaMantenimiento = New ZonaMantenimiento()
                oPaginacion.Empleado.ZonaMantenimiento.NombreZona = DataUtil.DbValueToDefault(Of String)(oIDataReader(indice_NombreZona))
                'oPaginacion.Empleado.Zona = New Zona()
                'oPaginacion.Empleado.Zona.NombreZona = DataUtil.DbValueToDefault(Of String)(oIDataReader(indice_NombreZona))
                oPaginacion.Empleado.Estado = New Estado()
                oPaginacion.Empleado.Estado.IdEstado = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indice_Codigo))
                oPaginacion.Empleado.Estado.Codigo = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indice_Codigo))
                oPaginacion.Empleado.Estado.Descripcion = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indice_Codigo))

                oPaginacion.Empleado.ProcesoEstado = New ProcesoEstado()
                oPaginacion.Empleado.ProcesoEstado.IdEstado = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indice_Codigo))
                oPaginacion.Empleado.ProcesoEstado.Codigo = DataUtil.DbValueToDefault(Of String)(oIDataReader(indice_CodigoEstado))
                oPaginacion.Empleado.ProcesoEstado.Descripcion = DataUtil.DbValueToDefault(Of String)(oIDataReader(indice_DescripcionEstado))

                oPaginacion.ListaEmpleado.Add(oPaginacion.Empleado)
            End While
        End Using
        oPaginacion.TotalRows = Convert.ToInt32(oDatabase.GetParameterValue(oDbComand, "@TotalRows"))
        Return oPaginacion
    End Function

    Public Function BuscarVendedor(ByRef oPaginacion As Paginacion) As Paginacion

        oPaginacion.ListaEmpleado = New ListaEmpleado()
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_BUSCAVENTAEMPLEADO)

        oDatabase.AddInParameter(oDbCommand, "@CodigoOfisis", DbType.String, oPaginacion.Empleado.CodigoOfisis)
        oDatabase.AddInParameter(oDbCommand, "@NombresApellidos", DbType.String, oPaginacion.Empleado.NombresApellidos)
        oDatabase.AddInParameter(oDbCommand, "@IdSucursal", DbType.Int32, oPaginacion.Empleado.Sucursal.IdSucursal)
        oDatabase.AddInParameter(oDbCommand, "@IdPerfil", DbType.Int32, oPaginacion.Empleado.EmpleadoPerfil.IdPerfil)
        oDatabase.AddInParameter(oDbCommand, "@IdCargo", DbType.Int32, oPaginacion.Empleado.EmpleadoCargo.IdEmpleadoCargo)
        oDatabase.AddInParameter(oDbCommand, "@PageSize", DbType.Int32, oPaginacion.PageSize)
        oDatabase.AddInParameter(oDbCommand, "@PageNumber", DbType.Int32, oPaginacion.PageNumber)
        oDatabase.AddInParameter(oDbCommand, "@SortBy", DbType.String, oPaginacion.SortBy)
        oDatabase.AddInParameter(oDbCommand, "@SortType", DbType.String, oPaginacion.SortType)
        oDatabase.AddOutParameter(oDbCommand, "@TotalRows", DbType.Int32, 10)
        oDbCommand.CommandTimeout = 120000

        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_IdEmpleado As Integer = oIDataReader.GetOrdinal("CodEmpleado")
            Dim INDICE_CodigoOfisis As Integer = oIDataReader.GetOrdinal("CodOfisis")
            Dim INDICE_NomApe As Integer = oIDataReader.GetOrdinal("NomApe")
            Dim INDICE_DescripSucursal As Integer = oIDataReader.GetOrdinal("Sucursal")
            Dim INDICE_Descripcion_Cargo As Integer = oIDataReader.GetOrdinal("Cargo")
            Dim INDICE_Descripcion_Perfil As Integer = oIDataReader.GetOrdinal("Perfil")

            While oIDataReader.Read()
                oPaginacion.Empleado = New Empleado()
                oPaginacion.Empleado.IdEmpleado = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_IdEmpleado))
                oPaginacion.Empleado.CodigoOfisis = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_CodigoOfisis))
                oPaginacion.Empleado.NombresApellidos = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_NomApe))
                oPaginacion.Empleado.Sucursal = New Sucursal()
                oPaginacion.Empleado.Sucursal.DescripcionSucursal = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_DescripSucursal))
                oPaginacion.Empleado.EmpleadoCargo = New EmpleadoCargo()
                oPaginacion.Empleado.EmpleadoCargo.DescripcionCargo = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_Descripcion_Cargo))
                oPaginacion.Empleado.EmpleadoPerfil = New EmpleadoPerfil()
                oPaginacion.Empleado.EmpleadoPerfil.Descripcion = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_Descripcion_Perfil))
                oPaginacion.ListaEmpleado.Add(oPaginacion.Empleado)
            End While
        End Using

        oPaginacion.TotalRows = Convert.ToInt32(oDatabase.GetParameterValue(oDbCommand, "@TotalRows"))
        Return oPaginacion

    End Function

    Function ListaRepresentantesVenta() As ListaComisionRepresentantesVenta
        Dim oListaComisionRepresentantesVenta As New ListaComisionRepresentantesVenta()
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_COMISION_REPRESENTANTESVENTAS)
        oListaComisionRepresentantesVenta = New ListaComisionRepresentantesVenta
        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim oComisionRepresentanteVenta As New ComisionRepresentanteVenta()
            Dim m_IdComisionEscala As Integer = oIDataReader.GetOrdinal("IdComisionEscala")
            Dim m_TiempoServicio As Integer = oIDataReader.GetOrdinal("TiempoServicio")
            While oIDataReader.Read()
                oComisionRepresentanteVenta = New ComisionRepresentanteVenta()
                oComisionRepresentanteVenta.IdComisionEscala = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(m_IdComisionEscala))
                oComisionRepresentanteVenta.TiempoServicio = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(m_TiempoServicio))
                oListaComisionRepresentantesVenta.Add(oComisionRepresentanteVenta)
            End While
        End Using
        Return oListaComisionRepresentantesVenta
    End Function

    Function ListaVentaNombreRepresentante() As ListaVentaNombreRepresentante
        Dim oListaVentaNombreRepresentante As New ListaVentaNombreRepresentante()
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_NOMBRE_REPRESENTANTESVENTAS)
        oListaVentaNombreRepresentante = New ListaVentaNombreRepresentante
        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim oVentaNombreRepresentante As New VentaNombreRepresentante()

            Dim m_IdEmpleado As Integer = oIDataReader.GetOrdinal("IdEmpleado")
            Dim m_NombresApellidos As Integer = oIDataReader.GetOrdinal("NombresApellidos")

            While oIDataReader.Read()
                oVentaNombreRepresentante = New VentaNombreRepresentante()
                oVentaNombreRepresentante.IdEmpleado = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(m_IdEmpleado))
                oVentaNombreRepresentante.NombresApellidos = DataUtil.DbValueToDefault(Of String)(oIDataReader(m_NombresApellidos))
                oListaVentaNombreRepresentante.Add(oVentaNombreRepresentante)
            End While
        End Using
        Return oListaVentaNombreRepresentante
    End Function

    Function ListaEmpleadoCargo() As ListaEmpleadoCargo
        Dim oListaEmpleadoCargo As New ListaEmpleadoCargo()
        'Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_EMPLEADOCARGOLISTA)
        'oListaEmpleadoCargo = New ListaEmpleadoCargo
        'oDbCommand.CommandTimeout = 120000
        'Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
        '    Dim oEmpleadoCargo As New EmpleadoCargo()

        '    Dim m_IdEmpleadoCargo As Integer = oIDataReader.GetOrdinal("IdCargo")
        '    Dim m_Descripcion As Integer = oIDataReader.GetOrdinal("NombreCargo")

        '    While oIDataReader.Read()
        '        oEmpleadoCargo = New EmpleadoCargo()
        '        oEmpleadoCargo.IdEmpleadoCargo = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(m_IdEmpleadoCargo))
        '        oEmpleadoCargo.DescripcionCargo = DataUtil.DbValueToDefault(Of String)(oIDataReader(m_Descripcion))
        '        oListaEmpleadoCargo.Add(oEmpleadoCargo)
        '    End While
        'End Using
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

    Function ListaClienteSector() As ListaClienteSector

        Dim oListaClienteSector As New ListaClienteSector()
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_LISTACLIENTESECTOR)

        oListaClienteSector = New ListaClienteSector()
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim m_IdClienteSector As Integer = oIDataReader.GetOrdinal("IdClienteSector")
            Dim m_Descripcion As Integer = oIDataReader.GetOrdinal("Descripcion")
            While oIDataReader.Read()
                Dim oClienteSector As New ClienteSector()
                oClienteSector = New ClienteSector()

                oClienteSector.IdClienteSector = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(m_IdClienteSector))
                oClienteSector.Descripcion = DataUtil.DbValueToDefault(Of String)(oIDataReader(m_Descripcion))
                oListaClienteSector.Add(oClienteSector)
            End While
        End Using

        Return oListaClienteSector
    End Function

    Function RegistrarEmpleado(ByVal oEmpleado As Empleado) As Integer

        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_INS_EMPLEADO)
        Dim oListaVendedor As New ListaVentaEmpleado()
        Dim result As Integer = 0

        oDatabase.AddInParameter(oDbCommand, "@IdEmpleadoIn", DbType.Int32, oEmpleado.IdEmpleado)
        oDatabase.AddInParameter(oDbCommand, "@CodigoOfisis", DbType.String, oEmpleado.CodigoOfisis)
        oDatabase.AddInParameter(oDbCommand, "@DNI", DbType.String, oEmpleado.DNI)
        oDatabase.AddInParameter(oDbCommand, "@Nombres", DbType.String, oEmpleado.Nombres)
        oDatabase.AddInParameter(oDbCommand, "@Apellidos", DbType.String, oEmpleado.Apellidos)
        oDatabase.AddInParameter(oDbCommand, "@NombresApellidos", DbType.String, oEmpleado.Apellidos + " " + oEmpleado.Nombres)
        oDatabase.AddInParameter(oDbCommand, "@FechaNacimiento", DbType.Date, oEmpleado.FechaNacimiento)
        oDatabase.AddInParameter(oDbCommand, "@FechaContrato", DbType.Date, oEmpleado.FechaContrato)
        oDatabase.AddInParameter(oDbCommand, "@Telefono", DbType.String, oEmpleado.Telefono)
        oDatabase.AddInParameter(oDbCommand, "@Email", DbType.String, oEmpleado.Email)
        oDatabase.AddInParameter(oDbCommand, "@Direccion", DbType.String, oEmpleado.Direccion)
        oDatabase.AddInParameter(oDbCommand, "@Celular1", DbType.String, oEmpleado.Celular1)
        oDatabase.AddInParameter(oDbCommand, "@Celular2", DbType.String, oEmpleado.Celular2)
        oDatabase.AddInParameter(oDbCommand, "@IdEmpleado", DbType.Int32, 10)
        oDatabase.AddInParameter(oDbCommand, "@PlanVenta", DbType.Decimal, oEmpleado.PlanVenta)
        oDatabase.AddInParameter(oDbCommand, "@IngresoBasicoMensual", DbType.Decimal, oEmpleado.IngresoBasicoMensual)
        oDatabase.AddInParameter(oDbCommand, "@UsuarioUsu", DbType.String, oEmpleado.UsuarioIngreso)
        oDatabase.AddInParameter(oDbCommand, "@Usuario", DbType.String, oEmpleado.UsuarioRegistro)
        oDatabase.AddInParameter(oDbCommand, "@Origen", DbType.String, oEmpleado.OrigenRegistro)
        result = oDatabase.ExecuteScalar(oDbCommand)

        Return result

    End Function

    Function ListaZonas() As ListaZona
        Dim oListaZona As New ListaZona()
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_LISTA_ZONA)

        oDbCommand.CommandTimeout = 12000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim oEmpleadoCargo As New EmpleadoCargo()
            Dim oZona As New Zona()

            Dim idzona As Integer = oIDataReader.GetOrdinal("IdZona")
            Dim descripcion As Integer = oIDataReader.GetOrdinal("Descripcion")
            While oIDataReader.Read()
                oZona = New Zona()
                oZona.IdZona = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(idzona))
                oZona.Descripcion = DataUtil.DbValueToDefault(Of String)(oIDataReader(descripcion))
                oListaZona.Add(oZona)
            End While
        End Using
        Return oListaZona
    End Function

    Function ListaSucursal() As ListaSucursal
        Dim oListaSucursal As New ListaSucursal()
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_LISTA_SUCURSAL)

        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim oEmpleadoCargo As New EmpleadoCargo()
            Dim oSucursal As New Sucursal()


            Dim idsucursal As Integer = oIDataReader.GetOrdinal("IdSucursal")
            Dim descripcion As Integer = oIDataReader.GetOrdinal("Descripcion")
            Dim codigosucursal As Integer = oIDataReader.GetOrdinal("CodigoSucursal")
            While oIDataReader.Read()
                oSucursal = New Sucursal()
                oSucursal.IdSucursal = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(idsucursal))
                oSucursal.DescripcionSucursal = DataUtil.DbValueToDefault(Of String)(oIDataReader(descripcion))
                oSucursal.CodigoSucursal = DataUtil.DbValueToDefault(Of String)(oIDataReader(codigosucursal))
                oListaSucursal.Add(oSucursal)
            End While
        End Using
        Return oListaSucursal
    End Function

    Function ObtenerSucursalEmpleadoPorId(IdEmpleado As Integer) As SucursalEmpleado
        Dim oSucursalEmpleado As New SucursalEmpleado()
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_SUCURSALEMPLEADO_BY_ID, IdEmpleado)
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim indiceIdEmpleado As Integer = oIDataReader.GetOrdinal("IdEmpleado")
            Dim indiceNombreSucursal As Integer = oIDataReader.GetOrdinal("NombreSucursal")
            Dim indiceNombrePerfil As Integer = oIDataReader.GetOrdinal("NombrePerfil")
            Dim indiceNombreCargo As Integer = oIDataReader.GetOrdinal("NombreCargo")
            Dim indiceZona As Integer = oIDataReader.GetOrdinal("Zona")
            'Dim indiceNombrePerfilSuperior As Integer = oIDataReader.GetOrdinal("NombrePerfilSuperior")
            Dim indiceNombreCargoSuperior As Integer = oIDataReader.GetOrdinal("NombreCargoSuperior")
            Dim indiceNombreApellidos As Integer = oIDataReader.GetOrdinal("NombresApellidos")
            Dim indicePlanVentaGeneral As Integer = oIDataReader.GetOrdinal("PlanVenta")
            Dim indiceTiempoServicio As Integer = oIDataReader.GetOrdinal("TiempoServicio")

            While oIDataReader.Read()
                oSucursalEmpleado.Empleado = New Empleado()
                oSucursalEmpleado.Empleado.IdEmpleado = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indiceIdEmpleado))
                oSucursalEmpleado.Sucursal = New Sucursal()
                oSucursalEmpleado.Sucursal.Descripcion = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceNombreSucursal))
                oSucursalEmpleado.Perfil = New Perfil()
                oSucursalEmpleado.Perfil.NombrePerfil = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceNombrePerfil))
                oSucursalEmpleado.Cargo = New Cargo()
                oSucursalEmpleado.Cargo.NombreCargo = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceNombreCargo))
                oSucursalEmpleado.ZonaMantenimiento = New ZonaMantenimiento()
                oSucursalEmpleado.ZonaMantenimiento.NombreZona = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceZona))
                oSucursalEmpleado.Cargo.NombreCargoSuperior = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceNombreCargoSuperior))
                oSucursalEmpleado.Empleado.NombresApellidos = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceNombreApellidos))
                ''oSucursalEmpleado.ComisionEscala = New ComisionEscala()
                ''oSucursalEmpleado.ComisionEscala.PlanVenta = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(indicePlanVentaGeneral))
                oSucursalEmpleado.ComisionEscalaTiempoServicio = New ComisionEscalaTiempoServicio()
                oSucursalEmpleado.ComisionEscalaTiempoServicio.PlanVenta = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(indicePlanVentaGeneral))
                oSucursalEmpleado.ComisionEscalaTiempoServicio.TiempoServicio = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indiceTiempoServicio))


            End While
        End Using
        Return oSucursalEmpleado
    End Function

    Function ObtenerSucursalEmpleadoPorIdV2(IdEmpleado As Integer) As SucursalEmpleado
        Dim oSucursalEmpleado As New SucursalEmpleado()
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_SUCURSALEMPLEADO_BY_IDV2, IdEmpleado)
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim indiceIdEmpleado As Integer = oIDataReader.GetOrdinal("IdEmpleado")
            Dim indiceNombreSucursal As Integer = oIDataReader.GetOrdinal("NombreSucursal")
            Dim indiceNombrePerfil As Integer = oIDataReader.GetOrdinal("NombrePerfil")
            Dim indiceNombreCargo As Integer = oIDataReader.GetOrdinal("NombreCargo")
            Dim indiceZona As Integer = oIDataReader.GetOrdinal("Zona")
            'Dim indiceNombrePerfilSuperior As Integer = oIDataReader.GetOrdinal("NombrePerfilSuperior")
            Dim indiceNombreCargoSuperior As Integer = oIDataReader.GetOrdinal("NombreCargoSuperior")
            Dim indiceNombreApellidos As Integer = oIDataReader.GetOrdinal("NombresApellidos")
            Dim indicePlanVentaGeneral As Integer = oIDataReader.GetOrdinal("PlanVenta")
            Dim indiceTiempoServicio As Integer = oIDataReader.GetOrdinal("TiempoServicio")

            While oIDataReader.Read()
                oSucursalEmpleado.Empleado = New Empleado()
                oSucursalEmpleado.Empleado.IdEmpleado = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indiceIdEmpleado))
                oSucursalEmpleado.Sucursal = New Sucursal()
                oSucursalEmpleado.Sucursal.Descripcion = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceNombreSucursal))
                oSucursalEmpleado.Perfil = New Perfil()
                oSucursalEmpleado.Perfil.NombrePerfil = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceNombrePerfil))
                oSucursalEmpleado.Cargo = New Cargo()
                oSucursalEmpleado.Cargo.NombreCargo = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceNombreCargo))
                oSucursalEmpleado.ZonaMantenimiento = New ZonaMantenimiento()
                oSucursalEmpleado.ZonaMantenimiento.NombreZona = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceZona))
                oSucursalEmpleado.Cargo.NombreCargoSuperior = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceNombreCargoSuperior))
                oSucursalEmpleado.Empleado.NombresApellidos = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceNombreApellidos))
                ''oSucursalEmpleado.ComisionEscala = New ComisionEscala()
                ''oSucursalEmpleado.ComisionEscala.PlanVenta = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(indicePlanVentaGeneral))
                oSucursalEmpleado.ComisionEscalaTiempoServicio = New ComisionEscalaTiempoServicio()
                oSucursalEmpleado.ComisionEscalaTiempoServicio.PlanVenta = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(indicePlanVentaGeneral))
                oSucursalEmpleado.ComisionEscalaTiempoServicio.TiempoServicio = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indiceTiempoServicio))


            End While
        End Using
        Return oSucursalEmpleado
    End Function

    Function ObtenerPerfilEmpleado(IdEmpleado As Integer, TipoPerfil As Integer) As Empleado
        Dim oEmpleado As New Empleado()

        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_OBTENEREMPLEADOTIPO, IdEmpleado, TipoPerfil)

        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim indiceTipoPerfil As Integer = oIDataReader.GetOrdinal("TipoPerfil")
            While oIDataReader.Read()
                oEmpleado.Perfil = New Perfil()
                oEmpleado.Perfil.TipoPerfil = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indiceTipoPerfil))
            End While
        End Using
        Return oEmpleado
    End Function

    Function ObtenerEmpleadoPorId(IdEmpleado As Integer, tipoperfil As Integer) As Empleado
        Dim oEmpleado As New Empleado()

        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_EMPLEADO_BY_ID, IdEmpleado, tipoperfil)

        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)

            Dim indiceIdEmpleado As Integer = oIDataReader.GetOrdinal("IdEmpleado")
            Dim indiceCodigoOfisis As Integer = oIDataReader.GetOrdinal("CodigoOfisis")
            Dim indiceDNI As Integer = oIDataReader.GetOrdinal("DNI")
            Dim indiceNombres As Integer = oIDataReader.GetOrdinal("Nombres")
            Dim indiceApellidos As Integer = oIDataReader.GetOrdinal("Apellidos")
            Dim indiceNombresApellidos As Integer = oIDataReader.GetOrdinal("NombresApellidos")
            Dim indiceFechaNacimiento As Integer = oIDataReader.GetOrdinal("FechaNacimiento")
            Dim indiceFechaContrato As Integer = oIDataReader.GetOrdinal("FechaContrato")
            Dim indiceTelefono As Integer = oIDataReader.GetOrdinal("Telefono")
            Dim indiceEmail As Integer = oIDataReader.GetOrdinal("Email")
            Dim indiceDireccion As Integer = oIDataReader.GetOrdinal("Direccion")
            Dim indiceActivo As Integer = oIDataReader.GetOrdinal("Activo")
            Dim indiceCelular1 As Integer = oIDataReader.GetOrdinal("Celular1")
            Dim indiceCelular2 As Integer = oIDataReader.GetOrdinal("Celular2")
            Dim indicePlan As Integer = oIDataReader.GetOrdinal("PlanVenta")
            Dim indiceIngresoBasico As Integer = oIDataReader.GetOrdinal("IngresoBasicoMensual")
            Dim indiceTipoPerfil As Integer = oIDataReader.GetOrdinal("TipoPerfil")
            Dim indiceFechaSucursalUltimo As Integer = oIDataReader.GetOrdinal("FechaSucursalUltimo")
            Dim indiceUsuarioUsu As Integer = oIDataReader.GetOrdinal("UsuarioUsu")

            While oIDataReader.Read()

                oEmpleado.IdEmpleado = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indiceIdEmpleado))
                oEmpleado.CodigoOfisis = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceCodigoOfisis))
                oEmpleado.DNI = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceDNI))
                oEmpleado.Nombres = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceNombres))
                oEmpleado.Apellidos = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceApellidos))
                oEmpleado.NombresApellidos = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceNombresApellidos))
                oEmpleado.FechaNacimiento = DataUtil.DbValueToDefault(Of Date)(oIDataReader(indiceFechaNacimiento))
                oEmpleado.FechaContrato = DataUtil.DbValueToDefault(Of Date)(oIDataReader(indiceFechaContrato))
                oEmpleado.Telefono = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceTelefono))
                oEmpleado.Email = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceEmail))
                oEmpleado.Direccion = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceDireccion))
                oEmpleado.Activo = DataUtil.DbValueToDefault(Of Boolean)(oIDataReader(indiceActivo))
                oEmpleado.Celular1 = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceCelular1))
                oEmpleado.Celular2 = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceCelular2))
                oEmpleado.PlanVenta = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(indicePlan))
                oEmpleado.IngresoBasicoMensual = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(indiceIngresoBasico))
                oEmpleado.Perfil = New Perfil()
                oEmpleado.Perfil.TipoPerfil = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indiceTipoPerfil))
                oEmpleado.FechaSucursalUltimo = DataUtil.DbValueToDefault(Of Date)(oIDataReader(indiceFechaSucursalUltimo))
                oEmpleado.UsuarioIngreso = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceUsuarioUsu))
            End While
        End Using

        Return oEmpleado
    End Function

    Function ObtenerSucursalPorIdEmpleados(ByRef oPaginacion As Paginacion) As Paginacion
        Dim ListaSucursalEmpleado As New List(Of SucursalEmpleado)
        Dim oSucursalEmpleado As New SucursalEmpleado

        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_SUCURSAL_BY_IDEMPLEADO)
        oDatabase.AddInParameter(oDbCommand, "@IdEmpleado", DbType.Int32, oPaginacion.Empleado.IdEmpleado)
        oDatabase.AddInParameter(oDbCommand, "@PageSize", DbType.Int32, oPaginacion.PageSize)
        oDatabase.AddInParameter(oDbCommand, "@PageNumber", DbType.Int32, oPaginacion.PageNumber)
        oDatabase.AddInParameter(oDbCommand, "@SortBy", DbType.String, oPaginacion.SortBy)
        oDatabase.AddInParameter(oDbCommand, "@SortType", DbType.String, oPaginacion.SortType)
        oDatabase.AddOutParameter(oDbCommand, "@TotalRows", DbType.Int32, 10)
        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim indiceNombreCompleto As Integer = oIDataReader.GetOrdinal("NombresApellidos")
            Dim indiceNombrePerfil As Integer = oIDataReader.GetOrdinal("NombrePerfil")
            Dim indiceZona As Integer = oIDataReader.GetOrdinal("Zona")
            Dim indiceSucursal As Integer = oIDataReader.GetOrdinal("Sucursal")
            Dim indiceReporta As Integer = oIDataReader.GetOrdinal("REPORTA")
            Dim indiceEscalaTiempoAsignado As Integer = oIDataReader.GetOrdinal("TiempoServicio")
            Dim indiceFechaRegistro As Integer = oIDataReader.GetOrdinal("FechaRegistro")
            Dim indiceFechaSalida As Integer = oIDataReader.GetOrdinal("FechaSalida")
            Dim indiceVigente As Integer = oIDataReader.GetOrdinal("VIGENTE")
            Dim indiceActivo As Integer = oIDataReader.GetOrdinal("Activo")

            While oIDataReader.Read()
                oPaginacion.SucursalEmpleado = New SucursalEmpleado()
                oPaginacion.SucursalEmpleado.Empleado = New Empleado()
                oPaginacion.SucursalEmpleado.Empleado.NombresApellidos = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceNombreCompleto))
                oPaginacion.SucursalEmpleado.Empleado.Activo = DataUtil.DbValueToDefault(Of Boolean)(oIDataReader(indiceVigente))
                oPaginacion.SucursalEmpleado.EscalaTiempoAsignado = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indiceEscalaTiempoAsignado))
                oPaginacion.SucursalEmpleado.Sucursal = New Sucursal() With {.DescripcionSucursal = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceSucursal))}
                oPaginacion.SucursalEmpleado.Zona = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceZona))
                oPaginacion.SucursalEmpleado.ComisionEscalaTiempoServicio = New ComisionEscalaTiempoServicio()
                oPaginacion.SucursalEmpleado.Perfil = New Perfil()
                oPaginacion.SucursalEmpleado.Perfil.NombrePerfil = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceNombrePerfil))
                oPaginacion.SucursalEmpleado.Reporta = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceReporta))
                oPaginacion.SucursalEmpleado.FechaRegistro = DataUtil.DbValueToDefault(Of Date)(oIDataReader(indiceFechaRegistro))
                oPaginacion.SucursalEmpleado.FechaSalida = DataUtil.DbValueToDefault(Of Date)(oIDataReader(indiceFechaSalida))
                oPaginacion.SucursalEmpleado.Activo = Convert.ToInt32(DataUtil.DbValueToDefault(Of Boolean)(oIDataReader(indiceActivo)))
                oPaginacion.ListaSucursalEmpleado.Add(oPaginacion.SucursalEmpleado)
            End While
        End Using
        oPaginacion.TotalRows = Convert.ToInt32(oDatabase.GetParameterValue(oDbCommand, "@TotalRows"))
        Return oPaginacion
    End Function

    Function RegistrarSucursalEmpleado(sucursalEmpleado As Empleado) As String
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_INS_SUCURSALEMPLEADO)

        Dim result As Integer = 0

        'basic register
        oDatabase.AddInParameter(oDbCommand, "@IdSucursal", DbType.Int32, sucursalEmpleado.Sucursal.IdSucursal)
        oDatabase.AddInParameter(oDbCommand, "@IdEmpleado", DbType.Int32, sucursalEmpleado.IdEmpleado)
        oDatabase.AddInParameter(oDbCommand, "@IdEmpleadoPerfil", DbType.Int32, sucursalEmpleado.Perfil.IdPerfil)
        oDatabase.AddInParameter(oDbCommand, "@IdEmpleadoTipoRepVen", DbType.Int32, sucursalEmpleado.TipoRepresentanteVenta.IdTipoRepVen)
        oDatabase.AddInParameter(oDbCommand, "@IdEmpleadoCargo", DbType.Int32, sucursalEmpleado.Cargo.IdCargo)
        oDatabase.AddInParameter(oDbCommand, "@IdZona", DbType.Int32, sucursalEmpleado.Zona.IdZona)
        oDatabase.AddInParameter(oDbCommand, "@EscalaTiempoInicial", DbType.Int32, sucursalEmpleado.SucursalEmpleado.EscalaTiempoAsignado)
        oDatabase.AddInParameter(oDbCommand, "@FechaIngresoSucursal", DbType.Date, sucursalEmpleado.SucursalEmpleado.FechaRegistro)
        oDatabase.AddInParameter(oDbCommand, "@IdCargoSupervisor", DbType.Int32, sucursalEmpleado.Cargo.IdCargoSuperior)
        oDatabase.AddInParameter(oDbCommand, "@ReportarA", DbType.String, sucursalEmpleado.Reportar)
        result = oDatabase.ExecuteScalar(oDbCommand)

        Return result
    End Function

    Function RegistrarPlanVentasEmpleado(planventaEmpleado As Empleado) As String
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_INS_PLANVENTAEMPLEADO)
        Dim result As Integer = -1
        oDatabase.AddInParameter(oDbCommand, "@IdPlanVentaEmpleado", DbType.Int32, planventaEmpleado.PlanVentaEmpleado.IdPlanVentaEmpleado)
        oDatabase.AddInParameter(oDbCommand, "@IdEmpleado", DbType.Int32, planventaEmpleado.IdEmpleado)
        oDatabase.AddInParameter(oDbCommand, "@PlanVentaBase", DbType.Decimal, planventaEmpleado.PlanVentaEmpleado.PlanVentaBase)
        oDatabase.AddInParameter(oDbCommand, "@IngresoBasicoMensual", DbType.Decimal, planventaEmpleado.PlanVentaEmpleado.IngresoBasicoMensual)
        'oDatabase.AddInParameter(oDbCommand, "@FechaActivacion", DbType.DateTime, planventaEmpleado.PlanVentaEmpleado.FechaActivacion)
        oDatabase.AddInParameter(oDbCommand, "@TiempoServicio", DbType.Int32, planventaEmpleado.PlanVentaEmpleado.comboTiempoServicio)

        'result = oDatabase.ExecuteNonQuery(oDbCommand)
        result = Integer.Parse(oDatabase.ExecuteScalar(oDbCommand))
        Return result

    End Function

    Function ObtenerPlanVentaPorIdEmpleado(ByRef oPaginacion As Paginacion) As Paginacion

        Dim oListaPlanVentaEmpleado As New ListaPlanVentaEmpleado

        Dim oPlanVentaEmpleado As New PlanVentaEmpleado


        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_PLANVENTAEMPLEADO_BY_ID)
        oDatabase.AddInParameter(oDbCommand, "@IdEmpleado", DbType.Int32, oPaginacion.Empleado.IdEmpleado)
        oDatabase.AddInParameter(oDbCommand, "@PageSize", DbType.Int32, oPaginacion.PageSize)
        oDatabase.AddInParameter(oDbCommand, "@PageNumber", DbType.Int32, oPaginacion.PageNumber)
        oDatabase.AddInParameter(oDbCommand, "@SortBy", DbType.String, oPaginacion.SortBy)
        oDatabase.AddInParameter(oDbCommand, "@SortType", DbType.String, oPaginacion.SortType)
        oDatabase.AddOutParameter(oDbCommand, "@TotalRows", DbType.Int32, 10)
        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)

            Dim indicePeriodo As Integer = oIDataReader.GetOrdinal("Periodo")
            Dim indiceFechaPeriodo As Integer = oIDataReader.GetOrdinal("FechaPeriodo")
            Dim indiceTiempoServicio As Integer = oIDataReader.GetOrdinal("TiempoServicio")
            Dim indicePlanVenta As Integer = oIDataReader.GetOrdinal("PlanVenta")
            Dim indiceNombreCargo As Integer = oIDataReader.GetOrdinal("NombreCargo")
            Dim indiceNuevoplanventa As Integer = oIDataReader.GetOrdinal("Nuevoplanventa")
            Dim indiceTiempoPlan As Integer = oIDataReader.GetOrdinal("TiempoEmpleado")
            Dim indiceFechaRegistro As Integer = oIDataReader.GetOrdinal("FechaRegistro")
            Dim IndiceVIGENTE As Integer = oIDataReader.GetOrdinal("Vigente")
            Dim indiceACTIVO As Integer = oIDataReader.GetOrdinal("ACTIVO")


            While oIDataReader.Read()
                oPaginacion.PlanVentaEmpleado = New PlanVentaEmpleado()
                oPaginacion.PlanVentaEmpleado.ComisionPeriodo = New ComisionPeriodo()
                oPaginacion.PlanVentaEmpleado.ComisionPeriodo.NombrePeriodo = DataUtil.DbValueToDefault(Of String)(oIDataReader(indicePeriodo))
                oPaginacion.PlanVentaEmpleado.ComisionPeriodo.FechaPeriodo = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceFechaPeriodo))
                'oPaginacion.PlanVentaEmpleado.ComisionEscala = new  
                'oPaginacion.PlanVentaEmpleado.ComisionEscalaTiempoServicio = New ComisionEscalaTiempoServicio()
                'oPaginacion.PlanVentaEmpleado.ComisionEscalaTiempoServicio.TiempoServicio = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indiceTiempoServicio))
                oPaginacion.PlanVentaEmpleado.ComisionEscala = New ComisionEscala()
                oPaginacion.PlanVentaEmpleado.ComisionEscala.PlanVenta = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(indicePlanVenta))
                oPaginacion.PlanVentaEmpleado.ComisionEscala.TiempoServicio = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indiceTiempoServicio))
                oPaginacion.PlanVentaEmpleado.Cargo = New Cargo() With {.NombreCargo = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceNombreCargo))}
                oPaginacion.PlanVentaEmpleado.PlanVentaBase = DataUtil.DbValueToDefault(Of Decimal)(oIDataReader(indiceNuevoplanventa))
                'oPaginacion.PlanVentaEmpleado.TiempoServicio = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceTiempoPlan))
                oPaginacion.PlanVentaEmpleado.DescripcionMes = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceTiempoPlan))
                oPaginacion.PlanVentaEmpleado.FechaActivacion = DataUtil.DbValueToDefault(Of Date)(oIDataReader(indiceFechaRegistro))
                oPaginacion.PlanVentaEmpleado.Activo = DataUtil.DbValueToDefault(Of Boolean)(oIDataReader(indiceACTIVO))
                oPaginacion.PlanVentaEmpleado.Empleado = New Empleado
                oPaginacion.PlanVentaEmpleado.Empleado.Activo = DataUtil.DbValueToDefault(Of Boolean)(oIDataReader(IndiceVIGENTE))
                oPaginacion.ListaPlanVentaEmpleado.Add(oPaginacion.PlanVentaEmpleado)
            End While
        End Using
        oPaginacion.TotalRows = Convert.ToInt32(oDatabase.GetParameterValue(oDbCommand, "@TotalRows"))
        Return oPaginacion
    End Function

    Function DesactivarEmpleado(IdEmpleado As Integer) As Integer

        Dim result As Integer = 0

        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_DESACTIVAR_EMPLEADO, IdEmpleado)

        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)

            Dim resultindice As Integer = oIDataReader.GetOrdinal("Activo")
            While oIDataReader.Read()
                result = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(resultindice))
            End While
        End Using

        Return result
    End Function
    'AGREGADO

    Function DesactivarEmpleadoporEstado(IdEmpleado As Integer, IdEstado As Integer, Usuario As String, Origen As String) As Integer
        Dim result As Integer = -1

        ''Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_DESACTIVAR_EMPLEADO, IdEmpleado, IdEstado)
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_DESACTIVAR_EMPLEADO)
        oDatabase.AddInParameter(oDbCommand, "@IdEmpleado", DbType.Int32, IdEmpleado)
        oDatabase.AddInParameter(oDbCommand, "@IdEstado", DbType.Int32, IdEstado)
        oDatabase.AddInParameter(oDbCommand, "@Usuario", DbType.String, Usuario)
        oDatabase.AddInParameter(oDbCommand, "@Origen", DbType.String, Origen)
        'oDbCommand.CommandTimeout = 9999
        result = Integer.Parse(oDatabase.ExecuteScalar(oDbCommand))
        Return result
    End Function

    Function ObtenerTiempoServicio() As Integer
        Dim result As Integer = 0

        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_ESCALATIEMPO)

        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)

            Dim resultindice As Integer = oIDataReader.GetOrdinal("TiempoEscala")
            While oIDataReader.Read()
                result = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(resultindice))
            End While
        End Using

        Return result
    End Function

    Public Function ListarCargosPorPerfil(ByRef IdEmpleadoPerfil As Integer) As ListaEmpleadoCargo
        Dim oEmpleadoCargo As EmpleadoCargo
        Dim oListaEmpleadoCargo As New ListaEmpleadoCargo

        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_EMPLEADOCARGO_PORIDEMPLEADOPERFIL)
        oDatabase.AddInParameter(oDbCommand, "@IdEmpleadoPerfil", DbType.Int32, IdEmpleadoPerfil)

        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)

            Dim indiceIdEmpleadoCargo As Integer = oIDataReader.GetOrdinal("IdEmpleadoCargo")
            Dim indiceDescripcion As Integer = oIDataReader.GetOrdinal("Descripcion")
            Dim indiceEstado As Integer = oIDataReader.GetOrdinal("Estado")
            Dim indiceIdPerfil As Integer = oIDataReader.GetOrdinal("IdPerfil")

            While oIDataReader.Read()
                oEmpleadoCargo = New EmpleadoCargo()
                oEmpleadoCargo.IdEmpleadoCargo = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indiceIdEmpleadoCargo))
                oEmpleadoCargo.DescripcionCargo = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceDescripcion))
                oEmpleadoCargo.Estado = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indiceEstado))
                oEmpleadoCargo.EmpleadoPerfil = New EmpleadoPerfil()
                oEmpleadoCargo.EmpleadoPerfil.IdPerfil = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indiceIdPerfil))
                oListaEmpleadoCargo.Add(oEmpleadoCargo)
            End While
        End Using

        Return oListaEmpleadoCargo
    End Function

    Function Seleccion_tipoPerfilCargo(idcargos As Integer) As Integer
        Dim result As Integer = -1
        'Dim oListaCargos As New ListaCargo()
        Dim oDbComand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_TIPO_PERFILCARGO)
        oDatabase.AddInParameter(oDbComand, "@idtipoPerfil", DbType.Int32, idcargos)
        result = oDatabase.ExecuteScalar(oDbComand)
        Return result
    End Function

    Function ObtenerTipoPerfilVendedor(IdPerfil As Integer, IdZona As Integer) As Integer
        Dim result As Integer = -1
        'Dim oListaCargos As New ListaCargo()
        Dim oDbComand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_OBTENER_TIPO_PERFILVENDEDOR)
        oDatabase.AddInParameter(oDbComand, "@IdPerfil", DbType.Int32, IdPerfil)
        oDatabase.AddInParameter(oDbComand, "@IDZONA", DbType.Int32, IdZona)
        result = oDatabase.ExecuteScalar(oDbComand)
        Return result
    End Function

    Function Selecion_PerfilNombre(idperfil As Integer) As String
        Dim result As String = ""
        Dim oDbComand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_MOTRARNOMBREXPERFIL)
        oDatabase.AddInParameter(oDbComand, "@IDPERFIL", DbType.Int32, idperfil)


        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbComand)
            Dim indNombreReporta As Integer = oIDataReader.GetOrdinal("REPORTA")
            While oIDataReader.Read()
                result = DataUtil.DbValueToDefault(Of String)(oIDataReader(indNombreReporta))
            End While
        End Using
        Return result
    End Function

    Function CargarEscalas_Tiempo_Servicio(ByVal idcargos As Integer) As ListaComisionEscalaDetalle
        Dim oListaEscalaTiempoDetalle As New ListaComisionEscalaDetalle()
        Dim oDbComand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_CARGAR_ESCALAS)
        oDatabase.AddInParameter(oDbComand, "@IDCARGO", DbType.Int32, idcargos)
        oListaEscalaTiempoDetalle = New ListaComisionEscalaDetalle
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbComand)
            Dim indiIdEscalaDetalle As Integer = oIDataReader.GetOrdinal("IdSucursal")
            'Dim indiDescripcion As Integer = oIDataReader.GetOrdinal("Descripcion")
            Dim oComisionDetalle = New ComisionEscalaDetalle
            While oIDataReader.Read()
                oComisionDetalle = New ComisionEscalaDetalle()
                oComisionDetalle.IdComisionEscala = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indiIdEscalaDetalle))
                'oComisionDetalle.DescripcionSucursal = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiDescripcion))
                oListaEscalaTiempoDetalle.Add(oComisionDetalle)
            End While
        End Using
        Return oListaEscalaTiempoDetalle
    End Function

    Function CargarPerfiles() As ListaPerfil
        Dim oListaPerfil As New ListaPerfil()
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_LISTAPERFILVENTAS)
        'oDbCommand.CommandTimeout = 120000
        ' oListaPerfil = New ListaPerfil
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim indIdperfil As Integer = oIDataReader.GetOrdinal("IdPerfil")
            Dim indNombreperfil As Integer = oIDataReader.GetOrdinal("NombrePerfil")
            Dim oPerfil = New Perfil
            While oIDataReader.Read()
                oPerfil = New Perfil()
                oPerfil.IdPerfil = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indIdperfil))
                oPerfil.NombrePerfil = DataUtil.DbValueToDefault(Of String)(oIDataReader(indNombreperfil))
                oListaPerfil.Add(oPerfil)
            End While
        End Using
        Return oListaPerfil
    End Function

    Function CargarListaCargoxPerfil(IdPerfil As Integer) As ListaCargo
        Dim oListaCargo As New ListaCargo()
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_LISTACARGOXPERFIL)
        oDatabase.AddInParameter(oDbCommand, "@idperfil", DbType.Int32, IdPerfil)
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim indIdcargo As Integer = oIDataReader.GetOrdinal("IdCargo")
            Dim indNombre As Integer = oIDataReader.GetOrdinal("NombreCargo")
            Dim oCargo = New Cargo
            While oIDataReader.Read()
                oCargo = New Cargo()
                oCargo.IdCargo = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indIdcargo))
                oCargo.NombreCargo = DataUtil.DbValueToDefault(Of String)(oIDataReader(indNombre))
                oListaCargo.Add(oCargo)
            End While
            Return oListaCargo
        End Using
    End Function

    ' Function CargarEstado() As ListaProcesoEstado
    Function CargarEstado() As ListaEstado
        Dim oListaEstado As New ListaEstado()
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_LISTAESTADO)
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim indice_Idestado As Integer = oIDataReader.GetOrdinal("IdEstado")
            Dim indice_Descripcion As Integer = oIDataReader.GetOrdinal("Descripcion")
            'Dim oProcesoEstado = New ProcesoEstado
            Dim oProcesoEstado = New Estado
            While oIDataReader.Read()
                'oProcesoEstado = New ProcesoEstado()
                oProcesoEstado = New Estado()
                oProcesoEstado.IdEstado = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indice_Idestado))
                oProcesoEstado.Descripcion = DataUtil.DbValueToDefault(Of String)(oIDataReader(indice_Descripcion))
                oListaEstado.Add(oProcesoEstado)
            End While
        End Using
        Return oListaEstado

    End Function

    Function ObtenerEscalasPeriodo(ByVal idempleado As Integer) As ListaPlanVentaEmpleado
        Dim oListaPlanVentaEmpleado As New ListaPlanVentaEmpleado()
        'Dim escalas As Integer = 12
        Dim oDbComand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_LISTADINAMICAESCALAS)
        oDatabase.AddInParameter(oDbComand, "@IdEmpleado", DbType.Int32, idempleado)
        oListaPlanVentaEmpleado = New ListaPlanVentaEmpleado
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbComand)
            Dim indTiempoServicio As Integer = oIDataReader.GetOrdinal("TiempoServicio")
            Dim indCantidadEscalas As Integer = oIDataReader.GetOrdinal("Escalas")
            Dim oplanventaempleado = New PlanVentaEmpleado
            While oIDataReader.Read()
                Dim a As Integer = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indTiempoServicio))
                'Dim cantidades As Integer = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indCantidadEscalas))
                For i As Integer = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indCantidadEscalas)) To 12
                    If i > 0 Then
                        oplanventaempleado = New PlanVentaEmpleado()

                        oplanventaempleado.comboTiempoServicio = a + i
                    End If
                    oListaPlanVentaEmpleado.Add(oplanventaempleado)
                Next
            End While
        End Using
        Return oListaPlanVentaEmpleado
    End Function

    Function ObtenerTiempoServicioPeriodo(ByVal IdEmpleado As Integer) As ListaPlanVentaEmpleado
        Dim oListaPlanVentaEmpleado As New ListaPlanVentaEmpleado()
        Dim oDbComand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_OBTENERESCALASPERIODOTIEMPO)
        oDatabase.AddInParameter(oDbComand, "@IdEmpleado", DbType.Int32, IdEmpleado)
        oListaPlanVentaEmpleado = New ListaPlanVentaEmpleado
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbComand)
            Dim INDICETIEMPOSERVICIO As Integer = oIDataReader.GetOrdinal("TiempoServicio")
            Dim INDICECANTIDADESCALAS As Integer = oIDataReader.GetOrdinal("Escalas")
            Dim INDICETIEMPOSERVICIIOESCALAS As Integer = oIDataReader.GetOrdinal("TiempoServicioEscalas")
            Dim oplanventaempleado = New PlanVentaEmpleado
            While oIDataReader.Read()
                Dim tiempo As Integer = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICETIEMPOSERVICIO))
                Dim MesesTotal As Int32 = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICETIEMPOSERVICIIOESCALAS))
                For i As Integer = tiempo To MesesTotal
                    If i > tiempo Then
                        oplanventaempleado = New PlanVentaEmpleado()
                        oplanventaempleado.comboTiempoServicio = i
                    End If
                    oListaPlanVentaEmpleado.Add(oplanventaempleado)
                Next
            End While
        End Using
        Return oListaPlanVentaEmpleado

    End Function

    Function ObtenerMesesComisonalesFaltantes() As ListaComisionPeriodoDetalle
        Dim oListaComisionPeriodoDetalle As New ListaComisionPeriodoDetalle
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_OBTENER_MESESCOMISIONALESFALTANTES)
        oListaComisionPeriodoDetalle = New ListaComisionPeriodoDetalle
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_IdPeriodoDetalle As Integer = oIDataReader.GetOrdinal("IdPeriodoDetalle")
            Dim INDICE_DescripcionMeses As Integer = oIDataReader.GetOrdinal("DescripcionMeses")

            Dim oComisionPeriodoDetalle = New ComisionPeriodoDetalle
            While oIDataReader.Read()
                oComisionPeriodoDetalle = New ComisionPeriodoDetalle()

                oComisionPeriodoDetalle.IdPeriodoDetalle = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_IdPeriodoDetalle))
                oComisionPeriodoDetalle.Descripcion = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_DescripcionMeses))
                oListaComisionPeriodoDetalle.Add(oComisionPeriodoDetalle)
            End While

        End Using
        Return oListaComisionPeriodoDetalle

    End Function

    Function ObtenerTiempoServicioporEmpleado(ByVal IdEmpleado As Integer) As ListaPlanVentaEmpleado
        Dim oListaPlanVentaEmpleado As New ListaPlanVentaEmpleado()
        Dim oDbComand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_OBTENERESCALASTIEMPOSERVICIOEMPLEADO)
        oDatabase.AddInParameter(oDbComand, "@IdEmpleado", DbType.Int32, IdEmpleado)
        oListaPlanVentaEmpleado = New ListaPlanVentaEmpleado
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbComand)
            Dim INDICE_TiempoServicioActual As Integer = oIDataReader.GetOrdinal("TiempoServicioActual")
            Dim INDICE_CantEscalas As Integer = oIDataReader.GetOrdinal("CantEscalas")
            Dim INDICE_TiempoServicioTope As Integer = oIDataReader.GetOrdinal("TiempoServicioEscalas")

            Dim oplanventaempleado = New PlanVentaEmpleado
            While oIDataReader.Read()
                Dim TiempoServicio_Actual As Integer = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_TiempoServicioActual))
                Dim INDICE_CantEscalas_ As Integer = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_CantEscalas))
                Dim INDICE_TiempoServicioTope_ As Integer = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_TiempoServicioTope))

                If INDICE_TiempoServicioTope_ >= TiempoServicio_Actual Then
                    If TiempoServicio_Actual > INDICE_CantEscalas_ Then
                        oplanventaempleado = New PlanVentaEmpleado()
                        oplanventaempleado.comboTiempoServicio = INDICE_CantEscalas_
                        oListaPlanVentaEmpleado.Add(oplanventaempleado)
                    Else
                        For id As Integer = TiempoServicio_Actual To INDICE_CantEscalas_
                            oplanventaempleado = New PlanVentaEmpleado()
                            oplanventaempleado.comboTiempoServicio = id
                            oListaPlanVentaEmpleado.Add(oplanventaempleado)
                        Next
                    End If
                End If


                'Dim TiempoServicio_Cargo As Integer = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_TiempoServicioCargo))
                'Dim TiempoServicio_Tope As Integer = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_TiempoServicioTope))

                'If TiempoServicio_Actual < TiempoServicio_Cargo And TiempoServicio_Cargo <= TiempoServicio_Tope Then
                '    For id As Integer = TiempoServicio_Cargo To TiempoServicio_Tope   'Caso cuadno esta dentro del tiempo Servicio del cargo
                '        oplanventaempleado = New PlanVentaEmpleado()
                '        oplanventaempleado.comboTiempoServicio = id + 1
                '        oListaPlanVentaEmpleado.Add(oplanventaempleado)
                '    Next
                'ElseIf TiempoServicio_Actual >= TiempoServicio_Cargo And TiempoServicio_Cargo <= TiempoServicio_Tope Then
                '    For id As Integer = TiempoServicio_Actual To TiempoServicio_Tope 'Caso cuadno se sale del tiempo Servicio del cargo
                '        oplanventaempleado = New PlanVentaEmpleado()
                '        oplanventaempleado.comboTiempoServicio = id + 1
                '        oListaPlanVentaEmpleado.Add(oplanventaempleado)
                '    Next
                'Else 'Caso cuando el empleado ya tiene un plan venta hasta el fin del periodo
                '    oplanventaempleado.comboTiempoServicio = -1
                '    oListaPlanVentaEmpleado.Add(oplanventaempleado)
                'End If
            End While
        End Using
        Return oListaPlanVentaEmpleado
    End Function

    Function ValidarEmpleadoCartera(ByVal idempleado As Integer) As Integer
        Dim resultado As Integer = -1
        Dim oDbComand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_VAL_SUCURSALEMPLEADOCARTERA)
        oDatabase.AddInParameter(oDbComand, "@IdEmpleado", DbType.Int32, idempleado)
        resultado = oDatabase.ExecuteScalar(oDbComand)
        Return resultado
    End Function

    Function ValidaEmpleadoActivoCartera(ByVal IdEmpleado As Integer) As Integer
        Dim resultado As Integer = -1
        Dim oDbComand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_VAL_EMPLEADOCARTERA)
        oDatabase.AddInParameter(oDbComand, "@IdEmpleado", DbType.Int32, IdEmpleado)
        resultado = oDatabase.ExecuteScalar(oDbComand)
        Return resultado
    End Function

    Function ObtenerNombreCargoVendedor(IdPerfil As Integer, IdZona As Integer) As String
        Dim nombre As String = ""
        Dim oDbComand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_OBTENER_NOMBRECARGO_BY_PERFILZONA)
        oDatabase.AddInParameter(oDbComand, "@IdPerfil", DbType.Int32, IdPerfil)
        oDatabase.AddInParameter(oDbComand, "@IdZona", DbType.Int32, IdZona)
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbComand)
            Dim INDICE_NOMBRECARGO As Integer = oIDataReader.GetOrdinal("NombreCargo")
            While oIDataReader.Read()
                nombre = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_NOMBRECARGO))
            End While
        End Using
        'nombre = oDatabase.ExecuteScalar(oDbComand)
        Return nombre
    End Function

    Function CargarEscalasComisionTiempoServicio(ByVal IdPerfil As Integer, ByVal IdZona As Integer) As ListaComisionEscala
        Dim oListaEscalaTiempoServicio As New ListaComisionEscala()
        Dim oDbComand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_OBTENER_ESCALASTIEMPO)
        oDatabase.AddInParameter(oDbComand, "@IDPERFIL", DbType.Int32, IdPerfil)
        oDatabase.AddInParameter(oDbComand, "@IDZONA", DbType.Int32, IdZona)
        oListaEscalaTiempoServicio = New ListaComisionEscala
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbComand)
            Dim indiIdComisionTiempoServicio As Integer = oIDataReader.GetOrdinal("IdComisionEscala")
            Dim indiIdEscalaTiempoServicio As Integer = oIDataReader.GetOrdinal("EscalaTiempoServicio")
            Dim oComisionEscala = New ComisionEscala
            While oIDataReader.Read()
                For i As Integer = 0 To DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indiIdEscalaTiempoServicio))
                    If i <> 0 Then
                        oComisionEscala = New ComisionEscala()
                        oComisionEscala.IdComisionEscala = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indiIdComisionTiempoServicio))
                        oComisionEscala.TiempoServicio = i
                    End If
                    oListaEscalaTiempoServicio.Add(oComisionEscala)
                Next
            End While
        End Using
        Return oListaEscalaTiempoServicio
    End Function

    Function ObtenerNombreCargoSuperior(IdPerfil As Integer, IdZona As Integer) As String
        Dim nombreSuperior As String = ""
        Dim oDbComand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_OBTENER_CARGOSUPERIOR)
        oDatabase.AddInParameter(oDbComand, "@IdPerfil", DbType.Int32, IdPerfil)
        oDatabase.AddInParameter(oDbComand, "@IdZona", DbType.Int32, IdZona)
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbComand)
            Dim INDICE_NOMBRECARGOSUPERIOR As Integer = oIDataReader.GetOrdinal("cargoEmpleado")
            While oIDataReader.Read()
                nombreSuperior = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_NOMBRECARGOSUPERIOR))
            End While
        End Using
        Return nombreSuperior
    End Function

    Function ObtenerTiempoServicioEmpleado(IdEmpleado As Integer) As Integer
        Dim result As Integer = 0

        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_OBTENERTIEMPOSERVICIOPOREMPLEADO, IdEmpleado)

        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim resultindice As Integer = oIDataReader.GetOrdinal("TiempoServicio")
            While oIDataReader.Read()
                result = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(resultindice))
            End While
        End Using
        Return result
    End Function

    Function ObtenerNombreEmpleado(IdEmpleado As Integer) As String
        Dim result As String = ""
        Dim oDbComand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_OBTENERNOMBREEMPLEADO)
        oDatabase.AddInParameter(oDbComand, "@IDEMPLEADO", DbType.Int32, IdEmpleado)

        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbComand)
            Dim indNombreReporta As Integer = oIDataReader.GetOrdinal("NombresApellidos")
            Dim indice_IdPerfil As Integer = oIDataReader.GetOrdinal("IdPerfil")
            While oIDataReader.Read()
                result = DataUtil.DbValueToDefault(Of String)(oIDataReader(indNombreReporta))
            End While
        End Using
        Return result
    End Function

    Function ObtenerDatosEmpleado(IdEmpleado As Integer) As Empleado
        Dim result As String = ""
        Dim oDbComand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_OBTENERNOMBREEMPLEADO)
        oDatabase.AddInParameter(oDbComand, "@IDEMPLEADO", DbType.Int32, IdEmpleado)
        Dim oEmpleado As New Empleado()
        oEmpleado = New Empleado()
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbComand)
            Dim indNombreReporta As Integer = oIDataReader.GetOrdinal("NombresApellidos")
            Dim indiceIdPerfil As Integer = oIDataReader.GetOrdinal("IdPerfil")
            While oIDataReader.Read()
                oEmpleado = New Empleado()
                oEmpleado.IdEmpleadoPerfilActual = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(indiceIdPerfil))
                oEmpleado.NombresApellidos = DataUtil.DbValueToDefault(Of String)(oIDataReader(indNombreReporta))
            End While
        End Using
        Return oEmpleado
    End Function

    Function InsertaVentasporConsulta(IdZona As Integer, IdSucursal As String, FechaInicio As String, FechaFin As String) As Integer
        Dim resultado As Integer = 0
        Try
            Dim oDbComand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_INSERTAREPROCESOVENTAS)
            oDbComand.CommandTimeout = 300
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

    'eliot
    Function Sucursales_PV_Grilla(ByVal opaginacion As Paginacion) As Paginacion
        Dim paginacion As New Paginacion()
        opaginacion.ListaSucursal = New ListaSucursal
        Dim oSucursal As New Sucursal()

        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_LISTARSUCUSAL_GRILLA)
        oDatabase.AddInParameter(oDbCommand, "@IdsSucursal", DbType.String, opaginacion.Sucursal.IdSucursalActual)
        oDatabase.AddInParameter(oDbCommand, "@sortType", DbType.String, opaginacion.SortType)
        oDatabase.AddInParameter(oDbCommand, "@sortdir", DbType.String, opaginacion.SortBy)
        oDatabase.AddInParameter(oDbCommand, "@Page", DbType.String, opaginacion.PageNumber)
        oDatabase.AddInParameter(oDbCommand, "@RowsPerPage", DbType.Int32, opaginacion.PageSize)
        oDatabase.AddOutParameter(oDbCommand, "@RowCount", DbType.Int32, 1)

        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim idsucursal As Integer = oIDataReader.GetOrdinal("IdSucursal")
            Dim descripcion As Integer = oIDataReader.GetOrdinal("Descripcion")
            Dim codigosucursal As Integer = oIDataReader.GetOrdinal("CodigoSucursal")
            While oIDataReader.Read()
                oSucursal = New Sucursal()
                oSucursal.IdSucursal = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(idsucursal))
                oSucursal.DescripcionSucursal = DataUtil.DbValueToDefault(Of String)(oIDataReader(descripcion))
                oSucursal.CodigoSucursal = DataUtil.DbValueToDefault(Of String)(oIDataReader(codigosucursal))
                opaginacion.ListaSucursal.Add(oSucursal)
            End While
        End Using

        opaginacion.TotalRows = Convert.ToInt32(oDatabase.GetParameterValue(oDbCommand, "@RowCount"))
        Return opaginacion
    End Function

    Function CargarTipoRepresentanteVenta(idPerfil As Integer) As ListaTipoRepresentanteVenta
        Dim oListaTipoRepresentanteVenta As New ListaTipoRepresentanteVenta
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_LISTAR_TIPOREPRESENTANTEVENTAPORPERFIL)
        oDatabase.AddInParameter(oDbCommand, "@IdPerfil", DbType.Int32, idPerfil)
        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim iIdTipoRepVen As Integer = oIDataReader.GetOrdinal("IdTipoRepVen")
            Dim iNombreTipoRepVen As Integer = oIDataReader.GetOrdinal("NombreTipoRepVen")

            Dim oTipoRepresentanteVenta = New TipoRepresentanteVenta
            While oIDataReader.Read()
                oTipoRepresentanteVenta = New TipoRepresentanteVenta()
                oTipoRepresentanteVenta.IdTipoRepVen = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(iIdTipoRepVen))
                oTipoRepresentanteVenta.NombreTipoRepVen = DataUtil.DbValueToDefault(Of String)(oIDataReader(iNombreTipoRepVen))
                oListaTipoRepresentanteVenta.Add(oTipoRepresentanteVenta)
            End While
        End Using
        Return oListaTipoRepresentanteVenta
    End Function

End Class
