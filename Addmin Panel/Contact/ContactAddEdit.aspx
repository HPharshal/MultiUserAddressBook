<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MultiUserAddressBook.master" AutoEventWireup="true" CodeFile="ContactAddEdit.aspx.cs" Inherits="Addmin_Panel_Contact_ContactAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    
       <div class="row border m-0">
        <div class="col-md-12 text-center">
             <h1>ADD Contact</h1>
            <div class="row">
                <div class="col-md-12">
                    <asp:Label ID="lblMassge" runat="server" Text="" ForeColor="#33CC33"></asp:Label>
                </div>
            </div>
        </div>
    </div>
    <div class="  d-block border  border-info shadow m-4">
        <div class="row m-0 ">
            <div class="col-md-12 col-sm-12 ">
                <div class="mt-3">
                    <div class="row">
                        <div class="col-md-6   font-weight-bold ">
                            <div class="row ">
                                <div class=" ml-3 col-md-5 mt-1 ">
                                    <asp:Label CssClass="form-label" ID="lblCountry" runat="server" Text="Select Country*"></asp:Label>
                                </div>
                                <div class="col-md-6  mt-1 ml-3">
                                    <asp:RequiredFieldValidator ID="rfvState" runat="server" ErrorMessage="Plasse Select Country" Display="Dynamic" ForeColor="Red" ControlToValidate="ddlCountry" InitialValue="-1" ValidationGroup="saveBtn"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                           <div class="col-md-12 mt-1">
                                <asp:DropDownList CssClass=" form-control" ID="ddlCountry" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>
                         
                        <div class="col-md-6  font-weight-bold">
                            <div class="row">
                                <div class="col-md-5 ml-3 mt-1 ">
                                    <asp:Label CssClass="form-label" ID="lblState" runat="server" Text="Select State*"></asp:Label>
                                </div>
                                <div class="col-md-6 mt-1 ml-3">
                                    <asp:RequiredFieldValidator ID="rfvSate" runat="server" ErrorMessage="Plasse Select State" Display="Dynamic" ForeColor="Red" ControlToValidate="ddlState" InitialValue="-1" ValidationGroup="saveBtn"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-12 mt-1">
                                <asp:DropDownList CssClass=" form-control" ID="ddlState" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlState_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>



        
    <div class="row  m-0 w-100">
        <div class="col-md-12">
            <div class=" form-group">
                <div class="row ">
                     <div class=" col-md-6">
                    <div class="row font-weight-bold">
                        <div class="col-md-5  ml-3 mt-1">
                            <asp:Label CssClass="form-label" ID="lblCity" runat="server" Text="Select City*"></asp:Label>
                        </div>
                        <div class="col-md-6  mt-1 ml-3">
                            <asp:RequiredFieldValidator ID="rfvCity" runat="server" ErrorMessage="Plasse Select State" Display="Dynamic" ForeColor="Red" ControlToValidate="ddlCity" InitialValue="-1" ValidationGroup="saveBtn"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                     <div class="col-md-12 mt-1">
                        <asp:DropDownList CssClass=" form-control" ID="ddlCity" runat="server" AutoPostBack="True"></asp:DropDownList>
                    </div>
                </div>
                    <div class="col-md-6">
                        <div class="row font-weight-bold">
                            <div class="col-md-5 ml-3 mt-1 ">
                                <asp:Label CssClass="col-form-label" ID="lblContactCategory" runat="server" Text="Select Contact Category"></asp:Label>
                            </div>
                            <div class="col-md-6 mt-1 ml-3 ">
                               <asp:Label ID="lblContectCategoryMassage" runat="server" ForeColor="Red"></asp:Label>
                            </div>
                        </div> 
                         <div class="col-md-12 mt-1">
                             <asp:CheckBoxList RepeatDirection="Horizontal" ID="cblContectCategoryID" runat="server"></asp:CheckBoxList>
                        </div>
                    </div>                    
                </div>
            </div>
        </div>
    </div>
        <div class="row  m-0">
        <div class="col-md-12">
            <div class="form-group">
                <div class="row  font-weight-bold">
                    <div class="col-md-6">
                        <div class="row ">
                            <div class="col-md-5 ml-3">
                                <asp:Label CssClass="col-form-label" ID="lblContactName" runat="server" Text="Enter Contact Name*"></asp:Label>
                            </div>
                            <div class="col-md-6 ml-3">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Plasse Enter Contact Name" Display="Dynamic" ForeColor="Red" ControlToValidate="txtContactName" ValidationGroup="saveBtn"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <asp:TextBox CssClass=" form-control" ID="txtContactName" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="row">
                             <div class="col-md-5 ml-3">
                                <asp:Label  ID="lblContectNO" runat="server" Text="Enter Contact Number*"></asp:Label>
                            </div>
                            <div class="col-md-6 ml-3">
                                  <asp:RegularExpressionValidator ID="revContectNo" runat="server" ErrorMessage="Enter Valid Contect No" Display="Dynamic" ValidationExpression="^[6-9][0-9]{9}$" ControlToValidate="txtContactNumber" ForeColor="Red" ValidationGroup="saveBtn"></asp:RegularExpressionValidator>
                                  <asp:RequiredFieldValidator ID="rfvContrctNo" runat="server" ErrorMessage="Plasse Enter Contact Number" Display="Dynamic" ForeColor="Red" ControlToValidate="txtContactNumber" ValidationGroup="saveBtn" ></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="col-md-12">
                            <asp:TextBox CssClass=" form-control" ID="txtContactNumber" runat="server"></asp:TextBox>
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
                    <div class="col-md-3">
                        <div class="row font-weight-bold">
                            <div class="col-md-12 ml-3">
                                  <asp:Label CssClass="col-form-label" ID="lblWhatsappNo" runat="server" Text="Enter Whatsapp No"></asp:Label>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <asp:TextBox CssClass=" form-control" ID="txtWhatsappNo" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-3">
                         <div class="row">
                              <div class="col-md-12 ml-3">
                                <asp:Label CssClass="col-form-label" ID="lblBirthDate" runat="server" Text="Enter Birth Date"></asp:Label>
                              </div>
                         </div>
                        <div class="col-md-12">
                            <asp:TextBox CssClass=" form-control" ID="txtBirthDate" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-md-3">
                        <div class="row">
                             <div class="col-md-12 ml-3">
                                <asp:Label CssClass="col-form-label" ID="lblAge" runat="server" Text="Enter Age"></asp:Label>
                            </div>
                        </div>
                         <div class="col-md-12">
                            <asp:TextBox CssClass="form-control" ID="txtAge" runat="server"></asp:TextBox>
                        </div>

                    </div>


                    <div class="col-md-3">
                        <div class="row">
                            <div class="col-md-12 ml-3">
                                <asp:Label CssClass="col-form-label" ID="lblBloodGroup" runat="server" Text="Enter Blood Group"></asp:Label>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <asp:TextBox CssClass="form-control" ID="txtBloodGroup" runat="server"></asp:TextBox>
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
                                <div class="col-md-3 ml-3">
                                    <asp:Label CssClass="col-form-label" ID="lblAddress" runat="server" Text="Enter Address*"></asp:Label>
                                </div>
                                 <div class="col-md-6 ml-3">
                                    <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ErrorMessage="Plasse Enter Address" Display="Dynamic" ForeColor="Red" ControlToValidate="txtAddress" ValidationGroup="saveBtn" ></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <asp:TextBox CssClass=" form-control" ID="txtAddress" runat="server"></asp:TextBox>
                            </div>

                        </div>
                    </div>

                </div>
            </div>
        </div>




        <div class="row  m-0">
            <div class="col-md-12">
                <div class="form-group">
                    <div class="row font-weight-bold">
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-5 ml-3">
                                    <asp:Label CssClass="col-form-label" ID="lblEmail" runat="server" Text="Enter Email*"></asp:Label>
                                </div>
                                <div class="col-md-6 ml-3 ">
                                    <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="Plasse Enter Email " Display="Dynamic" ForeColor="Red" ControlToValidate="txtEmail" ValidationGroup="saveBtn"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="revEmail" runat="server" ErrorMessage="Enter valid Email ID" ControlToValidate="txtEmail" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="Red" ValidationGroup="saveBtn"></asp:RegularExpressionValidator>
                                </div>

                            </div>

                            <div class="col-md-12">
                                <asp:TextBox CssClass=" form-control" ID="txtEmail" runat="server"></asp:TextBox>
                            </div>

                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-12 ml-3">
                                  <asp:Label CssClass="col-form-label" ID="lblFaceBookID" runat="server" Text="Enter FaceBook ID"></asp:Label>
                                </div>

                            </div>
                             <div class="col-md-12">
                                <asp:TextBox CssClass="form-control" ID="txtFaceBookID" runat="server"></asp:TextBox>
                            </div>


                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-12 ml-3">
                                    <asp:Label CssClass="col-form-label" ID="lblLinkinID" runat="server" Text="Enter LinkIn ID"></asp:Label>
                                </div>
                            </div>

                             <div class="col-md-12">
                                <asp:TextBox CssClass="form-control" ID="txtLinkInId" runat="server"></asp:TextBox>
                            </div>

                        </div>

                    </div>

                    
                </div>
            </div>
        </div>

          <div class="row m-0 mb-4">
            <div class="col-md-12 col-sm-12 ">
                <div class="mt-3">
                    <div class="row ">
                        <div class="col-md-6   font-weight-bold ">
                            <div class="row ">
                                <div class=" ml-3 col-md-2 mt-1 ">
                                    <asp:Label ID="lblSelectFile" CssClass="form-control-file" runat="server" Text="Select File"></asp:Label>&nbsp;&nbsp;
                                </div>
                                <div class="col-md-3  mt-1 ml-0">
                                <%--<asp:RequiredFieldValidator ID="rfvFileUplod" runat="server" ErrorMessage="Plasee Select File" ControlToValidate="fuContactPhotoPath" Display="Dynamic" ForeColor="Red" ValidationGroup="saveBtn"></asp:RequiredFieldValidator>--%>
                                    <asp:Label ID="lblphoto" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                              <div class="col-md-6" style="object-fit:cover;">
                                <asp:Image ID="Image1" runat="server"     CssClass="mb-2" Width="180" Height="130"  />
                       </div>
                           <div class="col-md-6 ">
                                <asp:FileUpload ID="fuContactPhotoPath" runat="server"  CssClass=" " />
                            </div>
                        </div>
                         
                     
                        </div>
                    </div>
                </div>
            </div>
        <div>
            <asp:Label ID="lblPhotoPath" runat="server" Text="" Visible="false"></asp:Label><br />
            <asp:Label ID="lblFileName" runat="server" Text="" Visible="false"></asp:Label><br />
            <asp:Label ID="lblFileSize" runat="server" Text="" Visible="false"></asp:Label><br />
            <asp:Label ID="lblFileExt" runat="server" Text="" Visible="false"></asp:Label><br />
        </div>

        <div class="col-md-12">
            <div class="text-center m-2">
                <asp:Button CssClass="btn  btn-primary pl-4 pr-4" ID="btnSave" runat="server" Text="Save" ValidationGroup="saveBtn" OnClick="btnSave_Click1"   />
                <asp:HyperLink CssClass="btn  btn-danger" ID="hlCancal" runat="server" Text="Cancal" NavigateUrl="~/AddminPanel/Contact/List" />
            </div>
        </div>



    </div>
    
</asp:Content>

