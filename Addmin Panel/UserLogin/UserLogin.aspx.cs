using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Addmin_Panel_UserLogin_UserLogin : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    #endregion Load Event

    #region Button | Login
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        #region Server Side Validation
        if (txtUserName.Text.Trim()=="")
        {
            lblMassage.Text += "- Enter User Name</br>";
            lblMassage.ForeColor = Color.Red;
        }
        if (txtPassword.Text.Trim() == "")
        {
            lblMassage.ForeColor = Color.Red;
            lblMassage.Text += "- Enter  Password</br>";
        }
        #endregion Server Side Validation
        #region Local Variable
        SqlString strUserName = SqlString.Null;
        SqlString strPassword = SqlString.Null;
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        #endregion Local Variable
        try
        {
           

            #region Assign The Value
            if(txtUserName.Text.Trim() != "")
            {
                strUserName = txtUserName.Text.Trim(); 
            }
            if(txtPassword.Text.Trim() != "")
            {
                strPassword = txtPassword.Text.Trim();
            }
            #endregion Assign The Value

            #region Set The Connection
            if(objConn.State != ConnectionState.Open)
            {
                objConn.Open();
                SqlCommand objCmd = objConn.CreateCommand();
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "PR_User_SelectByUserNamePassword";
                objCmd.Parameters.AddWithValue("@UserName", strUserName);
                objCmd.Parameters.AddWithValue("@Password", strPassword);

                SqlDataReader objSDR = objCmd.ExecuteReader();
                if(objSDR.HasRows)
                {
                    while(objSDR.Read())
                    {
                       if(!objSDR["UserID"].Equals(DBNull.Value))
                       {
                           Session["UserId"] = objSDR["UserID"].ToString().Trim();
                       }
                       if (!objSDR["DisplayName"].Equals(DBNull.Value))
                       {
                           Session["DisplayName"] = objSDR["DisplayName"].ToString().Trim();
                       }
                       break;
                    }
                    Response.Redirect("~/AddminPanel/Home");

                }
                else
                {
                    lblMassage.Text = "Either UserName OR Password Are Not Valid Try Again";
                }
                objConn.Close();
            }



            #endregion Set The Connection

        }
        catch (Exception ex)
        {
            lblMassage.Text = ex.Message;
        }
        finally
        {
           if(objConn.State == ConnectionState.Open)
           {
               objConn.Close();
           }
        }
    }

    #endregion Button | Login
}