<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Goods.aspx.cs" Inherits="UI.Good" %>

<%@ Register Src="~/WebUserControl1.ascx" TagPrefix="uc1" TagName="WebUserControl1" %>
<%@ Register Src="~/WebUserControl2.ascx" TagPrefix="uc1" TagName="WebUserControl2" %>
<%@ Register Src="~/WebUserControl3.ascx" TagPrefix="uc1" TagName="WebUserControl3" %>
<%@ Register Src="~/WebUserControl4.ascx" TagPrefix="uc1" TagName="WebUserControl4" %>





<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>ECShop</title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        dt, dl {
            margin: 0px;
            padding: 0px;
        }

        dd {
            margin-left: 40px;
        }

        .flash1 {
            width: 400px;
            height: 200px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <uc1:WebUserControl1 runat="server" ID="WebUserControl1" />
        <uc1:WebUserControl2 runat="server" ID="WebUserControl2" />
            <div class="block clearfix">
                <uc1:WebUserControl3 runat="server" ID="WebUserControl3" />
                <div class="AreaR">
            <div class="clearfix" id="goodsInfo">
                <div class="imgInfo">
                    <img alt="<%=book.BName %>" src="BookImages/<%=book.BPic %>" />
                </div>
                <!--书籍简要介绍-->
                <div class="textInfo">
                    <div class="clearfix">
                        <p class="f_l">
                            <%=book.BName %></p>
                    </div>
                    <ul>
                        <li class="clearfix">
                            <dd>
                                <strong>书籍货号：</strong><%=book.BISBN %>
                            </dd>
                            <dd class="ddR">
                                <strong>书籍库存：</strong> <font color="red"><%=book.BCount %></font>
                            </dd>
                        </li>
                        <li class="clearfix">
                            <dd>
                                <strong>书籍作者：</strong><%=book.BAuthor %>
                            </dd>
                            <dd class="ddR">
                                <strong>书籍价格：</strong><font id="Font1" class="shop">￥<%=book.BPrice %>元</font>
                            </dd>
                        </li>
                        <li class="clearfix">
                            <dd>
                                <strong>购买数量：</strong> <asp:TextBox ID="TextBox1" runat="server" Width="40px" Text="1" onkeyup="value=value.replace(/^(0+)|[^\d]+/g,'')"></asp:TextBox>
                                <asp:CompareValidator ControlToValidate="TextBox1" Type="Integer" Operator="DataTypeCheck" ID="CompareValidator1" runat="server" ErrorMessage=""></asp:CompareValidator>
                            </dd>
                            <dd class="ddR">
                            </dd>
                        </li>
                        <li class="padd"><%--<a href="login.htm">
                            <img src="images/bnt_cat.gif"></a>--%> 
                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="images/bnt_cat.gif" OnClick="ImageButton1_Click"/>
                        </li>
                    </ul>
                </div>
                                    <div class="textInfo">
                <div class="clearfix">
                    <p class="f_l">
                        书籍简介</p>
                </div>
                <ul>
                    <li class="clearfix">
                        <dd>
                            <textarea id="TextArea1" cols="20" rows="2" width="auto"><%=book.BComment %></textarea>
                        </dd>
                    </li>
                </ul>
            </div>

            </div>            

            <!--书籍简介介绍-->
            
        </div>

        <div class="blank5">
        </div>
    </div>

        <uc1:WebUserControl4 runat="server" ID="WebUserControl4" />
        </form>
</body>
</html>
