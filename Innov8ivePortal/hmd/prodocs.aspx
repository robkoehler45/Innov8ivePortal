<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="prodocs.aspx.cs" Inherits="Innov8ivePortal.hmd.prodocs" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Custom Demo - Promode</title>
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
    <link rel="stylesheet" href="~/Content/mine.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <style>
        #header {
            width: 100%;
            text-align: center;
            background-color: dodgerblue;
            color: white;
            padding-top: 10px;
            padding-bottom: 10px;
            font-family: 'Trebuchet MS', 'Lucida Sans Unicode', 'Lucida Grande', 'Lucida Sans', Arial, sans-serif;
        }
        h2 {
            text-align: center;
        }
        #walkthrough {
            margin-left: auto;
            margin-right: auto;
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="header">
            <h1>Promode Instructions</h1>
        </div>
        <div id="body">
            <h3>What is Promode?</h3>
            <p>
                Exact same idea as using Jotform, only you build your form/webpage.  Think of it like this.
                You come across a page that has data entry already, or a customer page you really want to use.
                Well, let's download a copy, make some edits, and make some API calls!
            </p>
            <h2>TLDR?</h2>
            <div id="walkthrough"><iframe width="560" height="315" src="https://www.youtube.com/embed/BvP2gg6eRiw" frameborder="0" allowfullscreen></iframe></div>
            <p>
                Or, maybe you just don't like Jotform, or maybe you really like html, or maybe you have an existing powerform demo you want to use with this.
                Any of these are a good reason to use <a href="https://innov8ive.app/hmd/promode.aspx" target="_blank">https://innov8ive.app/hmd/promode.aspx</a>
            </p>
            <h3>So how do I use it?</h3>
            <p>
                Again, it's all based on naming conventions. To help get started, here is a zip <a href="https://innov8ive.app/promode.zip" target="_blank">file</a> that is the equivilent of the Jotform template as well as a css file to help make styling easier.  Make sure you save both files (html and css) to the same folder/directory.  You should be able to demo locally, or put it on the demo server and run it from there if you want to be able to go from an iPad or something.  It does use bootstrap, so it should scale decently for mobile devices.
                It includes the available options for authentication and SBS as well as models for text, dropdown, radio buttons and checkboxes.  You can simply copy what's in the template to provide more inputs.  Just make sure your IDs and Names are correct in the inputs.  I've tried to include comments inline in the files to help you along.
                Include all of these things you need, and don't forget the hidden input values.
                Hit me up if you have any questions.  
                Rob K.
            </p>
        </div>
    </form>
</body>
</html>
