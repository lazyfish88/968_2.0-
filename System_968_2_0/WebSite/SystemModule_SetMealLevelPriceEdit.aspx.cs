using Ac968.SystemModuleSetMeal.Model;
using Ac968.SystemModuleSetMeal.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class SystemModule_SetMealLevelPriceEdit : SetMealPageBase
{
    protected SystemModuleSetMealLevelPrice __Model = new SystemModuleSetMealLevelPrice();
    protected PlanAgentLevel[] __LevelList = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        Service_SystemModuleSetMealLevelPrice.SystemModuleSetMealLevelPriceClient bll = new Service_SystemModuleSetMealLevelPrice.SystemModuleSetMealLevelPriceClient();
        int id = GetRequest.GetInt32("id", Method.All, 0);
        if (Request.HttpMethod.ToLower() == "post")
        {
            __Model.id = id;
            __Model.LevelId = GetRequest.GetInt32("LevelId");
            __Model.Price = GetRequest.GetDecimal("Price",Method.Post,0);
            __Model.SetMealId = GetRequest.GetInt32("SetMealId");
            bll.Edit(__Model);
            bll.Abort();
            bll.Close();
            Success();
        }
        else
        {
            __Model.SetMealId = GetRequest.GetInt32("setMealId");
            if (id > 0)
            {
                __Model = bll.Info(id);
            }

            Service_PlanAgentLevel.PlanAgentLevelClient levelBll = new Service_PlanAgentLevel.PlanAgentLevelClient();
            __LevelList = levelBll.List();
            List<int> hasLevelIdArray = new List<int>();
            V_SystemModuleSetMealLevel[] levelPriceList = bll.List(__Model.SetMealId);
            foreach (V_SystemModuleSetMealLevel item in levelPriceList)
            {
                if (item.LevelId == __Model.LevelId)
                {
                    continue;
                }
                hasLevelIdArray.Add(item.LevelId);
            }
            if (hasLevelIdArray.Count>0)
            {
                int[] hasLevelIds = hasLevelIdArray.ToArray();
                //__LevelList.Where(m => !hasLevelIds.Contains<int>(m.id));
                __LevelList = __LevelList.Where(m => !hasLevelIds.Contains<int>(m.id)).ToArray();
            }
            bll.Abort();
            bll.Close();
        }
    }
}