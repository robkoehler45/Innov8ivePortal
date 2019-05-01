using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Innov8ivePortal.uscc
{
    public partial class _012 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void image012_Click(object sender, ImageClickEventArgs e)
        {
            string envId = Request.QueryString["eid"];
            Response.Redirect("~/uscc/013.aspx?eid=" + envId);
        }
    }
}