using Ac968.SystemModuleSetMeal.Interface;
using Ac968.SystemModuleSetMeal.Model;
using Ac968.Utils.Data;
using System.Collections.Generic;

namespace Ac968.SystemModuleSetMeal.ServiceBLL
{
    public class SystemModuleSetMealValidityLogBLL : ISystemModuleSetMealValidityLog
    {
        public SystemModuleSetMealValidityLog Add(SystemModuleSetMealValidityLog model)
        {
            DALBase<SystemModuleSetMealValidityLog, DataContext> bll = new DALBase<SystemModuleSetMealValidityLog, DataContext>();
            model = bll.AddReturnModel(model);
            return model;
        }

        public List<SystemModuleSetMealValidityLog> ListByCompany(long companyId)
        {
            List<SystemModuleSetMealValidityLog> list = new DALBase<SystemModuleSetMealValidityLog, DataContext>().List(m => m.CompanyId == companyId, m => m.id);
            return list;
        }

        public List<SystemModuleSetMealValidityLog> ListByOrder(long orderId)
        {
            List<SystemModuleSetMealValidityLog> list = new DALBase<SystemModuleSetMealValidityLog, DataContext>().List(m => m.OrderId == orderId, m => m.id);
            return list;
        }
    }
}
