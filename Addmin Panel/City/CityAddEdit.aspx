<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MultiUserAddressBook.master" AutoEventWireup="true" CodeFile="CityAddEdit.aspx.cs" Inherits="Addmin_Panel_City_CityAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="row  border m-4  border-info p-4  ">
        <div class="col-md-12 text-center">
            <h1>ADD City</h1>
            <div class="col-md-12">
                <asp:Label ID="lblMassge" runat="server" ForeColor="Red"></asp:Label>
            </div>
        </div>
       
            <div class="col-md-12">

               

                <div class=" m-3  form-group">

                     <div class="row">
                    
                </div>



                    <div class="row">
                    <div class="col-md-3"></div>
                    <div class="col-md-9 h5">
                        <asp:RequiredFieldValidator ID="rfvCountry" runat="server" ErrorMessage="Plasse Select State" Display="Dynamic" ForeColor="Red" ControlToValidate="ddlState" InitialValue="-1"></asp:RequiredFieldValidator>


                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3 h4  text-md-right text-sm-left">
                            <asp:Label CssClass="col-form-label" ID="LblState" runat="server" Text="Select State:-"></asp:Label>
                    </div>
                     <div class="col-md-9">
                             <asp:DropDownList CssClass=" form-control" ID="ddlState" runat="server" AutoPostBack="True"></asp:DropDownList>
                    </div>
                </div>
                
            </div>



             
            </div>

       
       <div class="col-md-12">
            <div class=" m-3  form-group">
                <div class="row">
                    <div class="col-md-3"></div>
                    <div class="col-md-9 h5">
                        <asp:RequiredFieldValidator ID="rfvStateName" runat="server" ErrorMessage="Plasse Enter City Name" ControlToValidate="txtCityName" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>


                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3 h4  text-md-right text-sm-left">
                             <asp:Label CssClass="col-form-label" ID="lblCity" runat="server" Text="Enter City Name:-"></asp:Label>
                    </div>
                     <div class="col-md-9">
                             <asp:TextBox CssClass=" form-control" ID="txtCityName" runat="server" placeholder="Enter City Name"></asp:TextBox>
                    </div>
                </div>
                
            </div>
        </div>

        <div class="col-md-12">
            <div class=" m-3  form-group">
                
                 <div class="row">
                    <div class="col-md-3 h4  text-sm-left  col-sm-12 text-md-right">
                             <asp:Label CssClass="col-form-label" ID="lblSTDCode" runat="server"  Text="Enter STD Code:-"></asp:Label>
                    </div>
                     <div class="col-md-3">
                             <asp:TextBox CssClass=" form-control" ID="txtSTDCode" runat="server" placeholder="Enter STD Code" ></asp:TextBox>
                    </div>
                     <div class="col-md-2 h4  text-sm-left  col-sm-12 text-md-right">
                             <asp:Label CssClass="col-form-label" ID="LblPINCode" runat="server"  Text="Enter PIN Code:-"></asp:Label>
                    </div>
                     <div class="col-md-3">
                             <asp:TextBox CssClass=" form-control" ID="txtPINcode" runat="server" placeholder="Enter PIN Code" ></asp:TextBox>
                    </div>
                </div>
                
                
            </div>
        </div>

        <div class="col-md-12">
            <div class="text-center">
                <asp:Button CssClass="btn  btn-primary" ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click1"/>
                <asp:HyperLink CssClass="btn  btn-danger" ID="hlCancal" runat="server" Text="Cancal" NavigateUrl="~/Addmin Panel/City/CityList.aspx" />

            </div>
        </div>
    </div>
</asp:Content>

