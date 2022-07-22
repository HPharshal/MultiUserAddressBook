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

public partial class Addmin_Panel_State_StateAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillDropDownList();
            if (Page.RouteData.Values["OperationName"].ToString().Trim() != "Add")
            {
                var Base64DataBytes = Convert.FromBase64String(Page.RouteData.Values["StateID"].ToString());
                 FillControls(Convert.ToInt32(System.Text.Encoding.UTF8.GetString(Base64DataBytes)));
            }
            else
            {
                if (Request.QueryString["StateID"] == null)
                {
                    lblMassge.Text = "Add Mode";
                    lblMassge.ForeColor = Color.Green;
                }
            }

        }
    }
    #endregion Load Event

    #region Button | Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Local variable
        SqlInt32 strCountryID = SqlInt32.Null;
        SqlString strStateName = SqlString.Null;
        SqlString strStateCode = SqlString.Null;
        SqlInt32 IntUserID = SqlInt32.Null;
        SqlString strErrorMassge = "";
        #endregion Local variable


        #region Sever Side Validation
        if (ddlCountry.SelectedIndex == 0)
        {
            lblMassge.Text += " Select Country </br>";
        }

        if (txtStateName.Text.Trim() == "")
        {
            lblMassge.Text += "Enter State Name </br>";
        }
        if (txtStateCode.Text.Trim() == "")
        {
            lblMassge.Text += "Enter State Code </br>";
        }



        if (ddlCountry.SelectedIndex > 0)
        {
            strCountryID = Convert.ToInt32(ddlCountry.SelectedValue);
        }

        if (txtStateName.Text.Trim() != "")
        {
            strStateName = txtStateName.Text.Trim();
        }
        if (txtStateCode.Text.Trim() != "")
        {
            strStateCode = txtStateCode.Text.Trim();
        }
        if (Session["UserID"] != null)
        {
            IntUserID = Convert.ToInt32(Session["UserId"]);
        }
        #endregion Sever Side Validation

        #region Local Variable
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        #endregion Local Variable

        try
        {
            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
            {
                objConn.Open();

                #region Read The Value And Set The Controals
                SqlCommand objCmd = objConn.CreateCommand();
                objCmd.CommandType = CommandType.StoredProcedure;

                objCmd.Parameters.AddWithValue("@CountryID", strCountryID);
                objCmd.Parameters.AddWithValue("@StateName", strStateName);
                objCmd.Parameters.AddWithValue("@StateCode", strStateCode);
                objCmd.Parameters.AddWithValue("@UserID", IntUserID);

                #endregion Read The Value And Set The Controals


                #region Update Value
                if (Page.RouteData.Values["OperationName"].ToString().Trim() != "Add")
                {

                    var Base64DataBytes = Convert.FromBase64String(Page.RouteData.Values["StateID"].ToString());

                    objCmd.Parameters.AddWithValue("@StateID", System.Text.Encoding.UTF8.GetString(Base64DataBytes));
                    objCmd.CommandText = "[PR_State_UpdateByPK_UserID]";
                    objCmd.ExecuteNonQuery();
                    Response.Redirect("~/Addmin Panel/State/StateList.aspx");


                }
                #endregion Update Value

                #region Insert Data
                else
                {


                    objCmd.CommandText = "[PR_State_InsertByUserId]";
                    objCmd.ExecuteNonQuery();
                    ddlCountry.SelectedIndex = -1;
                    txtStateName.Text = "";
                    txtStateCode.Text = "";
                    lblMassge.Text = "Data ADD Successfuly";
                    lblMassge.ForeColor = Color.Green;
                }
                #endregion Insert Data

                objConn.Close();
            #endregion Set Connection & Command Object
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

    #region Fill DropDown List
    private void FillDropDownList()
    {


        CommonDropDownFillMethods.FillDropDownListCountry(ddlCountry);
        //#region Local Variable
        //SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        //SqlInt32 IntUserID = SqlInt32.Null;
        //#endregion Local Variable
        //if (Session["UserID"] != null)
        //{
        //    IntUserID = Convert.ToInt32(Session["UserId"]);
        //}
        //try
        //{
        //    #region Set Connection & Command Object
        //    if (objConn.State != ConnectionState.Open)
        //    {


        //        objConn.Open();

        //        SqlCommand objCmd = objConn.CreateCommand();
        //        objCmd.CommandType = CommandType.StoredProcedure;
        //        objCmd.CommandText = "[PR_Country_SelectForDropDownListByUserID]";
        //        objCmd.Parameters.AddWithValue("@UserID", IntUserID);
        //        SqlDataReader objSDR = objCmd.ExecuteReader();


        //        #region Read The Value And Set The Controals
        //        if (objSDR.HasRows == true)
        //        {
        //            ddlCountry.DataSource = objSDR;
        //            ddlCountry.DataValueField = "CountryID";
        //            ddlCountry.DataTextField = "CountryName";
        //            ddlCountry.DataBind();
        //        }
        //        #endregion Read The Value And Set The Controals
        //        ddlCountry.Items.Insert(0, new ListItem("Select Country", "-1"));


        //        objConn.Close();
        //    #endregion Set Connection & Command Object
        //    }
        //}
        //catch (Exception ex)
        //{
        //    lblMassge.Text = ex.Message;
        //}
        //finally
        //{
        //    objConn.Close();
        //}


    }

    #endregion Fill DropDown List

    #region FillControls
    private void FillControls(SqlInt32 StateID)
    {

        #region local variable
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        SqlInt32 IntUserID = SqlInt32.Null;
        #endregion local variable
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
                SqlCommand objCmd = objConn.CreateCommand();
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "[PR_State_SelectAllByPK_UserID]";
                objCmd.Parameters.AddWithValue("@StateID", StateID.ToString().Trim());
                objCmd.Parameters.AddWithValue("@UserID", IntUserID.ToString().Trim());
                SqlDataReader objSDR = objCmd.ExecuteReader();
                lblMassge.Text = "Edit Mode";
                lblMassge.ForeColor = Color.Green;
                #region Read The Value And Set The Controals
                if (objSDR.HasRows)
                {
                    while (objSDR.Read())
                    {
                        if (!objSDR["CountryID"].Equals(DBNull.Value))
                        {
                            ddlCountry.SelectedValue = objSDR["CountryID"].ToString().Trim();
                        }
                        if (!objSDR["StateName"].Equals(DBNull.Value))
                        {
                            txtStateName.Text = objSDR["StateName"].ToString().Trim();
                        }
                        if (!objSDR["StateCode"].Equals(DBNull.Value))
                        {
                            txtStateCode.Text = objSDR["StateCode"].ToString().Trim();
                        }
                        break;
                    }
                }
                #endregion Read The Value And Set The Controals
                else
                {
                    lblMassge.Text = "Data Is Not Available";
                }
                objConn.Close();
            #endregion Set Connection & Command Object
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
    #endregion FillControls
}