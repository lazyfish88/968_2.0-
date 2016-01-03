using Ac968.SystemModuleSetMeal.Model;
using System.Collections.Generic;
using System.ServiceModel;

namespace Ac968.SystemModuleSetMeal.Interface
{
    [ServiceContract]
    public interface ISystemModuleSetMeal
    {
        [OperationContract]
        List<Model.SystemModuleSetMeal> List(int pageIndex, out int record, int pageSize = 20);
        [OperationContract]
        List<Model.SystemModuleSetMeal> ListByIds(string ids);
        [OperationContract]
        List<Model.SystemModuleSetMeal> ListByEnable(bool enable, int pageIndex, out int record, int pageSize = 20);
        [OperationContract]
        Model.SystemModuleSetMeal Edit(Model.SystemModuleSetMeal model,string moduleIds);
        [OperationContract]
        void Del(int id);
        [OperationContract]
        Model.SystemModuleSetMeal Info(int id);
    }
}
