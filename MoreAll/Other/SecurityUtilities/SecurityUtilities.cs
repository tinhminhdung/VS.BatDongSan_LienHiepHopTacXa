using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using MoreAll;

namespace MoreAll
{
    public class SecurityUtilities
    {
        private EncodeDecode ed = new EncodeDecode();

        public string CreatePassword(int length)
        {
            string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            string res = "";
            Random rnd = new Random();
            while (0 < length--)
            {
                res = res + valid[rnd.Next(valid.Length)];
            }
            return res;
        }

        public string decodeStr(string str, string pCharSet)
        {
            this.ed.pCharSet = pCharSet;
            return this.ed.Decode(str);
        }

        public string decodeStr(string text, string Key, string IV)
        {
            return this.ed.DecodeString(text.Trim(), Key.Trim(), IV.Trim());
        }

        public string encodedecode(string text)
        {
            try
            {
                return this.ed.encryptDescrypt(text);
            }
            catch (Exception)
            {
                return "";
            }
        }

        public static string EncodeMD5(string text)
        {
            byte[] byteArray = new UnicodeEncoding().GetBytes(text);
            byte[] hashvalue = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(byteArray);
            string encryptedText = "";
            for (int i = 0; i < hashvalue.Length; i++)
            {
                encryptedText = encryptedText + Convert.ToString(hashvalue[i]);
            }
            return encryptedText;
        }

        public string encodeStr(string str, string pCharSet)
        {
            this.ed.pCharSet = pCharSet;
            return this.ed.Encode(str);
        }

        public string encodeStr(string text, string Key, string IV)
        {
            return this.ed.EncodeString(text.Trim(), Key.Trim(), IV.Trim());
        }

        public string keysize()
        {
            return this.ed.keysize();
        }

        public string MD5(string text)
        {
            byte[] byteArray = new UnicodeEncoding().GetBytes(text);
            byte[] hashvalue = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(byteArray);
            string encryptedText = "";
            for (int i = 0; i < hashvalue.Length; i++)
            {
                encryptedText = encryptedText + Convert.ToString(hashvalue[i]);
            }
            return encryptedText;
        }
    }
}

