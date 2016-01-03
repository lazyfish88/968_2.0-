﻿using System;
using System.Collections.Generic;
using Ac968.SystemModuleSetMeal.Interface;
using Ac968.SystemModuleSetMeal.Model;
using Ac968.Utils.Data;
using System.Linq.Expressions;
using System.ServiceModel;

namespace Ac968.SystemModuleSetMeal.ServiceBLL
{
    public class SystemModuleSetMealBLL : ISystemModuleSetMeal
    {
        [OperationBehavior(TransactionAutoComplete = true, TransactionScopeRequired = true)]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        public void Del(int id)
        {
            new DALBase<Model.SystemModuleSetMeal, DataContext>().Deletes(m => m.id == id);
            new DALBase<Model.SystemModuleSetMealDetail, DataContext>().Deletes(m => m.SystemModuleSetMealId == id);
        }

        [OperationBehavior(TransactionAutoComplete = true, TransactionScopeRequired = true)]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        public Model.SystemModuleSetMeal Edit(Model.SystemModuleSetMeal model, string moduleIds)
        {
            DALBase<Model.SystemModuleSetMeal, DataContext> bll = new DALBase<Model.SystemModuleSetMeal, DataContext>();
            DALBase<Model.SystemModuleSetMealDetail, DataContext> detailBll = new DALBase<Model.SystemModuleSetMealDetail, DataContext>();
            if (model.id == 0)
            {
                model = bll.AddReturnModel(model);
            }
            else
            {
                bll.AddOrUpdate(model);
                detailBll.Deletes(m => m.SystemModuleSetMealId == model.id);
            }
            string[] moduleIdsArr = moduleIds.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string moduleId in moduleIdsArr)
            {
                detailBll.Add(new SystemModuleSetMealDetail() {
                    SystemModuleId = Convert.ToInt32(moduleId),
                    SystemModuleSetMealId = model.id
                },false);
            }
            detailBll.SaveChanges();
            return model;
        }

        public Model.SystemModuleSetMeal Info(int id)
        {
            return new DALBase<Model.SystemModuleSetMeal, DataContext>().Info(m => m.id == id);
        }

        public List<Model.SystemModuleSetMeal> List(int pageIndex, out int record, int pageSize = 20)
        {
            Expression<Func<Model.SystemModuleSetMeal, bool>> condition = null;
            List<Model.SystemModuleSetMeal> list = new DALBase<Model.SystemModuleSetMeal, DataContext>().List(condition, m => m.id, pageIndex, pageSize, out record);
            return list;
        }

        public List<Model.SystemModuleSetMeal> ListByEnable(bool enable, int pageIndex, out int record, int pageSize = 20)
        {
            Expression<Func<Model.SystemModuleSetMeal, bool>> condition = m => m.Enable == enable;
            List<Model.SystemModuleSetMeal> list = new DALBase<Model.SystemModuleSetMeal, DataContext>().List(condition, m => m.id, pageIndex, pageSize, out record);
            return list;
        }

        public List<Model.SystemModuleSetMeal> ListByIds(string ids)
        {
            Expression<Func<Model.SystemModuleSetMeal, bool>> condition = m => ids.Contains("," + m.id + ",");
            List<Model.SystemModuleSetMeal> list = new DALBase<Model.SystemModuleSetMeal, DataContext>().List(condition, m => m.id);
            return list;
        }
    }
}
