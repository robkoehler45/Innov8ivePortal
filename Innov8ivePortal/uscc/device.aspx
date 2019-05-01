<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="device.aspx.cs" Inherits="Innov8ivePortal.uscc.device" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Customer Signature</title>
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
            <div class="jumbotron">
                <asp:Image class="img-responsive logo" ID="Image1" runat="server" src="https://www.uscellular.com/uscellular/images/home/logo-usc-transparent.png" />
                <h2>Enter Order Details</h2>
            </div>
            <div class="form-horizontal">
                <div class="form-group">
                    <div class="col-sm-3 col-xs-3"></div>
                    <label class="control-label col-sm-3 col-xs-3 deviceLabel" for="txtOrderId">Order ID:</label>
                    <div id="orderIdDiv" class="col-sm-2 col-xs-4" runat="server">
                        <asp:TextBox ID="txtOrderId" runat="server" class="form-control" required="true"></asp:TextBox>
                    </div>
                    <div class="col-sm-4 col-xs-2"></div>
                </div>
                <div class="form-group">
                    <div class="col-sm-3 col-xs-3"></div>
                    <label class="control-label col-sm-3 col-xs-3 deviceLabel" for="txtAccessCode">Customer A/C:</label>
                    <div id="accessCodeDiv" class="col-sm-2 col-xs-4" runat="server">
                        <asp:TextBox ID="txtAccessCode" runat="server" class="form-control" required="true"></asp:TextBox>
                    </div>
                    <div class="col-sm-4 col-xs-2"></div>
                </div>
            </div>
            <div class="row text-center">
                <asp:Button ID="getUrl" runat="server" class="btn mybtn" Text="Sign Document(s)" OnClick="getUrl_Click" />
            </div>
        </div>
    </form>
</body>
</html>
