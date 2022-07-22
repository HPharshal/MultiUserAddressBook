<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MultiUserAddressBook.master" AutoEventWireup="true" CodeFile="ContactCategoryList.aspx.cs" Inherits="Addmin_Panel_ContactCategory_ContactCategoryList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="col-12">
        <div class="row badge-info">
       
            <div class="col-12 border p-2 ">
                <h4 class="text-md-left">Contact Category List</h4>
            </div>
            <div class="col-12">
                 
                <div class="row">
                    <div class="col-4  h5  mt-2">
                        <asp:Label CssClass="col-form-label" ID="lblContactCategory" runat="server" Text="Enter Contact Category"></asp:Label>
                    </div>
                     <div class="col-4  h5 mt-2 text-center ">
                        <asp:RequiredFieldValidator CssClass="col-form-label" ID="rfvStateName" runat="server" ErrorMessage="Plasse Enter  Contact Category" ControlToValidate="txtContactCategory" Display="Static" ForeColor="Red" SetFocusOnError="True" ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                    </div>
                    
                    
                </div>
               
           <div class="row">
            <div class="col-md-12 mt-2 pt-1  mb-2">
                        <asp:TextBox CssClass=" form-control" ID="txtContactCategory" runat="server" placeholder="Enter Name"></asp:TextBox>
                    </div>

              
                     <div class="col-12  text-center">

                        <asp:Button CssClass="btn  pl-3 pr-3 btn-primary m-3" ID="btnSave" runat="server" Text="save" OnClick="btnSave_Click" ValidationGroup="btnsave" />
                        <asp:HyperLink CssClass="btn pl-3 pr-3 btn-danger  m-3" ID="hlCancal" runat="server" Text="Cancal" NavigateUrl="~/Addmin Panel/ContactCategory/ContactCategoryList.aspx" />

                    </div>

           </div>
            
            </div>
                 
           
       </div>

        <div class="row">
            <div class="col-md-12 text-center">
                <asp:Label ID="lblMassge" runat="server" ForeColor="#00CC00"></asp:Label>
            </div>

        </div>
           
        <div class="mt-3">
            <asp:GridView ID="gvCountry" runat="server" CssClass="w-100 table   text-center  table-hover shadow " AutoGenerateColumns="false" OnRowCommand="gvCountry_RowCommand">
                <Columns>
                    <asp:BoundField DataField="ContactCategoryID" HeaderText="ID" />

                    <asp:BoundField DataField="ContactCategoryName" HeaderText="ContactCategory" />
                    
                    <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>

                            <asp:HyperLink ID="hlEdit" runat="server" Text="Edit" CssClass="btn btn-success btn-sm btn-block " NavigateUrl ='<%#"~/Addmin Panel/ContactCategory/ContactCategoryList.aspx?ContactCategoryID=" + Eval("ContactCategoryID").ToString().Trim()%>'  />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger btn-sm btn-block " CommandName="DeleteRecord" CommandArgument='<%# Eval("ContactCategoryID").ToString().Trim() %>'    />
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>

            </asp:GridView>

        </div>

        
    
    </div>
</asp:Content>

