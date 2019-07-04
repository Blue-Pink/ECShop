using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI
{
    public partial class WebUserControl2 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MyDataBind();
        }

        public void MyDataBind() {
            Repeater1.DataSource = Bll.Bll_BLCategory.Select_All();
            Repeater1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text!="")
            {
                Response.Redirect("Category.aspx?BName="+TextBox1.Text);
            }
        }
    }
}