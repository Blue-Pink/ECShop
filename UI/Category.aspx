<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Category.aspx.cs" Inherits="UI.Category" %>

<%@ Register Src="~/WebUserControl1.ascx" TagPrefix="uc1" TagName="WebUserControl1" %>
<%@ Register Src="~/WebUserControl2.ascx" TagPrefix="uc1" TagName="WebUserControl2" %>
<%@ Register Src="~/WebUserControl3.ascx" TagPrefix="uc1" TagName="WebUserControl3" %>
<%@ Register Src="~/WebUserControl4.ascx" TagPrefix="uc1" TagName="WebUserControl4" %>






<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>ECShop</title>
        <link href="css/style.css" rel="stylesheet" type="text/css" />
      <style type="text/css">
        dt, dl
        {
            margin: 0px;
            padding: 0px;
        }
        dd
        {
            margin-left: 40px;
        }
        .flash1
        {
            width: 400px;
            height: 200px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <uc1:WebUserControl1 runat="server" ID="WebUserControl1" />
        <uc1:WebUserControl2 runat="server" ID="WebUserControl2" />
    <div class="block">
        <uc1:WebUserControl3 runat="server" ID="WebUserControl3" />
        <div class="AreaR">
            <div class="flowBox">
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <table align="center" width="99%" cellspacing="1" cellpadding="5" border="0" bgcolor="#dddddd">
                    <tbody>
                        <tr>
                            <td align="center" bgcolor="#ffffff" rowspan="3" style="width: 100px;">
                                <a href="Goods.aspx?BID=<%#Eval("BID") %>"><img border="0" width="100px" height="100px;" title="<%#Eval("BName") %>" src="BookImages/<%#Eval("BPic") %>"></a><br>
                            </td>
                            <td align="left" bgcolor="#ffffff">
                                书籍名：<%#Eval("BName") %></td>
                        </tr>
                        <tr>
                            <td align="left" bgcolor="#ffffff" colspan="2">
                                书籍作者: <%#Eval("BAuthor") %>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" bgcolor="#ffffff" colspan="2">
                                商品价格:￥<%#Eval("BPrice") %>元
                            </td>
                        </tr>
                        <tr>
                            <td align="left" bgcolor="#ffffff" colspan="2">
                                简介:<br />
                                <textarea id="TextArea1" cols="20" rows="2"><%#Eval("BComment") %></textarea>
                            </td>
                        </tr>
                    </tbody>
                </table>
                    </ItemTemplate>
                </asp:Repeater>
                <div>
                    <asp:HyperLink ID="HyperLink1" runat="server">首页</asp:HyperLink>&nbsp
                    <asp:HyperLink ID="HyperLink2" runat="server">上一页</asp:HyperLink>&nbsp
                    <asp:HyperLink ID="HyperLink3" runat="server">下一页</asp:HyperLink>&nbsp
                    <asp:HyperLink ID="HyperLink4" runat="server">末页</asp:HyperLink>&nbsp&nbsp
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
        </div>
        <div class="blank5">
        </div>
    </div>
        <uc1:WebUserControl4 runat="server" ID="WebUserControl4" />
    </form>
</body>
</html>
