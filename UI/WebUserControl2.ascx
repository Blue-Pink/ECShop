<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebUserControl2.ascx.cs" Inherits="UI.WebUserControl2" %>

        <link href="css/style.css" rel="stylesheet" type="text/css" />
    <div class="clearfix" id="mainNav">
        <a class="cur" href="Main.aspx">首页</a> 

        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                 <a href="Category.aspx?BLID=<%#Eval("BLID") %>"><%#Eval("BLName") %><span></span></a>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div class="clearfix" id="search">
        <div style="_position: relative; top: 5px;" class="f_r"  name="searchForm" id="searchForm">
            书名:<asp:TextBox ID="TextBox1" runat="server" Width="110px" CssClass="B_input" ValidationGroup="serch"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="搜索" CssClass="logout" OnClick="Button1_Click"  ValidationGroup="serch"/>
        </div>
    </div>
