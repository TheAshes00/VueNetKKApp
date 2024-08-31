using System.ComponentModel.DataAnnotations;

namespace VueNetKKApp.Server.DTO.Auth
{
    public class LogLoginDto
    {
        public class In
        {
            [Required]
            public string strUsername { get; set; }
            [Required] 
            public string strPassword { get; set; }
        }
    }
}
