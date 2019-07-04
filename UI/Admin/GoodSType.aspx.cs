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
    public partial class GoodSType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["BLID"]==null)
                {
                    Repeater1.DataSource = Bll_BSCategory.Select_All();
                    Repeater1.DataBind();
                }
                else
                {
                    Repeater1.DataSource = Bll_BSCategory.Select_BLAndBS_BLID(Convert.ToInt32(Request.QueryString["BLID"]));
                    Repeater1.DataBind();
                }
            }
        }
    }
}