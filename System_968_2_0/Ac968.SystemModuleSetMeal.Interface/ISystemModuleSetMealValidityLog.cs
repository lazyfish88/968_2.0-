using Ac968.SystemModuleSetMeal.Model;
using System.Collections.Generic;
using System.ServiceModel;

namespace Ac968.SystemModuleSetMeal.Interface
{
    [ServiceContract]
    public interface ISystemModuleSetMealValidityLog
    {
        [OperationContract]
        List<SystemModuleSetMealValidityLog> ListByCompany(long companyId);
        [OperationContract]
        List<SystemModuleSetMealValidityLog> ListByOrder(long orderId);
        [OperationContract]
        SystemModuleSetMealValidityLog Add(SystemModuleSetMealValidityLog model);
    }
}
