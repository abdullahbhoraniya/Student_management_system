<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminDashboard.aspx.cs" Inherits="StudentManaghement.AdminDashboard" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Dashboard</title>

    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>

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
            justify-content: space-between;
            padding: 0 20px;
        }

        .navbar .title {
            font-size: 18px;
            font-weight: bold;
        }

        .logout-btn {
            background: #ef4444;
            border: none;
            padding: 6px 12px;
            color: white;
            border-radius: 5px;
            cursor: pointer;
        }

        .logout-btn:hover {
            background: #dc2626;
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

        .sidebar h4 {
            margin-top: 20px;
            font-size: 14px;
            color: #9ca3af;
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

        /* CARDS */
        .card {
            background: white;
            padding: 20px;
            border-radius: 10px;
            margin-bottom: 20px;
            box-shadow: 0 2px 6px rgba(0,0,0,0.08);
        }

        .card h2, .card h3 {
            margin-top: 0;
        }

        /* STATS GRID */
        .stats {
            display: grid;
            grid-template-columns: repeat(3, 1fr);
            gap: 15px;
        }

        .stat-box {
            background: linear-gradient(135deg, #3b82f6, #2563eb);
            color: white;
            padding: 20px;
            border-radius: 10px;
        }

        .stat-box h3 {
            margin: 0;
            font-size: 22px;
        }

        .stat-box p {
            margin: 5px 0 0;
            font-size: 13px;
        }
    </style>
</head>

<body>
<form id="form1" runat="server">

    <!-- NAVBAR -->
    <div class="navbar">
        <div class="title">
            Admin Dashboard
        </div>

        <div>
            Welcome,
            <asp:Label ID="lblUserName" runat="server"></asp:Label>

            <asp:Button ID="btnLogout" runat="server" Text="Logout"
                CssClass="logout-btn" OnClick="btnLogout_Click" />
        </div>
    </div>

    <div class="layout">

        <!-- SIDEBAR -->
        <div class="sidebar">
            <h4>User Management</h4>
            <asp:HyperLink runat="server" NavigateUrl="~/admin/UsersList.aspx" Text="Users List" />
            <asp:HyperLink runat="server" NavigateUrl="~/admin/UserForm.aspx" Text="Create User" />

            <h4>Student Management</h4>
            <asp:HyperLink runat="server" NavigateUrl="~/admin/StudentsList.aspx" Text="Students List" />
            <asp:HyperLink runat="server" NavigateUrl="~/StudentForm.aspx" Text="Create Student" />
        </div>

        <!-- MAIN CONTENT -->
        <div class="main">

            <!-- STATS -->
            <div class="stats">
                <div class="stat-box">
                    <h3>120</h3>
                    <p>Total Students</p>
                </div>

                <div class="stat-box">
                    <h3>45</h3>
                    <p>Total Users</p>
                </div>

                <div class="stat-box">
                    <h3>12</h3>
                    <p>Active Exams</p>
                </div>
            </div>

            <!-- WELCOME -->
            <div class="card">
                <h2>Welcome</h2>
                <p>You are successfully logged in. Use the sidebar to manage users and students.</p>
            </div>

            <!-- CHART -->
            <div class="card">
                <h3>Users Growth</h3>
                <canvas id="myChart" height="100"></canvas>
            </div>



        </div>
    </div>

</form>

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