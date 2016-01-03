using Ac968.SystemModuleSetMeal.Model;
using Ac968.SystemModuleSetMeal.Utility;
using Ac968.SystemModuleSetMeal.Utility.Alipay;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

public partial class SystemModule_Alipay_SystemModule_PaySuccess : SetMealPageBase
{
    protected SystemModuleSetMeal[] __SetMealList;
    protected List<V_SystemModuleSetMealDetail> __ModuleList = new List<V_SystemModuleSetMealDetail>();
    protected PlanAgentOrder __OrderInfo = new PlanAgentOrder();
    protected string __SetMealNames = "";
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

    protected void Page_Load(object sender, EventArgs e)
    {
        SortedDictionary<string, string> sPara = GetRequestGet();
        string types = "1", sn = "";
        if (sPara.Count > 0)//判断是否有带返回参数
        {
            //BLL.Recharge bll = new BLL.Recharge();
            //BLL.Users userBll = new BLL.Users();
            string order_no = Request.QueryString["out_trade_no"];          //获取订单号

            //Model.Recharge info = bll.GetModel("Sn='" + order_no + "'");
            //if (info != null)
            //{
            //    RechType = info.RechType;//用来区分的
            //    types = (RechType == 0 ? "1" : "2");
            //    sn = info.Sn;
            //}
            Notify aliNotify = new Notify(types);
            Service_PlanAgentOrder.PlanAgentOrderClient bll = new Service_PlanAgentOrder.PlanAgentOrderClient();
            __OrderInfo = bll.Info(0, order_no);
            bool verifyResult = aliNotify.Verify(sPara, Request.QueryString["notify_id"], Request.QueryString["sign"]);
            Service_SystemModuleSetMeal.SystemModuleSetMealClient setMealBLL = new Service_SystemModuleSetMeal.SystemModuleSetMealClient();
            Service_SystemModuleSetMealDetail.SystemModuleSetMealDetailClient setMealDetailBll = new Service_SystemModuleSetMealDetail.SystemModuleSetMealDetailClient();
            __SetMealList = setMealBLL.ListByIds(__OrderInfo.RelationId);
            foreach (SystemModuleSetMeal item in __SetMealList)
            {
                V_SystemModuleSetMealDetail[] moduleList = setMealDetailBll.List(item.id);
                foreach (V_SystemModuleSetMealDetail moduleItem in moduleList)
                {
                    moduleItem.Day = item.Day;
                    if (__ModuleList.Where(m => m.SystemModuleId == moduleItem.SystemModuleId).ToArray().Length > 0)
                    {
                        __ModuleList.Where(m => m.SystemModuleId == moduleItem.SystemModuleId).ToArray()[0].Day += moduleItem.Day;
                    }
                    else
                    {
                        __ModuleList.Add(moduleItem);
                    }
                }
                __SetMealNames += item.Name + "，";
            }

            if (verifyResult && __OrderInfo.State == 0)//验证成功
            {
                if (__OrderInfo.Type == 1)
                {
                    string[] setMealIdArr = __OrderInfo.RelationId.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    Service_Message.MessageClient msgBll = new Service_Message.MessageClient();
                    Service_SystemModuleSetMealValidityLog.SystemModuleSetMealValidityLogClient logBll = new Service_SystemModuleSetMealValidityLog.SystemModuleSetMealValidityLogClient();
                    foreach (string idItem in setMealIdArr)
                    {
                        string moduleIds = "", moduleNames = "";
                        SystemModuleSetMeal setMealInfo = setMealBLL.Info(Convert.ToInt32(idItem));
                        V_SystemModuleSetMealDetail[] detailList = setMealDetailBll.List(setMealInfo.id);
                        Service_CompanyModule.CompanyModuleClient companyModuleBll = new Service_CompanyModule.CompanyModuleClient();
                        foreach (V_SystemModuleSetMealDetail item in detailList)
                        {
                            CompanyModule moduleInfo = companyModuleBll.InfoByModule(__OrderInfo.CompanyId, item.SystemModuleId);
                            moduleNames += Enum.GetName(typeof(ModuleType), item.SystemModuleId) + "，";
                            moduleIds += moduleInfo.id + ",";
                            if (moduleInfo == null)
                            {
                                moduleInfo = new CompanyModule()
                                {
                                    CompanyId = __OrderInfo.CompanyId,
                                    ModuleId = item.SystemModuleId,
                                    ValidityDateStart = DateTime.Now,
                                    ValidityDateEnd = DateTime.Now.AddDays(setMealInfo.Day)
                                };
                            }
                            else
                            {
                                if (moduleInfo.ValidityDateEnd.CompareTo(DateTime.Now) == -1)//已过期
                                {
                                    moduleInfo.ValidityDateStart = DateTime.Now;
                                    moduleInfo.ValidityDateEnd = DateTime.Now.AddDays(setMealInfo.Day);
                                }
                                else
                                {
                                    if (moduleInfo.ValidityDateEnd.CompareTo(DateTime.Now.AddDays(setMealInfo.Day)) == -1)
                                    {
                                        moduleInfo.ValidityDateEnd = DateTime.Now.AddDays(setMealInfo.Day);
                                    }
                                }
                            }
                            companyModuleBll.Edit(moduleInfo);
                        }
                        logBll.Add(new SystemModuleSetMealValidityLog()
                        {
                            CompanyId = __OrderInfo.CompanyId,
                            ModuleIds = moduleIds,
                            OrderId = __OrderInfo.id,
                            ModuleNames = moduleNames,
                            SetMealName = setMealInfo.Name,
                            SetMealId = setMealInfo.id,
                            ValidityDateEnd = DateTime.Now.AddDays(setMealInfo.Day),
                            ValidityDateStart = DateTime.Now
                        });
                        msgBll.AddSystemMessage(LoginUserId, "套餐购买", string.Format("成功购买{0}套餐", __SetMealNames.TrimEnd('，')));
                    }
                    logBll.Abort();
                    logBll.Close();
                }
                bll.UpdateState(__OrderInfo.Sn, 1);
            }
            setMealBLL.Abort();
            setMealBLL.Close();
        }
    }


    /// <summary>
    /// 获取支付宝GET过来通知消息，并以“参数名=参数值”的形式组成数组
    /// </summary>
    /// <returns>request回来的信息组成的数组</returns>
    public SortedDictionary<string, string> GetRequestGet()
    {
        int i = 0;
        SortedDictionary<string, string> sArray = new SortedDictionary<string, string>();
        NameValueCollection coll;
        //Load Form variables into NameValueCollection variable.
        coll = Request.QueryString;

        // Get names of all forms into a string array.
        String[] requestItem = coll.AllKeys;

        for (i = 0; i < requestItem.Length; i++)
        {
            sArray.Add(requestItem[i], Request.QueryString[requestItem[i]]);
        }

        return sArray;
    }
}