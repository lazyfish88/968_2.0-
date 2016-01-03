using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Ac968.SystemModuleSetMeal.Model
{
    [DataContract(Namespace = "Ac968.SystemModuleSetMeal.Model")]
    [Table("SystemModule")]
    public class SystemModule
    {
        [DataMember]
        [Key]
        public int id { set; get; }
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
        /// <summary>
        /// 图标
        /// </summary>
        [DataMember]
        public string Icon { set; get; }
        /// <summary>
        /// 说明地址
        /// </summary>
        [DataMember]
        public string DescriptionUrl { set; get; }

        /// <summary>
        /// 菜单状态
        /// </summary>
        [NotMapped]
        [DataMember]
        public int State { set; get; }
    }
}
