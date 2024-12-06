<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignupWebForm.aspx.cs" Inherits="RegistrationForm.SignupWebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sign Up</title>
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

    .signup-box {
        background-color: #fff;
        padding: 40px;
        border-radius: 12px;
        box-shadow: 0 4px 10px rgba(0, 0, 0, 0.1);
        max-width: 400px;
        width: 100%;
        text-align: center;
        transition: transform 0.3s ease;
    }

    .signup-box:hover {
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

    .signup-button {
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

    .signup-button:hover {
        background-color: #45a049;
        transform: translateY(-2px);
    }

    .signup-button:active {
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
        <div class="signup-box">
        <h2>Sign Up</h2>
        <asp:Label ID="lblMessage" runat="server" ForeColor="Red" CssClass="error-message"></asp:Label><br /><br />

        <div class="input-group">
            <label for="txtEmail" class="input-label">Email:</label>
            <asp:TextBox ID="txtEmail" runat="server" required="true" CssClass="input-field" placeholder="Enter your email"></asp:TextBox>
        </div><br />

        <div class="input-group">
            <label for="txtPassword" class="input-label">Password:</label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" required="true" CssClass="input-field" placeholder="Enter your password"></asp:TextBox>
        </div><br />

        <div class="input-group">
            <label for="txtConfirmPassword" class="input-label">Confirm Password:</label>
            <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" required="true" CssClass="input-field" placeholder="Confirm your password"></asp:TextBox>
        </div><br />

        <asp:Button ID="btnSignUp" runat="server" Text="Sign Up" CssClass="signup-button" OnClick="btnSignUp_Click" />
    </div>
    </form>
</body>
</html>