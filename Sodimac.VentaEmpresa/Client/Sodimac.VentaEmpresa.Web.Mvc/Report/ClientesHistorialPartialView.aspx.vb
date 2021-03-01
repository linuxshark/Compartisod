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

Public Class ClientesHistorialPartialView
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Session("FechaInicio") Is Nothing Then
                Session("FechaInicio") = Constantes.FechaDefecto
            End If
            If Session("FechaFin") Is Nothing Then
                Session("FechaFin") = Constantes.FechaDefecto
            End If
            If Session("Sector") Is Nothing Or Session("Sector").ToString().CompareTo("") = 0 Then
                Session("Sector") = 0
            End If
            If Session("Categoria") Is Nothing Or Session("Categoria").ToString().CompareTo("") = 0 Then
                Session("Categoria") = 0
            End If
            If Session("FormaPago") Is Nothing Or Session("FormaPago").ToString().CompareTo("") = 0 Then
                Session("FormaPago") = 0
            End If
            If Session("Sucursal") Is Nothing Or Session("Sucursal").ToString().CompareTo("") = 0 Then
                Session("Sucursal") = 0
            End If
            If Session("Zona") Is Nothing Or Session("Zona").ToString().CompareTo("") = 0 Then
                Session("Zona") = 0
            End If
            If Session("RazonSocial") Is Nothing Or Session("RazonSocial").ToString().CompareTo("") = 0 Then
                Session("RazonSocial") = Constantes.Clear
            End If

            rvReporteClientesHistorial.ServerReport.ReportServerUrl = New Uri(ConfigurationManager.AppSettings("Servidor"))
            rvReporteClientesHistorial.ServerReport.ReportPath = ConfigurationManager.AppSettings("Carpeta") + ConfigurationManager.AppSettings("ReporteClientesHistorial")
            rvReporteClientesHistorial.ServerReport.ReportServerCredentials = New Sodimac.VentaEmpresa.Web.Mvc.CustomReportCredentials(ConfigurationManager.AppSettings("ReportUser"), ConfigurationManager.AppSettings("ReportPassword"), ConfigurationManager.AppSettings("ReportDominio"))

            Dim listParam As New List(Of ReportParameter)
            Dim param1 As New ReportParameter("FechaInicio", Session("FechaInicio").ToString())
            listParam.Add(param1)
            Dim param2 As New ReportParameter("FechaFin", Session("FechaFin").ToString())
            listParam.Add(param2)
            Dim param3 As New ReportParameter("Sector", Session("Sector").ToString())
            listParam.Add(param3)
            Dim param4 As New ReportParameter("Categoria", Session("Categoria").ToString())
            listParam.Add(param4)
            Dim param5 As New ReportParameter("FormaPago", Session("FormaPago").ToString())
            listParam.Add(param5)
            Dim param6 As New ReportParameter("Sucursal", Session("Sucursal").ToString())
            listParam.Add(param6)
            Dim param7 As New ReportParameter("Zona", Session("Zona").ToString())
            listParam.Add(param7)
            Dim param8 As New ReportParameter("RazonSocial", Session("RazonSocial").ToString())
            listParam.Add(param8)

            rvReporteClientesHistorial.ServerReport.SetParameters(listParam)
            rvReporteClientesHistorial.ServerReport.Refresh()
        End If
    End Sub

End Class