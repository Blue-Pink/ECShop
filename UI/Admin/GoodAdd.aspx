<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GoodAdd.aspx.cs" Inherits="UI.Admin.GoodAdd" %>

<%@ Register Src="~/Admin/Top.ascx" TagPrefix="uc1" TagName="Top" %>
<%@ Register Src="~/Admin/Menu.ascx" TagPrefix="uc1" TagName="Menu" %>
<%@ Register Src="~/Admin/Drag.ascx" TagPrefix="uc1" TagName="Drag" %>

<link href="styles/general.css" rel="stylesheet" type="text/css" />
<link href="styles/main.css" rel="stylesheet" type="text/css" />
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>商品添加</title>
    <style type="text/css">
        .td1 {
            text-align: left;
        }

        .auto-style1 {
            text-align: left;
            height: 24px;
        }

        .auto-style2 {
            text-align: left;
            height: 28px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <uc1:Top runat="server" ID="Top1" />
        <div style="width: 1850px; height: 900px; cursor: default">
            <div style="float: left; height: 900px; width: 250px" id="divMenu">
                <uc1:Menu runat="server" ID="Menu" />

                <uc1:Drag runat="server" ID="Drag" />
            </div>
            <div style="float: left; width: 1600px; height: 900px; background-color: #DDEEF2" id="divMain">


                <h1>
                    <span class="action-span"><a href="Goods.aspx">商品列表</a></span>
                    <span class="action-span1"><a href="Main.aspx">ECSHOP 管理中心</a> </span>
                    <span id="search_id" class="action-span1">- 添加商品信息 </span>
                    <div style="clear: both"></div>
                </h1>

                <!-- start goods form -->
                <div class="tab-div">
                    <!-- tab bar -->
                    <div id="tabbar-div">
                        <p>
                            <span class="tab-front" id="general-tab">通用信息</span>
                        </p>
                    </div>

                    <!-- tab body -->
                    <div id="tabbody-div">
                        <%--<form enctype="multipart/form-data" action="" method="post" name="theForm">--%>
                        <div>
                            <!-- 通用信息 -->
                            <table width="90%" id="general-table" align="center">
                                <tr>
                                    <td class="label" style="height: 28px">商品名称：</td>
                                    <td class="auto-style2">
                                        <%--<input type="text" name="goods_name" value="Visual C#2005技术内幕" style="float: left; color: ;" size="30" />--%>
                                        <asp:TextBox ID="TextBox1" runat="server" Width="150px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ControlToValidate="TextBox1" Display="Dynamic" ForeColor="Red" ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ControlToValidate="TextBox1" Display="Dynamic" ForeColor="Red" ValidationExpression="^.{1,15}$" ID="RegularExpressionValidator1" runat="server" ErrorMessage="长度请控制在1-15位"></asp:RegularExpressionValidator>
                                </tr>
                                <tr>
                                    <td class="label">书籍作者：</td>
                                    <td class="td1">
                                        <%--<input type="text" name="goods_name" value="Visual C#2005技术内幕" style="float: left; color: ;" size="30" />--%>
                                        <asp:TextBox ID="TextBox5" runat="server" Width="150px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ControlToValidate="TextBox5" ForeColor="Red" ID="RequiredFieldValidator4" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ControlToValidate="TextBox5" Display="Dynamic" ForeColor="Red" ValidationExpression="^.{1,15}$" ID="RegularExpressionValidator2" runat="server" ErrorMessage="长度请控制在1-15位"></asp:RegularExpressionValidator>
                                </tr>
                                <tr>
                                    <td class="label">商品货号： </td>
                                    <td class="td1">
                                        <%--<input type="text" name="goods_sn" value="9787302144175" size="20" />--%>
                                        <asp:TextBox ReadOnly="true" ID="TextBox2" runat="server" Width="150px"></asp:TextBox><br />
                                </tr>
                                <tr>
                                    <td class="label" style="height: 24px">商品小类：</td>
                                    <td class="auto-style1">
                                        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" Height="16px" Width="100px"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="label">商品价格：</td>
                                    <td class="td1">
                                        <%--<input type="text" name="shop_price" value="59.0000" size="20" />--%>
                                        <asp:TextBox ID="TextBox3" runat="server" Width="150px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ControlToValidate="TextBox3" ForeColor="Red" Display="Dynamic" ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                        <asp:CompareValidator ControlToValidate="TextBox3" ForeColor="Red" Display="Dynamic" Type="Double" ID="CompareValidator1" runat="server" ErrorMessage="格式有误"></asp:CompareValidator>
                                </tr>
                                <tr>
                                    <td class="label">上传商品图片：</td>
                                    <td class="td1">
                                        <%--<input type="file" name="goods_img" size="35" />--%>
                                        <asp:RequiredFieldValidator ControlToValidate="FileUpload1" ForeColor="Red" Display="Dynamic" ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                        <asp:FileUpload ID="FileUpload1" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="label">商品库存：</td>
                                    <td class="td1">
                                        <%--<input type="text" name="shop_count" value="0" size="20" />--%>
                                        <asp:TextBox ID="TextBox4" runat="server" Width="150px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ControlToValidate="TextBox4" ForeColor="Red" Display="Dynamic" ID="RequiredFieldValidator5" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                        <asp:CompareValidator ControlToValidate="TextBox4" ForeColor="Red" Display="Dynamic" Type="Double" ID="CompareValidator2" runat="server" ErrorMessage="格式有误"></asp:CompareValidator>
                                </tr>
                            </table>
                            <div class="button-div" style="text-align: left; margin-left: 450px">
                                <%--<input type="hidden" name="goods_id" value="32" />--%>
                                <%--<input type="submit" value=" 确定 " class="button" />--%>
                                <asp:Button ID="Button1" runat="server" Text="确定" CssClass="button" Width="70px" OnClick="Button1_Click" />
                                <input type="reset" value=" 重置 " class="button" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- end goods form -->
    </form>
</body>
</html>
