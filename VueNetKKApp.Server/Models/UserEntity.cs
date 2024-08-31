using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VueNetKKApp.Server.Models
{
    [Table("Users")]
    public class UserEntity
    {
        [Key]
        [Column("Pk")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int intPk { get; set; }

        [Column("Name", TypeName = "varchar(80)")]
        public string strName { get; set; }

        [Column("Surename", TypeName = "varchar(80)")]
        public string strSurename { get; set; }

        [Column("PkAuth")]
        [ForeignKey("AuthEntity")]
        public int intPkAuth { get; set; }

        public virtual AuthEntity AuthEntity { get; set; }

    }
}