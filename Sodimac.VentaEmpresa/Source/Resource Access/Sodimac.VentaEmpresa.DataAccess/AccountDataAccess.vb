Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Common
Imports System.Linq
Imports System.Text
Imports Sodimac.VentaEmpresa.BusinessEntities
Imports Sodimac.VentaEmpresa.DataContracts
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common.Configuration

Public Class AccountDataAccess

    Private oDatabase As Database = EnterpriseLibraryContainer.Current.GetInstance(Of Database)(Conexion.cnsSqlSeguridad)


    Public Function ValidarUsuarioBD(UsuarioUsu As Usuario) As Usuario
        Dim oUsuarios As New Usuario()
        Dim resultado As Integer = 0
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_VALIDARUSUARIOEXISTE)
        oDatabase.AddInParameter(oDbCommand, "@UsuarioUsu", DbType.String, UsuarioUsu)
        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim i_activo As Integer = oIDataReader.GetOrdinal("ActivoUsu")
            While oIDataReader.Read()
                resultado = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(i_activo))
            End While
        End Using
        Return oUsuarios
    End Function

    Public Function ValidateUser(oUsuario As Usuario) As Usuario
        Dim oUsuario_return As New Usuario()
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_VALIDAR_USUARIO)
        oDatabase.AddInParameter(oDbCommand, "@UsuarioUsu", DbType.String, oUsuario.UsuarioUsu)
        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim i_IdUsu As Integer = oIDataReader.GetOrdinal("IdUsu")
            Dim i_UsuarioUsu As Integer = oIDataReader.GetOrdinal("UsuarioUsu")
            Dim i_UsuarioNom As Integer = oIDataReader.GetOrdinal("UsuarioNom")
            While oIDataReader.Read()
                oUsuario_return.IdUsu = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(i_IdUsu))
                oUsuario_return.UsuarioUsu = DataUtil.DbValueToDefault(Of String)(oIDataReader(i_UsuarioUsu))
                oUsuario_return.UsuarioNom = DataUtil.DbValueToDefault(Of String)(oIDataReader(i_UsuarioNom))
            End While
        End Using
        Return oUsuario_return
    End Function

    Public Function ObtenerUsuarios(IdRol As Integer) As ListaUsuario
        Dim oListaUsuario As New ListaUsuario()
        Dim oUsuario As New Usuario()
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(Procedimientos.USP_SEL_USUARIO, IdRol)
            Dim indiceIdUsu As Integer = oIDataReader.GetOrdinal("IdUsu")
            Dim indiceUsuarioUsu As Integer = oIDataReader.GetOrdinal("UsuarioUsu")
            While oIDataReader.Read()
                oUsuario = New Usuario()
                oUsuario.IdUsu = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(indiceIdUsu))
                oUsuario.UsuarioUsu = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceUsuarioUsu))
                oListaUsuario.Add(oUsuario)
            End While
        End Using
        Return oListaUsuario
    End Function

    Public Function AsignarRolUsuarios(oUsuarioRol As UsuarioRol) As Integer
        Dim resultado As Integer = 0
        Try
            Using oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_INS_ROLUSUARIO)
                oDatabase.AddInParameter(oDbCommand, "@IdUsu", DbType.Int32, oUsuarioRol.Usuario.IdUsu)
                oDatabase.AddInParameter(oDbCommand, "@IdRol", DbType.Int32, oUsuarioRol.Rol.IdRol)
                oDbCommand.CommandTimeout = 120000
                resultado = CType(oDatabase.ExecuteNonQuery(oDbCommand), Int32)
            End Using
        Catch generatedExceptionName As Exception
            Throw
        End Try
        Return resultado
    End Function

    Public Function DesasignarRolUsuarios(oUsuarioRol As UsuarioRol) As Integer
        Dim resultado As Integer = 0
        Using oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_DEL_ROLUSUARIO)
            oDatabase.AddInParameter(oDbCommand, "@IdRol", DbType.Int32, oUsuarioRol.Rol.IdRol)
            oDbCommand.CommandTimeout = 120000
            resultado = CType(oDatabase.ExecuteNonQuery(oDbCommand), Int32)
        End Using
        Return resultado
    End Function

    Public Function AgregarRol(oRol As Rol) As Integer
        Dim resultado As Integer = 0

        Using oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_INS_ROL)
            oDatabase.AddInParameter(oDbCommand, "@NombreRol", DbType.String, oRol.NombreRol)
            oDatabase.AddInParameter(oDbCommand, "@ActivoRol", DbType.Boolean, oRol.ActivoRol)
            oDbCommand.CommandTimeout = 120000
            resultado = CType(oDatabase.ExecuteNonQuery(oDbCommand), Int32)
        End Using
        Return resultado
    End Function

    Public Function ListarRoles(oRol As Rol, sortType As String, maximumRows As Integer, startRowIndex As Integer, ByRef Total As Integer) As ListaRol
        Dim oListaRol As New ListaRol()
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_ROL_PAGINADO)
        oDatabase.AddInParameter(oDbCommand, "@NombreRol", DbType.String, oRol.NombreRol)
        oDatabase.AddInParameter(oDbCommand, "@EstadoRol", DbType.Int32, oRol.EstadoId)
        oDatabase.AddInParameter(oDbCommand, "@sortType", DbType.String, sortType)
        oDatabase.AddInParameter(oDbCommand, "@maximumRows", DbType.Int32, maximumRows)
        oDatabase.AddInParameter(oDbCommand, "@startRowIndex", DbType.Int32, startRowIndex)
        oDatabase.AddOutParameter(oDbCommand, "@Total", DbType.Int32, 10)
        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim indiceIdRol As Integer = oIDataReader.GetOrdinal("IdRol")
            Dim indiceNombreRol As Integer = oIDataReader.GetOrdinal("NombreRol")
            Dim indiceActivoRol As Integer = oIDataReader.GetOrdinal("ActivoRol")
            While oIDataReader.Read()
                oRol = New Rol()
                oRol.IdRol = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(indiceIdRol))
                oRol.NombreRol = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceNombreRol))
                oRol.ActivoRol = DataUtil.DbValueToDefault(Of Boolean)(oIDataReader(indiceActivoRol))
                oListaRol.Add(oRol)
            End While
        End Using

        Total = Convert.ToInt32(oDatabase.GetParameterValue(oDbCommand, "@Total"))
        Return oListaRol
    End Function

    Public Function EditarRol(oRol As Rol) As Integer
        Dim resultado As Integer = 0
        Using oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_UPD_ROL)
            oDatabase.AddInParameter(oDbCommand, "@IdRol", DbType.Int32, oRol.IdRol)
            oDatabase.AddInParameter(oDbCommand, "@NombreRol", DbType.String, oRol.NombreRol)
            oDatabase.AddInParameter(oDbCommand, "@ActivoRol", DbType.Boolean, oRol.ActivoRol)
            oDbCommand.CommandTimeout = 120000
            resultado = CType(oDatabase.ExecuteNonQuery(oDbCommand), Int32)
        End Using
        Return resultado
    End Function

    Public Function DesactivarRol(oRol As Rol) As Integer
        Dim resultado As Integer = 0
        Using oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_DEL_ROL)
            oDatabase.AddInParameter(oDbCommand, "@IdRol", DbType.Int32, oRol.IdRol)
            oDbCommand.CommandTimeout = 120000
            resultado = CType(oDatabase.ExecuteNonQuery(oDbCommand), Int32)
        End Using
        Return resultado
    End Function

    Public Function ObtenerRolPorId(IdRol As Integer) As Rol
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_ROLPORID)
        oDatabase.AddInParameter(oDbCommand, "@IdRol", DbType.String, IdRol)
        Dim oRol As New Rol()
        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim indiceIdRol As Integer = oIDataReader.GetOrdinal("IdRol")
            Dim indiceNombreRol As Integer = oIDataReader.GetOrdinal("NombreRol")
            Dim indiceActivoRol As Integer = oIDataReader.GetOrdinal("ActivoRol")
            While oIDataReader.Read()
                oRol = New Rol()
                oRol.IdRol = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(indiceIdRol))
                oRol.NombreRol = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceNombreRol))
                oRol.ActivoRol = DataUtil.DbValueToDefault(Of Boolean)(oIDataReader(indiceActivoRol))
            End While
        End Using
        Return oRol
    End Function

    Public Function BuscarPagina(oPagina As Pagina) As ListaPagina
        Dim oListaPagina As New ListaPagina()
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(Procedimientos.USP_SEL_PAGINA, oPagina.IdPagina, oPagina.NombrePagina, oPagina.PadrePagina)
            Dim indexIdPagina As Integer = oIDataReader.GetOrdinal("IdPagina")
            Dim indexNombrePagina As Integer = oIDataReader.GetOrdinal("NombrePagina")
            Dim indexUrlPagina As Integer = oIDataReader.GetOrdinal("UrlPagina")
            Dim indexPadrePagina As Integer = oIDataReader.GetOrdinal("PadrePagina")
            Dim indexActivoPagina As Integer = oIDataReader.GetOrdinal("ActivoPagina")
            Dim indexNivelPagina As Integer = oIDataReader.GetOrdinal("NivelPagina")
            While oIDataReader.Read()
                oPagina = New Pagina()
                oPagina.IdPagina = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(indexIdPagina))
                oPagina.NombrePagina = DataUtil.DbValueToDefault(Of String)(oIDataReader(indexNombrePagina))
                oPagina.UrlPagina = DataUtil.DbValueToDefault(Of String)(oIDataReader(indexUrlPagina))
                oPagina.PadrePagina = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(indexPadrePagina))
                oPagina.ActivoPagina = DataUtil.DbValueToDefault(Of Boolean)(oIDataReader(indexActivoPagina))
                oPagina.NivelPagina = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(indexNivelPagina))
                oListaPagina.Add(oPagina)
            End While
        End Using
        Return oListaPagina
    End Function

    Public Function BuscarPaginaRol(oRol As Rol, idPagina As Integer, maximumRows As Integer, startRowIndex As Integer, ByRef Total As Integer) As ListaRol
        Dim oListaRol As New ListaRol()
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_PAGINAROL)
        oDatabase.AddInParameter(oDbCommand, "@NombreRol", DbType.String, oRol.NombreRol)
        oDatabase.AddInParameter(oDbCommand, "@ActivoRol", DbType.Boolean, oRol.ActivoRol)
        oDatabase.AddInParameter(oDbCommand, "@IdPagina", DbType.Int32, idPagina)
        oDatabase.AddInParameter(oDbCommand, "@maximumRows", DbType.Int32, maximumRows)
        oDatabase.AddInParameter(oDbCommand, "@startRowIndex", DbType.Int32, startRowIndex)
        oDatabase.AddOutParameter(oDbCommand, "@Total", DbType.Int32, 10)
        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim indiceIdRol As Integer = oIDataReader.GetOrdinal("IdRol")
            Dim indiceNombreRol As Integer = oIDataReader.GetOrdinal("NombreRol")
            Dim indiceActivoRol As Integer = oIDataReader.GetOrdinal("ActivoRol")
            While oIDataReader.Read()
                oRol = New Rol()
                oRol.IdRol = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(indiceIdRol))
                oRol.NombreRol = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceNombreRol))
                oRol.ActivoRol = DataUtil.DbValueToDefault(Of Boolean)(oIDataReader(indiceActivoRol))
                oListaRol.Add(oRol)
            End While
        End Using

        Total = Convert.ToInt32(oDatabase.GetParameterValue(oDbCommand, "@Total"))
        Return oListaRol
    End Function

    Public Function AsignarPerfil(oPaginaRol As PaginaRol) As Integer
        Dim resultado As Integer = 0
        Try
            Using oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_INS_PAGINAROL)
                oDatabase.AddInParameter(oDbCommand, "@IdPagina", DbType.Int32, oPaginaRol.Pagina.IdPagina)
                oDatabase.AddInParameter(oDbCommand, "@IdRol", DbType.Int32, oPaginaRol.Rol.IdRol)
                oDbCommand.CommandTimeout = 120000
                resultado = CType(oDatabase.ExecuteNonQuery(oDbCommand), Int32)
            End Using
        Catch generatedExceptionName As Exception
            Throw
        End Try
        Return resultado
    End Function

    Public Function DesasignarPerfil(oPaginaRol As PaginaRol) As Integer
        Dim resultado As Integer = 0
        Using oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_DEL_PAGINAROL)
            oDatabase.AddInParameter(oDbCommand, "@IdPagina", DbType.Int32, oPaginaRol.Pagina.IdPagina)
            oDbCommand.CommandTimeout = 120000
            resultado = CType(oDatabase.ExecuteNonQuery(oDbCommand), Int32)
        End Using
        Return resultado
    End Function

    Public Function ObtenerRolCheckeado(oPaginaRol As PaginaRol) As ListaRol
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_ROLCHECK)
        oDatabase.AddInParameter(oDbCommand, "@IdRol", DbType.Int32, oPaginaRol.Rol.IdRol)
        oDatabase.AddInParameter(oDbCommand, "@IdPagina", DbType.Int32, oPaginaRol.Pagina.IdPagina)
        Dim oListaRol As New ListaRol()
        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim indiceIdRol As Integer = oIDataReader.GetOrdinal("IdRol")
            Dim indiceNombreRol As Integer = oIDataReader.GetOrdinal("NombreRol")
            Dim indiceActivoRol As Integer = oIDataReader.GetOrdinal("ActivoRol")
            While oIDataReader.Read()
                oPaginaRol.Rol = New Rol()
                oPaginaRol.Rol.IdRol = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(indiceIdRol))
                oPaginaRol.Rol.NombreRol = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceNombreRol))
                oPaginaRol.Rol.ActivoRol = DataUtil.DbValueToDefault(Of Boolean)(oIDataReader(indiceActivoRol))
                oListaRol.Add(oPaginaRol.Rol)
            End While
        End Using
        Return oListaRol
    End Function

    Public Function ObtenerRolesPorEstado(oRol As Rol) As ListaRol
        Dim oListaRol As New ListaRol()
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_ROLPORESTADO)
        oDatabase.AddInParameter(oDbCommand, "@ActivoRol", DbType.Boolean, oRol.ActivoRol)
        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim indiceIdRol As Integer = oIDataReader.GetOrdinal("IdRol")
            Dim indiceNombreRol As Integer = oIDataReader.GetOrdinal("NombreRol")
            While oIDataReader.Read()
                oRol = New Rol()
                oRol.IdRol = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(indiceIdRol))
                oRol.NombreRol = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceNombreRol))
                oListaRol.Add(oRol)
            End While
        End Using
        Return oListaRol
    End Function

    Public Function ObtenerRolPorUsuario(username As String) As ListaRol
        Dim oRol As Rol
        Dim oListaRol As New ListaRol()
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(Procedimientos.USP_ROL_BY_USER, username)
            Dim indexIdRol As Integer = oIDataReader.GetOrdinal("IdRol")
            Dim indexRol As Integer = oIDataReader.GetOrdinal("NombreRol")
            While oIDataReader.Read()
                oRol = New Rol()
                oRol.IdRol = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(indexIdRol))
                oRol.NombreRol = DataUtil.DbValueToDefault(Of String)(oIDataReader(indexRol))
                oListaRol.Add(oRol)
            End While
        End Using
        Return oListaRol
    End Function

    Public Function SiteMapByUser(username As String) As ListaPagina
        Try
            Dim oListaPagina As New ListaPagina()
            Using oIDataReader As IDataReader = oDatabase.ExecuteReader(Procedimientos.SITEMAP_ROL_BY_USER, username)
                Dim indiceIdPagina As Integer = oIDataReader.GetOrdinal("IdPagina")
                Dim indiceNombrePagina As Integer = oIDataReader.GetOrdinal("NombrePagina")
                Dim indiceUrlPagina As Integer = oIDataReader.GetOrdinal("UrlPagina")
                Dim indicePadrePagina As Integer = oIDataReader.GetOrdinal("PadrePagina")
                Dim indiceVisiblePagina As Integer = oIDataReader.GetOrdinal("VisiblePagina")
                Dim indiceNivelPagina As Integer = oIDataReader.GetOrdinal("NivelPagina")
                Dim indiceUrlImagePagina As Integer = oIDataReader.GetOrdinal("UrlImagePagina")
                While oIDataReader.Read()
                    Dim oPagina As New Pagina()
                    oPagina.IdPagina = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(indiceIdPagina))
                    oPagina.NombrePagina = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceNombrePagina))
                    oPagina.UrlPagina = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceUrlPagina))
                    oPagina.PadrePagina = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(indicePadrePagina))
                    oPagina.VisiblePagina = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(indiceVisiblePagina))
                    oPagina.NivelPagina = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(indiceNivelPagina))
                    oPagina.UrlImagePagina = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceUrlImagePagina))
                    oListaPagina.Add(oPagina)
                End While
            End Using
            Return oListaPagina
        Catch ex As Exception
            username = ex.Message
            Return Nothing
        Finally
        End Try
    End Function

    Public Function ListarUsuarios(oUsuario As Usuario, sortType As String, maximumRows As Integer, startRowIndex As Integer, ByRef Total As Integer) As ListaUsuario
        Dim oListaUsuario As New ListaUsuario()
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_USUARIO_PAGINADO)
        oDatabase.AddInParameter(oDbCommand, "@UsuarioUsu", DbType.String, oUsuario.UsuarioUsu)
        oDatabase.AddInParameter(oDbCommand, "@ActivoUsu", DbType.Int32, oUsuario.ActivoUsu)
        oDatabase.AddInParameter(oDbCommand, "@sortType", DbType.String, sortType)
        oDatabase.AddInParameter(oDbCommand, "@maximumRows", DbType.Int32, maximumRows)
        oDatabase.AddInParameter(oDbCommand, "@startRowIndex", DbType.Int32, startRowIndex)
        oDatabase.AddOutParameter(oDbCommand, "@Total", DbType.Int32, 10)
        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim indiceIdUsu As Integer = oIDataReader.GetOrdinal("IdUsu")
            Dim indiceUsuarioUsu As Integer = oIDataReader.GetOrdinal("UsuarioUsu")
            Dim indiceUsuarioNom As Integer = oIDataReader.GetOrdinal("UsuarioNom")
            Dim indiceActivoUsu As Integer = oIDataReader.GetOrdinal("ActivoUsu")
            While oIDataReader.Read()
                oUsuario = New Usuario()
                oUsuario.IdUsu = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(indiceIdUsu))
                oUsuario.UsuarioUsu = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceUsuarioUsu))
                oUsuario.UsuarioNom = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceUsuarioNom))
                oUsuario.ActivoUsu = Convert.ToInt32(DataUtil.DbValueToDefault(Of Boolean)(oIDataReader(indiceActivoUsu)))
                oListaUsuario.Add(oUsuario)
            End While
        End Using
        Total = Convert.ToInt32(oDatabase.GetParameterValue(oDbCommand, "@Total"))
        Return oListaUsuario
    End Function

    Public Function AgregarUsuario(oUsuario As Usuario) As Integer
        Dim resultado As Integer = 0
        Using oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_INS_USUARIO)
            oDatabase.AddInParameter(oDbCommand, "@UsuarioUsu", DbType.String, oUsuario.UsuarioUsu)
            oDatabase.AddInParameter(oDbCommand, "@UsuarioNom", DbType.String, oUsuario.UsuarioNom)
            oDatabase.AddInParameter(oDbCommand, "@ActivoUsu", DbType.Boolean, oUsuario.ActivoUsu)
            oDbCommand.CommandTimeout = 120000
            resultado = CType(oDatabase.ExecuteNonQuery(oDbCommand), Int32)
        End Using
        Return resultado
    End Function

    Public Function EditarUsuario(oUsuario As Usuario) As Integer
        Dim resultado As Integer = 0
        Using oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_UPD_USUARIO)
            oDatabase.AddInParameter(oDbCommand, "@IdUsu", DbType.Int32, oUsuario.IdUsu)
            oDatabase.AddInParameter(oDbCommand, "@UsuarioUsu", DbType.String, oUsuario.UsuarioUsu)
            oDatabase.AddInParameter(oDbCommand, "@UsuarioNom", DbType.String, oUsuario.UsuarioNom)
            oDatabase.AddInParameter(oDbCommand, "@ActivoUsu", DbType.Boolean, oUsuario.ActivoUsu)
            oDbCommand.CommandTimeout = 120000
            resultado = CType(oDatabase.ExecuteNonQuery(oDbCommand), Int32)
        End Using
        Return resultado
    End Function

    Public Function DesactivarUsuario(oUsuario As Usuario) As Integer
        Dim resultado As Integer = 0
        Using oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_DEL_USUARIO)
            oDatabase.AddInParameter(oDbCommand, "@IdUsu", DbType.Int32, oUsuario.IdUsu)
            oDbCommand.CommandTimeout = 120000
            resultado = CType(oDatabase.ExecuteNonQuery(oDbCommand), Int32)
        End Using
        Return resultado
    End Function

    Public Function ObtenerUsuarioPorId(IdUsu As Integer) As Usuario
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_USUARIOPORID)
        oDatabase.AddInParameter(oDbCommand, "@IdUsu", DbType.String, IdUsu)
        Dim oUsuario As New Usuario()
        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim indiceIdUsu As Integer = oIDataReader.GetOrdinal("IdUsu")
            Dim indiceUsuarioUsu As Integer = oIDataReader.GetOrdinal("UsuarioUsu")
            Dim indiceUsuarioNom As Integer = oIDataReader.GetOrdinal("UsuarioNom")
            Dim indiceActivoUsu As Integer = oIDataReader.GetOrdinal("ActivoUsu")
            While oIDataReader.Read()
                oUsuario = New Usuario()
                oUsuario.IdUsu = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(indiceIdUsu))
                oUsuario.UsuarioUsu = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceUsuarioUsu))
                oUsuario.UsuarioNom = DataUtil.DbValueToDefault(Of String)(oIDataReader(indiceUsuarioNom))
                oUsuario.ActivoUsu = Convert.ToInt32(DataUtil.DbValueToDefault(Of Boolean)(oIDataReader(indiceActivoUsu)))
            End While
        End Using
        Return oUsuario
    End Function

    Public Function ValidaEmpleado_NombreUsuarioUsu(UsuarioUsu As String) As Boolean
        Dim Val As New Boolean
        Dim oDatabase As Database = EnterpriseLibraryContainer.Current.GetInstance(Of Database)(Conexion.cnsSql)
        Dim oEmpleado As New Empleado()
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_VALIDARUSUARIOUSU_EEMPLEADO)
        oDatabase.AddInParameter(oDbCommand, "@UsuarioUsu", DbType.String, UsuarioUsu)
        oDbCommand.CommandTimeout = 120000
        Val = False
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim i_IdEmpleado As Integer = oIDataReader.GetOrdinal("IdEmpleado")

            While oIDataReader.Read()
                oEmpleado.IdEmpleado = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(i_IdEmpleado))
            End While
        End Using

        If oEmpleado.IdEmpleado <> 0 Then
            Val = True

        End If


        Return Val
    End Function

    Public Function ValidaEmpleado_NombreUsuarioUsu_(UsuarioUsu As String) As Integer
        Dim IdEmpleado As Integer
        Dim oDatabase As Database = EnterpriseLibraryContainer.Current.GetInstance(Of Database)(Conexion.cnsSql)
        Dim oEmpleado As New Empleado()
        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_VALIDARUSUARIOUSU_EEMPLEADO)
        oDatabase.AddInParameter(oDbCommand, "@UsuarioUsu", DbType.String, UsuarioUsu)
        oDbCommand.CommandTimeout = 120000
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim i_IdEmpleado As Integer = oIDataReader.GetOrdinal("IdEmpleado")

            While oIDataReader.Read()
                oEmpleado.IdEmpleado = DataUtil.DbValueToDefault(Of Int32)(oIDataReader(i_IdEmpleado))
            End While
        End Using
        If oEmpleado.IdEmpleado <> 0 Then
            IdEmpleado = oEmpleado.IdEmpleado
        End If
        Return IdEmpleado
    End Function

    Function ListarRol() As ListaRol
        Dim oListaRol As New ListaRol()

        Dim oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_SEL_ROL)
        oDbCommand.CommandTimeout = 120000
        Dim oRol As New Rol()
        Using oIDataReader As IDataReader = oDatabase.ExecuteReader(oDbCommand)
            Dim INDICE_IdRol As Integer = oIDataReader.GetOrdinal("IdRol")
            Dim INDICE_NombreRol As Integer = oIDataReader.GetOrdinal("NombreRol")
            Dim INDICE_ActivoRol As Integer = oIDataReader.GetOrdinal("ActivoRol")
            While oIDataReader.Read()
                oRol = New Rol
                oRol.IdRol = DataUtil.DbValueToDefault(Of Integer)(oIDataReader(INDICE_IdRol))
                oRol.NombreRol = DataUtil.DbValueToDefault(Of String)(oIDataReader(INDICE_NombreRol))
                oRol.ActivoRol = DataUtil.DbValueToDefault(Of Boolean)(oIDataReader(INDICE_ActivoRol))
                oListaRol.Add(oRol)
            End While
        End Using
        Return oListaRol
    End Function

    Public Function EditarSesionUsuario(usuarioUsu As String) As Integer
        Dim resultado As Integer = 0
        Using oDbCommand As DbCommand = oDatabase.GetStoredProcCommand(Procedimientos.USP_UPD_SESIONUSUARIO)
            oDatabase.AddInParameter(oDbCommand, "@UsuarioUsu", DbType.String, usuarioUsu)
            oDbCommand.CommandTimeout = 120000
            resultado = CType(oDatabase.ExecuteNonQuery(oDbCommand), Int32)
        End Using
        Return resultado
    End Function

End Class
