<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GoodSTypeEdit.aspx.cs" enableEventValidation ="false"  ValidateRequest="false" Inherits="UI.Admin.GoodSTypeEdit" %>

<%@ Register Src="~/Admin/Top.ascx" TagPrefix="uc1" TagName="Top" %>
<%@ Register Src="~/Admin/Menu.ascx" TagPrefix="uc1" TagName="Menu" %>
<%@ Register Src="~/Admin/Drag.ascx" TagPrefix="uc1" TagName="Drag" %>

<!DOCTYPE html>
<link href="styles/general.css" rel="stylesheet" type="text/css" />
<link href="styles/main.css" rel="stylesheet" type="text/css" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>商品小类别信息修改</title>
    <style>
        table{
            border-style:hidden;
            width:100%;
        }
        tr {
            height:30px;
            border-style:hidden;
            
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
            <div style="float: left; width: 1600px; height: 900px; background-color: #DDEEF2"  id="divMain">
                <h1>
                    <span class="action-span"><a href="GoodSType.aspx">商品小类别</a></span> <span class="action-span1">
                        <a href="Main.aspx">ECSHOP 管理中心</a> </span><span id="search_id" class="action-span1">- 添加小类别 </span>
                    <div style="clear: both">
                    </div>
                </h1>    
                <!-- start Type form -->
                <div class="tab-div">
                    <!-- tab body -->
                    <div id="tabbody-div">
                        <!-- 通用信息 -->
                        <div style="width:1000px;line-height:30px">
                            大类别名称:<asp:DropDownList ID="DropDownList1" runat="server" Width="120px" Height="25px" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
                            &nbsp;&nbsp;&nbsp
                            <asp:TextBox ID="TextBox2" runat="server" Width="80px" AutoPostBack="True" ValidationGroup="update"></asp:TextBox>
                            <asp:Button ID="Button1" runat="server" Text="修改"  CssClass="button" OnClick="Button1_Click" ValidationGroup="update"/>
                            <asp:RequiredFieldValidator ControlToValidate="TextBox2" ID="RequiredFieldValidator1" runat="server" ErrorMessage="" ValidationGroup="update"></asp:RequiredFieldValidator>
                            <a href="GoodSTypeEdit.aspx"><input type="button" value="查看所有小类别" class="button"/></a>
                        </div>
                        <div class="button-div" style="width:1000px;text-align:center;">
                            <asp:GridView ID="GridView1" runat="server" DataKeyNames="BSID" AutoGenerateColumns="False" OnRowEditing="GridView1_RowEditing" OnRowDeleting="GridView1_RowDeleting" OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDataBound="GridView1_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="大类别">
                                        <EditItemTemplate>
                                            <asp:DropDownList  DataSource="<%# Bll.Bll_BLCategory.Select_All() %>" ID="DropDownList2" runat="server" AutoPostBack="True" DataTextField="BLName" DataValueField="BLID" SelectedValue='<%# Eval("BLID") %>'>
                                            </asp:DropDownList>
                                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ECSHOPConnectionString2 %>" SelectCommand="SELECT [BLID], [BLName] FROM [BLCategory]"></asp:SqlDataSource>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("BLName1") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="小类别">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("BLName") %>' Width="80px"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("BLName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:CommandField HeaderText="操作" ShowDeleteButton="True" ShowEditButton="True" ButtonType="Image" CancelImageUrl="~/Admin/images/icon_cancle.png" DeleteImageUrl="~/Admin/images/icon_trash.gif" EditImageUrl="~/Admin/images/icon_edit.gif" UpdateImageUrl="~/Admin/images/icon_update.png" />
                                </Columns>
                            </asp:GridView>
                        </div>
                        <%--<div class="button-div" style="width:1000px">
                            <input type="hidden" name="goods_id" value="32" />
                            <asp:Button ID="Button1" runat="server" Text="确定" CssClass="button" Width="70px" OnClick="Button1_Click" />
                            <input type="reset" value=" 重置 " class="button" />
                        </div>--%>
                    </div>
                </div>
                <!-- end Type form -->
            </div>
        </div>
    </form>
</body>
</html>
