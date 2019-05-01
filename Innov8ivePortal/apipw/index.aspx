<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Innov8ivePortal.apipw.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>API Password Generator</title>
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
    <link rel="stylesheet" href="~/Content/mine.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <script type="text/javascript">
        function hideError {
            var ele = document.getElementById(errorRow);
            ele.style.display = "none";
        }
        function showError {
            var ele = document.getElementById(errorRow);
            ele.style.display = "block";
        }
    </script>
</head>
<body>
    <div class="jumbotron-fluid text-center">
            <h1>DocuSign API Password Generator</h1>
    </div>
    <div class="row text-center">
        <div class="col-md-3 col-sm-3 col-xs-3"></div>
        <div class="col-md-6 col-sm-6 col-xs-6">
            <p>Use this page to generate an API password that you can then enter/use in integrations like DocuSign for Salesforce, Ariba, Fieldglass, etc.  This way, your password used to connect to DocuSign will not be stored there.</p>
        </div>
        <div class="col-md-3 col-sm-3 col-xs-3"></div>
    </div>
    <form id="form1" class="form-horizontal" runat="server">
        <div class="row">
            <div class="col-md-5 col-sm-4 col-xs-3"></div>
            <div class="col-md-2 col-sm-4 col-xs-6 form-group">
                <label for="dsusr">Email:</label>
                <asp:TextBox ID="dsusr" TextMode="Email" CssClass="form-control float-right" runat="server" ToolTip="Enter Email"></asp:TextBox>
            </div>
            <div class="col-md-5 col-sm-4 col-xs-3"></div>
        </div>
        <div class="row">
            <div class="col-md-5 col-sm-4 col-xs-3"></div>
            <div class="col-md-2 col-sm-4 col-xs-6 form-group">
                <label for="dspwd">Password:</label>
                <asp:TextBox ID="dspwd" CssClass="form-control float-right" TextMode="Password" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-5 col-sm-4 col-xs-3"></div>
        </div>
        <div class="row">
            <div class="col-md-5 col-sm-4 col-xs-3"></div>
            <div class="form-group col-md-2 col-sm-4 col-xs-6">
                <label for="dsserver">Environment:</label>
                <asp:DropDownList ID="dsserver" CssClass="form-control" runat="server">
                    <asp:ListItem Text="na1" Value="na1"></asp:ListItem>
                    <asp:ListItem Text="na2" Value="na2"></asp:ListItem>
                    <asp:ListItem Text="na3" Value="na3"></asp:ListItem>
                    <asp:ListItem Text="eu" Value="eu"></asp:ListItem>
                    <asp:ListItem Text="demo" Value="demo"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-md-5 col-sm-4 col-xs-3"></div>
        </div>
        <div class="row">
            <div class="col-md-5 col-sm-4 col-xs-3"></div>
            <div class="col-md-2 col-sm-4 col-xs-6">
                <asp:Button ID="generate" runat="server" CssClass="btn-primary" Text="Generate API Password" OnClick="generate_Click" />
            </div>
            <div class="col-md-5 col-sm-4 col-xs-3"></div>
        </div>
        <div class="row" runat="server" id="errorRow">
            <div class="col-md-5 col-sm-4 col-xs-3"></div>
            <div class="col-md-2 col-sm-4 col-xs-6">
                <p class="invalid" id="errorMessage" runat="server">Invalid Username and/or Password</p>
            </div>
            <div class="col-md-5 col-sm-4 col-xs-3"></div>
        </div>
        <div class="row">
            <div class="col-md-5 col-sm-4 col-xs-3"></div>
            <div class="col-md-2 col-sm-4 col-xs-6 form-group">
                <label for="apiPw">API Password:</label>
                <asp:TextBox ID="apiPw" CssClass="form-control" runat="server" ReadOnly="True"></asp:TextBox>
            </div>
            <div class="col-md-5 col-sm-4 col-xs-3"></div>
        </div>
    </form>
    <div class="footer">
        <div class="container text-center">
            <p>This page does not store any data.</p>
        </div>
    </div>
</body>
</html>
