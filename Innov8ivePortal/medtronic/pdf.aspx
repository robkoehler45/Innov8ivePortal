<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pdf.aspx.cs" Inherits="Innov8ivePortal.medtronic.pdf" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Signed Document</title>
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
    <link rel="stylesheet" href="~/Content/medtronic.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <script src="../Scripts/medtronic.js"></script>
    <style>
        div {
            width: auto;
            height: auto;
        }#pdfFrame {
            margin-right: 5px;
            margin-left: 5px;
            width: auto;
            height: auto;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
    </form>
</body>
</html>
