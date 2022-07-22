<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MultiUserAddressBook.master" AutoEventWireup="true" CodeFile="StateAddEdit.aspx.cs" Inherits="Addmin_Panel_State_StateAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="row  border m-4  border-info p-4  shadow ">
        <div class="col-md-12 text-center">
            <h1>ADD State</h1>
            <div class="col-md-12">
                <asp:Label ID="lblMassge" runat="server" ForeColor="Red"></asp:Label>
            </div>
        </div>
       
            <div class="col-md-12 ">

                <div class=" m-3  form-group">
                    <div class="row">
                    <div class="col-md-3"></div>
                    <div class="col-md-9 h5">
                        <asp:RequiredFieldValidator ID="rfvCountry" runat="server" ErrorMessage="Plasse Select Country " Display="Dynamic" ForeColor="Red" ControlToValidate="ddlCountry" InitialValue="-1"></asp:RequiredFieldValidator>


                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3 h4  text-md-right text-sm-left">
                            <asp:Label CssClass="col-form-label" ID="LblCountry" runat="server" Text="Select Country:-"></asp:Label>
                    </div>
                     <div class="col-md-9">
                             <asp:DropDownList CssClass=" form-control" ID="ddlCountry" runat="server"></asp:DropDownList>
                    </div>
                </div>
                
            </div>



             
            </div>

       
       <div class="col-md-12">
            <div class=" m-3  form-group">
                <div class="row">
                    <div class="col-md-3"></div>
                    <div class="col-md-9 h5">
                        <asp:RequiredFieldValidator ID="rfvStateName" runat="server" ErrorMessage="Plasse Enter  State Name" ControlToValidate="txtStateName" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>


                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3 h4  text-md-right text-sm-left">
                             <asp:Label CssClass="col-form-label" ID="lblState" runat="server" Text="Enter State Name:-"></asp:Label>
                    </div>
                     <div class="col-md-9">
                             <asp:TextBox CssClass=" form-control" ID="txtStateName" runat="server" placeholder="Enter Name"></asp:TextBox>
                    </div>
                </div>
                
            </div>
        </div>

        <div class="col-md-12">
            <div class=" m-3  form-group">
                <div class="row">
                    <div class="col-md-3"></div>
                    <div class="col-md-9 h5">
                        <asp:RequiredFieldValidator ID="rfvStateCode" runat="server" ErrorMessage="Plasse Enter  State Code" ControlToValidate="txtStateCode" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>


                    </div>
                </div>
                 <div class="row">
                    <div class="col-md-3 h4  text-sm-left  col-sm-12 text-md-right">
                             <asp:Label CssClass="col-form-label" ID="lblStateCode" runat="server"  Text="Enter State Code:-"></asp:Label>
                    </div>
                     <div class="col-md-9">
                             <asp:TextBox CssClass=" form-control" ID="txtStateCode" runat="server" placeholder="Enter Code" ></asp:TextBox>
                    </div>
                </div>
                
                
            </div>
        </div>
        
        <div class="col-md-12">
            <div class="text-center">
                <asp:Button CssClass="btn  btn-primary" ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click"   />
                <asp:HyperLink CssClass="btn  btn-danger" ID="hlCancal" runat="server" Text="Cancal" NavigateUrl="~/Addmin Panel/State/StateList.aspx" />

            </div>
        </div>
    </div>

</asp:Content>

