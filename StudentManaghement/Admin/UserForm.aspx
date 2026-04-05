<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserForm.aspx.cs" Inherits="StudentManaghement.Admin.UserForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
   <form id="form1" runat="server">

    <h2>User Form</h2>

    <asp:HiddenField ID="hfUserId" runat="server" />

    <asp:TextBox ID="txtName" runat="server" Placeholder="Full Name"></asp:TextBox><br /><br />
    <asp:TextBox ID="txtEmail" runat="server" Placeholder="Email"></asp:TextBox><br /><br />
    <asp:TextBox ID="txtPhone" runat="server" Placeholder="Phone"></asp:TextBox><br /><br />
    <asp:TextBox ID="txtAddress" runat="server" Placeholder="Address"></asp:TextBox><br /><br />
    <asp:TextBox ID="txtPassword" runat="server" Placeholder="Password"></asp:TextBox><br /><br />

    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />

    <br /><br />
    <asp:Label ID="lblMessage" runat="server"></asp:Label>

</form>
</body>
</html>
