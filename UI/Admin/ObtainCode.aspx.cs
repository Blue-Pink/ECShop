using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing.Drawing2D;
using System.Drawing;
namespace UI.Admin
{
    public partial class ObtainCode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Remove("Code");
            CreateImgInfo(GetCode());
        }

        public string GetCode() {
            Random random = new Random();
            string a = "1234567890abcdefghigkl1234567890mnopqrstuvwxyz1234567890ABCDEFGHIGKLMN1234567890OPQRSTUVWXYZ";
            string code = "";
            for (int i = 0; i < 5; i++)
            {
                code += a[random.Next(0, a.Length)];
            }
            Session["Code"] = code;
            return code;
        }

        public void CreateImgInfo(string code)
        {
            if (code == null || code == "")

                return;
            Bitmap img = new Bitmap(
               (int)Math.Ceiling(code.Length * 13.0), 22);
            Graphics g = Graphics.FromImage(img);
            //干扰线代码等下写
            //生成随机生成器
            Random random = new Random();
            //清空图片背景色
            g.Clear(Color.White);
            //画图片的背景噪音线
            for (int i = 0; i < 25; i++)
            {
                int x1 = random.Next(img.Width);
                int x2 = random.Next(img.Width);
                int y1 = random.Next(img.Height);
                int y2 = random.Next(img.Height);
                g.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
            }

            Font f = new Font("微软雅黑", 12, FontStyle.Bold);
            LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, img.Width, img.Height), Color.Blue, Color.DarkRed, 1.2f, true);
            g.DrawString(code, f, brush, 6, 2);
            g.DrawRectangle(new Pen(Color.Silver), 0, 0, img.Width - 1, img.Height - 1);
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            Response.ClearContent();
            Response.ContentType = "image/Gif";
            Response.BinaryWrite(ms.ToArray());


            g.Dispose();
            img.Dispose();


        }
    }
}