<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentsList.aspx.cs" Inherits="StudentManaghement.Admin.StudentsList" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student Management</title>

    <style>
        body {
            font-family: Arial;
            background: #f4f6f9;
        }

        .container {
            width: 900px;
            margin: 30px auto;
        }

        .card {
            background: white;
            padding: 20px;
            border-radius: 10px;
            margin-bottom: 20px;
            box-shadow: 0 2px 6px rgba(0,0,0,0.1);
        }

        .form-group {
            margin-bottom: 10px;
        }

        .form-control {
            width: 100%;
            padding: 8px;
        }

        .btn {
            padding: 8px 12px;
            border: none;
            margin-right: 5px;
            cursor: pointer;
        }

        .btn-save { background: green; color: white; }
        .btn-update { background: blue; color: white; }
        .btn-edit { background: orange; }
        .btn-delete { background: red; color: white; }

        .grid {
            width: 100%;
        }
    </style>
</head>

<body>
<form id="form1" runat="server">
<div class="container">

    <!-- FORM -->
    <div class="card">
        <h2>Create / Update Student</h2>

        <asp:HiddenField ID="hfStudentId" runat="server" />

        <div class="form-group">
            Name:
            <asp:TextBox ID="txtName" runat="server" CssClass="form-control" />
        </div>

        <div class="form-group">
            Email:
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />
        </div>

        <div class="form-group">
            Phone:
            <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" />
        </div>

        <div class="form-group">
            Address:
            <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" />
        </div>

        <div class="form-group">
            Password:
            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" />
        </div>

        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-save" OnClick="btnSave_Click" />
        <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-update" OnClick="btnUpdate_Click" />
    </div>

    <!-- GRID -->
    <div class="card">
        <h2>Student List</h2>

        <asp:GridView ID="gvStudents" runat="server"
            CssClass="grid"
            AutoGenerateColumns="false"
            OnRowCommand="gvStudents_RowCommand">

            <Columns>
                <asp:BoundField DataField="StudentId" HeaderText="ID" />
                <asp:BoundField DataField="FullName" HeaderText="Name" />
                <asp:BoundField DataField="EmailId" HeaderText="Email" />
                <asp:BoundField DataField="PhoneNo" HeaderText="Phone" />
                <asp:BoundField DataField="Address" HeaderText="Address" />

                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button runat="server" Text="Edit"
                            CssClass="btn btn-edit"
                            CommandName="EditRow"
                            CommandArgument='<%# Eval("StudentId") %>' />

                        <asp:Button runat="server" Text="Delete"
                            CssClass="btn btn-delete"
                            CommandName="DeleteRow"
                            CommandArgument='<%# Eval("StudentId") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

        </asp:GridView>
    </div>

</div>
</form>
</body>
</html>