<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GoodSTypeAdd.aspx.cs" Inherits="UI.Admin.GoodSTypeAdd" %>

<%@ Register Src="~/Admin/Top.ascx" TagPrefix="uc1" TagName="Top" %>
<%@ Register Src="~/Admin/Menu.ascx" TagPrefix="uc1" TagName="Menu" %>
<%@ Register Src="~/Admin/Drag.ascx" TagPrefix="uc1" TagName="Drag" %>

<!DOCTYPE html>
<link href="styles/general.css" rel="stylesheet" type="text/css" />
<link href="styles/main.css" rel="stylesheet" type="text/css" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>新增商品小类别</title>
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
        <span class="action-span"><a href="GoodSType.aspx">商品小类别</a></span> <span class="action-span1">
            <a href=" href="Main.aspx">ECSHOP 管理中心</a> </span><span id="search_id" class="action-span1">
                - 添加小类别 </span>
        <div style="clear: both">
        </div>
    </h1>
    
                <div class="tab-div">
                    <!-- tab body -->
                    <div id="tabbody-div">
                        <!-- 通用信息 -->
                        <table width="90%" id="general-table" align="center">
                            <tr>
                                <td class="label">大类别名称：
                                </td>
                                <td style="text-align: left">
                                    <asp:DropDownList ID="DropDownList1" runat="server" Width="120px"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="label">小类别名称：
                                </td>
                                <td style="text-align: left">
                                    <%--<input type="text" name="goods_name" value="C#" style="float: left; color: " size="30" /><br />--%>
                                    <asp:TextBox ID="TextBox1" runat="server" Width="120px" Height="20px"></asp:TextBox>
                                    <asp:RequiredFieldValidator Display="Dynamic" ForeColor="red" ControlToValidate="TextBox1" ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                            </tr>
                        </table>
                        <div class="button-div" style="width:1000px">
                            <%--<input type="hidden" name="goods_id" value="32" />--%>
                            <asp:Button ID="Button1" runat="server" Text="添加" CssClass="button" Width="70px" OnClick="Button1_Click" />
                            <input type="reset" value=" 重置 " class="button" />
                        </div>
                    </div>
                </div>
    <!-- end Type form -->

                </div>
            </div>
    </form>
</body>
</html>
