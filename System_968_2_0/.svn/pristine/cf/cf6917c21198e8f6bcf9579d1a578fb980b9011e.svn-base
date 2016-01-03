using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Ac968.SystemModuleSetMeal.Model
{
    [DataContract(Namespace = "Ac968.SystemModuleSetMeal.Model")]
    [Table("SystemModuleSetMeal")]
    public class SystemModuleSetMeal
    {
        [DataMember]
        [Key]
        public int id { set; get; }
        /// <summary>
        /// 名称
        /// </summary>
        [DataMember]
        public string Name { set; get; }
        /// <summary>
        /// 价格
        /// </summary>
        [DataMember]
        public decimal Price { set; get; }
        /// <summary>
        /// 是否启用
        /// </summary>
        [DataMember]
        public bool Enable { set; get; }
        /// <summary>
        /// 添加时间
        /// </summary>
        [DataMember]
        public DateTime AddDate { set; get; }
        /// <summary>
        /// 使用天数
        /// </summary>
        [DataMember]
        public int Day { set; get; }

        [NotMapped]
        [DataMember]
        public V_SystemModuleSetMealDetail[] ModuleList { get; set; }

        [NotMapped]
        [DataMember]
        public int CompanyState { get; set; }

        [NotMapped]
        [DataMember]
        public DateTime OverDate { get; set; }
    }
}
