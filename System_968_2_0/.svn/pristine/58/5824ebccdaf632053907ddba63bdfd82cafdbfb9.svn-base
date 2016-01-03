using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Ac968.SystemModuleSetMeal.Model
{
    [DataContract(Namespace = "Ac968.SystemModuleSetMeal.Model")]
    [Table("SystemModuleSetMealLevelPrice")]
    public class SystemModuleSetMealLevelPrice
    {
        [DataMember]
        [Key]
        public int id { set; get; }
        /// <summary>
        /// 套餐ID
        /// </summary>
        [DataMember]
        public int SetMealId { set; get; }
        /// <summary>
        /// 等级ID
        /// </summary>
        [DataMember]
        public int LevelId { set; get; }
        /// <summary>
        /// 价格
        /// </summary>
        [DataMember]
        public decimal Price { set; get; }
    }
}
