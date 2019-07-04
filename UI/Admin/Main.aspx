<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="UI.Admin.Main" %>

<%@ Register Src="~/Admin/Top.ascx" TagPrefix="uc1" TagName="Top" %>
<%@ Register Src="~/Admin/Menu.ascx" TagPrefix="uc1" TagName="Menu" %>
<%@ Register Src="~/Admin/Drag.ascx" TagPrefix="uc1" TagName="Drag" %>


<link href="styles/general.css" rel="stylesheet" type="text/css" />
<link href="styles/main.css" rel="stylesheet" type="text/css" />

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>您好,管理员</title>
</head>
<body>
    <form id="form1" runat="server">
        <uc1:Top runat="server" ID="Top" />
        <div style="width:1850px;height:900px;cursor:default">
            <div style="float:left;height:900px;width:250px" id="divMenu">
                <uc1:Menu runat="server" ID="Menu" />

                <uc1:Drag runat="server" ID="Drag" />
            </div>
            <div style="float: left; width: 1600px;height:900px;background-color:#DDEEF2" id="divMain">
                <h1>
                    <span class="action-span1"><a href="Main.aspx">ECSHOP 管理中心</a>> </span><span
                        id="search_id" class="action-span1"></span>
                    <div style="clear: both">
                    </div>
                </h1>
                <div class="list-div">
                    <table cellspacing='1' cellpadding='3'>
                        <tr>
                            <th colspan="4" class="group-title">订单统计信息
                            </th>
                        </tr>
                        <tr>
                            <td width="20%">新订单:
                            </td>
                            <td width="30%">
                                <strong style="color: red"><%=Bll.Bll_Order.GetRowCount_State(1)%></strong>
                            </td>
                            <td width="20%">确认订单:
                            </td>
                            <td width="30%">
                                <strong><%=Bll.Bll_Order.GetRowCount_State(2) %></strong>
                            </td>
                        </tr>
                        <tr>
                            <td>发货订单:
                            </td>
                            <td>
                                <strong><%=Bll.Bll_Order.GetRowCount_State(3) %></strong>
                            </td>
                            <td>成交订单数:
                            </td>
                            <td>
                                <strong><%=Bll.Bll_Order.GetRowCount_State(4) %></strong>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <br />
        </div>
    </form>
</body>
</html>
