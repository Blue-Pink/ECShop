<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="UI.Main" %>

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

        /*.flash1 {
            width: 400px;
            height: 200px;
        }*/
    </style>
</head>
<body>
    <form id="form1" runat="server">
        
        <uc1:WebUserControl1 runat="server" ID="WebUserControl1" />

        <uc1:WebUserControl2 runat="server" ID="WebUserControl2" />
        <div class="block clearfix">
            <uc1:WebUserControl3 runat="server" ID="WebUserControl3" />
            
            <div class="AreaR">
                <div class="box clearfix">
                    <div class="flash1">
                    </div>
                </div>
                <div class="blank5">
                </div>
                <div class="blank5">
                </div>
                <div class="box">
                    <div class="box_2 centerPadd">
                        <div id="itemBest" class="itemTit">
                        </div>
                        <div class="clearfix goodsBox" id="show_best_area">
                            <asp:Repeater ID="Repeater1" runat="server">
                                <ItemTemplate>
                                    <div class="goodsItem">
                                        <span class="best"></span>
                                        <a href="Goods.aspx?BID=<%#Eval("BID") %>">
                                            <img class="goodsimg" alt="<%#Eval("BName")%>" src="BookImages/<%#Eval("BPic") %>"></a><br>
                                        <p>
                                            <a title="<%#Eval("BName")%>" href="Goods.aspx?BID=<%#Eval("BID") %>"><%#Eval("BName").ToString().Length>17?Eval("BName").ToString().Substring(0,17)+"…": Eval("BName")%></a>
                                        </p>
                                        <font class="f1"><%#Eval("BPrice") %> </font>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>

                            <div class="more">
                                <a href="#">
                                    <img src="images/more.gif"></a>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="blank5">
                </div>
                <div class="box">
                    <div class="box_2 centerPadd">
                        <div id="itemNew" class="itemTit New">
                        </div>
                        <div class="clearfix goodsBox" id="show_new_area">
                            <asp:Repeater ID="Repeater2" runat="server">
                                <ItemTemplate>
                                    <div class="goodsItem">
                                        <span class="best"></span><a href="Goods.aspx?BID=<%#Eval("BID") %>">
                                            <img class="goodsimg" alt="<%#Eval("BName")%>" src="BookImages/<%#Eval("BPic") %>"></a><br>
                                        <p>
                                            <a title="<%#Eval("BName")%>" href="Goods.aspx?BID=<%#Eval("BID") %>"><%#Eval("BName").ToString().Length>17?Eval("BName").ToString().Substring(0,17)+"…": Eval("BName")%></a>
                                        </p>
                                        <font class="f1"><%#Eval("BPrice") %> </font>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                            
                            <div class="more">
                                <a href="#">
                                    <img src="images/more.gif"></a>
                            </div>

                        </div>
                    </div>
                </div>
                <div class="blank5">
                </div>
                <div class="blank5">
                </div>
            </div>
        </div>
        <uc1:WebUserControl4 runat="server" ID="WebUserControl4" />
        <%--<div id="footer">
            <div class="text">
                &copy; 2005-2012 ECSHOP 版权所有，并保留所有权利。<br>
                <br>
                共执行 41 个查询，用时 0.090556 秒，在线 2 人，Gzip 已禁用，占用内存 3.136 MB<br>
                <a style="font-family: Verdana; font-size: 11px;" target="_blank" href="http://www.ecshop.com">Powered&nbsp;by&nbsp;<strong><span style="color: #3366FF">ECShop</span>&nbsp;<span
                    style="color: #FF9966">v2.7.0</span></strong></a>&nbsp;<br>
                <div align="left" id="rss">
                    <a href="#">
                        <img alt="rss" src="images/xml_rss2.gif"></a>
                </div>
            </div>
        </div>--%>
    </form>
</body>
</html>
