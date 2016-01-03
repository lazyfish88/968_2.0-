using Ac968.SystemModuleSetMeal.Interface;
using Ac968.SystemModuleSetMeal.Model;
using Ac968.Utils.Data;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ServiceModel;

namespace Ac968.SystemModuleSetMeal.ServiceBLL
{
    public class SystemModuleSetMealLevelPriceBLL : ISystemModuleSetMealLevelPrice
    {
        [OperationBehavior(TransactionAutoComplete = true, TransactionScopeRequired = true)]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        public void Del(long id)
        {
            new DALBase<SystemModuleSetMealDetail, DataContext>().Deletes(m => m.id == id);
        }

        [OperationBehavior(TransactionAutoComplete = true, TransactionScopeRequired = true)]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        public SystemModuleSetMealLevelPrice Edit(SystemModuleSetMealLevelPrice model)
        {
            DALBase<SystemModuleSetMealLevelPrice, DataContext> bll = new DALBase<SystemModuleSetMealLevelPrice, DataContext>();
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

        public SystemModuleSetMealLevelPrice Info(long id)
        {
            return new DALBase<SystemModuleSetMealLevelPrice, DataContext>().Info(m => m.id == id);
        }

        public SystemModuleSetMealLevelPrice InfoByLevel(int setMealId, int levelId)
        {
            return new DALBase<SystemModuleSetMealLevelPrice, DataContext>().Info(m => m.SetMealId == setMealId && m.LevelId == levelId);
        }

        public List<V_SystemModuleSetMealLevel> List(int setMealId)
        {
            Expression<Func<V_SystemModuleSetMealLevel, bool>> condition = m=>m.SetMealId == setMealId;
            List<V_SystemModuleSetMealLevel> list = new DALBase<V_SystemModuleSetMealLevel, DataContext>().List(condition, m => m.id);
            return list;
        }
    }
}
