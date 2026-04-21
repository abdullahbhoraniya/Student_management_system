<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin_mst.Master" AutoEventWireup="true" CodeBehind="UserDashboard.aspx.cs" Inherits="StudentManaghement.Admin.UserDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

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


</asp:Content>
