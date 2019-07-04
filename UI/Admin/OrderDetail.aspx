<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderDetail.aspx.cs" Inherits="UI.Admin.OrderDetail" %>

<%@ Register Src="~/Admin/Top.ascx" TagPrefix="uc1" TagName="Top" %>
<%@ Register Src="~/Admin/Menu.ascx" TagPrefix="uc1" TagName="Menu" %>
<%@ Register Src="~/Admin/Drag.ascx" TagPrefix="uc1" TagName="Drag" %>

<link href="styles/general.css" rel="stylesheet" type="text/css" />
<link href="styles/main.css" rel="stylesheet" type="text/css" />
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>订单详情</title>
    <style type="text/css">
        .auto-style1 {
            height: 29px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <uc1:top runat="server" id="Top1" />
        <div style="width: 1850px; height: 900px; cursor: default">
            <div style="float: left; height: 900px; width: 250px" id="divMenu">
                <uc1:menu runat="server" id="Menu" />

                <uc1:drag runat="server" id="Drag" />
            </div>
            <div style="float: left; width: 1600px; height: 900px; background-color: #DDEEF2" id="divMain">

    <h1>
        <span class="action-span"><a href="Orders.aspx">订单列表</a></span> <span class="action-span1">
            <a href="Main.aspx">ECSHOP 管理中心</a> </span><span id="search_id" class="action-span1">
                - 订单信息 </span>
        <div style="clear: both">
        </div>
    </h1>
    <div class="list-div" style="margin-bottom: 5px">
        <table width="100%" cellpadding="3" cellspacing="1">
            <tr>
                <th colspan="4">
                    收货信息
                </th>
            </tr>
            <tr>
                <td width="18%">
                    <div align="right">
                        <strong>订单号：</strong></div>
                </td>
                <td width="34%">
                   <%=Request.QueryString["OID"] %>
                </td>
                <td width="15%">
                    <div align="right">
                        <strong>订单状态：</strong></div>
                </td>
                <%Model.Order order = Bll.Bll_Order.Select_OID(Request.QueryString["OID"].ToString())[0];%>
                <td>
                    <%=Enum.Parse(typeof(Model.Order.enumOState),order.OState) %>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <div align="right">
                        <strong>收货人：</strong></div>
                </td>
                <td class="auto-style1">
                    <%=order.OConsignee %>
                </td>
                <td class="auto-style1">
                    <div align="right">
                        <strong>订单时间：</strong></div>
                </td>
                <td class="auto-style1">
                    <%=order.ODate %>
                </td>
            </tr>
            <tr>
                <td>
                    <div align="right">
                        <strong>送货地址：</strong></div>
                </td>
                <td>
                    <%=order.OAddress %>
                </td>
                <td>
                    <div align="right">
                        <strong>联系电话：</strong></div>
                </td>
                <td>
                    <%=order.OTelephone %>
                </td>
            </tr>
        </table>
    </div>
    <div class="list-div" style="margin-bottom: 5px">
        <table width="100%" cellpadding="3" cellspacing="1">
            <tr>
                <th colspan="4" scope="col">
                    商品信息
                </th>
            </tr>
            <tr>
                <td scope="col">
                    <div align="center">
                        <strong>订单号</strong></div>
                </td>
                <td scope="col">
                    <div align="center">
                        <strong>书籍编号</strong></div>
                </td>
                <td scope="col">
                    <div align="center">
                        <strong>价格</strong></div>
                </td>
                <td scope="col">
                    <div align="center">
                        <strong>数量</strong></div>
                </td>
            </tr>
            <%--<tr>
                <td align="center">
                    DD20120305
                </td>
                <td align="center">
                    4939
                </td>
                <td>
                    <div align="right">
                        ￥50.00元</div>
                </td>
                <td>
                    <div align="right">
                        1
                    </div>
                </td>
            </tr>
            <tr>
                <td align="center">
                    DD20120305
                </td>
                <td align="center">
                    4942
                </td>
                <td>
                    <div align="right">
                        ￥50.00元</div>
                </td>
                <td>
                    <div align="right">
                        1
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    <div align="right">
                        <strong>合计：</strong></div>
                </td>
                <td>
                    <div align="right">
                        ￥100.00元</div>
                </td>
            </tr>--%>

            <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
                <ItemTemplate>
                    <tr>
                <td align="center">
                    <%#Eval("OID") %>
                </td>
                <td align="center">
                    <%#Eval("BID") %>
                </td>
                <td>
                    <div align="center">
                        ￥<%#Eval("BPrice") %>元</div>
                </td>
                <td>
                    <div align="center">
                        <%#Eval("BCount") %>
                    </div>
                </td>
            </tr>
                </ItemTemplate>
            </asp:Repeater>
            <tr><td colspan="4" style="text-align:right">总消费:<%=total %></td></tr>
        </table>
    </div>

            </div>
        </div>
    </form>
</body>
</html>
