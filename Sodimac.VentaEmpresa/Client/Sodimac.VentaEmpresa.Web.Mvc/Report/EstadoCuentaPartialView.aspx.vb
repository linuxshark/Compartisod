Imports Microsoft.Reporting.WebForms

Public Class EstadoCuentaPartialView
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Session("RUC") Is Nothing Or Session("RUC").ToString().CompareTo("") = 0 Then
                Session("RUC") = ""
            End If
            If Session("RazonSocial") Is Nothing Or Session("RazonSocial").ToString().CompareTo("") = 0 Then
                Session("RazonSocial") = ""
            End If
            rvReporteEstadoCuenta.ServerReport.ReportServerUrl = New Uri(ConfigurationManager.AppSettings("Servidor"))
            rvReporteEstadoCuenta.ServerReport.ReportPath = ConfigurationManager.AppSettings("Carpeta") + ConfigurationManager.AppSettings("ReporteEstadoCuenta")
            rvReporteEstadoCuenta.ServerReport.ReportServerCredentials = New Sodimac.VentaEmpresa.Web.Mvc.CustomReportCredentials(ConfigurationManager.AppSettings("ReportUser"), ConfigurationManager.AppSettings("ReportPassword"), ConfigurationManager.AppSettings("ReportDominio"))
            Dim listParam As New List(Of ReportParameter)
            Dim param1 As New ReportParameter("RUC", Session("RUC").ToString())
            listParam.Add(param1)
            Dim param2 As New ReportParameter("RazonSocial", Session("RazonSocial").ToString())
            listParam.Add(param2)
            rvReporteEstadoCuenta.ZoomMode = ZoomMode.Percent
            rvReporteEstadoCuenta.ZoomPercent = 100
            rvReporteEstadoCuenta.ServerReport.SetParameters(listParam)
            rvReporteEstadoCuenta.ServerReport.Refresh()
        End If
    End Sub

End Class