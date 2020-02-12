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

namespace Innov8ivePortal.medtronic
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void send_Click(object sender, EventArgs e)
        {
            var config = new Configuration(new ApiClient("https://demo.docusign.net/restapi"));
            string dsAuthHeader = "<DocuSignCredentials><Username>senderrob+medtronic@outlook.com</Username><Password>docusign</Password><IntegratorKey>a4eb3887-b65d-4bfe-916c-b69345e66425</IntegratorKey></DocuSignCredentials>";
            config.AddDefaultHeader("X-DocuSign-Authentication", dsAuthHeader);
            
            EnvelopeDefinition envDef = new EnvelopeDefinition();
            envDef.CompositeTemplates = new List<CompositeTemplate>();

            if (cmn.Checked == true)
            {
                CompositeTemplate cmn = new CompositeTemplate();
                cmn.CompositeTemplateId = "1";

                cmn.ServerTemplates = new List<ServerTemplate>();
                ServerTemplate st = new ServerTemplate();
                st.Sequence = "1";
                st.TemplateId = "f01c731e-a2ac-4c81-bdc6-ea059fd85756";
                cmn.ServerTemplates.Add(st);

                cmn.InlineTemplates = new List<InlineTemplate>();
                InlineTemplate it = new InlineTemplate();
                it.Sequence = "1";
                it.Recipients = new Recipients();
                it.Recipients.Signers = new List<Signer>();

                Signer admin = new Signer();
                admin.RoleName = "Admin";
                admin.RecipientId = "1";
                admin.Name = adminName.Text;
                admin.Email = adminEmail.Text; 
                it.Recipients.Signers.Add(admin);

                Signer hcp = new Signer();
                hcp.RoleName = "HCP";
                hcp.RecipientId = "2";
                hcp.Name = hcpName.Text;
                hcp.Email = hcpEmail.Text;

                Text patId = new Text();
                patId.TabLabel = "patientId";
                patId.Value = patientId.Text;

                Text visNum = new Text();
                visNum.TabLabel = "visitNumber";
                visNum.Value = visitNumber.Text;

                Text pName = new Text();
                pName.TabLabel = "patientName";
                pName.Value = patientName.Text;

                Date pDOB = new Date();
                pDOB.TabLabel = "patientDOB";
                pDOB.Value = patientDOB.Text;

                Text sAddress = new Text();
                sAddress.TabLabel = "patientStreet";
                sAddress.Value = streetAddress.Text;

                Text c = new Text();
                c.TabLabel = "patientCity";
                c.Value = city.Text;

                Text s = new Text();
                s.TabLabel = "patientState";
                s.Value = state.Text;

                Zip z = new Zip();
                z.TabLabel = "patientZip";
                z.Value = zip.Text;

                Tabs hcpTabs = new Tabs
                {
                    TextTabs = new List<Text> {patId,visNum,pName,sAddress,c,s},
                    DateTabs = new List<Date> {pDOB},
                    ZipTabs = new List<Zip> {z}
                };

                admin.Tabs = hcpTabs;

                it.Recipients.Signers.Add(hcp);

                cmn.InlineTemplates.Add(it);
                envDef.CompositeTemplates.Add(cmn);
            }

            if (rx.Checked == true)
            {
                CompositeTemplate rx = new CompositeTemplate();
                rx.CompositeTemplateId = "1";

                rx.ServerTemplates = new List<ServerTemplate>();
                ServerTemplate st = new ServerTemplate();
                st.Sequence = "1";
                st.TemplateId = "114ce31d-3e2e-4438-acdc-dc33e8c3eb80";
                rx.ServerTemplates.Add(st);

                rx.InlineTemplates = new List<InlineTemplate>();
                InlineTemplate it = new InlineTemplate();
                it.Sequence = "1";
                it.Recipients = new Recipients();
                it.Recipients.Signers = new List<Signer>();

                Signer admin = new Signer();
                admin.RoleName = "Admin";
                admin.RecipientId = "1";
                admin.Name = adminName.Text;
                admin.Email = adminEmail.Text;
                it.Recipients.Signers.Add(admin);

                Signer hcp = new Signer();
                hcp.RoleName = "HCP";
                hcp.RecipientId = "2";
                hcp.Name = hcpName.Text;
                hcp.Email = hcpEmail.Text;

                Text pName = new Text();
                pName.TabLabel = "patientName";
                pName.Value = patientName.Text;

                Date pDOB = new Date();
                pDOB.TabLabel = "patientDOB";
                pDOB.Value = patientDOB.Text;

                Text a = new Text();
                a.TabLabel = "combinedAddress";
                a.Value = streetAddress.Text + ", " + city.Text + ", " + state.Text + " " + zip.Text;

                Tabs hcpTabs = new Tabs
                {
                    TextTabs = new List<Text> { pName, a },
                    DateTabs = new List<Date> { pDOB }
                };

                admin.Tabs = hcpTabs;

                it.CustomFields = new CustomFields();

                it.CustomFields.TextCustomFields = new List<TextCustomField>();

                TextCustomField ptId = new TextCustomField();
                ptId.Name = "patientId";
                ptId.Value = patientId.Text;
                ptId.Show = "true";

                TextCustomField vNum = new TextCustomField();
                vNum.Name = "visitNumber";
                vNum.Value = visitNumber.Text;
                vNum.Show = "true";

                it.CustomFields.TextCustomFields.Add(ptId);
                it.CustomFields.TextCustomFields.Add(vNum);

                it.Recipients.Signers.Add(hcp);

                rx.InlineTemplates.Add(it);
                envDef.CompositeTemplates.Add(rx);
            }

            envDef.EmailSubject = "Please DocuSign these documents";
            envDef.Status = "sent";

            EnvelopesApi envelopesApi = new EnvelopesApi(config);
            EnvelopeSummary envelopeSummary = envelopesApi.CreateEnvelope("eacfbb5c-34f3-4458-814a-a86f8d3078bd", envDef);
            String dsEnvelopeId = envelopeSummary.EnvelopeId;
            Response.Redirect("status.aspx?eid=" + dsEnvelopeId);
        }

    }
}