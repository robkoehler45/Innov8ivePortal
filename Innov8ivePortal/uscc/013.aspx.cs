using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Innov8ivePortal.uscc
{
    public partial class _013 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void image013_Click(object sender, ImageClickEventArgs e)
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