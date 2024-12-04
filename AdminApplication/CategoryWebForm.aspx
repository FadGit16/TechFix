<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CategoryWebForm.aspx.cs" Inherits="AdminApplication.CategoryWebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>Category Form</title>
    <style>
            .auto-style1 {
                max-width: 800px;
                margin: 0 auto;
                padding: 20px;
                background-color: #f9f9f9;
                border: 1px solid #ddd;
                border-radius: 8px;
                box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
                font-family: Arial, sans-serif;
            }

            h2 {
                text-align: center;
                color: #333;
                margin-bottom: 20px;
            }

            table {
                width: 100%;
                margin-bottom: 20px;
                border-spacing: 10px;
            }

            h3 {
                margin: 0;
                color: #666;
            }

            input[type="text"], 
            asp\:TextBox {
                width: 100%;
                padding: 10px;
                font-size: 16px;
                border: 1px solid #ccc;
                border-radius: 4px;
                box-sizing: border-box;
                background-color: #fff;
                color: #333;
                transition: border-color 0.2s ease;
            }

            input[type="text"]:focus, 
            asp\:TextBox:focus {
                border-color: #007BFF;
                outline: none;
            }

            .button {
                display: inline-block;
                padding: 10px 20px;
                font-size: 16px;
                background-color: #007BFF;
                color: white;
                border: none;
                border-radius: 4px;
                cursor: pointer;
                transition: background-color 0.3s ease;
            }

            .button:hover {
                background-color: #0056b3;
            }

            .table {
                width: 100%;
                border-collapse: collapse;
            }

            .table th, 
            .table td {
                padding: 12px;
                text-align: left;
                border-bottom: 1px solid #ddd;
                font-size: 16px;
            }

            .table tr:hover {
                background-color: #f1f1f1;
            }

            .label {
                display: block;
                margin-top: 15px;
                color: #28a745;
                font-size: 16px;
            }

            .search-section {
                text-align: center;
                margin-top: 20px;
            }

            .search-section input[type="text"], 
            .search-section asp\:TextBox {
                width: 80%;
                padding: 10px;
                font-size: 16px;
                border: 1px solid #ccc;
                border-radius: 4px;
                margin-right: 10px;
            }

            .search-section .button {
                background-color: #28a745;
            }

            .search-section .button:hover {
                background-color: #218838;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />
            <h2>Category Form</h2>
            <table>
                <tr>
                    <td><h3>Category Id</h3></td>
                    <td><asp:TextBox ID="txtCategoryId" runat="server" Height="31px" Width="447px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><h3>Category Name</h3></td>
                    <td><asp:TextBox ID="txtCategoryName" runat="server" Height="29px" Width="444px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnInsertCategory" runat="server" Text="Insert Category" CssClass="button" OnClick="btnSubmit_Click" />
                    </td>
                </tr>
                 <asp:Label ID="lblText" runat="server" CssClass="label"></asp:Label>
            </table>

                <div>
                    <asp:Button ID="btnUpdateCategory" runat="server" Text="Update Category" CssClass="button" OnClick="btnUpdateCategory_Click" />
                </div>

             <!-- View Button -->
            <div style="margin-top: 20px;">
                <asp:Button ID="btnView" runat="server" Text="View All Categories" CssClass="button" OnClick="btnView_Click" />
            </div>

                <asp:GridView ID="gvAllCategories" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="10" GridLines="None" CssClass="table" OnRowCommand="gvAllCategories_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="CategoryId" HeaderText="Category ID" />
                        <asp:BoundField DataField="CategoryName" HeaderText="Category Name" />
                        <asp:ButtonField CommandName="Delete" Text="Delete" ButtonType="Button" />
                    </Columns>
                </asp:GridView>

            <!-- Search Section -->
            <div class="search-section" style="margin-top: 20px;">
                <asp:TextBox ID="txtSearch" runat="server" Width="350px" placeholder="Search by Category ID..."></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="button" OnClick="btnSearch_Click1" />
            </div>

            <!-- GridView for displaying results -->
            <asp:GridView ID="gvCategories" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="10" GridLines="None" CssClass="table" OnRowCommand="gvCategories_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="CategoryId" HeaderText="Category ID" />
                        <asp:BoundField DataField="CategoryName" HeaderText="Category Name" />
                        <asp:ButtonField CommandName="Delete" Text="Delete" ButtonType="Button" />
                    </Columns>
            </asp:GridView>

        </div>
    </form>
</body>
</html>

