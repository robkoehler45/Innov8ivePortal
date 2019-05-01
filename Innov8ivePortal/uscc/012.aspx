﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="012.aspx.cs" Inherits="Innov8ivePortal.uscc._012" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Payment</title>
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
    <link rel="stylesheet" href="~/Content/uscc.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ImageButton ID="image012" runat="server" ImageUrl="https://innov8ive.app/images/uscc/image012.png" CssClass="img-responsive" AlternateText="Payment" OnClick="image012_Click" />
        </div>
    </form>
</body>
</html>