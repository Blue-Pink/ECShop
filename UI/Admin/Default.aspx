<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UI.Admin.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>管理员登录</title>
        <link href="styles/general.css" rel="stylesheet" type="text/css" />
    <link href="styles/main.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        body
        {
            color: white;
            background: #278296;
            font-size:12px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
    <table cellspacing="0" cellpadding="0" style="margin-top: 100px" align="center">
        <tr>
            <td>
                <img src="images/login.png" width="178" height="256" border="0" alt="ECSHOP" />
            </td>
            <td style="padding-left: 50px">
                <table>
                    <tr>
                        <td>
                            管理员姓名：
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox1" runat="server" MaxLength="20"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            管理员密码：
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox2" runat="server" TextMode="Password" MaxLength="20"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            验证码：
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox3" runat="server" MaxLength="20"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="right">
                            <img src="ObtainCode.aspx" width="145" height="20" alt="CAPTCHA" border="1" onclick="this.src=this.src+'?'" style="cursor: pointer;"
                                title="看不清？点击更换另一个验证码" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:Button ID="Button1" runat="server" class="button" Text="进入管理中心" OnClick="Button1_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
