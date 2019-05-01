<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="customerfinish.aspx.cs" Inherits="Innov8ivePortal.uscc.customerfinish" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Thank You!</title>
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
                <h3 id="thankYouHeader" runat="server">Thank you for your business!  Would you like to take a brief survey?</h3>
                <h3 id="didNotSignHeader" runat="server" visible="false">Please speak with your associate if you need assistance.</h3>
            </div>
            <div class="row buttonGroup">
                <div class="col-sm-3"></div>
                <div class="col-sm-6">
                    <div runat="server">
                        <asp:Button ID="survey" class="btn mybtn" runat="server" Text="Take Survey" OnClick="survey_Click" />
                        <asp:Button ID="reset" class="btn mybtn" runat="server" Text="Done" OnClick="reset_Click" />
                    </div>
                </div>
                <div class="col-sm-3"></div>
            </div>
        </div>
    </form>
</body>
</html>
