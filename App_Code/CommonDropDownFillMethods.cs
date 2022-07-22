using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for CommonDropDownFillMethods
/// </summary>
public static class CommonDropDownFillMethods
{
    #region FillDropDownListCountry
    public static void FillDropDownListCountry( DropDownList ddlCountry )
    {
        #region Local Variable
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        SqlInt32 IntUserID = SqlInt32.Null;
        #endregion Local Variable
        if (HttpContext.Current.Session["UserID"] != null)
        {
            IntUserID = Convert.ToInt32(HttpContext.Current.Session["UserID"]);
        }
        try
        {
            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
            {
                

                objConn.Open();

                SqlCommand objCmd = objConn.CreateCommand();
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "[PR_Country_SelectForDropDownListByUserID]";
                objCmd.Parameters.AddWithValue("@UserID", IntUserID);
                SqlDataReader objSDR = objCmd.ExecuteReader();


                #region Read The Value And Set The Controals
                if (objSDR.HasRows == true)
                {
                    ddlCountry.DataSource = objSDR;
                    ddlCountry.DataValueField = "CountryID";
                    ddlCountry.DataTextField = "CountryName";
                    ddlCountry.DataBind();
                }
                #endregion Read The Value And Set The Controals
                ddlCountry.Items.Insert(0, new ListItem("Select Country", "-1"));


                objConn.Close();
            #endregion Set Connection & Command Object
            }
        }
        catch (Exception ex)
        {
            //lblMassge.Text = ex.Message;
        }
        finally
        {
            objConn.Close();
        }
    }
    
    #endregion FillDropDownListCountry

    #region FillDropDownListState
    public static void FillDropDownListState(DropDownList ddlState)
    {
        #region Local Variable
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        SqlInt32 IntUserID = SqlInt32.Null;
        if (HttpContext.Current.Session["UserID"] != null)
        {
            IntUserID = Convert.ToInt32(HttpContext.Current.Session["UserID"]);
        }
        #endregion Local Variable
        try
        {
            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)

                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_State_SelectForDropdown";
            objCmd.Parameters.AddWithValue("@UserID", IntUserID);
            SqlDataReader objSDR = objCmd.ExecuteReader();
            #endregion Set Connection & Command Object

            #region Read The Value And Set The Controals
            if (objSDR.HasRows == true)
            {
                ddlState.DataSource = objSDR;
                ddlState.DataValueField = "StateID";
                ddlState.DataTextField = "StateName";
                ddlState.DataBind();
                ddlState.Items.Insert(0, new ListItem("Select State", "-1"));
            }


            #endregion Read The Value And Set The Controals

            objConn.Close();
        }
        catch (Exception ex)
        {
            //lblMassge.Text = ex.Message;
        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
            {
                objConn.Close();
            }
        }
    }

    #endregion FillDropDownListState

    #region Fill CityDropDown list By StateID

    public static void FillDropDownListCity(DropDownList ddlCity , DropDownList ddlState)
    {
        #region local Variable
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        SqlInt32 IntUserID = SqlInt32.Null;
        #endregion local Variable
        if ( HttpContext.Current.Session["UserID"] != null)
        {
            IntUserID = Convert.ToInt32(HttpContext.Current.Session["UserId"]);
        }
        try
        {
            if (objConn.State != ConnectionState.Open)
            {


                objConn.Open();

                SqlCommand objCmd = objConn.CreateCommand();
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "[dbo].[PR_City_SelectbyStateID]";
                objCmd.Parameters.AddWithValue("@UserID", IntUserID);
                objCmd.Parameters.AddWithValue("@StateID", Convert.ToInt32(ddlState.SelectedValue.ToString()));
                SqlDataReader objSDR = objCmd.ExecuteReader();
                ddlCity.DataSource = objSDR;
                ddlCity.DataValueField = "CityID";
                ddlCity.DataTextField = "CityName";
                ddlCity.DataBind();
                objConn.Close();
                ddlCity.Items.Insert(0, new ListItem("Select City", "-1"));
            }
        }
        catch (Exception ex)
        {
            //lblMassge.Text = ex.Message;
            //lblMassge.ForeColor = Color.Red;
        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
            {
                objConn.Close();
            }
        }
    }

    #endregion Fill CityDropDown list By StateID

    #region FillStateDropDown List By CountryID
    public static void FillStateDropDownListbyCountryID(DropDownList ddlState, DropDownList ddlCountry)
    {

         #region Local Variable
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        SqlInt32 IntUserID = SqlInt32.Null;
        #endregion Local Variable
        if (HttpContext.Current.Session["UserID"] != null)
        {
            IntUserID = Convert.ToInt32(HttpContext.Current.Session["UserId"]);
        }
        try
        {
            if (objConn.State != ConnectionState.Open)

                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "[dbo].[PR_State_SelectbyCountryID]";
            objCmd.Parameters.AddWithValue("@UserID", IntUserID);
            objCmd.Parameters.AddWithValue("@CountryID", Convert.ToInt32(ddlCountry.SelectedValue.ToString()));
            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows == true)
            {
                ddlState.DataSource = objSDR;
                ddlState.DataValueField = "StateID";
                ddlState.DataTextField = "StateName";
                ddlState.DataBind();
            }

            ddlState.Items.Insert(0, new ListItem("Select State", "-1"));


            objConn.Close();
        }
        catch (Exception ex)
        {
            //lblMassge.Text = ex.Message;
            //lblMassge.ForeColor = Color.Red;
        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
            {
                objConn.Close();
            }
        }
    }


    #endregion FillStateDropDown List By CountryID

    #region Fill ContactCategory DropdownList

    public static void FillContactCategorylist(CheckBoxList cblContectCategoryID)
    {


        #region local Variable
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        SqlInt32 IntUserID = SqlInt32.Null;
        #endregion local Variable
        if (HttpContext.Current.Session["UserID"] != null)
        {
            IntUserID = Convert.ToInt32(HttpContext.Current.Session["UserId"]);
        }
        try
        {
            if (objConn.State != ConnectionState.Open)
            {


                objConn.Open();

                SqlCommand objCmd = objConn.CreateCommand();
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "[PR_ContactCategory_SelectForCheckBoxList]";
                objCmd.Parameters.AddWithValue("@UserID", IntUserID);
                objCmd.ExecuteNonQuery();

                SqlDataReader objSDR = objCmd.ExecuteReader();

                if (objSDR.HasRows)
                {

                    cblContectCategoryID.DataValueField = "ContactCategoryID";
                    cblContectCategoryID.DataTextField = "ContactCategoryName";
                    cblContectCategoryID.DataSource = objSDR;
                    cblContectCategoryID.DataBind();
                }

                objConn.Close();
                //ddlContactCategory.Items.Insert(0, new ListItem("Select Contact Category", "-1"));
            }
        }
        catch (Exception ex)
        {
            //lblMassge.Text = ex.Message;
            //lblMassge.ForeColor = Color.Red;
        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
            {
                objConn.Close();
            }
        }
    }

    #endregion Fill ContactCategory DropdownList


    #region DecodeData
    public static string Base64decode(string Base64EncodeData)
    {
        var Base64DateBytes = Convert.FromBase64String(Base64EncodeData);
        return System.Text.Encoding.UTF8.GetString(Base64DateBytes);
    }


    #endregion DecodeData


    #region EncodeData
    public static string Base64encode(string plaintext)
    {
        var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plaintext);
        return System.Convert.ToBase64String(plainTextBytes);
    }


    #endregion EncodeData


}
