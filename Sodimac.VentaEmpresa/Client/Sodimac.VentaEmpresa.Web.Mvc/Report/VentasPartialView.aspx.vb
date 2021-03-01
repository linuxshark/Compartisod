Imports Sodimac.VentaEmpresa.Web.Mvc
Imports Microsoft.Reporting.WebForms

Public Class VentasPartialView
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            If Session("FechaInicio") Is Nothing Or Session("FechaInicio").ToString().CompareTo("") = 0 Then
                Session("FechaInicio") = Format(DateTime.Now, "yyyy/mm/dd")
            End If
            If Session("FechaFin") Is Nothing Or Session("FechaFin").ToString().CompareTo("") = 0 Then
                Session("FechaFin") = Format(DateTime.Now, "yyyy/mm/dd")
            End If
            If Session("Sucursal") Is Nothing Or Session("Sucursal").ToString().CompareTo("") = 0 Then
                Session("Sucursal") = 0
            End If
            If Session("Ruc") Is Nothing Or Session("Ruc").ToString().CompareTo("") = 0 And Not Int64.TryParse(Session("Ruc").ToString(), 0) Then
                Session("Ruc") = 0
            End If
            If Session("JefeRegional") Is Nothing Or Session("JefeRegional").ToString().CompareTo("") = 0 Then
                Session("JefeRegional") = 0
            End If
            If Session("Vendedor") Is Nothing Or Session("Vendedor").ToString().CompareTo("") = 0 Then
                Session("Vendedor") = 0
            End If
            If Session("TipoCliente") Is Nothing Or Session("TipoCliente").ToString().CompareTo("") = 0 Then
                Session("TipoCliente") = 0
            End If
            If Session("RazonSocial") Is Nothing Or Session("RazonSocial").ToString().CompareTo("") = 0 And Not Int64.TryParse(Session("RazonSocial").ToString(), 0) Then
                Session("RazonSocial") = 0
            End If
            If Session("Zona") Is Nothing Or Session("Zona").ToString().CompareTo("") = 0 Then
                Session("Zona") = 0
            End If
            If Session("IdGrupo") Is Nothing Or Session("IdGrupo").ToString().CompareTo("") = 0 Then
                Session("IdGrupo") = 0
            End If

            rvReporteVentas.ServerReport.ReportServerUrl = New Uri(ConfigurationManager.AppSettings("Servidor"))
            rvReporteVentas.ServerReport.ReportPath = ConfigurationManager.AppSettings("Carpeta") + ConfigurationManager.AppSettings("ReporteVentas")
            rvReporteVentas.ServerReport.ReportServerCredentials = New Sodimac.VentaEmpresa.Web.Mvc.CustomReportCredentials(ConfigurationManager.AppSettings("ReportUser"), ConfigurationManager.AppSettings("ReportPassword"), ConfigurationManager.AppSettings("ReportDominio"))

            Dim DiaFI As String = Session("FechaInicio").ToString().Substring(0, 2)
            Dim MesFI As String = Session("FechaInicio").ToString().Substring(3, 2)
            Dim AnnioFI As String = Session("FechaInicio").ToString().Substring(6, 4)

            Dim DiaFF As String = Session("FechaFin").ToString().Substring(0, 2)
            Dim MesFF As String = Session("FechaFin").ToString().Substring(3, 2)
            Dim AnnioFF As String = Session("FechaFin").ToString().Substring(6, 4)

            Dim FechaIni As String = AnnioFI & MesFI & DiaFI
            Dim FechaFin As String = AnnioFF & MesFF & DiaFF

            Dim listParam As New List(Of ReportParameter)
            Dim param1 As New ReportParameter("FechaInicio", FechaIni)
            listParam.Add(param1)
            Dim param2 As New ReportParameter("FechaFin", FechaFin)
            listParam.Add(param2)
            Dim param3 As New ReportParameter("Sucursal", Session("Sucursal").ToString())
            listParam.Add(param3)
            Dim param4 As New ReportParameter("Ruc", Session("Ruc").ToString())
            listParam.Add(param4)
            Dim param5 As New ReportParameter("JefeRegional", Session("JefeRegional").ToString())
            listParam.Add(param5)
            Dim param6 As New ReportParameter("Vendedor", Session("Vendedor").ToString())
            listParam.Add(param6)
            Dim param7 As New ReportParameter("TipoCliente", Session("TipoCliente").ToString())
            listParam.Add(param7)
            Dim param8 As New ReportParameter("RazonSocial", Session("RazonSocial").ToString())
            listParam.Add(param8)
            Dim param9 As New ReportParameter("Zona", Session("Zona").ToString())
            listParam.Add(param9)
            Dim param10 As New ReportParameter("IdGrupo", Session("IdGrupo").ToString())
            listParam.Add(param10)

            rvReporteVentas.ZoomMode = ZoomMode.Percent
            rvReporteVentas.ZoomPercent = 100
            rvReporteVentas.ServerReport.SetParameters(listParam)
            rvReporteVentas.ServerReport.Refresh()
        End If
    End Sub


End Class
