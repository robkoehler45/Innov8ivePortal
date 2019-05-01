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

namespace Innov8ivePortal.uscc
{
    public partial class status : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void checkStatus_Click(object sender, EventArgs e)
        {
            string envId = Request.QueryString["eid"];
            Configuration.Default.DefaultHeader.Remove("X-DocuSign-Authentication");
            Configuration.Default.AddDefaultHeader("X-DocuSign-Authentication", "<DocuSignCredentials><Username>senderrob+uscc@outlook.com</Username><Password>docusign</Password><IntegratorKey>fdc86660-3188-4286-ae42-f73e0f221b2b</IntegratorKey></DocuSignCredentials>");

            EnvelopesApi envelopesApi = new EnvelopesApi();
            Recipients recips = envelopesApi.ListRecipients("3910586", envId);

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
            string envId = Request.QueryString["eid"];
            Response.Write(string.Format("<script>window.open('{0}','_blank');</script>", "/uscc/pdf.aspx?eid=" + envId));
        }

        protected void restart_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/uscc/001.aspx");
        }
    }
}