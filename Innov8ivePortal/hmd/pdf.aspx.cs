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

namespace Innov8ivePortal.hmd
{
    public partial class pdf : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ApiClient apiClient = new ApiClient("https://demo.docusign.net/restapi");
            Configuration.Default.ApiClient = apiClient;
            Configuration.Default.DefaultHeader.Remove("X-DocuSign-Authentication");
            Configuration.Default.AddDefaultHeader("X-DocuSign-Authentication", envelope.dsAuthHeader);

            EnvelopesApi envelopesApi2 = new EnvelopesApi();

            EnvelopeDocumentsResult docs = envelopesApi2.ListDocuments(envelope.dsAccountId, envelope.dsEnvelopeId);
            string docID = docs.EnvelopeDocuments[0].DocumentId;

            MemoryStream docStream = (MemoryStream)envelopesApi2.GetDocument(envelope.dsAccountId, envelope.dsEnvelopeId, docID);
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