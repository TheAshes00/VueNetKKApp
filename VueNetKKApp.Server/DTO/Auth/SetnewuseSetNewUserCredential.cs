using System.ComponentModel.DataAnnotations;

namespace VueNetKKApp.Server.DTO.Auth
{
    public class SetnewuseSetNewUserCredential
    {
        public class In
        {
            [Required]
            public string strPassword { get; set; }

            [Required] 
            public string strUsername { get; set; }

            [Required] 
            public string strName { get; set; }

            [Required] 
            public string strSurename { get; set; }
        }

    }
}
