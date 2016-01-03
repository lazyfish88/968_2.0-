using System;
using System.Web;

namespace Ac968.SystemModuleSetMeal.Utility
{
    public class GetRequest
    {
        #region 表单处理
        /// <summary>
        /// 取得请求表单、URL参数值
        /// </summary>
        /// <param name="requestName">表单名称、URL参数名称</param>
        /// <param name="method">请求方法</param>
        /// <returns></returns>
		public static string GetRequestValue(string requestName)
        {
            return GetRequestValue(requestName, Method.All);
        }
        /// <summary>
        /// 取得请求表单、URL参数值
        /// </summary>
        /// <param name="requestName">表单名称、URL参数名称</param>
        /// <param name="method">请求方法</param>
        /// <returns></returns>
        public static string GetRequestValue(string requestName, Method method)
        {
            string requestValue = string.Empty;
            switch (method)
            {
                case Method.Get:
                    if (HttpContext.Current.Request.QueryString[requestName] != null)
                    {
                        requestValue = HttpContext.Current.Request.QueryString[requestName];
                    }
                    break;
                case Method.Post:
                    if (HttpContext.Current.Request.Form[requestName] != null)
                    {
                        requestValue = HttpContext.Current.Request.Form[requestName];
                    }
                    break;
                default:
                    requestValue = HttpContext.Current.Request[requestName];
                    break;
            }
            return string.IsNullOrEmpty(requestValue) ? "" : requestValue;
        }

        /// <summary>
        /// 判断是否点击了按钮
        /// </summary>
        /// <param name="RequestName"></param>
        /// <returns></returns>
        public static bool IsClick(string RequestName)
        {
            if (HttpContext.Current.Request.Form[RequestName] != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 取得字符串(表单、URL参数)
        /// </summary>
        /// <param name="requestName">请求名称</param>
        /// <param name="method">请求方式</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static string GetString(string requestName, Method method, string defaultValue)
        {
            string requestValue = GetRequestValue(requestName, method);
            if (!string.IsNullOrEmpty(requestValue))
            {
                return requestValue;
            }
            return defaultValue;
        }

        public static DateTime GetDateTime(string requestName, Method method, DateTime defaultValue)
        {
            DateTime value = defaultValue;
            string requestValue = GetRequestValue(requestName, method);
            if (DateTime.TryParse(requestValue, out value))
            {
                return value;
            }
            return defaultValue;
        }
        public static decimal GetDecimal(string requestName, Method method, decimal defaultValue)
        {
            decimal value = defaultValue;
            string requestValue = GetRequestValue(requestName, method);
            if (decimal.TryParse(requestValue, out value))
            {
                return value;
            }
            return defaultValue;
        }
        public static double GetDouble(string requestName, Method method, double defaultValue)
        {
            double value = defaultValue;
            string requestValue = GetRequestValue(requestName, method);
            if (double.TryParse(requestValue, out value))
            {
                return value;
            }
            return defaultValue;
        }
        public static Int64 GetInt64(string requestName, Method method, Int64 defaultVale)
        {
            Int64 value = defaultVale;
            string requestValue = GetRequestValue(requestName, method);
            if (Int64.TryParse(requestValue, out value))
            {
                return value;
            }
            return defaultVale;
        }
        public static int GetInt32(string requestName)
        {
            return GetInt32(requestName, Method.All, 0);
        }
        public static int GetInt32(string requestName, Method method, int defaultVale)
        {
            int value = defaultVale;
            string requestValue = GetRequestValue(requestName, method);
            if (int.TryParse(requestValue, out value))
            {
                return value;
            }
            return defaultVale;
        }
        public static Int16 GetInt16(string requestName, Method method, short defaultValue)
        {
            short value = defaultValue;
            string requestValue = GetRequestValue(requestName, method);
            if (short.TryParse(requestValue, out value))
            {
                return value;
            }
            return defaultValue;
        }
        #endregion
    }

    public enum Method
    {
        Get = 1,
        Post = 2,
        All = 3,
    }
}
