﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Ac968.SystemModuleSetMeal.Model
{
    [DataContract(Namespace = "Ac968.SystemModuleSetMeal.Model")]
    [Table("CompanyFastModule")]
    public class CompanyFastModule
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
        /// 名称
        /// </summary>
        [DataMember]
        public string Name { set; get; }
        /// <summary>
        /// URL地址
        /// </summary>
        [DataMember]
        public string Url { set; get; }
        /// <summary>
        /// 管理用户ID
        /// </summary>
        [DataMember]
        public long UserId { set; get; }
    }
}
