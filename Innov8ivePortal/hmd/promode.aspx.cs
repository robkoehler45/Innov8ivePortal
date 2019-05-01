using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Drawing;
using DocuSign.eSign.Api;
using DocuSign.eSign.Client;
using DocuSign.eSign.Model;
using Newtonsoft.Json;
using System.IO;

namespace Innov8ivePortal.hmd
{
    public partial class promode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            EnvelopeDefinition envDef = new EnvelopeDefinition();
            envDef.CompositeTemplates = new List<CompositeTemplate>();
            CompositeTemplate ct = new CompositeTemplate();
            ct.CompositeTemplateId = "1";

            ct.ServerTemplates = new List<ServerTemplate>();
            ServerTemplate st = new ServerTemplate();
            st.Sequence = "1";

            ct.InlineTemplates = new List<InlineTemplate>();
            InlineTemplate it = new InlineTemplate();
            it.Sequence = "1";
            it.Recipients = new Recipients();
            it.Recipients.Signers = new List<Signer>();

            Signer Signer1 = new Signer();
            Signer1.RecipientId = "1";
            Signer1.Tabs = new Tabs();
            Signer1.Tabs.TextTabs = new List<Text>();
            Signer1.Tabs.CheckboxTabs = new List<Checkbox>();
            Signer1.Tabs.ListTabs = new List<List>();
            Signer1.Tabs.RadioGroupTabs = new List<RadioGroup>();
            Signer Signer2 = new Signer();
            Signer2.RecipientId = "2";
            Signer2.Tabs = new Tabs();
            Signer2.Tabs.TextTabs = new List<Text>();
            Signer2.Tabs.CheckboxTabs = new List<Checkbox>();
            Signer2.Tabs.ListTabs = new List<List>();
            Signer2.Tabs.RadioGroupTabs = new List<RadioGroup>();

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            foreach (string key in Request.Form)
            {
                if (key.Length > 9)
                {
                    switch (key.Substring(0, 10))
                    {
                        case "signer1_us":
                            Signer1.Name = Request[key];
                            break;

                        case "signer1_em":
                            Signer1.Email = Request[key];
                            break;

                        case "signer1_ro":
                            Signer1.RoleName = Request[key];
                            envelope.dsSigner1Role = Request[key];
                            break;

                        case "signer1_ty":
                            if (Request[key] == "embedded")
                            {
                                Random random1 = new Random();
                                envelope.dsSigner1CID = new string(Enumerable.Repeat(chars, 10)
                                    .Select(s => s[random1.Next(s.Length)]).ToArray());
                                Signer1.ClientUserId = envelope.dsSigner1CID;
                            }
                            break;

                        case "signer1_au":
                            envelope.dsSigner1AuthMethod = Request[key];
                            break;

                        case "signer1_nu":
                            envelope.dsSigner1AuthNumber = Request[key];
                            break;

                        case "signer1_si":
                            envelope.dsSigner1SP = Request[key];
                            break;

                        case "signer1_tx":
                            Text tempText1 = new Text();
                            string tempTxtLabel = key;
                            tempTxtLabel = tempTxtLabel.Substring(12);
                            tempText1.TabLabel = tempTxtLabel;
                            tempText1.Value = Request[key];
                            Signer1.Tabs.TextTabs.Add(tempText1);
                            break;

                        case "signer1_rb":
                            RadioGroup tempRG1 = new RadioGroup();
                            string tempRBLabel = key;
                            tempRBLabel = tempRBLabel.Substring(11);
                            tempRG1.GroupName = tempRBLabel;
                            tempRG1.Radios = new List<Radio>();
                            Radio tempRB1 = new Radio();
                            tempRB1.Selected = "true";
                            tempRB1.Value = Request[key];
                            tempRG1.Radios.Add(tempRB1);
                            Signer1.Tabs.RadioGroupTabs.Add(tempRG1);
                            break;

                        case "signer1_li":
                            List tempList1 = new List();
                            string tempListLabel = key;
                            tempListLabel = tempListLabel.Substring(13);
                            tempList1.TabLabel = tempListLabel;
                            tempList1.Value = Request[key];
                            Signer1.Tabs.ListTabs.Add(tempList1);
                            break;

                        case "signer1_cb":
                            Checkbox tempCB1 = new Checkbox();
                            string tempCBLabel = key;
                            tempCBLabel = tempCBLabel.Substring(11);
                            tempCB1.TabLabel = tempCBLabel;
                            tempCB1.Selected = "true";
                            Signer1.Tabs.CheckboxTabs.Add(tempCB1);
                            break;


                        case "signer2_us":
                            Signer2.Name = Request[key];
                            envelope.dsSigner2Name = Signer2.Name;
                            break;

                        case "signer2_em":
                            Signer2.Email = Request[key];
                            envelope.dsSigner2Email = Request[key];
                            break;

                        case "signer2_ro":
                            Signer2.RoleName = Request[key];
                            envelope.dsSigner2Role = Request[key];
                            break;

                        case "signer2_ty":
                            if (Request[key] == "embedded")
                            {
                                Random random2 = new Random();
                                envelope.dsSigner2CID = new string(Enumerable.Repeat(chars, 10)
                                    .Select(s => s[random2.Next(s.Length)]).ToArray());
                                Signer2.ClientUserId = envelope.dsSigner2CID;
                            }
                            break;

                        case "signer2_au":
                            envelope.dsSigner2AuthMethod = Request[key];
                            break;

                        case "signer2_nu":
                            envelope.dsSigner2AuthNumber = Request[key];
                            break;

                        case "signer2_si":
                            envelope.dsSigner2SP = Request[key];
                            break;

                        case "signer2_tx":
                            Text tempText2 = new Text();
                            string tempTxtLabel2 = key;
                            tempTxtLabel2 = tempTxtLabel2.Substring(12);
                            tempText2.TabLabel = tempTxtLabel2;
                            tempText2.Value = Request[key];
                            Signer2.Tabs.TextTabs.Add(tempText2);
                            break;

                        case "signer2_rb":
                            RadioGroup tempRG2 = new RadioGroup();
                            string tempRBLabel2 = key;
                            tempRBLabel2 = tempRBLabel2.Substring(11);
                            tempRG2.GroupName = tempRBLabel2;
                            tempRG2.Radios = new List<Radio>();
                            Radio tempRB2 = new Radio();
                            tempRB2.Selected = "true";
                            tempRB2.Value = Request[key];
                            tempRG2.Radios.Add(tempRB2);
                            Signer2.Tabs.RadioGroupTabs.Add(tempRG2);
                            break;

                        case "signer2_li":
                            List tempList2 = new List();
                            string tempListLabel2 = key;
                            tempListLabel2 = tempListLabel2.Substring(13);
                            tempList2.TabLabel = tempListLabel2;
                            tempList2.Value = Request[key];
                            Signer2.Tabs.ListTabs.Add(tempList2);
                            break;

                        case "signer2_cb":
                            Checkbox tempCB2 = new Checkbox();
                            string tempCBLabel2 = key;
                            tempCBLabel2 = tempCBLabel2.Substring(13);
                            tempCB2.TabLabel = tempCBLabel2;
                            tempCB2.Selected = "true";
                            Signer2.Tabs.CheckboxTabs.Add(tempCB2);
                            break;

                        case "accountnum":
                            envelope.dsAccountId = Request[key];
                            break;

                        default:
                            break;

                    }
                }
                else
                {
                    switch (key)
                    {
                        case "usr":
                            envelope.dsUser = Request[key];
                            break;

                        case "pd":
                            envelope.dsPassword = Request[key];
                            break;

                        case "dst":
                            envelope.dsTemplateId = Request[key];
                            break;

                        case "logo":
                            envelope.dsLogo = Request[key];
                            break;

                        default:
                            break;
                    }
                }
            }
            switch (envelope.dsSigner1AuthMethod.ToLower())
            {
                case "access code":
                    Signer1.AccessCode = envelope.dsSigner1AuthNumber;
                    break;

                case "sms":
                    Signer1.IdCheckConfigurationName = "SMS Auth $";
                    Signer1.RequireIdLookup = "true";
                    Signer1.SmsAuthentication = new RecipientSMSAuthentication();
                    Signer1.SmsAuthentication.SenderProvidedNumbers = new List<string>();
                    Signer1.SmsAuthentication.SenderProvidedNumbers.Add("+" + envelope.dsSigner1AuthNumber);
                    break;

                case "phone":
                    Signer1.IdCheckConfigurationName = "Phone Auth $";
                    Signer1.RequireIdLookup = "true";
                    Signer1.PhoneAuthentication = new RecipientPhoneAuthentication();
                    Signer1.PhoneAuthentication.SenderProvidedNumbers = new List<string>();
                    Signer1.PhoneAuthentication.SenderProvidedNumbers.Add("+" + envelope.dsSigner1AuthNumber);
                    Signer1.PhoneAuthentication.RecipMayProvideNumber = "false";
                    break;

                case "idcheck":
                    Signer1.IdCheckConfigurationName = "ID Check $";
                    Signer1.RequireIdLookup = "true";
                    break;

                default:
                    break;
            }

