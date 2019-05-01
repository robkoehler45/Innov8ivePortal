using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Innov8ivePortal.uscc
{
    public partial class finish : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void survey_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/uscc/survey.aspx");
        }

        protected void newCustomer_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/uscc/001.aspx");
        }

        protected void docs_Click(object sender, EventArgs e)
        {
            Response.Write(string.Format("<script>window.open('{0}','_blank');</script>", "/uscc/pdf.aspx"));
        }
    }
}