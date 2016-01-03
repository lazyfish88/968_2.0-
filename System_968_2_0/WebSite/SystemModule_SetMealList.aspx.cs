using Ac968.SystemModuleSetMeal.Model;
using Ac968.SystemModuleSetMeal.Utility;
using System;

public partial class SystemModule_SetMealList : SetMealPageBase
{
    protected SystemModuleSetMeal[] list;
    protected string Pager = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        Service_SystemModuleSetMeal.SystemModuleSetMealClient bll = new Service_SystemModuleSetMeal.SystemModuleSetMealClient();
        switch (GetRequest.GetRequestValue("action"))
        {
            case "del":
                bll.Del(GetRequest.GetInt32("id"));
                bll.Abort();
                bll.Close();
                Success();
                break;
            default:
                int page = GetRequest.GetInt32("page");
                int pageSize = 20;
                int record = 0;
                list = bll.List(page, pageSize, out record);
                Pager = InitPageView(page, record);
                bll.Abort();
                bll.Close();
                break;
        }
    }
}