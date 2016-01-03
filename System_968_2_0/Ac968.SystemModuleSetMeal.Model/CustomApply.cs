using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Ac968.SystemModuleSetMeal.Model
{
    [DataContract(Namespace = "Ac968.SystemModuleSetMeal.Model")]
    [Table("CustomApply")]
    public class CustomApply
    {
        [DataMember]
        [Key]
        public long id { set; get; }
        /// <summary>
        /// 企业ID
        /// </summary>
        [DataMember]
        public long CompanyId { set; get; }
        /// <summary>
        /// 联系人
        /// </summary>
        [DataMember]
        public string UserName { set; get; }
        /// <summary>
        /// 联系电话
        /// </summary>
        [DataMember]
        public string Tel { set; get; }
        /// <summary>
        /// 说明
        /// </summary>
        [DataMember]
        public string Remark { set; get; }
        /// <summary>
        /// 状态，0：未处理，1：已处理
        /// </summary>
        [DataMember]
        public int State { set; get; }
        /// <summary>
        /// 添加时间
        /// </summary>
        [DataMember]
        public DateTime AddDate { set; get; }
    }
}
