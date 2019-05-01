<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="status.aspx.cs" Inherits="Innov8ivePortal.hmd.status" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Status</title>
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
    <link rel="stylesheet" href="~/Content/mine.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="header" runat="server" class="jumbotron">
            <asp:Image ID="logo" class="img-responsive" runat="server" ImageAlign="Middle" Height="100px"/>
            <h3>Envelope Status and Information</h3>
        </div>
        <div id="status1" class="row">
            <div class="col-sm-3 col-md-3"></div>
            <div class="col-sm-3 col-md-3"><h5 id="signer1Nametxt" runat="server"></h5></div>
            <div class="col-sm-3 col-md-3"><h5 id="signer1Boxtxt" runat="server"></h5></div>
            <div class="col-sm-3 col-md-3"></div>
        </div>
        <div id="status2" runat="server" class="row">
            <div class="col-sm-3 col-md-3"></div>
            <div class="col-sm-3 col-md-3"><h5 id="signer2Nametxt" runat="server"></h5></div>
            <div class="col-sm-3 col-md-3"><h5 id="signer2Boxtxt" runat="server"></h5></div>
            <div class="col-sm-3 col-md-3"></div>
        </div>
        <div class="text-center">
            <div class="btn-group">
                <asp:Button ID="checkStatus" class="btn" runat="server" OnClick="checkStatus_Click" Text="Check Status" />
                <asp:Button ID="viewDocument" class="btn" runat="server" OnClick="viewDocument_Click" Text="View Document" />
                <asp:Button ID="formData" class="btn" runat="server" OnClick="formData_Click" Text="View Form Data" />
                <asp:Button ID="jsonBody" class="btn" runat="server" Text="View JSON" OnClick="jsonBody_Click" />
            </div>
        </div>
    </form>
</body>
</html>
