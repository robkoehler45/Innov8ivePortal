using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Drawing;
using System.IO;
using DocuSign.eSign.Api;
using DocuSign.eSign.Client;
using DocuSign.eSign.Model;
using Newtonsoft.Json;

namespace Innov8ivePortal.hmd
{
    public partial class envelope : System.Web.UI.Page
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

        public static string dsUser
        {
            get
            {
                object value = HttpContext.Current.Session["dsUser"];
                return value == null ? "" : (string)value;
            }
            set
            {
                HttpContext.Current.Session["dsUser"] = value;
            }
        }

        public static string dsPassword
        {
            get
            {
                object value = HttpContext.Current.Session["dsPassword"];
                return value == null ? "" : (string)value;
            }
            set
            {
                HttpContext.Current.Session["dsPassword"] = value;
            }
        }

        public static string dsEnvelopeId
        {
            get
            {
                object value = HttpContext.Current.Session["dsEnvelopeId"];
                return value == null ? "" : (string)value;
            }
            set
            {
                HttpContext.Current.Session["dsEnvelopeId"] = value;
            }
        }

        public static string dsSigner1CID
        {
            get
            {
                object value = HttpContext.Current.Session["dsSigner1CID"];
                return value == null ? "" : (string)value;
            }
            set
            {
                HttpContext.Current.Session["dsSigner1CID"] = value;
            }
        }

        public static string dsSigner1Role
        {
            get
            {
                object value = HttpContext.Current.Session["dsSigner1Role"];
                return value == null ? "" : (string)value;
            }
            set
            {
                HttpContext.Current.Session["dsSigner1Role"] = value;
            }
        }

        public static string dsSigner2CID
        {
            get
            {
                object value = HttpContext.Current.Session["dsSigner2CID"];
                return value == null ? "" : (string)value;
            }
            set
            {
                HttpContext.Current.Session["dsSigner2CID"] = value;
            }
        }

        public static string dsSigner2Role
        {
            get
            {
                object value = HttpContext.Current.Session["dsSigner2Role"];
                return value == null ? "" : (string)value;
            }
            set
            {
                HttpContext.Current.Session["dsSigner2Role"] = value;
            }
        }

        public static string dsSigner2Name
        {
            get
            {
                object value = HttpContext.Current.Session["dsSigner2Name"];
                return value == null ? "" : (string)value;
            }
            set
            {
                HttpContext.Current.Session["dsSigner2Name"] = value;
            }
        }

        public static string dsSigner2Email
        {
            get
            {
                object value = HttpContext.Current.Session["dsSigner2Email"];
                return value == null ? "" : (string)value;
            }
            set
            {
                HttpContext.Current.Session["dsSigner2Email"] = value;
            }
        }

        public static string dsSigner1AuthMethod
        {
            get
            {
                object value = HttpContext.Current.Session["dsSigner1AuthMethod"];
                return value == null ? "" : (string)value;
            }
            set
            {
                HttpContext.Current.Session["dsSigner1AuthMethod"] = value;
            }
        }

        public static string dsSigner1AuthNumber
        {
            get
            {
                object value = HttpContext.Current.Session["dsSigner1AuthNumber"];
                return value == null ? "" : (string)value;
            }
            set
            {
                HttpContext.Current.Session["dsSigner1AuthNumber"] = value;
            }
        }

        public static string dsSigner2AuthMethod
        {
            get
            {
                object value = HttpContext.Current.Session["dsSigner2AuthMethod"];
                return value == null ? "" : (string)value;
            }
            set
            {
                HttpContext.Current.Session["dsSigner2AuthMethod"] = value;
            }
        }

