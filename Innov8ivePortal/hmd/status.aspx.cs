using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;
using System.Net;
using DocuSign.eSign.Api;
using DocuSign.eSign.Client;
using DocuSign.eSign.Model;
using Newtonsoft.Json;

namespace Innov8ivePortal.hmd
{
    public partial class status : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            logo.ImageUrl = envelope.dsLogo;
            logo.Height = 100;
            header.Style.Add("background-color", envelope.dsHeaderColor);
            header.Style.Add("color", envelope.dsFontColor);
        }

        protected void checkStatus_Click(object sender, EventArgs e)
        {
            Configuration.Default.DefaultHeader.Remove("X-DocuSign-Authentication");
            Configuration.Default.AddDefaultHeader("X-DocuSign-Authentication", envelope.dsAuthHeader);

            EnvelopesApi envelopesApi = new EnvelopesApi();
            Recipients recips = envelopesApi.ListRecipients(envelope.dsAccountId, envelope.dsEnvelopeId);

            signer1Nametxt.InnerText = recips.Signers[0].Name;
            signer1Boxtxt.InnerText = recips.Signers[0].Status;
            if (recips.Signers.Count == 1)
            {
                status2.Visible = false;
            }
            else
            {
                signer2Nametxt.InnerText = recips.Signers[1].Name;
                signer2Boxtxt.InnerText = recips.Signers[1].Status;
            }
        }

        protected void viewDocument_Click(object sender, EventArgs e)
        {
            Response.Write(string.Format("<script>window.open('{0}','_blank');</script>", "pdf.aspx"));
        }

        protected void formData_Click(object sender, EventArgs e)
        {
            Response.Write(string.Format("<script>window.open('{0}','_blank');</script>", "formdata.aspx"));
        }

        protected void jsonBody_Click(object sender, EventArgs e)
        {
            Response.Write(string.Format("<script>window.open('{0}','_blank');</script>", "body.aspx"));
        }
    }
}