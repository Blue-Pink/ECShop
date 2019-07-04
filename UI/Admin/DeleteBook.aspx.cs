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
    public partial class DeleteBook : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Bll_Book.Delete_BID(Convert.ToInt32(Request.QueryString["BID"]));
            Response.Redirect("Goods.aspx");
        }
    }
}