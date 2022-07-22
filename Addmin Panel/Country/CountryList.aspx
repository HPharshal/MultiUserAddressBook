<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MultiUserAddressBook.master" AutoEventWireup="true" CodeFile="CountryList.aspx.cs" Inherits="Addmin_Panel_Country_CountryList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     <div>

       <div class="col-12">
           <div class="row bg-info">
               <div class="col-8">
                   <h1 class="pt-2">Country List</h1>
                   
               </div>
               <div class="col-4 float-left pt-3">
                   <asp:HyperLink ID="hlAddCountry" CssClass="btn btn-sm  btn-outline-light float-right" NavigateUrl="~/AddminPanel/Country/List/Add" runat="server">Add Country</asp:HyperLink>
               </div>

           </div>
            <div class="row">
               <div class="col-md-12">
                   <asp:Label ID="lblmassge" runat="server" Text=""/>
               </div>
           </div>
           <div class="mt-3">
           <asp:GridView ID="gvCountry" runat="server" CssClass="table text-center  table-hover shadow"  AutoGenerateColumns="false" OnRowCommand="gvCountry_RowCommand">
                <Columns>
                <asp:BoundField DataField ="CountryID" HeaderText="ID"/>
                <asp:BoundField DataField ="CountryName" HeaderText="Country"/>
                <asp:BoundField DataField ="CountryCode" HeaderText="CountryCode"/>
               <asp:TemplateField HeaderText="Edit">
                    <ItemTemplate>
                        <asp:HyperLink ID="hlEdit" runat="server" Text="Edit" CssClass="btn btn-success btn-sm btn-block " commandName="EditRecord "  NavigateUrl ='<%#"~/AddminPanel/Country/Edit/" +CommonDropDownFillMethods.Base64encode(Eval("CountryID").ToString().Trim())%>' />
                    </ItemTemplate>
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="Delete">
                    <ItemTemplate >
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger btn-sm btn-block " CommandName="DeleteRecord" CommandArgument='<%#Eval("CountryID").ToString().Trim() %>'  />
                    </ItemTemplate>
                </asp:TemplateField>
               
            </Columns>

           </asp:GridView>

           </div>
       </div>
   </div>


</asp:Content>

