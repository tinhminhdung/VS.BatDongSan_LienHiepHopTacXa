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

namespace MoreAll
{
    internal class EncodeDecode
    {
        private char[] arrCharSet;
        private string[] arrKeys;
        private static string CharSet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private const byte KEY = 0x13;
        private string[] Keys = new string[] { "98tvajsdhg!8034y0h0~3uhf0cu3H40TUH30H2FLKJ+GEU502*9029+8H20495*", "0984tpeo^rhg09WHIN2043HNTX098~H98X07H98M942-9x8h9mg-8g598xm9521", "NVLIDSJnv0w45uv045vlskj~vo8uh0837013509*yrehfaiu!oiudfsjp098sdh", "*+pninutcpiu##piucpoieupcoun409*(13485c0439856c084n5609834750c!" };
        private SymmetricAlgorithm mCSP = new RijndaelManaged();

        public string Decode(string str)
        {
            try
            {
                string DecodedStr = "";
                string CodeStr = "";
                this.arrCharSet = CharSet.ToCharArray();
                this.arrKeys = this.LoadKeyArray();
                for (int i = 0; i < (str.Length / this.Keys.Length); i++)
                {
                    CodeStr = str.Substring(this.Keys.Length * i, this.Keys.Length);
                    for (int h = 0; h < this.arrKeys.Length; h++)
                    {
                        if (CodeStr == this.arrKeys[h])
                        {
                            DecodedStr = DecodedStr + this.arrCharSet[h];
                            break;
                        }
                    }
                }
                return DecodedStr;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        public string DecodeString(string text, string KeyString, string IVString)
        {
            this.mCSP.GenerateKey();
            this.mCSP.GenerateIV();
            this.mCSP.GenerateKey();
            this.mCSP.GenerateIV();
            ICryptoTransform ct = this.mCSP.CreateDecryptor(this.mCSP.Key, this.mCSP.IV);
            byte[] byt = Convert.FromBase64String(text);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, ct, CryptoStreamMode.Write);
            cs.Write(byt, 0, byt.Length);
            cs.FlushFinalBlock();
            cs.Close();
            return Encoding.UTF8.GetString(ms.ToArray());
        }

        public string Encode(string str)
        {
            try
            {
                string EncodedStr = "";
                int CharPos = 0;
                for (int i = 0; i < str.Length; i++)
                {
                    CharPos = CharSet.IndexOf(str.Substring(i, 1));
                    for (int j = 0; j < this.Keys.Length; j++)
                    {
                        EncodedStr = EncodedStr + this.Keys[j].Substring(CharPos, 1);
                    }
                }
                return EncodedStr;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        public string EncodeString(string text, string KeyString, string IVString)
        {
            this.mCSP.GenerateKey();
            this.mCSP.GenerateIV();
            this.mCSP.GenerateKey();
            this.mCSP.GenerateIV();
            ICryptoTransform ct = this.mCSP.CreateEncryptor(this.mCSP.Key, this.mCSP.IV);
            byte[] byt = Encoding.UTF8.GetBytes(text);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, ct, CryptoStreamMode.Write);
            cs.Write(byt, 0, byt.Length);
            cs.FlushFinalBlock();
            cs.Close();
            return Convert.ToBase64String(ms.ToArray());
        }

        public string encryptDescrypt(string strOrg)
        {
            byte[] bData = Encoding.ASCII.GetBytes(strOrg);
            for (int i = 0; i < bData.Length; i++)
            {
                bData[i] = (byte)(bData[i] ^ 0x13);
            }
            return Encoding.ASCII.GetString(bData);
        }

        public string keysize()
        {
            SymmetricAlgorithm mCSP = new RijndaelManaged();
            return mCSP.KeySize.ToString();
        }

        private string[] LoadKeyArray()
        {
            string[] tmpArray = new string[this.Keys[0].Length];
            int KeyStrLength = this.Keys[0].Length;
            for (int i = 0; i < KeyStrLength; i++)
            {
                for (int h = 0; h < this.Keys.Length; h++)
                {
                    string[] CS00001;
                    IntPtr CS00002;
                    (CS00001 = tmpArray)[(int)(CS00002 = (IntPtr)i)] = CS00001[(int)CS00002] + this.Keys[h].Substring(i, 1);
                }
            }
            return tmpArray;
        }

        public string pCharSet
        {
            set
            {
                CharSet = value;
            }
        }

        public string[] pKey
        {
            set
            {
                this.Keys = value;
            }
        }
    }
}

