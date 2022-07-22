<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MultiUserAddressBook.master" AutoEventWireup="true" CodeFile="CityList.aspx.cs" Inherits="Addmin_Panel_City_CityList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    
    <div>
        <div class="col-md-12 ">
            <div class="row  bg-info">
                <div class="col-6">
                    <h1 class="pt-2">City List</h1>
                </div>
                <div class="col-6  pt-3 ">
                    <asp:HyperLink ID="hlAddState" CssClass="btn btn-sm btn-outline-light float-right" NavigateUrl="~/AddminPanel/City/List/Add" runat="server">Add Country</asp:HyperLink>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <asp:Label ID="lblMassge" runat="server" Text=""></asp:Label>
                </div>

            </div>
            <div class="mt-2">
                <asp:GridView ID="gvCity" runat="server" CssClass="  table text-center  table-hover shadow " AutoGenerateColumns="false" OnRowCommand="gvCity_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="CityID" HeaderText="ID" />
                        <asp:BoundField DataField="StateName" HeaderText="StateName" />
                        <asp:BoundField DataField="CityName" HeaderText="CityName" />
                        <asp:BoundField DataField="STDCode" HeaderText="STDCode" />
                        <asp:BoundField DataField="PinCode" HeaderText="PINCode" />
                        
                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:HyperLink ID="hlEdit" runat="server" Text="Edit" CssClass="btn btn-success btn-sm btn-block " NavigateUrl='<%#"~/AddminPanel/City/List/Edit/" +CommonDropDownFillMethods.Base64encode(Eval("CityID").ToString().Trim())%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>
                                <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger btn-sm btn-block " CommandName="DeleteRecord" CommandArgument='<%#Eval("CityID").ToString().Trim() %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
    
</asp:Content>

