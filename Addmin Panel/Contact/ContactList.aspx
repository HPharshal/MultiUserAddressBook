<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MultiUserAddressBook.master" AutoEventWireup="true" CodeFile="ContactList.aspx.cs" Inherits="Addmin_Panel_Contact_ContactList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

       <div>

        <div class=" col-12">
            <div class="row bg-info">
                <div class="col-8">
                    <h1 class="pt-2">Contact List</h1>
                </div>
                <div class="col-4 float-left pt-3">
                 <asp:HyperLink ID="hlAddContact" CssClass="btn btn-sm btn-outline-light float-right" NavigateUrl="~/AddminPanel/Contact/List/Add" runat="server">Add Country</asp:HyperLink>

                </div>
            </div>
            <div class="row ">
               <div class="col-md-12">
                   <asp:Label ID="lblmassge" runat="server" Text=""/>
               </div>
           </div>
            <div class="mt-3 overflow-auto">
            <asp:GridView CssClass="w-100 table text-center  table-hover shadow" ID="gvContact" runat="server" AutoGenerateColumns="false" OnRowCommand="gvContact_RowCommand">

                <Columns>
                     
                    
                    <%--<asp:BoundField DataField="ContactID" HeaderText="ID" />--%>
                    <asp:BoundField DataField="CountryName" HeaderText="Country" />
                    <asp:BoundField DataField="StateName" HeaderText="State" />
                    <asp:BoundField DataField="CityName" HeaderText="City" />
                    <asp:BoundField DataField="category" HeaderText="ContactCategory" />
                    <asp:BoundField DataField="ContactName" HeaderText="Name" />
                    <asp:BoundField DataField="ContactNo" HeaderText="PhoneNO" />
                    <asp:BoundField DataField="WhatsAppNo" HeaderText="WhatsAppNo" />
                    <asp:BoundField DataField="BirthDate" HeaderText="BirthDate" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:BoundField DataField="Age" HeaderText="Age" />
                    <asp:BoundField DataField="Address" HeaderText="Address" />
                    <asp:BoundField DataField="BloodGroup" HeaderText="BloodGroup" />
                    <asp:BoundField DataField="FaceBookID" HeaderText="FaceBook" />
                    <asp:BoundField DataField="LinkedInID" HeaderText="LinkedIn" />
                    <asp:TemplateField HeaderText="Photo">
                        <ItemTemplate>
                            <asp:Image ID="imgPhoto" CssClass="img mx-auto " runat="server" ImageUrl='<%#Eval("ContactPhotoPath") %>' Width="130" Height="140" />
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="File Info" ItemStyle-CssClass="text-left">
                        <ItemTemplate>
                            <asp:Label ID="lblFileInfo" runat="server" Text='<%#"FileName:"+" "+"<b>"+Eval("FileName")+"</b>"+"<br>"+"FileSize:"+" "+"<b>"+ Eval("FileSize")+"</b>"+"<br>"+"FileType:"+" "+"<b>"+Eval("FileExt")+"</b>"+"<br>" %> '></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                            <asp:HyperLink ID="hlEdit" runat="server" Text="Edit" CssClass="btn btn-success btn-sm btn-block " NavigateUrl='<%#"~/AddminPanel/Contact/List/Edit/" +CommonDropDownFillMethods.Base64encode(Eval("ContactID").ToString().Trim())%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger btn-sm btn-block " CommandName="DeleteRecord" CommandArgument='<%#Eval("ContactID").ToString().Trim() %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            </div>

        </div>
    </div>
</asp:Content>

