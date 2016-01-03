using System;
using System.Collections.Generic;
using Ac968.SystemModuleSetMeal.Interface;
using Ac968.SystemModuleSetMeal.Model;
using Ac968.Utils.Data;
using System.Linq.Expressions;
using System.ServiceModel;

namespace Ac968.SystemModuleSetMeal.ServiceBLL
{
    public class SystemModuleSetMealDetailBLL : ISystemModuleSetMealDetail
    {
        public List<V_SystemModuleSetMealDetail> List(int setmealId)
        {
            Expression<Func<V_SystemModuleSetMealDetail, bool>> condition = m=>m.SystemModuleSetMealId == setmealId;
            List<V_SystemModuleSetMealDetail> list = new DALBase<V_SystemModuleSetMealDetail, DataContext>().List(condition, m => m.id);
            return list;
        }
        [OperationBehavior(TransactionAutoComplete = true, TransactionScopeRequired = true)]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        public void Del(int id)
        {
            new DALBase<SystemModuleSetMealDetail, DataContext>().Deletes(m => m.id == id);
        }

        [OperationBehavior(TransactionAutoComplete = true, TransactionScopeRequired = true)]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        public SystemModuleSetMealDetail Edit(SystemModuleSetMealDetail model)
        {
            DALBase<SystemModuleSetMealDetail, DataContext> bll = new DALBase<SystemModuleSetMealDetail, DataContext>();
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

        public SystemModuleSetMealDetail Info(int id)
        {
            return new DALBase<SystemModuleSetMealDetail, DataContext>().Info(m => m.id == id);
        }
    }
}
