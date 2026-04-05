<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminDashboard.aspx.cs" Inherits="StudentManaghement.AdminDashboard" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Dashboard</title>

    <!-- Chart.js CDN -->
    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>

    <style>
        body {
            font-family: Arial;
            margin: 0;
            background: #f5f5f5;
        }

        .navbar {
            background: #2c3e50;
            color: white;
            padding: 15px;
            display: flex;
            justify-content: space-between;
        }

        .container {
            padding: 20px;
        }

        .card {
            background: white;
            padding: 20px;
            margin-top: 20px;
            border-radius: 5px;
        }

        .logout-btn {
            background: red;
            color: white;
            border: none;
            padding: 8px 12px;
            cursor: pointer;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">

        <!-- 🔹 Top Navbar -->
        <div class="navbar">
            <div>
                Welcome,
                <asp:Label ID="lblUserName" runat="server"></asp:Label>
            </div>

            <div>
                <asp:Button ID="btnLogout" runat="server" Text="Logout" CssClass="logout-btn" OnClick="btnLogout_Click" />
            </div>
        </div>

        <div style="display: flex;">

            <div style="width: 200px; background: #34495e; color: white; min-height: 100vh; padding: 10px;">
                <h4>User Actions</h4>
                <asp:HyperLink runat="server" NavigateUrl="~/admin/UsersList.aspx" Text="Users List" /><br />
                <br />
                <asp:HyperLink runat="server" NavigateUrl="~/admin/UserForm.aspx" Text="Create User" /><br />
                <br />

                <h4>Student Actions</h4>
                <asp:HyperLink runat="server" NavigateUrl="~/StudentsList.aspx" Text="Students List" /><br />
                <br />
                <asp:HyperLink runat="server" NavigateUrl="~/StudentForm.aspx" Text="Create Student" />
            </div>

            <div style="flex: 1; padding: 20px;">
                <h2>Dashboard</h2>
                <p>Select an action from the menu.</p>
            </div>

        </div>

        <!-- 🔹 Content -->
        <div class="container">

            <div class="card">
                <h2>Dashboard</h2>
                <p>Welcome to your dashboard. You are successfully logged in.</p>
            </div>

            <div class="card">
                <h3>Sample Chart</h3>
                <canvas id="myChart" width="400" height="150"></canvas>
            </div>

        </div>

    </form>

    <!-- 🔹 Chart Script -->
    <script>
        const ctx = document.getElementById('myChart');

        new Chart(ctx, {
            type: 'bar',
            data: {
                labels: ['Jan', 'Feb', 'Mar', 'Apr'],
                datasets: [{
                    label: 'Users Data',
                    data: [10, 25, 15, 30]
                }]
            }
        });
    </script>

</body>
</html>
