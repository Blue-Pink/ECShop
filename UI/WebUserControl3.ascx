<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebUserControl3.ascx.cs" Inherits="UI.WebUserControl3" %>
<link href="css/style.css" rel="stylesheet" type="text/css" />

<div class="AreaL">
    <div id="ECS_CARTINFO" class="cart">
        <a title="查看购物车" href="<%=Request.Cookies["Login"]==null ?"Login.aspx":this.TotalProduct==0?"javascript:alert('购物车内没有任何商品,您再逛逛吧'); ":"Flow.aspx" %>">您的购物车中有 <%=this.TotalProduct %> 件商品，总计金额 ￥<%=this.TotalPrice %>元。</a>
    </div>
    <div class="blank5">
    </div>
    <div class="box">
        <div class="box_1">
            <div id="category_tree">

                <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
                    <ItemTemplate>
                        <dl>
                            <dt>
                                <a href="Category.aspx?BLID=<%#Eval("BLID") %>"><%#Eval("BLName") %></a>
                            </dt>
                            <asp:Repeater ID="Repeater2" runat="server">
                                <ItemTemplate>
                                    <dd>
                                        <a href="Category.aspx?BSID=<%#Eval("BSID") %>"><%#Eval("BLName") %></a>
                                    </dd>
                                </ItemTemplate>
                            </asp:Repeater>
                        </dl>
                    </ItemTemplate>
                </asp:Repeater>

            </div>
        </div>
    </div>
    <div class="blank5">
    </div>
</div>
