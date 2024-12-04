<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderDetailsWebForm.aspx.cs" Inherits="AdminApplication.OrderDetailsWebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Orders</title>
    <style>
            div {
                max-width: 900px;
                margin: 0 auto;
                padding: 20px;
                background-color: #f8f9fa;
                border: 1px solid #ddd;
                border-radius: 8px;
                box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
                font-family: Arial, sans-serif;
            }

            h2 {
                text-align: center;
                color: #343a40;
                margin-bottom: 20px;
            }

            table {
                width: 100%;
                border-collapse: collapse;
                margin-bottom: 20px;
            }

            table th, table td {
                padding: 12px;
                text-align: left;
                border-bottom: 1px solid #dee2e6;
                color: #495057;
            }

            table th {
                background-color: #28a745;
                color: white;
                font-weight: bold;
                text-align: center;
            }

            table td {
                background-color: #ffffff;
                text-align: center;
            }

            table tr:hover {
                background-color: #f1f1f1;
            }

            button, 
            asp\:Button {
                display: inline-block;
                margin: 0 auto;
                padding: 10px 20px;
                font-size: 16px;
                background-color: #007bff;
                color: white;
                border: none;
                border-radius: 4px;
                cursor: pointer;
                transition: background-color 0.3s ease;
                margin-bottom: 20px;
                display: block;
            }

            button:hover, 
            asp\:Button:hover {
                background-color: #0056b3;
            }

            asp\:Literal {
                font-size: 18px;
                font-weight: bold;
                color: #28a745;
                text-align: center;
                display: block;
                margin-top: 20px;
            }

            @media screen and (max-width: 768px) {
                div {
                    padding: 15px;
                }

                table th, table td {
                    font-size: 14px;
                    padding: 10px;
                }

                button {
                    font-size: 14px;
                    padding: 8px 16px;
                }
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />
            <h2>Orders List</h2>
            <asp:GridView ID="gvAdminOrders" runat="server" AutoGenerateColumns="False"  >
                <Columns>
                    <asp:BoundField DataField="ProductId" HeaderText="Product ID" />
                    <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                    <asp:BoundField DataField="Price" HeaderText="Price" DataFormatString="{0:C}" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                    <asp:BoundField DataField="Total" HeaderText="Total" DataFormatString="{0:C}" />
                </Columns>
            </asp:GridView>
            <asp:Button ID="btnRefresh" runat="server" Text="Refresh Orders" OnClick="btnRefresh_Click1" />
            <asp:Literal ID="ltTotalAmount" runat="server"></asp:Literal>
        </div>
    </form>
</body>
</html>
