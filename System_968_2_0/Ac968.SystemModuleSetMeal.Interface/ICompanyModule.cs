using Ac968.SystemModuleSetMeal.Model;
using System.Collections.Generic;
using System.ServiceModel;

namespace Ac968.SystemModuleSetMeal.Interface
{
    [ServiceContract]
    public interface ICompanyModule
    {
        [OperationContract]
        List<V_CompanyModule> List(long companyId);
        [OperationContract]
        List<V_CompanyModule> ListByDomain(string domain);

        [OperationContract]
        CompanyModule InfoByModule(long companyId,int moduleId);
        [OperationContract]
        CompanyModule Edit(CompanyModule model);
        [OperationContract]
        void Delete(long companyId);

        [OperationContract]
        int VerifyCheck(long companyId, long userId, int moduleId, int fnId);
    }
}
