using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bll;
using Model;
namespace UI.Admin
{
    public partial class Orders : System.Web.UI.Page
    {
        protected int pagesize = 5;//页大小
        protected int pageindex = 1;//当前页
        protected int pagecount = 1;//页大小
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["pagesize"] != null)
            {
                pagesize = Convert.ToInt32(Session["pagesize"]);
            }
            if (Request.QueryString["pageindex"] != null)
            {
                Repeater1Paging();
            }
            if (!IsPostBack)
            {
                if (Request.QueryString["pageindex"] == null)
                {
                    Repeater1.DataSource = Bll_Order.Select_All();
                    Repeater1.DataBind();
                }
            }
        }

        void Repeater1Paging()
        {
            if (Request.QueryString["pageindex"] != null)
            {
                pageindex = Convert.ToInt32(Request.QueryString["pageindex"]);
            }

            pagecount = Bll_Order.RowCount() % pagesize == 0 ? Bll_Order.RowCount() / pagesize : Bll_Order.RowCount() / pagesize + 1;

            if (Request.QueryString["pageindex"] != null)
            {
                if (Convert.ToInt32(Request.QueryString["pageindex"]) > pagecount)
                {
                    pageindex = pagecount;
                }
            }

            List<Order> orders = Bll_Order.Paging(pageindex, pagesize);
            Repeater1.DataSource = orders;
            Repeater1.DataBind();

            if (pageindex > 1)
            {
                HyperLink1.NavigateUrl = "Orders.aspx?pageindex=1";
                HyperLink2.NavigateUrl = "Orders.aspx?pageindex=" + (pageindex - 1);
            }
            if (pageindex < pagecount)
            {
                HyperLink3.NavigateUrl = "Orders.aspx?pageindex=" + (pageindex + 1);
                HyperLink4.NavigateUrl = "Orders.aspx?pageindex=" + pagecount;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if ((TextBox1.Text != null && TextBox1.Text != "" && TextBox1.Text.Trim() != "") && (TextBox4.Text == null || TextBox4.Text == "" || TextBox4.Text.Trim() == ""))
            {
                Repeater1.DataSource = Bll_Order.Select_OID(TextBox1.Text);
                Repeater1.DataBind();
            }
            if ((TextBox1.Text == null || TextBox1.Text == "" || TextBox1.Text.Trim() == "") && (TextBox4.Text != null && TextBox4.Text != "" && TextBox4.Text.Trim() != ""))
            {
                Repeater1.DataSource = Bll_Order.Select_OConsignee(TextBox4.Text);
                Repeater1.DataBind();
            }
            if ((TextBox1.Text != null && TextBox1.Text != "" && TextBox1.Text.Trim() != "") && (TextBox4.Text != null && TextBox4.Text != "" && TextBox4.Text.Trim() != ""))
            {
                Repeater1.DataSource = Bll_Order.Select_OConsignee_OID(TextBox4.Text, TextBox1.Text);
                Repeater1.DataBind();
            }
            if ((TextBox1.Text == null || TextBox1.Text == "" || TextBox1.Text.Trim() == "") && (TextBox4.Text == null || TextBox4.Text == "" || TextBox4.Text.Trim() == ""))
            {
                Session.Remove("pagesize");
                Response.Redirect("Orders.aspx"/* + (Request.QueryString["pageindex"] == null ? "" : "?pageindex=" + Request.QueryString["pageindex"].ToString())*/);
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Bll_Order.UpdateOState_OID((sender as Button).CommandName, Convert.ToInt32((sender as Button).AccessKey));
            Response.Redirect("Orders.aspx");
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {
            Session["pagesize"] = TextBox2.Text;
            pagesize = Convert.ToInt32(TextBox2.Text);
            Repeater1Paging();
        }
    }
}