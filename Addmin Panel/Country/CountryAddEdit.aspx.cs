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

public partial class Addmin_Panel_Country_CountryAddEdit : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            if (Page.RouteData.Values["OperationName"].ToString().Trim() != "Add")
            {
                var Base64DataBytes = Convert.FromBase64String(Page.RouteData.Values["CountryID"].ToString());
                FillControls(Convert.ToInt32(System.Text.Encoding.UTF8.GetString(Base64DataBytes)));
            }
            else
            {
                //(Page.RouteData.Values['Opration'].ToString().Trim() != "Add")
                if (Request.QueryString["CountryID"] == null)
                {
                    lblMassge.Text = "Add Mode";
                    lblMassge.ForeColor = Color.Green;
                }
            }
        }
    }
    #region Button | Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Local Variables
        SqlString strCountryName = SqlString.Null;
        SqlInt32 intCountryCode = SqlInt32.Null;
        SqlInt32 intUserID = SqlInt32.Null;
       

        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        #endregion Local Variables
        if (txtCountryCode.Text.Trim() != null)
        {
            intCountryCode = Convert.ToInt32(txtCountryCode.Text.Trim());
        }
        if (txtCountryName.Text.Trim() != null)
        {
            strCountryName = txtCountryName.Text.Trim();
        }
        if (Session["UserID"] != null)
        {
            intUserID = Convert.ToInt32( Session["UserId"]);
        }
        try
        {

            #region Set Connection & Command Object

            if (objConn.State != ConnectionState.Open)
            {
                objConn.Open();

                SqlCommand objCmd = objConn.CreateCommand();
                objCmd.CommandType = CommandType.StoredProcedure;

                #region Gather Information
              
                objCmd.Parameters.AddWithValue("@CountryCode", intCountryCode);

             
                objCmd.Parameters.AddWithValue("@CountryName", strCountryName);
                objCmd.Parameters.AddWithValue("@UserID", intUserID);
                #endregion Gather Information


            #endregion Set Connection & Command Object


                #region Update Record
                if (Page.RouteData.Values["OperationName"].ToString().Trim() != "Add")
                {
                    var Base64DataBytes = Convert.FromBase64String(Page.RouteData.Values["CountryID"].ToString());

                    objCmd.Parameters.AddWithValue("@CountryID",System.Text.Encoding.UTF8.GetString(Base64DataBytes));
                    objCmd.CommandText = "[PR_Country_UpdateByPK_UserID]";
                    objCmd.ExecuteNonQuery();
                    Response.Redirect("~/AddminPanel/Country/List");


                }
                #endregion Update Record
                else
                {

                    #region Insert Record

                    objCmd.CommandText = "[PR_Country_InsertByUserId]";
                    objCmd.ExecuteNonQuery();

                    txtCountryName.Text = "";
                    txtCountryCode.Text = "";

                    txtCountryName.Focus();
                    lblMassge.Text = "Data ADD Successfuly";
                    lblMassge.ForeColor = Color.Green;

                    #endregion Insert Record
                }






                objConn.Close();
            }
        }
        catch (Exception ex)
        {
            lblMassge.Text = ex.Message;
        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
            {
                objConn.Close();
            }
        }
    }

    #endregion Button | Save

    #region Fill Controls
    private void FillControls(SqlInt32 CountryID)
    {

        #region Local Variable
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
         SqlInt32 intUserID = SqlInt32.Null;

        #endregion Local Variable
        if (Session["UserID"] != null)
        {
            intUserID = Convert.ToInt32(Session["UserId"]);
        }
        try
        {
            #region Set Connection & Command Object

            if (objConn.State != ConnectionState.Open)
            {
                objConn.Open();
                SqlCommand objCmd = objConn.CreateCommand();
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "[PR_Country_SelectAllByPK_UserID]";
                objCmd.Parameters.AddWithValue("@CountryID", CountryID.ToString().Trim());
                objCmd.Parameters.AddWithValue("@UserID", intUserID);
                SqlDataReader objSDR = objCmd.ExecuteReader();
                lblMassge.Text = "Edit Mode";
                lblMassge.ForeColor = Color.Green;

            #endregion Set Connection & Command Object


                #region Read The Value And Set The Controals
                if (objSDR.HasRows)
                {
                    while (objSDR.Read())
                    {
                        if (!objSDR["CountryName"].Equals(DBNull.Value))
                        {
                            txtCountryName.Text = objSDR["CountryName"].ToString().Trim();
                        }
                        if (!objSDR["CountryCode"].Equals(DBNull.Value))
                        {
                            txtCountryCode.Text = objSDR["CountryCode"].ToString().Trim();
                        }
                        break;
                    }
                }
                else
                {
                    lblMassge.Text = "Data Is Not Available";
                }
                #endregion Read The Value And Set The Controals
            }
        }
        catch (Exception ex)
        {
            lblMassge.Text = ex.Message;
        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
            {
                objConn.Close();
            }
        }
    }
    #endregion Fill Controls
}