            switch (envelope.dsSigner1SP.ToLower())
            {
                case "ds electronic":
                    Signer1.RecipientSignatureProviders = new List<RecipientSignatureProvider>();
                    RecipientSignatureProvider rspE = new RecipientSignatureProvider();
                    rspE.SignatureProviderName = "UniversalSignaturePen_ImageOnly";
                    Signer1.RecipientSignatureProviders.Add(rspE);
                    break;

                case "ds express":
                    Signer1.RecipientSignatureProviders = new List<RecipientSignatureProvider>();
                    RecipientSignatureProvider rspD = new RecipientSignatureProvider();
                    rspD.SignatureProviderName = "UniversalSignaturePen_Default";
                    Signer1.RecipientSignatureProviders.Add(rspD);
                    break;

                case "ds aes ac":
                    Signer1.RecipientSignatureProviders = new List<RecipientSignatureProvider>();
                    RecipientSignatureProvider rspAESAC = new RecipientSignatureProvider();
                    rspAESAC.SignatureProviderName = "UniversalSignaturePen_OpenTrust_Hash_TSP";
                    rspAESAC.SignatureProviderOptions = new RecipientSignatureProviderOptions();
                    rspAESAC.SignatureProviderOptions.OneTimePassword = envelope.dsSigner1AuthNumber;
                    Signer1.RecipientSignatureProviders.Add(rspAESAC);
                    break;

                case "ds aes sms":
                    Signer1.RecipientSignatureProviders = new List<RecipientSignatureProvider>();
                    RecipientSignatureProvider rspAESSMS = new RecipientSignatureProvider();
                    rspAESSMS.SignatureProviderName = "UniversalSignaturePen_OpenTrust_Hash_TSP";
                    rspAESSMS.SignatureProviderOptions = new RecipientSignatureProviderOptions();
                    rspAESSMS.SignatureProviderOptions.Sms = "+" + envelope.dsSigner1AuthNumber;
                    Signer1.RecipientSignatureProviders.Add(rspAESSMS);
                    break;

                case "dsa":
                    Signer1.RecipientSignatureProviders = new List<RecipientSignatureProvider>();
                    RecipientSignatureProvider rspDSA = new RecipientSignatureProvider();
                    rspDSA.SignatureProviderName = "universalsignaturepen_docusignsigningappliance_tsp";
                    Signer1.RecipientSignatureProviders.Add(rspDSA);
                    break;

                case "id now":
                    Signer1.RecipientSignatureProviders = new List<RecipientSignatureProvider>();
                    RecipientSignatureProvider rspIDNOW = new RecipientSignatureProvider();
                    rspIDNOW.SignatureProviderName = "UniversalSignaturePen_IDNow_TSP";
                    Signer1.RecipientSignatureProviders.Add(rspIDNOW);
                    break;

                case "us piv":
                    Signer1.RecipientSignatureProviders = new List<RecipientSignatureProvider>();
                    RecipientSignatureProvider rspUSPIV = new RecipientSignatureProvider();
                    rspUSPIV.SignatureProviderName = "UniversalSignaturePen_PIV_Test_TSP";
                    Signer1.RecipientSignatureProviders.Add(rspUSPIV);
                    break;

                case "it agile":
                    Signer1.RecipientSignatureProviders = new List<RecipientSignatureProvider>();
                    RecipientSignatureProvider rspAgile = new RecipientSignatureProvider();
                    rspAgile.SignatureProviderName = "UniversalSignaturePen_ItAgile_TSP";
                    Signer1.RecipientSignatureProviders.Add(rspAgile);
                    break;

                case "icp":
                    Signer1.RecipientSignatureProviders = new List<RecipientSignatureProvider>();
                    RecipientSignatureProvider rspICP = new RecipientSignatureProvider();
                    rspICP.SignatureProviderName = "UniversalSignaturePen_ICP_SmartCard_TSP";
                    Signer1.RecipientSignatureProviders.Add(rspICP);
                    break;

                case "ds smart card":
                    Signer1.RecipientSignatureProviders = new List<RecipientSignatureProvider>();
                    RecipientSignatureProvider rspSMART = new RecipientSignatureProvider();
                    rspSMART.SignatureProviderName = "universalsignaturepen_ds_smartcard_tsp";
                    Signer1.RecipientSignatureProviders.Add(rspSMART);
                    break;

                default:
                    break;
            }

