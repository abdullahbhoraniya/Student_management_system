<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin_mst.Master" AutoEventWireup="true" CodeBehind="UserSearch.aspx.cs" Inherits="StudentManaghement.Admin.UserSearch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Users List</h2>

<!-- 🔍 Search -->
<asp:TextBox ID="txtSearch" runat="server" Placeholder="Search by name"></asp:TextBox>
<asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />

<br /><br />

<!-- 📋 Grid -->
<asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="false">
    <Columns>
        <asp:BoundField DataField="UserId" HeaderText="ID" />
        <asp:BoundField DataField="FullName" HeaderText="Name" />
        <asp:BoundField DataField="EmailId" HeaderText="Email" />

        <asp:TemplateField HeaderText="Action">
            <ItemTemplate>
                <a href='UserForm.aspx?id=<%# Eval("UserId") %>'>Edit</a>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
</asp:Content>
