<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="011.aspx.cs" Inherits="Innov8ivePortal.uscc._011" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Service Agreement Generation</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0 maximum-scale=1.0"/>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <!-- Bootstrap -->
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/css/bootstrap.min.css"
        rel="stylesheet">
    <link rel="stylesheet" href="~/Content/uscc.css" />
    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
    <script type="text/javascript">
        function openModal() {
            $('#myModal').modal('show');
            }
        function closeModal() {
            $('#myModal').modal('hide');
            window.location = "https://innov8ive.app/uscc/012.aspx";
        }
        function openSigning() {
            $('#myModal').on('hidden', function () {
                $('#signingModal').modal('show')
            })
        }
    </script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ImageButton ID="image011" runat="server" ImageUrl="https://innov8ive.app/images/uscc/image011.png" CssClass="img-responsive" AlternateText="Service Agreement Generation" OnClick="image011_Click" />
        </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
        <!-- Include all compiled plugins (below), or include individual files as needed -->
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/js/bootstrap.min.js"></script>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <!-- Modal -->
                <div class="modal fade" data-backdrop="static" id="myModal" role="dialog" aria-labelledby="Device Details" aria-hidden="true">
                    <div id="modalSize" class="modal-dialog" runat="server">
                        <div class="modal-content">
                            <div id="modalHeader" class="modal-header" runat="server">
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span></button>
                                <h3 class="modal-title modalText" id="myModalLabel" runat="server">Location</h3>
                            </div>
                            <div class="modal-body text-center">
                                <div id="step1" runat="server" visible="true">
                                    <div class="row">
                                        <div class="col-md-4"></div>
                                        <div class="col-md-4 text-left">
                                            <asp:RadioButtonList ID="location" runat="server" class="radio">
                                                <asp:ListItem Value="instore" Selected="True" class="modalText" Text="In Store"></asp:ListItem>
                                                <asp:ListItem Value="telesales" class="modalText" Text="Telesales"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                        <div class="col-md-4"></div>
                                    </div>
                                </div>
                                <div id="step2" runat="server" visible="false">
                                    <div class="row">
                                        <h3 id="orderIdHeader" runat="server" class="modalText"></h3>
                                    </div>
                                    <div class="row">
                                        <h3 id="accessCodeHeader" runat="server" class="modalText"></h3>
                                    </div>
                                    <div class="row">
                                        <h3 id="assocAccessCodeHeader" runat="server" class="modalText"></h3>
                                    </div>
                                    <div class="row">
                                        <h5 id="helperURL" runat="server" class="modalText">2nd Device URL is <a href="https://innov8ive.app/uscc/device.aspx" target="_blank">https://innov8ive.app/uscc/device.aspx</a></h5>
                                        <asp:TextBox ID="hiddenEID" runat="server" Visible="False" ReadOnly="True"></asp:TextBox>
                                    </div>
                                    <div class="row">
                                        <h5 id="waiting" visible="false" runat="server">The Agreement is not executed yet.  Please wait.</h5>
                                        <h5 id="errorMessage" visible="false" runat="server">Customer did not sign.  Please restart the process.</h5>
                                    </div>
                                </div>
                                <div id="step3" runat="server" visible="false">
                                    <div class="row">
                                        <h3 id="successMessage" class="modalText">Customer Service Agreement sent!</h3>
                                    </div>
                                    <div class="row">
                                        <h3 id="customerCode" runat="server" class="modalText"></h3>
                                    </div>
                                </div>
                            </div>
                            <div id="modalFooter" class="modal-footer text-center" runat="server">
                                <%--<button type="button"  class="btn btn-primary">
                                    Save changes</button>--%>
                                <asp:Button ID="docusign" runat="server" CssClass="btn mybtn" Text="DocuSign" OnClick="docusign_Click" Visible="true" />
                                <asp:Button ID="continue" runat="server" CssClass="btn mybtn" Text="Continue" OnClick="continue_Click" Visible="false" />
                                <asp:Button ID="status" runat="server" CssClass="btn mybtn" Text="Check Status" OnClick="status_Click" Visible="false" />
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
