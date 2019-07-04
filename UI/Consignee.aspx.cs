using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using Bll;
namespace UI
{
    public partial class Consignee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["TradesTID"] == null || Request.QueryString["TradesTID"].Trim() == "^" || Request.QueryString["TradesTID"].Trim() == "")
                {
                    Response.Redirect("Main.aspx");
                }
                List<Trade> trades = new List<Trade>();
                decimal OSumPrice = 0;
                string[] TradeTID = Request.QueryString["TradesTID"].ToString().Trim().Split('^');
                for (int i = 0; i < TradeTID.Length; i++)
                {
                    if (TradeTID[i] != "")
                    {
                        Trade trade = Bll_Trade.Select_TradeAndBook_TID(Convert.ToInt32(TradeTID[i]));
                        trades.Add(trade);
                        OSumPrice += trade.BCount * trade.BPrice;
                    }
                }
                if (!IsPostBack)
                {
                    Repeater1.DataSource = trades;
                    Repeater1.DataBind();
                }
                TextBox4.Text = OSumPrice.ToString();
                TextBox4.ReadOnly = true;
                //Response.Write(Request.QueryString["TradesTID"].ToString());
            }
            catch (Exception)
            {
                Response.Redirect("Main.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string OConsignee = TextBox1.Text;//收货人昵称
            string OAddress = TextBox2.Text;//地址
            string OTelephone = TextBox3.Text;//联系电话
            double OSumPrice = Convert.ToDouble(TextBox4.Text);//订单总消费
            bool UpdateSwitch = true;//修改库存开关
            string[] TradeTID = Request.QueryString["TradesTID"].ToString().Trim().Split('^');

            //遍历结算中商品的库存对比购买的数量,如果全部商品库存足够,则打开修改开关,否则关闭修改开关
            for (int i = 0; i < TradeTID.Length; i++)
            {
                if (TradeTID[i] != "")
                {
                    Trade trade = Bll_Trade.Select_TradeAndBook_TID(Convert.ToInt32(TradeTID[i]));
                    if (trade.BCount > Bll_Book.Select_BID(trade.BID).BCount)
                    {
                        UpdateSwitch = false;
                    }
                }
            }
            //修改订单内商品的库存和销量
            if (UpdateSwitch)
            {
                for (int i = 0; i < TradeTID.Length; i++)
                {
                    if (TradeTID[i] != "")
                    {
                        Trade trade = Bll_Trade.Select_TradeAndBook_TID(Convert.ToInt32(TradeTID[i]));
                        Bll_Book.Update_BCountAndBSaleCount(new Book()
                        {
                            BID = trade.BID,
                            BCount = trade.BCount
                        });
                    }
                }
                //为当前结算添加订单
                Order order = new Order()
                {
                    OID = Bll_Order.ObtainOID(),
                    MID = Bll_Member.GetMID(Request.Cookies["Login"].Values["MName"]),
                    ODate = DateTime.Now.ToString(),
                    OConsignee = OConsignee,
                    OAddress = OAddress,
                    OTelephone = OTelephone,
                    OSumPrice = OSumPrice,
                    OState = "1"
                };
                Bll_Order.Insert(order);
                //为订单添加订单明细
                for (int i = 0; i < TradeTID.Length; i++)
                {
                    if (TradeTID[i] != "")
                    {
                        Trade trade = Bll_Trade.Select_TradeAndBook_TID(Convert.ToInt32(TradeTID[i]));
                        Bll_OrderDetails.Insert(new OrderDetails() {
                            OID=order.OID,
                            BID=trade.BID,
                            BPrice=trade.BPrice,
                            BCount=trade.BCount
                        });
                    }
                }
                //清空当前用户购物车
                Bll_Trade.Delelte_MID(order.MID);
                //订单号页面
                Response.Redirect("Done.aspx?OID="+order.OID);
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(),"", "<script>alert('部分商品库存不足')</script>");
            }
        }
    }
}