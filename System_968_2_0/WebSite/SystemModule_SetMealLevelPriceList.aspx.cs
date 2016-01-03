using Ac968.SystemModuleSetMeal.Model;
using Ac968.SystemModuleSetMeal.Utility;
using System;

public partial class SystemModule_SetMealLevelPriceList : SetMealPageBase
{
    protected V_SystemModuleSetMealLevel[] list;
    protected string Pager = "";
    protected int setMealId = GetRequest.GetInt32("setMealId");

    protected void Page_Load(object sender, EventArgs e)
    {

        Service_SystemModuleSetMealLevelPrice.SystemModuleSetMealLevelPriceClient bll = new Service_SystemModuleSetMealLevelPrice.SystemModuleSetMealLevelPriceClient();
        switch (GetRequest.GetRequestValue("action"))
        {
            case "del":
                bll.Del(GetRequest.GetInt32("id"));
                bll.Abort();
                bll.Close();
                Success();
                break;
            default:
                list = bll.List(GetRequest.GetInt32("setMealId"));
                bll.Abort();
                bll.Close();
                break;
        }
    }
}