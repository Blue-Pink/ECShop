<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UI.Login" %>

<%@ Register Src="~/WebUserControl1.ascx" TagPrefix="uc1" TagName="WebUserControl1" %>
<%@ Register Src="~/WebUserControl2.ascx" TagPrefix="uc1" TagName="WebUserControl2" %>



<%@ Register src="WebUserControl4.ascx" tagname="WebUserControl4" tagprefix="uc2" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>用户登录</title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style1 {
            height: 34px;
        }
        .auto-style2 {
            border: 1px solid #b3b3b3;
            background: url('css/images/inputbg.gif') repeat-x left top;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">
        <uc1:WebUserControl1 runat="server" ID="WebUserControl1" />
        <uc1:WebUserControl2 runat="server" ID="WebUserControl2" />
    <div class="block">
        <div class="flowBox">
            <table align="center" width="99%" cellspacing="1" cellpadding="5" border="0" bgcolor="#dddddd">
                <tbody>
                    <tr>
                        <td width="50%" valign="top" bgcolor="#ffffff">
                            <h6>
                                <span>用户登录：</span></h6>
                            <table width="90%" cellspacing="1" cellpadding="8" border="0" bgcolor="#B0D8FF" class="table">
                                <tbody>
                                    <tr>
                                        <td bgcolor="#ffffff">
                                            <div align="right">
                                                <strong>用户名</strong></div>
                                        </td>
                                        <td bgcolor="#ffffff">
                                            <%--<input type="text" id="username" class="inputBg" name="username">--%>
                                            <asp:TextBox ID="TextBox1" runat="server" CssClass="auto-style2" Height="18px" ValidationGroup="Login" Width="146px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ControlToValidate="TextBox1" ValidationGroup="Login"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td bgcolor="#ffffff">
                                            <div align="right">
                                                <strong>密码</strong></div>
                                        </td>
                                        <td bgcolor="#ffffff">
                                            <%--<input type="password" class="inputBg" name="password">--%>
                                            <asp:TextBox ID="TextBox2" runat="server" CssClass="inputBg" TextMode="Password" ValidationGroup="Login" Width="146px"></asp:TextBox>

                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" ControlToValidate="TextBox2" ValidationGroup="Login"></asp:RequiredFieldValidator>

                                        </td>
                                    </tr>
                                    <tr>
                                        <td bgcolor="#ffffff" colspan="2">
                                            <div align="center">
                                                <%--<input type=button value="登录" name="login" class="bnt_blue" onclick="javascript:location.href='flow.htm'">--%>
                                            <asp:Button ID="Button2" runat="server" Text="登录"  CssClass="bnt_blue" OnClick="Button2_Click" ValidationGroup="Login"/>
                                            </div>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                        <td valign="top" bgcolor="#ffffff">
                            <h6>
                                <span>用户注册：</span></h6>
                            <table width="98%" cellspacing="1" cellpadding="8" border="0" bgcolor="#B0D8FF" class="table">
                                <tbody>
                                    <tr>
                                        <td align="right" width="25%" bgcolor="#ffffff" class="auto-style1">
                                            <strong>用户名</strong>
                                        </td>
                                        <td bgcolor="#ffffff" class="auto-style1">
                                            <%--<input type="text" id="username" class="inputBg" name="username">--%>
                                            <asp:TextBox ID="TextBox3" runat="server" CssClass="inputBg"></asp:TextBox>
                                            <asp:RequiredFieldValidator ControlToValidate="TextBox3" CssClass="Validator" Display="Dynamic" ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ValidationGroup="Register"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ControlToValidate="TextBox3" CssClass="Validator" Display="Dynamic" ValidationExpression="^(\d|\w|_){4,12}$" ID="RegularExpressionValidator1" runat="server" ErrorMessage="数字、字母和_，4-12位" ValidationGroup="Register"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" bgcolor="#ffffff">
                                            <strong>电子邮件地址</strong>
                                        </td>
                                        <td bgcolor="#ffffff">
                                            <%--<input type="text" id="email" class="inputBg" name="email">--%>
                                            <asp:TextBox ID="TextBox4" runat="server" CssClass="inputBg"></asp:TextBox>
                                            <asp:RequiredFieldValidator ControlToValidate="TextBox4" CssClass="Validator" Display="Dynamic" ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ValidationGroup="Register"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ControlToValidate="TextBox4" CssClass="Validator" Display="Dynamic" ValidationExpression="[\w!#$%&'*+/=?^_`{|}~-]+(?:\.[\w!#$%&'*+/=?^_`{|}~-]+)*@(?:[\w](?:[\w-]*[\w])?\.)+[\w](?:[\w-]*[\w])?" ID="RegularExpressionValidator2" runat="server" ErrorMessage="邮箱格式不正确" ValidationGroup="Register"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" bgcolor="#ffffff">
                                            <strong>密码</strong>
                                        </td>
                                        <td bgcolor="#ffffff">
                                            <%--<input type="password" id="password1" class="inputBg" name="password">--%>
                                            <asp:TextBox ID="TextBox5" runat="server" CssClass="inputBg" TextMode="Password"></asp:TextBox>
                                            <asp:RequiredFieldValidator ControlToValidate="TextBox5" CssClass="Validator" Display="Dynamic" ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ValidationGroup="Register"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ControlToValidate="TextBox5" CssClass="Validator" Display="Dynamic" ValidationExpression="^.{6,18}$" ID="RegularExpressionValidator3" runat="server" ErrorMessage="6-18位" ValidationGroup="Register"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" bgcolor="#ffffff">
                                            <strong>确认密码</strong>
                                        </td>
                                        <td bgcolor="#ffffff">
                                            <%--<input type="password" id="confirm_password" class="inputBg" name="confirm_password">--%>
                                            <asp:TextBox ID="TextBox6" runat="server" CssClass="inputBg" TextMode="Password"></asp:TextBox>
                                            <asp:RequiredFieldValidator ControlToValidate="TextBox6" CssClass="Validator" Display="Dynamic" ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ValidationGroup="Register"></asp:RequiredFieldValidator>
                                            <asp:CompareValidator ControlToValidate="TextBox6" ControlToCompare="TextBox5" CssClass="Validator" Display="Dynamic" ID="CompareValidator1" runat="server" ErrorMessage="两次密码不一致" ValidationGroup="Register"></asp:CompareValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" bgcolor="#ffffff" colspan="2">
                                            <%--<input type="submit" value="注册新用户" class="bnt_blue_1" name="Submit">--%>
                                            <asp:Button ID="Button1" runat="server" Text="注册新用户"  CssClass="bnt_blue_1" OnClick="Button1_Click" ValidationGroup="Register"/>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>

        <uc2:WebUserControl4 ID="WebUserControl41" runat="server" />
    </form>
</body>
</html>
