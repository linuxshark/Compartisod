<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ClientesPartialView.aspx.vb" Inherits="Sodimac.VentaEmpresa.Web.Mvc.ClientesPartialView" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <script src="../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
        <script src="../Scripts/View/Reportes.js" type="text/javascript"></script>
        <title></title>
    </head>
    <body style="height: 278px">
        <form id="form1" runat="server">
        <div style="height: 292px">
            <rsweb:ReportViewer ID="rvReporteClientes" runat="server" Font-Names="Verdana" 
                Font-Size="8pt" InteractiveDeviceInfos="(Collection)" ProcessingMode="Remote" 
                WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="482px" Width="100%"
                ZoomMode="FullPage" ViewStateMode="Enabled">
                <ServerReport ReportServerUrl="http://testfile/Reports_SSRS" />
            </rsweb:ReportViewer>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
        </div>
        </form>     
    </body>
</html>

<script type="text/javascript" language="javascript">
    $(window).load(function () {
        $("#rvReporteClientes_ctl05_ctl04_ctl00_Menu div a").each(function (i, element) {
            if (i == 0) {
                element.setAttribute("Onclick", "SaveLogExport('PDF',20);$find('rvReporteClientes').exportReport('PDF');");
            } else if (i == 1) {
                element.setAttribute("Onclick", "SaveLogExport('Excel',20);$find('rvReporteClientes').exportReport('Excel');");
            }
        });
    });
</script>





