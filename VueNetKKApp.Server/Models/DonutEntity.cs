using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VueNetKKApp.Server.Models
{
    [Table("Donut")]
    public class DonutEntity
    {
        [Key]
        [Column("Pk")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int intPk { get; set; }
        
        [Column("Type",TypeName = "varchar(45)")]
        public string strType { get; set; }

        public virtual ICollection<SaleEntity> IcSaleEntity { get; set; } = new List<SaleEntity>();
    }
}