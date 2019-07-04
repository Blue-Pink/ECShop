<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Done.aspx.cs" Inherits="UI.Done" %>

<%@ Register Src="~/WebUserControl1.ascx" TagPrefix="uc1" TagName="WebUserControl1" %>
<%@ Register Src="~/WebUserControl2.ascx" TagPrefix="uc1" TagName="WebUserControl2" %>
<%@ Register Src="~/WebUserControl4.ascx" TagPrefix="uc1" TagName="WebUserControl4" %>




<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>ECShop-订单号</title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <uc1:WebUserControl1 runat="server" ID="WebUserControl1" />
    
        <uc1:WebUserControl2 runat="server" ID="WebUserControl2" />
    <!-- 订单信息-->
    <div class="block">
        <div class="box">
            <div class="box_1">
                <h3>
                    <span>系统信息</span></h3>
                <div align="center" class="boxCenterList RelaArticle">
                    <div style="margin: 20px auto;">
                        <p style="font-size: 14px; font-weight: bold; color: red;">
                            订单号:<%=Request.QueryString["OID"] %></p>
                        <div class="blank">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
        <uc1:WebUserControl4 runat="server" ID="WebUserControl4" />
    </form>
</body>
</html>
