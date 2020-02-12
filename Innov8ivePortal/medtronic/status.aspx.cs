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
    public partial class status : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void checkStatus_Click(object sender, EventArgs e)
        {
            string envId = Request.QueryString["eid"];
            
            var config = new Configuration(new ApiClient("https://demo.docusign.net/restapi"));
            string dsAuthHeader = "<DocuSignCredentials><Username>senderrob+medtronic@outlook.com</Username><Password>docusign</Password><IntegratorKey>a4eb3887-b65d-4bfe-916c-b69345e66425</IntegratorKey></DocuSignCredentials>";
            config.AddDefaultHeader("X-DocuSign-Authentication", dsAuthHeader);

            EnvelopesApi envelopesApi = new EnvelopesApi(config);
            Recipients recips = envelopesApi.ListRecipients("eacfbb5c-34f3-4458-814a-a86f8d3078bd", envId);

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
            Response.Write(string.Format("<script>window.open('{0}','_blank');</script>", "pdf.aspx?eid=" + envId));
        }

        protected void formData_Click(object sender, EventArgs e)
        {
            string envId = Request.QueryString["eid"]; 
            Response.Write(string.Format("<script>window.open('{0}','_blank');</script>", "formdata.aspx?eid=" + envId));
        }

    }
}