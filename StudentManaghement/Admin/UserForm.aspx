<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserForm.aspx.cs" Inherits="StudentManaghement.Admin.UserForm" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Form</title>

    <style>
        body {
            margin: 0;
            font-family: Arial, sans-serif;
            background: #f4f6f9;
        }

        /* NAVBAR */
        .navbar {
            height: 60px;
            background: #1f2937;
            color: white;
            display: flex;
            align-items: center;
            padding: 0 20px;
            font-weight: bold;
        }

        /* LAYOUT */
        .layout {
            display: flex;
        }

        /* SIDEBAR */
        .sidebar {
            width: 220px;
            background: #111827;
            color: white;
            min-height: calc(100vh - 60px);
            padding: 15px;
        }

        .sidebar a {
            display: block;
            color: #e5e7eb;
            text-decoration: none;
            padding: 8px;
            border-radius: 6px;
            margin-bottom: 5px;
        }

        .sidebar a:hover {
            background: #374151;
        }

        /* MAIN */
        .main {
            flex: 1;
            padding: 20px;
        }

        /* CARD */
        .card {
            background: white;
            padding: 25px;
            border-radius: 10px;
            max-width: 500px;
            box-shadow: 0 2px 8px rgba(0,0,0,0.08);
        }

        .card h2 {
            margin-top: 0;
        }

        /* FORM */
        .form-group {
            margin-bottom: 15px;
        }

        .form-group label {
            display: block;
            font-size: 13px;
            margin-bottom: 4px;
            color: #555;
        }

        .form-control {
            width: 100%;
            padding: 10px;
            border-radius: 6px;
            border: 1px solid #ccc;
        }

        .form-control:focus {
            border-color: #3b82f6;
            outline: none;
        }

        /* BUTTON */
        .btn {
            padding: 10px 15px;
            background: #3b82f6;
            border: none;
            color: white;
            border-radius: 6px;
            cursor: pointer;
        }

        .btn:hover {
            background: #2563eb;
        }

        /* MESSAGE */
        .message {
            margin-top: 10px;
            font-size: 13px;
            color: green;
        }
    </style>
</head>

<body>

<form id="form1" runat="server">

    <!-- NAVBAR -->
    <div class="navbar">
        User Management
    </div>

    <div class="layout">

        <!-- SIDEBAR -->
        <div class="sidebar">
            <asp:HyperLink runat="server" NavigateUrl="~/admin/UsersList.aspx" Text="Users List" />
            <asp:HyperLink runat="server" NavigateUrl="~/admin/UserForm.aspx" Text="Create User" />
            <asp:HyperLink runat="server" NavigateUrl="~/admin/StudentsList.aspx" Text="Students List" />
        </div>

        <!-- MAIN -->
        <div class="main">

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

        </div>

    </div>

</form>

</body>
</html>