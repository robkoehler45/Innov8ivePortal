<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="formdata.aspx.cs" Inherits="Innov8ivePortal.hrb.formdata" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Collected Data</title>
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
            <h1 runat="server" id="clientStatus">Form Data</h1>
        </div>
        <div id="fd" class="text-center">
            <asp:Table ID="Table1" runat="server" CssClass="table-responsive table-striped">
            </asp:Table>
        </div>
    </form>
</body>
</html>
