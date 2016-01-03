using Ac968.SystemModuleSetMeal.Model;
using System.Collections.Generic;
using System.ServiceModel;

namespace Ac968.SystemModuleSetMeal.Interface
{
    [ServiceContract]
    public interface IPlanAgentOrder
    {
        [OperationContract]
        List<PlanAgentOrder> List(long companyId,int state, int pageIndex, out int record, int pageSize = 20);
        [OperationContract]
        void Add(PlanAgentOrder model);
        [OperationContract]
        void UpdateState(string sn, int state);
        [OperationContract]
        PlanAgentOrder Info(long id, string sn);
    }
}
