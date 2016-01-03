using Ac968.SystemModuleSetMeal.Model;
using System.Collections.Generic;
using System.ServiceModel;

namespace Ac968.SystemModuleSetMeal.Interface
{
    [ServiceContract]
    public interface ISystemModule
    {
        [OperationContract]
        List<SystemModule> List();
        [OperationContract]
        List<SystemModule> ListByCompany(long companyId, string domain, long userId);
        [OperationContract]
        void SetDefault(int id, bool isDefault);
        [OperationContract]
        void SetNeedCompany(int id, bool needCompany);
    }
}
