using Ac968.SystemModuleSetMeal.Model;
using Ac968.SystemModuleSetMeal.Utility;
using System;

public partial class SystemModule_SetMealDetail : SetMealPageBase
{
    protected SystemModule[] __ModuleList;
    protected SystemModuleSetMeal __SetMeal = new SystemModuleSetMeal();
    protected V_SystemModuleSetMealDetail[] __SetMealDetail = null;
    protected string __setMealIds = ",";

    protected void Page_Load(object sender, EventArgs e)
    {
        int id = GetRequest.GetInt32("id", Method.All, 0);
        if (Request.HttpMethod.ToLower() == "post")
        {
            Service_SystemModuleSetMeal.SystemModuleSetMealClient bll = new Service_SystemModuleSetMeal.SystemModuleSetMealClient();
            if (id > 0)
            {
                __SetMeal = bll.Info(id);
            }
            else
            {
                __SetMeal.AddDate = DateTime.Now;
            }
            __SetMeal.Enable = GetRequest.GetRequestValue("Enable", Method.Post) == "1";
            __SetMeal.Name = GetRequest.GetRequestValue("Name", Method.Post);
            __SetMeal.Day = GetRequest.GetInt32("Day", Method.Post,0);
            __SetMeal.Price = GetRequest.GetDecimal("Price", Method.Post, 0);
            bll.Edit(__SetMeal,GetRequest.GetRequestValue("Module"));
            Response.Write("ok");
            Response.End();
        }
        else
        {
            Service_SystemModule.SystemModuleClient moduleBll = new Service_SystemModule.SystemModuleClient();
            __ModuleList = moduleBll.List();
            if (id > 0)
            {
                Service_SystemModuleSetMeal.SystemModuleSetMealClient setMealBll = new Service_SystemModuleSetMeal.SystemModuleSetMealClient();
                Service_SystemModuleSetMealDetail.SystemModuleSetMealDetailClient setMealDetailBll = new Service_SystemModuleSetMealDetail.SystemModuleSetMealDetailClient();
                __SetMeal = setMealBll.Info(id);
                __SetMealDetail = setMealDetailBll.List(id);
                foreach (V_SystemModuleSetMealDetail item in __SetMealDetail)
                {
                    __setMealIds += item.SystemModuleId + ",";
                }
                setMealBll.Abort();
                setMealBll.Close();
                setMealDetailBll.Abort();
                setMealDetailBll.Close();
            }
            moduleBll.Abort();
            moduleBll.Close();
        }
    }
}