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

public partial class Addmin_Panel_City_CityAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
           

            FillStateDropDownList();

            if (Page.RouteData.Values["OperationName"].ToString().Trim() != "Add")
            {

                var Base64DataBytes = Convert.FromBase64String(Page.RouteData.Values["CityID"].ToString());

                FillControls(Convert.ToInt32(System.Text.Encoding.UTF8.GetString(Base64DataBytes)));

                lblMassge.Text = "Edit Mode";
                lblMassge.ForeColor = Color.Green;
              
               
            }
            else
            {
                if (Request.QueryString["CityID"] == null)
                {
                   
                    lblMassge.Text = "Add Mode";
                    lblMassge.ForeColor = Color.Green;
                   

                }
            }

        }


    }


    #endregion Load Event

    #region Button | save
    protected void btnSave_Click1(object sender, EventArgs e)
    {
        #region Local variable
        SqlInt32 strStateID = SqlInt32.Null;
        SqlString strCityName = SqlString.Null;
        SqlString strSTDCode = SqlString.Null;
        SqlString strPINCode = SqlString.Null;

        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        SqlInt32 IntUserID = SqlInt32.Null;
        if (Session["UserID"] != null)
        {
            IntUserID = Convert.ToInt32(Session["UserId"]);
        }
        #endregion Local variable
        try
        {
            #region Server Side validation
            if (ddlState.SelectedIndex > 0)
            {
                strStateID = Convert.ToInt32(ddlState.SelectedValue);
            }
            if (txtCityName.Text.Trim() != "")
            {
                strCityName = txtCityName.Text.Trim();
            }
            if (txtPINcode.Text.Trim() != "")
            {
                strPINCode = txtPINcode.Text.Trim();
            }
            if (txtSTDCode.Text.Trim() != "")
            {
                strSTDCode = txtSTDCode.Text.Trim();
            }
            #endregion Server Side validation

            #region Read The Value And Set The Controals
            if (objConn.State != ConnectionState.Open)
            {
                objConn.Open();
                SqlCommand objCmd = objConn.CreateCommand();
                objCmd.CommandType = CommandType.StoredProcedure;


                objCmd.Parameters.AddWithValue("@StateID", strStateID);
                objCmd.Parameters.AddWithValue("@CityName", strCityName);
                objCmd.Parameters.AddWithValue("@STDCode", strSTDCode);
                objCmd.Parameters.AddWithValue("@PinCode", strPINCode);
                objCmd.Parameters.AddWithValue("@UserID", IntUserID);
            #endregion Read The Value And Set The Controals

                #region update Data


                if (Page.RouteData.Values["OperationName"].ToString().Trim() != "Add")
                {

                    var Base64DataBytes = Convert.FromBase64String(Page.RouteData.Values["CityID"].ToString());

                    objCmd.Parameters.AddWithValue("@CityID", System.Text.Encoding.UTF8.GetString(Base64DataBytes));
                   
                    objCmd.CommandText = "PR_City_UpdateByPK_UserID";
                    objCmd.ExecuteNonQuery();
                    Response.Redirect("~/Addmin Panel/City/CityList.aspx");


                }
                #endregion update Data

                #region Insert data
                else
                {
                    objCmd.CommandText = "PR_City_InsertByUserID";
                    
                    objCmd.ExecuteNonQuery();
                    txtCityName.Text = "";
                    txtPINcode.Text = "";
                    txtSTDCode.Text = "";
                    ddlState.SelectedIndex = -1;
                  
                    lblMassge.Text = "Insert Data SucessFully";

                }
                #endregion Insert data



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

    #endregion Button | save



    #region Fill StateDropDown List
    private void FillStateDropDownList()
    {

        CommonDropDownFillMethods.FillDropDownListState(ddlState);
    }

    //    #region Local Variable
    //    SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
    //    SqlInt32 IntUserID = SqlInt32.Null;
    //    if (Session["UserID"] != null)
    //    {
    //        IntUserID = Convert.ToInt32(Session["UserId"]);
    //    }
    //    #endregion Local Variable
    //    try
    //    {
    //        #region Set Connection & Command Object
    //        if (objConn.State != ConnectionState.Open)

    //            objConn.Open();

    //        SqlCommand objCmd = objConn.CreateCommand();
    //        objCmd.CommandType = CommandType.StoredProcedure;
    //        objCmd.CommandText = "PR_State_SelectForDropdown";
    //        objCmd.Parameters.AddWithValue("@UserID", IntUserID);
    //        SqlDataReader objSDR = objCmd.ExecuteReader();
    //        #endregion Set Connection & Command Object

    //        #region Read The Value And Set The Controals
    //        if (objSDR.HasRows == true)
    //        {
    //            ddlState.DataSource = objSDR;
    //            ddlState.DataValueField = "StateID";
    //            ddlState.DataTextField = "StateName";
    //            ddlState.DataBind();
    //            ddlState.Items.Insert(0, new ListItem("Select State", "-1"));
    //        }

            
    //        #endregion Read The Value And Set The Controals

    //        objConn.Close();
    //    }
    //    catch (Exception ex)
    //    {
    //        lblMassge.Text = ex.Message;
    //    }
    //    finally
    //    {
    //        if (objConn.State == ConnectionState.Open)
    //        {
    //            objConn.Close();
    //        }
    //    }
    //}


    #endregion Fill StateDropDown List

  
    #region  FillControls
    private void FillControls(SqlInt32 CityID)
    {
        #region Local Variable

        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        SqlInt32 IntUserID = SqlInt32.Null;
        if (Session["UserID"] != null)
        {
            IntUserID = Convert.ToInt32(Session["UserId"]);
        }
        #endregion Local Variable

        try
        {
            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
            {
                objConn.Open();
                SqlCommand objCmd = objConn.CreateCommand();
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "PR_City_SelectByPK_UserID";
                objCmd.Parameters.AddWithValue("@CityID", CityID.ToString().Trim());
                objCmd.Parameters.AddWithValue("@UserID", IntUserID);
                SqlDataReader objSDR = objCmd.ExecuteReader();
                lblMassge.Text = "Edit Mode";
                lblMassge.ForeColor = Color.Green;
            #endregion Set Connection & Command Object

                #region Read The Value And Set The Controals
                if (objSDR.HasRows)
                {
                    while (objSDR.Read())
                    {

                        if (!objSDR["StateID"].Equals(DBNull.Value))
                        {
                            ddlState.SelectedValue = objSDR["StateID"].ToString().Trim();
                        }
                        if (!objSDR["CityName"].Equals(DBNull.Value))
                        {
                            txtCityName.Text = objSDR["CityName"].ToString().Trim();
                        }

                        {
                            txtSTDCode.Text = objSDR["STDCode"].ToString().Trim();
                        }

                        {
                            txtPINcode.Text = objSDR["PinCode"].ToString().Trim();
                        }
                        break;
                    }
                #endregion Read The Value And Set The Controals
                }
                else
                {
                    lblMassge.Text = "Data Is Not Available";
                }

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
    #endregion  FillControls
    
}