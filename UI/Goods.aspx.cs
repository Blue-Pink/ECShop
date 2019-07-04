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
    public partial class Good : System.Web.UI.Page
    {
        protected Book book = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["BID"]!=null)
            {
                try
                {
                    if (!Bll_Book.Exists_BID(Convert.ToInt32(Request.QueryString["BID"])))
                    {
                        Response.Redirect("Main.aspx");
                    }
                }
                catch (Exception)
                {
                    Response.Redirect("Main.aspx");
                }
            }
            else
            {
                Response.Redirect("Main.aspx");
            }
            if (!IsPostBack)
            {
                TextBox1.Text = 1.ToString();
            }
            book = Bll_Book.Select_BID(Convert.ToInt32(Request.QueryString["BID"]));
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (Request.Cookies["Login"] != null)
            {
                Trade trade = new Trade()
                {
                    BCount = Convert.ToInt32(TextBox1.Text),
                    BID = Convert.ToInt32(Request.QueryString["BID"]),
                    MID = Bll_Member.GetMID(Request.Cookies["Login"].Values["MName"].ToString()),
                };
                if (Bll_Trade.Exits(trade))
                {
                    if (book.BCount > 0 && trade.BCount<=book.BCount)
                    {
                        Bll_Trade.Update_BCount(trade);
                        Response.Redirect("Goods.aspx?BID="+book.BID);
                    }
                    else
                    {
                        TextBox1.Text = "库存不足";
                    }

                }
                else
                {
                    if (book.BCount > 0 && trade.BCount <= book.BCount)
                    {
                        
                        Bll_Trade.Insert(trade); 
                        Response.Redirect("Goods.aspx?BID="+book.BID);
                    }
                    else
                    {
                        TextBox1.Text = "库存不足";
                    }
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}