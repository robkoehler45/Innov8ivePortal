<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Innov8ivePortal.bulksend.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>API Bulk Send Login</title>
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
    <link rel="stylesheet" href="~/Content/mine.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="pageHeader" class="jumbotron" runat="server">
            <asp:Image class="img-responsive" ID="Image1" runat="server" src="https://www.docusign.com/sites/default/files/docusign-logo-standard.png"/>
            <h3>Oauth/API Bulk Send Demo Setup</h3>
        </div>
        <div id="buttonDiv">
            <asp:Button class="btn" ID="dsLogin" runat="server" Text="Login" OnClick="dsLogin_Click" />
        </div>
    </form>
</body>
</html>
