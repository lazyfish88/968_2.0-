using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ac968.SystemModuleSetMeal.Model;

public partial class SetCompanyModule : System.Web.UI.Page
{
    protected List<V_CompanyModule> __CompanyModuleList;
    protected SystemModule[] __ModuleList;

    protected long CompanyId
    {
        get
        {
            if (string.IsNullOrEmpty(Request["CompanyId"]))
            {
                return 0;
            }
            return Convert.ToInt64(Request["CompanyId"]);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.HttpMethod.ToLower() == "post")
        {
            Service_CompanyModule.CompanyModuleClient cmBll = new Service_CompanyModule.CompanyModuleClient();
            cmBll.Delete(CompanyId);
            string[] moduleIdsArr = Request.Form["module"].Split(new char[] { ','},StringSplitOptions.RemoveEmptyEntries);
            foreach (string item in moduleIdsArr)
            {
                cmBll.Edit(new CompanyModule()
                {
                    CompanyId = CompanyId,
                    ModuleId = Convert.ToInt32(item),
                    ValidityDateEnd = DateTime.MaxValue,
                    ValidityDateStart = DateTime.Now.AddDays(-1)
                });
            }
            
            cmBll.Abort();
            cmBll.Close();
            Response.Redirect("SetCompanyModule.aspx");
        }
        else
        {
            Service_SystemModule.SystemModuleClient moduleBll = new Service_SystemModule.SystemModuleClient();
            __ModuleList = moduleBll.List();
            moduleBll.Abort();
            moduleBll.Close();
        }
    }
}