        public static string dsSigner2AuthNumber
        {
            get
            {
                object value = HttpContext.Current.Session["dsSigner2AuthNumber"];
                return value == null ? "" : (string)value;
            }
            set
            {
                HttpContext.Current.Session["dsSigner2AuthNumber"] = value;
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

        public static string dsAuthHeader
        {
            get
            {
                object value = HttpContext.Current.Session["dsAuthHeader"];
                return value == null ? "" : (string)value;
            }
            set
            {
                HttpContext.Current.Session["dsAuthHeader"] = value;
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

        public static string dsSigner1SP
        {
            get
            {
                object value = HttpContext.Current.Session["dsSigner1SP"];
                return value == null ? "" : (string)value;
            }
            set
            {
                HttpContext.Current.Session["dsSigner1SP"] = value;
            }
        }

        public static string dsSigner2SP
        {
            get
            {
                object value = HttpContext.Current.Session["dsSigner2SP"];
                return value == null ? "" : (string)value;
            }
            set
            {
                HttpContext.Current.Session["dsSigner2SP"] = value;
            }
        }

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
                            string tempName = Request[key];
                            string[] nameArray = tempName.Split(',');
                            string dsName = nameArray[0];
                            for (int i = 1; i < nameArray.Length; i = i + 1)
                            {
                                dsName = dsName + " " + nameArray[i];
                            }
                            Signer1.Name = dsName;
                            break;

                        case "signer1_em":
                            Signer1.Email = Request[key];
                            break;

                        case "signer1_ro":
                            Signer1.RoleName = Request[key];
                            dsSigner1Role = Request[key];
                            break;

                        case "signer1_ty":
                            if (Request[key] == "embedded")
                            {
                                Random random1 = new Random();
                                dsSigner1CID = new string(Enumerable.Repeat(chars, 10)
                                    .Select(s => s[random1.Next(s.Length)]).ToArray());
                                Signer1.ClientUserId = dsSigner1CID;
                            }
                            break;

                        case "signer1_au":
                            dsSigner1AuthMethod = Request[key];
                            break;

                        case "signer1_nu":
                            dsSigner1AuthNumber = Request[key];
                            break;

                        case "signer1_si":
                            dsSigner1SP = Request[key];
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
                            tempCBLabel = tempCBLabel.Substring(11, tempCBLabel.Length - 13);
                            tempCB1.TabLabel = tempCBLabel;
                            tempCB1.Selected = "true";
                            Signer1.Tabs.CheckboxTabs.Add(tempCB1);
                            break;

                        case "signer1_ad":
                            string tempAddress = Request[key];
                            string[] addArray = tempAddress.Split(',');
                            string tempAddLabel = key;
                            tempAddLabel = tempAddLabel.Substring(16, tempAddLabel.Length - 18);
                            if (addArray[0] != "")
                            {
                                Text street1 = new Text();
                                street1.TabLabel = tempAddLabel + "_street1";
                                street1.Value = addArray[0];
                                Signer1.Tabs.TextTabs.Add(street1);
                            }
                            if (addArray[1] != "")
                            {
                                Text street2 = new Text();
                                street2.TabLabel = tempAddLabel + "_street2";
                                street2.Value = addArray[1];
                                Signer1.Tabs.TextTabs.Add(street2);
                            }
                            if (addArray[2] != "")
                            {
                                Text city = new Text();
                                city.TabLabel = tempAddLabel + "_city";
                                city.Value = addArray[2];
                                Signer1.Tabs.TextTabs.Add(city);
                            }
                            if (addArray[3] != "")
                            {
                                Text state = new Text();
                                state.TabLabel = tempAddLabel + "_state";
                                state.Value = addArray[3];
                                Signer1.Tabs.TextTabs.Add(state);
                            }
                            if (addArray[4] != "")
                            {
                                Text zip = new Text();
                                zip.TabLabel = tempAddLabel + "_zip";
                                zip.Value = addArray[4];
                                Signer1.Tabs.TextTabs.Add(zip);
                            }
                            break;



                        case "signer2_us":
                            string tempName2 = Request[key];
                            string[] nameArray2 = tempName2.Split(',');
                            string dsName2 = nameArray2[0];
                            for (int i = 1; i < nameArray2.Length; i = i + 1)
                            {
                                dsName2 = dsName2 + " " + nameArray2[i];
                            }
                            Signer2.Name = dsName2;
                            dsSigner2Name = dsName2;
                            break;

                        case "signer2_em":
                            Signer2.Email = Request[key];
                            dsSigner2Email = Request[key];
                            break;

                        case "signer2_ro":
                            Signer2.RoleName = Request[key];
                            dsSigner2Role = Request[key];
                            break;

                        case "signer2_ty":
                            if (Request[key] == "embedded")
                            {
                                Random random2 = new Random();
                                dsSigner2CID = new string(Enumerable.Repeat(chars, 10)
                                    .Select(s => s[random2.Next(s.Length)]).ToArray());
                                Signer2.ClientUserId = dsSigner2CID;
                            }
                            break;

                        case "signer2_au":
                            dsSigner2AuthMethod = Request[key];
                            break;

                        case "signer2_nu":
                            dsSigner2AuthNumber = Request[key];
                            break;

                        case "signer2_si":
                            dsSigner2SP = Request[key];
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
                            tempCBLabel2 = tempCBLabel2.Substring(11 - tempCBLabel2.Length - 13);
                            tempCB2.TabLabel = tempCBLabel2;
                            tempCB2.Selected = "true";
                            Signer2.Tabs.CheckboxTabs.Add(tempCB2);
                            break;

                        case "signer2_ad":
                            string tempAddress2 = Request[key];
                            string[] addArray2 = tempAddress2.Split(',');
                            string tempAddLabel2 = key;
                            tempAddLabel2 = tempAddLabel2.Substring(16, tempAddLabel2.Length - 18);
                            if (addArray2[0] != "")
                            {
                                Text street12 = new Text();
                                street12.TabLabel = tempAddLabel2 + "_street1";
                                street12.Value = addArray2[0];
                                Signer2.Tabs.TextTabs.Add(street12);
                            }
                            if (addArray2[1] != "")
                            {
                                Text street22 = new Text();
                                street22.TabLabel = tempAddLabel2 + "_street2";
                                street22.Value = addArray2[1];
                                Signer2.Tabs.TextTabs.Add(street22);
                            }
                            if (addArray2[2] != "")
                            {
                                Text city2 = new Text();
                                city2.TabLabel = tempAddLabel2 + "_city";
                                city2.Value = addArray2[2];
                                Signer2.Tabs.TextTabs.Add(city2);
                            }
                            if (addArray2[3] != "")
                            {
                                Text state2 = new Text();
                                state2.TabLabel = tempAddLabel2 + "_state";
                                state2.Value = addArray2[3];
                                Signer2.Tabs.TextTabs.Add(state2);
                            }
                            if (addArray2[4] != "")
                            {
                                Text zip2 = new Text();
                                zip2.TabLabel = tempAddLabel2 + "_zip";
                                zip2.Value = addArray2[4];
                                Signer2.Tabs.TextTabs.Add(zip2);
                            }
                            break;

                        case "accountnum":
                            dsAccountId = Request[key];
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
                            dsUser = Request[key];
                            break;

                        case "pd":
                            dsPassword = Request[key];
                            break;

                        case "dst":
                            dsTemplateId = Request[key];
                            break;

                        case "logo":
                            dsLogo = Request[key];
                            break;

                        default:
                            break;
                    }
                }
            }
            switch (dsSigner1AuthMethod.ToLower())
            {
                case "access code":
                    Signer1.AccessCode = dsSigner1AuthNumber;
                    break;

                case "sms":
                    Signer1.IdCheckConfigurationName = "SMS Auth $";
                    Signer1.RequireIdLookup = "true";
                    Signer1.SmsAuthentication = new RecipientSMSAuthentication();
                    Signer1.SmsAuthentication.SenderProvidedNumbers = new List<string>();
                    Signer1.SmsAuthentication.SenderProvidedNumbers.Add("+" + dsSigner1AuthNumber);
                    break;

                case "phone":
                    Signer1.IdCheckConfigurationName = "Phone Auth $";
                    Signer1.RequireIdLookup = "true";
                    Signer1.PhoneAuthentication = new RecipientPhoneAuthentication();
                    Signer1.PhoneAuthentication.SenderProvidedNumbers = new List<string>();
                    Signer1.PhoneAuthentication.SenderProvidedNumbers.Add("+" + dsSigner1AuthNumber);
                    Signer1.PhoneAuthentication.RecipMayProvideNumber = "false";
                    break;

                case "idcheck":
                    Signer1.IdCheckConfigurationName = "ID Check $";
                    Signer1.RequireIdLookup = "true";
                    break;

                default:
                    break;
            }

            switch (dsSigner1SP.ToLower())
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
                    rspAESAC.SignatureProviderOptions.OneTimePassword = dsSigner1AuthNumber;
                    Signer1.RecipientSignatureProviders.Add(rspAESAC);
                    break;

                case "ds aes sms":
                    Signer1.RecipientSignatureProviders = new List<RecipientSignatureProvider>();
                    RecipientSignatureProvider rspAESSMS = new RecipientSignatureProvider();
                    rspAESSMS.SignatureProviderName = "UniversalSignaturePen_OpenTrust_Hash_TSP";
                    rspAESSMS.SignatureProviderOptions = new RecipientSignatureProviderOptions();
                    rspAESSMS.SignatureProviderOptions.Sms = "+" + dsSigner1AuthNumber;
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

            switch (dsSigner2AuthMethod.ToLower())
            {
                case "access code":
                    Signer2.AccessCode = dsSigner2AuthNumber;
                    break;

                case "sms":
                    Signer2.IdCheckConfigurationName = "SMS Auth $";
                    Signer2.RequireIdLookup = "true";
                    Signer2.SmsAuthentication = new RecipientSMSAuthentication();
                    Signer2.SmsAuthentication.SenderProvidedNumbers = new List<string>();
                    Signer2.SmsAuthentication.SenderProvidedNumbers.Add("+" + dsSigner2AuthNumber);
                    break;

                case "phone":
                    Signer2.IdCheckConfigurationName = "Phone Auth $";
                    Signer2.RequireIdLookup = "true";
                    Signer2.PhoneAuthentication = new RecipientPhoneAuthentication();
                    Signer2.PhoneAuthentication.SenderProvidedNumbers = new List<string>();
                    Signer2.PhoneAuthentication.SenderProvidedNumbers.Add("+" + dsSigner2AuthNumber);
                    Signer2.PhoneAuthentication.RecipMayProvideNumber = "false";
                    break;

                case "idcheck":
                    Signer2.IdCheckConfigurationName = "ID Check $";
                    Signer2.RequireIdLookup = "true";
                    break;

                default:
                    break;
            }

            switch (dsSigner2SP.ToLower())
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
                    rspAESAC.SignatureProviderOptions.OneTimePassword = dsSigner2AuthNumber;
                    Signer2.RecipientSignatureProviders.Add(rspAESAC);
                    break;

                case "ds aes sms":
                    Signer2.RecipientSignatureProviders = new List<RecipientSignatureProvider>();
                    RecipientSignatureProvider rspAESSMS = new RecipientSignatureProvider();
                    rspAESSMS.SignatureProviderName = "UniversalSignaturePen_OpenTrust_Hash_TSP";
                    rspAESSMS.SignatureProviderOptions = new RecipientSignatureProviderOptions();
                    rspAESSMS.SignatureProviderOptions.Sms = "+" + dsSigner2AuthNumber;
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

            st.TemplateId = dsTemplateId;

            ct.ServerTemplates.Add(st);
            ct.InlineTemplates.Add(it);

            envDef.CompositeTemplates.Add(ct);

            envDef.Status = "sent";

            string json = JsonConvert.SerializeObject(envDef, Formatting.Indented);
            System.Diagnostics.Debug.Write(json);

            ApiClient apiClient = new ApiClient("https://demo.docusign.net/restapi");
            Configuration.Default.ApiClient = apiClient;
            dsAuthHeader = "{\"Username\":\"" + dsUser + "\", \"Password\":\"" + dsPassword + "\", \"IntegratorKey\":\"49cfeb67-7406-4cef-bac9-7594a8802986\"}";
            Configuration.Default.DefaultHeader.Remove("X-DocuSign-Authentication");
            Configuration.Default.AddDefaultHeader("X-DocuSign-Authentication", dsAuthHeader);

            TemplatesApi tempApi = new TemplatesApi();
            EnvelopeTemplate tempInfo = tempApi.Get(dsAccountId, dsTemplateId);
            string brandId = tempInfo.BrandId;

            AccountsApi acctApi = new AccountsApi();
            Brand brandInfo = acctApi.GetBrand(dsAccountId, brandId);
            foreach (var key in brandInfo.Colors)
            {
                if (key.Name == "headerBackground")
                {
                    dsHeaderColor = key.Value;
                }
                if (key.Name == "headerText")
                {
                    dsFontColor = key.Value;
                }
            }
            if (dsHeaderColor == "")
            {
                dsHeaderColor = "#5376B7";
            }
            if (dsFontColor == "")
            {
                dsFontColor = "#FFFFFF";
            }

            EnvelopesApi envelopesApi = new EnvelopesApi();

            EnvelopeSummary envelopeSummary = envelopesApi.CreateEnvelope(dsAccountId, envDef);
            dsEnvelopeId = envelopeSummary.EnvelopeId;

            using (StreamWriter file = File.CreateText(Server.MapPath("~/json/" + dsEnvelopeId + ".json")))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, envDef);
            }

            if (Signer1.ClientUserId != null && Signer2.ClientUserId != null)
            {
                RecipientViewRequest viewOptions = new RecipientViewRequest()
                {
                    ReturnUrl = "https://innov8ive.app/hmd/signer2start.aspx",
                    ClientUserId = dsSigner1CID,
                    AuthenticationMethod = "email",
                    UserName = Signer1.Name,
                    Email = Signer1.Email
                };

                ViewUrl recipientView = envelopesApi.CreateRecipientView(dsAccountId, dsEnvelopeId, viewOptions);

                Response.Redirect(recipientView.Url);

            }
            else if (Signer1.ClientUserId != null && Signer2.ClientUserId == null)
            {
                RecipientViewRequest viewOptions = new RecipientViewRequest()
                {
                    ReturnUrl = "https://innov8ive.app/hmd/status.aspx",
                    ClientUserId = dsSigner1CID,
                    AuthenticationMethod = "email",
                    UserName = Signer1.Name,
                    Email = Signer1.Email
                };

                ViewUrl recipientView = envelopesApi.CreateRecipientView(dsAccountId, dsEnvelopeId, viewOptions);

                Response.Redirect(recipientView.Url);

            }
            else
            {
                Response.Redirect("~/hmd/status.aspx");
            }
        }
    }
}