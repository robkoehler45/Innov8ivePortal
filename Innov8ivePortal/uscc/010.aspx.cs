using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Innov8ivePortal.uscc
{
    public partial class _010 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void image010_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/uscc/011.aspx");
        }
    }
}