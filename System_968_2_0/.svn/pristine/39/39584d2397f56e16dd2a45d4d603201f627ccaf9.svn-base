
namespace Ac968.SystemModuleSetMeal.Utility.Alipay
{
    /// <summary>
    /// 类名：Config
    /// 功能：基础配置类
    /// 详细：设置帐户有关信息及返回路径
    /// 版本：3.2
    /// 日期：2011-03-17
    /// 说明：
    /// 以下代码只是为了方便商户测试而提供的样例代码，商户可以根据自己网站的需要，按照技术文档编写,并非一定要使用该代码。
    /// 该代码仅供学习和研究支付宝接口使用，只是提供一个参考。
    /// 
    /// 如何获取安全校验码和合作身份者ID
    /// 1.用您的签约支付宝账号登录支付宝网站(www.alipay.com)
    /// 2.点击“商家服务”(https://b.alipay.com/order/myOrder.htm)
    /// 3.点击“查询合作者身份(PID)”、“查询安全校验码(Key)”
    /// </summary>
    internal class Config
    {
        #region 字段
        private  string partner = "", partner2 = "";
        private  string key = "", key2 = "";
        private  string seller_email = "", seller_email2 = "";
        private  string return_url = "";
        private  string notify_url = "";
        private  string input_charset = "";
        private  string sign_type = "";
        private  string type = "1";
        #endregion

        public Config()
        {
            //↓↓↓↓↓↓↓↓↓↓请在这里配置您的基本信息↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
            #region 得到支付宝即时到帐接口信息
            //O2O.BLL.PayType obp = new O2O.BLL.PayType();
            //List<O2O.Model.PayType> lomp = obp.GetModelList("[OnlinePayType]=" + LibHelper.Enums.OnlinePayType.支付宝即时到账.GetHashCode());
            //if (lomp.Count <= 0)
            //{
            //    KzsLibHelper.CommonLib.MsgBox("系统还未设置支付接口信息，请联系管理员", "", true);
            //}
            #endregion
            //合作身份者ID，以2088开头由16位纯数字组成的字符串

            partner = "2088121597513837";
            //partner2 = parentSysSet.PayID;
            

            //交易安全检验码，由数字和字母组成的32位字符串
            key = "blsb4gy5o6tqp0byiw1gge4gx75bjqin";
            //key2 =parentSysSet.PayKey;

            //签约支付宝账号或卖家支付宝帐户
            seller_email = "sophia@968ch.com";// lomp[0].UserName;
            //seller_email2 =parentSysSet.PayMail;// lomp[0].UserName;

            string url = "http://m.968ch.com";// "http://" + System.Web.HttpContext.Current.Request.Url.Authority;
            //if (System.Web.HttpContext.Current.Request.Url.Port!=80)
            //{
            //    url += ":" + System.Web.HttpContext.Current.Request.Url.Port;
            //}
            //页面跳转同步返回页面文件路径 要用 http://格式的完整路径，不允许加?id=123这类自定义参数
            return_url = url + "/SystemModule_Alipay/SystemModule_PaySuccess.aspx";

            //System.Web.HttpContext.Current.Response.Write(return_url);
            //System.Web.HttpContext.Current.Response.End();

            //服务器通知的页面文件路径 要用 http://格式的完整路径，不允许加?id=123这类自定义参数
            notify_url = url + "/SystemModule_Alipay/SystemModule_AlipayNotify.aspx";


            //↑↑↑↑↑↑↑↑↑↑请在这里配置您的基本信息↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑



            //字符编码格式 目前支持 gbk 或 utf-8
            input_charset = "utf-8";

            //签名方式 不需修改
            sign_type = "MD5";
        }

        #region 属性
        /// <summary>
        /// 获取或设置合作者身份ID
        /// </summary>
        public   string Partner
        {
            get { return type == "1" ? partner : partner2; }
            set { partner = value; }
        }

        /// <summary>
        /// 获取或设置交易安全检验码
        /// </summary>
        public   string Key
        {
            get { return type == "1" ? key : key2; }
            set { key = value; }
        }
        /// <summary>
        /// 充值方式，1：前台用户充值  2：渠道充值
        /// </summary>
        public   string Type
        {
            get { return  type; }
            set {  type = value; }
        }

        /// <summary>
        /// 获取或设置签约支付宝账号或卖家支付宝帐户
        /// </summary>
        public   string Seller_email
        {
            get { return type == "1" ? seller_email : seller_email2 ; }
            set { seller_email = value; }
        }

        /// <summary>
        /// 获取页面跳转同步通知页面路径
        /// </summary>
        public   string Return_url
        {
            get { return return_url; }
        }

        /// <summary>
        /// 获取服务器异步通知页面路径
        /// </summary>
        public   string Notify_url
        {
            get { return notify_url; }
        }

        /// <summary>
        /// 获取字符编码格式
        /// </summary>
        public   string Input_charset
        {
            get { return input_charset; }
        }

        /// <summary>
        /// 获取签名方式
        /// </summary>
        public   string Sign_type
        {
            get { return sign_type; }
        }
        #endregion
    }
}