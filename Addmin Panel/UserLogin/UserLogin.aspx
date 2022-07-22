<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserLogin.aspx.cs" Inherits="Addmin_Panel_UserLogin_UserLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Login Page</title>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
   
    <link href="../../Content/Css/Style/StyleSheet.css" rel="stylesheet" />
    <link href="../../Content/Css/bootstrap.min.css" rel="stylesheet" />
    <script src="../../Content/Js/bootstrap.min.js"></script>
      <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="col-12">
            <div class="row">
                <div class="col-12 text-center p-3" style="font-size:30px; letter-spacing:2px; font-family:'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif">
                    <asp:Label ID="lblAddress" runat="server" Text="AddressBook" CssClass="font-weight-bold text-success"></asp:Label>
                </div>
            </div>
        </div>
    <div>

    <div class=" container h-100" style="display:flex;align-items:center;justify-content:center; " >
     <div class=" card Login-Form bg-light" style="width:380px; margin:20px; font-size:18px; ">
         <h3 class=" card-title text-center p-2  bg-secondary">Login</h3>
         <div class=" pl-3 lbl">
             <asp:Label ID="lblMassage" runat="server" Text="" EnableViewState="True"></asp:Label>
         </div>
         <div class="card-text p-3">
            <div class="form-group font-weight-bold ">
                <asp:Label ID="Label1" runat="server" Text="User Name"></asp:Label>
                <asp:RequiredFieldValidator ID="rfvUsreName" runat="server" ErrorMessage="Enter User Name" ControlToValidate="txtUserName" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:TextBox ID="txtUserName"  class="form-control form-control-sm" runat="server"></asp:TextBox>
            </div>
              <div class="form-group font-weight-bold">
                <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
                  <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ErrorMessage="Enter Password" ControlToValidate="txtPassword" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:TextBox ID="txtPassword" class="form-control form-control-sm" runat="server"></asp:TextBox>
            </div>
              <div class="form-group font-weight-bold  p-4 text-center" style="color:white">
                  <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-sm btn-info font-weight-bold" Text="Login" OnClick="btnLogin_Click"></asp:Button>
                  
                  <asp:HyperLink ID="hlRegistration" runat="server" CssClass="btn btn-sm btn-danger font-weight-bold" NavigateUrl="~/AddminPanel/UserRagistration">Registration</asp:HyperLink>

            </div>
         </div>
         
     </div>
    </div>
    
    
   


    </div>
    </form>
</body>
</html>
