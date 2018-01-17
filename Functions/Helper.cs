using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using System.Text;
using System.Configuration;
using System.Web.Configuration;
using System.Threading;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Web.Mvc;

namespace TheAgency.Functions
{
    public static class Helper
    {
        public static void ShowException(Exception ex)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\r\n\r\n\r\n");
            sb.Append("\t\t\t");
            sb.Append("**********---------- EXCEPTION MESSAGE START ----------**********");
            sb.Append("\r\n\r\n");
            sb.Append("\t\t\t" + ex.Message);
            sb.Append("\r\n\r\n");
            sb.Append("\t\t\t");
            sb.Append("**********----------  EXCEPTION MESSAGE END  ----------**********");
            sb.Append("\r\n\r\n\r\n");
            Debug.WriteLine(sb.ToString());
        }
        public static string GetConfigValue(string key)
        {
            string ddKey = ConfigurationManager.AppSettings[key];
            return (!String.IsNullOrEmpty(ddKey)) ? ddKey : null;
        }
        public static string CurrencySymbol()
        {
            RegionInfo ri = new RegionInfo(Thread.CurrentThread.CurrentUICulture.LCID);
            return ri.CurrencySymbol;
        }
        public static string ISOCurrencySymbol()
        {
            RegionInfo ri = new RegionInfo(Thread.CurrentThread.CurrentUICulture.LCID);
            return ri.ISOCurrencySymbol;
        }
        public static string CleanHTML(string source)
        {
            Regex _htmlRegex = new Regex("<.*?>", RegexOptions.Compiled);
            if (source != null)
            {
                return _htmlRegex.Replace(source, string.Empty);
            }
            return string.Empty;
        }
        public static string ToAbsoluteUrl(this string relativeUrl) //Use absolute URL instead of adding phycal path for CSS, JS and Images     
        {
            if (string.IsNullOrEmpty(relativeUrl)) return relativeUrl;
            if (HttpContext.Current == null) return relativeUrl;
            if (relativeUrl.StartsWith("/")) relativeUrl = relativeUrl.Insert(0, "~");
            if (!relativeUrl.StartsWith("~/")) relativeUrl = relativeUrl.Insert(0, "~/");
            var url = HttpContext.Current.Request.Url;
            var port = url.Port != 80 ? (":" + url.Port) : String.Empty;
            return String.Format("{0}://{1}{2}{3}", url.Scheme, url.Host, port, VirtualPathUtility.ToAbsolute(relativeUrl));
        }
        public static string GeneratePassword(int length)
        {
            const string allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789";
            Random randNum = new Random();
            char[] chars = new char[length];
            int allowedCharCount = allowedChars.Length;
            for (var i = 0; i <= length - 1; i++)
            {
                chars[i] = allowedChars[Convert.ToInt32((allowedChars.Length) * randNum.NextDouble())];
            }
            return new string(chars);
        }
        public static string EncodePassword(string pass, string salt)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(pass);
            byte[] src = Encoding.Unicode.GetBytes(salt);
            byte[] dst = new byte[src.Length + bytes.Length];
            Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);
            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return EncodePasswordMd5(Convert.ToBase64String(inArray));
        }
        private static string EncodePasswordMd5(string pass)
        {
            Byte[] originalBytes;
            Byte[] encodedBytes;
            MD5 md5 = new MD5CryptoServiceProvider();
            originalBytes = ASCIIEncoding.Default.GetBytes(pass);
            encodedBytes = md5.ComputeHash(originalBytes);
            return BitConverter.ToString(encodedBytes);
        }
        public static string base64Encode(string sData)
        {
            try
            {
                byte[] encData_byte = new byte[sData.Length];
                encData_byte = Encoding.UTF8.GetBytes(sData);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }
        public static string base64Decode(string sData)
        {
            try
            {
                var encoder = new System.Text.UTF8Encoding();
                Decoder utf8Decode = encoder.GetDecoder();
                byte[] todecodeByte = Convert.FromBase64String(sData);
                int charCount = utf8Decode.GetCharCount(todecodeByte, 0, todecodeByte.Length);
                char[] decodedChar = new char[charCount];
                utf8Decode.GetChars(todecodeByte, 0, todecodeByte.Length, decodedChar, 0);
                string result = new String(decodedChar);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Decode" + ex.Message);
            }
        }
        public static Int32 generateRNGCSP()
        {
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] data = new byte[4];
                rng.GetBytes(data);
                int value = BitConverter.ToInt32(data, 0);
                return Math.Abs(value);
            }
        }
    }
}