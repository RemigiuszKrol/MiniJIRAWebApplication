using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using Newtonsoft.Json;
using System.Data.SqlClient;

namespace MiniJIRAWebApplication
{
    /// <summary>
    /// Summary description for MainMiniJIRA
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class MainMiniJIRA : System.Web.Services.WebService
    {
        DataTable dtUsers = new DataTable();
        DBAccess objDbAccess = new DBAccess();
        DataTable dbUsers = new DataTable();

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public int Sum(int a, int b)
        {
            return a+b;
        }

        [WebMethod]
        public string UsersTable()
        {
            dtUsers.Columns.Add("UserName");
            dtUsers.Columns.Add("Login");

            dtUsers.Rows.Add("Remigiusz Król", "REKROL");
            dtUsers.Rows.Add("Joanna Król", "JOKROL");

            return JsonConvert.SerializeObject(dtUsers);
        }

        [WebMethod]
        public string UsersTableForUsers(string id)
        {
            string query = "SELECT * FROM [dbo].[Users] WHERE UserLogin = '" + id + "'";
            objDbAccess.readDataThroughAdapter(query, dtUsers);

            string result = JsonConvert.SerializeObject(dtUsers);
            return result;
        }

        [WebMethod]
        public string GetIp()
        {
            string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(ip))
            {
                ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
            string allHttp = System.Web.HttpContext.Current.Request.ServerVariables["ALL_HTTP"];
            string allRaw = System.Web.HttpContext.Current.Request.ServerVariables["ALL_RAW"];
            string allPoolID = System.Web.HttpContext.Current.Request.ServerVariables["APP_POOL_ID"];
            string allMDPath = System.Web.HttpContext.Current.Request.ServerVariables["APPL_MD_PATH"];
            string allPhyPath = System.Web.HttpContext.Current.Request.ServerVariables["APPL_PHYSICAL_PATH"];
            string authPassword = System.Web.HttpContext.Current.Request.ServerVariables["AUTH_PASSWORD"];
            string authType = System.Web.HttpContext.Current.Request.ServerVariables["AUTH_TYPE"];
            string authUser = System.Web.HttpContext.Current.Request.ServerVariables["AUTH_USER"];
            string cacheUrl = System.Web.HttpContext.Current.Request.ServerVariables["CACHE_URL"];
            string certCookie = System.Web.HttpContext.Current.Request.ServerVariables["CERT_COOKIE"];

            return ip + "/;/" + allHttp + "/;/" + allRaw + "/;/" + allPoolID + "/;/" + allMDPath + "/;/" + allPhyPath + "/;/" + authPassword + "/;/" + authType + "/;/" + authUser + "/;/" + cacheUrl + "/;/" + certCookie;
        }
        [WebMethod]
        public string GetIp2()
        {
            string allHttp = System.Web.HttpContext.Current.Request.ServerVariables["CERT_FLAGS"];
            string allRaw = System.Web.HttpContext.Current.Request.ServerVariables["CERT_ISSUER"];
            string allPoolID = System.Web.HttpContext.Current.Request.ServerVariables["CERT_KEYSIZE"];
            string allMDPath = System.Web.HttpContext.Current.Request.ServerVariables["CERT_SECRETKEYSIZE"];
            string allPhyPath = System.Web.HttpContext.Current.Request.ServerVariables["CERT_SERIALNUMBER"];
            string authPassword = System.Web.HttpContext.Current.Request.ServerVariables["CERT_SERVER_ISSUER"];
            string authType = System.Web.HttpContext.Current.Request.ServerVariables["CERT_SERVER_SUBJECT"];
            string authUser = System.Web.HttpContext.Current.Request.ServerVariables["CERT_SUBJECT"];
            string cacheUrl = System.Web.HttpContext.Current.Request.ServerVariables["CONTENT_LENGTH"];
            string certCookie = System.Web.HttpContext.Current.Request.ServerVariables["CONTENT_TYPE"];

            return "/;/" + allHttp + "/;/" + allRaw + "/;/" + allPoolID + "/;/" + allMDPath + "/;/" + allPhyPath + "/;/" + authPassword + "/;/" + authType + "/;/" + authUser + "/;/" + cacheUrl + "/;/" + certCookie;
        }
        [WebMethod]
        public string GetIp3()
        {
            string allHttp = System.Web.HttpContext.Current.Request.ServerVariables["GATEWAY_INTERFACE"];
            string allRaw = System.Web.HttpContext.Current.Request.ServerVariables["HEADER_"];
            string allPoolID = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_ACCEPT"];
            string allMDPath = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_ACCEPT_ENCODING"];
            string allPhyPath = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_ACCEPT_LANGUAGE"];
            string authPassword = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_CONNECTION"];
            string authType = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_COOKIE"];
            string authUser = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_HOST"];
            string cacheUrl = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_METHOD"];
            string certCookie = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_REFERER"];

            return "/;/" + allHttp + "/;/" + allRaw + "/;/" + allPoolID + "/;/" + allMDPath + "/;/" + allPhyPath + "/;/" + authPassword + "/;/" + authType + "/;/" + authUser + "/;/" + cacheUrl + "/;/" + certCookie;
        }
        [WebMethod]
        public string GetIp5()
        {
            string allHttp = System.Web.HttpContext.Current.Request.ServerVariables["LOCAL_ADDR"];
            string allRaw = System.Web.HttpContext.Current.Request.ServerVariables["LOGON_USER"];
            string allPoolID = System.Web.HttpContext.Current.Request.ServerVariables["PATH_INFO"];
            string allMDPath = System.Web.HttpContext.Current.Request.ServerVariables["PATH_TRANSLATED"];
            string allPhyPath = System.Web.HttpContext.Current.Request.ServerVariables["QUERY_STRING"];
            string authPassword = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            string authType = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_HOST"];
            string authUser = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_PORT"];
            string cacheUrl = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_USER"];
            string certCookie = System.Web.HttpContext.Current.Request.ServerVariables["REQUEST_METHOD"];

            return "/;/" + allHttp + "/;/" + allRaw + "/;/" + allPoolID + "/;/" + allMDPath + "/;/" + allPhyPath + "/;/" + authPassword + "/;/" + authType + "/;/" + authUser + "/;/" + cacheUrl + "/;/" + certCookie;
        }
        [WebMethod]
        public string GetIp4()
        {
            string allHttp = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_URL"];
            string allRaw = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_USER_AGENT"];
            string allPoolID = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_VERSION"];
            string allMDPath = System.Web.HttpContext.Current.Request.ServerVariables["HTTPS"];
            string allPhyPath = System.Web.HttpContext.Current.Request.ServerVariables["HTTPS_KEYSIZE"];
            string authPassword = System.Web.HttpContext.Current.Request.ServerVariables["HTTPS_SECRETKEYSIZE"];
            string authType = System.Web.HttpContext.Current.Request.ServerVariables["HTTPS_SERVER_ISSUER"];
            string authUser = System.Web.HttpContext.Current.Request.ServerVariables["HTTPS_SERVER_SUBJECT"];
            string cacheUrl = System.Web.HttpContext.Current.Request.ServerVariables["INSTANCE_ID"];
            string certCookie = System.Web.HttpContext.Current.Request.ServerVariables["INSTANCE_META_PATH"];

            return "/;/" + allHttp + "/;/" + allRaw + "/;/" + allPoolID + "/;/" + allMDPath + "/;/" + allPhyPath + "/;/" + authPassword + "/;/" + authType + "/;/" + authUser + "/;/" + cacheUrl + "/;/" + certCookie;
        }
        [WebMethod]
        public string GetIp6()
        {
            string allHttp = System.Web.HttpContext.Current.Request.ServerVariables["SCRIPT_NAME"];
            string allRaw = System.Web.HttpContext.Current.Request.ServerVariables["SCRIPT_TRANSLATED"];
            string allPoolID = System.Web.HttpContext.Current.Request.ServerVariables["SERVER_NAME"];
            string allMDPath = System.Web.HttpContext.Current.Request.ServerVariables["SERVER_PORT"];
            string allPhyPath = System.Web.HttpContext.Current.Request.ServerVariables["SERVER_PORT_SECURE"];
            string authPassword = System.Web.HttpContext.Current.Request.ServerVariables["SERVER_PROTOCOL"];
            string authType = System.Web.HttpContext.Current.Request.ServerVariables["SERVER_SOFTWARE"];
            string authUser = System.Web.HttpContext.Current.Request.ServerVariables["SSI_EXEC_DISABLED"];
            string cacheUrl = System.Web.HttpContext.Current.Request.ServerVariables["UNENCODED_URL"];
            string certCookie = System.Web.HttpContext.Current.Request.ServerVariables["UNMAPPED_REMOTE_USER"];

            return "/;/" + allHttp + "/;/" + allRaw + "/;/" + allPoolID + "/;/" + allMDPath + "/;/" + allPhyPath + "/;/" + authPassword + "/;/" + authType + "/;/" + authUser + "/;/" + cacheUrl + "/;/" + certCookie;
        }
    }
}
