using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
namespace Filtration
{
    public class MyFiltration : IHttpModule
    {
        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public void Init(HttpApplication context)
        {
            context.AcquireRequestState += Context_AcquireRequestState;
        }

        private void Context_AcquireRequestState(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            HttpApplication application = sender as HttpApplication;
            string url = application.Context.Request.CurrentExecutionFilePath;
            #region 页面存储
            List<string> Mpageurl = new List<string>();//用户所有页面
            List<string> Mpageurl1 = new List<string>();//用户无限制页面
            List<string> Apageurl = new List<string>();//管理员所有页面
            List<string> Apageurl1 = new List<string>();//管理员无限制页面

            Mpageurl.AddRange(new string[] {
                "/Category.aspx",
                "/Consignee.aspx",
                "/DeleteTrade.aspx",
                "/Done.aspx",
                "/Flow.aspx",
                "/Goods.aspx",
                "/Login.aspx",
                "/Main.aspx",
            });
            Mpageurl1.AddRange(new string[] {
                "/Category.aspx",
                "/Goods.aspx",
                "/Login.aspx",
                "/Main.aspx",
            });

            Apageurl.AddRange(new string[] {
                "/Admin/Default.aspx",
                "/Admin/DeleteBook.aspx",
                "/Admin/DeleteType.aspx",
                "/Admin/GoodAdd.aspx",
                "/Admin/GoodEdit.aspx",
                "/Admin/GoodLType.aspx",
                "/Admin/Goods.aspx",
                "/Admin/GoodSType.aspx",
                "/Admin/GoodSTypeAdd.aspx",
                "/Admin/GoodSTypeEdit.aspx",
                "/Admin/Main.aspx",
                "/Admin/ObtainCode.aspx",
                "/Admin/Orders.aspx",
                "/Admin/OrderDetail.aspx",
            });
            Apageurl1.AddRange(new string[] {
                "/Admin/Default.aspx",
                "/Admin/ObtainCode.aspx",
            });
            #endregion



            if (application.Context.Session == null)
            {
                return;
            }
            if (Mpageurl.Contains(url))//用户访问
            {
                if (!Mpageurl1.Contains(url))//用户限制访问
                {
                    if (application.Context.Request.Cookies["Login"] == null)
                    {
                        if (url == "/Login.aspx")
                        {
                            return;
                        }
                        application.Context.Response.Redirect("Login.aspx");
                    }
                }
            }

            if (Apageurl.Contains(url))//管理员访问
            {
                if (!Apageurl1.Contains(url))//管理员限制访问
                {
                    if (application.Context.Session["AName"] == null)
                    {
                        if (url == "/Admin/Default.aspx")
                        {
                            return;
                        }
                        application.Context.Response.Redirect("Default.aspx");
                    }
                }
            }
        }
    }
}
