using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bll;
using Model;
namespace UI.Admin
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["AName"]!=null)
            //{
            //    Response.Redirect("Main.aspx");
            //}
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox3.Text.Equals(Session["Code"].ToString(),StringComparison.OrdinalIgnoreCase))
            {
                if (Bll_Admin.Login(new Model.Admin()
                {
                    AName = TextBox1.Text,
                    APassword = TextBox2.Text
                }) > 0)
                {
                    Session["AName"] = TextBox1.Text;
                    Response.Redirect("Main.aspx");
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('管理员信息填写有误')</script>");
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(),"","<script>alert('验证码错误')</script>");
                TextBox3.Text = "";
            }
        }
    }
}