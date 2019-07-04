using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using Bll;
namespace UI.Admin
{
    public partial class Goods : System.Web.UI.Page
    {
        //当前页
        int pageindex = 1;
        //页大小
        int pagesize = 5;
        //总页数
        int pagecount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["pagesize"] != null)
            {
                pagesize = Convert.ToInt32(Session["pagesize"]);
            }
            if (!IsPostBack)
            {
                GoodsPaging();
            }
        }

        /// <summary>
        /// 页面:Goods.aspx (为Repeater1添加数据源并产生分页
        /// </summary>
        private void GoodsPaging()
        {
            pagecount = Bll_Book.RowCount() % pagesize == 0 ? Bll_Book.RowCount() / pagesize : Bll_Book.RowCount() / pagesize + 1;
            List<Book> books = new List<Book>();

            if (Request.QueryString["pageindex"] != null)
            {
                pageindex = Convert.ToInt32(Request.QueryString["pageindex"]);
            }

            if (Request.QueryString["pageindex"] != null)
            {
                if (Convert.ToInt32(Request.QueryString["pageindex"]) > pagecount)
                {
                    pageindex = pagecount;
                }
            }

            if (Request.QueryString["BName"] != null)
            {

                pagecount =
                    Bll_Book.RowCount_BName(Request.QueryString["BName"].ToString()) % pagesize == 0 ?
                    Bll_Book.RowCount_BName(Request.QueryString["BName"].ToString()) / pagesize :
                    Bll_Book.RowCount_BName(Request.QueryString["BName"].ToString()) / pagesize + 1;

                if (Request.QueryString["pageindex"] != null)
                {
                    if (Convert.ToInt32(Request.QueryString["pageindex"]) > pagecount)
                    {
                        pageindex = pagecount;
                    }
                }

                books = Bll_Book.TopPaging_BName(Request.QueryString["BName"], pagesize, pageindex);
                Repeater1.DataSource = books;
                Repeater1.DataBind();
            }
            else
            {
                books = Bll_Book.TopPaging(pagesize, pageindex);
                Repeater1.DataSource = books;
                Repeater1.DataBind();
            }

            if (pageindex > 1)
            {
                HyperLink1.NavigateUrl = "Goods.aspx?pageindex=1" + (Request.QueryString["BName"] == null ? "" : "&BName=" + Request.QueryString["BName"]);
                HyperLink2.NavigateUrl = "Goods.aspx?pageindex=" + (pageindex - 1) + (Request.QueryString["BName"] == null ? "" : "&BName=" + Request.QueryString["BName"]);
            }
            if (pageindex < pagecount)
            {
                HyperLink3.NavigateUrl = "Goods.aspx?pageindex=" + (pageindex + 1) + (Request.QueryString["BName"] == null ? "" : "&BName=" + Request.QueryString["BName"]);
                HyperLink4.NavigateUrl = "Goods.aspx?pageindex=" + pagecount + (Request.QueryString["BName"] == null ? "" : "&BName=" + Request.QueryString["BName"]);
            }

            Label1.Text = pagecount.ToString();
            Label2.Text = pagesize.ToString();
            Label3.Text = pageindex.ToString();
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {
            if (TextBox2.Text != "" && TextBox2.Text != null && TextBox2.Text.Trim() != "")
            {
                Session["pagesize"] = TextBox2.Text;
                pagesize = Convert.ToInt32(TextBox2.Text);
                GoodsPaging();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text != null && TextBox1.Text != "" && TextBox1.Text.Trim() != "")
            {
                Response.Redirect("Goods.aspx?BName=" + TextBox1.Text);
            }
            else
            {
                Response.Redirect("Goods.aspx");
            }
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                pagecount = Bll_Book.RowCount() % pagesize == 0 ? Bll_Book.RowCount() / pagesize : Bll_Book.RowCount() / pagesize + 1;
                if (Convert.ToInt32(TextBox3.Text) <= pagecount)
                {
                    Response.Redirect("Goods.aspx?pageindex=" + TextBox3.Text + (Request.QueryString["BName"] == null ? "" : "&BName=" + Request.QueryString["BName"]));
                }
                else
                {
                    TextBox3.Text = "页码超出";
                }
            }
            catch (Exception)
            {
                TextBox3.Text = "错误";
            }
        }
    }
}