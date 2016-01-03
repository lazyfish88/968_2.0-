using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Ac968.SystemModuleSetMeal.Model
{
    [DataContract(Namespace = "Ac968.SystemModuleSetMeal.Model")]
    [Table("SystemModuleSetMealDetail")]
    public class SystemModuleSetMealDetail
    {
        [DataMember]
        [Key]
        public int id { set; get; }
        /// <summary>
        /// 套餐ID
        /// </summary>
        [DataMember]
        public int SystemModuleSetMealId { set; get; }
        /// <summary>
        /// 模块ID
        /// </summary>
        [DataMember]
        public int SystemModuleId { set; get; }
        /// <summary>
        /// 使用天数
        /// </summary>
        [DataMember]
        public int Day { set; get; }
    }
}
