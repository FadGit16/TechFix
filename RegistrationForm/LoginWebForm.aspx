<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginWebForm.aspx.cs" Inherits="RegistrationForm.LoginWebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <style>
    body {
        font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
        background-color: #f0f2f5;
        display: flex;
        justify-content: center;
        align-items: center;
        height: 100vh;
        margin: 0;
    }

    .login-box {
        background-color: #fff;
        padding: 40px;
        border-radius: 12px;
        box-shadow: 0 4px 10px rgba(0, 0, 0, 0.1);
        max-width: 400px;
        width: 100%;
        text-align: center;
        transition: transform 0.3s ease;
    }

    .login-box:hover {
        transform: translateY(-5px);
    }

    h2 {
        color: #333;
        font-weight: 600;
        margin-bottom: 30px;
        font-size: 26px;
    }

    .input-group {
        margin-bottom: 20px;
        text-align: left;
    }

    .input-label {
        font-size: 14px;
        color: #666;
        margin-bottom: 5px;
        display: inline-block;
        font-weight: 500;
    }

    .input-field {
        width: 100%;
        padding: 12px;
        border: 1px solid #ccc;
        border-radius: 6px;
        font-size: 16px;
        outline: none;
        transition: border-color 0.3s ease, box-shadow 0.3s ease;
    }

    .input-field:focus {
        border-color: #4CAF50;
        box-shadow: 0 0 8px rgba(76, 175, 80, 0.2);
    }

   .login-button {
        background-color: #4CAF50;
        color: #fff;
        padding: 12px 20px;
        border: none;
        border-radius: 6px;
        cursor: pointer;
        font-size: 16px;
        width: 100%;
        transition: background-color 0.3s ease, transform 0.2s ease;
    }

    .login-button:hover {
        background-color: #45a049;
        transform: translateY(-2px);
    }

    .login-button:active {
        transform: translateY(0);
    }

    .error-message {
        font-size: 14px;
        color: #e74c3c;
        margin-bottom: 20px;
    }
</style>
</head>
<body>
   <form id="form1" runat="server">
    <div class="login-box">
        <h2>Login</h2>

        <div class="input-group">
            <asp:Label ID="lblEmail" runat="server" Text="Email" CssClass="input-label"></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="input-field" placeholder="Enter your email"></asp:TextBox>
        </div><br />

        <div class="input-group">
            <asp:Label ID="lblPassword" runat="server" Text="Password" CssClass="input-label"></asp:Label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="input-field" placeholder="Enter your password"></asp:TextBox>
        </div><br />

        <asp:Label ID="lblMessage" runat="server" ForeColor="Red" CssClass="error-message"></asp:Label><br /><br />
        <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="login-button" />
    </div>
</form>
</body>
</html>
