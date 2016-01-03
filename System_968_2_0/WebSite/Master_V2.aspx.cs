using Ac968.SystemModuleSetMeal.Model;
using Ac968.SystemModuleSetMeal.Utility;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

public partial class Master_V2 : System.Web.UI.Page
{
    protected V_CompanyModule[] __list;
    protected SystemModule[] __AllList;
    protected CompanyFastModule[] __FastModule;
    protected List<SystemModule> __OpenModule_1 = new List<SystemModule>();
    protected List<SystemModule> __OpenModule_2 = new List<SystemModule>();
    protected List<SystemModule> __OpenModule_3 = new List<SystemModule>();
    protected List<SystemModule> __NotOpenModule_1 = new List<SystemModule>();
    protected List<SystemModule> __NotOpenModule_2 = new List<SystemModule>();
    protected List<SystemModule> __NotOpenModule_3 = new List<SystemModule>();
    protected Service_OEMAgent.PlanAgent __OEMInfo;
    protected Service_Company.Company __Company = new Service_Company.Company();
    protected string __companyModuleIds = ",";
    protected bool __IsCompany = false;
    protected Service_PublicUser.CompanyManageUser __userInfo;
    protected bool __HasMoreCompany = false;
    /// <summary>
    /// 当前登陆企业ID
    /// </summary>
    protected long LoginCompanyId
    {
        get
        {
            try
            {
                if (!string.IsNullOrEmpty(System.Configuration.ConfigurationSettings.AppSettings.Get("CompanyId")))
                {
                    return Convert.ToInt64(System.Configuration.ConfigurationSettings.AppSettings.Get("CompanyId"));
                }
                return Convert.ToInt64(CookiesUtil.GetCookiesValue_V2("Camel", "CenterComId"));
            }
            catch
            {
                Response.Redirect("http://m.968ch.com/admin/login.aspx");
                return 0;
            }
        }
    }
    /// <summary>
    /// 当前登陆企业ID
    /// </summary>
    protected long LoginUserId
    {
        get
        {
            try
            {
                if (!string.IsNullOrEmpty(System.Configuration.ConfigurationSettings.AppSettings.Get("UserId")))
                {
                    return Convert.ToInt64(System.Configuration.ConfigurationSettings.AppSettings.Get("UserId"));
                }
                return Convert.ToInt64(CookiesUtil.GetCookiesValue_V2("Camel", "FrameUserId"));
            }
            catch
            {
                Response.Redirect("http://m.968ch.com/admin/login.aspx");
                return 0;
            }
        }
    }

    protected override void OnError(EventArgs e)
    {
        Exception ex = Server.GetLastError();
        Response.Write(ex.ToString());
    }

    protected string GetModuleName(int moduleId)
    {
        return Enum.GetName(typeof(ModuleType), moduleId);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        switch (GetRequest.GetRequestValue("action"))
        {
            case "HasNewMsg":
                NameValueCollection Pars = new NameValueCollection();
                Pars.Add("LoginUserId", LoginUserId.ToString());
                Response.Write(GetHTML("http://person.968ch.com/Message/HasNew", Pars, Method.Get));
                Response.End();
                return;
            default:
                break;
        }

        try
        {

            Service_CompanyFastModule.CompanyFastModuleClient fastModuleBll = new Service_CompanyFastModule.CompanyFastModuleClient();
            __FastModule = fastModuleBll.ListByUser(LoginCompanyId, LoginUserId).OrderBy(m => m.ModuleId).ToArray();
            fastModuleBll.Abort();
            fastModuleBll.Close();
            Service_OEMAgent.AgentServiceClient oemBll = new Service_OEMAgent.AgentServiceClient();
            __OEMInfo = oemBll.AgentGetByComId(LoginCompanyId);
            Service_SystemModule.SystemModuleClient systemModuleBll = new Service_SystemModule.SystemModuleClient();
            __AllList = systemModuleBll.ListByCompany(LoginCompanyId, "", LoginUserId).OrderBy(m => m.OrderBy).ToArray();
            systemModuleBll.Abort();
            systemModuleBll.Close();
            Service_Company.CompanyServiceClient companyBll = new Service_Company.CompanyServiceClient();
            __Company = companyBll.GetCompany(LoginCompanyId);
            __IsCompany = companyBll.CompanyValid(LoginCompanyId);
            companyBll.Abort();
            companyBll.Close();
            Service_PublicUser.UserServiceClient puBll = new Service_PublicUser.UserServiceClient();
            __userInfo = puBll.CompanyManageGet(LoginCompanyId, LoginUserId);
            __HasMoreCompany = puBll.CompanyManageListAll(LoginUserId).Length > 1;
            puBll.Abort();
            puBll.Close();
            if (__userInfo == null)
            {
                Response.Redirect("http://m.968ch.com/admin/login.aspx");
                return;
            }

            if (__AllList != null)
            {
                foreach (SystemModule item in __AllList)
                {
                    if (item.State == 3//未购买
                        || (__userInfo.RoleTypeId != 1 && __userInfo._UserPowerExLst.Where(m => m.ModuleId == item.id).ToArray().Length == 0)//无操作权限
                            )
                    {
                        continue;
                    }

                    if (item.State == 0)
                    {
                        switch (item.Type)
                        {
                            case 1:
                                __OpenModule_1.Add(item);
                                break;
                            case 2:
                                __OpenModule_2.Add(item);
                                break;
                            case 3:
                                __OpenModule_3.Add(item);
                                break;
                            default:
                                break;
                        }
                    }
                    else if (__userInfo.RoleTypeId == 1)
                    {
                        switch (item.Type)
                        {
                            case 1:
                                __NotOpenModule_1.Add(item);
                                break;
                            case 2:
                                __NotOpenModule_2.Add(item);
                                break;
                            case 3:
                                __NotOpenModule_3.Add(item);
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
            oemBll.Abort();
            oemBll.Close();

        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }

    /// <summary>
    /// 获取远程文本内容
    /// </summary>
    /// <param name="GetUrl">获取地址，如http://www.abc.com/1.aspx</param>
    /// <param name="Pars">参数集合</param>
    /// <param name="m">读取行为，POST或者GET</param>
    /// <param name="CharSet">字符集，utf-8、gb2312、gbk等</param>
    /// <returns></returns>
    public static string GetHTML(string GetUrl, NameValueCollection Pars, Method m)
    {
        try
        {
            Encoding CharSet = Encoding.UTF8;
            WebClient w = new WebClient();
            string BackStr = "";
            if (m == Method.Post)
            {
                byte[] byRemoteInfo = w.UploadValues(GetUrl, m.ToString().ToUpper(), Pars);
                BackStr = CharSet.GetString(byRemoteInfo);
            }
            else
            {
                w.Encoding = CharSet;
                string UrlData = "";
                foreach (string key in Pars)
                {
                    string[] values = Pars.GetValues(key);
                    foreach (string v in values)
                    {

                        UrlData += key + "=" + HttpUtility.UrlEncode(v).Replace("+", "%20") + "&";
                    }
                }
                UrlData = UrlData.Trim('&');
                GetUrl = GetUrl.Contains("?") ? GetUrl + "&" + UrlData : GetUrl + "?" + UrlData;
                BackStr = w.DownloadString(GetUrl);
            }
            return BackStr;
        }
        catch (Exception e)
        {
            return e.ToString();
        }
    }

}
