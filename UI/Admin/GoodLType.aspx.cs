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
    public partial class GoodLType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Repeater1.DataSource = Bll_BLCategory.Select_All();
                Repeater1.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text!=""&&TextBox1.Text!=null&&TextBox1.Text.Trim()!="")
            {
                Bll_BLCategory.Insert(new BLCategory()
                {
                    BLName = TextBox1.Text
                });
                Response.Redirect("GoodLType.aspx");
            }
        }
    }
}