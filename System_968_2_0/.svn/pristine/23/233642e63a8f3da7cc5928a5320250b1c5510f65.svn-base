using Ac968.SystemModuleSetMeal.Interface;
using Ac968.SystemModuleSetMeal.Model;
using Ac968.Utils.Data;
using System.Collections.Generic;
using System.ServiceModel;

namespace Ac968.SystemModuleSetMeal.ServiceBLL
{
    public class PlanAgentLevelBLL : IPlanAgentLevel
    {
        [OperationBehavior(TransactionAutoComplete = true, TransactionScopeRequired = true)]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        public void Del(int id)
        {
            new DALBase<PlanAgentLevel, DataContext>().Deletes(m => m.id == id);
        }

        [OperationBehavior(TransactionAutoComplete = true, TransactionScopeRequired = true)]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        public PlanAgentLevel Edit(PlanAgentLevel model)
        {
            DALBase<PlanAgentLevel, DataContext> bll = new DALBase<PlanAgentLevel, DataContext>();
            if (model.id == 0)
            {
                model = bll.AddReturnModel(model);
            }
            else
            {
                bll.AddOrUpdate(model);
            }
            return model;
        }

        public PlanAgentLevel Info(int id)
        {
            return new DALBase<PlanAgentLevel, DataContext>().Info(m => m.id == id);
        }

        public List<PlanAgentLevel> List()
        {
            List<PlanAgentLevel> list = new DALBase<PlanAgentLevel, DataContext>().List(null, m => m.id);
            return list;
        }
    }
}
