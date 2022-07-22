using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Content_MultiUserAddressBook : System.Web.UI.MasterPage
{
    #region load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("~/AddminPanel/UserLogin", true);
        }
        if(!Page.IsPostBack)
        {
           
            if (Session["DisplayName"] != null)
            {
                lblDisplayName.Text = "Hi" +"  "+ Session["DisplayName"] +"!";
            }
        }
      
    }
    #endregion load Event
    protected void lbtnLogout_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Response.Redirect("~/AddminPanel/UserLogin", true);
    }
}
