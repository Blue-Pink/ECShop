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
    public partial class GoodSTypeEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropDownList1Bind();
                GrideView1Bind();
            }

            if (Request.QueryString["BSID"]!=null)
            {
                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    if (Convert.ToInt32(GridView1.DataKeys[i].Value)== Convert.ToInt32(Request.QueryString["BSID"]))
                    {
                        GridView1.Rows[i].Style.Add("background-color","lightgreen");
                    }
                }
            }
        }

        private void GrideView1Bind()
        {
            if (Request.QueryString["BLID"] != null)
            {
                DropDownList1.SelectedValue = Request.QueryString["BLID"];
                GridView1.DataSource = Bll_BSCategory.Select_BLAndBS_BLID(Convert.ToInt32(Request.QueryString["BLID"]));
                GridView1.DataBind();

            }
            else
            {
                GridView1.DataSource = Bll_BSCategory.Select_All();
                GridView1.DataBind();
            }

        }

        private void DropDownList1Bind()
        {
            DropDownList1.DataSource = Bll_BLCategory.Select_All();
            DropDownList1.DataValueField = "BLID";
            DropDownList1.DataTextField = "BLName";
            DropDownList1.DataBind();
            if (Request.QueryString["BLID"]!=null)
            {
                DropDownList1.SelectedValue = Request.QueryString["BLID"];
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            GridView1.EditIndex = e.NewEditIndex;
            GrideView1Bind();
            GridView1.Rows[e.NewEditIndex].Style.Add("background-color", "skyblue");
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            GrideView1Bind();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Bll_BSCategory.Delete_BSID(Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value));
            GrideView1Bind();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string BLName = ((GridView1.Rows[e.RowIndex].Cells[0].Controls[0]).FindControl("TextBox1") as TextBox).Text;
            int BLID = Convert.ToInt32((GridView1.Rows[e.RowIndex].FindControl("DropDownList2") as DropDownList).SelectedItem.Value);
            int BSID = Convert.ToInt32(GridView1.DataKeys[GridView1.EditIndex].Value);
            //Response.Write(BLName+"__"+BLID+"__"+BSID);
            Bll_BSCategory.Update(new BSCategory()
            {
                BLID = BLID,
                BSID = BSID,
                BLName = BLName
            });

            GridView1.EditIndex = -1;
            GrideView1Bind();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Style.Add("color", "green");
            }
            if (e.Row.RowIndex != -1)
            {
                e.Row.Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='lightpink'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='white'");
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("GoodSTypeEdit.aspx?BLID=" + DropDownList1.SelectedValue);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Bll_BLCategory.Update(new BLCategory()
            {
                BLID = Convert.ToInt32(Request.QueryString["BLID"]),
                BLName = TextBox2.Text
            });
            DropDownList1Bind();
        }

    }
}