using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net;
using DocuSign.eSign.Api;
using DocuSign.eSign.Client;
using DocuSign.eSign.Model;
using Newtonsoft.Json;

namespace Innov8ivePortal.medtronic
{
    public partial class pdf : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string envId = Request.QueryString["eid"];
            
            var config = new Configuration(new ApiClient("https://demo.docusign.net/restapi"));
            string dsAuthHeader = "<DocuSignCredentials><Username>senderrob+medtronic@outlook.com</Username><Password>docusign</Password><IntegratorKey>a4eb3887-b65d-4bfe-916c-b69345e66425</IntegratorKey></DocuSignCredentials>";
            config.AddDefaultHeader("X-DocuSign-Authentication", dsAuthHeader);

            EnvelopesApi envelopesApi2 = new EnvelopesApi(config);

            EnvelopeDocumentsResult docs = envelopesApi2.ListDocuments("eacfbb5c-34f3-4458-814a-a86f8d3078bd", envId);
            string docID = docs.EnvelopeDocuments[0].DocumentId;

            MemoryStream docStream = (MemoryStream)envelopesApi2.GetDocument("eacfbb5c-34f3-4458-814a-a86f8d3078bd", envId, "combined");
            string filePath = null;
            filePath = Path.GetTempPath() + Path.GetRandomFileName() + ".pdf";
            FileStream fs = null;
            fs = new FileStream(filePath, FileMode.Create);
            docStream.Seek(0, SeekOrigin.Begin);
            docStream.CopyTo(fs);
            fs.Close();
            WebClient client = new WebClient();
            Byte[] buffer = client.DownloadData(filePath);
            if (buffer != null)
            {
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-length", buffer.Length.ToString());
                Response.BinaryWrite(buffer);
            }
        }
    }
}