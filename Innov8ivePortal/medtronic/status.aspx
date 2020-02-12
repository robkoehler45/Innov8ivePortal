<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="status.aspx.cs" Inherits="Innov8ivePortal.medtronic.status" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Medtronic Demo Status Page</title>
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
        <div id="header" runat="server" class="jumbotron text-center">
            <img src="https://www.medtechy.com/imager/assets/the-ticker/heros/9407/medtronic-diabetes-7x4_b5c52c0c830bb4a3ad0adcc12d12280b.jpg" style="height: 100px">
            <h3>Envelope Status and Information</h3>
        </div>
        <div id="status1" class="row text-center">
            <div class="col-sm-3 col-md-3"></div>
            <div class="col-sm-3 col-md-3"><h5 id="signer1Nametxt" runat="server"></h5></div>
            <div class="col-sm-3 col-md-3"><h5 id="signer1Boxtxt" runat="server"></h5></div>
            <div class="col-sm-3 col-md-3"></div>
        </div>
        <div id="status2" runat="server" class="row text-center">
            <div class="col-sm-3 col-md-3"></div>
            <div class="col-sm-3 col-md-3"><h5 id="signer2Nametxt" runat="server"></h5></div>
            <div class="col-sm-3 col-md-3"><h5 id="signer2Boxtxt" runat="server"></h5></div>
            <div class="col-sm-3 col-md-3"></div>
        </div>
        <div class="text-center">
            <div class="btn-group">
                <asp:Button ID="checkStatus" class="btn-primary" runat="server" OnClick="checkStatus_Click" Text="Check Status" />
                <asp:Button ID="viewDocument" class="btn-primary" runat="server" OnClick="viewDocument_Click" Text="View Document" />
                <asp:Button ID="formData" class="btn-primary" runat="server" OnClick="formData_Click" Text="View Form Data" />
            </div>
        </div>
    </form>
</body>
</html>
