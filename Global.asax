<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup
        RegisterRoutes(System.Web.Routing.RouteTable.Routes);
    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }
    
    public static void RegisterRoutes(System.Web.Routing.RouteCollection routes)
    {
        routes.Ignore("{resource}.axd/{*pathInfo}");

        #region Country
        routes.MapPageRoute("AddminCountryList",
                 "AddminPanel/Country/List","~/Addmin Panel/Country/CountryList.aspx");

        routes.MapPageRoute("AddminCountryAdd",
                 "AddminPanel/Country/List/{OperationName}", "~/Addmin Panel/Country/CountryAddEdit.aspx");

        routes.MapPageRoute("AddminCountryEdit",
                            "AddminPanel/Country/{OperationName}/{CountryID}",
                            "~/Addmin Panel/Country/CountryAddEdit.aspx");

        #endregion Country
        #region State
        routes.MapPageRoute("AddminState",
                "AddminPanel/State/List", "~/Addmin Panel/State/StateList.aspx");
        
        routes.MapPageRoute("AddminStateAdd",
               "AddminPanel/State/List/{OperationName}", "~/Addmin Panel/State/StateAddEdit.aspx");
        
        routes.MapPageRoute("AddminStateEdit",
                            "Addmin Panel/State/{OperationName}/{StateID}",
                            "~/Addmin Panel/State/StateAddEdit.aspx");
        #endregion State

        #region City
        routes.MapPageRoute("AddminCity",
               "AddminPanel/City/List", "~/Addmin Panel/City/CityList.aspx");
        routes.MapPageRoute("AddminCityAdd",
               "AddminPanel/City/List/{OperationName}", "~/Addmin Panel/City/CityAddEdit.aspx");
        routes.MapPageRoute("AddminCityEdit",
             "AddminPanel/City/List/{OperationName}/{CityID}", "~/Addmin Panel/City/CityAddEdit.aspx");
        #endregion City

        #region Contact
        routes.MapPageRoute("AddminContact",
             "AddminPanel/Contact/List", "~/Addmin Panel/Contact/ContactList.aspx");

         routes.MapPageRoute("AddminContactAdd",
                 "AddminPanel/Contact/List/{OperationName}", "~/Addmin Panel/Contact/ContactAddEdit.aspx");

         routes.MapPageRoute("AddminContactEdit",
                  "AddminPanel/Contact/List/{OperationName}/{ContactID}", "~/Addmin Panel/Contact/ContactAddEdit.aspx");

         #endregion Contact
         #region ContactCategory
         routes.MapPageRoute("AddminContactCategory",
             "AddminPanel/ContactCategory/List", "~/Addmin Panel/ContactCategory/ContactCategoryList.aspx");

        //routes.MapPageRoute("AddminContactCategoryEdit",
        //     "AddminPanel/ContactCatagory/List/{OperationName}/{ContactCategoryID}", "~/Addmin Panel/ContactCategory/ContactCategoryList.aspx");

        //routes.MapPageRoute()
        #endregion ContactCategory

         #region loginpage
         routes.MapPageRoute("AddminLogin",
            "AddminPanel/UserLogin", "~/Addmin Panel/UserLogin/UserLogin.aspx");
        #endregion loginpage

         #region Ragistration
         routes.MapPageRoute("AddminRagistration",
            "AddminPanel/UserRagistration", "~/Addmin Panel/UserRegistration/UserRegistration.aspx");
         #endregion Ragistration

         #region Home
         routes.MapPageRoute("AddminHome",
            "AddminPanel/Home", "~/Addmin Panel/Default.aspx");
         #endregion Home
    }
    
    
       
</script>
