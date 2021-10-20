using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Security.Cryptography;
using System.Collections.Specialized;


namespace MoreAll
{
    public class ServerInfoUtlitities
    {
        private NameValueCollection coll = HttpContext.Current.Request.ServerVariables;

        public object _QUERY_STRING
        {
            get
            {
                return this.coll["QUERY_STRING"];
            }
        }

        public string APPL_MD_PATH
        {
            get
            {
                return this.coll["APPL_MD_PATH"];
            }
        }

        public string APPL_PHYSICAL_PATH
        {
            get
            {
                return this.coll["APPL_PHYSICAL_PATH"];
            }
        }

        public string HTTP_ACCEPT
        {
            get
            {
                return this.coll["HTTP_ACCEPT"];
            }
        }

        public string HTTP_HOST
        {
            get
            {
                return this.coll["HTTP_HOST"];
            }
        }

        public string LOCAL_ADDR
        {
            get
            {
                return this.coll["LOCAL_ADDR"];
            }
        }

        public string PATH_INFO
        {
            get
            {
                return this.coll["PATH_INFO"];
            }
        }

        public string PATH_TRANSLATED
        {
            get
            {
                return this.coll["PATH_TRANSLATED"];
            }
        }

        public string QUERY_STRING
        {
            get
            {
                return this.coll["QUERY_STRING"];
            }
        }

        public string REMOTE_ADDR
        {
            get
            {
                return this.coll["REMOTE_ADDR"];
            }
        }

        public string REMOTE_HOST
        {
            get
            {
                return this.coll["REMOTE_HOST"];
            }
        }

        public string REMOTE_PORT
        {
            get
            {
                return this.coll["REMOTE_PORT"];
            }
        }

        public string REQUEST_METHOD
        {
            get
            {
                return this.coll["REQUEST_METHOD"];
            }
        }

        public string SCRIPT_NAME
        {
            get
            {
                return this.coll["SCRIPT_NAME"];
            }
        }

        public string SERVER_NAME
        {
            get
            {
                return this.coll["SERVER_NAME"];
            }
        }

        public string SERVER_PORT
        {
            get
            {
                return this.coll["SERVER_PORT"];
            }
        }

        public string URL
        {
            get
            {
                return this.coll["URL"];
            }
        }
    }
}

