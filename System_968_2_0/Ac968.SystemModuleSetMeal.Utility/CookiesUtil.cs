using System;
using System.Web;
using System.Security.Cryptography;
using System.IO;
using System.Text;

namespace Ac968.SystemModuleSetMeal.Utility
{
    public static class CookiesUtil
    {
        #region 取Cookies

        /// <summary>
        /// 取cookies值[不论是否跨域，取值的时候，不需要有domain]
        /// </summary>
        /// <param name="cookiesName"></param>
        /// <returns></returns>
        public static string GetCookiesValue_V2(string cookiesName, string valueKey)
        {
            if (HttpContext.Current.Request.Cookies[cookiesName] != null)
            {
                try
                {
                    if (cookiesName != "RedirectUrl")
                        return CookiesUtil.Decode_V2(HttpUtility.UrlDecode(HttpContext.Current.Request.Cookies[cookiesName].Values[valueKey]), "968ch").Replace("\0", "");
                    else
                    {
                        return HttpContext.Current.Request.Cookies[cookiesName].Value.Replace("\0", "");
                    }
                }
                catch (Exception)
                {
                    return string.Empty;
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// 取cookies值[不论是否跨域，取值的时候，不需要有domain]
        /// </summary>
        /// <param name="cookiesName"></param>
        /// <returns></returns>
        public static string GetCookiesValue(string cookiesName)
        {
            if (HttpContext.Current.Request.Cookies[cookiesName] != null)
            {
                try
                {
                    if (cookiesName != "RedirectUrl")
                        return CookiesUtil.DesDecode(HttpUtility.UrlDecode(HttpContext.Current.Request.Cookies[cookiesName].Value)).Replace("\0", "");
                    else
                    {
                        return HttpContext.Current.Request.Cookies[cookiesName].Value.Replace("\0", "");
                    }
                }
                catch (Exception)
                {
                    return string.Empty;
                }
            }
            return string.Empty;
        }
        #endregion
        #region 写入cookies
        /// <summary>
        /// 写入cookies
        /// </summary>
        /// <param name="cookiesName">cookies名称</param>
        /// <param name="cookiesValue">cookies值</param>
        /// <param name="expires">过期时间</param>
        public static void SetCookies(string cookiesName, object cookiesValue, DateTime? expires)
        {
            SetCookies(cookiesName, cookiesValue.ToString(), expires, string.Empty);
        }
        /// <summary>
        /// 写入cookies
        /// </summary>
        /// <param name="cookiesName">cookies名称</param>
        /// <param name="cookiesValue">cookies值</param>
        /// <param name="expires">过期时间</param>
        /// <param name="domain">域</param>
        public static void SetCookies(string cookiesName, string cookiesValue, DateTime? expires, string domain)
        {
            if (HttpContext.Current.Request.Url.ToString().IndexOf("localhost") == -1)
            {
                domain = "968ch.com";
            }
            ClearCookies(cookiesName, domain);//清除cookies
                                              // HttpContext.Current.Response.AddHeader("p3p", "CP=\"CAO PSA OUR\"");//ok，正常可以使用,设置cookies跨域共享
            if (cookiesName != "RedirectUrl")
            {
                cookiesValue = HttpUtility.UrlEncode(CookiesUtil.DesEncode(cookiesValue));
            }
            // HttpContext.Current.Response.AddHeader("p3p", "CP=\"CAO PSA OUR\"");//ok，正常可以使用,设置cookies跨域共享
            HttpCookie cncookies = new HttpCookie(cookiesName, cookiesValue);
            if (expires != null)
            {
                cncookies.Expires = Convert.ToDateTime(expires);
            }
            if (!string.IsNullOrEmpty(domain))
            {
                //cncookies.Domain = ".b.com";
                //cncookies.Path = "/";
                //if (domain != "localhost")
                //{
                //    cncookies.Domain = domain;
                //    cncookies.Path = "/";
                //}
            }
            HttpContext.Current.Response.Cookies.Add(cncookies);
        }
        #endregion
        #region 清除cookies
        /// <summary>
        /// 清除cookies
        /// </summary>
        /// <param name="cookiesName">cookies名称</param>
        public static void ClearCookies(string cookiesName)
        {
            ClearCookies(cookiesName, string.Empty);
        }
        /// <summary>
        /// 清除cookies
        /// </summary>
        /// <param name="cookiesName">cookise名称</param>
        /// <param name="domain">域</param>
        public static void ClearCookies(string cookiesName, string domain)
        {
            if (HttpContext.Current.Request.Cookies[cookiesName] != null)
            {
                HttpCookie cookies = new HttpCookie(cookiesName);
                if (!string.IsNullOrEmpty(domain))
                {
                    //cncookies.Domain = ".b.com";
                    //cncookies.Path = "/";
                    cookies.Domain = domain;
                    cookies.Path = "/";
                }
                cookies.Expires = DateTime.Now.AddDays(-1);
                HttpContext.Current.Response.Cookies.Add(cookies);
                HttpContext.Current.Request.Cookies.Remove(cookiesName);
            }
        }
        #endregion
        #region Des加密/解密
        static string KEY_64 = "!qzhost!";
        static string IV_64 = "!qzhost!"; //注意了，是8个字符，64位 
                                          /// <summary>
                                          /// Des加密
                                          /// </summary>
                                          /// <param name="data">要加密的字符串</param>
                                          /// <returns></returns>
        public static string DesEncode(string data)
        {
            byte[] byKey = System.Text.ASCIIEncoding.ASCII.GetBytes(KEY_64);
            byte[] byIV = System.Text.ASCIIEncoding.ASCII.GetBytes(IV_64);

            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();


            cryptoProvider.Key = System.Text.Encoding.ASCII.GetBytes(KEY_64);

            cryptoProvider.Mode = CipherMode.ECB;
            cryptoProvider.Padding = PaddingMode.Zeros;



            int i = cryptoProvider.KeySize;
            MemoryStream ms = new MemoryStream();
            CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateEncryptor(byKey, byIV), CryptoStreamMode.Write);

            StreamWriter sw = new StreamWriter(cst);
            sw.Write(data);
            sw.Flush();
            cst.FlushFinalBlock();
            sw.Flush();
            return Convert.ToBase64String(ms.GetBuffer(), 0, (int)ms.Length);

        }
        /// <summary>
        /// Des解密
        /// </summary>
        /// <param name="data">要加密的字符串</param>
        /// <returns></returns>
        public static string DesDecode(string data, string key = "")
        {
            if (key != string.Empty)
            {
                KEY_64 = IV_64 = key;
            }

            byte[] byKey = System.Text.ASCIIEncoding.ASCII.GetBytes(KEY_64);
            byte[] byIV = System.Text.ASCIIEncoding.ASCII.GetBytes(IV_64);

            byte[] byEnc;
            try
            {
                byEnc = Convert.FromBase64String(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();


            cryptoProvider.Key = System.Text.Encoding.ASCII.GetBytes(KEY_64);

            cryptoProvider.Mode = CipherMode.ECB;
            cryptoProvider.Padding = PaddingMode.Zeros;

            MemoryStream ms = new MemoryStream(byEnc);
            CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateDecryptor(byKey, byIV), CryptoStreamMode.Read);
            StreamReader sr = new StreamReader(cst);
            return sr.ReadToEnd();
        }
        #endregion

        /// <summary>
        /// 解密
        /// </summary>
        public static string Decode_V2(this string decryptString, string decryptKey)
        {
            byte[] Keys = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };


            decryptString = System.Text.Encoding.Default.GetString(Convert.FromBase64String(decryptString));

            try
            {
                if (decryptKey.Length >= 8) decryptKey = decryptKey.Substring(0, 8);
                decryptKey = decryptKey.PadRight(8, ' ');
                byte[] rgbKey = Encoding.UTF8.GetBytes(decryptKey);
                byte[] rgbIV = Keys;
                byte[] inputByteArray = Convert.FromBase64String(decryptString);
                DESCryptoServiceProvider DCSP = new DESCryptoServiceProvider();

                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, DCSP.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Encoding.UTF8.GetString(mStream.ToArray());
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// DES加密字符串
        /// </summary>
        /// <param name="encryptString">待加密的字符串</param>
        /// <param name="encryptKey">加密密钥,要求为8位</param>
        /// <returns>加密成功返回加密后的字符串,失败返回源串</returns>
        public static string Encode_V2(this string encryptString, string encryptKey)
        {
            byte[] Keys = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };


            //  encryptString = System.Text.Encoding.Default.GetString(Convert.FromBase64String(encryptString));


            if (encryptKey.Length >= 8) encryptKey = encryptKey.Substring(0, 8);


            encryptKey = encryptKey.PadRight(8, ' ');
            byte[] rgbKey = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 8));
            byte[] rgbIV = Keys;
            byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptString);
            DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider();
            MemoryStream mStream = new MemoryStream();
            CryptoStream cStream = new CryptoStream(mStream, dCSP.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
            cStream.Write(inputByteArray, 0, inputByteArray.Length);
            cStream.FlushFinalBlock();
            return Convert.ToBase64String(System.Text.Encoding.Default.GetBytes(Convert.ToBase64String(mStream.ToArray())));

        }
    }
}
