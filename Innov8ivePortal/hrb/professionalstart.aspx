<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="professionalstart.aspx.cs" Inherits="Innov8ivePortal.hrb.professionalstart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>HRB Demo - Tax Pro Start</title>
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
            <h1 runat="server" id="clientStatus">Spouse has not signed</h1>
            <h1>Please hand device to tax professional</h1>
        </div>
        <div class="text-center">
            <asp:Button ID="checkStatus" class="btn" runat="server" Text="Check Status" OnClick="checkStatus_Click" />
            <asp:Button ID="sign" class="btn" runat="server" Text="Sign" Visible="False" OnClick="sign_Click" />
        </div>
    </form>
</body>
</html>
