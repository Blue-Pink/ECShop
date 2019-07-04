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
    public partial class goodEdit : System.Web.UI.Page
    {
        Book book = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AName"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            book = Bll_Book.Select_BID(Convert.ToInt32(Request.QueryString["BID"]));
            if (!IsPostBack)
            {
                DropDownList1.DataSource = Bll_BSCategory.Select_All();
                DropDownList1.DataValueField = "BSID";
                DropDownList1.DataTextField = "BLName";
                DropDownList1.DataBind();
                TextBox1.Text = book.BName;
                TextBox5.Text = book.BAuthor;
                TextBox2.Text = book.BISBN;
                DropDownList1.SelectedValue = book.BSID.ToString();
                TextBox3.Text = book.BPrice.ToString();
                TextBox4.Text = book.BCount.ToString();
                TextBox8.Text = book.BSaleCount.ToString();
                TextBox6.Text = book.BTOC;
                TextBox7.Text = book.BComment;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            string img = 
                FileUpload1.FileName != null && FileUpload1.FileName != "" ?
                random.Next() + DateTime.Now.Ticks + FileUpload1.FileName.Substring(FileUpload1.FileName.LastIndexOf('.')) :
                book.BPic;
            if (Bll_Book.Update_BID(new Book()
            {
                BID= Convert.ToInt32(Request.QueryString["BID"]),
                BName = TextBox1.Text,
                BAuthor = TextBox5.Text,
                BISBN = TextBox2.Text,
                BSID = Convert.ToInt32(DropDownList1.SelectedValue),
                BPrice = Convert.ToDecimal(TextBox3.Text),
                BCount = Convert.ToInt32(TextBox4.Text),
                BSaleCount = Convert.ToInt32(TextBox8.Text),
                BTOC = TextBox7.Text,
                BComment = TextBox6.Text,
                BPic = img
            }) > 0)
            {
                ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('修改成功')</script>");
                if (img!=book.BPic)
                {
                    FileUpload1.SaveAs(Server.MapPath("../BookImages") + "/" + img); 
                }
                Response.Redirect("Goods.aspx");
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('修改失败')</script>");
            }
        }
    }
}