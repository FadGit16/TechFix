<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductWebForm.aspx.cs" Inherits="AdminApplication.ProductWebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Product Form</title>
    <style>
        /* Container for the form */
div {
    max-width: 900px;
    margin: 0 auto;
    padding: 20px;
    background-color: #f9f9f9;
    border: 1px solid #ddd;
    border-radius: 8px;
    box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
    font-family: Arial, sans-serif;
}

/* Heading Style */
h2 {
    text-align: center;
    color: #333;
    margin-bottom: 20px;
}

/* Table and form element styling */
table {
    width: 100%;
    border-collapse: collapse;
    margin-bottom: 20px;
}

table td {
    padding: 10px;
    vertical-align: middle;
}

table td h3 {
    font-size: 16px;
    color: #555;
    margin: 0;
}

asp\:TextBox, 
asp\:DropDownList {
    width: 100%;
    padding: 8px;
    border: 1px solid #ccc;
    border-radius: 4px;
    box-sizing: border-box;
    font-size: 14px;
}

/* Button Style */
.btn {
    display: inline-block;
    margin: 10px 0;
    padding: 10px 20px;
    font-size: 16px;
    background-color: #28a745;
    color: white;
    border: none;
    border-radius: 4px;
    cursor: pointer;
    transition: background-color 0.3s ease;
    text-align: center;
    text-decoration: none;
}

.btn:hover {
    background-color: #218838;
}

/* GridView Table Style */
.grid-view {
    width: 100%;
    border-collapse: collapse;
    margin-bottom: 20px;
}

.grid-view th, 
.grid-view td {
    padding: 12px;
    text-align: left;
    border-bottom: 1px solid #dee2e6;
    text-align: center;
}

.grid-view th {
    background-color: #28a745;
    color: white;
    font-weight: bold;
}

.grid-view tr:hover {
    background-color: #f1f1f1;
}

/* Search Section Style */
div > asp\:TextBox {
    padding: 8px;
    font-size: 14px;
    border: 1px solid #ccc;
    border-radius: 4px;
    margin-right: 10px;
}

div > asp\:Button {
    padding: 10px 20px;
    background-color: #007bff;
    color: white;
    border: none;
    border-radius: 4px;
    cursor: pointer;
}

div > asp\:Button:hover {
    background-color: #0056b3;
}

/* Responsiveness */
@media screen and (max-width: 768px) {
    div {
        padding: 15px;
    }

    table td {
        padding: 8px;
    }

    .btn {
        font-size: 14px;
        padding: 8px 16px;
    }

    .grid-view th, .grid-view td {
        font-size: 14px;
        padding: 10px;
    }
}

    </style>
   
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />
            <h2>Product Form</h2>
            <table>
                <tr>
                    <td><h3>Product ID</h3></td>
                    <td><asp:TextBox ID="txtProductId" runat="server"></asp:TextBox></td>
                </tr>

                <tr>
                    <td><h3>Product Name</h3></td>
                    <td><asp:TextBox ID="txtProductName" runat="server"></asp:TextBox></td>
                </tr>

                <tr>
                    <td><h3>Price</h3></td>
                    <td><asp:TextBox ID="txtPrice" runat="server"></asp:TextBox></td>
                </tr>

                <tr>
                    <td><h3>Category ID</h3></td>
                    <td><asp:DropDownList ID="dlCategory" runat="server"></asp:DropDownList></td>
                </tr>

                <tr>
                    <td><h3>Quantity</h3></td>
                    <td><asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox></td>
                </tr>

                <tr>
                    <td><asp:Button ID="btnInsertProduct" runat="server" Text="Insert Product" OnClick="btnInsertProduct_Click" CssClass="btn"/></td>
                </tr>

                <asp:Label ID="lblText" runat="server" Text="Label"></asp:Label>

            </table>

            <div>
                <asp:Button ID="btnUpdate" runat="server" Text="Update Product" OnClick="btnUpdate_Click" CssClass="btn"/>
            </div>

            <div>
                <asp:Button ID="btnView" runat="server" Text="View Product" OnClick="btnView_Click" CssClass="btn"/>
            </div>

            <asp:GridView ID="gvAllProducts" runat="server" AutoGenerateColumns="False" OnRowCommand="gvAllProducts_RowCommand" CssClass="grid-view">
                <Columns>
                    <asp:BoundField DataField="ProductId" HeaderText="Product ID"/>
                    <asp:BoundField DataField="ProductName" HeaderText="Product Name"/>
                    <asp:BoundField DataField="Price" HeaderText="Price"/>
                    <asp:BoundField DataField="CategoryId" HeaderText="Category ID"/>
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity"/>
                    <asp:ButtonField CommandName="Delete" Text="Delete" ButtonType="Button"/>
                </Columns>
            </asp:GridView>

            <div>
                <asp:TextBox ID="txtSearch" runat="server" placeholder="Search By Product ID..." Width="440px"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" Height="39px" Width="107px" />
            </div>

            <asp:GridView ID="gvProducts" runat="server" AutoGenerateColumns="False" OnRowCommand="gvProducts_RowCommand" CssClass="grid-view">
                <Columns>
                    <asp:BoundField DataField="ProductId" HeaderText="Product ID"/>
                    <asp:BoundField DataField="ProductName" HeaderText="Product Name"/>
                    <asp:BoundField DataField="Price" HeaderText="Price"/>
                    <asp:BoundField DataField="CategoryId" HeaderText="Category ID"/>
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity"/>
                    <asp:ButtonField CommandName="Delete" Text="Delete" ButtonType="Button"/>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
