<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="004.aspx.cs" Inherits="Innov8ivePortal.uscc._004" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Select Plan</title>
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
            <asp:ImageButton ID="image004" runat="server" ImageUrl="https://innov8ive.app/images/uscc/image004.png" CssClass="img-responsive" AlternateText="Select Plan" OnClick="image004_Click" />
        </div>
    </form>
</body>
</html>
