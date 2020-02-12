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

namespace Innov8ivePortal.hrb
{
    public partial class formdata : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string dsEnvelopeId = Request.QueryString["eid"].ToString();

            var config = new Configuration(new ApiClient("https://demo.docusign.net/restapi"));
            string dsAuthHeader = "<DocuSignCredentials><Username>senderrob+hrb@outlook.com</Username><Password>docusign</Password><IntegratorKey>ADMI-419a8616-2b0e-41b1-9f69-f179b841e51f</IntegratorKey></DocuSignCredentials>";
            config.AddDefaultHeader("X-DocuSign-Authentication", dsAuthHeader);

            EnvelopesApi envelopesApi2 = new EnvelopesApi(config);

            var apiInstance = new EnvelopesApi(config);
            EnvelopeFormData result = apiInstance.GetFormData("c38ae2b3-ec22-42e9-8c11-e958abb95100", dsEnvelopeId);

            TableRow header = new TableRow();
            TableCell cell1 = new TableCell();
            cell1.Text = "Name";
            TableCell cell2 = new TableCell();
            cell2.Text = "Original Value";
            TableCell cell3 = new TableCell();
            cell3.Text = "Signed Value";
            header.Cells.Add(cell1);
            header.Cells.Add(cell2);
            header.Cells.Add(cell3);
            Table1.Rows.Add(header);

            foreach (var data in result.RecipientFormData)
            {
                TableRow row1 = new TableRow();
                TableCell name1 = new TableCell();
                name1.Text = data.Name;
                TableCell blank1 = new TableCell();
                TableCell blank2 = new TableCell();
                row1.Cells.Add(name1);
                row1.Cells.Add(blank1);
                row1.Cells.Add(blank2);
                Table1.Rows.Add(row1);
                foreach (var fd in data.FormData)
                {
                    TableRow entry = new TableRow();
                    TableCell label = new TableCell();
                    label.Text = fd.Name;
                    TableCell oValue = new TableCell();
                    oValue.Text = fd.OriginalValue;
                    TableCell value = new TableCell();
                    value.Text = fd.Value;
                    entry.Cells.Add(label);
                    entry.Cells.Add(oValue);
                    entry.Cells.Add(value);
                    Table1.Rows.Add(entry);
                }
            }
        }
    }
}