using Ac968.SystemModuleSetMeal.Model;
using Ac968.SystemModuleSetMeal.Utility;
using System;

public partial class CustomDevList : SetMealPageBase
{
    protected CustomApply[] list;
    protected string Pager = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        Service_CustomApply.CustomApplyClient bll = new Service_CustomApply.CustomApplyClient();
        switch (GetRequest.GetRequestValue("action"))
        {
            case "update":
                bll.UpdateState(GetRequest.GetInt32("id"),GetRequest.GetInt32("state"));
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