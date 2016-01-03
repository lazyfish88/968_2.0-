using Ac968.SystemModuleSetMeal.Model;
using System.Collections.Generic;
using System.ServiceModel;

namespace Ac968.SystemModuleSetMeal.Interface
{
    [ServiceContract]
    public interface ISystemModuleSetMealLevelPrice
    {
        [OperationContract]
        List<V_SystemModuleSetMealLevel> List(int setMealId);
        [OperationContract]
        SystemModuleSetMealLevelPrice Edit(SystemModuleSetMealLevelPrice model);
        [OperationContract]
        void Del(long id);
        [OperationContract]
        SystemModuleSetMealLevelPrice Info(long id);
        [OperationContract]
        SystemModuleSetMealLevelPrice InfoByLevel(int setMealId,int levelId);
    }
}
