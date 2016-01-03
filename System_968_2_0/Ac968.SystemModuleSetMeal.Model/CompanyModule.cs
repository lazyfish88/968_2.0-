using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Ac968.SystemModuleSetMeal.Model
{
    [DataContract(Namespace = "Ac968.SystemModuleSetMeal.Model")]
    [Table("CompanyModule")]
    public class CompanyModule
    {
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
    }
}
