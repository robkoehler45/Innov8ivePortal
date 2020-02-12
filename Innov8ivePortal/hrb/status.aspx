<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="status.aspx.cs" Inherits="Innov8ivePortal.hrb.status" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>HRB Demo - Status</title>
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
            <h1 runat="server" id="clientStatus">Transaction is complete</h1>
        </div>
        <div class="text-center space">
            <asp:Button ID="pdf" class="btn" runat="server" Text="View Doc" OnClick="pdf_Click" />
        </div>
        <div class="text-center space">
            <asp:Button ID="formdata" class="btn" runat="server" Text="View Form Data" OnClick="formdata_Click" />
        </div>
        <div class="text-center space">
            <asp:Button ID="restart" class="btn" runat="server" Text="Start Over" OnClick="restart_Click" />
        </div>
    </form>
</body>
</html>
