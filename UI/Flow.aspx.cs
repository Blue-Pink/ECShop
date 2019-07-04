using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bll;
using Model;
namespace UI
{
    public partial class Flow : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["Login"] != null)
                {
                    Repeater1.DataSource = Bll_Trade.Select_TradeAndBook_MID(Bll_Member.GetMID(Request.Cookies["Login"].Values["MName"].ToString()));
                    Repeater1.DataBind();
                }
            }
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex != -1)
            {
                (e.Item.FindControl("Label1") as Label).Text = ((e.Item.DataItem as Trade).BCount * (e.Item.DataItem as Trade).BPrice).ToString();
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            bool thisSwitch = false;
            foreach (RepeaterItem item in Repeater1.Items)
            {
                if ((item.FindControl("CheckBox1") as CheckBox).Checked)
                {
                    thisSwitch = true;
                }
            }

            if (!thisSwitch)
            {
                return;
            }

            string TradesTID = "";
            foreach (RepeaterItem item in Repeater1.Items)
            {
                if ((item.FindControl("CheckBox1") as CheckBox).Checked)
                {
                    TradesTID += (item.FindControl("Label2") as Label).Text + "^";
                }
            }
            Response.Redirect("Consignee.aspx?TradesTID=" + TradesTID);
        }

        protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            foreach (RepeaterItem item in Repeater1.Items)
            {
                (item.FindControl("CheckBox1") as CheckBox).Checked = (sender as CheckBox).Checked;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
                foreach (RepeaterItem item in Repeater1.Items)
            {
                    Bll_Trade.Update_BCount(Convert.ToInt32((item.FindControl("TextBox1") as TextBox).Text),Convert.ToInt32((item.FindControl("Label2") as Label).Text));
                Response.Redirect("Flow.aspx");
            }
        }
    }
}