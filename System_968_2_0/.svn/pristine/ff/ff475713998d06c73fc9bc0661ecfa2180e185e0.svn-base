using Ac968.SystemModuleSetMeal.Model;
using Ac968.SystemModuleSetMeal.Utility;
using System;

public partial class SystemModule_SystemModuleList : SetMealPageBase
{
    protected SystemModule[] list;

    protected void Page_Load(object sender, EventArgs e)
    {
        Service_SystemModule.SystemModuleClient bll = new Service_SystemModule.SystemModuleClient();
        switch (GetRequest.GetRequestValue("action"))
        {
            case "UpdateDefault":
                bll.SetDefault(GetRequest.GetInt32("id"), GetRequest.GetInt32("isDefault") == 1);
                bll.Abort();
                bll.Close();
                Success();
                break;
            case "UpdateType":
                bll.SetNeedCompany(GetRequest.GetInt32("id"), GetRequest.GetInt32("needCompany") == 1);
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