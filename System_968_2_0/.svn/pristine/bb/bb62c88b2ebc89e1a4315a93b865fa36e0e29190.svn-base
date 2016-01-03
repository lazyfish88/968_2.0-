using Ac968.SystemModuleSetMeal.Model;
using System.Collections.Generic;
using System.ServiceModel;

namespace Ac968.SystemModuleSetMeal.Interface
{
    [ServiceContract]
    public interface IPlanAgentLevel
    {
        [OperationContract]
        List<PlanAgentLevel> List();
        [OperationContract]
        PlanAgentLevel Edit(PlanAgentLevel model);
        [OperationContract]
        void Del(int id);
        [OperationContract]
        PlanAgentLevel Info(int id);
    }
}
