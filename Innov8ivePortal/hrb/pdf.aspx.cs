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
using System.Net;
using System.IO;

namespace Innov8ivePortal.hrb
{
    public partial class pdf : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string dsEnvelopeId = Request.QueryString["eid"].ToString();

            var config = new Configuration(new ApiClient("https://demo.docusign.net/restapi"));
            string dsAuthHeader = "<DocuSignCredentials><Username>senderrob+hrb@outlook.com</Username><Password>docusign</Password><IntegratorKey>ADMI-419a8616-2b0e-41b1-9f69-f179b841e51f</IntegratorKey></DocuSignCredentials>";
            config.AddDefaultHeader("X-DocuSign-Authentication", dsAuthHeader);

            EnvelopesApi envelopesApi2 = new EnvelopesApi(config);

            EnvelopeDocumentsResult docs = envelopesApi2.ListDocuments("c38ae2b3-ec22-42e9-8c11-e958abb95100", dsEnvelopeId);
            string docID = docs.EnvelopeDocuments[0].DocumentId;

            MemoryStream docStream = (MemoryStream)envelopesApi2.GetDocument("c38ae2b3-ec22-42e9-8c11-e958abb95100", dsEnvelopeId, "combined");
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