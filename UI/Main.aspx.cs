using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bll;
namespace UI
{
    public partial class Main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                Repeater1.DataSource = Bll_Book.DOrderBy_BSaleCount();
                Repeater1.DataBind();

                Repeater2.DataSource = Bll_Book.DOrderBy_BDate();
                Repeater2.DataBind();
            }
        }
    }
}