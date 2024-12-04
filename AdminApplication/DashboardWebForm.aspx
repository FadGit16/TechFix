<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DashboardWebForm.aspx.cs" Inherits="AdminApplication.DashboardWebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Dashboard</title>
    <style>
        body {
            font-family: 'Arial', sans-serif;
            margin: 0;
            padding: 0;
            background-color: #f4f4f9;
        }

        .dashboard-container {
            max-width: 1200px;
            margin: 0 auto;
            padding: 20px;
        }

        h1 {
            text-align: center;
            margin-bottom: 40px;
            color: #333;
        }

        .dashboard-card {
            background-color: #fff;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            margin-bottom: 30px;
            text-align: center;
            transition: transform 0.3s;
        }

        .dashboard-card:hover {
            transform: translateY(-10px);
        }

        .dashboard-card h2 {
            color: #4CAF50;
            margin-bottom: 20px;
        }

        .dashboard-container .dashboard-row {
            display: flex;
            flex-wrap: wrap;
            justify-content: space-between;
        }

        .dashboard-container .dashboard-row .dashboard-card {
            flex-basis: 30%;
        }

        .dashboard-container .dashboard-row .dashboard-card a {
            display: inline-block;
            background-color: #3498db;
            color: white;
            padding: 10px 20px;
            border-radius: 5px;
            text-decoration: none;
            transition: background-color 0.3s;
        }

        .dashboard-container .dashboard-row .dashboard-card a:hover {
            background-color: #2980b9;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="dashboard-container">
            <h1>Admin Dashboard</h1>

            <div class="dashboard-row">
                <!-- Manage Categories Section -->
                <div class="dashboard-card">
                    <h2>Manage Categories</h2>
                    <p>View, Add, Edit, Delete, or Search Categories</p>
                    <a href="CategoryWebForm.aspx">Go to Manage Categories</a>
                </div>

                <!-- Manage Products Section -->
                <div class="dashboard-card">
                    <h2>Manage Products</h2>
                    <p>View, Add, Edit, Delete, or Search Products</p>
                    <a href="ProductWebForm.aspx">Go to Manage Products</a>
                </div>

                <!-- View Orders Section -->
                <div class="dashboard-card">
                    <h2>View Orders</h2>
                    <p>View and manage all customer orders</p>
                    <a href="OrderDetailsWebForm.aspx">Go to View Orders</a>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
