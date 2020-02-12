using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DocuSign.eSign.Client;
using DocuSign.eSign.Api;
using DocuSign.eSign.Model;
using Newtonsoft.Json;

namespace Innov8ivePortal.hrb
{
    public partial class start : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void demo_Click(object sender, EventArgs e)
        {

            // we set the api client in global config when we configured the client
            var config = new Configuration(new ApiClient("https://demo.docusign.net/restapi"));
            string dsAuthHeader = "<DocuSignCredentials><Username>senderrob+hrb@outlook.com</Username><Password>docusign</Password><IntegratorKey>ADMI-419a8616-2b0e-41b1-9f69-f179b841e51f</IntegratorKey></DocuSignCredentials>";
            config.AddDefaultHeader("X-DocuSign-Authentication", dsAuthHeader);

            AccountsApi workflowDetails = new AccountsApi(config);
            AccountIdentityVerificationResponse wfRes = workflowDetails.GetAccountIdentityVerification("c38ae2b3-ec22-42e9-8c11-e958abb95100");
            String workflowId = wfRes.IdentityVerification[0].WorkflowId;

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();
            string pcid = new string(Enumerable.Repeat(chars, 6)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            EnvelopeDefinition envDef = new EnvelopeDefinition();
            envDef.CompositeTemplates = new List<CompositeTemplate>();
            CompositeTemplate ct = new CompositeTemplate();
            ct.CompositeTemplateId = "1";

            ct.ServerTemplates = new List<ServerTemplate>();
            ServerTemplate st = new ServerTemplate();
            st.Sequence = "1";
            if (spouseLocation.SelectedValue == "inOffice")
            {
                st.TemplateId = "7edd87ee-7db5-4185-916f-b45a98915df2";
            } else
            {
                st.TemplateId = "7177ea76-eb21-41ee-95cc-14f70e0c67f9";
            }
            
            ct.ServerTemplates.Add(st);

            ct.InlineTemplates = new List<InlineTemplate>();
            InlineTemplate it = new InlineTemplate();
            it.Sequence = "1";
            it.Recipients = new Recipients();
            it.Recipients.Signers = new List<Signer>();

            Signer taxpayer = new Signer();
            taxpayer.RecipientId = "1";
            taxpayer.Name = taxpayerName.Text;
            taxpayer.Email = taxpayerEmail.Text;
            taxpayer.RoleName = "Taxpayer";
            if (taxpayerLocation.SelectedValue == "inOffice")
            {
                taxpayer.ClientUserId = pcid;
            }
            it.Recipients.Signers.Add(taxpayer);
            
            if (spouseLocation.SelectedValue == "inOffice")
            {
                Signer spouse = new Signer();
                spouse.RecipientId = "2";
                spouse.Name = "Robert Koehler";
                spouse.Email = "dssignerrob@gmail.com";
                spouse.RoleName = "Taxpayer Spouse";
                spouse.ClientUserId = pcid;
                it.Recipients.Signers.Add(spouse);
            }

            Signer professional = new Signer();
            professional.RecipientId = "3";
            professional.Name = taxName.Text;
            professional.Email = taxEmail.Text;
            professional.RoleName = "Tax Professional";
            if (taxLocation.SelectedValue == "inOffice")
            {
                professional.ClientUserId = "3";
            }
            it.Recipients.Signers.Add(professional);

            ct.InlineTemplates.Add(it);

            envDef.CompositeTemplates.Add(ct);

            envDef.EmailSubject = "Please DocuSign these tax documents from HRB";
            envDef.EmailBlurb = "Let me know if you have any questions.";
            envDef.Status = "sent";

            EnvelopesApi envelopesApi = new EnvelopesApi(config);
            EnvelopeSummary envelopeSummary = envelopesApi.CreateEnvelope("c38ae2b3-ec22-42e9-8c11-e958abb95100", envDef);
            String dsEnvelopeId = envelopeSummary.EnvelopeId;

            if (taxpayerLocation.SelectedValue == "remote")
            {
                Response.Redirect("~/status.aspx&eid=" + dsEnvelopeId);
            } else if (spouseLocation.SelectedValue == "remote")
            {
                RecipientViewRequest viewOptions = new RecipientViewRequest()
                {
                    ReturnUrl = "https://innov8ive.app/hrb/professionalstart.aspx?eid=" + dsEnvelopeId + "&cid=" +pcid,
                    ClientUserId = pcid,
                    AuthenticationMethod = "email",
                    UserName = taxpayerName.Text,
                    Email = taxpayerEmail.Text,
                    AssertionId = pcid
                };

                ViewUrl recipientView = envelopesApi.CreateRecipientView("c38ae2b3-ec22-42e9-8c11-e958abb95100", dsEnvelopeId, viewOptions);

                Response.Redirect(recipientView.Url);
            } else
            {
                RecipientViewRequest viewOptions = new RecipientViewRequest()
                {
                    ReturnUrl = "https://innov8ive.app/hrb/spousestart.aspx?eid=" + dsEnvelopeId + "&cid=" + pcid,
                    ClientUserId = pcid,
                    AuthenticationMethod = "email",
                    UserName = taxpayerName.Text,
                    Email = taxpayerEmail.Text,
                    AssertionId = pcid
                };

                ViewUrl recipientView = envelopesApi.CreateRecipientView("c38ae2b3-ec22-42e9-8c11-e958abb95100", dsEnvelopeId, viewOptions);

                Response.Redirect(recipientView.Url);
            }
        }
    }
}