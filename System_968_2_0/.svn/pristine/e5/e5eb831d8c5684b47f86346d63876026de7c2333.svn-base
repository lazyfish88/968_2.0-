using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Ac968.SystemModuleSetMeal.Model
{
    [DataContract(Namespace = "Ac968.SystemModuleSetMeal.Model")]
    [Table("V_CompanyModule")]
    public class V_CompanyModule
    {
        #region CompanyModule表
        [DataMember]
        [Key]
        public long id { set; get; }
        /// <summary>
        /// 模块ID
        /// </summary>
        [DataMember]
        public int ModuleId { set; get; }
        /// <summary>
        /// 企业ID
        /// </summary>
        [DataMember]
        public long CompanyId { set; get; }
        /// <summary>
        /// 有效期（开始）
        /// </summary>
        [DataMember]
        public DateTime ValidityDateStart { set; get; }
        /// <summary>
        /// 有效期（结束）
        /// </summary>
        [DataMember]
        public DateTime ValidityDateEnd { set; get; }
        #endregion

        #region SystemModule表
        /// <summary>
        /// 等级名称
        /// </summary>
        [DataMember]
        public string Name { set; get; }
        /// <summary>
        /// 等级名称
        /// </summary>
        [DataMember]
        public string Url { set; get; }
        /// <summary>
        /// 等级名称
        /// </summary>
        [DataMember]
        public int OrderBy { set; get; }
        /// <summary>
        /// 等级名称
        /// </summary>
        [DataMember]
        public bool IsDefault { set; get; }
        /// <summary>
        /// 菜单类型
        /// </summary>
        [DataMember]
        public int Type { set; get; }
        /// <summary>
        /// 菜单样式名
        /// </summary>
        [DataMember]
        public string StyleClass { set; get; }
        /// <summary>
        /// 是否需要认证企业
        /// </summary>
        [DataMember]
        public bool NeedCompany { set; get; }
        #endregion
    }
}
