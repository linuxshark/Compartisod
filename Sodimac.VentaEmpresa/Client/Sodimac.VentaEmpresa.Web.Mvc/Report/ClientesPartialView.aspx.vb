Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Configuration
Imports Microsoft.Reporting.WebForms
Imports System.IO

Public Class ClientesPartialView
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
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
            If Session("TipoCliente") Is Nothing Or Session("TipoCliente").ToString().CompareTo("") = 0 Then
                Session("TipoCliente") = 0
            End If
            If Session("Zona") Is Nothing Or Session("Zona").ToString().CompareTo("") = 0 Then
                Session("Zona") = 0
            End If
            If Session("EstadoLinea") Is Nothing Or Session("EstadoLinea").ToString().CompareTo("") = 0 Then
                Session("EstadoLinea") = 0
            End If
            If Session("Vendedor") Is Nothing Or Session("Vendedor").ToString().CompareTo("") = 0 Then
                Session("Vendedor") = 0
            End If

            rvReporteClientes.ServerReport.ReportServerUrl = New Uri(ConfigurationManager.AppSettings("Servidor"))
            rvReporteClientes.ServerReport.ReportPath = ConfigurationManager.AppSettings("Carpeta") + ConfigurationManager.AppSettings("ReporteClientes")
            rvReporteClientes.ServerReport.ReportServerCredentials = New Sodimac.VentaEmpresa.Web.Mvc.CustomReportCredentials(ConfigurationManager.AppSettings("ReportUser"), ConfigurationManager.AppSettings("ReportPassword"), ConfigurationManager.AppSettings("ReportDominio"))

            Dim listParam As New List(Of ReportParameter)
            Dim param1 As New ReportParameter("Sector", Session("Sector").ToString())
            listParam.Add(param1)
            Dim param2 As New ReportParameter("Categoria", Session("Categoria").ToString())
            listParam.Add(param2)
            Dim param3 As New ReportParameter("FormaPago", Session("FormaPago").ToString())
            listParam.Add(param3)
            Dim param4 As New ReportParameter("Sucursal", Session("Sucursal").ToString())
            listParam.Add(param4)
            Dim param5 As New ReportParameter("TipoCliente", Session("TipoCliente").ToString())
            listParam.Add(param5)
            Dim param6 As New ReportParameter("Zona", Session("Zona").ToString())
            listParam.Add(param6)
            Dim param7 As New ReportParameter("EstadoLinea", Session("EstadoLinea").ToString())
            listParam.Add(param7)
            Dim param8 As New ReportParameter("Vendedor", Session("Vendedor").ToString())
            listParam.Add(param8)
            rvReporteClientes.ZoomMode = ZoomMode.Percent
            rvReporteClientes.ZoomPercent = 100
            rvReporteClientes.ServerReport.SetParameters(listParam)
            rvReporteClientes.ServerReport.Refresh()
        End If
    End Sub

End Class