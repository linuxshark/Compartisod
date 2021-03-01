Imports System
imports System.Collections.Generic
imports System.Linq
imports System.Web
imports System.Web.UI
imports System.Web.UI.WebControls
imports System.Configuration
Imports Microsoft.Reporting.WebForms
imports System.IO

Public Class GuiasPartialView
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
            If Session("Zona") Is Nothing Or Session("Zona").ToString().CompareTo("") = 0 Then
                Session("Zona") = 0
            End If
            If Session("Correlativo") Is Nothing Or Session("Correlativo").ToString().CompareTo("") = 0 Then
                Session("Correlativo") = 0
            End If
            If Session("TipoPedido") Is Nothing Or Session("TipoPedido").ToString().CompareTo("") = 0 Then
                Session("TipoPedido") = ""
            End If
            If Session("Caja") Is Nothing Or Session("Caja").ToString().CompareTo("") = 0 Then
                Session("Caja") = 0
            End If
            If Session("Vendedor") Is Nothing Or Session("Vendedor").ToString().CompareTo("") = 0 Then
                Session("Vendedor") = ""
            End If

            rvReporteGuia.ServerReport.ReportServerUrl = New Uri(ConfigurationManager.AppSettings("Servidor"))
            rvReporteGuia.ServerReport.ReportPath = ConfigurationManager.AppSettings("Carpeta") + ConfigurationManager.AppSettings("ReporteGuias")
            rvReporteGuia.ServerReport.ReportServerCredentials = New Sodimac.VentaEmpresa.Web.Mvc.CustomReportCredentials(ConfigurationManager.AppSettings("ReportUser"), ConfigurationManager.AppSettings("ReportPassword"), ConfigurationManager.AppSettings("ReportDominio"))

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
            Dim param4 As New ReportParameter("Correlativo", Session("Correlativo").ToString())
            listParam.Add(param4)
            Dim param5 As New ReportParameter("TipoPedido", Session("TipoPedido").ToString())
            listParam.Add(param5)
            Dim param6 As New ReportParameter("Caja", Session("Caja").ToString())
            listParam.Add(param6)
            Dim param7 As New ReportParameter("IdEmpleado", Session("Vendedor").ToString())
            listParam.Add(param7)
            Dim param8 As New ReportParameter("Zona", Session("Zona").ToString())
            listParam.Add(param8)

            rvReporteGuia.ZoomMode = ZoomMode.Percent
            rvReporteGuia.ZoomPercent = 100
            rvReporteGuia.ServerReport.SetParameters(listParam)
            rvReporteGuia.ServerReport.Refresh()
        End If
    End Sub

End Class