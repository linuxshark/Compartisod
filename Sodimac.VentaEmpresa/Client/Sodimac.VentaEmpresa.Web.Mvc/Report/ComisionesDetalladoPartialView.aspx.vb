Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Configuration
Imports Microsoft.Reporting.WebForms
Imports System.IO
Imports Sodimac.VentaEmpresa.Common
Public Class ComisionesDetalladoPartialView
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Session("FechaInicio") Is Nothing Then
                Session("FechaInicio") = Constantes.FechaDefecto
            End If
            If Session("FechaFin") Is Nothing Then
                Session("FechaFin") = Constantes.FechaDefecto
            End If
            If Session("Sucursal") Is Nothing Or Session("Sucursal").ToString().CompareTo("") = 0 Then
                Session("Sucursal") = 0
            End If
            If Session("Zona") Is Nothing Or Session("Zona").ToString().CompareTo("") = 0 Then
                Session("Zona") = 0
            End If
            If Session("IdRRVV") Is Nothing Or Session("IdRRVV").ToString().CompareTo("") = 0 Then
                Session("IdRRVV") = 0
            End If
            If Session("IdJefe") Is Nothing Or Session("IdJefe").ToString().CompareTo("") = 0 Then
                Session("IdJefe") = 0
            End If

            rvReporteComisionesDetallado.ServerReport.ReportServerUrl = New Uri(ConfigurationManager.AppSettings("Servidor"))
            rvReporteComisionesDetallado.ServerReport.ReportPath = ConfigurationManager.AppSettings("Carpeta") + ConfigurationManager.AppSettings("ReporteComisionesDetallado")
            rvReporteComisionesDetallado.ServerReport.ReportServerCredentials = New Sodimac.VentaEmpresa.Web.Mvc.CustomReportCredentials(ConfigurationManager.AppSettings("ReportUser"), ConfigurationManager.AppSettings("ReportPassword"), ConfigurationManager.AppSettings("ReportDominio"))

            Dim FechaIni As String = Format(DateTime.Parse(Session("FechaInicio").ToString()), "yyyyMMdd")
            Dim FechaFin As String = Format(DateTime.Parse(Session("FechaFin").ToString()), "yyyyMMdd")

            Dim listParam As New List(Of ReportParameter)
            Dim param1 As New ReportParameter("Sucursal", Session("Sucursal").ToString())
            listParam.Add(param1)
            Dim param2 As New ReportParameter("Zona", Session("Zona").ToString())
            listParam.Add(param2)
            Dim param3 As New ReportParameter("FechaInicio", FechaIni)
            listParam.Add(param3)
            Dim param4 As New ReportParameter("FechaFin", FechaFin)
            listParam.Add(param4)
            Dim param5 As New ReportParameter("IdRRVV", Session("IdRRVV").ToString())
            listParam.Add(param5)
            Dim param6 As New ReportParameter("IdJefe", Session("IdJefe").ToString())
            listParam.Add(param6)

            rvReporteComisionesDetallado.ZoomMode = ZoomMode.Percent
            rvReporteComisionesDetallado.ZoomPercent = 100
            rvReporteComisionesDetallado.ServerReport.SetParameters(listParam)
            rvReporteComisionesDetallado.ServerReport.Refresh()
        End If
    End Sub

End Class