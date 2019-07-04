 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI
{
    public partial class WebUserControl1 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            #region Session
            //if (Session["MName"] == null)
            //{
            //    Image1.Style.Add("Display", "inline");
            //    Image2.Style.Add("Display", "inline");
            //    Label1.Style.Add("Display", "none");
            //    Button1.Style.Add("Display", "none");
            //}
            //else
            //{
            //    Image1.Style.Add("Display", "none");
            //    Image2.Style.Add("Display", "none");
            //    Label1.Text = Convert.ToString(Session["MName"]);
            //    Label1.Style.Add("Display", "inline");
            //    Button1.Style.Add("Display", "inline");
            //} 
            #endregion

            #region Cookie
            HttpCookie cookie = Request.Cookies["Login"];
            if (cookie == null)
                {
                    Image1.Style.Add("Display", "inline");
                    Image2.Style.Add("Display", "inline");
                    Label1.Style.Add("Display", "none");
                    Button1.Style.Add("Display", "none");
                }
                else
                {
                    Image1.Style.Add("Display", "none");
                    Image2.Style.Add("Display", "none");
                    Label1.Text = Convert.ToString(cookie.Values["MName"]);
                    Label1.Style.Add("Display", "inline");
                    Button1.Style.Add("Display", "inline");
                } 
            #endregion
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            #region Session
            //Session["MName"] = null;
            #endregion

            #region Cookie
            HttpCookie changeCookie = new HttpCookie("Login"); //使名称为Login的Cookies失效，就把HttpCookie对象的Cookie名称写成Login，相当于用新Login覆盖了旧的Login，Cookie可以覆盖
            changeCookie["MName"] = ""; //依然设置属性值，无法读取，证明Cookie已经失效
            changeCookie.Expires = DateTime.Now.AddDays(-1); //设定Cookies的有效期为无效时间即可让该Cookie失效
            Response.Cookies.Add(changeCookie);

            #endregion

            Response.Redirect("Main.aspx");
        }
    }
}