using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Addmin_Panel_Contact_ContactList : System.Web.UI.Page
{
    #region load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            FillGridview();
        }

    }
    #endregion load Event

    #region Fill Grid view
    private void FillGridview()
    {
        #region Local Variable
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        SqlInt32 IntUserID = SqlInt32.Null;
        #endregion Local Variable
        if (Session["UserID"] != null)
        {
            IntUserID = Convert.ToInt32(Session["UserId"]);
        }
        try
        {
            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
            {


                objConn.Open();

                SqlCommand objComm = objConn.CreateCommand();

                objComm.CommandType = CommandType.StoredProcedure;
                objComm.CommandText = "[dbo].[PR_ContectWiseContactCategory_Contact_SelectALL]";
                objComm.Parameters.AddWithValue("@UserID", IntUserID);

                SqlDataReader objSDR = objComm.ExecuteReader();
                gvContact.DataSource = objSDR;
                gvContact.DataBind();
            }
            #endregion Set Connection & Command Object
        }
        catch (Exception ex)
        {
            lblmassge.Text = ex.Message;
        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
            {
                objConn.Close();
            }
        }
    }

    #endregion Fill Grid view


    #region gvContact | RowCommand
    protected void gvContact_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument != null)
            {
                DeleteContact(Convert.ToInt32(e.CommandArgument.ToString().Trim()));

            }
        }
    }
    #endregion gvContact | RowCommand

    #region Delete Contact
    private void DeleteContact(SqlInt32 ContactID)
    {
        #region Local Variable
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        SqlInt32 IntUserID = SqlInt32.Null;
        String ContactPhotoPath = "";
        #endregion Local Variable
        if (Session["UserID"] != null)
        {
            IntUserID = Convert.ToInt32(Session["UserId"]);
        }
        {
            try
            {
                #region Set Connection & Command Object
                objConn.Open();

                SqlCommand ObjCmd = new SqlCommand();

                ObjCmd.Connection = objConn;
                ObjCmd.CommandType = CommandType.StoredProcedure;
                ObjCmd.Parameters.AddWithValue("@ContactID", ContactID);
                ObjCmd.Parameters.AddWithValue("@UserID", IntUserID);
                ObjCmd.CommandText = "[dbo].[PR_Contact_SelectByPK_UserID]";

                SqlDataReader objSDR = ObjCmd.ExecuteReader();

                if (objSDR.HasRows)
                {
                    while (objSDR.Read())
                    {
                        if (!objSDR["ContactPhotoPath"].Equals(DBNull.Value))
                        {
                            ContactPhotoPath = objSDR["ContactPhotoPath"].ToString().Trim();
                            objSDR.Close();
                        }
                        
                        break;
                    }
                }
                else
                {
                    lblmassge.Text = "Data Will Not Found";
                }


                FileInfo file = new FileInfo(Server.MapPath(ContactPhotoPath));
                if (file.Exists)
                {
                    file.Delete();
                    ObjCmd.CommandText = "[PR_Contact_DeleteByPK]";
                    ObjCmd.CommandText = "PR_ContactWiseCategory_DeleteByPK_UserID";
                    
                    ObjCmd.ExecuteNonQuery();

                }










                objConn.Close();
                FillGridview();
                #endregion Set Connection & Command Object
            }
            catch (Exception ex)
            {
                lblmassge.Text = ex.Message;
            }
            finally
            {
                objConn.Close();
            }

        }
    }
    #endregion Delete Contact


}