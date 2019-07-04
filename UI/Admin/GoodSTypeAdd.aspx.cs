using Bll;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Admin
{
    public partial class GoodSTypeAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropDownList1.DataSource = Bll_BLCategory.Select_All();
                DropDownList1.DataValueField = "BLID";
                DropDownList1.DataTextField = "BLName";
                DropDownList1.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Bll_BSCategory.Insert(new BSCategory()
            {
                BLName = TextBox1.Text,
                BLID=Convert.ToInt32(DropDownList1.SelectedValue)
            });
            Response.Redirect("GoodSType.aspx");
        }
    }
}