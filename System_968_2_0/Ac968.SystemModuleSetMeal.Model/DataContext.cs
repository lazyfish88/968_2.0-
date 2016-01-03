﻿using System.Data.Entity;

namespace Ac968.SystemModuleSetMeal.Model
{
    public class DataContext : DbContext
    {
        public DataContext()
            : this("SystemModuleDbConnection")
        { }
        public DataContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }
        public DbSet<CompanyFastModule> TPL_CompanyFastModuleAssembly { set; get; }
        public DbSet<Company> TPL_CompanyAssembly { set; get; }
        public DbSet<CompanyModule> TPL_CompanyModuleAssembly { set; get; }
        public DbSet<PlanAgentLevel> TPL_PlanAgentLevelAssembly { set; get; }
        public DbSet<SystemModule> TPL_SystemModuleAssembly { set; get; }
        public DbSet<SystemModuleSetMeal> TPL_SystemModuleSetMealAssembly { set; get; }
        public DbSet<SystemModuleSetMealDetail> TPL_SystemModuleSetMealDetailAssembly { set; get; }
        public DbSet<SystemModuleSetMealLevelPrice> TPL_SystemModuleSetMealLevelPriceAssembly { set; get; }
        public DbSet<V_CompanyModule> TPL_V_CompanyModuleAssembly { set; get; }
        public DbSet<V_SystemModuleSetMealLevel> TPL_V_SystemModuleSetMealLevelAssembly { set; get; }
        public DbSet<PlanAgentOrder> TPL_PlanAgentOrderAssembly { set; get; }
        public DbSet<V_SystemModuleSetMealDetail> TPL_V_SystemModuleSetMealDetailAssembly { set; get; }
        public DbSet<CustomApply> TPL_CustomApplyAssembly { set; get; }
        public DbSet<SystemModuleSetMealValidityLog> TPL_SystemModuleSetMealValidityLogAssembly { set; get; }
    }
}

