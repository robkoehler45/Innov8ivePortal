<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="start.aspx.cs" Inherits="Innov8ivePortal.hrb.start" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>HRB Demo</title>
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
    <link rel="stylesheet" href="~/Content/hrb.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
</head>
<body>
    <div class="jumbotron hrb">
            <h1>Customer Data for Demo</h1>
        </div>
    <form id="form1" runat="server">
        <div class="text-center">
            <h3>Who are my signers?  Where are they located?</h3>
        </div>
        <div class="col-sm-4 col-md-4">
            <div class="text-center role">
                <h4>Taxpayer Info</h4>
            </div>
            <div class="text-center">
                <div class="row form-group">
                    <div class="col-sm-1 col-md-1"></div>
                    <div class="col-sm-10 col-md-10">
                        <asp:TextBox ID="taxpayerName" class="col-sm-4 col-md-4 form-control" runat="server" placeholder="Name" Text="Taxpayer Tammy"></asp:TextBox>
                    </div>
                    <div class="col-sm-1 col-md-1"></div>
                </div>
                <div class="row form-group">
                    <div class="col-sm-1 col-md-1"></div>
                    <div class="col-sm-10 col-md-10">
                        <asp:TextBox ID="taxpayerEmail" class="col-sm-4 col-md-4 form-control" runat="server" placeholder="Email" Text="taxpayertammy@mailinator.com"></asp:TextBox>
                    </div>
                    <div class="col-sm-1 col-md-1"></div>
                </div>
                <div class="row form-group">
                    <div class="col-sm-1 col-md-1"></div>
                    <div class="col-sm-10 col-md-10">
                        <asp:DropDownList ID="taxpayerLocation" class="col-sm-4 col-md-4 form-control" runat="server">
                            <asp:ListItem Selected="True" Value="inOffice">In Office</asp:ListItem>
                            <asp:ListItem Value="remote">Remote</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-sm-1 col-md-1"></div>
                </div>
            </div>
        </div>
        <div class="col-sm-4 col-md-4">
            <div class="text-center role">
                <h4>Spouse Info</h4>
            </div>
            <div class="text-center">
                <div class="row form-group">
                    <div class="col-sm-1 col-md-1"></div>
                    <div class="col-sm-10 col-md-10">
                        <asp:TextBox ID="spouseName" class="col-sm-4 col-md-4 form-control" runat="server" placeholder="Name" Text="Robert Koehler"></asp:TextBox>
                    </div>
                    <div class="col-sm-1 col-md-1"></div>
                </div>
                <div class="row form-group">
                    <div class="col-sm-1 col-md-1"></div>
                    <div class="col-sm-10 col-md-10">
                        <asp:TextBox ID="spouseEmail" class="col-sm-4 col-md-4 form-control" runat="server" placeholder="Email" Text="dssignerrob@gmail.com"></asp:TextBox>
                    </div>
                    <div class="col-sm-1 col-md-1"></div>
                </div>
                <div class="row form-group">
                    <div class="col-sm-1 col-md-1"></div>
                    <div class="col-sm-10 col-md-10">
                        <asp:DropDownList ID="spouseLocation" class="col-sm-4 col-md-4 form-control" runat="server">
                            <asp:ListItem Value="inOffice">In Office</asp:ListItem>
                            <asp:ListItem Selected="True" Value="remote">Remote</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-sm-1 col-md-1"></div>
                </div>
            </div>
        </div>
        <div class="col-sm-4 col-md-4">
            <div class="text-center role">
                <h4>Tax Professional Info</h4>
            </div>
            <div class="text-center">
                <div class="row form-group">
                    <div class="col-sm-1 col-md-1"></div>
                    <div class="col-sm-10 col-md-10">
                        <asp:TextBox ID="taxName" class="col-sm-4 col-md-4 form-control" runat="server" placeholder="Name" Text="Professional Pete"></asp:TextBox>
                    </div>
                    <div class="col-sm-1 col-md-1"></div>
                </div>
                <div class="row form-group">
                    <div class="col-sm-1 col-md-1"></div>
                    <div class="col-sm-10 col-md-10">
                        <asp:TextBox ID="taxEmail" class="col-sm-4 col-md-4 form-control" runat="server" placeholder="Email" Text="senderrob+hrb@outlook.com"></asp:TextBox>
                    </div>
                    <div class="col-sm-1 col-md-1"></div>
                </div>
                <div class="row form-group">
                    <div class="col-sm-1 col-md-1"></div>
                    <div class="col-sm-10 col-md-10">
                        <asp:DropDownList ID="taxLocation" class="col-sm-4 col-md-4 form-control" runat="server">
                            <asp:ListItem Selected="True" Value="inOffice">In Office</asp:ListItem>
                            <asp:ListItem Value="remote">Remote</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-sm-1 col-md-1"></div>
                </div>
            </div>
        </div>
        <div class="text-center">
            <asp:Button ID="demo" runat="server" class="btn" Text="Demo" OnClick="demo_Click" />
        </div>
    </form>
</body>
</html>
