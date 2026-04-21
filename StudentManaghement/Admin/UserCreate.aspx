<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin_mst.Master" AutoEventWireup="true" CodeBehind="UserCreate.aspx.cs" Inherits="StudentManaghement.Admin.UserCreate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="card">
     <h2>Create / Update User</h2>

     <asp:HiddenField ID="hfUserId" runat="server" />

     <div class="form-group">
         <label>Full Name</label>
         <asp:TextBox ID="txtName" runat="server" CssClass="form-control" />
     </div>

     <div class="form-group">
         <label>Email</label>
         <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />
     </div>

     <div class="form-group">
         <label>Phone</label>
         <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" />
     </div>

     <div class="form-group">
         <label>Address</label>
         <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" />
     </div>

     <div class="form-group">
         <label>Password</label>
         <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" />
     </div>

     <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn" OnClick="btnSave_Click" />

     <asp:Label ID="lblMessage" runat="server" CssClass="message" />

 </div>
</asp:Content>
