using Ac968.SystemModuleSetMeal.Model;
using Ac968.SystemModuleSetMeal.Utility;
using System;

public partial class SystemModule_PlanAgentLevelEdit : SetMealPageBase
{
    protected PlanAgentLevel __Model = new PlanAgentLevel();

    protected void Page_Load(object sender, EventArgs e)
    {
        Service_PlanAgentLevel.PlanAgentLevelClient bll = new Service_PlanAgentLevel.PlanAgentLevelClient();
        int id = GetRequest.GetInt32("id", Method.All, 0);
        if (Request.HttpMethod.ToLower() == "post")
        {
            __Model.id = id;
            __Model.Name = GetRequest.GetRequestValue("Name", Method.Post);
            bll.Edit(__Model);
            bll.Abort();
            bll.Close();
            Success();
        }
        else
        {
            if (id>0)
            {
                __Model = bll.Info(id);
                bll.Abort();
                bll.Close();
            }
        }
    }
}