using System;
using System.Collections.Generic;
using Ac968.SystemModuleSetMeal.Interface;
using Ac968.SystemModuleSetMeal.Model;
using Ac968.Utils.Data;
using System.Linq.Expressions;
using System.ServiceModel;
using System.Linq;

namespace Ac968.SystemModuleSetMeal.ServiceBLL
{
    public class SystemModuleBLL : ISystemModule
    {
        public List<SystemModule> List()
        {
            Expression<Func<SystemModule, bool>> condition = null;
            List<SystemModule> list = new DALBase<SystemModule, DataContext>().List(condition, m => m.id);
            return list;
        }

        public List<SystemModule> ListByCompany(long companyId, string domain, long userId)
        {
            Expression<Func<SystemModule, bool>> condition = null;
            List<SystemModule> list = new DALBase<SystemModule, DataContext>().List(condition, m => m.OrderBy);

            if (!string.IsNullOrEmpty(domain))
            {
                Company companyInfo = new DALBase<Company, DataContext>().Info(m => m.Domain == domain);
                if (companyInfo == null)
                {
                    return null;
                }
                companyId = companyInfo.CompanyId;
            }
            Expression<Func<CompanyModule, bool>> companyCondition = m => m.CompanyId == companyId;
            List<CompanyModule> companyList = new DALBase<CompanyModule, DataContext>().List(companyCondition, m => m.id);
            //new Camel.ApiUserBLL.UserPowerExBLL().
            Camel.ApiModel.CompanyManageUser userModule = Camel.ApiUserBLL.UserPowerExBLL.CompanyManageGet(companyId, userId);
            if (userModule==null)
            {
                return null;
            }
            foreach (SystemModule item in list)
            {
                if (userModule.RoleTypeId == 1)//超级用户
                {
                    if (item.IsDefault
                        || companyId == 1)
                    {
                        item.State = 0;
                        continue;
                    }
                    if (companyList.Where(m => m.ModuleId == item.id).ToArray().Length > 0)
                    {
                        CompanyModule existModel = companyList.Where(m => m.ModuleId == item.id).ToArray()[0];

                        if (existModel.ValidityDateEnd >= DateTime.Now && existModel.ValidityDateStart <= DateTime.Now)
                        {
                            item.State = 0;
                        }
                        else//过期
                        {
                            item.State = 1;
                        }
                    }
                    else//未开通
                    {
                        item.State = 2;
                    }
                }
                else//普通用户
                {
                    if (
                        (companyList.Where(m => m.ModuleId == item.id).ToArray().Length > 0 || item.IsDefault)//企业有模块使用权
                        && userModule._UserPowerExLst.Where(m => m.ModuleId == item.id).ToArray().Length > 0//用户仍有操作权限
                        )
                    {
                        if (item.IsDefault
                            || companyId == 1)
                        {
                            item.State = 0;
                            continue;
                        }

                        CompanyModule existModel = companyList.Where(m => m.ModuleId == item.id).ToArray()[0];
                        if (existModel.ValidityDateEnd >= DateTime.Now && existModel.ValidityDateStart <= DateTime.Now)

                        {
                            item.State = 0;
                        }
                        else//过期
                        {
                            item.State = 3;
                        }
                    }
                    else
                    {
                        item.State = 3;
                    }
                }
            }
            return list;
        }

        [OperationBehavior(TransactionAutoComplete = true, TransactionScopeRequired = true)]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        public void SetDefault(int id, bool isDefault)
        {
            Expression<Func<SystemModule, bool>> filter = m => m.id == id;
            Expression<Func<SystemModule, SystemModule>> update = m => new SystemModule { IsDefault = isDefault };
            new DALBase<SystemModule, DataContext>().Update(filter, update);
        }

        [OperationBehavior(TransactionAutoComplete = true, TransactionScopeRequired = true)]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        public void SetNeedCompany(int id, bool needCompany)
        {
            Expression<Func<SystemModule, bool>> filter = m => m.id == id;
            Expression<Func<SystemModule, SystemModule>> update = m => new SystemModule { NeedCompany = needCompany };
            new DALBase<SystemModule, DataContext>().Update(filter, update);
        }
    }
}
