using Ac968.SystemModuleSetMeal.Model;
using Ac968.SystemModuleSetMeal.Utility;
using System;
using System.Linq;

public partial class SystemModule_SetMealDetailEdit : SetMealPageBase
{
    protected SystemModuleSetMealDetail __Model = new SystemModuleSetMealDetail();
    protected int setMealId = GetRequest.GetInt32("setMealId");
    protected SystemModule[] __ModuleList = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        int id = GetRequest.GetInt32("id",Method.All,0);
        Service_SystemModuleSetMealDetail.SystemModuleSetMealDetailClient bll = new Service_SystemModuleSetMealDetail.SystemModuleSetMealDetailClient();
        if (Request.HttpMethod.ToLower() == "post")
        {
            if (id>0)
            {
                __Model = bll.Info(id);
            }
            else
            {
                __Model.SystemModuleSetMealId = GetRequest.GetInt32("SystemModuleSetMealId", Method.All, 0);
            }
            __Model.Day = GetRequest.GetInt32("Day", Method.All, 0);
            __Model.SystemModuleId = GetRequest.GetInt32("Module", Method.All, 0);
            bll.Edit(__Model);
            Success();
        }
        else
        {
            if (id > 0)
            {
                __Model = bll.Info(id);
            }
            else
            {
                __Model.SystemModuleSetMealId = setMealId;
            }
            Service_SystemModule.SystemModuleClient moduleBll = new Service_SystemModule.SystemModuleClient();
            __ModuleList = moduleBll.List();
            Service_SystemModuleSetMealDetail.SystemModuleSetMealDetailClient setMealDetailBll = new Service_SystemModuleSetMealDetail.SystemModuleSetMealDetailClient();
            V_SystemModuleSetMealDetail[] setMealModuleList = setMealDetailBll.List(setMealId);
            string setMealModuleIds = ",";
            foreach (V_SystemModuleSetMealDetail item in setMealModuleList)
            {
                if (item.SystemModuleId == __Model.SystemModuleId)
                {
                    continue;
                }
                setMealModuleIds += item.SystemModuleId + ",";
            }
            __ModuleList = __ModuleList.Where(m => !setMealModuleIds.Contains("," + m.id + ",")).ToArray();
        }

    }
}