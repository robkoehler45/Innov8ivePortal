<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="survey.aspx.cs" Inherits="Innov8ivePortal.uscc.survey" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Customer Survey</title>
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
                <h2 id="banner" runat="server">Customer Survey</h2>
            </div>
            <div id="customerSurvey" class="panel" runat="server" visible="true">
                <div id="customerSurveyHeading" runat="server" class="panel-heading">
                    <h3 class="panel-title">How likely is it that you would recommend U.S. Cellular to a friend or colleague?</h3>
                </div>
                <div class="panel-body">
                    <div class="row text-center no-gutter">
                        <div class="col-sm-1 col-xs-1"></div>
                        <div class="form-group col-sm-1 col-xs-1">
                            <label for="1" class="control-label">1</label>
                            <div>
                                <input type="radio" name="optradio" id="1"/>
                            </div>
                        </div>
                        <div class="form-group col-sm-1 col-xs-1">
                            <label for="2" class="control-label">2</label>
                            <div>
                                <input type="radio" name="optradio" id="2"/>
                            </div>
                        </div>
                        <div class="form-group col-sm-1 col-xs-1">
                            <label for="3" class="control-label">3</label>
                            <div>
                                <input type="radio" name="optradio" id="3"/>
                            </div>
                        </div>
                        <div class="form-group col-sm-1 col-xs-1">
                            <label for="4" class="control-label">4</label>
                            <div>
                                <input type="radio" name="optradio" id="4"/>
                            </div>
                        </div>
                        <div class="form-group col-sm-1 col-xs-1">
                            <label for="5" class="control-label">5</label>
                            <div>
                                <input type="radio" name="optradio" id="5"/>
                            </div>
                        </div>
                        <div class="form-group col-sm-1 col-xs-1">
                            <label for="6" class="control-label">6</label>
                            <div>
                                <input type="radio" name="optradio" id="6"/>
                            </div>
                        </div>
                        <div class="form-group col-sm-1 col-xs-1">
                            <label for="7" class="control-label">7</label>
                            <div>
                                <input type="radio" name="optradio" id="7"/>
                            </div>
                        </div>
                        <div class="form-group col-sm-1 col-xs-1">
                            <label for="8" class="control-label">8</label>
                            <div>
                                <input type="radio" name="optradio" id="8"/>
                            </div>
                        </div>
                        <div class="form-group col-sm-1 col-xs-1">
                            <label for="9" class="control-label">9</label>
                            <div>
                                <input type="radio" name="optradio" id="9"/>
                            </div>
                        </div>
                        <div class="form-group col-sm-1 col-xs-1">
                            <label for="10" class="control-label">10</label>
                            <div>
                                <input type="radio" name="optradio" id="10"/>
                            </div>
                        </div>
                        <div class="col-sm-1 col-xs-1"></div>
                    </div>
                     <div class="row buttonGroup">
                        <div class="col-sm-3"></div>
                        <div class="col-sm-6">
                            <div id="surveyButtonGroup" class="btn-group" runat="server">
                                <asp:Button ID="newCustomer" class="btn mybtn" runat="server" Text="Done" OnClick="Done" />
                            </div>
                        </div>
                        <div class="col-sm-3"></div>
                    </div>
                </div>
        </div>
    </form>
</body>
</html>
