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
using Newtonsoft.Json.Linq;
using RestSharp;

namespace Innov8ivePortal.uscc
{
    public partial class device : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void getUrl_Click(object sender, EventArgs e)
        {
            var client = new RestClient("https://demo.docusign.net/restapi");
            var request = new RestRequest("/v2/accounts/3910586/envelopes?from_date=2017-10-10&status=sent&custom_field=orderId=" + txtOrderId.Text.ToUpper(), Method.GET);
            request.AddHeader("X-DocuSign-Authentication", "<DocuSignCredentials><Username>senderrob+uscc@outlook.com</Username><Password>docusign</Password><IntegratorKey>fdc86660-3188-4286-ae42-f73e0f221b2b</IntegratorKey></DocuSignCredentials>");
            IRestResponse response = client.Execute(request);
            JObject o = JObject.Parse(response.Content);

            if ((string)o["resultSetSize"] != "0")
            {
                string dsEnvelopeId = (string)o["envelopes"][0]["envelopeId"];

                if (Configuration.Default.DefaultHeader.Count < 1)
                {
                    // we set the api client in global config when we configured the client
                    ApiClient apiClient = new ApiClient("https://demo.docusign.net/restapi");
                    Configuration.Default.ApiClient = apiClient;
                    string dsAuthHeader = "<DocuSignCredentials><Username>senderrob+uscc@outlook.com</Username><Password>docusign</Password><IntegratorKey>fdc86660-3188-4286-ae42-f73e0f221b2b</IntegratorKey></DocuSignCredentials>";
                    Configuration.Default.AddDefaultHeader("X-DocuSign-Authentication", dsAuthHeader);
                };
                Configuration.Default.DefaultHeader.Remove("X-DocuSign-Authentication");
                Configuration.Default.AddDefaultHeader("X-DocuSign-Authentication", "<DocuSignCredentials><Username>senderrob+uscc@outlook.com</Username><Password>docusign</Password><IntegratorKey>fdc86660-3188-4286-ae42-f73e0f221b2b</IntegratorKey></DocuSignCredentials>");

                EnvelopesApi envelopesApi = new EnvelopesApi();

                Recipients signers = envelopesApi.ListRecipients("3910586", dsEnvelopeId);

                RecipientViewRequest viewOptions = new RecipientViewRequest()
                {
                    ReturnUrl = "https://innov8ive.app/uscc/signer2start.aspx?eid=" + dsEnvelopeId,
                    ClientUserId = signers.Signers[0].ClientUserId,
                    AuthenticationMethod = "email",
                    UserName = signers.Signers[0].Name,
                    Email = signers.Signers[0].Email
                };

                ViewUrl recipientView = envelopesApi.CreateRecipientView("3910586", dsEnvelopeId, viewOptions);

                Response.Redirect(recipientView.Url);
            }
            else
            {
                txtOrderId.Attributes.Add("placeholder", "ID not found");
                orderIdDiv.Attributes.Add("Class", "col-sm-2 col-xs-4 has-error");
                txtOrderId.Text = "";
            }
        }
    }
}