            switch (envelope.dsSigner2AuthMethod.ToLower())
            {
                case "access code":
                    Signer2.AccessCode = envelope.dsSigner2AuthNumber;
                    break;

                case "sms":
                    Signer2.IdCheckConfigurationName = "SMS Auth $";
                    Signer2.RequireIdLookup = "true";
                    Signer2.SmsAuthentication = new RecipientSMSAuthentication();
                    Signer2.SmsAuthentication.SenderProvidedNumbers = new List<string>();
                    Signer2.SmsAuthentication.SenderProvidedNumbers.Add("+" + envelope.dsSigner2AuthNumber);
                    break;

                case "phone":
                    Signer2.IdCheckConfigurationName = "Phone Auth $";
                    Signer2.RequireIdLookup = "true";
                    Signer2.PhoneAuthentication = new RecipientPhoneAuthentication();
                    Signer2.PhoneAuthentication.SenderProvidedNumbers = new List<string>();
                    Signer2.PhoneAuthentication.SenderProvidedNumbers.Add("+" + envelope.dsSigner2AuthNumber);
                    Signer2.PhoneAuthentication.RecipMayProvideNumber = "false";
                    break;

                case "idcheck":
                    Signer2.IdCheckConfigurationName = "ID Check $";
                    Signer2.RequireIdLookup = "true";
                    break;

                default:
                    break;
            }

