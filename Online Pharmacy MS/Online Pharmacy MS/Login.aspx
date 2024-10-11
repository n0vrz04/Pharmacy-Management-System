<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="YourNamespace.Login" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Login</title>
    <link rel="stylesheet" href="FontAwesome.css">
    <link rel="stylesheet" href="Login.css">
</head>
<body>
    <form id="loginForm" runat="server">
        <div class="agile-field-txt">
            <label class="label" style="color:darkslategrey; font-size:24px;"><i class="fa fa-user" style="color:darkslategrey;" aria-hidden="true"></i> Username </label>
            <asp:TextBox ID="username" runat="server" placeholder="Enter UserName" required="true" style="color:darkslategrey"></asp:TextBox>
        </div>
        <div class="agile-field-txt">
            <label class="label" style="color: darkslategrey; font-size: 24px;"><i class="fa fa-unlock-alt" style="color:darkslategrey;" aria-hidden="true"></i> Password </label>
            <asp:TextBox ID="password" runat="server" TextMode="Password" placeholder="Enter Password" required="true" style="color:darkslategrey" CssClass="showPassword"></asp:TextBox>
           
            
        </div>
        <asp:Button ID="loginButton" runat="server" Text="LOGIN" OnClick="LoginButton_Click" />
    </form>

    
</body>
</html>

