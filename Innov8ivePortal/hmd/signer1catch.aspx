<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="signer1catch.aspx.cs" Inherits="Innov8ivePortal.hmd.signer1catch" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Didn't Sign?</title>
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
    <link rel="stylesheet" href="~/Content/mine.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="header" class="jumbotron" runat="server">
            <asp:Image ID="logo" class="img-responsive" runat="server" ImageAlign="Middle" Height="100px" />
            <h3>The first signer did not sign.</h3>
        </div>
        <div id="continueDiv">
            <p id="signerAction" runat="server"></p>
        </div>
    </form>
</body>
</html>
