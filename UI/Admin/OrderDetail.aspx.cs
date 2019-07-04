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
    public partial class OrderDetail : System.Web.UI.Page
    {
        protected decimal total = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Repeater1.DataSource = Bll_OrderDetails.Select_OID(Request.QueryString["OID"].ToString());
                Repeater1.DataBind();
            }
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                total += (e.Item.DataItem as OrderDetails).BPrice* (e.Item.DataItem as OrderDetails).BCount;
            }
        }
    }
}