using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Innov8ivePortal.uscc
{
    public partial class customerfinish : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["event"] != "signing_complete")
            {
                thankYouHeader.Visible = false;
                didNotSignHeader.Visible = true;
                survey.Visible = false;
            }
            else
            {
                thankYouHeader.Visible = true;
                didNotSignHeader.Visible = false;
                survey.Visible = true;
            }
        }

        protected void survey_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/uscc/survey.aspx");
        }

        protected void reset_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/uscc/device.aspx");
        }
    }
}