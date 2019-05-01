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

namespace Innov8ivePortal.uscc
{
    public partial class pdf : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string envId = Request.QueryString["eid"];
            string dsAuthHeader = "<DocuSignCredentials><Username>senderrob+uscc@outlook.com</Username><Password>docusign</Password><IntegratorKey>fdc86660-3188-4286-ae42-f73e0f221b2b</IntegratorKey></DocuSignCredentials>";

            Configuration.Default.DefaultHeader.Remove("X-DocuSign-Authentication");
            Configuration.Default.AddDefaultHeader("X-DocuSign-Authentication", dsAuthHeader);

            EnvelopesApi envelopesApi2 = new EnvelopesApi();
            MemoryStream docStream = (MemoryStream)envelopesApi2.GetDocument("3910586", envId, "combined");
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