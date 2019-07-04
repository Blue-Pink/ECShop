using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Admin
{
    public partial class DeleteType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["BLID"]!=null)
            {
                Bll.Bll_BLCategory.Delete_BLID(Convert.ToInt32(Request.QueryString["BLID"]));
                Response.Redirect("GoodLType.aspx"); 
            }
            if (Request.QueryString["BSID"] != null)
            {
                Bll.Bll_BSCategory.Delete_BSID(Convert.ToInt32(Request.QueryString["BSID"]));
                Response.Redirect("GoodSType.aspx");
            }
        }
    }
}