<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Goods.aspx.cs" Inherits="UI.Admin.Goods" %>

<%@ Register Src="~/Admin/Top.ascx" TagPrefix="uc1" TagName="Top" %>
<%@ Register Src="~/Admin/Menu.ascx" TagPrefix="uc1" TagName="Menu" %>
<%@ Register Src="~/Admin/Drag.ascx" TagPrefix="uc1" TagName="Drag" %>



<link href="styles/general.css" rel="stylesheet" type="text/css" />
<link href="styles/main.css" rel="stylesheet" type="text/css" />
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>商品</title>

    <style type="text/css">
        th {
            font-weight: bold;
        }

        td {
            text-align: center;
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
                    <span class="action-span"><a href="GoodAdd.aspx">添加新商品</a></span> <span class="action-span1">
                        <a href="Main.aspx">ECSHOP 管理中心</a> </span><span id="search_id" class="action-span1">- 商品列表 </span>
                    <div style="clear: both">
                    </div>
                </h1>
                <!-- 商品搜索 -->
                <div class="form-div">
                    商品名
        <asp:TextBox ID="TextBox1" runat="server" ValidationGroup="Serch"></asp:TextBox>
                    <asp:Button ID="Button1" runat="server" Text="搜索" CssClass="button" OnClick="Button1_Click" ValidationGroup="Serch" />
                </div>
                <!-- 商品列表 -->
                <!-- start goods list -->
                <div class="list-div" id="listDiv">

                    <table cellpadding="3" cellspacing="1">
                        <tr>
                            <th style="width: 15%">编号
                            </th>
                            <th style="width: 50%">商品名称
                            </th>
                            <th style="width: 15%">ISBN
                            </th>
                            <th style="width: 7%">价格
                            </th>
                            <th style="width: 7%">库存
                            </th>
                            <th style="width: 6%">操作
                            </th>
                            <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <%#Eval("BID") %>
                                        </td>
                                        <td style="text-align: left">
                                            <img src="../BookImages/<%#Eval("BPic") %>"
                                                width="50px" height="50px" />
                                            <%#Eval("BName") %>
                                        </td>
                                        <td>
                                            <span><%#Eval("BISBN") %></span>
                                        </td>
                                        <td align="right">
                                            <span><%#Eval("BPrice") %></span>
                                        </td>
                                        <td align="center">
                                            <span><%#Eval("BCount") %></span>
                                        </td>
                                        <td align="center">
                                            <a href="GoodEdit.aspx?BID=<%#Eval("BID") %>" title="编辑">
                                                <img src="images/icon_edit.gif" width="16" height="16" border="0" /></a>
                                            <a onclick="javascript:if(confirm('确定删除该书籍吗?')){location.href='DeleteBook.aspx?BID=<%#Eval("BID") %>'}" title="回收站">
                                                <img src="images/icon_trash.gif" width="16" height="16" border="0" /></a>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                    </table>

                    <!-- end goods list -->
                    <!-- 分页 -->
                    <table id="page-table" cellspacing="0">
                        <tr>
                            <td align="right" nowrap="true">
                                <div id="turn-page">
                                    &nbsp;<div id="turn-page">
                                        总计 <span id="totalRecords">
                                            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></span>
                                        个记录分为 
                                        <span id="totalPages">
                                            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                                        </span>
                                        页当前第 
                                        <span id="pageCurrent">
                                            <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                                        </span>页，每页
                                        <asp:TextBox AutoPostBack="true" ID="TextBox2" runat="server" Width="20px" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
                                        <span id="page-link">
                                            <asp:HyperLink ID="HyperLink1" runat="server">首页</asp:HyperLink>&nbsp|&nbsp
                                            <asp:HyperLink ID="HyperLink2" runat="server">上一页</asp:HyperLink>&nbsp|&nbsp
                                            <asp:HyperLink ID="HyperLink3" runat="server">下一页</asp:HyperLink>&nbsp|&nbsp
                                            <asp:HyperLink ID="HyperLink4" runat="server">末页</asp:HyperLink>&nbsp|&nbsp
                                            <asp:TextBox ID="TextBox3" runat="server" Width="60px" ValidationGroup="Go"></asp:TextBox><asp:Button ID="Button2" runat="server" Text="GO"  CssClass="button" OnClick="Button2_Click" ValidationGroup="Go"/>
                                        <asp:RequiredFieldValidator ControlToValidate="TextBox3" ID="RequiredFieldValidator1" runat="server" ErrorMessage="" ValidationGroup="Go"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ControlToValidate="TextBox3" ValidationExpression="^[0-9]+" ID="RegularExpressionValidator1" runat="server" ErrorMessage="" ValidationGroup="Go"></asp:RegularExpressionValidator>
                                        </span>
                                    </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
