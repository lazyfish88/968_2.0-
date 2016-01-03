using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Ac968.SystemModuleSetMeal.Model
{
    [DataContract(Namespace = "Ac968.SystemModuleSetMeal.Model")]
    [Table("Company")]
    public class Company
    {
        [DataMember]
        [Key]
        public long CompanyId { set; get; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string Domain { set; get; }
    }
}
