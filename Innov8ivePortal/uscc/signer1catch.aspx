<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="signer1catch.aspx.cs" Inherits="Innov8ivePortal.uscc.signer1catch" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Customer Did Not Sign</title>
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
    <link rel="stylesheet" href="~/Content/uscc.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid">
            <div id="pageHeader" class="jumbotron" runat="server">
                <asp:Image class="img-responsive logo" ID="Image1" runat="server" src="https://www.uscellular.com/uscellular/images/home/logo-usc-transparent.png"/>
                <h3>The Customer did not sign.</h3>
            </div>
            <div id="continueDiv">
                <p id="signerAction" runat="server"></p>
            </div>
            <div class="row buttonGroup">
                <div class="col-sm-3"></div>
                <div class="col-sm-6" style="height: 21px">
                    <div id="signer1CatchButtonGroup" class="btn-group" runat="server">
                        <asp:Button ID="continue" class="btn mybtn" runat="server" OnClick="continue_Click" Text="Restart" />
                    </div>
                </div>
                <div class="col-sm-3"></div>
            </div>
        </div>
    </form>
</body>
</html>
