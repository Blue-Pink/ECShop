using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bll;
using Model;
namespace UI
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["Login"]!=null)
            {
                Response.Redirect("Main.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Bll_Member.Registered(TextBox3.Text))
            {
                ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('此用户已注册')</script>");
            }
            else
            {
                if (Bll_Member.Register(new Member()
                {
                    MEmail = TextBox4.Text,
                    MName = TextBox3.Text,
                    MPassword = TextBox6.Text
                }) > 0)
                {
                    ClientScript.RegisterStartupScript(GetType(),"","<script>alert('注册成功')</script>");
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (Bll_Member.Login(new Member()
            {
                MName =TextBox1.Text,
                MPassword =TextBox2.Text})>0)
            {
                //Session["MName"] = TextBox1.Text;

                HttpCookie keepCookie = new HttpCookie("Login"); //创建一个HttpCookie实例，Cookies名称为Login，实例只是一个容器，真正使用的是Cookie名称
                keepCookie["MName"] = TextBox1.Text; //向Login中添加一个userName属性，并赋值
                keepCookie.Expires = DateTime.Now.AddDays(2); //设定Cookies的有效期为两天
                Response.Cookies.Add(keepCookie); //把Cookies对象返回给客户端

                Response.Redirect("Main.aspx");
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('用户名或密码错误')</script>");
            }
        }
    }
}