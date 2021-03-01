Imports System
imports System.Collections.Generic
imports System.Linq
imports System.Web
imports System.Web.UI
imports System.Web.UI.WebControls
imports System.Configuration
Imports Microsoft.Reporting.WebForms
Imports System.IO
Imports Sodimac.VentaEmpresa.Common

Public Class ComisionesPartialView
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

            rvReporteComisiones.ServerReport.ReportServerUrl = New Uri(ConfigurationManager.AppSettings("Servidor"))
            rvReporteComisiones.ServerReport.ReportPath = ConfigurationManager.AppSettings("Carpeta") + ConfigurationManager.AppSettings("ReporteComisiones")
            rvReporteComisiones.ServerReport.ReportServerCredentials = New Sodimac.VentaEmpresa.Web.Mvc.CustomReportCredentials(ConfigurationManager.AppSettings("ReportUser"), ConfigurationManager.AppSettings("ReportPassword"), ConfigurationManager.AppSettings("ReportDominio"))

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

            rvReporteComisiones.ZoomMode = ZoomMode.Percent
            rvReporteComisiones.ZoomPercent = 100
            rvReporteComisiones.ServerReport.SetParameters(listParam)
            rvReporteComisiones.ServerReport.Refresh()
        End If
    End Sub

End Class
