using Ac968.SystemModuleSetMeal.Model;
using System.Collections.Generic;
using System.ServiceModel;

namespace Ac968.SystemModuleSetMeal.Interface
{
    [ServiceContract]
    public interface ISystemModuleSetMealDetail
    {
        [OperationContract]
        List<V_SystemModuleSetMealDetail> List(int setmealId);
        [OperationContract]
        SystemModuleSetMealDetail Edit(SystemModuleSetMealDetail model);
        [OperationContract]
        void Del(int id);
        [OperationContract]
        SystemModuleSetMealDetail Info(int id);
    }
}
