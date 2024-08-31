using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using VueNetKKApp.Server.Context;
using VueNetKKApp.Server.DTO;
using VueNetKKApp.Server.DTO.Auth;
using VueNetKKApp.Server.Support;

namespace VueNetKKApp.Server.Controllers
{
    public class AuthController : ControllerBase
    {
        //--------------------------------------------------------------------------------------------------------------
        //                                          INSTANCE VARIABLES
        //--------------------------------------------------------------------------------------------------------------
        private readonly ILogger<AuthController> _logger;
        private IConfiguration _configuration;

        //-------------------------------------------------------------------------------------------------------------
        //                                                  //CONSTRUCTORS.
        public AuthController(ILogger<AuthController> logger, IConfiguration iConfig)
        {
            _logger = logger;
            _configuration = iConfig;
        }
        //--------------------------------------------------------------------------------------------------------------
        [HttpPost("[action]")]
        public IActionResult Login(
            [FromBody]
            LogLoginDto.In logdtoin
        )
        {
            using var context = new DonutsContext();
            ServansdtoServiceAnswerDto servansdto;

            if (
                logdtoin == null
                )
            {
                servansdto = new(
                    400,
                    "Something went wrong",
                    "Invalid client request",
                    null);
            }
            else if (
                //                                          // Validates model
                !ModelState.IsValid
                )
            {
                servansdto = new(
                    400,
                    "Information sent is not valid",
                    "Invalid Data Model",
                    ModelState);
            }
            else if (
                //                                          // Validates user
                AuthAuthentication.boolValidateUser(context, logdtoin)
                )
            {
                Claim[] claims = new[]
                {
                new Claim(JwtRegisteredClaimNames.Sub, logdtoin.strUsername),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

                SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWTSettings:Key"]));
                SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                JwtSecurityToken token = new JwtSecurityToken(
                    issuer: _configuration["JWTSettings:Issuer"],
                    audience: _configuration["JWTSettings:Audience"],
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds);

                servansdto = new(
                    200,
                    new { token = new JwtSecurityTokenHandler().WriteToken(token) }
                );
            }
            else
            {
                //                                          // User validation failed
                servansdto = new(
                    400,
                    "Incorrect username or password",
                    "Unauthorized",
                    null);
            }

            IActionResult aresult = base.Ok(servansdto);
            return aresult;
        }

        //--------------------------------------------------------------------------------------------------------------
        [HttpPost("[action]")]
        public IActionResult AddUserAuth(
            [FromBody]
            SetnewuseSetNewUserCredential.In setnewuserin
        )
        {
            // {"strName":"Fernando","strSurename":"Agraz","strUsername":"archer","strPassword": "molly"}
            ServansdtoServiceAnswerDto servansdto;
            using var context = new DonutsContext();
            using var transaction = context.Database.BeginTransaction();

            try
            {
                AuthAuthentication.subSaveNewUser(context, setnewuserin, out servansdto);
                transaction.Commit();
            }
            catch (
                Exception ex
            )
            {
                servansdto = new ServansdtoServiceAnswerDto(400,"Error while saving new user" ,ex.Message,null);
                transaction.Rollback();
            }

            IActionResult aresult = base.Ok(servansdto);
            return aresult;
        }

         //--------------------------------------------------------------------------------------------------------------
    }
}
