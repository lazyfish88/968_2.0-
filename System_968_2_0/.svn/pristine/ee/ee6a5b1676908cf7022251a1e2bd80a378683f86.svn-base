using Ac968.SystemModuleSetMeal.Interface;
using Ac968.SystemModuleSetMeal.Model;
using Ac968.Utils.Data;
using System.Collections.Generic;
using System;
using System.Linq.Expressions;

namespace Ac968.SystemModuleSetMeal.ServiceBLL
{
    public class CustomApplyBLL : ICustomApply
    {
        public CustomApply Edit(CustomApply model)
        {
            DALBase<CustomApply, DataContext> bll = new DALBase<CustomApply, DataContext>();
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

        public List<CustomApply> List(int pageIndex, out int record, int pageSize = 20)
        {
            Expression<Func<CustomApply, bool>> condition = null;
            List<CustomApply> list = new DALBase<CustomApply, DataContext>().List(condition, m => m.id, pageIndex, pageSize, out record);
            return list;
        }

        public void UpdateState(long id, int state)
        {
            Expression<Func<CustomApply, bool>> filter = m => m.id == id;
            Expression<Func<CustomApply, CustomApply>> update = m => new CustomApply { State = state };
            new DALBase<CustomApply, DataContext>().Update(filter, update);
        }
    }
}
