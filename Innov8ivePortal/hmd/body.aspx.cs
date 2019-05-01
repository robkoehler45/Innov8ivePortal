using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Innov8ivePortal.hmd
{
    public partial class body : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (StreamReader r = new StreamReader(Server.MapPath("~/json/" + envelope.dsEnvelopeId + ".json")))
            {
                string jsonText = r.ReadToEnd();
                json.InnerText = jsonText;
            }
        }
    }
}