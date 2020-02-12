<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="formdata.aspx.cs" Inherits="Innov8ivePortal.medtronic.formdata" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Form Data</title>
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
    <link rel="stylesheet" href="~/Content/medtronic.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <script src="../Scripts/medtronic.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="pageHeader" runat="server" class="jumbotron text-center">
            <img src="https://www.medtechy.com/imager/assets/the-ticker/heros/9407/medtronic-diabetes-7x4_b5c52c0c830bb4a3ad0adcc12d12280b.jpg" style="height: 100px">
            <h3>Recipient Form Data</h3>
        </div>
        <div id="fd" class="text-center">
            <asp:Table ID="Table1" runat="server" CssClass="table-responsive table-striped">
            </asp:Table>
        </div>
    </form>
</body>
</html>
