<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MultiUserAddressBook.master" AutoEventWireup="true" CodeFile="CountryAddEdit.aspx.cs" Inherits="Addmin_Panel_Country_CountryAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    
    <div class="row  border m-4  border-info p-4  ">
        <div class="col-md-12 text-center">
            <h1>ADD Country</h1>
            <div class="col-md-12">
                <asp:Label ID="lblMassge" runat="server" ForeColor="Red"></asp:Label>
            </div>
        </div>
       
            <div class="col-md-12">

                <div class=" m-3  form-group">
                    <div class="row">
                    <div class="col-md-3"></div>
                    <div class="col-md-9 h5">
                        <asp:RequiredFieldValidator ID="rfvCountry" runat="server" ErrorMessage="Plase Enter Country " Display="Dynamic" ForeColor="Red" ControlToValidate="txtCountryName"></asp:RequiredFieldValidator>


                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3 h4  text-md-right text-sm-left">
                            <asp:Label CssClass="col-form-label" ID="LblCountry" runat="server" Text="Enter Country:-"></asp:Label>
                    </div>
                     <div class="col-md-9">
                             <asp:TextBox CssClass=" form-control" ID="txtCountryName" runat="server" placeholder="Enter Country Name"></asp:TextBox>
                    </div>
                </div>
                
            </div>



             
            </div>

       
       <div class="col-md-12">
            <div class=" m-3  form-group">
                <div class="row">
                    <div class="col-md-3"></div>
                    <div class="col-md-9 h5">
                        <asp:RequiredFieldValidator ID="rfvCountryCode" runat="server" ErrorMessage="Plasse Enter  CountryCode" ControlToValidate="txtCountryCode" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>


                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3 h4  text-md-right text-sm-left">
                             <asp:Label CssClass="col-form-label" ID="lblCountryCode" runat="server" Text="Enter Country Code:-"></asp:Label>
                    </div>
                     <div class="col-md-9">
                             <asp:TextBox CssClass=" form-control" ID="txtCountryCode" runat="server" placeholder="Enter Country Code"></asp:TextBox>
                    </div>
                </div>
                
            </div>
        </div>

      
        
        <div class="col-md-12">
            <div class="text-center">
                <asp:Button CssClass="btn  btn-primary" ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click"/>
                <asp:HyperLink CssClass="btn  btn-danger" ID="hlCancal" runat="server" Text="Cancal" NavigateUrl="~/AddminPanel/Country/List" />

            </div>
        </div>
    </div>
    
    
</asp:Content>

