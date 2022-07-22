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

public partial class Addmin_Panel_UserRegistration_UserRegistration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    #region Button | Save
    protected void btnSave_Click(object sender, EventArgs e)
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
         if (txtDisplayName.Text.Trim() == "")
        {
            lblMassage.ForeColor = Color.Red;
            lblMassage.Text += "- Enter  Password</br>";
        }
         if (txtEmail.Text.Trim() == "")
         {
             lblMassage.ForeColor = Color.Red;
             lblMassage.Text += "- Enter  Password</br>";
         }
         if (txtContactNumber.Text.Trim() == "")
         {
             lblMassage.ForeColor = Color.Red;
             lblMassage.Text += "- Enter  Password</br>";
         }
      
        #endregion Server Side Validation
        #region Local Variable
        SqlString strUserName = SqlString.Null;
        SqlString strPassword = SqlString.Null;
        SqlString strDisplayName = SqlString.Null;
        SqlString strEmail = SqlString.Null;
        SqlString strContactNumber = SqlString.Null;
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
            if (txtDisplayName.Text.Trim() != "")
            {
                strDisplayName = txtDisplayName.Text.Trim();
            }
            if (txtEmail.Text.Trim() != "")
            {
                strEmail = txtEmail.Text.Trim();
            }
            if (txtContactNumber.Text.Trim() != "")
            {
                strContactNumber = txtContactNumber.Text.Trim();
            }
            #endregion Assign The Value

            #region Set The Connection
            if(objConn.State != ConnectionState.Open)
            {
                objConn.Open();
                SqlCommand objCmd = objConn.CreateCommand();
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "[PR_User_Insert]";
                objCmd.Parameters.AddWithValue("@UserName", strUserName);
                objCmd.Parameters.AddWithValue("@Password", strPassword);
                objCmd.Parameters.AddWithValue("@DisplayName", strDisplayName);
                objCmd.Parameters.AddWithValue("@Email", strEmail);
                objCmd.Parameters.AddWithValue("@ContectNo", strContactNumber);
                objCmd.ExecuteNonQuery();
                
               
                objConn.Close();
                lblMassage.Text = "Insert Data SuccessFuly";
                lblMassage.ForeColor = Color.Green;
                txtUserName.Text = "";
                txtPassword.Text = "";
                txtDisplayName.Text = "";
                txtEmail.Text = "";
                txtContactNumber.Text = "";

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

    #endregion Button | Save

}