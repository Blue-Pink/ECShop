<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GoodLType.aspx.cs" Inherits="UI.Admin.GoodLType" %>

<%@ Register Src="~/Admin/Top.ascx" TagPrefix="uc1" TagName="Top" %>
<%@ Register Src="~/Admin/Menu.ascx" TagPrefix="uc1" TagName="Menu" %>
<%@ Register Src="~/Admin/Drag.ascx" TagPrefix="uc1" TagName="Drag" %>

<!DOCTYPE html>
    <link href="styles/general.css" rel="stylesheet" type="text/css" />
    <link href="styles/main.css" rel="stylesheet" type="text/css" />

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>商品大类别</title>
        <style type="text/css">
        td
        {
            text-align: center;
        }
        th
        {
            font-weight: bold;
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
        <span class="action-span"><a href="GoodSTypeAdd.aspx">添加小类别</a></span> <span class="action-span1">
            <a href="Main.aspx">ECSHOP 管理中心</a> </span><span id="search_id" class="action-span1">
                - 商品大类别 </span>
        <div style="clear: both">
        </div>
    </h1>
    <!-- 商品搜索 -->
    <div class="form-div">
        商品大类别
        <%--<input type="text" name="keyword" size="15" />--%>
            <asp:TextBox ID="TextBox1" runat="server" Width="100px"></asp:TextBox>
        <%--<input type="submit" value=" 添加 " class="button" />--%>
            <asp:Button ID="Button1" runat="server" Text="添加" CssClass="button" OnClick="Button1_Click"/>
    </div>
    <!-- 商品列表 -->
    <!-- start goods list -->
    <div class="list-div" id="listDiv">
        <table cellpadding="3" cellspacing="1">
            <tr>
                <th>
                    大类别名称
                </th>
                <th>
                    操作
                </th>
                </tr>
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <tr>
                        <td>
                            <%#Eval("BLName") %>
                        </td>
                        <td align="center">
                            <a href="GoodSTypeEdit.aspx?BLID=<%#Eval("BLID") %>" title="编辑">
                                <img src="images/icon_edit.gif" width="16" height="16" border="0" /></a>
                            <a onclick="javascript:if(confirm('你确定要删除吗')){location.href='DeleteType.aspx?BLID=<%#Eval("BLID") %>'}"title="回收站">
                                    <img src="images/icon_trash.gif" width="16" height="16" border="0" /></a>
                            <a href="GoodSType.aspx?BLID=<%# Eval("BLID") %>" title="查看小类别">
                                <img src="images/icon_view.gif" width="16" height="16" border="0" /></a>
                        </td>
                    </tr>
                    </ItemTemplate>
            </asp:Repeater>
        </table>
        <!-- end goods list -->
    </div>
            </div>
            </div>
    </form>
</body>
</html>
