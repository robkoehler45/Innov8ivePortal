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

namespace Innov8ivePortal.hrb
{
    public partial class professionalstart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string dsEnvelopeId = Request.QueryString["eid"].ToString();

            var config = new Configuration(new ApiClient("https://demo.docusign.net/restapi"));
            string dsAuthHeader = "<DocuSignCredentials><Username>senderrob+hrb@outlook.com</Username><Password>docusign</Password><IntegratorKey>ADMI-419a8616-2b0e-41b1-9f69-f179b841e51f</IntegratorKey></DocuSignCredentials>";
            config.AddDefaultHeader("X-DocuSign-Authentication", dsAuthHeader);

            EnvelopesApi envelopesApi = new EnvelopesApi(config);
            Recipients recips = envelopesApi.ListRecipients("c38ae2b3-ec22-42e9-8c11-e958abb95100", dsEnvelopeId);

            if (recips.Signers[1].Status == "completed")
            {
                checkStatus.Visible = false;
                sign.Visible = true;
                clientStatus.InnerText = "Spouse has signed";
            }
        }

        protected void checkStatus_Click(object sender, EventArgs e)
        {
            string dsEnvelopeId = Request.QueryString["eid"].ToString();

            var config = new Configuration(new ApiClient("https://demo.docusign.net/restapi"));
            string dsAuthHeader = "<DocuSignCredentials><Username>senderrob+hrb@outlook.com</Username><Password>docusign</Password><IntegratorKey>ADMI-419a8616-2b0e-41b1-9f69-f179b841e51f</IntegratorKey></DocuSignCredentials>";
            config.AddDefaultHeader("X-DocuSign-Authentication", dsAuthHeader);

            EnvelopesApi envelopesApi = new EnvelopesApi(config);
            Recipients recips = envelopesApi.ListRecipients("c38ae2b3-ec22-42e9-8c11-e958abb95100", dsEnvelopeId);

            if (recips.Signers[1].Status == "completed")
            {
                checkStatus.Visible = false;
                sign.Visible = true;

            }
        }

        protected void sign_Click(object sender, EventArgs e)
        {
            string dsCid = Request.QueryString["cid"].ToString();
            string dsEnvelopeId = Request.QueryString["eid"].ToString();

            var config = new Configuration(new ApiClient("https://demo.docusign.net/restapi"));
            string dsAuthHeader = "<DocuSignCredentials><Username>senderrob+hrb@outlook.com</Username><Password>docusign</Password><IntegratorKey>ADMI-419a8616-2b0e-41b1-9f69-f179b841e51f</IntegratorKey></DocuSignCredentials>";
            config.AddDefaultHeader("X-DocuSign-Authentication", dsAuthHeader);

            EnvelopesApi envelopesApi = new EnvelopesApi(config);

            RecipientViewRequest viewOptions = new RecipientViewRequest()
            {
                ReturnUrl = "https://innov8ive.app/hrb/status.aspx?eid=" + dsEnvelopeId + "&cid=" + dsCid,
                ClientUserId = "3",
                AuthenticationMethod = "email",
                UserName = "Professional Pete",
                Email = "senderrob+hrb@outlook.com",
                AssertionId = "6786238974"
            };

            ViewUrl recipientView = envelopesApi.CreateRecipientView("c38ae2b3-ec22-42e9-8c11-e958abb95100", dsEnvelopeId, viewOptions);

            Response.Redirect(recipientView.Url);
        }
    }
}