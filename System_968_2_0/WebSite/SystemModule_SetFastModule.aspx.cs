using Ac968.SystemModuleSetMeal.Model;
using Ac968.SystemModuleSetMeal.Utility;
using System;
using System.Linq;

public partial class SystemModule_SetFastModule : SetMealPageBase
{
    /// <summary>
    /// 当前登陆企业ID
    /// </summary>
    protected int LoginCompanyId
    {
        get
        {
            if (!string.IsNullOrEmpty(System.Configuration.ConfigurationSettings.AppSettings.Get("CompanyId")))
            {
                return Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings.Get("CompanyId"));
            }
            return Convert.ToInt32(CookiesUtil.GetCookiesValue_V2("Camel", "CenterComId"));
            //return 2;
        }
    }
    /// <summary>
    /// 当前登陆企业ID
    /// </summary>
    protected long LoginUserId
    {
        get
        {
            if (!string.IsNullOrEmpty(System.Configuration.ConfigurationSettings.AppSettings.Get("UserId")))
            {
                return Convert.ToInt64(System.Configuration.ConfigurationSettings.AppSettings.Get("UserId"));
            }
            return Convert.ToInt64(CookiesUtil.GetCookiesValue_V2("Camel", "FrameUserId"));
        }
    }

    protected CompanyFastModule[] __CompanyFastList;
    protected string __FnUrls;
    protected string __HasModuleIds;

    protected void Page_Load(object sender, EventArgs e)
    {
        Service_CompanyFastModule.CompanyFastModuleClient bll = new Service_CompanyFastModule.CompanyFastModuleClient();
        if (Request.HttpMethod.ToLower() == "post")
        {
            bll.BatchAdd(LoginCompanyId
                , LoginUserId
                , GetRequest.GetRequestValue("ModuleIds", Method.Post)
                , GetRequest.GetRequestValue("FnUrls", Method.Post)
                , GetRequest.GetRequestValue("FnNames", Method.Post)
                );
            bll.Abort();
            bll.Close();
            Success();
        }
        else
        {
            Service_CompanyModule.CompanyModuleClient cmBll = new Service_CompanyModule.CompanyModuleClient();
            __CompanyFastList = bll.ListByUser(LoginCompanyId, LoginUserId);
            V_CompanyModule[] cmList = cmBll.List(LoginCompanyId);
            Service_PublicUser.UserServiceClient puBll = new Service_PublicUser.UserServiceClient();
            Service_PublicUser.CompanyManageUser userInfo = puBll.CompanyManageGet(LoginCompanyId, LoginUserId);
            __HasModuleIds = ",";
            foreach (V_CompanyModule item in cmList)
            {
                if (userInfo.RoleTypeId != 1 && userInfo._UserPowerExLst.Where(m => m.ModuleId == item.ModuleId).ToArray().Length == 0)
                {
                    continue;
                }
                __HasModuleIds += item.ModuleId + ",";
            }
            foreach (CompanyFastModule item in __CompanyFastList)
            {
                __FnUrls += item.Url + "|";
            }

            bll.Abort();
            bll.Close();
        }
    }
}