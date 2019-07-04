<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GoodSType.aspx.cs" Inherits="UI.Admin.GoodSType" %>

<%@ Register Src="~/Admin/Top.ascx" TagPrefix="uc1" TagName="Top" %>
<%@ Register Src="~/Admin/Menu.ascx" TagPrefix="uc1" TagName="Menu" %>
<%@ Register Src="~/Admin/Drag.ascx" TagPrefix="uc1" TagName="Drag" %>

<!DOCTYPE html>
<link href="styles/general.css" rel="stylesheet" type="text/css" />
<link href="styles/main.css" rel="stylesheet" type="text/css" />

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>商品小类别</title>
    <style type="text/css">
        td {
            text-align: center;
        }

        th {
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
                    <span class="action-span1"><a href="Main.aspx">ECSHOP 管理中心</a></span><span id="search_id"
                        class="action-span1"> - 商品小类别 </span>
                    <div style="clear: both">
                    </div>
                </h1>
                <!-- 商品搜索 -->
                <div class="form-div">
                    <input type="button" value=" 显示所有小类别" class="button" onclick="javascript: location.href='GoodSType.aspx'"/>
                    <input type="button" value=" 小类别添加 " class="button" onclick="javascript: window.location.href = 'GoodSTypeAdd.aspx'" />
                </div>
                <!-- 商品列表 -->
                <!-- start goods list -->
                <div class="list-div" id="listDiv">
                    <table cellpadding="3" cellspacing="1">
                        <tr>
                            <th>小类别名称
                            </th>
                            <th>大类别名称
                            </th>
                            <th>操作
                            </th>
                        </tr>
                        <asp:Repeater ID="Repeater1" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <%#Eval("BLName") %>
                                    </td>
                                    <td>
                                        <%#Eval("BLName1") %>
                                    </td>
                                    <td align="center">
                                        <a href="GoodSTypeEdit.aspx?BLID=<%#Eval("BLID") %>&BSID=<%#Eval("BSID") %>" title="编辑">
                                            <img src="images/icon_edit.gif" width="16" height="16" border="0" /></a>
                                        <a onclick="javascript:if(confirm('你确定要删除吗')){location.href='DeleteType.aspx?BSID=<%#Eval("BSID") %>'}" title="回收站">
                                            <img src="images/icon_trash.gif" width="16" height="16" border="0" /></a>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                    <!-- end goods list -->
                </div>

            </div>
            &nbsp;&nbsp;&nbsp;
        </div>
    </form>
</body>
</html>