            switch (envelope.dsSigner2SP.ToLower())
            {
                case "ds electronic":
                    Signer2.RecipientSignatureProviders = new List<RecipientSignatureProvider>();
                    RecipientSignatureProvider rspE = new RecipientSignatureProvider();
                    rspE.SignatureProviderName = "UniversalSignaturePen_ImageOnly";
                    Signer2.RecipientSignatureProviders.Add(rspE);
                    break;

                case "ds express":
                    Signer2.RecipientSignatureProviders = new List<RecipientSignatureProvider>();
                    RecipientSignatureProvider rspD = new RecipientSignatureProvider();
                    rspD.SignatureProviderName = "UniversalSignaturePen_Default";
                    Signer2.RecipientSignatureProviders.Add(rspD);
                    break;

                case "ds aes ac":
                    Signer2.RecipientSignatureProviders = new List<RecipientSignatureProvider>();
                    RecipientSignatureProvider rspAESAC = new RecipientSignatureProvider();
                    rspAESAC.SignatureProviderName = "UniversalSignaturePen_OpenTrust_Hash_TSP";
                    rspAESAC.SignatureProviderOptions = new RecipientSignatureProviderOptions();
                    rspAESAC.SignatureProviderOptions.OneTimePassword = envelope.dsSigner1AuthNumber;
                    Signer2.RecipientSignatureProviders.Add(rspAESAC);
                    break;

                case "ds aes sms":
                    Signer2.RecipientSignatureProviders = new List<RecipientSignatureProvider>();
                    RecipientSignatureProvider rspAESSMS = new RecipientSignatureProvider();
                    rspAESSMS.SignatureProviderName = "UniversalSignaturePen_OpenTrust_Hash_TSP";
                    rspAESSMS.SignatureProviderOptions = new RecipientSignatureProviderOptions();
                    rspAESSMS.SignatureProviderOptions.Sms = "+" + envelope.dsSigner1AuthNumber;
                    Signer2.RecipientSignatureProviders.Add(rspAESSMS);
                    break;

                case "dsa":
                    Signer2.RecipientSignatureProviders = new List<RecipientSignatureProvider>();
                    RecipientSignatureProvider rspDSA = new RecipientSignatureProvider();
                    rspDSA.SignatureProviderName = "universalsignaturepen_docusignsigningappliance_tsp";
                    Signer2.RecipientSignatureProviders.Add(rspDSA);
                    break;

                case "id now":
                    Signer2.RecipientSignatureProviders = new List<RecipientSignatureProvider>();
                    RecipientSignatureProvider rspIDNOW = new RecipientSignatureProvider();
                    rspIDNOW.SignatureProviderName = "UniversalSignaturePen_IDNow_TSP";
                    Signer2.RecipientSignatureProviders.Add(rspIDNOW);
                    break;

                case "us piv":
                    Signer2.RecipientSignatureProviders = new List<RecipientSignatureProvider>();
                    RecipientSignatureProvider rspUSPIV = new RecipientSignatureProvider();
                    rspUSPIV.SignatureProviderName = "UniversalSignaturePen_PIV_Test_TSP";
                    Signer2.RecipientSignatureProviders.Add(rspUSPIV);
                    break;

                case "it agile":
                    Signer2.RecipientSignatureProviders = new List<RecipientSignatureProvider>();
                    RecipientSignatureProvider rspAgile = new RecipientSignatureProvider();
                    rspAgile.SignatureProviderName = "UniversalSignaturePen_ItAgile_TSP";
                    Signer2.RecipientSignatureProviders.Add(rspAgile);
                    break;

                case "icp":
                    Signer2.RecipientSignatureProviders = new List<RecipientSignatureProvider>();
                    RecipientSignatureProvider rspICP = new RecipientSignatureProvider();
                    rspICP.SignatureProviderName = "UniversalSignaturePen_ICP_SmartCard_TSP";
                    Signer2.RecipientSignatureProviders.Add(rspICP);
                    break;

                case "ds smart card":
                    Signer2.RecipientSignatureProviders = new List<RecipientSignatureProvider>();
                    RecipientSignatureProvider rspSMART = new RecipientSignatureProvider();
                    rspSMART.SignatureProviderName = "universalsignaturepen_ds_smartcard_tsp";
                    Signer2.RecipientSignatureProviders.Add(rspSMART);
                    break;

                default:
                    break;
            }

