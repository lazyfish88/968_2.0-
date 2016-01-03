using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Ac968.SystemModuleSetMeal.Model
{
    [DataContract(Namespace = "Ac968.SystemModuleSetMeal.Model")]
    [Table("PlanAgentOrder")]
    public class PlanAgentOrder
    {
        [DataMember]
        [Key]
        public long id { set; get; }
        /// <summary>
        /// 订单号
        /// </summary>
        [DataMember]
        public string Sn { set; get; }
        /// <summary>
        /// 企业ID
        /// </summary>
        [DataMember]
        public long CompanyId { set; get; }
        /// <summary>
        /// 订单价格
        /// </summary>
        [DataMember]
        public decimal Price { set; get; }
        /// <summary>
        /// 状态：0=未支付，1=已支付
        /// </summary>
        [DataMember]
        public int State { set; get; }
        /// <summary>
        /// 关联ID
        /// </summary>
        [DataMember]
        public string RelationId { set; get; }
        /// <summary>
        /// 订单类型：1=套餐订单
        /// </summary>
        [DataMember]
        public int Type { set; get; }
        /// <summary>
        /// 添加时间
        /// </summary>
        [DataMember]
        public DateTime AddDate { set; get; }
        /// <summary>
        /// 订单内容
        /// </summary>
        [DataMember]
        [NotMapped]
        public string OrderContent { set; get; }
    }
}
