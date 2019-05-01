using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DocuSign.eSign.Api;
using DocuSign.eSign.Client;
using DocuSign.eSign.Model;
using Newtonsoft.Json;

namespace Innov8ivePortal.uscc
{
    public partial class signer2start : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["event"] != "signing_complete")
            {
                Response.Redirect("~/uscc/signer1catch.aspx?event=" + Request.QueryString["event"]);
            }
        }

        protected void continue_Click(object sender, EventArgs e)
        {
            Configuration.Default.DefaultHeader.Remove("X-DocuSign-Authentication");
            Configuration.Default.AddDefaultHeader("X-DocuSign-Authentication", "<DocuSignCredentials><Username>senderrob+uscc@outlook.com</Username><Password>docusign</Password><IntegratorKey>fdc86660-3188-4286-ae42-f73e0f221b2b</IntegratorKey></DocuSignCredentials>");

            EnvelopesApi envelopesApi = new EnvelopesApi();

            RecipientViewRequest viewOptions = new RecipientViewRequest()
            {
                ReturnUrl = "https://innov8ive.app/uscc/customerfinish.aspx",
                ClientUserId = "1",  // must match clientUserId set in step #2!
                AuthenticationMethod = "email",
                UserName = "Associate Adam",
                Email = "senderrob+uscc@outlook.com"
            };

            string dsEnvelopeId = Request.QueryString["eid"];

            // create the recipient view (aka signing URL)
            ViewUrl recipientView = envelopesApi.CreateRecipientView("3910586", dsEnvelopeId, viewOptions);

            Response.Redirect(recipientView.Url);
        }
    }
}