using Ac968.SystemModuleSetMeal.Model;
using Ac968.SystemModuleSetMeal.Utility;
using System;

public partial class SystemModule_PlanAgentLevelList : SetMealPageBase
{
    protected PlanAgentLevel[] list;
    protected string Pager = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        Service_PlanAgentLevel.PlanAgentLevelClient bll = new Service_PlanAgentLevel.PlanAgentLevelClient();
        switch (GetRequest.GetRequestValue("action"))
        {
            case "del":
                bll.Del(GetRequest.GetInt32("id"));
                bll.Abort();
                bll.Close();
                Success();
                break;
            default:
                list = bll.List();
                bll.Abort();
                bll.Close();
                break;
        }
    }
}