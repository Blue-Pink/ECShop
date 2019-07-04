using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bll;
using Model;
namespace UI
{
    public partial class Category : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //页大小
                int pagesize = 5;
                //当前页
                int pageindex = 1;
                //数据源
                List<Book> books = new List<Book>();
                //总页数
                int pagecount = 0;
                if (Request.QueryString["pageindex"] != null)
                {
                    pageindex = Convert.ToInt32(Request.QueryString["pageindex"]);
                }

                #region 大类别筛选分页
                if (Request.QueryString["BLID"] != null)
                {
                    string BLID = Request.QueryString["BLID"];
                    books = Bll_Book.Select_BLID(Convert.ToInt32(BLID));

                    pagecount = books.Count % pagesize == 0 ?
                    books.Count / pagesize :
                    books.Count / pagesize + 1;

                    Repeater1.DataSource = Bll_Book.TopPaging_BLID(pagesize, pageindex, Convert.ToInt32(BLID));
                    Repeater1.DataBind();
                    if (pageindex > 1)
                    {
                        HyperLink1.NavigateUrl = "Category.aspx?BLID=" + BLID + "&pageindex=1";
                        HyperLink2.NavigateUrl = "Category.aspx?BLID=" + BLID + "&pageindex=" + (pageindex - 1);
                    }
                    if (pageindex < pagecount)
                    {
                        HyperLink3.NavigateUrl = "Category.aspx?BLID=" + BLID + "&pageindex=" + (pageindex + 1);
                        HyperLink4.NavigateUrl = "Category.aspx?BLID=" + BLID + "&pageindex=" + pagecount;
                    }
                    Label1.Text = pageindex + " / " + pagecount;
                }
                #endregion

                #region 小类别筛选分页
                if (Request.QueryString["BSID"] != null)
                {
                    string BSID = Request.QueryString["BSID"];
                    books = Bll_Book.Select_BSID(Convert.ToInt32(BSID));

                    pagecount = books.Count % pagesize == 0 ?
                    books.Count / pagesize :
                    books.Count / pagesize + 1;

                    Repeater1.DataSource = Bll_Book.TopPaging_BSID(pagesize, pageindex, Convert.ToInt32(BSID));
                    Repeater1.DataBind();
                    if (pageindex > 1)
                    {
                        HyperLink1.NavigateUrl = "Category.aspx?BSID=" + BSID + "&pageindex=1";
                        HyperLink2.NavigateUrl = "Category.aspx?BSID=" + BSID + "&pageindex=" + (pageindex - 1);
                    }
                    if (pageindex < pagecount)
                    {
                        HyperLink3.NavigateUrl = "Category.aspx?BSID=" + BSID + "&pageindex=" + (pageindex + 1);
                        HyperLink4.NavigateUrl = "Category.aspx?BSID=" + BSID + "&pageindex=" + pagecount;
                    }
                    Label1.Text = pageindex + " / " + pagecount;
                }
                #endregion

                #region 书名筛选分页
                if (Request.QueryString["BName"] != null)
                {
                    string BName = Request.QueryString["BName"];
                    books = Bll_Book.DimSelect_BName(BName);

                    pagecount = books.Count % pagesize == 0 ?
                   books.Count / pagesize :
                   books.Count / pagesize + 1;

                    Repeater1.DataSource = Bll_Book.TopPaging_BName(BName,pagesize, pageindex);
                    Repeater1.DataBind();
                    if (pageindex > 1)
                    {
                        HyperLink1.NavigateUrl = "Category.aspx?BName=" + BName + "&pageindex=1";
                        HyperLink2.NavigateUrl = "Category.aspx?BName=" + BName + "&pageindex=" + (pageindex - 1);
                    }
                    if (pageindex < pagecount)
                    {
                        HyperLink3.NavigateUrl = "Category.aspx?BName=" + BName + "&pageindex=" + (pageindex + 1);
                        HyperLink4.NavigateUrl = "Category.aspx?BName=" + BName + "&pageindex=" + pagecount;
                    }
                    Label1.Text = pageindex + " / " + pagecount;
                }
                #endregion
            }
        }
    }
}
