<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebUserControl1.ascx.cs" Inherits="UI.WebUserControl1" %>
<link href="css/style.css" rel="stylesheet" type="text/css" />

<style type="text/css">

</style>

<div class="block clearfix">
    <div class="f_l">
        <a name="top" href="Main.aspx">
            <img src="images/logo.gif"></a>
    </div>
    <div class="f_r log">
        <ul>
            <li class="userInfo"><font id="ECS_MEMBERZONE">
                    <div id="append_parent">
                    </div>
                    欢迎光临本店&nbsp;&nbsp;&nbsp;&nbsp; 
            <a href="Login.aspx">
                <asp:Image ID="Image1" runat="server" ImageUrl="images/bnt_log.gif" CssClass="auto-style2"></asp:Image>
            </a> 
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

                <a href="Login.aspx"> 
                <asp:Image ID="Image2" runat="server" ImageUrl="images/bnt_reg.gif" style="left: 2px; top: 5px;width:52px;height:21px"></asp:Image>
                </a> 
                <asp:Button ID="Button1" runat="server" Text="注销" OnClick="Button1_Click" CssClass="logout"></asp:Button>
                                     </font></li>
        </ul>
    </div>
</div>
<div class="blank">
</div>
