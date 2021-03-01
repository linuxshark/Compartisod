Imports System.Web.Security
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports System.Web.Routing
Imports MvcSiteMapProvider.DefaultSiteMapProvider
Imports Sodimac.VentaEmpresa.Web.Mvc.Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad
Imports Sodimac.VentaEmpresa.Web.Seguridad
Imports Microsoft.Practices.EnterpriseLibrary.Logging
Imports Sodimac.VentaEmpresa.Web.Seguridad.Filters
Imports Sodimac.VentaEmpresa.Common
Imports Sodimac.VentaEmpresa.BusinessLogic
Imports System.Management
Imports System.Net.NetworkInformation
Imports Sodimac.VentaEmpresa

Namespace Sodimac.VentaEmpresa.Web.Mvc
    Public Class AccountController
        Inherits BaseController
        Dim SiSeguridad As Boolean = True

        <RequiresAuthenticationAttribute()>
        <RequiresAuthorizationAttribute()>
        Public Function GestionarUsuario(oUsuario As Usuario) As ActionResult
            Dim oAccountViewModel As New AccountViewModel()
            oAccountViewModel.Usuario = New Usuario()
            oAccountViewModel.ListaEstados = ListarEstados()
            Return View(oAccountViewModel)
        End Function

        <RequiresAuthenticationAjaxAttribute()>
        Public Function ConsultarUsuario_PVGrilla(Optional pNombreUsu As [String] = "", Optional pEstadoUsu As Integer = 0, Optional sort As [String] = "UsuarioUsu", Optional page As Integer = 0, Optional sortDir As [String] = "DESC") As ActionResult
            Dim pageIndex As Integer = page
            Dim oAccountViewModel As New AccountViewModel()
            If page = 0 OrElse page = -1 Then
                oAccountViewModel.Usuario = New Usuario()
                oAccountViewModel.Usuario.UsuarioUsu = pNombreUsu
                oAccountViewModel.Usuario.ActivoUsu = pEstadoUsu

            End If

            If page <> -1 AndAlso Not (page > 1) Then
                page = 1
            End If

            Dim sw As Boolean = False
            If page = -1 Then
                page = 1
                sw = True
                Session("oAccountViewModel.Usuario") = Nothing
            End If

            If oAccountViewModel Is Nothing Then
                oAccountViewModel = New AccountViewModel()
            End If

            If Session("oAccountViewModel.Usuario") Is Nothing Then
                Session("oAccountViewModel.Usuario") = oAccountViewModel.Usuario
            Else
                oAccountViewModel.Usuario = DirectCast(Session("oAccountViewModel.Usuario"), Usuario)
            End If

            Dim Total As Integer

            Dim UsuarioPagina As Integer = 10
            If page = 1 Then
                page = 0
            Else
                page = ((page - 1) * UsuarioPagina) + 1
                UsuarioPagina -= 1
            End If

            oAccountViewModel.RegistroPorPagina = 10
            oAccountViewModel.sortType = If(sortDir = "ASC", sort, Convert.ToString(sort) & " DESC")
            oAccountViewModel.startRowIndex = page
            oAccountViewModel.maximumRows = UsuarioPagina
            Dim oUsuario As New Usuario()
            oAccountViewModel.ListaUsuarios = ServicioAccountController.ListarUsuarios(oAccountViewModel.Usuario, oAccountViewModel.sortType, oAccountViewModel.maximumRows, oAccountViewModel.startRowIndex, Total)

            If (SiSeguridad) Then
                Dim LBE As New LogBusinessLogic
                Dim Log As DataContracts.Log = Session("Log")
                Log.DescripcionAccion = "Usuario:" & oAccountViewModel.Usuario.UsuarioNom & "|IdEstado:" & oAccountViewModel.Usuario.ActivoUsu
                Log.IdOrigenAccion = Constantes.Seguridad_Usuario
                Log.IdLogAccion = Constantes.Buscar
                LBE.ActualizarLog(Log)
            End If

            oAccountViewModel.TotalRegistros = Total
            oAccountViewModel.DescRegistrosPorPagina = UtilWebGrid.ContadorRegistrosWebGrid(pageIndex, oAccountViewModel.RegistroPorPagina, oAccountViewModel.TotalRegistros)

            If sw Then
                Return PartialView("ConsultarUsuario_PVGrilla", oAccountViewModel)
            End If

            Return View(oAccountViewModel)
        End Function

        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()>
        Public Function EditarUsuario(IdUsu As Integer) As ActionResult
            Dim oAccountViewModel As New AccountViewModel()
            oAccountViewModel.Usuario = ServicioAccountController.ObtenerUsuarioPorId(IdUsu)
            Return PartialView("EditarUsuario", oAccountViewModel)
        End Function

        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()>
        <ValidateAntiForgeryToken()>
        Public Function EditarUsuario_(oAccountViewModel As AccountViewModel) As ActionResult
            Dim resultado As Integer = ServicioAccountController.EditarUsuario(oAccountViewModel.Usuario)

            If (resultado = Constantes.ValorUno And SiSeguridad) Then
                Dim LBE As New LogBusinessLogic
                Dim Log As DataContracts.Log = Session("Log")
                Log.DescripcionAccion = "IdUsu:" & oAccountViewModel.Usuario.IdUsu & "|Usuario:" & oAccountViewModel.Usuario.UsuarioUsu &
                    "|Nombre:" & oAccountViewModel.Usuario.UsuarioNom & "|Activo:" & oAccountViewModel.Usuario.ActivoUsu
                Log.IdOrigenAccion = Constantes.Seguridad_Usuario
                Log.IdLogAccion = Constantes.Modificar
                LBE.ActualizarLog(Log)
            End If

            Return Content(Convert.ToString(resultado))
        End Function

        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()>
        <ValidateAntiForgeryToken()>
        Public Function AgregarUsuario(oAccountViewModel As AccountViewModel) As ActionResult
            Dim resultado As Integer = 0
            resultado = ServicioAccountController.AgregarUsuario(oAccountViewModel.Usuario)

            If (resultado = Constantes.ValorUno And SiSeguridad) Then
                Dim LBE As New LogBusinessLogic
                Dim Log As DataContracts.Log = Session("Log")
                Log.DescripcionAccion = "IdUsu:" & oAccountViewModel.Usuario.IdUsu & "|Usurio:" & oAccountViewModel.Usuario.UsuarioUsu & "|Nombre:" & oAccountViewModel.Usuario.UsuarioNom & "|Activo:" & oAccountViewModel.Usuario.ActivoUsu
                Log.IdOrigenAccion = Constantes.Seguridad_Usuario
                Log.IdLogAccion = Constantes.Insertar
                LBE.ActualizarLog(Log)
            End If

            Return Content(Convert.ToString(resultado))
        End Function

        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()>
        Public Function DesactivarUsuario(pIdUsu As Integer) As ActionResult
            Dim oUsuario As New Usuario()
            oUsuario.IdUsu = pIdUsu
            Dim resultado As Integer = ServicioAccountController.DesactivarUsuario(oUsuario)

            If (resultado = 1 And SiSeguridad) Then
                Dim LBE As New LogBusinessLogic
                Dim Log As DataContracts.Log = Session("Log")
                Log.DescripcionAccion = "IdUsu:" & pIdUsu
                Log.IdOrigenAccion = Constantes.Seguridad_Usuario
                Log.IdLogAccion = Constantes.Desactivar
                LBE.ActualizarLog(Log)
            End If

            Return Content(Convert.ToString(resultado))
        End Function

        <RequiresAuthorizationAttribute()>
        Public Function Consultar() As ActionResult
            Dim oAccountViewModel As New AccountViewModel()
            oAccountViewModel.ListaEstados = ListarEstados()
            Return View(oAccountViewModel)
        End Function

        <RequiresAuthenticationAjaxAttribute()>
        Public Function ConsultarRol_PVGrilla(Optional pNombreRol As [String] = "", Optional pEstadoRol As Integer = 0, Optional sort As [String] = "NombreRol", Optional page As Integer = 0, Optional sortDir As [String] = "DESC") As ActionResult
            Dim pageIndex As Integer = page
            Dim oAccountViewModel As New AccountViewModel()
            If page = 0 OrElse page = -1 Then
                oAccountViewModel.Rol = New Rol()
                oAccountViewModel.Rol.NombreRol = pNombreRol
                oAccountViewModel.Rol.EstadoId = pEstadoRol
            End If

            If page <> -1 AndAlso Not (page > 1) Then
                page = 1
            End If

            Dim sw As Boolean = False
            If page = -1 Then
                page = 1
                sw = True
                Session("oAccountViewModel.Rol") = Nothing
            End If

            If oAccountViewModel Is Nothing Then
                oAccountViewModel = New AccountViewModel()
            End If

            If Session("oAccountViewModel.Rol") Is Nothing Then
                Session("oAccountViewModel.Rol") = oAccountViewModel.Rol
            Else
                oAccountViewModel.Rol = DirectCast(Session("oAccountViewModel.Rol"), Rol)
            End If

            Dim Total As Integer

            Dim RolPagina As Integer = 10
            If page = 1 Then
                page = 0
            Else
                page = ((page - 1) * RolPagina) + 1
                RolPagina -= 1
            End If

            oAccountViewModel.RegistroPorPagina = 10
            oAccountViewModel.sortType = If(sortDir = "ASC", sort, Convert.ToString(sort) & " DESC")
            oAccountViewModel.startRowIndex = page
            oAccountViewModel.maximumRows = RolPagina
            Dim oRol As New Rol()
            oAccountViewModel.ListaRoles = ServicioAccountController.ListarRoles(oAccountViewModel.Rol, oAccountViewModel.sortType, oAccountViewModel.maximumRows, oAccountViewModel.startRowIndex, Total)

            If (SiSeguridad) Then
                Dim LBE As New LogBusinessLogic
                Dim Log As DataContracts.Log = Session("Log")
                Log.DescripcionAccion = "Rol:" & pNombreRol & "|IdEstado:" & pEstadoRol
                Log.IdOrigenAccion = Constantes.Seguridad_Rol
                Log.IdLogAccion = Constantes.Buscar
                LBE.ActualizarLog(Log)
            End If

            oAccountViewModel.TotalRegistros = Total
            oAccountViewModel.DescRegistrosPorPagina = UtilWebGrid.ContadorRegistrosWebGrid(pageIndex, oAccountViewModel.RegistroPorPagina, oAccountViewModel.TotalRegistros)

            If sw Then
                Return PartialView("ConsultarRol_PVGrilla", oAccountViewModel)
            End If

            Return View(oAccountViewModel)
        End Function

        Public Function Agregar() As ActionResult
            Return View()
        End Function

        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()>
        <ValidateAntiForgeryToken()>
        Public Function Agregar(oAccountViewModel As AccountViewModel) As ActionResult
            Dim resultado As Integer = 0
            resultado = ServicioAccountController.AgregarRol(oAccountViewModel.Rol)

            If (resultado = Constantes.ValorUno And SiSeguridad) Then
                Dim LBE As New LogBusinessLogic
                Dim Log As DataContracts.Log = Session("Log")
                Log.DescripcionAccion = "IdRol:" & oAccountViewModel.Rol.IdRol & "|Rol:" & oAccountViewModel.Rol.NombreRol & "|Activo:" & oAccountViewModel.Rol.ActivoRol
                Log.IdOrigenAccion = Constantes.Seguridad_Rol
                Log.IdLogAccion = Constantes.Insertar
                LBE.ActualizarLog(Log)
            End If
            Return Content(Convert.ToString(resultado))
        End Function

        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()>
        Public Function Editar(idRol As Integer) As ActionResult
            Dim oAccountViewModel As New AccountViewModel()
            oAccountViewModel.Rol = ServicioAccountController.ObtenerRolPorId(idRol)
            Return PartialView("Editar", oAccountViewModel)
        End Function

        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()>
        <ValidateAntiForgeryToken()>
        Public Function EditarRol(oAccountViewModel As AccountViewModel) As ActionResult
            Dim resultado As Integer = ServicioAccountController.EditarRol(oAccountViewModel.Rol)

            If (resultado = Constantes.ValorUno And SiSeguridad) Then
                Dim LBE As New LogBusinessLogic
                Dim Log As DataContracts.Log = Session("Log")
                Log.DescripcionAccion = "IdRol:" & oAccountViewModel.Rol.IdRol & "|Rol:" & oAccountViewModel.Rol.NombreRol & "|Activo:" & oAccountViewModel.Rol.ActivoRol
                Log.IdOrigenAccion = Constantes.Seguridad_Rol
                Log.IdLogAccion = Constantes.Modificar
                LBE.ActualizarLog(Log)
            End If
            Return Content(Convert.ToString(resultado))
        End Function

        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()>
        Public Function DesactivarRol(pIdRol As Integer) As ActionResult
            Dim oRol As New Rol()
            oRol.IdRol = pIdRol
            Dim resultado As Integer = ServicioAccountController.DesactivarRol(oRol)

            If (resultado = 1 And SiSeguridad) Then
                Dim LBE As New LogBusinessLogic
                Dim Log As DataContracts.Log = Session("Log")
                Log.DescripcionAccion = "IdRol:" & pIdRol
                Log.IdOrigenAccion = Constantes.Seguridad_Rol
                Log.IdLogAccion = Constantes.Desactivar
                LBE.ActualizarLog(Log)
            End If
            Return Content(Convert.ToString(resultado))
        End Function

        Public Shared oPaginaList As New AccountViewModel()
        Public Shared CPagina As Integer

        Public Function LogOn() As ActionResult
            'If Request.IsAuthenticated Then
            '    Return RedirectToAction("Index", "Home")
            'End If
            Return View()
        End Function
        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()>
        Function ValidarUsuarioBD(Optional ByVal UsuarioUsu As String = "") As ActionResult
            Dim oAccountViewModel As New AccountViewModel()
            Dim oAccountBusinessLogic As New AccountBusinessLogic()
            Dim oUsuarioBusinessLogic As New UsuarioBusinessLogic()
            Dim valornumero As Integer = 0
            Dim resultado As Boolean = False

            'resultado = oUsuarioBusinessLogic.UsuarioExiste(UsuarioUsu)
            resultado = oUsuarioBusinessLogic.BuscarNombre(UsuarioUsu)

            If resultado = True Then
                valornumero = 1
            Else
                valornumero = 0
            End If


            Return Content(valornumero)
        End Function


        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()>
        Function GetUsersByFirstName(Optional ByVal UsuarioUsu As String = "") As ActionResult
            Dim oAccountViewModel As New AccountViewModel()
            Dim oAccountBusinessLogic As New AccountBusinessLogic()
            Dim oUsuarioBusinessLogic As New UsuarioBusinessLogic()
            Dim valornumero As Integer = 0
            Dim resultado As Boolean = False

            'resultado = oUsuarioBusinessLogic.UsuarioExiste(UsuarioUsu)
            resultado = oUsuarioBusinessLogic.ObtenerNombreCompleto(UsuarioUsu)
            If resultado = True Then
                valornumero = 1
            Else
                valornumero = 0
            End If


            Return Content(valornumero)
        End Function


        <HttpPost()>
        Public Function LogOn2(oUsuario As Usuario) As ActionResult
            Try
                Dim oServico As New AccountBusinessLogic()
                Dim valid As Boolean = MembershipService.ValidateUser(oUsuario.UsuarioUsu, oUsuario.PasswordUsu)
                Dim UsuarioUsuVal As Boolean = oServico.ValidaEmpleado_NombreUsuarioUsu(oUsuario.UsuarioUsu)
                Dim IdEmpleadoUsu As Integer = oServico.ValidaEmpleado_NombreUsuarioUsu_(oUsuario.UsuarioUsu)

                If (valid = True And UsuarioUsuVal = True) Then

                    FormsService.SignIn(oUsuario.UsuarioUsu, False)
                    Dim lista As [String]() = Roles.GetRolesForUser(oUsuario.UsuarioUsu)
                    '   Dim dfsmp As New MvcSiteMapProvider.DefaultSiteMapProvider()
                    Session("User") = oUsuario.UsuarioUsu
                    Session("IdEmpUser") = IdEmpleadoUsu

                    Dim Log As DataContracts.Log = New DataContracts.Log
                    Log.Usuario = oUsuario.UsuarioUsu
                    Log.NombrePc = IIf(Request.UserHostName = "::1", System.Net.Dns.GetHostName, Request.UserHostName)
                    Log.MACPc = getMacAddress()
                    Log.TiempoNavegacion = Now.Hour.ToString().PadLeft(2, "0") + ":" + Now.Minute.ToString().PadLeft(2, "0") + ":" + Now.Second.ToString().PadLeft(2, "0")
                    Session("Log") = Log

                    Dim sitemap As New MvcSiteMapProvider.DI.Composer



                    '  dfsmp.Refresh()
                    Return Content("1", "1")
                ElseIf (valid = True And UsuarioUsuVal = False) Then

                    Return Content("3", "3")

                Else
                    Return Content("2", "2")
                End If

            Catch ex As Exception
                Logger.Write(ex)
            End Try
        End Function

        <ValidateAntiForgeryToken(), HttpPost()>
        Public Function LogOn(model As LoginViewModel) As ActionResult
            Try
                If ModelState.IsValid Then
                    If MembershipService.ValidateUser(model.UserName, model.Password) Then
                        Dim accountService As New AccountBusinessLogic()
                        If accountService.ValidaEmpleado_NombreUsuarioUsu(model.UserName) Then
                            Dim lista As [String]() = Roles.GetRolesForUser(model.UserName)
                            Session("User") = model.UserName
                            Session("IdEmpUser") = accountService.ValidaEmpleado_NombreUsuarioUsu_(model.UserName)
                            Session("Rol") = lista(0).ToString()
                            accountService.EditarSesionUsuario(model.UserName)

                            Dim Log As DataContracts.Log = New DataContracts.Log
                            Log.Usuario = model.UserName
                            Log.NombrePc = IIf(Request.UserHostName = "::1", System.Net.Dns.GetHostName, Request.UserHostName)
                            Log.MACPc = getMacAddress()
                            Log.TiempoNavegacion = Now.Hour.ToString().PadLeft(2, "0") + ":" + Now.Minute.ToString().PadLeft(2, "0") + ":" + Now.Second.ToString().PadLeft(2, "0")
                            Session("Log") = Log
                            Dim sitemap As New MvcSiteMapProvider.DI.Composer

                            FormsService.SignIn(model.UserName, False)
                            FormsService.RedirectFromLoginPage(model.UserName, False)
                        Else
                            ModelState.AddModelError("", "Usuario no válido para acceder al sistema.")
                        End If
                    Else
                        ModelState.AddModelError("", "Usuario y/o contraseña no válida.")
                    End If
                End If
            Catch ex As Exception
                Logger.Write(ex)
            End Try
            Return View()
        End Function

        Function getMacAddress()
            Dim nics() As NetworkInterface = NetworkInterface.GetAllNetworkInterfaces()
            Return nics(0).GetPhysicalAddress.ToString
        End Function


        'Public Function IpLocal() As String
        '    Dim strHostName As String
        '    Dim strIPAddress As String

        '    strHostName = System.Net.Dns.GetHostName()
        '    strIPAddress = System.Net.Dns.GetHostByName(strHostName).AddressList(0).ToString()
        '    Return strIPAddress
        'End Function

        <RequiresAuthenticationAttribute()>
        <RequiresAuthorizationAttribute()>
        Public Function AsignarPagina() As ActionResult
            Dim oAccountViewModel As New AccountViewModel()
            oPaginaList.ListaPaginas = ServicioAccountController.BuscarPagina(New Pagina() With {.NombrePagina = "", .PadrePagina = 0})
            oAccountViewModel.ListaNodos = getListarPaginas(oAccountViewModel.ListaPaginas)

            Dim Total As Integer = 0
            oAccountViewModel.RegistroPorPagina = 10
            oAccountViewModel.sortType = If("ASC" = "ASC", "Rol.NombreRol", "Rol.NombreRol" & " DESC")
            oAccountViewModel.startRowIndex = 0
            oAccountViewModel.maximumRows = 10
            oAccountViewModel.Rol = New Rol()
            oAccountViewModel.Rol.NombreRol = ""
            oAccountViewModel.Rol.EstadoId = 0
            oAccountViewModel.ListaRoles = ServicioAccountController.ListarRoles(oAccountViewModel.Rol, oAccountViewModel.sortType, oAccountViewModel.maximumRows, oAccountViewModel.startRowIndex, Total)
            oAccountViewModel.TotalRegistros = Total

            oAccountViewModel.ListaRoles.ForEach(Function(m) m.ActivoRol = False)
            oAccountViewModel.Pagina = New Pagina()
            Return View(oAccountViewModel)
        End Function

        <RequiresAuthenticationAjaxAttribute()>
        Public Function loadTreeView(IdPagina As Integer) As ActionResult
            Dim oAccountViewModel As New AccountViewModel()
            Dim oPagina As New Pagina()
            oAccountViewModel.ListaPaginas = ServicioAccountController.BuscarPagina(oPagina)
            Return PartialView("loadTreeView", oAccountViewModel)
        End Function

        <RequiresAuthenticationAttribute()>
        Public Function PaginaRol_PV_Grilla(Optional codigoPagina As Integer = 0, Optional check As Boolean = False, Optional pNombreRol As [String] = "", Optional pEstadoRol As Integer = 0, Optional sort As [String] = "Rol.NombreRol", Optional page As Integer = 0) As ActionResult

            If codigoPagina <> 0 Then
                CPagina = codigoPagina
            End If

            Dim pageIndex As Integer = page
            Dim oAccountViewModel As New AccountViewModel()
            If page = 0 OrElse page = -1 Then
                oAccountViewModel.Rol = New Rol()
                oAccountViewModel.Rol.NombreRol = pNombreRol
                oAccountViewModel.Rol.EstadoId = pEstadoRol
            End If

            If page <> -1 AndAlso Not (page > 1) Then
                page = 1
            End If

            Dim sw As Boolean = False
            If page = -1 Then
                page = 1
                sw = True
                Session("oAccountViewModel.Rol") = Nothing
            End If

            If oAccountViewModel Is Nothing Then
                oAccountViewModel = New AccountViewModel()
            End If

            If Session("oAccountViewModel.Rol") Is Nothing Then
                Session("oAccountViewModel.Rol") = oAccountViewModel.Rol
            Else
                oAccountViewModel.Rol = DirectCast(Session("oAccountViewModel.Rol"), Rol)
            End If

            Dim Total As Integer

            Dim RolPagina As Integer = 10
            If page = 1 Then
                page = 0
            Else
                page = ((page - 1) * RolPagina) + 1
                RolPagina -= 1
            End If

            oAccountViewModel.RegistroPorPagina = 10
            oAccountViewModel.startRowIndex = page
            oAccountViewModel.maximumRows = RolPagina
            Dim oRol As New Rol()
            oAccountViewModel.Rol.ActivoRol = True
            oAccountViewModel.ListaRoles = ServicioAccountController.BuscarPaginaRol(oAccountViewModel.Rol, CPagina, oAccountViewModel.maximumRows, oAccountViewModel.startRowIndex, Total)
            oAccountViewModel.TotalRegistros = Total
            Dim oPaginaRol As New PaginaRol()
            oPaginaRol.Rol = oAccountViewModel.Rol
            oPaginaRol.Pagina = New Pagina()
            oPaginaRol.Pagina.IdPagina = CPagina

            Dim oListaRolesCheck As ListaRol = ServicioAccountController.ObtenerRolCheckeado(oPaginaRol)
            Dim cadenaRoles As [String] = ""
            Dim count As Integer = 0

            For Each item As Rol In oListaRolesCheck
                If item.ActivoRol = True Then
                    If count = 0 Then
                        cadenaRoles = item.IdRol.ToString()
                    Else
                        cadenaRoles = cadenaRoles & "," & item.IdRol.ToString()
                    End If

                    count += 1

                End If
            Next

            oAccountViewModel.arrayRoles = cadenaRoles

            oAccountViewModel.DescRegistrosPorPagina = UtilWebGrid.ContadorRegistrosWebGrid(pageIndex, oAccountViewModel.RegistroPorPagina, oAccountViewModel.TotalRegistros)

            If sw Then
                Return PartialView("PaginaRol_PV_Grilla", oAccountViewModel)
            End If

            Return View(oAccountViewModel)
        End Function

        <RequiresAuthenticationAjaxAttribute()>
        Private Function getListarPaginas(lst As ListaPagina) As List(Of TreeNode)
            Dim ListaTreeView As New List(Of TreeNode)()

            Dim ListaPadres As List(Of Pagina) = oPaginaList.ListaPaginas.Where(Function(n) n.NivelPagina = 0).ToList()

            For i As Integer = 0 To ListaPadres.Count - 1
                Dim nodoPadre As New TreeNode()
                nodoPadre.Name = ListaPadres(i).NombrePagina
                nodoPadre.Value = ListaPadres(i).IdPagina.ToString()
                nodoPadre.Padre = ListaPadres(i).PadrePagina.ToString()
                nodoPadre.ChildNodes = getListaDeHijos(nodoPadre)
                ListaTreeView.Add(nodoPadre)
            Next

            Return ListaTreeView
        End Function

        <RequiresAuthenticationAjaxAttribute()>
        Public Function getListaDeHijos(nodePadre As TreeNode) As List(Of TreeNode)
            Dim ListaHijos As List(Of Pagina) = oPaginaList.ListaPaginas.Where(Function(c) c.PadrePagina = Convert.ToInt32(nodePadre.Value)).ToList()

            Dim NodosHijos As New List(Of TreeNode)()
            For i As Integer = 0 To ListaHijos.Count - 1
                Dim nodoHijo As New TreeNode()

                nodoHijo.Name = ListaHijos(i).NombrePagina
                nodoHijo.Value = ListaHijos(i).IdPagina.ToString()
                nodoHijo.Padre = ListaHijos(i).PadrePagina.ToString()
                nodoHijo.ChildNodes = getListaDeHijos(nodoHijo)
                NodosHijos.Add(nodoHijo)
            Next
            Return NodosHijos

        End Function

        <RequiresAuthenticationAjaxAttribute()>
        <ValidateAntiForgeryToken()>
        Public Function AsignarPerfil(Optional IdRoles As [String] = "", Optional IdPagina As [String] = "") As ActionResult
            Dim oListaPaginaRol As New ListaPaginaRol()
            If IdRoles.Length <> 0 AndAlso IdPagina.Length <> 0 Then
                For Each item As String In IdRoles.Split(","c)
                    If Not [String].IsNullOrEmpty(item) Then
                        oListaPaginaRol.Add(New PaginaRol() With {
                         .Rol = New Rol() With {
                          .IdRol = Convert.ToInt32(item)
                         },
                         .Pagina = New Pagina() With {
                          .IdPagina = Convert.ToInt32(IdPagina)
                         }
                        })
                    End If
                Next
            End If

            Dim resultado As Integer = ServicioAccountController.AsignarPerfil(oListaPaginaRol)

            If (SiSeguridad And resultado = Constantes.ValorUno) Then
                Dim LBE As New LogBusinessLogic
                Dim Log As DataContracts.Log = Session("Log")
                Log.DescripcionAccion = "IdPagina:" & IdPagina & "|IdRoles:" & IdRoles
                Log.IdOrigenAccion = Constantes.Seguridad_Permisos
                Log.IdLogAccion = Constantes.Asociar
                LBE.ActualizarLog(Log)
            End If

            Dim msjCliente As String = Constantes.ValorDefecto
            Select Case resultado
                Case Constantes.ValorUno
                    msjCliente = Constantes.msjGrabar
                    Exit Select
                Case Else
                    msjCliente = Constantes.msjGrabar
                    Exit Select
            End Select
            Return Content(msjCliente)
        End Function

        Public Property FormsService() As IFormsAuthenticationService
            Get
                Return m_FormsService
            End Get
            Set(value As IFormsAuthenticationService)
                m_FormsService = value
            End Set
        End Property
        Private m_FormsService As IFormsAuthenticationService
        Public Property MembershipService() As IMembershipService
            Get
                Return m_MembershipService
            End Get
            Set(value As IMembershipService)
                m_MembershipService = value
            End Set
        End Property
        Private m_MembershipService As IMembershipService
        Protected Overrides Sub Initialize(requestContext As System.Web.Routing.RequestContext)
            If FormsService Is Nothing Then
                FormsService = New FormsAuthenticationService
            End If
            If MembershipService Is Nothing Then
                MembershipService = New AccountMembershipService
            End If
            MyBase.Initialize(requestContext)
        End Sub

        Public Function LogOff() As ActionResult
            FormsAuthentication.SignOut()
            Session.RemoveAll()
            Return RedirectToAction("LogOn", "Account")
        End Function

        <RequiresAuthenticationAttribute()>
        <RequiresAuthorizationAttribute()>
        Public Function AsignarRol() As ActionResult
            Dim oAccountViewModel As New AccountViewModel()
            oAccountViewModel.Rol = New Rol()
            oAccountViewModel.Rol.ActivoRol = True
            oAccountViewModel.ListaRoles = ServicioAccountController.ObtenerRolesPorEstado(oAccountViewModel.Rol)
            Return View(oAccountViewModel)
        End Function

        <RequiresAuthenticationAttribute()>
        Public Function VistaUsuarioRol(Optional IdRol As Integer = 0) As ActionResult
            Dim oAccountViewModel As New AccountViewModel()
            oAccountViewModel.ListaUsuarios2 = New ListaUsuario()
            If IdRol <> 0 Then
                oAccountViewModel.ListaUsuarios2 = ServicioAccountController.ObtenerUsuarios(0)
            End If

            oAccountViewModel.ListaUsuarios = New ListaUsuario()
            oAccountViewModel.Rol = New Rol()
            oAccountViewModel.Rol.ActivoRol = True
            oAccountViewModel.ListaRoles = ServicioAccountController.ObtenerRolesPorEstado(oAccountViewModel.Rol)
            If IdRol <> 0 Then
                oAccountViewModel.ListaUsuarios = ServicioAccountController.ObtenerUsuarios(IdRol)
            End If

            Dim ListaUsu As List(Of Usuario)
            For i As Integer = 0 To oAccountViewModel.ListaUsuarios.Count - 1
                ListaUsu = oAccountViewModel.ListaUsuarios2.Where(Function(m) m.IdUsu = oAccountViewModel.ListaUsuarios(i).IdUsu).ToList()
                If ListaUsu.Count > 0 Then
                    oAccountViewModel.ListaUsuarios2.Remove(ListaUsu.First())
                End If
            Next

            Return PartialView("LstUsuarios_PV", oAccountViewModel)
        End Function

        <RequiresAuthenticationAjaxAttribute()>
        <ValidateAntiForgeryToken()>
        Public Function AsignarUsuarioRol(Optional idUsuarios As String = "", Optional IdRol As Integer = 0) As ActionResult
            Dim oListaUsuarioRol As New ListaUsuarioRol()
            If idUsuarios.Length <> 0 Then
                For Each item As String In idUsuarios.Split(","c)
                    If Not [String].IsNullOrEmpty(item) Then
                        oListaUsuarioRol.Add(New UsuarioRol() With {
                         .Rol = New Rol() With {
                           .IdRol = Convert.ToInt32(IdRol)
                         },
                          .Usuario = New Usuario() With {
                           .IdUsu = Convert.ToInt32(item)
                         }
                        })
                    End If
                Next
            Else
                oListaUsuarioRol.Add(New UsuarioRol() With {.Rol = New Rol() With {.IdRol = Convert.ToInt32(IdRol)},
                 .Usuario = New Usuario() With {
                  .IdUsu = 0
                 }
                })
            End If

            Dim Resultado As Integer = ServicioAccountController.AsignarRolUsuarios(oListaUsuarioRol)

            If (SiSeguridad And Resultado = Constantes.ValorUno) Then
                Dim LBE As New LogBusinessLogic
                Dim Log As DataContracts.Log = Session("Log")
                Log.DescripcionAccion = "IdRol:" & IdRol & "|IdUsuarios:" & idUsuarios
                Log.IdOrigenAccion = Constantes.Seguridad_Permisos
                Log.IdLogAccion = Constantes.Asignar
                LBE.ActualizarLog(Log)
            End If

            Return Content(Resultado.ToString())
        End Function

        Function ListarEstados() As ServicioComun.ListaTablaGeneral
            Dim oTablaGeneral As ServicioComun.TablaGeneral = New ServicioComun.TablaGeneral
            Dim oListaTablaGeneral As ServicioComun.ListaTablaGeneral = New ServicioComun.ListaTablaGeneral

            oTablaGeneral.DescripcionLargaTabGen = "ACTIVO"
            oTablaGeneral.IdTabGen = 18
            oListaTablaGeneral.Add(oTablaGeneral)

            oTablaGeneral = New ServicioComun.TablaGeneral
            oTablaGeneral.DescripcionLargaTabGen = "INACTIVO"
            oTablaGeneral.IdTabGen = 19
            oListaTablaGeneral.Add(oTablaGeneral)

            Return oListaTablaGeneral
        End Function



    End Class
End Namespace
