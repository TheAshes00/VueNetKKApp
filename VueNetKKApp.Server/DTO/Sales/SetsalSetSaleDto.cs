using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using VueNetKKApp.Server.Context;
using VueNetKKApp.Server.DAO;
using VueNetKKApp.Server.Models;

namespace VueNetKKApp.Server.DTO.Sales
{
    public class SetsalSetSaleDto
    {
        public class In
        {
            [Required]
            public string strName { get; set; }

            [Required]
            public string strAddress { get; set; }

            [Required]
            [Range(1, int.MaxValue)]
            public int intPkDonut { get; set; }

            [Required]
            [Range(1, int.MaxValue)]
            public int intDonutsBought { get; set; }

            [Required]
            public string strUsername {  get; set; }

        }

    }
}
