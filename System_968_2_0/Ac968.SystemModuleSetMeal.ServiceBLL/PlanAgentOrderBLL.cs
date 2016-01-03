using Ac968.SystemModuleSetMeal.Interface;
using Ac968.SystemModuleSetMeal.Model;
using Ac968.Utils.Data;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ServiceModel;

namespace Ac968.SystemModuleSetMeal.ServiceBLL
{
    public class PlanAgentOrderBLL : IPlanAgentOrder
    {
        [OperationBehavior(TransactionAutoComplete = true, TransactionScopeRequired = true)]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        public void Add(PlanAgentOrder model)
        {
            model.AddDate = DateTime.Now;
            new DALBase<PlanAgentOrder, DataContext>().Add(model);
        }

        public PlanAgentOrder Info(long id, string sn)
        {
            Expression<Func<PlanAgentOrder, bool>> condition = m => m.id == id;
            if (!string.IsNullOrEmpty(sn))
            {
                condition = m => m.Sn == sn;
            }

            return new DALBase<PlanAgentOrder, DataContext>().Info(condition);
        }

        public List<PlanAgentOrder> List(long companyId, int state, int pageIndex, out int record, int pageSize = 20)
        {
            Expression<Func<PlanAgentOrder, bool>> condition = m => m.CompanyId == companyId;
            if (state!=-1)
            {
                condition = m => m.CompanyId == companyId && m.State == state;
            }
            List<PlanAgentOrder> list = new DALBase<PlanAgentOrder, DataContext>().List(condition, m => m.id, pageIndex, pageSize, out record);

            DALBase<SystemModuleSetMealValidityLog, DataContext> logBll = new DALBase<SystemModuleSetMealValidityLog, DataContext>();
            foreach (PlanAgentOrder item in list)
            {
                item.OrderContent = string.Empty;
                List<SystemModuleSetMealValidityLog> logList = logBll.List(m => m.OrderId == item.id, m => m.id);
                foreach (SystemModuleSetMealValidityLog logItem in logList)
                {
                    item.OrderContent += string.Format("{0}(含模块：{1})，有效期至{2:yyyy-MM-dd HH:mm}<br/>"
                        ,logItem.SetMealName,logItem.ModuleNames,logItem.ValidityDateEnd);
                }
            }
            return list;
        }

        [OperationBehavior(TransactionAutoComplete = true, TransactionScopeRequired = true)]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        public void UpdateState(string sn, int state)
        {
            Expression<Func<PlanAgentOrder, bool>> filter = m => m.Sn == sn;
            Expression<Func<PlanAgentOrder, PlanAgentOrder>> update = m => new PlanAgentOrder { State = state };
            new DALBase<PlanAgentOrder, DataContext>().Update(filter, update);
        }
    }
}
