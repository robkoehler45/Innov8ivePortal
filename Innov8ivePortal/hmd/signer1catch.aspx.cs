using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Innov8ivePortal.hmd
{
    public partial class signer1catch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            logo.ImageUrl = envelope.dsLogo;
            logo.Height = 100;
            header.Style.Add("background-color", envelope.dsHeaderColor);
            header.Style.Add("color", envelope.dsFontColor);
            string signerEvent = Request.QueryString["event"];
            signerAction.InnerText = "The signer action was " + signerEvent;
        }
    }
}