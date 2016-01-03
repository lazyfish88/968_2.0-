using Ac968.SystemModuleSetMeal.Interface;
using Ac968.SystemModuleSetMeal.Model;
using Ac968.Utils.Data;
using System.Collections.Generic;
using System;

namespace Ac968.SystemModuleSetMeal.ServiceBLL
{
    public class CompanyFastModuleBLL : ICompanyFastModule
    {
        public void BatchAdd(long companyId, long userId, string moduleIds, string urls, string names)
        {
            string[] moduleIdsArr = moduleIds.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            string[] urlsArr = urls.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            string[] namesArr = names.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            DALBase<CompanyFastModule, DataContext> bll = new DALBase<CompanyFastModule, DataContext>();
            bll.Deletes(m => m.CompanyId == companyId);
            for (int i = 0; i < moduleIdsArr.Length; i++)
            {
                string[] urlsArr2 = urlsArr[i].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                string[] namesArr2 = namesArr[i].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < urlsArr2.Length; j++)
                {
                    bll.Add(new CompanyFastModule() {
                        CompanyId = companyId,
                        UserId = userId,
                        ModuleId = Convert.ToInt32(moduleIdsArr[i]),
                        Name = namesArr2[j],
                        Url = urlsArr2[j]
                    },false);
                }
            }
            bll.SaveChanges();
        }

        public void Del(long id)
        {
            new DALBase<CompanyModule, DataContext>().Deletes(m => m.id == id);
        }

        public CompanyFastModule Edit(CompanyFastModule model)
        {
            DALBase<CompanyFastModule, DataContext> bll = new DALBase<CompanyFastModule, DataContext>();
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

        public CompanyFastModule Info(long id)
        {
            return new DALBase<CompanyFastModule, DataContext>().Info(m => m.id == id);
        }

        public List<CompanyFastModule> List(long companyId)
        {
            List<CompanyFastModule> list = new DALBase<CompanyFastModule, DataContext>().List(m => m.CompanyId == companyId, m => m.id);
            return list;
        }

        public List<CompanyFastModule> ListByUser(long companyId, long userId)
        {
            List<CompanyFastModule> list = new DALBase<CompanyFastModule, DataContext>().List(m => m.CompanyId == companyId && m.UserId == userId, m => m.id);
            return list;
        }
    }
}
