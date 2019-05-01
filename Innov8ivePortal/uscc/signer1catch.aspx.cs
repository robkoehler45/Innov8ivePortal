using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Innov8ivePortal.uscc
{
    public partial class signer1catch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string signerEvent = Request.QueryString["event"];
            signerAction.InnerText = "The signer action was " + signerEvent;
        }

        protected void continue_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/uscc/device.aspx");
        }
    }
}