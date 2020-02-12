using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Innov8ivePortal.atria
{
    public partial class status : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void pdf_Click(object sender, EventArgs e)
        {
            string dsEnvelopeId = Request.QueryString["eid"].ToString();
            Response.Write(string.Format("<script>window.open('{0}','_blank');</script>", "pdf.aspx?eid=" + dsEnvelopeId));
        }

        protected void restart_Click(object sender, EventArgs e)
        {
            Response.Redirect("start.aspx");
        }
    }
}