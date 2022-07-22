using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Addmin_Panel_State_StateList : System.Web.UI.Page
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


    #region FillGridview
    private void FillGridview()
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
            objConn.Open();

            SqlCommand ObjCmd = new SqlCommand();

            ObjCmd.Connection = objConn;
            ObjCmd.CommandType = CommandType.StoredProcedure;
            ObjCmd.CommandText = "[PR_State_SelectAllByUserID]";
            ObjCmd.Parameters.AddWithValue("@UserID", intUserID);
            SqlDataReader objSDR = ObjCmd.ExecuteReader();
            #endregion Set Connection & Command Object

            #region Read The Value And Set The Controals
            if (objSDR.HasRows)
            {


                gvState.DataSource = objSDR;
                gvState.DataBind();

            }

            #endregion Read The Value And Set The Controals
            objConn.Close();
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
    #endregion FillGridview
    #region  gvState | RowCommand
    protected void gvState_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "DeleteRecord")
        {


            if (e.CommandArgument != "")
            {

                DeleteState(Convert.ToInt32(e.CommandArgument.ToString().Trim()));

            }


        }

    }
    #endregion  gvState | RowCommand
    #region Delete State
    private void DeleteState(SqlInt32 StateID)
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
            objConn.Open();

            SqlCommand ObjCmd = new SqlCommand();

            ObjCmd.Connection = objConn;
            ObjCmd.CommandType = CommandType.StoredProcedure;
            ObjCmd.CommandText = "[PR_State_DeleteByPK]";
            ObjCmd.Parameters.AddWithValue("@StateID", StateID);
            ObjCmd.Parameters.AddWithValue("@UserID ", intUserID);
            ObjCmd.ExecuteNonQuery();

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

    #endregion Delete State
}