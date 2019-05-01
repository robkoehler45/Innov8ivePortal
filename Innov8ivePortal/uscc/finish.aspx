<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="finish.aspx.cs" Inherits="Innov8ivePortal.uscc.finish" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sale Complete</title>
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
    <link rel="stylesheet" href="~/Content/uscc.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <script type = "text/javascript">
         function SetTarget() {
             document.forms[0].target = "_blank";
         }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid">
             <div id="pageHeader" runat="server" class="jumbotron">
                <asp:Image class="img-responsive logo" ID="Image1" runat="server" src="https://www.uscellular.com/uscellular/images/home/logo-usc-transparent.png"/>
                <h3>Sale Complete!</h3>
            </div>
            <div class="row buttonGroup">
                <div class="col-sm-3"></div>
                <div class="col-sm-6">
                    <div runat="server">
                        <asp:Button ID="newCustomer" class="btn mybtn" runat="server" Text="New Customer" OnClick="newCustomer_Click" />
                        <asp:Button ID="docs" class="btn mybtn" runat="server" Text="View Documents" OnClick="docs_Click" />
                    </div>
                </div>
                <div class="col-sm-3"></div>
            </div>
        </div>
    </form>
</body>
</html>
