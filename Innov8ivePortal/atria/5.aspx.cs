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

namespace Innov8ivePortal.atria
{
    public partial class _5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            var config = new Configuration(new ApiClient("https://demo.docusign.net/restapi"));
            string dsAuthHeader = "<DocuSignCredentials><Username>rob@innov8ive.app</Username><Password>Corpse4life!</Password><IntegratorKey>ADMI-419a8616-2b0e-41b1-9f69-f179b841e51f</IntegratorKey></DocuSignCredentials>";
            config.AddDefaultHeader("X-DocuSign-Authentication", dsAuthHeader);

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
            st.TemplateId = "ee71d5eb-d588-49ec-af71-129237fa6844";
            ct.ServerTemplates.Add(st);

            ct.InlineTemplates = new List<InlineTemplate>();
            InlineTemplate it = new InlineTemplate();
            it.Sequence = "2";
            it.Recipients = new Recipients();
            it.Recipients.Signers = new List<Signer>();

            Signer resident = new Signer();
            resident.RecipientId = "1";
            resident.Name = "Resident Rob";
            resident.Email = "dssignerrob@gmail.com";
            resident.RoleName = "Resident";
            resident.ClientUserId = pcid;
            it.Recipients.Signers.Add(resident);

            it.Recipients.CarbonCopies = new List<CarbonCopy>();

            CarbonCopy son = new CarbonCopy();
            son.Name = "Son Seth";
            son.Email = "signerrob@outlook.com";
            son.RoutingOrder = "1";
            son.RecipientId = "2";
            it.Recipients.CarbonCopies.Add(son);

            CarbonCopy sister = new CarbonCopy();
            sister.Name = "Sister Sally";
            sister.Email = "dssistersally@mailinator.com";
            sister.RoutingOrder = "1";
            sister.RecipientId = "3";
            it.Recipients.CarbonCopies.Add(sister);

            ct.InlineTemplates.Add(it);

            envDef.EmailSubject = "Please review this paperwork for Resident Rob";
            envDef.EmailBlurb = "Please let us know if you have any questions.";

            envDef.CompositeTemplates.Add(ct);

            envDef.Status = "sent";

            EnvelopesApi envelopesApi = new EnvelopesApi(config);
            EnvelopeSummary envelopeSummary = envelopesApi.CreateEnvelope("53e87a81-3ab4-43d4-9d29-b7861bfc1e1e", envDef);
            String dsEnvelopeId = envelopeSummary.EnvelopeId;

            RecipientViewRequest viewOptions = new RecipientViewRequest()
            {
                ReturnUrl = "https://innov8ive.app/atria/status.aspx?eid=" + dsEnvelopeId + "&cid=" + pcid,
                ClientUserId = pcid,
                AuthenticationMethod = "email",
                UserName = "Resident Rob",
                Email = "dssignerrob@gmail.com",
                AssertionId = pcid
            };

            ViewUrl recipientView = envelopesApi.CreateRecipientView("53e87a81-3ab4-43d4-9d29-b7861bfc1e1e", dsEnvelopeId, viewOptions);

            Response.Redirect(recipientView.Url);
        }
    }
}