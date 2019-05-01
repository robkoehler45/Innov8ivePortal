<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="signer2start.aspx.cs" Inherits="Innov8ivePortal.uscc.signer2start" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Associate Signature</title>
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
            <div id="pageHeader" runat="server" class="jumbotron">
                <asp:Image class="img-responsive logo" ID="Image1" runat="server" src="https://www.uscellular.com/uscellular/images/home/logo-usc-transparent.png"/>
                <h3>The Customer has signed. Please pass control to the Associate. Enter access code and click below to continue.</h3>
            </div>
            <div class="form-horizontal">
                <div class="form-group">
                    <div class="col-sm-3 col-xs-3"></div>
                    <label class="control-label col-sm-3 col-xs-3 deviceLabel" for="txtOrderId">Assoc A/C:</label>
                    <div id="assocAccessCodeDiv" class="col-sm-2 col-xs-4" runat="server">
                        <asp:TextBox ID="txtAssocAC" runat="server" class="form-control" required="true"></asp:TextBox>
                    </div>
                    <div class="col-sm-4 col-xs-2"></div>
                </div>
            </div>
            <div class="row buttonGroup">
                <div class="col-sm-3"></div>
                <div class="col-sm-6">
                    <div id="signer2StartButtonGroup" class="btn-group" runat="server">
                        <asp:Button ID="continue" class="btn mybtn" runat="server" OnClick="continue_Click" Text="Continue" />
                    </div>
                </div>
                <div class="col-sm-3"></div>
            </div>
        </div>
    </form>
</body>
</html>
