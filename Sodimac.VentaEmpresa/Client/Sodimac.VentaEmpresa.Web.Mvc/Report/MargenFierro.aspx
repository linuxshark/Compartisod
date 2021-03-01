<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="MargenFierro.aspx.vb" Inherits="Sodimac.VentaEmpresa.Web.Mvc.MargenFierro" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 278px">
    <form id="form1" runat="server">
        <div style="height: 292px">
            <rsweb:reportviewer id="rvMargenFierro" runat="server" font-names="Verdana"
                font-size="8pt" interactivedeviceinfos="(Collection)" processingmode="Remote"
                waitmessagefont-names="Verdana" waitmessagefont-size="14pt" height="482px" width="100%"
                zoommode="FullPage" viewstatemode="Enabled">
                <ServerReport ReportServerUrl="http://testfile/Reports_SSRS" />
            </rsweb:reportviewer>
            <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="300">
            </asp:ScriptManager>
        </div>
    </form>
</body>
</html>
