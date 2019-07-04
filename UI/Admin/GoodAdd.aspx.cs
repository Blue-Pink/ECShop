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
    public partial class GoodAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropDownList1.DataSource = Bll_BSCategory.Select_All();
                DropDownList1.DataValueField = "BSID";
                DropDownList1.DataTextField = "BLName";
                DropDownList1.DataBind();
                TextBox2.Text = (Bll_Book.Select_MaxBISBN()+1).ToString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            string img = random.Next() + DateTime.Now.Ticks + FileUpload1.FileName.Substring(FileUpload1.FileName.LastIndexOf('.'));
            if (Bll_Book.Insert(new Book()
            {
                BID=Bll_Book.Select_MaxBID()+1,
                BSID = Convert.ToInt32(DropDownList1.SelectedValue),
                BName = Convert.ToString(TextBox1.Text),
                BAuthor = Convert.ToString(TextBox5.Text),
                BISBN = Convert.ToString(TextBox2.Text),
                BPrice = Convert.ToDecimal(TextBox3.Text),
                BCount = Convert.ToInt32(TextBox4.Text),
                BPic = img,
                BDate = DateTime.Now,
            }) > 0)
            {
                FileUpload1.SaveAs(Server.MapPath("../BookImages") + "/" + img);
                Response.Redirect("Goods.aspx");
            }
        }
    }
}