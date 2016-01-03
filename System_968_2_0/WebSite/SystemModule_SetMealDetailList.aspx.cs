using Ac968.SystemModuleSetMeal.Model;
using Ac968.SystemModuleSetMeal.Utility;
using System;

public partial class SystemModule_SetMealDetailList : SetMealPageBase
{
    protected V_SystemModuleSetMealDetail[] list;
    protected string Pager = "";
    protected int setMealId = GetRequest.GetInt32("setMealId");

    protected void Page_Load(object sender, EventArgs e)
    {
        Service_SystemModuleSetMealDetail.SystemModuleSetMealDetailClient bll = new Service_SystemModuleSetMealDetail.SystemModuleSetMealDetailClient();
        switch (GetRequest.GetRequestValue("action"))
        {
            case "del":
                bll.Del(GetRequest.GetInt32("id"));
                bll.Abort();
                bll.Close();
                Success();
                break; 
            default:
                list = bll.List(setMealId);
                bll.Abort();
                bll.Close();
                break;
        }
    }
}