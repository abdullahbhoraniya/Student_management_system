<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="StudentManaghement.Admin.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>

    <style>
        body {
            margin: 0;
            font-family: 'Segoe UI', sans-serif;
            height: 100vh;
            display: flex;
            background: linear-gradient(135deg, #667eea, #764ba2);
        }

        /* LEFT SIDE (branding) */
        .left {
            flex: 1;
            color: white;
            display: flex;
            flex-direction: column;
            justify-content: center;
            padding: 60px;
        }

        .left h1 {
            font-size: 36px;
            margin-bottom: 10px;
        }

        .left p {
            font-size: 16px;
            opacity: 0.9;
        }

        /* RIGHT SIDE (login box) */
        .right {
            width: 400px;
            background: white;
            display: flex;
            align-items: center;
            justify-content: center;
        }

        .login-box {
            width: 80%;
        }

        .login-box h2 {
            margin-bottom: 20px;
            color: #333;
        }

        .input-group {
            margin-bottom: 15px;
        }

        .input-group label {
            font-size: 13px;
            color: #555;
        }

        .input-group input {
            width: 100%;
            padding: 10px;
            margin-top: 5px;
            border-radius: 6px;
            border: 1px solid #ccc;
        }

        .input-group input:focus {
            border-color: #667eea;
            outline: none;
        }

        .btn-login {
            width: 100%;
            padding: 12px;
            background: #667eea;
            border: none;
            border-radius: 6px;
            color: white;
            font-size: 15px;
            cursor: pointer;
            transition: 0.2s;
        }

        .btn-login:hover {
            background: #5a67d8;
        }

        .message {
            color: red;
            font-size: 13px;
            margin-bottom: 10px;
        }

        .footer {
            text-align: center;
            margin-top: 15px;
            font-size: 12px;
            color: #888;
        }

        @media (max-width: 768px) {
            .left {
                display: none;
            }

            .right {
                width: 100%;
            }
        }
    </style>
</head>

<body>

    <!-- LEFT SIDE -->
    <div class="left">
        <h1>Student Management</h1>
        <p>Manage students, users, and exams from one place.</p>
    </div>

    <!-- RIGHT SIDE -->
    <div class="right">
        <form id="form1" runat="server">
            <div class="login-box">

                <h2>Login</h2>

                <asp:Label ID="lblMessage" runat="server" CssClass="message" />

                <div class="input-group">
                    <label>Email</label>
                    <asp:TextBox ID="txtEmail" runat="server" />
                </div>

                <div class="input-group">
                    <label>Password</label>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" />
                </div>

                <asp:Button ID="btnLogin" runat="server"
                    Text="Login"
                    CssClass="btn-login"
                    OnClick="btnLogin_Click" />

                <div class="footer">
                    © Student Management System
                </div>

            </div>
        </form>
    </div>

</body>
</html>