<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Flow.aspx.cs" Inherits="UI.Flow" %>

<%@ Register Src="~/WebUserControl1.ascx" TagPrefix="uc1" TagName="WebUserControl1" %>
<%@ Register Src="~/WebUserControl2.ascx" TagPrefix="uc1" TagName="WebUserControl2" %>
<%@ Register Src="~/WebUserControl4.ascx" TagPrefix="uc1" TagName="WebUserControl4" %>




<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>ECShop-购物车</title>
    <style type="text/css">
        .auto-style1 {
            width: 52px;
            text-align: center;
            line-height: 21px;
            color: #fff;
            cursor: pointer;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            margin-left: 730px;
            background: url('images/bg.gif') no-repeat 0px 0px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <uc1:WebUserControl1 runat="server" ID="WebUserControl1" />
        <uc1:WebUserControl2 runat="server" ID="WebUserControl2" />
        <div class="block">
            <div class="flowBox">
                <h6><span>商品列表&nbsp&nbsp&nbsp
                    <asp:CheckBox ID="CheckBox2" runat="server" Text="全选" AutoPostBack="true" OnCheckedChanged="CheckBox2_CheckedChanged" />
                    <asp:Button ID="Button1" runat="server" Text="保存" CssClass="auto-style1" OnClick="Button1_Click" style="height: 17px"/>
                    </span></h6>

                <table align="center" width="99%" cellspacing="1" cellpadding="5" border="0" bgcolor="#dddddd">
                    <tbody>
                        <tr>
                            <th bgcolor="#ffffff">商品名称
                            </th>
                            <th bgcolor="#ffffff">价格
                            </th>
                            <th bgcolor="#ffffff">购买数量
                            </th>
                            <th bgcolor="#ffffff">小计
                            </th>
                            <th bgcolor="#ffffff">操作
                            </th>

                        </tr>
                        <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
                            <ItemTemplate>
                                <tr>
                                    <td align="center" bgcolor="#ffffff">
                                        <asp:Label ID="Label2" runat="server" Text='<%#Eval("TID") %>' Visible="false"></asp:Label>
                                        <asp:CheckBox ID="CheckBox1" runat="server" />
                                        <a href="Goods.aspx?BID=<%#Eval("BID") %>"><img border="0" width="100px" height="100px;" title="<%#Eval("BName") %>" src="BookImages/<%#Eval("BPic") %>"></a><br>
                                        <%#Eval("BName") %>
                                    </td>
                                    <td align="right" bgcolor="#ffffff">￥<%#Eval("BPrice") %>元
                                    </td>
                                    <td align="right" bgcolor="#ffffff">
                                        <asp:TextBox ID="TextBox1" runat="server" Width="40" Text='<%#Eval("BCount") %>' CssClass="inputBg" onkeyup="value=value.replace(/^(0+)|[^\d]+/g,'')"></asp:TextBox>
                                    </td>
                                    <td align="right" bgcolor="#ffffff">￥<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>元
                                    </td>
                                    <td align="center" bgcolor="#ffffff">
                                        <a class="f6" href="javascript:if (confirm('您确实要把该商品移出购物车吗？')){location.href='DeleteTrade.aspx?TID=<%#Eval("TID") %>'}">删除</a>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>


                <table align="center" width="99%" cellspacing="0" cellpadding="5" border="0" bgcolor="#dddddd">
                    <tbody>
                        <tr>
                            <td align="right" bgcolor="#ffffff">
                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="images/checkout.gif" OnClick="ImageButton1_Click" />
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div class="blank5">
            </div>
        </div>
        <uc1:WebUserControl4 runat="server" ID="WebUserControl4" />
    </form>
</body>
</html>
