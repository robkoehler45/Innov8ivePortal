<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="spousestart.aspx.cs" Inherits="Innov8ivePortal.hrb.spousestart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>HRB Demo - Spouse Start</title>
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
    <link rel="stylesheet" href="~/Content/hrb.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="jumbotron">
            <h1 runat="server" id="clientStatus">Taxpayer has signed</h1>
            <h1>Please hand device to Spouse</h1>
        </div>
        <div class="text-center">
            <asp:Button ID="sign" class="btn" runat="server" Text="Sign" OnClick="sign_Click" />
        </div>
    </form>
</body>
</html>
