<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Consignee.aspx.cs" Inherits="UI.Consignee" %>

<%@ Register Src="~/WebUserControl1.ascx" TagPrefix="uc1" TagName="WebUserControl1" %>
<%@ Register Src="~/WebUserControl2.ascx" TagPrefix="uc1" TagName="WebUserControl2" %>
<%@ Register Src="~/WebUserControl4.ascx" TagPrefix="uc1" TagName="WebUserControl4" %>




<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>ECShop-订单提交</title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <uc1:WebUserControl1 runat="server" ID="WebUserControl1" />
        <uc1:WebUserControl2 runat="server" ID="WebUserControl2" />
        <!--购物车信息-->
        <div class="block">
            <div class="flowBox">
                <h6>
                    <span>商品列表</span></h6>

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
                        </tr>
                        <asp:Repeater ID="Repeater1" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td align="center" bgcolor="#ffffff">
                                        <img border="0" width="100px" height="100px;" title="<%#Eval("BName") %>" src="BookImages/<%#Eval("BPic") %>"><br>
                                        <%#Eval("BName") %>
                                    </td>
                                    <td align="right" bgcolor="#ffffff">￥<%#Eval("BPrice") %>元
                                    </td>
                                    <td align="right" bgcolor="#ffffff"><%#Eval("BCount") %>
                                    </td>
                                    <td align="right" bgcolor="#ffffff">￥<%#Convert.ToInt32(Eval("BPrice"))*Convert.ToInt32(Eval("BCount")) %>元
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>

            </div>
            <div class="blank5">
            </div>
        </div>
        <!-- 地区信息-->
        <div class="block">
            <div class="flowBox">
                <h6>
                    <span>收货人信息</span></h6>
                <table align="center" width="99%" cellspacing="1" cellpadding="5" border="0" bgcolor="#dddddd">
                    <tbody>
                        <tr>
                            <td bgcolor="#ffffff">收货人姓名:
                            </td>
                            <td bgcolor="#ffffff">
                                <asp:TextBox ID="TextBox1" runat="server" ValidationGroup="address"></asp:TextBox>
                                <asp:RequiredFieldValidator ControlToValidate="TextBox1" ID="RequiredFieldValidator3" runat="server" ErrorMessage="(必填)" ValidationGroup="address"></asp:RequiredFieldValidator>
                            </td>
                            <td bgcolor="#ffffff">详细地址:
                            </td>
                            <td bgcolor="#ffffff">
                                <asp:TextBox ID="TextBox2" runat="server" ValidationGroup="address"></asp:TextBox>
                                <asp:RequiredFieldValidator ControlToValidate="TextBox2" ID="RequiredFieldValidator4" runat="server" ErrorMessage="(必填)" ValidationGroup="address"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#ffffff">电话:
                            </td>
                            <td bgcolor="#ffffff">
                                <asp:TextBox ID="TextBox3" runat="server" ValidationGroup="address"></asp:TextBox>
                                <asp:RequiredFieldValidator ControlToValidate="TextBox3" ID="RequiredFieldValidator1" runat="server" ErrorMessage="(必填)" ValidationGroup="address"></asp:RequiredFieldValidator>
                            </td>
                            <td bgcolor="#ffffff">总金额:
                            </td>
                            <td bgcolor="#ffffff">
                                <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" bgcolor="#ffffff" colspan="4">
                                <%--<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="images/bg.gif" CssClass="bnt_blue_2"/>--%>
                                <asp:Button ID="Button1" runat="server" Text="配送至这个地址" CssClass="bnt_blue_2" OnClick="Button1_Click" ValidationGroup="address"/>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
        <uc1:WebUserControl4 runat="server" ID="WebUserControl4" />
    </form>
</body>
</html>
