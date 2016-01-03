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
    public class CompanyModuleBLL : ICompanyModule
    {
        public CompanyModule InfoByModule(long companyId, int moduleId)
        {
            return new DALBase<CompanyModule, DataContext>().Info(m => m.CompanyId == companyId && m.ModuleId == moduleId);
        }

        public List<V_CompanyModule> List(long companyId)
        {

            Expression<Func<SystemModule, bool>> baseModuleCondition = m => m.IsDefault == true;
            List<SystemModule> baseModuleList = new DALBase<SystemModule, DataContext>().List(baseModuleCondition, m => m.id, isDesc: false);

            Expression<Func<V_CompanyModule, bool>> condition = m => m.CompanyId == companyId && m.ValidityDateEnd >= DateTime.Now && m.ValidityDateStart <= DateTime.Now;
            List<V_CompanyModule> list = new DALBase<V_CompanyModule, DataContext>().List(condition, m => m.id, isDesc: false);
            List<V_CompanyModule> newList = new List<V_CompanyModule>();
            foreach (SystemModule item in baseModuleList)
            {
                newList.Add(new V_CompanyModule()
                {
                    CompanyId = companyId,
                    IsDefault = true,
                    ModuleId = item.id,
                    Name = item.Name,
                    NeedCompany = item.NeedCompany,
                    StyleClass = item.StyleClass,
                    Type = item.Type,
                    OrderBy = item.OrderBy,
                    Url = item.Url,
                    ValidityDateEnd = DateTime.MaxValue,
                    ValidityDateStart = DateTime.Now.AddDays(-1)
                });
            }
            foreach (V_CompanyModule item in list)
            {
                if (newList.Where(m => m.ModuleId == item.ModuleId).ToArray().Length == 0)
                {
                    newList.Add(item);
                }
            }

            return newList;
        }
        [OperationBehavior(TransactionAutoComplete = true, TransactionScopeRequired = true)]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        public CompanyModule Edit(CompanyModule model)
        {
            DALBase<CompanyModule, DataContext> bll = new DALBase<CompanyModule, DataContext>();
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

        public int VerifyCheck(long companyId, long userId, int moduleId, int fnId)
        {
            //return 0;
            DALBase<CompanyModule, DataContext> bll = new DALBase<CompanyModule, DataContext>();
            CompanyModule info = bll.Info(m => m.ModuleId == moduleId && m.CompanyId == companyId);
            DALBase<SystemModule, DataContext> baseModuleBll = new DALBase<SystemModule, DataContext>();
            Expression<Func<SystemModule, bool>> baseCondition = m => m.IsDefault == true;
            List<SystemModule> baseList = baseModuleBll.List(baseCondition, m => m.id);
            Camel.ApiModel.CompanyManageUser userModule = Camel.ApiUserBLL.UserPowerExBLL.CompanyManageGet(companyId, userId);
            if (baseList.Where(m => m.id == moduleId).ToArray().Length > 0)//模块为基本模块
            {
                if (userId == 0)
                {
                    return 0;
                }
                Camel.ApiModel.UserActionType result = Camel.ApiUserBLL.UserPowerExBLL.UserPowerExGet(companyId, userId, moduleId);
                if (userModule.RoleTypeId == 1)//当前为总管理用户
                {
                    return 0;
                }
                if (result == Camel.ApiModel.UserActionType.View)//仅能查看
                {
                    return 1;
                }
                else if (result == Camel.ApiModel.UserActionType.All)//可编辑
                {
                    return 0;
                }
                else
                {
                    return -3;
                }
            }
            if (info == null)//无购买模块
            {
                return -1;
            }
            if (info.ValidityDateEnd.CompareTo(DateTime.Now) > -1 && info.ValidityDateStart.CompareTo(DateTime.Now) < 1)
            {
                if (userId == 0)
                {
                    return 0;
                }
                if (userModule.RoleTypeId == 1)//当前为总管理用户
                {
                    return 0;
                }
                Camel.ApiModel.UserActionType result = Camel.ApiUserBLL.UserPowerExBLL.UserPowerExGet(companyId, userId, moduleId);
                if (result == Camel.ApiModel.UserActionType.View)//仅能查看
                {
                    return 1;
                }
                else if (result == Camel.ApiModel.UserActionType.All)//可编辑
                {
                    return 0;
                }
                else
                {
                    return -3;
                }
            }
            else//模块过期
            {
                return -2;
            }
        }

        public List<V_CompanyModule> ListByDomain(string domain)
        {
            Company companyInfo = new DALBase<Company, DataContext>().Info(m => m.Domain == domain);
            if (companyInfo == null)
            {
                return null;
            }

            Expression<Func<SystemModule, bool>> condition1 = m => m.IsDefault == true;
            List<SystemModule> baselist = new DALBase<SystemModule, DataContext>().List(condition1, m => m.OrderBy);
            List<V_CompanyModule> newlist = new List<V_CompanyModule>();
            foreach (SystemModule item in baselist)
            {
                newlist.Add(new V_CompanyModule()
                {
                    CompanyId = companyInfo.CompanyId,
                    IsDefault = item.IsDefault,
                    ModuleId = item.id,
                    Name = item.Name,
                    NeedCompany = item.NeedCompany,
                    OrderBy = item.OrderBy,
                    StyleClass = item.StyleClass,
                    Type = item.Type,
                    Url = item.Url,
                    ValidityDateEnd = DateTime.MaxValue,
                    ValidityDateStart = DateTime.Now.AddDays(-1),
                });
            }

            Expression<Func<V_CompanyModule, bool>> condition = m => m.CompanyId == companyInfo.CompanyId && m.ValidityDateEnd >= DateTime.Now && m.ValidityDateStart <= DateTime.Now;
            List<V_CompanyModule> list = new DALBase<V_CompanyModule, DataContext>().List(condition, m => m.id);
            foreach (V_CompanyModule item in list)
            {
                if (newlist.Where(m => m.ModuleId == item.ModuleId).ToArray().Length > 0)
                {
                    continue;
                }
                newlist.Add(item);
            }
            return newlist;
        }

        public void Delete(long companyId)
        {
            new DALBase<CompanyModule, DataContext>().Deletes(m => m.CompanyId == companyId);
        }
    }
}
