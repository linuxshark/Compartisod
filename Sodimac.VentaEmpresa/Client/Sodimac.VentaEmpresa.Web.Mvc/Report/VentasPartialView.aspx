<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="VentasPartialView.aspx.vb" Inherits="Sodimac.VentaEmpresa.Web.Mvc.VentasPartialView" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <script src="../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../Scripts/View/Reportes.js" type="text/javascript"></script>
    <title></title>
</head>
<body>
    <form id="form2" runat="server">
    <div style="height: 459px"> 
        <rsweb:ReportViewer ID="rvReporteVentas" runat="server" Font-Names="Verdana" 
            Font-Size="8pt" InteractiveDeviceInfos="(Collection)" ProcessingMode="Remote" 
            WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="482px" Width="100%"
            ZoomMode="FullPage" ViewStateMode="Enabled" >
            <ServerReport ReportServerUrl="http://testfile/Reports_SSRS" />
        </rsweb:ReportViewer>
        <asp:ScriptManager ID="ScriptManager2" runat="server" AsyncPostBackTimeout="56000">
        </asp:ScriptManager>
    </div>
    </form>
</body>
</html>

<script type="text/javascript" language="javascript">
    $(window).load(function () {
        $("#rvReporteVentas_ctl05_ctl04_ctl00_Menu div a").each(function (i, element) {
            if (i == 0) {
                
                element.setAttribute("Onclick", "SaveLogExport('PDF',15);$find('rvReporteVentas').exportReport('PDF');");
            } else if (i == 1) {
           
                element.setAttribute("Onclick", "SaveLogExport('Excel',15);$find('rvReporteVentas').exportReport('Excel');");
            }
        });
    });
</script>