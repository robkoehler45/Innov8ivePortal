<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="013.aspx.cs" Inherits="Innov8ivePortal.uscc._013" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Receipt Generation</title>
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
            <asp:ImageButton ID="image013" runat="server" ImageUrl="https://innov8ive.app/images/uscc/image013.png" CssClass="img-responsive" AlternateText="Receipt Generation" OnClick="image013_Click" />
        </div>
        <div class="text-center">
            <asp:Button ID="restart" runat="server" Text="Restart" CssClass="btn pbutton" OnClick="restart_Click" />
        </div>
    </form>
</body>
</html>
