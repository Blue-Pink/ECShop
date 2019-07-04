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
    public partial class WebUserControl3 : System.Web.UI.UserControl
    {
        public int TotalProduct { get; set; }
        public decimal TotalPrice { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            MyDataBind();
        }

        public void MyDataBind()
        {
            Repeater1.DataSource = Bll.Bll_BLCategory.Select_All();
            Repeater1.DataBind();
            if (Request.Cookies["Login"] != null)
            {
                List<Trade> trades = Bll_Trade.Select_TradeAndBook_MID((Bll_Member.GetMID(Request.Cookies["Login"].Values["MName"].ToString())));
                foreach (Trade trade in trades)
                {
                    TotalPrice += trade.BPrice * trade.BCount;
                }
                TotalProduct = trades.Count; 
            }
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            (e.Item.FindControl("Repeater2") as Repeater).DataSource = Bll_BSCategory.Select_BLID(((e.Item.DataItem)as Model.BLCategory).BLID);
            (e.Item.FindControl("Repeater2") as Repeater).DataBind();

        }
    }
}