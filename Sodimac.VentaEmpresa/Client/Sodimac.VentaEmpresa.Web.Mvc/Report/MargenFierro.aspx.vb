Imports Microsoft.Reporting.WebForms

Public Class MargenFierro
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'If Session("FechaInicio") Is Nothing Or Session("FechaInicio").ToString().CompareTo("") = 0 Then
            '    Session("FechaInicio") = Format(DateTime.Now, "yyyy/mm/dd")
            'End If
            'If Session("FechaFin") Is Nothing Or Session("FechaFin").ToString().CompareTo("") = 0 Then
            '    Session("FechaFin") = Format(DateTime.Now, "yyyy/mm/dd")
            'End If
            'If Session("Sucursal") Is Nothing Or Session("Sucursal").ToString().CompareTo("") = 0 Then
            '    Session("Sucursal") = 0
            'End If
            'If Session("Zona") Is Nothing Or Session("Zona").ToString().CompareTo("") = 0 Then
            '    Session("Zona") = 0
            'End If
            rvMargenFierro.AsyncRendering = False

            rvMargenFierro.ServerReport.ReportServerUrl = New Uri(ConfigurationManager.AppSettings("Servidor"))
            rvMargenFierro.ServerReport.ReportPath = ConfigurationManager.AppSettings("Carpeta") + ConfigurationManager.AppSettings("ReporteMargenFierro")
            rvMargenFierro.ServerReport.ReportServerCredentials = New Sodimac.VentaEmpresa.Web.Mvc.CustomReportCredentials(ConfigurationManager.AppSettings("ReportUser"), ConfigurationManager.AppSettings("ReportPassword"), ConfigurationManager.AppSettings("ReportDominio"))

            'Dim DiaFI As String = Session("FechaInicio").ToString().Substring(0, 2)
            'Dim MesFI As String = Session("FechaInicio").ToString().Substring(3, 2)
            'Dim AnnioFI As String = Session("FechaInicio").ToString().Substring(6, 4)

            'Dim DiaFF As String = Session("FechaFin").ToString().Substring(0, 2)
            'Dim MesFF As String = Session("FechaFin").ToString().Substring(3, 2)
            'Dim AnnioFF As String = Session("FechaFin").ToString().Substring(6, 4)

            'Dim FechaIni As String = AnnioFI & MesFI & DiaFI
            'Dim FechaFin As String = AnnioFF & MesFF & DiaFF

            Dim listParam As New List(Of ReportParameter)
            listParam.Add(New ReportParameter("FECHAI", Session("FECHAI").ToString()))
            listParam.Add(New ReportParameter("FECHAF", Session("FECHAF").ToString()))
            listParam.Add(New ReportParameter("IdEmpresa", Session("IdEmpresa").ToString()))
            listParam.Add(New ReportParameter("IdSucursal", Session("IdSucursal").ToString()))
            listParam.Add(New ReportParameter("Sku", Session("Sku").ToString()))
            listParam.Add(New ReportParameter("TipoCaja", Session("TipoCaja").ToString()))

            rvMargenFierro.ZoomMode = ZoomMode.Percent
            rvMargenFierro.ZoomPercent = 100
            rvMargenFierro.ServerReport.SetParameters(listParam)
            rvMargenFierro.ServerReport.Refresh()

        End If
    End Sub

End Class