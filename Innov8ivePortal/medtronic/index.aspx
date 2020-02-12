<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Innov8ivePortal.medtronic.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Medtronic Demo Sending Page</title>
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
    <link rel="stylesheet" href="~/Content/medtronic.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <script src="../Scripts/medtronic.js"></script>
</head>
<body>
    <div class="jumbotron text-center">
        <div>
            <img src="https://www.medtechy.com/imager/assets/the-ticker/heros/9407/medtronic-diabetes-7x4_b5c52c0c830bb4a3ad0adcc12d12280b.jpg" style="height: 100px">
        </div>
        <div>
            <button type="button" class="btn btn-link" onclick="prefill()"><h3>CMN/RX API Demo</h3></button>
        </div>
    </div>
    <form id="form1" runat="server">
        <div class="panel-primary">
            <div class="panel-heading">
                <h4>Patient Info</h4>
            </div>
            <div class="panel-body">
                <div class="form-row">
                    <div class="col-sm-6 col-md-6 form-group">
                        <label for="patientId">Patient ID:</label>
                        <asp:TextBox ID="patientId" runat="server" CssClass="form-control" type="text"></asp:TextBox>
                    </div>
                    <div class="col-sm-6 col-md-6 form-group">
                        <label for="visitNumber">Visit Number:</label>
                        <asp:TextBox ID="visitNumber" runat="server" CssClass="form-control" type="text"></asp:TextBox>
                    </div>
                </div>
                <div class="form-row">
                    <div class="col-sm-6 col-md-6 form-group">
                        <label for="patientName">Patient Name:</label>
                        <asp:TextBox ID="patientName" runat="server" CssClass="form-control" type="text"></asp:TextBox>
                    </div>
                    <div class="col-sm-6 col-md-6 form-group">
                        <label for="patientDOB">Patient DOB:</label>
                        <asp:TextBox ID="patientDOB" runat="server" CssClass="form-control" type="text"></asp:TextBox>
                    </div>
                </div>
                <div class="form-row">
                    <div class="col-sm-12 col-md-12 form-group">
                        <label for="streetAddress">Street Address:</label>
                        <asp:TextBox ID="streetAddress" runat="server" CssClass="form-control" type="text"></asp:TextBox>
                    </div>
                </div>
                <div class="form-row">
                    <div class="col-sm-6 col-md-6 form-group">
                        <label for="city">City:</label>
                        <asp:TextBox ID="city" runat="server" CssClass="form-control" type="text"></asp:TextBox>
                    </div>
                    <div class="col-sm-4 col-md-4 form-group">
                        <label for="state">State:</label>
                        <asp:TextBox ID="state" runat="server" CssClass="form-control" type="text"></asp:TextBox>
                    </div>
                    <div class="col-sm-2 col-md-2 form-group">
                        <label for="zip">Zip Code:</label>
                        <asp:TextBox ID="zip" runat="server" CssClass="form-control" type="text"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
        <div class="panel-primary">
            <div class="panel-heading">
                <h4>HCP Info</h4>
            </div>
            <div class="panel-body">
                <div id="admin" class="form-row">
                    <div class="col-sm-6 col-md-6 form-group">
                        <label for="adminName">Admin Contact Name:</label>
                        <asp:TextBox ID="adminName" runat="server" CssClass="form-control" type="text"></asp:TextBox>
                    </div>
                    <div class="col-sm-6 col-md-6 form-group">
                        <label for="adminEmail">Admin Contact Email:</label>
                        <asp:TextBox ID="adminEmail" runat="server" CssClass="form-control" type="email"></asp:TextBox>
                    </div>
                </div>
                <div id="hcp" class="form-row">
                    <div class="col-sm-6 col-md-6 form-group">
                        <label for="hcpName">HCP Name:</label>
                        <asp:TextBox ID="hcpName" runat="server" CssClass="form-control" type="text"></asp:TextBox>
                    </div>
                    <div class="col-sm-6 col-md-6 form-group">
                        <label for="hcpEmail">HCP Email:</label>
                        <asp:TextBox ID="hcpEmail" runat="server" CssClass="form-control" type="email"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
        <div class="panel-primary">
            <div class="panel-heading">
                <h4>Assigned Field Rep</h4>
            </div>
            <div class="panel-body">
                <div id="fieldRep" class="form-row">
                    <div class="col-sm-6 col-md-6 form-group">
                        <label for="repName">Field Rep Name:</label>
                        <asp:TextBox ID="repName" runat="server" CssClass="form-control" type="text"></asp:TextBox>
                    </div>
                    <div class="col-sm-6 col-md-6 form-group">
                        <label for="repEmail">Field Rep Email:</label>
                        <asp:TextBox ID="repEmail" runat="server" CssClass="form-control" type="email"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
        <div class="panel-primary">
            <div class="panel-heading">
                <h4>Documents to Send</h4>
            </div>
            <div class="panel-body">
                <div class="row">
                    <div class="col-sm-12 col-md-12">
                        <asp:CheckBox runat="server" cssClass="form-check-input" type="checkbox" value="" ID="cmn" onchange="toggle()"/>
                        <label class="form-check-label" for="cmn">
                            Include CMN
                      </label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-12 col-md-12">
                        <asp:CheckBox runat="server" cssClass="form-check-input" type="checkbox" value="" ID="rx" onchange="toggle()"/>
                        <label class="form-check-label" for="rx">
                            Include RX
                      </label>
                    </div>
                </div>
            </div>
        </div>
        <div class="form-row text-center">
            <div class="col-sm-5 col-md-5"></div>
            <div class="col-sm-2 col-md-2 text-center">
                <asp:Button ID="send" runat="server" Text="Send" CssClass="form-control btn-primary" OnClick="send_Click"/>
            </div>
            <div class="col-sm-5 col-md-5"></div>
        </div>
    </form>

</body>
</html>
