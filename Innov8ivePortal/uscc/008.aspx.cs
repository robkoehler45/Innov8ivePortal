using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Innov8ivePortal.uscc
{
    public partial class _008 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void image008_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/uscc/009.aspx");
        }
    }
}