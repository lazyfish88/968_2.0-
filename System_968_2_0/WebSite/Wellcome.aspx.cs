using Ac968.SystemModuleSetMeal.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ac968.SystemModuleSetMeal.Model;

public partial class Wellcome : System.Web.UI.Page
{

    /// <summary>
    /// 当前登陆企业ID
    /// </summary>
    protected long LoginCompanyId
    {
        get
        {
            if (!string.IsNullOrEmpty(System.Configuration.ConfigurationSettings.AppSettings.Get("CompanyId")))
            {
                return Convert.ToInt64(System.Configuration.ConfigurationSettings.AppSettings.Get("CompanyId"));
            }
            return Convert.ToInt64(CookiesUtil.GetCookiesValue_V2("Camel", "CenterComId"));
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

    protected V_CompanyModule[] __ModuleList;
    protected CompanyFastModule[] __FastModuleList;
    protected string __ModuleIds = ",";

    protected void Page_Load(object sender, EventArgs e)
    {
        switch (GetRequest.GetString("Action", Method.All, ""))
        {
            case "apply":
                try
                {

                    Service_CustomApply.CustomApplyClient customBll = new Service_CustomApply.CustomApplyClient();
                    CustomApply customInfo = new CustomApply()
                    {
                        CompanyId = LoginCompanyId,
                        Remark = GetRequest.GetRequestValue("Remark", Method.Post),
                        UserName = GetRequest.GetRequestValue("Name", Method.Post),
                        Tel = GetRequest.GetRequestValue("Tel", Method.Post),
                        State = 0,
                        AddDate = DateTime.Now
                    };
                    customBll.Edit(customInfo);
                    Response.Write("ok");
                }
                catch (Exception ex)
                {
                    Response.Write(ex.ToString());
                }
                Response.End();
                break;
            default:
                Service_CompanyModule.CompanyModuleClient cmBll = new Service_CompanyModule.CompanyModuleClient();
                __ModuleList = cmBll.List(LoginCompanyId);
                __ModuleList = cmBll.ListByDomain("968xxkj");
                foreach (V_CompanyModule item in __ModuleList)
                {
                    __ModuleIds += item.ModuleId + ",";
                }
                cmBll.Abort();
                cmBll.Close();

                Service_CompanyFastModule.CompanyFastModuleClient cfmBll = new Service_CompanyFastModule.CompanyFastModuleClient();
                __FastModuleList = cfmBll.List(LoginCompanyId);
                cfmBll.Abort();
                cfmBll.Close();
                break;
        }
    }
}