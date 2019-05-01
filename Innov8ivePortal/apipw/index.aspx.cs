using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Deserializers;
using RestSharp.Extensions;
using RestSharp.Serializers;
using RestSharp.Validation;

namespace Innov8ivePortal.apipw
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (dsusr.Text == "")
            {
                errorRow.Visible = false;
            }
        }

        protected void generate_Click(object sender, EventArgs e)
        {
            string usr = dsusr.Text;
            string pwd = dspwd.Text;
            string DSIK = "49cfeb67-7406-4cef-bac9-7594a8802986";
            string server = dsserver.Text;
            string holder = "";

            switch (server)
            {
                case "na1":
                    holder = "https://www.docusign.net/restapi";
                    break;

                case "na2":
                    holder = "https://na2.docusign.net/restapi";
                    break;

                case "na3":
                    holder = "https://na3.docusign.net/restapi";
                    break;

                case "eu":
                    holder = "https://eu.docusign.net/restapi";
                    break;

                case "demo":
                    holder = "https://demo.docusign.net/restapi";
                    break;

                default:
                    break;
            }

            var login = new RestClient(holder);
            var loginRequest = new RestRequest("/v2/login_information?api_password=true", Method.GET);
            loginRequest.AddHeader("content-type", "application/json");
            loginRequest.AddHeader("X-DocuSign-Authentication", "<DocuSignCredentials><Username>" + usr + "</Username><Password>" + pwd + "</Password><IntegratorKey>" + DSIK + "</IntegratorKey></DocuSignCredentials>");
            IRestResponse loginResponse = login.Execute(loginRequest);

            if (loginResponse.StatusDescription == "OK")
            {
                JObject i = JObject.Parse(loginResponse.Content);
                JToken data = i.SelectToken("apiPassword");
                apiPw.Text = data.ToString();
                errorRow.Visible = false;
            }
            else
            {
                errorRow.Visible = true;
            }
        }
    }
}