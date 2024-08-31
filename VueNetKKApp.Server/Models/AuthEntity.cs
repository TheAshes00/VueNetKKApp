using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http.HttpResults;

namespace VueNetKKApp.Server.Models
{
    [Table("Auth")]
    public class AuthEntity
    {
        [Key]
        [Column("Pk")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int intPk { get; set; }

        [Column("Username", TypeName = "varchar(80)")]
        public string strUsername { get; set; }

        [Column("Password", TypeName = "varchar(80)")]
        public string strPassword { get; set; }

        public virtual UserEntity UserEntity { get; set; }

        public virtual ICollection<SaleEntity> IcSaleEntity { get; set; } = new List<SaleEntity>();
    }
}