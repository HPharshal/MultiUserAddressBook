using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Addmin_Panel_Contact_ContactAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!Page.IsPostBack)
        {

            

            FillCountryDropDownList();
            FillContactCategoryDropdownList();

            ddlState.Items.Insert(0, new ListItem("Select State", "-1"));
            ddlCity.Items.Insert(0, new ListItem("Select City", "-1"));




            if (Page.RouteData.Values["OperationName"].ToString().Trim() != "Add")
            {


                var Base64DataBytes = Convert.FromBase64String(Page.RouteData.Values["ContactID"].ToString());
                FillControls(Convert.ToInt32(System.Text.Encoding.UTF8.GetString(Base64DataBytes)));
                FillStateDropDownList();
                FillCityDropDownList();
                //lblMassge.Text = "Edit Mode";
                lblMassge.ForeColor = Color.Green;
            }


            else
            {
                //if (Request.QueryString["ContactID"] == null)
                {


                    //lblMassge.Text = "Add Mode";
                    lblMassge.ForeColor = Color.Green;

                }
            }
        }
    }
    #endregion Load Event

    #region Fill Country DropDownList
    private void FillCountryDropDownList()
    {
        #region local Variable
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        SqlInt32 IntUserID = SqlInt32.Null;
        #endregion local Variable
        if (Session["UserID"] != null)
        {
            IntUserID = Convert.ToInt32(Session["UserId"]);
        }
        try
        {
            if (objConn.State != ConnectionState.Open)
            {


                objConn.Open();

                SqlCommand objCmd = objConn.CreateCommand();
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "PR_Country_SelectForDropDownListByUserID";
                objCmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));
                SqlDataReader objSDR = objCmd.ExecuteReader();

                if (objSDR.HasRows == true)
                {
                    ddlCountry.DataSource = objSDR;
                    ddlCountry.DataValueField = "CountryID";
                    ddlCountry.DataTextField = "CountryName";
                    ddlCountry.DataBind();
                }

                ddlCountry.Items.Insert(0, new ListItem("Select Country", "-1"));


                objConn.Close();
            }
        }
        catch (Exception ex)
        {
            lblMassge.Text = ex.Message;
            lblMassge.ForeColor = Color.Red;
        }
        finally
        {
            objConn.Close();
        }




    }


    #endregion Fill Country DropDownList

    #region Fill State DropDownList
    private void FillStateDropDownList()
    {


        CommonDropDownFillMethods.FillStateDropDownListbyCountryID(ddlState, ddlCountry);



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
        //    if (objConn.State != ConnectionState.Open)

        //        objConn.Open();

        //    SqlCommand objCmd = objConn.CreateCommand();
        //    objCmd.CommandType = CommandType.StoredProcedure;
        //    objCmd.CommandText = "[dbo].[PR_State_SelectbyCountryID]";
        //    objCmd.Parameters.AddWithValue("@UserID", IntUserID);
        //    objCmd.Parameters.AddWithValue("@CountryID", Convert.ToInt32(ddlCountry.SelectedValue.ToString()));
        //    SqlDataReader objSDR = objCmd.ExecuteReader();

        //    if (objSDR.HasRows == true)
        //    {
        //        ddlState.DataSource = objSDR;
        //        ddlState.DataValueField = "StateID";
        //        ddlState.DataTextField = "StateName";
        //        ddlState.DataBind();
        //    }

        //    ddlState.Items.Insert(0, new ListItem("Select State", "-1"));


        //    objConn.Close();
        //}
        //catch (Exception ex)
        //{
        //    lblMassge.Text = ex.Message;
        //    lblMassge.ForeColor = Color.Red;
        //}
        //finally
        //{
        //    if (objConn.State == ConnectionState.Open)
        //    {
        //        objConn.Close();
        //    }
        //}
    }


    #endregion Fill State DropDownList

    #region Fill ContactCategory DropdownList

    private void FillContactCategoryDropdownList()
    {


        CommonDropDownFillMethods.FillContactCategorylist(cblContectCategoryID);


        //#region local Variable
        //SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        //SqlInt32 IntUserID = SqlInt32.Null;
        //#endregion local Variable
        //if (Session["UserID"] != null)
        //{
        //    IntUserID = Convert.ToInt32(Session["UserId"]);
        //}
        //try
        //{
        //    if (objConn.State != ConnectionState.Open)
        //    {


        //        objConn.Open();

        //        SqlCommand objCmd = objConn.CreateCommand();
        //        objCmd.CommandType = CommandType.StoredProcedure;
        //        objCmd.CommandText = "[PR_ContactCategory_SelectForCheckBoxList]";
        //        objCmd.Parameters.AddWithValue("@UserID", IntUserID);
        //        objCmd.ExecuteNonQuery();

        //        SqlDataReader objSDR = objCmd.ExecuteReader();

        //        if(objSDR.HasRows)
        //        {
                    
        //            cblContectCategoryID.DataValueField = "ContactCategoryID";
        //            cblContectCategoryID.DataTextField = "ContactCategoryName";
        //            cblContectCategoryID.DataSource = objSDR;
        //            cblContectCategoryID.DataBind();
        //        }
                
        //        objConn.Close();
        //        //ddlContactCategory.Items.Insert(0, new ListItem("Select Contact Category", "-1"));
        //    }
        //}
        //catch (Exception ex)
        //{
        //    lblMassge.Text = ex.Message;
        //    lblMassge.ForeColor = Color.Red;
        //}
        //finally
        //{
        //    if (objConn.State == ConnectionState.Open)
        //    {
        //        objConn.Close();
        //    }
        //}


    }
    #endregion Fill ContactCategory DropdownList

    #region Fill City DropDownList

    private void FillCityDropDownList()
    {



        CommonDropDownFillMethods.FillDropDownListCity(ddlCity, ddlState);

        //#region local Variable
        //SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        //SqlInt32 IntUserID = SqlInt32.Null;
        //#endregion local Variable
        //if (Session["UserID"] != null)
        //{
        //    IntUserID = Convert.ToInt32(Session["UserId"]);
        //}
        //try
        //{
        //    if (objConn.State != ConnectionState.Open)
        //    {


        //        objConn.Open();

        //        SqlCommand objCmd = objConn.CreateCommand();
        //        objCmd.CommandType = CommandType.StoredProcedure;
        //        objCmd.CommandText = "[dbo].[PR_City_SelectbyStateID]";
        //        objCmd.Parameters.AddWithValue("@UserID", IntUserID);
        //        objCmd.Parameters.AddWithValue("@StateID", Convert.ToInt32(ddlState.SelectedValue.ToString()));
        //        SqlDataReader objSDR = objCmd.ExecuteReader();
        //        ddlCity.DataSource = objSDR;
        //        ddlCity.DataValueField = "CityID";
        //        ddlCity.DataTextField = "CityName";
        //        ddlCity.DataBind();
        //        objConn.Close();
        //        ddlCity.Items.Insert(0, new ListItem("Select City", "-1"));
        //    }
        //}
        //catch (Exception ex)
        //{
        //    lblMassge.Text = ex.Message;
        //    lblMassge.ForeColor = Color.Red;
        //}
        //finally
        //{
        //    if (objConn.State == ConnectionState.Open)
        //    {
        //        objConn.Close();
        //    }
        //}



    }
    #endregion Fill City DropDownList

    #region Button | Save
    protected void btnSave_Click1(object sender, EventArgs e)
    {
        #region Local Variable
        SqlInt32 strCountryID = SqlInt32.Null;
        SqlInt32 strUserID = SqlInt32.Null;
        SqlInt32 strStateID = SqlInt32.Null;
        SqlInt32 strCityID = SqlInt32.Null;
        //SqlInt32 strContactCategoryID = SqlInt32.Null;
        SqlString strContactName = SqlString.Null;
        SqlString strContactNO = SqlString.Null;
        SqlString strWhatsAppNo = SqlString.Null;
        SqlString strBirthDate = SqlString.Null;
        SqlInt32 strAge = SqlInt32.Null;
        SqlString strBloodGroup = SqlString.Null;
        SqlString strAddress = SqlString.Null;
        SqlString strEmailID = SqlString.Null;
        SqlString strFaceBookID = SqlString.Null;
        SqlString strLinkInID = SqlString.Null;
        SqlInt32 IntUserID = SqlInt32.Null;
        int Count = 0;

       
        if (Session["UserID"] != null)
        {
            IntUserID = Convert.ToInt32(Session["UserId"]);
        }
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        #endregion Local Variable

        try
        {

            

            #region Server Side Validation
            if (txtContactName.Text.Trim() == "" || txtContactNumber.Text.Trim() == "" || txtEmail.Text.Trim() == "" || txtAddress.Text.Trim() == "")
            {
                lblMassge.Text = "Plasse Enter All Fild";
                lblMassge.ForeColor = Color.Red;
                return;
            }


            if (ddlCountry.SelectedIndex > 0)
            {
                strCountryID = Convert.ToInt32(ddlCountry.SelectedValue);
            }
            if (ddlState.SelectedIndex > 0)
            {
                strStateID = Convert.ToInt32(ddlState.SelectedValue);
            }
            if (ddlCity.SelectedIndex > 0)
            {
                strCityID = Convert.ToInt32(ddlCity.SelectedValue);
            }
            #region Count
            foreach (ListItem ContactCategorylist in cblContectCategoryID.Items)
            {
                if (ContactCategorylist.Selected)
                {
                    Count++;

                }
            }
            #endregion Count

            if (txtContactName.Text.Trim() != "")
            {
                strContactName = txtContactName.Text.Trim();
            }
            if (txtContactNumber.Text.Trim() != "")
            {
                strContactNO = txtContactNumber.Text.Trim();
            }
            if (txtWhatsappNo.Text.Trim() != "")
            {
                strWhatsAppNo = txtWhatsappNo.Text.Trim();
            }
            if (txtBirthDate.Text.Trim() != "")
            {
                strBirthDate = txtBirthDate.Text.Trim();
            }
            if (txtAge.Text.Trim() != "")
            {
                strAge = Convert.ToInt32(txtAge.Text.Trim());
            }
            if (txtBloodGroup.Text.Trim() != "")
            {
                strBloodGroup = txtBloodGroup.Text.Trim();
            }
            if (txtAddress.Text.Trim() != "")
            {
                strAddress = txtAddress.Text.Trim();
            }
            if (txtEmail.Text.Trim() != "")
            {
                strEmailID = txtEmail.Text.Trim();
            }
            if (txtFaceBookID.Text.Trim() != "")
            {
                strFaceBookID = txtFaceBookID.Text.Trim();
            }
            if (txtLinkInId.Text.Trim() != "")
            {
                strLinkInID = txtLinkInId.Text.Trim();
            }
            #endregion Server Side Validation
            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
            {
                objConn.Open();
                SqlCommand objCmd = objConn.CreateCommand();


                objCmd.CommandType = CommandType.StoredProcedure;

                objCmd.Parameters.AddWithValue("@CountryID", strCountryID);
                objCmd.Parameters.AddWithValue("@StateID ", strStateID);
                objCmd.Parameters.AddWithValue("@CityID  ", strCityID);
                //objCmd.Parameters.AddWithValue("@ContactCategoryID  ", strContactCategoryID);
                objCmd.Parameters.AddWithValue("@ContactName ", strContactName);
                objCmd.Parameters.AddWithValue("@ContactNo ", strContactNO);
                objCmd.Parameters.AddWithValue("@WhatsAppNo ", strWhatsAppNo);
                objCmd.Parameters.AddWithValue("@BirthDate", strBirthDate);
                objCmd.Parameters.AddWithValue("@Email", strEmailID);
                objCmd.Parameters.AddWithValue("@Age", strAge);
                objCmd.Parameters.AddWithValue("@Address", strAddress);
                objCmd.Parameters.AddWithValue("@BloodGroup ", strBloodGroup);
                objCmd.Parameters.AddWithValue("@FacebookID ", strFaceBookID);
                objCmd.Parameters.AddWithValue("@LinkedINID  ", strLinkInID);
                objCmd.Parameters.AddWithValue("@UserID", IntUserID);
                //contect photo path
               
            #endregion Set Connection & Command Object

                #region Update Data
                if (Page.RouteData.Values["OperationName"].ToString().Trim() != "Add")
                {
                    var Base64DataBytes = Convert.FromBase64String(Page.RouteData.Values["ContactID"].ToString());
                    Int32 Contact = Convert.ToInt32(System.Text.Encoding.UTF8.GetString(Base64DataBytes));
                    if (Count <= 0)
                    {
                        lblContectCategoryMassage.Text = "Plasee Select ContactCategory";
                    }
                    else
                    {

                        #region file uplod
                        String ContactPhotoPath = "";

                        if (fuContactPhotoPath.HasFile)
                        {

                            ContactPhotoPath = "~/User Controls/" + fuContactPhotoPath.FileName;

                            fuContactPhotoPath.SaveAs(Server.MapPath(ContactPhotoPath));

                            String FileName = fuContactPhotoPath.FileName;
                            String FileSize = (fuContactPhotoPath.PostedFile.ContentLength) / 1024 + "kb";
                            String FileExt = System.IO.Path.GetExtension(fuContactPhotoPath.FileName);
                            objCmd.Parameters.AddWithValue("@ContactPhotoPath", ContactPhotoPath);
                            objCmd.Parameters.AddWithValue("@FileName", FileName);
                            objCmd.Parameters.AddWithValue("@FileSize", FileSize);
                            objCmd.Parameters.AddWithValue("@FileExt", FileExt);
                            FileInfo file = new FileInfo(Server.MapPath(lblPhotoPath.Text.ToString().Trim()));

                            if (file.Exists)
                            {

                                file.Delete();



                            }

                        }
                        else
                        {
                            //    SqlCommand objCmdPhotoPath = objConn.CreateCommand();
                            //    objCmdPhotoPath.CommandType = CommandType.StoredProcedure;
                            //    objCmdPhotoPath.CommandText = "PR_ContectWiseContactCategory_Contact_SelectALLByPk_UserID";
                            //    objCmdPhotoPath.Parameters.AddWithValue("@ContactID",Convert.ToInt32(Request.QueryString["ContactID"].ToString().Trim()));
                            //    objCmdPhotoPath.Parameters.AddWithValue("@UserID", IntUserID);
                            //    objCmdPhotoPath.ExecuteNonQuery();
                            //    SqlDataReader objSDR = objCmdPhotoPath.ExecuteReader();
                            //    if (objSDR.HasRows)
                            //    {
                            //        while (objSDR.Read())
                            //        {
                            //            if (!objSDR["ContactPhotoPath"].Equals(DBNull.Value))
                            //            {
                            //                lblPhotoPath.Text = objSDR["ContactPhotoPath"].ToString();
                            //            }
                            //            if (!objSDR["FileName"].Equals(DBNull.Value))
                            //            {
                            //                lblFileName.Text = objSDR["FileName"].ToString();
                            //            }
                            //            if (!objSDR["FileSize"].Equals(DBNull.Value))
                            //            {
                            //                lblFileSize.Text = objSDR["FileSize"].ToString();

                            //            }
                            //            if (!objSDR["FileExt"].Equals(DBNull.Value))
                            //            {
                            //                lblFileExt.Text = objSDR["FileExt"].ToString();
                            //            }

                            //        }
                            //    }
                            //if (lblMassge.Text == "Edit Mode")
                            {
                                objCmd.Parameters.AddWithValue("@ContactPhotoPath", lblPhotoPath.Text.ToString().Trim());
                                objCmd.Parameters.AddWithValue("@FileName", lblFileName.Text.ToString().Trim());
                                objCmd.Parameters.AddWithValue("@FileSize", lblFileSize.Text.ToString().Trim());
                                objCmd.Parameters.AddWithValue("@FileExt", lblFileExt.Text.ToString().Trim());
                            }



                        }
                        #endregion file uplod
                        objCmd.Parameters.AddWithValue("ContactID", Contact);
                        // objCmd.Parameters.AddWithValue("@UserID", IntUserID);
                        objCmd.CommandText = "[PR_Contact_UpdateByPk]";
                        objCmd.ExecuteNonQuery();
                        #region cbl
                        {
                            SqlCommand objCmdCtegory = objConn.CreateCommand();
                            objCmdCtegory.CommandType = CommandType.StoredProcedure;
                            objCmdCtegory.Parameters.AddWithValue("ContactID", Contact);
                            objCmdCtegory.Parameters.AddWithValue("@UserID", IntUserID);
                            objCmdCtegory.CommandText = "PR_ContactWiseCategory_DeleteByPK_UserID";
                            objCmdCtegory.ExecuteNonQuery();

                            foreach (ListItem Cclist in cblContectCategoryID.Items)
                            {
                                if (Cclist.Selected)
                                {
                                    SqlCommand objCmdContactCategory = objConn.CreateCommand();
                                    objCmdContactCategory.CommandType = CommandType.StoredProcedure;
                                    objCmdContactCategory.CommandText = "[dbo].[PR_ContactWiseCategory_Insert]";
                                    objCmdContactCategory.Parameters.AddWithValue("@UserID", IntUserID);
                                    objCmdContactCategory.Parameters.AddWithValue("@ContactID", Contact);
                                    objCmdContactCategory.Parameters.AddWithValue("@ContactCategoryID", Cclist.Value.ToString());
                                    objCmdContactCategory.ExecuteNonQuery();

                                }
                            }
                        }
                        #endregion cbl

                        Response.Redirect("~/AddminPanel/Contact/List");
                    }
                }
                #endregion Update Data
                #region Insert Data
                else
                {


                    if (Count <= 0)
                    {
                        lblContectCategoryMassage.Text = "Plasee Select ContactCategory";
                    }
                    else
                    {
                        #region file uplod
                         String ContactPhotoPath = "";

                         if (fuContactPhotoPath.HasFile)
                         {

                             ContactPhotoPath = "~/User Controls/" + fuContactPhotoPath.FileName;

                             fuContactPhotoPath.SaveAs(Server.MapPath(ContactPhotoPath));

                             String FileName = fuContactPhotoPath.FileName;
                             String FileSize = (fuContactPhotoPath.PostedFile.ContentLength) / 1024 + "kb";
                             String FileExt = System.IO.Path.GetExtension(fuContactPhotoPath.FileName);
                             objCmd.Parameters.AddWithValue("@ContactPhotoPath", ContactPhotoPath);
                             objCmd.Parameters.AddWithValue("@FileName", FileName);
                             objCmd.Parameters.AddWithValue("@FileSize", FileSize);
                             objCmd.Parameters.AddWithValue("@FileExt", FileExt);

                         }
                        #endregion file uplod


                        //Contect
                        objCmd.CommandText = "[PR_Contact_InsertByUserId]";


                        //Photopath


                        //outParaetar
                        objCmd.Parameters.Add("@ContactID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;




                        objCmd.ExecuteNonQuery();

                        SqlInt32 ContactID = 0;
                        ContactID = Convert.ToInt32(objCmd.Parameters["@ContactID"].Value);

                        foreach (ListItem ContactCategorylist in cblContectCategoryID.Items)
                        {
                            if (ContactCategorylist.Selected)
                            {
                                SqlCommand objCmdContactCategory = objConn.CreateCommand();
                                objCmdContactCategory.CommandType = CommandType.StoredProcedure;
                                objCmdContactCategory.CommandText = "[dbo].[PR_ContactWiseCategory_Insert]";
                                objCmdContactCategory.Parameters.AddWithValue("@UserID", IntUserID);
                                objCmdContactCategory.Parameters.AddWithValue("@ContactID", ContactID);
                                objCmdContactCategory.Parameters.AddWithValue("@ContactCategoryID", ContactCategorylist.Value.ToString());
                                objCmdContactCategory.ExecuteNonQuery();

                            }
                        }















                        ddlCountry.SelectedIndex = -1;
                        ddlState.SelectedIndex = -1;
                        ddlCity.SelectedIndex = -1;
                        foreach (ListItem ContactCategorylist in cblContectCategoryID.Items)
                        {
                            if (ContactCategorylist.Selected)
                            {
                                ContactCategorylist.Selected = false;

                            }
                        }
                        txtContactName.Text = "";
                        txtContactNumber.Text = "";
                        txtWhatsappNo.Text = "";
                        txtBirthDate.Text = "";
                        txtBloodGroup.Text = "";
                        txtAge.Text = "";
                        txtAddress.Text = "";
                        txtEmail.Text = "";
                        txtFaceBookID.Text = "";
                        txtLinkInId.Text = "";
                        lblMassge.Text = "Save Data SuccsessFlly";
                    }
                }
                #endregion Insert Data


                objConn.Close();



            }
        }
        catch (Exception ex)
        {
            lblMassge.Text = ex.Message;
            lblMassge.ForeColor = Color.Red;
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
    private void FillControls(SqlInt32 ContactID)
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
                objCmd.CommandText = "PR_ContectWiseContactCategory_Contact_SelectALLByPk_UserID";
                objCmd.Parameters.AddWithValue("@ContactID", ContactID.ToString().Trim());
                objCmd.Parameters.AddWithValue("@UserID", IntUserID);
                objCmd.ExecuteNonQuery();
                SqlDataReader objSDR = objCmd.ExecuteReader();

                //lblMassge.Text = "Edit Mode";
                lblMassge.ForeColor = Color.Green;
            #endregion Set Connection & Command Object
                #region Read The Value And Set The Controals
                if (objSDR.HasRows)
                {
                    while (objSDR.Read())
                    {

                        if (!objSDR["CountryID"].Equals(DBNull.Value))
                        {
                            ddlCountry.SelectedValue = objSDR["CountryID"].ToString().Trim();
                        }
                        if (!objSDR["StateID"].Equals(DBNull.Value))
                        {
                            ddlState.SelectedValue = objSDR["StateID"].ToString().Trim();
                        }
                        if (!objSDR["CityID"].Equals(DBNull.Value))
                        {
                            ddlCity.SelectedValue = objSDR["CityID"].ToString().Trim();
                        }
                        if (!objSDR["category"].Equals(DBNull.Value))
                        {
                                Int32 c = 0;
                                String category  = objSDR["category"].ToString();
                                //lblMassge.Text = category.ToString().Trim();
                                String[] Saprator = { ", " };
                                foreach (ListItem ContactCategorylist in cblContectCategoryID.Items)
                                {
                                    c++;
                                }
                                Int32 list = c;
                                String[] LiCategory = category.Split(Saprator, list, StringSplitOptions.RemoveEmptyEntries);

                                foreach (String s in LiCategory)
                                {
                               
                                    foreach (ListItem ContactCategorylist in cblContectCategoryID.Items)
                                    {
                                        if (s.ToString().Trim() == ContactCategorylist.ToString().Trim())
                                        {
                                            ContactCategorylist.Selected = true;

                                        }
                                    }
                                }
                        }
                        if (!objSDR["ContactName"].Equals(DBNull.Value))
                        {
                            txtContactName.Text = objSDR["ContactName"].ToString().Trim();
                        }
                        if (!objSDR["ContactNo"].Equals(DBNull.Value))
                        {
                            txtContactNumber.Text = objSDR["ContactNo"].ToString().Trim();
                        }
                        if (!objSDR["WhatsAppNo"].Equals(DBNull.Value))
                        {
                            txtWhatsappNo.Text = objSDR["WhatsAppNo"].ToString().Trim();
                        }
                        if (!objSDR["BirthDate"].Equals(DBNull.Value))
                        {
                            txtBirthDate.Text = objSDR["BirthDate"].ToString().Trim();
                        }
                        if (!objSDR["Age"].Equals(DBNull.Value))
                        {
                            txtAge.Text = objSDR["Age"].ToString().Trim();
                        }
                        if (!objSDR["BloodGroup"].Equals(DBNull.Value))
                        {
                            txtBloodGroup.Text = objSDR["BloodGroup"].ToString().Trim();
                        }
                        if (!objSDR["Address"].Equals(DBNull.Value))
                        {
                            txtAddress.Text = objSDR["Address"].ToString().Trim();
                        }
                        if (!objSDR["Email"].Equals(DBNull.Value))
                        {
                            txtEmail.Text = objSDR["Email"].ToString().Trim();
                        }
                        if (!objSDR["FacebookID"].Equals(DBNull.Value))
                        {
                            txtFaceBookID.Text = objSDR["FacebookID"].ToString().Trim();
                        }
                        if (!objSDR["LinkedINID"].Equals(DBNull.Value))
                        {
                            txtLinkInId.Text = objSDR["LinkedINID"].ToString().Trim();
                        }
                        if (!objSDR["ContactPhotoPath"].Equals(DBNull.Value))
                        {
                            lblPhotoPath.Text = objSDR["ContactPhotoPath"].ToString().Trim();
                            Image1.ImageUrl = lblPhotoPath.Text.ToString().Trim();
                        }
                        if (!objSDR["FileName"].Equals(DBNull.Value))
                        {
                            lblFileName.Text = objSDR["FileName"].ToString();
                        }
                        if (!objSDR["FileSize"].Equals(DBNull.Value))
                        {
                            lblFileSize.Text = objSDR["FileSize"].ToString();

                        }
                        if (!objSDR["FileExt"].Equals(DBNull.Value))
                        {
                            lblFileExt.Text = objSDR["FileExt"].ToString();
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
            lblMassge.ForeColor = Color.Red;

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




    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillStateDropDownList();
        FillCityDropDownList();
    }
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillCityDropDownList();
    }
}
