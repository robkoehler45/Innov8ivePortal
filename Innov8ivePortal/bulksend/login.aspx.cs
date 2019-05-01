using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Innov8ivePortal.bulksend
{
    public partial class login : System.Web.UI.Page
    {
        public static string dsAccountId
        {
            get
            {
                object value = HttpContext.Current.Session["dsAccountId"];
                return value == null ? "" : (string)value;
            }
            set
            {
                HttpContext.Current.Session["dsAccountId"] = value;
            }
        }

        public static string dsToken
        {
            get
            {
                object value = HttpContext.Current.Session["dsToken"];
                return value == null ? "" : (string)value;
            }
            set
            {
                HttpContext.Current.Session["dsToken"] = value;
            }
        }

        public static string dsTokenType
        {
            get
            {
                object value = HttpContext.Current.Session["dsTokenType"];
                return value == null ? "" : (string)value;
            }
            set
            {
                HttpContext.Current.Session["dsTokenType"] = value;
            }
        }

        public static string dsRefreshToken
        {
            get
            {
                object value = HttpContext.Current.Session["dsRefreshToken"];
                return value == null ? "" : (string)value;
            }
            set
            {
                HttpContext.Current.Session["dsRefreshToken"] = value;
            }
        }

        public static DateTime dsTokenExpire
        {
            get
            {
                object value = HttpContext.Current.Session["dsTokenExpire"];
                return (System.DateTime)value;
            }
            set
            {
                HttpContext.Current.Session["dsTokenExpire"] = value;
            }
        }

        public static string dsAuthUrl
        {
            get
            {
                object value = HttpContext.Current.Session["dsAuthUrl"];
                return value == null ? "" : (string)value;
            }
            set
            {
                HttpContext.Current.Session["dsAuthUrl"] = value;
            }
        }

        public static string dsBaseUrl
        {
            get
            {
                object value = HttpContext.Current.Session["dsBaseUrl"];
                return value == null ? "" : (string)value;
            }
            set
            {
                HttpContext.Current.Session["dsBaseUrl"] = value;
            }
        }

        public static string dsTemplateId
        {
            get
            {
                object value = HttpContext.Current.Session["dsTemplateId"];
                return value == null ? "" : (string)value;
            }
            set
            {
                HttpContext.Current.Session["dsTemplateId"] = value;
            }
        }

        public static string dsTemplateRole
        {
            get
            {
                object value = HttpContext.Current.Session["dsTemplateRole"];
                return value == null ? "" : (string)value;
            }
            set
            {
                HttpContext.Current.Session["dsTemplateRole"] = value;
            }
        }

        public static string dsAuthString
        {
            get
            {
                object value = HttpContext.Current.Session["dsAuthString"];
                return value == null ? "" : (string)value;
            }
            set
            {
                HttpContext.Current.Session["dsAuthString"] = value;
            }
        }

        public static string dsIK
        {
            get
            {
                object value = HttpContext.Current.Session["dsIK"];
                return value == null ? "" : (string)value;
            }
            set
            {
                HttpContext.Current.Session["dsIK"] = value;
            }
        }

        public static string dsKeyAndSecret
        {
            get
            {
                object value = HttpContext.Current.Session["dsKeyAndSecret"];
                return value == null ? "" : (string)value;
            }
            set
            {
                HttpContext.Current.Session["dsKeyAndSecret"] = value;
            }
        }

        public static string dsBatchID
        {
            get
            {
                object value = HttpContext.Current.Session["dsBatchID"];
                return value == null ? "" : (string)value;
            }
            set
            {
                HttpContext.Current.Session["dsBatchID"] = value;
            }
        }

        public static string dsLogo
        {
            get
            {
                object value = HttpContext.Current.Session["dsLogo"];
                return value == null ? "" : (string)value;
            }
            set
            {
                HttpContext.Current.Session["dsLogo"] = value;
            }
        }

        public static string dsHeaderColor
        {
            get
            {
                object value = HttpContext.Current.Session["dsHeaderColor"];
                return value == null ? "" : (string)value;
            }
            set
            {
                HttpContext.Current.Session["dsHeaderColor"] = value;
            }
        }

        public static string dsFontColor
        {
            get
            {
                object value = HttpContext.Current.Session["dsFontColor"];
                return value == null ? "" : (string)value;
            }
            set
            {
                HttpContext.Current.Session["dsFontColor"] = value;
            }
        }

        public static string dsBrandId
        {
            get
            {
                object value = HttpContext.Current.Session["dsBrandId"];
                return value == null ? "" : (string)value;
            }
            set
            {
                HttpContext.Current.Session["dsBrandId"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            dsIK = "87b2564f-b35f-4044-85c6-ec52e5b01fcd";
            dsKeyAndSecret = dsIK + ":f025dfc1-beaf-47d8-815c-ae1e440a2661";
        }

        protected void dsLogin_Click(object sender, EventArgs e)
        {
            if (dsRefreshToken == "")
            {
                dsAuthUrl = "https://account-d.docusign.com";


                Response.Redirect(dsAuthUrl + "/oauth/auth?response_type=code&scope=signature&client_id=" + dsIK + "&redirect_uri=http://innov8ive.app/bulksend/callback.aspx");
            }
            else
            {
                Response.Redirect("~/accountpicker.aspx");
            }
        }
    }
}