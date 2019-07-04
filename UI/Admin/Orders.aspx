<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Orders.aspx.cs" Inherits="UI.Admin.Orders" %>

<%@ Register Src="~/Admin/Top.ascx" TagPrefix="uc1" TagName="Top" %>
<%@ Register Src="~/Admin/Menu.ascx" TagPrefix="uc1" TagName="Menu" %>
<%@ Register Src="~/Admin/Drag.ascx" TagPrefix="uc1" TagName="Drag" %>

<!DOCTYPE html>
<link href="styles/general.css" rel="stylesheet" type="text/css" />
<link href="styles/main.css" rel="stylesheet" type="text/css" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>订单</title>
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
                    <span class="action-span1"><a href="Main.aspx">ECSHOP 管理中心</a> </span><span id="search_id"
                        class="action-span1">- 订单列表 </span>
                    <div style="clear: both">
                    </div>
                </h1>
                <!-- 商品搜索 -->
                <div class="form-div">
                    订单号
        <%--<input type="text" name="ordernumber" size="15" />--%>
                    <asp:TextBox ID="TextBox1" runat="server" Width="80px" ValidationGroup="Serch"></asp:TextBox>
                    收货人
                            <asp:TextBox ID="TextBox4" runat="server" Width="80px" ValidationGroup="Serch"></asp:TextBox>
                    <%--<input type="submit" value=" 搜索 " class="button" />--%>
                    <asp:Button ID="Button1" runat="server" Text="搜索" CssClass="button" OnClick="Button1_Click" ValidationGroup="Serch"/>
                </div>
                <!-- 商品列表 -->
                <!-- start goods list -->
                <div class="list-div" id="listDiv">
                    <table cellpadding="3" cellspacing="1">
                        <tr>
                            <th>订单号
                            </th>
                            <th>订单时间
                            </th>
                            <th>收货人
                            </th>
                            <th>总金额
                            </th>
                            <th>订单状态
                            </th>
                            <th>操作
                            </th>
                            <asp:Repeater ID="Repeater1" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%#Eval("OID") %>
                                        </td>
                                        <td align="left"><%#Eval("ODate") %>
                                        </td>
                                        <td><%#Eval("OConsignee") %>
                                        </td>
                                        <td align="right"><%#Eval("OSumPrice") %>
                                        </td>
                                        <td align="right"><%#Eval("OState") %>->
                   <%--<input type="button" value="订单确认" />--%>
                                            <asp:Button OnClick="Button3_Click" CommandName='<%#Eval("OID") %>' ID="Button3" runat="server" AccessKey='<%#Convert.ToInt32(Enum.Parse(typeof(Model.Order.enumOState),Eval("OState").ToString()).GetHashCode())+1%>'
                                                Text='<%#Convert.ToInt32(Enum.Parse(typeof(Model.Order.enumOState),Eval("OState").ToString()).GetHashCode())<4?
                                                        Enum.GetName(typeof(Model.Order.enumOState),Convert.ToInt32(Enum.Parse(typeof(Model.Order.enumOState),Eval("OState").ToString()).GetHashCode())+1): 
                                                        Enum.GetName(typeof(Model.Order.enumOState),Convert.ToInt32(Enum.Parse(typeof(Model.Order.enumOState),Eval("OState").ToString()).GetHashCode()))%>'
                                                CssClass="button" Visible='<%#Eval("OState").ToString()!="订单结束" %>' />
                                        </td>
                                        <td align="center">
                                            <a href="OrderDetail.aspx?OID=<%#Eval("OID") %>" title="查看">
                                                <img src="images/icon_view.gif" width="16" height="16" border="0" /></a>
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
                                <div id="turn-page" <%=(TextBox1.Text == null || TextBox1.Text == "" ||TextBox1.Text.Trim() == "")&&(TextBox4.Text == null || TextBox4.Text == "" ||TextBox4.Text.Trim() == "")?"style='display:inline'":"style='display:none'" %>>
                                    <span style="float:left">页大小:<asp:TextBox ID="TextBox2" runat="server" Width="30px" Height="10px" BorderStyle="Dotted" OnTextChanged="TextBox2_TextChanged" ValidationGroup="page" AutoPostBack="True"></asp:TextBox></span><span style="clear:both"></span>
                                    <asp:HyperLink ID="HyperLink1" runat="server">首页</asp:HyperLink>&nbsp|&nbsp
                                    <asp:HyperLink ID="HyperLink2" runat="server">上一页</asp:HyperLink>&nbsp|&nbsp
                                    <asp:HyperLink ID="HyperLink3" runat="server">下一页</asp:HyperLink>&nbsp|&nbsp
                                    <asp:HyperLink ID="HyperLink4" runat="server">末页</asp:HyperLink>&nbsp&nbsp&nbsp
                                    共:<%=pagecount %>页&nbsp / &nbsp 当前:<%=pageindex %>页
                                    <%-- 总计 <span id="totalRecords">
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
                                        
                                        <asp:TextBox ID="TextBox3" runat="server" Width="60px" ValidationGroup="Go"></asp:TextBox><asp:Button ID="Button2" runat="server" Text="GO" CssClass="button" OnClick="Button2_Click" ValidationGroup="Go" />
                                        <asp:RequiredFieldValidator ControlToValidate="TextBox3" ID="RequiredFieldValidator1" runat="server" ErrorMessage="" ValidationGroup="Go"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ControlToValidate="TextBox3" ValidationExpression="^[0-9]+" ID="RegularExpressionValidator1" runat="server" ErrorMessage="" ValidationGroup="Go"></asp:RegularExpressionValidator>
                                    </span>--%>
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
