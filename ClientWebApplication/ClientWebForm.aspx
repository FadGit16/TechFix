<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClientWebForm.aspx.cs" Inherits="ClientWebApplication.ClientWebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body {
            font-family: Arial, sans-serif;
        }
        .container {
            width: 70%;
            margin: 20px auto;
            padding: 20px;
            background-color: #f9f9f9;
            border-radius: 8px;
            box-shadow: 0px 4px 10px rgba(0, 0, 0, 0.1);
        }
        h2 {
            color: #333;
            text-align: center;
        }
        table {
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
        }
        table, th, td {
            border: 1px solid #ddd;
        }
        th, td {
            padding: 8px;
            text-align: left;
        }
        th {
            background-color: #f2f2f2;
        }
        input[type="text"], input[type="number"] {
            width: 100%;
            padding: 8px;
            margin: 5px 0;
            border: 1px solid #ccc;
            border-radius: 4px;
            box-sizing: border-box;
        }
        .btn {
            padding: 10px 15px;
            background-color: #4CAF50;
            color: white;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            transition: background-color 0.3s ease;
        }
        .btn:hover {
            background-color: #45a049;
        }
        .btn-danger {
            background-color: #f44336;
            color: white;
        }
        .btn-danger:hover {
            background-color: #e53935;
        }
        h3 {
            margin-top: 20px;
            color: #555;
        }
        .total-amount {
            font-size: 18px;
            font-weight: bold;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>Search for Products</h2>
            <input type="text" id="searchInput" runat="server" placeholder="Enter product name" />
            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn" OnClick="btnSearch_Click" />
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>

            <h2>Available Items</h2>
            <asp:GridView ID="gvProducts" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="ProductId" HeaderText="Product ID" />
                    <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                    <asp:BoundField DataField="Price" HeaderText="Price" DataFormatString="{0:N2}" />
                    <asp:TemplateField HeaderText="Quantity">
                        <ItemTemplate>
                            <asp:TextBox ID="txtQuantity" runat="server" Width="50px" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Button ID="btnOrder" runat="server" Text="Order" OnClick="btnOrder_Click"/>   
            <asp:Label ID="lblOrderMessage" runat="server" ForeColor="Green" Visible="False"></asp:Label>
            
            <h2>Your Orders</h2>
            <asp:Button ID="btnViewOrders" runat="server" Text="View Orders" CssClass="btn" OnClick="btnViewOrders_Click" />
            
            <asp:GridView ID="gvOrders" runat="server" AutoGenerateColumns="false" Visible="false" OnRowCommand="gvOrders_RowCommand">
                <Columns>
                    <asp:BoundField DataField="ProductId" HeaderText="Product ID" />
                    <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                    <asp:BoundField DataField="Price" HeaderText="Price" DataFormatString="{0:N2}" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                    <asp:BoundField DataField="Total" HeaderText="Total" DataFormatString="{0:N2}" />
                    <asp:ButtonField ButtonType="Button" CommandName="DeleteOrder" Text="Delete"  />
                </Columns>
            </asp:GridView>

            <asp:Label ID="lblOrderStatus" runat="server" ForeColor="Green" Visible="false"></asp:Label>
            <asp:Label ID="lblDeleteMessage" runat="server" ForeColor="Green" Visible="False"></asp:Label>
            <h3>Total Amount:</h3>
            <asp:Literal ID="ltTotalAmount" runat="server" Text=""></asp:Literal>
        </div>
    </form>
</body>
</html>
