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
Public Class LogPartialView
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Session("FechaInicio") Is Nothing Or Session("FechaInicio").ToString().CompareTo("") = 0 Then
                Session("FechaInicio") = Format(DateTime.Now, "yyyy/mm/dd")
            End If
            If Session("FechaFin") Is Nothing Or Session("FechaFin").ToString().CompareTo("") = 0 Then
                Session("FechaFin") = Format(DateTime.Now, "yyyy/mm/dd")
            End If
            If Session("LogAccion") Is Nothing Or Session("LogAccion").ToString().CompareTo("") = 0 Then
                Session("LogAccion") = Constantes.Clear
            End If
            If Session("OrigenAccion") Is Nothing Or Session("OrigenAccion").ToString().CompareTo("") = 0 Then
                Session("OrigenAccion") = Constantes.Clear
            End If

            rvReporteLog.ServerReport.ReportServerUrl = New Uri(ConfigurationManager.AppSettings("Servidor"))
            rvReporteLog.ServerReport.ReportPath = ConfigurationManager.AppSettings("Carpeta") + ConfigurationManager.AppSettings("ReporteLog")
            rvReporteLog.ServerReport.ReportServerCredentials = New Sodimac.VentaEmpresa.Web.Mvc.CustomReportCredentials(ConfigurationManager.AppSettings("ReportUser"), ConfigurationManager.AppSettings("ReportPassword"), ConfigurationManager.AppSettings("ReportDominio"))

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
            Dim param3 As New ReportParameter("IdsLogAccion", Session("LogAccion").ToString())
            listParam.Add(param3)
            Dim param4 As New ReportParameter("IdsOrigenAccion", Session("OrigenAccion").ToString())
            listParam.Add(param4)

            rvReporteLog.ServerReport.SetParameters(listParam)
            rvReporteLog.ServerReport.Refresh()
        End If
    End Sub

End Class