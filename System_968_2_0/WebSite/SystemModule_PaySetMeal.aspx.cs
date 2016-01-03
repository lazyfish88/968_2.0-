using Ac968.SystemModuleSetMeal.Model;
using Ac968.SystemModuleSetMeal.Utility;
using System;
using System.Linq;

public partial class SystemModule_PaySetMeal : SetMealPageBase
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

    protected Service_OEMAgent.PlanAgent __PlanAgent
    {
        get
        {
            Service_OEMAgent.AgentServiceClient bll = new Service_OEMAgent.AgentServiceClient();
            Service_OEMAgent.PlanAgent info = bll.AgentGetByComId(LoginCompanyId);
            bll.Abort();
            bll.Close();
            return info;
            //return new Service_OEMAgent.AgentServiceClient().AgentGetByComId()
        }
    }
    protected SystemModuleSetMeal[] list;
    protected SystemModuleSetMealValidityLog[] __logList;
    protected bool __IsCompany= false;
    protected string Pager = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        Service_Company.CompanyServiceClient companyBll = new Service_Company.CompanyServiceClient();
        __IsCompany = companyBll.CompanyValid(LoginCompanyId);
        //Service_Company.Company
        companyBll.Abort();
        companyBll.Close();

        Service_SystemModuleSetMeal.SystemModuleSetMealClient bll = new Service_SystemModuleSetMeal.SystemModuleSetMealClient();
        switch (GetRequest.GetRequestValue("action"))
        {
            case "pay":
                string payId = GetRequest.GetRequestValue("id");
                decimal sum = 0;
                string[] payIdArr = payId.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                Service_SystemModuleSetMeal.SystemModuleSetMealClient setMealBll = new Service_SystemModuleSetMeal.SystemModuleSetMealClient();
                foreach (string item in payIdArr)
                {
                    SystemModuleSetMeal setMealInfo = setMealBll.Info(Convert.ToInt32(item));
                    if (setMealInfo ==null)
                    {
                        continue;
                    }
                    sum += setMealInfo.Price;
                }

                Service_PlanAgentOrder.PlanAgentOrderClient orderBll = new Service_PlanAgentOrder.PlanAgentOrderClient();
                PlanAgentOrder orderInfo = new PlanAgentOrder() {
                    CompanyId = LoginCompanyId,
                    Price = sum,
                    RelationId = payId,
                    Sn = string.Format("{0}{1:yyyyMMddHHmmss}", LoginCompanyId, DateTime.Now),
                    State = 0,
                    Type = 1
                };
                orderBll.Add(orderInfo);
                orderBll.Abort();
                orderBll.Close();
                Response.Redirect("SystemModule_GoPay.aspx?sn="+orderInfo.Sn);
                break;
            default:
                int page = GetRequest.GetInt32("page");
                int pageSize = 20;
                int record = 0;
                list = bll.ListByEnable(true, page, pageSize, out record);
                Service_SystemModuleSetMealLevelPrice.SystemModuleSetMealLevelPriceClient levelBll = new Service_SystemModuleSetMealLevelPrice.SystemModuleSetMealLevelPriceClient();
                foreach (SystemModuleSetMeal item in list)
                {
                    SystemModuleSetMealLevelPrice levelPriceInfo = levelBll.InfoByLevel(item.id, __PlanAgent.LevelId==null?0:((int)__PlanAgent.LevelId));
                    if (levelPriceInfo!=null)
                    {
                        item.Price = levelPriceInfo.Price;
                    }
                }
                Service_SystemModuleSetMealDetail.SystemModuleSetMealDetailClient setMealDetialBll = new Service_SystemModuleSetMealDetail.SystemModuleSetMealDetailClient();
                Service_SystemModuleSetMealValidityLog.SystemModuleSetMealValidityLogClient logBll = new Service_SystemModuleSetMealValidityLog.SystemModuleSetMealValidityLogClient();
                __logList = logBll.ListByCompany(LoginCompanyId);
                foreach (SystemModuleSetMeal item in list)
                {
                    item.ModuleList = setMealDetialBll.List(item.id);
                    SystemModuleSetMealValidityLog[] currentLog = __logList.Where(m => m.SetMealId == item.id).ToArray();
                    if (currentLog.Length>0)//已购买
                    {
                        if (currentLog.Where(m=>m.ValidityDateEnd>DateTime.Now).ToArray().Length>0)//未过期
                        {
                            item.OverDate = currentLog.Where(m => m.ValidityDateEnd > DateTime.Now).OrderByDescending(m => m.ValidityDateEnd).ToArray()[0].ValidityDateEnd;
                            item.CompanyState = 0;
                        }
                        else//已过期
                        {
                            item.OverDate = currentLog.OrderByDescending(m => m.ValidityDateEnd).ToArray()[0].ValidityDateEnd;
                            item.CompanyState = 1;
                        }
                    }
                    else
                    {
                        item.CompanyState = -1;
                    }
                }
                levelBll.Abort();
                levelBll.Close();
                Pager = InitPageView(page, record);
                bll.Abort();
                bll.Close();
                break;
        }
    }
}