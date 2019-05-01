using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using DocuSign.eSign.Api;
using DocuSign.eSign.Client;
using DocuSign.eSign.Model;
using Newtonsoft.Json;

namespace Innov8ivePortal.hmd
{
    public partial class signer2start : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["event"] == "signing_complete")
            {
                logo.ImageUrl = envelope.dsLogo;
                logo.Height = 100;
                header.Style.Add("background-color", envelope.dsHeaderColor);
                header.Style.Add("color", envelope.dsFontColor);
            }
            else
            {
                Response.Redirect("~/signer1catch.aspx?event=" + Request.QueryString["event"]);
            }
        }

        protected void continue_Click(object sender, EventArgs e)
        {
            Configuration.Default.DefaultHeader.Remove("X-DocuSign-Authentication");
            Configuration.Default.AddDefaultHeader("X-DocuSign-Authentication", envelope.dsAuthHeader);

            EnvelopesApi envelopesApi = new EnvelopesApi();

            RecipientViewRequest viewOptions = new RecipientViewRequest()
            {
                ReturnUrl = "https://innov8ive.app/hmd/status.aspx",
                ClientUserId = envelope.dsSigner2CID,  // must match clientUserId set in step #2!
                AuthenticationMethod = "email",
                UserName = envelope.dsSigner2Name,
                Email = envelope.dsSigner2Email
            };

            // create the recipient view (aka signing URL)
            ViewUrl recipientView = envelopesApi.CreateRecipientView(envelope.dsAccountId, envelope.dsEnvelopeId, viewOptions);

            Response.Redirect(recipientView.Url);
        }
    }
}