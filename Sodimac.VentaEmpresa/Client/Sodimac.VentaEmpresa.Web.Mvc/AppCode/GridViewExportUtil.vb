Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.IO
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Drawing

Public Class GridViewExportUtil
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="fileName"></param>
    ''' <param name="gv"></param>
    Public Shared Function Export(fileName As String, gv As GridView, _tableStyle As TableStyle, _headerStyle As TableItemStyle) As StringWriter
        HttpContext.Current.Response.Clear()
        HttpContext.Current.Response.AddHeader("content-disposition", String.Format("attachment; filename={0}", fileName))
        HttpContext.Current.Response.ContentType = "application/ms-excel"

        Using sw As New StringWriter()
            Using htw As New HtmlTextWriter(sw)
                Dim table As New Table()

                If gv.HeaderRow IsNot Nothing Then
                    GridViewExportUtil.PrepareControlForExport(gv.HeaderRow)
                    table.Rows.Add(gv.HeaderRow)
                End If

                For Each row As GridViewRow In gv.Rows
                    GridViewExportUtil.PrepareControlForExport(row)

                    table.Rows.Add(row)
                Next

                If gv.FooterRow IsNot Nothing Then
                    GridViewExportUtil.PrepareControlForExport(gv.FooterRow)
                    table.Rows.Add(gv.FooterRow)
                End If

                table.RenderControl(htw)

                HttpContext.Current.Response.Write(sw.ToString())
                HttpContext.Current.Response.[End]()
                Return sw
            End Using
        End Using
    End Function

    ''' <summary>
    ''' Replace any of the contained controls with literals
    ''' </summary>
    ''' <param name="control"></param>
    Private Shared Sub PrepareControlForExport(control As Control)
        For i As Integer = 0 To control.Controls.Count - 1
            Dim current As Control = control.Controls(i)
            If TypeOf current Is LinkButton Then
                control.Controls.Remove(current)
                control.Controls.AddAt(i, New LiteralControl(TryCast(current, LinkButton).Text))
            ElseIf TypeOf current Is ImageButton Then
                control.Controls.Remove(current)
                control.Controls.AddAt(i, New LiteralControl(TryCast(current, ImageButton).AlternateText))
            ElseIf TypeOf current Is HyperLink Then
                control.Controls.Remove(current)
                control.Controls.AddAt(i, New LiteralControl(TryCast(current, HyperLink).Text))
            ElseIf TypeOf current Is DropDownList Then
                control.Controls.Remove(current)
                control.Controls.AddAt(i, New LiteralControl(TryCast(current, DropDownList).SelectedItem.Text))
            ElseIf TypeOf current Is CheckBox Then
                control.Controls.Remove(current)
                control.Controls.AddAt(i, New LiteralControl(If(TryCast(current, CheckBox).Checked, "True", "False")))
            End If

            If current.HasControls() Then
                GridViewExportUtil.PrepareControlForExport(current)
            End If
        Next
    End Sub


    Public Shared Sub ExportText(fileName As String, str As [String], Response As System.Web.HttpResponseBase)
        Using sw As New StringWriter()
            Using htw As New HtmlTextWriter(sw)
                Response.Clear()
                Response.AddHeader("content-disposition", String.Format("attachment; filename={0}", fileName))
                Response.ContentType = "text/plain"
                Response.ContentEncoding = System.Text.Encoding.UTF8
                Response.Write(str)
                Response.[End]()
            End Using
        End Using
    End Sub


    Public Shared Sub Export(fileName As String, gv As GridView, Response As System.Web.HttpResponseBase)
        Dim strHeader As [String], strFooter As [String]
        Using sw As New StringWriter()
            Using htw As New HtmlTextWriter(sw)
                strHeader = "<HTML><HEAD><meta http-equiv=Content-Type content='application/ms-excel; charset=utf-8'></HEAD><BODY>"
                strFooter = "</BODY></HTML>"
                Response.Clear()
                Response.AddHeader("content-disposition", String.Format("attachment; filename={0}", fileName))
                Response.ContentType = "application/ms-excel"
                Response.ContentEncoding = System.Text.Encoding.UTF8

                gv.HeaderStyle.Font.Name = "Arial"
                gv.HeaderStyle.Font.Bold = True
                gv.HeaderStyle.Font.Size = System.Web.UI.WebControls.FontUnit.Point(9)
                gv.HeaderStyle.HorizontalAlign = HorizontalAlign.Center

                gv.RowStyle.Font.Name = "Arial"
                gv.RowStyle.BackColor = Color.White
                gv.RowStyle.Font.Size = System.Web.UI.WebControls.FontUnit.Point(8)

                gv.RenderControl(htw)

                strHeader = strHeader + sw.ToString() + "<br><br>" & strFooter
                Response.Write(strHeader)
                Response.[End]()
            End Using
        End Using
    End Sub

    Public Shared Function TransformarCadena(Cadena As String) As String
        Dim i As Integer
        Dim sTemp As String = ""

        For i = 0 To (Cadena.Length) - 1
            Select Case (Cadena.Substring(i, 1))
                Case "á"
                    sTemp = sTemp & "á"
                    Exit Select
                Case "é"
                    sTemp = sTemp & "é"
                    Exit Select
                Case "í"
                    sTemp = sTemp & "í"
                    Exit Select
                Case "ó"
                    sTemp = sTemp & "ó"
                    Exit Select
                Case "ú"
                    sTemp = sTemp & "ú"
                    Exit Select
                Case "Á"
                    sTemp = sTemp & "Á"
                    Exit Select
                Case "É"
                    sTemp = sTemp & "É"
                    Exit Select
                Case "Í"
                    sTemp = sTemp & "Í"
                    Exit Select
                Case "Ó"
                    sTemp = sTemp & "Ó"
                    Exit Select
                Case "Ú"
                    sTemp = sTemp & "Ú"
                    Exit Select
                Case "ñ"
                    sTemp = sTemp & "ñ"
                    Exit Select
                Case "Ñ"
                    sTemp = sTemp & "Ñ"
                    Exit Select
                Case Else
                    sTemp = sTemp & (Cadena.Substring(i, 1))
                    Exit Select
            End Select
        Next
        Return sTemp
    End Function


End Class
