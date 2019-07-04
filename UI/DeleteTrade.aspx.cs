using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bll;
namespace UI
{
    public partial class DeleteTrade : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["TID"]!=null)
            {
                Bll_Trade.Delete_TID(Convert.ToInt32(Request.QueryString["TID"])); 
            }
            Response.Redirect("Flow.aspx");
        }
    }
}