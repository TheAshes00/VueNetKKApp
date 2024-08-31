using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http.HttpResults;
using System;

namespace VueNetKKApp.Server.Models
{
    [Table("Sale")]
    public class SaleEntity
    {
        [Key]
        [Column("Pk")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int intPk { get; set; }

        [Column("Name", TypeName = "varchar(150)")]
        public string strName { get; set; }

        [Column("Address", TypeName = "varchar(250)")]
        public string strAddress { get; set; }

        [Column("Quantity")]
        public int intQuantity { get; set; }

        [Column("SaleDate", TypeName = "datetime")]
        public DateTime DateSaleDate { get; set; }

        [Column("PkAuth")]
        [ForeignKey("AuthEntity")]
        public int intPkAuth { get; set; }

        [Column("PkDonut")]
        [ForeignKey("DonutEntity")]
        public int intPkDonut { get; set; }

        public virtual DonutEntity DonutEntity { get; set; }
        public virtual AuthEntity AuthEntity { get; set; }
    }
}
