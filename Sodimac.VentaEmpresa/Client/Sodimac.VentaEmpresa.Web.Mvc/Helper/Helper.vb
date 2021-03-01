Imports Microsoft.Reporting.WebForms
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports Sodimac.VentaEmpresa.Web.Mvc.DataSet1TableAdapters
Imports Sodimac.VentaEmpresa.Web.Mvc.DataSet1
Imports System.IO

Public Class ExportarExcel

    Public Sub CreateExcelRldc(FileName As String, DataSourceName As String, ArrayReportParameter As [String](), Response As HttpResponseBase)

        Dim ta As New Usp_Reporte_Ventas_ExportarTableAdapter()
        Dim Ds As New DataSet1.Usp_Reporte_Ventas_ExportarDataTable()
        'ta.Adapter.SelectCommand = New SqlCommand
        'ta.Adapter.SelectCommand.CommandTimeout = 60
        ta.CommandTimeout = 120
        ta.Fill(Ds, ArrayReportParameter(0).Split(",")(1).ToString(),
                ArrayReportParameter(1).Split(",")(1).ToString(),
                ArrayReportParameter(2).Split(",")(1).ToString(),
                ArrayReportParameter(3).Split(",")(1).ToString(),
                ArrayReportParameter(4).Split(",")(1).ToString(),
                ArrayReportParameter(5).Split(",")(1).ToString(),
                ArrayReportParameter(6).Split(",")(1).ToString(),
                ArrayReportParameter(7).Split(",")(1).ToString(),
                ArrayReportParameter(8).Split(",")(1).ToString(),
                ArrayReportParameter(9).Split(",")(1).ToString()
                )


        Dim rds As New ReportDataSource(DataSourceName, CType(Ds, DataTable))

        Dim warnings As Warning()
        Dim streamIds As String()
        Dim mimeType As String = String.Empty
        Dim encoding As String = String.Empty
        Dim extension As String = String.Empty

        Dim viewer As New ReportViewer()
        viewer.ProcessingMode = ProcessingMode.Local
        viewer.LocalReport.ReportPath = "Report\" & FileName & ".rdlc"
        'ReportParameter p1 = new ReportParameter("DateNow", DateTime.Now.ToString());
        'ReportParameter p2 = new ReportParameter("Month", Month);
        'viewer.LocalReport.SetParameters(new ReportParameter[] { p1, p2 });
        Dim lstParameter As New List(Of ReportParameter)()

        Dim parameter As New ReportParameter(ArrayReportParameter(0).Split(",")(0).ToString(), ArrayReportParameter(0).Split(",")(1).ToString())
        lstParameter.Add(parameter)

        Dim parameter1 As New ReportParameter(ArrayReportParameter(1).Split(",")(0).ToString(), ArrayReportParameter(1).Split(",")(1).ToString())
        lstParameter.Add(parameter1)

        If lstParameter.Count() > 0 Then
            viewer.LocalReport.SetParameters(lstParameter)
        End If


        viewer.LocalReport.DataSources.Add(rds)

        Dim bytes As Byte() = viewer.LocalReport.Render("EXCELOPENXML", Nothing, mimeType, encoding, extension, streamIds, warnings)

        Response.Buffer = True
        Response.Clear()
        Response.ContentType = mimeType
        Response.AddHeader("content-disposition", "attachment; filename=" & FileName & "." & extension)
        Response.BinaryWrite(bytes)
        Response.Flush()
    End Sub

    Public Function CreateExcelRldcPrueba(ReportPath As String, FileName As String, DataSourceName As String, DataSource As Object, ArrayReportParameter As String(), Response As HttpResponseBase) As Byte()
        Dim rds As New ReportDataSource(DataSourceName, DataSource)
        Dim warnings As Warning()
        Dim streamIds As String()
        Dim mimeType As String
        Dim encoding As String
        Dim extension As String

        Dim viewer As New ReportViewer
        viewer.ProcessingMode = ProcessingMode.Local
        viewer.LocalReport.ReportPath = ReportPath
        Dim lstParameter As New List(Of ReportParameter)()
        For Each item As String In ArrayReportParameter
            Dim parameter As ReportParameter = New ReportParameter(item.Split(",")(0).ToString(), item.Split(",")(1).ToString())
            lstParameter.Add(parameter)
        Next

        If lstParameter.Count() > 0 Then
            viewer.LocalReport.SetParameters(lstParameter)
        End If

        viewer.LocalReport.DataSources.Add(rds)

        'Return viewer.LocalReport.Render("EXCEL", Nothing, mimeType, encoding, extension, streamIds, warnings)
        Return viewer.LocalReport.Render("EXCELOPENXML", Nothing, mimeType, encoding, extension, streamIds, warnings)
    End Function

    Public Sub CreateExcel(ReportPath As String, FileName As String, DataSourcename As String, DataSource As Object, ArrayReportParameter As String(), Response As HttpResponseBase)
        Dim rds = New ReportDataSource(DataSourcename, DataSource)

        Dim warnings As Warning()
        Dim streamIds As String()
        Dim mimeType As String = String.Empty
        Dim encoding As String = String.Empty
        Dim extension As String = String.Empty

        Dim viewer = New ReportViewer()
        viewer.ProcessingMode = ProcessingMode.Local
        viewer.LocalReport.ReportPath = ReportPath
        Dim lstParameter As New List(Of ReportParameter)()
        For Each item As String In ArrayReportParameter
            Dim parameter As ReportParameter = New ReportParameter(item.Split(",")(0).ToString(), item.Split(",")(1).ToString())
            lstParameter.Add(parameter)
        Next

        If lstParameter.Count() > 0 Then
            viewer.LocalReport.SetParameters(lstParameter)
        End If

        viewer.LocalReport.DataSources.Add(rds)
        Dim bytes As Byte() = viewer.LocalReport.Render("Excel", Nothing, mimeType, encoding, extension, streamIds, warnings)

        Response.Buffer = True
        Response.Clear()
        Response.ContentType = mimeType
        Response.AddHeader("content-disposition", "attachment; filename=" & FileName & "." & extension)
        Response.BinaryWrite(bytes)
        Response.Flush()
    End Sub

    Public Sub CrearExcelSave(nameFile As String, reportPath As String, dataSet As String(), dataSource As Object(), typeFile As String, ArrayReportParameter As String())
        Dim mimeType As String
        Dim extension As String
        Dim absolutePath As String = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings("ReportesVVEE"))

        If Directory.Exists(absolutePath) Then

        Else
            Directory.CreateDirectory(absolutePath)
        End If

        Dim bytes As Byte() = ByteFile(reportPath, dataSet, dataSource, typeFile, mimeType, extension, ArrayReportParameter)

        Dim finalPath As String = Path.Combine(absolutePath, nameFile + "." + extension)
        File.WriteAllBytes(finalPath, bytes)
    End Sub

    Private Function ByteFile(reportPath As String, dataSet As String(), dataSource As Object(), format As String, mimeType As String, extension As String, ArrayReportParameter As String()) As Byte()
        Dim report As LocalReport = GetLocalReport()
        report.ReportPath = reportPath
        Dim lstParameter As New List(Of ReportParameter)()
        For Each item As String In ArrayReportParameter
            Dim parameter As ReportParameter = New ReportParameter(item.Split(",")(0).ToString(), item.Split(",")(1).ToString())
            lstParameter.Add(parameter)
        Next

        If lstParameter.Count() > 0 Then
            report.SetParameters(lstParameter)
        End If

        Dim warnings As Warning()
        Dim streamids As String()
        Dim encoding As String
        Dim bytes As Byte() = report.Render(format, Nothing, mimeType, encoding, extension, streamids, warnings)
        Return bytes
    End Function

    Private Function GetLocalReport() As LocalReport
        Dim localReport As LocalReport = New LocalReport()
        If (LocalReport.DataSources.Count > 0) Then
            localReport.DataSources.RemoveAt(0)
        End If
        Return localReport
    End Function

End Class

