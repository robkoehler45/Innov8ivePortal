<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Innov8ivePortal.hmd.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Custom Demos</title>
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
    <link rel="stylesheet" href="~/Content/mine.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="header" class="jumbotron">
            <h1>A Custom Demo Alternative</h1>
        </div>
        <div id="body">
            <h3>Background</h3>
            <p>
                My goal for this project was to find a way to use an off-the-shelf drag/drop forms product and make it work with the DocuSign API for custom demonstrations. 
                The idea is that you can put whatever you want on your form, include some hidden data, label it all the right way, and POST it to a page to launch an API demo. 
                I hope you find some use from the result.
            </p>
            <h2>TLDR?</h2>
            <div id="walkthrough"><iframe width="560" height="315" src="https://www.youtube.com/embed/Je6lsfRVVSc"></iframe></div>
            <h3>Where Do I Start?</h3>
            <p>
                First step is to sign up for a free Jotform account if you don't already have one at <a href="https://www.jotform.com/signup" target="_blank">https://www.jotform.com/signup</a>.  The free account gives you access to 5 live forms at a time and 100 submissions a month.
                I've never needed more than the free one.  5 live forms also means you don't have to delete old demos.  You can deactivate them so you can use them again later if needed.
                Once you have your account, you're ready to start building your form.  Below, I will discuss all the things you can include and how to name them, but I'll also provide a shortcut.
                When you create a new form, there is an option to Import (from a web page).  Use <a href="https://form.jotform.us/72073985578169" target="_blank">https://form.jotform.us/72073985578169</a> as your starting template.  It will have everything you need to get going already properly on the page.
                Then you can start moving it around, adding other form elements, and branding the heck out of it.
            </p>
            <h3>Details</h3>
            <p>
                Again, for this to work, it relies on proper naming on the Jotform side so <a href="https://innov8ive.app/hmd/envelope.aspx" target="_blank">https://innov8ive.app/hmd/envelope.aspx</a> can do what it needs to do with it.  What can this demo tool do?
                <ul>
                    <li>It can handle one or two signers</li>
                    <li>Workflows can be embedded/embedded, embedded/remote, or remote/remote</li>
                    <li>Either, or both, signer can have authentication (access code, sms, phone or id check)</li>
                    <li>On branding, you can include a logo url for use on the demo pages. The header colors will be pulled from the brand associated with your template.</li>
                    <li>In a 2nd Signer Embedded scenario, there is a 2nd Signer starting page to show where you are in the process.</li>
                    <li>There is a status page to show Recipient Status.  It also has buttons to Refresh Status, open a tab with the combined pdf, and also view form data</li>
                </ul>
            </p>
            <p>
                So, what all can you put on a Jotform for POSTing to this page and what are the naming conventions? (X would be a 1 or 2 depending on which signer they are).
                <ul>
                    <li>Signer Names - signerX_username</li>
                    <li>Signer Emails - signerX_email</li>
                    <li>Signer Template Roles - signerX_role</li>
                    <li>Signer Type (embedded or remote) - signerX_type</li>
                    <li>Signer Authentication Method - signerX_auth</li>
                    <li>Signer Authentication Number (catchall for AC, SMS and Phone - Phone numbers need country code and no + sign) - signerX_number</li>
                    <li>Signer SBS - signerX_signature - AES will use the same Authentication Number Authentciation will use</li>
                    <li>tabs - labels in DocuSign should be all lowercase
                        <ul>
                            <li>Text Tabs - signerX_txt_DocuSignLabel</li>
                            <li>Drop Downs - signerX_list_DocuSignLabel - list values must match between DS and JF</li>
                            <li>Radio Buttons - signerX_rb_DocuSignGroupName - rb values must match between DS and JF</li>
                            <li>Checkboxes - signerX_cb_DocuSignLabel</li>
                        </ul>
                    </li>
                    <li>Email to make API call - usr</li>
                    <li>Password for your API call - pd</li>
                    <li>Account ID for your API call - accountnumber</li>
                    <li>Template ID for your API call - dst</li>
                    <li>Logo URL for branding - logo</li>
                    <li>Header Background Color - backgroundcolor</li>
                    <li>Header Font Color - fontcolor</li>
                    <li>URL for if Signer 1 doesn't sign - redirect</li>
                    <li>Jotform Address block to Text Fields
                        <ul>
                            <li>label for Address Block - signerX_address_DocuSignLabelPrefix</li>
                            <li>DocuSign Tab Setup
                            <ul>
                                <li>Street Address Line 1 DocuSign Label - DocuSignLabelPrefix_street1</li>
                                <li>Street Address Line 2 DocuSign Label - DocuSignLabelPrefix_street2</li>
                                <li>City DocuSign Label - DocuSignLabelPrefix_city</li>
                                <li>State DocuSign Label - DocuSignLabelPrefix_state</li>
                                <li>Zip DocuSign Label - DocuSignLabelPrefix_zip</li>
                            </ul>
                            </li>
                        </ul>
                    </li>
                </ul>
            </p>
            <h3>Some JotForm Basics to Help</h3>
            <p>
                This will not be an all emcompassing "how to use JotForm", but hopefully this will help speed you up on the places you really need to go after you import the form above.
                <ul>
                    <li>Add Form Element on the left - This is where you can drag and drop more things onto your form</li>
                    <li>Gear on the right of a selected form field will pop open the field properties.  If you're adding new things and need to name them, this is where you do it.  Go to the Advanced section, click Field Details, and enter the correct label for the field in Unique Name</li>
                    <li>If you dismiss the properties, youll see a Paint Roller button in the upper right hand corner.  That slides open the basic Form Designer.</li>
                    <li>In the Form Designer pane, if you want to get crazy, click Advanced Designer and get crazy.</li>
                    <li>If you start with my template, there's only one reason to get into Settings at the top middle, and that's to change the Page Title.  Settings-Form Settings-Show More Options-Page Title</li>
                    <li>Other things you can do in settings (if you're starting from scratch), turn on Send Post Data (it's right below Page Title) and set the Thank You Page to <a href="https://innov8ive.app/hmd/envelope.aspx">https://innov8ive.app/hmd/envelope.aspx</a></li>
                    <li>The Publish option on the top middle will give you options for how to use your form.  You can get a simple url that allows you to open it up in a browser.
                         Super easy, but you'll be displaying a JotForm url.  You can also get a quick Embed option.  This you can use in a web page anywhere to display the form (even your local machine).
                    </li>
                </ul>
            </p>
            <h2>Things To Avoid!</h2>
            <p>Do not make login pages or ask for something that can be deemed as a fishing attempt.  I've had my account suspended for a mockedup login page as well as a direct deposit form for testing this out (asking for account and routing numbers).</p>
            <h3>Questions or Problems?</h3>
            <p>Pound sand!  Just kidding.  Give me a ring or email me.</p>
            <p>Hope you enjoy, Rob</p>
            <h4>PS, don't like Jotform? Check out <a href="prodocs.aspx" target="_blank">this</a> out....</h4>
        </div>
    </form>
</body>
</html>
