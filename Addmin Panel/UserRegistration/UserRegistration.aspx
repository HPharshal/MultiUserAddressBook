<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserRegistration.aspx.cs" Inherits="Addmin_Panel_UserRegistration_UserRegistration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <meta name="viewport" content="width=device-width, initial-scale=1"/>
   
    <link href="../../Content/Css/Style/StyleSheet.css" rel="stylesheet" />
    <link href="../../Content/Css/bootstrap.min.css" rel="stylesheet" />
    <script src="../../Content/Js/bootstrap.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" class="col-12" runat="server">
   
    
        
       <div class="row border m-0">
        <div class="col-md-12 text-center">
             <h1>RegisTration Form</h1>
            <div class="row">
                <div class="col-md-12">
                    <asp:Label ID="lblMassage" runat="server" Text="" ForeColor="#33CC33"></asp:Label>
                </div>
            </div>
        </div>
    </div>
        <div class="d-flex justify-content-center align-items-center">
             <div class="  d-block border  border-info shadow m-4 ">
       
        <div class="col-12">
            <div class="row">
                <div class="col-md-12 text-center">
                    <h1>
                        User Form
                    </h1>
                </div>
            </div>
        </div>
         <div class="col-12">
            <div class="row">
                <div class="col-md-12 text-center">
                   <p>
                       <asp:Label ID="lblMassge" runat="server" Text=""></asp:Label>
                   </p>
                </div>
            </div>
        </div>



        <div class="row  m-0">
        <div class="col-12">
            <div class="form-group">
                <div class="row  font-weight-bold">
                    <div class="col-md-12">
                        <div class="row ">
                            <div class="col-md-5 ml-3">
                                <asp:Label CssClass="col-form-label" ID="lblUserName" runat="server" Text="Enter User Name*"></asp:Label>
                            </div>
                            <div class="col-md-6 ml-3">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Plasse Enter User Name" Display="Dynamic" ForeColor="Red" ControlToValidate="txtUserName" ValidationGroup="saveBtn"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <asp:TextBox CssClass=" form-control" ID="txtUserName" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-12">
                        <div class="row">
                             <div class="col-md-5 ml-3">
                                <asp:Label  ID="lblPassword" runat="server" Text="Enter Password*"></asp:Label>
                            </div>
                            <div class="col-md-6 ml-3">
                                 
                                  <asp:RequiredFieldValidator ID="rfvContrctNo" runat="server" ErrorMessage="Plasse Enter Password" Display="Dynamic" ForeColor="Red" ControlToValidate="txtPassword" ValidationGroup="saveBtn" ></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="col-md-12">
                            <asp:TextBox CssClass=" form-control" ID="txtPassword" runat="server"></asp:TextBox>
                        </div>
                      
                    </div>
                </div>
            </div>
        </div>
    </div>


         <div class="row  m-0">
        <div class="col-md-12">
            <div class=" form-group">
                <div class="row font-weight-bold">
                    <div class="col-md-12">
                        <div class="row">
                            <div class="col-md-5 ml-3">
                                <asp:Label CssClass="col-form-label" ID="lblDisplayName" runat="server" Text="Enter DisplayName"></asp:Label>
                            </div>
                             <div class="col-md-6 ml-3">
                                 <asp:RequiredFieldValidator ID="rfvDispalyName" runat="server" ErrorMessage=" Enter Display Name " ControlToValidate="txtDisplayName" Display="Dynamic" ForeColor="Red" ValidationGroup="saveBtn"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <asp:TextBox CssClass="form-control" ID="txtDisplayName" runat="server"></asp:TextBox>
                        </div>
                    </div>



                   
                </div>
               
            </div>
        </div>
    </div>
        <div class="row m-0">
            <div class="col-md-12">
                <div class="form-group">
                    <div class="row font-weight-bold">
                        <div class="col-md-12">
                            <div class="row">
                                <div class="col-md-5 ml-3">
                                   <asp:Label CssClass="col-form-label" ID="Label1" runat="server" Text="Enter Email*"></asp:Label>
                                </div>
                                 <div class="col-md-6 ml-3">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Plasse Enter Email " Display="Dynamic" ForeColor="Red" ControlToValidate="txtEmail" ValidationGroup="saveBtn"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Enter valid Email ID" ControlToValidate="txtEmail" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="Red" ValidationGroup="saveBtn"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="col-md-12">
                               <asp:TextBox CssClass=" form-control" ID="txtEmail" runat="server"></asp:TextBox>
                            </div>

                        </div>
                    </div>

                </div>
            </div>
        </div>


                 <div class="col-md-12">
                     <div class="row font-weight-bold">
                         <div class="col-md-5 ml-3">
                             <asp:Label ID="lblContectNO" runat="server" Text="Enter Contact Number*"></asp:Label>
                         </div>
                         <div class="col-md-6 ml-3">
                             <asp:RegularExpressionValidator ID="revContectNo" runat="server" ErrorMessage="Enter Valid Contect No" Display="Dynamic" ValidationExpression="^[6-9][0-9]{9}$" ControlToValidate="txtContactNumber" ForeColor="Red" ValidationGroup="saveBtn"></asp:RegularExpressionValidator>
                             <asp:RequiredFieldValidator ID="rfvContactNO" runat="server" ErrorMessage="Plasse Enter Contact Number" Display="Dynamic" ForeColor="Red" ControlToValidate="txtContactNumber" ValidationGroup="saveBtn"></asp:RequiredFieldValidator>
                         </div>
                     </div>

                     <div class="col-md-12">
                         <asp:TextBox CssClass=" form-control" ID="txtContactNumber" runat="server"></asp:TextBox>
                     </div>

                 </div>
                 <div class="col-md-12">
            <div class="text-center m-2">
                <asp:Button CssClass="btn  btn-primary pl-4 pr-4" ID="btnSave" runat="server" Text="Save" ValidationGroup="saveBtn" OnClick="btnSave_Click"/>
                <asp:HyperLink CssClass="btn  btn-danger" ID="hlCancal" runat="server" Text="Back To Login" NavigateUrl="~/AddminPanel/UserLogin" />
            </div>
        </div>
    </div>
        </div>
        <footer>
             <div class="col-12 bg-light border-top border-info  position-relative" style="bottom:0px; line-height:15px;">
                 <div class="row">
                     <div class="col-md-12 text-center">
                         <p class=" text-center pt-3">Khambhadiya Harshal | 190540107108 | 190540107108@Darshan.ac.in</p>
                     </div>
                 </div>
             </div>
        </footer>
    </form>

</body>
</html>