            it.Recipients.Signers.Add(Signer1);
            if (Signer2.Email != "")
            {
                it.Recipients.Signers.Add(Signer2);
            }

            st.TemplateId = envelope.dsTemplateId;

            ct.ServerTemplates.Add(st);
            ct.InlineTemplates.Add(it);

            envDef.CompositeTemplates.Add(ct);

            envDef.Status = "sent";

            string json = JsonConvert.SerializeObject(envDef, Formatting.Indented);
            System.Diagnostics.Debug.Write(json);

            ApiClient apiClient = new ApiClient("https://demo.docusign.net/restapi");
            Configuration.Default.ApiClient = apiClient;
            envelope.dsAuthHeader = "{\"Username\":\"" + envelope.dsUser + "\", \"Password\":\"" + envelope.dsPassword + "\", \"IntegratorKey\":\"49cfeb67-7406-4cef-bac9-7594a8802986\"}";
            Configuration.Default.DefaultHeader.Remove("X-DocuSign-Authentication");
            Configuration.Default.AddDefaultHeader("X-DocuSign-Authentication", envelope.dsAuthHeader);

            TemplatesApi tempApi = new TemplatesApi();
            EnvelopeTemplate tempInfo = tempApi.Get(envelope.dsAccountId, envelope.dsTemplateId);
            string brandId = tempInfo.BrandId;

            AccountsApi acctApi = new AccountsApi();
            Brand brandInfo = acctApi.GetBrand(envelope.dsAccountId, brandId);
            foreach (var key in brandInfo.Colors)
            {
                if (key.Name == "headerBackground")
                {
                    envelope.dsHeaderColor = key.Value;
                }
                if (key.Name == "headerText")
                {
                    envelope.dsFontColor = key.Value;
                }
            }
            if (envelope.dsHeaderColor == "")
            {
                envelope.dsHeaderColor = "#5376B7";
            }
            if (envelope.dsFontColor == "")
            {
                envelope.dsFontColor = "#FFFFFF";
            }

            EnvelopesApi envelopesApi = new EnvelopesApi();

            EnvelopeSummary envelopeSummary = envelopesApi.CreateEnvelope(envelope.dsAccountId, envDef);
            envelope.dsEnvelopeId = envelopeSummary.EnvelopeId;

            using (StreamWriter file = File.CreateText(Server.MapPath("~/json/" + envelope.dsEnvelopeId + ".json")))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, envDef);
            }

            if (Signer1.ClientUserId != null && Signer2.ClientUserId != null)
            {
                RecipientViewRequest viewOptions = new RecipientViewRequest()
                {
                    ReturnUrl = "https://innov8ive.app/hmd/signer2start.aspx",
                    ClientUserId = envelope.dsSigner1CID,
                    AuthenticationMethod = "email",
                    UserName = Signer1.Name,
                    Email = Signer1.Email
                };

                ViewUrl recipientView = envelopesApi.CreateRecipientView(envelope.dsAccountId, envelope.dsEnvelopeId, viewOptions);

                Response.Redirect(recipientView.Url);

            }
            else if (Signer1.ClientUserId != null && Signer2.ClientUserId == null)
            {
                RecipientViewRequest viewOptions = new RecipientViewRequest()
                {
                    ReturnUrl = "https://innov8ive.app/hmd/status.aspx",
                    ClientUserId = envelope.dsSigner1CID,
                    AuthenticationMethod = "email",
                    UserName = Signer1.Name,
                    Email = Signer1.Email
                };

                ViewUrl recipientView = envelopesApi.CreateRecipientView(envelope.dsAccountId, envelope.dsEnvelopeId, viewOptions);

                Response.Redirect(recipientView.Url);

            }
            else
            {
                Response.Redirect("~/status.aspx");

            }
        }
    }
}